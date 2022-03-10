using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SuperX
{
    public partial class ucPhong : UserControl
    {
        public ucPhong()
        {
            InitializeComponent();
        }
        private string idPhong;
        public string IDPhong
        {
            get { return idPhong; }
            set { idPhong = value; }
        }
        private string tenPhong;
        public string TenPhong
        {
            get { return tenPhong; }
            set { tenPhong = value; }
        }
        private string trangThai;
        public string TrangThai
        {
            get { return tenPhong; }
            set { tenPhong = value; }
        }
        private string loaiPhong;
        public string LoaiPhong
        {
            get { return loaiPhong; }
            set { loaiPhong = value; }
        }

        private void ucPhong_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadPhong()
        {
            lblTenPhong.Text = tenPhong;
            picLoaiPhong.Image = (loaiPhong == "1" ? Properties.Resources.user_vip : null);
            picTrangThai.Image = (trangThai == "1" ? Properties.Resources._1454839877_Open_Sign : Properties.Resources._1454839955_closed_shop_black_friday_sale_store);
        }
    }
}
