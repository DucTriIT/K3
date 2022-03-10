using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Globalization;

namespace GoldRT
{
    public partial class frmRTBuy : DevExpress.XtraEditors.XtraForm
    {
        #region "Private Variables"
        
        private string strTrnID = "";
        private bool IsLoading;
        /// <summary>
        /// Biến dùng để xác định thời điểm người dùng đang chọn duyệt
        /// Khi người dùng chọn duyệt bIsApprove = true; ngược lại bIsApprove = false
        /// Sự kiện: grdDanhSach_MouseDown
        /// </summary>
        private bool bIsApprove = false;
        private bool bIsPrint = true;
        private bool bIsInsert = false;
     
        #endregion

        #region "Public Functions"

        public frmRTBuy()
        {
            InitializeComponent();
        }

        #endregion

        #region "Private Functions"
   
        private void f_loadDefault()
        {
            dtpTuNgay.EditValue = DateTime.Now;
            dtpDenNgay.EditValue = DateTime.Now;
        }

        private void f_loadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_Gold", "");
                Functions.BindDropDownList(rcboGoldCode, ds, "GoldDesc", "GoldCode", false);
                ds.Clear();

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "T_SECTION", "");
                Functions.BindDropDownList(rcboSectionID, ds, "SectionName", "SectionID", false);
                ds.Clear();

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "T_EMPLOYEE", "");
                Functions.BindDropDownList(rcboPriceUnit, ds, "UnitDesc", "UnitCode",  false);
                ds.Clear();

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "SYS_USERS", "1");
                Functions.BindDropDownList(rcboEmpID, ds, "UserName", "UserID", false);
                Functions.BindDropDownList(cboEmpID, ds, "UserName", "UserID","", false);
                ds.Clear();

                //cboSellBuy.Items.Add(new ImageComboBoxItem("Nhập","I"));
                //cboSellBuy.Items.Add(new ImageComboBoxItem("Xuất", "0"));
                
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

        //private void f_EnableControl(string _Status)
        //{
        //    bool bEditable;
        //    if (_Status == "C")
        //        bEditable = false;
        //    else
        //        bEditable = true;

        //    grdDanhSach.Columns["CustID"].OptionsColumn.AllowEdit = bEditable;
        //    grdDanhSach.Columns["GoldCode"].OptionsColumn.AllowEdit = bEditable;
        //    grdDanhSach.Columns["BuyRate"].OptionsColumn.AllowEdit = bEditable;
        //    grdDanhSach.Columns["GoldWeight"].OptionsColumn.AllowEdit = bEditable;
        //    grdDanhSach.Columns["PercentValue"].OptionsColumn.AllowEdit = bEditable;
        //    grdDanhSach.Columns["DiamondWeight"].OptionsColumn.AllowEdit = bEditable;
        //}

        private void f_loadDataToGrid(string _strID)
        {
            DataSet ds = new DataSet();

            try
            {
                labelTongTien.Text = " ";
                lbGoldWeightToChar.Text = " ";
                if (IsLoading == true)
                {
                    if (chkType.Checked)
                        ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYGOLD_Lst]", "",
                                dtpTuNgay.Text != "" ? dtpTuNgay.DateTime.ToString("dd/MM/yyyy") : "",
                                dtpDenNgay.Text != "" ? dtpDenNgay.DateTime.ToString("dd/MM/yyyy") : "",
                               "", "", "", "", clsSystem.UserID, "");
                    else ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYGOLD_Lst]", "",
                           dtpTuNgay.Text != "" ? dtpTuNgay.DateTime.ToString("dd/MM/yyyy") : "",
                           dtpDenNgay.Text != "" ? dtpDenNgay.DateTime.ToString("dd/MM/yyyy") : "",
                           "", "", "W", "", clsSystem.UserID, "");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYGOLD_Lst]", _strID,
                           "",
                          "",
                         "", "", "", "", clsSystem.UserID, "");
                }
                grdControl.DataSource = ds.Tables[0];
                fn_GetFocusedRowValue();
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

        /// <summary>
        /// Ham tinh thanh tien
        /// </summary>
        /// <param name="_eventArgs">Gia tri thay doi</param>
        /// <param name="_dData1">Trong luong vang/Gia mua</param>
        /// <param name="_dData2">Phan tram (Neu co)</param>
        private void f_calcTotalAmount(decimal _dGoldWeight, decimal _dGoldRate, decimal _dPercent)
        {
            DataRow row = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);
            decimal dTotalAmount = 0;
            if (grdDanhSach.GetFocusedRowCellValue("PriceUnit") != null && grdDanhSach.GetFocusedRowCellValue("PriceUnit").ToString() == "G")
            {
                decimal dXRate = 1; //Ty gia hien tai theo de tinh theo loai de da chon

                string strGoldCode = grdDanhSach.GetFocusedRowCellValue("GoldCode").ToString();
                DataRow rowIGold = Functions.fn_GetIGold(strGoldCode);
                if (rowIGold["PriceCcy"].ToString() != "VND" && rowIGold["PriceCcy"].ToString() != "")
                {
                    DataRow rowXRate = Functions.fn_GetXRate(rowIGold["PriceCcy"].ToString());
                    dXRate = rowXRate["BuyRate"] == DBNull.Value ? 1 : decimal.Parse(rowXRate["BuyRate"].ToString());
                }
                if (dXRate != 1)
                {
                    dTotalAmount = _dGoldWeight * _dGoldRate * dXRate * (_dPercent / 100);
                }
                else
                {
                    dTotalAmount = _dGoldWeight * _dGoldRate * dXRate * 1000 * (_dPercent / 100);
                }
                //dTotalAmount = _dGoldWeight * _dGoldRate * dXRate * (_dPercent / 100);
            }
            else if (grdDanhSach.GetFocusedRowCellValue("PriceUnit") != null && grdDanhSach.GetFocusedRowCellValue("PriceUnit").ToString() == "M")
            {
                dTotalAmount =  _dGoldRate * 1000;
            }
            else
            {
                dTotalAmount = _dGoldWeight * _dGoldRate * 1000 / clsSystem.HSGia*_dPercent/100;
            }
            dTotalAmount = Functions.fn_VNDRounding(dTotalAmount);
            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["TotalAmount"], dTotalAmount);
        }
        private void ReadAmountToChar()
        {
            try
            {
                decimal value = decimal.Zero;
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() == "True")
                    {
                        value += decimal.Parse(grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TotalAmount"]).ToString());
                    }
                }

                if (value != 0)
                {
                    labelTongTien.Text = "Phải chi " + Math.Abs(value).ToString("#,#", CultureInfo.InstalledUICulture);
                    emptySpaceItem1.Text = "Phải chi:" + VND.process(value.ToString("###")).ToUpper() + "ĐỒNG";
                }
                else
                {
                    labelTongTien.Text = " ";
                    emptySpaceItem1.Text = " ";
                }

                // SetLabelColor(value);
            }
            catch
            {
                lbGoldWeightToChar.Text = " ";
            }
        }
        private bool fn_CheckValidate(DataRow row)
        {
            try
            {
                if (row["InOut"].ToString() == "")
                {
                    ThongBao.Show("Lỗi", "Vui lòng loại nhập/xuất.", "OK", ICon.Error);
                    return false;
                }

                if (row["GoldCode"].ToString() == "")
                {
                    ThongBao.Show("Lỗi", "Vui lòng chọn món hàng.", "OK", ICon.Error);
                    return false;
                }
                if (row["Quantity"].ToString() == "")
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập số lượng.", "OK", ICon.Error);
                    return false;
                }
                if (decimal.Parse(row["Quantity"].ToString())<=0)
                {
                    ThongBao.Show("Lỗi", "Số lượng phải lớn hơn 0.", "OK", ICon.Error);
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

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                if (grdDanhSach.GetFocusedRowCellValue("TrnID") == null)
                    strTrnID = "";
                else
                    strTrnID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();
                     // cboEmpID.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("EmpID").ToString(), cboEmpID, 0);
                //decimal value = decimal.Parse(grdDanhSach.GetFocusedRowCellValue("TotalAmount").ToString());
               // labelTongTien.Text = "Phải chi " + value.ToString("#,#", CultureInfo.InstalledUICulture);
                //labelToalAmount.Text = "CHI " + VND.process(Math.Abs(decimal.Parse(grdDanhSach.GetFocusedRowCellValue("TotalAmount").ToString())).ToString("###")).ToUpper() + "ĐỒNG";
                if(!string.IsNullOrEmpty(strTrnID))
                     cboEmpID.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("EmpID").ToString(), cboEmpID, 0);

                if (grdDanhSach.GetFocusedRowCellValue("Status")!=null && grdDanhSach.GetFocusedRowCellValue("Status").ToString() == "C")
                {
                    btnComplete.Enabled = false;
                    btnDel.Enabled = false;
                    btnPrint.Enabled = true;                    
                    fn_EnableControl(false);
                }
                else
                {
                    btnComplete.Enabled = true;
                    btnDel.Enabled = true;
                    btnPrint.Enabled = false;
                    //btnPayment.Enabled = false;
                    //fn_EnableControl(true);
                }
            }
            else
            {
                this.strTrnID = String.Empty;
                btnComplete.Enabled = false;
                btnDel.Enabled = false;
                //btnPayment.Enabled = false;
                fn_EnableControl(true);
                //labelToalAmount.Text = " "; 
               // labelTongTien.Text = " ";
            }
        }

        private void fn_EnableControl(bool bEditMode)
        {
            grdDanhSach.Columns["InOut"].OptionsColumn.AllowEdit = bEditMode;
            grdDanhSach.Columns["GoldCode"].OptionsColumn.AllowEdit = bEditMode;
            grdDanhSach.Columns["Quantity"].OptionsColumn.AllowEdit = bEditMode;
          
            grdDanhSach.Columns["Notes"].OptionsColumn.AllowEdit = bEditMode;
           
        }

        #endregion

        #region "Event Handlers"


        private void frmRTBuy_Load(object sender, EventArgs e)
        {
            IsLoading = true;
            this.Cursor = Cursors.WaitCursor;
            Functions.Format_DecimalNumber(this.layoutControl2.Controls);
            chkType.Checked = false;
            f_loadDefault();
            f_loadDataToCombo();
            f_loadDataToGrid("");
           // ReadAmountToChar();
            btnPrint.Enabled = false;

            this.Cursor = Cursors.Default;
        }

        private void grdDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //Nếu đang trong trang thái chọn duyệt => bỏ qua
            if (bIsApprove || e.Row == null)
            {
                bIsApprove = false;
                return;
            }
            IsLoading = true;
            DataRow dr = ((DataRowView)e.Row).Row;
            DataSet ds = new DataSet();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (strTrnID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYGOLD_Ins]", "", DateTime.Now.ToString("dd/MM/yyyy"),
                        DateTime.Now.ToString("H:mm:ss"),dr["InOut"].ToString(),dr["SectionID"].ToString(),  dr["GoldCode"].ToString(),
                        decimal.Parse(dr["Quantity"].ToString()),dr["PriceUnit"].ToString(), dr["Notes"].ToString(), 
                        null, "0", clsSystem.UserID, DateTime.Now.ToString("dd/MM/yyyy"),((ItemList)cboEmpID.SelectedItem).ID);
                    f_loadDataToGrid("");
                    bIsInsert = true;
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYGOLD_Upd]", strTrnID, DateTime.Now.ToString("dd/MM/yyyy"),
                        DateTime.Now.ToString("H:mm:ss"), dr["InOut"].ToString(),dr["SectionID"].ToString(),  dr["GoldCode"].ToString(),
                        decimal.Parse(dr["Quantity"].ToString()),dr["PriceUnit"].ToString(), dr["Notes"].ToString(), 
                        null, "0", clsSystem.UserID, null, ((ItemList)cboEmpID.SelectedItem).ID);
                    f_loadDataToGrid("");
                }
//ReadAmountToChar();
                
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
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void rtxtGoldWeight_EditValueChanging(object sender, ChangingEventArgs e)
        {
            decimal dBuyRate = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("BuyRate").ToString(), out dBuyRate);

            decimal dPercent = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("PercentValue").ToString(), out dPercent);

            decimal dDiamondWeight = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("DiamondWeight").ToString(), out dDiamondWeight);

            decimal dDirty = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("Dirty").ToString(), out dDirty);
        


            decimal dNewValue = 0;
            if (!decimal.TryParse(e.NewValue.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào kiểu số cột TL Vàng.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            if (dNewValue < 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào số lớn hơn 0 cột TL Vàng.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            decimal NewValue = decimal.Zero;
            decimal TLHot = decimal.Zero;
            decimal TLVang = decimal.Zero;
            DataRow dr = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);
            try
            {
                if (dr["DiamondWeight"].ToString() != "")
                {
                    if (!decimal.TryParse(dr["DiamondWeight"].ToString(), out TLHot))
                    {
                        ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại cột Trọng lượng hột ", "OK", ICon.Error);
                        return;
                    }
                }
                else
                {
                    TLHot = 0;
                }
                if (e.NewValue.ToString().Trim() != "")
                {
                    if (!decimal.TryParse(e.NewValue.ToString(), out NewValue))
                    {
                        ThongBao.Show("Lỗi", "Trọng lượng chỉ nhập kiểu số ", "OK", ICon.Error);
                        return;
                    }
                }
                else
                {
                    NewValue = 0;
                }
                TLVang = NewValue - TLHot-dDirty;
                grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["GoldWeight"], TLVang);
            }
            catch
            {

            }

            f_calcTotalAmount(dNewValue-dDiamondWeight-dDirty, dBuyRate, dPercent);
        }

        private void rtxtGoldWeight_EditValueChanging(string value)
        {
            decimal dBuyRate = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("BuyRate").ToString(), out dBuyRate);

            decimal dPercent = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("PercentValue").ToString(), out dPercent);

            decimal dDiamondWeight = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("DiamondWeight").ToString(), out dDiamondWeight);

            decimal dDirty = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("Dirty").ToString(), out dDirty);


            decimal dNewValue = 0;
            if (!decimal.TryParse(value.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào kiểu số cột TL Vàng.", "OK", ICon.Error);
                //e.Cancel = true;
                return;
            }

            if (dNewValue < 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào số lớn hơn 0 cột TL Vàng.", "OK", ICon.Error);
                //e.Cancel = true;
                return;
            }

            f_calcTotalAmount(dNewValue - dDiamondWeight-dDirty, dBuyRate, dPercent);
        }



        private void rtxtBuyRate_EditValueChanging(object sender, ChangingEventArgs e)
        {
            decimal dTotalWeight = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("TotalWeight").ToString(), out dTotalWeight);

            decimal dPercent = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("PercentValue").ToString(), out dPercent);

            decimal dDiamondWeight = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("DiamondWeight").ToString(), out dDiamondWeight);

            decimal dDirty = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("Dirty").ToString(), out dDirty);
        

            decimal dNewValue = 0;
            if (!decimal.TryParse(e.NewValue.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào kiểu số cột Giá mua.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            if (dNewValue < 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào số lớn hơn 0 cột Giá mua.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            f_calcTotalAmount(dTotalWeight-dDiamondWeight-dDirty, dNewValue, dPercent);
        }
        void rtxtDiamondWeight_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dBuyRate = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("BuyRate").ToString(), out dBuyRate);

            decimal dTotalWeight = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("TotalWeight").ToString(), out dTotalWeight);

            decimal dPercent = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("PercentValue").ToString(), out dPercent);

            decimal dDirty = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("Dirty").ToString(), out dDirty);
        
            decimal dNewValue = 0;
            if (!decimal.TryParse(e.NewValue.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào kiểu số cột trọng lượng hột", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            if (dNewValue < 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào số lớn hơn 0 cột cột trọng lượng hột.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
            if (dNewValue > dTotalWeight)
            {
                ThongBao.Show("Lỗi", "Trọng lượng hột phải nhỏ hơn trọng lượng vàng + hột.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
            decimal NewValue = 0;
            decimal TotalGoldWeight = 0;
            decimal GoldWeight = 0;
            DataRow row = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);

            if (e.NewValue.ToString().Trim() != "")
            {
                if (!decimal.TryParse(e.NewValue.ToString(), out NewValue))
                {
                    ThongBao.Show("Lỗi", "Trọng lượng hột chỉ được nhập kiểu số.", "OK", ICon.Error);
                    return;
                }
                if (!decimal.TryParse(row["TotalWeight"].ToString(), out TotalGoldWeight))
                {
                    ThongBao.Show("Lỗi", "Vui lòng kiểm tra cột trọng lượng vàng + hột.", "OK", ICon.Error);
                    return;
                }

            }
            else
            {
                NewValue = 0;
            }
            GoldWeight = TotalGoldWeight - NewValue-dDirty;

            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["GoldWeight"], GoldWeight);

            f_calcTotalAmount(dTotalWeight - dNewValue-dDirty, dBuyRate, dPercent);
        }
        private void rtxtPercentValue_EditValueChanging(object sender, ChangingEventArgs e)
        {
            decimal dBuyRate = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("BuyRate").ToString(), out dBuyRate);

            decimal dTotalWeight = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("TotalWeight").ToString(), out dTotalWeight);

            decimal dDirty = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("Dirty").ToString(), out dDirty);
        
            decimal dNewValue = 0;
            if (!decimal.TryParse(e.NewValue.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào kiểu số cột Giá trị %.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            if (dNewValue < 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào số lớn hơn 0 cột Giá trị %.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
            if (dNewValue > 100)
            {
                ThongBao.Show("Lỗi","Vui lòng nhập số nhỏ hơn 100 cột Giá trị %.","OK",ICon.Error);
                e.Cancel = true;
                return;
            }
            decimal dDiaMondWeight = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("DiamondWeight").ToString(), out dDiaMondWeight);

            f_calcTotalAmount(dTotalWeight-dDiaMondWeight-dDirty, dBuyRate, dNewValue);
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
            SelectRowAfterIns();
            //ReadGoldWeightToChar(e.FocusedRowHandle);
        }
        private void ReadGoldWeightToChar(int i)
        {
            try
            {
                decimal GoldWeight = decimal.Parse(grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["GoldWeight"]).ToString());
                if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["PriceUnit"]).ToString() == "L")
                {
                    
                        GoldWeight = GoldWeight *clsSystem.HSTL;
                        lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper();

                }
                else if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["PriceUnit"]).ToString() == "G")
                {
                    int k;
                    if (clsSystem.UnitWeight == "Ly" || clsSystem.UnitWeight == "P"||clsSystem.UnitWeight=="Z")
                        k = 2;
                    else if (clsSystem.UnitWeight == "C")
                        k = 3;
                    else k = 4;
                    GoldWeight = Math.Round(GoldWeight,k);
                    lbGoldWeightToChar.Text = Gam.process(GoldWeight.ToString().Trim()).ToUpper() + "GAM";
                }
                else
                    lbGoldWeightToChar.Text = "";
            }
            catch
            {
                lbGoldWeightToChar.Text = " ";
            }
        }

        private void SelectRowAfterIns()
        {
            if (bIsInsert == true)
            {
                bIsInsert = false;
                if (grdDanhSach.RowCount >= 0)
                {
                    grdDanhSach.FocusedRowHandle = 0;                   
                }
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            bool bFlag = true;
            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá các thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    for (int i = 0; i < grdDanhSach.RowCount; i++)
                    {
                        if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() == "True")
                        {
                            if (grdDanhSach.GetRowCellValue(i, "Status").ToString() == "W")
                            {
                                ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYGOLD_Del]", grdDanhSach.GetRowCellValue(i, "TrnID"));

                                if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                                    bFlag = false;
                            }
                            else ThongBao.Show("Thông báo", "Không được xóa đơn hàng đã hoàn tất!", "Đồng ý", ICon.Information);
                        }
                    }

                    if (bFlag)
                    {
                        f_loadDataToGrid("");                        
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
                          //  ReadAmountToChar();
                        }
                    }

                    if (hInfo.InRowCell && hInfo.Column.Name != "colChon")
                    {
                        bIsApprove = false;
                        //if (hInfo.InRowCell && hInfo.Column.Name == "BuyRate")
                        //{
                        //    string curValue = grdDanhSach.GetRowCellValue(hInfo.RowHandle, grdDanhSach.Columns["GoldCode"]).ToString();
                        //    if (curValue == "D La" && grdDanhSach.GetRowCellValue(hInfo.RowHandle, grdDanhSach.Columns["Status"]).ToString() != "C")
                        //    {
                        //        BuyRate.OptionsColumn.AllowEdit = true;
                        //    }
                        //    else BuyRate.OptionsColumn.AllowEdit = false;
                        //}
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
                       // ReadAmountToChar();
                    }
                }
            }
            catch { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            IsLoading = true;
            f_loadDataToGrid("");
           // ReadAmountToChar();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
             //if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn thanh toán giao dịch này?", "Có", "Không", ICon.QuestionMark) != DialogResult.OK)
            // return;
         btnComplete.Enabled = false;
                DataSet ds = new DataSet();
                string strTrnIDs = "";
                try
                {
                    for (int i = 0; i < grdDanhSach.RowCount; i++)
                    {
                        if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() == "True")
                        {
                            if (grdDanhSach.GetRowCellValue(i, "Status").ToString() == "W")
                                strTrnIDs += grdDanhSach.GetRowCellValue(i, "TrnID") + "@";
                        }
                    }
                    if (strTrnIDs != "")
                    {
                      //  if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn hoàn tất các thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                      //  {
                        if (clsSystem.TillID == "")
                        {
                            ThongBao.Show("Lỗi","Quầy đang đóng không thể thực hiện giao dịch", "OK", ICon.Error);
                            btnComplete.Enabled = true;
                            return;
                        }
                        else
                        {
                            ds = clsCommon.ExecuteDatasetSP("TRN_RT_BUYGOLD_CompleteMore", strTrnIDs);
                            if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() != "0")
                            {
                                ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                            }
                            else
                            {
                                IsLoading = false;
                                //ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                                frmTillProccessTxn frm = new frmTillProccessTxn(strTrnIDs);

                                f_loadDataToGrid(strTrnIDs);
                                ReadAmountToChar();
                                btnPrint.Focus();

                            }
                        }
                        //}
                    }
                    else
                    {
                        ThongBao.Show("Thông báo", "Vui lòng chọn giao dịch cần thanh toán.", "OK", ICon.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    btnComplete.Enabled = true;
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                    return;
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

        //private void btnPayment_Click(object sender, EventArgs e)
        //{
        //    DataSet ds = new DataSet();
        //    string strIDs = "";
        //    bIsPrint = false;
        //    try
        //    {
                
        //            for (int i = 0; i < grdDanhSach.RowCount; i++)
        //            {
        //                if (grdDanhSach.GetRowCellValue(i, "colChon").ToString() == "True")
        //                {
        //                    strIDs += grdDanhSach.GetRowCellValue(i, "TrnID").ToString() + "@";
        //                }
        //            }                    
        //             if (strIDs != "")
        //             {
        //                    //if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn thanh toán?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
        //                    //{
        //                        frmTillProccessTxn frm = new frmTillProccessTxn(strIDs);
        //                        frm.ShowDialog();
        //                        f_loadDataToGrid();
        //                    //}
        //             }
        //             else
        //             {
        //                    ThongBao.Show("Thông báo", "Vui lòng chọn giao dịch cần thanh toán.", "OK", ICon.Warning);
        //             }                    
        //    }
        //    catch (Exception ex)
        //    {
        //        ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
        //    }
        //    finally
        //    {
        //        ds.Dispose();
        //    }
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues;
            string strIDs = "";

            strParams = "";
            strValues = "";

           
            

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
                strParams += "TillName@DocTienThanhChu";
                strValues = clsSystem.TillName+"@"+emptySpaceItem1.Text;
                Functions.fn_ShowReport_CloseAfterPrint(ds, "rptBRT_PrintBill.rpt", strParams, strValues,true);
            }
            f_loadDataToGrid(strIDs);
         
        }

        #endregion

        private void rcboGoldCode_EditValueChanged(object sender, EventArgs e)
        {
            string strGoldCode = ((ComboBoxEdit)sender).EditValue.ToString();
            
            //Kiem tra neu loai de nay thuoc Gram?
            DataRow rowIGold = Functions.fn_GetIGold(strGoldCode);
            //if (rowIGold["PriceUnit"] != DBNull.Value && rowIGold["PriceUnit"].ToString() == "G")
           // {
                grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["PriceUnit"], rowIGold["PriceUnit"].ToString());
                grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["SectionID"], rowIGold["GoldType"].ToString());
           // }

           
        }

        private void grdDanhSach_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
           
           
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            IsLoading = true;
            f_loadDefault();
            f_loadDataToCombo();
            f_loadDataToGrid("");
            btnPrint.Enabled = false;
           // ReadAmountToChar();
        }

        private void grdDanhSach_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    DataRow dr = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);
            //    if (e.Column.FieldName == "GoldCode")
            //    {
            //        if (dr["BuyRate"].ToString() != "" && dr["TotalWeight"].ToString() != "")
            //        {
            //            rtxtGoldWeight_EditValueChanging(dr["TotalWeight"].ToString());
            //        }
            //    }
            //}
            //catch { }
            try
            {
                if (e.Column.FieldName == "TotalWeight" || e.Column.FieldName == "DiamondWeight")
                {
                    //DataRow row = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);
                    //decimal GoldWeight = decimal.Parse(row["GoldWeight"].ToString());
                    //DataRow dr = Functions.fn_GetIGold(row["GoldCode"].ToString());
                    //if (dr["PriceUnit"].ToString() == "L")
                    //    lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper();
                    //else if (dr["PriceUnit"].ToString() == "G")
                    //    lbGoldWeightToChar.Text = Gam.process(GoldWeight.ToString()).ToUpper() + "GAM";
                    //else
                    //    lbGoldWeightToChar.Text = "";
                    ReadGoldWeightToChar(grdDanhSach.FocusedRowHandle);
                }
            }
            catch
            {
                lbGoldWeightToChar.Text = " ";
            }
        }

        private void rcboGoldCode_Leave(object sender, EventArgs e)
        {
          
            try
            {
                //string strGoldCode = ((ComboBoxEdit)sender).EditValue.ToString();
               // DataRow dr = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);
                //if (strGoldCode == "D La")
                  //  BuyRate.OptionsColumn.AllowEdit = true;
                //else BuyRate.OptionsColumn.AllowEdit = false;
               // grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["GoldCode"], strGoldCode);
                //if (dr["BuyRate"].ToString() != "" && dr["TotalWeight"].ToString() != "")
                //{
                //    rtxtGoldWeight_EditValueChanging(dr["TotalWeight"].ToString());
                //}
            }
            catch { }
        }

       
        private void frmRTBuy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(clsSystem.IsScan)
                FunctionTill.fn_CloseTill();
        }

        private void rtxtDirty_EditValueChanging(object sender, ChangingEventArgs e)
        {
            decimal dBuyRate = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("BuyRate").ToString(), out dBuyRate);

            decimal dTotalWeight = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("TotalWeight").ToString(), out dTotalWeight);

            decimal dPercent = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("PercentValue").ToString(), out dPercent);

            decimal dDiamondWeight = 0;
            decimal.TryParse(grdDanhSach.GetFocusedRowCellValue("DiamondWeight").ToString(), out dDiamondWeight);

            decimal dNewValue = 0;
            if (!decimal.TryParse(e.NewValue.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào kiểu số cột trừ dơ", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }

            if (dNewValue < 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào số lớn hơn 0 cột trừ dơ.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
            if (dNewValue > dTotalWeight)
            {
                ThongBao.Show("Lỗi", "Trọng lượng trừ dơ phải nhỏ hơn trọng lượng vàng + hột.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
            //decimal NewValue = 0;
            //decimal TotalGoldWeight = 0;
            decimal GoldWeight = 0;
            //DataRow row = grdDanhSach.GetDataRow(grdDanhSach.FocusedRowHandle);

            //if (e.NewValue.ToString().Trim() != "")
            //{
            //    if (!decimal.TryParse(e.NewValue.ToString(), out NewValue))
            //    {
            //        ThongBao.Show("Lỗi", "Trọng lượng hột chỉ được nhập kiểu số.", "OK", ICon.Error);
            //        return;
            //    }
            //    if (!decimal.TryParse(row["TotalWeight"].ToString(), out TotalGoldWeight))
            //    {
            //        ThongBao.Show("Lỗi", "Vui lòng kiểm tra cột trọng lượng vàng + hột.", "OK", ICon.Error);
            //        return;
            //    }

            //}
            //else
            //{
            //    NewValue = 0;
            //}
            GoldWeight = dTotalWeight - dDiamondWeight - dNewValue;

            grdDanhSach.SetFocusedRowCellValue(grdDanhSach.Columns["GoldWeight"], GoldWeight);

            f_calcTotalAmount(dTotalWeight - dDiamondWeight - dNewValue, dBuyRate, dPercent);
        }
    }
}