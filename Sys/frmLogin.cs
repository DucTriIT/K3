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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        frmMain frm;
        bool flag = false;

        public frmLogin(frmMain pFormMain)
        {
            InitializeComponent();

            frm = pFormMain;
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = clsSystem.OldUserName;
        }

        private void cmdBoQua_Click(object sender, EventArgs e)
        {
            frm.fn_SetMenuPermit("NotLogin");
            this.Close();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strErrCode ="", strErrDesc = "";

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_Users_CheckLogin]", txtUserName.Text, Functions.getMd5Hash(txtPassword.Text));

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strErrCode = ds.Tables[0].Rows[0]["Result"].ToString();
                        strErrDesc = ds.Tables[0].Rows[0]["ErrorDesc"].ToString();
                        ds.Dispose();
                        if (strErrCode == "0") // dang nhap thanh cong
                        {
                            flag = true;
                            //luu cac thong tin user dang online vao clsSystem
                            clsSystem.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                            clsSystem.IsAdmin = ds.Tables[0].Rows[0]["IsAdmin"].ToString();
                            clsSystem.GroupID = ds.Tables[0].Rows[0]["GroupID"].ToString();
                            clsSystem.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                            clsSystem.FullName = ds.Tables[0].Rows[0]["FullName"].ToString();
                            clsSystem.OldUserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                            clsSystem.TillID = ds.Tables[0].Rows[0]["TillID"].ToString(); 
                            clsSystem.TillCode = ds.Tables[0].Rows[0]["TillCode"].ToString();
                            clsSystem.TillName = ds.Tables[0].Rows[0]["TillName"].ToString();

                            if (clsSystem.GetCurrentAccountType() != AccountType.SuperAccount)
                                frm.fn_SetMenuPermit(clsSystem.GroupID);
                            else
                                frm.fn_SetMenuDefault();

                            //Save User Login
                            Functions.fn_SetProfileUserLogin(clsSystem.UserName);

                            //
                            if (ds.Tables[0].Rows[0]["Active"].ToString() == "2")
                                frm.fn_Active_Menu();
                            else
                                frm.fn_Disable_Menu();
                            
                            // Load sơ đồ phòng
                            frm.LoadSoDoPhong();

                            //Dong form
                            this.Close();
                        }
                        else
                        {
                            ThongBao.Show("Thông báo", strErrDesc, "OK", ICon.Error);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            if (txtUserName.Text != "")
            {
                txtPassword.Focus();
            }
            else
            {
                txtUserName.Focus();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flag == false)
            {
                frm.fn_SetMenuPermit("NotLogin");
               
            }
          

        }
    }
}