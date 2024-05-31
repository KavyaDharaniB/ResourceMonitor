using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceMonitor
{
    public partial class UI : Form
    {
        private ResourceMonitor resourceMonitor;       
        string directoryPath;
        public UI()
        {
            InitializeComponent();
            StopMonitor.Enabled = false;
            StartMonitor.Enabled = true;
            ExportData.Enabled = false;            
        }

        private void StopMonitor_Click(object sender, EventArgs e)
        {  
            resourceMonitor?.StopMonitoring();
            StopMonitor.Enabled = false;
            StartMonitor.Enabled = true;
            ExportData.Enabled = false;
        }

        private void StartMonitor_Click(object sender, EventArgs e)
        {
            string processNames = InputProcesses.Text;
            directoryPath = txtBoxExportDataDirectory.Text.Trim();
            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("Invalid export data directory path.");
                return;
            }
            resourceMonitor = new ResourceMonitor(processNames, directoryPath);
            resourceMonitor.StartMonitoring();
            StopMonitor.Enabled = true;
            StartMonitor.Enabled = false;
            ExportData.Enabled = true;
        }

        private void ExportData_Click(object sender, EventArgs e)
        {  
            resourceMonitor.ExportDataToCsv();            
        }
    }
}
