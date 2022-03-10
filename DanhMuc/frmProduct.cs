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
using System.IO;

namespace GoldRT
{
    public partial class frmProduct : DevExpress.XtraEditors.XtraForm
    {

    #region Private Variables
        string strID = String.Empty;
    #endregion

    #region Public Functions
        public frmProduct()
        {
            InitializeComponent();
            txtTrongLuong.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(Functions.Numeric_EditValueChanging);
            txtGiaCong.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(Functions.Numeric_EditValueChanging);
        }
    #endregion

    #region Public Properties
        private Byte[] m_PrdtImage;
        public Byte[] PrdtImage
        {
            get { return m_PrdtImage; }
            set { m_PrdtImage = value; }
        }
    #endregion

    #region Private Functions
        private void fn_EnableControl(bool bEditMode)
        {
            txtTenHang.Enabled = bEditMode;
            cboNhomHang.Enabled = bEditMode;
            //cboLoaiVang.Enabled = bEditMode;
            txtGiaCong.Enabled = bEditMode;
            txtTrongLuong.Enabled = bEditMode;
            lnkUpload.Enabled = bEditMode;
            lnkHuy.Enabled = bEditMode;
            ckbActive.Enabled = bEditMode;

            btnThem.Enabled = !bEditMode;
            btnSua.Enabled = !bEditMode;
            btnXoa.Enabled = !bEditMode;
            btnCapNhat.Enabled = bEditMode;
            grdControl.Enabled = !bEditMode;
        }

        private void fn_LoadDefault()
        {
            strID = String.Empty;
            lblMaHang.Text = "Tự động";
            txtTenHang.Text = String.Empty;
            cboNhomHang.SelectedIndex = 0;
            cboLoaiVang.SelectedIndex = 0;
            txtGiaCong.Text = "0";
            txtTrongLuong.Text = "0";
            picProduct.Image = null;
            ckbActive.Checked = true;
            cboNhomHang.Focus();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", null);
            Functions.BindDropDownList(cboNhomHang, ds, "GroupName", "GroupID", "", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("I_GOLD", "G");
            Functions.BindDropDownList(cboLoaiVang, ds, "GoldDesc", "GoldCode", "", true);
            ds.Clear();

            ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Lst]", "", "", "", "", "", "", "", "", "ProductDesc");
            Functions.BindDropDownList(txtTenHang, ds, "ProductDesc", "ProductID", "", true);
            ds.Clear();

            ds.Dispose();
        }

        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtTenHang.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên hàng.", "OK", ICon.Error);
                txtTenHang.Focus();
                return false;
            }

            if (cboNhomHang.SelectedIndex == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn nhóm hàng.", "OK", ICon.Error);
                cboNhomHang.Focus();
                return false;
            }

            if (cboLoaiVang.SelectedIndex == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn loại vàng.", "OK", ICon.Error);
                cboLoaiVang.Focus();
                return false;
            }

            if (Decimal.Parse(txtGiaCong.Text) < Decimal.Zero)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào giá trị giá công là số dương.", "OK", ICon.Error);
                txtGiaCong.Focus();
                return false;
            }

            try 
            {
                if (!string.IsNullOrEmpty(txtTrongLuong.Text))
                    decimal.Parse(txtTrongLuong.Text);
            }
            catch
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào giá trị trọng lượng hột là số dương.", "OK", ICon.Error);
                txtTrongLuong.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtTrongLuong.Text) && Decimal.Parse(txtTrongLuong.Text) < Decimal.Zero)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào giá trị trọng lượng hột là số dương.", "OK", ICon.Error);
                txtTrongLuong.Focus();
                return false;
            }

            //if (PrdtImage != null && PrdtImage.Length > clsSystem.UploadImageSize * 1024)
            //{
            //    ThongBao.Show("Lỗi", "Kích thước ảnh không được lớn hơn " + clsSystem.UploadImageSize + " (KBs).", "OK", ICon.Error);
            //    return false;
            //}

            return true;
        }

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("ProductID").ToString();
                lblMaHang.Text = grdDanhSach.GetFocusedRowCellValue("ProductCode").ToString();
                txtTenHang.Text = grdDanhSach.GetFocusedRowCellValue("ProductDesc").ToString();
                cboNhomHang.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("GroupID").ToString(), cboNhomHang, 0);
                cboLoaiVang.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("GoldCode").ToString(), cboLoaiVang, 0);
                txtGiaCong.Text = grdDanhSach.GetFocusedRowCellValue("TaskPrice").ToString();
                txtTrongLuong.Text = grdDanhSach.GetFocusedRowCellValue("DiamondWeight").ToString();
                ckbActive.Checked = grdDanhSach.GetFocusedRowCellValue("Active").ToString() == "1" ? true : false;
                if (grdDanhSach.GetFocusedRowCellValue("Image") != DBNull.Value)
                {
                    PrdtImage = (Byte[])grdDanhSach.GetFocusedRowCellValue("Image");
                    MemoryStream fs = new MemoryStream(PrdtImage);
                    Bitmap bitmap = new Bitmap(fs);
                    picProduct.Image = bitmap;
                }
                else
                {
                    picProduct.Image = null;
                    PrdtImage = null;
                }
            }
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Lst]", "", "", "", "", "", null, null, "", "ProductID DESC");

                if (ds.Tables.Count > 0)
                {
                    grdControl.DataSource = ds.Tables[0];
                    lblNumRec.Text = ds.Tables[0].Rows.Count.ToString();
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

        //private Byte[] fn_getProductImage()
        //{
        //    try
        //    {
        //        Byte[] Data = new Byte[PrdtImage.Length];
        //        int i = PrdtImage.Read(Data, 0, int.Parse(PrdtImage.Length.ToString()));
        //        return Data;
        //    }
        //    catch { return null; }
        //}
    #endregion

    #region Event Handlers
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            fn_LoadDataToGrid();
            fn_EnableControl(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fn_EnableControl(true);
            fn_LoadDefault();
            grdControl.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle < 0)
            {
                ThongBao.Show("Thông tin", "Chưa chọn dữ liệu để sửa.", "OK", ICon.Warning);
                return;
            }
            fn_EnableControl(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Chưa chọn dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc chắn là muốn xóa thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDataToGrid();
                        fn_EnableControl(false);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            fn_EnableControl(false);
            fn_GetFocusedRowValue();
            grdControl.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Ins]", "", "", txtTenHang.Text.Trim(),
                        ((ItemList)cboNhomHang.SelectedItem).ID, ((ItemList)cboLoaiVang.SelectedItem).ID, decimal.Parse(txtGiaCong.Text.Trim()).ToString(),
                        string.IsNullOrEmpty(txtTrongLuong.Text) ? null : decimal.Parse(txtTrongLuong.Text.Trim()).ToString(), this.PrdtImage, ckbActive.Checked ? "1" : "0");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Upd]", strID, lblMaHang.Text, txtTenHang.Text.Trim(),
                        ((ItemList)cboNhomHang.SelectedItem).ID, ((ItemList)cboLoaiVang.SelectedItem).ID, decimal.Parse(txtGiaCong.Text.Trim()).ToString(),
                        string.IsNullOrEmpty(txtTrongLuong.Text) ? null : decimal.Parse(txtTrongLuong.Text.Trim()).ToString(), this.PrdtImage, ckbActive.Checked ? "1" : "0");
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    if (strID == "")
                    {
                        //Clear sorting của người dùng trước khi load lại -> chỉ đối với TH thêm mới
                        grdDanhSach.ClearSorting();
                        fn_LoadDataToGrid();
                        btnThem_Click(btnThem, e);
                    }
                    else
                    {
                        fn_EnableControl(false);
                        fn_LoadDataToGrid();
                        fn_GetFocusedRowValue();
                        grdControl.Enabled = true;
                    }
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fn_GetFocusedRowValue();
        }
    #endregion

        private void cboNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhomHang.SelectedIndex > 0)
            {
                txtTenHang.Text = cboNhomHang.Text + " ";

                DataSet ds = new DataSet();
                ds = clsCommon.ExecuteDatasetSP("[I_PRODUCT_GROUP_Get]", ((ItemList)cboNhomHang.SelectedItem).ID);
                cboLoaiVang.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldCode"].ToString(), cboLoaiVang, 0);
                ds.Dispose();

            }
        }

        private void cboNhomHang_Leave(object sender, EventArgs e)
        {
            //txtTenHang.Focus();
            if (txtTenHang.Text != "")
                txtTenHang.Select(txtTenHang.Text.Length, 0);
        }

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(fDialog.FileName);
                    picProduct.Image = bitmap;
                    FileStream fs = new FileStream(fDialog.FileName, FileMode.Open, FileAccess.Read);
                    this.PrdtImage = new Byte[fs.Length];
                    fs.Read(this.PrdtImage, 0, int.Parse(fs.Length.ToString()));
                }
                catch {
                    ThongBao.Show("Lỗi", "Chọn không đúng định dạng ảnh. Vui lòng chọn lại.", "OK", ICon.Error);
                }
                
            }
        }

        private void lnkHuy_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            this.PrdtImage = null;
            picProduct.Image = null;
        }

    }
}