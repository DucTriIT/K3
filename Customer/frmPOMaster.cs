using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;

namespace GoldRT
{
    public partial class frmPOMaster : DevExpress.XtraEditors.XtraForm
    {

    #region Private Variables
        ucPOMaster[] ctrlPoMaster;
        string strID;
        string strStatus;
        public string strTillTxnID = "";
        private string strCustID = "";

        /// <summary>
        /// Mục địch: Tránh trường hợp Handle đến sự kiện 
        /// cboKhachHang_SelectedIndexChanged của cboKhachHang
        /// khi gán giá trị lên form trong hàm fn_LoadDataToForm
        /// </summary>
        private bool isSearching = false;
    #endregion

    #region Public Functions

        public frmPOMaster()
        {
            InitializeComponent();

        }

        public frmPOMaster(string _strCust)
        {
            InitializeComponent();
            strCustID = _strCust;
        }

        public void fn_LoadDataToForm(string _POID, string _Status, string _CustID)
        {
            pnlThongTin.Controls.Clear();
            this.strID = _POID;
            this.strStatus = _Status;
            cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(_Status, cboStatus, 0);
            cboKhachHang.SelectedIndex = Functions.GetSelectedIndexCombo(_CustID, cboKhachHang, 0);

            DataSet ds = new DataSet();
            DataSet dsDt = new DataSet();

            //Chi tiết toa hàng
            ds = clsCommon.ExecuteDatasetSP("[TRN_PO_MASTER_Get]", _POID);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dsDt = clsCommon.ExecuteDatasetSP("[TRN_PO_MASTER_DT_LstByTrnPoMaster]", _POID);
                //Kiểm tra dữ liệu và tạo control chi tiết giao dịch
                int iY = 0;
                int i = 0;
                ctrlPoMaster = new ucPOMaster[dsDt.Tables[0].Rows.Count];
                foreach (DataRow row in dsDt.Tables[0].Rows)
                {
                    ucPOMaster ctrl = new ucPOMaster();

                    ctrl.IsLoadData = true;
                    //ctrl.AmountConverting += new ucPOMaster.AmmountConvertingHandler(ucPOMaster_AmmountConverting);
                    ctrl.fn_LoadDataToCombo(dsDt, row["GoldCode"].ToString());

                    ctrl.Location = new Point(5, iY + 3);

                    //Lấy thông tin trong dsDt set vào ctrl
                    ctrl.CustID = _CustID;
                    ctrl.ProductPOID = row["ProductPOID"].ToString();
                    ctrl.GoldPOID = row["GoldPOID"].ToString();
                    ctrl.GoldCode = row["GoldCode"].ToString();
                    ctrl.GoldDesc = row["GoldDesc"].ToString();
                    ctrl.DTotalWeight = row["GoldWeight"].ToString();
                    ctrl.GTotalWeight = row["ProductGoldWeight"].ToString();
                    ctrl.Debt = row["Old_Debt"].ToString();
                    ctrl.Balance = row["Gold_Remaining"].ToString();
                    ctrl.isDebit = row["Trn_Debt"].ToString() == "0" ? false : true;
                    ctrl.isConvert = row["Trn_Convert"].ToString() == "0" ? false : true;
                    ctrl.isSellBuy = row["Trn_SellBuy"].ToString() == "0" ? false : true;
                    ctrl.BuyOrSell = row["Trn_SellBuy"].ToString() != "0" ? row["Trn_SellBuy"].ToString() : "";
                    ctrl.Quatity = row["Quatity"].ToString();
                    ctrl.Price = row["Price"].ToString();
                    ctrl.Convert_GoldCode = row["Convert_GoldCode"].ToString();
                    ctrl.Convert_Amount = row["Convert_Amount"].ToString();
                    ctrl.GoldAge = row["GoldAge"].ToString();
                    ctrl.GoldAgeChange = row["GoldAgeChange"].ToString();
                    ctrl.AllowChange = row["AllowChange"].ToString() == "0" ? false : true;
                    ctrl.Convert_Amount = row["Convert_Amount"].ToString();
                    ctrlPoMaster[i] = ctrl;
                    pnlThongTin.Controls.Add(ctrl);
                    i++;
                    iY += ctrl.Height + 3;
                    ctrl.IsLoadData = false;

                }

                //Hiển thị thông tin tiền công đã nợ của khách hàng đã chọn
                txtTongTienCong.Text = ds.Tables[0].Rows[0]["Total_TaskPrice"].ToString();
                txtNoTienCong.Text = ds.Tables[0].Rows[0]["Old_TaskPrice"].ToString();
                txtConLaiTienCong.Text = ds.Tables[0].Rows[0]["New_TaskPrice"].ToString();
                rdGhiNo.Checked = ds.Tables[0].Rows[0]["Trn_Debt"].ToString() == "0" ? false : true;
                rdThanhToan.Checked = ds.Tables[0].Rows[0]["Trn_Pay"].ToString() == "0" ? false : true;
                txtSoTien.Text = ds.Tables[0].Rows[0]["Trn_PayAmount"].ToString();
                txtConLai.Text = ds.Tables[0].Rows[0]["Remain_Amount"].ToString();
               
                this.Cursor = Cursors.Default;
                pnlThongTin.Focus();
                isSearching = false;
                fn_SetFormToEdit(this.strStatus == "W");
            }
            fn_TinhTongTien();
            txtPayAmount.Text = ds.Tables[0].Rows[0]["PayAmount"].ToString();
            txtDebtAmount.Text = ds.Tables[0].Rows[0]["DebtAmount"].ToString();
        }

    #endregion

    #region Private Functions
        private void fn_LoadDefault()
        {
            this.Cursor = Cursors.WaitCursor;

            this.strID = String.Empty;
            this.strStatus = String.Empty;
            cboStatus.SelectedIndex = 0;

            txtTongTienCong.Text = "0";
            txtNoTienCong.Text = "0";
            txtConLaiTienCong.Text = "0";
            rdGhiNo.Checked = true;
            cboKhachHang.SelectedIndex = 0;
            cboKhachHang.Enabled = true;
            txtTongTien.Text = "0";
            txtPayAmount.Text = "0";
            txtDebtAmount.Text = "0";

            txtSoTien.Text = "0";
            txtConLai.Text = "0";
            txtSoTien.Enabled = false;
            txtConLai.Enabled = false;
            

            btnKetToa.Enabled = true;
            btnCapNhat.Enabled = false;
            btnComplete.Enabled = false;
            btnXoa.Enabled = false;
            btnInBangKe.Enabled = false;
            btnThanhToan.Enabled = false;

            grpTienCong.Enabled = false;
            grpToaHang.Enabled = false;

            if (ctrlPoMaster != null && ctrlPoMaster.Length > 0)
            {
                foreach (ucPOMaster uc in ctrlPoMaster)
                    uc.Dispose();
                ctrlPoMaster = null;
            }

            pnlThongTin.Controls.Clear();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Set trạng thai form được phép chỉnh sửa dữ liệu hay không?
        /// </summary>
        /// <param name="bEdit">
        /// true: được phép;
        /// false: không được phép
        /// </param>
        private void fn_SetFormToEdit(bool bEdit)
        {
            cboKhachHang.Enabled = (this.strStatus == "");
            //pnlThongTin.Enabled = bEdit;
            if (ctrlPoMaster != null)
            {
                foreach (ucPOMaster uc in ctrlPoMaster)
                    uc.Enabled = bEdit;
            }

            rdGhiNo.Enabled = bEdit;
            rdThanhToan.Enabled = bEdit;
            txtPayAmount.Enabled = bEdit;
            btnCapNhat.Enabled = bEdit;
            btnXoa.Enabled = bEdit;
            btnComplete.Enabled = (this.strStatus == "W");
            btnInBangKe.Enabled = (this.strStatus == "C");
            btnKetToa.Enabled = (this.strID == String.Empty);

            grpTienCong.Enabled = bEdit;
            grpToaHang.Enabled = bEdit;
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.LoadComboSP("I_CUSTOMER", "NOTWALKINCUST");
                Functions.BindDropDownList(cboKhachHang, ds, "CustInfo", "CustID", "", true);
                ds.Clear();

                ds = clsCommon.LoadComboSP("T_STATUS", "PO");
                Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
                ds.Clear();
            }
            catch { }
            finally { ds.Dispose(); }
        }

        private bool fn_CheckValidate()
        {
            if (rdThanhToan.Checked)
            {
                if (String.IsNullOrEmpty(txtSoTien.Text))
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập vào số tiền thanh toán tiền công.", "OK", ICon.Error);
                    txtSoTien.Focus();
                    return false;
                }
            }

            return true;
        }

        private void fn_TinhTongTien()
        {
            decimal dSum = decimal.Parse(txtSoTien.Text);
            decimal dPay = 0;
            decimal dDebt = 0;
            for (int i = 0; i < ctrlPoMaster.Length; i++)
            {
                if (ctrlPoMaster[i].isSellBuy)
                {
                    decimal dTemp;
                    
                    try { dTemp = decimal.Parse(ctrlPoMaster[i].ThanhTien); }
                    catch { dTemp = 0; }

                    decimal dConLai;
                    try { dConLai= decimal.Parse(ctrlPoMaster[i].Balance); }
                    catch { dConLai= 0; }

                    if (ctrlPoMaster[i].BuyOrSell == "B")
                    {
                        dSum = dSum - dTemp;
                    }
                    else if (ctrlPoMaster[i].BuyOrSell == "S")
                    {
                        dSum = dSum + dTemp;
                    }
                }
            }
            txtTongTien.Text= dSum.ToString();
            if (txtPayAmount.Text == "0")
                txtPayAmount.Text = dSum.ToString();
            dPay= decimal.Parse(txtPayAmount.Text);
            txtDebtAmount.Text = (dSum - dPay).ToString();
        }
    #endregion

    #region Event Handlers
        private void frmPOMaster_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            fn_LoadDefault();
            cboKhachHang.SelectedIndex = Functions.GetSelectedIndexCombo(strCustID, cboKhachHang, 0);
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DataSet ds = new DataSet();

            string strGoldCodes = String.Empty;
            string strTrn_Debts = String.Empty;
            string strTrn_Converts = String.Empty;
            string strTrn_SellBuys = String.Empty;
            string strQuatitys = String.Empty;
            string strPrices = String.Empty;
            string strProductPOID = String.Empty;
            string strGoldPOID = String.Empty;
            string strGoldWeight = String.Empty;
            string strProductGoldWeight = String.Empty;
            string strOld_Debt = String.Empty;
            string strGold_Remaining = String.Empty;
            string strConvert_GoldCode = String.Empty;
            string strConvert_Amount = String.Empty;
            string strGoldAge = String.Empty;
            string strGoldAgeChange = String.Empty;

            try
            {
                if (!fn_CheckValidate()) return;

                bool bIsConverting = false;

                if (ctrlPoMaster != null)
                {
                    for (int i = 0; i < ctrlPoMaster.Length; i++)
                    {
                        if (!ctrlPoMaster[i].fn_CheckValidate()) return;

                        strGoldCodes += ctrlPoMaster[i].GoldCode + "@";
                        strTrn_Debts += (ctrlPoMaster[i].isDebit ? "1" : "0") + "@";
                        strTrn_Converts += (ctrlPoMaster[i].isConvert ? "1" : "0") + "@";
                        strTrn_SellBuys += (ctrlPoMaster[i].isSellBuy ? ctrlPoMaster[i].BuyOrSell : "0") + "@";//(ctrlPoMaster[i].isSellBuy ? "1" : "0") + "@";
                        strQuatitys += decimal.Parse(ctrlPoMaster[i].Quatity).ToString(Program.ciUS) + "@";
                        strPrices += decimal.Parse(ctrlPoMaster[i].Price).ToString(Program.ciUS) + "@";
                        strProductPOID += ctrlPoMaster[i].ProductPOID + "@";
                        strGoldPOID += ctrlPoMaster[i].GoldPOID + "@";
                        strGoldWeight += decimal.Parse(ctrlPoMaster[i].DTotalWeight).ToString(Program.ciUS) + "@";
                        strProductGoldWeight += decimal.Parse(ctrlPoMaster[i].GTotalWeight).ToString(Program.ciUS) + "@";
                        strOld_Debt += decimal.Parse(ctrlPoMaster[i].Debt).ToString(Program.ciUS) + "@";
                        strGold_Remaining += decimal.Parse(ctrlPoMaster[i].Balance).ToString(Program.ciUS) + "@";
                        strConvert_GoldCode += ctrlPoMaster[i].Convert_GoldCode + "@";
                        strConvert_Amount += decimal.Parse(ctrlPoMaster[i].Convert_Amount).ToString(Program.ciUS) + "@";
                        strGoldAge += decimal.Parse(ctrlPoMaster[i].GoldAge).ToString(Program.ciUS) + "@";
                        strGoldAgeChange += decimal.Parse(ctrlPoMaster[i].GoldAgeChange).ToString(Program.ciUS) + "@";

                        if (!bIsConverting)
                            bIsConverting = ctrlPoMaster[i].isConvert;
                    }

                    strGoldCodes = strGoldCodes.Substring(0, strGoldCodes.Length - 1);
                    strTrn_Debts = strTrn_Debts.Substring(0, strTrn_Debts.Length - 1);
                    strTrn_Converts = strTrn_Converts.Substring(0, strTrn_Converts.Length - 1);
                    strTrn_SellBuys = strTrn_SellBuys.Substring(0, strTrn_SellBuys.Length - 1);
                    strQuatitys = strQuatitys.Substring(0, strQuatitys.Length - 1);
                    strPrices = strPrices.Substring(0, strPrices.Length - 1);
                    strProductPOID = strProductPOID.Substring(0, strProductPOID.Length - 1);
                    strGoldPOID = strGoldPOID.Substring(0, strGoldPOID.Length - 1);
                    strGoldWeight = strGoldWeight.Substring(0, strGoldWeight.Length - 1);
                    strProductGoldWeight = strProductGoldWeight.Substring(0, strProductGoldWeight.Length - 1);
                    strOld_Debt = strOld_Debt.Substring(0, strOld_Debt.Length - 1);
                    strGold_Remaining = strGold_Remaining.Substring(0, strGold_Remaining.Length - 1);
                    strConvert_GoldCode = strConvert_GoldCode.Substring(0, strConvert_GoldCode.Length - 1);
                    strConvert_Amount = strConvert_Amount.Substring(0, strConvert_Amount.Length - 1);
                    strGoldAge = strGoldAge.Substring(0, strGoldAge.Length - 1);
                    strGoldAgeChange = strGoldAgeChange.Substring(0, strGoldAgeChange.Length - 1);
                }

                //Thực hiện việc chuyển dẻ
                //if (bIsConverting)
                //{
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_MASTER_InsConvertGold]", this.strID, ((ItemList)cboKhachHang.SelectedItem).ID,
                        clsSystem.UserID, strTrn_Converts, strConvert_GoldCode, strConvert_Amount, strGoldAge, strGoldAgeChange);
                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "-1")
                    {
                        ThongBao.Show("Thông báo", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                        return;
                    }
                //}

                //Refresh lại tất cả các toa
              //  for (int i = 0; i < ctrlPoMaster.Length; i++)
               // {
              //      ctrlPoMaster[i].fn_Refresh();
              //  }
                 for (int i = 0; i < ctrlPoMaster.Length; i++)
                {
                    if (ctrlPoMaster[i].isConvert == true)
                    {
                        for (int j = 0; j < ctrlPoMaster.Length; j++)
                        {
                            if (ctrlPoMaster[i].Convert_GoldCode == ctrlPoMaster[j].GoldCode)
                            {
                                ctrlPoMaster[j].fn_Refresh();
                            }
                        }
                    }
                }
#region draf
                //strGoldCodes = String.Empty;
                //strTrn_Debts = String.Empty;
                //strTrn_Converts = String.Empty;
                //strTrn_SellBuys = String.Empty;
                //strQuatitys = String.Empty;
                //strPrices = String.Empty;
                //strProductPOID = String.Empty;
                //strGoldPOID = String.Empty;
                //strGoldWeight = String.Empty;
                //strProductGoldWeight = String.Empty;
                //strOld_Debt = String.Empty;
                //strGold_Remaining = String.Empty;
                //strConvert_GoldCode = String.Empty;
                //strConvert_Amount = String.Empty;
                //strGoldAge = String.Empty;
                //strGoldAgeChange = String.Empty;

                //if (ctrlPoMaster != null)
                //{
                //    for (int i = 0; i < ctrlPoMaster.Length; i++)
                //    {
                //        if (!ctrlPoMaster[i].fn_CheckValidate()) return;

                //        strGoldCodes += ctrlPoMaster[i].GoldCode + "@";
                //        strTrn_Debts += (ctrlPoMaster[i].isDebit ? "1" : "0") + "@";
                //        strTrn_Converts += (ctrlPoMaster[i].isConvert ? "1" : "0") + "@";
                //        strTrn_SellBuys += (ctrlPoMaster[i].isSellBuy ? ctrlPoMaster[i].BuyOrSell : "0") + "@";//(ctrlPoMaster[i].isSellBuy ? "1" : "0") + "@";
                //        strQuatitys += decimal.Parse(ctrlPoMaster[i].Quatity).ToString(Program.ciUS) + "@";
                //        strPrices += decimal.Parse(ctrlPoMaster[i].Price).ToString(Program.ciUS) + "@";
                //        strProductPOID += ctrlPoMaster[i].ProductPOID + "@";
                //        strGoldPOID += ctrlPoMaster[i].GoldPOID + "@";
                //        strGoldWeight += decimal.Parse(ctrlPoMaster[i].DTotalWeight).ToString(Program.ciUS) + "@";
                //        strProductGoldWeight += decimal.Parse(ctrlPoMaster[i].GTotalWeight).ToString(Program.ciUS) + "@";
                //        strOld_Debt += decimal.Parse(ctrlPoMaster[i].Debt).ToString(Program.ciUS) + "@";
                //        strGold_Remaining += decimal.Parse(ctrlPoMaster[i].Balance).ToString(Program.ciUS) + "@";
                //        strConvert_GoldCode += ctrlPoMaster[i].Convert_GoldCode + "@";
                //        strConvert_Amount += decimal.Parse(ctrlPoMaster[i].Convert_Amount).ToString(Program.ciUS) + "@";
                //        strGoldAge += decimal.Parse(ctrlPoMaster[i].GoldAge).ToString(Program.ciUS) + "@";
                //        strGoldAgeChange += decimal.Parse(ctrlPoMaster[i].GoldAgeChange).ToString(Program.ciUS) + "@";

                //        if (!bIsConverting)
                //            bIsConverting = ctrlPoMaster[i].isConvert;
                //    }

                //    strGoldCodes = strGoldCodes.Substring(0, strGoldCodes.Length - 1);
                //    strTrn_Debts = strTrn_Debts.Substring(0, strTrn_Debts.Length - 1);
                //    strTrn_Converts = strTrn_Converts.Substring(0, strTrn_Converts.Length - 1);
                //    strTrn_SellBuys = strTrn_SellBuys.Substring(0, strTrn_SellBuys.Length - 1);
                //    strQuatitys = strQuatitys.Substring(0, strQuatitys.Length - 1);
                //    strPrices = strPrices.Substring(0, strPrices.Length - 1);
                //    strProductPOID = strProductPOID.Substring(0, strProductPOID.Length - 1);
                //    strGoldPOID = strGoldPOID.Substring(0, strGoldPOID.Length - 1);
                //    strGoldWeight = strGoldWeight.Substring(0, strGoldWeight.Length - 1);
                //    strProductGoldWeight = strProductGoldWeight.Substring(0, strProductGoldWeight.Length - 1);
                //    strOld_Debt = strOld_Debt.Substring(0, strOld_Debt.Length - 1);
                //    strGold_Remaining = strGold_Remaining.Substring(0, strGold_Remaining.Length - 1);
                //    strConvert_GoldCode = strConvert_GoldCode.Substring(0, strConvert_GoldCode.Length - 1);
                //    strConvert_Amount = strConvert_Amount.Substring(0, strConvert_Amount.Length - 1);
                //    strGoldAge = strGoldAge.Substring(0, strGoldAge.Length - 1);
                //    strGoldAgeChange = strGoldAgeChange.Substring(0, strGoldAgeChange.Length - 1);
                //}
#endregion         
                fn_TinhTongTien();
                if (String.IsNullOrEmpty(this.strID)) //Insert
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_MASTER_Ins]", "", ((ItemList)cboKhachHang.SelectedItem).ID,
                        txtTongTienCong.EditValue, txtNoTienCong.EditValue, txtConLaiTienCong.EditValue, rdGhiNo.Checked ? "1" : "0",
                        rdThanhToan.Checked ? "1" : "0", txtSoTien.EditValue, txtConLai.EditValue, "W", clsSystem.UserID,
                        strGoldCodes, strProductPOID, strGoldPOID, strGoldWeight, strProductGoldWeight, strOld_Debt,
                        strGold_Remaining, strTrn_Debts, strTrn_Converts, strConvert_GoldCode, strConvert_Amount, strGoldAge, strGoldAgeChange, strTrn_SellBuys, strQuatitys, strPrices,txtPayAmount.EditValue,txtDebtAmount.EditValue);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                        {
                            this.strID = ds.Tables[0].Rows[0]["POID"].ToString();
                            this.strStatus = "W";
                            cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("W", cboStatus, 0);
                            fn_SetFormToEdit(true);
                            ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                        }
                        else
                        {
                            ThongBao.Show("Thông báo", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                        }
                    }
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_MASTER_Upd]", this.strID, ((ItemList)cboKhachHang.SelectedItem).ID,
                        txtTongTienCong.EditValue, txtNoTienCong.EditValue, txtConLaiTienCong.EditValue, rdGhiNo.Checked ? "1" : "0",
                        rdThanhToan.Checked ? "1" : "0", txtSoTien.EditValue, txtConLai.EditValue, "W", clsSystem.UserID,
                        strGoldCodes, strProductPOID, strGoldPOID, strGoldWeight, strProductGoldWeight, strOld_Debt,
                        strGold_Remaining, strTrn_Debts, strTrn_Converts, strConvert_GoldCode, strConvert_Amount, strGoldAge, strGoldAgeChange, strTrn_SellBuys, strQuatitys, strPrices, txtPayAmount.EditValue, txtDebtAmount.EditValue);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                    }
                }

                
            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
                
            }
        }

        private void btnKetToa_Click(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex <= 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn khách hàng trước khi thực hiện", "OK", ICon.Error);
                cboKhachHang.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            ctrlPoMaster = null;
            pnlThongTin.Controls.Clear();

            DataSet dsDebt = new DataSet();
            DataSet ds = new DataSet();

            string strCustID = ((ItemList)cboKhachHang.SelectedItem).ID;

            //Tổng giá công của tất cả các toa hàng trong dsPrdtPO
            decimal dTotalTaskPrice = 0;

            //Chi tiết toa hàng + Toa de
            ds = clsCommon.ExecuteDatasetSP("[TRN_PO_KetToa]", strCustID, "W");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                btnCapNhat.Enabled = true;
                btnComplete.Enabled = true;

                //Kiểm tra dữ liệu và tạo control chi tiết giao dịch
                int iY = 0;
                int i = 0;
                ctrlPoMaster = new ucPOMaster[ds.Tables[0].Rows.Count];
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //Get nợ ứng với từng loại vàng trong toa này
                    dsDebt = clsCommon.ExecuteDatasetSP("[T_CUSTOMER_DEBT_Lst]", strCustID, row["GoldCode"].ToString(), "");

                    ucPOMaster ctrl = new ucPOMaster();
                    //ctrl.AmountConverting += new ucPOMaster.AmmountConvertingHandler(ucPOMaster_AmmountConverting);
                    ctrl.fn_LoadDataToCombo(ds, row["GoldCode"].ToString());
                    ctrl.Location = new Point(5, iY + 3);

                    //Lấy thông tin trong ds set vào ctrl phần 'hàng'
                    ctrl.CustID = ((ItemList)cboKhachHang.SelectedItem).ID;
                    ctrl.ProductPOID = row["ProductPOID"].ToString();
                    ctrl.GoldCode = row["GoldCode"].ToString();
                    ctrl.GoldDesc = row["GoldDesc"].ToString();
                    ctrl.GTotalWeight = String.IsNullOrEmpty(row["TP_Total_GoldWeight"].ToString()) ? "0" : row["TP_Total_GoldWeight"].ToString();
                    
                    //Lấy thông tin trong ds set vào ctrl phần 'dẻ'
                    ctrl.GoldPOID = row["GoldPOID"].ToString();
                    ctrl.DTotalWeight = String.IsNullOrEmpty(row["TG_Total_GoldWeightChange"].ToString()) ? "0" : row["TG_Total_GoldWeightChange"].ToString();

                    //Lấy thông tin nợ set vào ctrl
                    ctrl.Debt = (dsDebt.Tables.Count > 0 && dsDebt.Tables[0].Rows.Count > 0) ? dsDebt.Tables[0].Rows[0]["Debt_Bal"].ToString() : "0";

                    try
                    {
                        ctrl.Balance = ((Decimal)(Decimal.Parse(ctrl.GTotalWeight) - Decimal.Parse(ctrl.DTotalWeight) + Decimal.Parse(ctrl.Debt))).ToString(); 
                    }
                    catch
                    { ctrl.Balance = ""; }

                    ctrlPoMaster[i] = ctrl;
                    pnlThongTin.Controls.Add(ctrl);
                    i++;
                    iY += ctrl.Height + 3;

                    //Sum tổng giá công trên từng dòng
                    try
                    { dTotalTaskPrice += Decimal.Parse(row["TP_Total_TaskPrice"].ToString()); }
                    catch
                    { dTotalTaskPrice += 0; }
                }
                fn_SetFormToEdit(true);
            }
            //Hiển thị thông tin tiền công đã nợ của khách hàng đã chọn
            dsDebt = clsCommon.ExecuteDatasetSP("[T_CUSTOMER_DEBT_Lst]", strCustID, "VND", "");
            txtNoTienCong.Text = (dsDebt.Tables.Count > 0 && dsDebt.Tables[0].Rows.Count > 0) ? dsDebt.Tables[0].Rows[0]["Debt_Bal"].ToString() : "0";
            txtTongTienCong.Text = dTotalTaskPrice.ToString();
            try
            { 
                txtConLaiTienCong.EditValue = ((Decimal)(Decimal.Parse(txtTongTienCong.Text) + Decimal.Parse(txtNoTienCong.Text))).ToString();
                //txtSoTien.EditValue= ((Decimal)(Decimal.Parse(txtTongTienCong.Text) + Decimal.Parse(txtNoTienCong.Text))).ToString();
                //txtConLai.Text = "0";
                txtSoTien.EditValue = "0";
                txtConLai.Text = ((Decimal)(Decimal.Parse(txtTongTienCong.Text) + Decimal.Parse(txtNoTienCong.Text))).ToString();
            }
            catch(Exception ex)
            { 
                txtConLaiTienCong.Text = ""; 
                txtSoTien.Text = "";
                txtConLai.Text = "";
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }

            this.Cursor = Cursors.Default;
            pnlThongTin.Focus();
        }

        void ucPOMaster_AmmountConverting(string strConvert_GoldCode_Old, string strConvert_GoldCode, string strConvert_Amount)
        {
            if (!String.IsNullOrEmpty(strConvert_GoldCode_Old))
            {
                if (ctrlPoMaster != null)
                {
                    foreach (ucPOMaster c in ctrlPoMaster)
                    {
                        if (c != null && c.ProductPOID == strConvert_GoldCode_Old)
                        {
                            Decimal dConvert_Amount = Decimal.Parse(strConvert_Amount);
                            Decimal dBalance = Decimal.Parse(c.Balance);

                            c.Balance = ((Decimal)(dBalance - dConvert_Amount)).ToString();
                            break;
                        }
                    }
                }
            }

            if (ctrlPoMaster != null)
            {
                foreach (ucPOMaster c in ctrlPoMaster)
                {
                    if (c != null && c.ProductPOID == strConvert_GoldCode)
                    {
                        Decimal dConvert_Amount = Decimal.Parse(strConvert_Amount);
                        Decimal dBalance = Decimal.Parse(c.Balance);

                        c.Balance = ((Decimal)(dBalance + dConvert_Amount)).ToString();
                        break;
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            frmTillProccessTxn frm = new frmTillProccessTxn(strID);
            //frm.ShowDialog();
            if (frm.strErrorCode == "0")
            {
                btnThanhToan.Enabled = false;
                //txtIsPaid.Text = "Y";
            }

            //DataSet ds = new DataSet();

            //string strGoldCcy = String.Empty;
            //string strDebt_Bal = String.Empty;

            //try
            //{
            //    if (!String.IsNullOrEmpty(this.strID))
            //    {
            //        ds = clsCommon.ExecuteDatasetSP("[TRN_PO_MASTER_Payment]", strID, clsSystem.UserID);

            //        if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
            //        {
            //            this.strStatus = "C";
            //            cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("C", cboStatus, 0);
            //            fn_SetFormToEdit(false);
            //            ThongBao.Show("Thông báo", "Thanh toán thành công.", "OK", ICon.Information);
            //        }
            //        else
            //            ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
            //    }
            //    else
            //    {
            //        ThongBao.Show("Lỗi", "Vui lòng cập nhật trước khi thực hiện thanh toán!", "OK", ICon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            //}
            //finally
            //{
            //    ds.Dispose();
            //}
        }

        private void rdThanhToan_Properties_CheckedChanged(object sender, EventArgs e)
        {
            if (rdThanhToan.Checked)
            {
                txtSoTien.Enabled = true;
                txtSoTien.EditValue = decimal.Parse(txtConLaiTienCong.Text);
                txtConLai.EditValue= decimal.Parse(txtConLaiTienCong.Text) - decimal.Parse(txtSoTien.Text);
                txtSoTien.Focus();
            }
            else
            {
                txtSoTien.EditValue = 0;
                txtConLai.EditValue = decimal.Parse(txtConLaiTienCong.Text);
                txtSoTien.Enabled = false;
            }
        }

        private void txtSoTien_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!txtSoTien.Enabled || String.IsNullOrEmpty(txtSoTien.Text)) return;

                Decimal d = Decimal.Parse(txtSoTien.Text);
                Decimal dBalance = 0;

                try { dBalance = Decimal.Parse(txtConLaiTienCong.Text); }
                catch { }

                if (d < Decimal.Zero)
                {
                    ThongBao.Show("Lỗi", "Số tiền thanh toán tiền công phải lớn hơn 0.", "OK", ICon.Error);
                    txtSoTien.Focus();
                    return;
                }

                if (d > dBalance)
                {
                    ThongBao.Show("Lỗi", "Số tiền thanh toán tiền công không được nhập quá số tiền còn lại.", "OK", ICon.Error);
                    txtSoTien.Focus();
                    return;
                }

                txtConLai.Text = ((Decimal)(dBalance - d)).ToString();
            }
            catch
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin số tiền thanh toán tiền công.", "OK", ICon.Error);
                txtSoTien.Focus();
                txtConLaiTienCong.Text = "0";
                return;
            }
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            isSearching = true;
            frmPOMasterLst frm = new frmPOMasterLst(this);
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fn_LoadDefault();
        }

        private void btnInBangKe_Click1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams ="", strValues = "";
            double dTotal = 0;

            //strParams = "TuNgay@DenNgay";
            //strValues = strFromDate;
            //strValues += "@" + strToDate;

            ds = clsCommon.ExecuteDatasetSP("rptBangKeThanhToan", strID);
            dTotal = Math.Abs(double.Parse(ds.Tables[8].Rows[ds.Tables[8].Rows.Count - 1]["TotalPaymentAmt"].ToString()));
            strParams = "ThanhTien";
            strValues = VND.process(dTotal.ToString()).ToUpper() + "ĐỒNG";  

            Functions.fn_ShowReport(ds, "rptBangKeThanhToan.rpt", strParams, strValues);
            //Functions.fn_ShowReport_AndImage(ds, "rptBangKeThanhToan.rpt", strParams, strValues);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_MASTER_Del]", strID);

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

        private void txtSoTien_Leave(object sender, EventArgs e)
        {            
            txtConLai.EditValue = ((Decimal)(Decimal.Parse(txtConLaiTienCong.EditValue.ToString()) - Decimal.Parse(txtSoTien.EditValue.ToString()))).ToString();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedIndex == 0)
            {
                lblStatus.Text = "{rỗng}";
                return;
            }

            lblStatus.Text = ((ItemList)cboStatus.SelectedItem).Value;
        }
    #endregion

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string strGoldCcy = String.Empty;
            string strDebt_Bal = String.Empty;

            try
            {
                if (!String.IsNullOrEmpty(this.strID))
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_MASTER_Complete]", strID, clsSystem.UserID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        this.strStatus = "C";
                        cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("C", cboStatus, 0);
                        fn_SetFormToEdit(false);
                        frmTillProccessTxn frm = new frmTillProccessTxn(strID);
                        //frm.ShowDialog();
                        if (frm.strErrorCode == "0")
                        {
                            btnThanhToan.Enabled = false;
                            //txtIsPaid.Text = "Y";
                        }
                        //ThongBao.Show("Thông báo", "Hoàn tất thành công.", "OK", ICon.Information);
                        //btnThanhToan.Enabled = true;
                    }
                    else
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
                else
                {
                    ThongBao.Show("Lỗi", "Vui lòng cập nhật trước khi thực hiện thanh toán!", "OK", ICon.Error);
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

        private void btnInBangKe_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams = "", strValues = "", ThuChi = "";
            double dTotal = 0, dTongGiao = 0, dPayAmount = 0, dTotalPhatsinh = 0, dTongket = 0;

            ds = clsCommon.ExecuteDatasetSP("rptBangKeThanhToan_Rutgon", strID);
            dTongket = Convert.ToDouble(txtPayAmount.EditValue.ToString()) * 1000;
            if (dTongket > 0)
                ThuChi = "Thu:";
            else
                ThuChi = "Chi:";

            dTotal = Math.Abs(double.Parse(ds.Tables[11].Rows[ds.Tables[11].Rows.Count - 1]["TotalPaymentAmt"].ToString()));
            dTongGiao = Math.Abs(double.Parse(ds.Tables[11].Rows[ds.Tables[11].Rows.Count - 1]["TotalGoldWeight"].ToString()));
            strParams = "ThanhTien@TongGiao@dPayAmount@dTotalPhatsinh@ThuChi@TongketThuChi";
            strValues = VND.process(dTotal.ToString()).ToUpper() + "ĐỒNG@" + dTongGiao.ToString() + "@" + dPayAmount + "@" + dTotalPhatsinh + "@" + ThuChi + "@" + dTongket;

            Functions.fn_ShowReport(ds, "rptBangKeThanhToan_Rg.rpt", strParams, strValues);
        }

        private void txtPayAmount_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!txtPayAmount.Enabled)
                return;
            decimal dTongTien = decimal.Parse(txtTongTien.Text);
            decimal dPay=0,dDebt=0;
            if (!decimal.TryParse(e.NewValue.ToString(), out dPay))
            {
                ThongBao.Show("Lỗi","Vui lòng nhập giá trị số","OK",ICon.Error);
                e.Cancel = true;
                return;
            }
            dDebt = dTongTien - dPay;
            txtDebtAmount.Text = dDebt.ToString();
        }

    }
}