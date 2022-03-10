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
    public partial class frmSection : DevExpress.XtraEditors.XtraForm
    {

    #region Private Variables
        string strID = String.Empty;
    #endregion

    #region Public Functions
        public frmSection()
        {
            InitializeComponent();
        }
    #endregion

    #region Private Functions
        //private void fn_EnableControl(bool bEditMode)
        //{
        //    txtSectionCode.Enabled = bEditMode;
        //    txtSectionName.Enabled = bEditMode;
        //    cboMainSection.Enabled = bEditMode;
        //    cboEmp.Enabled = bEditMode;
        //    ckbActive.Enabled = bEditMode;

        //    btnThem.Enabled = !bEditMode;
        //    btnSua.Enabled = !bEditMode;
        //    btnXoa.Enabled = !bEditMode;
        //    btnCapNhat.Enabled = bEditMode;
        //}

        //private void fn_LoadDefault()
        //{
        //    strID = String.Empty;
        //    txtSectionCode.Text = String.Empty;
        //    txtSectionName.Text = String.Empty;
        //    cboMainSection.SelectedIndex = 0;
        //    cboEmp.SelectedIndex = 0;
        //    ckbActive.Checked = true;
        //    txtSectionCode.Focus();
        //}

        //private bool fn_CheckValidate()
        //{
        //    if (String.IsNullOrEmpty(txtSectionCode.Text))
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng nhập vào mã quầy", "OK", ICon.Error);
        //        txtSectionCode.Focus();
        //        return false;
        //    }
        //    if (String.IsNullOrEmpty(txtSectionName.Text))
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng nhập vào tên quầy", "OK", ICon.Error);
        //        txtSectionName.Focus();
        //        return false;
        //    }

        //    if (cboMainSection.SelectedIndex <= 0)
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng chọn quầy lớn", "OK", ICon.Error);
        //        cboMainSection.Focus();
        //        return false;
        //    }

        //    if (cboEmp.SelectedIndex <= 0)
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng chọn nhân viên", "OK", ICon.Error);
        //        cboEmp.Focus();
        //        return false;
        //    }
        //    return true;
        //}

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("SectionID").ToString();
                //txtSectionCode.Text = grdDanhSach.GetFocusedRowCellValue("SectionCode").ToString();
               // txtSectionName.Text = grdDanhSach.GetFocusedRowCellValue("SectionName").ToString();
               // cboMainSection.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("MainSectionID").ToString(), cboMainSection, 0);
               // cboEmp.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("EmpID").ToString(), cboEmp, 0);
              //  ckbActive.Checked = grdDanhSach.GetFocusedRowCellValue("Active").ToString() == "1" ? true : false;
            }
        }

        //private void fn_LoadDataToCombo()
        //{
        //    DataSet ds = new DataSet();

        //    ds = clsCommon.LoadComboSP("T_MAINSECTION", "");
        //    Functions.BindDropDownList(cboMainSection, ds, "MainSectionName", "MainSectionID", "", true);
        //    ds.Clear();

        //    ds = clsCommon.LoadComboSP("T_EMPLOYEE", "");
        //    Functions.BindDropDownList(cboEmp, ds, "EmpName", "EmpID", "", true);
        //    ds.Clear();

        //    ds.Dispose();
        //}

        public void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_SECTION_Lst]", "", "", "", "", "", "");

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
        private void frmSection_Load(object sender, EventArgs e)
        {
            //fn_LoadDataToCombo();
            fn_LoadDataToGrid();
            //fn_EnableControl(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmOptionSecTion frm = new frmOptionSecTion(this, "");
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle < 0)
            {
                ThongBao.Show("Thông tin", "Không có dữ liệu để sửa.", "OK", ICon.Warning);
                return;
            }
            frmOptionSecTion frm = new frmOptionSecTion(this, strID);
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

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_SECTION_Del]", strID);

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

        //private void btnCapNhat_Click(object sender, EventArgs e)
        //{
        //    DataSet ds = new DataSet();


        //    if (!fn_CheckValidate()) return;

        //    this.Cursor = Cursors.WaitCursor;
        //    try
        //    {
        //        if (strID == "")
        //        {
        //            ds = clsCommon.ExecuteDatasetSP("[T_SECTION_Ins]", "", txtSectionCode.Text.Trim(), txtSectionName.Text.Trim(),
        //                ((ItemList)cboMainSection.SelectedItem).ID, ((ItemList)cboEmp.SelectedItem).ID, ckbActive.Checked ? "1" : "0");
        //        }
        //        else
        //        {
        //            ds = clsCommon.ExecuteDatasetSP("[T_SECTION_Upd]", strID, txtSectionCode.Text.Trim(), txtSectionName.Text.Trim(),
        //                ((ItemList)cboMainSection.SelectedItem).ID, ((ItemList)cboEmp.SelectedItem).ID, ckbActive.Checked ? "1" : "0");
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
        //        ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
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