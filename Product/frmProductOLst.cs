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
    public partial class frmProductOLst : DevExpress.XtraEditors.XtraForm
    {
        frmProduct_Out frm;

        public frmProductOLst()
        {
            InitializeComponent();
        }

        public frmProductOLst(frmProduct_Out _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void fn_LoadDefault()
        {
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now.AddDays(-15);
            txtMaHang.Text = String.Empty;
            cboLoaiVang.SelectedIndex = 0;
            cboTinhTrang.SelectedIndex = 0;

            grdDanhSach.Focus();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("I_GOLD", "G");
            Functions.BindDropDownList(cboLoaiVang, ds, "GoldDesc", "GoldCode", "", true);
            ds.Clear();

            ds.Dispose();

            cboTinhTrang.Properties.Items.Add(new ItemList("", ""));
            cboTinhTrang.Properties.Items.Add(new ItemList("C", "Đã xuất"));
            cboTinhTrang.Properties.Items.Add(new ItemList("W", "Chưa xuất"));
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_INOUT_Lst]", "", "O", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                "", txtMaHang.Text.Trim(), ((ItemList)cboLoaiVang.SelectedItem).ID, "", "", "", ((ItemList)cboTinhTrang.SelectedItem).ID, "");

                gridControl.DataSource = ds.Tables[0];
            }
            catch { }
            finally 
            { 
                ds.Dispose();
                grdDanhSach_FocusedRowChanged(null, null);
            }

        }

        private void frmGoldPOLst_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            fn_LoadDefault();
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

        private void grdDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle > -1)
                btnXemChiTiet.Enabled = (grdDanhSach.GetFocusedRowCellValue("Status").ToString() == "W");
        }
    }
}