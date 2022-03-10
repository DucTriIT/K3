using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.IO;
using Messages;

namespace GoldRT
{
    public partial class frmSMS : DevExpress.XtraEditors.XtraForm
    {
        public frmSMS()
        {
            InitializeComponent();
        }

        private void frmSMS_Load(object sender, EventArgs e)
        {
            try
            {
                txtPhoneNumber.Text = clsCommon.ExecuteDatasetSP("[SYS_PARAMETERS_Get]", "SMS_NUMBER").Tables[0].Rows[0]["ParaValue"].ToString();
                string transType = string.Empty;
                string DuongDan = Application.StartupPath + "\\configSMS.xml"; //Đường dẫn file cấu hình
                string FileName = DuongDan;
                if (!File.Exists(FileName))
                    throw new Exception("Không tìm thấy file cấu hình");

                //Đọc dữ liệu từ file cấu hình
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);
                string a = Functions.fn_GetXMLNodeValue(xmlDoc, "SMS");
                if (a == "0") CkActive.Checked = false; else CkActive.Checked = true;
            }
            catch { }
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string DuongDan = Application.StartupPath + "\\configSMS.xml"; //Đường dẫn file cấu hình
                string FileName = DuongDan;
                if (!File.Exists(FileName))
                {
                    throw new Exception("Không tìm thấy file cấu hình");
                    return;
                }

                XmlDocument XMLDoc = new XmlDocument();


                XMLDoc.Load(DuongDan);
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "SMS", CkActive.Checked == true ? "1" : "0");
                XMLDoc.Save(DuongDan);

                clsCommon.ExecuteDatasetSP("[SYS_PARAMETERS_UpdPhoneNo]", txtPhoneNumber.Text);
                Program.fn_LoadSystemParameter();
                //Program.fn_getAppConfigSMS();
                ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
        }

    }
}