using System;
using System.Data;
using System.Windows.Forms;
using Messages;
using DevExpress.XtraGrid.Views.Grid;

namespace GoldRT
{
    public partial class frmPOGold : DevExpress.XtraEditors.XtraForm
    {

    #region Private Variables
        private DataTable dtNull = new DataTable();
        private string strID = String.Empty;
        private string strCus = "";

        /// <summary>
        /// Trạng thái của toa dẻ hiện chọn
        /// </summary>
        private string strStatus = String.Empty;

        /// <summary>
        /// Mục địch: Tránh trường hợp Handle đến sự kiện 
        /// cboLoaiVang_SelectedIndexChanged của cboLoaiVang
        /// khi gán giá trị lên form
        /// </summary>
        private bool isSearching = false;
    #endregion
        
    #region Public Functions

        public frmPOGold()
        {
            InitializeComponent();

            this.dtNull.Columns.Add("GoldPODTID", typeof(string));
            this.dtNull.Columns.Add("GoldPOID", typeof(string));
            this.dtNull.Columns.Add("GoldCode", typeof(string));
            this.dtNull.Columns.Add("Total_Weight", typeof(decimal));
            this.dtNull.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtNull.Columns.Add("Dirty", typeof(decimal));
            this.dtNull.Columns.Add("GoldAge", typeof(decimal));
            this.dtNull.Columns.Add("GoldAgeChange", typeof(decimal));
            this.dtNull.Columns.Add("GoldWeight", typeof(decimal));
            this.dtNull.Columns.Add("GoldWeightChange", typeof(decimal));

            this.gridControl.DataSource = this.dtNull;
        }

        public frmPOGold(string _strCusID)
        {
            InitializeComponent();

            this.dtNull.Columns.Add("GoldPODTID", typeof(string));
            this.dtNull.Columns.Add("GoldPOID", typeof(string));
            this.dtNull.Columns.Add("GoldCode", typeof(string));
            this.dtNull.Columns.Add("Total_Weight", typeof(decimal));
            this.dtNull.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtNull.Columns.Add("Dirty", typeof(decimal));
            this.dtNull.Columns.Add("GoldAge", typeof(decimal));
            this.dtNull.Columns.Add("GoldAgeChange", typeof(decimal));
            this.dtNull.Columns.Add("GoldWeight", typeof(decimal));
            this.dtNull.Columns.Add("GoldWeightChange", typeof(decimal));

            this.gridControl.DataSource = this.dtNull;
            strCus = _strCusID;
        }

        public void fn_RefreshForm()
        {
            //this.fn_LoadDataToCombo();
            this.fn_LoadDataToForm();
        }

        /// <summary>
        /// Load dữ liệu lên form từ danh sách
        /// </summary>
        /// <param name="_ID">ID toa dẻ gán lên form</param>
        /// <param name="_CustID">Mã khách hàng của toa dẻ</param>
        /// <param name="_GoldCode">Loại vàng của toa dẻ</param>
        public void fn_LoadDataToForm(string _ID, string _CustID, string _GoldCode, string _GoldDesc, string _Status)
        {
            //Load thông tin
            this.strID = _ID;
            this.strStatus = _Status;
            cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(_Status, cboStatus, 0);

            cboKhachHang.SelectedIndex = Functions.GetSelectedIndexCombo(_CustID, cboKhachHang, 0);
            cboLoaiVang.SelectedIndex = Functions.GetSelectedIndexCombo(_GoldCode, cboLoaiVang, 0);

            //Nếu loại vàng không tồn tại trong cboLoaiVang => gán Text = GoldDesc
            if (cboLoaiVang.SelectedIndex == 0) cboLoaiVang.Text = _GoldDesc;

            fn_SetFormToEdit(_Status == "P");

            //Load danh sách
            DataSet dsDt = new DataSet();
            dsDt = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_DT_Lst]", "", strID, "", "", "", "", "", "", "", "");
            DataViewManager dvManager = new DataViewManager(dsDt);
            DataView dv = dvManager.CreateDataView(dsDt.Tables[0]);
            gridControl.DataSource = dv;

            isSearching = false;
        }

        public void fn_LoadDataToForm()
        {
            if (this.strID != "")
            {
                DataSet ds = new DataSet();

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_Get]", this.strID);

                    this.strStatus = ds.Tables[0].Rows[0]["Status"].ToString();
                    cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["Status"].ToString(), cboStatus, 0);

                    cboKhachHang.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["CustID"].ToString(), cboKhachHang, 0);
                    cboLoaiVang.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldCode"].ToString(), cboLoaiVang, 0);

                    //Nếu loại vàng không tồn tại trong cboLoaiVang => gán Text = GoldDesc
                    if (cboLoaiVang.SelectedIndex == 0) cboLoaiVang.Text = ds.Tables[0].Rows[0]["GoldDesc"].ToString();

                    fn_SetFormToEdit(ds.Tables[0].Rows[0]["Status"].ToString() == "P");

                    //Load danh sách
                    DataSet dsDt = new DataSet();
                    dsDt = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_DT_Lst]", "", strID, "", "", "", "", "", "", "", "");
                    DataViewManager dvManager = new DataViewManager(dsDt);
                    DataView dv = dvManager.CreateDataView(dsDt.Tables[0]);
                    gridControl.DataSource = dv;
                }
                catch
                {
                }
                finally
                {
                    ds.Dispose();
                }
            }
        }
    #endregion

    #region Private Functions
        /// <summary>
        /// Set trạng thai form được phép chỉnh sửa dữ liệu hay không?
        /// </summary>
        /// <param name="bEdit">
        /// true: được phép;
        /// false: không được phép
        /// </param>
        private void fn_SetFormToEdit(bool bEdit)
        {
            btnCapNhat.Enabled = bEdit;
            btnRowDel.Enabled = bEdit;
            btnXoa.Enabled = bEdit;
            btnComplete.Enabled = (this.strStatus == "C") ? false : true;
            btnComplete.Text = bEdit ? "&Hoàn tất" : "&Lấy lại";
            
            //Không được phép chọn thông tin toa dẻ nữa
            cboKhachHang.Enabled = bEdit;
            cboLoaiVang.Enabled = bEdit;

            grdDanhSach.OptionsView.NewItemRowPosition = bEdit ? NewItemRowPosition.Top : NewItemRowPosition.None;
            grdDanhSach.OptionsBehavior.Editable = bEdit;
        }

        private void fn_LoadDefault()
        {
            strID = String.Empty;
            cboKhachHang.SelectedIndex = 0;
            cboLoaiVang.SelectedIndex = 0;
            txtTenKH.Text = String.Empty;
            txtDiaChi.Text = String.Empty;
            cboStatus.SelectedIndex = 0;
            for (int i = grdDanhSach.RowCount - 1; i >= 0 ; i--)
            {
                grdDanhSach.DeleteRow(i);
            }
            grdDanhSach.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            grdDanhSach.OptionsBehavior.Editable = true;
            Functions.fn_SetFormCaption(this, "Lập toa dẻ");
            cboKhachHang.Enabled = true;
            cboLoaiVang.Enabled = true;

            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnRowDel.Enabled = false;
            btnDanhSach.Enabled = true;
            btnComplete.Enabled = false;

            cboKhachHang.Focus();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("I_CUSTOMER", "NOTWALKINCUST");
                Functions.BindDropDownList(cboKhachHang, ds, "CustInfo", "CustID", "", true);
                ds.Clear();                

                ds = clsCommon.LoadComboSP("I_GOLD", "D");
                Functions.BindDropDownList(cboLoaiDe, ds, "GoldDesc", "GoldCode", false);
                ds.Clear();

                ds = clsCommon.LoadComboSP("I_GOLD_PRICEUINT", "L");
                Functions.BindDropDownList(cboLoaiVang, ds, "GoldDesc", "GoldCode", "", true);
                ds.Clear();

                ds = clsCommon.LoadComboSP("T_STATUS", "PO");
                Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
                ds.Clear();
            }
            catch
            {
            }
            finally
            {
                ds.Dispose();
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu trên form
        /// </summary>
        /// <returns></returns>
        private bool fn_CheckValidate()
        {
            if (cboKhachHang.SelectedIndex <= 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn thông tin khách hàng.", "OK", ICon.Error);
                cboKhachHang.Focus();
                return false;
            }

            if (cboLoaiVang.SelectedIndex <= 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn thông tin loại vàng.", "OK", ICon.Error);
                cboLoaiVang.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập trên lưới
        /// </summary>
        /// <param name="dr">Dòng dữ liệu trên lưới</param>
        /// <param name="index">Index của dòng dữ liệu hiện tại</param>
        /// <returns></returns>
        private bool fn_ValidateDetails(DataRow dr, int index)
        {
            if (String.IsNullOrEmpty(dr["GoldCode"].ToString()))
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn thông tin loại dẻ.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            if (String.IsNullOrEmpty(dr["Total_Weight"].ToString()) || (Decimal)dr["Total_Weight"] < Decimal.Zero)
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột trọng lượng luôn hột.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            if (String.IsNullOrEmpty(dr["DiamondWeight"].ToString()) || (Decimal)dr["DiamondWeight"] < Decimal.Zero)
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột trọng lượng hột.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            if (String.IsNullOrEmpty(dr["Dirty"].ToString()) || (Decimal)dr["Dirty"] < Decimal.Zero)
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột trừ dơ.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            if (String.IsNullOrEmpty(dr["GoldAge"].ToString()) || (Decimal)dr["GoldAge"] < Decimal.Zero)
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột tuổi.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            if (String.IsNullOrEmpty(dr["GoldAgeChange"].ToString()) || (Decimal)dr["GoldAgeChange"] < Decimal.Zero)
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột tuổi qui đổi.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            if (String.IsNullOrEmpty(dr["GoldWeight"].ToString()) || (Decimal)dr["GoldWeight"] < Decimal.Zero)
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột trọng lượng vàng.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            if (String.IsNullOrEmpty(dr["GoldWeightChange"].ToString()) || (Decimal)dr["GoldWeightChange"] < Decimal.Zero)
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột vàng qui đổi.", "OK", ICon.Error);
                grdDanhSach.FocusedRowHandle = index;
                return false;
            }

            return true;
        }
    #endregion

    #region Event Handlers
        private void frmGoldPO_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            fn_LoadDefault();
            cboKhachHang.SelectedIndex = Functions.GetSelectedIndexCombo(strCus, cboKhachHang, 0);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboLoaiVang.SelectedIndex = 0;
            //cboLoaiVang.Properties.Items.Clear();

            string strCustID = ((ItemList)cboKhachHang.SelectedItem).ID;
            if (!String.IsNullOrEmpty(strCustID))
            {
                DataSet ds = new DataSet();

                try
                {
                    //Load thông tin khách hàng
                    ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_Get]", strCustID);
                    txtTenKH.Text = ds.Tables[0].Rows[0]["CustName"].ToString();
                    txtDiaChi.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    Functions.fn_SetFormCaption(this, "Lập toa dẻ - " + ds.Tables[0].Rows[0]["CustName"].ToString()); //Thay đổi tiêu đề
                    ds.Clear();

                    //Bind dữ liệu vào combo các loại vàng mà khách hàng đã giao dịch để lấy dẻ đổi vàng
                    //ds = clsCommon.LoadComboSP("I_GOLD_TRN_PO_PRODUCT", strCustID);
                    //Functions.BindDropDownList(cboLoaiVang, ds, "GoldDesc", "GoldCode", "", true);
                    //ds.Clear();

                }
                catch (Exception ex)
                {
                }
                finally
                {
                    ds.Dispose();
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            //Các biến chứa tham số thông tin toa dẻ
            string strTrn_CustID = String.Empty;
            string strTrn_GoldCode = String.Empty;
            string strTrn_Total_Weight = String.Empty;
            string strTrn_Total_GoldWeightChange = String.Empty;
            string strTrn_Status = String.Empty;
            string strTrn_UserID = String.Empty;

            //Các biến chứa tham số Details
            string strGoldCode = String.Empty;
            string strTotal_Weight = String.Empty;
            string strDiamondWeight = String.Empty;
            string strDirty = String.Empty;
            string strGoldAge = String.Empty;
            string strGoldAgeChange = String.Empty;
            string strGoldWeight = String.Empty;
            string strGoldWeightChange = String.Empty;

            if (!fn_CheckValidate())
                return;

            try
            {
                strTrn_CustID = ((ItemList)cboKhachHang.SelectedItem).ID;
                strTrn_GoldCode = ((ItemList)cboLoaiVang.SelectedItem).ID;
                strTrn_Total_Weight = decimal.Parse(grdDanhSach.Columns["GoldWeight"].SummaryText).ToString(Program.ciUS);
                strTrn_Total_GoldWeightChange = decimal.Parse(grdDanhSach.Columns["GoldWeightChange"].SummaryText).ToString(Program.ciUS);
                strTrn_Status = "P";
                strTrn_UserID = clsSystem.UserID;

                if (grdDanhSach.RowCount > 0)
                {
                    for (int i = 0; i < grdDanhSach.RowCount; i++)
                    {
                        DataRow row = grdDanhSach.GetDataRow(i);

                        if (!fn_ValidateDetails(row, i))
                            return;

                        strGoldCode += row["GoldCode"].ToString() + "@";
                        strTotal_Weight += decimal.Parse(row["Total_Weight"].ToString()).ToString(Program.ciUS) + "@";
                        strDiamondWeight += decimal.Parse(row["DiamondWeight"].ToString()).ToString(Program.ciUS) + "@";
                        strDirty += decimal.Parse(row["Dirty"].ToString()).ToString(Program.ciUS) + "@";
                        strGoldAge += decimal.Parse(row["GoldAge"].ToString()).ToString(Program.ciUS) + "@";
                        strGoldAgeChange += decimal.Parse(row["GoldAgeChange"].ToString()).ToString(Program.ciUS) + "@";
                        strGoldWeight += decimal.Parse(row["GoldWeight"].ToString()).ToString(Program.ciUS) + "@";
                        strGoldWeightChange += decimal.Parse(row["GoldWeightChange"].ToString()).ToString(Program.ciUS) + "@";
                    }

                    strGoldCode = strGoldCode.Substring(0, strGoldCode.Length - 1);
                    strTotal_Weight = strTotal_Weight.Substring(0, strTotal_Weight.Length - 1);
                    strDiamondWeight = strDiamondWeight.Substring(0, strDiamondWeight.Length - 1);
                    strDirty = strDirty.Substring(0, strDirty.Length - 1);
                    strGoldAge = strGoldAge.Substring(0, strGoldAge.Length - 1);
                    strGoldAgeChange = strGoldAgeChange.Substring(0, strGoldAgeChange.Length - 1);
                    strGoldWeight = strGoldWeight.Substring(0, strGoldWeight.Length - 1);
                    strGoldWeightChange = strGoldWeightChange.Substring(0, strGoldWeightChange.Length - 1);

                    if (String.IsNullOrEmpty(strID)) //Add new
                    {
                        ds = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_Ins]", "", strTrn_CustID, strTrn_GoldCode,
                            strTrn_Total_Weight, strTrn_Total_GoldWeightChange, strTrn_Status, strTrn_UserID, strGoldCode, strTotal_Weight,
                            strDiamondWeight, strDirty, strGoldAge, strGoldAgeChange, strGoldWeight, strGoldWeightChange);
                    }
                    else //Update
                    {
                        ds = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_Ins]", strID, strTrn_CustID, strTrn_GoldCode,
                            strTrn_Total_Weight, strTrn_Total_GoldWeightChange, strTrn_Status, strTrn_UserID, strGoldCode, strTotal_Weight,
                            strDiamondWeight, strDirty, strGoldAge, strGoldAgeChange, strGoldWeight, strGoldWeightChange);
                    }

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                        {
                            ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                            //Kết thúc cập nhật => thành công
                            this.strStatus = "P";
                            cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("P", cboStatus, 0);
                            this.strID = ds.Tables[0].Rows[0]["GoldPOID"].ToString();
                            fn_SetFormToEdit(true);
                        }
                        else
                        {
                            ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập chi tiết toa.", "OK", ICon.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            finally { ds.Dispose(); }
        }

        private void grdDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                //Tính toán cột GoldWeight & GoldWeightChange
                Decimal GoldWeight = (Decimal.Parse(((DataRowView)e.Row)["Total_Weight"].ToString()));// - Decimal.Parse(((DataRowView)e.Row)["DiamondWeight"].ToString()) - Decimal.Parse(((DataRowView)e.Row)["Dirty"].ToString()));
                Decimal GoldWeightChange = GoldWeight * Decimal.Parse(((DataRowView)e.Row)["GoldAge"].ToString()) / Decimal.Parse(((DataRowView)e.Row)["GoldAgeChange"].ToString());
                ((DataRowView)e.Row)["GoldWeight"] = Decimal.Round(GoldWeight, 2);
                ((DataRowView)e.Row)["GoldWeightChange"] = Decimal.Round(GoldWeightChange, 2);
            }
            catch { }
        }

        private void btnRowDel_Click(object sender, EventArgs e)
        {
            int[] index = grdDanhSach.GetSelectedRows();
            for (int i = 0; i < index.Length; i++)
                grdDanhSach.DeleteRow(index[i]);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá toa dẻ này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        fn_LoadDefault();
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

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            isSearching = true;
            frmPOGoldLst frm = new frmPOGoldLst(this);
            frm.ShowDialog();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.strID))
            {
                ThongBao.Show("Thông báo", "Vui lòng chọn dữ liệu trước khi thực hiện.", "OK", ICon.Error);
                return;
            }

            if (this.strStatus == "P")
            {
                clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_Upd]", this.strID, null, null, null, "W", null);
                this.strStatus = "W";
                cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("W", cboStatus, 0);
                fn_SetFormToEdit(false);
            }
            else
            {
                clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_Upd]", this.strID, null, null, null, "P", null);
                this.strStatus = "P";
                cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("P", cboStatus, 0);
                fn_SetFormToEdit(true);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fn_LoadDefault();
        }

        private void cboLoaiVang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiVang.SelectedIndex == 0)
            {
                return;
            }

            //Tìm kiếm toa đã tồn tại cho khách hàng được chọn ở trạng thái P hoặc W
            DataSet dsP = new DataSet(); //Danh sách toa dẻ ở trạng thái P
            DataSet dsW = new DataSet(); //Danh sách toa dẻ ở trạng thái W
            DataSet dsDt = new DataSet();
            try
            {
                dsP = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_Lst]", "", "", "", ((ItemList)cboKhachHang.SelectedItem).ID, "",
                    ((ItemList)cboLoaiVang.SelectedItem).ID, "", "P", "");

                dsW = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_Lst]", "", "", "", ((ItemList)cboKhachHang.SelectedItem).ID, "",
                    ((ItemList)cboLoaiVang.SelectedItem).ID, "", "W", "");

                //Nếu tồn tại toa dẻ ở trạng thái P hoặc W
                if (!isSearching && dsP.Tables.Count > 0 && dsP.Tables[0].Rows.Count > 0) //P
                {
                    //Hiển thị danh sách chi tiết toa
                    if (ThongBao.Show("Thông báo", "Đã tồn tại toa này trong hệ thống. Bạn có muốn hiển thị không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                    {
                        this.strID = dsP.Tables[0].Rows[0]["GoldPOID"].ToString();
                        dsDt = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_DT_Lst]", "", strID, "", "", "", "", "", "", "", "");
                        DataViewManager dvManager = new DataViewManager(dsDt);
                        DataView dv = dvManager.CreateDataView(dsDt.Tables[0]);
                        gridControl.DataSource = dv;
                        this.strStatus = "P";
                        cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("P", cboStatus, 0);
                        fn_SetFormToEdit(true);
                    }
                }
                else if (!isSearching && dsW.Tables.Count > 0 && dsW.Tables[0].Rows.Count > 0) //W
                {
                    if (ThongBao.Show("Thông báo", "Đã tồn tại toa này trong hệ thống. Bạn có muốn hiển thị không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                    {
                        this.strID = dsW.Tables[0].Rows[0]["GoldPOID"].ToString();
                        dsDt = clsCommon.ExecuteDatasetSP("[TRN_PO_GOLD_DT_Lst]", "", strID, "", "", "", "", "", "", "", "");
                        DataViewManager dvManager = new DataViewManager(dsDt);
                        DataView dv = dvManager.CreateDataView(dsDt.Tables[0]);
                        gridControl.DataSource = dv;
                        this.strStatus = "W";
                        cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo("W", cboStatus, 0);
                        fn_SetFormToEdit(false);
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                dsP.Dispose();
                dsW.Dispose();
                dsDt.Dispose();
            }
            btnCapNhat.Enabled = true;
            grdDanhSach.Focus();
        }

        private void grdDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GridView grd = (GridView)sender;
                grd.CloseEditor();
                grd.UpdateCurrentRow();
            }
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmPOMaster frm = new frmPOMaster(((ItemList)cboKhachHang.SelectedItem).ID);
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }

        private void grdDanhSach_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "DiamondWeight", 0);
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "Dirty", 0);
        }

    #region Rem
        /*private void grdDanhSach_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //Kiểm tra dữ liệu nhập trên lưới
            bool flag = true;
            if (String.IsNullOrEmpty(((DataRowView)e.Row)["GoldCode"].ToString()))
            {
                flag = false;
                ((DataRowView)e.Row).Row.SetColumnError("GoldCode", Message.strFieldNotEmpty);
            }
            if (String.IsNullOrEmpty(((DataRowView)e.Row)["Total_Weight"].ToString()))
            {
                flag = false;
                ((DataRowView)e.Row).Row.SetColumnError("Total_Weight", Message.strFieldNotEmpty);
            }
            if (String.IsNullOrEmpty(((DataRowView)e.Row)["DiamondWeight"].ToString()))
            {
                flag = false;
                ((DataRowView)e.Row).Row.SetColumnError("DiamondWeight", Message.strFieldNotEmpty);
            }
            if (String.IsNullOrEmpty(((DataRowView)e.Row)["Dirty"].ToString()))
            {
                flag = false;
                ((DataRowView)e.Row).Row.SetColumnError("Dirty", Message.strFieldNotEmpty);
            }
            if (String.IsNullOrEmpty(((DataRowView)e.Row)["GoldAge"].ToString()))
            {
                flag = false;
                ((DataRowView)e.Row).Row.SetColumnError("GoldAge", Message.strFieldNotEmpty);
            }
            if (String.IsNullOrEmpty(((DataRowView)e.Row)["GoldAgeChange"].ToString()))
            {
                flag = false;
                ((DataRowView)e.Row).Row.SetColumnError("GoldAgeChange", Message.strFieldNotEmpty);
            }
            //Trả kết quả
            if (!flag)
            {
                e.Valid = false;
            }
            else
            {
                ((DataRowView)e.Row).Row.ClearErrors();
            }
        }

        private void grdDanhSach_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }*/
    #endregion

    }
}
