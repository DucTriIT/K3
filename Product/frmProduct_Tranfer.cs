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
using System.IO.Ports;


namespace GoldRT
{
    public partial class frmProduct_Tranfer : DevExpress.XtraEditors.XtraForm
    {
        #region Private Variables
        private SerialPort comport = new SerialPort();
        private DataTable dtProduct = new DataTable();
        
        string strID = string.Empty;
        string strProductID = string.Empty;
        string strGroupID = string.Empty;
        string strQuayFrom = string.Empty;
        string strQuayTo = string.Empty;
        string strStampWeight = string.Empty;
        string strStoreFrom = string.Empty;
        bool Continue = true;
       
        #endregion

        #region Public Functions
        public frmProduct_Tranfer()
        {
            InitializeComponent();
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // This method will be called when there is data waiting in the port's buffer

            // Determain which mode (string or binary) the user is in
            // Read all the data waiting in the buffer
            try
            {
                if (btnHoanTat.Enabled)
                {
                    string data = "", strTotalWeight = "";

                    data = comport.ReadLine();//.ReadExisting();
                    // Display the text to the user in the terminal
                    //if (data.Contains("W"))
                    //{
                    strTotalWeight = parsingdata(data);
                    txtAllWeight.Invoke(new EventHandler(delegate { txtAllWeight.EditValue = strTotalWeight; }));
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

                iRounding =2;

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
                        dWeight = Math.Round(double.Parse(strResult) * (double)clsSystem.HSTL, iRounding);
                    }
                    else
                    {
                        double sTMP = double.Parse(strResult) * (double)clsSystem.HSTL;

                        if (sTMP % Math.Truncate(sTMP) < 0.5)
                        {
                            dWeight = Math.Truncate(sTMP) + 0.5;
                        }
                        else
                        {
                            dWeight = Math.Truncate(sTMP) + 1;
                        }
                    }
                    // strResult =  dWeight.ToString("0.##");
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
           // fn_LoadDataToGrid();
            fn_GetFocusedRowValue();
        }
        #endregion

        #region Private Functions
        private void fn_createProductDataTable()
        {
            this.dtProduct.Columns.Add("ProductID", typeof(string));
            this.dtProduct.Columns.Add("ProductCode", typeof(string));
            this.dtProduct.Columns.Add("ProductDesc", typeof(string));
            this.dtProduct.Columns.Add("PriceCcy", typeof(string));
            this.dtProduct.Columns.Add("GiaBanMon", typeof(string));
           
            
            this.dtProduct.Columns.Add("TaskPrice", typeof(decimal));
            this.dtProduct.Columns.Add("DiamondWeight", typeof(decimal));
            this.dtProduct.Columns.Add("TotalWeight", typeof(decimal));
            this.dtProduct.Columns.Add("StampWeight", typeof(decimal));
            this.dtProduct.Columns.Add("PriceUnit", typeof(string));

            this.dtProduct.Columns.Add("SL", typeof(decimal));
            


        }
        private void fn_EnableControl(bool bEditMode,string _status)
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
            txtAllWeight.Enabled = bEditMode;
           
            //cboQuayTo.SelectedIndex = 0;
            btnThem.Enabled = bEditMode;
           
            btnXoa.Enabled = bEditMode;
            
            btnHoanTat.Enabled = bEditMode;
            if (_status == "")
            {
               // cboQuayFrom.Enabled = true;
                SL.OptionsColumn.AllowEdit = true;
                cboQuayFrom.SelectedIndex = 0;
                cboQuayTo.Enabled = true;
                cboMainSectionTo.Enabled = true;
              //  cboStore.Enabled = true;
                btnThem.Enabled = true;
                btnHoanTat.Enabled = false;
                btnXoa.Enabled = true;
                txtProductCode.Enabled = true;
                txtAllWeight.Enabled = true;
                txtReason.Enabled = true;

            }
            else if (_status == "W")
            {
               // cboQuayFrom.Enabled = true;
                SL.OptionsColumn.AllowEdit = true;
                cboQuayTo.Enabled = true;
                cboMainSectionTo.Enabled = true;
               // cboStore.Enabled = true;
                btnThem.Enabled = false;
                btnHoanTat.Enabled = true;
                btnXoa.Enabled = true;
                txtProductCode.Enabled = true;
                txtAllWeight.Enabled = true;
                txtReason.Enabled = true;
            }
            else if (_status == "C")
            {
                SL.OptionsColumn.AllowEdit = false;
                cboQuayFrom.Enabled = false;
                cboQuayTo.Enabled = false;
                cboMainSectionTo.Enabled = false;
               // cboStore.Enabled = false;
                btnThem.Enabled = true;
                btnHoanTat.Enabled = false;
                btnXoa.Enabled =false;
                txtProductCode.Enabled = false;
                txtAllWeight.Enabled = false;
                txtReason.Enabled = false;
            }
        }

        private void fn_LoadDefault()
        {
            strID = string.Empty;
            strProductID = string.Empty;
            cboStatus.SelectedIndex = 0;
            Continue = true;
            txtProductCode.Text = string.Empty;
            txtGoldCode.Text = string.Empty;
            txtProductDesc.Text = string.Empty;
            txtProductGroup.Text = string.Empty;
            txtTaskPrice.Text = "0";
            txtGoldWeight.Text = "0";
            txtRingSize.Text = "0";
            txtTotalWeight.Text = "0";
            txtDiamondWeigth.Text = "0";
            txtProductGroup.Text = "";
            txtSL.Text = "";
            txtReason.Text = "";
            txtAllWeight.Text = "";
            dtProduct.Clear();
            gridControl.DataSource= dtProduct;
           // txtReason.Text = string.Empty;
            txtSectionName.Text = string.Empty;
            txtMainSectionName.Text = string.Empty;
            

            this.ActiveControl = txtProductCode;
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
          
            ds = clsCommon.LoadComboSP("T_SECTION", "");
            Functions.BindDropDownList(cboQuayFrom, ds, "SectionName", "SectionID", "", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("T_MAINSECTION", "");
            Functions.BindDropDownList(cboMainSectionTo, ds, "MainSectionName", "MainSectionID", "", true);
            ds.Clear();

            ds.Dispose();
            cboStatus.Properties.Items.Add(new ItemList("", "Rỗng"));
            cboStatus.Properties.Items.Add(new ItemList("W","Lưu tạm"));
            cboStatus.Properties.Items.Add(new ItemList("C", "Hoàn tất"));
        }
        public void fn_LoadDataToForm(string _strID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_Section_Get]",_strID);
                cboQuayFrom.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["SectionFromID"].ToString(), cboQuayFrom, 0);
                cboQuayTo.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["SectionToID"].ToString(), cboQuayTo, 0);
                string status = ds.Tables[0].Rows[0]["Status"].ToString();
                strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                txtAllWeight.EditValue = ds.Tables[0].Rows[0]["AllWeight"].ToString();
                txtReason.Text = ds.Tables[0].Rows[0]["Reason"].ToString();
                gridControl.DataSource = ds.Tables[0];
                fn_EnableControl(true, status);
            }
            catch
            {
            }
            finally
            {
                ds.Dispose();
            }
        }
        private void fn_GetFocusedRowValue()
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();
                strProductID = grdDanhSach.GetFocusedRowCellValue("ProductID").ToString();
                txtProductCode.Text = grdDanhSach.GetFocusedRowCellValue("ProductCode").ToString();
                //txtGoldCode.Text = grdDanhSach.GetFocusedRowCellValue("GoldDesc").ToString();
                txtProductDesc.Text = grdDanhSach.GetFocusedRowCellValue("ProductDesc").ToString();
                strGroupID = grdDanhSach.GetFocusedRowCellValue("GroupID").ToString();
             txtProductGroup.Text = grdDanhSach.GetFocusedRowCellValue("GroupName").ToString();
                txtTaskPrice.Text = grdDanhSach.GetFocusedRowCellValue("TaskPrice").ToString();
                txtTotalWeight.Text = grdDanhSach.GetFocusedRowCellValue("TotalWeight").ToString();
            //    txtGoldWeight.Text = grdDanhSach.GetFocusedRowCellValue("GoldWeight").ToString();
                txtDiamondWeigth.Text = grdDanhSach.GetFocusedRowCellValue("DiamondWeight").ToString();
                //txtRingSize.Text = grdDanhSach.GetFocusedRowCellValue("RingSize").ToString();
                cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("Status").ToString(), cboStatus, 0);
                //txtSectionName.Text = grdDanhSach.GetFocusedRowCellValue("SectionName").ToString();
                //txtMainSectionName.Text = grdDanhSach.GetFocusedRowCellValue("MainSectionName").ToString();
                //txtReason.Text = grdDanhSach.GetFocusedRowCellValue("Reson").ToString();
               txtSL.Text = grdDanhSach.GetFocusedRowCellValue("SL").ToString();
                ///
                //  cboQuayTo.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("Reson").ToString(), cboQuayTo, 0);
                //cboQuayFrom.SelectedIndex = Functions.GetSelectedIndexCombo(grdDanhSach.GetFocusedRowCellValue("SectionID").ToString(), cboQuayFrom, 0);
                //cboQuayFrom.Enabled = false;
               // cboQuayTo.Enabled = false;
            }
        }

        //private void fn_LoadDataToGrid()
        //{
        //    DataSet ds = new DataSet();

        //    this.Cursor = Cursors.WaitCursor;
        //    try
        //    {
        //        ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_Section_Lst]", "", "", "", "",
        //        "", "", "", "", "", "", "", "Trn_SecTion", "", "", "W", "");

        //        if (ds.Tables.Count > 0)
        //        {
        //            gridControl.DataSource = ds.Tables[0];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ds.Dispose();
        //        this.Cursor = Cursors.Default;
        //        ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
        //        return;
        //    }
        //    finally
        //    {
        //        ds.Dispose();
        //        this.Cursor = Cursors.Default;
        //    }
        //}
        #endregion

        #region Event Handlers
        private void frmProduct_Out_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToCombo();
            fn_createProductDataTable();
           // fn_OpenCOMPort();
            gridControl.DataSource = dtProduct;
          // fn_LoadDataToGrid();
            fn_EnableControl(false,"");
        }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fn_EnableControl(true, "W");
            fn_LoadDefault();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle < 0)
            {
                ThongBao.Show("Thông tin", "Chưa chọn dữ liệu để sửa.", "OK", ICon.Warning);
                return;
            }
           
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
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_Section_Del]", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                       // fn_LoadDataToGrid();
                        fn_EnableControl(true,"");
                        fn_LoadDefault();
                       // fn_GetFocusedRowValue();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
           // fn_EnableControl(false);
            fn_GetFocusedRowValue();
            gridControl.Enabled = true;
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
            bool IsDup=false;
            if (e.KeyChar == 13) //enter
            {
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["ProductCode"]).ToString() == txtProductCode.Text.Trim())
                    { IsDup = true;
                    break;
                    }
                }
                if (IsDup)
                {
                    ThongBao.Show("Thông báo","Mã hàng "+txtProductCode.Text+" đã tồn tại trên danh sách","OK",ICon.Information);
                    txtProductCode.Text = string.Empty;
                    return;
                }
                    fn_ChoiceProduct();

            }
        }

        private void fn_ChoiceProduct()
        {
            if (grdDanhSach.RowCount > 0)
            {

                if (((ItemList)cboQuayFrom.SelectedItem).ID == "" || ((ItemList)cboQuayTo.SelectedItem).ID == "")
                {
                    ThongBao.Show("Thông tin", "Phải chọn quầy trước.", "OK", ICon.Error);
                    return;
                }
            }
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
                return;
            }

            DataSet ds = new DataSet();
            string strPdtCode = txtProductCode.EditValue.ToString().ToUpper().Trim();
            txtProductCode.Text = strPdtCode;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_PRODUCT_GetByCodeForOut", strPdtCode);

                if (ds.Tables.Count > 0)
                {
                    //Tồn tại mã hàng cần nhập
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        if (ds.Tables[0].Rows[0]["ErrorCode"].ToString() == "0")
                        {
                            if (grdDanhSach.RowCount == 0)
                            {
                                cboQuayFrom.SelectedIndex=Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["SectionID"].ToString(),cboQuayFrom,0);
                                strProductID = ds.Tables[0].Rows[0]["ProductID"].ToString();
                                txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldDesc"].ToString();
                                txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                                txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();
                                strGroupID = ds.Tables[0].Rows[0]["GroupID"].ToString();
                                txtProductGroup.Text = ds.Tables[0].Rows[0]["GroupID"].ToString();
                                txtProductGroup.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
                                txtDiamondWeigth.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
                                txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
                                txtGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
                                txtRingSize.Text = ds.Tables[0].Rows[0]["RingSize"].ToString();
                                txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                                txtMainSectionName.Text = ds.Tables[0].Rows[0]["MainSectionName"].ToString();
                                txtPriceUnit.Text = ds.Tables[0].Rows[0]["PriceUnit"].ToString();
                                txtSL.Text = ds.Tables[0].Rows[0]["SL"].ToString();
                                txtGiaBanMon.Text = ds.Tables[0].Rows[0]["GiaBanMon"].ToString();
                                strStampWeight = ds.Tables[0].Rows[0]["StampWeight"].ToString();
                                grdDanhSach.AddNewRow();
                                grdDanhSach.UpdateCurrentRow();

                                /// Khóa quầy lại
                                //cboQuayFrom.Enabled = false;
                               // cboQuayTo.Enabled = false;
                                /// end Khóa quầy lại

                                txtProductCode.EditValue = string.Empty;
                                txtProductCode.Refresh();
                                txtProductCode.Focus();
                                /// thêm tiếp
                                /// 
                                //fn_LoadDataToForm(strID);
                                //fn_EnableControl(true);
                                //fn_LoadDefault();
                                gridControl.Enabled = true;
                            }
                            else
                            {

                                if (((ItemList)cboQuayFrom.SelectedItem).ID == "" || ((ItemList)cboQuayFrom.SelectedItem).ID != ds.Tables[0].Rows[0]["SectionID"].ToString())
                                {
                                    ThongBao.Show("Thông tin", "Hàng [" + strPdtCode + "] không có trong quầy.", "OK", ICon.Error);

                                    //Refresh lại dữ liệu thông tin sản phẩm khi mã hàng = rỗng
                                    txtProductCode.EditValue = string.Empty;
                                    txtProductCode.Refresh();
                                    txtProductCode.Focus();
                                    return;
                                }


                                else
                                {
                                    strProductID = ds.Tables[0].Rows[0]["ProductID"].ToString();
                                    txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldDesc"].ToString();
                                    txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                                    txtTaskPrice.Text = ds.Tables[0].Rows[0]["TaskPrice"].ToString();
                                    strGroupID = ds.Tables[0].Rows[0]["GroupID"].ToString();
                                    txtProductGroup.Text = ds.Tables[0].Rows[0]["GroupID"].ToString();
                                    txtProductGroup.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
                                    txtDiamondWeigth.Text = ds.Tables[0].Rows[0]["DiamondWeight"].ToString();
                                    txtTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
                                    txtGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
                                    txtRingSize.Text = ds.Tables[0].Rows[0]["RingSize"].ToString();
                                    txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                                    txtMainSectionName.Text = ds.Tables[0].Rows[0]["MainSectionName"].ToString();
                                    txtPriceUnit.Text = ds.Tables[0].Rows[0]["PriceUnit"].ToString();
                                    txtSL.Text = ds.Tables[0].Rows[0]["SL"].ToString();
                                    txtGiaBanMon.Text = ds.Tables[0].Rows[0]["GiaBanMon"].ToString();
                                    strStampWeight = ds.Tables[0].Rows[0]["StampWeight"].ToString();
                                    grdDanhSach.AddNewRow();
                                    grdDanhSach.UpdateCurrentRow();

                                    /// Khóa quầy lại
                                    cboQuayFrom.Enabled = false;
                                  //  cboQuayTo.Enabled = false;
                                    /// end Khóa quầy lại

                                    txtProductCode.EditValue = string.Empty;
                                    txtProductCode.Refresh();
                                    txtProductCode.Focus();
                                    /// thêm tiếp
                                    /// 
                                    //fn_LoadDataToForm(strID);
                                    //fn_EnableControl(true);
                                    //fn_LoadDefault();
                                    gridControl.Enabled = false;

                                }
                            }
                            Continue = true;
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
                return;
            }
            finally { ds.Dispose(); }
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            //fn_ChoiceProduct();
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int updCount = 0;
            if (!Continue)
                return;
            btnCapnhat_Click(null, null);
            if (string.IsNullOrEmpty(((ItemList)cboQuayTo.SelectedItem).ID) || ((ItemList)cboQuayTo.SelectedItem).ID == ((ItemList)cboQuayFrom.SelectedItem).ID)
            {
                ThongBao.Show("Thông báo","Quầy đến chưa chọn hoặc trùng với quầy chuyển","OK",ICon.Error);
                return;
            }
            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {

                DataSet ds = new DataSet();

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_Section_Appr_tranfer]", grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString(), clsSystem.UserID);
                    if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                        return;
                    }
                    else { fn_EnableControl(true, "C"); }
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
              //  this.frmProduct_Out_Load(sender, e);
                fn_EnableControl(false,"C");
            }

            if (updCount == 0)
                ThongBao.Show("Thông báo", "Vui lòng chọn dữ liệu trước khi thực hiện", "OK", ICon.Information);

            //fn_LoadDataToGrid();
        }

        private void btnCapNhat_Click()
        {

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
           

            decimal dTongTL = 0;
            string strReason = "", strProductIDs = "",strSLs="";
            
            decimal hs = clsSystem.HSTL;
            this.Cursor = Cursors.WaitCursor;
            
                strReason = txtReason.Text;
                dTongTL = decimal.Parse(txtAllWeight.Text.Trim()==""?"0":txtAllWeight.Text.Trim());
                DataSet ds = new DataSet();
                DataRow row;


                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (grdDanhSach.RowCount > 0)
                    {
                        for (int i = 0; i < grdDanhSach.RowCount; i++)
                        {
                            row = grdDanhSach.GetDataRow(i);

                            strProductIDs += row["ProductID"].ToString() + "@";
                            strSLs += row["SL"].ToString() + "@";

                        }
                        strProductIDs = strProductIDs.Substring(0, strProductIDs.Length - 1);
                        strSLs = strSLs.Length == 0 ? "" : strSLs.Substring(0, strSLs.Length - 1);

                    }
                    else
                    {
                        Continue = false;
                        return;
                        //strProductIDs = "";

                    }
                    if (strID == "")
                    {
                        ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_TrnSection_Ins]", "", DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("HH:mm:ss"),((ItemList)cboQuayFrom.SelectedItem).ID,((ItemList)cboQuayTo.SelectedItem).ID, strReason, dTongTL, strProductID,strSLs, clsSystem.UserID);
                    }
                    else
                    {
                        ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_Section_Upd]", strID, DateTime.Now.ToString("dd/MM/yyyy"),
                            DateTime.Now.ToString("HH:mm:ss"), ((ItemList)cboQuayFrom.SelectedItem).ID, ((ItemList)cboQuayTo.SelectedItem).ID, strReason, dTongTL,strProductIDs,strSLs, clsSystem.UserID);
                    }

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        cboStatus.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["Status"].ToString(), cboStatus, 0);
                        strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                        fn_EnableControl(true,"W");
                        fn_LoadDataToForm(strID);
                        gridControl.Enabled = true;
                       // fn_LoadDefault();
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

        private void grdDanhSach_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "ProductID", strProductID);
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "ProductCode", txtProductCode.Text.ToUpper());
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "ProductDesc", txtProductDesc.Text);

            this.grdDanhSach.SetRowCellValue(e.RowHandle, "StampWeight", strStampWeight==""?decimal.Parse(null):decimal.Parse(strStampWeight));
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "GoldWeight", txtGoldWeight.Text == "" ? decimal.Parse(null) : decimal.Parse(txtGoldWeight.Text));
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "DiamondWeight", txtDiamondWeigth.Text == "" ? decimal.Parse(null) : decimal.Parse(txtDiamondWeigth.Text));
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "TaskPrice", txtTaskPrice.Text == "" ? decimal.Parse(null) : decimal.Parse(txtTaskPrice.Text));
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "PriceUnit", txtPriceUnit.Text);
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "PriceCcy", txtPriceCcy.Text);
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "GiaBanMon", txtGiaBanMon.Text);
            this.grdDanhSach.SetRowCellValue(e.RowHandle, "SL", txtSL.Text);
        }

        private void grdDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            btnCapnhat_Click(null,null);
        }

        private void btnDanhsach_Click(object sender, EventArgs e)
        {
            frmProduct_Tranfer_Lst frm = new frmProduct_Tranfer_Lst(this);
            frm.ShowDialog();
        }

        private void frmProduct_Tranfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //fn_CloseCOMPort();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();
        }

        private void cboMainSectionTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strMainSectionID = "";
            try
            {
                strMainSectionID = ((ItemList)cboMainSectionTo.SelectedItem).ID;
            }
            catch
            { }
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("T_SECTION", strMainSectionID);
                Functions.BindDropDownList(cboQuayTo, ds, "SectionName", "SectionID", "", true);
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

        private void rtxtSL_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //decimal dSl = 0;
            //DataSet ds = new DataSet();
            //try
            //{
            //    string strID = grdDanhSach.GetFocusedRowCellValue("TrnID").ToString();
            //    if (!decimal.TryParse(e.NewValue.ToString(), out dSl))
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(strID))
            //        return;
            //    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_Section_Upd]", strID, DateTime.Now.ToString("dd/MM/yyyy"),
            //                DateTime.Now.ToString("HH:mm:ss"), ((ItemList)cboQuayFrom.SelectedItem).ID, ((ItemList)cboQuayTo.SelectedItem).ID, strReason, dTongTL, strProductIDs, strSLs, clsSystem.UserID);
            //    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_OUT_Upd]", strID, null, null, null, null, null, null, null, null, null, null, clsSystem.UserID, clsSystem.UserID, "W", null, dSl);
            //    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
            //    {
            //        fn_LoadDataToGrid();
            //    }
            //}
            //catch { }
            //finally
            //{
            //    grdDanhSach.UpdateTotalSummary();
            //    ds.Dispose();
            //}
        }

        private void btnTranfer_Click(object sender, EventArgs e)
        {

        }

       
    }
}