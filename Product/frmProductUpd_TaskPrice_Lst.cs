using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GoldRT
{
    public partial class frmProductUpd_TaskPrice_Lst : DevExpress.XtraEditors.XtraForm
    {
        frmProductUpd_TaskPrice frm;
        public frmProductUpd_TaskPrice_Lst()
        {
            InitializeComponent();
        }
        public frmProductUpd_TaskPrice_Lst(frmProductUpd_TaskPrice _frm)
        {
            InitializeComponent();
            frm = _frm;
        }
        private void fn_LoadDataToComboo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
                Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
                ds.Clear();

                ds = clsCommon.LoadComboSP("T_SUPPLIER", "");
                Functions.BindDropDownList(cboNCC, ds, "SupplierName", "SupplierID", "", true);
                ds.Clear();
            }
            catch
            {
            }
            finally
            {
                ds.Dispose();
            }
        }
        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_UPDATE_TASKPRICE_List]", dtpTuNgay.DateTime.ToString("MM/dd/yyyy"), dtpDenNgay.DateTime.ToString("MM/dd/yyyy"), ((ItemList)cboProductGroup.SelectedItem).ID, ((ItemList)cboNCC.SelectedItem).ID);
               gridControl.DataSource= ds.Tables[0];
            }
            catch
            { }
            finally { ds.Dispose(); }
        }
        private void frmProductUpd_TaskPrice_Lst_Load(object sender, EventArgs e)
        {
            dtpTuNgay.DateTime = DateTime.Now;
            dtpDenNgay.DateTime = DateTime.Now;
            fn_LoadDataToComboo();
            fn_LoadDataToGrid();
        }
        private void grdDanhSach_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (e.Button == MouseButtons.Left)
                {
                    btnXemChiTiet_Click(null, null);
                }
            }
        }

        private void grdDanhSach_DoubleClick(object sender, EventArgs e)
        {
            btnXemChiTiet_Click(sender, e);
        }
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                string strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();

                frm.fn_LoadDataToForm(strID);
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        
    }
}