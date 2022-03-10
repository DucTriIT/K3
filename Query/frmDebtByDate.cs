using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmDebtByDate : Form
    {
        public frmDebtByDate()
        {
            InitializeComponent();

            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now;
        }

        private void frmDebtByDate_Load(object sender, EventArgs e)
        {
            f_loadDataToGrid();

        }
        private void f_loadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[rptDebtByTime]", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"));
                grdDanhSach.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm loadDataToGrid: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            f_loadDataToGrid();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string strParams = "";
            string strValues = "";
            DataSet ds = new DataSet();
             ds = clsCommon.ExecuteDatasetSP("[rptDebtByTime]", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"));

            string strFromDate = ((DateTime)dtpTuNgay.EditValue).ToString("dd/MM/yyyy");
            string strToDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");
            strParams = "TuNgay@DenNgay";
            strValues = strFromDate + "@" + strToDate;
            Functions.fn_ShowReport_AndImage(ds, "rptDebtByDate.rpt", strParams, strValues);
        }

        private void grdDanhSach_Click(object sender, EventArgs e)
        {

        }
    }
}