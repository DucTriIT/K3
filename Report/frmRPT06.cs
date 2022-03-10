using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GoldRT
{
    public partial class frmRPT06 : DevExpress.XtraEditors.XtraForm
    {

        private string mvarReportCode;

        public frmRPT06()
        {
            InitializeComponent();
        }

        public frmRPT06(string pReportCode)
        {
            InitializeComponent();
            mvarReportCode = pReportCode;
        }
        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("T_TILL", null);
                Functions.BindDropDownList(cboTill, ds, "TillName", "TillID", "", true, "Tất cả", "");
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

        private void fn_LoadDefault()
        {
            dtpDenNgay.EditValue = DateTime.Now;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strDate = "";
            string strTillID = "", strTillName = "";
            string strParams, strValues;

            strDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");

            strTillID = ((ItemList)cboTill.SelectedItem).ID;
            strTillName = ((ItemList)cboTill.SelectedItem).Value;

            strParams = "TillName@Ngay";
            strValues = strTillName + "@" + strDate;

            switch (mvarReportCode)
            {
                case "BC105":
                    ds = clsCommon.ExecuteDatasetSP("rptBC105", strTillID, strDate);
                    //Functions.fn_ShowReport(ds, "rptBC105.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC105.rpt", strParams, strValues);
                    break;
            }            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRPT01_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            fn_LoadDataToCombo();

            switch (mvarReportCode)
            {
                case "BC105":
                    this.Text = "BC005 - Báo cáo số dư cuối ngày";
                    lblReport.Text = "BC005 - Báo cáo số dư cuối ngày";
                    break;
            }
        }
    }
}
