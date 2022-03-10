using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmCurrency : DevExpress.XtraEditors.XtraForm
    {

    #region Private Variables
        string strID = String.Empty;
    #endregion

    #region Public Functions
        public frmCurrency()
        {
            InitializeComponent();
        }
    #endregion

    #region Private Functions
        //private void fn_EnableControl(bool bEditMode)
        //{
        //    txtCcy.Enabled = bEditMode;
        //    txtCcyDesc.Enabled = bEditMode;
        //    txtNotes.Enabled = bEditMode;
        //    ckbActive.Enabled = bEditMode;

        //    btnThem.Enabled = !bEditMode;
        //    btnSua.Enabled = !bEditMode;
        //    btnXoa.Enabled = !bEditMode;
        //    btnCapNhat.Enabled = bEditMode;
        //}

        //private void fn_LoadDefault()
        //{
        //    strID = String.Empty;
        //    txtCcy.Text = String.Empty;
        //    txtCcyDesc.Text = String.Empty;
        //    txtNotes.Text = String.Empty;
        //    ckbActive.Checked = true;
        //    txtCcy.Focus();
        //}

        //private bool fn_CheckValidate()
        //{
        //    if (String.IsNullOrEmpty(txtCcy.Text))
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng nhập vào Tên loại", "OK", ICon.Error);
        //        txtCcy.Focus();
        //        return false;
        //    }
        //    return true;
        //}

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("Ccy").ToString();
              //  txtCcy.Text = grdDanhSach.GetFocusedRowCellValue("Ccy").ToString();
              //  txtCcyDesc.Text = grdDanhSach.GetFocusedRowCellValue("CcyDesc").ToString();
               // txtNotes.Text = grdDanhSach.GetFocusedRowCellValue("Notes").ToString();
               // ckbActive.Checked = grdDanhSach.GetFocusedRowCellValue("Active").ToString() == "1" ? true : false;
            }
        }

        public void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_CURRENCY_Lst]",
                    "", "", "", "", "");

                if (ds.Tables.Count > 0)
                {
                    grdControl.DataSource = ds.Tables[0];
                   // lblNumRec.Text = ds.Tables[0].Rows.Count.ToString();
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
    #endregion

    #region Event Handlers
        private void frmCurrency_Load(object sender, EventArgs e)
        {           
            this.Subtract.Visible = this.Add.Visible = clsSystem.IsHeSo;
            fn_LoadDataToGrid();
           // fn_EnableControl(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmOptionCurrency frm = new frmOptionCurrency(this, "");
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle < 0)
            {
                ThongBao.Show("Thông tin", "Không có dữ liệu để sửa.", "OK", ICon.Warning);
                return;
            }
            frmOptionCurrency frm = new frmOptionCurrency(this, strID);
            frm.ShowDialog();
            //fn_EnableControl(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_CURRENCY_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDataToGrid();
                       // fn_EnableControl(false);
                        fn_GetFocusedRowValue();
                        grdControl.Enabled = true;
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                }
            }

        }

        //private void btnHuy_Click(object sender, EventArgs e)
        //{
        //    fn_EnableControl(false);
        //    fn_GetFocusedRowValue();
        //    grdControl.Enabled = true;
        //}

       

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fn_GetFocusedRowValue();
        }
    #endregion

    }
}