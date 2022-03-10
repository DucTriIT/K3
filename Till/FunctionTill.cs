using System;
using System.Data;
using Messages;

namespace GoldRT
{
    internal class FunctionTill
    {
        public static void fn_CloseTill()
        {
            DataSet ds = new DataSet();
            try
            {
                if (clsSystem.TillCode != "")
                {
                    ds = clsCommon.ExecuteDatasetSP("T_TILL_Close", clsSystem.TillID, clsSystem.UserID);

                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        clsSystem.TillID = "";
                        clsSystem.TillCode = "";

                    }
                    ds.Clear();
                }
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm fn_CloseTill: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }
        public static string fn_TillProccessTxn(string strIDs)
        {
            string strErrorCode = "";
            if (clsSystem.TillID == "")
            {                
                ThongBao.Show("Lỗi", "Không thể thực hiện giao dịch thu ngân.\nDo bạn chưa mở Quầy thu ngân.", "OK", ICon.Error);                
                return strErrorCode;
            }

            /// Thực hiện luôn nút Đồng ý thanh toán
            DataSet ds = new DataSet();
            string strTillID;            
            try
            {
                strTillID = clsSystem.TillID;

                if (strIDs != "")
                {
                    ds = clsCommon.ExecuteDatasetSP("T_TILL_TXN_Proc", strIDs, strTillID, clsSystem.UserID);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        strErrorCode = ds.Tables[0].Rows[0]["Result"].ToString();
                        if (strErrorCode != "0")
                        {
                            ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString() + " [" + ds.Tables[0].Rows[0]["ErrorCode"].ToString() + "]", "OK", ICon.Error);
                           
                        }
                        else
                        {
                            ThongBao.Show("Thông báo", "Thanh toán thành công", "OK", ICon.Information);                            
                            //fn_LoadDataToGrid();
                        }
                    }

                }
                else
                {
                    ThongBao.Show("Thông báo", "Vui lòng chọn giao dịch cần thanh toán.", "OK", ICon.Warning);                   
                }
                return strErrorCode;
            }
            catch (Exception ex)
            {
                ds.Dispose();                
                ThongBao.Show("Lỗi", "Hàm btnProcess_Click: " + ex.Message, "OK", ICon.Error);
                return strErrorCode;
            }
            finally
            {
                //fn_LoadDataToGrid();
                ds.Dispose();
               
            }
        }
    }
}
