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
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace GoldRT
{
    public partial class frmTillProcess : DevExpress.XtraEditors.XtraForm
    {
        
        public frmTillProcess()
        {
            InitializeComponent();
            timer1.Start();
        }
        
        private void frmTillProcess_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            fn_LoadDefault();
            fn_LoadDataToGrid();
            if (clsSystem.IsPayCard)
            {
                this.PayCard.Visible = true;
                this.PayCard.VisibleIndex = 10;
            }
            else this.PayCard.Visible = false;
            //if (clsSystem.UserID != "0")
            //    btnAssigned.Dispose();
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                //ds = clsCommon.ExecuteDatasetSP("T_TILL_TXN_Lst", "", "", "", dtpDate.DateTime.ToString("dd/MM/yyyy"), "",
                //"", "", ((ItemList)cboCust.SelectedItem).ID, "", "", "", "");
                
                    ds = clsCommon.ExecuteDatasetSP("T_TILL_TXN_Lst", "", "", "",
                        ((DateTime)dtpFromDate.EditValue).ToString("dd/MM/yyyy"), ((DateTime)dtpToDate.EditValue).ToString("dd/MM/yyyy"),
                        "", ((ItemList)cboTrnType.SelectedItem).ID, "", ((ItemList)cboCust.SelectedItem).ID, "", "", ((ItemList)cboStatus.SelectedItem).ID, "", "",clsSystem.UserID);
              

                grdControl.DataSource = ds.Tables[0];
               
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
            finally { ds.Dispose(); } 
        }

        private void grdDanhSach_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GridHitInfo hInfo = grdDanhSach.CalcHitInfo(new Point(e.X, e.Y));
                if (hInfo.InRowCell && hInfo.Column.Name == "colSelect")
                {
                    string curValue = grdDanhSach.GetRowCellValue(hInfo.RowHandle, hInfo.Column).ToString();
                    if (curValue != "")
                        grdDanhSach.SetRowCellValue(hInfo.RowHandle, hInfo.Column, curValue == "1" ? "0" : "1");
                }

                if (hInfo.InColumnPanel && hInfo.Column.Name == "colSelect")
                {
                    if (hInfo.Column.ImageIndex == 0)
                    {
                        for (int i = 0; i < grdDanhSach.RowCount; i++)
                        {
                            grdDanhSach.SetRowCellValue(i, hInfo.Column, "1");
                        }
                        hInfo.Column.ImageIndex = 1;
                    }
                    else
                    {
                        for (int i = 0; i < grdDanhSach.RowCount; i++)
                        {
                            grdDanhSach.SetRowCellValue(i, hInfo.Column, "0");
                        }
                        hInfo.Column.ImageIndex = 0;
                    }
                }
            }
        }

        private void fn_LoadDefault()
        {
            dtpToDate.DateTime = DateTime.Now;
            dtpFromDate.DateTime = DateTime.Now.AddDays(-15);
            cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("P", cboStatus, 0);
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_TRNTYPE", "");
                Functions.BindDropDownList(cboTrnType, ds, "TrnTypeDesc", "TrnType", "", true );
                ds.Clear();

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_CUSTOMER", "ALL");
                Functions.BindDropDownList(cboCust, ds, "CustName", "CustID", "", true);
                ds.Clear();

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "T_STATUS", "TILLTRN");
                Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn thanh toán giao dịch này?", "Có", "Không", ICon.QuestionMark) != DialogResult.OK)
                return;
            DataSet ds = new DataSet();
            string strTillTxnID = "", strTillID = "", TrnRefID = "";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // Duyet qua grid ed lay cac giao dich duoc chon
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colSelect"]).ToString() == "1")
                    {
                        strTillTxnID += grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TillTxnID"]) + "@";
                        TrnRefID += grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnRefID"]) + "@";
                    }
                }

                if (TrnRefID != "")
                {
                    frmTillProccessTxn frm = new frmTillProccessTxn(TrnRefID);
                    //frm.ShowDialog();
                    fn_LoadDataToGrid();
                }
                else
                {
                    ThongBao.Show("Thông báo", "Vui lòng chọn giao dịch cần thanh toán.", "OK", ICon.Warning);
                    return;
                }

                //if (strTillTxnID != "")
                //{
                //    strTillTxnID = strTillTxnID.Substring(0, strTillTxnID.Length - 1);
                //}

                //strTillID = clsSystem.TillID;

                //if (strTillTxnID != "")
                //{
                //    ds = clsCommon.ExecuteDatasetSP("T_TILL_TXN_Proc", strTillTxnID, strTillID, clsSystem.UserID);

                //    if (ds.Tables[0].Rows.Count != 0)
                //    {
                //        if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                //        {
                //            ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString() + " [" + ds.Tables[0].Rows[0]["ErrorCode"].ToString() + "]", "OK", ICon.Error);
                //        }
                //        else
                //        {
                //            ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);            
                //            fn_LoadDataToGrid();
                //        }
                //    }
                //}
                //else
                //{
                //    ThongBao.Show("Thông báo", "Vui lòng chọn giao dịch cần thanh toán.", "OK", ICon.Warning);
                //}
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", "Hàm RowUpdated: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                //fn_LoadDataToGrid();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strTrnRefID = "";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // Duyet qua grid ed lay cac giao dich duoc chon
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colSelect"]).ToString() == "1")
                    {                        
                        strTrnRefID += grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnRefID"]) + "@";
                    }
                }

                if (strTrnRefID != "")
                {
                    string strParams, strValues;

                    strParams = "TillName";
                    strValues = clsSystem.TillName;

                    ds = clsCommon.ExecuteDatasetSP("rptPrintTrn", strTrnRefID);
                    Functions.fn_ShowReport(ds, "rptPrintTrn.rpt", strParams, strValues);
                  
                }
                else
                {
                    ThongBao.Show("Thông báo", "Vui lòng chọn giao dịch cần in.", "OK", ICon.Warning);
                }               
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", "btnPrint_Click RowUpdated: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                //fn_LoadDataToGrid();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnHuyThanhToan_Click(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            string trnRefIDs = "";
            string trnCodes = "";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // Duyet qua grid ed lay cac giao dich duoc chon
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colSelect"]).ToString() == "1"&&grdDanhSach.GetRowCellValue(i,grdDanhSach.Columns["Status"]).ToString()=="P")
                    {
                        trnRefIDs = grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnRefID"]).ToString() ;
                        trnCodes = grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnCode"]).ToString();
                        if (trnRefIDs != "")
                        {
                            ds = clsCommon.ExecuteDatasetSP("[T_TILL_TXN_Del]", trnRefIDs, trnCodes);                       
                        }
                    }
                }
                //if (trnRefIDs != "")
                //{
                //    ds = clsCommon.ExecuteDatasetSP("[T_TILL_TXN_Del]", trnRefIDs, trnCodes);

                //    if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                //    {
                        
                //    }
                //    else
                //    {
                //        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                //    }
                //}
                //else
                //{
                //    ThongBao.Show("Thông báo", "Vui lòng chọn giao dịch cần duyệt.", "OK", ICon.Warning);
                //}
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", "Hàm RowUpdated: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                fn_LoadDataToGrid();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int a = grdDanhSach.RowCount;
            fn_LoadDataToGrid();
            if (grdDanhSach.RowCount > a)
            {
                for (int i = a ; i < grdDanhSach.RowCount; i++)
                {
                    grdDanhSach.FocusedRowHandle = i;
                    grdDanhSach.TopRowIndex = i;
                    grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["colSelect"], 1);                 
                }
            }
            
            
        }

        private void grdDanhSach_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {//CustomColumnDisplayTextEventArgs 
            if (e.Column.Name == "STT")
            { 
                if (e.ListSourceRowIndex >= 0)
                {
                    e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
                }
            } 
        }

        private void btnChangeProduct_Click(object sender, EventArgs e)
        {
            string strID = grdDanhSach.GetFocusedRowCellValue("TrnRefID").ToString();
            string status = grdDanhSach.GetFocusedRowCellValue("Status").ToString();
            string strTrnCode = grdDanhSach.GetFocusedRowCellValue("TrnCode").ToString();
            string strBillCode = grdDanhSach.GetFocusedRowCellValue("BillCode").ToString();
            decimal dMoneyBill = decimal.Parse(grdDanhSach.GetFocusedRowCellValue("TrnTotalAmount").ToString());
            frmRTChangeProduct frm = new frmRTChangeProduct(strID, strBillCode, status, strTrnCode, dMoneyBill);
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }

        private void btnAssigned_Click(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            string trnRefIDs = "";
            string trnCodes = "";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // Duyet qua grid ed lay cac giao dich duoc chon
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colSelect"]).ToString() == "1" && grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["Status"]).ToString() == "P")
                    {
                        trnRefIDs = grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnRefID"]).ToString();
                        trnCodes = grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnCode"]).ToString();
                        if (trnRefIDs != "")
                        {
                            ds = clsCommon.ExecuteDatasetSP("[T_TILL_TXN_Assigned]", trnRefIDs, trnCodes);
                        }
                    }
                }
               

                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0"&&trnRefIDs!="")
                {
                    ThongBao.Show("Thông báo", "Giao dẻ thành công.", "OK", ICon.Warning);
                }
       
            }
            catch(Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", "Hàm RowUpdated: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                fn_LoadDataToGrid();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }
    }
}