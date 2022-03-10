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
    public partial class frmRTChangeProduct : DevExpress.XtraEditors.XtraForm
    {
        
        
        public frmRTChangeProduct()
        {
            InitializeComponent();
        }
        string strID, strBillCode,status,strTrnCode;
        decimal dMoneyBill=0;
        ucSRTChangeProduct uc;
        public frmRTChangeProduct(string _strID, string _BillCode,string _status,string _strTrnCode,decimal _dMoneyBill)
        {
            InitializeComponent();
            strID = _strID;
            strBillCode=_BillCode;
            status = _status;
            strTrnCode = _strTrnCode;
            dMoneyBill = _dMoneyBill;

        }

        private void frmRTChangeProduct_Load(object sender, EventArgs e)
        {
            txtBillCode.Text = strBillCode;
            txtPayMount.EditValue = dMoneyBill;
            if (status != "P")
                ThongBao.Show("Lỗi","Không thể đổi trả hóa đơn lưu tạm","OK",ICon.Error);
            if (strTrnCode == "SRT"||strTrnCode=="CRT")
                fn_loadwithtrncode();
            else
                ThongBao.Show("Lỗi", "Hóa đơn này không thể đổi trả", "OK", ICon.Error);

        }
        public void MoneyBill_DT(decimal dTien,int dSMDT)
        {
            txtPayAmount_After.EditValue = dTien;
            txtSMDT.EditValue = dSMDT;
            txtPay.EditValue =decimal.Parse(txtPayMount.EditValue.ToString()) - decimal.Parse(txtPayAmount_After.EditValue.ToString());
        }
        private void fn_loadwithtrncode()
        {
              uc=null;
            switch (strTrnCode)
            {
                  
                case "SRT":
                    uc = new ucSRTChangeProduct(strBillCode);
                    uc.MyGetData = new ucSRTChangeProduct.GetString(MoneyBill_DT);
                    break;
                case "CRT":
                    break;
                default:
                    break;
            }
            if (uc != null)
            {
                pnlChangeProdcut.Controls.Clear();
                pnlChangeProdcut.Controls.Add(uc);
                pnlChangeProdcut.Dock = DockStyle.Fill;
            }
        }

        private void btnChangeProduct_OK_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(txtSMDT.EditValue.ToString()) <= 0)
            {
                ThongBao.Show("Lỗi","Danh sách hàng đổi trả chưa có món nào","OK",ICon.Error);
                return;
            }
           
            DataSet ds = new DataSet();
            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có muốn đổi thực hiện đổi trả cho hóa đơn này", "OK", "Cancel", ICon.Information) == DialogResult.OK)
                {
                    //Hủy thanh toán của HD
                    ds = clsCommon.ExecuteDatasetSP("[T_TILL_TXN_Del]",strID , strTrnCode);
                   // uc.btnSave_Click();
                    uc.btnPayment_Click(sender,e);

                  
                }
            }
            catch
            { }
            finally
            { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void InHD_SRT()
        {
 
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            switch(strTrnCode)
            {
                case "SRT":
                    uc.btnPrint_Click(sender,e);
                    break;
                
            }
        }
    }
}