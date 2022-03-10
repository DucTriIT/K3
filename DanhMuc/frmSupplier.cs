using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmSupplier : DevExpress.XtraEditors.XtraForm
    {

    #region Private Variables
        string strID = String.Empty;
    #endregion

    #region Public Functions
        public frmSupplier()
        {
            InitializeComponent();
        }
    #endregion

    #region Private Functions
        private void fn_EnableControl(bool bEditMode)
        {
            txtNCC.Enabled = bEditMode;
            txtTenNCC.Enabled = bEditMode;
            ckbActive.Enabled = bEditMode;

            btnThem.Enabled = !bEditMode;
            btnSua.Enabled = !bEditMode;
            btnXoa.Enabled = !bEditMode;
            btnCapNhat.Enabled = bEditMode;
        }

        private void fn_LoadDefault()
        {
            strID = String.Empty;
            txtNCC.Text = String.Empty;
            txtTenNCC.Text = String.Empty;
            ckbActive.Checked = true;
            txtNCC.Focus();
        }

        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtNCC.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào mã nhà cung cấp", "OK", ICon.Error);
                txtNCC.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtTenNCC.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên nhà cung cấp", "OK", ICon.Error);
                txtTenNCC.Focus();
                return false;
            }
            return true;
        }

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("SupplierID").ToString();
                txtNCC.Text = grdDanhSach.GetFocusedRowCellValue("SupplierCode").ToString();
                txtTenNCC.Text = grdDanhSach.GetFocusedRowCellValue("SupplierName").ToString();
                ckbActive.Checked = grdDanhSach.GetFocusedRowCellValue("Active").ToString() == "1" ? true : false;
            }
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_SUPPLIER_Lst]", "", "", "", "", "SupplierName ASC");

                if (ds.Tables.Count > 0)
                {
                    grdControl.DataSource = ds.Tables[0];
                    lblNumRec.Text = ds.Tables[0].Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }
    #endregion

    #region Event Handlers
        private void frmPdtGroup_Load(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
            fn_EnableControl(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fn_EnableControl(true);
            fn_LoadDefault();
            grdControl.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle < 0)
            {
                ThongBao.Show("Thông tin", "Chưa chọn dữ liệu để sửa.", "OK", ICon.Warning);
                return;
            }
            fn_EnableControl(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Chưa chọn dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_SUPPLIER_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDataToGrid();
                        fn_EnableControl(false);
                        fn_GetFocusedRowValue();
                        grdControl.Enabled = true;
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                }
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            fn_EnableControl(false);
            fn_GetFocusedRowValue();
            grdControl.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_SUPPLIER_Ins]", "", txtNCC.Text.Trim(), txtTenNCC.Text.Trim(),
                        ckbActive.Checked ? "1" : "0");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_SUPPLIER_Upd]", strID, txtNCC.Text.Trim(), txtTenNCC.Text.Trim(),
                        ckbActive.Checked ? "1" : "0");
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                    fn_EnableControl(false);
                    fn_LoadDataToGrid();
                    fn_GetFocusedRowValue();
                    grdControl.Enabled = true;
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fn_GetFocusedRowValue();
        }
    #endregion

    }
}