using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Messages;
using System.IO;
using System.Collections;



namespace GoldRT
{
    public partial class frmProductUpd_TaskPrice : DevExpress.XtraEditors.XtraForm
    {
        public bool Continue = false;
        public string strID;
        public string mstrID;
        public string strStatus="";
        ArrayList list=new ArrayList();
        public frmProductUpd_TaskPrice()
        {
            InitializeComponent();

        }
        private void fn_LoadDataToComboo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
                Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
                ds.Clear();

                ds = clsCommon.LoadComboSP("T_SUPPLIER", "");
                Functions.BindDropDownList(cboNCC, ds, "SupplierName", "SupplierID", "", true);
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
        public void fn_LoadDataToForm(string _strID)
        {
            DataSet ds = new DataSet();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_UPDATE_TASKPRICE_Get]",_strID);
                gridControl.DataSource = ds.Tables[0];
                strStatus = ds.Tables[0].Rows[0]["Status"].ToString().Trim();
                strID = _strID;
                fn_EnableControl(strStatus);
            }
            catch(Exception ex)
            {
                
              ThongBao.Show("Lỗi","Có lỗi xảy ra:"+ex.Message,"OK",ICon.Error);
            }
            finally 
            {
                this.Cursor = Cursors.Default;
                ds.Dispose();
            }
        }

        private void frmProductUpd_TaskPrice_Load(object sender, EventArgs e)
        {
            timer1.Tick+=new EventHandler(timer1_Tick);
            fn_LoadDefault();
            fn_EnableControl(strStatus);
            list.Clear();
            fn_LoadDataToComboo();
            timer1.Interval = 5000;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblThongBao.Text = "";       
        }
        private void fn_GetStatusGrid()
        {
            int index = 0;
            
            try
            {
                if (grdDanhSach.RowCount > 0)
                {
                    // giữ trạng thái Focus và colChon của grid trước khi refresh

                    for (int i = 0; i < grdDanhSach.RowCount; i++)
                    {
                        if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                            list.Add(grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["ProductCode"]).ToString());
                    }
                  
                }
            }
            catch
            {

            }
        }
        private void fn_SetStatusGrid()
        {
           
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (list.Contains(grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["ProductCode"]).ToString()))
                    {
                        grdDanhSach.SetRowCellValue(i, grdDanhSach.Columns["colChon"], "True");
                        
                    }
                    else grdDanhSach.SetRowCellValue(i, grdDanhSach.Columns["colChon"], "False");
                   
                }

            
        }
        private void gridControl_MouseDown(object sender, MouseEventArgs e)
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

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_Upd_TaskPrice_Lst]", dtpTuNgay.DateTime.ToString(),dtpDenNgay.DateTime.ToString(), ((ItemList)cboProductGroup.SelectedItem).ID, ((ItemList)cboNCC.SelectedItem).ID, 'I');
                gridControl.DataSource = ds.Tables[0];
            }
            catch
            { }
            finally { ds.Dispose(); }
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            strID = "";
            mstrID = "";
            list.Clear();
            fn_EnableControl("");
            fn_LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool fn_CheckValidate()
        {
            if (string.IsNullOrEmpty(txtTaskPrice.Text))
            {
                ThongBao.Show("Lỗi", "Nhập giá công mới trước khi cập nhật", "OK", ICon.Error);
                return false;
            }
            return true;
        }
        private void btnPrintStamp_Click(object sender, EventArgs e)
        {
            //btnGenCode_Click(null, null);
            if (Continue == false)
            {
                return;
            }
            DataSet ds = new DataSet();
            string strSQL = "";
            string m_strRptName = "btPrintStamp_";

            string m_strUnit = "";
            bool m_bIsSameUnit = true, m_bPrinted = false;
            int j, i;
            try
            {
                for (i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                    {
                        if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["Printed"]).ToString() == "Y")
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

                for (i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                    {
                        m_strUnit = grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["PriceUnit"]).ToString();

                        for (j = i + 1; j < grdDanhSach.RowCount; j++)
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

                    }
                }

                if (!m_bIsSameUnit)
                {
                    lblThongBao.Text="Vui lòng chọn cùng đơn vị loại vàng.";
                    return;
                }
                else
                {
                    //using (Engine btEngine = new Engine())
                    //{
                    //    btEngine.Start();
                    //    m_strRptName += m_strUnit + ".btw";
                    //    strSQL = "SELECT * FROM vwPrintStamp_Product WHERE CHARINDEX(ProductCode, '" + mstrID + "', 0) > 0";
                    //    Functions.fn_PrintStamp_Bartender(m_strRptName, strSQL, "V", btEngine);

                    //    btEngine.Stop(SaveOptions.DoNotSaveChanges);
                    //    lblThongBao.Text = "In tem thành công .";
                    //}


                }
            }
            catch (Exception ex)
            {
                //ThongBao.Show("Lỗi", "Hàm btnPrintStamp_Click: " + ex.Message, "OK", ICon.Error);
                lblThongBao.Text = "Đã xảy ra lỗi liên hệ bộ phận hỗ trợ để được giải quyết";
                //return;
            }
            finally
            {
                ds.Dispose();
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            this.Cursor = Cursors.WaitCursor;
            mstrID = "";
            try
            {
                if (!fn_CheckValidate())
                    return;
                for (int i = 0; i < grdDanhSach.RowCount; i++)
                {
                    if (grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["colChon"]).ToString() == "True")
                    {
                        mstrID += grdDanhSach.GetRowCellValue(i, grdDanhSach.Columns["ProductCode"]).ToString() + "@";
                    }
                }
                if (string.IsNullOrEmpty(mstrID))
                {
                    lblThongBao.Text = "Vui lòng chọn hàng cần thay đổi giá công";
                    return;
                }
                if (strID == "")
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_UPDATE_TASKPRICE_Ins]", "", mstrID, txtTaskPrice.Text.Trim());
                    
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_UPDATE_TASKPRICE_Upd]", strID, mstrID, txtTaskPrice.Text.Trim());

                }
                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                {
                    strStatus = "W";
                    strID = ds.Tables[0].Rows[0]["TrnID"].ToString();
                    lblThongBao.Text = "Cập nhật tiền công thành công!Bấm hoàn tất để kết thúc giao dịch .";
                    fn_LoadDataToForm(strID);
                    fn_EnableControl(strStatus);
                    
                  
                }
            }
            catch
            {
                
                lblThongBao.Text = "Có lỗi xảy ra,vui lòng kiểm tra lại và liên hệ Cty để được hỗ trợ";
            }
            finally
            {
                list.Clear();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }
        private void fn_EnableControl(string pStatus)
        {
            if (pStatus == "")
            {
                btnXóa.Enabled = true;
                btnCapNhat.Enabled = true;
                // btnSave.Enabled = true;
                // btnComplete.Enabled = false;
                btnHoanTat.Enabled = false;

                btnPrintStamp.Enabled = false;
                txtTaskPrice.Enabled = true;
            }

            if (pStatus == "W")
            {
                  btnXóa.Enabled = true;
                  btnCapNhat.Enabled = true;
               
                  btnHoanTat.Enabled = true;

                  btnPrintStamp.Enabled = false;
                  txtTaskPrice.Enabled = true;
            }

            if (pStatus == "C")
            {
                btnXóa.Enabled = false;
                btnHoanTat.Enabled = false;
                btnCapNhat.Enabled = false;
                btnPrintStamp.Enabled = true;
                txtTaskPrice.Enabled = false;
            }
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            frmProductUpd_TaskPrice_Lst frm = new frmProductUpd_TaskPrice_Lst(this);
            frm.ShowDialog();
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_UPDATE_TASKPRICE_Complete]", strID);
                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                {
                    strStatus = "C";
                    lblThongBao.Text = "Hoàn tất giao dịch thành công!Nhấn in tem để in lại tem.";
                    fn_EnableControl(strStatus);
                    btnPrintStamp.Focus();
                    Continue=true;
                }
                else
                {
                    lblThongBao.Text = "Có lỗi xảy ra ,liên hệ bộ phận hỗ trợ để giải quyết!";
                    Continue = false;
                }
            }
            catch
            {
                lblThongBao.Text = "Có lỗi xảy ra ,liên hệ bộ phận hỗ trợ để giải quyết!";
                Continue = false;
            }
            finally { ds.Dispose(); }
        }
        private void fn_LoadDefault()
        {
            strID = "";
            strStatus = "";
            mstrID = "";
            dtpDenNgay.DateTime = DateTime.Now;
            dtpTuNgay.DateTime = DateTime.Now;
            DataTable dt=new DataTable();
            gridControl.DataSource = dt;
            txtTaskPrice.EditValue = null;
        }
        private void btnXóa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (strID == "")
            {
                lblThongBao.Text = "Không có dữ liệu để xóa";
                return;
            }

            if (ThongBao.Show("Thông báo", "Bạn có chắc là muốn xoá?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_UPDATE_TASKPRICE_Del]", strID);

                    if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                    {
                       
                        fn_LoadDefault();
                    }
                    else
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    ds.Dispose();
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmRPT10 frm = new frmRPT10("rptBC011");
            frm.ShowDialog();
        }


    }


}