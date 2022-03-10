using DevExpress.XtraEditors;
using GoldRT;
using Messages;
using SuperX.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace SuperX
{
    public partial class frmChangeRoom : Form
    {
        private string room;
        public string changeroom;
        public string changemagd;

        public frmChangeRoom()
        {
            InitializeComponent();
        }

        public frmChangeRoom(string room)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.room = room;
            
        }

        private void frmChangeRoom_Load(object sender, EventArgs e)
        {
            InitSoDoPhong();
        }
        private void InitSoDoPhong()
        {
            DataSet ds = new DataSet();
            tileControl1.Groups.Clear();
            ds = clsCommon.ExecuteDatasetSP("T_Phong_Lst",room);
            TileGroup group = new TileGroup();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TileItem item = new TileItem();
                    item.Name = dr["IDPhong"].ToString();
                    item.Text = dr["TenPhong"].ToString();
                    item.Tag = dr["MAHD"] + "";
                    item.TextAlignment = TileItemContentAlignment.TopCenter;
                    item.Image = !string.IsNullOrEmpty(dr["MAHD"] + "") ? Resources._1454839877_Open_Sign : Resources._1454839955_closed_shop_black_friday_sale_store;
                    item.ImageAlignment = TileItemContentAlignment.MiddleCenter;
                    item.ItemClick += new TileItemClickEventHandler(item_ItemClick);
                    group.Items.Add(item);
                }
                tileControl1.Groups.Add(group);
            }
        }

        private void item_ItemClick(object sender, TileItemEventArgs e)
        {
            if (ThongBao.Show("Thông báo", "Bạn có muốn chuyển sang phòng :" + (sender as TileItem).Text, "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
            {
                changemagd = (sender as TileItem).Tag.ToString();
                changeroom = (sender as TileItem).Name;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
