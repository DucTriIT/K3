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
    public partial class frmRPT01 : DevExpress.XtraEditors.XtraForm
    {

        private string mvarReportCode;

        public frmRPT01()
        {
            InitializeComponent();
        }

        public frmRPT01(string pReportCode)
        {
            InitializeComponent();
            mvarReportCode = pReportCode;
        }


        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("T_MAINSECTION", null);
                Functions.BindDropDownList(cboMainSection, ds, "MainSectionName", "MainSectionID", "", true, "--- Tất cả ---", "");
                ds.Clear();

                ds = clsCommon.LoadComboSP("T_SECTION", null);
                Functions.BindDropDownList(cboSection, ds, "SectionName", "SectionID", "", true, "--- Tất cả ---", "");
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
            string strSectionID = "", strSectionName = "", strParams, strValues;
            string strMainSectionID = "", strMainSectionName = "";

            strSectionName = ((ItemList)cboSection.SelectedItem).Value;
            strSectionID = ((ItemList)cboSection.SelectedItem).ID;
            strMainSectionID = ((ItemList)cboMainSection.SelectedItem).ID;
            strMainSectionName = ((ItemList)cboMainSection.SelectedItem).Value;

            strParams = "SectionName@MainSectionName";
            strValues = strSectionName + "@" + strMainSectionName;

            switch (mvarReportCode)
            {
                case "BC001":
                    ds = clsCommon.ExecuteDatasetSP("rptBC001", strMainSectionID, strSectionID);
                    //Functions.fn_ShowReport(ds, "rptBC001.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC001.rpt", strParams, strValues);
                    break;
                case "BC003":
                    ds = clsCommon.ExecuteDatasetSP("rptBC003", strMainSectionID, strSectionID);
                   // Functions.fn_ShowReport(ds, "rptBC003.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC003.rpt", strParams, strValues);
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
                case "BC001":
                    this.Text = "BC001 - Danh sách hàng tồn theo Quầy";
                    lblReport.Text = "BC001 - Danh sách hàng tồn theo Quầy";
                    break;
                case "BC003":
                    this.Text = "BC003 - Thống kê hàng tồn theo Quầy";
                    lblReport.Text = "BC003 - Thống kê hàng tồn theo Quầy";
                    break;
            }
        }

        private void cboMainSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                string strMainSectionID = ((ItemList)cboMainSection.SelectedItem).ID;

                ds = clsCommon.LoadComboSP("T_SECTION", strMainSectionID);
                Functions.BindDropDownList(cboSection, ds, "SectionName", "SectionID", "", true, "--- Tất cả ---", "");
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

       
    }
}