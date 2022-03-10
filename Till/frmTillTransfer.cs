using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using DevExpress.XtraEditors.Repository;

namespace GoldRT
{
    public partial class frmTillTransfer : DevExpress.XtraEditors.XtraForm
    {
        string m_strTrnID;
        string m_strTillID;
        string m_strTillCode;
        string m_strTillName;

        public frmTillTransfer()
        {
            InitializeComponent();
            m_strTrnID = "";
            m_strTillID = clsSystem.TillID;
            m_strTillCode = clsSystem.TillCode;
            m_strTillName = clsSystem.TillName;
        }

        private void f_loadDefault()
        {
            //lblFromTill.Text = clsSystem.TillCode + " - " + clsSystem.TillName;
        }

        private void f_loadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("TILLALL", m_strTillID);//TILLNOTCURRENT
                Functions.BindDropDownList(cboToTill, ds, "TillName", "TillID", "", true);
                Functions.BindDropDownList(cboFromTill, ds, "TillName", "TillID", "", true);
                ds.Clear();
            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm loadDataToCombo: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void f_loadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("TRN_TILL_TransferQueryBal", ((ItemList)cboFromTill.SelectedItem).ID);//m_strTillID =TIL110400000001
                grdControl.DataSource = ds.Tables[0];
                grdDanhSach.UpdateCurrentRow();
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm loadDataToGrid: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private bool f_checkValidate()
        {
            if (cboFromTill.SelectedIndex == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn quầy chuyển.", "OK", ICon.Error);
                cboFromTill.Focus();
                return false;
            }
            if (cboToTill.SelectedIndex == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn quầy nhận.", "OK", ICon.Error);
                cboToTill.Focus();
                return false;
            }
            if (cboToTill.SelectedIndex == cboFromTill.SelectedIndex)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn quầy nhận khác quầy chuyển.", "OK", ICon.Error);
                cboToTill.Focus();
                return false;
            }   
            return true;
        }

        private bool f_checkValidateDetails(DataRow dr, int index)
        {

            if (Decimal.Parse(dr["Amount"].ToString()) < Decimal.Zero) //String.IsNullOrEmpty(dr["Amount"].ToString()) || 
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập Số lượng/ Trọng lượng lớn hơn 0.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            if (decimal.Parse(dr["TillBal"].ToString()) < decimal.Parse(dr["Amount"].ToString()))
            {
                ThongBao.Show("Lỗi", "Số dự hiện tại không đủ.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            return true;
        }

        private void frmTillTransfer_Load(object sender, EventArgs e)
        {
            //Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            f_loadDefault();
            f_loadDataToCombo();
            if (clsSystem.TillID != "")
            {
                cboFromTill.SelectedIndex = Functions.GetSelectedIndexCombo(clsSystem.TillID, cboFromTill, 0);
            }
            //f_loadDataToGrid();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (m_strTrnID == "")
            {
                ThongBao.Show("Lỗi", "Vui lòng cập nhật thông tin trước khi hoàn tất.", "OK", ICon.Error);
                return;
            }

            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("TRN_TILL_TRANSFER_Complete", m_strTrnID, clsSystem.UserID);
                if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                    m_strTrnID = "";
                    f_loadDataToGrid();
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    return;
                }
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!f_checkValidate()) return;

            DataSet ds = new DataSet();
            
            //Các biến chứa tham số Details
            string strGoldCcys = String.Empty;
            string strAmounts = String.Empty;
            string strAmount_Diamonds = String.Empty;

            try
            {
                if (grdDanhSach.RowCount > 0)
                {
                    for (int i = 0; i < grdDanhSach.RowCount; i++)
                    {
                        
                        DataRow row = grdDanhSach.GetDataRow(i);

                        if (decimal.Parse(row["Amount"].ToString()) != 0 || decimal.Parse(row["Amount_Diamond"].ToString()) != 0)                  
                        { 
                           if (!f_checkValidateDetails(row, i)) return;
                           strGoldCcys += row["GoldCcy"].ToString() + "@";
                           strAmounts += (row["Amount"].ToString() == "" ? "0" : row["Amount"].ToString()) + "@";
                           strAmount_Diamonds += (row["Amount_Diamond"].ToString() == "" ? "0" : row["Amount_Diamond"].ToString()) + "@";
                        }
                    }
                    
                    strGoldCcys = strGoldCcys.Substring(0, strGoldCcys.Length - 1);                    
                    strAmounts = strAmounts.Substring(0, strAmounts.Length - 1);                    
                    strAmount_Diamonds = strAmount_Diamonds.Substring(0, strAmount_Diamonds.Length - 1);

                    if (String.IsNullOrEmpty(m_strTrnID)) //Add new 
                    {
                        //m_strTillID: Quay Chuyen 
                        ds = clsCommon.ExecuteDatasetSP("[TRN_TILL_TRANSFER_Ins]", "", ((ItemList)cboFromTill.SelectedItem).ID,
                            ((ItemList)cboToTill.SelectedItem).ID, clsSystem.UserID, strGoldCcys, strAmounts, strAmount_Diamonds);

                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                            {
                                ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                                //Kết thúc cập nhật => thành công
                                //this.strStatus = "P";
                                //cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("P", cboStatus, 0);
                                this.m_strTrnID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                                //fn_SetFormToEdit(true);
                            }
                            else
                            {
                                ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                                return;
                            }
                        }
                    }
                    else //Update
                    {
                        //m_strTillID: Quay Chuyen
                        ds = clsCommon.ExecuteDatasetSP("[TRN_TILL_TRANSFER_Upd]", m_strTrnID, ((ItemList)cboFromTill.SelectedItem).ID,
                            ((ItemList)cboToTill.SelectedItem).ID, clsSystem.UserID, strGoldCcys, strAmounts);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                            {
                                ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                                //Kết thúc cập nhật => thành công
                                //this.strStatus = "P";
                                //cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("P", cboStatus, 0);
                                //this.strID = ds.Tables[0].Rows[0]["GoldPOID"].ToString();
                                //fn_SetFormToEdit(true);
                            }
                            else
                            {
                                ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập chi tiết toa.", "OK", ICon.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();                
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (m_strTrnID == "")
            {
                ThongBao.Show("Lỗi", "Vui lòng cập nhật thông tin trước khi In.", "OK", ICon.Error);
                return;
            }

            DataSet ds = new DataSet();
            string strParams = "", strValues = "";

            strParams = "Unit";
            strValues = clsSystem.UnitWeight;
            ds = clsCommon.ExecuteDatasetSP("rptTillTransfer", m_strTrnID);

            Functions.fn_ShowReport(ds, "rptTillTransfer.rpt", strParams, strValues);
        }

        private void rtxtAmount_Diamond_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (grdDanhSach.GetFocusedRowCellValue("Type").ToString() == "C")
            {
                e.Cancel = true;
            }
        }

        private void cboFromTill_EditValueChanged(object sender, EventArgs e)
        {
            if (cboToTill.SelectedIndex == cboFromTill.SelectedIndex && cboToTill.SelectedIndex != 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn quầy nhận khác quầy chuyển.", "OK", ICon.Error);
                cboToTill.Focus();
             //   return false;
            } 
            f_loadDataToGrid();
        }

        private void grdDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            
        }

        private void cboFromTill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboToTill_EditValueChanged(object sender, EventArgs e)
        {
            if (cboToTill.SelectedIndex == cboFromTill.SelectedIndex && cboToTill.SelectedIndex!=0 )
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn quầy nhận khác quầy chuyển.", "OK", ICon.Error);
                cboToTill.Focus();
                
            } 
        }

        //private void grdDanhSach_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{            
        //    if (e.Column.FieldName == "Amount_Diamond" && )
        //    {
                
        //    }
        //}

        //private void grdDanhSach_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    //e.Column.
        //}

    }
}