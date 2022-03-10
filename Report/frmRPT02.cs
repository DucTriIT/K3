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
    public partial class frmRPT02 : DevExpress.XtraEditors.XtraForm
    {

        private string mvarReportCode;

        public frmRPT02()
        {
            InitializeComponent();
        }

        public frmRPT02(string pReportCode)
        {
            InitializeComponent();
            mvarReportCode = pReportCode;
        }


        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("I_GOLD", "G");
                Functions.BindDropDownList(cboGoldCode, ds, "GoldDesc", "GoldCode", "", true, "--- Tất cả ---", "");
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
            string strGoldCode = "", strGoldDesc = "", strParams, strValues;

            strGoldDesc = ((ItemList)cboGoldCode.SelectedItem).Value;
            strGoldCode = ((ItemList)cboGoldCode.SelectedItem).ID;

            strParams = "GoldDesc";
            strValues = strGoldDesc;

            switch (mvarReportCode)
            {
                case "BC002":
                    ds = clsCommon.ExecuteDatasetSP("rptBC002", strGoldCode);
                    Functions.fn_ShowReport(ds, "rptBC002.rpt", strParams, strValues);
                    break;
                case "BC004":
                    ds = clsCommon.ExecuteDatasetSP("rptBC004", strGoldCode);
                    Functions.fn_ShowReport(ds, "rptBC004.rpt", strParams, strValues);
                    break;
            }            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRPT01_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();

            switch (mvarReportCode)
            {
                case "BC002":
                    this.Text = "BC002 - Danh sách hàng tồn theo loại vàng";
                    lblReport.Text = "BC002 - Danh sách hàng tồn theo loại vàng";
                    break;
                case "BC004":
                    this.Text = "BC004 - Thống kê hàng tồn theo Loại vàng ";
                    lblReport.Text = "BC004 - Thống kê hàng tồn theo Loại vàng";
                    break;
            }
        }

       
    }
}