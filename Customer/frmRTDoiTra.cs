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
    public partial class frmRTDoiTra : DevExpress.XtraEditors.XtraForm
    {
        UserControl uc;
        string strID;
        bool bIsLoading;
        public frmRTDoiTra()
        {
            InitializeComponent();
        }

        private void frmRTDoiTra_Load(object sender, EventArgs e)
        {

        }
      

        private void txtBillCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataSet ds = new DataSet();
            if (e.KeyChar == 13)
            {
                ds = clsCommon.ExecuteDatasetSP("[Get_TrnType_BillCode]",txtBillCode.Text);
                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TrnType"].ToString()))
                    {
                        string Type = ds.Tables[0].Rows[0]["TrnType"].ToString();
                        ds.Clear();
                        switch (Type)
                        {
                            case "SRT":
                                ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYSELL_GetBillCode]",txtBillCode.Text.Trim());
                                //uc = new ucRTBUYSELL(txtBillCode.Text);
                                break;
                           
                        }
                        if (uc != null)
                        {
                            pn1.Controls.Clear();
                            pn1.Controls.Add(uc);
                            uc.Dock = DockStyle.Fill;

                        }
                            
                    }
                }
            }
        }
       
    }
}