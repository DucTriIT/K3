using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using Messages;
using System.IO;
using System.Xml;
using System.Drawing.Printing;

using Super;
using System.Threading;

namespace GoldRT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static clsDatabase objDB;
        private static string SvrInfoFilePathSMS = "";
        public static CultureInfo ciVN = new System.Globalization.CultureInfo("vi-VN");
        public static CultureInfo ciUS = new System.Globalization.CultureInfo("en-US");
        static System.Threading.Mutex singleton = new Mutex(true, "SuperX");
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = ciUS;
            System.Threading.Thread.CurrentThread.CurrentCulture = ciUS;

            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (!singleton.WaitOne(TimeSpan.Zero, true))
                {
                    //there is already another instance running!
                   MessageBox.Show("Phần mềm đã đang chạy", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
                }
                //if (!GenKeys.CompareKey())
                //{
                //    frmRegister frm = new frmRegister();
                //    frm.ShowDialog();
                //    return;
                //}
                clsSystem.SvrInfoFilePath = Application.StartupPath + "\\config.xml"; //Đường dẫn file cấu hình
                SvrInfoFilePathSMS = Application.StartupPath + "\\configSMS.xml"; //Đường dẫn file cấu hình SMS
                clsSystem.ProfileInfoFilePath = Application.StartupPath + "\\app.xml"; //Đường dẫn file cấu hình


                //Load user Profile info
                fn_LoadProfileInfo();

                //Connect DB
                objDB = new clsDatabase();
                objDB.Connect();

                //try
                //{
                //    DataRow dr = clsCommon.ExecuteDatasetSP("Sys_LoadDEMO").Tables[0].Rows[0];
                //    DateTime dateTime = clsSystem.GetNISTDate(true);
                //    DateTime dateEnd = new DateTime(Convert.ToInt32(dr["Year"].ToString()) + 2000,
                //                                    Convert.ToInt32(dr["Month"].ToString()),
                //                                    Convert.ToInt32(dr["CurValue"].ToString()));
                //    if (dateTime > dateEnd)
                //    {
                //        if (clsSystem.deny)
                //            clsCommon.ExecuteDatasetSP("SYS_UpdateDeny");
                //        return;
                //    }
                //}
                //catch (Exception)
                //{
                //    ThongBao.Show("Thông báo", "“ªŽFÙbEn?¯¾^=ƒÓh¹iUÄ'¼˜èz]ç€Ðƒ§eÃÞÞ¡¶î²AWB{=ÓµêÏõ4L*|HÉÉ…Ò~¤} ®Í|ó_t(ÍîvJm”RÒL¼D 1›h±sßMöV^ƒr#ì9<Ç“±}ÎÒÜv)òq2B±J", "OK", ICon.Error);
                //    return;
                //}


                //Load tham so he thong
                fn_LoadSystemParameter();
                fn_getAppConfig();
                //fn_getAppConfigSMS();
            }
            catch (Exception ex)
            {
                ThongBao.Show("Thông báo", ex.Message, "OK", ICon.Error);
            }

            Application.Run(new frmMain());
        }

        private static void fn_LoadProfileInfo()
        {
            string FileName = clsSystem.ProfileInfoFilePath;

            if (!File.Exists(FileName))
                throw new Exception("Không tìm thấy file cấu hình");

            try
            {
                int count = 0;

                //Đọc dữ liệu từ file cấu hình
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);
                XmlNode xmlnut = xmlDoc.SelectSingleNode("DATA");
                count = xmlnut.ChildNodes.Count;

                clsSystem.OldUserName = xmlnut.SelectSingleNode("USER").Attributes["UserName"].InnerText;
                clsSystem.SkinPaintStyle = xmlnut.SelectSingleNode("SKINNAME").Attributes["PaintStyle"].InnerText;
                clsSystem.SkinName = xmlnut.SelectSingleNode("SKINNAME").Attributes["Skin"].InnerText;
            }
            catch
            {
                //throw new Exception("File cấu hình không hợp lệ");
            }
        }

        public static void fn_LoadSystemParameter()
        {
            try
            {
                clsSystem.AppTitle = clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "AppTitle").Tables[0].Rows[0]["ParaValue"].ToString();
                clsSystem.ShopName = clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "ShopName").Tables[0].Rows[0]["ParaValue"].ToString();
                clsSystem.ShopAddress = clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "ShopAddress").Tables[0].Rows[0]["ParaValue"].ToString();
                clsSystem.ShopTel = clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "ShopTel").Tables[0].Rows[0]["ParaValue"].ToString();
                clsSystem.StampWieght = Decimal.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "StampWeight").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.XRatePercent_FCY = int.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "XRatePercent_FCY").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.XRatePercent_Gold = int.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "XRatePercent_Gold").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.ProductCodeLen = int.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "ProductCodeLen").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.WalkInCustID = clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "WalkInCustID").Tables[0].Rows[0]["ParaValue"].ToString();
                clsSystem.ReloadXRate = int.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "ReloadXRate").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.StampWieght_G = Decimal.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "StampWeight_Gam").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.SMS_NUMBER = clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "SMS_NUMBER").Tables[0].Rows[0]["ParaValue"].ToString();
                clsSystem.BackupLink = clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "zBackupLink").Tables[0].Rows[0]["ParaValue"].ToString();
                clsSystem.BackupTime = clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "zBackupTime").Tables[0].Rows[0]["ParaValue"].ToString();
                clsSystem.XRate = clsCommon.ExecuteDatasetSP("[I_XRATE_GetAll]");
                clsSystem.IGold = clsCommon.ExecuteDatasetSP("I_GOLD_GetAll");
                clsSystem.AllGoldCcy = clsCommon.ExecuteDatasetSP("[I_GOLDCCY_GetAll]");
                clsSystem.IsSMS = clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "IsSMS").Tables[0].Rows[0]["ParaValue"].ToString() == "1" ? true : false;
                clsSystem.TienGio = Decimal.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "TienGioThuong").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.TienGioVip = Decimal.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "TienGioVIP").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.HSLe = Decimal.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "TienNgayLe").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.TiemThem11h = Decimal.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "11h").Tables[0].Rows[0]["ParaValue"].ToString());
                clsSystem.TiemThem12h = Decimal.Parse(clsCommon.ExecuteDatasetSP("SYS_PARAMETERS_Get", "12h").Tables[0].Rows[0]["ParaValue"].ToString());

                DataSet dsF = clsCommon.ExecuteDatasetSP("SYS_FUNCTION_lst");
                clsSystem.IsNoStamp = dsF.Tables[0].Rows[1]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.IsDiamondPrice = dsF.Tables[0].Rows[2]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.IsShowLCD = dsF.Tables[0].Rows[3]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.IsShowPOTaskPrice = dsF.Tables[0].Rows[4]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.ISChangeTaskPrice = dsF.Tables[0].Rows[5]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.UnitWeight = dsF.Tables[0].Rows[6]["FnValue"].ToString();
                if (clsSystem.UnitWeight == "L")
                {
                    clsSystem.HSGia = 0.1M;
                    clsSystem.HSTL = 1000;
                    clsSystem.HSCan = 1;
                }
                else if (clsSystem.UnitWeight == "C")
                {
                    clsSystem.HSGia = 1;
                    clsSystem.HSTL = 100;
                    clsSystem.HSCan = 10;
                }
                else if (clsSystem.UnitWeight == "P")
                {
                    clsSystem.HSGia = 10;
                    clsSystem.HSTL = 10;
                    clsSystem.HSCan = 100;
                }
                else if (clsSystem.UnitWeight == "Ly")
                {
                    clsSystem.HSGia = 100;
                    clsSystem.HSTL = 1;
                    clsSystem.HSCan = 1000;
                }
                else if (clsSystem.UnitWeight == "Z")
                {
                    clsSystem.HSGia = 1000;
                    clsSystem.HSTL = 0.1M;
                    clsSystem.HSCan = 10000;
                }

                clsSystem.ShowSMS = dsF.Tables[0].Rows[7]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.IsPayCard = dsF.Tables[0].Rows[8]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.IsScan = dsF.Tables[0].Rows[9]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.IsHeSo = dsF.Tables[0].Rows[10]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.IsDoiTra = dsF.Tables[0].Rows[11]["FnValue"].ToString() == "1" ? true : false;
                clsSystem.IsCatGia = dsF.Tables[0].Rows[12]["FnValue"].ToString() == "1" ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception("SYS_PARAMETER : " + ex.Message);
            }
        }

        public static void fn_getFTPConnectionInfo()
        {
            string FileName = clsSystem.SvrInfoFilePath;

            if (!File.Exists(FileName))
                throw new Exception("Không tìm thấy file cấu hình");

            try
            {
                int count = 0;

                //Đọc dữ liệu từ file cấu hình
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);
                XmlNode xmlnut = xmlDoc.SelectSingleNode("DATA");
                count = xmlnut.ChildNodes.Count;
            }
            catch
            {
                throw new Exception("File cấu hình không hợp lệ");
            }
        }

        public static void fn_getAppConfig()
        {
            string FileName = clsSystem.SvrInfoFilePath;
            string FileNameSMS = SvrInfoFilePathSMS;

            if (!File.Exists(FileName))
                throw new Exception("Không tìm thấy file cấu hình");

            if (!File.Exists(FileNameSMS))
                throw new Exception("Không tìm thấy file cấu hình SMS");

            try
            {
               

                //Đọc dữ liệu từ file cấu hình
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);

                clsSystem.L_ParseData_Config_position = int.Parse(Functions.fn_GetXMLNodeValue(xmlDoc, "L-Position"));
                clsSystem.L_ParseData_Config_length = int.Parse(Functions.fn_GetXMLNodeValue(xmlDoc, "L-Length"));
                clsSystem.G_ParseData_Config_position = int.Parse(Functions.fn_GetXMLNodeValue(xmlDoc, "G-Position"));
                clsSystem.G_ParseData_Config_length = int.Parse(Functions.fn_GetXMLNodeValue(xmlDoc, "G-Length"));

                clsSystem.PortName = Functions.fn_GetXMLNodeValue(xmlDoc, "PortName");
                clsSystem.BitPerSecond = Functions.fn_GetXMLNodeValue(xmlDoc, "BitPerSecond");
                clsSystem.DataBit = Functions.fn_GetXMLNodeValue(xmlDoc, "DataBit");
                clsSystem.Parity = Functions.fn_GetXMLNodeValue(xmlDoc, "Parity");
                clsSystem.StopBit = Functions.fn_GetXMLNodeValue(xmlDoc, "StopBit");
                clsSystem.FlowControl = Functions.fn_GetXMLNodeValue(xmlDoc, "FlowControl");
                clsSystem.ReadTimeout = Functions.fn_GetXMLNodeValue(xmlDoc, "ReadTimeout");
                // Lưu chức năng ngoại tệ
                clsSystem.NgoaiTe = Functions.fn_GetXMLNodeValue(xmlDoc, "NGOAITE");
                /// Đọc cấu hình máy in
                clsSystem.Printer = Functions.fn_GetXMLNodeValue(xmlDoc, "PRINTER");
                clsSystem.PrinterBill = Functions.fn_GetXMLNodeValue(xmlDoc, "PRINTERBILL");
                PrinterSettings settings = new PrinterSettings();
                settings.PrinterName = clsSystem.Printer;
                if (settings.IsValid == false)
                {
                    ThongBao.Show("Lỗi máy in A4, vào danh mục (hệ thống) chọn (kết nối CSDL) để cập nhật", "Lỗi máy in", "OK", ICon.Error); return;
                }
                settings.PrinterName = clsSystem.PrinterBill;
                if (settings.IsValid == false)
                {
                    ThongBao.Show("Lỗi máy in bill, vào danh mục (hệ thống) chọn (kết nối CSDL) để cập nhật", "Lỗi máy in", "OK", ICon.Error); return;
                }
            }
            catch
            {
                throw new Exception("File cấu hình không hợp lệ");
            }
        }

    }
}