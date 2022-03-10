using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmGoldType : DevExpress.XtraEditors.XtraForm
    {

    #region Private Variables
        string strID = String.Empty;
        string strOrderBy = String.Empty;
    #endregion

    #region Public Functions
        public frmGoldType()
        {
            InitializeComponent();
            fn_InitValue();
        }
    #endregion

    #region Private Functions
        private void fn_InitValue()
        {
            //Thêm Item vô cboNhom
           // cboGoldType.Properties.Items.Add(new ItemList("G", "Loại vàng"));
            //cboGoldType.Properties.Items.Add(new ItemList("D", "Loại vàng cũ"));
        }

        private void fn_EnableControl(bool bEditMode)
        {
          //  txtGoldCode.Enabled = bEditMode;
           // txtGoldDesc.Enabled = bEditMode;
          //  txtNotes.Enabled = bEditMode;
           // numOrderBy.Enabled = bEditMode;
           // cboGoldType.Enabled = bEditMode;
          //  cboUnit.Enabled = bEditMode;
          //  cboCurrency.Enabled = bEditMode;
           // ckbActive.Enabled = bEditMode;
           // txtGoldAge.Enabled = bEditMode;
           // txtGhiChu.Enabled = bEditMode;

           // btnThem.Enabled = !bEditMode;
           // btnSua.Enabled = !bEditMode;
            //btnXoa.Enabled = !bEditMode;
           // btnCapNhat.Enabled = bEditMode;
        }

        private void fn_LoadDefault()
        {
            //strID = String.Empty;
            //txtGoldCode.Text = String.Empty;
            //txtGoldDesc.Text = String.Empty;
            //txtNotes.Text = String.Empty;
            //numOrderBy.Value = 1;
            //cboGoldType.SelectedIndex = 0;
            //cboUnit.SelectedIndex = 0;
            //cboCurrency.SelectedIndex = 0;
            //ckbActive.Checked = true;
            //txtGhiChu.Text = String.Empty;
            //txtGoldCode.Focus();
        }

        //private bool fn_CheckValidate()
        //{
        //    if (String.IsNullOrEmpty(txtGoldCode.Text))
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng nhập vào mã loại", "OK", ICon.Error);
        //        txtGoldCode.Focus();
        //        return false;
        //    }
        //    if (String.IsNullOrEmpty(txtGoldDesc.Text))
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng nhập vào tên loại", "OK", ICon.Error);
        //        txtGoldDesc.Focus();
        //        return false;
        //    }
        //    if (cboUnit.SelectedIndex == 0 || cboUnit.SelectedIndex==-1)
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng chọn đơn vị tính.", "OK", ICon.Error);
        //        cboUnit.Focus();
        //        return false;
        //    }
        //    if (cboCurrency.SelectedIndex == 0 || cboCurrency.SelectedIndex == -1)
        //    {
        //        ThongBao.Show("Lỗi", "Vui lòng chọn loại tiền tệ.", "OK", ICon.Error);
        //        cboCurrency.Focus();
        //        return false;
        //    }
        //    return true;
        //}

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("GoldCode").ToString();
                //txtGoldDesc.Text = grdDanhSach.GetFocusedRowCellValue("GoldDesc").ToString();
                //strOrderBy = numOrderBy.Text = grdDanhSach.GetFocusedRowCellValue("OrderBy").ToString();
                //cboGoldType.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("GoldType").ToString(), cboGoldType, 0);
                //cboUnit.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("PriceUnit").ToString(), cboUnit, 0);
                //cboCurrency.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("PriceCcy").ToString(), cboCurrency, 0);
                //txtNotes.Text = grdDanhSach.GetFocusedRowCellValue("Notes").ToString();
                //txtGoldAge.EditValue = grdDanhSach.GetFocusedRowCellValue("GoldAge").ToString();
                //ckbActive.Checked = grdDanhSach.GetFocusedRowCellValue("Active").ToString() == "1" ? true : false;
            }
        }

        //private void fn_LoadDataToCombo()
        //{
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_UNIT", "");
        //        Functions.BindDropDownList(cboUnit, ds, "UnitDesc", "UnitCode", "", true);
        //        ds.Clear();

        //        ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_CURRENCY", "");
        //        Functions.BindDropDownList(cboCurrency, ds, "Ccy", "Ccy", "", true);
        //        ds.Clear();
        //    }
        //    catch(Exception ex)
        //    {
        //        ThongBao.Show("Lỗi", "Hàm LoadDataToCombo: " + ex.Message, "OK", ICon.Error);
        //    }
        //    finally
        //    {
        //        ds = null;
        //    }
        //}

        public void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_GOLD_Lst]", "", "", "", "", "", "", "OrderBy ASC");

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
        private void frmPdtGroup_Load(object sender, EventArgs e)
        {
            //fn_LoadDataToCombo();
            fn_LoadDataToGrid();
            //fn_EnableControl(false);
            if (!clsSystem.IsHeSo)
                this.Subtract.Visible = this.Add.Visible = this.Group.Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {           
            frmOptionGoldType frm = new frmOptionGoldType(this,"");
            frm.ShowDialog();          
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Chưa chọn dữ liệu để sửa.", "OK", ICon.Warning);
                return;
            }
            frmOptionGoldType frm = new frmOptionGoldType(this, strID);
            frm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Chưa chọn dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá dữ liệu này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_GOLD_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDataToGrid();
                       // fn_EnableControl(false);
                       // fn_LoadDefault();
                       // grdControl.Enabled = true;
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
                    ThongBao.Show("Lỗi", "Không thể xóa loại hàng đang sử dụng", "OK", ICon.Error);
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

       // private void btnCapNhat_Click(object sender, EventArgs e)
       // {
            //DataSet ds = new DataSet();


            //if (!fn_CheckValidate()) return;

            //this.Cursor = Cursors.WaitCursor;
            //try
            //{
            //    string strGoldType = ((ItemList)cboGoldType.SelectedItem).ID;

            //    if (strID == "")
            //    {
            //        ds = clsCommon.ExecuteDatasetSP("[I_GOLD_Ins]", txtGoldCode.Text.Trim(), txtGoldDesc.Text.Trim(),
            //            numOrderBy.Text, strGoldType, ((ItemList)cboCurrency.SelectedItem).ID, ((ItemList)cboUnit.SelectedItem).ID,
            //            txtNotes.Text.Trim(), ckbActive.Checked ? "1" : "0", 0,txtGhiChu.Text.Trim());//txtGoldAge.EditValue.ToString() == "" ? "0" : txtGoldAge.EditValue);
            //    }
            //    else
            //    {
            //        ds = clsCommon.ExecuteDatasetSP("[I_GOLD_Upd]", strID, txtGoldCode.Text.Trim(), txtGoldDesc.Text.Trim(),
            //            numOrderBy.Text, strGoldType, ((ItemList)cboCurrency.SelectedItem).ID, ((ItemList)cboUnit.SelectedItem).ID,
            //            txtNotes.Text.Trim(), ckbActive.Checked ? "1" : "0", 0,txtGhiChu.Text.Trim()); //txtGoldAge.EditValue.ToString() == "" ? "0" : txtGoldAge.EditValue);
            //    }

            //    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
            //    {

            //        fn_EnableControl(false);
            //        fn_LoadDataToGrid();
            //        fn_LoadDefault();
            //        grdControl.Enabled = true;
            //    }
            //    else
            //    {
            //        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
            //    }
         //   }
         //   catch (Exception ex)
          //  {
          //      ds.Dispose();
          //      this.Cursor = Cursors.Default;
          //      return;
         //   }
        //    finally
          //  {
            //    ds.Dispose();
         //       this.Cursor = Cursors.Default;
          //  }
        //}
    //
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