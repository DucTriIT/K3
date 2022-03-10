using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using Messages;
using System.Threading;
using SplashScreenThreaded;
using SuperX;
using System.Text;


namespace GoldRT
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        FrmSplashScreen frm = new FrmSplashScreen();
        frmProduct_In FrmProduct_In;
        frmRTBuy FrmRTBuy;
        frmRTBuySell FrmRTBuySell;
        frmRTChange FrmRTChange;
        frmForeignCurrency FrmForeignCurrency;
        frmTillInOut FrmTillInOut;
        frmTillProcess FrmTillProcess;
        frmProduct_Out FrmProduct_Out;
        frmQueryTillBal FrmQueryTillBal;
        frmTransferStorage FrmTransferStorage;
        frmInventory_Check FrmInventory_Check;
        frmSoDoPhong FrmSoDoPhong;


        public frmMain()
        {
            this.Hide();
            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            InitializeComponent();
            splashthread.IsBackground = true;
            splashthread.Start();
            InitSkins();
            timer2.Interval = clsSystem.ReloadXRate == 0 ? 60 * 1000 : clsSystem.ReloadXRate * 1000;
            timer1.Start();
            timer2.Start();
            sTime.Caption = DateTime.Now.ToString("hh:mm:ss");
            sDate.Caption = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Show();
            SplashScreen.CloseSplashScreen();
            this.Activate();

            fn_LoadSkin(clsSystem.SkinName, clsSystem.SkinPaintStyle);
            //fn_LoadNgoaiTe(clsSystem.NgoaiTe);


            FileInfo fi = new FileInfo(Application.ExecutablePath);
            string appPath = fi.DirectoryName;
            //this.BackgroundImage = Image.FromFile(appPath + "\\Image.jpg");            
            this.Text = clsSystem.AppTitle + " - " + clsSystem.ShopName;

            //Application.Run(new frmLogin());
            if (Program.objDB.gConnection != null)
            {
                //Application.DoEvents();
                //frmLoadData frmLoad = new frmLoadData();
                //frmLoad.ShowDialog();
                fn_LoadChucNang();
                IsPO();
                Application.DoEvents();
                frmLogin frmLogin = new frmLogin(this);
                frmLogin.ShowDialog();
            }
            else
            {
                //disable all menu, toolbar
                fn_SetMenuPermit("DBNotFound");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ThongBao.Show("Thông báo", "Bạn có thật sự muốn thoát khỏi chương trình?", "Có", "Không", ICon.QuestionMark) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sTime.Caption = DateTime.Now.ToString("HH:mm:ss");
            sDate.Caption = DateTime.Now.ToString("dd/MM/yyyy");

            if (clsSystem.BackupTime != null && clsSystem.BackupTime.Contains(DateTime.Now.ToString("HH:mm:ss")))
            {
                if (clsSystem.IsSMS)
                {
                    try
                    {

                        this.Cursor = Cursors.WaitCursor;
                        DataSet ds = new DataSet();
                        ds = clsCommon.ExecuteDatasetSP("SMS", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

                        StringBuilder msg = new StringBuilder();                       
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            msg.AppendLine(clsSystem.ShopName + " " + DateTime.Now.ToString("dd/MM/yyyy"));
                            msg.AppendLine("Tiền Hát:" + dr[0].ToString() + ",Tiền Phòng:" + dr[1].ToString() + ",Tiền Bớt:" + dr[2].ToString() + ",T.T:" + dr[3].ToString());

                        }
                        CommSetting.SendMessage(msg.ToString());
                        ds.Dispose();
                    }
                    catch
                    {

                        Cursor.Dispose();
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            if (Program.objDB.gConnection != null)
            {
                if (clsSystem.TillCode == "")
                {
                    sTill.Caption = "Quầy đang đóng";
                    sTill.ImageIndex = 28;
                }
                else
                {
                    sTill.Caption = "Quầy đang mở (" + clsSystem.TillName + ")";
                    sTill.ImageIndex = 27;
                }
            }

        }


        //GC.Collect();


        private void timer2_Tick(object sender, EventArgs e)
        {
            // CommSetting.SendMessage("Giao dich: mua ban \n So tien: " + "1800000" + ",Quay: " + clsSystem.TillName + " NV:" + clsSystem.UserName);
        }

        #region Skins
        private void InitSkins()
        {
            barManager1.ForceInitialize();
            BarButtonItem item;
            foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
            {
                item = new BarButtonItem(barManager1, "Skin: " + cnt.SkinName);
                item.Tag = "NotSecurity";
                mnuGiaoDien.AddItem(item);
                item.ItemClick += new ItemClickEventHandler(OnSkinClick);
            }
        }

        private void OnSkinClick(object sender, ItemClickEventArgs e)
        {
            string skinName = e.Item.Caption.Replace("Skin: ", "");
            fn_LoadSkin(skinName, "Skin");
            Functions.fn_SetProfileSkinInfo(skinName, "Skin");
        }

        private void ips_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fn_LoadSkin(e.Item.Description, "Default");
            Functions.fn_SetProfileSkinInfo(e.Item.Description, "Default");
        }
        #endregion

        #region Menu event

        private void mnuDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChangPassword frm = new frmChangPassword();
            frm.ShowDialog();
        }

        private void mnuKhoaManHinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKhoaManHinh frm = new frmKhoaManHinh(this);
            frm.ShowDialog();
        }

        private void mnuNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.ShowDialog();
        }

        private void mnuNhomUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNhomUsers frm = new frmNhomUsers();
            frm.ShowDialog();
        }
        private void mnuPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPhanQuyen frm = new frmPhanQuyen(this);
            frm.ShowDialog();
        }

        private void mnuDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (xtraTabbedMdiManager1.SelectedPage != null)
            {

                ThongBao.Show("Warning", "Vui lòng đóng các form đang mở trước khi đăng nhập lại!", "OK", ICon.Warning);
                return;
            }
            frmLogin frm = new frmLogin(this);
            frm.ShowDialog();
        }

        private void mnuKetNoiCSDL_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDatabaseInfo frm = new frmDatabaseInfo(this);
            frm.ShowDialog();
        }

        private void mnuDMPhongBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmDept frm = new frmDept();
            //frm.ShowDialog();
        }

        private void mnuNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmEmployee frm = new frmEmployee();
            //frm.ShowDialog();
        }

        private void mnuCVDi_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmWorkerTran frm = new frmWorkerTran();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void mnuLoaiCongVan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmDocTypes frm = new frmDocTypes();
            //frm.ShowDialog();
        }

        private void mnuCoQuan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmOrgs frm = new frmOrgs();
            //frm.ShowDialog();
        }

        private void mnuCapCoQuan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmOrgLevels frm = new frmOrgLevels();
            //frm.ShowDialog();
        }

        private void mnuCVDen_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmIDoc_Ins frm = new frmIDoc_Ins();
            //frm.ShowDialog();
        }
        private void mnuDoMat_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmSecrets frm = new frmSecrets();
            //frm.ShowDialog();
        }

        private void mnuDoKhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmUrgents frm = new frmUrgents();
            //frm.ShowDialog();
        }
        private void mnuCVDenXuLy_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmIDoc_ProcessLst frm = new frmIDoc_ProcessLst();
            //frm.ShowDialog();
        }
        private void mnuLinhVuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmFields frm = new frmFields();
            //frm.ShowDialog();
        }

        private void mnuChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmPosition frm = new frmPosition();
            //frm.ShowDialog();
        }
        #endregion

        #region public function
        public void fn_LoadSkin(string SkinName, string PaintStyle)
        {
            if (PaintStyle == "Skin")
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(SkinName);
                barManager1.GetController().PaintStyleName = PaintStyle;
            }
            else
            {
                barManager1.GetController().PaintStyleName = SkinName;
                barManager1.GetController().ResetStyleDefaults();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
            }
            mnuGiaoDien.Caption = mnuGiaoDien.Hint = "Skin: " + SkinName;
            mnuGiaoDien.Hint = mnuGiaoDien.Caption;
        }

        public void fn_SetMenuDefault()
        {
            //Duyet qua tat ca cac menuitem tren menubar
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].GetType().Name == "BarSubItem" || barManager1.Items[i].GetType().Name == "BarButtonItem")
                {
                    barManager1.Items[i].Enabled = true;
                }
            }

            //Duyet qua tat ca cac toolbar
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].GetType().Name == "BarLargeButtonItem" && barManager1.Items[i].Tag != null)
                {
                    barManager1.Items[i].Enabled = true;
                }
            }



            sUserOnline.Caption = clsSystem.UserName + " - " + clsSystem.FullName;
            if (clsSystem.TillCode == "")
            {
                sTill.Caption = "Quầy đang đóng";
                sTill.ImageIndex = 28;
            }
            else
            {
                sTill.Caption = "Quầy đang mở (" + clsSystem.TillCode + " - " + clsSystem.TillName + ")";
                sTill.ImageIndex = 27;
            }
            sStatus.Caption = "Phần mềm quản lý quán cafe-karaoke";
        }

        public void fn_SetMenuPermit(string pGroupID)
        {
            if (pGroupID == "NotLogin")
            {
                //Menu bar
                mnuGiaoDich_GRP.Enabled = false;
                mnuGDThuNgan_GRP.Enabled = false;
                mnuGDTho_GRP.Enabled = false;
                mnuGDHang_GRP.Enabled = false;
                mnuDanhMuc_GRP.Enabled = false;
                mnuTraCuu_GRP.Enabled = false;
                mnuBaoCao_GRP.Enabled = false;
                mnuDanhMuc_GRP.Enabled = false;

                mnuHeThong_GRP.Enabled = true;
                mnuDangNhap.Enabled = true;
                mnuDoiMatKhau.Enabled = false;
                mnuKhoaManHinh.Enabled = false;
                mnuThoat.Enabled = true;
                mnuNguoiDung.Enabled = false;
                mnuNhomUsers.Enabled = false;
                mnuPhanQuyen.Enabled = false;
                mnuNgayNghi.Enabled = false;
                mnuParam.Enabled = false;
                mnuTygia.Enabled = false;
                mnuTaiAnh.Enabled = false;
                mnuKetNoiCSDL.Enabled = false;
                mnuCNHT.Visibility = BarItemVisibility.Never;

                //toolbar

                tbProductIn.Enabled = false;
                //tbProductOut.Enabled = false;
                tbSoDuQuay.Enabled = false;
                tbTraCuuHang.Enabled = false;
                //tbBC001.Enabled = false;
                //tbBC002.Enabled = false;
                tbDangNhap.Enabled = true;
                tbKiemKeHang.Enabled = false;
                tbTyGiaVang.Enabled = false;
                tbBackUp.Enabled = false;
                tbTraCuuGD.Enabled = false;

                //Set thong tin tren Status bar
                sStatus.Caption = "Chưa đăng nhập vào hệ thống";
                sUserOnline.Caption = "";
                sTill.Caption = "Quầy đang đóng";
                sTill.ImageIndex = 28;

                return;
            }

            if (pGroupID == "DBNotFound")
            {
                //Menu bar
                mnuGiaoDich_GRP.Enabled = false;
                mnuGDThuNgan_GRP.Enabled = false;
                mnuGDTho_GRP.Enabled = false;
                mnuGDHang_GRP.Enabled = false;
                mnuDanhMuc_GRP.Enabled = false;
                mnuTraCuu_GRP.Enabled = false;
                mnuBaoCao_GRP.Enabled = false;
                mnuDanhMuc_GRP.Enabled = false;

                mnuHeThong_GRP.Enabled = true;
                mnuDangNhap.Enabled = false;
                mnuDoiMatKhau.Enabled = false;
                mnuKhoaManHinh.Enabled = false;
                mnuThoat.Enabled = true;
                mnuNguoiDung.Enabled = false;
                mnuNhomUsers.Enabled = false;
                mnuPhanQuyen.Enabled = false;
                mnuNgayNghi.Enabled = false;
                mnuParam.Enabled = false;
                mnuTygia.Enabled = false;
                mnuKetNoiCSDL.Enabled = true;
                mnuCNHT.Visibility = BarItemVisibility.Never;
                //Toolbar

                tbProductIn.Enabled = false;
                //tbProductOut.Enabled = false;
                tbSoDuQuay.Enabled = false;
                tbTraCuuHang.Enabled = false;
                //tbBC001.Enabled = false;
                //tbBC002.Enabled = false;
                tbDangNhap.Enabled = false;
                tbTraCuuGD.Enabled = false;

                //Set thong tin tren Status bar
                sStatus.Caption = "Lỗi kết nối CSDL";
                sUserOnline.Caption = "";
                sTill.Caption = "Quầy đang đóng";
                sTill.ImageIndex = 28;

                return;
            }

            //Da login
            DataSet ds = new DataSet();

            ds = clsCommon.ExecuteDatasetSP("[SYS_MENUS_GetAllRights]", pGroupID);

            //Duyet qua tat ca cac menuitem tren menubar
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].GetType().Name == "BarSubItem" || barManager1.Items[i].GetType().Name == "BarButtonItem")
                {
                    if (ds.Tables[0].Select("MenuID = '" + barManager1.Items[i].Name + "'").Length > 0 || barManager1.Items[i].Tag != null)
                    {
                        barManager1.Items[i].Enabled = true;
                    }
                    else
                    {
                        barManager1.Items[i].Enabled = false;
                    }
                }
            }

            //Duyet qua tat ca cac toolbar
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].GetType().Name == "BarLargeButtonItem" && barManager1.Items[i].Tag != null)
                {
                    if (!String.IsNullOrEmpty(barManager1.Items[i].Tag.ToString()) && barManager1.Items[barManager1.Items[i].Tag.ToString()] != null)
                    {
                        barManager1.Items[i].Enabled = barManager1.Items[barManager1.Items[i].Tag.ToString()].Enabled;
                    }
                }
            }

            sStatus.Caption = "Phần mềm quản lý quán cafe-karaoke";
            sUserOnline.Caption = clsSystem.UserName + " - " + clsSystem.FullName;

            if (clsSystem.TillCode == "")
            {
                sTill.Caption = "Quầy đang đóng";
                sTill.ImageIndex = 28;
            }
            else
            {
                sTill.Caption = "Quầy đang mở (" + clsSystem.TillCode + " - " + clsSystem.TillName + ")";
                sTill.ImageIndex = 27;
            }
        }

        public void fn_SetMenuAllowLogin()
        {
            mnuDangNhap.Enabled = true;
            tbDangNhap.Enabled = true;
        }
        public void fn_LoadNgoaiTe(string Value)
        {
            if (Value == "KHONG")
            {

                mnuBC103.Visibility = BarItemVisibility.Never;
            }
        }

        public void IsPO()
        {

        }

        public void fn_LoadChucNang()
        {
            DataSet ds = new DataSet();
            ds = clsCommon.ExecuteDatasetSP("[SYS_MENUS_GetAllRights]", "2");

            //Duyet qua tat ca cac menuitem tren menubar
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].GetType().Name == "BarSubItem" || barManager1.Items[i].GetType().Name == "BarButtonItem")
                {
                    if (ds.Tables[0].Select("MenuID = '" + barManager1.Items[i].Name + "'").Length > 0 || barManager1.Items[i].Tag != null)
                    {
                        //barManager1.Items[i].Enabled = true;
                        barManager1.Items[i].Visibility = BarItemVisibility.Always;
                    }
                    else
                    {
                        // barManager1.Items[i].Enabled = false;
                        barManager1.Items[i].Visibility = BarItemVisibility.Never;
                    }
                }
            }

            //Duyet qua tat ca cac toolbar
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].GetType().Name == "BarLargeButtonItem" && barManager1.Items[i].Tag != null)
                {
                    if (!String.IsNullOrEmpty(barManager1.Items[i].Tag.ToString()) && barManager1.Items[barManager1.Items[i].Tag.ToString()] != null)
                    {
                        //barManager1.Items[i].Enabled = barManager1.Items[barManager1.Items[i].Tag.ToString()].Enabled;
                        barManager1.Items[i].Visibility = barManager1.Items[barManager1.Items[i].Tag.ToString()].Visibility;
                    }
                }
            }
        }
        #endregion

        private void Test()
        {
            //foreach (object ctrl in )
            //{
            //    MessageBox.Show(ctrl.GetType().Name);
            //}
            //barManager1.Items[4].Enabled = false;
            //MessageBox.Show(barManager1.Items[4]);
            //for (int i = 0; i < barManager1.Items.Count; i++)
            //{
            //    MessageBox.Show(barManager1.Items[i].Name + " " + barManager1.Items[i]. .ItemId.ToString());
            //}
            //bool d = mnuCongVan_GRP.ContainsItem(barManager1.Items[""]);
        }

        private void mnuDMQuayLon_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMainSection frm = new frmMainSection();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDMKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDMNhomHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPdtGroup frm = new frmPdtGroup();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDMHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuLoaiVang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmGoldType frm = new frmGoldType();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDMQuayNho_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSection frm = new frmSection();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDMNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.MdiParent = this;
            frm.Show();
        }


        private void mnuForeignCurrency_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmForeignCurrency.Close();
            }
            catch { }
            FrmForeignCurrency = new frmForeignCurrency();
            FrmForeignCurrency.MdiParent = this;
            if (clsSystem.IsScan)
            {
                frmOpenTill_1 frm = new frmOpenTill_1();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                frm.Close();
            }
            FrmForeignCurrency.Show();
        }

        private void mnuMoQuay_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmOpenTill frm = new frmOpenTill(this);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuThanhToan_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmTillProcess.Close();
            }
            catch { }
            FrmTillProcess = new frmTillProcess();
            FrmTillProcess.MdiParent = this;
            if (clsSystem.IsScan)
            {
                frmOpenTill_1 frm = new frmOpenTill_1();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                frm.Close();
            }
            FrmTillProcess.Show();
        }

        private void mnuProductIN_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmRTBuy.Close();
            }
            catch { }
            FrmRTBuy = new frmRTBuy();
            FrmRTBuy.MdiParent = this;
            FrmRTBuy.Show();
        }

        private void mnuProductIN_Appr_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProductILstApprove frm = new frmProductILstApprove();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuProductOUT_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmProduct_Out.Close();
            }
            catch { }
            FrmProduct_Out = new frmProduct_Out();
            FrmProduct_Out.MdiParent = this;
            FrmProduct_Out.Show();
        }

        private void mnuProductOUT_Appr_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProductOLstApprove frm = new frmProductOLstApprove();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDongQuay_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCloseTill frm = new frmCloseTill(this);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuKiemKeTonKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmInventory_Check.Close();
            }
            catch { }
            FrmInventory_Check = new frmInventory_Check();
            FrmInventory_Check.MdiParent = this;
            FrmInventory_Check.Show();
        }

        private void mnuCapNhatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProduct_Upd frm = new frmProduct_Upd();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuBC001_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT01 frm = new frmRPT01("BC001");
            frm.ShowDialog();
        }

        private void mnuBC002_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT02 frm = new frmRPT02("BC002");
            frm.ShowDialog();
        }

        private void mnuBC003_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT01 frm = new frmRPT01("BC003");
            frm.ShowDialog();
        }

        private void mnuBC004_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmRPT02 frm = new frmRPT02("BC004");
            frm.ShowDialog();
        }

        private void mnuBC005_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT04 frm = new frmRPT04("BC005");
            frm.ShowDialog();
        }

        private void mnuDMTienTe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCurrency frm = new frmCurrency();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tbProductIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmProduct_In frm = new frmProduct_In();
            try
            {
                FrmRTBuy.Close();
            }
            catch { }
            FrmRTBuy = new frmRTBuy();
            FrmRTBuy.MdiParent = this;
            FrmRTBuy.Show();
        }

        private void tbProductOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmProduct_Out.Close();
            }
            catch { }
            FrmProduct_Out = new frmProduct_Out();
            FrmProduct_Out.MdiParent = this;
            FrmProduct_Out.Show();
        }

        private void mnuBC006_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT04 frm = new frmRPT04("BC006");
            frm.ShowDialog();
        }

        private void mnuBC007_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("BC007");
            frm.ShowDialog();
        }

        private void mnuBC008_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT04 frm = new frmRPT04("BC008");
            frm.ShowDialog();
        }

        private void mnuPOGold_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPOGold frm = new frmPOGold();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuPOMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPOMaster frm = new frmPOMaster();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuPOProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPOProduct frm = new frmPOProduct();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void mnuParam_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmParam frm = new frmParam();
            frm.ShowDialog();
        }

        private void mnuDoiVang_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (FrmRTChange != null)
                    FrmRTChange.Close();

            }
            catch
            {
                ThongBao.Show("Thông báo", "Lỗi đóng cửa sổ đổi bù", "OK", ICon.Information);
            }
            FrmRTChange = new frmRTChange();
            FrmRTChange.MdiParent = this;
            if (clsSystem.IsScan)
            {
                frmOpenTill_1 frm = new frmOpenTill_1();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                frm.Close();
            }
            FrmRTChange.Show();
        }

        private void mnuMuaBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (FrmRTBuySell != null)
                    FrmRTBuySell.Close();
            }
            catch
            {
                ThongBao.Show("Thông báo", "Lỗi đóng cửa sổ mua bán", "OK", ICon.Information);
            }
            FrmRTBuySell = new frmRTBuySell();
            FrmRTBuySell.MdiParent = this;
            if (clsSystem.IsScan)
            {
                frmOpenTill_1 frm = new frmOpenTill_1();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                frm.Close();
            }
            FrmRTBuySell.Show();
        }

        private void tbToaHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPOProduct frm = new frmPOProduct();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tbToaDe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPOGold frm = new frmPOGold();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPOMaster frm = new frmPOMaster();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTC_ToaHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPOStatistic frm = new frmPOStatistic();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tbDoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (FrmRTChange != null)
                    FrmRTChange.Close();

            }
            catch
            {
                ThongBao.Show("Thông báo", "Lỗi đóng cửa sổ đổi bù", "OK", ICon.Information);
            }
            FrmRTChange = new frmRTChange();
            FrmRTChange.MdiParent = this;
            if (clsSystem.IsScan)
            {
                frmOpenTill_1 frm = new frmOpenTill_1();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                frm.Close();
            }
            FrmRTChange.Show();
        }

        private void mnuMuaDe_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (FrmSoDoPhong != null)
                    FrmSoDoPhong.Close();
            }
            catch
            {
                ThongBao.Show("Thông báo", "Lỗi đóng cửa sổ sơ đồ phòng", "OK", ICon.Information);
            }
            FrmSoDoPhong = new frmSoDoPhong();
            FrmSoDoPhong.MdiParent = this;
            FrmSoDoPhong.Show();
        }
        public void LoadSoDoPhong()
        {
            try
            {
                if (FrmSoDoPhong != null)
                    FrmSoDoPhong.Close();
            }
            catch
            {
                ThongBao.Show("Thông báo", "Lỗi đóng cửa sổ sơ đồ phòng", "OK", ICon.Information);
            }
            FrmSoDoPhong = new frmSoDoPhong();
            FrmSoDoPhong.MdiParent = this;
            FrmSoDoPhong.Show();
        }
        private void tbMuaBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (FrmRTBuySell != null)
                    FrmRTBuySell.Close();
            }
            catch
            {
                ThongBao.Show("Thông báo", "Lỗi đóng cửa sổ mua bán", "OK", ICon.Information);
            }
            FrmRTBuySell = new frmRTBuySell();
            FrmRTBuySell.MdiParent = this;
            if (clsSystem.IsScan)
            {
                frmOpenTill_1 frm = new frmOpenTill_1();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                frm.Close();
            }
            FrmRTBuySell.Show();
        }

        private void tbMuaDe_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (FrmRTBuy != null)
                    FrmRTBuy.Close();
            }
            catch
            {
                ThongBao.Show("Thông báo", "Lỗi đóng cửa sổ mua dẻ", "OK", ICon.Information);
            }
            FrmRTBuy = new frmRTBuy();
            FrmRTBuy.MdiParent = this;
            if (clsSystem.IsScan)
            {
                frmOpenTill_1 frm = new frmOpenTill_1();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                frm.Close();
            }
            FrmRTBuy.Show();
        }

        private void tbNgoaiTe_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmForeignCurrency.Close();
            }
            catch { }
            FrmForeignCurrency = new frmForeignCurrency();
            FrmForeignCurrency.MdiParent = this;
            if (clsSystem.IsScan)
            {
                frmOpenTill_1 frm = new frmOpenTill_1();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                frm.Close();
            }
            FrmForeignCurrency.Show();
        }

        private void mnuQryTillBal_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmQueryTillBal.Close();
            }
            catch { }
            FrmQueryTillBal = new frmQueryTillBal();
            FrmQueryTillBal.MdiParent = this;
            FrmQueryTillBal.Show();
        }

        private void mnuBC101_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("BC101");
            frm.ShowDialog();
        }

        private void mnuBC102_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("BC102");
            frm.ShowDialog();
        }

        private void mnuBC103_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("BC103");
            frm.ShowDialog();
        }

        private void mnuThiChiQuay_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (clsSystem.TillID == "")
            {
                ThongBao.Show("Thông báo", "Vui lòng mở quầy trước khi thực hiện.", "OK", ICon.Information);
                return;
            }
            frmTillTransfer frm = new frmTillTransfer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDMThuNgan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTill frm = new frmTill();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTho_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTrnWorker frm = new frmTrnWorker();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDMTho_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmWorker frm = new frmWorker();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuBC105_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT06 frm = new frmRPT06("BC105");
            frm.ShowDialog();
        }

        private void mnuTC_TTHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryProduct frm = new frmQueryProduct();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTC_DeTrongNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPTGoldInDay frm = new frmRPTGoldInDay();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTC_NoCu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryCustDebt frm = new frmQueryCustDebt();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTC_NoTho_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryWorkerDebt frm = new frmQueryWorkerDebt();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTC_MuaDe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryRTBuy frm = new frmQueryRTBuy();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTC_MuaBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryRTBuySell frm = new frmQueryRTBuySell();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTC_Doi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryRTChange frm = new frmQueryRTChange();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTC_GDTho_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryTrnWorker frm = new frmQueryTrnWorker();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuBC201_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("BC201");
            frm.ShowDialog();
        }

        private void tbDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            mnuDangNhap_ItemClick(sender, e);
        }

        private void mnuThuChiTaiQuay_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmTillInOut.Close();
            }
            catch { }
            FrmTillInOut = new frmTillInOut();
            FrmTillInOut.MdiParent = this;
            if (clsSystem.IsScan)
            {
                frmOpenTill_1 frm = new frmOpenTill_1();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                frm.Close();
            }
            FrmTillInOut.Show();
        }

        private void mnuBC402_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT05 frm = new frmRPT05("BC402");
            frm.ShowDialog();
        }

        private void mnuBC401_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT05 frm = new frmRPT05("BC401");
            frm.ShowDialog();
        }

        private void mnuTC_DSKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryCust frm = new frmQueryCust();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tbThuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            mnuThuChiTaiQuay_ItemClick(sender, e);
        }

        private void tbSoDuQuay_ItemClick(object sender, ItemClickEventArgs e)
        {
            mnuQryTillBal_ItemClick(sender, e);
        }

        private void tbTraCuuHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            mnuTC_TTHang_ItemClick(sender, e);
        }

        private void tbBC001_ItemClick(object sender, ItemClickEventArgs e)
        {
            mnuBC001_ItemClick(sender, e);
        }

        private void tbBC002_ItemClick(object sender, ItemClickEventArgs e)
        {
            mnuBC002_ItemClick(sender, e);
        }

        private void tbThanhToan_ItemClick(object sender, ItemClickEventArgs e)
        {
            mnuThanhToan_ItemClick(sender, e);
        }

        private void mnuTC_GDBanLe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryRTTran frm = new frmQueryRTTran();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTC_XRate_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryXRate frm = new frmQueryXRate();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tbKiemKeHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmInventory_Check frm = new frmInventory_Check();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTygia_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmXRate frm = new frmXRate();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuBC104_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("BC104");
            frm.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSectionGroup frm = new FrmSectionGroup();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNgoaiTe frm = new frmNgoaiTe();
            frm.ShowDialog();
        }

        private void barButtonItem23_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmPhanQuyenHeThong frm = new frmPhanQuyenHeThong();
            frm.ShowDialog();
        }

        public void fn_Active_Menu()
        {
            mnuCNHT.Visibility = BarItemVisibility.Always;
            mnuCNHT.Enabled = true;
        }
        public void fn_Disable_Menu()
        {
            mnuCNHT.Visibility = BarItemVisibility.Never;
        }
        private void mnuCongNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCongNo frm = new frmCongNo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuBC106_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("BC106");
            frm.ShowDialog();
        }

        private void mnuTaiAnh_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTaiAnh frm = new frmTaiAnh();
            frm.ShowDialog();
        }

        private void mnuCapNhatGia_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuImportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmImportData frm = new frmImportData();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuSMS_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSMS frm = new frmSMS();
            frm.ShowDialog();
        }

        private void tbTyGiaVang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmXRate frm = new frmXRate();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuBC010_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT09 frm = new frmRPT09("rptBC010");
            frm.ShowDialog();
        }

        private void mnuBC009_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("rptBC009");
            frm.ShowDialog();
        }

        private void mnuBC011_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT07 frm = new frmRPT07("rptBC011");
            frm.ShowDialog();
        }

        private void mnuBC202_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuBC009__ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT04 frm = new frmRPT04("BC005_");
            frm.ShowDialog();
        }

        private void barButtonItem16_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmProgress frm = new frmProgress("BK");
            frm.ShowDialog();
            //Thread t = new Thread(BackUp);
            //t.Start();
            //t.Join();
            //if (s)
            //{
            //    ThongBao.Show("Thông báo", "Sao lưu thành công", "OK", ICon.Information);
            //}



        }

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (xtraTabbedMdiManager1.SelectedPage != null && xtraTabbedMdiManager1.SelectedPage.MdiChild == FrmRTBuySell)
            {
                FrmRTBuySell.FocusProductCode();
            }

        }

        private void mnuBC300_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT08 frm = new frmRPT08("BC300");
            frm.ShowDialog();
        }

        private void btnTraCuuGD_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryRTTran frm = new frmQueryRTTran();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuHDNhapHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Nhap hang.mht");
            Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Nhap hang.mht");

        }

        private void mnuDMNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSupplier frm = new frmSupplier();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, strDocPath, HelpNavigator.Index);
            }
        }

        private void mnuHDCNTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Cap nhat thong tin hang.mht");
            Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Cap nhat thong tin hang.mht");
        }

        private void mnuHDMuaBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Mua-ban.mht");
            Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Mua-ban.mht");
        }

        private void mnuHDDoiBu_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Doi hang.mht");
            Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Doi hang.mht");
        }

        private void mnuHDTraCuuHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Tra cuu thong tin hang.mht");
            Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Tra cuu thong tin hang.mht");
        }

        private void mnuHDTraCuuGD_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Tra cuu giao dich.mht");
            Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Tra cuu giao dich.mht");
        }

        private void mnuHDKiemHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Kiem hang.mht");
            Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Kiem hang.mht");
        }

        private void mnuHDTKBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Xem thong ke, bao cao.mht");
            Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Xem thong ke, bao cao.mht");
        }

        private void mnuHDKBDM_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Khai bao danh muc.mht");
            Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Khai bao danh muc.mht");
        }

        private void barButtonItem23_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            frmExpenses frm = new frmExpenses();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuBC107_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("BC107");
            frm.ShowDialog();
        }

        private void mnuTC_CacQuay_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryThuChiGiuaCacQuay frm = new frmQueryThuChiGiuaCacQuay();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem23_ItemClick_3(object sender, ItemClickEventArgs e)
        {
            frmPaymentDebit frm = new frmPaymentDebit();
            frm.ShowDialog();
        }

        private void mnuBC203_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRPT03 frm = new frmRPT03("BC203");
            frm.ShowDialog();
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProductUpd_TaskPrice frm = new frmProductUpd_TaskPrice();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuXRateRef_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRefPrice frm = new frmRefPrice();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void mnuTC_ProductSell_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryProduct_BestSeller frm = new frmQueryProduct_BestSeller();
            frm.MdiParent = this;
            frm.Show();

        }

        private void mnuChuyenQuay_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProduct_Tranfer frm = new frmProduct_Tranfer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuHangDoiTra_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQueryProduct_DoiTra frm = new frmQueryProduct_DoiTra();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem24_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmRTCatGia frm = new frmRTCatGia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuThanhtoantho_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmWorkerPayment frm = new frmWorkerPayment();
            frm.ShowDialog();
        }

        private void mnuMainSectionTran_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmTransferStorage.Close();
            }
            catch { }
            FrmTransferStorage = new frmTransferStorage();
            FrmTransferStorage.MdiParent = this;
            FrmTransferStorage.Show();
        }

        private void mnuDebtByDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmDebtByDate frm = new frmDebtByDate();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void mnuNgayLe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNgayLe frm = new frmNgayLe();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuXoaDuLieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProgress frm = new frmProgress("DD");
            frm.ShowDialog();
        }
    }
}