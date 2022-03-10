using System;
using System.Data;

namespace GoldRT
{
    public partial class frmRPT04 : DevExpress.XtraEditors.XtraForm
    {

        private string mvarReportCode;

        public frmRPT04()
        {
            InitializeComponent();
        }

        public frmRPT04(string pReportCode)
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

        private void fn_LoadDefault()
        {
            dtpTuNgay.EditValue = DateTime.Now;
            dtpDenNgay.EditValue = DateTime.Now;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strFromDate = "", strToDate = "";
            string strMainSectionID = "", strMainSectionName = "", strSectionID = "", strSectionName = "";
            string strParams, strValues;

            strFromDate = ((DateTime)dtpTuNgay.EditValue).ToString("dd/MM/yyyy");
            strToDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");

            strMainSectionID = ((ItemList)cboMainSection.SelectedItem).ID;
            strMainSectionName = ((ItemList)cboMainSection.SelectedItem).Value;
            strSectionID = ((ItemList)cboSection.SelectedItem).ID;
            strSectionName = ((ItemList)cboSection.SelectedItem).Value;

            strParams = "TuNgay@DenNgay@MainSectionName@SectionName";
            strValues = strFromDate + "@" + strToDate + "@" + strMainSectionName + "@" + strSectionName;

            switch (mvarReportCode)
            {
                case "BC005":
                    ds = clsCommon.ExecuteDatasetSP("rptBC005", strMainSectionID, strSectionID, strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC005.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC005.rpt", strParams, strValues);
                    break;
                case "BC006":
                    ds = clsCommon.ExecuteDatasetSP("rptBC006", strMainSectionID, strSectionID, strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC006.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC006.rpt", strParams, strValues);
                    break;
                case "BC008":
                    if (clsSystem.IsPO == true)
                    {
                        ds = clsCommon.ExecuteDatasetSP("rptBC008", strMainSectionID, strSectionID, strFromDate, strToDate);
                        //Functions.fn_ShowReport(ds, "rptBC008.rpt", strParams, strValues);
                        Functions.fn_ShowReport_AndImage(ds, "rptBC008.rpt", strParams, strValues);
                    }
                    else
                    {
                        ds = clsCommon.ExecuteDatasetSP("rptBC008", strMainSectionID, strSectionID, strFromDate, strToDate);
                        //Functions.fn_ShowReport(ds, "rptBC008_1.rpt", strParams, strValues);
                        Functions.fn_ShowReport_AndImage(ds, "rptBC008_1.rpt", strParams, strValues);
                    }
                    break;
                case "BC005_":
                    ds = clsCommon.ExecuteDatasetSP("rptBC005_", strMainSectionID, strSectionID, strFromDate, strToDate);
                    
                    Functions.fn_ShowReport_AndImage(ds, "rptBC005_.rpt", strParams, strValues);
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
                case "BC005":
                    this.Text = "BC005 - Danh sách nhập hàng trước khi duyệt";
                    lblReport.Text = "BC005 - Danh sách nhập hàng trước khi duyệt";
                    break;
                case "BC006":
                    this.Text = "BC006 - Danh sách nhập hàng sau khi duyệt";
                    lblReport.Text = "BC006 - Danh sách nhập hàng sau khi duyệt";
                    break;
                case "BC008":
                    this.Text = "BC008 - Báo cáo xuất nhập hàng tồn theo quầy";
                    lblReport.Text = "BC008 - Báo cáo xuất nhập hàng tồn theo quầy";
                    break;
                case "BC005_":
                    this.Text = "BC012-Báo cáo xuất hàng sau khi duyệt";
                    lblReport.Text = "BC012-Báo cáo xuất hàng trước khi duyệt ";
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
