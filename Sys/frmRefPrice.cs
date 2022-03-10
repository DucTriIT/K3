using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class frmRefPrice : DevExpress.XtraEditors.XtraForm
    {
        public frmRefPrice()
        {
            InitializeComponent();
        }

        private void frmRefPrice_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("I_XRATE_REF_Lst");
                grdTyGia.DataSource = ds.Tables[0];               
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToGrid: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string strGoldCcys = "";
            string strSellRates = "";
            string strBuyRates = "";
            string strTypes = "";

            for (int i = 0; i < grvTyGia.RowCount; i++)
            {
                DataRow dr = grvTyGia.GetDataRow(i);
                
                if (!fn_CheckValidate(dr)) return;
                if (dr[0].ToString() == "S1" || dr[0].ToString() == "S2")
                {
                    strGoldCcys += dr["GoldCcy"].ToString() + "@";
                    strGoldCcys += "D " + dr["GoldCcy"].ToString() + "@";
                    strSellRates += dr["SellRate"].ToString() + "@";
                    strSellRates += "0" + "@";
                    strBuyRates += "0" + "@";
                    strBuyRates += dr["BuyRate"].ToString() + "@";
                    strTypes += dr["Type"].ToString() + "@";
                    strTypes += "D" + "@";
                }
                else
                {
                    strGoldCcys += dr["GoldCcy"].ToString() + "@";
                    strSellRates += dr["SellRate"].ToString() + "@";
                    strBuyRates += dr["BuyRate"].ToString() + "@";
                    strTypes += dr["Type"].ToString() + "@";
                }
            }           

            strGoldCcys = strGoldCcys.Substring(0, strGoldCcys.Length - 1);
            strSellRates = strSellRates.Substring(0, strSellRates.Length - 1);
            strBuyRates = strBuyRates.Substring(0, strBuyRates.Length - 1);
            strTypes = strTypes.Substring(0, strTypes.Length - 1);

            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[I_XRATE_REF_Ins]",
                    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss"),
                    strGoldCcys, strSellRates, strBuyRates, strTypes);


                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                    return;
                }
                else
                {
                    ThongBao.Show("Lỗi", "Cập nhật không thành công. Vui lòng thử lại", "OK", ICon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                this.Cursor = Cursors.Default;
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private bool fn_CheckValidate(DataRow dr)
        {
            bool p;
            decimal iTemp;

            p = decimal.TryParse(dr["SellRate"].ToString(), out iTemp);

            if (!p)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập Giá bán là kiểu số.", "OK", ICon.Error);
                return false;
            }

            if (iTemp < 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập Giá bán là số lớn hơn 0.", "OK", ICon.Error);
                return false;
            }

            p = decimal.TryParse(dr["BuyRate"].ToString(), out iTemp);
            if (!p)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập Giá mua là kiểu số.", "OK", ICon.Error);
                return false;
            }

            if (iTemp < 0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập Giá mua là số lớn hơn 0.", "OK", ICon.Error);
                return false;
            }

            return true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}