//using System;
//using System.Collections.Generic;
//using System.Collections;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.IO;
//using System.Xml;
//using System.Data.SqlClient;
//using System.Data;
//using DevExpress.XtraEditors;
//using System.Windows.Forms;
//using System.Security.Cryptography;
//using CrystalDecisions.Shared;
//using CrystalDecisions.CrystalReports.Engine;
//using DevExpress.XtraEditors.Repository;
//using DevExpress.XtraEditors.Controls;
//using Seagull.BarTender.Print;
//using Seagull.BarTender.Print.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SuperX.Report;

namespace GoldRT
{
    public class Functions
    {
        public  static bool isloading;
        public static void Numeric_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString().Length > ((TextEdit)sender).Properties.MaxLength)
            {
                e.Cancel = true;
            }
        }
        public static void Format_DecimalNumber_TextEdit(TextEdit edit)
        {
            if (clsSystem.UnitWeight == "L")
            {
                edit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.Properties.Mask.EditMask = "n4";
                edit.Properties.EditFormat.FormatString = "#,##0.###0";
                edit.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            else if (clsSystem.UnitWeight == "C")
            {
                edit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.Properties.Mask.EditMask = "n3";
                edit.Properties.EditFormat.FormatString= "#,##0.##0";
                edit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                edit.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            else if (clsSystem.UnitWeight == "P" || clsSystem.UnitWeight == "Ly" || clsSystem.UnitWeight == "Z")
            {
                edit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.Properties.Mask.EditMask = "n2";
                edit.Properties.EditFormat.FormatString = "#,##0.#0";
                edit.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            
        }
        public static void Format_DecimalNumber_GridColums(DevExpress.XtraGrid.Columns.GridColumn col)
        {
            if (clsSystem.UnitWeight == "L")
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = "#,##0.###0";
                if (col.ColumnEdit!=null)
                {
                    ((DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)col.ColumnEdit).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    ((DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)col.ColumnEdit).Mask.EditMask = "n4";
                    ((DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)col.ColumnEdit).Mask.UseMaskAsDisplayFormat = true;
                    col.ColumnEdit.EditFormat.FormatString = "#,##0.###0";
                }
                 
                col.SummaryItem.DisplayFormat = "{0:#,##0.###0}";
            }
            else if (clsSystem.UnitWeight == "C")
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
               
                col.DisplayFormat.FormatString = "#,##0.##0";
               
                if ( col.ColumnEdit!=null)
                {
                    ((DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)col.ColumnEdit).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    ((DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)col.ColumnEdit).Mask.EditMask = "n3";
                    ((DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)col.ColumnEdit).Mask.UseMaskAsDisplayFormat = true;
                    col.ColumnEdit.EditFormat.FormatString = "#,##0.##0";
                }
                    col.SummaryItem.DisplayFormat = "{0:#,##0.##0}";
            }
            else if (clsSystem.UnitWeight == "P" || clsSystem.UnitWeight == "Ly" || clsSystem.UnitWeight == "Z")
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = "#,##0.#0";
                if (col.ColumnEdit!=null)
                {
                    ((DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)col.ColumnEdit).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    ((DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)col.ColumnEdit).Mask.EditMask = "n2";
                    ((DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)col.ColumnEdit).Mask.UseMaskAsDisplayFormat = true;
                    col.ColumnEdit.EditFormat.FormatString = "#,##0.#0";
                }
                col.SummaryItem.DisplayFormat = "{0:#,##0.#0}";
            }
         

        }
        public static void Format_DecimalNumber(Control.ControlCollection cc)
        {
            
            
                foreach (Control ctr in cc)
                {

                    if (ctr is TextEdit)
                    {
                        if (ctr.Tag == "1")
                            Format_DecimalNumber_TextEdit((TextEdit)ctr);
                    }
                    if (ctr is DevExpress.XtraGrid.GridControl)
                    {
                        foreach (DevExpress.XtraGrid.Views.Grid.GridView a in ((DevExpress.XtraGrid.GridControl)ctr).Views)
                        {
                            foreach (DevExpress.XtraGrid.Columns.GridColumn cl in a.Columns)
                            {
                                if (cl.Tag == "1")
                                {
                                    Format_DecimalNumber_GridColums(cl);
                                }
                            }

                        }
                        //DevExpress.XtraGrid.Views.Grid.GridView a = (DevExpress.XtraGrid.Views.Grid.GridView)((DevExpress.XtraGrid.GridControl)ctr).FocusedView;

                        // DevExpress.XtraGrid.GridControl grd = ctr;
                        //grd.key
                    }
                }
          
        }

        public static void BindDropDownList(ComboBoxEdit Ddl, object MyObject, string Text, string Value, string ItemSelected, bool OptNull)
        {
            Ddl.Properties.Items.Clear();
            DataTable dt = new DataTable();
            if (MyObject.GetType() == typeof(DataSet))
            {
                if (((DataSet)MyObject).Tables.Count > 0)
                    dt = ((DataSet)MyObject).Tables[0];
            }
            else if (MyObject.GetType() == typeof(DataTable))
            {
                dt = (DataTable)MyObject;
            }

            if (OptNull)
                Ddl.Properties.Items.Add(new ItemList("", ""));

            foreach (DataRow row in dt.Rows)
            {
                Ddl.Properties.Items.Add(new ItemList(row[Value].ToString(), row[Text].ToString()));
            }

            Ddl.SelectedIndex = GetSelectedIndexCombo(ItemSelected, Ddl, 0);

            dt.Dispose();
        }

        public static void BindDropDownList(ComboBoxEdit Ddl, object MyObject, string Text, string Value, string ItemSelected, bool OptNull, string NullText, string NullValue)
        {
            Ddl.Properties.Items.Clear();
            DataTable dt = new DataTable();
            if (MyObject.GetType() == typeof(DataSet))
            {
                if (((DataSet)MyObject).Tables.Count > 0)
                    dt = ((DataSet)MyObject).Tables[0];
            }
            else if (MyObject.GetType() == typeof(DataTable))
            {
                dt = (DataTable)MyObject;
            }

            if (OptNull)
                Ddl.Properties.Items.Add(new ItemList(NullValue, NullText));

            foreach (DataRow row in dt.Rows)
            {
                Ddl.Properties.Items.Add(new ItemList(row[Value].ToString(), row[Text].ToString()));
            }

            Ddl.SelectedIndex = GetSelectedIndexCombo(ItemSelected, Ddl, 0);
           
            dt.Dispose();
        }

        public static void BindDropDownList(RepositoryItemComboBox Ddl, object MyObject, string Text, string Value, bool OptNull)
        {
            Ddl.Items.Clear();
            DataTable dt = new DataTable();
            if (MyObject.GetType() == typeof(DataSet))
            {
                if (((DataSet)MyObject).Tables.Count > 0)
                    dt = ((DataSet)MyObject).Tables[0];
            }
            else if (MyObject.GetType() == typeof(DataTable))
            {
                dt = (DataTable)MyObject;
            }

            if (OptNull)
                Ddl.Items.Add(new ImageComboBoxItem("", ""));

            foreach (DataRow row in dt.Rows)
            {
                Ddl.Items.Add(new ImageComboBoxItem(row[Text].ToString(), row[Value].ToString()));
            }

            dt.Dispose();
        }

        public static DataRow fn_GetXRate(string _GoldCode)
        {
            string expression = "GoldCcy = '" + _GoldCode + "'";
            DataRow[] arrRow = clsSystem.XRate.Tables[0].Select(expression);
            DataRow dr;

            if (arrRow.Length == 0)
            {
                dr = null;
            }
            else
            {
                dr = arrRow[0];
            }
            return dr;
        }

        public static DataRow fn_GetIGold(string _GoldCode)
        {
            string expression = "GoldCode = '" + _GoldCode + "'";
            DataRow[] arrRow = clsSystem.IGold.Tables[0].Select(expression);
            DataRow dr;
            if (arrRow.Length == 0)
            {
                dr = null;
            }

            else
            {
                dr = arrRow[0];
            }
            return dr;
        }

        public static decimal fn_VNDRounding(decimal _Amount)
        {
            decimal dAmount = Math.Round(_Amount/1000, 0) * 1000;
            return dAmount;
        }

        //public static void BindDropDownList(RepositoryItemComboBox Ddl, object MyObject, string Text, string Value, bool OptNull)
        //{
        //    Ddl.Items.Clear();
        //    DataTable dt = new DataTable();
        //    if (MyObject.GetType() == typeof(DataSet))
        //    {
        //        if (((DataSet)MyObject).Tables.Count > 0)
        //            dt = ((DataSet)MyObject).Tables[0];
        //    }
        //    else if (MyObject.GetType() == typeof(DataTable))
        //    {
        //        dt = (DataTable)MyObject;
        //    }

        //    if (OptNull)
        //        Ddl.Items.Add(new ComboBoxItem(new ItemList("", "")));

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Ddl.Items.Add(new ComboBoxItem(new  ComboBoxItem(new ItemList(row[Value].ToString(), row[Text].ToString())));
        //    }


        //    dt.Dispose();
        //}

        public static bool IsInfinitiveNumeric(string inputString)
        {
            return Regex.IsMatch(inputString, "^[0-9.]+$");
        }

        public static bool IsInterger(string inputString)
        {
            return Regex.IsMatch(inputString, "^[0-9]+$");
        }

        public static bool IsNumeric(string inputString)
        {
            return Regex.IsMatch(inputString, "^[0-9.-]+$");
        } 
        //Rem by HungTC
        //Không sử dụng cách LoadCombo ngay từ đầu nữa.
        //public static void LoadCombo(XtraForm frm)
        //{
        //    string[] arrDM = { "N_DOCTYPES", "N_ORGS", "N_ORGLEVELS", "N_URGENTS", "N_SECRETS", "N_SUFFIXS_I", "N_SUFFIXS_O", "SYS_LEADER", "SYS_SIGNER", "N_FIELDS", "SYS_DEPT", "SYS_EMP", "SYS_GROUPS", "SYS_POSITIONS" };
          
        //    foreach (object ctrl in frm.Controls)
        //    {
        //       if (ctrl.GetType().Name == "ComboBoxEdit")
        //       {
        //           if (((ComboBoxEdit)ctrl).Tag != null)
        //           {
        //               for (int i = 0; i < arrDM.Length; i++)
        //               {
        //                   if (((ComboBoxEdit)ctrl).Tag.ToString() == arrDM[i].ToString())
        //                   {
        //                       for (int j = 0; j < clsSystem.gArrDanhMuc[i].Count; j++)
        //                       {
        //                           ((ComboBoxEdit)ctrl).Properties.Items.Add(clsSystem.gArrDanhMuc[i][j]);
        //                       }
        //                   }
        //               }
        //           }
        //       }

        //       if (ctrl.GetType().Name == "GroupControl")
        //       {
        //           foreach (object ctrl1 in ((GroupControl)ctrl).Controls)
        //           {
        //               if (ctrl1.GetType().Name == "ComboBoxEdit")
        //               {
        //                   if (((ComboBoxEdit)ctrl1).Tag != null)
        //                   {
        //                       for (int i = 0; i < arrDM.Length; i++)
        //                       {
        //                           if (((ComboBoxEdit)ctrl1).Tag.ToString() == arrDM[i].ToString())
        //                           {
        //                               for (int j = 0; j < clsSystem.gArrDanhMuc[i].Count; j++)
        //                               {
        //                                   ((ComboBoxEdit)ctrl1).Properties.Items.Add(clsSystem.gArrDanhMuc[i][j]);
        //                               }
        //                           }
        //                       }
        //                   }
        //               }
        //           }
        //       }
        //    }
        //}
        //End Rem

        public static int GetSelectedIndexCombo(string strID, ComboBoxEdit objCombo, int Method)
        {
            int i = 0, index = 0;

            if (Method == 0)
            {
                foreach (ItemList il in objCombo.Properties.Items)
                {
                    if (il.ID == strID)
                    {   
                        index = i;
                        break;
                    }
                    ++i;
                }
            }
            else
            {
                foreach (ItemList il in objCombo.Properties.Items)
                {
                    if (il.Value == strID)
                    {                        
                        index = i;
                        break;
                    }
                    ++i;
                }            
            }
            return index;
        }

        public static bool WriteXmlFile(string FileName, string strXML)
        {
            XmlDocument xmldoc;
            XmlTextWriter writer;
            try
            {
                xmldoc = new XmlDocument();
                xmldoc.LoadXml(strXML);
                writer = new XmlTextWriter(FileName, null);
                xmldoc.Save(writer);
            }
            catch
            {
                return false;
            }
            writer.Close();
            return true;
        }

        public static void fn_EnableControl(XtraForm frm, bool bEnableStatus)
        {
            string strTypeName  = "";
            foreach (Control ctrl in frm.Controls)
            {
                
                strTypeName = ctrl.GetType().Name;
                if (strTypeName == "TextEdit" || strTypeName == "DateEdit" || strTypeName == "ComboBoxEdit" || strTypeName == "MemoEdit" || strTypeName == "GridLookUpEdit")
                {
                    ctrl.Enabled = bEnableStatus;
                }
            }
            
        }

        public static void fn_SetProfileSkinInfo(string SkinName, string PaintStyle)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(clsSystem.ProfileInfoFilePath);
                XmlNode node = xmlDoc.SelectSingleNode("DATA").SelectSingleNode("SKINNAME");
                node.Attributes["PaintStyle"].Value = PaintStyle;
                node.Attributes["Skin"].Value = SkinName;
                xmlDoc.Save(clsSystem.ProfileInfoFilePath);
            }
            catch(Exception ex)
            {
            }
        }

        public static void fn_SetProfileUserLogin(string pUserName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(clsSystem.ProfileInfoFilePath);
                XmlNode node = xmlDoc.SelectSingleNode("DATA").SelectSingleNode("USER");
                node.Attributes["UserName"].Value = pUserName;
                xmlDoc.Save(clsSystem.ProfileInfoFilePath);
            }
            catch (Exception ex)
            {
            }
        }

        //Ham ma hoa password
        public static string getMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        //Ham tao ten file upload
        public static string getUploadFileName(string strExtension)
        {
            string strResult = "";
            Random ran = new Random();
            
            strResult = DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + ran.Next(1000).ToString() + strExtension;

            ran = null;
            return strResult;
        }

        ////View file from FTPSerevr
        //public static void ViewFileFTP(string pUploadName, string pPathName)
        //{
        //    string DestPath = Application.StartupPath + "\\Temp\\";
        //    FTPclient objFTP = new FTPclient(clsSystem.FTPHost, clsSystem.FTPUser, clsSystem.FTPPassword);

        //    objFTP.Download(pPathName + pUploadName, DestPath + pUploadName, true);
        //    try
        //    {
        //        System.Diagnostics.Process.Start(DestPath + pUploadName);
        //    }
        //    catch
        //    {
        //        throw new Exception("Chưa cài đặt phần mềm để xem file này!");
        //    }
        //}
        public static void fn_ShowReport(DataSet dsReport, string pReportName, string sParams, string sValues)
        {
            ReportDocument Report = new ReportDocument();
            ParameterFields pfs = new ParameterFields();

            string strReportPath;
            strReportPath = Application.StartupPath + "\\Reports\\" + pReportName;
            Report.Load(strReportPath);

            pfs = Report.ParameterFields;

            //Load parameter            
            for (int i = 0; i < pfs.Count; i++)
            {
                switch (pfs[i].Name.ToUpper())
                {
                    case "NGUOILAP":
                        pfs[i].CurrentValues.AddValue(clsSystem.FullName);
                        break;
                    case "NGAYLAP":
                        pfs[i].CurrentValues.AddValue(DateTime.Now.ToString("dd/MM/yyyy"));
                        break;
                    case "SHOPNAME":
                        pfs[i].CurrentValues.AddValue(clsSystem.ShopName);
                        break;
                    case "SHOPADDRESS":
                        pfs[i].CurrentValues.AddValue(clsSystem.ShopAddress);
                        break;
                    case "SHOPTEL":
                        pfs[i].CurrentValues.AddValue(clsSystem.ShopTel);
                        break;
                    case "UNIT":
                        pfs[i].CurrentValues.AddValue(clsSystem.UnitWeight);
                        break;
                    default:
                        break;
                }
            }

            if (sParams != "")
            {
                //Cac param khac        
                string[] aParams = sParams.Split('@');
                string[] aValues = sValues.Split('@');
                for (int j = 0; j < aParams.Length; j++)
                {
                    pfs[aParams[j]].CurrentValues.AddValue(aValues[j].ToString());

                }
            }


            //end Load parameter

            Report.SetDataSource(dsReport.Tables[0]);

            for (int i = 0; i < Report.Subreports.Count; i++)
            {
                Report.Subreports[i].SetDataSource(dsReport.Tables[i + 1]);

            }


            frmViewReport frm = new frmViewReport(100);
            frm.WindowState = FormWindowState.Maximized;
            frm.Report = Report;
            frm.pfs = pfs;
            frm.Show();
        }
        public static void fn_ShowReport_CloseAfterPrint(DataSet dsReport, string pReportName, string sParams, string sValues,bool isBill)
        {
            ReportDocument Report = new ReportDocument();
            ParameterFields pfs = new ParameterFields();

            string strReportPath;
            strReportPath = Application.StartupPath + "\\Reports\\" + pReportName;
            Report.Load(strReportPath);

            pfs = Report.ParameterFields;

            //Load parameter            
            for (int i = 0; i < pfs.Count; i++)
            {
                switch (pfs[i].Name.ToUpper())
                {
                    case "NGUOILAP":
                        pfs[i].CurrentValues.AddValue(clsSystem.FullName);
                        break;
                    case "NGAYLAP":
                        pfs[i].CurrentValues.AddValue(DateTime.Now.ToString("dd/MM/yyyy"));
                        break;
                    case "SHOPNAME":
                        pfs[i].CurrentValues.AddValue(clsSystem.ShopName);
                        break;
                    case "SHOPADDRESS":
                        pfs[i].CurrentValues.AddValue(clsSystem.ShopAddress);
                        break;
                    case "SHOPTEL":
                        pfs[i].CurrentValues.AddValue(clsSystem.ShopTel);
                        break;
                    case "UNIT":
                        pfs[i].CurrentValues.AddValue(clsSystem.UnitWeight);
                        break;
                    default:
                        break;
                }
            }
            if (sParams != "")
            {
                //Cac param khac        
                string[] aParams = sParams.Split('@');
                string[] aValues = sValues.Split('@');
                for (int j = 0; j < aParams.Length; j++)
                {
                    pfs[aParams[j]].CurrentValues.AddValue(aValues[j].ToString());
                }
            }


            //end Load parameter

            Report.SetDataSource(dsReport.Tables[0]);

            for (int i = 0; i < Report.Subreports.Count; i++)
            {
                Report.Subreports[i].SetDataSource(dsReport.Tables[i + 1]);
            }

            frmViewReport frm = new frmViewReport(100);
            frm.WindowState = FormWindowState.Maximized;
            frm.Report = Report;
            frm.pfs = pfs;
            frm.Show();
            PrintDirect(Report, isBill);
            frm.Close();
        }
        public static void fn_ShowReport_CloseAfterPrint_Two(DataSet dsReport, string pReportName, string sParams, string sValues, bool isBill)
        {
            //ReportDocument Report = new ReportDocument();
            //ParameterFields pfs = new ParameterFields();

            //string strReportPath;
            //strReportPath = Application.StartupPath + "\\Reports\\" + pReportName;
            //Report.Load(strReportPath);

            //pfs = Report.ParameterFields;

            ////Load parameter            
            //for (int i = 0; i < pfs.Count; i++)
            //{
            //    switch (pfs[i].Name.ToUpper())
            //    {
            //        case "NGUOILAP":
            //            pfs[i].CurrentValues.AddValue(clsSystem.FullName);
            //            break;
            //        case "NGAYLAP":
            //            pfs[i].CurrentValues.AddValue(DateTime.Now.ToString("dd/MM/yyyy"));
            //            break;
            //        case "SHOPNAME":
            //            pfs[i].CurrentValues.AddValue(clsSystem.ShopName);
            //            break;
            //        case "SHOPADDRESS":
            //            pfs[i].CurrentValues.AddValue(clsSystem.ShopAddress);
            //            break;
            //        case "SHOPTEL":
            //            pfs[i].CurrentValues.AddValue(clsSystem.ShopTel);
            //            break;
            //        case "UNIT":
            //            pfs[i].CurrentValues.AddValue(clsSystem.UnitWeight);
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //if (sParams != "")
            //{
            //    //Cac param khac        
            //    string[] aParams = sParams.Split('@');
            //    string[] aValues = sValues.Split('@');
            //    for (int j = 0; j < aParams.Length; j++)
            //    {
            //        pfs[aParams[j]].CurrentValues.AddValue(aValues[j].ToString());
            //    }
            //}


            ////end Load parameter

            //Report.SetDataSource(dsReport.Tables[0]);

            //for (int i = 0; i < Report.Subreports.Count; i++)
            //{
            //    Report.Subreports[i].SetDataSource(dsReport.Tables[i + 1]);
            //}

            //frmViewReport frm = new frmViewReport(100);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Report = Report;
            //frm.pfs = pfs;
            //frm.Show();
            //PrintDirect_Two(Report, isBill);
            //frm.Close();
        }
        static void PrintDirect(ReportDocument _crp, bool isBill)
        {
            PrintDialog print = new PrintDialog();
            string PrinterName = clsSystem.Printer;
            if (isBill) PrinterName = clsSystem.PrinterBill;
            try
            {

                _crp.PrintOptions.PrinterName = PrinterName;
                _crp.PrintToPrinter(1, false, 0, 1);

               // this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi in, vui lòng cấu hình lại máy in và thử lại!", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        static void PrintDirect_Two(ReportDocument _crp, bool isBill)
        {
            PrintDialog print = new PrintDialog();
            string PrinterName = clsSystem.Printer;
            if (isBill) PrinterName = clsSystem.PrinterBill;
            try
            {

                _crp.PrintOptions.PrinterName = PrinterName;
                _crp.PrintToPrinter(2, false, 0, 1);

                //this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi in, vui lòng cấu hình lại máy in và thử lại!", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public static void fn_ShowReport(DataSet dsReport, string pReportName, string sParams, string sValues, int iZoomSize)
        {
            ReportDocument Report = new ReportDocument();
            ParameterFields pfs = new ParameterFields();
            //

            //
            string strReportPath;
            strReportPath = Application.StartupPath + "\\Reports\\" + pReportName;
            Report.Load(strReportPath);

            pfs = Report.ParameterFields;

            //Load parameter            
            for (int i = 0; i < pfs.Count; i++)
            {
                switch (pfs[i].Name.ToUpper())
                {
                    case "NGUOILAP":
                        pfs[i].CurrentValues.AddValue(clsSystem.FullName);
                        break;
                    case "NGAYLAP":
                        pfs[i].CurrentValues.AddValue(DateTime.Now.ToString("dd/MM/yyyy"));
                        break;
                    case "SHOPNAME":
                        pfs[i].CurrentValues.AddValue(clsSystem.ShopName);
                        break;
                    case "SHOPADDRESS":
                        pfs[i].CurrentValues.AddValue(clsSystem.ShopAddress);
                        break;
                    case "SHOPTEL":
                        pfs[i].CurrentValues.AddValue(clsSystem.ShopTel);
                        break;
                    case "UNIT":
                        pfs[i].CurrentValues.AddValue(clsSystem.UnitWeight);
                        break;
                    default:
                        break;
                }
            }
            if (sParams != "")
            {
                //Cac param khac        
                string[] aParams = sParams.Split('@');
                string[] aValues = sValues.Split('@');
                for (int j = 0; j < aParams.Length; j++)
                {
                    pfs[aParams[j]].CurrentValues.AddValue(aValues[j].ToString());

                }
            }


            //end Load parameter

            Report.SetDataSource(dsReport.Tables[0]);

            for (int i = 0; i < Report.Subreports.Count; i++)
            {
                Report.Subreports[i].SetDataSource(dsReport.Tables[i + 1]);
            }

            frmViewReport frm = new frmViewReport(iZoomSize);
            frm.WindowState = FormWindowState.Maximized;
            frm.Report = Report;
            frm.pfs = pfs;

            //frm.ShowDialog();            
            frm.Show();
        }

        public static void fn_ShowReport_AndImage(DataSet dsReport, string pReportName, string sParams, string sValues)
        {
            //ReportDocument Report = new ReportDocument();
            //ParameterFields pfs = new ParameterFields();

            //string strReportPath;
            //strReportPath = Application.StartupPath + "\\Reports\\" + pReportName;
            //Report.Load(strReportPath);

            //pfs = Report.ParameterFields;

            ////Load parameter            
            //for (int i = 0; i < pfs.Count; i++)
            //{
            //    switch (pfs[i].Name.ToUpper())
            //    {
            //        case "NGUOILAP":
            //            pfs[i].CurrentValues.AddValue(clsSystem.FullName);
            //            break;
            //        case "NGAYLAP":
            //            pfs[i].CurrentValues.AddValue(DateTime.Now.ToString("dd/MM/yyyy"));
            //            break;
            //        case "SHOPNAME":
            //            pfs[i].CurrentValues.AddValue(clsSystem.ShopName);
            //            break;
            //        case "SHOPADDRESS":
            //            pfs[i].CurrentValues.AddValue(clsSystem.ShopAddress);
            //            break;
            //        case "SHOPTEL":
            //            pfs[i].CurrentValues.AddValue(clsSystem.ShopTel);
            //            break;
            //        case "UNIT":
            //            pfs[i].CurrentValues.AddValue(clsSystem.UnitWeight);
            //            break;
            //        default:
            //            break;
            //    }
            //  }
            //if (sParams != "")
            //{
            //    //Cac param khac        
            //    string[] aParams = sParams.Split('@');
            //    string[] aValues = sValues.Split('@');
            //    for (int j = 0; j < aParams.Length; j++)
            //    {
            //        pfs[aParams[j]].CurrentValues.AddValue(aValues[j].ToString());
            //    }
            //}


            ////end Load parameter

            //Report.SetDataSource(dsReport.Tables[0]);

            //bool fixIndex = false;
            //if (Report.Subreports.Count >= 1 && Report.Subreports[0].Name == "Showpic.rpt")
            //    fixIndex = true;

            //for (int i = 0; i < Report.Subreports.Count; i++)
            //{
            //    if (fixIndex)
            //    {
            //        if (i + 1 == Report.Subreports.Count)
            //            //Report.Subreports[0].SetDataSource(dsReport.Tables[i + 1]);
            //            break;
            //        else
            //            Report.Subreports[i + 1].SetDataSource(dsReport.Tables[i + 1]);
            //    }
            //    else
            //        Report.Subreports[i].SetDataSource(dsReport.Tables[i + 1]);
            //}

            ///* Show hinh*/
            ////DataTable dtImage = new DataTable(dsReport.Tables[1].TableName.ToString());
            //if (dsReport.Tables[dsReport.Tables.Count-1].Rows.Count > 0)
            //{
            //    DataTable dt = new DataTable();
            //    DataRow dr;
            //    dt.Columns.Add("Image", System.Type.GetType("System.Byte[]"));
            //    dr = dt.NewRow();
            //    dr[0] = dsReport.Tables[dsReport.Tables.Count - 1].Rows[0]["Image"];//imgByte;
            //    //dt.NewRow();
            //    dt.Rows.Add(dr);
            //    Report.Subreports["Showpic.rpt"].SetDataSource(dt);
            //}
            //frmViewReport frm = new frmViewReport(100);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Report = Report;
            //frm.pfs = pfs;
            //frm.Show();
        }

        public static void fn_PrintStamp_Bartender(string pBarTenderFileName, string pSQL, string pNgonNgu, object objBarTender)
        {
            //LabelFormatDocument btFormat;
            //ODBC btDB ; // = new ODBC("OLEDatabase");

            //string[] arrDatabaseInfo;
            //arrDatabaseInfo = getDatabaseInfo();

            //string strBarTenderPath;
            //strBarTenderPath = Application.StartupPath + "\\Reports\\" + pBarTenderFileName;
            
            //btFormat = objBarTender.Documents.Open(strBarTenderPath);

            //btDB = (ODBC)btFormat.DatabaseConnections[0];
            //btDB.UserID = arrDatabaseInfo[2];
            //btDB.SetPassword(arrDatabaseInfo[3]);

            ////btFormat.SubStrings["NgonNgu"].Value = pNgonNgu;
            //btDB.SQLStatement = pSQL;
            //Result result = btFormat.Print();
        }

        public static XmlDocument fn_UpdateXMLDocument(XmlDocument XMLDoc, string TagName, string NewValue)
        {            
            XmlNodeList node = XMLDoc.GetElementsByTagName(TagName);
            if (node.Count != 0)
            {
                foreach (XmlNode XMLNode in node)
                {
                    XMLNode.ChildNodes.Item(0).InnerText = NewValue;
                }
            }
            return XMLDoc;
        }

        public static string fn_GetXMLNodeValue(XmlDocument XMLDoc, string TagName)
        {
            string strResult = "";
            XmlNodeList node = XMLDoc.GetElementsByTagName(TagName);

            if (node.Count != 0)
            {
                strResult = node.Item(0).InnerText.Trim();
            }
            else
            {
                strResult = "";
            }

            return strResult;
        }
       

        //public static bool fn_CheckFTPServer()
        //{
        //    FTPclient ftpC = new FTPclient(clsSystem.FTPHost, clsSystem.FTPUser, clsSystem.FTPPassword);
        //    if (!ftpC.FtpCreateDirectory("/Test"))
        //    {                
        //        return false;
        //    }
        //    ftpC.FtpDeleteDirectory("/Test");
        //    ftpC = null;
        //    return true;
        //}

        public static void fn_SetFormCaption(XtraForm frm, string text)
        {
            if (text.Length > 20)
                frm.Text = text.Substring(0, 20) + " ...";
            else
                frm.Text = text;
        }

        #region Encryption
        public static string fn_CreateKey(string pKey)
        {
            StringBuilder builder = new StringBuilder();
            int length = pKey.Length;
            for (int i = 1; i <= length; i++)
            {
                int start = (pKey.Length - i);
                builder.Append(pKey.Substring(start, 1));
            }
            string str2 = builder.ToString();
            return builder.ToString();
        }

        public static string fn_EncryptPassword(string pIn)
        {
            try
            {
                string sKey = "";
                if (pIn == "")
                {
                    return pIn;
                }

                sKey = fn_CreateKey("PASSWORD");


                System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
                DES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESEncrypt = DES.CreateEncryptor();
                byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(pIn);
                return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch { return ""; }
        }

        public static string fn_DeEncryptPassword(string pOut)
        {
            try
            {
                if (pOut == "")
                {
                    return pOut;
                }
                string sKey = "";
                System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                sKey = fn_CreateKey("PASSWORD");
                DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
                DES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESEncrypt = DES.CreateDecryptor();
                byte[] Buffer = Convert.FromBase64String(pOut);
                return System.Text.ASCIIEncoding.ASCII.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch
            {
                return "";
            }
        }

        public static string[] getDatabaseInfo()
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
            }
            catch
            {
                throw new Exception("File cấu hình không hợp lệ");
            }
            return retValue;
        }
    
        #endregion

        internal static bool TimeBetween(DateTime datetime, TimeSpan start, TimeSpan end)
        {
            // convert datetime to a TimeSpan
            TimeSpan now = datetime.TimeOfDay;
            // see if start comes before end
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }    

    }



    public class ItemList
    {
        private string mID;
        private string mValue;

        public ItemList(string pID, string pValue)
        {
            mID = pID;
            mValue = pValue;
        }

        public string ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public string Value
        {
            get { return mValue; }
            set { mValue = value; }
        }

        public override string ToString()
        {
            return this.mID != "" ? this.mValue : "";
        }
     
       
        public static void fn_ShowReport_AndImage()
        {

        }
       
    }
}
