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
    public partial class frmOptionMainSection : DevExpress.XtraEditors.XtraForm
    {
        frmMainSection frm;
        string strID = "";
        public frmOptionMainSection()
        {
            InitializeComponent();
        }
        public frmOptionMainSection(frmMainSection _frm,string _strID)
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
            if (String.IsNullOrEmpty(txtMainSectionCode.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào kí hiệu", "OK", ICon.Error);
                txtMainSectionCode.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtMainSectionName.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào chi nhánh", "OK", ICon.Error);
                txtMainSectionName.Focus();
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
                    ds = clsCommon.ExecuteDatasetSP("[T_MAINSECTION_Ins]", "", txtMainSectionCode.Text.Trim(), txtMainSectionName.Text.Trim(),
                        chkActive.Checked ? "1" : "0");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_MAINSECTION_Upd]", strID, txtMainSectionCode.Text.Trim(), txtMainSectionName.Text.Trim(),
                        chkActive.Checked ? "1" : "0");
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                    //fn_EnableControl(false);
                    frm.fn_LoadDataToGrid();
                    //fn_GetFocusedRowValue();
                    //grdControl.Enabled = true;
                    this.Close();
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
            txtMainSectionCode.Text = String.Empty;
            txtMainSectionName.Text = String.Empty;
            chkActive.Checked = true;
            txtMainSectionCode.Focus();
        }
        private void fn_EnableControl(bool bEditMode)
        {
            txtMainSectionCode.Enabled = bEditMode;
            txtMainSectionName.Enabled = bEditMode;
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
                ds = clsCommon.ExecuteDatasetSP("T_MAINSECTION_Get", strID);
                txtMainSectionCode.Text = ds.Tables[0].Rows[0]["MainSectionCode"].ToString();
                txtMainSectionName.Text = ds.Tables[0].Rows[0]["MainSectionName"].ToString();
                chkActive.Checked = ds.Tables[0].Rows[0]["Active"].ToString()=="1"?true:false;
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