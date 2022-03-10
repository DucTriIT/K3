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

namespace GoldRT
{
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm
    {

    #region Private Variables
        string strID = String.Empty;
    #endregion

    #region Public Functions
        public frmCustomer()
        {
            InitializeComponent();
        }
    #endregion

    #region Private Functions
        //private void fn_EnableControl(bool bEditMode)
        //{
        //    txtTenKH.Enabled = bEditMode;
        //    txtDienThoai.Enabled = bEditMode;
        //    txtDiaChi.Enabled = bEditMode;
        //    txtGhiChu.Enabled = bEditMode;
        //    chkActive.Enabled = bEditMode;

        //    btnThem.Enabled = !bEditMode;
        //    btnSua.Enabled = !bEditMode;
        //    btnXoa.Enabled = !bEditMode;
        //    btnCapNhat.Enabled = bEditMode;
        //}

        //private void fn_LoadDefault()
        //{
        //    strID = String.Empty;
        //    lblMaHang.Text = "Tự động";
        //    txtTenKH.Text = String.Empty;
        //    txtDienThoai.Text = String.Empty;
        //    txtDiaChi.Text = String.Empty;
        //    txtGhiChu.Text = String.Empty;
        //    chkActive.Checked = true;
        //    txtTenKH.Focus();
        //}

        //private bool fn_CheckValidate()
        //{
        //    if (String.IsNullOrEmpty(txtTenKH.Text))
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng nhập vào tên khách hàng", "OK", ICon.Error);
        //        txtTenKH.Focus();
        //        return false;
        //    }
        //    return true;
        //}

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("IDPhong").ToString();
               // lblMaHang.Text = grdDanhSach.GetFocusedRowCellValue("CustCode").ToString();
               // txtTenKH.Text = grdDanhSach.GetFocusedRowCellValue("CustName").ToString();
               // txtDiaChi.Text = grdDanhSach.GetFocusedRowCellValue("Address").ToString();
              //  txtDienThoai.Text = grdDanhSach.GetFocusedRowCellValue("Phone").ToString();
               // txtGhiChu.Text = grdDanhSach.GetFocusedRowCellValue("Notes").ToString();
               // chkActive.Checked = grdDanhSach.GetFocusedRowCellValue("Active").ToString() == "1" ? true : false;
            }
        }

        public void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_Phong_Lst]");

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
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
           // fn_EnableControl(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmOptionCustomer frm = new frmOptionCustomer(this, "");
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle < 0)
            {
                ThongBao.Show("Thông tin", "Không có dữ liệu để sửa.", "OK", ICon.Warning);
                return;
            }
            frmOptionCustomer frm = new frmOptionCustomer(this, strID);
            frm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá phòng này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_Phong_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDataToGrid();
                       //fn_EnableControl(false);
                        fn_GetFocusedRowValue();
                        grdControl.Enabled = true;
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", "Không thể xóa phòng này.\nPhòng này đang mở", "OK", ICon.Error);
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                    ThongBao.Show("Lỗi", "Không thể xóa phòng này.\nPhòng này đang mở. ", "OK", ICon.Error);
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

        //private void btnCapNhat_Click(object sender, EventArgs e)
        //{
        //    DataSet ds = new DataSet();


        //    if (!fn_CheckValidate()) return;

        //    this.Cursor = Cursors.WaitCursor;
        //    try
        //    {
        //        if (strID == "")
        //        {
        //            ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_Ins]", "", "", txtTenKH.Text.Trim(),
        //                txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), txtGhiChu.Text.Trim(), chkActive.Checked ? "1" : "0");
        //        }
        //        else
        //        {
        //            ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_Upd]", strID, lblMaHang.Text, txtTenKH.Text.Trim(),
        //                txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), txtGhiChu.Text.Trim(), chkActive.Checked ? "1" : "0");
        //        }

        //        if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
        //        {

        //            fn_EnableControl(false);
        //            fn_LoadDataToGrid();
        //            fn_GetFocusedRowValue();
        //            grdControl.Enabled = true;
        //        }
        //        else
        //        {
        //            ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ds.Dispose();
        //        this.Cursor = Cursors.Default;
        //        return;
        //    }
        //    finally
        //    {
        //        ds.Dispose();
        //        this.Cursor = Cursors.Default;
        //    }
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