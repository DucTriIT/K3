using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmOpenTill_1 : DevExpress.XtraEditors.XtraForm
    {
        frmMain frm;
        public frmOpenTill_1(frmMain _frm)
        {
            InitializeComponent();
            frm = _frm;
        }
        public frmOpenTill_1()
        {
            InitializeComponent();
        }
        private void frmOpenTill_Load(object sender, EventArgs e)
        {
            //txtTill.Focus();
            //fn_LoadDataToCombo();
            //fn_LoadDataToForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenTill_Click(object sender, EventArgs e)
        {
            if (fn_OpenTill())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
        bool fn_OpenTill()
        {
            bool result = false;
            DataSet ds = new DataSet();
            string strTillID =txtTill.Text;
            try
            {
                if (strTillID != "")
                {
                    ds = clsCommon.ExecuteDatasetSP("T_TILL_CheckTill", strTillID);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ThongBao.Show("Thông báo", "Mã quầy không chính xác. Xin vui lòng nhập lại", "OK", ICon.Information);
                        txtTill.Text = "";
                        return false;
                    }
                    ds.Clear();
                    if (clsSystem.TillID != "")
                        FunctionTill.fn_CloseTill();
                    ds = clsCommon.ExecuteDatasetSP("T_TILL_Open_1", strTillID, clsSystem.UserID);

                    if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() == "0")
                    {
                        clsSystem.TillID = ds.Tables[0].Rows[0]["TillID"].ToString();
                        clsSystem.TillCode = ds.Tables[0].Rows[0]["TillCode"].ToString();
                        clsSystem.TillName = ds.Tables[0].Rows[0]["TillName"].ToString();
                        result = true;
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                        result =  false;
                        
                    }
                    ds.Clear();
                }
                return result;
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Mở quầy: " + ex.Message, "OK", ICon.Error);
                return false;
            }
            finally
            {
                ds = null;
            }
        }

        private void fn_LoadDataToForm()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_TILL_GetByUserID", clsSystem.UserID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //cboTill.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["TillID"].ToString(), cboTill, 0);
                    //txtTillName.Text = ds.Tables[0].Rows[0]["TillName"].ToString();
                   // txtStatus.Text = ds.Tables[0].Rows[0]["StatusDesc"].ToString();

                   // cboTill.Enabled = false;
                    //txtTillName.Enabled = false;
                   // txtStatus.Enabled = false;
                    btnOpenTill.Enabled = false;
                }
                else
                {
                   // cboTill.Enabled = true;
                   // txtTillName.Enabled = true;
                   // txtStatus.Enabled = true;
                    btnOpenTill.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void txtTill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (fn_OpenTill())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

    }
}