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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Globalization;

namespace GoldRT
{
    public partial class frmForeignCurrency : DevExpress.XtraEditors.XtraForm
    {
        string strID;
        private bool bIsApprove = false;

        public frmForeignCurrency()
        {
            InitializeComponent();
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new MyLocalizer();
        }

        public void fn_Refresh()
        {
            fn_LoadDataToCombo();
            fn_LoadDataToGrid();
        }

        private void fn_InitDataToGrid()
        {
            DataTable dtNull = new DataTable();
            dtNull.Columns.Add("TrnID", typeof(string));
            dtNull.Columns.Add("TrnDate", typeof(string));
            dtNull.Columns.Add("TrnTime", typeof(string));
            dtNull.Columns.Add("TrnDateTime", typeof(DateTime));
            dtNull.Columns.Add("SellBuy", typeof(string));
            dtNull.Columns.Add("Ccy", typeof(decimal));
            dtNull.Columns.Add("Fcy_Amount", typeof(string));
            dtNull.Columns.Add("XRate", typeof(string));
            dtNull.Columns.Add("Lcy_Amount", typeof(string));
            dtNull.Columns.Add("Notes", typeof(string));
            dtNull.Columns.Add("Status", typeof(string));
            dtNull.Columns.Add("IsDel", typeof(string));
            dtNull.Columns.Add("CreatedBy", typeof(string));
            dtNull.Columns.Add("CreatedDate", typeof(string));
            this.grdControl.DataSource = dtNull;
        }

        private void fn_EnableControl(bool bEditMode)
        {
            grdDanhSach.Columns["CustID"].OptionsColumn.AllowEdit = bEditMode;
            grdDanhSach.Columns["SellBuy"].OptionsColumn.AllowEdit = bEditMode;
            grdDanhSach.Columns["Ccy"].OptionsColumn.AllowEdit = bEditMode;
            grdDanhSach.Columns["XRate"].OptionsColumn.AllowEdit = bEditMode;
            grdDanhSach.Columns["Fcy_Amount"].OptionsColumn.AllowEdit = bEditMode;
            grdDanhSach.Columns["Notes"].OptionsColumn.AllowEdit = bEditMode;
        }

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();
                string SellBuy = grdDanhSach.GetFocusedRowCellValue("SellBuy").ToString();
                decimal value = decimal.Parse(grdDanhSach.GetFocusedRowCellValue("Lcy_Amount").ToString());
                labelTongTien.Text = SellBuy == "B" ? "Phải chi: " + value.ToString("#,#", CultureInfo.InstalledUICulture) : "Phải thu: " + value.ToString("#,#", CultureInfo.InstalledUICulture);
                SetLabelColor(SellBuy);
                if (grdDanhSach.GetFocusedRowCellValue("Status").ToString() == "C")
                {
                    btnComplete.Enabled = false;
                    btnDel.Enabled = false;


                    if (grdDanhSach.GetFocusedRowCellValue("IsPaid").ToString() == "Y")
                    {
                        btnPayment.Enabled = false;
                        btnPrint.Enabled = true;
                    }
                    else
                    {
                        btnPayment.Enabled = true;
                        btnPrint.Enabled = false;
                    }
                    fn_EnableControl(false);
                }
                else
                {
                    btnComplete.Enabled = true;
                    btnDel.Enabled = true;
                    btnPayment.Enabled = false;
                    fn_EnableControl(true);
                    btnPrint.Enabled = false;

                }
            }
            else
            {
                this.strID = String.Empty;
                btnComplete.Enabled = true;
                btnDel.Enabled = true;
                fn_EnableControl(true);
                btnPrint.Enabled = false;
                labelTongTien.Text = " ";
            }
        }

        private void SetLabelColor(string value)
        {
            if (value == "B")
                labelTongTien.AppearanceItemCaption.ForeColor = Color.Blue;
            else
                labelTongTien.AppearanceItemCaption.ForeColor = Color.Red;
        }
        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_CURRENCY", "F");
                Functions.BindDropDownList(cboCcy, ds, "Ccy", "Ccy", true);
                ds.Clear();

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_CUSTOMER", "ALL");
                Functions.BindDropDownList(cboKhachHang, ds, "CustName", "CustID", false);
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

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_FX_Lst]",
                    "", dtpTuNgay.Text != "" ? dtpTuNgay.DateTime.ToString("dd/MM/yyyy") : "",
                    dtpDenNgay.Text != "" ? dtpDenNgay.DateTime.ToString("dd/MM/yyyy") : "",
                    "", "", "", "", "", "", "", "", "", clsSystem.UserID, "", "");

                if (ds.Tables.Count > 0)
                {
                    grdControl.DataSource = ds.Tables[0];
                    fn_GetFocusedRowValue();
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

        private bool fn_CheckValidate(DataRow row)
        {
            try
            {
                //if (row["CustID"].ToString() == "")
                //{
                //    ThongBao.Show("Lỗi", "Vui lòng chọn khách hàng.", "OK", ICon.Error);
                //    return false;
                //}

                if (row["SellBuy"].ToString() == "")
                {
                    ThongBao.Show("Lỗi", "Vui lòng chọn Mua/ bán.", "OK", ICon.Error);
                    return false;
                }

                if (row["Ccy"].ToString() == "")
                {
                    ThongBao.Show("Lỗi", "Vui lòng chọn loại Ngoại tệ.", "OK", ICon.Error);
                    return false;
                }

                if (row["Fcy_Amount"].ToString() == "")
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập vào Số lượng mua bán.", "OK", ICon.Error);
                    return false;
                }

                decimal dTyGia = 0;
                decimal dMinRate = 0;
                decimal dMaxRate = 0;

                dTyGia = decimal.Parse(row["XRate"].ToString());
                dMinRate = decimal.Parse(row["MinRate"].ToString());
                dMaxRate = decimal.Parse(row["MaxRate"].ToString());

                if (dTyGia < dMinRate || dTyGia > dMaxRate)
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập Tỷ giá trong khoảng [" + decimal.Round(decimal.Parse(row["MinRate"].ToString()), 0) + ","
                        + decimal.Round(decimal.Parse(row["MaxRate"].ToString()), 0) + "]", "OK", ICon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm CheckValidate: " + ex.Message, "OK", ICon.Error);
                return false;
            }

            return true;
        }

        private void frmForeignCurrency_Load(object sender, EventArgs e)
        {
            
            fn_LoadDataToCombo();
            fn_LoadDataToGrid();
        }

        private void cboSellBuy_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (XRate != null)
            {
                try
                {
                    string strCcy = "";
                    if (grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle) != null)
                    {
                        strCcy = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle)["Ccy"].ToString();
                    }

                    if (String.IsNullOrEmpty(e.NewValue.ToString()) ||
                        String.IsNullOrEmpty(strCcy))
                    {
                        return;
                    }

                    string expression = "GoldCcy = '" + strCcy + "'";
                    DataRow[] arrRow = clsSystem.XRate.Tables[0].Select(expression);
                    if (arrRow.Length > 0)
                    {
                        if (e.NewValue.ToString() == "B")
                        {
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["XRate"], arrRow[0]["BuyRate"].ToString());
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["MinRate"], arrRow[0]["MinBuyRate"].ToString());
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["MaxRate"], arrRow[0]["MaxBuyRate"].ToString());

                        }
                        else if (e.NewValue.ToString() == "S")
                        {
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["XRate"], arrRow[0]["SellRate"].ToString());
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["MinRate"], arrRow[0]["MinSellRate"].ToString());
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["MaxRate"], arrRow[0]["MaxSellRate"].ToString());
                        }

                        //Tinh lai gia tri thanh tien dua tren ty gia moi
                        DataRow row = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);
                        decimal dTyGia = 0;
                        decimal dSoLuong = 0;
                        decimal dThanhTien = 0;
                        decimal.TryParse(row["XRate"].ToString(), out dTyGia);
                        decimal.TryParse(row["Fcy_Amount"].ToString(), out dSoLuong);

                        dThanhTien = dTyGia * dSoLuong;
                        grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["Lcy_Amount"], dThanhTien);
                    }
                }
                catch { }
            }
        }

        private void cboCcy_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (XRate != null)
            {
                try
                {
                    string strSellBuy = "";
                    if (grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle) != null)
                    {
                        strSellBuy = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle)["SellBuy"].ToString();
                    }

                    if (String.IsNullOrEmpty(e.NewValue.ToString()) ||
                        String.IsNullOrEmpty(strSellBuy))
                    {
                        return;
                    }

                    string expression = "GoldCcy = '" + e.NewValue.ToString() + "'";
                    DataRow[] arrRow = clsSystem.XRate.Tables[0].Select(expression);
                    if (arrRow.Length > 0)
                    {
                        if (strSellBuy == "B")
                        {
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["XRate"], arrRow[0]["BuyRate"].ToString());
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["MinRate"], arrRow[0]["MinBuyRate"].ToString());
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["MaxRate"], arrRow[0]["MaxBuyRate"].ToString());
                        }
                        else if (strSellBuy == "S")
                        {
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["XRate"], arrRow[0]["SellRate"].ToString());
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["MinRate"], arrRow[0]["MinSellRate"].ToString());
                            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["MaxRate"], arrRow[0]["MaxSellRate"].ToString());
                        }
                    }

                    //Tinh lai gia tri thanh tien dua tren ty gia moi
                    DataRow row = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);
                    decimal dTyGia = 0;
                    decimal dSoLuong = 0;
                    decimal dThanhTien = 0;
                    decimal.TryParse(row["XRate"].ToString(), out dTyGia);
                    decimal.TryParse(row["Fcy_Amount"].ToString(), out dSoLuong);

                    dThanhTien = dTyGia * dSoLuong;
                    grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["Lcy_Amount"], dThanhTien);
                }
                catch { }
            }
        }

        private void txtSoLuong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dTyGia = 0;
            decimal dSoLuong = 0;
            decimal dThanhTien = 0;
            DataRow row = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);

            if (!decimal.TryParse(e.NewValue.ToString(), out dSoLuong))
            {
                ThongBao.Show("Lỗi", "Chỉ được nhập vào kiểu số.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            if (dSoLuong <= 0)
            {
                ThongBao.Show("Lỗi", "Chỉ được nhập vào số lớn hơn 0.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            decimal.TryParse(row["XRate"].ToString(), out dTyGia);

            dThanhTien = dTyGia * dSoLuong;
            dThanhTien = Functions.fn_VNDRounding(dThanhTien);
            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["Lcy_Amount"], dThanhTien);
        }

        private void txtTyGia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dTyGia = 0;
            decimal dSoLuong = 0;
            decimal dThanhTien = 0;
            DataRow row = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);

            if (!decimal.TryParse(e.NewValue.ToString(), out dTyGia))
            {
                ThongBao.Show("Lỗi", "Chỉ được nhập vào kiểu số.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            if (dTyGia < 0)
            {
                ThongBao.Show("Lỗi", "Chỉ được nhập vào số lớn hơn 0.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            decimal.TryParse(row["Fcy_Amount"].ToString(), out dSoLuong);

            dThanhTien = dTyGia * dSoLuong;
            dThanhTien = Functions.fn_VNDRounding(dThanhTien);
            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["Lcy_Amount"], dThanhTien);
        }

        private void grdDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //Nếu đang trong trang thái chọn duyệt => bỏ qua
            if (bIsApprove)
            {
                bIsApprove = false;
                return;
            }

            DataRow dr = ((DataRowView)e.Row).Row;
            DataSet ds = new DataSet();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_FX_Ins]", "", DateTime.Now.ToString("dd/MM/yyyy"),
                        DateTime.Now.ToString("hh:mm:ss"), "FX", dr["CustID"].ToString() == "" ? "CU0000000000000" : dr["CustID"].ToString(), dr["SellBuy"].ToString(),
                        dr["Ccy"].ToString(), dr["Fcy_Amount"].ToString(), dr["XRate"].ToString(),
                        dr["Lcy_Amount"].ToString(), dr["Notes"].ToString(), "W", "0", clsSystem.UserID, DateTime.Now.ToString());
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_FX_Upd]", strID, DateTime.Now.ToString("dd/MM/yyyy"),
                        DateTime.Now.ToString("hh:mm:ss"), "FX", dr["CustID"].ToString(), dr["SellBuy"].ToString(),
                        dr["Ccy"].ToString(), dr["Fcy_Amount"].ToString(), dr["XRate"].ToString(),
                        dr["Lcy_Amount"].ToString(), dr["Notes"].ToString(), "W", "0", clsSystem.UserID, DateTime.Now.ToString());
                }
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

        private void grdDanhSach_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (!fn_CheckValidate(((DataRowView)e.Row).Row))
                e.Valid = false;
        }

        private void grdDanhSach_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grdDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fn_GetFocusedRowValue();
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
                            bIsApprove = true;
                            grdDanhSach.SetRowCellValue(hInfo.RowHandle, hInfo.Column, curValue == "True" ? "False" : "True");
                        }
                    }

                    if (hInfo.InColumnPanel && hInfo.Column.Name == "colChon")
                    {
                        if (hInfo.Column.ImageIndex == 0)
                        {
                            for (int i = 0; i < grdDanhSach.RowCount; i++)
                            {
                                if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() != "")
                                {
                                    bIsApprove = true;
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
                                    bIsApprove = true;
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

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            bool bChon = false;
            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn hoàn tất các thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    for (int i = 0; i < grdDanhSach.RowCount; i++)
                    {
                        if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() == "True")
                        {
                            bChon = true;
                            clsCommon.ExecuteDatasetSP("[TRN_FX_Complete]", grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]));
                        }
                    }

                    if (bChon)
                    {
                        fn_LoadDataToGrid();
                        ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", "Vui lòng chọn thông tin trước khi thực hiện.", "OK", ICon.Error);
                    }

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

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            bool bChon = false;
            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá các thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    for (int i = 0; i < grdDanhSach.RowCount; i++)
                    {
                        if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() == "True")
                        {
                            bChon = true;
                            clsCommon.ExecuteDatasetSP("[TRN_FX_Del]", grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]));
                        }
                    }

                    if (bChon)
                    {
                        fn_LoadDataToGrid();
                        ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", "Vui lòng chọn thông tin trước khi thực hiện.", "OK", ICon.Error);
                    }

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn thanh toán giao dịch này?", "Có", "Không", ICon.QuestionMark) != DialogResult.OK)
                return;
            DataSet ds = new DataSet();
            string strIDs = "";
            bool bChon = false;
            try
            {

                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() == "True")
                    {
                        bChon = true;
                        strIDs += grdDanhSach.GetRowCellValue(i, "TrnID").ToString() + "@";
                    }
                }

                if (bChon)
                {
                    if (strIDs != "")
                    {
                        frmTillProccessTxn frm = new frmTillProccessTxn(strIDs);
                        //frm.ShowDialog();
                        fn_LoadDataToGrid();
                    }
                }
                else
                {
                    ThongBao.Show("Lỗi", "Vui lòng chọn thông tin trước khi thực hiện.", "OK", ICon.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues;
            string strIDs = "";

            strParams = "";
            strValues = "";

            strParams = "TillName";
            strValues = clsSystem.TillName;

            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {
                if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() == "True")
                {
                    strIDs += grdDanhSach.GetRowCellValue(i, "TrnID").ToString() + "@";
                }
            }

            if (strIDs != "")
            {

                ds = clsCommon.ExecuteDatasetSP("rptBRT_PrintBill", strIDs);
                Functions.fn_ShowReport_CloseAfterPrint(ds, "rptBRT_PrintBill.rpt", strParams, strValues, true);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                CustID.OptionsColumn.AllowEdit = false;
                CustID.OptionsColumn.AllowFocus = false;
            }
            else
            {
                CustID.OptionsColumn.AllowEdit = true;
                CustID.OptionsColumn.AllowFocus = true;
            }
        }

        private void frmForeignCurrency_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsSystem.IsScan)
                FunctionTill.fn_CloseTill();
        }


    }

    public class MyLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
        {
            if (id == DevExpress.XtraGrid.Localization.GridStringId.ColumnViewExceptionMessage)
                return "Dòng nhập liệu hiện tại chưa lưu. Bạn có muốn tiếp tục nhập không?";
            return base.GetLocalizedString(id);
        }
    }
}