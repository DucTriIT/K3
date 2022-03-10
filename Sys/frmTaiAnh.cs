using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Messages;

namespace GoldRT
{
    public partial class frmTaiAnh : DevExpress.XtraEditors.XtraForm
    {
        private Byte[] m_PrdtImage;
        public Byte[] PrdtImage
        {
            get { return m_PrdtImage; }
            set { m_PrdtImage = value; }
        }
        public frmTaiAnh()
        {
            InitializeComponent();
        }

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(fDialog.FileName);
                    //txtLink.Text = fDialog.FileName;
                    picProduct.Image = bitmap;
                    FileStream fs = new FileStream(fDialog.FileName, FileMode.Open, FileAccess.Read);
                    this.PrdtImage = new Byte[fs.Length];
                    fs.Read(this.PrdtImage, 0, int.Parse(fs.Length.ToString()));
                    InsertToDataBase(fDialog.FileName, PrdtImage);
                    //
                

                }
                catch
                {
                    ThongBao.Show("Lỗi", "Chọn không đúng định dạng ảnh. Vui lòng chọn lại.", "OK", ICon.Error);
                }

            }
        }

        private void frmTaiAnh_Load(object sender, EventArgs e)
        {
            fn_LoadData();
        }

        private void InsertToDataBase(string FileName,byte[] Image)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_IMAGE_Ins]", FileName, Image);
            }
            catch
            {
                ThongBao.Show("Lỗi", "Chọn không đúng định dạng ảnh. Vui lòng chọn lại.", "OK", ICon.Error);
            }

        }

        private void hyperLinkEdit2_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_IMAGE_del]");
                //txtLink.Text = "";
                picProduct.Image = null;
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
        }

        private void fn_LoadData()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_IMAGE_get]");
                if (ds.Tables.Count > 0)
                {
                    //txtLink.Text = ds.Tables[0].Rows[0]["Link"].ToString();
                    PrdtImage = (Byte[])ds.Tables[0].Rows[0]["image"];
                    MemoryStream fs = new MemoryStream(PrdtImage);
                    Bitmap bitmap = new Bitmap(fs);
                    picProduct.Image = bitmap;
                }
            }
            catch (Exception ex)
            {
                //ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
        }

        private void hyperLinkEdit3_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            this.Close();
        }
    }
}