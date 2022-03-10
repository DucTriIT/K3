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
    public partial class frmTransferStorage_Lst : DevExpress.XtraEditors.XtraForm
    {

        frmTransferStorage frm;
        public frmTransferStorage_Lst()
        {
            InitializeComponent();
        }
        public frmTransferStorage_Lst(frmTransferStorage _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }
        private void frmTransferStorage_Lst_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            fn_LoadDataToGrid();
        }
        
     

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_TransferStore_Lst]", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"));
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}