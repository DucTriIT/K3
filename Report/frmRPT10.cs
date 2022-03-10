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
    public partial class frmRPT10 : DevExpress.XtraEditors.XtraForm
    {

        private string mvarReportCode;

        public frmRPT10()
        {
            InitializeComponent();
        }

        public frmRPT10(string pReportCode)
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
                ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
                Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
                ds.Clear();

                ds = clsCommon.LoadComboSP("T_SUPPLIER", "");
                Functions.BindDropDownList(cboNCC, ds, "SupplierName", "SupplierID", "", true);
                ds.Clear();
            }
            catch
            {
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strFromDate = "", strToDate = "", strEmpName = "", strEmpID = "",strLoai="", strParams, strValues;

            strFromDate = ((DateTime)dtpTuNgay.EditValue).ToString("dd/MM/yyyy");
            strToDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");

            strEmpName = ((ItemList)cboProductGroup.SelectedItem).Value;
            strEmpID = ((ItemList)cboProductGroup.SelectedItem).ID;
            strLoai = (ItemList)cboNCC.SelectedItem == null ? "" : ((ItemList)cboNCC.SelectedItem).ID;
            strParams = "EmpName@TuNgay@DenNgay";
            strValues = strEmpName + "@" + strFromDate + "@" + strToDate;

            switch (mvarReportCode)
            {
                case "rptBC011":
                    ds = clsCommon.ExecuteDatasetSP("rptBC011", strEmpID, strLoai, strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC401.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC011.rpt", strParams, strValues);
                    break;
               
            }            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmRPT10_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            f_loadDataToCombo();
            switch (mvarReportCode)
            {

                case "rptBC011":
                    this.Text = "BC011 - Nhật ký thay đổi tiền công theo nhóm hàng";
                    lblReport.Text = "BC011 - Nhật ký thay đổi tiền công theo nhóm hàng";
                    break;
              
            }
        }

        

       
    }
}
