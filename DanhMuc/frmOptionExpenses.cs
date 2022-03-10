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
    public partial class frmOptionExpenses : DevExpress.XtraEditors.XtraForm
    {
        frmExpenses frm;
        string strID="";
        public frmOptionExpenses()
        {
            InitializeComponent();
        }
        public frmOptionExpenses(frmExpenses _frm,string _strID )
        {
            InitializeComponent();
            frm = _frm;
            strID = _strID;
        }
        private void frmOptionExpenses_Load(object sender, EventArgs e)
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
            txtExpensesCode.Text = string.Empty;
            txtExpensesName.Text = string.Empty;
            ckbActive.Checked = true;
            txtExpensesCode.Focus();
        }
        private void fn_EnableControl(bool bEditMode)
        {
            txtExpensesCode.Enabled = bEditMode;
            txtExpensesName.Enabled = bEditMode;
            //btnCapNhat.Enabled = bEditMode;
        }
        private void fn_load_data_form()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_EXPENSES_Get", strID);
           txtExpensesCode.Text = ds.Tables[0].Rows[0]["ExpensesCode"].ToString();
               txtExpensesName.Text = ds.Tables[0].Rows[0]["ExpensesName"].ToString();
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
            if (String.IsNullOrEmpty(txtExpensesCode.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào mã chi phí", "OK", ICon.Error);
                txtExpensesCode.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtExpensesName.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên chi phí", "OK", ICon.Error);
                txtExpensesName.Focus();
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
                    ds = clsCommon.ExecuteDatasetSP("[T_EXPENSES_Ins]", "", txtExpensesCode.Text, txtExpensesName.Text.Trim(),
                        ckbActive.Checked ? "1" : "0");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_EXPENSES_Upd]", strID, txtExpensesCode.Text, txtExpensesName.Text.Trim(),
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