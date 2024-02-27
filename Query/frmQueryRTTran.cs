using System;
using System.Data;
using System.Windows.Forms;
using Messages;
using GoldRT.Query.ucQueryRTTran;

namespace GoldRT
{
    public partial class frmQueryRTTran : DevExpress.XtraEditors.XtraForm
    {

        private UserControl uc;
        private string _strTrnType = string.Empty;
        private bool IsLoading = false;
        #region "Public Functions"
        public frmQueryRTTran()
        {
            InitializeComponent();

        }
        #endregion

        #region "Private Functions"
        private void f_loadDefault()
        {
            IsLoading = true;
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now.AddHours(-24);
        }

        private void f_loadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_TRNTYPE_GetAllType]");
                grdTrnType.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm f_loadDataToGrid: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void f_loadControlWithTrnType(string strTrnType)
        {           
            uc = null;
            _strTrnType = strTrnType;
            string strBillCode = txtBillCode.Text.Trim();
            switch (_strTrnType)
            {
                case "CRT":
                    cboEmp.Enabled = true;
                    uc = new ucCRT(strBillCode, txtCustName.Text, dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), 
                        dtpDenNgay.DateTime.ToString("dd/MM/yyyy"), ((ItemList)cboEmp.SelectedItem).ID);
                    break;
                case "BRT":
                    cboEmp.Enabled = false;
                    uc = new ucBRT(strBillCode, txtCustName.Text, dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"));
                    break;
                case "SRT":
                    cboEmp.Enabled = false;
                    uc = new ucSRT(strBillCode,(cboPhong.SelectedItem as ItemList).ID, dtpTuNgay.DateTime.ToString("dd/MM/yyyy HH:mm"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy HH:mm"));
                    break;
                case "FX":
                    cboEmp.Enabled = false;
                    uc = new ucFX(strBillCode, txtCustName.Text, dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"));
                    break;
            }

            if (uc != null)
            {
                pnlThongTin.Controls.Clear();
                pnlThongTin.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
        }
        #endregion

        #region "Event Handlers"
        private void frmQueryCust_Load(object sender, EventArgs e)
        {
            f_loadDefault();
            f_LoadCombo();
            f_loadDataToGrid();            
            btnIn.Dispose();
            btnCanceled.Enabled = clsSystem.IsAdmin=="1";
        }

        private void f_LoadCombo()
        {
            DataSet ds = new DataSet();

            try
            {
            //{
            //    ds = clsCommon.LoadComboSP("T_EMPLOYEE", "");
            //    Functions.BindDropDownList(cboEmp, ds, "EmpName", "EmpID", "", true, "Tất cả", "");
                ds = clsCommon.LoadComboSP("T_PHONG", "");
                Functions.BindDropDownList(cboPhong, ds, "TenPhong", "IDPhong", "", true, "Tất cả", "");
                ds.Clear();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvTrnType_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            f_loadControlWithTrnType(grvTrnType.GetFocusedRowCellValue("TrnCode").ToString());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            f_loadControlWithTrnType(grvTrnType.GetFocusedRowCellValue("TrnCode").ToString());
        }
        #endregion

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckeShowHour_CheckedChanged(object sender, EventArgs e)
        {
            switch (_strTrnType)
            {
                case "CRT":
                    (uc as ucCRT).fnShowHour(ckeShowHour.Checked);
                    break;
                case "BRT":
                    (uc as ucBRT).fnShowHour(ckeShowHour.Checked);
                    break;
                case "SRT":
                    (uc as ucSRT).fnShowHour(ckeShowHour.Checked);
                    break;
                case "FX":
                    (uc as ucFX).fnShowHour(ckeShowHour.Checked);
                    break;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string strParams = "";
            string strValues = "";
            //string TGV18K_CU;string TGV18K_MO;
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["Type"].ToString() = "Vàng mới")
            //    {
            //        if(ds.Tables[0].Rows[i]["GoldCode"].ToString() ""
            //    }
            //}
            
            string strFromDate = ((DateTime)dtpTuNgay.EditValue).ToString("dd/MM/yyyy");
            string strToDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");
            strParams = "TuNgay@DenNgay";
            strValues = strFromDate + "@" + strToDate;
            switch (_strTrnType)
            {
                case "CRT":
                    Functions.fn_ShowReport_AndImage((uc as ucCRT).DS, "rptTCDBu.rpt", strParams, strValues);
                    break;
                case "BRT":
                    Functions.fn_ShowReport_AndImage((uc as ucBRT).DS, "rptTCMDe.rpt", strParams, strValues);
                    break;
                case "SRT":
                    Functions.fn_ShowReport_AndImage((uc as ucSRT).DS, "rptTCMBan.rpt", strParams+"@TT", strValues+"@"+(uc as ucSRT).TT.ToString());
                    break;
                case "FX":
                    DataSet ds1 = clsCommon.ExecuteDatasetSP("[rptTCNTe_Lst]", 
                        dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),"0", "");
                    
                    Functions.fn_ShowReport_AndImage(ds1, "rptTCNTe.rpt", strParams, strValues);
                    break;
            }
        }

        private void grdTrnType_Click(object sender, EventArgs e)
        {

        }

        private void frmQueryRTTran_KeyDown(object sender, KeyEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Tra cuu giao dich.mht");
                Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Tra cuu giao dich.mht");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            switch (_strTrnType)
            {
                case "CRT":
                    this.printableComponentLink1.Component = ((ucCRT) uc).grdDanhSach;
                    if (!((ucCRT) uc).grdDanhSach.IsPrintingAvailable)
                    {
                        MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                        return;
                    }
                    //((ucCRT) uc).grdDanhSach.ShowPreview();
                    break;
                case "BRT":
                    this.printableComponentLink1.Component = ((ucBRT) uc).grdDanhSach;
                    if (!((ucBRT) uc).grdDanhSach.IsPrintingAvailable)
                    {
                        MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                        return;
                    }
                    //((ucBRT) uc).grdDanhSach.ShowPreview();
                    break;
                case "SRT":
                    this.printableComponentLink1.Component = ((ucSRT) uc).grdDanhSach;
                    if (!((ucSRT) uc).grdDanhSach.IsPrintingAvailable)
                    {
                        MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                        return;
                    }
                    //((ucSRT) uc).grdDanhSach.ShowPreview();
                    break;
                case "FX":
                    this.printableComponentLink1.Component = ((ucFX) uc).grdDanhSach;
                    if (!((ucFX) uc).grdDanhSach.IsPrintingAvailable)
                    {
                        MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                        return;
                    }
                    //((ucFX) uc).grdDanhSach.ShowPreview();
                    break;
            }

            // Opens the Preview window. 
            //grdControl.ShowPreview();
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview(); 
        }

        private void btnCanceled_Click(object sender, EventArgs e)
        {
            if (ThongBao.Show("Thông báo", "Bạn có thực sự muốn xóa không?", "Có", "Không", ICon.QuestionMark) == DialogResult.Cancel)
            {
                return;
            }
           
            DataSet ds = new DataSet();
            try
            {
                switch (_strTrnType)
                {
                    case "CRT":
                        ds = clsCommon.ExecuteDatasetSP("TRN_RT_CANCELED", _strTrnType,
                            dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), 
                            dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                            clsNumericFormat.fn_Join(txtBillCode.Text), txtCustName.Text, "");
                        break;
                    case "BRT":
                        ds = clsCommon.ExecuteDatasetSP("TRN_RT_CANCELED", _strTrnType,
                           dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), 
                           dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                           clsNumericFormat.fn_Join(txtBillCode.Text), txtCustName.Text, "");
                        break;
                    case "SRT":
                        ds = clsCommon.ExecuteDatasetSP("TRN_RT_CANCELED", _strTrnType,
                           dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), 
                           dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                           clsNumericFormat.fn_Join(txtBillCode.Text), txtCustName.Text, "");
                        break;
                    case "FX":
                        ds = clsCommon.ExecuteDatasetSP("TRN_RT_CANCELED", _strTrnType,
                           dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), 
                           dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                           clsNumericFormat.fn_Join(txtBillCode.Text), txtCustName.Text, "");
                        break;
                }
                f_loadControlWithTrnType(_strTrnType);
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
            } 
        }

        private void dtpTuNgay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
        }

        private void dtpDenNgay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
     
        }

        private void dtpTuNgay_EditValueChanged(object sender, EventArgs e)
        {

            if (IsLoading)
            {
                IsLoading = false;
                return;
            }
            DateTime dt = dtpTuNgay.DateTime;
            TimeSpan t = dtpDenNgay.DateTime - dt;
            if (Math.Abs(t.Days) > 90)
                dtpTuNgay.DateTime = dtpDenNgay.DateTime.AddDays(-90);
            
        }

        private void dtpDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (IsLoading)
            {
                IsLoading = false;
                return;
            }
            DateTime dt = dtpDenNgay.DateTime;
            TimeSpan t = dt - dtpTuNgay.DateTime;
            if (Math.Abs(t.Days) > 90)
                dtpDenNgay.DateTime = dtpTuNgay.DateTime.AddDays(90);

        }

      

    }
}