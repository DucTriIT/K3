using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Utils;


namespace GoldRT
{
    public partial class frmProduct_Out_Dlt : DevExpress.XtraEditors.XtraForm
    {

        #region Private Variables
        string strID = string.Empty;
        string strProductID = string.Empty;
        string strGroupID = string.Empty;
        bool Continue = true;
        string strStampWeight = string.Empty;

        #endregion
        string StrTrnID = "";
        private string strProductCode = "";
        #region Public Functions

        public frmProduct_Out_Dlt()
        {
            InitializeComponent();
        }

        public frmProduct_Out_Dlt(string _TrnID, string _StrProductCode)
        {
            InitializeComponent();
            StrTrnID = _TrnID;
            this.strProductCode = _StrProductCode;
        }


        public void fn_RefreshForm()
        {
            fn_LoadDataToGrid();
            fn_GetFocusedRowValue();
        }
        #endregion

        #region Private Functions
        private void fn_EnableControl(bool bEditMode)
        {
            txtProductCode.Enabled = bEditMode;
            txtGoldCode.Enabled = bEditMode;
            txtProductDesc.Enabled = bEditMode;
            txtProductGroup.Enabled = bEditMode;
            txtTaskPrice.Enabled = bEditMode;
            txtTotalWeight.Enabled = bEditMode;
            txtDiamondWeigth.Enabled = bEditMode;
            txtGoldWeight.Enabled = bEditMode;
            txtRingSize.Enabled = bEditMode;
            txtReason.Enabled = bEditMode;
            txtSectionName.Enabled = bEditMode;
            txtMainSectionName.Enabled = bEditMode;

            //btnThem.Enabled = !bEditMode;
            //btnSua.Enabled = !bEditMode;
            //btnXoa.Enabled = !bEditMode;
            //btnCapNhat.Enabled = bEditMode;
        }

        private void fn_LoadDefault()
        {
            strID = string.Empty;
            strProductID = string.Empty;
            cboStatus.SelectedIndex = 0;

            txtProductCode.Text = string.Empty;
            txtGoldCode.Text = string.Empty;
            txtProductDesc.Text = string.Empty;
            txtProductGroup.Text = string.Empty;
            txtTaskPrice.Text = "0";
            txtGoldWeight.Text = "0";
            txtRingSize.Text = "0";
            txtTotalWeight.Text = "0";
            txtDiamondWeigth.Text = "0";
            //txtReason.Text = string.Empty;
            txtSectionName.Text = string.Empty;
            txtMainSectionName.Text = string.Empty;

            this.ActiveControl = txtProductCode;
        }

        private void fn_LoadDataToCombo()
        {
            //DataSet ds = new DataSet();
            //try
            //{
            //    ds = clsCommon.LoadComboSP("T_STATUS", null);
            //    Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
            //    ds.Clear();

            //    ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Lst]", "", "", "", "", "", "", "",
            //        "", "", "", "", "I", "", "", "", "", "P.ProductCode");
            //    Functions.BindDropDownList(cboProductCode, ds, "ProductCode", "ProductCode", "", true);
            //    ds.Clear();

            //    ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
            //    Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
            //    ds.Clear();
            //}
            //catch
            //{
            //}
            //finally
            //{
            //    ds.Dispose();
            //}
        }

        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();
                strProductID = grdDanhSach.GetFocusedRowCellValue("ProductID").ToString();
                //txtProductCode.Text = grdDanhSach.GetFocusedRowCellValue("ProductCode").ToString();
                txtGoldCode.Text = grdDanhSach.GetFocusedRowCellValue("GoldDesc").ToString();
                txtProductDesc.Text = grdDanhSach.GetFocusedRowCellValue("ProductDesc").ToString();
                strGroupID = grdDanhSach.GetFocusedRowCellValue("GroupID").ToString();
                txtProductGroup.Text = grdDanhSach.GetFocusedRowCellValue("GroupName").ToString();
                txtTaskPrice.Text = grdDanhSach.GetFocusedRowCellValue("TaskPrice").ToString();
                txtTotalWeight.Text = grdDanhSach.GetFocusedRowCellValue("TotalWeight").ToString();
                txtGoldWeight.Text = grdDanhSach.GetFocusedRowCellValue("GoldWeight").ToString();
                txtDiamondWeigth.Text = grdDanhSach.GetFocusedRowCellValue("DiamondWeight").ToString();
                txtRingSize.Text = grdDanhSach.GetFocusedRowCellValue("RingSize").ToString();
                cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("Status").ToString(), cboStatus, 0);
                txtSectionName.Text = grdDanhSach.GetFocusedRowCellValue("SectionName").ToString();
                txtMainSectionName.Text = grdDanhSach.GetFocusedRowCellValue("MainSectionName").ToString();
                txtReason.Text = grdDanhSach.GetFocusedRowCellValue("Reson").ToString();
            }
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_OUT_Lst]", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "", "", "");
                if (ds.Tables.Count > 0)
                {
                    gridControl.DataSource = ds.Tables[0];

                    GetFoucsIndexByTrnID(StrTrnID);
                    btnDel.Enabled = btnPayment.Enabled =
                                     (ds.Tables[0].Rows[0]["Status"].ToString() == "W" &&
                                      clsSystem.GetCurrentAccountType() == AccountType.SuperAccount);
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
            }
        }

        private void GetFoucsIndexByTrnID(string TrnID)
        {
            DataRow row;

            if (TrnID != "")
            {
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    row = grdDanhSach.GetDataRow(i);
                    if (row["TrnID"].ToString() == TrnID)
                    {

                        grdDanhSach.FocusedRowHandle = i;
                        break;
                    }
                }
            }


        }
        #endregion

        #region Event Handlers



        private void txtProductCode_Validating(object sender, CancelEventArgs e)
        {
            //string strStatus = "";

            //if (String.IsNullOrEmpty(txtProductCode.Text))
            //{
            //    txtGoldCode.Text = String.Empty;
            //    txtProductDesc.Text = String.Empty;
            //    txtTaskPrice.Text = String.Empty;
            //    return;
            //}

            //DataSet ds = new DataSet();
            //string strPdtCode = txtProductCode.Text;

            //try
            //{
            //    ds = clsCommon.ExecuteDatasetSP("T_PRODUCT_GetByCode", strPdtCode);
            //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    {
            //        strStatus=ds.Tables[0].Rows[0]["Status"].ToString();
            //        if (strStatus == "I")
            //        {
            //            strProductID = ds.Tables[0].Rows[0]["ProductID"].ToString();
            //            txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldDesc"].ToString();
            //            txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
            //            txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();
            //            strGroupID = ds.Tables[0].Rows[0]["GroupID"].ToString();
            //            txtProductGroup.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
            //            txtDiamondWeigth.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
            //            txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
            //            txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
            //            txtMainSectionName.Text = ds.Tables[0].Rows[0]["MainSectionName"].ToString();
            //        }
            //        else
            //        {
            //            ThongBao.Show("Thông báo", "Mã hàng đã xuất hoặc xuất bán.\nVui lòng nhập mã hàng khác.", "OK", ICon.Error);
            //            txtProductCode.Focus();
            //            return;                        
            //        }
            //    }
            //    else
            //    {
            //        ThongBao.Show("Thông báo", "Mã hàng không hợp lệ.", "OK", ICon.Error);
            //        txtProductCode.Focus();
            //        return;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    ds.Dispose();
            //    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            //    return;
            //}
            //finally { ds.Dispose(); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fn_LoadDefault();
        }

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void btnThem_Click(object sender, EventArgs e)
        //{
        //    fn_EnableControl(true);
        //    fn_LoadDefault();
        //    gridControl.Enabled = false;
        //}

        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    if (grdDanhSach.FocusedRowHandle < 0)
        //    {
        //        ThongBao.Show("Thông tin", "Chưa chọn dữ liệu để sửa.", "OK", ICon.Warning);
        //        return;
        //    }
        //    fn_EnableControl(true);
        //}

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
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_OUT_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDataToGrid();
                        fn_EnableControl(true);
                        fn_LoadDefault();
                        fn_GetFocusedRowValue();
                        gridControl.Enabled = true;
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
        //    gridControl.Enabled = true;
        //}

        private void btnCapNhat_Click()
        {
            DataSet ds = new DataSet();

            string strTongTL = "", strTongTLHot = "", strSLTem = "", strTLTem = "";

            //if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                strTongTL = txtTotalWeight.Text == "" ? "" : decimal.Parse(txtTotalWeight.Text).ToString();
                strTongTLHot = txtDiamondWeigth.Text == "" ? "" : decimal.Parse(txtDiamondWeigth.Text).ToString();
                //strSLTem = txtNumOfStamp.Text == "" ? "" : decimal.Parse(txtNumOfStamp.Text).ToString();
                //strTLTem = txtNumOfStamp.Text == "" ? "" : (decimal.Parse(txtNumOfStamp.Text) * clsSystem.StampWieght).ToString();

                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_OUT_Ins]", "", DateTime.Now.ToString("dd/MM/yyyy"),
                        DateTime.Now.ToString("hh:mm:ss"), strProductID, txtProductCode.Text.Trim(),
                        strGroupID, decimal.Parse(txtTotalWeight.Text).ToString(),
                        decimal.Parse(txtDiamondWeigth.Text).ToString(), decimal.Parse(strStampWeight),
                        decimal.Parse(txtTaskPrice.Text).ToString(), txtReason.Text.Trim(), clsSystem.UserID, clsSystem.UserID, "W", txtGiaBanMon.EditValue);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_OUT_Upd]", strID, null, null, strProductID,
                        txtProductCode.Text.Trim(), strGroupID,
                        decimal.Parse(txtTotalWeight.Text).ToString(), decimal.Parse(txtDiamondWeigth.Text).ToString(),
                        decimal.Parse(strStampWeight), decimal.Parse(txtTaskPrice.Text).ToString(), txtReason.Text.Trim(),
                        clsSystem.UserID, clsSystem.UserID, "W", txtGiaBanMon.EditValue);
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                    fn_EnableControl(true);
                    fn_LoadDataToGrid();
                    gridControl.Enabled = true;
                    fn_LoadDefault();
                    fn_GetFocusedRowValue();
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    Continue = false;
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                Continue = false;
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

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedIndex == 0)
            {
                lblStatus.Text = "{rỗng}";
                return;
            }

            lblStatus.Text = ((ItemList)cboStatus.SelectedItem).Value;
        }
        #endregion

        private void txtProductCode_EditValueChanged(object sender, EventArgs e)
        {
            //string strStatus = "";

            //if (String.IsNullOrEmpty(txtProductCode.Text))
            //{
            //    strProductID = "";
            //    txtGoldCode.Text = String.Empty;
            //    txtProductDesc.Text = String.Empty;
            //    txtTaskPrice.Text = String.Empty;
            //    strGroupID = String.Empty;
            //    txtProductGroup.Text = String.Empty;
            //    txtDiamondWeigth.Text = String.Empty;
            //    txtTotalWeight.Text = String.Empty;
            //    txtGoldWeight.Text = String.Empty;
            //    txtRingSize.Text = String.Empty;
            //    txtSectionName.Text = String.Empty;
            //    txtMainSectionName.Text = String.Empty;
            //    return;
            //}

            //DataSet ds = new DataSet();
            //string strPdtCode = txtProductCode.EditValue.ToString().ToUpper().Trim();

            //try
            //{
            //    if (strPdtCode.Length == clsSystem.ProductCodeLen)
            //    {
            //        ds = clsCommon.ExecuteDatasetSP("T_PRODUCT_GetByCode", strPdtCode);
            //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //        {
            //            strStatus = ds.Tables[0].Rows[0]["Status"].ToString();
            //            if (strStatus == "I")
            //            {
            //                strProductID = ds.Tables[0].Rows[0]["ProductID"].ToString();
            //                txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldDesc"].ToString();
            //                txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
            //                txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();
            //                strGroupID = ds.Tables[0].Rows[0]["GroupID"].ToString();
            //                txtProductGroup.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
            //                txtDiamondWeigth.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
            //                txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
            //                txtGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
            //                txtRingSize.Text = ds.Tables[0].Rows[0]["RingSize"].ToString();
            //                txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
            //                txtMainSectionName.Text = ds.Tables[0].Rows[0]["MainSectionName"].ToString();

            //                SendKeys.Send("{tab}");
            //            }
            //            else
            //            {
            //                ThongBao.Show("Thông báo", "Mã hàng đã xuất hoặc xuất bán.\nVui lòng nhập mã hàng khác.", "OK", ICon.Error);
            //                txtProductCode.Focus();
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            ThongBao.Show("Thông báo", "Mã hàng không hợp lệ.", "OK", ICon.Error);
            //            txtProductCode.Focus();
            //            return;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ds.Dispose();
            //    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            //    return;
            //}
            //finally { ds.Dispose(); }
        }

        private void grdDanhSach_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            //{
            //    InitStartValue();
            //}
            //if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            //{
            //    if (e.FieldValue != null)
            //    {
            //        if (e.IsGroupSummary) totalCount++;
            //        if (e.IsTotalSummary) totalSum += (decimal)e.FieldValue;
            //    }
            //    if (e.IsGroupSummary)
            //        e.TotalValue = totalCount;
            //    if (e.IsTotalSummary)
            //        e.TotalValue = totalSum;
            //}
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //enter
            {
                fn_ChoiceProduct();
                if (Continue == false)
                {
                    Continue = true;
                    return;
                }
                strID = "";
                btnCapNhat_Click();
                if (Continue == false)
                {
                    Continue = true;
                    return;
                }
                //fn_LoadDefault();
            }
        }

        private void fn_ChoiceProduct()
        {
            string strStatus = "";

            if (String.IsNullOrEmpty(txtProductCode.Text))
            {
                strProductID = "";
                txtGoldCode.Text = String.Empty;
                txtProductDesc.Text = String.Empty;
                txtTaskPrice.Text = String.Empty;
                strGroupID = String.Empty;
                txtProductGroup.Text = String.Empty;
                txtDiamondWeigth.Text = String.Empty;
                txtTotalWeight.Text = String.Empty;
                txtGoldWeight.Text = String.Empty;
                txtRingSize.Text = String.Empty;
                txtSectionName.Text = String.Empty;
                txtMainSectionName.Text = String.Empty;
                strStampWeight = String.Empty;
                return;
            }

            DataSet ds = new DataSet();
            string strPdtCode = txtProductCode.EditValue.ToString().ToUpper().Trim();
            txtProductCode.Text = strPdtCode;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_PRODUCT_GetByCodeForSell", strPdtCode);

                if (ds.Tables.Count > 0)
                {
                    //Tồn tại mã hàng cần nhập
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() == "0")
                        {
                            strProductID = ds.Tables[0].Rows[0]["ProductID"].ToString();
                            txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldDesc"].ToString();
                            txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                            txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();
                            strGroupID = ds.Tables[0].Rows[0]["GroupID"].ToString();
                            txtProductGroup.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
                            txtDiamondWeigth.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
                            txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
                            txtGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
                            txtRingSize.Text = ds.Tables[0].Rows[0]["RingSize"].ToString();
                            txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                            txtMainSectionName.Text = ds.Tables[0].Rows[0]["MainSectionName"].ToString();
                            strStampWeight = ds.Tables[0].Rows[0]["StampWeight"].ToString();
                            txtGiaBanMon.Text = ds.Tables[0].Rows[0]["GiaBanMon"].ToString();
                            //SendKeys.Send("{tab}");
                        }
                        else
                        {
                            ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                            Continue = false;
                            txtProductCode.EditValue = string.Empty;
                            txtProductCode.Refresh();
                            txtProductCode.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                Continue = false;
                return;
            }
            finally { ds.Dispose(); }
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            //fn_ChoiceProduct();
            //btnCapNhat_Click();
        }

        private void grdDanhSach_Click(object sender, EventArgs e)
        {
            fn_GetFocusedRowValue();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProduct_Out_Dlt_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToCombo();
            fn_LoadDataToGrid();
            fn_EnableControl(false);
            fn_LoadDefault();
            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {

                if (grdDanhSach.GetRowCellValue(i, "ProductCode").ToString().ToUpper() == strProductCode)
                {
                    //grvProduct.TopRowIndex = i;
                    grdDanhSach.FocusedRowHandle = i;
                    grdDanhSach.SelectRow(i);
                }

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
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
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_OUT_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Xoá dữ liệu thành công", "OK", ICon.Error);
                        this.Close();
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

        private void btnPayment_Click(object sender, EventArgs e)
        {

            int updCount = 0;

            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {

                DataSet ds = new DataSet();

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_OUT_Appr]", grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString(), clsSystem.UserID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                    return;
                }
                finally
                {
                    ds.Dispose();
                    updCount++;
                }
            }
            if (updCount > 0)
            {
                ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                this.Close();
            }
        }
    }
}
