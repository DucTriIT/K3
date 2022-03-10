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
    public partial class frmTillProccessTxn : DevExpress.XtraEditors.XtraForm
    {
        private string strIDs = "";
        public string strErrorCode = "";
        //private string strTillTxnIDs = "";

        //private string strTrnTypes = "";
        //private string strTrnCodes = "";


        public frmTillProccessTxn()
        {
            InitializeComponent();
        }

        public frmTillProccessTxn(string mIDs)
        {
            strIDs = mIDs;
            //strTillTxnIDs = _TillTxnIDs;

            InitializeComponent();
            //// Thanh toán luôn ở đây
            fn_LoadDataToGrid();
            if (clsSystem.TillID == "")
            {
                btnProcess.Enabled = false;
                ThongBao.Show("Lỗi", "Không thể thực hiện giao dịch thu ngân.\nDo bạn chưa mở Quầy thu ngân.", "OK", ICon.Error);
                this.Close();
                return;
            }
           
            /// Thực hiện luôn nút Đồng ý thanh toán
            DataSet ds = new DataSet();
            string strTillID;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                strTillID = clsSystem.TillID;

                if (strIDs != "")
                {
                    
                    ds = clsCommon.ExecuteDatasetSP("T_TILL_TXN_Proc", strIDs, strTillID, clsSystem.UserID);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        strErrorCode = ds.Tables[0].Rows[0]["Result"].ToString();
                        if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                        {
                            ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString() + " [" + ds.Tables[0].Rows[0]["ErrorCode"].ToString() + "]", "OK", ICon.Error);
                            return;
                        }
                        else
                        {
                            ThongBao.Show("Thông báo", "Thanh toán thành công", "OK", ICon.Information);
                            this.Close();
                            //fn_LoadDataToGrid();
                        }
                    }
                    
                }
                else
                {
                    ThongBao.Show("Thông báo", "Vui lòng chọn giao dịch cần thanh toán.", "OK", ICon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", "Hàm btnProcess_Click: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                //fn_LoadDataToGrid();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void fn_LoadDataToGrid()
        {
            //Goi SP T_TILL_TXN_DETAIL_GetByTrnID
            //Tao da viet SP xogn rui do
            // IDs la TrnRefID

            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("T_TILL_TXN_DETAIL_GetByTrnID", strIDs);
                grdControl.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
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

        private void frmTillProccessTxn_Load(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();            
            if (clsSystem.TillID == "")
            {
                btnProcess.Enabled = false;
                ThongBao.Show("Lỗi", "Không thể thực hiện giao dịch thu ngân.\nDo bạn chưa mở Quầy thu ngân.", "OK", ICon.Error);
            }
            else
            {
                btnProcess.Enabled = true;
                btnProcess.Focus();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strTillID;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                strTillID = clsSystem.TillID;

                if (strIDs != "")
                {
                    if (ThongBao.Show("Thông báo", "Bạn có chắc chắn không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                    {
                        ds = clsCommon.ExecuteDatasetSP("T_TILL_TXN_Proc", strIDs, strTillID, clsSystem.UserID);

                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            strErrorCode = ds.Tables[0].Rows[0]["Result"].ToString();
                            if (ds.Tables[0].Rows[0]["Result"].ToString() != "0")
                            {
                                ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString() + " [" + ds.Tables[0].Rows[0]["ErrorCode"].ToString() + "]", "OK", ICon.Error);
                            }
                            else
                            {
                                //ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                                this.Close();
                                //fn_LoadDataToGrid();
                            }
                        }
                    }
                }
                else
                {
                    ThongBao.Show("Thông báo", "Vui lòng chọn giao dịch cần thanh toán.", "OK", ICon.Warning);
                }                
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", "Hàm btnProcess_Click: " + ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                //fn_LoadDataToGrid();
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnHuyThanhToan_Click(object sender, EventArgs e)
        {
           
        }
    }
}