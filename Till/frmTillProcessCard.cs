using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmTillProcessCard : DevExpress.XtraEditors.XtraForm
    {
        frmRTBuySell frm;
        frmRTChange frm1;
        private string strID = null;
        public string strTillTXNID = null;
        public string TypeTrade=null;
        public frmTillProcessCard(string mID,string mTillTxnID,string mTypeTrade)
        {
            strID = mID;
            InitializeComponent();
            strTillTXNID = mTillTxnID;
            TypeTrade = mTypeTrade;
            LoadControl();
         
        }

        private void LoadControl()
        {
            DataSet ds = new DataSet();
            decimal totalAmout;
            switch (TypeTrade)
            {         
                case "SRT":
                    
                    ds = clsCommon.ExecuteDatasetSP("TRN_RT_BUYSELL_Get", strID);
                    
                    totalAmout = decimal.Parse(ds.Tables[0].Rows[0]["PayAmount"].ToString());
                    textEdit1.Text = totalAmout.ToString("#,##0");
                    txtCardAmount.Text = totalAmout.ToString("#,##0");
                    break;
                case "CRT":         
                    ds = clsCommon.ExecuteDatasetSP("TRN_RT_CHANGE_Get", strID);        
                    totalAmout = decimal.Parse(ds.Tables[0].Rows[0]["PayAmount"].ToString());
                    textEdit1.Text = totalAmout.ToString("#,##0");
                    txtCardAmount.Text = totalAmout.ToString("#,##0");
                    break;

            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private bool ValidateData()
        {
            if (txtIDCard.Text == "")
            {
                ThongBao.Show("Thông báo", "Vui lòng nhập ID thẻ.", "OK", ICon.Warning);
                txtIDCard.Focus();
                this.DialogResult = DialogResult.None;
                return false;
            }
            if (txtBankName.Text == "")
            {
                ThongBao.Show("Thông báo", "Vui lòng nhập ngân hàng.", "OK", ICon.Warning);
                txtBankName.Focus();
                this.DialogResult = DialogResult.None;
                return false;
            }
            if (txtHoTenChuThe.Text == "")
            {
                ThongBao.Show("Thông báo", "Vui lòng nhập tên chủ,thẻ.", "OK", ICon.Warning);
                txtHoTenChuThe.Focus();
                this.DialogResult = DialogResult.None;
                return false;
            }
            if (txtCardAmount.Text == "0" || txtCardAmount.Text == "")
            {
                ThongBao.Show("Thông báo", "Vui lòng nhập số tiền trả thẻ.", "OK", ICon.Warning);
                txtCardAmount.Focus();
                this.DialogResult = DialogResult.None;
                return false;
            }
            return true;
        }            

        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            
           
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet dsN = new DataSet();
            string strTillID,  strProductIDs = "", strCardAmounts = "";
            string strErrorCode = "";
            decimal _dCardAmount = 0;
             string   strBankName = "", strHoTenChuThe = "", strNgayHetHan = "";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                
                strTillID = clsSystem.TillID;
                if (ValidateData())
                {
                    if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                    {

                        _dCardAmount = Convert.ToDecimal(txtCardAmount.EditValue.ToString());
                        strBankName = txtBankName.Text;
                        strHoTenChuThe = txtHoTenChuThe.Text;
                        strNgayHetHan = txtOutDate.Text;
                        switch (TypeTrade)
                        {
                            case "SRT":
                                ds1 = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYSELL_Complete]", strID, clsSystem.UserID);
                                strTillTXNID = ds1.Tables[0].Rows[0]["TillTxnID"].ToString();
                                 
                                dsN = clsCommon.ExecuteDatasetSP("TRN_RT_BUYSELL_SELL_LstM", strID);

                                foreach (DataRow row in dsN.Tables[0].Rows)
                                {
                                    if (_dCardAmount <= Convert.ToDecimal(row["SellAmount"].ToString()))
                                    {
                                        strProductIDs += row["ProductID"].ToString() + "@";
                                        strCardAmounts += _dCardAmount.ToString() + "@";
                                        break;
                                    }
                                    else
                                    {
                                        strProductIDs += row["ProductID"].ToString() + "@";
                                        strCardAmounts += row["SellAmount"].ToString() + "@";
                                        _dCardAmount -= Convert.ToDecimal(row["SellAmount"].ToString());
                                    }
                                }
                                strProductIDs = strProductIDs.Substring(0, strProductIDs.Length - 1);
                                strCardAmounts = strCardAmounts.Substring(0, strCardAmounts.Length - 1);
                                ds = clsCommon.ExecuteDatasetSP("T_TILL_CARDPAY_Ins", strTillID, strTillTXNID,
                                    txtIDCard.Text, Convert.ToDecimal(txtCardAmount.Text),strBankName,strHoTenChuThe,strNgayHetHan, strID, strProductIDs, strCardAmounts);
                                break;
                            case "CRT":
                                ds1 = clsCommon.ExecuteDatasetSP("[TRN_RT_CHANGE_Complete]", strID, clsSystem.UserID);
                                strTillTXNID = ds1.Tables[0].Rows[0]["TillTxnID"].ToString();
                                ds = clsCommon.ExecuteDatasetSP("T_TILL_CARDPAY_Ins", strTillID, strTillTXNID,
                                    txtIDCard.Text, Convert.ToDecimal(txtCardAmount.Text), strBankName, strHoTenChuThe, strNgayHetHan, strID, null, null);
                                break;
                        }
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            strErrorCode = ds.Tables[0].Rows[0]["Result"].ToString();
                            if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                            {
                                ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString() + " [" + ds.Tables[0].Rows[0]["ErrorCode"].ToString() + "]", "OK", ICon.Error);
                            }
                            else
                            {
                                //ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                                this.Close();
                                //fn_LoadDataToGrid();
                            }
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                ds.Dispose();
                ds1.Dispose();
                dsN.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", "Hàm btnProcess_Click: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                //fn_LoadDataToGrid();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void txtCardAmount_EditValueChanged(object sender, System.EventArgs e)
        {
            //txtCardAmount
            if(txtCardAmount.EditValue.ToString() == "")
                txtCardAmount.EditValue = "0";
            if (decimal.Parse(txtCardAmount.EditValue.ToString()) > decimal.Parse(textEdit1.EditValue.ToString()) ||
                decimal.Parse(txtCardAmount.Text) > decimal.Parse(textEdit1.EditValue.ToString()))
            {
                txtCardAmount.Text = textEdit1.EditValue.ToString();
                txtCardAmount.EditValue = textEdit1.EditValue;                                
            }
            txtCashAmount.EditValue = (decimal.Parse(textEdit1.EditValue.ToString()) - decimal.Parse(txtCardAmount.EditValue.ToString())).ToString();
        }

        private void frmTillProcessCard_Load(object sender, EventArgs e)
        {

        }
    }
}