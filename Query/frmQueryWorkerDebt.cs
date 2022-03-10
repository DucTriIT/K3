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
    public partial class frmQueryWorkerDebt : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryWorkerDebt()
        {
            InitializeComponent();
        }

        private void f_loadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_WORKER_BAL_Lst", "", txtWorkerName.Text.Trim(), "", "");
                grdDebt.DataSource = ds.Tables[0];
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

        private void frmQueryWorkerDebt_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            f_loadDataToGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            f_loadDataToGrid();
        }
    }
}