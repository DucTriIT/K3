namespace GoldRT
{
    partial class frmViewReport
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
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "KatzkinReports.All_Star.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(661, 657);
            this.ReportViewer1.TabIndex = 0;
            this.ReportViewer1.Resize += crystalReportViewer1_Resize;
            // 
            // frmViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(747, 534);
            this.Controls.Add(this.ReportViewer1);
            this.Name = "frmViewReport";
            this.ShowIcon = false;
            this.Text = "Xem báo cáo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmViewReport_Load);
            this.ResumeLayout(false);

        }     

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
    }
}