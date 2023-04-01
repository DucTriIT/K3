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
    public partial class frmOptionGoldType : DevExpress.XtraEditors.XtraForm
    {
        frmGoldType frm;
        string strID="";

        public frmOptionGoldType()
        {
            InitializeComponent();
        }

        public frmOptionGoldType(frmGoldType _frm,string _strid)
        {
            InitializeComponent();
            this.frm = _frm;
            strID = _strid;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void fn_LoadDefault()
        {
              strID = String.Empty;
              txtGoldCode.Text = String.Empty;
              txtGoldDesc.Text = String.Empty;
              txtNotes.Text = String.Empty;
              numOrderBy.Value = 1;
              cboGoldType.SelectedIndex = 0;
              cboUnit.SelectedIndex = 0;
              cboCurrency.SelectedIndex = 0;
              chkActive.Checked = true;
              txtGhiChu.Text = String.Empty;
              txtGoldCode.Focus();
        }

        private void fn_load_data_form()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("I_Gold_Get", strID);
                txtGoldCode.Text = ds.Tables[0].Rows[0]["GoldCode"].ToString();
                txtGoldDesc.Text = ds.Tables[0].Rows[0]["GoldDesc"].ToString();
                txtGhiChu.Text = ds.Tables[0].Rows[0]["GhiChu"].ToString();
                numOrderBy.Text = ds.Tables[0].Rows[0]["OrderBy"].ToString();
                cboGoldType.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldType"].ToString() , cboGoldType, 0);
                cboUnit.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["PriceUnit"].ToString() , cboUnit, 0);
                cboCurrency.SelectedIndex =  Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["PriceCcy"].ToString(), cboCurrency, 0);
              //  ckbActive.Checked = (ds.Tables[0].Rows[0]["Active"].ToString() == "1" ? true : false);
              //  txtHeSoBan.EditValue = decimal.Parse(ds.Tables[0].Rows[0]["HeSoBan"].ToString());
                txtNotes.EditValue =decimal.Parse( ds.Tables[0].Rows[0]["Notes"].ToString());
                chkActive.Checked = ds.Tables[0].Rows[0]["Active"].ToString() == "1" ? true : false;
                txtGoldAge.Text = ds.Tables[0].Rows[0]["GoldAge"].ToString();
                cboGroup.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GROUP"].ToString(),
                                                                         cboGroup, 0);
                txtTruLai.Text = ds.Tables[0].Rows[0]["TruLai"].ToString();
                txtTruGia.Text = ds.Tables[0].Rows[0]["TruGia"].ToString();
                txtTruvao.Text = ds.Tables[0].Rows[0]["Subtract"].ToString();
                txtCongra.Text = ds.Tables[0].Rows[0]["Add"].ToString();
                chkStd.Checked = ds.Tables[0].Rows[0]["IsStd"].ToString() == "1" ? true : false;                
            }
            catch { }
            finally 
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            cboGroup.Properties.Items.Add(new ItemList("1", "Vàng miếng, ngoại tệ"));
            cboGroup.Properties.Items.Add(new ItemList("2", "Vàng Khâu/ Ntrang"));
            cboGroup.Properties.Items.Add(new ItemList("3", "Vàng theo tuổi"));
            cboGroup.SelectedIndex = 0;           

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_UNIT", "");
                Functions.BindDropDownList(cboUnit, ds, "UnitDesc", "UnitCode", "", true);
                ds.Clear();

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_CURRENCY", "");
                Functions.BindDropDownList(cboCurrency, ds, "Ccy", "Ccy", "", true);
                ds.Clear();

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "T_SECTION", "");
                Functions.BindDropDownList(cboGoldType, ds, "SectionName", "SectionID", "", true);
                ds.Clear();
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToCombo: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

        private void fn_InitValue()
        {
           
        }

        private bool fn_CheckValidate()
        {
            if (String.IsNullOrEmpty(txtGoldCode.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào mã loại", "OK", ICon.Error);
                txtGoldCode.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtGoldDesc.Text))
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập vào tên loại", "OK", ICon.Error);
                txtGoldDesc.Focus();
                return false;
            }
            if (cboGoldType.SelectedIndex == 0 || cboGoldType.SelectedIndex == -1)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn loại nhóm hàng.", "OK", ICon.Error);
                cboGoldType.Focus();
                return false;
            }
            if (cboUnit.SelectedIndex == 0 || cboUnit.SelectedIndex == -1)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn đơn vị tính.", "OK", ICon.Error);
                cboUnit.Focus();
                return false;
            }
            if (cboCurrency.SelectedIndex == 0 || cboCurrency.SelectedIndex == -1)
            {
                ThongBao.Show("Lỗi", "Vui lòng chọn loại tiền tệ.", "OK", ICon.Error);
                cboCurrency.Focus();
                return false;
            }
            return true;
        }

        private void frmOptionGoldType_Load(object sender, EventArgs e)
        {
           
            fn_LoadDataToCombo();
            fn_InitValue();
            if (strID == "")
            {
                fn_LoadDefault();                
            }
            else
            {
                fn_load_data_form();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            if (!fn_CheckValidate()) return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                string strGoldType = ((ItemList)cboGoldType.SelectedItem).ID;

                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_GOLD_Ins]", txtGoldCode.Text.Trim(), txtGoldDesc.Text.Trim(),
                        numOrderBy.Text, strGoldType, ((ItemList)cboCurrency.SelectedItem).ID, ((ItemList)cboUnit.SelectedItem).ID,
                        txtNotes.Text.Trim(), chkActive.Checked ? "1" : "0", txtGoldAge.Text, txtGhiChu.Text.Trim(),
                        txtTruvao.Text, txtCongra.Text, ((ItemList)cboGroup.SelectedItem).ID,
                        chkStd.Checked ? "1" : "0", txtTruLai.Text, txtTruGia.Text);//txtGoldAge.EditValue.ToString() == "" ? "0" : txtGoldAge.EditValue);
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_GOLD_Upd]", strID, txtGoldCode.Text.Trim(), txtGoldDesc.Text.Trim(),
                        numOrderBy.Text, strGoldType, ((ItemList)cboCurrency.SelectedItem).ID, ((ItemList)cboUnit.SelectedItem).ID,
                        txtNotes.Text.Trim(), chkActive.Checked ? "1" : "0", txtGoldAge.Text, txtGhiChu.Text.Trim(),
                        txtTruvao.Text, txtCongra.Text, ((ItemList)cboGroup.SelectedItem).ID,
                        chkStd.Checked ? "1" : "0", txtTruLai.Text, txtTruGia.Text); //txtGoldAge.EditValue.ToString() == "" ? "0" : txtGoldAge.EditValue);
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                    //fn_EnableControl(false);
                    ThongBao.Show("Thông báo", "Cập nhật thành công!", "OK", ICon.Information);
                    frm.fn_LoadDataToGrid();
                    this.Close();
                    //fn_LoadDefault();
                    //grdControl.Enabled = true;
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
            }
            catch (Exception ex)
            {
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
}