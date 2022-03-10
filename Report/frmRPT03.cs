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
    public partial class frmRPT03 : DevExpress.XtraEditors.XtraForm
    {

        private string mvarReportCode;

        public frmRPT03()
        {
            InitializeComponent();
        }

        public frmRPT03(string pReportCode)
        {
            InitializeComponent();
            mvarReportCode = pReportCode;
        }
        private void fn_LoadToComboo()
        {
            DataSet ds = new DataSet();       
            try
            {
                
                ds = clsCommon.LoadComboSP("I_CUSTOMER","ALL");
                Functions.BindDropDownList(cboCustID, ds, "CustName", "CustID", "", true, "--- Tất cả ---", "");
            }
            catch { }
            finally { ds.Dispose(); }

        }
        private void fn_LoadDefault()
        {
            dtpTuNgay.EditValue = DateTime.Now;
            dtpDenNgay.EditValue = DateTime.Now;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strFromDate = "", strToDate = "", strGoldDesc = "", strParams, strValues;

            strFromDate = ((DateTime)dtpTuNgay.EditValue).ToString("dd/MM/yyyy");
            strToDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");

            //strGoldDesc = ((ItemList)cboGoldCode.SelectedItem).Value;
            //strGoldCode = ((ItemList)cboGoldCode.SelectedItem).ID;
            
            strParams = "GoldDesc@TuNgay@DenNgay";
            strValues = strGoldDesc + "@" + strFromDate + "@" + strToDate;

            switch (mvarReportCode)
            {
                case "BC007":
                    if (clsSystem.IsPO == true)
                    {
                        ds = clsCommon.ExecuteDatasetSP("rptBC007", strFromDate, strToDate);
                        //Functions.fn_ShowReport(ds, "rptBC007.rpt", strParams, strValues);
                        Functions.fn_ShowReport_AndImage(ds, "rptBC007.rpt", strParams, strValues);
                    }
                    else
                    {
                        ds = clsCommon.ExecuteDatasetSP("rptBC007", strFromDate, strToDate);
                       // Functions.fn_ShowReport(ds, "rptBC007_1.rpt", strParams, strValues);
                        Functions.fn_ShowReport_AndImage(ds, "rptBC007_1.rpt", strParams, strValues);
                    }
                    break;
                case "BC008":
                    ds = clsCommon.ExecuteDatasetSP("rptBC008", strFromDate, strToDate);
                    Functions.fn_ShowReport(ds, "rptBC008.rpt", strParams, strValues);
                    break;
                case "BC101":
                    ds = clsCommon.ExecuteDatasetSP("rptBC101", strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC101.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC101.rpt", strParams, strValues);
                    break;
                case "BC102":
                    ds = clsCommon.ExecuteDatasetSP("rptBC102", strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC102.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC102.rpt", strParams, strValues);
                    break;
                case "BC103":
                    ds = clsCommon.ExecuteDatasetSP("rptBC103", strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC103.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC103.rpt", strParams, strValues);
                    break;
                case "BC201":
                    ds = clsCommon.ExecuteDatasetSP("rptBC201", strFromDate, strToDate);
                   // Functions.fn_ShowReport(ds, "rptBC201.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC201.rpt", strParams, strValues);
                    break;
                case "BC104":
                    ds = clsCommon.ExecuteDatasetSP("rptBC104", strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC104.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC104.rpt", strParams, strValues);
                    break;
                case "BC106":
                    ds = clsCommon.ExecuteDatasetSP("rptBC106", strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC106.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC106.rpt", strParams, strValues);
                    break;
                case "rptBC009":
                    ds = clsCommon.ExecuteDatasetSP("rptBC009", strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC106.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC009.rpt", strParams, strValues);
                    break;
                case "BC107":
                    ds = clsCommon.ExecuteDatasetSP("rptBC107", strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC106.rpt", strParams, strValues);
                    Functions.fn_ShowReport(ds, "rptBC107.rpt", strParams, strValues);
                    break;
                case "BC203":
                    strParams +="@CustName";
                    strValues = strGoldDesc + "@" + strFromDate + "@" + strToDate+"@"+((ItemList)cboCustID.SelectedItem).Value;
                    ds = clsCommon.ExecuteDatasetSP("rptBCCNKH",((ItemList)cboCustID.SelectedItem).ID, strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC106.rpt", strParams, strValues);
                    Functions.fn_ShowReport(ds, "BCCNKH.rpt", strParams, strValues);
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
            fn_LoadToComboo();
            switch (mvarReportCode)
            {

                case "BC007":
                    this.Text = "BC007 - Báo cáo xuất nhập hàng tồn theo loại vàng";
                    lblReport.Text = "BC007 - Báo cáo xuất nhập hàng tồn theo loại vàng";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;
                case "BC008":
                    this.Text = "BC008 - Báo cáo xuất nhập hàng tồn theo quầy";
                    lblReport.Text = "BC008 - Báo cáo xuất nhập hàng tồn theo quầy";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;
                case "BC101":
                    this.Text = "BC101 - Báo cáo quầy thu ngân";
                    lblReport.Text = "BC101 - Báo cáo quầy thu ngân";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;

                case "BC102":
                    this.Text = "BC102 - Báo cáo dẻ tại Quầy";
                    lblReport.Text = "BC102 - Báo cáo dẻ tại Quầy";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;
                case "BC103":
                    this.Text = "BC103 - Báo cáo ngoại tệ tại Quầy";
                    lblReport.Text = "BC103 - Báo cáo ngoại tệ tại Quầy";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;
                case "BC201":
                    this.Text = "BC201 - Doanh số mua bán hàng của khách hàng";
                    lblReport.Text = "BC201 - Doanh số mua bán hàng của khách hàng";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;
                case "BC104":
                    this.Text = "BC104 - Thống kê dẻ đổi";
                    lblReport.Text = "BC104 - Thống kê dẻ đổi";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;
                case "BC106":
                    this.Text = "BC106 - Thống kê dẻ mua";
                    lblReport.Text = "BC106 - Thống kê dẻ mua";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;
                case "rptBC009":
                    this.Text = "BC009 - Báo cáo danh sách dẻ mua + đổi";
                    lblReport.Text = "BC009 - Báo cáo danh sách dẻ mua + đổi";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;
                case "BC107":
                  this.Text = "BC107 - Báo cáo chi phí";
                    lblReport.Text = "BC107 - Báo cáo chi phí";
                    lblKhachHang.Visible = false;
                    cboCustID.Visible = false;
                    break;
                case "BC203":
                    this.Text = "BCCNKH- Báo cáo công nợ khách hàng";
                    lblReport.Text = "BCCNKH- Báo cáo công nợ khách hàng";
                    break;
            }
        }

       
    }
}
