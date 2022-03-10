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
    public partial class frmChangPassword : DevExpress.XtraEditors.XtraForm
    {
        public frmChangPassword()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ThongBao.Show("Thông báo", "Mật khẩu mới và mật khẩu xác nhận lại không trùng nhau!", "OK", ICon.Error);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_USERS_ChangePwd]", clsSystem.UserID, Functions.getMd5Hash(txtOldPassword.Text), Functions.getMd5Hash(txtNewPassword.Text));

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Mật khẩu đã thay đổi.", "OK", ICon.Information);
                }
                else
                {
                    ThongBao.Show("Thông báo", "Mật khẩu cũ không hợp lệ!", "OK", ICon.Error);
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}