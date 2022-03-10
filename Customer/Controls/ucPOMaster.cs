using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class ucPOMaster : UserControl
    {

    #region Properties

        #region Thông tin chính
           
        bool _IsLoadData;
        public bool IsLoadData
        {
            get { return _IsLoadData; }
            set { _IsLoadData = value; }
        }

        string _custID;
        public string CustID
        {
            get { return _custID; }
            set { _custID = value; }
        }

        string _productPOID;
        public string ProductPOID
        {
            get { return _productPOID; }
            set { _productPOID = value; }
        }

        string _goldPOID;
        public string GoldPOID
        {
            get { return _goldPOID; }
            set { _goldPOID = value; }
        }

        string _goldCode;
        public string GoldCode
        {
            get { return _goldCode; }
            set { _goldCode = value; }
        }

        public string GoldDesc
        {
            get { return txtLoaiVang.Text; }
            set { txtLoaiVang.Text = value; }
        }

        public string DTotalWeight
        {
            get { return txtDe.Text; }
            set { txtDe.Text = value; }
        }

        public string GTotalWeight
        {
            get { return txtHang.Text; }
            set { txtHang.Text = value; }
        }

        public string Debt
        {
            get { return txtNo.Text; }
            set { txtNo.Text = value; }
        }

        public string Balance
        {
            get { return txtCon.Text; }
            set
            { txtCon.Text = value; }
        }

        private bool m_allowChange = true;
        public bool AllowChange
        {
            get { return m_allowChange; }
            set { m_allowChange = value; }
        }
        #endregion

        #region Lựa chọn (RadioButton)
        public bool isDebit
        {
            get { return rdGhiNo.Checked; }
            set { rdGhiNo.Checked = value; }
        }

        public bool isConvert
        {
            get { return rdChuyen.Checked; }
            set { rdChuyen.Checked = value; }
        }

        public bool isSellBuy
        {
            get { return rdMuaBan.Checked; }
            set { rdMuaBan.Checked = value; }
        }
        #endregion

        #region Các biến liên quan phần "Chuyển"

        public string m_Convert_GoldCode;
        public string Convert_GoldCode
        {
            get { return m_Convert_GoldCode; }
            set { m_Convert_GoldCode = value; }
        }

        private string m_Convert_Amount = "0";
        public string Convert_Amount
        {
            get { return String.IsNullOrEmpty(m_Convert_Amount) ? "0" : m_Convert_Amount; }
            set { m_Convert_Amount = value; }
        }

        public string GoldAge
        {
            get { return String.IsNullOrEmpty(txtGoldAge.Text) ? "0" : txtGoldAge.Text; }
            set { txtGoldAge.Text = value; }
        }

        public string GoldAgeChange
        {
            get { return String.IsNullOrEmpty(txtGoldAgeChange.Text) ? "0" : txtGoldAgeChange.Text; }
            set { txtGoldAgeChange.Text = value; }
        }

        #endregion

        #region Các biến liên quan phần "Mua/ Bán"

        public string Quatity
        {
            get { return txtSoLuong.Text; }
            set { txtSoLuong.Text = value; }
        }

        public string Price
        {
            get { return txtGia.EditValue == null ? "0" : txtGia.EditValue.ToString(); }
            set { txtGia.EditValue = value; }
        }

        private string m_BuyOrSell;
        public string BuyOrSell
        {
            get { return m_BuyOrSell; }
            set
            { m_BuyOrSell = value; }
        }

        public string ThanhTien
        {
            get { return txtThanhTien.Text; }
            set { txtThanhTien.Text = value; }
        }

        private string m_TrnQuantity = "0";
        public string TrnQuantity
        {
            get { return m_TrnQuantity; }
            set { m_TrnQuantity = value; }
        }

        #endregion

    #endregion

    #region Public Functions
        public ucPOMaster()
        {
            InitializeComponent();
        }

        public bool fn_CheckValidate()
        {
            if (rdMuaBan.Checked)
            {
                if (String.IsNullOrEmpty(txtSoLuong.Text))
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập vào Số lượng Mua/Bán.", "OK", ICon.Error);
                    txtSoLuong.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtGia.Text))
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập vào giá Mua/Bán.", "OK", ICon.Error);
                    txtGia.Focus();
                    return false;
                }
            }

            if (rdChuyen.Checked)
            {
                if (cboLoaiVang.SelectedIndex == 0)
                {
                    ThongBao.Show("Lỗi", "Vui lòng chọn Loại vàng muốn chuyển.", "OK", ICon.Error);
                    cboLoaiVang.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtGoldAge.Text))
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập vào Tuổi.", "OK", ICon.Error);
                    txtGoldAge.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtGoldAgeChange.Text))
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập vào Tuổi qui đổi.", "OK", ICon.Error);
                    txtGoldAgeChange.Focus();
                    return false;
                }

                if (decimal.Parse(txtGoldAgeChange.Text) <= 0)
                {
                    ThongBao.Show("Lỗi", "Tuổi qui đổi phải lớn hơn 0.", "OK", ICon.Error);
                    txtGoldAgeChange.Focus();
                    return false;
                }

                if (decimal.Parse(txtGoldAge.Text) <= 0)
                {
                    ThongBao.Show("Lỗi", "Tuổi phải lớn hơn 0.", "OK", ICon.Error);
                    txtGoldAge.Focus();
                    return false;
                }
            }
            return true;
        }

        public void fn_LoadDataToCombo(DataSet ds, string curGoldCode)
        {
            cboLoaiVang.Properties.Items.Add(new ItemList("", ""));

            rdChuyen.Enabled = (ds.Tables[0].Rows.Count > 1);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string strGoldCode = row["GoldCode"].ToString();
                if (row["GoldCode"].ToString() != curGoldCode)
                {
                    string strGoldDesc = row["GoldDesc"].ToString();
                    cboLoaiVang.Properties.Items.Add(new ItemList(strGoldCode, strGoldDesc));
                }
            }
        }

        public void fn_Refresh()
        {
            btnRefresh_Click(null, null);
        }
    #endregion

    #region Event Handlers
        private void rdMuaBan_CheckedChanged(object sender, EventArgs e)
        {
            if (IsLoadData == true) return;

            if (rdMuaBan.Checked)
            {
                //Khởi tạo giá trị ban đầu cho txtSoLuong khi check chọn Mua/ Bán
                fn_Refresh();
                txtSoLuong.Enabled = true;
                txtSoLuong.Text = ((Decimal)Math.Abs(Decimal.Parse(txtCon.Text))).ToString();
                txtGia.Enabled = true;
                txtSoLuong.Focus();
            }
            else
            {
                //Trả lại giá trị ban đầu cho txtCon sau khi không còn chọn Mua/ Bán nữa
                //if (BuyOrSell == "B")
                //    Balance = ((Decimal)(Decimal.Parse(Balance) + Decimal.Parse(Quatity))).ToString();
                //else
                //    Balance = ((Decimal)(Decimal.Parse(Balance) - Decimal.Parse(Quatity))).ToString();

                //Balance = ((Decimal)(Decimal.Parse(Balance) + Decimal.Parse(TrnQuantity))).ToString();
                Balance = ((Decimal)(Decimal.Parse(GTotalWeight) - Decimal.Parse(DTotalWeight) + Decimal.Parse(Debt))).ToString();
                txtGia.Enabled = false;
                txtSoLuong.Enabled = false;
                Quatity = Price = TrnQuantity = "0";
            }
        }

        private void rdChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (IsLoadData == true) return;

            cboLoaiVang.SelectedIndex = 0;
            cboLoaiVang.Enabled = rdChuyen.Checked;
            txtGoldAge.Enabled = rdChuyen.Checked;
            txtGoldWeight.Enabled = rdChuyen.Checked;
            txtGoldAgeChange.Enabled = rdChuyen.Checked;
            txtGoldAge.Text = "0";
            txtGoldAgeChange.Text = "0";

            if (rdChuyen.Checked)
            {
                //Convert_Amount = Balance;
                //Balance = "0";
                cboLoaiVang.Focus();
            }
            else
            {
                Balance = Convert_Amount;
                Convert_Amount = "0";
            }
        }

        private void rdGhiNo_CheckedChanged(object sender, EventArgs e)
        {
            if (IsLoadData == true) return;
            if (rdGhiNo.Checked)
            {
                fn_Refresh();
            }
        }

        private void txtSoLuong_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!txtSoLuong.Enabled || String.IsNullOrEmpty(txtSoLuong.Text)) return;

                Decimal d = Decimal.Parse(Quatity);
                Decimal dBalance = 0;
                Decimal dTrnQuantity = String.IsNullOrEmpty(TrnQuantity) == true ? 0 : Decimal.Parse(TrnQuantity);

                try { dBalance = Decimal.Parse(txtCon.Text); }
                catch { }

                //Kiểm tra dữ liệu 0 < txtSoLuong < Balance
                //if (d <= Decimal.Zero)
                //{
                //    ThongBao.Show("Lỗi", "Số lượng Mua/Bán phải lớn hơn 0.", "OK", ICon.Error);
                //    txtSoLuong.Focus();
                //    return;
                //}

                //Tính lại giá trị cho txtCon
                if (dBalance + dTrnQuantity < 0)
                {
                    Balance = ((Decimal)(d + (dBalance + dTrnQuantity))).ToString();
                    TrnQuantity = ((Decimal)(-d)).ToString();
                }
                else if (dBalance + dTrnQuantity > 0)
                {
                    Balance = ((Decimal)((dBalance + dTrnQuantity) - d)).ToString();
                    TrnQuantity = d.ToString();
                }
            }
            catch
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin Số lượng Mua/Bán.", "OK", ICon.Error);
                txtSoLuong.Focus();
                return;
            }
        }

        private void txtGia_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!txtGia.Enabled || String.IsNullOrEmpty(txtGia.Text)) return;

                Decimal d = Decimal.Parse(txtGia.Text);

                if (d < Decimal.Zero)
                {
                    ThongBao.Show("Lỗi", "Giá Mua/Bán phải lớn hơn 0.", "OK", ICon.Error);
                    txtGia.Focus();
                    return;
                }
            }
            catch
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin giá Mua/Bán.", "OK", ICon.Error);
                txtGia.Focus();
                return;
            }
        }

        private void fn_EnableControl()
        {
            if (rdChuyen.Checked)
            {
                cboLoaiVang.Enabled = true;
                txtGoldAge.Enabled = true;
                txtGoldAgeChange.Enabled = true;
            }

            if (rdMuaBan.Checked)
            {
                txtSoLuong.Enabled = true;
                txtGia.Enabled = true;
            }
            rdChuyen.Enabled = (decimal.Parse(txtCon.EditValue.ToString()) < 0 && cboLoaiVang.Properties.Items.Count > 1);
        }

        private void fn_LoadDataToForm()
        {
            this.Enabled = AllowChange;
            /* Phong Rem ngay 30-04.2011
            if (isDebit)
            {
                if (Decimal.Parse(Balance) >= 0)
                {
                    rdMuaBan.Text = "Bán";
                    BuyOrSell = "S";
                }
                else
                {
                    rdMuaBan.Text = "Mua";
                    BuyOrSell = "B";
                }
            }

            if (isConvert)
            {
                if (Decimal.Parse(Convert_Amount) >= 0)
                {
                    rdMuaBan.Text = "Bán";
                    BuyOrSell = "S";
                }
                else
                {
                    rdMuaBan.Text = "Mua";
                    BuyOrSell = "B";
                }
            }

            if (rdMuaBan.Checked)
            {
                rdMuaBan.Text = BuyOrSell == "B" ? "Mua" : "Bán";
                TrnQuantity = txtSoLuong.Text;
            }
            end rem*/

            if (BuyOrSell == "" || BuyOrSell == null)
            {
                if (Decimal.Parse(Balance) >= 0)
                {
                    rdMuaBan.Text = "Bán";
                    BuyOrSell = "S";
                }
                else
                {
                    rdMuaBan.Text = "Mua";
                    BuyOrSell = "B";
                }
            }
            else
            {
                if (Decimal.Parse(Balance) > 0)
                {
                    BuyOrSell = "S";
                }
                else if (Decimal.Parse(Balance) == 0)
                {

                }
                else
                {
                    BuyOrSell = "B";
                }
                rdMuaBan.Text = BuyOrSell == "S" ? "Bán" : "Mua";
            }
            if (rdMuaBan.Checked)
            {
                TrnQuantity = txtSoLuong.Text;
            }
            cboLoaiVang.SelectedIndex = Functions.GetSelectedIndexCombo(Convert_GoldCode, cboLoaiVang, 0);
        }

        private void cboLoaiVang_SelectedIndexChanged(object sender, EventArgs e)
        {
            Convert_GoldCode = ((ItemList)cboLoaiVang.SelectedItem).ID;
        }

        private void ucPOMaster_Load(object sender, EventArgs e)
        {
            fn_LoadDataToForm();
            fn_EnableControl();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataSet dsPrdt = new DataSet();
            DataSet dsGld = new DataSet();
            GTotalWeight = "0";
            DTotalWeight = "0";
            
            //Edited By Son Nguyen - 10/11/2011

            if (!String.IsNullOrEmpty(ProductPOID))
            {
                //dsPrdt = clsCommon.ExecuteDatasetSP("[TRN_PO_PRODUCT_Get]", ProductPOID);
                dsPrdt = clsCommon.ExecuteDatasetSP("[TRN_PO_PRODUCT_DT_Get]", ProductPOID, GoldCode);
                if (dsPrdt.Tables.Count > 0 && dsPrdt.Tables[0].Rows.Count > 0)
                {
                    //GTotalWeight = String.IsNullOrEmpty(dsPrdt.Tables[0].Rows[0]["Total_GoldWeight"].ToString()) ? "0" : dsPrdt.Tables[0].Rows[0]["Total_GoldWeight"].ToString();
                    GTotalWeight = dsPrdt.Tables[0].Rows[0]["Total_GoldWeight"].ToString();
                }
            }

            if (!String.IsNullOrEmpty(GoldCode))
            {
                dsGld = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_Lst]", "", "", "", CustID, "", GoldCode, "", "W", "");
                if (dsGld.Tables.Count > 0 && dsGld.Tables[0].Rows.Count > 0)
                {
                    GoldPOID = dsGld.Tables[0].Rows[0]["GoldPOID"].ToString();
                    DTotalWeight = String.IsNullOrEmpty(dsGld.Tables[0].Rows[0]["Total_GoldWeightChange"].ToString()) ? "0" : dsGld.Tables[0].Rows[0]["Total_GoldWeightChange"].ToString();
                }
                else
                {
                    GoldPOID = "";
                    DTotalWeight = "0"; 
                }
            }

            try
            {
                //Balance = isConvert == true ? "0" : ((Decimal)(Decimal.Parse(GTotalWeight) - Decimal.Parse(DTotalWeight) + Decimal.Parse(Debt))).ToString();
                if (isConvert)  //Chuyen
                {
                    //Balance = "0";
                    Balance = (decimal.Parse(txtHang.Text) - decimal.Parse(txtDe.Text) + decimal.Parse(txtNo.Text) + decimal.Parse(Convert_Amount.ToString())).ToString();
                }
                else if (isDebit) // ghi no
                {
                    Balance = (decimal.Parse(txtHang.Text) - decimal.Parse(txtDe.Text) + decimal.Parse(txtNo.Text) + decimal.Parse(Convert_Amount.ToString())).ToString();
                    //Balance = ((Decimal)(Decimal.Parse(GTotalWeight) - Decimal.Parse(DTotalWeight) + Decimal.Parse(Debt))).ToString();
                }
                else //Mua ban
                {
                    if (BuyOrSell == "B") //Mua
                    {
                        Balance = ((Decimal)(Decimal.Parse(GTotalWeight) - Decimal.Parse(DTotalWeight) + Decimal.Parse(Debt) + Decimal.Parse(Quatity))).ToString();
                    }
                    else
                    {
                        Balance = ((Decimal)(Decimal.Parse(GTotalWeight) - Decimal.Parse(DTotalWeight) + Decimal.Parse(Debt) - Decimal.Parse(Quatity))).ToString();
                    }
                }
            }
            catch
            { Balance = "0"; }

            fn_LoadDataToForm();
        }

        private void txtCon_EditValueChanged(object sender, EventArgs e)
        {
            if (!rdMuaBan.Checked)
                rdChuyen.Enabled = (decimal.Parse(txtCon.EditValue.ToString()) < 0 && cboLoaiVang.Properties.Items.Count > 1);
        }
    #endregion

        private void txtGia_EditValueChanged(object sender, EventArgs e)
        {
            decimal dSoLuong = decimal.Parse(txtSoLuong.Text);

            decimal dGia;
            try { dGia = decimal.Parse(txtGia.Text); }
            catch { dGia = 0; }

            ThanhTien = ((decimal)(Math.Round(dSoLuong * dGia * 10 / 1000))).ToString();
        }

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            decimal dSoLuong = decimal.Parse(txtSoLuong.Text);

            decimal dGia;
            try { dGia = decimal.Parse(txtGia.Text); }
            catch { dGia = 0; }

            ThanhTien = ((decimal)(Math.Round(dSoLuong * dGia * 10 / 1000))).ToString();
        }

        private void rdChuyen_Click(object sender, EventArgs e)
        {
            if (rdChuyen.Checked)
            {
                rdChuyen.Checked = false;
                fn_Refresh();
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Convert_Amount = txtGoldWeight.EditValue.ToString();
            Balance = (decimal.Parse(txtHang.Text) - decimal.Parse(txtDe.Text) + decimal.Parse(txtNo.Text) + decimal.Parse(Convert_Amount.ToString())).ToString();
        }

     
    }
}
