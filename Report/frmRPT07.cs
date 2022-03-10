using System;
using System.Data;
using System.Windows.Forms;

namespace GoldRT
{
    public partial class frmRPT07 : DevExpress.XtraEditors.XtraForm
    {
        private string mvarReportCode;

        public frmRPT07()
        {
            InitializeComponent();
        }

        public frmRPT07(string pReportCode)
        {
            InitializeComponent();
            mvarReportCode = pReportCode;
        }              

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQuy10.EditValue) == decimal.Zero)
            {
                Messages.ThongBao.Show("Thông báo", "Vui lòng nhập giá trị khác 0", "OK", Messages.ICon.Information);
                return;
            }
            DataSet ds = new DataSet();
            string strParams, strValues;          

            strParams = "SumAmount";
            strValues = "";

            switch (mvarReportCode)
            {
                case "rptBC011":
                    ds = clsCommon.ExecuteDatasetSP("rptBCSumAmount",txtQuy10.EditValue);
                    strValues = ds.Tables[5].Rows[0]["SumAmount"].ToString();
                    Functions.fn_ShowReport_AndImage(ds, "rptBCSumAmount.rpt", strParams, strValues);
                    break;
            }            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRPT07_Load(object sender, EventArgs e)
        {
            switch (mvarReportCode)
            {
                case "rptBC011":
                    this.Text = "BC011 - Báo cáo tổng tài sản";
                    lblReport.Text = "BC011 - Báo cáo tổng tài sản";
                    break;
            }
        }

        private void txtQuy10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPrint_Click(sender, e);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQuy10.EditValue) == decimal.Zero)
            {
                
                Messages.ThongBao.Show("Thông báo", "Vui lòng nhập giá trị khác 0", "OK", Messages.ICon.Information);
                return;
            }
            DataSet ds = new DataSet();
            string strParams, strValues;

            strParams = "SumAmount@PriceQ10@NgayGioIn";
            strValues = "";
            decimal GiaQuy10=decimal.Parse(txtQuy10.EditValue.ToString())*10;
            switch (mvarReportCode)
            {
                case "BC011":
                    ds = clsCommon.ExecuteDatasetSP("rptBCSumAmount", GiaQuy10);
                    strValues = ds.Tables[6].Rows[0]["SumAmount"].ToString() + "@" +GiaQuy10.ToString()+"@"+DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    Functions.fn_ShowReport(ds, "rptBCSumAmountInPhieu.rpt", strParams, strValues);
                    break;
            }  
        }
     
    }
}