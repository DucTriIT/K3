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
    public partial class frmRTCatGia : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt= new DataTable();
        

        public string strID = "";
        public frmRTCatGia()
        {
            InitializeComponent();
        }
        private void fn_createDataTable()
        {

            this.dt.Columns.Add("GoldCcy", typeof(string));
            this.dt.Columns.Add("SL", typeof(decimal));
            this.dt.Columns.Add("Rate", typeof(decimal));
            this.dt.Columns.Add("GhiChu", typeof(string));
          }

        private void frmRTCatGia_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);

            fn_createDataTable();
            grdOut.DataSource = dt;
       
           

            fn_LoadDataToCombo();
            fn_LoadDefault();

        }
        private bool fn_CheckValidate()
        {

            if (cboCust.Text == "")
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn khách hàng.", "OK", ICon.Error);
                cboCust.Focus();
                return false;
            }

            return true;
        }
        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("I_CUSTOMER", "");
            Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "0", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("I_GOLDCCY", "CATGIA");
            Functions.BindDropDownList(cboGoldCcy, ds, "GoldCcyDesc", "GoldCcy", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("T_STATUS", "WORKER");
            Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
            ds.Clear();

            ds.Dispose();
        }
        private void fn_LoadDefault()
        {
            strID = "";
            dtpDate.DateTime = DateTime.Now;

            dt.Clear();
            grdOut.DataSource = dt;

            cboCust.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

            //fn_EnableControl("");
            cboCust.Focus();
        }
       
          private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataRow row;
            string strGoldCcy = "", strSL = "", strGia = "", strGhiChu = "";

            if (!fn_CheckValidate()) return;
          
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (grvOut.RowCount > 0)
                {
                    for (int i = 0; i < grvOut.RowCount; i++)
                    {
                        row = grvOut.GetDataRow(i);
                       

                       strGoldCcy += row["GoldCcy"].ToString() + "@";
                       strSL += row["SL"].ToString() + "@";
                       strGia += row["Rate"].ToString() + "@";
                       strGhiChu += row["GhiChu"].ToString() + "@";
                    }
                    strGoldCcy = strGoldCcy.Substring(0, strGoldCcy.Length - 1);
                    strSL = strSL.Substring(0, strSL.Length - 1);
                    strGia = strGia.Substring(0, strGia.Length - 1);
                    strGhiChu = strGhiChu.Substring(0, strGhiChu.Length - 1);
                }
                else
                {
                    strGoldCcy = "";
                    strSL = "";
                    strGia = "";
                    strGhiChu = "";
                }

              

                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_CATGIA_Ins",
                            "", DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("hh:mm:ss"),
                            ((ItemList)cboCust.SelectedItem).ID,
                             strGoldCcy, strSL, strGia, strGhiChu, clsSystem.UserID);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_CATGIA_Upd",
                            strID, DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("hh:mm:ss"),
                            ((ItemList)cboCust.SelectedItem).ID,
                             strGoldCcy, strSL, strGia, strGhiChu, clsSystem.UserID);
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    if (strID == "")
                    {
                        strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                        cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["Status"].ToString(), cboStatus, 0);
                    }
                    ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strStatus = "";

            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    //strStatus = ((ItemList)cboStatus.SelectedItem).ID == "C" ? "W" : "C";
                    strStatus = "C";

                    ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_CATGIA_Complete", strID,((ItemList)cboCust.SelectedItem).ID, strStatus);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                        cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("C", cboStatus, 0);
                       // cboWorker_SelectedIndexChanged(sender, e);
                        cboCust_SelectedIndexChanged(sender, e);
                        
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
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

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (cboCust.SelectedIndex < 0)
                return;
            string strCustID = ((ItemList)cboCust.SelectedItem).ID;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_GETCATGIA", strCustID);
                grdDebt.DataSource = ds.Tables[0];
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            fn_LoadDefault();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedIndex == 0)
                lblStatusName.Text = "{rỗng}";
            else
                lblStatusName.Text = ((ItemList)cboStatus.SelectedItem).Value;
            fn_EnableControl(((ItemList)cboStatus.SelectedItem).ID);
        }
        private void fn_EnableControl(string pStatus)
        {
            if (pStatus == "")
            {
                btnDel.Enabled = false;
                btnSave.Enabled = true;
                btnComplete.Enabled = true;
                cboCust.Enabled = true;
                grvOut.OptionsBehavior.Editable = true;
                
            }

            if (pStatus == "W")
            {
                btnDel.Enabled = true;
                btnSave.Enabled = true;
                btnComplete.Enabled = true;
                cboCust.Enabled = true;

                grvOut.OptionsBehavior.Editable = true;
                
            }

            if (pStatus == "C")
            {
                btnDel.Enabled = false;
                btnSave.Enabled = false;
                btnComplete.Enabled = false;
                cboCust.Enabled = false;

                grvOut.OptionsBehavior.Editable = false;
               
            }
        }
        public void fn_LoadDataToForm()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_CATGIA_Get]", strID);

                dtpDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"];
                cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["CustID"].ToString(), cboCust, 0);
                cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["Status"].ToString(), cboStatus, 0);

                grdOut.DataSource = ds.Tables[0];
                grdDebt.DataSource = ds.Tables[1];
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmRTCatGia_Lst frm = new frmRTCatGia_Lst(this);
            frm.ShowDialog();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (ThongBao.Show("Thông báo", "Hủy cắt giá của khách hàng này?", "OK", "Cancel", ICon.QuestionMark) == DialogResult.Cancel)
                    return;
                ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_CATGIA_CANCEL", ((ItemList)cboCust.SelectedItem).ID);
                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Hủy thành công", "OK", ICon.Information);
                }
                else
                {
                    ThongBao.Show("Thông báo", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Information);
                }

            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.ToString(), "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
                cboCust_SelectedIndexChanged(sender,e);
            }
        }
    }
}