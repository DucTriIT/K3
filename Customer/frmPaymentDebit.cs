

using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmPaymentDebit : DevExpress.XtraEditors.XtraForm
    {
        private string strCustID = "";
        public frmPaymentDebit()
        {
            InitializeComponent();
        }

        public frmPaymentDebit(string _strCustID)
        {
            InitializeComponent();
            strCustID = _strCustID;
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
          
            ds = clsCommon.LoadComboSP("I_CUSTOMER", "");
            Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "0", true);
            ds.Clear();

            ds.Dispose();
        }

        private void btnCapNhat_Click(object sender, System.EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_PayDebit", ((ItemList) cboCust.SelectedItem).ID,
                                                txtTienKhachTra.EditValue);
                if (ds.Tables[1].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Thanh toán thành công", "OK", ICon.Information);
                    txtOldDebit.EditValue = txtTienKhachTra.EditValue = txtNewDebit.EditValue;
                    txtNewDebit.EditValue = 0;
                }
                else
                {
                    ThongBao.Show("Lỗi", "Có lỗi trong quá trình cập nhật dữ liệu", "OK", ICon.Error);
                }

            }
            catch (Exception ex)
            {
                ThongBao.Show("Thông báo", ex.Source, "OK", ICon.Error);
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void txtTienKhachTra_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dTienKhachTra =
                Convert.ToDecimal(e.NewValue.ToString() == ""
                                      ? "0"
                                      : e.NewValue.ToString());
            decimal dOldDebit =
                Convert.ToDecimal(txtOldDebit.EditValue.ToString() == ""
                                      ? "0"
                                      : txtOldDebit.EditValue.ToString());
            if (dTienKhachTra > dOldDebit || dTienKhachTra < 0)
            {
                e.Cancel = true;
                return;
            }
            txtNewDebit.EditValue = dOldDebit - dTienKhachTra;
        }

        private void frmPaymentDebit_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            if(strCustID != "")
            {                
                cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(strCustID, cboCust, 0);
            }
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_GetDebit", ((ItemList)cboCust.SelectedItem).ID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtOldDebit.EditValue = ds.Tables[0].Rows[0]["Debt_Bal"];
                    txtTienKhachTra.EditValue = txtOldDebit.EditValue;
                }
            }
            catch (Exception exception)
            {
                ThongBao.Show("Thông báo", exception.Source, "OK", ICon.Error);
            }
        }

        private void txtTienKhachTra_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
                btnCapNhat_Click(sender, e);
        }
    }
}