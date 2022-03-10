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
    public partial class frmProduct_Upd : DevExpress.XtraEditors.XtraForm
    {
        string strProductID;
        string strPriceUnit;
        string strSectionID;
        public frmProduct_Upd()
        {
            InitializeComponent(); 
        }

        private void fn_LoadDefault()
        {
            strProductID = string.Empty;

            txtProductCode.Text = string.Empty;
            cboGoldCode.SelectedIndex = 0;
            txtProductDesc.Text = string.Empty;
            cboProductGroup.SelectedIndex = 0;
            txtTaskPrice.Text = string.Empty;
            //txtPOTaskPrice1.Text = string.Empty;
            //txtPOTaskPrice2.Text = string.Empty;
            txtTotalWeight.Text = string.Empty;
            txtDiamondWeight.Text = string.Empty;
            txtRingSize.Text = string.Empty;
            //txtInPrice.Text = string.Empty;
           
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("I_GOLD", "G");
                Functions.BindDropDownList(cboGoldCode, ds, "GoldDesc", "GoldCode", "", true);
                ds.Clear();

                ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
                Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
                ds.Clear();


                ds = clsCommon.LoadComboSP("T_SECTION", "");
                Functions.BindDropDownList(cboSection, ds, "SectionName", "SectionID", "", true);
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
            if (strProductID == "")
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập mã hàng.", "OK", ICon.Error);
                txtProductCode.Focus();
                return false;
            }

            if (txtRingSize.Text == "")
            {
                txtRingSize.Text = "0";
            }

            return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
                DataSet ds = new DataSet();

     
            if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                /*ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Upd]", strProductID, null, txtProductDesc.Text.Trim(),
                        ((ItemList)cboProductGroup.SelectedItem).ID, ((ItemList)cboGoldCode.SelectedItem).ID,
                        null, txtTotalWeight.Text, txtDiamondWeight.EditValue,
                        clsSystem.StampWieght, txtTaskPrice.EditValue, txtPOTaskPrice1.EditValue, txtPOTaskPrice2.EditValue, txtInPrice.EditValue);*/

                ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Upd]", strProductID, null, txtProductDesc.Text.Trim(),
                        ((ItemList)cboProductGroup.SelectedItem).ID, ((ItemList)cboGoldCode.SelectedItem).ID,
                        ((ItemList)cboSection.SelectedItem).ID, strPriceUnit == "L" ? Convert.ToDecimal(txtTotalWeight.Text) *clsSystem.HSTL : Convert.ToDecimal(txtTotalWeight.Text), strPriceUnit == "L" ? (txtDiamondWeight.Text == "" ? 0 : Convert.ToDecimal(txtDiamondWeight.Text)) * clsSystem.HSTL : txtDiamondWeight.Text == "" ? 0 : Convert.ToDecimal(txtDiamondWeight.Text),
                        Convert.ToDecimal(txtTaskPrice.EditValue), (txtPOTaskPrice.EditValue.ToString() == "" ? "0" : txtPOTaskPrice.EditValue.ToString()), null, null, 
                        txtRingSize.Text == "" ? 0 : Convert.ToDecimal(txtRingSize.Text),
                        txtGiaBanMon.EditValue, !clsSystem.IsDiamondPrice ? null :
                        (txtDiamondPrice.EditValue.ToString() == "" ? "0" : txtDiamondPrice.EditValue.ToString()));

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                    btnPrintStamp.Enabled = true;
                }
                else
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
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

        private void frmProduct_Upd_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            strPriceUnit = "";
            fn_LoadDataToCombo();
            fn_LoadDefault();
            this.ActiveControl = txtProductCode;
            if (!clsSystem.IsDiamondPrice)
                txtDiamondPrice.Dispose();
            if (!clsSystem.IsShowPOTaskPrice)
                txtPOTaskPrice.Dispose();
        }

         private void fn_EnableControl(bool bEditMode, string strPriceUnit)
        {
            cboGoldCode.Enabled = bEditMode;
            cboProductGroup.Enabled = bEditMode;
            txtProductDesc.Enabled = bEditMode;
            txtDiamondWeight.Enabled = bEditMode;
            txtTotalWeight.Enabled = bEditMode;
            txtTaskPrice.Enabled = bEditMode;
            //txtPOTaskPrice1.Enabled = bEditMode;
            //txtPOTaskPrice2.Enabled = bEditMode;
            txtRingSize.Enabled = bEditMode;
            //txtInPrice.Enabled = bEditMode;

            if (bEditMode)
            {
                switch (strPriceUnit)
                {
                    case "":
                        txtRingSize.Enabled = false;
                        txtTotalWeight.Enabled = false;
                        txtDiamondWeight.Enabled = false;
                        txtTaskPrice.Enabled = false;
                        //txtPOTaskPrice1.Enabled = false;
                        //txtPOTaskPrice2.Enabled = false;
                        //txtInPrice.Enabled = false;
                        txtGiaBanMon.Enabled = false;
                        break;
                    case "L":
                        txtRingSize.Enabled = true;
                        txtTotalWeight.Enabled = true;
                        txtDiamondWeight.Enabled = true;
                        txtTaskPrice.Enabled = true;
                        //txtPOTaskPrice1.Enabled = true;
                        //txtPOTaskPrice2.Enabled = true;
                        //txtInPrice.Enabled = false;
                        txtGiaBanMon.Enabled = false;
                        break;
                    case "G":
                         txtRingSize.Enabled = false;
                        //txtTotalWeight.Enabled = true;
                        txtDiamondWeight.Enabled = false;
                         txtTaskPrice.Enabled = false;
                        //txtPOTaskPrice1.Enabled = false;
                        //txtPOTaskPrice2.Enabled = false;
                        //txtInPrice.Enabled = true;
                         txtGiaBanMon.Enabled = false;
                        break;
                    case "M":
                       // txtRingSize.Enabled = true;
                         txtTotalWeight.Enabled = false;
                         txtDiamondWeight.Enabled = false;
                         txtTaskPrice.Enabled = false;
                        //txtPOTaskPrice1.Enabled = false;
                        //txtPOTaskPrice2.Enabled = false;
                        //txtInPrice.Enabled = true;
                         txtGiaBanMon.Enabled = true;
                        break;
                }
                txtTotalWeight.Enabled = false;
                txtDiamondWeight.Enabled = false;
                txtRingSize.Enabled = false;
            }
        }

        private void txtProductCode_EditValueChanged(object sender, EventArgs e)
        {
            //string m_strProductCode = txtProductCode.Text.Trim();
            //if (m_strProductCode == "")
            //{
            //    fn_LoadDefault();
            //    return;
            //}

            //DataSet ds = new DataSet();
            //try
            //{
            //    if (m_strProductCode.Length == clsSystem.ProductCodeLen)
            //    {
            //        ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_GetByProductCode]", m_strProductCode, "I");

            //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //        {
            //            strPriceUnit = ds.Tables[0].Rows[0]["PriceUnit"].ToString();

            //            cboGoldCode.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldCode"].ToString(), cboGoldCode, 0);
            //            strProductID = ds.Tables[0].Rows[0]["ProductID"].ToString();
            //            txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
            //            cboProductGroup.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GroupID"].ToString(), cboProductGroup, 0);
            //            txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
            //            txtTaskPrice.EditValue = ds.Tables[0].Rows[0]["TaskPrice"];
            //            txtPOTaskPrice1.EditValue = ds.Tables[0].Rows[0]["POTaskPrice1"];
            //            txtPOTaskPrice2.EditValue = ds.Tables[0].Rows[0]["POTaskPrice2"];
            //            txtDiamondWeight.EditValue = ds.Tables[0].Rows[0]["DiamondWeight"];
            //            txtTotalWeight.EditValue = ds.Tables[0].Rows[0]["TotalWeight"];
            //            txtInPrice.EditValue = ds.Tables[0].Rows[0]["InPrice"];

            //            fn_EnableControl(true, strPriceUnit);
            //            cboGoldCode.Focus();
            //        }
            //        else
            //        {
            //            ThongBao.Show("Lỗi", "Không tồn tại mã hàng này.", "OK", ICon.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ds.Dispose();
            //    this.Cursor = Cursors.Default;
            //    ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            //    return;
            //}
            //finally
            //{
            //    ds.Dispose();
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintStamp_Click(object sender, EventArgs e)
        {
            try
            {
                //string m_strRptName = "rptPrintStamp_";
                //DataSet ds = new DataSet();

                //m_strRptName += strPriceUnit + ".rpt";
                //ds = clsCommon.ExecuteDatasetSP("rptPrintStamp", "", txtProductCode.Text.Trim(), "PRODUCT");
                //Functions.fn_ShowReport(ds, m_strRptName, "", "");

                // In tem bang Bartender
                string strSQL = "";
                string m_strRptName = "btPrintStamp_";
                string m_strTrnIDs = "";
                m_strTrnIDs = txtProductCode.Text.Trim();
                //using (Engine btEngine = new Engine())
                //{
                //    btEngine.Start();
                //    m_strRptName += strPriceUnit + ".btw";
                //    strSQL = "SELECT * FROM vwPrintStamp_Product WHERE ProductCode='" + m_strTrnIDs + "'";
                //    Functions.fn_PrintStamp_Bartender(m_strRptName, strSQL, "V", btEngine);

                //    btEngine.Stop(SaveOptions.DoNotSaveChanges);
                //}
            }
            catch
            { }
            finally { btnPrintStamp.Enabled = false; }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string m_strProductCode = txtProductCode.Text.Trim();

            if (e.KeyChar == 13)
            {                
                if (m_strProductCode == "")
                {
                    fn_LoadDefault();
                    return;
                }

                DataSet ds = new DataSet();
                try
                {
                    //if (m_strProductCode.Length == clsSystem.ProductCodeLen)
                    //{
                        ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_GetByProductCode]", m_strProductCode, "I");

                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            strPriceUnit = ds.Tables[0].Rows[0]["PriceUnit"].ToString();

                            cboGoldCode.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldCode"].ToString(), cboGoldCode, 0);
                            strProductID = ds.Tables[0].Rows[0]["ProductID"].ToString();
                            txtProductDesc.Text = ds.Tables[0].Rows[0]["ProductDesc"].ToString();
                            cboProductGroup.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GroupID"].ToString(), cboProductGroup, 0);
                            cboSection.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["SectionID"].ToString(), cboSection, 0);
                            //txtSectionName.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                            txtTaskPrice.EditValue = ds.Tables[0].Rows[0]["TaskPrice"];
                            txtPOTaskPrice.EditValue = ds.Tables[0].Rows[0]["POTaskPrice1"];
                            //txtPOTaskPrice2.EditValue = ds.Tables[0].Rows[0]["POTaskPrice2"];
                            txtDiamondWeight.EditValue = ds.Tables[0].Rows[0]["DiamondWeight"];
                            txtTotalWeight.EditValue = ds.Tables[0].Rows[0]["TotalWeight"];
                            txtRingSize.EditValue = ds.Tables[0].Rows[0]["RingSize"];
                            strSectionID = ds.Tables[0].Rows[0]["SectionID"].ToString();
                            //txtInPrice.EditValue = ds.Tables[0].Rows[0]["InPrice"];
                            strPriceUnit = ds.Tables[0].Rows[0]["PriceUnit"].ToString();
                            txtGiaBanMon.EditValue = ds.Tables[0].Rows[0]["GiaBanMon"].ToString();
                            txtDiamondPrice.EditValue = ds.Tables[0].Rows[0]["DiamondPrice"].ToString();
                            fn_EnableControl(true, strPriceUnit);
                            cboGoldCode.Focus();
                        }
                        else
                        {
                            ThongBao.Show("Lỗi", "Không tồn tại mã hàng này.", "OK", ICon.Error);
                        }
                    //}
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
                }
                //cboGoldCode.Enabled = false;
            }
        }

        private void txtRingSize_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmProduct_Upd_KeyDown(object sender, KeyEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Cap nhat thong tin hang.mht");
                Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Cap nhat thong tin hang.mht");
            }
        }
    }
}