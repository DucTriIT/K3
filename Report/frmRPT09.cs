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
    public partial class frmRPT09 : DevExpress.XtraEditors.XtraForm
    {

        private string mvarReportCode;

        public frmRPT09()
        {
            InitializeComponent();
        }

        public frmRPT09(string pReportCode)
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
                cboLoai.Properties.Items.Add( new ItemList("",""));
                cboLoai.Properties.Items.Add(new ItemList("SRT", "Hàng bán"));
                cboLoai.Properties.Items.Add(new ItemList("CRT", "Hàng đổi"));

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
            string strFromDate = "", strToDate = "", strEmpName = "", strEmpID = "",strLoai="", strParams, strValues;

            strFromDate = ((DateTime)dtpTuNgay.EditValue).ToString("dd/MM/yyyy");
            strToDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");

            strEmpName = ((ItemList)cboEmp.SelectedItem).Value;
            strEmpID = ((ItemList)cboEmp.SelectedItem).ID;
            strLoai = (ItemList)cboLoai.SelectedItem == null ? "" : ((ItemList)cboLoai.SelectedItem).ID;
            strParams = "EmpName@TuNgay@DenNgay";
            strValues = strEmpName + "@" + strFromDate + "@" + strToDate;

            switch (mvarReportCode)
            {
                case "rptBC010":
                    ds = clsCommon.ExecuteDatasetSP("rptBC010", strEmpID, strLoai, strFromDate, strToDate);
                    //Functions.fn_ShowReport(ds, "rptBC401.rpt", strParams, strValues);
                    Functions.fn_ShowReport_AndImage(ds, "rptBC010.rpt", strParams, strValues);
                    break;
               
            }            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmRPT09_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            f_loadDataToCombo();
            switch (mvarReportCode)
            {

                case "rptBC010":
                    this.Text = "BC010 - Danh sách hàng bán,đổi";
                    lblReport.Text = "BC010 - Danh sách hàng bán,đổi";
                    break;
              
            }
        }

        

       
    }
}
