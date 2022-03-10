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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Controls;
using System.Globalization;

namespace GoldRT
{
    public partial class frmRTChange : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtProduct = new DataTable();
        private DataTable dtOldGold = new DataTable();

        public string strID = "";
        public string strTillTxnID = "";
        
        DataRow arrXRate;

        public frmRTChange()
        {
            InitializeComponent();
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
            cboGoldCode.SelectedIndex = 0;
            txtTotalGoldWeight.EditValue = "0";
            //txtGoldWeight.EditValue = "0";
            txtSellRate.EditValue = "0";
            txtTotalAmount.EditValue = "0";
            txtTotalTaskPrice.EditValue = "0";
            txtChangeAmount.EditValue = "0";
            txtTotalAllAmount.EditValue = "0";
           // txtTaskPriceAdd.EditValue = "0";
            txtDiscount.EditValue = "0";
           // txtMS4.EditValue = "0";
            txtTienVangThem.EditValue = "0";
            txtPayAmount.EditValue = "0";
            lblPayAmountByWord.Text = "";
            lblPayAmountByNumber.Text = " ";

            txtBillCode.Text = "Tự động";
            lblStatusName.Text = "{Rỗng}";
            txtStatus.Text = "";
            txtIsPaid.Text = "N";

            cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(clsSystem.WalkInCustID, cboCust, 0);

            fn_EnableControl("");
            this.ActiveControl = txtProductCode;
        }
        private void fn_LoadDataToComboOld()
        {
            string gocode = "";

            gocode = grvProduct.GetFocusedRowCellValue("GoldCode").ToString();
            DataSet ds = new DataSet();
            ds = clsCommon.LoadComboSP("I_GOLD_CHANGE", gocode);
            Functions.BindDropDownList(cboGoldCode_Old, ds, "GoldDesc", "GoldCode", false);
            ds.Clear();
            ds.Dispose();

        }
        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("I_GOLD_PRICEUINT", "L");
            Functions.BindDropDownList(cboGoldCode, ds, "GoldDesc", "GoldCode", "", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("T_EMPLOYEE", null);
            Functions.BindDropDownList(cboEmp, ds, "EmpName", "EmpID", "", false);
            ds.Clear();

            ds = clsCommon.LoadComboSP("I_CUSTOMER", "");
            Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "", true);
            ds.Clear();

            ds.Dispose();
        }

        public void fn_LoadDataToForm(string _TrnID)
        {
            if (_TrnID != "")
            {
                DataSet ds = new DataSet();

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    ds = clsCommon.ExecuteDatasetSP("TRN_RT_CHANGE_Get", _TrnID);

                    strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                    strTillTxnID = ds.Tables[0].Rows[0]["TillTxnID"].ToString();

                    txtBillCode.EditValue = ds.Tables[0].Rows[0]["BillCode"].ToString();
                    cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["CustID"].ToString(), cboCust, 0);
                    cboGoldCode.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldCode"].ToString(), cboGoldCode, 0);
                    cboEmp.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["EmpID"].ToString(), cboEmp, 0);
                    dtpDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"].ToString();
         
                    txtStatus.EditValue = ds.Tables[0].Rows[0]["Status"].ToString();
                    lblStatusName.Text = ds.Tables[0].Rows[0]["StatusName"].ToString();
                    txtProductGoldWeight.EditValue = ds.Tables[0].Rows[0]["SellGoldWeight"];
                    txtOldGoldWeight.EditValue = ds.Tables[0].Rows[0]["BuyGoldWeight"];
                    txtTotalGoldWeight.EditValue = ds.Tables[0].Rows[0]["TotalGoldWeight"];
                    txtSellRate.EditValue = ds.Tables[0].Rows[0]["SellRate"];
                    txtTotalAmount.EditValue = ds.Tables[0].Rows[0]["TotalAmount"];
                    txtTotalTaskPrice.EditValue = ds.Tables[0].Rows[0]["TotalTaskPrice"];
                    txtChangeAmount.EditValue = ds.Tables[0].Rows[0]["ChangeAmount"];
                    txtTotalAllAmount.EditValue = ds.Tables[0].Rows[0]["TotalAllAmount"];
                    txtTienVangThem.EditValue = ds.Tables[0].Rows[0]["AddMoney"];
                    //txtMS4.EditValue = ds.Tables[0].Rows[0]["TaskPriceAdd"];
                    txtDiscount.EditValue = ds.Tables[0].Rows[0]["Discount"];
                    txtPayAmount.EditValue = ds.Tables[0].Rows[0]["PayAmount"];
                    fn_EnableControl(ds.Tables[0].Rows[0]["Status"].ToString());
                    decimal dPayAmount = decimal.Parse(txtPayAmount.EditValue.ToString());
                    lblPayAmountByNumber.Text = dPayAmount > 0 ? "Phải thu: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture) : "Phải chi: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture);
                    SetLabelColor(dPayAmount);
                    lblPayAmountByWord.Text = dPayAmount > 0 ? "THU " + Gam.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG" : "CHI " + Gam.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";

                    //grvProduct
                    dtProduct = ds.Tables[1];
                    grdProduct.DataSource = ds.Tables[1];

                    //grvOldGold
                    fn_LoadDataToComboOld();
                    dtOldGold = ds.Tables[2];
                    grdOldGold.DataSource = ds.Tables[2];
                    lbGoldWeightToChar.Text = " ";
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
        private void SetLabelColor(decimal value)
        {
            if (value > 0)
                lblPayAmountByNumber.AppearanceItemCaption.ForeColor = Color.Red;
            else
                lblPayAmountByNumber.AppearanceItemCaption.ForeColor = Color.Blue;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues;

            string strDay = DateTime.Now.Day.ToString();
            string strMonth = DateTime.Now.Month.ToString();
            string strYear = DateTime.Now.Year.ToString();
            string TotalGoldWeightChar = string.Empty;
            //strParams = "Day@Month@Year@SplitBill@ToTalGoldWeightChar";
            strParams = "Day@Month@Year@SplitBill@Unit@DocTienThanhChu";
            ds = clsCommon.ExecuteDatasetSP("rptCRT_PrintBill", strID);
            //TotalGoldWeightChar = ds.Tables[5].Rows[0]["GoldWeightChar"].ToString();
            strValues = strDay + "@" + strMonth + "@" + strYear + "@" + clsNumericFormat.fn_Split(ds.Tables[0].Rows[0]["BillCode"].ToString()) + "@" + clsSystem.UnitWeight+"@"+lblPayAmountByWord.Text;// +"@" + TotalGoldWeightChar;
            Functions.fn_ShowReport_CloseAfterPrint(ds, "rptCRT_PrintBill.rpt", strParams, strValues, true);
            //Functions.fn_ShowReport(ds, "rptCRT_PrintBill.rpt", strParams, strValues);
            fn_LoadDefault();
        }

        private void frmRTChange_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            this.SL.Visible = clsSystem.IsNoStamp;
            fn_createProductDataTable();

            grdProduct.DataSource = dtProduct;
            grdOldGold.DataSource = dtOldGold;

            if (!clsSystem.IsPayCard)
                btnPayCard.Dispose();
            fn_LoadDataToCombo();
            fn_LoadDefault();
        }

        private void fn_createProductDataTable()
        {
            this.dtProduct.Columns.Add("ProductID", typeof(string));
            this.dtProduct.Columns.Add("ProductCode", typeof(string));
            this.dtProduct.Columns.Add("ProductDesc", typeof(string));
            this.dtProduct.Columns.Add("GoldCode", typeof(string));
            this.dtProduct.Columns.Add("SectionName", typeof(string));
            this.dtProduct.Columns.Add("TaskPrice", typeof(decimal));
            this.dtProduct.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtProduct.Columns.Add("TotalWeight", typeof(decimal));
            this.dtProduct.Columns.Add("GoldWeight", typeof(decimal));
            this.dtProduct.Columns.Add("SL", typeof(decimal));
            this.dtProduct.Columns.Add("A", typeof(decimal));
            this.dtProduct.Columns.Add("CatNi", typeof(decimal));


            this.dtProduct.Columns.Add("RingSize", typeof(decimal));

            this.dtOldGold.Columns.Add("GoldCode", typeof(string));
            this.dtOldGold.Columns.Add("GoldWeight", typeof(decimal));
            this.dtOldGold.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtOldGold.Columns.Add("ChangeRate", typeof(decimal));
            this.dtOldGold.Columns.Add("TotalGoldWeight", typeof(decimal));
        }

        private void grvProduct_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                //this.
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductID", txtProductID.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductCode", txtProductCode.Text.ToUpper());
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductDesc", txtProductDesc.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "GoldCode", txtGoldCode.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "SectionName", txtSectionName.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "GoldWeight", txtGoldWeight.Text == "" ? decimal.Parse(null) : decimal.Parse(txtGoldWeight.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "DiamondWeight", txtDiamondWeight.Text == "" ? decimal.Parse(null) : decimal.Parse(txtDiamondWeight.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "TaskPrice", txtTaskPrice.Text == "" ? decimal.Parse(null) : decimal.Parse(txtTaskPrice.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "RingSize", txtRingSize.Text == "" ? decimal.Parse(null) : decimal.Parse(txtRingSize.Text));
                this.grvProduct.SetRowCellValue(e.RowHandle, "A", txtA.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "SL", 1);
                this.grvProduct.SetRowCellValue(e.RowHandle, "CatNi", 0);
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm grvProduct_InitNewRow " + ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            //string strProductCode = "";
            //strProductCode = txtProductCode.EditValue.ToString().Trim().ToUpper();

            //if (strProductCode == string.Empty) return;

            ////Bắt buộc chọn loại vàng trước khi add hàng vào danh sách
            //if (cboGoldCode.SelectedIndex == 0)
            //{
            //    ThongBao.Show("Lỗi", "Vui lòng chọn Loại vàng trước khi nhập hàng.", "OK", ICon.Error);
            //    txtProductCode.EditValue = string.Empty;
            //    txtProductCode.Refresh();
            //    cboGoldCode.Focus();
            //    return;
            //}

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
            //                    //Nếu loại vàng không giống nhau
            //                    if (ds.Tables[0].Rows[0]["GoldCode"].ToString() != ((ItemList)cboGoldCode.SelectedItem).ID)
            //                    {
            //                        ThongBao.Show("Thông tin", "Chỉ được nhập hàng có loại vàng [" + cboGoldCode.Text + "].", "OK", ICon.Error);

            //                        //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
            //                        txtProductCode.EditValue = string.Empty;
            //                        txtProductCode.Refresh();
            //                        txtProductCode.Focus();
            //                    }
            //                    else if (ds.Tables[0].Rows[0]["Status"].ToString() == "O")
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
            //                        txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();
            //                        txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
            //                        txtGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
            //                        txtDiamondWeight.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
            //                        txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
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

        private void fn_clearChooseProduct()
        {
            txtProductID.Text = "";
            txtProductCode.EditValue = "";
            txtProductDesc.Text = "";
            txtGoldCode.Text = "";
            txtTaskPrice.Text = "";
            txtTotalWeight.Text = "";
            txtDiamondWeight.Text = "";
            txtGoldWeight.Text = "";
            txtSectionName.Text = "";
            txtRingSize.Text = "";
            txtA.Text = "";
            
        }

        private void grvProduct_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }

        private decimal fn_CalcChangeAmount()
        {
            
            decimal dResult = 0, dTMP = 0;
            decimal dProductGoldWeight = 0, dOldGoldWeight = 0;
            decimal dChangeRate = 0;
            bool flag = true;

            //dProductGoldWeight = decimal.Parse(grvProduct.Columns["GoldWeight"].SummaryText);
            // dOldGoldWeight = decimal.Parse(grvOldGold.Columns["GoldWeight"].SummaryText);
            //Tinh tong vang hang va tien cong
            dProductGoldWeight = decimal.Parse(txtProductGoldWeight.EditValue.ToString());

            //Tinh tong vang cu
            dOldGoldWeight = decimal.Parse(txtOldGoldWeight.EditValue.ToString());

            if (dProductGoldWeight >= dOldGoldWeight) // vang moi > vang cu
            {
                for (int j = 0; j < grvOldGold.RowCount; j++)
                {
                    dTMP += decimal.Parse((grvOldGold.GetRowCellValue(j, "GoldWeight").ToString() == "" ? "0" : grvOldGold.GetRowCellValue(j, "GoldWeight").ToString())) * decimal.Parse((grvOldGold.GetRowCellValue(j, "ChangeRate").ToString() == "" ? "0" : grvOldGold.GetRowCellValue(j, "ChangeRate").ToString())) * 1000 /clsSystem.HSGia;
                }
                dResult = dTMP;
            }
            else
            {
                if (grvOldGold.RowCount > 1)
                {
                    for (int i = 0; i < grvOldGold.RowCount - 1; i++)
                    {
                        for (int j = i + 1; j < grvOldGold.RowCount; j++)
                        {
                            if ((grvOldGold.GetRowCellValue(j, "ChangeRate").ToString() == "" ? "0" : grvOldGold.GetRowCellValue(j, "ChangeRate").ToString()) != (grvOldGold.GetRowCellValue(i, "ChangeRate").ToString() == "" ? "0" : grvOldGold.GetRowCellValue(i, "ChangeRate").ToString()))
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag) //cung 1 gia bu
                    {
                        dChangeRate = grvOldGold.RowCount > 0 ? dChangeRate = decimal.Parse((grvOldGold.GetRowCellValue(0, "ChangeRate").ToString() == "" ? "0" : grvOldGold.GetRowCellValue(0, "ChangeRate").ToString())) : 0;
                        dResult = Math.Min(dProductGoldWeight, dOldGoldWeight) * dChangeRate * 1000 / clsSystem.HSGia;
                    }
                    else //Ko cung 1 gia 
                    {
                        for (int j = 0; j < grvOldGold.RowCount; j++)
                        {
                            dTMP += decimal.Parse((grvOldGold.GetRowCellValue(j, "GoldWeight").ToString() == "" ? "0" : grvOldGold.GetRowCellValue(j, "GoldWeight").ToString())) * decimal.Parse((grvOldGold.GetRowCellValue(j, "ChangeRate").ToString() == "" ? "0" : grvOldGold.GetRowCellValue(j, "ChangeRate").ToString())) * 1000 / clsSystem.HSGia;
                        }
                        dResult = dTMP;
                    }
                }
                else
                {
                    dChangeRate = grvOldGold.RowCount > 0 ? dChangeRate = decimal.Parse((grvOldGold.GetRowCellValue(0, "ChangeRate").ToString() == "" ? "0" : grvOldGold.GetRowCellValue(0, "ChangeRate").ToString())) : 0;
                    dResult = dProductGoldWeight * dChangeRate * 1000 / clsSystem.HSGia;
                }
            }

            return dResult;
        }

        private void fn_CalcBillTotal()
        {
            if (clsCommon.ExecuteDatasetSP("I_GOLD_GET", ((ItemList)cboGoldCode.SelectedItem).ID).Tables[0].Rows[0]["PriceUnit"].ToString() != "L")
                clsSystem.HSGia = 1;
            decimal dTotalGoldWeight = 0, dProductGoldWeight = 0, dOldGoldWeight = 0;
            decimal dTotalAmount = 0, dTotalAllAmount = 0;
            decimal dChangeAmount = 0, dChangeRate = 0;
            decimal dTaskPrice = 0, dDiscount = 0, dPayAmount = 0;
            decimal dXRate = 0;
            decimal dTaskPriceAdd = 0;
            decimal dCatNi=0;
            decimal dMS4=0;
            try
            {
                //Tinh tong vang hang va tien cong
                for (int i = 0; i < grvProduct.RowCount; i++)
                {

                    dProductGoldWeight += decimal.Parse((grvProduct.GetRowCellValue(i, "GoldWeight").ToString() == "" ? "0" : grvProduct.GetRowCellValue(i, "GoldWeight").ToString())) * decimal.Parse((grvProduct.GetRowCellValue(i, "SL").ToString() == "" ? "0" : grvProduct.GetRowCellValue(i, "SL").ToString()));
                    dTaskPrice += decimal.Parse((grvProduct.GetRowCellValue(i, "TaskPrice").ToString() == "" ? "0" : grvProduct.GetRowCellValue(i, "TaskPrice").ToString())) * 1000 * decimal.Parse((grvProduct.GetRowCellValue(i, "SL").ToString() == "" ? "0" : grvProduct.GetRowCellValue(i, "SL").ToString()));
                    dCatNi += decimal.Parse((grvProduct.GetRowCellValue(i, "CatNi").ToString() == "" ? "0" : grvProduct.GetRowCellValue(i, "CatNi").ToString()));
                }
                txtProductGoldWeight.EditValue = dProductGoldWeight+dCatNi;

                //Tinh tong vang cu
                for (int j = 0; j < grvOldGold.RowCount; j++)
                {
                    dOldGoldWeight += decimal.Parse((grvOldGold.GetRowCellValue(j, "GoldWeight").ToString() == "" ? "0" : grvOldGold.GetRowCellValue(j, "GoldWeight").ToString()));
                }
                dTotalGoldWeight = dProductGoldWeight + dCatNi - dOldGoldWeight;
                txtOldGoldWeight.EditValue = dOldGoldWeight;

                txtTotalGoldWeight.EditValue = dTotalGoldWeight;
                txtTotalTaskPrice.EditValue = dTaskPrice;

                //Ty gia
                txtSellRate.EditValue = fn_CalSellRate();
                dXRate = decimal.Parse(txtSellRate.EditValue.ToString());

                //tinh tien bu
                dChangeAmount = fn_CalcChangeAmount();
                dChangeAmount = Functions.fn_VNDRounding(dChangeAmount);
                txtChangeAmount.EditValue = dChangeAmount;

                dTotalAmount = dTotalGoldWeight * dXRate * 1000 / clsSystem.HSGia;
                dTotalAmount = Functions.fn_VNDRounding(dTotalAmount);
                txtTotalAmount.EditValue = dTotalAmount;

                //Tong thanh tien
                dTotalAllAmount = dTotalAmount + dChangeAmount + dTaskPrice;
                txtTotalAllAmount.EditValue = dTotalAllAmount;

                //Thanh toan
                dDiscount = decimal.Parse(txtDiscount.EditValue.ToString());
                dTaskPriceAdd = decimal.Parse(txtTienVangThem.EditValue.ToString());
                //dMS4 = decimal.Parse(txtMS4.EditValue.ToString());
                dPayAmount = dTotalAllAmount - dDiscount+dTaskPriceAdd+dMS4;
                txtPayAmount.EditValue = dPayAmount;

                lblPayAmountByNumber.Text = dPayAmount > 0 ? "Phải thu: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture) : "Phải chi: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture);
                SetLabelColor(dPayAmount);
                lblPayAmountByWord.Text = dPayAmount > 0 ? "THU " + Gam.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG" : "CHI " + Gam.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";
                btnPayment.Enabled = true;
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

        private void fn_CalcBillSubTotal()
        {
            decimal dTotalGoldWeight = 0;
            decimal dTotalAmount = 0, dTotalAllAmount = 0;
            decimal dChangeAmount = 0;
            decimal dTaskPrice = 0, dDiscount = 0, dPayAmount = 0;
            decimal dXRate = 0;
            decimal dTaskPriceAdd = 0;
            decimal dMS4 = 0;
            try
            {
                dXRate = decimal.Parse(txtSellRate.EditValue.ToString());
                dTaskPrice = decimal.Parse(txtTotalTaskPrice.EditValue.ToString());
                dTotalGoldWeight = decimal.Parse(txtTotalGoldWeight.EditValue.ToString());
                dChangeAmount = decimal.Parse(txtChangeAmount.EditValue.ToString());
                dDiscount = decimal.Parse(txtDiscount.EditValue.ToString());
                dTaskPriceAdd = decimal.Parse(txtTienVangThem.EditValue.ToString());
                //dMS4 = decimal.Parse(txtMS4.EditValue.ToString());
                dTotalAmount = dTotalGoldWeight * dXRate * 1000 / clsSystem.HSGia;
                dTotalAmount = Functions.fn_VNDRounding(dTotalAmount);
                txtTotalAmount.EditValue = dTotalAmount;

                //Tong thanh tien
                dTotalAllAmount = Functions.fn_VNDRounding(dTotalAmount + dChangeAmount + dTaskPrice);
                txtTotalAllAmount.EditValue = dTotalAllAmount;

                //Thanh toan
                dPayAmount = dTotalAllAmount - dDiscount+dTaskPriceAdd+dMS4;
                txtPayAmount.EditValue = dPayAmount;

                lblPayAmountByNumber.Text = dPayAmount > 0 ? "Phải thu: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture) : "Phải chi: " + Math.Abs(dPayAmount).ToString("#,#", CultureInfo.InstalledUICulture);
                SetLabelColor(dPayAmount);
                lblPayAmountByWord.Text = dPayAmount > 0 ? "THU " + Gam.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG" : "CHI " + Gam.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";
            }
            catch (Exception ex)
            {
                //ThongBao.Show("Lỗi", "Hàm fn_CalcBillSubTotal: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {

            }
        }

        private decimal fn_CalSellRate()
        {
            try
            {
                string strGoldCode = ((ItemList)cboGoldCode.SelectedItem).ID;
                string expression = "GoldCcy = '" + strGoldCode + "'";
                DataRow[] arrRow = clsSystem.XRate.Tables[0].Select(expression);
                decimal dResult = 0, dTotalGoldWeight = 0;

                int iMaxIndex = 0;
                decimal dMaxGoldWeight = 0;
                DataRow row;

                if (txtTotalGoldWeight.EditValue != null)
                {
                    dTotalGoldWeight = decimal.Parse(txtTotalGoldWeight.EditValue.ToString());
                }

                if (dTotalGoldWeight >= 0) //Neu tong vang = ban - mua > 0
                {
                    if (arrRow.Length > 0)
                    {
                        arrXRate = arrRow[0];
                        dResult = decimal.Parse(arrRow[0]["SellRate"].ToString());
                    }
                    else
                    {
                        arrXRate = null;
                        dResult = 0;
                    }
                }
                else
                {
                    if (grvOldGold.RowCount >= 2)
                    {
                        //arrXRate = arrRow[0];
                        //dResult = 0;

                        //Tim TL lon nhat de lay ty gia mua
                        row = grvOldGold.GetDataRow(0);
                        iMaxIndex = 0;
                        dMaxGoldWeight = decimal.Parse((row["GoldWeight"].ToString() == "" ? "0" : row["GoldWeight"].ToString()));

                        for (int j = 1; j < grvOldGold.RowCount; j++)
                        {
                            row = grvOldGold.GetDataRow(j);

                            if (dMaxGoldWeight < decimal.Parse((row["GoldWeight"].ToString() == "" ? "0" : row["GoldWeight"].ToString())))
                            {
                                iMaxIndex = j;
                                dMaxGoldWeight = decimal.Parse((row["GoldWeight"].ToString() == "" ? "0" : row["GoldWeight"].ToString()));
                            }
                        }

                        expression = "GoldCcy = '" + grvOldGold.GetRowCellValue(iMaxIndex, "GoldCode").ToString() + "'";
                        arrRow = clsSystem.XRate.Tables[0].Select(expression);

                        if (arrRow.Length > 0)
                        {
                            arrXRate = arrRow[0];
                            dResult = decimal.Parse(arrRow[0]["BuyRate"].ToString());
                        }
                        else
                        {
                            arrXRate = null;
                            dResult = 0;
                        }
                    }
                    else
                    {
                        expression = "GoldCcy = '" + grvOldGold.GetRowCellValue(0, "GoldCode").ToString() + "'";
                        arrRow = clsSystem.XRate.Tables[0].Select(expression);

                        if (arrRow.Length > 0)
                        {
                            arrXRate = arrRow[0];
                            dResult = decimal.Parse(arrRow[0]["BuyRate"].ToString());
                        }
                        else
                        {
                            arrXRate = null;
                            dResult = 0;
                        }
                    }
                }

                return dResult;

            }
            catch
            { return 0; }





            /**************** Cach tinh cu *********************/
            /*
            string strGoldCode = ((ItemList)cboGoldCode.SelectedItem).ID;
            string expression = "GoldCcy = '" + strGoldCode + "'";
            DataRow[] arrRow = clsSystem.XRate.Tables[0].Select(expression);
            decimal dResult = 0, dTotalGoldWeight = 0;

            if (txtTotalGoldWeight.EditValue != null)
            {
                dTotalGoldWeight = decimal.Parse(txtTotalGoldWeight.EditValue.ToString());
            }

            if (dTotalGoldWeight >= 0) //Neu tong vang = ban - mua > 0
            {
                if (arrRow.Length > 0)
                {
                    arrXRate = arrRow[0];
                    dResult = decimal.Parse(arrRow[0]["SellRate"].ToString());
                }
                else
                {
                    arrXRate = null;
                    dResult = 0;
                }
            }
            else
            {
                expression = "GoldCcy = '" + grvOldGold.GetRowCellValue(0, "GoldCode").ToString() + "'";
                arrRow = clsSystem.XRate.Tables[0].Select(expression);

                if (grvOldGold.RowCount >= 2)
                {
                    arrXRate = arrRow[0];
                    dResult = 0;
                }
                else
                {
                    if (arrRow.Length > 0)
                    {
                        arrXRate = arrRow[0];
                        dResult = decimal.Parse(arrRow[0]["BuyRate"].ToString());
                    }
                    else
                    {
                        arrXRate = null;
                        dResult = 0;
                    }
                }
            }

            return dResult;
             
             */
        }

        private void cboGoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSellRate.EditValue = fn_CalSellRate();
        }

        private void grvProduct_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            fn_CalcBillTotal();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvOldGold_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

            fn_CalcBillTotal();
        }

        private void grvOldGold_RowCountChanged(object sender, EventArgs e)
        {
            //if (grvOldGold.RowCount != 0)
            //{
            //    cboGoldCode.Enabled = false;
            //}
        }

        private void grvProduct_RowCountChanged(object sender, EventArgs e)
        {
            if (grvProduct.RowCount != 0)
            {
                cboGoldCode.Enabled = false;
            }
            else
            {
                cboGoldCode.Enabled = true;
            }

        }

        private void grvOldGold_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                // this.grvOldGold.SetRowCellValue(e.RowHandle, "GoldWeight", 0);
                this.grvOldGold.SetRowCellValue(e.RowHandle, "DiamondWeight", 0);
                //this.grvOldGold.SetRowCellValue(e.RowHandle, "ChangeRate", 0);
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm grvOldGold_InitNewRow " + ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
        }

        private void grvOldGold_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (!fn_CheckValidate_OldGold(((DataRowView)e.Row).Row))
                e.Valid = false;


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
                if (decimal.Parse(row["TotalGoldWeight"].ToString()) < decimal.Parse(row["DiamondWeight"].ToString()))
                {
                    ThongBao.Show("Lỗi", "Trọng lượng vàng + hột không thể nhỏ hơn trọng lượng hột", "OK", ICon.Error);
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

        private bool fn_CheckValidate()
        {
            if (cboGoldCode.SelectedIndex == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn loại vàng.", "OK", ICon.Error);
                cboGoldCode.Focus();
                return false;
            }

            if (cboCust.SelectedIndex == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn khách hàng.", "OK", ICon.Error);
                cboCust.Focus();
                return false;
            }

            if (grvProduct.RowCount == 0)
            {
                //ThongBao.Show("Lỗi", "Vui lòng nhập ít nhất 1 món hàng.", "OK", ICon.Error);
                //txtProductCode.Focus();
                //return false;                
            }
            if (grvOldGold.RowCount == 0)
            {
                //ThongBao.Show("Lỗi", "Vui lòng nhập ít nhất 1 món vàng cũ.", "OK", ICon.Error);
                //grvOldGold.Focus();
                //return false;
            }

            return true;
        }

        private void btnSave_Click()
        {
            DataSet ds = new DataSet();
            DataRow row;
            string strProductIDs = "",strSL="", strTaskPrices = "";
            string strGoldCodes = "", strGoldWeights = "", strDiamondWeights = "", strChangeRates = "", strTotalGoldWeight = "";
            string strCatNi = "";
            if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (grvProduct.RowCount > 0)
                {
                    for (int i = 0; i < grvProduct.RowCount; i++)
                    {
                        row = grvProduct.GetDataRow(i);
                        strProductIDs += row["ProductID"].ToString() + "@";
                        strTaskPrices += row["TaskPrice"].ToString() + "@";
                        strSL += (row["SL"].ToString() == "" ? "1" : row["SL"].ToString()) + "@";
                        strCatNi += (row["CatNi"].ToString() == "" ? "1" : row["CatNi"].ToString()) + "@";
                    }
                    strProductIDs = strProductIDs.Substring(0, strProductIDs.Length - 1);
                    strTaskPrices = strTaskPrices.Substring(0, strTaskPrices.Length - 1);
                    strSL = strSL.Substring(0, strSL.Length - 1);
                    strCatNi = strCatNi.Substring(0, strCatNi.Length - 1);
                }
                else
                {
                    strProductIDs = "";
                    strTaskPrices = "";
                    strSL = "";
                    strCatNi = "";
                }

                if (grvOldGold.RowCount > 0)
                {
                    for (int i = 0; i < grvOldGold.RowCount; i++)
                    {
                        row = grvOldGold.GetDataRow(i);
                        strGoldCodes += row["GoldCode"].ToString() + "@";
                        strGoldWeights += (row["GoldWeight"].ToString() == "" ? "0" : row["GoldWeight"].ToString()) + "@";
                        strDiamondWeights += (row["DiamondWeight"].ToString() == "" ? "0" : row["DiamondWeight"].ToString()) + "@";
                        strChangeRates += (row["ChangeRate"].ToString() == "" ? "0" : row["ChangeRate"].ToString()) + "@";
                        strTotalGoldWeight += (row["TotalGoldWeight"].ToString() == "" ? "0" : row["TotalGoldWeight"].ToString()) + "@";
                    }
                    strGoldCodes = strGoldCodes.Substring(0, strGoldCodes.Length - 1);
                    strGoldWeights = strGoldWeights.Substring(0, strGoldWeights.Length - 1);
                    strDiamondWeights = strDiamondWeights.Substring(0, strDiamondWeights.Length - 1);
                    strChangeRates = strChangeRates.Substring(0, strChangeRates.Length - 1);
                    strTotalGoldWeight = strTotalGoldWeight.Substring(0, strTotalGoldWeight.Length - 1);
                }
                else
                {
                    strGoldCodes = "";
                    strGoldWeights = "";
                    strDiamondWeights = "";
                    strChangeRates = "";
                    strTotalGoldWeight = "";
                }

                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_RT_CHANGE_Ins]",
                            "", DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("hh:mm:ss"),
                            ((ItemList)cboCust.SelectedItem).ID,
                            ((ItemList)cboGoldCode.SelectedItem).ID,
                            txtProductGoldWeight.EditValue.ToString(),
                            txtOldGoldWeight.EditValue.ToString(),
                            txtTotalGoldWeight.EditValue.ToString(),
                            txtSellRate.EditValue.ToString(),
                            txtTotalAmount.EditValue.ToString(),
                            txtTotalTaskPrice.EditValue.ToString(),
                            txtChangeAmount.EditValue.ToString(),
                            txtTotalAllAmount.EditValue.ToString(),
                            txtDiscount.EditValue.ToString(),
                            "0", txtTienVangThem.EditValue.ToString(),
                            txtPayAmount.EditValue.ToString(),
                            strProductIDs,
                            strTaskPrices,strSL,
                            strGoldCodes, strGoldWeights, strDiamondWeights, strChangeRates, strTotalGoldWeight,
                            "W", clsSystem.UserID,((ItemList)cboEmp.SelectedItem).ID,strCatNi);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_RT_CHANGE_Upd]",
                            strID, DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("hh:mm:ss"),
                            ((ItemList)cboCust.SelectedItem).ID,
                            ((ItemList)cboGoldCode.SelectedItem).ID,
                            txtProductGoldWeight.EditValue.ToString(),
                            txtOldGoldWeight.EditValue.ToString(),
                            txtTotalGoldWeight.EditValue.ToString(),
                            txtSellRate.EditValue.ToString(),
                            txtTotalAmount.EditValue.ToString(),
                            txtTotalTaskPrice.EditValue.ToString(),
                            txtChangeAmount.EditValue.ToString(),
                            txtTotalAllAmount.EditValue.ToString(),
                            txtDiscount.EditValue.ToString(),
                            "0", txtTienVangThem.EditValue.ToString(),
                            txtPayAmount.EditValue.ToString(),
                            strProductIDs,
                            strTaskPrices,strSL,
                            strGoldCodes, strGoldWeights, strDiamondWeights, strChangeRates, strTotalGoldWeight,
                            "W", clsSystem.UserID, ((ItemList)cboEmp.SelectedItem).ID,strCatNi);
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
                //btnComplete.Focus();
            }
        }

        private bool btnComplete_Click()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_RT_CHANGE_Complete]", strID, clsSystem.UserID);

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
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                btnPayment.Enabled = true;
                return false;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                btnPayment.Focus();
            }

        }


        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                string strProductCode = "";
                if (txtProductCode.EditValue == null || txtProductCode.EditValue.ToString() == "")
                    return;
                strProductCode = txtProductCode.EditValue.ToString().Trim().ToUpper();

                if (strProductCode == string.Empty) return;


                //Kiểm tra mã hàng mới nhập có trùng với các hàng trên danh sach không?
                bool IsDup = false;
                for (int i = 0; i < grvProduct.RowCount; i++)
                {
                    if (grvProduct.GetRowCellValue(i, "ProductCode").ToString() == strProductCode)
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
                                    if (((ItemList)cboGoldCode.SelectedItem).ID == "")
                                    {
                                        cboGoldCode.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldCode"].ToString(), cboGoldCode, 0);
                                    }
                                    if (cboGoldCode.SelectedIndex == 0)
                                    {
                                        ThongBao.Show("Thông tin", "Mã hàng không hợp lệ.", "OK", ICon.Error);

                                        //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
                                        txtProductCode.EditValue = string.Empty;
                                        txtProductCode.Refresh();
                                        txtProductCode.Focus();
                                    }
                                    else

                                        //Nếu loại vàng không giống nhau
                                        if (ds.Tables[0].Rows[0]["GoldCode"].ToString() != ((ItemList)cboGoldCode.SelectedItem).ID)
                                        {
                                            ThongBao.Show("Thông tin", "Chỉ được nhập hàng có loại vàng [" + cboGoldCode.Text + "].", "OK", ICon.Error);

                                            //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
                                            txtProductCode.EditValue = string.Empty;
                                            txtProductCode.Refresh();
                                            txtProductCode.Focus();
                                        }
                                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "O")
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
                                            txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();
                                            txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
                                            txtGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
                                            txtDiamondWeight.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
                                            txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                                            txtRingSize.Text = ds.Tables[0].Rows[0]["RingSize"].ToString();
                                            txtA.Text = ds.Tables[0].Rows[0]["A"].ToString();
                                            grvProduct.AddNewRow();
                                            grvProduct.UpdateCurrentRow();
                                            this.grvOldGold.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                                            fn_LoadDataToComboOld();
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

        private void btnPayment_Click(object sender, EventArgs e)
        {
            //if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn thanh toán giao dịch này?", "Có", "Không", ICon.QuestionMark) != DialogResult.OK)
            //   return;
            if (clsSystem.TillID == "")
            {
                ThongBao.Show("Lỗi", "Không thể thanh toán vì chưa mở quầy thu ngân.", "OK", ICon.Error);
                return;
            }
            btnPayment.Enabled = false;
            btnPayCard.Enabled = false;
            try
            {
                btnSave_Click();
                if (grvOldGold.RowCount == 0)
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập ít nhất 1 món vàng cũ.", "OK", ICon.Error);
                    grvOldGold.Focus();
                    return;
                }
                if (!btnComplete_Click())
                    return;
                btnPayment.Enabled = false;
                btnPayCard.Enabled = false;
                frmTillProccessTxn frm = new frmTillProccessTxn(strID);
                if (frm.strErrorCode == "0")
                {
                    btnPayment.Enabled = false;
                    btnPayCard.Enabled = false;
                    txtIsPaid.Text = "Y";
                    btnPrint.Focus();
                }
            }
            catch { }
            finally { }
            /* 
            DataSet ds = new DataSet();
            string strParams, strValues;

            string strDay = DateTime.Now.Day.ToString();
            string strMonth = DateTime.Now.Month.ToString();
            string strYear = DateTime.Now.Year.ToString();
     
            strParams = "Day@Month@Year@SplitBill";

            ds = clsCommon.ExecuteDatasetSP("rptCRT_PrintBill", strID);
            strValues = strDay + "@" + strMonth + "@" + strYear + "@" + clsNumericFormat.fn_Split(ds.Tables[0].Rows[0]["BillCode"].ToString());
 
            Functions.fn_ShowReport_CloseAfterPrint(ds, "rptCRT_PrintBill.rpt", strParams, strValues, false);
             */
            //fn_LoadDefault();

        }

        private void fn_EnableControl(string pStatus)
        {
            if (pStatus == "")
            {
                btnDel.Enabled = true;
                //btnSave.Enabled = true;
                //btnComplete.Enabled = false;
                btnPayment.Enabled = false;
                btnPayCard.Enabled = false;
                btnPrint.Enabled = false;
                btnInPhieu.Enabled = false;

                grvOldGold.OptionsBehavior.Editable = true;
                grvProduct.OptionsBehavior.Editable = true;
                cboGoldCode.Properties.ReadOnly = false;
                cboCust.Properties.ReadOnly = false;
                cboEmp.Enabled = true;
                txtChangeAmount.Properties.ReadOnly = true;
                txtDiscount.Properties.ReadOnly = false;
                txtTienVangThem.Properties.ReadOnly = false;
                //txtMS4.Properties.ReadOnly = false;
                txtSellRate.Properties.ReadOnly = false;
                txtProductCode.Properties.ReadOnly = false;
               // txtTaskPriceAdd.Properties.ReadOnly = false;
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

                grvOldGold.OptionsBehavior.Editable = true;
                grvProduct.OptionsBehavior.Editable = true;
                cboCust.Properties.ReadOnly = false;
                cboEmp.Enabled = true;
                txtDiscount.Properties.ReadOnly = false;
                txtChangeAmount.Properties.ReadOnly = true;
                txtDiscount.Properties.ReadOnly = false;
                txtSellRate.Properties.ReadOnly = false;
                txtProductCode.Properties.ReadOnly = false;
                txtTienVangThem.Properties.ReadOnly = false;
                //txtMS4.Properties.ReadOnly = false;

                //txtTaskPriceAdd.Properties.ReadOnly = false;
            }

            if (pStatus == "C")
            {
                btnDel.Enabled = false;
                //btnSave.Enabled = false;
                //btnComplete.Enabled = false;
                btnPayment.Enabled = false;// txtIsPaid.Text == "Y" ? false : true;
                btnPayCard.Enabled = false;
                btnPrint.Enabled = true;
                btnInPhieu.Enabled = true;
                cboEmp.Enabled = false;
                grvOldGold.OptionsBehavior.Editable = false;
                grvProduct.OptionsBehavior.Editable = false;
                cboCust.Properties.ReadOnly = true;
                txtDiscount.Properties.ReadOnly = true;
                txtChangeAmount.Properties.ReadOnly = true;
                txtDiscount.Properties.ReadOnly = true;
                txtSellRate.Properties.ReadOnly = true;
                txtProductCode.Properties.ReadOnly = true;
                txtTienVangThem.Properties.ReadOnly = true;
               // txtMS4.Properties.ReadOnly = true;
               // txtTaskPriceAdd.Properties.ReadOnly = true;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            fn_LoadDefault();
        }

        private void txtSellRate_Leave(object sender, EventArgs e)
        {
            decimal dXRate = decimal.Parse(txtSellRate.EditValue.ToString());
            decimal dTotalGoldWeight = decimal.Parse(txtTotalGoldWeight.EditValue.ToString());

            if (dTotalGoldWeight >= 0) //ban vang, lay ti gia ban
            {
                if (arrXRate != null)
                {
                    //if (dXRate > decimal.Parse(arrXRate["MaxSellRate"].ToString()) || dXRate < decimal.Parse(arrXRate["MinSellRate"].ToString()))
                    //{
                    //    ThongBao.Show("Lỗi", "Giá bán không được vượt quá biên độ cho phép.", "OK", ICon.Error);
                    //    txtSellRate.Focus();
                    //    return;
                    //}
                }
            }
            else
            {
                if (arrXRate != null)
                {
                    //if (dXRate > decimal.Parse(arrXRate["MaxBuyRate"].ToString()) || dXRate < decimal.Parse(arrXRate["MinBuyRate"].ToString()))
                    //{
                    //    ThongBao.Show("Lỗi", "Giá mua không được vượt quá biên độ cho phép.", "OK", ICon.Error);
                    //    txtSellRate.Focus();
                    //    return;
                    //}
                }
            }

            fn_CalcBillSubTotal();
        }

        private void txtChangeAmount_Leave(object sender, EventArgs e)
        {
            //     fn_CalcBillSubTotal();
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            fn_CalcBillSubTotal();
        }

        private void grvProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvProduct.OptionsBehavior.Editable == true)
            {
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

        private void btnList_Click(object sender, EventArgs e)
        {
            frmRTChange_Lst frm = new frmRTChange_Lst(this);
            frm.ShowDialog();
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("TRN_RT_CHANGE_Del", strID);

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

        private void grvOldGold_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues;

            string strDay = DateTime.Now.Day.ToString();
            string strMonth = DateTime.Now.Month.ToString();
            string strYear = DateTime.Now.Year.ToString();
            ds = clsCommon.ExecuteDatasetSP("rptCRT_PrintBill", strID);
            strParams = "Day@Month@Year@SplitBill@Unit";
            strValues = strDay + "@" + strMonth + "@" + strYear + "@" + clsNumericFormat.fn_Split(ds.Tables[0].Rows[0]["BillCode"].ToString()) + "@" + clsSystem.UnitWeight;


            //Functions.fn_ShowReport_CloseAfterPrint(ds, "rptCRT_PrintBill.rpt", strParams, strValues,false);
            if (clsSystem.UnitWeight == "Ly" || clsSystem.UnitWeight == "P")
                Functions.fn_ShowReport(ds, "rptCRT_PrintBill.rpt", strParams, strValues);
            else if (clsSystem.UnitWeight == "C")
                Functions.fn_ShowReport(ds, "rptCRT_PrintBill_C.rpt", strParams, strValues);
            else Functions.fn_ShowReport(ds, "rptCRT_PrintBill_L.rpt", strParams, strValues);
            fn_LoadDefault();
        }

        private void txtTotalAmount_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gtxtDiamondWeight_EditValueChanging(object sender, ChangingEventArgs e)
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

        private void gtxtTotalGoldWeight_EditValueChanging(object sender, ChangingEventArgs e)
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

        private void grvOldGold_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvOldGold.FocusedRowHandle <= -1)
                    lbGoldWeightToChar.Text = " ";
                else
                {
                    DataRow row = grvOldGold.GetDataRow(e.FocusedRowHandle);
                    decimal GoldWeight = decimal.Parse(row["GoldWeight"].ToString());
                    DataRow dr = Functions.fn_GetIGold(row["GoldCode"].ToString());
                    if (dr["PriceUnit"].ToString() == "L")
                    {
                        
                            GoldWeight = GoldWeight * clsSystem.HSTL;
                            lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper() == "" ? " " :
                              Gold.process(GoldWeight.ToString()).ToUpper();
                       
                    }

                    else if (dr["PriceUnit"].ToString() == "G")
                    {
                        int k;
                        if (clsSystem.UnitWeight == "Ly" || clsSystem.UnitWeight == "P"||clsSystem.UnitWeight=="Z")
                            k = 2;
                        else if (clsSystem.UnitWeight == "C")
                            k = 3;
                        else k = 4;
                        GoldWeight = Math.Round(GoldWeight, k);
                        lbGoldWeightToChar.Text = Gam.process(GoldWeight.ToString()).ToUpper() == "" ? " "
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
                        if (clsSystem.UnitWeight == "L")
                        {
                            GoldWeight = GoldWeight * 1000;
                            lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper() == "" ? " " :
                              Gold.process(GoldWeight.ToString()).ToUpper();
                        }
                        else if (clsSystem.UnitWeight == "C")
                        {
                            GoldWeight = GoldWeight * 100;
                            lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper() == "" ? " " :
                                        Gold.process(GoldWeight.ToString()).ToUpper();
                        }
                        else if (clsSystem.UnitWeight == "P")
                        {
                            GoldWeight = GoldWeight * 10;
                            lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper() == "" ? " " :
                              Gold.process(GoldWeight.ToString()).ToUpper();
                        }
                        else if (clsSystem.UnitWeight == "Ly")
                        {
                            lbGoldWeightToChar.Text = Gold.process(GoldWeight.ToString()).ToUpper() == "" ? " " :
                                 Gold.process(GoldWeight.ToString()).ToUpper();
                        }
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
                        lbGoldWeightToChar.Text = Gam.process(GoldWeight.ToString()).ToUpper() == "" ? " "
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

        private void grdProduct_Click(object sender, EventArgs e)
        {

        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDiscount_Leave(sender, e);
        }

        private void txtTotalGoldWeight_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            txtDiscount_Leave(sender, e);
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

        private void txtDiscount_EditValueChanging(object sender, ChangingEventArgs e)
        {
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

        }

        private void frmRTChange_KeyDown(object sender, KeyEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Doi hang.mht");
                Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Doi hang.mht");
            }
        }

        private void btnPayCard_Click(object sender, EventArgs e)
        {
            if (clsSystem.TillID == "")
            {
                ThongBao.Show("Lỗi", "Không thể thanh toán vì chưa mở quầy thu ngân.", "OK", ICon.Error);
                return;
            }

           
            frmTillProcessCard frm = new frmTillProcessCard(strID, strTillTxnID, "CRT");
            DialogResult dlg = frm.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                frmTillProccessTxn frm1 = new frmTillProccessTxn(strID);
                if (frm1.strErrorCode == "0")
                {
                    //if (clsSystem.IsSMS)
                    //{
                    //    decimal TongTien = 0;
                    //    decimal.TryParse(txtPayAmount.Text, out TongTien);
                    //    //if (TongTien > 10000000)
                    //    CommSetting.SendMessage("Giao dich: mua ban \n So tien: " + txtPayAmount.Text + ",Quay: " + clsSystem.TillName + " NV:" + clsSystem.UserName);
                    //}
                    btnPayment.Enabled = false;
                    btnPayCard.Enabled = false;
                    txtIsPaid.Text = "Y";
                    btnPrint.Focus();
                }
            }

        }

        private void frmRTChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsSystem.IsScan)
                FunctionTill.fn_CloseTill();
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
            fn_CalcBillTotal();
        }

        private void rtxtChangeAmount_MouseLeave(object sender, EventArgs e)
        {
         //   fn_CalcBillTotal();
        }

        private void txtTaskPriceAdd_EditValueChanged(object sender, EventArgs e)
        {
            txtTaskPriceAdd_Leave(sender,e);
        }

        private void txtTaskPriceAdd_Leave(object sender, EventArgs e)
        {
            fn_CalcBillSubTotal();
        }
    }
}