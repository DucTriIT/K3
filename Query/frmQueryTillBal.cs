using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmQueryTillBal : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryTillBal()
        {
            InitializeComponent();
        }

        private void frmQueryTillBal_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToCombo();
            if (clsSystem.TillID != "")
            {
                cboTill.SelectedIndex = Functions.GetSelectedIndexCombo(clsSystem.TillID, cboTill, 0);
            }
            fn_LoadDataToGrid();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("T_TILL", "");
            Functions.BindDropDownList(cboTill, ds, "TillName", "TillID", "", false);
            ds.Clear();

            ds.Dispose();
        }


        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            string strTillID = "";

            strTillID = ((ItemList)cboTill.SelectedItem).ID;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_TILL_QueryBal", strTillID);

                if (ds.Tables.Count > 0)
                {
                    grdControl.DataSource = ds.Tables[0];
                    
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strDate = "";
            string strTillID = "", strTillName = "";
            string strParams, strValues;

            strDate = DateTime.Now.ToString("dd/MM/yyyy");

            strTillID = clsSystem.GetCurrentAccountType() == AccountType.SuperAccount
                            ? ((ItemList) cboTill.SelectedItem).ID
                            : clsSystem.TillID;
            strTillName = clsSystem.GetCurrentAccountType() == AccountType.SuperAccount
                              ? ((ItemList) cboTill.SelectedItem).Value
                              : clsSystem.TillName;

            strParams = "TillName@Ngay";
            strValues = strTillName + "@" + strDate;

            ds = clsCommon.ExecuteDatasetSP("rptBC105", strTillID, strDate);            
            if(clsSystem.GetCurrentAccountType() == AccountType.SuperAccount)
            {
                Functions.fn_ShowReport_AndImage(ds, "rptBC105.rpt", strParams, strValues);
            }
            else
            {
                Functions.fn_ShowReport_AndImage(ds, "rptBC105_1.rpt", strParams, strValues);
            }
            
            
        }
    }
}