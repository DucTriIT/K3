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
    public partial class frmProduct_Tranfer_Lst : DevExpress.XtraEditors.XtraForm
    {
        frmProduct_Tranfer frm;
        public frmProduct_Tranfer_Lst()
        {
            InitializeComponent();
        }
        public frmProduct_Tranfer_Lst(frmProduct_Tranfer _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_Section_Lst]", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"));
                gridControl.DataSource = ds.Tables[0];
            }
            catch
            { }
            finally
            { ds.Dispose(); }

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }
        private void fn_LoadDefault()
        {
            dtpDenNgay.DateTime = DateTime.Now;
            //dtpTuNgay.DateTime = DateTime.Now.AddDays(-15);
            dtpTuNgay.DateTime = DateTime.Now;
        }
        private void frmProduct_Tranfer_Lst_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            fn_LoadDataToGrid();
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
    }
}