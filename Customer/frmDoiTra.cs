using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using GoldRT.Customer.Controls;
using Messages;

namespace GoldRT
{
    public partial class frmDoiTra : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiTra()
        {
            InitializeComponent();
        }
        UserControl uc;
        private void frmDoiTra_Load(object sender, EventArgs e)
        {

        }

        private void txtBillCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (e.KeyChar == 13)
                {
                    if (string.IsNullOrEmpty(txtBillCode.Text))
                    {
                        ThongBao.Show("L?i", "Vui lòng nh?p hóa ??n c?n ??i,tr?", "OK", ICon.Error);
                        txtBillCode.Focus();
                        return;
                    }
                    if (ThongBao.Show("Thông báo", "B?n có mu?n th?c hi?n ??i tr? cho hóa ??n này", "OK", "Cancel", ICon.QuestionMark) == DialogResult.OK)
                    {
                       
                        ds = clsCommon.ExecuteDatasetSP("Get_TrnType_BillCode",txtBillCode.Text);
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                        {
                            string strType=ds.Tables[0].Rows[0]["TrnType"].ToString();
                            if (!string.IsNullOrEmpty(strType))
                            {
                                uc=null;
                                switch (strType)
                                {
                                    case "SRT":
                                        //uc = new ucBuySell_DT(txtBillCode.Text);
                                        break;

                                }
                            }
                            if (uc != null)
                            {
                                pnlDT.Controls.Clear();
                                pnlDT.Controls.Add(uc);
                                uc.Dock = DockStyle.Fill;
                            }
                        }
                    }
                    else
                        return;
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("L?i", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
            }
        }
    }
}