using System;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Threading;
using Clockwork;

namespace GoldRT
{
    /// <summary>
    /// Summary description for CommSetting.
    /// </summary>

    public class CommSetting
    {
        public static int Comm_Port = 0;
        public static int Comm_BaudRate = 0;
        public static int Comm_TimeOut = 0;
        public static GsmCommMain comm;

        public CommSetting()
        {
            //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            // TODO: Add constructor lo e
            //
        }
        public static void Set()
        {

        }
        public static void SendMessage(string message)
        {
            try
            {
                Clockwork.API api = new API("fe1ee4e1b47311eb32568d2cedc27be23e2721c5");
                SMSResult result = api.Send(
                    new SMS
                    {
                        To = "84945351146",
                        Message = message
                    });

            }
            catch (Exception ex)
            {
                return;
            }
            //try
            //{
            //    string transType = string.Empty;

            //    string DuongDan = Application.StartupPath + "\\configSMS.xml"; //Đường dẫn file cấu hình
            //    string FileName = DuongDan;
            //    if (!File.Exists(FileName))
            //        throw new Exception("Không tìm thấy file cấu hình");

            //    //Đọc dữ liệu từ file cấu hình
            //    XmlDocument xmlDoc;
            //    xmlDoc = new XmlDocument();
            //    xmlDoc.Load(FileName);
            //    CommSetting.Comm_Port = int.Parse(Functions.fn_GetXMLNodeValue(xmlDoc, "PortName"));
            //    CommSetting.Comm_BaudRate = int.Parse(Functions.fn_GetXMLNodeValue(xmlDoc, "BitPerSecond"));
            //    CommSetting.Comm_TimeOut = 2000;
            //    Cursor.Current = Cursors.WaitCursor;
            //    CommSetting.comm = new GsmCommMain(Comm_Port, Comm_BaudRate, 2000);
            //    Cursor.Current = Cursors.Default;
            //    bool retry;                
            //    do
            //    {
            //        retry = false;
            //        try
            //        {
            //            Cursor.Current = Cursors.WaitCursor;
            //            comm.Open();
            //            Cursor.Current = Cursors.Default;
            //        }
            //        catch (Exception)
            //        {
            //            comm.Close();
            //            return;
            //        }
            //    }
            //    while (retry);

            //    // Send an SMS message
            //    SmsSubmitPdu pdu;

            //    string[] arrNumber = clsSystem.SMS_NUMBER.Split(',');
            //    for (int i = 0; i < arrNumber.Length; i++)
            //    {
            //        byte dcs = DataCodingScheme.NoClass_16Bit;
            //        pdu = new SmsSubmitPdu(message, arrNumber[i],dcs);
            //        CommSetting.comm.SendMessage(pdu);
            //        if (i < arrNumber.Length - 1)
            //        {
            //            Thread.Sleep(1000);
            //        }
            //    }
            //    comm.Close();

            //}
            //catch (Exception ex)
            //{
            //    return;
            //}

        }
    }
}
