using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Data;

namespace GoldRT
{
    public class clsDatabase
    {
        //private variable
        private string strConnectionString;
        
        //public variable
        public SqlConnection gConnection;

        public clsDatabase()
        {
            strConnectionString = getConnectionString();
        }

        public string[] getDatabaseInfo()
        {
            string FileName = clsSystem.SvrInfoFilePath;

            if (!File.Exists(FileName))
                throw new Exception("Không tìm thấy file cấu hình");

            string[] retValue = new string[0];
            try
            {
                int count = 0;

                //Đọc dữ liệu từ file cấu hình
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);
                XmlNode xmlnut = xmlDoc.SelectSingleNode("DATA");
                count = xmlnut.ChildNodes.Count;
                retValue = new string[count];
                retValue[0] = xmlnut.SelectSingleNode("SERVER").InnerText;
                retValue[1] = xmlnut.SelectSingleNode("NAME").InnerText;
                retValue[2] = xmlnut.SelectSingleNode("USERID").InnerText;
                retValue[3] = Functions.fn_DeEncryptPassword(xmlnut.SelectSingleNode("PASSWORD").InnerText);
                retValue[4] = xmlnut.SelectSingleNode("PRINTER").InnerText;
                retValue[5] = xmlnut.SelectSingleNode("PRINTERBILL").InnerText;
            }
            catch
            {
                throw new Exception("File cấu hình không hợp lệ");
            }
            return retValue;        
        }

        private string getConnectionString()
        {
            string[] arrDatabaseInfo;
            string strConnectionString = "";

            arrDatabaseInfo = getDatabaseInfo();
            strConnectionString = "Data source = " + arrDatabaseInfo[0] + "; Initial Catalog = " + arrDatabaseInfo[1] + "; Persist Security Info=True;User ID= " + arrDatabaseInfo[2] + "; Password = " + arrDatabaseInfo[3];
            return strConnectionString;
           
        }

        public void Connect()
        {
            if (gConnection == null)
            {
                try
                {
                    gConnection = new SqlConnection(strConnectionString);
                    gConnection.Open();
                }
                catch
                {
                    gConnection.Dispose();
                    gConnection = null;
                    throw new Exception("Không kết nối được đến cơ sở dữ liệu. Vui lòng kiểm tra lại");
                }
            }
        }

        public void Disconnect()
        {
            try
            {                
                gConnection.Close();
                gConnection.Dispose();
                gConnection = null;
            }
            catch
            {
                throw new Exception("Không đóng được kết nối cơ sở dữ liệu");
            }
        }

        //Kiểm tra xem chương trình có Connect được tới CSDL không?
        //Với tham số là 1 ConnectionString khác với hệ thống
        public bool TestConnection(string pConnectString)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(pConnectString);
                Conn.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }
        
    }
}
