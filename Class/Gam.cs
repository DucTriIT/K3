using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


public class Gam    
{
    private static string ParseMoney1(string _digit, int _position)
    {

        switch (_digit)
        {
            case "1": return "một ";
            case "2": return "hai ";
            case "3": return "ba ";
            case "4": return "bốn ";
            case "5": return "năm ";
            case "6": return "sáu ";
            case "7": return "bảy ";
            case "8": return "tám ";
            case "9": return "chín ";
            case "10": return "mười ";           
        }
        return string.Empty;
    }

    private static string ParseMoney2(int _len)
    {
        switch (_len)
        {
            case 1: return "mươi ";
            case 2: return "trăm ";
            case 3: return "nghìn ";
            case 6: return "triệu ";
            case 9: return "tỉ ";           
        }
        return string.Empty;
    }

    private static string Analize(string _moneyTemp)
    {
        string _strReturn = string.Empty;
        string _temp = string.Empty;
        while (_moneyTemp != string.Empty)
        {
            _temp = _moneyTemp.Substring(0, 3);
            _moneyTemp = _moneyTemp.Remove(0, 3);

            string _t = _temp;
            //string _t = Convert.ToInt32(_temp).ToString();
            for (int i = 0; i < _temp.Length; i++)
            {

                if (i == 1 && Convert.ToInt32(_t.Substring(1, 2)) / 10 == 1)
                {
                    _strReturn += "mười ";
                }
                else
                {
                    if (i == 2 && _t[2] == '1' && Convert.ToInt32(_t.Substring(1, 2)) / 10 >= 2)
                        _strReturn += "mốt";
                    else
                    {
                        if (_t[i] != '0' && i == 2 && _t[1] == '0' && _strReturn != string.Empty)
                            _strReturn += "lẻ ";
                        if (i == 2 && _t[1] != '0' && _t[2] == '5' && _strReturn != string.Empty)
                        {
                            _strReturn += "lăm ";
                        }
                        else
                            _strReturn += ParseMoney1(_t[i].ToString(), i);

                        if (_t[i] != '0')
                            _strReturn += ParseMoney2(_t.Length - i - 1);

                    }

                }

            }
            if (Convert.ToInt32(_temp) != 0)
                _strReturn += ParseMoney2(_moneyTemp.Length);
        }
        return _strReturn;
    }

    public static string process(string _moneyTemp)
    {
        string _strReturn = string.Empty;
        string __strReturn2 = string.Empty;
        string _bilionGroup = string.Empty;
        string _milionGroup = string.Empty;
        string _temp = string.Empty;
        string _temp1 = string.Empty; 
        string _temp2 = string.Empty;
        string _temp3 = string.Empty;
        string _temp4 = string.Empty;   
   

        _temp4 = _moneyTemp; // gán _temp4 = _moneyTemp để giữ số thập phân

        try { _temp1 = _moneyTemp.Substring(0, _moneyTemp.IndexOf(".")); } //temp1: lấy phần nguyên
        catch { _temp1 = ""; } // nếu _moneyTemp không phải số thập phân thì gán temp1 = "" 

        if (_temp1 != "")
            _temp2 = _temp1;
        else
            _temp2 = _moneyTemp;
        while (_temp2.Length % 3 != 0)
        {
            _temp2 = "0" + _temp2;
        }
        if (_temp2.Length > 9)
        {
            _bilionGroup = _temp2.Substring(0, _temp2.Length - 9);
            _strReturn += Analize(_bilionGroup);
            _strReturn += "tỷ ";
        }
        _milionGroup = _temp2.Substring(_bilionGroup.Length);
        _strReturn += Analize(_milionGroup);

      
        if (_temp1 != "") //nếu temp1 != "" --> số _moneyTemp là số thập phân --> thao tác
        {
            if (decimal.Parse(_temp4.Substring(_temp4.IndexOf(".") + 1)) > 0)
            {
                string _temp6 = _temp4.Substring(_temp4.IndexOf(".") + 1);
                while (_temp6.Length % 3 != 0)
                {
                    _temp6 = "0" + _temp6;
                }
                __strReturn2 += Analize(_temp6);
            }
        }
        if (__strReturn2.Length > 0)
        {
            if(_strReturn.Length >0)
                return _strReturn + "Chấm " + __strReturn2;
            return "Không Chấm " + __strReturn2;
        }
        return _strReturn;
    }
}




