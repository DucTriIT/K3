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
    public partial class frmGenCode : DevExpress.XtraEditors.XtraForm
    {
        string strID;

        public frmGenCode(string _ID)
        {
            InitializeComponent();
            strID = _ID;
        }

        private void fn_LoadDataToListBox()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_DT_Lst]", strID, "", "ProductCode");
                lstProductCode.DisplayMember = "ProductCode";
                lstProductCode.ValueMember = "ProductCode";
                lstProductCode.DataSource = ds.Tables[0];
                
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToListBox: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds = null;
            }
        }

        private void btnPrintStamp_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strProductCodes = "";

            try
            {
                for (int i = 0; i < lstProductCode.ItemCount; i++)
                {
                    strProductCodes += lstProductCode.GetItemValue(i).ToString() + "@";
                }

                ds = clsCommon.ExecuteDatasetSP("rptPrintStamp", strProductCodes,"PRODUCTIN");
                Functions.fn_ShowReport(ds, "rptPrintStamp.rpt", "", "");
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm btnPrintStamp_Click: " + ex.Message, "OK", ICon.Error);
                return;
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

        private void frmGenCode_Load(object sender, EventArgs e)
        {
            fn_LoadDataToListBox();
        }
    }
}