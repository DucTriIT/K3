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
    public partial class frmRPT05 : DevExpress.XtraEditors.XtraForm
    {

        private string mvarReportCode;

        public frmRPT05()
        {
            InitializeComponent();
        }

        public frmRPT05(string pReportCode)
        {
            InitializeComponent();
            mvarReportCode = pReportCode;
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
                ds = clsCommon.LoadComboSP("T_EMPLOYEE", "");
                Functions.BindDropDownList(cboEmp, ds, "EmpName", "EmpID", "", true, "Tất cả", "");
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
            string strFromDate = "", strToDate = "", strEmpName = "", strEmpID = "", strParams, strValues;

            strFromDate = ((DateTime)dtpTuNgay.EditValue).ToString("dd/MM/yyyy");
            strToDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");

            strEmpName = ((ItemList)cboEmp.SelectedItem).Value;
            strEmpID = ((ItemList)cboEmp.SelectedItem).ID;

            strParams = "EmpName@TuNgay@DenNgay";
            strValues = strEmpName + "@" + strFromDate + "@" + strToDate;

            switch (mvarReportCode)
            {
                case "BC401":
                    ds = clsCommon.ExecuteDatasetSP("rptBC401", strEmpID, strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC401.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC401.rpt", strParams, strValues);
                    break;
                case "BC402":
                    ds = clsCommon.ExecuteDatasetSP("rptBC402", strEmpID, strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC402.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC402.rpt", strParams, strValues);
                    break;
            }            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRPT05_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            f_loadDataToCombo();
            switch (mvarReportCode)
            {

                case "BC401":
                    this.Text = "BC401 - Báo cáo nhân viên bán hàng trong ngày";
                    lblReport.Text = "BC401 - Báo cáo nhân viên bán hàng trong ngày";
                    break;
                case "BC402":
                    this.Text = "BC402 - Doanh số nhân viên bán hàng trong tháng";
                    lblReport.Text = "BC402 - Doanh số nhân viên bán hàng trong tháng";
                    break;
            }
        }

       
    }
}
