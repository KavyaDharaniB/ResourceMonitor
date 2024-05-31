
using System;

namespace ResourceMonitor
{
    partial class UI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputProcesses = new System.Windows.Forms.TextBox();
            this.StartMonitor = new System.Windows.Forms.Button();
            this.StopMonitor = new System.Windows.Forms.Button();
            this.ExportData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxExportDataDirectory = new System.Windows.Forms.TextBox();
            this.ExportDataDirectory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputProcesses
            // 
            this.InputProcesses.Location = new System.Drawing.Point(186, 38);
            this.InputProcesses.Name = "InputProcesses";
            this.InputProcesses.Size = new System.Drawing.Size(527, 22);
            this.InputProcesses.TabIndex = 0;
            // 
            // StartMonitor
            // 
            this.StartMonitor.Location = new System.Drawing.Point(28, 300);
            this.StartMonitor.Name = "StartMonitor";
            this.StartMonitor.Size = new System.Drawing.Size(103, 37);
            this.StartMonitor.TabIndex = 2;
            this.StartMonitor.Text = "Start";
            this.StartMonitor.UseVisualStyleBackColor = true;
            this.StartMonitor.Click += new System.EventHandler(this.StartMonitor_Click);
            // 
            // StopMonitor
            // 
            this.StopMonitor.Location = new System.Drawing.Point(187, 300);
            this.StopMonitor.Name = "StopMonitor";
            this.StopMonitor.Size = new System.Drawing.Size(103, 37);
            this.StopMonitor.TabIndex = 3;
            this.StopMonitor.Text = "Stop";
            this.StopMonitor.UseVisualStyleBackColor = true;
            this.StopMonitor.Click += new System.EventHandler(this.StopMonitor_Click);
            // 
            // ExportData
            // 
            this.ExportData.Location = new System.Drawing.Point(608, 300);
            this.ExportData.Name = "ExportData";
            this.ExportData.Size = new System.Drawing.Size(154, 37);
            this.ExportData.TabIndex = 4;
            this.ExportData.Text = "Export Data";
            this.ExportData.UseVisualStyleBackColor = true;
            this.ExportData.Click += new System.EventHandler(this.ExportData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Process";
            // 
            // txtBoxExportDataDirectory
            // 
            this.txtBoxExportDataDirectory.Location = new System.Drawing.Point(186, 94);
            this.txtBoxExportDataDirectory.Name = "txtBoxExportDataDirectory";
            this.txtBoxExportDataDirectory.Size = new System.Drawing.Size(527, 22);
            this.txtBoxExportDataDirectory.TabIndex = 6;
            // 
            // ExportDataDirectory
            // 
            this.ExportDataDirectory.AutoSize = true;
            this.ExportDataDirectory.Location = new System.Drawing.Point(40, 94);
            this.ExportDataDirectory.Name = "ExportDataDirectory";
            this.ExportDataDirectory.Size = new System.Drawing.Size(143, 17);
            this.ExportDataDirectory.TabIndex = 7;
            this.ExportDataDirectory.Text = "Export Data Directory";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 368);
            this.Controls.Add(this.ExportDataDirectory);
            this.Controls.Add(this.txtBoxExportDataDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportData);
            this.Controls.Add(this.StopMonitor);
            this.Controls.Add(this.StartMonitor);
            this.Controls.Add(this.InputProcesses);
            this.Name = "UI";
            this.Text = "Resource Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputProcesses;
        private System.Windows.Forms.Button StartMonitor;
        private System.Windows.Forms.Button StopMonitor;
        private System.Windows.Forms.Button ExportData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxExportDataDirectory;
        private System.Windows.Forms.Label ExportDataDirectory;
    }
}

