using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using DevExpress.XtraEditors.Controls;

namespace GoldRT
{
    public partial class frmOpenTill : DevExpress.XtraEditors.XtraForm
    {
        frmMain frm;
        public frmOpenTill(frmMain _frm)
        {
            InitializeComponent();
            frm = _frm;
        }

        private void frmOpenTill_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            fn_LoadDataToForm();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "T_TILL", "");
                Functions.BindDropDownList(cboTill, ds, "TillCode", "TillID", "", true);
                ds.Clear();
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToCombo: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

        private void cboTill_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strTillID = ((ItemList)cboTill.SelectedItem).ID;
            try
            {
                if (strTillID != "")
                {
                    ds = clsCommon.ExecuteDatasetSP("T_TILL_Get", strTillID);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txtTillName.Text = ds.Tables[0].Rows[0]["TillName"].ToString();
                        txtStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", "Till khong hop le.", "OK", ICon.Error);
                    }
                    ds.Clear();
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToCombo: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenTill_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strTillID = ((ItemList)cboTill.SelectedItem).ID;
            string strTillCode = ((ItemList)cboTill.SelectedItem).Value;
            string strTillName = txtTillName.Text;
            try
            {
                if (strTillID != "")
                {
                    ds = clsCommon.ExecuteDatasetSP("T_TILL_Open", strTillID, clsSystem.UserID);

                    if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() == "0")
                    {
                        clsSystem.TillID = strTillID;
                        clsSystem.TillCode = strTillCode;
                        clsSystem.TillName = strTillName;
                        frm.sTill.ImageIndex = 27;
                        frm.sTill.Caption = "Quầy đang mở (" + strTillCode + " - " + strTillName + ")";

                        ThongBao.Show("Thông báo", "Cập nhật mở quầy thành công.", "OK", ICon.Information);
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                    ds.Clear();
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToCombo: " + ex.Message, "OK", ICon.Error);
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
                    cboTill.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["TillID"].ToString(), cboTill, 0);
                    txtTillName.Text = ds.Tables[0].Rows[0]["TillName"].ToString();
                    txtStatus.Text = ds.Tables[0].Rows[0]["StatusDesc"].ToString();

                    cboTill.Enabled = false;
                    txtTillName.Enabled = false;
                    txtStatus.Enabled = false;
                    btnOpenTill.Enabled = false;
                }
                else
                {
                    cboTill.Enabled = true;
                    txtTillName.Enabled = true;
                    txtStatus.Enabled = true;
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

    }
}