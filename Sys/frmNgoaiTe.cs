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
    public partial class frmNgoaiTe : DevExpress.XtraEditors.XtraForm
    {
        public frmNgoaiTe()
        {
            InitializeComponent();
        }

        private void frmNgoaiTe_Load(object sender, EventArgs e)
        {
            if (clsSystem.NgoaiTe == "CO")
                ckbat.Checked = true;
            else
                cktat.Checked = true;
            
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbat_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbat.Checked)
                cktat.Checked = false;
            else
                cktat.Checked = true;
        }

        private void cktat_CheckedChanged(object sender, EventArgs e)
        {
            if (cktat.Checked)
                ckbat.Checked = false;
            else
                ckbat.Checked = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(clsSystem.SvrInfoFilePath);
                XMLDoc = Functions.fn_UpdateXMLDocument(XMLDoc, "NGOAITE", ckbat.Checked ? "CO" : "KHONG");
                XMLDoc.Save(clsSystem.SvrInfoFilePath);
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            ThongBao.Show("Thông báo", "Đã lưu cấu hình thành công. Vui lòng thoát khỏi chương trình và đăng nhập lại.", "OK", ICon.Information);
        }
    }
}