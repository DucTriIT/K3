using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Messages;

namespace GoldRT
{
    public partial class frmProductOLstApprove : DevExpress.XtraEditors.XtraForm
    {
        public frmProductOLstApprove()
        {
            InitializeComponent();
        }

        public void fn_RefreshForm()
        {
            fn_LoadDataToGrid();
        }

        private void fn_LoadDefault()
        {
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now;
            cboProductGroup.SelectedIndex = 0;
            cboLoaiVang.SelectedIndex = 0;
            cboStatus.SelectedIndex = 1;

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

            ds = clsCommon.LoadComboSP("T_STATUS", "PRODOUT");
            Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
            ds.Clear();

            ds.Dispose();
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_OUT_Lst]", "", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"),
                "", "", ((ItemList)cboProductGroup.SelectedItem).ID, ((ItemList)cboLoaiVang.SelectedItem).ID, "", "", "", "", "", ((ItemList)cboEmp.SelectedItem).ID, "", ((ItemList)cboStatus.SelectedItem).ID, "");

                gridControl.DataSource = ds.Tables[0];
                grdDanhSach.Columns["colChon"].ImageIndex = 0;
            }
            catch(Exception ex)
            {
                ds.Dispose();
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
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
            fn_LoadDataToGrid();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int updCount = 0;

            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {
                if(grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                {
                    DataSet ds = new DataSet();

                    try
                    {
                        ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_OUT_Appr]", grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["TrnID"]).ToString(), clsSystem.UserID);

                        if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                        {
                            ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                            return;
                        }
                    }
                    catch(Exception ex)
                    {
                        ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                        return;
                    }
                    finally
                    {
                        ds.Dispose();
                        updCount++;
                    }
                }
            }
            //if (!flag)
            //{
            //    ThongBao.Show("Lỗi", "Lỗi cập nhật dữ liệu.", "OK", ICon.Error);
            //}
            //else 
            if(updCount > 0)
            {
                ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
            }

            if(updCount == 0)
                ThongBao.Show("Thông báo", "Vui lòng chọn dữ liệu trước khi thực hiện", "OK", ICon.Information);

            fn_LoadDataToGrid();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDanhSach_MouseDown(object sender, MouseEventArgs e)
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {          
            DataTable tbExport = new DataTable("Excel");
            tbExport.Columns.Add("ProductDesc", typeof(string));
            tbExport.Columns.Add("TotalWeight", typeof (decimal));
            tbExport.Columns.Add("DiamondWeight", typeof(decimal));
            tbExport.Columns.Add("RingSize", typeof(decimal));
            tbExport.Columns.Add("TaskPrice", typeof(decimal));
            tbExport.Columns.Add("Qty", typeof(decimal));
            tbExport.Columns.Add("InPrice", typeof(decimal));
            DataRow row;
             for (int i = 0; i < grdDanhSach.RowCount; i++)
             {
                 if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                 {
                     row = tbExport.NewRow();

                     row[0] = grdDanhSach.GetDataRow(i)["ProductDesc"];
                     row[1] = grdDanhSach.GetDataRow(i)["TotalWeight"];
                     row[2] = grdDanhSach.GetDataRow(i)["DiamondWeight"];
                     row[3] = grdDanhSach.GetDataRow(i)["RingSize"];
                     row[4] = grdDanhSach.GetDataRow(i)["TaskPrice"].ToString() == "" ? 0 : Convert.ToInt32(grdDanhSach.GetDataRow(i)["TaskPrice"]);
                     row[5] = grdDanhSach.GetDataRow(i)["SL"];
                     row[6] = grdDanhSach.GetDataRow(i)["InPrice"].ToString() == "" ? 0 : Convert.ToInt64(grdDanhSach.GetDataRow(i)["InPrice"]);
                     tbExport.Rows.Add(row);
                 }
             }

             frmExportExcel frm = new frmExportExcel(tbExport);
             frm.MdiParent = this.ParentForm;
             frm.Show();
            //if (rgLoai.SelectedIndex < 0)
            //{
            //    ThongBao.Show("Thông báo", "Bạn chưa chọn loại hàng để xuất dữ liệu. Vui long kiểm tra lại", "OK", ICon.Error);
            //    return;
            //}
            //string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
            //if (fileName != "")
            //{
            //    ExportTo(new ExportXlsProvider(fileName));
            //}           
        }

        private void btnIn_Click(object sender, EventArgs e)
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
        }        
    }
}