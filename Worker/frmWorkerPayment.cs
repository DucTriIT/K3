using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Messages;

namespace GoldRT
{
    public partial class frmWorkerPayment : DevExpress.XtraEditors.XtraForm
    {
        private bool isLoading = false;
        public frmWorkerPayment()
        {
            InitializeComponent();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult  .OK)
                {
                    ds = clsCommon.ExecuteDatasetSP("TRN_WORKER_PAYMENT_Proc", 
                        ((ItemList)cboWorker.SelectedItem).ID, txtPayAmount.EditValue, 
                        DateTime.Now.ToString("dd/MM/yyyy"),
                        DateTime.Now.ToString("hh:mm:ss"),
                        clsSystem.UserID, txtNotes.Text);

                    if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Thanh toán thành công", "OK", ICon.Information);
                        this.Close();
                        //btnIn_Click(sender, null);
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Có lỗi : "+ ex.Source + " - " + ex.Message, "OK", ICon.Error);
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

        private void frmWorkerPayment_Load(object sender, EventArgs e)
        {
            isLoading = true;
            txtDebitAmount.EditValue = txtPayAmount.EditValue = txtDebitAmount.EditValue = decimal.Zero;
            fn_LoadCombo();
            isLoading = false;
        }

        #region LoadCombox

        private void fn_LoadCombo()
        {        
            DataSet ds = clsCommon.LoadComboSP("T_WORKER", "");
            Functions.BindDropDownList(cboWorker, ds, "WorkerName", "WorkerID", "", true);
            ds.Clear();

            ds.Dispose();
        }

        private void cboWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isLoading)
                return;
            if(cboWorker.SelectedIndex == -1)
            {
                txtDebitAmount.EditValue = decimal.Zero;
                txtPayAmount_EditValueChanging(sender, new ChangingEventArgs(e, txtPayAmount.EditValue));
                return;
            }
            txtPayAmount.EditValue = decimal.Zero;
            DataSet ds = clsCommon.ExecuteDatasetSP("TRN_WORKER_GetDebit", ((ItemList) cboWorker.SelectedItem).ID);
            if (ds.Tables[0].Rows.Count > 0)
                txtDebitAmount.EditValue = ds.Tables[0].Rows[0][0];
            else
                txtDebitAmount.EditValue = decimal.Zero;       
            txtPayAmount_EditValueChanging(sender, new ChangingEventArgs(e, txtPayAmount.EditValue));
        }

        private void txtPayAmount_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (isLoading)
                return;
            decimal _dDebitAmount = clsNumericFormat.Convert2Decimal(txtDebitAmount.EditValue.ToString());
            //if (_dDebitAmount < 0)
            //{
            //    txtPayAmount.EditValue = decimal.Zero;
            //    txtRemainAmount.EditValue = _dDebitAmount;
            //}
            //if (clsNumericFormat.Convert2Decimal(e.NewValue.ToString()) > _dDebitAmount)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            decimal _dRemainAmount = decimal.Zero;
            _dRemainAmount = _dDebitAmount - clsNumericFormat.Convert2Decimal(e.NewValue.ToString());
            txtRemainAmount.EditValue = _dRemainAmount;
        }

        #endregion        

        private void txtPayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnPayment_Click(sender, new EventArgs());
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            string strParams = "Tho@TienNo@TienTra@TienConLai";
            string strValues = cboWorker.Text+"@"+txtDebitAmount.EditValue+"@"+txtPayAmount.EditValue
                +"@"+txtRemainAmount.EditValue;

            Functions.fn_ShowReport(ds, "rptPrintPay.rpt", strParams, strValues);

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmRPT08 frm = new frmRPT08("rptHis", ((ItemList)cboWorker.SelectedItem).ID);
            frm.ShowDialog();
        }
    }
}