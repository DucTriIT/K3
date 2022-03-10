using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmRTChange_Dtl : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtProduct = new DataTable();
        private DataTable dtOldGold = new DataTable();

        public string strID = "";
        public string strTillTxnID = "";
        private string strProductCode = "";

        DataRow arrXRate;

        public frmRTChange_Dtl(string _ID)
        {
            InitializeComponent();
            this.strID = _ID;
        }

        public frmRTChange_Dtl(string _ID, string _StrProductCode)
        {
            InitializeComponent();
            this.strID = _ID;
            this.strProductCode = _StrProductCode;
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("I_GOLD_PRICEUINT", "L");
            Functions.BindDropDownList(cboGoldCode, ds, "GoldDesc", "GoldCode", "", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("I_GOLD", "D_RT");
            Functions.BindDropDownList(cboGoldCode_Old, ds, "GoldDesc", "GoldCode", false);
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
                    txtDiscount.EditValue = ds.Tables[0].Rows[0]["Discount"];
                    txtPayAmount.EditValue = ds.Tables[0].Rows[0]["PayAmount"];

                    btnDel.Enabled = btnPayment.Enabled =
                                     (ds.Tables[0].Rows[0]["Status"].ToString() == "W" &&
                                      clsSystem.GetCurrentAccountType() == AccountType.SuperAccount);

                    //grvProduct
                    dtProduct = ds.Tables[1];
                    grdProduct.DataSource = ds.Tables[1];

                    //grvOldGold
                    dtOldGold = ds.Tables[2];
                    grdOldGold.DataSource = ds.Tables[2];
                    lblPayAmountByWord.Text = Gam.process(Math.Abs(Convert.ToDecimal(txtPayAmount.EditValue.ToString())).ToString("###")).ToUpper() + "ĐỒNG"; 
                }
                catch (Exception ex)
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

        private void frmRTChange_Load(object sender, EventArgs e)
        {
           Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToCombo();
            fn_LoadDataToForm(this.strID);
            //fn_CalcBillTotal();
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
                    dTMP += decimal.Parse(grvOldGold.GetRowCellValue(j, "GoldWeight").ToString()) * decimal.Parse(grvOldGold.GetRowCellValue(j, "ChangeRate").ToString()) * 1000 / 100;
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
                            if (grvOldGold.GetRowCellValue(j, "ChangeRate").ToString() != grvOldGold.GetRowCellValue(i, "ChangeRate").ToString())
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag) //cung 1 gia bu
                    {
                        dChangeRate = grvOldGold.RowCount > 0 ? dChangeRate = decimal.Parse(grvOldGold.GetRowCellValue(0, "ChangeRate").ToString()) : 0;
                        dResult = Math.Min(dProductGoldWeight, dOldGoldWeight) * dChangeRate * 1000 / 100;
                    }
                    else //Ko cung 1 gia 
                    {
                        for (int j = 0; j < grvOldGold.RowCount; j++)
                        {
                            dTMP += decimal.Parse(grvOldGold.GetRowCellValue(j, "GoldWeight").ToString()) * decimal.Parse(grvOldGold.GetRowCellValue(j, "ChangeRate").ToString()) * 1000 / 100;
                        }
                        dResult = dTMP;
                    }
                }
                else
                {
                    dChangeRate = grvOldGold.RowCount > 0 ? dChangeRate = decimal.Parse(grvOldGold.GetRowCellValue(0, "ChangeRate").ToString()) : 0;
                    dResult = dProductGoldWeight * dChangeRate * 1000 / 100;
                }
            }

            return dResult;
        }

        private void fn_CalcBillTotal()
        {
            decimal dTotalGoldWeight = 0, dProductGoldWeight = 0, dOldGoldWeight = 0;
            decimal dTotalAmount = 0, dTotalAllAmount = 0;
            decimal dChangeAmount = 0, dChangeRate =0;
            decimal dTaskPrice = 0, dDiscount = 0, dPayAmount = 0;
            decimal dXRate = 0;
            try
            {
                //Tinh tong vang hang va tien cong
                for (int i = 0; i < grvProduct.RowCount; i++)
                {
                    dProductGoldWeight += decimal.Parse(grvProduct.GetRowCellValue(i, "GoldWeight").ToString());
                    dTaskPrice += decimal.Parse(grvProduct.GetRowCellValue(i, "TaskPrice").ToString()) * 1000;
                }
                txtProductGoldWeight.EditValue = dProductGoldWeight;

                //Tinh tong vang cu
                for (int j = 0; j < grvOldGold.RowCount; j++)
                {
                    dOldGoldWeight += decimal.Parse(grvOldGold.GetRowCellValue(j, "GoldWeight").ToString());
                }
                dTotalGoldWeight = dProductGoldWeight - dOldGoldWeight;
                txtOldGoldWeight.EditValue = dOldGoldWeight;

                txtTotalGoldWeight.EditValue = dTotalGoldWeight;
                txtTotalTaskPrice.EditValue = dTaskPrice;

                //Ty gia
                txtSellRate.EditValue = fn_CalSellRate();
                dXRate = decimal.Parse(txtSellRate.EditValue.ToString());

                //tinh tien bu
                dChangeAmount = fn_CalcChangeAmount();
                txtChangeAmount.EditValue = dChangeAmount;

                dTotalAmount = dTotalGoldWeight * dXRate * 1000 / 100;
                txtTotalAmount.EditValue = dTotalAmount;

                //Tong thanh tien
                dTotalAllAmount = dTotalAmount + dChangeAmount + dTaskPrice;
                txtTotalAllAmount.EditValue = dTotalAllAmount;

                //Thanh toan
                dDiscount = decimal.Parse(txtDiscount.EditValue.ToString());
                dPayAmount = dTotalAllAmount - dDiscount;
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

        private void fn_CalcBillSubTotal()
        {
            decimal dTotalGoldWeight = 0;
            decimal dTotalAmount = 0, dTotalAllAmount = 0;
            decimal dChangeAmount = 0;
            decimal dTaskPrice = 0, dDiscount = 0, dPayAmount = 0;
            decimal dXRate = 0;
            try
            {
                dXRate = decimal.Parse(txtSellRate.EditValue.ToString());
                dTaskPrice = decimal.Parse(txtTotalTaskPrice.EditValue.ToString());
                dTotalGoldWeight = decimal.Parse(txtTotalGoldWeight.EditValue.ToString());
                dChangeAmount = decimal.Parse(txtChangeAmount.EditValue.ToString());
                dDiscount = decimal.Parse(txtDiscount.EditValue.ToString());
 
                dTotalAmount = dTotalGoldWeight * dXRate * 1000 / 100;
                txtTotalAmount.EditValue = dTotalAmount;

                //Tong thanh tien
                dTotalAllAmount = dTotalAmount + dChangeAmount + dTaskPrice;
                txtTotalAllAmount.EditValue = dTotalAllAmount;

                //Thanh toan
                dPayAmount = dTotalAllAmount - dDiscount;
                txtPayAmount.EditValue = dPayAmount;

                lblPayAmountByWord.Text = Gam.process(Math.Abs(dPayAmount).ToString("###")).ToUpper() + "ĐỒNG";
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

        private decimal fn_CalSellRate()
        {
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
                    ds = clsCommon.ExecuteDatasetSP("TRN_RT_CHANGE_Del", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Xoá dữ liệu thành công", "OK", ICon.Information);
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
            //btnPayment.Enabled = false;
            try
            {                                
                if(!btnComplete_Click())
                    return;

                frmTillProccessTxn frm = new frmTillProccessTxn(strID);
                if (frm.strErrorCode == "0")
                {
                    ThongBao.Show("Thông báo", "thanh toán thành công.", "OK", ICon.Information);
                    this.Close();              
                }
            }
            catch { }
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
                                       
                    return true;
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
                return false;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;                
            }

        }
     
    }
}