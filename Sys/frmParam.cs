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
    public partial class frmParam : DevExpress.XtraEditors.XtraForm
    {
        string strID = String.Empty;

        public frmParam()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhomUsers_Load(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
            ckbSMS.Checked = clsSystem.IsSMS;
            if(!clsSystem.ShowSMS)
                ckbSMS.Dispose();
        }

        private bool fn_CheckValidate(DataRow dr)
        {
            if (dr["DataType"].ToString().ToLower() == "num")
            {
                decimal iTemp;
                if (!decimal.TryParse(dr["ParaValue"].ToString(), out iTemp))
                {
                    ThongBao.Show("Lỗi", "Vui lòng nhập vào kiểu số.", "OK", ICon.Error);
                    return false;
                }
            }
            return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {
                DataRow dr = grdDanhSach.GetDataRow(i);

                if (!fn_CheckValidate(dr)) break;

                DataSet ds = new DataSet();

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[SYS_PARAMETERS_Upd]", dr["ParaKey"].ToString(), dr["ParaValue"].ToString(), null, null, null);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    ds.Dispose();
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                    this.Cursor = Cursors.Default;
                    break;
                }
                finally
                {
                    ds.Dispose();
                    this.Cursor = Cursors.Default;

                }
            }
            for (int i = 0; i < grdDanhSach1.RowCount; i++)
            {
                DataRow dr = grdDanhSach1.GetDataRow(i);

                if (!fn_CheckValidate(dr)) break;

                DataSet ds = new DataSet();

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    ds = clsCommon.ExecuteDatasetSP("[SYS_PARAMETERS_Upd]", dr["ParaKey"].ToString(), dr["ParaValue"].ToString(), null, null, null);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                    {
                        ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                        break;
                       
                    }
                  
                }
                catch (Exception ex)
                {
                    ds.Dispose();
                    ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                    this.Cursor = Cursors.Default;
                    break;
                }
                finally
                {
                    ds.Dispose();
                    this.Cursor = Cursors.Default;

                }
            }
            DataSet ds1;
            try
            {
               ds1 = clsCommon.ExecuteDatasetSP("[SYS_PARAMETERS_Upd]", "IsSMS",
                   ckbSMS.Checked ? "1" : "0", null, null, null);

                if (ds1.Tables[0].Rows[0]["Result"].ToString() != "0")
                {
                    ThongBao.Show("Lỗi", ds1.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
                else
                    ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
            }
            catch(Exception ex)
            {                
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                this.Cursor = Cursors.Default;               
            }
            
            fn_LoadDataToGrid();
            Program.fn_LoadSystemParameter();
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_PARAMETERS_Lst]", "", "", "", "", "", "1", "");

                if (ds.Tables.Count > 0)
                {
                    grdControl.DataSource = ds.Tables[1];
                    gridControl1.DataSource = ds.Tables[2];
                 
                   // lblNumRec.Text = ds.Tables[0].Rows.Count.ToString();
                }
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

        private void btnLogo_Click(object sender, EventArgs e)
        {
            frmTaiAnh frm = new frmTaiAnh();
            frm.ShowDialog();

        }
        
    }
}