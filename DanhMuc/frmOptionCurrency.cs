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
    public partial class frmOptionCurrency : DevExpress.XtraEditors.XtraForm
    {
        frmCurrency frm;
        string strID = "";
        public frmOptionCurrency()
        {
            InitializeComponent();
        }

        public frmOptionCurrency(frmCurrency _frm,string _strID)
        {
            InitializeComponent();
            this.frm = _frm;
            strID = _strID;
        }

        private void txtMainSectionCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtCcy.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên loại tiền tệ ", "OK", ICon.Error);
                txtCcy.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtCcyDesc.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên chi tiết", "OK", ICon.Error);
                txtCcyDesc.Focus();
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_CURRENCY_Ins]",
                        txtCcy.Text.Trim(),
                        txtCcyDesc.Text.Trim(),
                        "F",
                        txtNotes.Text.Trim(),
                        chkActive.Checked ? "1" : "0",
                        txtTruvao.Text, txtCongra.Text);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_CURRENCY_Upd]",
                        strID,
                        txtCcy.Text.Trim(),
                        txtCcyDesc.Text.Trim(),
                        "F",
                        txtNotes.Text.Trim(),
                        chkActive.Checked ? "1" : "0",
                        txtTruvao.Text, txtCongra.Text);
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                   // fn_EnableControl(false);
                    ThongBao.Show("Thông báo","Cập nhật thành công","OK",ICon.Information);
                    frm.fn_LoadDataToGrid();
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frm.fn_LoadDataToGrid();
        }

        private void fn_LoadDefault()
        {
            strID = String.Empty;
            txtCcy.Text = String.Empty;
            txtCcyDesc.Text = String.Empty;
            chkActive.Checked = true;
            txtCcy.Focus();
        }

        private void fn_EnableControl(bool bEditMode)
        {
            txtCcy.Enabled = bEditMode;
            txtCcyDesc.Enabled = bEditMode;
           //ckbActive.Enabled = bEditMode;

           // btnThem.Enabled = !bEditMode;
            btnLuu.Enabled = bEditMode;
            btnThoat.Enabled = bEditMode;
        }

        private void fn_load_data_form()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("I_CURRENCY_Get", strID);
                txtCcy.Text = ds.Tables[0].Rows[0]["Ccy"].ToString();
                txtCcyDesc.Text = ds.Tables[0].Rows[0]["CcyDesc"].ToString();
                txtNotes.Text = ds.Tables[0].Rows[0]["Notes"].ToString();
                chkActive.Checked = ds.Tables[0].Rows[0]["Active"].ToString()=="1"?true:false;
                txtTruvao.Text = ds.Tables[0].Rows[0]["Subtract"].ToString();
                txtCongra.Text = ds.Tables[0].Rows[0]["Add"].ToString();
            }
            catch { }
            finally 
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void frmOptionMainSection_Load(object sender, EventArgs e)
        {
            if(!clsSystem.IsHeSo)
            {
                txtTruvao.Dispose();
                txtCongra.Dispose();
            }
            if (strID == "")
            {
                fn_LoadDefault();
                fn_EnableControl(true);
            }
            else
                fn_load_data_form();


        }
    }
}