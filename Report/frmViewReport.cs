using Microsoft.Reporting.WinForms;
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

        private int ZoomSize = 100;
        private DataSet DsReport;

        public frmViewReport(int _ZoomSize)
        {
            InitializeComponent();
            ZoomSize = _ZoomSize;
        }

        private void frmViewReport_Load(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (e.ReportPath == "BillThanhToanDetail"|| e.ReportPath == "BillBepDetail"|| e.ReportPath == "BillTraBepDetail")
            {
                ReportDataSource ds = new ReportDataSource("DataSet1", DsReport.Tables[1]);
                e.DataSources.Add(ds);
            }
        }

        private void crystalReportViewer1_Resize(object sender, EventArgs e)
        {
            ReportViewer1.Refresh();
        }
        public void SetReport(string pReportName, DataSet dsReport, string sParams = "", string sValues = "")
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.PageCountMode = PageCountMode.Actual;
            var pfs = new List<ReportParameter>();

            string strReportPath;
            strReportPath = "SuperX.Report.Reports." + pReportName;
            ReportViewer1.LocalReport.ReportEmbeddedResource = strReportPath;

            //Load parameter
            pfs.Add(new ReportParameter("NGUOILAP", clsSystem.FullName));
            pfs.Add(new ReportParameter("NGAYLAP", DateTime.Now.ToString("dd/MM/yyyy")));
            pfs.Add(new ReportParameter("SHOPNAME", clsSystem.ShopName));
            pfs.Add(new ReportParameter("SHOPADDRESS", clsSystem.ShopAddress));
            pfs.Add(new ReportParameter("SHOPTEL", clsSystem.ShopTel));
            pfs.Add(new ReportParameter("UNIT", clsSystem.UnitWeight));

            if (sParams != "" && sValues != "")
            {
                //Cac param khac        
                string[] aParams = sParams.Split('@');
                string[] aValues = sValues.Split('@');
                for (int j = 0; j < aParams.Length; j++)
                {
                    pfs.Add(new ReportParameter(aParams[j], aValues[j].ToString()));
                }
            }
            if (pfs != null)
            {
                ReportViewer1.LocalReport.SetParameters(pfs);
            }
            DsReport = dsReport;
            //end Load parameter
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DsReport.Tables[0]));
            ReportViewer1.RefreshReport();
        }

    }
}