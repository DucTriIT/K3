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
    public partial class frmNhomUsers : DevExpress.XtraEditors.XtraForm
    {
        string strID = String.Empty;

        public frmNhomUsers()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhomUsers_Load(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
            fn_EnableControl(false);
        }

        private void fn_EnableControl(bool bEditMode)
        {
            txtGroupCode.Enabled = bEditMode;
            txtGroupName.Enabled = bEditMode;
            txtDescription.Enabled = bEditMode;

            btnThem.Enabled = !bEditMode;
            btnSua.Enabled = !bEditMode;
            btnXoa.Enabled = !bEditMode;
            btnCapNhat.Enabled = bEditMode;
        }

        private void fn_LoadDefault()
        {
            strID = String.Empty;
            txtGroupCode.Text = String.Empty;
            txtGroupName.Text = String.Empty;
            txtDescription.Text = String.Empty;

            txtGroupCode.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fn_EnableControl(true);
            fn_LoadDefault();
            grdControl.Enabled = false;
        }

        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtGroupCode.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào mã nhóm", "OK", ICon.Error);
                txtGroupCode.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtGroupName.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên nhóm", "OK", ICon.Error);
                txtGroupName.Focus();
                return false;
            }
            return true;
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
                    ds = clsCommon.ExecuteDatasetSP("[SYS_GROUPS_Ins]", txtGroupCode.Text.Trim(), txtGroupName.Text.Trim(),
                    txtDescription.Text.Trim(), "0");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[SYS_GROUPS_Upd]", strID, txtGroupCode.Text.Trim(), txtGroupName.Text.Trim(),
                    txtDescription.Text.Trim(), "0");
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
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("GroupID").ToString();
                txtGroupCode.Text = grdDanhSach.GetFocusedRowCellValue("GroupCode").ToString();
                txtGroupName.Text = grdDanhSach.GetFocusedRowCellValue("GroupName").ToString();
                txtDescription.Text = grdDanhSach.GetFocusedRowCellValue("Description").ToString();
            }
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_GROUPS_Lst]", "", "", "", "", "", "GroupCode");

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

        private void grdDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fn_GetFocusedRowValue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle < 0)
            {
                ThongBao.Show("Thông tin", "Không có dữ liệu để sửa.", "OK", ICon.Warning);
                return;
            }
            fn_EnableControl(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            fn_EnableControl(false);
            fn_GetFocusedRowValue();
            grdControl.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá nhóm người dùng này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[SYS_GROUPS_Del]", strID);

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

    }
}