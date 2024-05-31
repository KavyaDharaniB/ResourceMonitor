using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ResourceMonitor
{
    public class ResourceMonitor
    {
        private List<string> processNames;
        private bool monitorAll;
        private CancellationTokenSource cancellationTokenSource;
        private Dictionary<string, List<float>> cpuUsages;
        private Dictionary<string, List<long>> memoryUsages;
        private DateTime monitorStartTime;
        private System.Timers.Timer exportTimer;
        private string exportDirectory;

        public ResourceMonitor(string processNames, string exportDirectory)
        {
            this.processNames = processNames.Split(',').Select(p => p.Trim()).ToList();
            this.monitorAll = this.processNames.Contains("all", StringComparer.OrdinalIgnoreCase);
            this.cpuUsages = new Dictionary<string, List<float>>();
            this.memoryUsages = new Dictionary<string, List<long>>();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.exportDirectory = exportDirectory;

            // Initialize the timer
            exportTimer = new System.Timers.Timer(3600000); // 1 hour in milliseconds
            exportTimer.Elapsed += OnTimedEvent;
            exportTimer.AutoReset = true;
        }

        public void StartMonitoring()
        {
            monitorStartTime = DateTime.Now;
            var processes = monitorAll ? Process.GetProcesses() : processNames.SelectMany(name => Process.GetProcessesByName(name)).ToArray();

            // Initialize dictionaries for each process
            foreach (var process in processes)
            {
                if (!cpuUsages.ContainsKey(process.ProcessName))
                {
                    cpuUsages[process.ProcessName] = new List<float>();
                    memoryUsages[process.ProcessName] = new List<long>();
                }
            }

            // Start the monitoring task
            Task.Run(async () =>
            {
                await MonitorProcessesAsync(this.cancellationTokenSource.Token, processes);
            });

            // Start the export timer
            exportTimer.Start();
        }

        public void StopMonitoring()
        {
            this.cancellationTokenSource.Cancel();
            exportTimer.Stop();
            ExportDataToCsv();
        }

        private async Task MonitorProcessesAsync(CancellationToken cancellationToken, Process[] processes)
        {
            var perfCounters = new Dictionary<string, PerformanceCounter>();
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    foreach (var process in processes)
                    {
                        if (!perfCounters.ContainsKey(process.ProcessName))
                        {
                            perfCounters[process.ProcessName] = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                        }

                        float cpuUsage = perfCounters[process.ProcessName].NextValue() / Environment.ProcessorCount;
                        long memoryUsage = process.WorkingSet64;

                        cpuUsages[process.ProcessName].Add(cpuUsage);
                        memoryUsages[process.ProcessName].Add(memoryUsage);
                    }

                    await Task.Delay(5000);
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("does not exist in the specified Category"))
                {
                    MessageBox.Show("Error monitoring processes: " + ex.Message);
                }
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {            
            ExportDataToCsv();
        }

        public void ExportDataToCsv()
        {
            string fileName = Path.Combine(exportDirectory, $"ResourceMonitor_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
            var csvLines = new List<string>
        {
            "Process Name, Monitor Start Time, Export Time, Average CPU Utilization (%), Highest CPU Utilization (%), Average Memory Usage (MB), Highest Memory Usage (MB) "
        };

            foreach (var entry in cpuUsages)
            {
                var processName = entry.Key;
                var cpuUsageData = entry.Value;
                var memoryUsageData = memoryUsages[processName];
                var averageCpuUsage = cpuUsageData.Average();
                var highestCpuUsage = cpuUsageData.Max();
                var averageMemoryUsage = memoryUsageData.Average() / (1024 * 1024); // Convert to MB
                var highestMemoryUsage = memoryUsageData.Max() / (1024 * 1024); // Convert to MB
                var exportTime = DateTime.Now;

                csvLines.Add($"{processName}, {monitorStartTime}, {exportTime}, {averageCpuUsage:F2}, {highestCpuUsage:F2}, {averageMemoryUsage:F2}, {highestMemoryUsage:F2}");
            }

            File.WriteAllLines(fileName, csvLines);

            MessageBox.Show("Data exported to " + fileName);
        }
    }
}
