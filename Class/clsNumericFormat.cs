using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;

namespace GoldRT
{
    public class clsNumericFormat
    {
        /// <summary>
        /// Định dạng hiển thị số cho control Numeric
        /// </summary>
        /// <param name="sender">Control phát sinh sự kiện</param>
        /// <param name="e">Giá trị sự kiện</param>
        public static void fn_FormatDisplayNumber(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            //Biến tạm
            string strTemp = null;
            //Nếu là kiểu chuỗi => Gán giá trị cho biến tạm
            if (e.Value is string)
                strTemp = e.Value.ToString();


            try
            {
                //Có bao nhiêu con số lẻ thập phân
                int iDecimal = 0;
                if (e.Value.ToString().IndexOf('.') != -1)
                {
                    string strDecimalNum = e.Value.ToString().Split(new string[] { "." }, StringSplitOptions.None)[1];
                    iDecimal = strDecimalNum.Length;
                    for (int i = strDecimalNum.Length - 1; i >= 0; i--)
                    {
                        if (strDecimalNum[i] == '0')
                            iDecimal--;
                        else
                            break;
                    }
                }

                //Định dạng chuỗi hiển thị của TextEdit
                (sender as TextEdit).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                (sender as TextEdit).Properties.DisplayFormat.FormatString = "n" + iDecimal;
            }
            catch { }

            //Nếu e.Value là kiểu chuỗi => Convert sang Decimal
            if (strTemp != null)
            {
                try
                {
                    e.Value = Convert.ToDecimal(strTemp);
                }
                catch (FormatException)
                {
                    e.Value = 0;
                }
            }
        }
        public static decimal Convert2Decimal(string strValue)
        {
            if (strValue == "")
                return decimal.Zero;
            return Convert.ToDecimal(strValue);
        }

        public static string Convert2Zero(string strValue)
        {
            if (strValue == "")
                return "0";
            return strValue;
        }
        public static string fn_Split(string billCode)
        {
            if (billCode == "")
                return billCode;
            string newCode = "";
            string[] temp = null;
            temp = billCode.Split('-');
            newCode = temp[0] + temp[1] + temp[2] + temp[3].Substring(3, 3);
            return newCode;
        }

        public static string fn_Join(string SplitCode)
        {
            if (SplitCode == "")
                return SplitCode;
            string newCode = "";
            newCode = SplitCode.Insert(2, "-");
            newCode = newCode.Insert(5, "-");
            newCode = newCode.Insert(8, "-000");
            return newCode;
        }
      
    }
}
