using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmPOProduct_Dtl : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtProduct = new DataTable();
        public string strID = "";
        private string strProductCode = "";

        public frmPOProduct_Dtl(string _ID, string _StrProductCode)
        {
            InitializeComponent();
            this.strID = _ID;
            this.strProductCode = _StrProductCode;
        }

        private void fn_loadDataToForm()
        {
            DataSet ds = new DataSet();
            string strCustID = "", strGoldCode = "";

            try
            {
                ds = clsCommon.ExecuteDatasetSP("TRN_PO_PRODUCT_Get", strID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    strID = ds.Tables[0].Rows[0]["ProductPOID"].ToString();
                    strCustID = ds.Tables[0].Rows[0]["CustID"].ToString();
                    strGoldCode = ds.Tables[0].Rows[0]["GoldCode"].ToString();
                    cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(strCustID, cboCust, 0);
                    cboGoldType.SelectedIndex = Functions.GetSelectedIndexCombo(strGoldCode, cboGoldType, 0);
                    txtTotal_TotalWeight.Text = ds.Tables[0].Rows[0]["Total_Weight"].ToString();
                    txtTotal_DiamondWeight.Text = ds.Tables[0].Rows[0]["Total_Weight_Diamond"].ToString();
                    txtTotal_TaskPrice.Text = ds.Tables[0].Rows[0]["Total_TaskPrice"].ToString();
                    txtTotal_Stamp.Text = ds.Tables[0].Rows[0]["Total_Weight_Stamp"].ToString();
                    txtToal_GoldWeight.Text = ds.Tables[0].Rows[0]["Total_GoldWeight"].ToString();
                    //cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["Status"].ToString(), cboStatus, 0);
                    grdProduct.DataSource = ds.Tables[1];
                    cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["Status"].ToString(), cboStatus, 0);

                    btnDel.Enabled = btnComplete.Enabled =
                                     (ds.Tables[0].Rows[0]["Status"].ToString() == "P" &&
                                      clsSystem.GetCurrentAccountType() == AccountType.SuperAccount);

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

        private void f_loadDataToCombo()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.LoadComboSP("I_CUSTOMER", "NOTWALKINCUST");
                Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "", true);
                ds.Clear();

                ds = clsCommon.LoadComboSP("I_GOLD_PRICEUINT", "L");
                Functions.BindDropDownList(cboGoldType, ds, "GoldDesc", "GoldCode", "", true);
                ds.Clear();

                ds = clsCommon.LoadComboSP("T_STATUS", "PO");
                Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
                ds.Clear();

            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        /// <summary>
        /// Hàm lấy giá trị Summary trên lưới. Khỏi tính toán lại.
        /// </summary>
        private void fn_calcCustomSummary()
        {
            decimal dTotal_TaskPrice = 0;
            decimal dTotal_DiamondWeight = 0;
            decimal dTotal_TotalWeight = 0;
            decimal dTotal_StampWeight = 0;

            if (grvProduct.Columns["TaskPrice"].SummaryItem.SummaryValue != null)
                decimal.TryParse(grvProduct.Columns["TaskPrice"].SummaryItem.SummaryValue.ToString(), out dTotal_TaskPrice);
            if (grvProduct.Columns["DiamondWeight"].SummaryItem.SummaryValue != null)
                decimal.TryParse(grvProduct.Columns["DiamondWeight"].SummaryItem.SummaryValue.ToString(), out dTotal_DiamondWeight);
            if (grvProduct.Columns["TotalWeight"].SummaryItem.SummaryValue != null)
                decimal.TryParse(grvProduct.Columns["TotalWeight"].SummaryItem.SummaryValue.ToString(), out dTotal_TotalWeight);
            if (grvProduct.Columns["StampWeight"].SummaryItem.SummaryValue != null)
                decimal.TryParse(grvProduct.Columns["StampWeight"].SummaryItem.SummaryValue.ToString(), out dTotal_StampWeight);

            //Trọng lượng luôn hột + Tem
            decimal dTotal_Weight_Stamp = dTotal_TotalWeight + dTotal_StampWeight;
            
            //TL vàng
            decimal dTotal_GoldWeight = dTotal_TotalWeight - dTotal_DiamondWeight;

            //Gán các giá trị cần để Insert/Update vào các controls
            txtTotal_TotalWeight.EditValue = dTotal_TotalWeight;
            txtTotal_DiamondWeight.EditValue = dTotal_DiamondWeight;
            txtTotal_Weight_Stamp.EditValue = dTotal_Weight_Stamp;
            txtTotal_Stamp.EditValue = dTotal_StampWeight;
            txtTotal_TaskPrice.EditValue = dTotal_TaskPrice;
            txtToal_GoldWeight.EditValue = dTotal_GoldWeight;
        }

        private void frmPOProduct_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            f_loadDataToCombo();
            fn_loadDataToForm();

            cboCust.Focus();
            for (int i = 0; i < grvProduct.RowCount; i++)
            {

                if (grvProduct.GetRowCellValue(i, "ProductCode").ToString().ToUpper() == strProductCode)
                {
                    //grvProduct.TopRowIndex = i;
                    //grvProduct.FocusedRowHandle = i;
                    grvProduct.ClearSelection();
                    grvProduct.SelectRow(i);
                }

            }
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strCustName = "";
            string strCustAddress = "";

            if (cboCust.SelectedIndex != 0)
            {
                DataSet ds = new DataSet();
                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_Get]", 
                        ((ItemList)cboCust.SelectedItem).ID);
                    strCustName = ds.Tables[0].Rows[0]["CustName"].ToString();
                    strCustAddress = ds.Tables[0].Rows[0]["Address"].ToString();
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

            txtCustName.Text = strCustName;
            txtCustAddress.Text = strCustAddress;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_PRODUCT_Del]", strID);
                    if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                    else
                    {
                        ThongBao.Show("Thông báo", "Xóa toa hàng thành công.", "OK", ICon.Information);
                        this.Close();
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
            string strStatus = "";
            DataRow row;

            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    strStatus = ((ItemList)cboStatus.SelectedItem).ID == "P" ? "W" : "P";

                    ds = clsCommon.ExecuteDatasetSP("TRN_PO_PRODUCT_ChangeStatus", strID, strStatus);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);                        
                        fn_loadDataToForm();
                        btnDel.Enabled = btnComplete.Enabled = false;
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
    }
}