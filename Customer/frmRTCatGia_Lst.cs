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
    public partial class frmRTCatGia_Lst : DevExpress.XtraEditors.XtraForm
    {
        frmRTCatGia frm;
        public frmRTCatGia_Lst()
        {
            InitializeComponent();
        }
        public frmRTCatGia_Lst(frmRTCatGia _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }
        private void fn_LoadDefault()
        {
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now.AddDays(-15);
            cboCust.SelectedIndex = 0;
            cboTinhTrang.SelectedIndex = 0;

            grdDanhSach.Focus();
        }
        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.LoadComboSP("I_CUSTOMER", "");
                Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "0", true);
                ds.Clear();
                ds = clsCommon.LoadComboSP("T_STATUS", "WORKER");
                Functions.BindDropDownList(cboTinhTrang, ds, "StatusName", "Status", "", true);
                ds.Clear();
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Lỗi hàm LoadDataToCombo: " + ex.Message, "OK", ICon.Error);
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
                ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_CATGIA_Lst]",
                                                "",
                                                dtpTuNgay.DateTime.ToString("dd/MM/yyyy"),
                                                dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                                                
                                                ((ItemList)cboCust.SelectedItem).ID,
                                                ((ItemList)cboTinhTrang.SelectedItem).ID,
                                                "");

                gridControl.DataSource = ds.Tables[0];
            }
            catch { }
            finally
            {
                ds.Dispose();
            }

        }
        private void frmRTCatGia_Lst_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            fn_LoadDataToCombo();
            fn_LoadDataToGrid();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            frm.strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();
            frm.fn_LoadDataToForm();
            this.Close();
        }

        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            frm.strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();
            frm.fn_LoadDataToForm();
            this.Close();
        }
    }
}