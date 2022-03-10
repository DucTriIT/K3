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
    public partial class frmOptionSecTion : DevExpress.XtraEditors.XtraForm
    {
        frmSection frm;
        string strID = "";
        public frmOptionSecTion()
        {
            InitializeComponent();
        }
        public frmOptionSecTion(frmSection _frm,string _strID)
        {
            InitializeComponent();
            this.frm = _frm;
            strID = _strID;
        }
        private void fn_LoadDefault()
        {
           // strID = String.Empty;
            txtSectionCode.Text = String.Empty;
            txtSectionName.Text = String.Empty;
            cboMainSection.SelectedIndex = 0;
            cboEmp.SelectedIndex = 0;
            chkActive.Checked = true;
            txtSectionCode.Focus();
            
        }

        private void txtOrderBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void Fn_load_data_form()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_SECTION_Get", strID);
                txtSectionCode.Text = ds.Tables[0].Rows[0]["SectionCode"].ToString();
                txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                cboMainSection.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["MainSectionID"].ToString(), cboMainSection, 0);
               // txtOrderBy.Text = ds.Tables[0].Rows[0]["OrderBy"].ToString();
                cboEmp.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["EmpID"].ToString(), cboEmp, 0);
                chkActive.Checked = ds.Tables[0].Rows[0]["Active"].ToString() == "1" ? true : false;
               
            }
            catch { }
            finally { ds.Dispose();
            this.Cursor = Cursors.Default;
            }
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("T_MAINSECTION", "");
            Functions.BindDropDownList(cboMainSection, ds, "MainSectionName", "MainSectionID", "", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("T_SECTION", "");
            Functions.BindDropDownList(cboEmp, ds, "SectionName", "SectionID", "", true);
            ds.Clear();

            ds.Dispose();
        }
        private void frmOptionSecTion_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            if (strID == "")
                fn_LoadDefault();
            else
            {
                Fn_load_data_form();
            }
        }
        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtSectionCode.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào mã nhóm", "OK", ICon.Error);
                txtSectionCode.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtSectionName.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên nhóm", "OK", ICon.Error);
                txtSectionName.Focus();
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
                    ds = clsCommon.ExecuteDatasetSP("[T_SECTION_Ins]", "", txtSectionCode.Text.Trim(), txtSectionName.Text.Trim(),
                        ((ItemList)cboMainSection.SelectedItem).ID, ((ItemList)cboEmp.SelectedItem).ID, chkActive.Checked ? "1" : "0",1);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_SECTION_Upd]", strID, txtSectionCode.Text.Trim(), txtSectionName.Text.Trim(),
                        ((ItemList)cboMainSection.SelectedItem).ID, ((ItemList)cboEmp.SelectedItem).ID, chkActive.Checked ? "1" : "0",1);
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                    //fn_EnableControl(false);
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
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
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
    }
}