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

namespace GoldRT
{
    public partial class frmTrnWorker : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtIn  = new DataTable();
        private DataTable dtOut = new DataTable();

        public string strID = "";
        
        public frmTrnWorker()
        {
            InitializeComponent();
        }

        private void fn_createDataTable()
        {
            this.dtOut.Columns.Add("GoldCode", typeof(string));
            this.dtOut.Columns.Add("TotalWeight", typeof(decimal));
            this.dtOut.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtOut.Columns.Add("GoldAge", typeof(decimal));
            this.dtOut.Columns.Add("GoldAgeChange", typeof(decimal));
            this.dtOut.Columns.Add("GoldWeightChange", typeof(decimal));
            this.dtOut.Columns.Add("PGoldCode", typeof(string));

            this.dtIn.Columns.Add("PGoldCode", typeof(string));
            this.dtIn.Columns.Add("ProductDesc", typeof(string));
            this.dtIn.Columns.Add("TotalWeight", typeof(decimal));
            this.dtIn.Columns.Add("GoldWeight", typeof(decimal));
            this.dtIn.Columns.Add("Notes", typeof(string));
            this.dtIn.Columns.Add("TaskPrice", typeof(decimal));
        }
        private decimal fn_CalRate()
        {
            decimal heso;
            if (clsSystem.UnitWeight == "L") heso = 1000;
            else if (clsSystem.UnitWeight == "C") heso = 100;
            else if (clsSystem.UnitWeight == "P") heso = 10;
            else heso = 1;
            return heso;

        }
        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("T_WORKER", "");
            Functions.BindDropDownList(cboWorker, ds, "WorkerName", "WorkerID", "", true);
            ds.Clear();


            ds = clsCommon.LoadComboSP("I_GOLD_PRICEUINT", "L");
            Functions.BindDropDownList(cboGoldCode_In, ds, "GoldDesc", "GoldCode", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("I_GOLD", "D_RT");
            Functions.BindDropDownList(cboGoldCode_Out, ds, "GoldDesc", "GoldCode", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("I_GOLD_PRICEUINT", "L");
            Functions.BindDropDownList(cboPGodlCode_Out, ds, "GoldDesc", "GoldCode", true);
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

            dtOut.Clear();
            dtIn.Clear();
            grdOut.DataSource = dtOut;
            grdIn.DataSource = dtIn;

            cboWorker.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;//Functions.GetSelectedIndexCombo("W", cboStatus, 0);
            txtNo.EditValue = 0;
            txtSoTienThanhToan.EditValue = 0;
            txtSoTienTra.EditValue = 0;
            fn_EnableControl("");
            //fn_EnableControl("");
            cboWorker.Focus();
        }

        public void fn_LoadDataToForm()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_WORKER_Get]", strID);

                dtpDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"];
                cboWorker.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["WorkerID"].ToString(), cboWorker, 0);
                cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["Status"].ToString(), cboStatus, 0);
                txtSoTienThanhToan.EditValue = ds.Tables[0].Rows[0]["TotalAmount"];
                txtSoTienTra.EditValue = ds.Tables[0].Rows[0]["PayAmount"];
                txtNo.EditValue = ds.Tables[0].Rows[0]["DebitAmount"];
                //cboLoaiVangQuyDoi.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldChange"].ToString(), cboLoaiVangQuyDoi, 0);

                grdOut.DataSource = ds.Tables[1];
                grdIn.DataSource = ds.Tables[2];
                grdDebt.DataSource = ds.Tables[3];
                fn_EnableControl(ds.Tables[0].Rows[0]["Status"].ToString());
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

        private void frmTrnWorker_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            
            fn_createDataTable();

            grdIn.DataSource = dtIn;
            grdOut.DataSource = dtOut;

            fn_LoadDataToCombo();
            fn_LoadDefault();
        }

        private void cboWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (cboWorker.SelectedIndex < 0)
                return;
            string strWorkerID = ((ItemList)cboWorker.SelectedItem).ID;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_WORKER_GetDebtByID", strWorkerID);
                grdDebt.DataSource = ds.Tables[0];
                grvIn.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                grvOut.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
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
        private string Check_PriceUnit(string _GoldCCy)
        {
            try
            {
                DataRow rowIGold = Functions.fn_GetIGold(_GoldCCy);
                return rowIGold["PriceUnit"].ToString();
            }
            catch { return ""; }
            { }
        }
        private bool fn_CheckValidate()
        {

            if (cboWorker.Text == "")
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn thợ.", "OK", ICon.Error);
                cboWorker.Focus();
                return false;
            }

            return true;
        }
        private void fn_AddWorker()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_WORKER_Ins]", "", "", cboWorker.Text.Trim(),
                         "1");
                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    string strWorkerID = ds.Tables[0].Rows[0]["WorkerID"].ToString();

                    DataSet ds1 = clsCommon.LoadComboSP("T_WORKER", "");
                    Functions.BindDropDownList(cboWorker, ds1, "WorkerName", "WorkerID", strWorkerID, true);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataRow row;
            decimal dO_TotalWeight = 0, dO_TotalDiamondWeight = 0, dO_TotalGoldWeightChange = 0;
            string strOGoldCodes = "", strOTotalWeight = "", strODiamondWeight = "", strOGoldWeightChange = "", strOPGoldCodes = "";

            decimal dI_TotalWeight = 0, dI_TotalGoldWeight = 0;
            string strIGoldCodes = "", strIProductDescs = "";
            string strITotalWeight = "", strIGoldWeight = "";
            string strNotes = "", strITaskPrice = "";

            if (!fn_CheckValidate()) return;
            if (cboWorker.SelectedIndex < 0)
            {
                fn_AddWorker();
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (grvOut.RowCount > 0)
                {
                    for (int i = 0; i < grvOut.RowCount; i++)
                    {
                        row = grvOut.GetDataRow(i);
                        dO_TotalWeight += Check_PriceUnit(row["GoldCode"].ToString()) == "L" ? decimal.Parse(row["TotalWeight"].ToString()) * clsSystem.HSTL :decimal.Parse(row["TotalWeight"].ToString());
                        dO_TotalDiamondWeight += Check_PriceUnit(row["GoldCode"].ToString()) == "L" ? decimal.Parse(row["DiamondWeight"].ToString()) * clsSystem.HSTL : decimal.Parse(row["DiamondWeight"].ToString());
                        dO_TotalGoldWeightChange += Check_PriceUnit(row["PGoldCode"].ToString()) == "L" ? decimal.Parse(row["GoldWeightChange"].ToString()) * clsSystem.HSTL : decimal.Parse(row["GoldWeightChange"].ToString());

                        strOGoldCodes += row["GoldCode"].ToString() + "@";
                        strOTotalWeight += row["TotalWeight"].ToString() + "@";
                        strODiamondWeight += row["DiamondWeight"].ToString() + "@";
                        strOGoldWeightChange += row["GoldWeightChange"].ToString() + "@";
                        strOPGoldCodes += row["PGoldCode"].ToString() + "@";
                    }
                    strOGoldCodes = strOGoldCodes.Substring(0, strOGoldCodes.Length - 1);
                    strOTotalWeight = strOTotalWeight.Substring(0, strOTotalWeight.Length - 1);
                    strODiamondWeight = strODiamondWeight.Substring(0, strODiamondWeight.Length - 1);
                    strOGoldWeightChange = strOGoldWeightChange.Substring(0, strOGoldWeightChange.Length - 1);
                    strOPGoldCodes = strOPGoldCodes.Substring(0, strOPGoldCodes.Length - 1);
                }
                else
                {
                    strOGoldCodes = "";
                    strOTotalWeight = "";
                    strODiamondWeight = "";
                    strOGoldWeightChange = "";
                    strOPGoldCodes = "";
                }

                if (grvIn.RowCount > 0)
                {
                    for (int i = 0; i < grvIn.RowCount; i++)
                    {
                        row = grvIn.GetDataRow(i);

                        dI_TotalWeight += Check_PriceUnit(row["PGoldCode"].ToString()) == "L" ? decimal.Parse(row["TotalWeight"].ToString()) * clsSystem.HSTL : decimal.Parse(row["TotalWeight"].ToString());
                        dI_TotalGoldWeight += Check_PriceUnit(row["PGoldCode"].ToString()) == "L" ? decimal.Parse(row["GoldWeight"].ToString()) * clsSystem.HSTL : decimal.Parse(row["GoldWeight"].ToString());

                        strIGoldCodes += row["PGoldCode"].ToString() + "@";
                        strIProductDescs += row["ProductDesc"].ToString() + "@";                        
                        strITotalWeight += row["TotalWeight"].ToString() + "@";
                        strIGoldWeight += row["GoldWeight"].ToString() + "@";
                        //if (row["Qty"].ToString() == "")
                        //{
                        //    ThongBao.Show("Thông báo", "Vui lòng nhập số lượng", "OK", ICon.Error);
                        //    grvIn.FocusedColumn = grvIn.Columns["Qty"];
                        //    return;
                        //}
                        //if (row["TaskPrice"].ToString() == "")
                        //{
                        //    ThongBao.Show("Thông báo", "Vui lòng nhập tiền công", "OK", ICon.Error);
                        //    grvIn.FocusedColumn = grvIn.Columns["TaskPrice"];
                        //    return;
                        //}
                        //strIQty += row["Qty"].ToString() + "@";
                        strNotes += row["Notes"].ToString() + "@";
                        strITaskPrice += row["TaskPrice"].ToString() + "@";
                    }
                    strIGoldCodes = strIGoldCodes.Substring(0, strIGoldCodes.Length - 1);
                    strIProductDescs = strIProductDescs.Substring(0, strIProductDescs.Length - 1);
                    strITotalWeight = strITotalWeight.Substring(0, strITotalWeight.Length - 1);
                    strIGoldWeight = strIGoldWeight.Substring(0, strIGoldWeight.Length - 1);
                    strNotes = strNotes.Substring(0, strNotes.Length - 1);
                    strITaskPrice = strITaskPrice.Substring(0, strITaskPrice.Length - 1);
                }
                else
                {
                    strIGoldCodes = "";
                    strIProductDescs = "";
                    strITotalWeight = "";
                    strIGoldWeight = "";
                    strNotes = "";
                    strITaskPrice = "";
                }

                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("TRN_WORKER_Ins",
                            "", DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("hh:mm:ss"),
                            ((ItemList)cboWorker.SelectedItem).ID,
                            dO_TotalWeight.ToString(),
                            dO_TotalDiamondWeight.ToString(),
                            dO_TotalGoldWeightChange.ToString(),
                            dI_TotalWeight.ToString(),
                            dI_TotalGoldWeight.ToString(),
                            "W", clsSystem.UserID, 
                            strOGoldCodes, strOTotalWeight, strODiamondWeight, strOGoldWeightChange, strOPGoldCodes,
                            strIGoldCodes, strIProductDescs, strITotalWeight, strIGoldWeight,strNotes,strITaskPrice,
                             txtSoTienThanhToan.EditValue, txtSoTienTra.EditValue, txtNo.EditValue);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_WORKER_Upd]",
                            strID, DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("hh:mm:ss"),
                            ((ItemList)cboWorker.SelectedItem).ID,
                            dO_TotalWeight.ToString(),
                            dO_TotalDiamondWeight.ToString(),
                            dO_TotalGoldWeightChange.ToString(),
                            dI_TotalWeight.ToString(),
                            dI_TotalGoldWeight.ToString(),
                            "W", clsSystem.UserID,
                            strOGoldCodes, strOTotalWeight, strODiamondWeight, strOGoldWeightChange, strOPGoldCodes,
                            strIGoldCodes, strIProductDescs, strITotalWeight, strIGoldWeight, strNotes, strITaskPrice,
                             txtSoTienThanhToan.EditValue, txtSoTienTra.EditValue, txtNo.EditValue);
                }

                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
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

        private void fn_EnableControl(string pStatus)
        {
            if (pStatus == "")
            {
                btnDel.Enabled = false;
                btnSave.Enabled = true;
                btnComplete.Enabled = true;
                cboWorker.Enabled = true;
                btnComplete.Enabled = false;
               // btnIn.Enabled = false;
                txtSoTienTra.Properties.ReadOnly = false;
                grvIn.OptionsBehavior.Editable = true;
                grvOut.OptionsBehavior.Editable = true;
            }

            if (pStatus == "W")
            {
                btnDel.Enabled = true;
                btnSave.Enabled = true;
                btnComplete.Enabled = true;
                //btnIn.Enabled = true;
                cboWorker.Enabled = true;
                txtSoTienTra.Properties.ReadOnly = false;
                grvIn.OptionsBehavior.Editable = true;
                grvOut.OptionsBehavior.Editable = true;
            }

            if (pStatus == "C")
            {
                btnDel.Enabled = false;
                btnSave.Enabled = false;
                btnComplete.Enabled = false;
               // btnIn.Enabled = false;
                cboWorker.Enabled = false;
                txtSoTienTra.Properties.ReadOnly = true;
                grvIn.OptionsBehavior.Editable = false;
                grvOut.OptionsBehavior.Editable = false;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_WORKER_Del]", strID);
                    if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                    else
                    {
                        ThongBao.Show("Thông báo", "Xóa toa hàng thành công.", "OK", ICon.Information);
                        fn_LoadDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //string strStatus = "";

            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    //strStatus = ((ItemList)cboStatus.SelectedItem).ID == "C" ? "W" : "C";
                   // strStatus = "C";

                    ds = clsCommon.ExecuteDatasetSP("TRN_WORKER_Complete", strID, clsSystem.UserID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                        cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("C", cboStatus, 0);
                        cboWorker_SelectedIndexChanged(sender, e);
                        fn_EnableControl("C");
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

        private void btnList_Click(object sender, EventArgs e)
        {
            frmTrnWorkerLst frm = new frmTrnWorkerLst(this);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu trước khi thoát không?", "Thông báo", MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
                btnSave_Click(sender, e);
            else if (dialogResult == DialogResult.No)
                this.Close();
            else
                return;
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedIndex == 0)
                lblStatusName.Text = "{rỗng}";
            else
                lblStatusName.Text = ((ItemList)cboStatus.SelectedItem).Value;
            fn_EnableControl(((ItemList)cboStatus.SelectedItem).ID);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fn_LoadDefault();
            fn_EnableControl("");
        }
        private void rtxtTastPrice_In_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal _dTienThanhToan = decimal.Zero;
            decimal _dTienTra = clsNumericFormat.Convert2Decimal(txtSoTienTra.EditValue.ToString());
            decimal _dTienNo = decimal.Zero;

            _dTienThanhToan = (clsNumericFormat.Convert2Decimal(txtSoTienThanhToan.EditValue.ToString())
                                            - clsNumericFormat.Convert2Decimal(e.OldValue.ToString())) +
                                           clsNumericFormat.Convert2Decimal(e.NewValue.ToString());
            txtSoTienThanhToan.EditValue = _dTienThanhToan;
            _dTienNo = _dTienThanhToan - _dTienTra;
            txtNo.EditValue = _dTienNo;
        }

        private void txtSoTienTra_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal _dTienThanhToan = clsNumericFormat.Convert2Decimal(txtSoTienThanhToan.EditValue.ToString());
            decimal _dTienTra = clsNumericFormat.Convert2Decimal(e.NewValue.ToString());
            decimal _dTienNo = decimal.Zero;

            _dTienNo = _dTienThanhToan - _dTienTra;
            txtNo.EditValue = _dTienNo;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues;

            //strParams = "TuNgay@DenNgay";
            //strValues = strFromDate;
            //strValues += "@" + strToDate;

            strParams = "";
            strValues = "";

            ds = clsCommon.ExecuteDatasetSP("rptPrintWorker", strID);
            Functions.fn_ShowReport(ds, "rptPrintWorker.rpt", strParams, strValues);
        }

        private void rtxtTotalWeight_Out_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dDiaWei = Convert.ToDecimal(grvOut.GetFocusedRowCellValue("DiamondWeight").ToString() == "" ?
                "0" : grvOut.GetFocusedRowCellValue("DiamondWeight").ToString());
            if (Convert.ToDecimal(e.NewValue.ToString()) < dDiaWei)
                e.Cancel = true;
        }

        private void rtxtDiamondWeight_Out_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dTotalWei = Convert.ToDecimal(grvOut.GetFocusedRowCellValue("TotalWeight").ToString() == "" ?
                "0" : grvOut.GetFocusedRowCellValue("TotalWeight").ToString());
            if (Convert.ToDecimal(e.NewValue.ToString()) > dTotalWei)
                e.Cancel = true;
        }

        private void rtxtGoldWeight_In_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dTotalWei = Convert.ToDecimal(grvIn.GetFocusedRowCellValue("TotalWeight").ToString() == "" ?
                "0" : grvIn.GetFocusedRowCellValue("TotalWeight").ToString());
            if (Convert.ToDecimal(e.NewValue.ToString()) > dTotalWei)
                e.Cancel = true;
        }

        private void rtxtTotalWeight_In_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dDiaWei = Convert.ToDecimal(grvIn.GetFocusedRowCellValue("GoldWeight").ToString() == "" ?
                "0" : grvIn.GetFocusedRowCellValue("GoldWeight").ToString());
            if (Convert.ToDecimal(e.NewValue.ToString()) < dDiaWei)
                e.Cancel = true;
        }
    }
}