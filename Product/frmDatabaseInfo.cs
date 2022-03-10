using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using Messages;
using System.Drawing.Printing;

namespace GoldRT
{
    public partial class frmDatabaseInfo : DevExpress.XtraEditors.XtraForm
    {
        frmMain frm;

        public frmDatabaseInfo()
        {
            InitializeComponent();
        }

        public frmDatabaseInfo(frmMain pfrm)
        {
            InitializeComponent();

            frm = pfrm;
        }

       

        private void frmDatabaseInfo_Load(object sender, EventArgs e)
        {
            string[] Info = new string[0];
            try
            {
                Info = Program.objDB.getDatabaseInfo();
            }
            catch
            {
                return;
            }

            txtServer.Text = Info[0];
            txtDBName.Text = Info[1];
            txtUserName.Text = Info[2];
            txtPassword.Text = Info[3];

            DataTable lTable = new DataTable("PrinterList");
            DataColumn lName = new DataColumn("Printer", typeof(string));
            lTable.Columns.Add(lName);
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
              
                DataRow lLang = lTable.NewRow();
                lLang["Printer"] = printer.ToString();
                lTable.Rows.Add(lLang);
            }
            Functions.BindDropDownList(cboPrinter, lTable, "Printer", "Printer", Info[4], false);
            /// Máy in
            DataTable lTable2 = new DataTable("PrinterList2");
            DataColumn lName2 = new DataColumn("Printer2", typeof(string));
            lTable2.Columns.Add(lName2);
            foreach (String printer2 in PrinterSettings.InstalledPrinters)
            {

                DataRow lLang2 = lTable2.NewRow();
                lLang2["Printer2"] = printer2.ToString();
                lTable2.Rows.Add(lLang2);
            }
            Functions.BindDropDownList(cboPrinterBill, lTable2, "Printer2", "Printer2", Info[5], false);
            cboPrinter.Text = Info[4];
            cboPrinterBill.Text = Info[5];
           
        }
    
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data source = " + txtServer.Text + "; Initial Catalog = " + txtDBName.Text + 
                   "; Persist Security Info=True;User ID= " + txtUserName.Text + "; Password = " + txtPassword.Text;
          //  string ConnectionString = "workstation id=GOLDRTDB.mssql.somee.com;packet size=4096;user id=PMV;pwd=phanmemvang;data source=GOLDRTDB.mssql.somee.com;persist security info=False;initial catalog=GOLDRTDB";
            //Kiểm tra kết nối CSDL
            clsDatabase DB = new clsDatabase();
            if (!DB.TestConnection(ConnectionString))
            {
                ThongBao.Show("Lỗi", "Không kết nối được đến cơ sở dữ liệu", "OK", ICon.Error);
                
                return;
            
            }
            PrinterSettings settings = new PrinterSettings();
            settings.PrinterName = cboPrinter.Text;
            if (settings.IsValid == false) return;
            settings.PrinterName = cboPrinterBill.Text;
            if (settings.IsValid == false) return;
            ThongBao.Show("Thống báo", "Kết nối cơ sở dữ liệu thành công", "OK", ICon.Information);
            btnLuu.Enabled = true;
        }

#region TextBox Event Handlers
        //Added by HungTC
        //Ép buộc người dùng phải "kiểm tra thông tin" kết nối trước khi "Lưu"
        private void txtServer_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            btnLuu.Enabled = false;
        }
        private void txtDBName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            btnLuu.Enabled = false;
        }
        private void txtUserName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            btnLuu.Enabled = false;
        }
        private void txtPassword_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument XMLDoc = new XmlDocument();

                string enDBPassword = Functions.fn_EncryptPassword(txtPassword.Text);

                XMLDoc.Load(clsSystem.SvrInfoFilePath);
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "SERVER", "ABC");
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "NAME", "GOLD");
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "USERID", "U");
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "PASSWORD", "P");
                XMLDoc.Save(clsSystem.SvrInfoFilePath);
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument XMLDoc = new XmlDocument();

                string enDBPassword = Functions.fn_EncryptPassword(txtPassword.Text);

                XMLDoc.Load(clsSystem.SvrInfoFilePath);
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "SERVER", txtServer.Text.Trim());
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "NAME", txtDBName.Text.Trim());
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "USERID", txtUserName.Text.Trim());
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "PASSWORD", enDBPassword);
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "PRINTER", cboPrinter.Text);
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "PRINTERBILL", cboPrinterBill.Text);
                XMLDoc.Save(clsSystem.SvrInfoFilePath);
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            ThongBao.Show("Thông báo", "Đã lưu cấu hình thành công. Vui lòng thoát khỏi chương trình và đăng nhập lại.", "OK", ICon.Information);
            frm.fn_SetMenuAllowLogin();
        }
        //End Added
#endregion

    }
}