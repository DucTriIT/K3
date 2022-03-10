using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Messages;
using System.Collections;


namespace GoldRT
{
    public partial class frmProductILstApprove : DevExpress.XtraEditors.XtraForm
    {
        frmProduct_In frm;
       
        public frmProductILstApprove()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void fn_RefreshForm()
        {
            fn_LoadDataToGrid();
        }

        public frmProductILstApprove(frmProduct_In _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void fn_LoadDefault()
        {
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now;
            //dtpTuNgay.DateTime = DateTime.Now.AddDays(-15);
            cboLoaiVang.SelectedIndex = 0;
            cboStatus.SelectedIndex = 1;
            checkEdit1.Checked = false;
            chkNCC.Checked = false;
            chkNi.Checked=false;
            chkTaskPrice.Checked = false;
            grdDanhSach.Focus();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("I_GOLD", "G");
            Functions.BindDropDownList(cboLoaiVang, ds, "GoldDesc", "GoldCode", "", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
            Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("SYS_USERS", "");
            Functions.BindDropDownList(cboEmp, ds, "UserName", "UserID", "", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("T_STATUS", "PRODIN");
            Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
            ds.Clear();

            ds.Dispose();
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                if (checkEdit1.Checked)
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_ApprLstHienMa]", "", "I", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                                   "", ((ItemList)cboLoaiVang.SelectedItem).ID, "", ((ItemList)cboProductGroup.SelectedItem).ID, "", "", "", "", "",
                                   "", ((ItemList)cboEmp.SelectedItem).ID, "", ((ItemList)cboStatus.SelectedItem).ID, "TrnDate ASC");
                else                
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_ApprLst]", "", "I", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                    "", ((ItemList)cboLoaiVang.SelectedItem).ID, "", ((ItemList)cboProductGroup.SelectedItem).ID, "", "", "", "", "",
                    "", ((ItemList)cboEmp.SelectedItem).ID, "", ((ItemList)cboStatus.SelectedItem).ID, "TrnDate ASC",txtProductList.Text);

                gridControl.DataSource = ds.Tables[0];
                grdDanhSach.Columns["colChon"].ImageIndex = 0;
                if (cboStatus.SelectedIndex == 2)
                    btnApprove.Enabled = false;
                else
                    btnApprove.Enabled = true;
            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", "hàm fn_LoadDataToGrid: " + ex.Message, "OK", ICon.Error);
                return;            
            }
            finally
            {
                ds.Dispose();
            }
            
        }
        private void fn_LoadDataToGridShowMa()
        {
            DataSet ds = new DataSet();

            try
            {
                gridControl.DataSource = ds.Tables[0];
                grdDanhSach.Columns["colChon"].ImageIndex = 0;
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "hàm fn_LoadDataToGrid: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
            }

        }

        private void frmGoldPOLst_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToCombo();
            fn_LoadDefault();
            //this.ProductCode.Visible = false;
            
            this.IsGenProductCode.Visible = true;
            chkNi_CheckedChanged(sender, e);
            chkTaskPrice_CheckedChanged(sender, e);
            chkNCC_CheckedChanged(sender, e);
            fn_LoadDataToGrid();
            //checkEdit1.Checked = true;
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtProductList.Text = "";
            fn_LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        if (curValue != "")
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

        private bool fn_CheckValidate()
        {
            int iUpdCount = 0;
            bool bFlagGenCode = true;

            //Kiem tra co check dong nao ko?
            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {
                if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                {
                    iUpdCount += 1;
                }
            }

            if (iUpdCount == 0)
            {
                ThongBao.Show("Thông báo", "Vui lòng chọn dữ liệu trước khi thực hiện", "OK", ICon.Information);
                return false;
            }

            //Kiem tra da gen code chua?
            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {
                if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True" &&
                    grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["IsGenCode"]).ToString() == "N" )
                {
                    bFlagGenCode = false;
                    break;
                }
            }

            if (bFlagGenCode == false)
            {
                ThongBao.Show("Thông báo", "Vui lòng tạo mã hàng trước khi duyệt.", "OK", ICon.Information);
                return false;
            }

            return true;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int updCount = 0;

            if (!fn_CheckValidate()) { return; }

            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {
                if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                {
                    DataSet ds = new DataSet();

                    try
                    {
                        ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_IN_Appr]", grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString(), clsSystem.UserID);

                        if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                        {
                            flag = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        ThongBao.Show("Lỗi", "hàm btnApprove_Click: " + ex.Message, "OK", ICon.Error);
                        return;
                    }
                    finally
                    {
                        ds.Dispose();
                        updCount++;
                    }
                }
            }
            if (!flag)
            {
                ThongBao.Show("Lỗi", "Lỗi cập nhật dữ liệu.", "OK", ICon.Error);
            }
            else if (updCount > 0)
            {
                ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                txtProductList.Text = "";
            }

            fn_LoadDataToGrid();
        }

        private void btnViewProductCode_Click(object sender, EventArgs e)
        {
            if (grdDanhSach.FocusedRowHandle > -1)
            {
                frmGenCode frm = new frmGenCode(grdDanhSach.GetFocusedRowCellValue("TrnID").ToString());
                frm.ShowDialog();
            }
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
                    e.TotalValue = Decimal.Parse(e.TotalValue == null ? "0" : e.TotalValue.ToString()) + dCalValue;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
                    fn_LoadDataToGrid();
                    // // cập nhật trạng thái Focus và colChon của grid sau khi refresh
                    grdDanhSach.FocusedRowHandle = index;
                    foreach (Object obj in list)
                    {
                        for (int i = 0; i < grdDanhSach.RowCount; i++)
                        {
                            if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString() == (string)obj)
                            {
                                grdDanhSach.SetRowCellValue(i, grdDanhSach.Columns["colChon"], "True");
                                break;
                            }
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

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                //btnApprove.Enabled = false;
                //this.ProductCode.Visible = true;           
                this.IsGenProductCode.Visible = false;
                
            }
            else
            {
                btnApprove.Enabled = true;
                //this.ProductCode.Visible = false;
                this.IsGenProductCode.Visible = true;
                
            }
            fn_LoadDataToGrid();
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string strProductCode = "";
                strProductCode = txtProductCode.EditValue.ToString().ToUpper().Trim();
                if(txtProductList.Text == "")
                    txtProductList.Text += strProductCode + "@";
                else
                    txtProductList.Text += "@" + strProductCode + "@";
                txtProductList.Text = txtProductList.Text.Substring(0, txtProductList.Text.Length - 1);
                txtProductCode.Text = "";
                fn_LoadDataToGrid();

            }
        }
        

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (!gridControl.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window. 
            //grdControl.ShowPreview();
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview(); 
            //DataSet ds = new DataSet();
            //string strFromDate = "", strToDate = "";
            //string strParams, strValues;
            //try
            //{
            //    strFromDate = dtpTuNgay.DateTime.ToString("dd/MM/yyyy");
            //    strToDate = dtpDenNgay.DateTime.ToString("dd/MM/yyyy");
            //    strParams = "TuNgay@DenNgay@MainSectionName@SectionName@Unit";
            //    strValues = strFromDate + "@" + strToDate + "@" + "Tất cả" + "@" + "Tất cả"+"@"+clsSystem.UnitWeight;
            //    ds = clsCommon.ExecuteDatasetSP("rptBC006", "", "", strFromDate, strToDate);
            //    Functions.fn_ShowReport_AndImage(ds, "rptBC006.rpt", strParams, strValues);

            //    if (clsSystem.IsPO == true)
            //    {
            //        ds = clsCommon.ExecuteDatasetSP("[rptBC008_1]", "", "", strFromDate, strToDate);
            //        //Functions.fn_ShowReport(ds, "rptBC008.rpt", strParams, strValues);
            //        Functions.fn_ShowReport_AndImage(ds, "rptBC008.rpt", strParams, strValues);
            //    }
            //    else
            //    {
            //        ds = clsCommon.ExecuteDatasetSP("[rptBC008_1]", "", "", strFromDate, strToDate);
            //        //Functions.fn_ShowReport(ds, "rptBC008_1.rpt", strParams, strValues);
            //        Functions.fn_ShowReport_AndImage(ds, "rptBC008_1.rpt", strParams, strValues);
            //    }
            //}
            //catch
            //{
            //    ds.Dispose();
            //}
        }

        private void chkNi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNi.Checked)
            {
                grdDanhSach.Columns["RingSize"].Visible = true;
                grdDanhSach.Columns["RingSize"].VisibleIndex = 13;
            }
            else
                grdDanhSach.Columns["RingSize"].Visible = false; 
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

        
    }
}