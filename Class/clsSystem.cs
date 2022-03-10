using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Collections;

namespace GoldRT
{
    public class RepoItem
    {
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
    }

    public enum AccountType
    { 
        NormalAccount,
        SuperAccount
    }

    public static class clsSystem
    {
        public static bool deny;
        /********* Static variable ************/
        public static string UserID;
        public static string IsAdmin;
        public static string UserName;
        public static string GroupID;
        public static string FullName;
        public static decimal HSLe;

        public static string TillID;
        public static string TillCode;
        public static string TillName;

        public static string SvrInfoFilePath;
        public static string ProfileInfoFilePath;

        public static string OldUserName;
        public static string UnitWeight;
        public static decimal HSGia;
        public static decimal HSTL;
        public static decimal HSCan;
        public static string AppTitle;
        public static string ShopName;
        public static string ShopAddress;
        public static string ShopTel;

        public static decimal StampWieght;
        public static decimal StampWieght_G;
        public static DataSet XRate;
        public static DataSet IGold;
        public static DataSet AllGoldCcy;
        public static int XRatePercent_Gold;
        public static int XRatePercent_FCY;
        public static int ProductCodeLen;
        public static string WalkInCustID;
        public static int ReloadXRate;        

        public static string SkinPaintStyle;
        public static string SkinName;

        public static int L_ParseData_Config_position;
        public static int L_ParseData_Config_length;
        public static int G_ParseData_Config_position;
        public static int G_ParseData_Config_length;

        public static string PortName;
        public static string BitPerSecond;
        public static string DataBit;
        public static string Parity;
        public static string StopBit;
        public static string FlowControl;
        public static string ReadTimeout;
        public static string Printer;
        public static string PrinterBill;

        public static string NgoaiTe;
        public static bool IsPO;
        public static string SMS_NUMBER;
        public static bool IsSMS;

        public static string BackupTime;
        public static string BackupLink;

        public static bool IsNoStamp;
        public static bool IsDiamondPrice;
        public static bool IsShowLCD;
        public static bool IsShowPOTaskPrice;
        public static bool ISChangeTaskPrice;
        public static bool ShowSMS;
        public static bool IsPayCard;
        public static bool IsScan;
        public static bool IsHeSo;
        public static bool IsDoiTra;
        public static bool IsCatGia;

        public static decimal TienGio;
        public static decimal TienGioVip;
        public static decimal TiemThem11h { get; set; }

        public static decimal TiemThem12h { get; set; }

        public static AccountType GetCurrentAccountType()
        {
            return UserID == "0" ? AccountType.SuperAccount : AccountType.NormalAccount;
        }

        public static DateTime GetNISTDate(bool convertToLocalTime)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            DateTime date = DateTime.Today;
            string serverResponse = string.Empty;

            // Represents the list of NIST servers
            string[] servers = new string[]
                                   {
                                       "nist1-ny.ustiming.org",
                                        "nist1-nj.ustiming.org",
                                        "nist1-pa.ustiming.org",
                                        "time-a.nist.gov",
                                        "time-b.nist.gov",
                                        "nist1.aol-va.symmetricom.com",
                                        "nist1.columbiacountyga.gov",
                                        "nist1-chi.ustiming.org",
                                        "nist.expertsmi.com",
                                        "nist.netservicesgroup.com"

                                   };

            // Try each server in random order to avoid blocked requests due to too frequent request
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    // Open a StreamReader to a random time server
                    StreamReader reader =
                        new StreamReader(
                            new System.Net.Sockets.TcpClient(servers[ran.Next(0, servers.Length)], 13).GetStream());
                    serverResponse = reader.ReadToEnd();
                    reader.Close();

                    // Check to see that the signiture is there
                    if (serverResponse.Length > 47 && serverResponse.Substring(38, 9).Equals("UTC(NIST)"))
                    {
                        // Parse the date
                        int jd = int.Parse(serverResponse.Substring(1, 5));
                        int yr = int.Parse(serverResponse.Substring(7, 2));
                        int mo = int.Parse(serverResponse.Substring(10, 2));
                        int dy = int.Parse(serverResponse.Substring(13, 2));
                        int hr = int.Parse(serverResponse.Substring(16, 2));
                        int mm = int.Parse(serverResponse.Substring(19, 2));
                        int sc = int.Parse(serverResponse.Substring(22, 2));

                        if (jd > 51544)
                            yr += 2000;
                        else
                            yr += 1999;

                        date = new DateTime(yr, mo, dy, hr, mm, sc);

                        // Convert it to the current timezone if desired
                        if (convertToLocalTime)
                            date = date.ToLocalTime();

                        // Exit the loop
                        break;
                    }
                }
                catch (Exception ex)
                {
                    deny = false;
                    return date;
                }
            }
            deny = true;
            return date;
        }

      
    }
}
