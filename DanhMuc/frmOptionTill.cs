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
    public partial class frmOptionTill : DevExpress.XtraEditors.XtraForm
    {
        #region Private Variables
        string strID = "";
        frmTill frm;
        #endregion
        public frmOptionTill()
        {
            InitializeComponent();
        }
        public frmOptionTill(frmTill _frm, string _strid)
        {
            InitializeComponent();
            strID = _strid;
            frm = _frm;
        }
        #region private

        private void fn_LoadDefault()
        {
            //strID = String.Empty;
            txtTillCode.Text = String.Empty;// String.Empty;
            txtTillName.Text = String.Empty;
          //  txtNotes.Text = String.Empty;
            ckbActive.Checked = true;
            txtTillCode.Focus();
        }
        private void fn_EnableControl(bool bEditMode)
        {
            txtTillCode.Enabled = bEditMode;
            txtTillName.Enabled = bEditMode;
           // txtNotes.Enabled = bEditMode;
           // ckbActive.Enabled = bEditMode;

          
            //btnCapNhat.Enabled = bEditMode;
        }
        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtTillCode.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào kí hiệu", "OK", ICon.Error);
                txtTillCode.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtTillName.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên quầy", "OK", ICon.Error);
                txtTillName.Focus();
                return false;
            } 
            return true;
        }
        private void fn_load_data_form(string strID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_Till_GET", strID);
                txtTillCode.Text = ds.Tables[0].Rows[0]["TillCode"].ToString();
                txtTillName.Text = ds.Tables[0].Rows[0]["TillName"].ToString();
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
                    ds = clsCommon.ExecuteDatasetSP("[T_TILL_Ins]", "", txtTillCode.Text.Trim(), txtTillName.Text.Trim(),
                        "", "", "", "", "",ckbActive.Checked?"1":"0");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_TILL_Upd]", strID, txtTillCode.Text.Trim(), txtTillName.Text.Trim(),
                         "", "", "", "", "", ckbActive.Checked ? "1" : "0");
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                    //fn_EnableControl(false);
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

        private void frmOptionTill_Load(object sender, EventArgs e)
        {
            if (strID=="")
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

       
    }
}