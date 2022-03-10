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
    public partial class frmCongNo : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtDt = new DataTable();
        DataTable dtDs = new DataTable();
        private string strID = "";
        public frmCongNo()
        {
            InitializeComponent();
        }

        private void frmCongNo_Load(object sender, EventArgs e)
        {
            f_loadDataToCombo();
            fn_createProductDataTable();
            fn_LoadDefault();      
        }

        private void f_loadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {             

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_CUSTOMER", "ALL");
                Functions.BindDropDownList(cboKhachHang, ds, "CustName", "CustID","", true);
                // rcboCust.ReadOnly = true;
                ds.Clear();

                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "I_GOLD", "D_RT+");
                Functions.BindDropDownList(cboGoldDesc, ds, "GoldDesc", "GoldCode", false);
                // rcboCust.ReadOnly = true;
                ds.Clear();


            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm loadDataToCombo: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

        private void fn_createProductDataTable()
        {
            this.dtDt.Columns.Add("TrnDate", typeof(DateTime));            
            this.dtDt.Columns.Add("DebtType", typeof(string));
            this.dtDt.Columns.Add("TotalAmount", typeof(decimal));
            this.dtDt.Columns.Add("Status", typeof(string));
            this.dtDt.Columns.Add("GoldCode", typeof(string));        

            this.dtDs.Columns.Add("GoldeCode", typeof(string));
            this.dtDs.Columns.Add("Debt", typeof(decimal));
        }

        private void fn_EnableControl(string pStatus)
        {
            if (pStatus == "")
            {
                btnDel.Enabled = false;
                //btnSave.Enabled = true;
                btnComplete.Enabled = false;
                //cboKhachHang.Enabled = true;

                //grvIn.OptionsBehavior.Editable = true;
                grvDt.OptionsBehavior.Editable = true;
            }

            if (pStatus == "W")
            {
                btnDel.Enabled = true;
                //btnSave.Enabled = true;
                btnComplete.Enabled = true;
                cboKhachHang.Enabled = true;
                //grvIn.OptionsBehavior.Editable = true;
                grvDt.OptionsBehavior.Editable = true;
            }

            if (pStatus == "C")
            {
                btnDel.Enabled = false;
                //btnSave.Enabled = false;
                btnComplete.Enabled = false;
                //cboKhachHang.Enabled = false;

                //grvIn.OptionsBehavior.Editable = false;
                grvDt.OptionsBehavior.Editable = false;
            }
        }


        private void fn_LoadDefault()
        {            
            dtDt.Clear();
            dtDs.Clear();        
            grdDt.DataSource = dtDt;
            grdDS.DataSource = dtDs; 
            _dtDenNgay.DateTime = DateTime.Now;
            dtTuNgay.DateTime = DateTime.Now.AddDays(-15);
            cboKhachHang.SelectedIndex = 0;          
            grvDt.OptionsBehavior.Editable = false;
            //fn_EnableControl("");
            cboKhachHang.Focus();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                {
                    ds = clsCommon.ExecuteDatasetSP("I_CUSTOMER_DEBT_DT_Complete", strID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                        //cbbTinhTrang.SelectedIndex = Functions.GetSelectedIndexCombo("C", cbbTinhTrang, 0);
                        fn_LoadDataToGrid();
                       // fn_LoadDataToGridNo();
                        fn_EnableControl("C");
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Source + " - " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void grvOut_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Row;

            //Kiểm tra dữ liệu

            if (cboKhachHang.SelectedIndex <=0)
            {
                fn_LoadDataToGrid();
                ThongBao.Show("Lỗi", "Chọn khách hàng để nhập.", "OK", ICon.Error);
                grvDt.FocusedRowHandle = e.RowHandle;
                return;
            }
            if (String.IsNullOrEmpty(dr["GoldCode"].ToString()))
            {
                fn_LoadDataToGrid();
                ThongBao.Show("Lỗi", "Nhập thông tin loại dẻ.", "OK", ICon.Error);
                grvDt.FocusedRowHandle = e.RowHandle;
                return;
            }

            if (String.IsNullOrEmpty(dr["TrnDate"].ToString()))
            {
                fn_LoadDataToGrid();
                ThongBao.Show("Lỗi", "Nhập thông tin ngày.", "OK", ICon.Error);
                grvDt.FocusedRowHandle = e.RowHandle;
                return;
            }

            if (String.IsNullOrEmpty(dr["TotalAmount"].ToString()) || (Decimal)dr["TotalAmount"] < Decimal.Zero)
            {
                fn_LoadDataToGrid();
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra lại thông tin cột trọng lượng.", "OK", ICon.Error);
                grvDt.FocusedRowHandle = e.RowHandle;
                return;
            }
        

            if (String.IsNullOrEmpty(dr["DebtType"].ToString()))
            {
                fn_LoadDataToGrid();
                ThongBao.Show("Lỗi", "Nhập thông tin công nợ.", "OK", ICon.Error);
                grvDt.FocusedRowHandle = e.RowHandle;
                return;
              }




            //--> Dữ liệu hợp lệ --> Cập nhật
            DataSet ds = new DataSet();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_DEBT_DT_Ins]", "",(DateTime)dr["TrnDate"] ,((ItemList)cboKhachHang.SelectedItem).ID,
                        dr["GoldCode"].ToString(),dr["DebtType"].ToString(), (decimal)dr["TotalAmount"],"W");
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_DEBT_DT_Upd]", strID,(DateTime)dr["TrnDate"] ,((ItemList)cboKhachHang.SelectedItem).ID,
                        dr["GoldCode"].ToString(),dr["DebtType"].ToString(), (decimal)dr["TotalAmount"]);
                }

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    fn_LoadDataToGrid();
                    fn_GetFocusedRowValue();
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                ds.Dispose();
                this.Cursor = Cursors.Default;
                return;
            }
            finally
            {
                fn_LoadDataToGrid();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            string strIDKhacHang = "";
            strIDKhacHang = ((ItemList)cboKhachHang.SelectedItem).ID;

            if (strIDKhacHang == "")
            {
                strID = "";
                dtDt.Clear();
                grdDt.DataSource = dtDt;
                cboStatus.SelectedIndex = 0;
                grvDt.OptionsBehavior.Editable = false;
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_CUSTOMER_DEBT_DT_Lst]", "", strIDKhacHang, dtTuNgay.DateTime.ToString("dd/MM/yyyy"),
                                                _dtDenNgay.DateTime.ToString("dd/MM/yyyy"), "", "","","");
                grdDt.DataSource = ds.Tables[0];
                grdDS.DataSource = ds.Tables[1];
                grvDt.OptionsBehavior.Editable = true;
                fn_GetFocusedRowValue();
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

         private void fn_GetFocusedRowValue()
        {
            try
            {
                if (grvDt.FocusedRowHandle > -1)
                {
                    strID = grvDt.GetFocusedRowCellValue("TrnID").ToString();
                    //cbbTinhTrang.SelectedIndex = Functions.GetSelectedIndexCombo(grvOut.GetFocusedRowCellValue("Status").ToString(), cbbTinhTrang, 0);
                    string status = grvDt.GetFocusedRowCellValue("Status").ToString();
                    if ( status == "C")
                    {
                        fn_EnableControl("C");                       
                        grvDt.Columns["TrnDate"].OptionsColumn.AllowEdit = false;
                        grvDt.Columns["CustID"].OptionsColumn.AllowEdit = false;
                        grvDt.Columns["GoldCode"].OptionsColumn.AllowEdit = false;
                        grvDt.Columns["DebtType"].OptionsColumn.AllowEdit = false;
                        grvDt.Columns["TotalAmount"].OptionsColumn.AllowEdit = false;
                        grvDt.Columns["Status"].OptionsColumn.AllowEdit = false;

                    }
                    else
                    {
                        fn_EnableControl("W");
                        grvDt.Columns["TrnDate"].OptionsColumn.AllowEdit = true;
                        grvDt.Columns["CustID"].OptionsColumn.AllowEdit = true;
                        grvDt.Columns["GoldCode"].OptionsColumn.AllowEdit = true;
                        grvDt.Columns["DebtType"].OptionsColumn.AllowEdit = true;
                        grvDt.Columns["TotalAmount"].OptionsColumn.AllowEdit = true;
                        grvDt.Columns["Status"].OptionsColumn.AllowEdit = true;
                    }
                }
                else
                {
                    this.strID = String.Empty;
                    fn_EnableControl("");
                    grvDt.Columns["TrnDate"].OptionsColumn.AllowEdit = true;
                    grvDt.Columns["CustID"].OptionsColumn.AllowEdit = true;
                    grvDt.Columns["GoldCode"].OptionsColumn.AllowEdit = true;
                    grvDt.Columns["DebtType"].OptionsColumn.AllowEdit = true;
                    grvDt.Columns["TotalAmount"].OptionsColumn.AllowEdit = true;
                    grvDt.Columns["Status"].OptionsColumn.AllowEdit = true;             
                }
            }
            catch { }
         }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void grvDt_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            grvDt.SetFocusedRowCellValue(grvDt.Columns["TrnDate"], DateTime.Today);
        }

        private void grvDt_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fn_GetFocusedRowValue();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}