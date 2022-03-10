using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmRTBuySell_Dtl : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtProduct = new DataTable();
        private DataTable dtOldGold = new DataTable();

        public string strID = "";
        public string strTillTxnID = "";
        private string strProductCode = "";

        public frmRTBuySell_Dtl(string _ID)
        {
            InitializeComponent();
            this.strID = _ID;
        }

        public frmRTBuySell_Dtl(string _ID, string _StrProductCode)
        {
            InitializeComponent();
            this.strID = _ID;
            this.strProductCode = _StrProductCode;
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("I_GOLD", "D_RT");
            Functions.BindDropDownList(cboGoldCode_Old, ds, "GoldDesc", "GoldCode", false);
            ds.Clear();

            ds = clsCommon.LoadComboSP("I_CUSTOMER", "");
            Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "", true);
            ds.Clear();

            ds.Dispose();
        }

        private void fn_CalcBillSubTotal()
        {
            decimal dPayAmount = 0, dDiscount = 0, dTotalAmount = 0;

            try
            {
                dTotalAmount = decimal.Parse(txtTotalAmount.EditValue.ToString());
                dDiscount = decimal.Parse(txtDiscount.EditValue.ToString());
                dPayAmount = dTotalAmount - dDiscount;
                txtPayAmount.EditValue = dPayAmount;

                lblPayAmountByWord.Text = VND.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";
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

        private void frmRTBuySell_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToCombo();
            fn_LoadDataToForm(this.strID);
            for (int i = 0; i < grvProduct.RowCount; i++)
            {

                if (grvProduct.GetRowCellValue(i, "ProductCode").ToString().ToUpper() == strProductCode)
                {
                    //grvProduct.TopRowIndex = i;
                    grvProduct.FocusedRowHandle = i;
                    grvProduct.SelectRow(i);
                }

            }
        }

        private void fn_CalcBillTotal()
        {
            decimal dSellTotalAmount = 0, dBuyTotalAmount = 0;
            decimal dTotalAmount = 0;
            decimal dDiscount = 0, dPayAmount = 0;
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
                dPayAmount = dTotalAmount - dDiscount;
                txtPayAmount.EditValue = dPayAmount;

                lblPayAmountByWord.Text = Gam.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";
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

        public void fn_LoadDataToForm(string _TrnID)
        {
            if (_TrnID != "")
            {
                DataSet ds = new DataSet();

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    ds = clsCommon.ExecuteDatasetSP("TRN_RT_BUYSELL_Get", _TrnID);

                    strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                    strTillTxnID = ds.Tables[0].Rows[0]["TillTxnID"].ToString();

                    txtBillCode.EditValue = ds.Tables[0].Rows[0]["BillCode"].ToString();
                    cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["CustID"].ToString(), cboCust, 0);
                    dtpDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"].ToString();
                    txtStatus.EditValue = ds.Tables[0].Rows[0]["Status"].ToString();
                    lblStatusName.Text = ds.Tables[0].Rows[0]["StatusName"].ToString();

                    txtSellTotalAmount.EditValue = ds.Tables[0].Rows[0]["SellTotalAmount"];
                    txtBuyTotalAmount.EditValue = ds.Tables[0].Rows[0]["BuyTotalAmount"];
                    txtTotalAmount.EditValue = ds.Tables[0].Rows[0]["TotalAmount"];
                    txtDiscount.EditValue = ds.Tables[0].Rows[0]["Discount"];
                    txtPayAmount.EditValue = ds.Tables[0].Rows[0]["PayAmount"];

                    //grvProduct
                    dtProduct = ds.Tables[1];
                    grdProduct.DataSource = ds.Tables[1];

                    //grvOldGold
                    dtOldGold = ds.Tables[2];
                    grdOldGold.DataSource = ds.Tables[2];

                    btnDel.Enabled = btnPayment.Enabled =
                                     (ds.Tables[0].Rows[0]["Status"].ToString() == "W" &&
                                      clsSystem.GetCurrentAccountType() == AccountType.SuperAccount);
                }
                catch(Exception ex)
                {
                    ds.Dispose();                    
                    ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                    return;
                }
                finally
                {
                    ds.Dispose();
                }
            }        
        }

        private decimal fn_CalSellAmount(string _PriceUnit, string _PriceCcy, decimal _CcyRate, decimal _InPrice, decimal _GoldWeight, decimal _SellRate, decimal _TaskPrice)
        {
            decimal dResult = 0;

            if (_PriceUnit == "L") //vang chi
            {
                dResult = _TaskPrice * 1000 + _GoldWeight * _SellRate * 1000 / 100;
            }

            if (_PriceUnit == "G") //vang chi
            {
                dResult = _GoldWeight * _SellRate * _CcyRate;
            }

            if (_PriceUnit == "M") //vang chi
            {
                dResult = _SellRate * _CcyRate;
            }

            return dResult;
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            fn_CalcBillSubTotal();
        }

        private void txtProdSellRate_Leave(object sender, EventArgs e)
        {
            decimal dSellAmount = 0;
            string strPriceUnit = "", strPriceCcy = "";
            decimal dCcyRate = 0, dGoldWeight =0, dSellRate =0, dTaskPrice = 0;

            try
            {
                strPriceUnit = grvProduct.GetFocusedRowCellValue("PriceUnit").ToString();
                strPriceCcy = grvProduct.GetFocusedRowCellValue("PriceCcy").ToString();
                dCcyRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("CcyRate").ToString());
                dGoldWeight = decimal.Parse(grvProduct.GetFocusedRowCellValue("GoldWeight").ToString());
                dSellRate = decimal.Parse(grvProduct.GetFocusedRowCellValue("SellRate").ToString());
                dTaskPrice = decimal.Parse(grvProduct.GetFocusedRowCellValue("TaskPrice").ToString());

                dSellAmount = fn_CalSellAmount(strPriceUnit, strPriceCcy, dCcyRate, 0, dGoldWeight, dSellRate, dTaskPrice);
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], dSellAmount);

                fn_CalcBillTotal();
            }
            catch (Exception ex)
            {
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["SellAmount"], 0);
            }
        }

        private void cboGoldCode_Old_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    ds = clsCommon.ExecuteDatasetSP("TRN_RT_BUYSELL_Del", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Xoá thành công", "OK", ICon.Information);
                        this.Close();
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

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (clsSystem.TillID == "")
            {
                ThongBao.Show("Lỗi", "Không thể thanh toán vì chưa mở quầy thu ngân.", "OK", ICon.Error);
                return;
            }

            if (!btnComplete_Click())
                return;
            btnPayment.Enabled = btnDel.Enabled = false;
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
                btnPayment.Enabled = false;             
            }
        }

        private bool btnComplete_Click()
        {           
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
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                return false;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                btnPayment.Focus();
            }
        }

    }
}