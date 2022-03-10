using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;

namespace GoldRT
{
    public partial class frmRPT08 : DevExpress.XtraEditors.XtraForm
    {

        private string mvarReportCode;
        private string strParam = "";
        public frmRPT08()
        {
            InitializeComponent();
        }

        public frmRPT08(string pReportCode)
        {
            InitializeComponent();
            mvarReportCode = pReportCode;
        }
        public frmRPT08(string pReportCode, string pParam)
        {
            InitializeComponent();
            mvarReportCode = pReportCode;
            strParam = pParam;
        }

        private void fn_LoadDefault()
        {
            dtpTuNgay.EditValue = DateTime.Now;
            dtpDenNgay.EditValue = DateTime.Now;
        }

        private void f_loadDataToCombo()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.LoadComboSP("T_Worker", "");
                Functions.BindDropDownList(cboWorker, ds, "WorkerName", "WorkerID", "", true, "Tất cả", "");
                ds.Clear();
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strFromDate = "", strToDate = "", strWorkerName = "", strWorkerID = "", strParams, strValues;

            strFromDate = ((DateTime)dtpTuNgay.EditValue).ToString("dd/MM/yyyy");
            strToDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");

            strWorkerName = ((ItemList)cboWorker.SelectedItem).Value;
            strWorkerID = ((ItemList)cboWorker.SelectedItem).ID;

            strParams = "WorkerName@TuNgay@DenNgay";
            strValues = strWorkerName + "@" + strFromDate + "@" + strToDate;

            switch (mvarReportCode)
            {
                case "BC300":
                    ds = clsCommon.ExecuteDatasetSP("rptBC300", strWorkerID, strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC401.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC300.rpt", strParams, strValues);
                    break;
                case "rptHis":
                    //strParams = "TuNgay@DenNgay";
                    //strValues = dtpFromDate.DateTime.ToString("dd/MM/yyyy") + "@" + dtpToDate.DateTime.ToString("dd/MM/yyyy");

                    ds = clsCommon.ExecuteDatasetSP("rptHisPayWorker", strParam, strFromDate, strToDate);
                    Functions.fn_ShowReport_AndImage(ds, "rptHisPayWorker.rpt", strParams, strValues);
                    break;
                
            }            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRPT08_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            f_loadDataToCombo();
            switch (mvarReportCode)
            {

                case "BC300":
                    this.Text = "BC300 - Báo cáo giao dịch thợ";
                    lblReport.Text = "BC300 - Báo cáo giao dịch thợ";
                    break;
                case "rptHis":
                    this.Text = "Lịch sử thanh toán tiền công thợ";
                    cboWorker.Visible = false;
                    labelControl3.Visible = false;
                    lblReport.Text = "Lịch sử thanh toán tiền công thợ";
                    break;
    
              
            }
        }

       

       
    }
}
