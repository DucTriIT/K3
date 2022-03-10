using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Messages;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace GoldRT
{
    public partial class frmPOProduct : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtProduct = new DataTable();
        public string strID = "";
        private bool bIsDeleting = false;

        public frmPOProduct()
        {
            InitializeComponent();
        }

        private void fn_LoadDefault()
        {
            cboStatus.SelectedIndex = 0;

            fn_createProductDataTable();
            grdProduct.DataSource = dtProduct;
            fn_EnableControl("");
        }

        private void fn_EnableControl(string _status)
        {
            if (_status == "")
            {
                btnSave.Enabled = true;
                btnDel.Enabled = false;
                btnList.Enabled = true;
                btnPrint.Enabled = false;
                btnComplete.Enabled = false;

                cboCust.Enabled = true;
                cboEmp.Enabled = true;
               // cboGoldType.Enabled = true;
                txtProductCode.Enabled = true;
                grdProduct.Enabled = true;


                btnComplete.Text = "Hoàn tất";
            }
            else if (_status == "P")
            {
                btnSave.Enabled = true;
                btnDel.Enabled = true;
                btnList.Enabled = true;
                btnPrint.Enabled = true;
                btnComplete.Enabled = true;

                cboCust.Enabled = true;
                cboEmp.Enabled = true;
                //cboGoldType.Enabled = true;
                txtProductCode.Enabled = true;
                grdProduct.Enabled = true;

                btnComplete.Text = "Hoàn tất";
            }
            else if (_status == "W")
            {
                btnSave.Enabled = false;
                btnDel.Enabled = false;
                btnList.Enabled = true;
                btnPrint.Enabled = true;
                btnComplete.Enabled = true;

                cboCust.Enabled = false;
                cboEmp.Enabled = false;
                //cboGoldType.Enabled = false;
                txtProductCode.Enabled = false;
                grdProduct.Enabled = false;

                btnComplete.Text = "Lấy lại";
            }
            else if (_status == "C")
            {
                btnSave.Enabled = false;
                btnDel.Enabled = false;
                btnList.Enabled = true;
                btnPrint.Enabled = true;
                btnComplete.Enabled = false;

                cboCust.Enabled = false;
                cboEmp.Enabled = false;
                //cboGoldType.Enabled = false;
                txtProductCode.Enabled = false;
                grdProduct.Enabled = false;
            }
        }

        private void fn_ClearForm()
        {
            strID = "";

            //Các giá trị thể hiện trên form
            cboCust.SelectedIndex = 0;
            //cboGoldType.SelectedIndex = -1;
            txtCustName.Text = "";
            txtCustAddress.Text = "";
            txtProductCode.Text = "";
            txtTotal_Weight_Stamp.Text = "0";
            txtTotal_Stamp.Text = "0";
            txtToal_GoldWeight.Text = "0";

            //Các biến hidden
            txtProductID.Text = "";
            txtGroupID.Text = "";
            cboStatus.SelectedIndex = 0;
            txtProductDesc.Text = "";
            txtGoldCode.Text = "";
            txtPriceCcy.Text = "";
            txtPriceUnit.Text = "";
            txtTaskPrice.Text = "0";
            txtTotalWeight.Text = "0";
            txtTotal_DiamondWeight.Text = "0";
            txtDiamondWeight.Text = "0";
            txtStampWeight.Text = "0";
            txtRingSize.Text = "0";
            txtInPrice.Text = "0";
            txtTotal_TaskPrice.Text = "0";
            txtTotal_TotalWeight.Text = "0";
            txtTotal_TotalWeight.Text = "0";
            txtTotal_TaskPrice.Text = "0";

            grdProduct.DataSource = dtProduct;
            grvProduct.SelectAll();
            grvProduct.DeleteSelectedRows();

            fn_EnableControl("");
            Functions.fn_SetFormCaption(this, "Lập toa hàng");
        }

        private void fn_createProductDataTable()
        {
            this.dtProduct.Columns.Add("colChon", typeof(string));
            this.dtProduct.Columns.Add("ProductID", typeof(string));
            this.dtProduct.Columns.Add("ProductPODTID", typeof(string));
            this.dtProduct.Columns.Add("ProductCode", typeof(string));
            this.dtProduct.Columns.Add("ProductDesc", typeof(string));
            this.dtProduct.Columns.Add("TaskPrice", typeof(decimal));
            this.dtProduct.Columns.Add("TaskPrice_Discount", typeof(decimal));
            this.dtProduct.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtProduct.Columns.Add("GoldWeight", typeof(decimal));
            this.dtProduct.Columns.Add("TotalWeight", typeof(decimal));
            this.dtProduct.Columns.Add("StampWeight", typeof(decimal));
            this.dtProduct.Columns.Add("GroupID", typeof(string));
            this.dtProduct.Columns.Add("PriceCcy", typeof(string));
            this.dtProduct.Columns.Add("PriceUnit", typeof(string));
            this.dtProduct.Columns.Add("GoldCode", typeof(string));
            this.dtProduct.Columns.Add("RingSize", typeof(decimal));
            this.dtProduct.Columns.Add("InPrice", typeof(decimal));
            this.dtProduct.Columns.Add("SectionName", typeof(string));
            this.dtProduct.Columns.Add("GroupName", typeof(string));
            this.dtProduct.Columns.Add("GoldAge",typeof(decimal));
            this.dtProduct.Columns.Add("GoldAgeChange",typeof(decimal));
            this.dtProduct.Columns.Add("GoldWeightChange", typeof(decimal));
        }

        private void fn_loadDataToForm()
        {
            DataSet ds = new DataSet();
            string strCustID = "", strGoldCode = "";

            try
            {
                ds = clsCommon.ExecuteDatasetSP("TRN_PO_PRODUCT_Get", strID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    strID = ds.Tables[0].Rows[0]["ProductPOID"].ToString();
                    strCustID = ds.Tables[0].Rows[0]["CustID"].ToString();
                    strGoldCode = ds.Tables[0].Rows[0]["GoldCode"].ToString();

                    cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(strCustID, cboCust, 0);
                    //cboGoldType.SelectedIndex = Functions.GetSelectedIndexCombo(strGoldCode, cboGoldType, 0);

                    txtTotal_TotalWeight.Text = ds.Tables[0].Rows[0]["Total_Weight"].ToString();
                    txtTotal_DiamondWeight.Text = ds.Tables[0].Rows[0]["Total_Weight_Diamond"].ToString();
                    txtTotal_TaskPrice.Text = ds.Tables[0].Rows[0]["Total_TaskPrice"].ToString();
                    txtTotal_Stamp.Text = ds.Tables[0].Rows[0]["Total_Weight_Stamp"].ToString();
                    txtToal_GoldWeight.Text = ds.Tables[0].Rows[0]["Total_GoldWeight"].ToString();
                    cboEmp.SelectedIndex=Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["EmpID"].ToString(),cboEmp,0);
                    cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["Status"].ToString(), cboStatus, 0);

                    grdProduct.DataSource = ds.Tables[1];

                    fn_EnableControl(ds.Tables[0].Rows[0]["Status"].ToString());
                    cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["Status"].ToString(), cboStatus, 0);
                    btnComplete.Text = ds.Tables[0].Rows[0]["Status"].ToString() == "P" ? "Hoàn tất" : "Lấy lại";
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void f_loadDataToCombo()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.LoadComboSP("I_CUSTOMER", "NOTWALKINCUST");
                Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "", true);
                ds.Clear();
                ds = clsCommon.LoadComboSP("T_EMPLOYEE", null);
                Functions.BindDropDownList(cboEmp, ds, "EmpName", "EmpID","",false);
                ds.Clear();

                //ds = clsCommon.LoadComboSP("I_GOLD_PRICEUINT", "L");
                //Functions.BindDropDownList(cboGoldType, ds, "GoldDesc", "GoldCode", "", true);
                //ds.Clear();

                ds = clsCommon.LoadComboSP("T_STATUS", "PO");
                Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
                ds.Clear();

            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void fn_clearChooseProduct()
        {
            txtProductID.Text = "";
            txtProductCode.EditValue = "";
            txtGroupID.Text = "";
            txtProductDesc.Text = "";
            txtGoldCode.Text = "";
            txtPriceCcy.Text = "";
            txtPriceUnit.Text = "";
            txtTaskPrice.Text = "";
            txtTotalWeight.Text = "";
            txtDiamondWeight.Text = "";
            txtStampWeight.Text = "";
            txtRingSize.Text = "";
            txtInPrice.Text = "";
           
        }

        /// <summary>
        /// Hàm lấy giá trị Summary trên lưới. Khỏi tính toán lại.
        /// </summary>
        private void fn_calcCustomSummary()
        {
            decimal dTotal_TaskPrice = 0;
            decimal dTotal_TaskPrice_Discount = 0;
            decimal dTotal_DiamondWeight = 0;
            decimal dTotal_TotalWeight = 0;
            decimal dTotal_StampWeight = 0;
            decimal dTotal_GoldWeightChange = 0;
            if (grvProduct.Columns["TaskPrice"].SummaryItem.SummaryValue != null)            
                decimal.TryParse(grvProduct.Columns["TaskPrice"].SummaryItem.SummaryValue.ToString(), out dTotal_TaskPrice);
            if (grvProduct.Columns["TaskPrice_Discount"].SummaryItem.SummaryValue != null)
                decimal.TryParse(grvProduct.Columns["TaskPrice_Discount"].SummaryItem.SummaryValue.ToString(), out dTotal_TaskPrice_Discount);            
            if (grvProduct.Columns["DiamondWeight"].SummaryItem.SummaryValue != null)
                decimal.TryParse(grvProduct.Columns["DiamondWeight"].SummaryItem.SummaryValue.ToString(), out dTotal_DiamondWeight);
            if (grvProduct.Columns["TotalWeight"].SummaryItem.SummaryValue != null)
                decimal.TryParse(grvProduct.Columns["TotalWeight"].SummaryItem.SummaryValue.ToString(), out dTotal_TotalWeight);
            if (grvProduct.Columns["StampWeight"].SummaryItem.SummaryValue != null)
                decimal.TryParse(grvProduct.Columns["StampWeight"].SummaryItem.SummaryValue.ToString(), out dTotal_StampWeight);
            if(grvProduct.Columns["GoldWeightChange"].SummaryItem.SummaryValue!=null)
                decimal.TryParse(grvProduct.Columns["GoldWeightChange"].SummaryItem.SummaryValue.ToString(), out dTotal_GoldWeightChange);
            //Trọng lượng luôn hột + Tem
            decimal dTotal_Weight_Stamp = dTotal_TotalWeight + dTotal_StampWeight;
            
            //TL vàng
            decimal dTotal_GoldWeight = dTotal_TotalWeight - dTotal_DiamondWeight;

            //Gán các giá trị cần để Insert/Update vào các controls
            txtTotal_TotalWeight.EditValue = dTotal_TotalWeight;
            txtTotal_DiamondWeight.EditValue = dTotal_DiamondWeight;
            txtTotal_Weight_Stamp.EditValue = dTotal_Weight_Stamp;
            txtTotal_Stamp.EditValue = dTotal_StampWeight;
            txtTotal_TaskPrice.EditValue = dTotal_TaskPrice - dTotal_TaskPrice_Discount;
            txtToal_GoldWeight.EditValue = dTotal_GoldWeight;
            txtTotal_GoldWeightChange.EditValue = dTotal_GoldWeightChange;
        }

        private bool f_checkValidate()
        {
            if (cboCust.SelectedIndex == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn thông tin khách hàng.", "OK", ICon.Error);
                cboCust.Focus();
                return false;
            }

            //if (cboGoldType.SelectedIndex == 0)
            //{
            //    ThongBao.Show("Lỗi", "Vui lòng chọn thông tin loại vàng.", "OK", ICon.Error);
            //    cboGoldType.Focus();
            //    return false;
            //}

            if (grvProduct.RowCount == 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập hàng vào toa.", "OK", ICon.Error);
                txtProductCode.Focus();
                return false;
            }

            return true;
        }

        private void frmPOProduct_Load(object sender, EventArgs e)
        {
            //Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            f_loadDataToCombo();

            cboCust.Focus();
            fn_LoadDefault();
            Functions.fn_SetFormCaption(this, "Lập toa hàng");
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strCustName = "";
            string strCustAddress = "";

            if (cboCust.SelectedIndex != 0)
            {
                DataSet ds = new DataSet();
                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_Get]", 
                        ((ItemList)cboCust.SelectedItem).ID);
                    strCustName = ds.Tables[0].Rows[0]["CustName"].ToString();
                    strCustAddress = ds.Tables[0].Rows[0]["Address"].ToString();
                    Functions.fn_SetFormCaption(this, "Lập toa hàng - " + strCustName);
                }
                catch (Exception ex)
                {
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                }
                finally
                {
                    ds.Dispose();
                }
            }

            txtCustName.Text = strCustName;
            txtCustAddress.Text = strCustAddress;
        }

        private void grvProduct_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductPODTID", "");
                this.grvProduct.SetRowCellValue(e.RowHandle, "colChon", "False");
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductID", txtProductID.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductCode", txtProductCode.Text.ToUpper());
                this.grvProduct.SetRowCellValue(e.RowHandle, "ProductDesc", txtProductDesc.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "GroupID", txtGroupID.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "GoldCode", txtGoldCode.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "PriceCcy", txtPriceCcy.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "PriceUnit", txtPriceUnit.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "SectionName", txtSectionName.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "GroupName", txtGroupName.Text);
                this.grvProduct.SetRowCellValue(e.RowHandle, "TaskPrice_Discount", 0);
                
                

                if (txtTaskPrice.Text != "")
                    this.grvProduct.SetRowCellValue(e.RowHandle, "TaskPrice", decimal.Parse(txtTaskPrice.Text));
                if (txtTotalWeight.Text != "")
                    this.grvProduct.SetRowCellValue(e.RowHandle, "TotalWeight", decimal.Parse(txtTotalWeight.Text));
                if (txtGoldWeight.Text != "")
                    this.grvProduct.SetRowCellValue(e.RowHandle, "GoldWeight", decimal.Parse(txtGoldWeight.Text));
                if (txtDiamondWeight.Text != "")
                    this.grvProduct.SetRowCellValue(e.RowHandle, "DiamondWeight", decimal.Parse(txtDiamondWeight.Text));
                if (txtStampWeight.Text != "")
                    this.grvProduct.SetRowCellValue(e.RowHandle, "StampWeight", decimal.Parse(txtStampWeight.Text));
                if (txtRingSize.Text != "")
                    this.grvProduct.SetRowCellValue(e.RowHandle, "RingSize", decimal.Parse(txtRingSize.Text));
                if (txtInPrice.Text != "")
                    this.grvProduct.SetRowCellValue(e.RowHandle, "InPrice", decimal.Parse(txtInPrice.Text));
                if(txtGoldAge.Text!="")
                    this.grvProduct.SetRowCellValue(e.RowHandle,"GoldAge",decimal.Parse(txtGoldAge.Text));
                if(txtGoldAgeChange.Text!="")
                    this.grvProduct.SetRowCellValue(e.RowHandle, "GoldAgeChange", decimal.Parse(txtGoldAgeChange.Text));
                if(txtGoldWeightChange.Text!="")
                    this.grvProduct.SetRowCellValue(e.RowHandle, "GoldWeightChange", decimal.Parse(txtGoldWeightChange.Text));
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm grvProduct_InitNewRow " + ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!f_checkValidate()) return;

            DataSet ds = new DataSet();
            DataRow row;

            string strCustID = "";
            //string strGoldCode = "";
            string strTotal_Weight = "";
            string strTotal_Weight_Diamond = "";
            string strTotal_Stamp = "";
            string strTotal_TaskPrice = "";
            string strTotal_GoldWeight = "";
            string strStatus = "P";
            string strProductIDs = "";
            string strTaskPrices = "";
            string strTaskPrice_Discounts = "";
            string strGoldCodes = "";
            string strGoldAge = "",strGoldAgeChange="";
            string strTotal_GoldWeightChange = "";
            string strGoldWeightChange="";
            strCustID = ((ItemList)cboCust.SelectedItem).ID;
            //strGoldCode = ((ItemList)cboGoldType.SelectedItem).ID;

            fn_calcCustomSummary();
            strTotal_Weight = txtTotal_TotalWeight.EditValue.ToString();
            strTotal_Weight_Diamond = txtTotal_DiamondWeight.EditValue.ToString();
            strTotal_Stamp = txtTotal_Stamp.EditValue.ToString();
            strTotal_TaskPrice = txtTotal_TaskPrice.EditValue.ToString();
            strTotal_GoldWeight = txtToal_GoldWeight.EditValue.ToString();
            strTotal_GoldWeightChange = txtTotal_GoldWeightChange.EditValue.ToString();
            //strStatus = ((ItemList)cboStatus.SelectedItem).ID;
            grvProduct.ClearSorting();
            if (grvProduct.RowCount > 0)
            {
                for (int i = 0; i < grvProduct.RowCount; i++)
                {
                    row = grvProduct.GetDataRow(i);
                    strProductIDs += row["ProductID"].ToString() + "@";
                    strTaskPrices += row["TaskPrice"].ToString() + "@";
                    strTaskPrice_Discounts += row["TaskPrice_Discount"].ToString() + "@";
                    strGoldCodes += row["GoldCode"].ToString() + "@";
                    strGoldAgeChange += row["GoldAgeChange"].ToString() + "@";
                    strGoldWeightChange+=row["GoldWeightChange"].ToString()+"@";
                    strGoldAge += row["GoldAge"].ToString() + "@";
                }
                strProductIDs = strProductIDs.Substring(0, strProductIDs.Length - 1);
                strTaskPrices = strTaskPrices.Substring(0, strTaskPrices.Length - 1);
                strTaskPrice_Discounts = strTaskPrice_Discounts.Substring(0, strTaskPrice_Discounts.Length - 1);
                strGoldCodes = strGoldCodes.Substring(0, strGoldCodes.Length - 1);
                strGoldAge = strGoldAge.Substring(0, strGoldAge.Length - 1);
                strGoldAgeChange = strGoldAgeChange.Substring(0, strGoldAgeChange.Length - 1);
                strGoldWeightChange=strGoldWeightChange.Substring(0,strGoldWeightChange.Length-1);
            }
            else
            {
                strProductIDs = "";
            }

            if (strID == "")
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PO_PRODUCT_Ins]", strCustID, "", strTotal_Weight,
                    strTotal_Weight_Diamond, strTotal_Stamp, strTotal_TaskPrice, strTotal_GoldWeight,
                    strStatus, clsSystem.UserID, strProductIDs, strTaskPrices, strTaskPrice_Discounts, strGoldCodes,((ItemList)cboEmp.SelectedItem).ID,strGoldWeightChange,strGoldAge,strGoldAgeChange);
            }
            else
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PO_PRODUCT_Upd]", strID, strCustID, "", strTotal_Weight,
                    strTotal_Weight_Diamond, strTotal_Stamp, strTotal_TaskPrice, strTotal_GoldWeight,
                    strStatus, clsSystem.UserID, strProductIDs, strTaskPrices, strTaskPrice_Discounts, strGoldCodes, ((ItemList)cboEmp.SelectedItem).ID,strGoldWeightChange,strGoldAge,strGoldAgeChange);
            }

            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() != "0")
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString() + " [" + ds.Tables[0].Rows[0]["ErrorCode"].ToString() + "]", "OK", ICon.Error);
                }
                else
                {
                    strID = ds.Tables[0].Rows[0]["ProductPOID"].ToString();
                    cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("P", cboStatus, 0);
                    fn_EnableControl(((ItemList)cboStatus.SelectedItem).ID);
                    ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                }
            }
        }

        private void grvProduct_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (bIsDeleting)
            {
                bIsDeleting = false;
                return;
            }
            fn_calcCustomSummary();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_PRODUCT_Del]", strID);
                    if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                    else
                    {
                        ThongBao.Show("Thông báo", "Xóa toa hàng thành công.", "OK", ICon.Information);
                        fn_ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strStatus = "";
            DataRow row;

            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    strStatus = ((ItemList)cboStatus.SelectedItem).ID == "P" ? "W" : "P";

                    ds = clsCommon.ExecuteDatasetSP("TRN_PO_PRODUCT_ChangeStatus", strID, strStatus);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                        fn_EnableControl(strStatus);
                        fn_loadDataToForm();
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmPOProductLst frm = new frmPOProductLst(this);
            frm.ShowDialog();

            fn_loadDataToForm();
            fn_calcCustomSummary();
        }

        private void grvProduct_KeyDown(object sender, KeyEventArgs e)
        {
            //Xóa dữ liệu trên lưới toa hàng
            if (e.KeyCode == Keys.Delete && grvProduct.FocusedRowHandle > 0)
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn là muốn xóa không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    int i = grvProduct.FocusedRowHandle;
                    grvProduct.DeleteRow(i);
                    //grvProduct.DeleteSelectedRows();
                    fn_calcCustomSummary();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvProduct_RowCountChanged(object sender, EventArgs e)
        {
            //if (grvProduct.RowCount != 0)
            //{
            //    cboGoldType.Enabled = false;
            //}
            //else
            //{
            //    cboGoldType.Enabled = true;
            //}
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            //string strProductCode = "";
            //strProductCode = txtProductCode.EditValue.ToString().Trim().ToUpper();

            //if (strProductCode == string.Empty) return;

            ////Bắt buộc chọn loại vàng trước khi add hàng vào danh sách
            //if (cboGoldType.SelectedIndex == 0)
            //{
            //    ThongBao.Show("Lỗi", "Vui lòng chọn Loại vàng trước khi nhập hàng.", "OK", ICon.Error);
            //    txtProductCode.EditValue = string.Empty;
            //    txtProductCode.Refresh();
            //    cboGoldType.Focus();
            //    return;
            //}

            ////Nếu không đủ số kí tự quy định về mã hàng => không kiểm tra
            //if (strProductCode.Length != clsSystem.ProductCodeLen) return;

            ////Kiểm tra mã hàng mới nhập có trùng với các hàng trên danh sach không?
            //bool IsDup = false;
            //for (int i = 0; i < grvProduct.RowCount; i++)
            //{
            //    if (grvProduct.GetRowCellValue(i, "ProductCode").ToString() == strProductCode)
            //        IsDup = true;
            //}
            //if (IsDup)
            //{
            //    ThongBao.Show("Lỗi", "Mã hàng này đã tồn tại trong danh sách.", "OK", ICon.Error);
            //    txtProductCode.EditValue = string.Empty;
            //    txtProductCode.Refresh();
            //    txtProductCode.Focus();
            //    return;
            //}

            //DataSet ds = new DataSet();
            //this.Cursor = Cursors.WaitCursor;
            //try
            //{
            //    if (txtProductCode.Text.Trim() != "")
            //    {
            //        ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Lst]",
            //                            "", strProductCode, "", "", "", "", "", "", "",
            //                            "", "", "", "", "", "", "", "");

            //        if (ds.Tables.Count > 0)
            //        {
            //            //Tồn tại mã hàng cần nhập
            //            if (ds.Tables[0].Rows.Count == 1)
            //            {
            //                //Nếu loại vàng không giống nhau
            //                if (ds.Tables[0].Rows[0]["GoldCode"].ToString() != ((ItemList)cboGoldType.SelectedItem).ID)
            //                {
            //                    ThongBao.Show("Thông tin", "Chỉ được nhập hàng có loại vàng [" + cboGoldType.Text + "].", "OK", ICon.Error);

            //                    //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
            //                    txtProductCode.EditValue = string.Empty;
            //                    txtProductCode.Refresh();
            //                    txtProductCode.Focus();
            //                }
            //                else if (ds.Tables[0].Rows[0]["Status"].ToString() == "O")
            //                {
            //                    ThongBao.Show("Thông tin", "Hàng [" + strProductCode + "] đã xuất.", "OK", ICon.Error);

            //                    //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
            //                    txtProductCode.EditValue = string.Empty;
            //                    txtProductCode.Refresh();
            //                    txtProductCode.Focus();
            //                }
            //                else
            //                {
            //                    txtProductID.Text = ds.Tables[0].Rows[0]["ProductID"].ToString();
            //                    txtGroupID.Text = ds.Tables[0].Rows[0]["GroupID"].ToString();
            //                    txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
            //                    txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldCode"].ToString();
            //                    txtPriceCcy.Text = ds.Tables[0].Rows[0]["PriceCcy"].ToString();
            //                    txtPriceUnit.Text = ds.Tables[0].Rows[0]["PriceUnit"].ToString();
            //                    txtTaskPrice.Text = ds.Tables[0].Rows[0]["POTaskPrice1"].ToString();
            //                    txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
            //                    txtDiamondWeight.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
            //                    txtStampWeight.Text = ds.Tables[0].Rows[0]["StampWeight"].ToString();
            //                    txtRingSize.Text = ds.Tables[0].Rows[0]["RingSize"].ToString();
            //                    txtInPrice.Text = ds.Tables[0].Rows[0]["InPrice"].ToString();

            //                    grvProduct.AddNewRow();
            //                    grvProduct.UpdateCurrentRow();

            //                    //Xóa thông tin mặt hàng đã chọn
            //                    fn_clearChooseProduct();
            //                    txtProductCode.Refresh();
            //                    txtProductCode.Focus();
            //                }
            //            }
            //            else if (ds.Tables[0].Rows.Count == 0)//Không tồn tại mã hàng cần nhập
            //            {
            //                ThongBao.Show("Thông tin", "Mã hàng không hợp lệ.", "OK", ICon.Error);

            //                //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
            //                txtProductCode.EditValue = string.Empty;
            //                txtProductCode.Refresh();
            //                txtProductCode.Focus();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        txtCustName.Text = "";
            //        txtCustAddress.Text = "";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ThongBao.Show("Error", ex.Source + " -" + ex.Message, "OK", ICon.Error);
            //    ds.Dispose();
            //    this.Cursor = Cursors.Default;
            //    return;
            //}
            //finally
            //{
            //    ds.Dispose();
            //    this.Cursor = Cursors.Default;
            //}
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            fn_ClearForm();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues;

            strParams = "";
            strValues = "";

            ds = clsCommon.ExecuteDatasetSP("rptBangKeToaHang", strID);
            Functions.fn_ShowReport(ds, "rptBangKeToaHang.rpt", strParams, strValues);
        }

        private void grvProduct_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.Name == "colTaskPrice")
            {
                (e.RepositoryItem as RepositoryItemComboBox).Items.Clear();
                DataSet ds = new DataSet();
                string strProductCode = grvProduct.GetRowCellValue(e.RowHandle, "ProductCode").ToString();

                ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_GetTaskPrice]", strProductCode);
                if ((e.RepositoryItem as RepositoryItemComboBox).Items.Count == 0)
                    Functions.BindDropDownList((e.RepositoryItem as RepositoryItemComboBox), ds, "POTaskPrice", "POTaskPrice", false);
            }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string strProductCode = "";
                strProductCode = txtProductCode.EditValue.ToString().Trim().ToUpper();

                if (strProductCode == string.Empty) return;

                //Bắt buộc chọn loại vàng trước khi add hàng vào danh sách
                //if (cboGoldType.SelectedIndex == 0)
                //{
                //    ThongBao.Show("Lỗi", "Vui lòng chọn Loại vàng trước khi nhập hàng.", "OK", ICon.Error);
                //    txtProductCode.EditValue = string.Empty;
                //    txtProductCode.Refresh();
                //    cboGoldType.Focus();
                //    return;
                //}

                //Nếu không đủ số kí tự quy định về mã hàng => không kiểm tra
                //if (strProductCode.Length != clsSystem.ProductCodeLen) return;

                //Kiểm tra mã hàng mới nhập có trùng với các hàng trên danh sach không?
                bool IsDup = false;
                for (int i = 0; i < grvProduct.RowCount; i++)
                {
                    if (grvProduct.GetRowCellValue(i, "ProductCode").ToString() == strProductCode)
                        IsDup = true;
                }
                if (IsDup)
                {
                    ThongBao.Show("Lỗi", "Mã hàng này đã tồn tại trong danh sách.", "OK", ICon.Error);
                    txtProductCode.EditValue = string.Empty;
                    txtProductCode.Refresh();
                    txtProductCode.Focus();
                    return;
                }

                DataSet ds = new DataSet();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (txtProductCode.Text.Trim() != "")
                    {
                        ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_GetByCodeForPO]", strProductCode);

                        if (ds.Tables.Count > 0)
                        {
                            //Tồn tại mã hàng cần nhập
                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() == "0")
                                {
                                    //Nếu loại vàng không giống nhau
                                    //if (ds.Tables[0].Rows[0]["GoldCode"].ToString() != ((ItemList)cboGoldType.SelectedItem).ID)
                                    //{
                                    //    ThongBao.Show("Thông tin", "Chỉ được nhập hàng có loại vàng [" + cboGoldType.Text + "].", "OK", ICon.Error);

                                    //    //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
                                    //    txtProductCode.EditValue = string.Empty;
                                    //    txtProductCode.Refresh();
                                    //    txtProductCode.Focus();
                                    //}
                                    //else 
                                    if (ds.Tables[0].Rows[0]["Status"].ToString() == "O")
                                    {
                                        ThongBao.Show("Thông tin", "Hàng [" + strProductCode + "] đã xuất.", "OK", ICon.Error);

                                        //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
                                        txtProductCode.EditValue = string.Empty;
                                        txtProductCode.Refresh();
                                        txtProductCode.Focus();
                                    }
                                    else
                                    {
                                        txtProductID.Text = ds.Tables[0].Rows[0]["ProductID"].ToString();
                                        txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                                        txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldCode"].ToString();
                                        txtPriceCcy.Text = ds.Tables[0].Rows[0]["PriceCcy"].ToString();
                                        txtPriceUnit.Text = ds.Tables[0].Rows[0]["PriceUnit"].ToString();
                                        txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();//POTaskPrice1
                                        txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
                                        txtDiamondWeight.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
                                        txtGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
                                        txtStampWeight.Text = ds.Tables[0].Rows[0]["StampWeight"].ToString();
                                        txtRingSize.Text = ds.Tables[0].Rows[0]["RingSize"].ToString();
                                        txtInPrice.Text = ds.Tables[0].Rows[0]["InPrice"].ToString();
                                        txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                                        txtGroupName.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
                                        txtGoldAge.Text = ds.Tables[0].Rows[0]["GoldAge"].ToString();
                                        txtGoldAgeChange.Text = ds.Tables[0].Rows[0]["GoldAge"].ToString();
                                        txtGoldWeightChange.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
                                        grvProduct.AddNewRow();
                                        grvProduct.UpdateCurrentRow();

                                        //Xóa thông tin mặt hàng đã chọn
                                        fn_clearChooseProduct();
                                        txtProductCode.Refresh();
                                        txtProductCode.Focus();
                                    }
                                }
                                else
                                {
                                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorCode"].ToString() + " - " + ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);

                                    txtProductCode.EditValue = string.Empty;
                                    txtProductCode.Refresh();
                                    txtProductCode.Focus();
                                }
                            }
                        }
                    }
                    else
                    {
                        txtCustName.Text = "";
                        txtCustAddress.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    ThongBao.Show("Error", ex.Source + " -" + ex.Message, "OK", ICon.Error);
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
        }

        private void grvProduct_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && grvProduct.FocusedRowHandle >= 0)
                {
                    GridHitInfo hInfo = grvProduct.CalcHitInfo(new Point(e.X, e.Y));
                    if (hInfo.InRowCell && hInfo.Column.Name == "colChon")
                    {
                        string curValue = grvProduct.GetRowCellValue(hInfo.RowHandle, hInfo.Column).ToString();
                        if (curValue != "")
                        {
                            bIsDeleting = true;
                            grvProduct.SetRowCellValue(hInfo.RowHandle, hInfo.Column, curValue == "True" ? "False" : "True");
                        }
                    }

                    if (hInfo.InRowCell && hInfo.Column.Name != "colChon")
                    {
                        bIsDeleting = false;
                    }

                    if (hInfo.InColumnPanel && hInfo.Column.Name == "colChon")
                    {
                        if (hInfo.Column.ImageIndex == 0)
                        {
                            for (int i = 0; i < grvProduct.RowCount; i++)
                            {
                                if (grvProduct.GetRowCellValue(i, "colChon").ToString() != "")
                                {
                                    bIsDeleting = true;
                                    grvProduct.SetRowCellValue(i, hInfo.Column, "True");
                                }
                            }
                            hInfo.Column.ImageIndex = 1;
                        }
                        else
                        {
                            for (int i = 0; i < grvProduct.RowCount; i++)
                            {
                                if (grvProduct.GetRowCellValue(i, "colChon").ToString() != "")
                                {
                                    bIsDeleting = true;
                                    grvProduct.SetRowCellValue(i, hInfo.Column, "False");
                                }
                            }
                            hInfo.Column.ImageIndex = 0;
                        }
                    }
                }
            }
            catch { }
        }

        private void btnRowDel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá các thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    for (int i = 0; i < grvProduct.RowCount; i++)
                    {
                        if (grvProduct.GetRowCellValue(i, "colChon").ToString() == "True")
                        {
                            grvProduct.DeleteRow(i);
                            i--;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmOptionCustomer frm = new frmOptionCustomer();
            frm.ShowDialog();
             DataSet ds = new DataSet();

             try
             {
                 ds = clsCommon.LoadComboSP("I_CUSTOMER", "NOTWALKINCUST");
                 Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "", true);
                 ds.Clear();
                 cboCust.SelectedIndex = Functions.GetSelectedIndexCombo(frm.mstrID, cboCust, 0);
             }  
            catch
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmPOGold frm = new frmPOGold(((ItemList)cboCust.SelectedItem).ID);
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }

        private void rtxtGoldAgeChange_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dGoldWeight = 0, dGoldAge = 0, dGoldAgeChange = 0, dGoldWeightChange = 0;
            if(!decimal.TryParse(e.NewValue.ToString(),out dGoldAgeChange))
            {
                ThongBao.Show("Lỗi","Vui lòng nhập giá trị số","OK",ICon.Error);
                e.Cancel=true;
                return;
            }
            try
            {
            dGoldWeight=decimal.Parse(grvProduct.GetFocusedRowCellValue("GoldWeight").ToString());
            dGoldAge=decimal.Parse(grvProduct.GetFocusedRowCellValue("GoldAge").ToString());
            dGoldWeightChange=dGoldWeight*dGoldAge/dGoldAgeChange;
            grvProduct.SetFocusedRowCellValue(grvProduct.Columns["GoldWeightChange"],Math.Round(dGoldWeightChange,2));
            }
            catch{}
        }

        private void rtxtGoldAge_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal dGoldWeight = 0, dGoldAge = 0, dGoldAgeChange = 0, dGoldWeightChange = 0;
            if (!decimal.TryParse(e.NewValue.ToString(), out dGoldAge))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập giá trị số", "OK", ICon.Error);
                e.Cancel = true;
                return;
            }
            try
            {
                dGoldWeight = decimal.Parse(grvProduct.GetFocusedRowCellValue("GoldWeight").ToString());
                dGoldAgeChange = decimal.Parse(grvProduct.GetFocusedRowCellValue("GoldAgeChange").ToString());
                dGoldWeightChange = dGoldWeight * dGoldAge / dGoldAgeChange;
                grvProduct.SetFocusedRowCellValue(grvProduct.Columns["GoldWeightChange"], Math.Round(dGoldWeightChange, 2));
            }
            catch { }
        }
        
    }
}