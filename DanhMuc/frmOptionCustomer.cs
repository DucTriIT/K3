using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using Messages;
using System.Security.Cryptography;
namespace GoldRT
{
    public partial class frmOptionCustomer : DevExpress.XtraEditors.XtraForm
    {
        frmCustomer frm;
        public string mstrID = "";
        public string ID
        {
            get { return mstrID; }
            set { mstrID = value; }
        }


        public frmOptionCustomer()
        {
            InitializeComponent();
        }
        public frmOptionCustomer(frmCustomer _frm, string _strID)
        {
            InitializeComponent();
            mstrID = _strID;
            this.frm = _frm;
        }
        private void fn_LoadDefault()
        {
            mstrID = String.Empty;
            lblMaHang.Text = "Tự động";
            txtTenKH.Text = String.Empty;
            txtTienGio.Text = String.Empty;
            txtTenKH.Focus();
            ckeAvtive.Checked = true;
        }
        private void fn_load_data_form()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_Phong_Get]", mstrID);
                lblMaHang.Text = ds.Tables[0].Rows[0]["IDPhong"].ToString();
                txtTenKH.Text = ds.Tables[0].Rows[0]["TenPhong"].ToString();
                txtTienGio.Text = ds.Tables[0].Rows[0]["TienGio"].ToString();
                ckeAvtive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["TrangThai"]);
            }
            catch { }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }


        }
        private void frmOptionCustomer_Load(object sender, EventArgs e)
        {
            if (mstrID == "")
                fn_LoadDefault();
            else
            {
                fn_load_data_form();
            }
        }
        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtTenKH.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên phòng", "OK", ICon.Error);
                txtTenKH.Focus();
                return false;
            }
            return true;
        }
        private void lblMaHang_Click(object sender, EventArgs e)
        {

        }

        private void txtGhiChu_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (mstrID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_Phong_Ins]", "", txtTenKH.Text.Trim(),
                        "", ckeAvtive.Checked ? 1 : 0, txtTienGio.Text.Trim());
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_Phong_Upd]", mstrID, txtTenKH.Text.Trim(),
                        "", ckeAvtive.Checked ? 1 : 0, txtTienGio.Text.Trim());
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    // fn_EnableControl(false);
                    ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                    if (this.frm != null)
                        this.frm.fn_LoadDataToGrid();
                    mstrID = ds.Tables[0].Rows[0]["IDPhong"].ToString();
                    //fn_GetFocusedRowValue();
                    //grdControl.Enabled = true;
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
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtMST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtFAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }



        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

    }
}