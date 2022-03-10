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
    public partial class frmOptionWorker : DevExpress.XtraEditors.XtraForm
    {
        #region Private Variables
        string strID = "";
        frmWorker frm;
        #endregion
        public frmOptionWorker()
        {
            InitializeComponent();
        }
        public frmOptionWorker(frmWorker _frm, string _strid)
        {
            InitializeComponent();
            strID = _strid;
            frm = _frm;
        }
        private void frmOptionWorker_Load(object sender, EventArgs e)
        {
            if (strID == "")
            {
                fn_LoadDefault();
                fn_EnableControl(true);
            }
            else
            {
                fn_load_data_form();
            }
        }
        private void fn_LoadDefault()
        {
            //strID = String.Empty;
            txtMaTho.Text = "Tự động"; ;
            txtTenTho.Text = String.Empty;
            ckbActive.Checked = true;
            txtTenTho.Focus();
        }
        private void fn_EnableControl(bool bEditMode)
        {
            txtTenTho.Enabled = bEditMode;
            //btnCapNhat.Enabled = bEditMode;
        }
        private void fn_load_data_form()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_WORKER_Get", strID);
                txtMaTho.Text = ds.Tables[0].Rows[0]["WorkerCode"].ToString();
                txtTenTho.Text = ds.Tables[0].Rows[0]["WorkerName"].ToString();
                ckbActive.Checked = ds.Tables[0].Rows[0]["Active"].ToString() == "1" ? true : false;
            }
            catch { }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }


        }
        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtTenTho.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên thợ", "OK", ICon.Error);
                txtTenTho.Focus();
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
                    ds = clsCommon.ExecuteDatasetSP("[T_WORKER_Ins]", "", "", txtTenTho.Text.Trim(),
                        ckbActive.Checked ? "1" : "0");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_WORKER_Upd]", strID, txtMaTho.Text, txtTenTho.Text.Trim(),
                        ckbActive.Checked ? "1" : "0");
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    // fn_EnableControl(false);
                    ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                    
                    frm.fn_LoadDataToGrid();
                    this.Close();
                   
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
    }
}