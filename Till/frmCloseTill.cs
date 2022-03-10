using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace GoldRT
{
    public partial class frmCloseTill : DevExpress.XtraEditors.XtraForm
    {
        string strTillID = "";
        frmMain frm;

        public frmCloseTill(frmMain _frm)
        {
            InitializeComponent();
            frm = _frm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fn_LoadDataToForm()
        {
            DataSet ds = new DataSet();
            string strCustID = "", strGoldCode = "";

            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_TILL_Get", clsSystem.TillID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    strTillID = ds.Tables[0].Rows[0]["TillID"].ToString();
                    txtTillCode.Text = ds.Tables[0].Rows[0]["TillCode"].ToString();
                    txtTillName.Text = ds.Tables[0].Rows[0]["TillName"].ToString();

                    grdControl.DataSource = ds.Tables[1];
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void frmCloseTill_Load(object sender, EventArgs e)
        {
            if (clsSystem.TillID != "")
            {
                fn_LoadDataToForm();
                btnCloseTill.Enabled = true;
            }
            else
            {                
                btnCloseTill.Enabled = false;
                ThongBao.Show("Lỗi", "Không tồn tại quầy chờ đóng.", "OK", ICon.Error);
            }
        }

        private void btnCloseTill_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            
            try
            {
                if (strTillID != "")
                {
                    ds = clsCommon.ExecuteDatasetSP("T_TILL_Close", clsSystem.TillID, clsSystem.UserID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        clsSystem.TillID = "";
                        clsSystem.TillCode = "";

                        frm.sTill.ImageIndex = 28;
                        frm.sTill.Caption = "Quầy đang đóng";

                        ThongBao.Show("Thông báo", "Cập nhật đóng quầy thành công.", "OK", ICon.Information);
                    }
                    else
                    {
                        //ThongBao.Show("Lỗi", "Till khong hop le.", "OK", ICon.Error);
                    }
                    ds.Clear();
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm btnCloseTill_Click: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }
    }
}