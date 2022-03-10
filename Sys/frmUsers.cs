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
    public partial class frmUsers : DevExpress.XtraEditors.XtraForm
    {
        public frmUsers()
        {
            InitializeComponent();
        }
        
    #region "Private Variables"
        string strID = "";
    #endregion

        private void fn_LoadDefault()
        {
            strID = String.Empty;
            txtHoTenLot.Text = String.Empty;
            txtTen.Text = String.Empty;
            txtHoTen.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtDienThoai.Text = String.Empty;
            txtTenDangNhap.Text = String.Empty;
            txtMatKhau.Text = String.Empty;
            ckbActive.Checked = true;
            cboNhomNSD.SelectedIndex = 0;

            txtHoTenLot.Focus();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("SYS_GROUPS", null);
            Functions.BindDropDownList(cboNhomNSD, ds, "GroupName", "GroupID", "", true);
            ds.Clear();

            //ds = clsCommon.LoadComboSP("T_MAINSECTION", "");
            //Functions.BindDropDownList(cboMainSection, ds, "MainSectionName", "MainSectionID", "", true);
            //ds.Clear();

            ds.Dispose();
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                if (clsSystem.GetCurrentAccountType() == AccountType.SuperAccount)
                    ds = clsCommon.ExecuteDatasetSP("[SYS_USERS_Lst]", "", "", "", "", "", "", "", "", "", "UserName ASC");
                else
                    ds = clsCommon.ExecuteDatasetSP("[SYS_USERS_LstNotSuperAcc]", "", "", "", "", "", "", "", "", "", "UserName ASC");

                if (ds.Tables.Count > 0)
                {
                    grdControl.DataSource = ds.Tables[0];
                    lblNumRec.Text = ds.Tables[0].Rows.Count.ToString();
                }
              
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void fn_EnableControl(bool bEditMode)
        {
            txtHoTenLot.Enabled = bEditMode;
            txtTen.Enabled = bEditMode;
            txtHoTen.Enabled = bEditMode;
            txtEmail.Enabled = bEditMode;
            txtDienThoai.Enabled = bEditMode;
            txtTenDangNhap.Enabled = bEditMode;
            txtMatKhau.Enabled = bEditMode;
            cboNhomNSD.Enabled = bEditMode;
            ckbActive.Enabled = bEditMode;
            
            btnThem.Enabled = !bEditMode;
            btnSua.Enabled = !bEditMode;
            btnXoa.Enabled = !bEditMode;
            btnCapNhat.Enabled = bEditMode;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
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
            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để sửa.", "OK", ICon.Information);
                return;
            }
            fn_EnableControl(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }
            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá user này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[SYS_USERS_Del]", strID);

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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            if (!fn_CheckValidate()) return;
            
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string strMatKhau = txtMatKhau.Text.Trim() != "" ? Functions.getMd5Hash(txtMatKhau.Text.Trim()) : "";
                string strGroupID = ((ItemList)cboNhomNSD.SelectedItem).ID;
                

                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[SYS_USERS_Ins]", txtTenDangNhap.Text.Trim(), strMatKhau,
                        txtHoTenLot.Text.Trim(), txtTen.Text.Trim(), txtHoTen.Text.Trim(), txtEmail.Text.Trim(),
                        txtDienThoai.Text.Trim(), null, "0", ckbActive.Checked ? "1" : "0",
                        strGroupID);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[SYS_USERS_Upd]", strID, txtTenDangNhap.Text.Trim(), strMatKhau,
                        txtHoTenLot.Text.Trim(), txtTen.Text.Trim(), txtHoTen.Text.Trim(), txtEmail.Text.Trim(),
                        txtDienThoai.Text.Trim(), null, "0", ckbActive.Checked ? "1" : "0",
                        strGroupID);
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

        private bool fn_CheckValidate()
        {
            if (txtTenDangNhap.Text.Trim() == "")
            {
                ThongBao.Show("Thông báo", "Vui lòng nhập tên đăng nhập", "OK", ICon.Warning);
                txtTenDangNhap.Focus();
                return false;
            }
            if (cboNhomNSD.SelectedIndex < 1)
            {
                ThongBao.Show("Thông báo", "Vui lòng chọn nhóm người dùng", "OK", ICon.Warning);
                cboNhomNSD.Focus();
                return false;
            }
            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            fn_EnableControl(false);
            fn_GetFocusedRowValue();
            grdControl.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fn_GetFocusedRowValue();
        }

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("UserID").ToString();
                txtHoTenLot.Text = grdDanhSach.GetFocusedRowCellValue("FirstName").ToString();
                txtTen.Text = grdDanhSach.GetFocusedRowCellValue("LastName").ToString();
                txtHoTen.Text = grdDanhSach.GetFocusedRowCellValue("FullName").ToString();
                txtEmail.Text = grdDanhSach.GetFocusedRowCellValue("Email").ToString();
                txtDienThoai.Text = grdDanhSach.GetFocusedRowCellValue("Mobile").ToString();
                txtTenDangNhap.Text = grdDanhSach.GetFocusedRowCellValue("UserName").ToString();
                cboNhomNSD.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("GroupID").ToString(), cboNhomNSD, 0);
               // cboMainSection.SelectedIndex= Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("MainSectionID").ToString(), cboMainSection, 0);
                ckbActive.Checked = grdDanhSach.GetFocusedRowCellValue("Active").ToString() == "1" ? true : false;
            }
        }
    }
}