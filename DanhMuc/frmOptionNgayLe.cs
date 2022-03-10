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
    public partial class frmOptionNgayLe : DevExpress.XtraEditors.XtraForm
    {
        #region Private Variables
        string strID = "";
        frmNgayLe frm;
        #endregion
        public frmOptionNgayLe()
        {
            InitializeComponent();
        }
        public frmOptionNgayLe(frmNgayLe _frm, string _strid)
        {
            InitializeComponent();
            strID = _strid;
            frm = _frm;
        }
        #region private

        private void fn_LoadDefault()
        {
            //strID = String.Empty;
            txtNgayLe.Text = String.Empty;// String.Empty;
            txtTienPhongThuong.Text = String.Empty;
            txtTienPhongVIP.Text = string.Empty;
            //  txtNotes.Text = String.Empty;
            ckbActive.Checked = true;
            txtNgayLe.Focus();
        }
        private void fn_EnableControl(bool bEditMode)
        {
            txtNgayLe.Enabled = bEditMode;
            txtTienPhongThuong.Enabled = bEditMode;
            txtTienPhongVIP.Enabled = bEditMode;
            // txtNotes.Enabled = bEditMode;
            // ckbActive.Enabled = bEditMode;


            //btnCapNhat.Enabled = bEditMode;
        }
        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtNgayLe.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào ngày lễ", "OK", ICon.Error);
                txtNgayLe.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtTienPhongThuong.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tiền hát phòng thường", "OK", ICon.Error);
                txtTienPhongThuong.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtTienPhongVIP.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tiền hát phòng VIP", "OK", ICon.Error);
                txtTienPhongThuong.Focus();
                return false;
            }
            return true;
        }
        private void fn_load_data_form(string strID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_NgayLe_GET", strID);
                txtNgayLe.Text = ds.Tables[0].Rows[0]["NgayLe"].ToString();
                txtTienPhongThuong.Text = ds.Tables[0].Rows[0]["TienPhongThuong"].ToString();
                txtTienPhongVIP.Text = ds.Tables[0].Rows[0]["TienPhongVIP"].ToString();
                //txtNotes.Text = ds.Tables[0].Rows[0]["Notes"].ToString();
                ckbActive.Checked = ds.Tables[0].Rows[0]["Active"].ToString() == "1" ? true : false;
            }
            catch
            { }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }

        }
        #endregion

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_NgayLe_Ins]",
                        txtNgayLe.Text.Trim(),
                        txtTienPhongThuong.EditValue,
                        txtTienPhongVIP.EditValue,
                        //"F",
                        //txtNotes.Text.Trim(),
                        ckbActive.Checked ? "1" : "0");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_NgayLe_Upd]",
                        strID,                       
                        txtTienPhongThuong.EditValue,
                        txtTienPhongVIP.EditValue,
                        // "F",
                        //txtNotes.Text.Trim(),
                        ckbActive.Checked ? "1" : "0");
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                    //fn_EnableControl(false);
                    ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                    this.frm.fn_LoadDataToGrid();
                    this.Close();
                    // fn_GetFocusedRowValue();
                    // grdControl.Enabled = true;
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

        private void frmOptionNgayLe_Load(object sender, EventArgs e)
        {
            if (strID == "")
            {
                fn_LoadDefault();
                fn_EnableControl(true);
            }
            else
            {
                fn_load_data_form(strID);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCcy_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}