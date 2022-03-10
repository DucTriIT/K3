using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Collections;

using Messages;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace GoldRT
{
    public partial class frmQueryProduct_DoiTra : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryProduct_DoiTra()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        void timer1_Tick(object sender, EventArgs e)
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
                            list.Add(grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["ProductCode"]).ToString());
                    }
                    fn_LoadDataToGrid();
                    // // cập nhật trạng thái Focus và colChon của grid sau khi refresh
                    grdDanhSach.FocusedRowHandle = index;
                    foreach (Object obj in list)
                    {
                        for (int i = 0; i < grdDanhSach.RowCount; i++)
                        {
                            if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["ProductCode"]).ToString() == (string)obj)
                                grdDanhSach.SetRowCellValue(i, grdDanhSach.Columns["colChon"], "True");
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
        private void fn_LoadDefault()
        {
            dtpDenNgay.DateTime = DateTime.Now;
            //dtpTuNgay.DateTime = DateTime.Now.AddDays(-15);
            dtpTuNgay.DateTime = DateTime.Now;
        }
        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("TRN_RT_DOITRA_Lst",  txtBillCode.Text.Trim(), dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                "", ((ItemList)cboCust.SelectedItem).ID, "", "", clsSystem.UserID);

                gridControl.DataSource = ds.Tables[0];
            }
            catch { }
            finally { ds.Dispose(); }

        }
        private void frmQueryProduct_DoiTra_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToCombo();
            fn_LoadDefault();
            fn_LoadDataToGrid();
        }
        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
     

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_CUSTOMER", "ALL");

                Functions.BindDropDownList(cboCust, ds, "CustName", "CustID", "0", true);
                ds.Clear();

              

            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm loadDataToCombo: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }
        private void btnPrintStamp_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sProductCode = "";
            string strSQL = "";
            string m_strRptName = "btPrintStamp_";
            string m_strTrnIDs = "";
            string m_strUnit = "";
            int i, j;
            bool m_bIsSameUnit = true, m_bPrinted = false;
            try
            {
                for ( i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                    {
                        if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["RePrint"]).ToString() == "Y")
                        {
                            m_bPrinted = true;
                            break;
                        }
                    }
                }

                if (m_bPrinted)
                {
                    if (ThongBao.Show("Thông báo", "Tem này đã được in, bạn có muốn in lại không?", "Có", "Không", ICon.QuestionMark) == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                for ( i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                    {
                        m_strUnit = grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["PriceUnit"]).ToString();

                        for (  j = i + 1; j < grdDanhSach.RowCount; j++)
                        {
                            if (grdDanhSach.GetRowCellValue(j, grdDanhSach.Columns["colChon"]).ToString() == "True")
                            {
                                if (grdDanhSach.GetRowCellValue(j, grdDanhSach.Columns["PriceUnit"]).ToString() != m_strUnit)
                                {
                                    m_bIsSameUnit = false;
                                    break;
                                }
                            }
                        }
                        if (j == grdDanhSach.RowCount)
                        {
                            sProductCode += grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["ProductCode"]).ToString() + "@";
                        }
                    }
                }

                if (!m_bIsSameUnit)
                {
                    ThongBao.Show("Lỗi", "Vui lòng chọn cùng đơn vị loại vàng.", "OK", ICon.Error);
                    return;
                }

                if (sProductCode == "")
                {
                    ThongBao.Show("Lỗi", "Vui lòng bấm chọn vào ô vuông.", "OK", ICon.Error);
                    return;
                }
                else
                {
                    //using (Engine btEngine = new Engine())
                    //{
                    //    btEngine.Start();

                    //    m_strRptName += m_strUnit + ".btw";
                    //    strSQL = "SELECT * FROM vwPrintStamp_Product WHERE CHARINDEX(ProductCode,'" + sProductCode + "', 0) > 0";
                    //    //string strNgonNgu = cboNgonNguIn.SelectedIndex.ToString();
                    //    //strNgonNgu = cboNgonNguIn.SelectedIndex == 0 ? "V" : "H";
                    //    Functions.fn_PrintStamp_Bartender(m_strRptName, strSQL, "", btEngine);
                    //    //Update Printed
                    //    ds = clsCommon.ExecuteDatasetSP("[dbo].[TRN_RT_DOITRA_UpdPrintStamp]", sProductCode);
                    //    btEngine.Stop(SaveOptions.DoNotSaveChanges);
                    //}
                
                }
            }
            catch (Exception ex)
            {
                //ThongBao.Show("Lỗi", "Hàm btnPrintStamp_Click: " + ex.Message, "OK", ICon.Error);
                fn_LoadDataToGrid();
                //return;
            }
            finally
            {
                fn_LoadDataToGrid();
                ds.Dispose();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            PC.CreateDocument(PS);
            PC.ShowPreview();
            //DataSet ds = new DataSet();
            //string strFromDate = "", strToDate = "",strCustName="",strCustID="";
            //string strParams, strValues;
            //try
            //{
            //    strFromDate =dtpTuNgay.DateTime.ToString("dd/MM/yyyy");
            //    strToDate = dtpTuNgay.DateTime.ToString("dd/MM/yyyy");
            //    strCustName=((ItemList)cboCust.SelectedItem).Value;
            //    strCustID = ((ItemList)cboCust.SelectedItem).ID;
            //    strParams = "TuNgay@DenNgay@CustName";
            //    strValues = strFromDate + "@" + strToDate +"@"+strCustName;
            //    ds = clsCommon.ExecuteDatasetSP("rptBCHangDoiTra", strFromDate, strToDate, strCustID);
            //    Functions.fn_ShowReport_AndImage(ds, "rptBCHangDoiTra.rpt", strParams, strValues);
            //}
            //catch
            //{
            //    ds.Dispose();
            //}
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
    }
}