using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using DevExpress.XtraGrid;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;

namespace GoldRT
{
    public partial class frmInventory_Check : DevExpress.XtraEditors.XtraForm
    {
        public frmInventory_Check()
        {
            InitializeComponent();
        }

        private void frmInventory_Check_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToCombo();
            fn_LoadDefault();
            this.SL.Visible = clsSystem.IsNoStamp;
            if(!clsSystem.IsNoStamp)
                txtSL.Dispose();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("T_SECTION", null);
                Functions.BindDropDownList(cboSection, ds, "SectionName", "SectionID", "", true,"","");
                ds.Clear();
                ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
                Functions.BindDropDownList(cboGroupID, ds, "GroupName", "GroupID", "", true);
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

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            string strSectionID = "";
            string strGroupID = "";
            this.Cursor = Cursors.WaitCursor;

            strSectionID = ((ItemList)cboSection.SelectedItem).ID;
            strGroupID = ((ItemList)cboGroupID.SelectedItem).ID;
            try
            {
                if (string.IsNullOrEmpty(strSectionID))
                {
                    DataTable dt = new DataTable();
                    gridControl.DataSource = dt;
                    return;
                }
                ds = clsCommon.ExecuteDatasetSP("T_PRODUCT_LstInvCheck", strSectionID,strGroupID, "I", "TotalWeight ASC");
                if (ds.Tables.Count <= 0)
                    return;
                gridControl.DataSource = ds.Tables[0];

                txtSectionQty.Text = ds.Tables[1].Rows[0]["ProductQty"].ToString();
                    txtSectionTotalWeight.Text = ds.Tables[1].Rows[0]["TotalWeight"].ToString();
                    txtSectionGoldWeight.Text = ds.Tables[1].Rows[0]["GoldWeight"].ToString();
                    txtSectionInPrice.Text = ds.Tables[1].Rows[0]["InPrice"].ToString();

                    //Tong so mon da kiem ke
                    ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_SUM_CheckProductCode]", strSectionID,strGroupID, "I");
                    txtCheckQty.Text = ds.Tables[0].Rows[0]["ProductQty"].ToString();
                    txtCheckTotalWeight.Text = ds.Tables[0].Rows[0]["TotalWeight"].ToString();
                    txtCheckGoldWeight.Text = ds.Tables[0].Rows[0]["GoldWeight"].ToString();
                    txtCheckInPrice.Text = ds.Tables[0].Rows[0]["InPrice"].ToString();

                txtSM.Text = (Convert.ToDecimal(txtSectionQty.Text == "" ? "0" : txtSectionQty.Text) -
                             Convert.ToDecimal(txtCheckQty.Text == "" ? "0" : txtCheckQty.Text)).ToString();
                
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

        private void fn_LoadDefault()
        {
            cboSection.SelectedIndex = 0;
            txtSectionQty.Text = "0";
            txtSectionTotalWeight.Text = "0";
            txtSectionGoldWeight.Text = "0";
            txtSectionInPrice.Text = "0";
            txtCheckQty.Text = "0";
            txtCheckTotalWeight.Text = "0";
            txtCheckGoldWeight.Text = "0";
            txtCheckInPrice.Text = "0";
            txtSM.Text = "0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strSectionID = "";
            try
            {
                strSectionID = ((ItemList)cboSection.SelectedItem).ID;
                ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", strSectionID);
                Functions.BindDropDownList(cboGroupID, ds, "GroupName", "GroupID", "", true);
            }
            catch { }
            fn_LoadDataToGrid();
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataSet ds = new DataSet();
                string strProductCode = "";
                strProductCode = txtProductCode.EditValue.ToString().ToUpper().Trim();                
                try
                {
                    //if (strProductCode.Length == clsSystem.ProductCodeLen)
                    //{
                        ds = clsCommon.ExecuteDatasetSP("T_PRODUCT_GetByCode", strProductCode);

                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            if (ds.Tables[0].Rows[0]["Status"].ToString() != "I")
                            {
                                ThongBao.Show("Lỗi", "Mã hàng này đã xuất hoặc đã bán.", "OK", ICon.Error);
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[0]["A"].ToString() == "1")
                                {
                                    txtSL.Focus();
                                    return;
                                }
                                for (int i = 0; i < grdDanhSach.RowCount; i++)
                                {
                                    
                                    if (grdDanhSach.GetRowCellValue(i, "ProductCode").ToString().ToUpper() == strProductCode)
                                    {
                                        if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colCheck"]).ToString() == "X")
                                        {
                                            grdDanhSach.SelectRow(i);
                                            grdDanhSach.TopRowIndex = i;
                                            DialogResult dr = MessageBox.Show(this, "Mã hàng này đã kiểm kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                                            if (dr != DialogResult.Yes) e.KeyChar = (char)Keys.Enter;                                            
                                            txtProductCode.Text = "";
                                            break;
                                        }
                                        else
                                        {
                                            DataSet das = new DataSet();
                                            //Update trang thai Hang da kiem ke
                                            try
                                            {
                                                das = clsCommon.ExecuteDatasetSP("T_PRODUCT_Upd_CheckProductCode", strProductCode, 1);
                                            }
                                            catch (Exception ex)
                                            {
                                                das.Dispose();                                                
                                                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                                                return;
                                            }
                                            finally
                                            {
                                                das.Dispose();
                                            }                                            
                                            txtProductCode.EditValue = "";
                                            txtProductCode.Refresh();
                                            txtCheckQty.EditValue = Int64.Parse(txtCheckQty.EditValue.ToString() == "" ? "0" : txtCheckQty.EditValue.ToString()) + 1;
                                            txtCheckTotalWeight.EditValue = (txtCheckTotalWeight.EditValue.ToString()==""? 0: decimal.Parse(txtCheckTotalWeight.EditValue.ToString())) + decimal.Parse(ds.Tables[0].Rows[0]["TotalWeight"].ToString());
                                            txtCheckGoldWeight.EditValue = (txtCheckGoldWeight.EditValue.ToString()==""? 0: decimal.Parse(txtCheckGoldWeight.EditValue.ToString())) + decimal.Parse(ds.Tables[0].Rows[0]["TotalWeight"].ToString()) - decimal.Parse(ds.Tables[0].Rows[0]["DiamondWeight"].ToString());
                                            txtCheckInPrice.EditValue = (txtCheckInPrice.EditValue.ToString() == "" ? 0 : decimal.Parse(txtCheckInPrice.EditValue.ToString())) ;
                                            //Load lai tat ca Hang da quet 
                                            fn_LoadDataToGrid();
                                            //grdDanhSach.SetRowCellValue(i, grdDanhSach.Columns["colCheck"], "X");
                                            grdDanhSach.TopRowIndex = i;
                                            txtSM.Text = (Convert.ToDecimal(txtSectionQty.Text == "" ? "0" : txtSectionQty.Text) -
                                            Convert.ToDecimal(txtCheckQty.Text == "" ? "0" : txtCheckQty.Text)).ToString();
                                        }
                                    }

                                }
                            }
                        }
                        else
                        {
                            ThongBao.Show("Lỗi", "Mã hàng không đúng.", "OK", ICon.Error);
                        }
                    //}
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
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string strSectionID = "",strGroupID="";
            this.Cursor = Cursors.WaitCursor;
            strSectionID = ((ItemList)cboSection.SelectedItem).ID;
            strGroupID = ((ItemList)cboGroupID.SelectedItem).ID;
            DataSet das = new DataSet();
            try
            {

                das = clsCommon.ExecuteDatasetSP("T_PRODUCT_Reset_Check", strSectionID,strGroupID);
            }
            catch (Exception ex)
            {
                das.Dispose();
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                das.Dispose();
            }
            fn_LoadDataToGrid();
        }

        private void frmInventory_Check_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmInventory_Check_KeyDown(object sender, KeyEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Kiem hang.mht");
                Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "kiem hang.mht");
            }
        }

        private void txtSL_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(e.NewValue) < 0)
                    e.Cancel = true;
            }
            catch{}
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                DataSet ds = new DataSet();
                string strProductCode = "";
                strProductCode = txtProductCode.EditValue.ToString().ToUpper().Trim();
                try
                {
                    //if (strProductCode.Length == clsSystem.ProductCodeLen)
                    //{
                    ds = clsCommon.ExecuteDatasetSP("T_PRODUCT_GetByCode", strProductCode);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (ds.Tables[0].Rows[0]["Status"].ToString() != "I")
                        {
                            ThongBao.Show("Lỗi", "Mã hàng này đã xuất hoặc đã bán.", "OK", ICon.Error);
                        }
                        else
                        {                            
                            for (int i = 0; i < grdDanhSach.RowCount; i++)
                            {

                                if (grdDanhSach.GetRowCellValue(i, "ProductCode").ToString().ToUpper() == strProductCode)
                                {
                                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colCheck"]).ToString() == "X")
                                    {
                                        grdDanhSach.SelectRow(i);
                                        grdDanhSach.TopRowIndex = i;
                                        DialogResult dr = MessageBox.Show(this, "Mã hàng này đã kiểm kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                                        if (dr != DialogResult.Yes) e.KeyChar = (char)Keys.Enter;
                                        txtProductCode.Text = "";
                                        break;
                                    }
                                    else
                                    {
                                        DataSet das = new DataSet();
                                        //Update trang thai Hang da kiem ke
                                        try
                                        {
                                            das = clsCommon.ExecuteDatasetSP("T_PRODUCT_Upd_CheckProductCode", strProductCode, txtSL.EditValue);
                                        }
                                        catch (Exception ex)
                                        {
                                            das.Dispose();
                                            ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
                                            return;
                                        }
                                        finally
                                        {
                                            das.Dispose();
                                        }
                                        txtProductCode.EditValue = "";
                                        txtProductCode.Refresh();
                                        txtSL.EditValue = 1;
                                        txtCheckQty.EditValue = Int64.Parse(txtCheckQty.EditValue.ToString() == "" ? "0" : txtCheckQty.EditValue.ToString()) + Convert.ToDecimal(txtSL.EditValue.ToString());
                                        txtCheckTotalWeight.EditValue = (txtCheckTotalWeight.EditValue.ToString() == "" ? 0 : decimal.Parse(txtCheckTotalWeight.EditValue.ToString())) + (decimal.Parse(ds.Tables[0].Rows[0]["TotalWeight"].ToString())*Convert.ToDecimal(txtSL.EditValue.ToString()));
                                        txtCheckGoldWeight.EditValue = (txtCheckGoldWeight.EditValue.ToString() == "" ? 0 : decimal.Parse(txtCheckGoldWeight.EditValue.ToString())) 
                                            + ((decimal.Parse(ds.Tables[0].Rows[0]["TotalWeight"].ToString()) - decimal.Parse(ds.Tables[0].Rows[0]["DiamondWeight"].ToString())) *
                                            Convert.ToDecimal(txtSL.EditValue.ToString()));
                                        txtCheckInPrice.EditValue = (txtCheckInPrice.EditValue.ToString() == "" ? 0 : decimal.Parse(txtCheckInPrice.EditValue.ToString()));
                                        //Load lai tat ca Hang da quet 
                                        fn_LoadDataToGrid();
                                        //grdDanhSach.SetRowCellValue(i, grdDanhSach.Columns["colCheck"], "X");
                                        grdDanhSach.TopRowIndex = i;
                                        txtProductCode.Focus();

                                        txtSM.Text = (Convert.ToDecimal(txtSectionQty.Text == "" ? "0" : txtSectionQty.Text) -
                                            Convert.ToDecimal(txtCheckQty.Text == "" ? "0" : txtCheckQty.Text)).ToString();
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", "Mã hàng không đúng.", "OK", ICon.Error);
                    }
                    //}
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
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
              
                string strSectionNane, strSectionID, strEmpName;
                string strParam, strValues;
                strEmpName = clsSystem.UserName;
                strSectionNane = ((ItemList) cboSection.SelectedItem).Value;
                strSectionID = ((ItemList) cboSection.SelectedItem).ID;
                strParam = "SectionName";
                strValues = strSectionNane;
                ds = clsCommon.ExecuteDatasetSP("rptBienBanKH", strSectionID);
                if(clsSystem.UnitWeight=="L") 
                Functions.fn_ShowReport_AndImage(ds, "rptBienBanKH_L.rpt", strParam, strValues);
                else if(clsSystem.UnitWeight=="C")
                Functions.fn_ShowReport_AndImage(ds, "rptBienBanKH_C.rpt", strParam, strValues);
            else Functions.fn_ShowReport_AndImage(ds, "rptBienBanKH.rpt", strParam, strValues);
            }
            catch
            {
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void cboGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }
        
    }
}