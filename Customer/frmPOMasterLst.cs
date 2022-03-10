using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Messages;

namespace GoldRT
{
    public partial class frmPOMasterLst : DevExpress.XtraEditors.XtraForm
    {
        frmPOMaster frm;

        public frmPOMasterLst()
        {
            InitializeComponent();
        }

        public frmPOMasterLst(frmPOMaster _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void fn_LoadDefault()
        {
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now.AddDays(-15);
            txtTenKhachHang.Text = String.Empty;
            cboTinhTrang.SelectedIndex = 0;

            grdDanhSach.Focus();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.LoadComboSP("T_STATUS", "PO");
                Functions.BindDropDownList(cboTinhTrang, ds, "StatusName", "Status", "", true);
                ds.Clear(); 
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

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PO_MASTER_Lst]", "", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                "", txtTenKhachHang.Text.Trim(), "", "", "", "", "", "", "", ((ItemList)cboTinhTrang.SelectedItem).ID, "");

                gridControl.DataSource = ds.Tables[0];
            }
            catch { }
            finally
            {
                ds.Dispose();
            }
            
        }

        private void frmGoldPOLst_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            fn_LoadDefault();
            fn_LoadDataToGrid();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                string strID = grdDanhSach.GetFocusedRowCellValue("POID").ToString();
                string strCustID = grdDanhSach.GetFocusedRowCellValue("CustID").ToString();
                string strStatus = grdDanhSach.GetFocusedRowCellValue("Status").ToString();

                frm.fn_LoadDataToForm(strID, strStatus, strCustID);
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDanhSach_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (e.Button == MouseButtons.Left)
                {
                    btnXemChiTiet_Click(null, null);
                }
            }
        }
    }
}