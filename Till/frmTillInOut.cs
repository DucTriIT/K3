using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace GoldRT
{
    public partial class frmTillInOut : DevExpress.XtraEditors.XtraForm
    {
        #region "Private Variables"
        
        private DataTable dtNull = new DataTable();
        string strID;
       
        private bool bIsPrinting = false;
        
        #endregion

        #region "Public Functions"

        public frmTillInOut()
        {
            InitializeComponent();
            this.dtNull.Columns.Add("TrnID", typeof(string));
            this.dtNull.Columns.Add("TrnDateTime", typeof(DateTime));
            this.dtNull.Columns.Add("InOut", typeof(string));
            this.dtNull.Columns.Add("GoldCcy", typeof(string));
            this.dtNull.Columns.Add("Amount", typeof(decimal));
            this.dtNull.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtNull.Columns.Add("TrnDesc", typeof(string));
            this.dtNull.Columns.Add("Status", typeof(string));
            this.dtNull.Columns.Add("StatusName", typeof(string));
            this.dtNull.Columns.Add("ExpensesID", typeof(string));
            this.gridControl.DataSource = this.dtNull;
        }

        #endregion

        #region "Private Functions"

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("TRN_TILL_INOUT_Lst", "", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"), "", "", "", "", "", "", "TrnDateTime DESC");

                if (ds.Tables.Count > 0)
                {
                    gridControl.DataSource = ds.Tables[0];
                   // fn_GetFocusedRowValue();
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

        private void fn_LoadDefault()
        {
            this.strID = String.Empty;
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now;

            btnComplete.Enabled = true;
        }

        private void fn_GetFocusedRowValue()
        {
            try
            {
                if (grdDanhSach.FocusedRowHandle > -1)
                {
                    strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();

                    if (grdDanhSach.GetFocusedRowCellValue("Status").ToString() == "C")
                    {
                        btnComplete.Enabled = false;
                        btnDel.Enabled = false;
                        grdDanhSach.Columns["InOut"].OptionsColumn.AllowEdit = false;
                        grdDanhSach.Columns["Amount"].OptionsColumn.AllowEdit = false;
                        grdDanhSach.Columns["TrnDesc"].OptionsColumn.AllowEdit = false;
                        grdDanhSach.Columns["GoldCcy"].OptionsColumn.AllowEdit = false;
                        grdDanhSach.Columns["DiamondWeight"].OptionsColumn.AllowEdit = false;
                       // grdDanhSach.Columns["ExpensesID"].OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        btnComplete.Enabled = true;
                        btnDel.Enabled = true;
                        grdDanhSach.Columns["InOut"].OptionsColumn.AllowEdit = true;
                        grdDanhSach.Columns["Amount"].OptionsColumn.AllowEdit = true;
                        grdDanhSach.Columns["TrnDesc"].OptionsColumn.AllowEdit = true;
                        grdDanhSach.Columns["GoldCcy"].OptionsColumn.AllowEdit = true;
                       // grdDanhSach.Columns["ExpensesID"].OptionsColumn.AllowEdit = true;
                        if (clsSystem.AllGoldCcy.Tables[0].Select("GoldCcy='" + grdDanhSach.GetFocusedRowCellValue("GoldCcy").ToString() + "'")[0]["Type"].ToString() == "C")
                            grdDanhSach.Columns["DiamondWeight"].OptionsColumn.AllowEdit = false;
                        else
                            grdDanhSach.Columns["DiamondWeight"].OptionsColumn.AllowEdit = true;
                    }
                }
                else
                {
                    this.strID = String.Empty;
                    btnComplete.Enabled = true;
                    btnDel.Enabled = true;
                    grdDanhSach.Columns["InOut"].OptionsColumn.AllowEdit = true;
                    grdDanhSach.Columns["Amount"].OptionsColumn.AllowEdit = true;
                    grdDanhSach.Columns["TrnDesc"].OptionsColumn.AllowEdit = true;
                    grdDanhSach.Columns["GoldCcy"].OptionsColumn.AllowEdit = true;
                   // grdDanhSach.Columns["ExpensesID"].OptionsColumn.AllowEdit = true;
                }
            }
            catch { }
            finally {  }
        }

        private void f_loadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_GOLDCCY", "");
                Functions.BindDropDownList(cboGoldCcy, ds, "GoldCcyDesc", "GoldCcy", true);
                ds.Clear();
                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "T_EXPENSES", "");
                Functions.BindDropDownList(cboExpenses, ds, "ExpensesName", "ExpensesID", true);
                ds.Clear();
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm loadDataToCombo: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

        #endregion

        #region "Event Handlers"

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Vui lòng chọn dữ liệu trước khi thực hiện.", "OK", ICon.Information);
                return;
            }
            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá thông tin đã nhập này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_CASH_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDataToGrid();
                        fn_GetFocusedRowValue();
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fn_LoadDefault();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (bIsPrinting)
            {
                bIsPrinting = false;
                return;
            }

            DataRowView dr = (DataRowView)e.Row;
            if (dr["Status"].ToString() == "C") return;
            //Kiểm tra dữ liệu
            if (String.IsNullOrEmpty(dr["InOut"].ToString()))
            {
                fn_LoadDataToGrid();
                ThongBao.Show("Lỗi", "Vui lòng chọn thông tin Thu/ Chi.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = e.RowHandle;
                return;
            }
            if (String.IsNullOrEmpty(dr["Amount"].ToString()) || (Decimal)dr["Amount"] < Decimal.Zero)
            {
                fn_LoadDataToGrid();
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột Số tiền.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = e.RowHandle;
                return;
            }
            if (String.IsNullOrEmpty(dr["GoldCcy"].ToString()) )
            {
                fn_LoadDataToGrid();
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột loại dẻ/tiền .", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = e.RowHandle;
                return;
            }
            //if (String.IsNullOrEmpty(dr["ExpensesID"].ToString()))
            //{
            //    fn_LoadDataToGrid();
            //    ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột hạng mục.", "OK", ICon.Error);
            //    grdDanhSach.FocusedRowHandle = e.RowHandle;
            //    return;
            //}
            //--> Dữ liệu hợp lệ --> Cập nhật
            DataSet ds = new DataSet();
            this.Cursor = Cursors.WaitCursor;
            try
            {   
                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_TILL_INOUT_Ins]", "", dr["InOut"].ToString(),
                        dr["GoldCcy"].ToString(), dr["Amount"].ToString(), dr["DiamondWeight"].ToString(),// dr["ExpensesID"].ToString(),
                        dr["TrnDesc"].ToString(), "W", clsSystem.UserID);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_TILL_INOUT_Upd]", strID, dr["InOut"].ToString(),
                        dr["GoldCcy"].ToString(), dr["Amount"], dr["DiamondWeight"],// dr["ExpensesID"].ToString(),
                        dr["TrnDesc"].ToString(), "W", clsSystem.UserID);
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    fn_LoadDataToGrid();
            
                  //  fn_GetFocusedRowValue();
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                ds.Dispose();
                this.Cursor = Cursors.Default;
                return;
            }
            finally
            {
               
               // btnComplete.Focus();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void grdDanhSach_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                
                string strInOut = grdDanhSach.GetRowCellValue(e.RowHandle, grdDanhSach.Columns["InOut"]).ToString();
                decimal dCurVal = Decimal.Parse(grdDanhSach.GetRowCellValue(e.RowHandle, grdDanhSach.Columns["Amount"]).ToString());
                dCurVal = strInOut == "I" ? dCurVal : -dCurVal;
                e.TotalValue = Decimal.Parse(e.TotalValue == null ? "0" : e.TotalValue.ToString()) + dCurVal;
            }
        }

        private void grdDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fn_GetFocusedRowValue();
            btnComplete.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void frmTillInOut_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDefault();
            f_loadDataToCombo();
            fn_LoadDataToGrid();

            if (clsSystem.TillID == "")
            {
                ThongBao.Show("Lỗi", "Vui lòng mở mở Quầy trước khi trước khi hoàn tất giao dịch thu/chi.", "OK", ICon.Error);

                btnComplete.Enabled = false;
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (strID != "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_TILL_INOUT_Complete]", strID, clsSystem.TillID, clsSystem.UserID);
                }
                else
                {
                    ThongBao.Show("Thông báo", "Vui lòng chọn dữ liệu trước khi thực hiện.", "OK", ICon.Error);
                    return;
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo","Thực hiện thành công","OK",ICon.Information);
                    fn_LoadDataToGrid();
                    fn_GetFocusedRowValue();
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
            }
            catch
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strIDs = "";
            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {
                if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() == "True")
                {
                    strIDs += grdDanhSach.GetRowCellValue(i, "TrnID").ToString() + "@";
                }
            }

            if (strIDs != "")
            {
                strIDs = strIDs.Substring(0, strIDs.Length - 1);
                DataSet ds = new DataSet();
                string strParams = "", strValues = "";

                strParams = "FromDate@ToDate";
                strValues = dtpTuNgay.DateTime.ToString("dd/MM/yyyy") + "@" + dtpDenNgay.DateTime.ToString("dd/MM/yyyy");
                ds = clsCommon.ExecuteDatasetSP("[rptTillInOut]", strIDs);

                Functions.fn_ShowReport(ds, "rptTillInOut.rpt", strParams, strValues);
            }
            else
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn dữ liệu In.", "OK", ICon.Error);
                return;
            }
        }

        private void grdDanhSach_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && grdDanhSach.FocusedRowHandle >= 0)
                {
                    GridHitInfo hInfo = grdDanhSach.CalcHitInfo(new Point(e.X, e.Y));
                    if (hInfo.InRowCell && hInfo.Column.Name == "colChon")
                    {
                        string curValue = grdDanhSach.GetRowCellValue(hInfo.RowHandle, hInfo.Column).ToString();
                        if (curValue != "")
                        {
                            bIsPrinting = true;
                            grdDanhSach.SetRowCellValue(hInfo.RowHandle, hInfo.Column, curValue == "True" ? "False" : "True");
                        }
                    }

                    if (hInfo.InRowCell && hInfo.Column.Name != "colChon")
                    {
                        bIsPrinting = false;
                    }

                    if (hInfo.InColumnPanel && hInfo.Column.Name == "colChon")
                    {
                        if (hInfo.Column.ImageIndex == 0)
                        {
                            for (int i = 0; i < grdDanhSach.RowCount; i++)
                            {
                                if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() != "")
                                {
                                    bIsPrinting = true;
                                    grdDanhSach.SetRowCellValue(i, hInfo.Column, "True");
                                }
                            }
                            hInfo.Column.ImageIndex = 1;
                        }
                        else
                        {
                            for (int i = 0; i < grdDanhSach.RowCount; i++)
                            {
                                if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() != "")
                                {
                                    bIsPrinting = true;
                                    grdDanhSach.SetRowCellValue(i, hInfo.Column, "False");
                                }
                            }
                            hInfo.Column.ImageIndex = 0;
                        }
                    }
                }
            }
            catch { }
        }

        private void cboGoldCcy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboGoldCcy_SelectedValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit cboEdit = (ImageComboBoxEdit)sender;
            DataRow[] rows = clsSystem.AllGoldCcy.Tables[0].Select("GoldCcy='" + (cboEdit.SelectedItem as DevExpress.XtraEditors.Controls.ComboBoxItem).Value + "'");

            if (rows.Length == 0 || rows[0]["Type"].ToString() == "C")
            {
                grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["DiamondWeight"], DBNull.Value);
                grdDanhSach.Columns["DiamondWeight"].OptionsColumn.AllowEdit = false;
            }
            else
            {
                grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["DiamondWeight"], 0);
                grdDanhSach.Columns["DiamondWeight"].OptionsColumn.AllowEdit = true;
            }

            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["GoldCcy"], cboEdit.Value);
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Vui lòng chọn dữ liệu trước khi thực hiện.", "OK", ICon.Information);
                return;
            }
            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá thông tin đã nhập này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_TILL_INOUT_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDataToGrid();
                        fn_GetFocusedRowValue();
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                }
            }
        }

        #endregion

        private void cboExpenses_SelectedValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit cboEdit = (ImageComboBoxEdit)sender;
            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["ExpensesID"], cboEdit.Value);
            
        }

        private void frmTillInOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsSystem.IsScan)
                FunctionTill.fn_CloseTill();
        }
    }
}