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
    public partial class frmQueryXRate : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryXRate()
        {
            InitializeComponent();
        }

    #region "Private Functions"

        private void fn_clearForm()
        {
            grdTyGia.DataSource = null;
            grdGiaVang.DataSource = null;
            grdGiaDe.DataSource = null;
            lblChangeTime.Text = "";
        }

        private void fn_LoadDefault()
        {
            dtpNgay.EditValue = DateTime.Now;
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                if (cboSerial.SelectedItem == null)
                {
                    fn_clearForm();
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("I_XRATE_HIST_Lst", dtpNgay.DateTime.ToString("dd/MM/yyyy"), ((ItemList)cboSerial.SelectedItem).ID);
                    grdTyGia.DataSource = ds.Tables[0];
                    grdGiaVang.DataSource = ds.Tables[1];
                    grdGiaDe.DataSource = ds.Tables[2];
                }
            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToGrid: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

    #endregion

    #region "Event Handlers"
        private void frmXRate_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            fn_LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void dtpNgay_EditValueChanged(object sender, EventArgs e)
        {
            fn_clearForm();

            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("I_XRATE_HIST_SerialsInDay", dtpNgay.DateTime.ToString("dd/MM/yyyy"));
                Functions.BindDropDownList(cboChangeTime, ds, "RateTime", "Serial", "", false);
                Functions.BindDropDownList(cboSerial, ds, "Serial", "Serial", "", false);
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

        private void cboSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSerial.SelectedItem != null && cboChangeTime.Properties.Items.Count > 0)
            {
                cboChangeTime.SelectedIndex = cboSerial.SelectedIndex;
                lblChangeTime.Text = ((ItemList)cboChangeTime.SelectedItem).Value;
            }
            fn_LoadDataToGrid();
        }



    }
}