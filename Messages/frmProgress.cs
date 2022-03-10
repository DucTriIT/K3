using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Messages;

namespace GoldRT
{
    public partial class frmProgress : DevExpress.XtraEditors.XtraForm
    {
        private readonly string strType;
        public frmProgress(string type)
        {
            InitializeComponent();
            strType = type;
        }
        private void BackUp()
        {
            string[] Info = new string[0];
            DataSet ds = new DataSet();
            try
            {
           

                Info = Program.objDB.getDatabaseInfo();
                ds = clsCommon.ExecuteDatasetSP("BackUpData", Info[1].ToString().Trim(), DateTime.Now.ToString("dd_MM_yyyy"));
                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Sao lưu  thành công", "Ok", ICon.Information);
                    this.Close();
                }
                else
                {
                    ThongBao.Show("Lỗi", "Sao lưu không  thành công", "Ok", ICon.Error);
                    this.Close();
                }

            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message.ToString(), "Ok", ICon.Error);
               
            }
            finally
            {
                ds.Dispose();
                this.Close();
            }
        }
        private void XoaDuLieu()
        {   
            DataSet ds = new DataSet();
            try
            {               
                ds = clsCommon.ExecuteDatasetSP("DeleteData");
                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Xóa dữ liệu  thành công", "Ok", ICon.Information);
                    this.Close();
                }
                else
                {
                    ThongBao.Show("Lỗi", "Xóa dữ liệu không  thành công", "Ok", ICon.Error);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message.ToString(), "Ok", ICon.Error);

            }
            finally
            {
                ds.Dispose();
            }
        }
        private void frmProgress_Load(object sender, EventArgs e)
        {            
            if (strType == "BK")
            {
                BackUp();
            }
            else
            {
                XoaDuLieu();
            }
        }
    }
}