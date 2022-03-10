using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Messages;
using System.Globalization;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace GoldRT
{
    public partial class frmRTBuySell : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtProduct = new DataTable();
        private DataTable dtOldGold = new DataTable();
        private string strGoldCatNi = string.Empty;
        private decimal dCatNi = 0;
        private string strProductCatNi = "";
        public string strID = "";
        public string strTillTxnID = "";
        private decimal strSellRate = decimal.Zero;
       private  DataTable dt= new DataTable();
        private bool bIsLoading = false;

        DataRow arrXRate;

        public frmRTBuySell()
        {
            InitializeComponent();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("I_GOLD", "D_RT");
            Functions.BindDropDownList(cboGoldCode_Old, ds, "GoldDesc", "GoldCode", false);
            ds.Clear();

            ds = clsCommon.LoadComboSP("I_CUSTOMER", "");
            Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "0", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("T_EMPLOYEE", null);
            Functions.BindDropDownList(cboEmp, ds, "EmpName", "EmpID", "", false);
            ds.Clear();
            ds.Dispose();
        }

        private void frmRTBuySell_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);

            fn_createProductDataTable();

            grdProduct.DataSource = dtProduct;
            grdOldGold.DataSource = dtOldGold;

            fn_LoadDataToCombo();
            fn_LoadDefault();
            if(!clsSystem.IsPayCard)
                btnPayCard.Dispose();
            this.SL.Visible = clsSystem.IsNoStamp;
            this.colTaskPrice.OptionsColumn.AllowEdit = clsSystem.ISChangeTaskPrice;
            //if (!clsSystem.IsDoiTra)
            //    chkDoiTra.Dispose();
            if (!clsSystem.IsCatGia)
                chkCatGia.Dispose();
                
        }

        private void fn_LoadDefault()
        {
            dtpDate.DateTime = DateTime.Now;
            strID = "";
            strTillTxnID = "";

            dtProduct.Clear();
            grvProduct.RefreshData();

            dtOldGold.Clear();
            grvOldGold.RefreshData();

            cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(clsSystem.WalkInCustID, cboCust, 0);
            txtSellTotalAmount.EditValue = "0";
            txtBuyTotalAmount.EditValue = "0";
            txtTotalAmount.EditValue = "0";
            txtDiscount.EditValue = "0";
            txtTienVangThem.EditValue = "0";
           // txtMS4.EditValue = "0";
            txtPayAmount.EditValue = "0";
            txtPayHand.EditValue = "0";
            txtDebitAmount.EditValue = "0";
            lblPayAmountByWord.Text = "";
            lblPayAmountByNumber.Text = " ";
            txtA.EditValue = "0";
            txtBillCode.Text = "Tự động";
            lblStatusName.Text = "{Rỗng}";
            txtStatus.Text = "";
            txtIsPaid.Text = "N";
            txtProductCode.Enabled = true;
            this.ActiveControl = txtProductCode;


        }

        private void fn_EnableControl(string pStatus)
        {
            if (pStatus == "")
            {
                btnDel.Enabled = true;
                // btnSave.Enabled = true;
                // btnComplete.Enabled = false;
                btnPayment.Enabled = false;
                btnPayCard.Enabled = false;
                btnPrint.Enabled = false;
                btnInPhieu.Enabled = false;
                btnPrintA4.Enabled = false;
                txtProductCode.Enabled = true;
                grvOldGold.OptionsBehavior.Editable = true;
                grvProduct.OptionsBehavior.Editable = true;
                cboCust.Properties.ReadOnly = false;
                txtDiscount.Properties.ReadOnly = false;
                //txtMS4.Properties.ReadOnly = false;
                txtTienVangThem.Properties.ReadOnly = false;
                txtPayHand.Properties.ReadOnly = false;
               //chkDoiTra.Enabled = true;
                chkCatGia.Enabled = true;
                cboEmp.Enabled = true;
                
            }

            if (pStatus == "W")
            {
                btnDel.Enabled = true;
                //btnSave.Enabled = true;
                //btnComplete.Enabled = true;
                btnPayment.Enabled = true;
                btnPayCard.Enabled = true;
                btnPrint.Enabled = false;
                btnInPhieu.Enabled = false;
                btnPrintA4.Enabled = false;
                cboEmp.Enabled = true;
                txtProductCode.Enabled = true;
                grvOldGold.OptionsBehavior.Editable = true;
                grvProduct.OptionsBehavior.Editable = true;
                cboCust.Properties.ReadOnly = false;
                txtDiscount.Properties.ReadOnly = false;
               // txtMS4.Properties.ReadOnly = false;
                txtTienVangThem.Properties.ReadOnly = false;
                txtPayHand.Properties.ReadOnly = false;
                //chkDoiTra.Enabled = true;
                chkCatGia.Enabled = true;

            }

            if (pStatus == "C")
            {
                btnDel.Enabled = false;
                //btnSave.Enabled = false;
                //btnComplete.Enabled = false;
                btnPayment.Enabled = txtIsPaid.Text == "Y" ? false : true;
                btnPayCard.Enabled = txtIsPaid.Text == "Y" ? false : true;
                btnPrint.Enabled = true;
                btnInPhieu.Enabled = true;
                btnPrintA4.Enabled = true;
                txtProductCode.Enabled = false;
                grvOldGold.OptionsBehavior.Editable = false;
                grvProduct.OptionsBehavior.Editable = false;
                cboCust.Properties.ReadOnly = true;
                cboEmp.Enabled = false;
                txtDiscount.Properties.ReadOnly = true;
               // txtMS4.Properties.ReadOnly = true;
                txtTienVangThem.Properties.ReadOnly = true;
                txtPayHand.Properties.ReadOnly = true;
               // chkDoiTra.Enabled = false;
                chkCatGia.Enabled = false;
            }
         //   if (chkDoiTra.Checked)
         //   {
          //      btnDel.Enabled = false;
          //  }
        }

        private void fn_createProductDataTable()
        {
            this.dtProduct.Columns.Add("ProductID", typeof(string));
            this.dtProduct.Columns.Add("ProductCode", typeof(string));
            this.dtProduct.Columns.Add("ProductDesc", typeof(string));
            this.dtProduct.Columns.Add("GoldCode", typeof(string));
            this.dtProduct.Columns.Add("GoldDesc", typeof(string));
            this.dtProduct.Columns.Add("SectionName", typeof(string));
            this.dtProduct.Columns.Add("TaskPrice", typeof(decimal));
            this.dtProduct.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtProduct.Columns.Add("TotalWeight", typeof(decimal));
            this.dtProduct.Columns.Add("GoldWeight", typeof(decimal));
            this.dtProduct.Columns.Add("SellRate", typeof(decimal));
            this.dtProduct.Columns.Add("SellAmount", typeof(decimal));
            this.dtProduct.Columns.Add("CcyRate", typeof(decimal));
            this.dtProduct.Columns.Add("PriceUnit", typeof(string));
            this.dtProduct.Columns.Add("PriceCcy", typeof(string));
            this.dtProduct.Columns.Add("CatNi", typeof(decimal));
            this.dtProduct.Columns.Add("RingSize", typeof(decimal));
            this.dtProduct.Columns.Add("GoldReal", typeof(decimal));
            this.dtProduct.Columns.Add("A", typeof(string));
            this.dtProduct.Columns.Add("SL", typeof(decimal));
            this.dtProduct.Columns.Add("DiamondPrice", typeof(decimal));

            this.dtOldGold.Columns.Add("GoldCode", typeof(string));
            this.dtOldGold.Columns.Add("GoldWeight", typeof(decimal));
            this.dtOldGold.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtOldGold.Columns.Add("BuyRate", typeof(decimal));
            this.dtOldGold.Columns.Add("PercentValue", typeof(decimal));
            this.dtOldGold.Columns.Add("BuyAmount", typeof(decimal));
            this.dtOldGold.Columns.Add("TotalGoldWeight", typeof(decimal));
            this.dtOldGold.Columns.Add("GCatNi", typeof(string));

            this.dt.Columns.Add("CustID",typeof(string));
            this.dt.Columns.Add("GoldCcy", typeof(string));
            this.dt.Columns.Add("SL",typeof(decimal));
            this.dt.Columns.Add("Amount", typeof(decimal));
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            //string strProductCode = "";
            //strProductCode = txtProductCode.EditValue.ToString().Trim().ToUpper();

            //if (strProductCode == string.Empty) return;


            ////Nếu không đủ số kí tự quy định về mã hàng => không kiểm tra
            //if (strProductCode.Length != clsSystem.ProductCodeLen) return;

            ////Kiểm tra mã hàng mới nhập có trùng với các hàng trên danh sach không?
            //bool IsDup = false;
            //for (int i = 0; i < grvProduct.RowCount; i++)
            //{
            //    if (grvProduct.GetRowCellValue(i, "ProductCode").ToString() == strProductCode)
            //        IsDup = true;
            //}
            //if (IsDup)
            //{
            //    ThongBao.Show("Lỗi", "Mã hàng này đã tồn tại trong danh sách.", "OK", ICon.Error);
            //    txtProductCode.EditValue = string.Empty;
            //    txtProductCode.Refresh();
            //    txtProductCode.Focus();
            //    return;
            //}

            //DataSet ds = new DataSet();
            //this.Cursor = Cursors.WaitCursor;
            //try
            //{
            //    if (txtProductCode.Text.Trim() != "")
            //    {
            //        ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_GetByCodeForSell]", strProductCode);

            //        if (ds.Tables.Count > 0)
            //        {
            //            //Tồn tại mã hàng cần nhập
            //            if (ds.Tables[0].Rows.Count == 1)
            //            {
            //                if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() == "0")
            //                {
            //                    if (ds.Tables[0].Rows[0]["Status"].ToString() == "O")
            //                    {
            //                        ThongBao.Show("Thông tin", "Hàng [" + strProductCode + "] đã xuất.", "OK", ICon.Error);

            //                        //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
            //                        txtProductCode.EditValue = string.Empty;
            //                        txtProductCode.Refresh();
            //                        txtProductCode.Focus();
            //                    }
            //                    else
            //                    {
            //                        txtProductID.Text = ds.Tables[0].Rows[0]["ProductID"].ToString();
            //                        txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
            //                        txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldCode"].ToString();
            //                        txtGoldDesc.Text = ds.Tables[0].Rows[0]["GoldDesc"].ToString();                                    
            //                        txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();
            //                        txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
            //                        txtGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
            //                        txtDiamondWeight.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
            //                        txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
            //                        txtSellRate.Text = ds.Tables[0].Rows[0]["SellRate"].ToString();
            //                        txtSellAmount.Text = fn_CalSellAmount(ds.Tables[0].Rows[0]["PriceUnit"].ToString(),
            //                                                                ds.Tables[0].Rows[0]["PriceCcy"].ToString(),                                                                            
            //                                                                decimal.Parse(ds.Tables[0].Rows[0]["CcyRate"].ToString()),
            //                                                                decimal.Parse(ds.Tables[0].Rows[0]["InPrice"].ToString()),
            //                                                                decimal.Parse(ds.Tables[0].Rows[0]["GoldWeight"].ToString()),
            //                                                                decimal.Parse(ds.Tables[0].Rows[0]["SellRate"].ToString())).ToString();
            //                        txtCcyRate.Text = ds.Tables[0].Rows[0]["CcyRate"].ToString();

            //                        grvProduct.AddNewRow();
            //                        grvProduct.UpdateCurrentRow();

            //                        //Xóa thông tin mặt hàng đã chọn
            //                        fn_clearChooseProduct();
            //                        txtProductCode.Refresh();
            //                        txtProductCode.Focus();
            //                    }
            //                }
            //                else
            //                {
            //                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);

            //                    txtProductCode.EditValue = string.Empty;
            //                    txtProductCode.Refresh();
            //                    txtProductCode.Focus();
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ThongBao.Show("Error", ex.Source + " -" + ex.Message, "OK", ICon.Error);
            //    ds.Dispose();
            //    this.Cursor = Cursors.Default;
            //    return;
            //}
            //finally
            //{
            //    ds.Dispose();
            //    this.Cursor = Cursors.Default;
            //}
        }

        private void fn_CalcBillTotal()
        {
            decimal dSellTotalAmount = 0, dBuyTotalAmount = 0;
            decimal dTotalAmount = 0;
            decimal dDiscount = 0,dAddMoney=0, dPayAmount = 0,dMS4=0;
            decimal dXRate = 0;
            try
            {
                //Tinh tong tien hang moi
                for (int i = 0; i < grvProduct.RowCount; i++)
                {
                    dSellTotalAmount += decimal.Parse(grvProduct.GetRowCellValue(i, "SellAmount").ToString());
                }
                txtSellTotalAmount.EditValue = dSellTotalAmount;

                //Tinh tong tien vang cu
                for (int j = 0; j < grvOldGold.RowCount; j++)
                {
                    dBuyTotalAmount += decimal.Parse(grvOldGold.GetRowCellValue(j, "BuyAmount").ToString());
                }
                txtBuyTotalAmount.EditValue = dBuyTotalAmount;


                //Con lai
                dTotalAmount = dSellTotalAmount - dBuyTotalAmount;
                txtTotalAmount.EditValue = dTotalAmount;

                //Thanh toan
                dDiscount = decimal.Parse(txtDiscount.EditValue.ToString());
                dAddMoney = decimal.Parse(txtDiscount.EditValue.ToString());
               // dMS4 = decimal.Parse(txtMS4.EditValue.ToString());
                dPayAmount = dTotalAmount - dDiscount+dAddMoney+dMS4;
                txtPayAmount.EditValue = dPayAmount;
                txtPayHand.EditValue = dPayAmount;

                lblPayAmountByNumber.Text = dPayAmount > 0 ? "Phải thu: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture) : "Phải chi: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture);
                SetLabelColor(dPayAmount);
                lblPayAmountByWord.Text = dPayAmount > 0 ? "THU " + VND.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG" : "CHI " + VND.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";
                btnSave_Click();
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm fn_CalcBillTotal: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {

            }
        }

        private void SetLabelColor(decimal value)
        {
            if (value > 0)
                lblPayAmountByNumber.AppearanceItemCaption.ForeColor = Color.Red;
            else
                lblPayAmountByNumber.AppearanceItemCaption.ForeColor = Color.Blue;
        }

        private void fn_CalcBillSubTotal()
        {
            decimal dPayAmount = 0, dDiscount = 0, dTotalAmount = 0,dAddMoney=0;

            try
            {
                dTotalAmount = decimal.Parse(txtTotalAmount.EditValue.ToString());
                dDiscount = decimal.Parse(txtDiscount.EditValue.ToString());
                dAddMoney = decimal.Parse(txtTienVangThem.EditValue == null ? "0" : txtTienVangThem.EditValue.ToString());
                dPayAmount = dTotalAmount - dDiscount+dAddMoney;
                txtPayAmount.EditValue = dPayAmount;
                txtPayHand.EditValue = dPayAmount;

                lblPayAmountByNumber.Text = dPayAmount > 0 ? "Phải thu: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture) : "Phải chi: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture);
                SetLabelColor(dPayAmount);
                lblPayAmountByWord.Text = dPayAmount > 0 ? "THU " + VND.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG" : "CHI " + VND.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm fn_CalcBillSubTotal: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {

            }
        }

        private decimal fn_CalSellAmount(string _PriceUnit, string _PriceCcy, decimal _CcyRate, decimal _InPrice,
            decimal _GoldWeight, decimal _SellRate, decimal _TaskPrice, decimal _DiamondPrice, decimal _SL)
        {
            decimal dResult = 0;
                if (_PriceUnit == "L") //vang chi
                {
                    dResult = (_TaskPrice * 1000 + _DiamondPrice * 1000 +  _GoldWeight * _SellRate * 1000 / clsSystem.HSGia) * _SL;
                }

                if (_PriceUnit == "G") //vang gam
                {
                    if (_PriceCcy == "USD")
                        dResult = ( _GoldWeight * _SellRate * _CcyRate + _DiamondPrice * 1000) * _SL;
                    else
                        dResult = (_GoldWeight * _SellRate * 1000 + _DiamondPrice * 1000) * _SL;
                }

                if (_PriceUnit == "M") //vang mon
                {
                    dResult = (_SellRate * 1000 + _DiamondPrice * 1000) * _SL; //_SellRate * _CcyRate;
                }

                //Lam tron den don vi nghin dong
                dResult = Functions.fn_VNDRounding(dResult);

                return dResult;
           
        }


        private void fn_clearChooseProduct()
        {
            txtProductID.Text = "";
            txtProductCode.EditValue = "";
            txtProductDesc.Text = "";
            txtGoldCode.Text = "";
            txtGoldDesc.Text = "";
            txtTaskPrice.Text = "";
            txtTotalWeight.Text = "";
            txtDiamondWeight.Text = "";
            txtGoldWeight.Text = "";
            txtSectionName.Text = "";
            txtSellRate.Text = "";
            txtSellAmount.Text = "";
            txtCcyRate.Text = "";
            txtPriceCcy.Text = "";
            txtPriceUnit.Text = "";
            txtRingSize.Text = "";
            txtDiamondPrice.Text = "";
        }

        private void grvProduct_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductID", txtProductID.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductCode", txtProductCode.Text.ToUpper());
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductDesc", txtProductDesc.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "GoldCode", txtGoldCode.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "GoldDesc", txtGoldDesc.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "SectionName", txtSectionName.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "GoldWeight", txtGoldWeight.Text == "" ? decimal.Parse(null) : decimal.Parse(txtGoldWeight.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "DiamondWeight", txtDiamondWeight.Text == "" ? decimal.Parse(null) : decimal.Parse(txtDiamondWeight.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "TaskPrice", txtTaskPrice.Text == "" ? decimal.Parse(null) : decimal.Parse(txtTaskPrice.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "SellRate", txtSellRate.Text == "" ? decimal.Parse(null) : decimal.Parse(txtSellRate.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "SellAmount", txtSellAmount.Text == "" ? decimal.Parse(null) : decimal.Parse(txtSellAmount.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "CcyRate", txtCcyRate.Text == "" ? decimal.Parse(null) : decimal.Parse(txtCcyRate.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "PriceUnit", txtPriceUnit.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "PriceCcy", txtPriceCcy.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "CatNi", txtCatNi.Text == "" ? decimal.Zero : decimal.Parse(txtCatNi.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "RingSize", txtRingSize.Text == "" ? decimal.Parse(null) : decimal.Parse(txtRingSize.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "A", txtA.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "SL", 1);
                this.grvProduct.SetRowCellValue(e.RowHandle, "DiamondPrice", txtDiamondPrice.Text == "" ? decimal.Zero : decimal.Parse(txtDiamondPrice.Text));
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm grvProduct_InitNewRow " + ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }

        }

        private void grvProduct_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            fn_CalcBillTotal();
        }

        private void grvOldGold_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            fn_CalcBillTotal();
        }

        private void grvOldGold_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                //this.grvOldGold.SetRowCellValue(e.RowHandle, "GoldWeight", 0);
                //this.grvOldGold.SetRowCellValue(e.RowHandle, "DiamondWeight", 0);
                if (strGoldCatNi == String.Empty)
                {
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "DiamondWeight", 0);
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "PercentValue", 100.00);
                }
                else
                {
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "GoldCode", strGoldCatNi);//DiamondWeight
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "DiamondWeight", 0);
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "TotalGoldWeight", dCatNi);
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "PercentValue", 100.00);
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "GoldWeight", dCatNi);
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "GCatNi", strGoldCatNi);
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "BuyRate", strSellRate);
                    // this.grvOldGold.SetRowCellValue(e.RowHandle, "DiamondWeight", 0);
                    this.grvOldGold.SetRowCellValue(e.RowHandle, "BuyAmount", Functions.fn_VNDRounding(dCatNi * 10 * decimal.Parse(grvOldGold.GetRowCellValue(e.RowHandle, "BuyRate").ToString())));
                    strGoldCatNi = "";
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm grvOldGold_InitNewRow " + ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
        }

        private void txtBuyRate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dBuyRate = 0;
            decimal dGoldWeight = 0;
            decimal dTotalBuyAmount = 0;
            DataRow row = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle);

            string strGoldCode = row["GoldCode"].ToString();
            decimal dPercentValue = decimal.Parse(row["PercentValue"].ToString());

            if (e.NewValue.ToString().Trim() != "")
            {
                if (!decimal.TryParse(e.NewValue.ToString(), out dBuyRate))
                {
                    ThongBao.Show("Lỗi", "Tỷ giá vàng chỉ được nhập kiểu số.", "OK", ICon.Error);
                    e.Cancel = true;
                    return;
                }

                if (dBuyRate <= 0)
                {
                    ThongBao.Show("Lỗi", "Tỷ giá vàng phải nhập vào số lớn hơn 0.", "OK", ICon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                dBuyRate = 0;
            }
            decimal.TryParse(row["GoldWeight"].ToString(), out dGoldWeight);

            //dTotalBuyAmount = dBuyRate * dGoldWeight * 1000 / 100;
            //dTotalBuyAmount = Functions.fn_VNDRounding(dTotalBuyAmount);
            //grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);

            dTotalBuyAmount = fn_Cal_OldGold_TotalAmount(strGoldCode, dBuyRate, dGoldWeight, dPercentValue);
            grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);
        }

        private void txtPercentValue_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dBuyRate = 0;
            decimal dGoldWeight = 0;
            decimal dTotalBuyAmount = 0;
            DataRow row = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle);

            string strGoldCode = row["GoldCode"].ToString();
            decimal dPercentValue = decimal.Parse(row["PercentValue"].ToString());

            if (e.NewValue.ToString().Trim() != "")
            {
                if (!decimal.TryParse(e.NewValue.ToString(), out dPercentValue))
                {
                    ThongBao.Show("Lỗi", "Giá trị % chỉ được nhập kiểu số.", "OK", ICon.Error);
                    e.Cancel = true;
                    return;
                }

                //if (dPercentValue <=0)
                //{
                //    ThongBao.Show("Lỗi", "Trọng lượng vàng phải nhập vào số lớn hơn 0.", "OK", ICon.Error);
                //    e.Cancel = true;
                //    return;
                //}
                if (decimal.Parse(e.NewValue.ToString()) > 100)
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập số nhỏ hơn 100 cột Giá trị %.", "OK", ICon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                dPercentValue = 100;
            }
            decimal.TryParse(row["BuyRate"].ToString(), out dBuyRate);
            decimal.TryParse(row["GoldWeight"].ToString(), out dGoldWeight);

            dTotalBuyAmount = fn_Cal_OldGold_TotalAmount(strGoldCode, dBuyRate, dGoldWeight, dPercentValue);
            grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);
        }

        private void txtGoldWeight_Old_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dBuyRate = 0;
            decimal dGoldWeight = 0;
            decimal dTotalBuyAmount = 0;
            DataRow row = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle);

            string strGoldCode = row["GoldCode"].ToString();
            decimal dPercentValue = decimal.Parse(row["PercentValue"].ToString());

            if (e.NewValue.ToString().Trim() != "")
            {
                if (!decimal.TryParse(e.NewValue.ToString(), out dGoldWeight))
                {
                    ThongBao.Show("Lỗi", "Trọng lượng vàng chỉ được nhập kiểu số.", "OK", ICon.Error);
                    e.Cancel = true;
                    return;
                }

                //if (dGoldWeight <= 0)
                //{
                //    ThongBao.Show("Lỗi", "Trọng lượng vàng phải nhập vào số lớn hơn 0.", "OK", ICon.Error);
                //    e.Cancel = true;
                //    return;
                //}
            }
            else
            {
                dGoldWeight = 0;
            }
            decimal.TryParse(row["BuyRate"].ToString(), out dBuyRate);

            //dTotalBuyAmount = dBuyRate * dGoldWeight * 1000 / 100;
            //dTotalBuyAmount = Functions.fn_VNDRounding(dTotalBuyAmount);
            //grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);

            dTotalBuyAmount = fn_Cal_OldGold_TotalAmount(strGoldCode, dBuyRate, dGoldWeight, dPercentValue);
            grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);
        }

        private decimal fn_Cal_OldGold_TotalAmount(string _GoldCode, decimal _BuyRate, decimal _GoldWeight, decimal _PercentValue)
        {
            try
            {
                decimal dTotalAmount = 0, dCcyXRate = 0;

                string strPriceUnit = "", strPriceCcy = "";
                //Lay thong tin loai de
                DataRow rowIGold = Functions.fn_GetIGold(_GoldCode);

                strPriceUnit = rowIGold["PriceUnit"].ToString();
                strPriceCcy = rowIGold["PriceCcy"].ToString();

                if (strPriceCcy != "" && strPriceCcy != "VND")
                {
                    DataRow rowXRate = Functions.fn_GetXRate(strPriceCcy);
                    dCcyXRate = decimal.Parse(rowXRate["BuyRate"].ToString());
                }
                else
                {
                    dCcyXRate = 1000;
                }

                if (strPriceUnit == "L")
                {
                    dTotalAmount = _BuyRate * _GoldWeight * dCcyXRate / clsSystem.HSGia*_PercentValue/100;
                }

                if (strPriceUnit == "G")
                {
                    dTotalAmount = _BuyRate * _GoldWeight * dCcyXRate * _PercentValue / 100;
                }

                if (strPriceUnit == "M")
                {
                    dTotalAmount = _BuyRate * dCcyXRate * _PercentValue / 100;
                }

                dTotalAmount = Functions.fn_VNDRounding(dTotalAmount);
                return dTotalAmount;
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                return 0;
            }
            finally
            {

            }
        }

        private bool fn_CheckValidate()
        {

            if (cboCust.SelectedIndex == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn khách hàng.", "OK", ICon.Error);
                cboCust.Focus();
                return false;
            }

            if (grvProduct.RowCount == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập ít nhất 1 món hàng.", "OK", ICon.Error);
                txtProductCode.Focus();
                return false;
            }
            return true;
        }
        private bool fn_CheckValidate(DataRow row)
        {
            string strGoldCode = "";
            string strSellRate = "";
            DataRow dr;
            try
            {
                //strGoldCode = row["GoldCode"].ToString();
                //strSellRate = row["SellRate"].ToString();
                //dr = Functions.fn_GetXRate(strGoldCode);
                //if (dr == null)
                //    return true;
                //if (decimal.Parse(strSellRate) < decimal.Parse(dr["MinSellRate"].ToString()) || decimal.Parse(strSellRate) > decimal.Parse(dr["MaxSellRate"].ToString()))
                //{
                //    ThongBao.Show("Lỗi", "Vui lòng chỉnh giá bán trong khoảng [" + decimal.Round(decimal.Parse(dr["MinSellRate"].ToString()), 0) + "]-[" + decimal.Round(decimal.Parse(dr["MaxSellRate"].ToString()), 0) + "]", "OK", ICon.Error);
                //    return false;
                //}
                //else 
                return true;
            }
            catch { return false; }
            finally { }
        }

        private void btnSave_Click()
        {
            DataSet ds = new DataSet();
            DataRow row;
            string strA="",strProductIDs = "", strTaskPrices = "", strSellRates = "", strSellAmounts = "", strCcyRates = "";
            string strGoldCodes = "", strGoldWeights = "", strDiamondWeights = "", strBuyRates = "", strPercentValues = "",
                strBuyAmounts = "", strTotalGoldWeight = "", strCatNis = "", strSL = "";
            if (bIsLoading)
                return;
            if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (grvProduct.RowCount > 0)
                {
                    for (int i = 0; i < grvProduct.RowCount; i++)
                    {
                        row = grvProduct.GetDataRow(i);
                        if (!fn_CheckValidate(row))
                            return;
                        strProductIDs += row["ProductID"].ToString() + "@";
                        strTaskPrices += row["TaskPrice"].ToString() + "@";
                        strSellRates += row["SellRate"].ToString() + "@";
                        strSellAmounts += row["SellAmount"].ToString() + "@";
                        strCcyRates += row["CcyRate"].ToString() + "@";
                        strCatNis += (row["CatNi"].ToString() == "" ? "0" : row["CatNi"].ToString()) + "@";
                        strSL += (row["SL"].ToString() == "" ? "1" : row["SL"].ToString()) + "@";
                        strA += (row["A"].ToString() == "" ? "1" : row["A"].ToString()) + "@";
                       
                    }
                    strProductIDs = strProductIDs.Substring(0, strProductIDs.Length - 1);
                    strTaskPrices = strTaskPrices.Substring(0, strTaskPrices.Length - 1);
                    strSellRates = strSellRates.Substring(0, strSellRates.Length - 1);
                    strSellAmounts = strSellAmounts.Substring(0, strSellAmounts.Length - 1);
                    strCcyRates = strCcyRates.Substring(0, strCcyRates.Length - 1);
                    strCatNis = strCatNis.Substring(0, strCatNis.Length - 1);
                    strSL = strSL.Substring(0, strSL.Length - 1);
                    strA = strA.Substring(0, strA.Length - 1);
  
                }
                else
                {
                    strProductIDs = "";
                    strTaskPrices = "";
                    strSellRates = "";
                    strSellAmounts = "";
                    strCcyRates = "";
                    strCatNis = "";
                    strSL = "";
                    strA = "";
              
                }

                if (grvOldGold.RowCount > 0)
                {
                    for (int i = 0; i < grvOldGold.RowCount; i++)
                    {
                        row = grvOldGold.GetDataRow(i);
                        strGoldCodes += row["GoldCode"].ToString() + "@";
                        strGoldWeights += (row["GoldWeight"].ToString() == "" ? "0" : row["GoldWeight"].ToString()) + "@";
                        strDiamondWeights += (row["DiamondWeight"].ToString() == "" ? "0" : row["DiamondWeight"].ToString()) + "@";
                        strBuyRates += (row["BuyRate"].ToString() == "" ? "0" : row["BuyRate"].ToString()) + "@";
                        strPercentValues += row["PercentValue"].ToString() + "@";
                        strBuyAmounts += row["BuyAmount"].ToString() + "@";
                        strTotalGoldWeight += row["TotalGoldWeight"].ToString() + "@";
                    }
                    strGoldCodes = strGoldCodes.Substring(0, strGoldCodes.Length - 1);
                    strGoldWeights = strGoldWeights.Substring(0, strGoldWeights.Length - 1);
                    strDiamondWeights = strDiamondWeights.Substring(0, strDiamondWeights.Length - 1);
                    strBuyRates = strBuyRates.Substring(0, strBuyRates.Length - 1);
                    strPercentValues = strPercentValues.Substring(0, strPercentValues.Length - 1);
                    strBuyAmounts = strBuyAmounts.Substring(0, strBuyAmounts.Length - 1);
                    strTotalGoldWeight = strTotalGoldWeight.Substring(0, strTotalGoldWeight.Length - 1);
                }
                else
                {
                    strGoldCodes = "";
                    strGoldWeights = "";
                    strDiamondWeights = "";
                    strBuyRates = "";
                    strPercentValues = "";
                    strBuyAmounts = "";
                    strTotalGoldWeight = "";
                }

                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYSELL_Ins]",
                            "", DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("hh:mm:ss"),
                            ((ItemList)cboCust.SelectedItem).ID,
                            "",
                            txtSellTotalAmount.EditValue.ToString(),
                            txtBuyTotalAmount.EditValue.ToString(),
                            txtTotalAmount.EditValue.ToString(),
                            txtDiscount.EditValue.ToString(),
                            txtPayAmount.EditValue.ToString(),
                            strProductIDs, strTaskPrices, strSellRates, strSellAmounts, strCcyRates,
                            strGoldCodes, strGoldWeights, strDiamondWeights, strBuyRates, strPercentValues, strBuyAmounts, strTotalGoldWeight,
                            "W", clsSystem.UserID, strCatNis, strSL,
                            txtDebitAmount.EditValue.ToString() == "" ? "0" : txtDebitAmount.EditValue.ToString(),chkCatGia.Checked?"1":"0",strA,txtTienVangThem.EditValue.ToString(),"0",((ItemList)cboEmp.SelectedItem).ID);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYSELL_Upd]",
                            strID, DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("hh:mm:ss"),
                            ((ItemList)cboCust.SelectedItem).ID,
                            "",
                            txtSellTotalAmount.EditValue.ToString(),
                            txtBuyTotalAmount.EditValue.ToString(),
                            txtTotalAmount.EditValue.ToString(),
                            txtDiscount.EditValue.ToString(),
                            txtPayAmount.EditValue.ToString(),
                            strProductIDs, strTaskPrices, strSellRates, strSellAmounts, strCcyRates,
                            strGoldCodes, strGoldWeights, strDiamondWeights, strBuyRates, strPercentValues, strBuyAmounts, strTotalGoldWeight,
                            "W", clsSystem.UserID, strCatNis, strSL,
                            txtDebitAmount.EditValue.ToString() == "" ? "0" : txtDebitAmount.EditValue.ToString(), chkCatGia.Checked ? "1" : "0", strA, txtTienVangThem.EditValue.ToString(),"0", ((ItemList)cboEmp.SelectedItem).ID);
                }

                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                {
                    if (strID == "")
                    {
                        strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                        txtBillCode.Text = ds.Tables[0].Rows[0]["BillCode"].ToString();
                        txtStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                        lblStatusName.Text = ds.Tables[0].Rows[0]["StatusName"].ToString();

                        fn_EnableControl(ds.Tables[0].Rows[0]["Status"].ToString());
                    }
                    //ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                    //btnComplete.Focus();
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
                fn_LoadDataToForm(strID);

            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            fn_LoadDefault();
            fn_EnableControl(txtStatus.Text.Trim());
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmRTBuySell_Lst frm = new frmRTBuySell_Lst(this);
            frm.ShowDialog();
        }

        public void fn_LoadDataToForm(string _TrnID)
        {
            if (_TrnID != "")
            {
                DataSet ds = new DataSet();

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    bIsLoading = true;
                    ds = clsCommon.ExecuteDatasetSP("TRN_RT_BUYSELL_Get", _TrnID);

                    strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                    strTillTxnID = ds.Tables[0].Rows[0]["TillTxnID"].ToString();

                    txtBillCode.EditValue = ds.Tables[0].Rows[0]["BillCode"].ToString();
                    cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["CustID"].ToString(), cboCust, 0);
                    cboEmp.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["EmpID"].ToString(),cboEmp,0);
                    dtpDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"].ToString();
                    txtStatus.EditValue = ds.Tables[0].Rows[0]["Status"].ToString();
                    txtIsPaid.EditValue = ds.Tables[0].Rows[0]["IsPaid"].ToString();
                    lblStatusName.Text = ds.Tables[0].Rows[0]["StatusName"].ToString();

                    txtSellTotalAmount.EditValue = ds.Tables[0].Rows[0]["SellTotalAmount"];
                    txtBuyTotalAmount.EditValue = ds.Tables[0].Rows[0]["BuyTotalAmount"];
                    txtTotalAmount.EditValue = ds.Tables[0].Rows[0]["TotalAmount"];
                    txtDiscount.EditValue = ds.Tables[0].Rows[0]["Discount"];
                    txtTienVangThem.EditValue = ds.Tables[0].Rows[0]["AddMoney"];
                   // txtMS4.EditValue=ds.Tables[0].Rows[0]["TaskPriceAdd"];
                    txtPayAmount.EditValue = ds.Tables[0].Rows[0]["PayAmount"];
                    txtPayHand.EditValue = ds.Tables[0].Rows[0]["PayHand"];
                    txtDebitAmount.EditValue = ds.Tables[0].Rows[0]["DebitAmount"];
                    fn_EnableControl(ds.Tables[0].Rows[0]["Status"].ToString());
                    if (ds.Tables[0].Rows[0]["IsCatGia"].ToString() == "1")
                        chkCatGia.Checked = true;
                    else chkCatGia.Checked = false;
                    decimal dPayAmount = decimal.Parse(txtPayAmount.EditValue.ToString());
                    lblPayAmountByNumber.Text = dPayAmount > 0 ? "Phải thu: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture) : "Phải chi: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture);
                    SetLabelColor(dPayAmount);
                    lblPayAmountByWord.Text = dPayAmount > 0 ? "THU " + VND.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG" : "CHI " + VND.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";
                    //grvProduct
                    dtProduct = ds.Tables[1];
                    grdProduct.DataSource = ds.Tables[1];

                    //grvOldGold
                    dtOldGold = ds.Tables[2];
                    grdOldGold.DataSource = ds.Tables[2];
                    lbGoldWeightToChar.Text = " ";
                    bIsLoading = false;
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
                }
            }
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            fn_CalcBillSubTotal();
        }

        public bool btnComplete_Click()
        {
            btnSave_Click();
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYSELL_Complete]", strID, clsSystem.UserID);

                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                {
                    strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                    strTillTxnID = ds.Tables[0].Rows[0]["TillTxnID"].ToString();
                    txtStatus.Text = "C";
                    lblStatusName.Text = "Đã hoàn tất";

                    fn_EnableControl("C");
                    return true;
                    //ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                btnPayment.Enabled = true;
                btnPayCard.Enabled = true;
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                return false;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                //btnPayment.Focus();
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            //if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn thanh toán giao dịch này?", "Có", "Không", ICon.QuestionMark) != DialogResult.OK)
            //    return;
            if (clsSystem.TillID == "")
            {
                ThongBao.Show("Lỗi", "Không thể thanh toán vì chưa mở quầy thu ngân.", "OK", ICon.Error);
                return;
            }

            if (!btnComplete_Click())
                return;
            btnPayment.Enabled = false;
            btnPayCard.Enabled = false;
            frmTillProccessTxn frm = new frmTillProccessTxn(strID);
            if (frm.strErrorCode == "0")
            {
                if (clsSystem.IsSMS)
                {
                    decimal TongTien = 0;
                    decimal.TryParse(txtPayAmount.Text, out TongTien);
                    //if (TongTien > 10000000)
                    CommSetting.SendMessage("Giao dich: mua ban \n So tien: " + txtPayAmount.Text + ",Quay: " + clsSystem.TillName + " NV:" + clsSystem.UserName);
                }
                //if (chkCatGia.Checked)
                //{
                //    DataSet ds = new DataSet();
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_CATGIA_UpdByCustID", dt.Rows[i]["CustID"].ToString(),dt.Rows[i]["GoldCcy"].ToString(),dt.Rows[i]["SL"],dt.Rows[i]["Amount"]);
                //        ds.Clear();
                //    }
                //     //DataSet ds = new DataSet();
                //     //ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_CATGIA_CANCEL", ((ItemList)cboCust.SelectedItem).ID);
                //     //ds.Dispose();
                //    ds.Dispose();
                //}
                btnPayment.Enabled = false;
                btnPayCard.Enabled = false;
                txtIsPaid.Text = "Y";
                btnAddNew.Focus();
            }
        }

        private void txtProdSellRate_Leave(object sender, EventArgs e)
        {
            decimal dSellAmount = 0;
            string strGoldCode = "", strPriceUnit = "", strPriceCcy = "";
            decimal dCcyRate = 0, dGoldWeight = 0, dSellRate = 0, dTaskPrice = 0, dCatNi = 0, dSL = 0, dDiamondPrice = 0;


            try
            {


                strPriceUnit = grvProduct.GetFocusedRowCellValue("PriceUnit").ToString();
                strPriceCcy = grvProduct.GetFocusedRowCellValue("PriceCcy").ToString();
                dCcyRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("CcyRate").ToString());
                dGoldWeight = decimal.Parse(grvProduct.GetFocusedRowCellValue("GoldWeight").ToString());
                dSellRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("SellRate").ToString());
                dDiamondPrice = decimal.Parse(grvProduct.GetFocusedRowCellValue("DiamondPrice").ToString());

                dTaskPrice = decimal.Parse(grvProduct.GetFocusedRowCellValue("TaskPrice").ToString());
                dCatNi = decimal.Parse(grvProduct.GetFocusedRowCellValue("CatNi").ToString());
                dSL = decimal.Parse(grvProduct.GetFocusedRowCellValue("SL").ToString());

                dSellAmount = fn_CalSellAmount(strPriceUnit, strPriceCcy, dCcyRate, 0, dGoldWeight + dCatNi, dSellRate, dTaskPrice, dDiamondPrice, dSL);
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], dSellAmount);

                fn_CalcBillTotal();
            }
            catch (Exception ex)
            {
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], 0);
            }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtProductCode.EditValue == null || txtProductCode.EditValue.ToString() == "")
                    return;
                string strProductCode = "";
                strProductCode = txtProductCode.EditValue.ToString().Trim().ToUpper();

                if (strProductCode == string.Empty) return;


                ////Nếu không đủ số kí tự quy định về mã hàng => không kiểm tra
                //if (strProductCode.Length != clsSystem.ProductCodeLen) return;

                //Kiểm tra mã hàng mới nhập có trùng với các hàng trên danh sach không?
                bool IsDup = false;
                for (int i = 0; i < grvProduct.RowCount; i++)
                {
                    if (grvProduct.GetRowCellValue(i, "ProductCode").ToString() == strProductCode)
                        //grvProduct.GetRowCellValue(i, "A").ToString() != "1")
                        IsDup = true;
                }
                if (IsDup)
                {
                    ThongBao.Show("Lỗi", "Mã hàng này đã tồn tại trong danh sách.", "OK", ICon.Error);
                    txtProductCode.EditValue = string.Empty;
                    txtProductCode.Refresh();
                    txtProductCode.Focus();
                    return;
                }

                DataSet ds = new DataSet();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (txtProductCode.Text.Trim() != "")
                    {
                        ds = clsCommon.ExecuteDatasetSP("T_PRODUCT_GetByCodeForSell", strProductCode);

                        if (ds.Tables.Count > 0)
                        {
                            //Tồn tại mã hàng cần nhập
                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() == "0")
                                {
                                    if (ds.Tables[0].Rows[0]["Status"].ToString() == "O")
                                    {
                                        ThongBao.Show("Thông tin", "Hàng [" + strProductCode + "] đã xuất.", "OK", ICon.Error);

                                        //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
                                        txtProductCode.EditValue = string.Empty;
                                        txtProductCode.Refresh();
                                        txtProductCode.Focus();
                                    }
                                    else
                                    {
                                        txtProductID.Text = ds.Tables[0].Rows[0]["ProductID"].ToString();
                                        txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                                        txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldCode"].ToString();
                                        txtGoldDesc.Text = ds.Tables[0].Rows[0]["GoldDesc"].ToString();
                                        txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();
                                        txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
                                        txtGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
                                        txtDiamondWeight.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
                                        txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                                        txtSellRate.Text = ds.Tables[0].Rows[0]["SellRate"].ToString();
                                        txtCatNi.Text = ds.Tables[0].Rows[0]["CatNi"].ToString();
                                        txtDiamondPrice.Text = ds.Tables[0].Rows[0]["DiamondPrice"].ToString();
                                        txtSellAmount.Text = fn_CalSellAmount(ds.Tables[0].Rows[0]["PriceUnit"].ToString(),
                                                                                ds.Tables[0].Rows[0]["PriceCcy"].ToString(),
                                                                                decimal.Parse(ds.Tables[0].Rows[0]["CcyRate"].ToString()),
                                                                                decimal.Parse(ds.Tables[0].Rows[0]["InPrice"].ToString()),
                                                                                decimal.Parse(ds.Tables[0].Rows[0]["GoldWeight"].ToString()),
                                                                                decimal.Parse(ds.Tables[0].Rows[0]["SellRate"].ToString()),
                                                                                decimal.Parse(ds.Tables[0].Rows[0]["TaskPrice"].ToString()), decimal.Parse(ds.Tables[0].Rows[0]["DiamondPrice"].ToString()),
                                                                                decimal.Parse(1.ToString())).ToString();
                                        txtCcyRate.Text = ds.Tables[0].Rows[0]["CcyRate"].ToString();
                                        txtPriceUnit.Text = ds.Tables[0].Rows[0]["PriceUnit"].ToString();
                                        txtPriceCcy.Text = ds.Tables[0].Rows[0]["PriceCcy"].ToString();
                                        txtRingSize.Text = ds.Tables[0].Rows[0]["RingSize"].ToString();
                                        txtA.Text = ds.Tables[0].Rows[0]["A"].ToString();
                                        grvProduct.AddNewRow();
                                        grvProduct.UpdateCurrentRow();
                                        btnSave_Click();
                                        //Xóa thông tin mặt hàng đã chọn
                                        fn_clearChooseProduct();
                                        txtProductCode.Refresh();
                                        txtProductCode.Focus();
                                    }
                                }
                                else
                                {
                                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);

                                    txtProductCode.EditValue = string.Empty;
                                    txtProductCode.Refresh();
                                    txtProductCode.Focus();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ThongBao.Show("Error", ex.Source + " -" + ex.Message, "OK", ICon.Error);
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
        }

        private void cboGoldCode_Old_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void grvOldGold_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "GoldCode")
            {
                string strGoldCode = "";
                DataRow dr;
                if (grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle) != null)
                {
                    strGoldCode = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle)["GoldCode"].ToString();
                }
                dr = Functions.fn_GetXRate(strGoldCode);
                if (dr != null)
                {
                    grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyRate"], dr["BuyRate"]);
                }
                else
                {
                    grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyRate"], "0");
                }
            }

            if (e.Column.FieldName == "GoldWeight")
            {
                DataRow dr = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle);
                if (dr == null)
                    return;
                //decimal GoldWeight = decimal.Parse(dr["TotalGoldWeight"].ToString()) - decimal.Parse(dr["DiamondWeight"].ToString());
                txtGoldWeight_Old_EditValueChanging(dr["GoldWeight"].ToString());
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }
            //if (chkDoiTra.Checked)
            //{
            //    ThongBao.Show("Thông báo", "Không thể xóa hóa đơn này.", "OK", ICon.Information);
            //    return;
            //}
            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("TRN_RT_BUYSELL_Del", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDefault();
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues, strSplit;
            string strDay = DateTime.Now.Day.ToString();
            string strMonth = DateTime.Now.Month.ToString();
            string strYear = DateTime.Now.Year.ToString().Substring(2, 2);
            strParams = "Day@Month@Year@SplitBill@DocTienThanhChu";


            ds = clsCommon.ExecuteDatasetSP("rptSRT_PrintBill", strID);
            strSplit = clsNumericFormat.fn_Split(ds.Tables[0].Rows[0]["BillCode"].ToString());
            strValues = strDay + "@" + strMonth + "@" + strYear + "@" + strSplit+"@"+lblPayAmountByWord.Text;
            //Functions.fn_ShowReport(ds, "rptSRT_PrintBill.rpt", strParams, strValues);
            if (clsSystem.UnitWeight == "P" || clsSystem.UnitWeight == "Ly")
                Functions.fn_ShowReport_CloseAfterPrint(ds, "rptSRT_PrintBill.rpt", strParams, strValues, true);
            else if (clsSystem.UnitWeight == "C")
                Functions.fn_ShowReport_CloseAfterPrint(ds, "rptSRT_PrintBill_C.rpt", strParams, strValues, true);
            else Functions.fn_ShowReport_CloseAfterPrint(ds, "rptSRT_PrintBill_L.rpt", strParams, strValues, true);
            fn_EnableControl("");
            fn_LoadDefault();
        }

        private void grvOldGold_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvOldGold.OptionsBehavior.Editable == true)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (ThongBao.Show("Thông báo", "Bạn có chắc chắn là muốn xóa không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                    {
                        int i = grvOldGold.FocusedRowHandle;
                        grvOldGold.DeleteRow(i);
                        fn_CalcBillTotal();
                    }
                }
            }
        }

        private void grvProduct_KeyDown(object sender, KeyEventArgs e)
        {
           
            DataSet ds = new DataSet();
            DataRow dr;
            try
            {
                if (grvProduct.OptionsBehavior.Editable == true)
                {
                    //if (grvProduct.FocusedRowHandle >= 0 && e.KeyCode == Keys.Delete && chkDoiTra.Checked == true)
                    //{
                    //    int i = grvProduct.FocusedRowHandle;

                    //    dr = grvProduct.GetDataRow(i);
                    //    if (dr != null)
                    //    {
                           
                    //        if (ThongBao.Show("Thông báo", "Bạn có chắc chắn là muốn xóa không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                    //        {
                    //            ds = clsCommon.ExecuteDatasetSP("TRN_RT_DOITRA_Ins", "",DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss"), dr["ProductCode"].ToString(), dr["GoldWeight"], dr["DiamondWeight"], dr["SectionID"], txtBillCode.Text.Trim(), ((ItemList)cboCust.SelectedItem).ID, clsSystem.UserID);
                    //            grvProduct.DeleteRow(i);
                    //            fn_CalcBillTotal();
                    //        }
                    //    }

                    //}
                     if (e.KeyCode == Keys.Delete)
                    {
                        if (ThongBao.Show("Thông báo", "Bạn có chắc chắn là muốn xóa không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                        {
                            int i = grvProduct.FocusedRowHandle;
                            grvProduct.DeleteRow(i);
                            fn_CalcBillTotal();
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                ds.Dispose();

            }
        }

        private void txtTrongluonghot_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal NewValue = 0;
            decimal TotalGoldWeight = 0;
            decimal GoldWeight = 0;
            DataRow row = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle);

            if (e.NewValue.ToString().Trim() != "")
            {
                if (!decimal.TryParse(e.NewValue.ToString(), out NewValue))
                {
                    ThongBao.Show("Lỗi", "Trọng lượng hột chỉ được nhập kiểu số.", "OK", ICon.Error);
                    return;
                }
                if (!decimal.TryParse(row["TotalGoldWeight"].ToString(), out TotalGoldWeight))
                {
                    ThongBao.Show("Lỗi", "Vui lòng kiểm tra cột trọng lượng vàng + hột.", "OK", ICon.Error);
                    return;
                }
                if (NewValue < 0)
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập vào số lớn hơn 0 cột trọng lượng hột.", "OK", ICon.Error);
                    e.Cancel = true;
                    return;
                }
                if (NewValue > TotalGoldWeight)
                {
                    ThongBao.Show("Lỗi", "TL hột phải nhỏ hơn TL vàng + hột", "OK", ICon.Error);
                    e.Cancel = true;
                    return;
                }

            }
            else
            {
                NewValue = 0;
            }
            GoldWeight = TotalGoldWeight - NewValue;

            //dTotalBuyAmount = dBuyRate * dGoldWeight * 1000 / 100;
            //dTotalBuyAmount = Functions.fn_VNDRounding(dTotalBuyAmount);
            //grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);            
            grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["GoldWeight"], GoldWeight);

        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues;

            strParams = "";
            strValues = "";

            ds = clsCommon.ExecuteDatasetSP("InPhieuThanhToan", strID);
            Functions.fn_ShowReport_CloseAfterPrint(ds, "InPhieuThanhToan.rpt", strParams, strValues, false);
        }

        private void grvOldGold_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private bool fn_CheckValidate_OldGold(DataRow row)
        {
            try
            {
                if (row["GoldWeight"] == DBNull.Value)
                {
                    ThongBao.Show("Lỗi", "Nhập trọng lương vàng", "OK", ICon.Error);
                    return false;
                }
                if (row["TotalGoldWeight"] == DBNull.Value)
                {
                    ThongBao.Show("Lỗi", "Nhập trọng lương dẻ", "OK", ICon.Error);
                    return false;
                }
                else if (decimal.Parse(row["TotalGoldWeight"].ToString()) < decimal.Parse(row["DiamondWeight"].ToString()))
                {
                    ThongBao.Show("Lỗi", "Trọng lượng vàng + hột phải lớn hơn trọng luong hột", "OK", ICon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm fn_CheckValidate_OldGold: " + ex.Message, "OK", ICon.Error);
                return false;
            }
            return true;

        }

        private void grvOldGold_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.Row != null && !fn_CheckValidate_OldGold(((DataRowView)e.Row).Row))
                e.Valid = false;
        }

        private void gtxtTotalWeight_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal NewValue = decimal.Zero;
            decimal TLHot = decimal.Zero;
            decimal TLVang = decimal.Zero;
            DataRow dr = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle);
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
                TLVang = NewValue - TLHot;
                grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["GoldWeight"], TLVang);
            }
            catch
            {

            }
        }

        private void txtGoldWeight_Old_EditValueChanging(string value)
        {
            decimal dBuyRate = 0;
            decimal dGoldWeight = 0;
            decimal dTotalBuyAmount = 0;
            DataRow row = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle);

            string strGoldCode = row["GoldCode"].ToString();
            decimal dPercentValue = decimal.Parse(row["PercentValue"].ToString());

            if (value.ToString().Trim() != "")
            {
                if (!decimal.TryParse(value, out dGoldWeight))
                {
                    ThongBao.Show("Lỗi", "Trọng lượng vàng chỉ được nhập kiểu số.", "OK", ICon.Error);
                    return;
                }

                //if (dGoldWeight <= 0)
                //{
                //    ThongBao.Show("Lỗi", "Trọng lượng vàng phải nhập vào số lớn hơn 0.", "OK", ICon.Error);
                //    e.Cancel = true;
                //    return;
                //}
            }
            else
            {
                dGoldWeight = 0;
            }
            decimal.TryParse(row["BuyRate"].ToString(), out dBuyRate);

            //dTotalBuyAmount = dBuyRate * dGoldWeight * 1000 / 100;
            //dTotalBuyAmount = Functions.fn_VNDRounding(dTotalBuyAmount);
            //grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);

            dTotalBuyAmount = fn_Cal_OldGold_TotalAmount(strGoldCode, dBuyRate, dGoldWeight, dPercentValue);
            grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);
        }

        private void grvOldGold_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "TotalGoldWeight" || e.Column.FieldName == "DiamondWeight")
                {
                    DataRow row = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle);
                    decimal GoldWeight = decimal.Parse(row["GoldWeight"].ToString());
                    DataRow dr = Functions.fn_GetIGold(row["GoldCode"].ToString());
                    if (dr["PriceUnit"].ToString() == "L")
                    {

                        GoldWeight = GoldWeight * clsSystem.HSTL;
                        lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper() == ""
                                                      ? " "
                                                      :
                                                          Gold.process(GoldWeight.ToString()).ToUpper();

                    }
                    else if (dr["PriceUnit"].ToString() == "G")
                    {
                        int k;
                        if (clsSystem.UnitWeight == "Ly" || clsSystem.UnitWeight == "P")
                            k = 2;
                        else if (clsSystem.UnitWeight == "C")
                            k = 3;
                        else k = 4;
                        GoldWeight = Math.Round(GoldWeight, k);
                        lbGoldWeightToChar.Text = Gam.process(GoldWeight.ToString()).ToUpper() == ""
                                                      ? " "
                                                      : (Gam.process(GoldWeight.ToString()).ToUpper() + " GAM");
                    }
                    else
                        lbGoldWeightToChar.Text = " ";
                }
            }
            catch
            {
                lbGoldWeightToChar.Text = " ";
            }
        }

        private void grvOldGold_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvOldGold.FocusedRowHandle <= -1)
                    lbGoldWeightToChar.Text = " ";
                else
                {
                    //DataRow row = grvOldGold.GetDataRow(e.FocusedRowHandle);
                    //decimal GoldWeight = Math.Abs(decimal.Parse(row["GoldWeight"].ToString()));
                    //DataRow dr = Functions.fn_GetIGold(row["GoldCode"].ToString());
                    //if (dr["PriceUnit"].ToString() == "L")
                    //    lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper() == "" ? " " :
                    //        Gold.process(GoldWeight.ToString()).ToUpper();
                    //else if (dr["PriceUnit"].ToString() == "G")
                    //    lbGoldWeightToChar.Text = Gam.process(GoldWeight.ToString()).ToUpper() == "" ? " "
                    //        : (Gam.process(GoldWeight.ToString()).ToUpper() + " GAM");
                    //else
                    //    lbGoldWeightToChar.Text = " ";                   

                    DataRow row = grvOldGold.GetDataRow(e.FocusedRowHandle);
                    decimal GoldWeight = decimal.Parse(row["GoldWeight"].ToString());
                    DataRow dr = Functions.fn_GetIGold(row["GoldCode"].ToString());
                    if (dr["PriceUnit"].ToString() == "L")
                    {
                        GoldWeight = GoldWeight * clsSystem.HSTL;
                        lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper() == ""
                                                      ? " "
                                                      :
                                                          Gold.process(GoldWeight.ToString()).ToUpper();

                    }
                    else if (dr["PriceUnit"].ToString() == "G")
                    {
                        int k;
                        if (clsSystem.UnitWeight == "Ly" || clsSystem.UnitWeight == "P" || clsSystem.UnitWeight == "Z")
                            k = 2;
                        else if (clsSystem.UnitWeight == "C")
                            k = 3;
                        else k = 4;
                        GoldWeight = Math.Round(GoldWeight, k);
                        lbGoldWeightToChar.Text = Gam.process(GoldWeight.ToString()).ToUpper() == ""
                                                      ? " "
                                                      : (Gam.process(GoldWeight.ToString()).ToUpper() + " GAM");
                    }
                    else
                        lbGoldWeightToChar.Text = " ";
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
        }

        private void cboGoldCode_Old_Leave(object sender, EventArgs e)
        {
            string strGoldCode = "";
            decimal dBuyRate = decimal.Zero;
            decimal dGoldWeight = decimal.Zero;
            decimal PercentValue = decimal.Zero;
            decimal dTotalBuyAmount = decimal.Zero;
            try
            {
                DataRow dr = grvOldGold.GetDataRow(grvOldGold.FocusedRowHandle);
                strGoldCode = ((ComboBoxEdit)sender).EditValue.ToString();
                //if (strGoldCode == "D La")
                //    colBuyRate.OptionsColumn.AllowEdit = true;
                //else
                //{
                //    colBuyRate.OptionsColumn.AllowEdit = false;
                //}
                dBuyRate = (decimal)dr["BuyRate"];
                dGoldWeight = (decimal)dr["GoldWeight"];
                PercentValue = (decimal)dr["PercentValue"];
                dTotalBuyAmount = fn_Cal_OldGold_TotalAmount(strGoldCode, dBuyRate, dGoldWeight, PercentValue);
                grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);
            }
            catch { }
            finally
            {
                grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["GoldCode"], strGoldCode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal TongTien = 0;
            decimal.TryParse(txtPayAmount.Text, out TongTien);
            // if (TongTien > 10000000)
            CommSetting.SendMessage("Giao dich: mua ban \n So tien: 10,000,000, Quay thu ngan: Quay 1, Nguoi Dung: Oanh");

        }

        private void rtxtCatNi_Leave(object sender, EventArgs e)
        {
            decimal dGoldWei = Convert.ToDecimal(grvProduct.GetFocusedRowCellValue("GoldWeight").ToString());
            //if (Convert.ToDecimal(grvProduct.GetFocusedRowCellValue("CatNi").ToString()) <= -dGoldWei)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            grvProduct.SetFocusedRowCellValue(grvProduct.Columns["GoldReal"], (dGoldWei + Convert.ToDecimal(grvProduct.GetFocusedRowCellValue("CatNi").ToString())));

            decimal dSellAmount = 0;
            string strPriceUnit = "", strPriceCcy = "";
            decimal dCcyRate = 0, dGoldWeight = 0, dSellRate = 0, dTaskPrice = 0, dCatNi = 0, dDiamondPrice = 0, dSL;


            try
            {
                //string gocode = "";
                //gocode = grvProduct.GetFocusedRowCellValue("GoldCode").ToString();
                //DataSet ds = new DataSet();
                //ds = clsCommon.LoadComboSP("I_GOLD_CHANGE", gocode);
                //strSellRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("SellRate").ToString());
                //strGoldCatNi = ds.Tables[0].Rows[0]["GoldCode"].ToString();

                //strProductCatNi = grvProduct.GetFocusedRowCellValue("ProductCode").ToString();
                //dCatNi = decimal.Parse(grvProduct.GetFocusedRowCellValue("CatNi").ToString());
                //bool co = true;
                //for (int j = 0; j < grvOldGold.RowCount; j++)
                //{
                //    if (grvOldGold.GetRowCellValue(j, "GCatNi").ToString() == strGoldCatNi)
                //    {
                //        grvOldGold.SetRowCellValue(j, "TotalGoldWeight", dCatNi);
                //        grvOldGold.SetRowCellValue(j, "GoldWeight", dCatNi);
                //        grvOldGold.UpdateCurrentRow();
                //        decimal dPercent = grvOldGold.GetRowCellValue(j, "PercentValue") == null ? 0 :
                //        Convert.ToDecimal(grvOldGold.GetRowCellValue(j, "PercentValue").ToString());
                //        decimal dTotalBuyAmount = fn_Cal_OldGold_TotalAmount(strGoldCatNi, strSellRate, dCatNi, dPercent);
                //        grvOldGold.SetFocusedRowCellValue(grvOldGold.Columns["BuyAmount"], dTotalBuyAmount);
                //        strGoldCatNi = "";
                //        co = false;
                //        break;
                //    }
                //}
                //if (co)
                //{
                //    grvOldGold.AddNewRow();
                //    grvOldGold.UpdateCurrentRow();
                //}
                strPriceUnit = grvProduct.GetFocusedRowCellValue("PriceUnit").ToString();
                strPriceCcy = grvProduct.GetFocusedRowCellValue("PriceCcy").ToString();
                dCcyRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("CcyRate").ToString());
                dGoldWeight = decimal.Parse(grvProduct.GetFocusedRowCellValue("GoldWeight").ToString());
                dSellRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("SellRate").ToString());
                dTaskPrice = decimal.Parse(grvProduct.GetFocusedRowCellValue("TaskPrice").ToString());
                dCatNi = Convert.ToDecimal(grvProduct.GetFocusedRowCellValue("CatNi").ToString());
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["CatNi"], dCatNi);
                dSL = decimal.Parse(grvProduct.GetFocusedRowCellValue("SL").ToString());
                dDiamondPrice = decimal.Parse(grvProduct.GetFocusedRowCellValue("DiamondPrice").ToString());
                dSellAmount = fn_CalSellAmount(strPriceUnit, strPriceCcy, dCcyRate, 0, dGoldWeight + dCatNi, dSellRate, dTaskPrice, dDiamondPrice, dSL);
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], dSellAmount);

                
                fn_CalcBillTotal();
            }
            catch (Exception ex)
            {
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], 0);
            }
        }

        internal void FocusProductCode()
        {
            txtProductCode.Focus();
        }

        private void txtDiscount_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (bIsLoading)
                return;
            decimal dNewValue = 0;
            decimal dTotalAMount = 0;
            dTotalAMount = decimal.Parse(txtTotalAmount.EditValue.ToString());
            if (!decimal.TryParse(e.NewValue.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Tiền bớt chỉ được nhập kiểu số.", "OK", ICon.Error);
                return;
            }
            if (dNewValue < 0)
            {
                ThongBao.Show("Lỗi", "Tiền bớt không thể nhỏ hơn không.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
            if (dNewValue > dTotalAMount)
            {
                ThongBao.Show("Lỗi", "Tiền bớt phải nhỏ hơn tiền còn lại.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
        }

        internal void focus_productcode()
        {
            txtProductCode.Focus();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmOptionCustomer frm = new frmOptionCustomer();
            frm.ShowDialog();
            fn_LoadDataToCombo();
            cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(frm.mstrID, cboCust, 0);
        }

        private void rtxtCatNi_EditValueChanging(object sender, ChangingEventArgs e)
        {
            decimal dGoldWei = Convert.ToDecimal(grvProduct.GetFocusedRowCellValue("GoldWeight").ToString());
            if (Convert.ToDecimal(e.NewValue.ToString()) <= -dGoldWei)
            {
                e.Cancel = true;
                return;
            }
            grvProduct.SetFocusedRowCellValue(grvProduct.Columns["GoldReal"], (dGoldWei + Convert.ToDecimal(e.NewValue.ToString())));

            decimal dSellAmount = 0;
            string strPriceUnit = "", strPriceCcy = "";
            decimal dCcyRate = 0, dGoldWeight = 0, dSellRate = 0, dTaskPrice = 0, dCatNi = 0, dDiamondPrice = 0, dSL;

            try
            {
                strPriceUnit = grvProduct.GetFocusedRowCellValue("PriceUnit").ToString();
                strPriceCcy = grvProduct.GetFocusedRowCellValue("PriceCcy").ToString();
                dCcyRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("CcyRate").ToString());
                dGoldWeight = decimal.Parse(grvProduct.GetFocusedRowCellValue("GoldWeight").ToString());
                dSellRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("SellRate").ToString());
                dTaskPrice = decimal.Parse(grvProduct.GetFocusedRowCellValue("TaskPrice").ToString());
                dCatNi = Convert.ToDecimal(e.NewValue.ToString());
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["CatNi"], dCatNi);
                dSL = decimal.Parse(grvProduct.GetFocusedRowCellValue("SL").ToString());
                dDiamondPrice = decimal.Parse(grvProduct.GetFocusedRowCellValue("DiamondPrice").ToString());
                dSellAmount = fn_CalSellAmount(strPriceUnit, strPriceCcy, dCcyRate, 0, dGoldWeight + dCatNi, dSellRate, dTaskPrice, dDiamondPrice, dSL);
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], dSellAmount);

                //fn_CalcBillTotal();
            }
            catch (Exception ex)
            {
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], 0);
            }
        }

        private void frmRTBuySell_KeyDown(object sender, KeyEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Mua-ban.mht");
                Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Mua-ban.mht");
            }
        }

        private void rtxtSL_EditValueChanging(object sender, ChangingEventArgs e)
        {
            decimal dSL =
              Convert.ToDecimal(e.NewValue == null || e.NewValue.ToString() == "" ? "0" : e.NewValue.ToString());
            decimal dSLTT = decimal.Parse(grvProduct.GetFocusedRowCellValue("A").ToString());

            if (dSL <= 0 || dSL > dSLTT)
            {
                e.Cancel = true;
                return;
            }

            grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SL"], dSL);
            txtProdSellRate_Leave(sender, new EventArgs());
        }

        private void grvProduct_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //try
            //{
            //    if (grvProduct.FocusedRowHandle > -1)
            //    {
            //        if (grvProduct.GetRowCellValue(e.FocusedRowHandle, "A").ToString() == "1" ||
            //            grvProduct.GetRowCellValue(e.FocusedRowHandle, "A").ToString() == "")
            //            grvProduct.Columns["SL"].OptionsColumn.AllowEdit = true;
            //        else
            //            grvProduct.Columns["SL"].OptionsColumn.AllowEdit = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            //}
        }

        private void txtPayHand_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (bIsLoading)
                return;
            decimal dNewValue = 0;
            decimal dTotalAMount = 0;
            dTotalAMount = decimal.Parse(txtPayAmount.EditValue.ToString());
            if (!decimal.TryParse(e.NewValue.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Trọng lượng hột chỉ được nhập kiểu số.", "OK", ICon.Error);
                return;
            }
            if (dNewValue < 0)
            {
                if (dTotalAMount > 0)
                    ThongBao.Show("Lỗi", "Tiền thanh toán không thể nhỏ hơn 0.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
            if (dNewValue > dTotalAMount)
            {
                ThongBao.Show("Lỗi", "Tiền thanh toán phải nhỏ hơn tiền hoá đơn.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
        }

        private void txtPayHand_EditValueChanged(object sender, EventArgs e)
        {
            //if (bIsLoading)
            //    return;
            //decimal dTotalAMount = decimal.Parse(txtPayAmount.EditValue.ToString());
            //decimal dPayHand = decimal.Parse(txtPayHand.EditValue.ToString());
            //txtDebitAmount.EditValue = dTotalAMount - dPayHand;
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !txtDiscount.Properties.ReadOnly)
                btnSave_Click();
        }

        private void txtPayHand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !txtPayHand.Properties.ReadOnly)
                btnSave_Click();
        }

        private void rtxtTaskPrice_Leave(object sender, EventArgs e)
        {
            decimal dSellAmount = 0;
            string strPriceUnit = "", strPriceCcy = "";
            decimal dCcyRate = 0, dGoldWeight = 0, dSellRate = 0, dTaskPrice = 0, dCatNi = 0, dDiamondPrice = 0, dSL = 0;

            try
            {
                strPriceUnit = grvProduct.GetFocusedRowCellValue("PriceUnit").ToString();
                strPriceCcy = grvProduct.GetFocusedRowCellValue("PriceCcy").ToString();
                dCcyRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("CcyRate").ToString());
                dGoldWeight = decimal.Parse(grvProduct.GetFocusedRowCellValue("GoldWeight").ToString());
                dSellRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("SellRate").ToString());
                dTaskPrice = decimal.Parse(grvProduct.GetFocusedRowCellValue("TaskPrice").ToString());
                dCatNi = decimal.Parse(grvProduct.GetFocusedRowCellValue("CatNi").ToString());
                dDiamondPrice = decimal.Parse(grvProduct.GetFocusedRowCellValue("DiamondPrice").ToString());
                dSL = decimal.Parse(grvProduct.GetFocusedRowCellValue("SL").ToString());

                dSellAmount = fn_CalSellAmount(strPriceUnit, strPriceCcy, dCcyRate, 0, dGoldWeight + dCatNi, dSellRate, dTaskPrice, dDiamondPrice, dSL);
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], dSellAmount);

                fn_CalcBillTotal();
            }
            catch (Exception ex)
            {
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], 0);
            }
        }

        private void btnPayCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSystem.TillID == "")
                {
                    ThongBao.Show("Lỗi", "Không thể thanh toán vì chưa mở quầy thu ngân.", "OK", ICon.Error);
                    return;
                }

                frmTillProcessCard frm = new frmTillProcessCard(strID, strTillTxnID, "SRT");
                DialogResult dlg = frm.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    frmTillProccessTxn frm1 = new frmTillProccessTxn(strID);
                    if (frm1.strErrorCode == "0")
                    {
                        if (clsSystem.IsSMS)
                        {
                            decimal TongTien = 0;
                            decimal.TryParse(txtPayAmount.Text, out TongTien);
                            //if (TongTien > 10000000)
                            CommSetting.SendMessage("Giao dich: mua ban \n So tien: " + txtPayAmount.Text + ",Quay: " + clsSystem.TillName + " NV:" + clsSystem.UserName);
                        }
                        btnPayment.Enabled = false;
                        btnPayCard.Enabled = false;
                        txtIsPaid.Text = "Y";
                        btnPrint.Focus();
                    }
                }
            }

            catch
            { return; }
            finally { }

        }

        private void frmRTBuySell_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsSystem.IsScan)
                FunctionTill.fn_CloseTill();
        }

        //private void chkDoiTra_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkDoiTra.Checked)
        //    {
        //        txtBillCode.Properties.ReadOnly = false;
        //        txtBillCode.Text = string.Empty;
                
        //    }
        //    else
        //    {
        //        txtBillCode.Properties.ReadOnly = true;
        //        txtBillCode.Text = "Tự động";
        //    }

        //}

        private void txtBillCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (e.KeyChar == 13)
                {
                    if (string.IsNullOrEmpty(txtBillCode.Text))
                    {
                        ThongBao.Show("Lỗi", "Vui lòng nhập hóa đơn cần đổi,trả", "OK", ICon.Error);
                        txtBillCode.Focus();
                        return;
                    }
                    if (ThongBao.Show("Thông báo", "Bạn có muốn thực hiện đổi trả cho hóa đơn này", "OK", "Cancel", ICon.QuestionMark) == DialogResult.OK)
                    {
                        ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYSELL_GetBillCode]", txtBillCode.Text.Trim());
                        if (ds.Tables.Count == 1)
                        {
                            if (ds.Tables[0].Rows[0]["ErrCode"].ToString() != "")
                            {
                                ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                                return;
                            }
                        }
                        else
                        {

                            strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                            strTillTxnID = ds.Tables[0].Rows[0]["TillTxnID"].ToString();

                            txtBillCode.EditValue = ds.Tables[0].Rows[0]["BillCode"].ToString();
                            cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["CustID"].ToString(), cboCust, 0);
                            dtpDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"].ToString();
                            txtStatus.EditValue = ds.Tables[0].Rows[0]["Status"].ToString();
                            txtIsPaid.EditValue = ds.Tables[0].Rows[0]["IsPaid"].ToString();
                            lblStatusName.Text = ds.Tables[0].Rows[0]["StatusName"].ToString();

                            txtSellTotalAmount.EditValue = ds.Tables[0].Rows[0]["SellTotalAmount"];
                            txtBuyTotalAmount.EditValue = ds.Tables[0].Rows[0]["BuyTotalAmount"];
                            txtTotalAmount.EditValue = ds.Tables[0].Rows[0]["TotalAmount"];
                            txtDiscount.EditValue = ds.Tables[0].Rows[0]["Discount"];
                            txtPayAmount.EditValue = ds.Tables[0].Rows[0]["PayAmount"];
                            txtPayHand.EditValue = ds.Tables[0].Rows[0]["PayHand"];
                            txtDebitAmount.EditValue = ds.Tables[0].Rows[0]["DebitAmount"];
                            fn_EnableControl(ds.Tables[0].Rows[0]["Status"].ToString());
                            decimal dPayAmount = decimal.Parse(txtPayAmount.EditValue.ToString());
                            lblPayAmountByNumber.Text = dPayAmount > 0 ? "Phải thu: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture) : "Phải chi: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture);
                            SetLabelColor(dPayAmount);
                            lblPayAmountByWord.Text = dPayAmount > 0 ? "THU " + VND.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG" : "CHI " + VND.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";
                            //grvProduct
                            dtProduct = ds.Tables[1];
                            grdProduct.DataSource = ds.Tables[1];

                            //grvOldGold
                            dtOldGold = ds.Tables[2];
                            grdOldGold.DataSource = ds.Tables[2];
                            lbGoldWeightToChar.Text = " ";
                            // bIsLoading = false;
                        }
                    }
                    else
                        return;
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
            }

        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkCatGia_CheckedChanged(object sender, EventArgs e)
        {

            decimal dGoldWeight_CG = 0;
            decimal dSellRate_CG = 0;
            decimal dTotalSellAmount=0;
            decimal dSellAmount = 0;
            string strGoldCode = "", strPriceUnit = "", strPriceCcy = "";
            decimal dCcyRate = 0, dGoldWeight = 0, dSellRate = 0, dTaskPrice = 0, dCatNi = 0, dSL = 0, dDiamondPrice = 0;
            if (cboCust.SelectedIndex < 0)
            {
                ThongBao.Show("Thông báo","Vui lòng chọn khách hàng","OK",ICon.Warning);
                return;
            }
            if (!chkCatGia.Checked)
            {
                for (int j = 0; j < grvProduct.RowCount; j++)
                {
                    
                        dGoldWeight = decimal.Parse(grvProduct.GetRowCellValue(j, "GoldWeight").ToString());
                        strPriceUnit = grvProduct.GetRowCellValue(j, "PriceUnit").ToString();
                        strPriceCcy = grvProduct.GetRowCellValue(j, "PriceCcy").ToString();
                        dCcyRate = decimal.Parse(grvProduct.GetRowCellValue(j, "CcyRate").ToString());

                        dSellRate = decimal.Parse(grvProduct.GetRowCellValue(j, "SellRate").ToString());
                        dDiamondPrice = decimal.Parse(grvProduct.GetRowCellValue(j, "DiamondPrice").ToString());
                        dTaskPrice = decimal.Parse(grvProduct.GetRowCellValue(j, "TaskPrice").ToString());
                        dCatNi = decimal.Parse(grvProduct.GetRowCellValue(j, "CatNi").ToString());
                        dSL = decimal.Parse(grvProduct.GetRowCellValue(j, "SL").ToString());
                        
                            dSellAmount = fn_CalSellAmount(strPriceUnit, strPriceCcy, dCcyRate, 0, dGoldWeight + dCatNi, dSellRate, dTaskPrice, dDiamondPrice, dSL);
                            grvProduct.SetRowCellValue(j, grvProduct.Columns["SellAmount"], dSellAmount);
                           

                    
                }
                fn_CalcBillTotal();
                dt.Clear();
                return;
            }
             DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_GETCATGIA]", ((ItemList)cboCust.SelectedItem).ID);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dGoldWeight_CG = decimal.Parse(ds.Tables[0].Rows[i]["SL"].ToString());
                    dSellRate_CG = decimal.Parse(ds.Tables[0].Rows[i]["Amount"].ToString());
                    for (int j = 0; j < grvProduct.RowCount; j++)
                    {
                        if (grvProduct.GetRowCellValue(j, "GoldCode").ToString() == ds.Tables[0].Rows[i]["GoldCcy"].ToString())
                        {
                            dGoldWeight = decimal.Parse(grvProduct.GetRowCellValue(j, "GoldWeight").ToString());
                            strPriceUnit = grvProduct.GetRowCellValue(j, "PriceUnit").ToString();
                            strPriceCcy = grvProduct.GetRowCellValue(j, "PriceCcy").ToString();
                            dCcyRate = decimal.Parse(grvProduct.GetRowCellValue(j, "CcyRate").ToString());

                            dSellRate = decimal.Parse(grvProduct.GetRowCellValue(j, "SellRate").ToString());
                            dDiamondPrice = decimal.Parse(grvProduct.GetRowCellValue(j, "DiamondPrice").ToString());
                            dTaskPrice = decimal.Parse(grvProduct.GetRowCellValue(j, "TaskPrice").ToString());
                            dCatNi = decimal.Parse(grvProduct.GetRowCellValue(j, "CatNi").ToString());
                            dSL = decimal.Parse(grvProduct.GetRowCellValue(j, "SL").ToString());
                            if (dGoldWeight_CG >= dGoldWeight + dCatNi)
                            {
                                dSellAmount = fn_CalSellAmount(strPriceUnit, strPriceCcy, dCcyRate, 0, dGoldWeight + dCatNi, dSellRate_CG, dTaskPrice, dDiamondPrice, dSL);
                                grvProduct.SetRowCellValue(j,grvProduct.Columns["SellAmount"], dSellAmount);
                                dGoldWeight_CG = dGoldWeight_CG - (dGoldWeight + dCatNi);

                            }
                            else
                            {
                                dSellAmount = fn_CalSellAmount(strPriceUnit, strPriceCcy, dCcyRate, 0, dGoldWeight_CG, dSellRate_CG, 0, 0, dSL) + fn_CalSellAmount(strPriceUnit, strPriceCcy, dCcyRate, 0, dGoldWeight + dCatNi - dGoldWeight_CG, dSellRate, dTaskPrice, dDiamondPrice, dSL);
                                grvProduct.SetRowCellValue(j,grvProduct.Columns["SellAmount"], dSellAmount);
                                dGoldWeight_CG = 0;
                            }

                        }
                        if (dGoldWeight_CG == 0)
                            break;
                    }
                    dt.Rows.Add(((ItemList)cboCust.SelectedItem).ID, ds.Tables[0].Rows[i]["GoldCcy"].ToString(), dGoldWeight_CG, dSellRate_CG);
                }
                fn_CalcBillTotal();
            }
            catch
            {

            }
            finally
            {
                ds.Dispose();
            }
        }

        private void grvOldGold_MouseDown(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    if (e.Button == MouseButtons.Left && grvOldGold.FocusedRowHandle >= 0)
            //    {
            //        GridHitInfo hInfo = grvOldGold.CalcHitInfo(new Point(e.X, e.Y));
            //        if (hInfo.InRowCell && hInfo.Column.FieldName == "BuyRate")
            //        {
            //            string curValue = grvOldGold.GetRowCellValue(hInfo.RowHandle, "GoldCode").ToString();
            //            if (curValue != "D La")
            //            {
            //                 colBuyRate.OptionsColumn.AllowEdit = false;
            //            }
            //            else colBuyRate.OptionsColumn.AllowEdit = true;
            //        }
            //    }
            //}
            //catch { }
        }

        private void txtAddMoney_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                fn_CalcBillSubTotal();
            }
            catch
            { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues, strSplit;
            string strDay = DateTime.Now.Day.ToString();
            string strMonth = DateTime.Now.Month.ToString();
            string strYear = DateTime.Now.Year.ToString().Substring(2, 2);
            strParams = "Day@Month@Year@SplitBill@DocTienThanhChu";


            ds = clsCommon.ExecuteDatasetSP("rptSRT_PrintBill", strID);
            strSplit = clsNumericFormat.fn_Split(ds.Tables[0].Rows[0]["BillCode"].ToString());
            strValues = strDay + "@" + strMonth + "@" + strYear + "@" + strSplit + "@" + lblPayAmountByWord.Text;
            //Functions.fn_ShowReport(ds, "rptSRT_PrintBill.rpt", strParams, strValues);
            if (clsSystem.UnitWeight == "P" || clsSystem.UnitWeight == "Ly")
                Functions.fn_ShowReport(ds, "rptSRT_PrintA4.rpt", strParams, strValues);
            else if (clsSystem.UnitWeight == "C")
                Functions.fn_ShowReport_CloseAfterPrint(ds, "rptSRT_PrintBill_C.rpt", strParams, strValues, true);
            else Functions.fn_ShowReport_CloseAfterPrint(ds, "rptSRT_PrintBill_L.rpt", strParams, strValues, true);
            fn_EnableControl("");
            fn_LoadDefault();
        }

        //private void txtMS4_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter && !txtMS4.Properties.ReadOnly)
        //        btnSave_Click();
        //}

        private void txtTienVangThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !txtTienVangThem.Properties.ReadOnly)
                btnSave_Click();
        }

        private void txtTienVangThem_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (bIsLoading)
                return;
            decimal dNewValue = 0;
            // decimal dTotalAMount = 0;
            // dTotalAMount = decimal.Parse(txtTotalAmount.EditValue.ToString());
            if (!decimal.TryParse(e.NewValue.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Chỉ được nhập kiểu số.", "OK", ICon.Error);
                return;
            }
            if (dNewValue < 0)
            {
                ThongBao.Show("Lỗi", "Không thể nhỏ hơn không.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
        }

        private void txtMS4_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (bIsLoading)
                return;
            decimal dNewValue = 0;
           // decimal dTotalAMount = 0;
           // dTotalAMount = decimal.Parse(txtTotalAmount.EditValue.ToString());
            if (!decimal.TryParse(e.NewValue.ToString(), out dNewValue))
            {
                ThongBao.Show("Lỗi", "Chỉ được nhập kiểu số.", "OK", ICon.Error);
                return;
            }
            if (dNewValue < 0)
            {
                ThongBao.Show("Lỗi", "Không thể nhỏ hơn không.", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
            //if (dNewValue > dTotalAMount)
            //{
            //    ThongBao.Show("Lỗi", "Tiền bớt phải nhỏ hơn tiền còn lại.", "OK", ICon.Error);
            //    e.Cancel = true;
            //    return;
            //}

        }

        private void txtTienVangThem_EditValueChanged(object sender, EventArgs e)
        {
            fn_CalcBillSubTotal();
        }

        private void txtMS4_EditValueChanged(object sender, EventArgs e)
        {
            fn_CalcBillSubTotal();
        }




    }
}