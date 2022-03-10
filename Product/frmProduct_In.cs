using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Messages;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO.Ports;

using DevExpress.Data.Filtering;

using System.Collections;

namespace GoldRT
{
    public partial class frmProduct_In : DevExpress.XtraEditors.XtraForm
    {
        private SerialPort comport = new SerialPort();
        public  string filename="";
        private Byte[] m_PrdtImage;
        public Byte[] PrdtImage
        {
            get { return m_PrdtImage; }
            set { m_PrdtImage = value; }
        }        

    #region Private Variables
        string strID = string.Empty;
        string sPUnit = string.Empty;
        bool bAddContinue = false;
        bool Continue = true;
        string strPriceUnit = "";
        bool IsRefresh = false;
        int a = 0;
        bool Sua = false;
        ArrayList list = new ArrayList();
        
    #endregion

    #region Public Functions
        public frmProduct_In()
        {
            InitializeComponent();
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
           // timer1.Start();
        }


        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // This method will be called when there is data waiting in the port's buffer

            // Determain which mode (string or binary) the user is in
            // Read all the data waiting in the buffer
            try
            {
                if (btnCapNhat.Enabled)
                {
                    string data = "", strTotalWeight = "";

                    data = comport.ReadLine();//.ReadExisting();
                    // Display the text to the user in the terminal
                    //if (data.Contains("W"))
                    //{
                    strTotalWeight = parsingdata(data);
                    txtTotalWeight.Invoke(new EventHandler(delegate { txtTotalWeight.EditValue = strTotalWeight; }));
                    // }
                    //txtProductDesc.Invoke(new EventHandler(delegate { txtProductDesc.EditValue = data + "-" + data.Substring(clsSystem.L_ParseData_Config_position, clsSystem.L_ParseData_Config_lenght); }));
                    //txtProductDesc.Invoke(new EventHandler(delegate { txtProductDesc.EditValue = data; }));
                    // MessageBox.Show(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //label2.Invoke(new EventHandler(delegate{label2.Text  = data;}));

            //Log(LogMsgType.Incoming, data);

        }
      
        private string parsingdata(string sData)
        {
            string strResult = "";
            double dWeight = 0;
            int iRounding = 0;

            try
            {                
                ////Bo 2 byte dac biet neu co
                //sData = sData.Replace((char)27+"", "");
                //sData = sData.Replace((char)33+"", "");
                //sData = sData.TrimStart();
                ////Bo ky tu 0 dau
                //if (sData.Substring(0, 2) == "0 ")
                //{
                //    sData = sData.Substring(1);
                //    sData = sData.TrimStart();
                //}

                iRounding = cboTotalWeightRounding.SelectedIndex;

                if (sData.Contains("g") || sData.Contains("G"))
                {
                    strResult = sData.Substring(clsSystem.G_ParseData_Config_position, clsSystem.G_ParseData_Config_length).Trim();
                    dWeight = Math.Round(double.Parse(strResult), iRounding);
                   // strResult = dWeight.ToString("0.##");
                }
                else
                {
                    if (clsSystem.L_ParseData_Config_length != 0)
                    {
                        strResult = sData.Substring(clsSystem.L_ParseData_Config_position, clsSystem.L_ParseData_Config_length).Trim();
                    }
                    else
                    {
                        strResult = sData.Substring(clsSystem.L_ParseData_Config_position).Trim();
                    }
                    if (iRounding == 0 || iRounding == 2)
                    {
                        dWeight = Math.Round(double.Parse(strResult) * (double)clsSystem.HSCan, iRounding);
                    }
                    else
                    {
                        double sTMP = double.Parse(strResult) * (double)clsSystem.HSCan;

                        if (sTMP % Math.Truncate(sTMP) < 0.5)
                        {
                            dWeight = Math.Truncate(sTMP) + 0.5;
                        }
                        else
                        {
                            dWeight = Math.Truncate(sTMP) + 1;
                        }
                    }
                    strResult =  dWeight.ToString("0.##");
                }
            }
            catch (Exception ex)
            {
                strResult = "0";
            }
            return strResult;
        }

        public void fn_RefreshForm()
        {
            fn_LoadDataToGrid();
            fn_GetFocusedRowValue();
        }
    #endregion

    #region Private Functions
        private void fn_EnableControl(bool bEditMode, string strPriceUnit, bool bIsGenStamp)
        {
            cboSection.Enabled = bEditMode;
            cboGoldCode.Enabled = bEditMode;
            cboProductGroup.Enabled = bEditMode;
            txtProductCode.Enabled = bEditMode;
            txtDiamondPrice.Enabled = bEditMode;
            txtGoldAge.Enabled = bEditMode;
            txtDiamondDlt.Enabled = bEditMode;
            txtDiamondInPrice.Enabled = bEditMode;
            txtMainSectionName.Enabled = bEditMode;
            txtEmpName.Enabled = bEditMode;
            txtProductDesc.Enabled = bEditMode;
           // cboTenhang.Enabled = bEditMode;
            txtSoLuong.Enabled = bEditMode;
            txtDiamondWeight.Enabled = bEditMode;
            txtTotalWeight.Enabled = bEditMode;
            cboTotalWeightRounding.Enabled = bEditMode;
            txtTaskPrice.Enabled = bEditMode;            
            txtRingSize.Enabled = bEditMode;
            txtTotalPrice.Enabled = bEditMode;
            txtGiaBanMon.Enabled = bEditMode;
            txtGiaVon.Enabled = bEditMode;
            txtPOTaskPrice.Enabled = bEditMode;
            cboNCC.Enabled = bEditMode;

            btnThem.Enabled = !bEditMode;
            btnSua.Enabled = !bEditMode;
            btnXoa.Enabled = !bEditMode;
            btnCapNhat.Enabled = bEditMode;
            btnGenCode.Enabled = !bEditMode;

            if (bEditMode)
            {
                switch (strPriceUnit)
                {
                    case "":
                        txtRingSize.Enabled = true;
                        txtTotalWeight.Enabled = true;
                        cboTotalWeightRounding.Enabled = true;
                        txtDiamondWeight.Enabled = true;
                        txtTaskPrice.Enabled = true;
                        txtTotalPrice.Enabled = true;
                        txtGiaBanMon.Enabled = true;
                        txtDiamondPrice.Enabled = false;
                        txtDiamondDlt.Enabled = false;
                        txtDiamondInPrice.Enabled = false;

                        txtPOTaskPrice.Enabled = false;
                        break;
                    case "L":
                        txtRingSize.Enabled = true;
                        txtTotalWeight.Enabled = true;
                        cboTotalWeightRounding.Enabled = true;
                        txtDiamondWeight.Enabled = true;
                        txtTaskPrice.Enabled = true;
                        txtTotalPrice.Enabled = true;
                        txtGiaBanMon.Enabled = false;
                        txtDiamondPrice.Enabled = true;
                        txtDiamondInPrice.Enabled = true;
                        txtDiamondDlt.Enabled = true;
                        txtPOTaskPrice.Enabled = true;
                        break;
                    case "G":
                        txtRingSize.Enabled = true;
                        txtTotalWeight.Enabled = true;
                        cboTotalWeightRounding.Enabled = true;
                        txtDiamondWeight.Enabled = false;
                        txtTaskPrice.Enabled = false;
                        txtTotalPrice.Enabled = false;
                        txtGiaBanMon.Enabled = false;
                        txtDiamondPrice.Enabled = false;
                        txtDiamondDlt.Enabled = false;
                        txtDiamondInPrice.Enabled = false;
                        txtPOTaskPrice.Enabled = false;
                        break;
                    case "M":
                        txtRingSize.Enabled = true;
                        txtTotalWeight.Enabled = true;
                        cboTotalWeightRounding.Enabled = false;
                        txtDiamondWeight.Enabled = false;
                        txtTaskPrice.Enabled = false;
                        txtTotalPrice.Enabled = false;
                        txtGiaBanMon.Enabled = true;
                        txtDiamondPrice.Enabled = true;
                        txtDiamondDlt.Enabled = false;
                        txtDiamondInPrice.Enabled = false;
                        txtPOTaskPrice.Enabled = false;
                        break;
                }
            }
            else
            {
                switch (strPriceUnit)
                {
                    case "Tem":
                        btnThem.Enabled = bEditMode;
                        btnSua.Enabled = bEditMode;
                        btnXoa.Enabled = bEditMode;
                        btnCapNhat.Enabled = !bEditMode;
                        btnGenCode.Enabled = bEditMode;
                        txtSoLuong.Enabled = !bEditMode;
                        break;
                }
            }
            if (bIsGenStamp)
            {
               // btnSua.Enabled = false;
            }
        }
        private void fn_SetValueControl(string strPriceUnit)
        {
            switch (strPriceUnit)
            {
                case "":
                    break;
                case "L":
                    txtRingSize.EditValue = 0;//Ni
                    txtTotalPrice.EditValue= 0;// Gia von
                    break;
                case "G"://Vang Y
                    txtTotalPrice.EditValue = 0;// Gia von
                    txtTaskPrice.EditValue = 0;//Cong
                    break;
                case "M": //Cam Thach
                    txtTaskPrice.EditValue = 0;//Cong                    
                    break;
            }
        }
        private void fn_LoadDefault()
        {
            //Duc Son Edit - 24/04 - By Request Customer.            
            //cboSection.SelectedIndex = 0;
            //cboGoldCode.SelectedIndex = 0;
            //txtMainSectionName.Text = string.Empty;
            //txtEmpName.Text = string.Empty;
            //txtTotalPrice.EditValue = null;
            //txtTaskPrice.EditValue = null;
            //review
            if (txtTotalPrice.EditValue == null || txtTotalPrice.Text == "")//txtTaskPrice.EditValue != null)
            {
                txtTaskPrice.Enabled  = txtTotalWeight.Enabled = cboTotalWeightRounding.Enabled =
                    txtDiamondWeight.Enabled = txtRingSize.Enabled = true;                
            }
            else
            {
                txtTotalPrice.Enabled = txtTotalWeight.Enabled = cboTotalWeightRounding.Enabled = true;                
            }
            //
            strID = String.Empty;
            cboStatus.SelectedIndex = 0;            
            //cboProductGroup.SelectedIndex = 0;            
            //cboTenhang.SelectedIndex = 0;
            //txtTotalWeight.EditValue = decimal.Zero;            
            
            //txtPOTaskPrice1.EditValue = null;
            //txtPOTaskPrice2.EditValue = null;
            filename = "";
            txtSoLuong.EditValue = "1";
            txtRingSize.EditValue = null;
            txtTotalWeight.EditValue = null;
            txtDiamondWeight.EditValue = null;//decimal.Zero;
            txtProductCode.Text = "";
            txtDiamondPrice.EditValue = decimal.Zero;
            txtDiamondInPrice.EditValue = decimal.Zero;
            txtDiamondDlt.Text = string.Empty;
            txtGoldAge.EditValue = decimal.Zero;
            //txtPOTaskPrice.EditValue = decimal.Zero;
            //cboTotalWeightRounding.SelectedIndex = 0;
            
            cboSection.Focus();
        }
        //private void fn_LoadUnit()
        //{
        //    DataSet ds = new DataSet();
        //    ds = clsCommon.LoadComboSP("TRN_PROCDUCT_IN", "");
        //    Functions.BindDropDownList(cboTenhang, ds, "ProductDesc", "ProductDesc", "", true);
        //    ds.Clear();
        //    fn_GetFocusedRowValue();
        //}
        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("T_STATUS", "PRODIN");
                Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
                ds.Clear();

                ds = clsCommon.LoadComboSP("T_SECTION", "");
                Functions.BindDropDownList(cboSection, ds, "SectionName", "SectionID", "", true);
                ds.Clear();

                //ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
                //Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
                //ds.Clear();

                ds = clsCommon.LoadComboSP("T_SUPPLIER", "KH");
                Functions.BindDropDownList(cboNCC, ds, "SupplierName", "SupplierID", "", true);
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

        private bool fn_CheckValidate()
        {
            string strGodlCode=((ItemList)cboGoldCode.SelectedItem).ID;
            DataRow[] dr = clsSystem.IGold.Tables[0].Select("GoldCode='" + strGodlCode + "'");
            string strPriceUnit = "";
            
            if (dr.Length !=0) strPriceUnit = dr[0]["PriceUnit"].ToString();

            if (cboSection.SelectedIndex == 0 || cboSection.SelectedIndex == -1)
            {
                ThongBao.Show("Thông báo", "Vui lòng chọn quầy hàng.", "OK", ICon.Information);
                cboSection.Focus();
                return false;            
            }

            if (cboGoldCode.SelectedIndex == 0 || cboGoldCode.SelectedIndex == -1)
            {
                ThongBao.Show("Thông báo", "Vui lòng chọn loại vàng.", "OK", ICon.Information);
                cboGoldCode.Focus();
                return false;
            }

            if (strPriceUnit == "L") // Neu la vang chi
            {
                if (txtTotalWeight.Text.Trim() == "")
                {
                    ThongBao.Show("Thông báo", "Vui lòng nhập trọng lượng vàng luôn hột.", "OK", ICon.Information);
                    txtTotalWeight.Focus();
                    return false;
                }
                else
                {
                    if (txtTotalWeight.EditValue == null)
                        txtTotalWeight.EditValue = decimal.Zero;
                    if (!Functions.IsInfinitiveNumeric(txtTotalWeight.EditValue.ToString()))
                    {
                        ThongBao.Show("Thông báo", "Trọng lượng vàng luôn hột phải là số dương.", "OK", ICon.Information);
                        txtTotalWeight.Focus();
                        return false;                    
                    }
                }
                if (txtDiamondWeight.Text.Trim() == "")
                {
                    ThongBao.Show("Thông báo", "Vui lòng nhập trọng lượng hột.", "OK", ICon.Information);
                    txtDiamondWeight.Focus();
                    return false;
                }
                else
                {
                    if (txtDiamondWeight.EditValue == null)
                        txtDiamondWeight.EditValue = decimal.Zero;
                    if (!Functions.IsInfinitiveNumeric(txtDiamondWeight.EditValue.ToString()))
                    {
                        ThongBao.Show("Thông báo", "Trọng lượng hột phải là số dương.", "OK", ICon.Information);
                        txtDiamondWeight.Focus();
                        return false;
                    }
                }
                if (txtTaskPrice.Text.Trim() == "")
                {
                    ThongBao.Show("Thông báo", "Vui lòng nhập giá công.", "OK", ICon.Information);
                    txtTaskPrice.Focus();
                    return false;
                }
                else
                {
                    if (!Functions.IsInfinitiveNumeric(txtTaskPrice.EditValue.ToString()))
                    {
                        ThongBao.Show("Thông báo", "Giá công phải là số dương.", "OK", ICon.Information);
                        txtTaskPrice.Focus();
                        return false;
                    }
                }

                //if (txtPOTaskPrice1.Text.Trim() == "")
                //{
                //    ThongBao.Show("Thông báo", "Vui lòng nhập giá công sỉ 1.", "OK", ICon.Information);
                //    txtPOTaskPrice1.Focus();
                //    return false;
                //}
                //else
                //{
                //    if (!Functions.IsInfinitiveNumeric(txtPOTaskPrice1.EditValue.ToString()))
                //    {
                //        ThongBao.Show("Thông báo", "Giá công sỉ 1 phải là số dương.", "OK", ICon.Information);
                //        txtPOTaskPrice1.Focus();
                //        return false;
                //    }
                //}

                //if (txtPOTaskPrice2.Text.Trim() == "")
                //{
                //    ThongBao.Show("Thông báo", "Vui lòng nhập giá công sỉ 2.", "OK", ICon.Information);
                //    txtPOTaskPrice2.Focus();
                //    return false;
                //}
                //else
                //{
                //    if (!Functions.IsInfinitiveNumeric(txtPOTaskPrice2.EditValue.ToString()))
                //    {
                //        ThongBao.Show("Thông báo", "Giá công phải là số dương sỉ 2.", "OK", ICon.Information);
                //        txtPOTaskPrice2.Focus();
                //        return false;
                //    }
                //}

                if (decimal.Parse(txtTotalWeight.EditValue.ToString()) <= decimal.Parse(txtDiamondWeight.EditValue.ToString()))
                {
                    ThongBao.Show("Thông báo", "TL hột phải nhỏ hơn TL vàng luôn hột.", "OK", ICon.Information);
                    txtTotalWeight.Focus();
                    return false;
                }
            }
            else if (strPriceUnit == "G") // Neu la vang chi
            {
                if (txtTotalWeight.Text.Trim() == "")
                {
                    ThongBao.Show("Thông báo", "Vui lòng nhập trọng lượng vàng luôn hột.", "OK", ICon.Information);
                    txtTotalWeight.Focus();
                    return false;
                }
                else
                {
                    if (txtTotalWeight.EditValue == null || !Functions.IsInfinitiveNumeric(txtTotalWeight.EditValue.ToString()))
                    {
                        ThongBao.Show("Thông báo", "Trọng lượng vàng luôn hột phải là số dương.", "OK", ICon.Information);
                        txtTotalWeight.Focus();
                        return false;
                    }
                }
                //if (txtTotalPrice.Text.Trim() == "")
                //{
                //    ThongBao.Show("Thông báo", "Vui lòng nhập giá vốn.", "OK", ICon.Information);
                //    txtTotalPrice.Focus();
                //    return false;
                //}
                //else
                //{
                //    if (!Functions.IsInfinitiveNumeric(txtTotalPrice.EditValue.ToString()))
                //    {
                //        ThongBao.Show("Thông báo", "Giá vốn luôn hột phải là số dương.", "OK", ICon.Information);
                //        txtTotalPrice.Focus();
                //        return false;
                //    }
                //}
            }
            else  //Vang tinh theo mon
            {
                if (txtGiaBanMon.Text.Trim() == "")
                {
                    ThongBao.Show("Thông báo", "Vui lòng nhập giá bán vốn.", "OK", ICon.Information);
                    txtGiaBanMon.Focus();
                    return false;
                }
                else
                {
                    if (!Functions.IsInfinitiveNumeric(txtGiaBanMon.EditValue.ToString()))
                    {
                        ThongBao.Show("Thông báo", " giá bán vốn luôn hột phải là số dương.", "OK", ICon.Information);
                        txtGiaBanMon.Focus();
                        return false;
                    }
                }
            }

            if (!Functions.IsInterger(txtSoLuong.Text.Trim()))
            {
                ThongBao.Show("Thông báo", "Số lượng nhập phải là số nguyên dương.", "OK", ICon.Information);
                txtSoLuong.Focus();
                return false;
            }
            else
            {
                if (int.Parse(txtSoLuong.Text.Trim()) <= 0)
                {
                    ThongBao.Show("Thông báo", "Số lượng nhập phải là lớn hơn 0.", "OK", ICon.Information);
                    txtSoLuong.Focus();
                    return false;                
                }
            }

            return true;
        }

        private void fn_GetFocusedRowValue()
        {
            if (IsRefresh == true)
            {
                a++;
                if (a == 2)
                {
                    IsRefresh = false;
                    a = 0;
                }
                return;
            }
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();
                cboSection.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("SectionID").ToString(), cboSection, 0);
                cboGoldCode.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("GoldCode").ToString(), cboGoldCode, 0);
                cboProductGroup.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("GroupID").ToString(), cboProductGroup, 0);
                txtProductDesc.Text = grdDanhSach.GetFocusedRowCellValue("ProductDesc").ToString();
                //cboTenhang.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("ProductDesc").ToString(), cboTenhang, 1);
                cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("Status").ToString(), cboStatus, 0);
                cboNCC.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("SupplierID").ToString(), cboNCC, 0);
                txtGoldAge.EditValue = grdDanhSach.GetFocusedRowCellValue("GoldAge");
                txtTaskPrice.EditValue = grdDanhSach.GetFocusedRowCellValue("TaskPrice");
                //txtPOTaskPrice1.EditValue = grdDanhSach.GetFocusedRowCellValue("POTaskPrice1");
                //txtPOTaskPrice2.EditValue = grdDanhSach.GetFocusedRowCellValue("POTaskPrice2");
                txtDiamondWeight.EditValue = grdDanhSach.GetFocusedRowCellValue("DiamondWeight");
                txtTotalWeight.EditValue = grdDanhSach.GetFocusedRowCellValue("TotalWeight");
                txtSoLuong.EditValue = grdDanhSach.GetFocusedRowCellValue("Quantity");
                txtRingSize.EditValue = grdDanhSach.GetFocusedRowCellValue("RingSize");
                txtTotalPrice.EditValue = grdDanhSach.GetFocusedRowCellValue("InPrice");
                txtGiaBanMon.EditValue = grdDanhSach.GetFocusedRowCellValue("GiaBanMon");
                txtGiaVon.EditValue = grdDanhSach.GetFocusedRowCellValue("GiaVon");
               //txtProductCode.Text = grdDanhSach.GetFocusedRowCellValue("ProductCode").ToString();
                txtDiamondPrice.EditValue = grdDanhSach.GetFocusedRowCellValue("DiamondPrice");
                txtDiamondInPrice.EditValue = grdDanhSach.GetFocusedRowCellValue("DiamondInPrice");
                txtDiamondDlt.Text = grdDanhSach.GetFocusedRowCellValue("DiamondDlt").ToString();
                txtPOTaskPrice.EditValue = grdDanhSach.GetFocusedRowCellValue("POTaskPrice1");
                bool bIsGenStamp = grdDanhSach.GetFocusedRowCellValue("IsGenCode").ToString() == "Y" ? true : false;
                string strPriceUnit = grdDanhSach.GetFocusedRowCellValue("PriceUnit").ToString();
                filename = grdDanhSach.GetFocusedRowCellValue("Image").ToString();
                if (!string.IsNullOrEmpty(filename))
                {
                    PrdtImage = (Byte[])grdDanhSach.GetFocusedRowCellValue("Image");
                    MemoryStream fs = new MemoryStream(PrdtImage);
                    Bitmap bitmap = new Bitmap(fs);
                    picProduct.Image = bitmap;
                    //Bitmap bitmap = new Bitmap(grdDanhSach.GetFocusedRowCellValue("Image").ToString());
                    //picProduct.Image = ResizeImage2(bitmap, 100, 100);
                }
                else
                {
                    picProduct.Image = null;
                    PrdtImage = null;
                    filename = "";
                }

                fn_EnableControl(false, strPriceUnit, bIsGenStamp);               
            }
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_Lst]", "", "I", "", "", "", "", "", "", "", "",
                        "", "", "", "", clsSystem.UserID, "", "W", "TrnDate DESC,TrnTime DESC");

                if (ds.Tables.Count > 0)
                {
                    gridControl.DataSource = ds.Tables[0];
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
        private void frmProduct_In_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
           
            //fn_LoadUnit();
            fn_LoadDataToCombo();
            fn_LoadDataToGrid();
            if (grdDanhSach.RowCount == 0)
                fn_EnableControl(false,"",false);
            fn_OpenCOMPort();
            timer1.Start();
            if(!clsSystem.IsNoStamp)
                txtProductCode.Dispose();
            if (!clsSystem.IsDiamondPrice)
            {
                txtDiamondPrice.Dispose();
                txtDiamondInPrice.Dispose();
                txtDiamondDlt.Dispose();
            }
            if (!clsSystem.IsShowPOTaskPrice)
                txtPOTaskPrice.Dispose();
            this.DiamondPrice.Visible = clsSystem.IsDiamondPrice;
            chkNCC.Checked = chkTaskPrice.Checked = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fn_LoadDefault();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
            fn_EnableControl(true, strPriceUnit, false);            
            fn_LoadDefault();
            gridControl.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle < 0)
            {
                ThongBao.Show("Thông tin", "Chưa chọn dữ liệu để sửa.", "OK", ICon.Warning);
                return;
            }
            bool bIsGenStamp = grdDanhSach.GetFocusedRowCellValue("IsGenCode").ToString() == "Y" ? true : false;
            string strPriceUnit = grdDanhSach.GetFocusedRowCellValue("PriceUnit").ToString();
            Sua = true;
            fn_EnableControl(true, strPriceUnit, bIsGenStamp);
            txtSoLuong.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                ThongBao.Show("Thông báo", "Chưa chọn dữ liệu để xóa.", "OK", ICon.Information);
                return;
            }

            if (((ItemList)cboStatus.SelectedItem).ID == "C")
            {
                ThongBao.Show("Lỗi", "Không thể xóa thông tin này.", "OK", ICon.Error);
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc chắn là muốn xóa thông tin này?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    for (int i = 0; i < grdDanhSach.RowCount; i++)
                    {
                        if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                        {
                            if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["Status"]).ToString() == "C")
                            {
                                ThongBao.Show("Lỗi", "Không thể xóa thông tin này.", "OK", ICon.Error);
                                return;
                            }
                            ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_Del]", grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString());

                            if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                            {
                               
                            }
                            else
                            {
                                ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                            }

                        }
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
                    fn_LoadDataToGrid();
                    fn_EnableControl(false, "", false);
                    fn_GetFocusedRowValue();
                    gridControl.Enabled = true;
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            fn_EnableControl(false, "", false);
            fn_GetFocusedRowValue();
            gridControl.Enabled = true;
            Sua = false;
        }

        private bool KiemTraNhomHang()
        {
            foreach (ItemList item in cboProductGroup.Properties.Items)
            {
                if (cboProductGroup.SelectedItem.ToString() == item.Value.ToString())
                    return true;
            }
            return false;
        }

        private bool ThemNhomHang()
        {

            if (cboProductGroup.SelectedIndex == -1&& cboProductGroup.SelectedItem.ToString()!="")
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc thêm nhóm hàng này vào quầy " + cboSection.Text, "Có", "Không", ICon.QuestionMark) == DialogResult.Cancel)
                    return false;
                DataSet ds = new DataSet();
                string GroupID = string.Empty;
                try
                {

                    ds = clsCommon.ExecuteDatasetSP("[I_PRODUCT_GROUP_Ins]", "", cboProductGroup.SelectedItem.ToString().Substring(0, 1), cboProductGroup.SelectedItem.ToString().Trim(),((ItemList)cboSection.SelectedItem).ID, "1");

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        GroupID = ds.Tables[0].Rows[0]["GroupID"].ToString();
                        ds = clsCommon.LoadComboSP("I_SECTION_PRODUCT_GROUP", ((ItemList)cboSection.SelectedItem).ID);
                        Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", GroupID, true);
                        return true;
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ds.Dispose();
                    this.Cursor = Cursors.Default;
                    return false;
                }
                finally
                {
                    ds.Dispose();
                    this.Cursor = Cursors.Default;
                }
            }
            else
                return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string dongDangChon = "";
            decimal SoLuong = 1;
            bool Insert = false;
            if (!fn_CheckValidate()) return;
            if (!ThemNhomHang()) return;
           
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (strID == "")
                {
                    Insert = true;
                    SoLuong = int.Parse(txtSoLuong.Text);
                    if (SoLuong >= 10)
                    {
                        if (ThongBao.Show("Thông báo", "Bạn có chắc chắn nhập hàng với số lượng " + SoLuong + " món", "Có", "Không", ICon.QuestionMark) == DialogResult.Cancel)
                            return;

                    }
                    //if (txtProductCode.Text != "")
                    //{
                    //    //if (ThongBao.Show("Thông báo",
                    //    //              "Mã hàng này dành cho các mặt hàng không làm tem. Bạn có muốn khai báo thông tin này không?",
                    //    //              "Có", "Không", ICon.QuestionMark) == DialogResult.Cancel)
                    //       // return;
                    //    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_Ins]",
                    //               "", "I", DateTime.Now.ToString("dd/MM/yyyy"),
                    //               DateTime.Now.ToString("hh:mm:ss"), ((ItemList)cboSection.SelectedItem).ID,
                    //               ((ItemList)cboGoldCode.SelectedItem).ID,
                    //               txtProductDesc.Text, //cboTenhang.Text,
                    //               ((ItemList)cboProductGroup.SelectedItem).ID,
                    //               SoLuong,
                    //               txtTotalWeight.EditValue,
                    //               cboTotalWeightRounding.SelectedIndex,
                    //               txtDiamondWeight.EditValue,
                    //               txtTaskPrice.EditValue,
                    //               txtPOTaskPrice.EditValue,
                    //               null,
                    //               txtRingSize.EditValue,
                    //               txtTotalPrice.EditValue,
                    //               "", clsSystem.UserID, "", "W", this.PrdtImage, txtGiaBanMon.EditValue,
                    //               ((ItemList)cboNCC.SelectedItem).ID, txtGoldAge.EditValue, txtProductCode.Text,
                    //               txtDiamondPrice.EditValue.ToString() == "" ? "0" : txtDiamondPrice.EditValue.ToString(), txtDiamondInPrice.EditValue.ToString() == "" ? "0" : txtDiamondInPrice.EditValue.ToString(), txtDiamondDlt.Text.Trim(),txtGiaVon.EditValue);

                    //}
                    //else
                    //{
                        for (int i = 0; i < decimal.Parse(txtSoLuong.Text); i++)
                        {
                            ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_Ins]",
                                    "", "I", DateTime.Now.ToString("dd/MM/yyyy"),
                                    DateTime.Now.ToString("HH:mm:ss"), ((ItemList)cboSection.SelectedItem).ID,
                                    ((ItemList)cboGoldCode.SelectedItem).ID,
                                    txtProductDesc.Text,// cboTenhang.Text,
                                    ((ItemList)cboProductGroup.SelectedItem).ID,
                                    "1",
                                    txtTotalWeight.EditValue,
                                    cboTotalWeightRounding.SelectedIndex,
                                    txtDiamondWeight.EditValue,
                                    txtTaskPrice.EditValue,
                                    txtPOTaskPrice.EditValue,
                                    null,
                                    txtRingSize.EditValue,
                                    txtTotalPrice.EditValue,
                                    "", clsSystem.UserID, "", "W", this.PrdtImage, txtGiaBanMon.EditValue,
                                    ((ItemList)cboNCC.SelectedItem).ID, txtGoldAge.EditValue, txtProductCode.Text,
                                    txtDiamondPrice.EditValue.ToString() == "" ? "0" : txtDiamondPrice.EditValue.ToString(), txtDiamondInPrice.EditValue.ToString() == "" ? "0" : txtDiamondInPrice.EditValue.ToString(), txtDiamondDlt.Text.Trim(),txtGiaVon.EditValue);

                        }
                    
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_Upd]", 
                            strID, "I", null, null,
                            ((ItemList)cboSection.SelectedItem).ID,
                            ((ItemList)cboGoldCode.SelectedItem).ID,
                            txtProductDesc.Text,// cboTenhang.Text,                            
                            ((ItemList)cboProductGroup.SelectedItem).ID,
                            txtSoLuong.Text,
                            txtTotalWeight.EditValue,
                            cboTotalWeightRounding.SelectedIndex,
                            txtDiamondWeight.EditValue,
                            txtTaskPrice.EditValue,
                            txtPOTaskPrice.EditValue,
                            null,
                            txtRingSize.EditValue,
                            txtTotalPrice.EditValue,
                            "", clsSystem.UserID, "", "W",this.PrdtImage, txtGiaBanMon.EditValue,
                            ((ItemList)cboNCC.SelectedItem).ID,txtGoldAge.EditValue, null,
                            txtDiamondPrice.EditValue.ToString() == "" ? "0" : txtDiamondPrice.EditValue.ToString(), txtDiamondInPrice.EditValue.ToString() == "" ? "0" : txtDiamondInPrice.EditValue.ToString(), txtDiamondDlt.Text.Trim(),txtGiaVon.EditValue);
                    dongDangChon = strID;
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                    fn_EnableControl(false, "",false);
                    fn_LoadDataToGrid();
                    //fn_LoadUnit();
                    Sua = false;
                    gridControl.Enabled = true;
                    //if (dongDangChon == "")
                    //{
                    //    grdDanhSach.FocusedRowHandle = 0;
                    //    grdDanhSach.TopRowIndex = 0;
                    //    grdDanhSach.SelectRow(0);
                    //    grdDanhSach.SetRowCellValue(0, grdDanhSach.Columns["colChon"], true);
                    //}
                    //else
                    //{
                    //    ChonDongTrenLuoi(dongDangChon);
                    //}
                   // fn_GetFocusedRowValue();
                    btnPrintStamp.Focus();
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
                if (Insert == true)
                {
                    for (int i = 0; i < SoLuong; i++)
                        grdDanhSach.SetRowCellValue(i, grdDanhSach.Columns["colChon"], true);
                }
                else
                    grdDanhSach.SetRowCellValue(0, grdDanhSach.Columns["colChon"], true);
                
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                
                ds.Dispose();
                this.Cursor = Cursors.Default;
                //btnGenCode.Focus();
            }
        }
        void ChonDongTrenLuoi(string TrnId)
        {
            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {

                if (grdDanhSach.GetRowCellValue(i, "TrnID").ToString().ToUpper() == TrnId)
                {
                    grdDanhSach.SelectRow(i);
                    grdDanhSach.FocusedRowHandle = i;
                    return;
                    
                }

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

        private void btnGenCode_Click(object sender, EventArgs e)
        {
            string m_strTrnIDs = String.Empty;
            DataSet ds = new DataSet();

            try
            {
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                    {
                        m_strTrnIDs += grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString() + "@";
                        list.Add(i);
                    }
                }
                if (m_strTrnIDs != "")
                {
                    m_strTrnIDs = m_strTrnIDs.Substring(0, m_strTrnIDs.Length - 1);

                    ds = clsCommon.ExecuteDatasetSP("TRN_PRODUCT_IN_GenProductCode", m_strTrnIDs);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0") //Thanh cong
                    {
                        //ThongBao.Show("Thông báo", "Tạo mã hàng thàng công.", "OK", ICon.Information);
                        
                        fn_LoadDataToGrid();
                        fn_GetFocusedRowValue();
                       // btnPrintStamp.Focus();
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", "Tạo mã hàng thất bại. Vui lòng thử lại.", "OK", ICon.Error);
                        Continue = false;
                        return;
                    }
                }
                else
                {
                    ThongBao.Show("Lỗi", "Vui lòng bấm chọn vào ô vuông.", "OK", ICon.Error);
                    Continue = false;
                    return;                
                }
                foreach (Object obj in list)
                {
                    grdDanhSach.SetRowCellValue((int)obj, grdDanhSach.Columns["colChon"], true);
                }
               
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                Continue = false;
                return;
            }
            finally
            {
                ds = null;
                list.Clear();
            }
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSection.SelectedIndex == 0)
            {
                txtEmpName.Text = "";
                txtMainSectionName.Text = "";

            }
            else
            {
                DataSet ds = new DataSet();
                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[T_SECTION_Get]", ((ItemList)cboSection.SelectedItem).ID);
                    txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    txtMainSectionName.Text = ds.Tables[0].Rows[0]["MainSectionName"].ToString();                    
                    ds = clsCommon.LoadComboSP("I_SECTION_GROUP", ((ItemList)cboSection.SelectedItem).ID);
                    Functions.BindDropDownList(cboGoldCode, ds, "GoldDesc", "GoldCode", "", true);
                    cboGoldCode.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldCode"].ToString(), cboGoldCode, 0);
                    // Load data into cboProductGroup
                    ds = clsCommon.LoadComboSP("I_SECTION_PRODUCT_GROUP", ((ItemList)cboSection.SelectedItem).ID);
                    Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
                    
                }
                catch { }
                finally
                {
                    ds.Clear();
                    ds = null;
                }
            }
        }

     

        private void cboGoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGoldCode.SelectedIndex == 0)
            {
                strPriceUnit = "";
                return;
            } 

            string m_strGoldUnit = "";
            string m_strGoldCode = ((ItemList)cboGoldCode.SelectedItem).ID;

            foreach (DataRow row in clsSystem.IGold.Tables[0].Rows)
            {
                if (row["GoldCode"].ToString() == m_strGoldCode)
                {
                    m_strGoldUnit = row["PriceUnit"].ToString();
                    strPriceUnit = row["PriceUnit"].ToString();
                    lblPriceUnit.Text = "(" + row["PriceCcy"].ToString() + "/" + row["UnitDesc"].ToString() + ")";
                    break;
                }
            }           
            
            fn_EnableControl(true, m_strGoldUnit, false);
            fn_SetValueControl(m_strGoldUnit);
           
        }

        private void grdDanhSach_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    GridHitInfo hInfo = grdDanhSach.CalcHitInfo(new Point(e.X, e.Y));
                    if (hInfo.InRowCell && hInfo.Column.Name == "colChon")
                    {
                        string curValue = grdDanhSach.GetRowCellValue(hInfo.RowHandle, hInfo.Column).ToString();
                        grdDanhSach.SetRowCellValue(hInfo.RowHandle, hInfo.Column, curValue == "True" ? "False" : "True");
                    }

                    if (hInfo.InColumnPanel && hInfo.Column.Name == "colChon")
                    {
                        if (hInfo.Column.ImageIndex == 0)
                        {
                            for (int i = 0; i < grdDanhSach.RowCount; i++)
                            {
                                grdDanhSach.SetRowCellValue(i, hInfo.Column, "True");
                            }
                            hInfo.Column.ImageIndex = 1;
                        }
                        else
                        {
                            for (int i = 0; i < grdDanhSach.RowCount; i++)
                            {
                                grdDanhSach.SetRowCellValue(i, hInfo.Column, "False");
                            }
                            hInfo.Column.ImageIndex = 0;
                        }
                    }
                }
            }
            catch { }
        }


    #endregion

        #region Private Variables

        private void fn_OpenCOMPort()
        {
            try
            {
                if (comport.IsOpen) comport.Close();
                else
                {
                    // Set the port's settings
                    comport.BaudRate = int.Parse(clsSystem.BitPerSecond);
                    comport.DataBits = int.Parse(clsSystem.DataBit);
                    comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), clsSystem.StopBit);
                    comport.Parity = (Parity)Enum.Parse(typeof(Parity), clsSystem.Parity);
                    comport.PortName = clsSystem.PortName;
                    comport.ReadTimeout = int.Parse(clsSystem.ReadTimeout);
                    comport.Open();                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fn_CloseCOMPort()
        {
            if (comport.IsOpen) comport.Close();
        }

        public void SetPic(Image image)
        {
           
            try
            {
                //filename = _filename;
                //picProduct.Image = ResizeImage2(image, 100,100) ;
                Bitmap bitmap = new Bitmap(image);
                this.PrdtImage = BmpToBytes_MemStream(bitmap);
            }
            catch
            {
                ThongBao.Show("Lỗi", "Chọn không đúng định dạng ảnh. Vui lòng chọn lại.", "OK", ICon.Error);
            }
        }

        private byte[] BmpToBytes_MemStream(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            // Save to memory using the Jpeg format
            bmp.Save(ms, ImageFormat.Jpeg);

            // read to end
            byte[] bmpBytes = ms.GetBuffer();
            bmp.Dispose();
            ms.Close();

            return bmpBytes;
        }

        #endregion

        private void frmProduct_In_FormClosing(object sender, FormClosingEventArgs e)
        {
            fn_CloseCOMPort();
        }

        private void grdDanhSach_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            decimal dCalValue = 0;

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                string strFieldName = ((GridSummaryItem)e.Item).FieldName;

                if (strFieldName.ToUpper() != "QUANTITY")
                {
                    if (grdDanhSach.GetRowCellValue(e.RowHandle, grdDanhSach.Columns[strFieldName]).ToString() == "" || grdDanhSach.Columns[strFieldName] == null)
                    {
                        dCalValue = 0;
                    }
                    else
                    {
                        dCalValue = Decimal.Parse(grdDanhSach.GetRowCellValue(e.RowHandle, grdDanhSach.Columns[strFieldName]).ToString()) * Decimal.Parse(grdDanhSach.GetRowCellValue(e.RowHandle, grdDanhSach.Columns["Quantity"]).ToString());
                    }
                    //decimal dCalValue = Decimal.Parse() * Decimal.Parse(grdDanhSach.GetRowCellValue(e.RowHandle, grdDanhSach.Columns["Quantity"]).ToString());
                    e.TotalValue = Decimal.Parse(e.TotalValue == null ? "0" : e.TotalValue.ToString()) + dCalValue;
                }
            }
        }

        private void cboTotalWeightRounding_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strGodlCode = ((ItemList)cboGoldCode.SelectedItem).ID;
                DataRow[] dr = clsSystem.IGold.Tables[0].Select("GoldCode='" + strGodlCode + "'");
                string strTotalWeight = txtTotalWeight.EditValue.ToString();
                string strResult = txtTotalWeight.EditValue.ToString();
                int iRounding = cboTotalWeightRounding.SelectedIndex;
                string strPriceUnit = "";
                double dWeight = 0;


                if (dr.Length != 0) strPriceUnit = dr[0]["PriceUnit"].ToString();

                if (strPriceUnit == "M")
                {
                    strTotalWeight = string.Empty;
                }
                else
                {
                    //decimal dWeight = decimal.Round(decimal.Parse(strTotalWeight), iRounding);
                    if (iRounding == 0 || iRounding == 2)
                    {
                        dWeight = Math.Round(double.Parse(strResult), iRounding);
                    }
                    else
                    {
                        double sTMP = double.Parse(strResult);

                        if (sTMP % Math.Truncate(sTMP) < 0.5)
                        {
                            dWeight = Math.Truncate(sTMP) + 0.5;
                        }
                        else
                        {
                            dWeight = Math.Truncate(sTMP) + 1;
                        }
                    }

                    strTotalWeight = dWeight.ToString("0.##");  
                }


                txtTotalWeight.Invoke(new EventHandler(delegate { txtTotalWeight.EditValue = strTotalWeight; }));
            }
            catch
            {
            }
            
        }

        private void txtTaskPrice_Leave(object sender, EventArgs e)
        {
            //if (txtPOTaskPrice1.EditValue == null)
            //{
            //    txtPOTaskPrice1.EditValue = txtTaskPrice.EditValue;
            //}
            //if (txtPOTaskPrice2.EditValue == null)
            //{
            //    txtPOTaskPrice2.EditValue = txtTaskPrice.EditValue;
            //}
        }

        private void btnPrintStamp_Click(object sender, EventArgs e)
        {
            btnGenCode_Click(null, null);
            if (Continue == false)
            {
                Continue = true;
                return;
            }
            DataSet ds = new DataSet();
            string strSQL = "";
            string m_strRptName = "btPrintStamp_";
            string m_strTrnIDs = "";
            string m_strUnit = "";
            bool m_bIsSameUnit = true, m_bPrinted = false;
            int j, i;
            try
            {
                for (i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                    {
                        if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["Printed"]).ToString() == "Y")
                        {
                            m_bPrinted = true;
                            break;
                        }
                    }
                }

                if (m_bPrinted)
                {
                    if (ThongBao.Show("Thông báo", "Tem này đã được in, bạn có muốn in lại không?", "Có", "Không", ICon.QuestionMark) == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                for (i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                    {
                        m_strUnit = grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["PriceUnit"]).ToString();

                        for (j = i + 1; j < grdDanhSach.RowCount; j++)
                        {
                            if (grdDanhSach.GetRowCellValue(j, grdDanhSach.Columns["colChon"]).ToString() == "True")
                            {
                                if (grdDanhSach.GetRowCellValue(j, grdDanhSach.Columns["PriceUnit"]).ToString() != m_strUnit)
                                {
                                    m_bIsSameUnit = false;
                                    break;
                                }
                            }
                        }
                        if (j == grdDanhSach.RowCount)
                        {
                            m_strTrnIDs += grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString() + "@";
                        }
                    }
                }

                if (!m_bIsSameUnit)
                {
                    ThongBao.Show("Lỗi", "Vui lòng chọn cùng đơn vị loại vàng.", "OK", ICon.Error);
                    return;
                }

                if (m_strTrnIDs == "")
                {
                    ThongBao.Show("Lỗi", "Vui lòng bấm chọn vào ô vuông.", "OK", ICon.Error);
                    return;
                }
                else
                {
                    //using (Engine btEngine = new Engine())
                    //{
                    //    btEngine.Start();

                    //    m_strRptName += m_strUnit + ".btw";
                    //    strSQL = "SELECT * FROM vwPrintStamp_ProductIn WHERE CHARINDEX(TrnID, '" + m_strTrnIDs + "', 0) > 0";
                    //    //string strNgonNgu = cboNgonNguIn.SelectedIndex.ToString();
                    //    //strNgonNgu = cboNgonNguIn.SelectedIndex == 0 ? "V" : "H";
                    //    Functions.fn_PrintStamp_Bartender(m_strRptName, strSQL, "", btEngine);
                    //    //Update Printed
                    //    ds = clsCommon.ExecuteDatasetSP("rptPrintStamp", m_strTrnIDs, "", "PRODUCTIN");
                    //    btEngine.Stop(SaveOptions.DoNotSaveChanges);
                    //}
                    fn_LoadDataToGrid();
                    btnThem_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                //ThongBao.Show("Lỗi", "Hàm btnPrintStamp_Click: " + ex.Message, "OK", ICon.Error);
                fn_LoadDataToGrid();
                //return;
            }
            finally
            {
                ds.Dispose();                
            }
        }

        //Duc Son - 25/04 - New
        private void Controls_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnCapNhat_Click(sender, e);
            }
        }

        private void txtTotalPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCapNhat_Click(sender, e);
            }
        }
        //End Duc Son
       
        //Minh
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Sua == true)
                return;
            int index = 0;
            ArrayList list = new ArrayList();
            try
            {
                if (grdDanhSach.RowCount > 0)
                {
                    // giữ trạng thái Focus và colChon của grid trước khi refresh
                    if (grdDanhSach.FocusedRowHandle > 0)
                        index = grdDanhSach.FocusedRowHandle;
                    for (int i = 0; i < grdDanhSach.RowCount; i++)
                    {
                        if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                            list.Add(grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString());
                    }
                    fn_LoadDataToGridRefesh();
                    // // cập nhật trạng thái Focus và colChon của grid sau khi refresh
                    grdDanhSach.FocusedRowHandle = index;
                    foreach (Object obj in list)
                    {
                        for (int i = 0; i < grdDanhSach.RowCount; i++)
                        {
                            if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString() == (string)obj)
                                grdDanhSach.SetRowCellValue(i, grdDanhSach.Columns["colChon"], "True");
                        }

                    }
                }
            }
            catch
            {
                if (grdDanhSach.RowCount >= 0)
                {
                    grdDanhSach.FocusedRowHandle = 0;
                    grdDanhSach.SetRowCellValue(0, grdDanhSach.Columns["colChon"], "True");
                }
            }
        }

        private void fn_LoadDataToGridRefesh()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_Lst]", "", "I", "", "", "", "", "", "", "", "",
                        "", "", "", "", clsSystem.UserID, "", "W", "TrnDate DESC,TrnTime DESC");

                if (ds.Tables.Count > 0)
                {
                    IsRefresh = true;
                    gridControl.DataSource = ds.Tables[0];
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

        private void lnkChupAnh_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            frmChupHinh frm = new frmChupHinh(this);
            frm.ShowDialog();
        }

        public  Image ResizeImage2(Image sourceImage, int width, int height)
        {
            Image oThumbNail = new Bitmap(sourceImage, width, height);
            Graphics oGraphic = Graphics.FromImage(oThumbNail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, width, height);
            oGraphic.DrawImage(sourceImage, oRectangle);
            return oThumbNail;
        }

        private void lnkHuy_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            this.PrdtImage = null;
            picProduct.Image = null;
            filename = "";
        }

        private void lnkUpload_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.InitialDirectory = Application.StartupPath + "\\Image";
            fDialog.Filter="JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //filename = fDialog.FileName; 
                    Bitmap bitmap = new Bitmap(fDialog.FileName);
                    picProduct.Image = ResizeImage2(bitmap, 100, 100);
                    FileStream fs = new FileStream(fDialog.FileName, FileMode.Open, FileAccess.Read);
                    this.PrdtImage = new Byte[fs.Length];
                    fs.Read(this.PrdtImage, 0, int.Parse(fs.Length.ToString()));
                    
                }
                catch
                {
                    ThongBao.Show("Lỗi", "Chọn không đúng định dạng ảnh. Vui lòng chọn lại.", "OK", ICon.Error);
                }

            }
            
        }

        private void grdDanhSach_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "STT")
            {
                if (e.ListSourceRowIndex >= 0)
                {
                    e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strFromDate = "", strToDate = "";
            string strParams, strValues;
            try
            {
                strFromDate = DateTime.Today.AddMonths(-2).ToString("dd/MM/yyyy");
                strToDate = DateTime.Today.ToString("dd/MM/yyyy");
                strParams = "TuNgay@DenNgay@MainSectionName@SectionName";
                strValues = strFromDate + "@" + strToDate + "@" + "Tất cả" + "@" + "Tất cả";
                ds = clsCommon.ExecuteDatasetSP("rptBC005", "","",strFromDate, strToDate);
                Functions.fn_ShowReport_AndImage(ds, "rptBC005.rpt", strParams, strValues);
            }
            catch
            {
                ds.Dispose();
            }
        }

        private void cboProductGroup_Leave(object sender, EventArgs e)
        {
            if (ThemNhomHang() == false)
                cboProductGroup.Focus();
        }

        private void frmProduct_In_KeyDown(object sender, KeyEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Nhap hang.mht");
                Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Nhap hang.mht");
            }

        }

        private void cboNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnCapNhat_Click(null, null);
        }

        private void chkNCC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNCC.Checked)
            {
                grdDanhSach.Columns["SupplierName"].Visible = true;
                grdDanhSach.Columns["SupplierName"].VisibleIndex = 14;
            }
            else
                grdDanhSach.Columns["SupplierName"].Visible = false; 
        }

        private void chkTaskPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTaskPrice.Checked)
            {
                grdDanhSach.Columns["InPrice"].Visible = true;
                grdDanhSach.Columns["InPrice"].VisibleIndex = 12;
            }
            else
                grdDanhSach.Columns["InPrice"].Visible = false; 
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataSet ds = new DataSet();
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtProductCode.Text))
                    return;
                ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_GetByProductCode]",txtProductCode.Text.Trim(),"I");
                //strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cboSection.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["SectionID"].ToString(), cboSection, 0);
                    cboGoldCode.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldCode"].ToString(), cboGoldCode, 0);
                    cboProductGroup.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GroupID"].ToString(), cboProductGroup, 0);
                    cboNCC.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GroupID"].ToString(), cboProductGroup, 0);
                    txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                    //cboTenhang.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["ProductDesc"].ToString(), cboTenhang, 1);
                    // cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("Status").ToString(), cboStatus, 0);

                    txtTaskPrice.EditValue = ds.Tables[0].Rows[0]["TaskPrice"];
                    //txtPOTaskPrice1.EditValue = grdDanhSach.GetFocusedRowCellValue("POTaskPrice1");
                    //txtPOTaskPrice2.EditValue = grdDanhSach.GetFocusedRowCellValue("POTaskPrice2");
                    txtDiamondWeight.EditValue = ds.Tables[0].Rows[0]["DiamondWeight"];
                    txtTotalWeight.EditValue = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
                    txtSoLuong.EditValue = 1;
                    txtRingSize.EditValue = ds.Tables[0].Rows[0]["RingSize"];
                    txtTotalPrice.EditValue = ds.Tables[0].Rows[0]["InPrice"];
                    txtGiaBanMon.EditValue = ds.Tables[0].Rows[0]["GiaBanMon"];
                    //txtProductCode.Text = grdDanhSach.GetFocusedRowCellValue("ProductCode").ToString();
                    txtDiamondPrice.EditValue = ds.Tables[0].Rows[0]["DiamondPrice"];
                    txtDiamondInPrice.EditValue = ds.Tables[0].Rows[0]["DiamondInPrice"];
                    txtDiamondDlt.Text = ds.Tables[0].Rows[0]["DiamondDlt"].ToString();
                    txtPOTaskPrice.EditValue = ds.Tables[0].Rows[0]["POTaskPrice1"];
                    //bool bIsGenStamp = grdDanhSach.GetFocusedRowCellValue("IsGenCode").ToString() == "Y" ? true : false;
                    string strPriceUnit = ds.Tables[0].Rows[0]["PriceUnit"].ToString();
                    filename = ds.Tables[0].Rows[0]["Image"].ToString();
                    if (!string.IsNullOrEmpty(filename))
                    {
                        PrdtImage = (Byte[])grdDanhSach.GetFocusedRowCellValue("Image");
                        MemoryStream fs = new MemoryStream(PrdtImage);
                        Bitmap bitmap = new Bitmap(fs);
                        picProduct.Image = bitmap;
                        //Bitmap bitmap = new Bitmap(grdDanhSach.GetFocusedRowCellValue("Image").ToString());
                        //picProduct.Image = ResizeImage2(bitmap, 100, 100);
                    }
                    else
                    {
                        picProduct.Image = null;
                        PrdtImage = null;
                        filename = "";
                    }
                    fn_EnableControl(false, "Tem", false);
                }
                
                

 
            }
        }

        private void txtGiaBanMon_EditValueChanged(object sender, EventArgs e)
        {

        }

       
      

    }
}