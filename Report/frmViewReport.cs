using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace GoldRT
{
    public partial class frmViewReport : Form
    {
        public frmViewReport()
        {
            InitializeComponent();
        }

        public ReportDocument Report = new ReportDocument();
        public ParameterFields pfs = new ParameterFields();
        private int ZoomSize = 100;

        public frmViewReport(int _ZoomSize)
        {
            InitializeComponent();
            ZoomSize = _ZoomSize;
        }

        private void frmViewReport_Load(object sender, EventArgs e)
        {            
            crystalReportViewer1.ReportSource = Report;
            crystalReportViewer1.ParameterFieldInfo = pfs;
            crystalReportViewer1.Zoom(ZoomSize);
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Resize(object sender, EventArgs e)
        {
            crystalReportViewer1.Refresh();
        }

    }
}