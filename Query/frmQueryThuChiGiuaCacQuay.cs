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
    public partial class frmQueryThuChiGiuaCacQuay : DevExpress.XtraEditors.XtraForm
    {
        private string strID;
        public frmQueryThuChiGiuaCacQuay()
        {
            InitializeComponent();
        }

        private void frmTillInOutList_Load(object sender, EventArgs e)
        {
            this.strID = String.Empty;
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now;
            fn_LoadDataToGrid();

        }
        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_TILL_LstTransfer]", "", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"));

                if (ds.Tables.Count > 0)
                {
                    gridControl.DataSource = ds.Tables[0];
                    fn_GetFocusedRowValue();
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

        private void grdDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fn_GetFocusedRowValue();
        }
        private void fn_GetFocusedRowValue()
        {
            
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
        }

        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            btnComplete_Click(sender, e);
        }

        private void dtpTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void dtpDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!gridControl.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window. 
            //grdControl.ShowPreview();
            printableComponentLink2.CreateDocument();
            printableComponentLink2.ShowPreview(); 
        }

    }
}