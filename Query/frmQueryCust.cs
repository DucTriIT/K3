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
    public partial class frmQueryCust : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryCust()
        {
            InitializeComponent();
        }

        private void f_loadDefault()
        {
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now.AddDays(-15);
        }

        private void f_loadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_QryLst]", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"));
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

        private void frmQueryCust_Load(object sender, EventArgs e)
        {
            f_loadDefault();
            f_loadDataToGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            f_loadDataToGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //try
            //{
            //    string strFromDate = "", strToDate = "", strGoldDesc = "", strParams, strValues;

            //    strFromDate = ((DateTime)dtpTuNgay.EditValue).ToString("dd/MM/yyyy");
            //    strToDate = ((DateTime)dtpDenNgay.EditValue).ToString("dd/MM/yyyy");

            //    //strGoldDesc = ((ItemList)cboGoldCode.SelectedItem).Value;
            //    //strGoldCode = ((ItemList)cboGoldCode.SelectedItem).ID;

            //    strParams = "GoldDesc@TuNgay@DenNgay";
            //    strValues = strGoldDesc + "@" + strFromDate + "@" + strToDate;

            //    ds = clsCommon.ExecuteDatasetSP("rptBC201", strFromDate, strToDate);
            //    Functions.fn_ShowReport(ds, "rptBC201.rpt", strParams, strValues);
            //}
            //catch (Exception ex)
            //{
            //    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            //}
            //finally
            //{
            //    ds.Dispose();
            //}

            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            dlgFolder.Description = "Vui lòng chọn thư mục để chứa dữ liệu kết xuất.";
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string strSelectedPath = dlgFolder.SelectedPath;
                    string strFileName = "\\DoanhThuKhachHang" + "_" + DateTime.Now.ToString("dd_MMM_yyyy_hhmmss") + ".xls";
                    grdDanhSach.ExportToXls(strSelectedPath + strFileName);
                    ThongBao.Show("Thông báo", "Kết xuất thành công.", "OK", ICon.Information);
                }
                catch (Exception ex)
                {
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                }
            }
            
        }


    }
}