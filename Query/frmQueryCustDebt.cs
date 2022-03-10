using System;
using System.Data;
using DevExpress.XtraGrid.Columns;

namespace GoldRT
{
    public partial class frmQueryCustDebt : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryCustDebt()
        {
            InitializeComponent();
            fn_GenerateGoldColumn();

        }

        private void fn_GenerateGoldColumn()
        {
            DataSet dsGldType = new DataSet();
            dsGldType = clsCommon.LoadComboSP("T_CUSTOMER_DEBT",null);
            int iIndex = 3;
            foreach (DataRow row in dsGldType.Tables[0].Rows)
            {
                GridColumn colTemp = grdDanhSach.Columns.Add();
                colTemp.Caption = row["GoldDesc"].ToString();
                colTemp.Name = row["GoldCode"].ToString();
                colTemp.FieldName = row["GoldCode"].ToString();
                colTemp.Tag = "1";
                colTemp.Visible = true;
                colTemp.VisibleIndex = iIndex;
                colTemp.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                iIndex++;
            }

            grdDanhSach.Columns["VND"].VisibleIndex = iIndex;
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.ExecuteDatasetSP("[T_CUSTOMER_DEBTStatistic]", txtTenKhachHang.Text);
            gridControl.DataSource = ds.Tables[0];
        }

        

        private void frmGoldPOLst_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToGrid();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void grdDanhSach_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Clicks == 2)
        //    {
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            btnXemChiTiet_Click(null, null);
        //        }
        //    }
        //}

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams = "", strValues = "";

            ds = clsCommon.ExecuteDatasetSP("rptDebt", txtTenKhachHang.Text, "");
            Functions.fn_ShowReport(ds, "rptDebt.rpt", strParams, strValues);
        }

        private void grdDanhSach_DoubleClick(object sender, EventArgs e)
        {
            //if (grdDanhSach.FocusedRowHandle >= 0)
            //{
            //    frmPaymentDebit frm = new frmPaymentDebit(grdDanhSach.GetFocusedRowCellValue("CustID").ToString());
            //    frm.ShowDialog();
            //}
        }
    }
}