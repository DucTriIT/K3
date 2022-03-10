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
    public partial class frmKhoaManHinh : DevExpress.XtraEditors.XtraForm
    {

        frmMain mForm;

        public frmKhoaManHinh()
        {
            InitializeComponent();
            lblThongBao.Visible = false;
        }

        public frmKhoaManHinh(frmMain frm)
        {
            InitializeComponent();
            lblThongBao.Visible = false;

            mForm = frm;
        }

        private void picOK_Click(object sender, EventArgs e)
        {
            clsUsers objUser = new clsUsers();
            DataSet ds = new DataSet();
            string strErrCode = "", strErrDesc = "";

            try
            {
                ds = objUser.CheckLogin(clsSystem.UserName, Functions.getMd5Hash(txtMatKhau.Text));

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strErrCode = ds.Tables[0].Rows[0]["Result"].ToString();
                        strErrDesc = ds.Tables[0].Rows[0]["ErrorDesc"].ToString();
                        ds.Dispose();
                        if (strErrCode == "0") // dang nhap thanh cong
                        {
                            //Dong form
                            this.Close();
                        }
                        else
                        {
                            lblThongBao.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            mForm.Close();
            //this.Close();

        }

     
    }
}