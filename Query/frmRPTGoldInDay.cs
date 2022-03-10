using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Messages;
using DevExpress.XtraEditors.DXErrorProvider;


namespace GoldRT
{
    public partial class frmRPTGoldInDay : DevExpress.XtraEditors.XtraForm
    {
        public frmRPTGoldInDay()
        {
            InitializeComponent();
        }

        private void frmRPTGoldInDay_Load(object sender, EventArgs e)
        {
            dtpDate.DateTime = DateTime.Now;
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("RPT_GOLD_INDAY", dtpDate.DateTime.ToString("dd/MM/yyyy"));
                grdGold.DataSource = ds.Tables[0];

                if (ds.Tables[1].Rows.Count != 0)
                {
                    txtCash.Text = ds.Tables[1].Rows[0]["CashAmount"].ToString();
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
            finally { ds.Dispose(); }             
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams = "", strValues = "";

            strParams = "Date";
            strValues = dtpDate.DateTime.ToString("dd/MM/yyyy");
            ds = clsCommon.ExecuteDatasetSP("RPT_GOLD_INDAY", dtpDate.DateTime.ToString("dd/MM/yyyy"));

            Functions.fn_ShowReport(ds, "rptGoldInDay.rpt", strParams, strValues);
        }
    }
}