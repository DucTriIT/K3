using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Messages;
using DevExpress.XtraEditors.DXErrorProvider;

namespace GoldRT
{
    public partial class frmPOProductLst : DevExpress.XtraEditors.XtraForm
    {
        private frmPOProduct frm; 

        public frmPOProductLst()
        {
            InitializeComponent();
        }

        public frmPOProductLst(frmPOProduct frmCallForm)
        {
            frm = frmCallForm;
            InitializeComponent();
        }

        private void frmProductPOLst_Load(object sender, EventArgs e)
        {
            dtpToDate.DateTime = DateTime.Now;
            dtpFromDate.DateTime = DateTime.Now.AddDays(-15);

            fn_LoadDataToCombo();
            fn_LoadDataToGird();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fn_LoadDataToGird()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PO_PRODUCT_Lst]", "", dtpFromDate.DateTime.ToString("dd/MM/yyyy"), dtpToDate.DateTime.ToString("dd/MM/yyyy"),
                "", txtCustName.Text.Trim(), ((ItemList)cboGoldType.SelectedItem).ID, "", "", "");

                grdProductPO.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
            finally { ds.Dispose(); } 
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("I_GOLD", "G");
            Functions.BindDropDownList(cboGoldType, ds, "GoldDesc", "GoldCode", "", true);
            ds.Clear();

            ds.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGird();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (grvProductPO.SelectedRowsCount>=1)
            {
                DataRow row = grvProductPO.GetDataRow(grvProductPO.FocusedRowHandle);
                frm.strID = row["ProductPOID"].ToString();

                this.Close();
            }
        }

        private void grvProductPO_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (e.Button == MouseButtons.Left)
                {
                    btnChoose_Click(null, null);
                }
            }
        }
    }
}