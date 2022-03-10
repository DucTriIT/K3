using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using System.IO;
using System.Xml;

namespace GoldRT
{
    public partial class frmXRate : DevExpress.XtraEditors.XtraForm
    {
        public frmXRate()
        {
            InitializeComponent();
        }

    #region "Private Functions"

        private void fn_LoadDefault()
        {
            dtpTuNgay.EditValue = DateTime.Now;
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("I_XRATE_Lst");
                grdTyGia.DataSource = ds.Tables[0];
                grdGiaVang.DataSource = ds.Tables[1];
                grdGiaDe.DataSource = ds.Tables[2];
                if(clsSystem.IsHeSo)
                    txtGold95.Text = ds.Tables[3].Rows[0]["SellRate"].ToString();
            }
            catch(Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToGrid: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
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

            //if (iTemp < 0)
            //{
            //    ThongBao.Show("Lỗi", "Vui lòng nhập Giá bán là số lớn hơn 0.", "OK", ICon.Error);
            //    return false;
            //}

            p = decimal.TryParse(dr["BuyRate"].ToString(), out iTemp);
            if (!p)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập Giá mua là kiểu số.", "OK", ICon.Error);
                return false;
            }

            //if (iTemp < 0)
            //{
            //    ThongBao.Show("Lỗi", "Vui lòng nhập Giá mua là số lớn hơn 0.", "OK", ICon.Error);
            //    return false;
            //}

            return true;
        }

    #endregion

    #region "Event Handlers"

        private void frmXRate_Load(object sender, EventArgs e)
        {
            fn_LoadDefault();
            fn_LoadDataToGrid();
            if(!clsSystem.IsShowLCD)
                btnBangGia.Dispose();
            if (!clsSystem.IsHeSo)
            {
                txtGold95.Dispose();
                btnCNGia.Dispose();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (clsSystem.IsHeSo)
            {
                btnCNGia_Click(sender, null);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            string strGoldCcys = "";
            string strSellRates = "";
            string strBuyRates = "";
            string strTypes = "";

            for (int i = 0; i < grvTyGia.RowCount; i++)
            {
                DataRow dr = grvTyGia.GetDataRow(i);

                if (!fn_CheckValidate(dr)) return;

                strGoldCcys += dr["GoldCcy"].ToString() + "@";
                strSellRates += dr["SellRate"].ToString() + "@";
                strBuyRates += dr["BuyRate"].ToString() + "@";
                strTypes += dr["Type"].ToString() + "@";
            }

            for (int i = 0; i < grvGiaVang.RowCount; i++)
            {
                DataRow dr = grvGiaVang.GetDataRow(i);

                if (!fn_CheckValidate(dr)) return;

                strGoldCcys += dr["GoldCcy"].ToString() + "@";
                strSellRates += dr["SellRate"].ToString() + "@";
                strBuyRates += dr["BuyRate"].ToString() + "@";
                strTypes += dr["Type"].ToString() + "@";
            }

            for (int i = 0; i < grvGiaDe.RowCount; i++)
            {
                DataRow dr = grvGiaDe.GetDataRow(i);

                if (!fn_CheckValidate(dr)) return;

                strGoldCcys += dr["GoldCcy"].ToString() + "@";
                strSellRates += dr["SellRate"].ToString() + "@";
                strBuyRates += dr["BuyRate"].ToString() + "@";
                strTypes += dr["Type"].ToString() + "@";
            }


            strGoldCcys = strGoldCcys.Substring(0, strGoldCcys.Length - 1);
            strSellRates = strSellRates.Substring(0, strSellRates.Length - 1);
            strBuyRates = strBuyRates.Substring(0, strBuyRates.Length - 1);
            strTypes = strTypes.Substring(0, strTypes.Length - 1);

            DataSet ds = new DataSet();
            try
            {

                ds = clsCommon.ExecuteDatasetSP("[I_XRATE_Ins]",
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
    #endregion

        private void btnShow_Click(object sender, EventArgs e)
        {

            CommunicationManager comm = new CommunicationManager();
            string transType = string.Empty;

            string DuongDan = Application.StartupPath + "\\configBangDienTu.xml"; //Đường dẫn file cấu hình
            string FileName = DuongDan;
            string G;
            if (!File.Exists(FileName))
                throw new Exception("Không tìm thấy file cấu hình");

            try
            {
 

                //Đọc dữ liệu từ file cấu hình
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);



                comm.PortName = Functions.fn_GetXMLNodeValue(xmlDoc, "PortName");
                comm.BaudRate = Functions.fn_GetXMLNodeValue(xmlDoc, "BitPerSecond");
                comm.DataBits = Functions.fn_GetXMLNodeValue(xmlDoc, "DataBit");
                comm.Parity = Functions.fn_GetXMLNodeValue(xmlDoc, "Parity");
                comm.StopBits = Functions.fn_GetXMLNodeValue(xmlDoc, "StopBit");
                G = Functions.fn_GetXMLNodeValue(xmlDoc, "Gold");
              
              
               
            }
            catch
            {
                throw new Exception("File cấu hình không hợp lệ");
            }            
            comm.OpenPort();

            
            string[] rG = G.Split('@');
            decimal[] dG = new decimal[rG.Length];

            string x1, x2, x3, x4;

            DataRow rowXRate = Functions.fn_GetXRate(rG[0].ToString());
            decimal dCcyXRate1 = decimal.Parse(rowXRate["BuyRate"].ToString());

            rowXRate = Functions.fn_GetXRate(rG[1].ToString());
            decimal dCcyXRate2 = decimal.Parse(rowXRate["SellRate"].ToString());

            rowXRate = Functions.fn_GetXRate(rG[2].ToString());
            decimal dCcyXRate3 = decimal.Parse(rowXRate["BuyRate"].ToString());

            rowXRate = Functions.fn_GetXRate(rG[3].ToString());
            decimal dCcyXRate4 = decimal.Parse(rowXRate["SellRate"].ToString());
            x1=string.Format("{0:00000}",dCcyXRate1*10);
            x2 = string.Format("{0:00000}", dCcyXRate2 * 10);
            x3 = string.Format("{0:00000}", dCcyXRate3 * 10);
            x4 = string.Format("{0:00000}", dCcyXRate4 * 10);

            comm.WriteData(x1, x3, x2, x4);
            comm.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmBangGia frm = new frmBangGia();
            frm.Size = SystemInformation.WorkingArea.Size;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnCNGia_Click(object sender, EventArgs e)
        {
            if (txtGold95.Text == "" || txtGold95.Text == "0")
            {
                ThongBao.Show("Thông báo", "Bạn vui lòng nhập giá 95%", "OK", ICon.Warning);
                return;
            }
            if(ThongBao.Show("Thông báo", "Bạn có chắc muốn cập nhật giá không?", "Có", "Không", ICon.QuestionMark) == DialogResult.Cancel)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            string strGoldCcys = "";           
            string strTypes = "";
            string strSellRates = "";

            for (int i = 0; i < grvTyGia.RowCount; i++)
            {
                DataRow dr = grvTyGia.GetDataRow(i);

                if (!fn_CheckValidate(dr)) return;

                strGoldCcys += dr["GoldCcy"].ToString() + "@";
                strSellRates += dr["SellRate"].ToString() + "@";
                strTypes += dr["Type"].ToString() + "@";
            }

            for (int i = 0; i < grvGiaVang.RowCount; i++)
            {
                DataRow dr = grvGiaVang.GetDataRow(i);

                if (!fn_CheckValidate(dr)) return;

                strGoldCcys += dr["GoldCcy"].ToString() + "@";               
                strTypes += dr["Type"].ToString() + "@";
                strSellRates += dr["SellRate"].ToString() + "@";
            }

            for (int i = 0; i < grvGiaDe.RowCount; i++)
            {
                DataRow dr = grvGiaDe.GetDataRow(i);

                //if (!fn_CheckValidate(dr)) return;

                strGoldCcys += dr["GoldCcy"].ToString() + "@";               
                strTypes += dr["Type"].ToString() + "@";
                strSellRates += dr["SellRate"].ToString() + "@";
            }


            strGoldCcys = strGoldCcys.Substring(0, strGoldCcys.Length - 1);         
            strTypes = strTypes.Substring(0, strTypes.Length - 1);
            strSellRates = strSellRates.Substring(0, strSellRates.Length - 1);

            DataSet ds = new DataSet();
            
            try
            {
                DataSet ds1 = new DataSet();
                ds1 = clsCommon.ExecuteDatasetSP("[I_XRATE_95]", txtGold95.Text);
                if (ds1.Tables[0].Rows[0]["Result"].ToString() == "-1")
                {
                    ThongBao.Show("Lỗi", "Có lỗi trong quá trình cập nhật. Vui lòng thử lại", "OK", ICon.Error);
                    return;
                }

                ds = clsCommon.ExecuteDatasetSP("[I_XRATE_Cal]",
                    strGoldCcys, strTypes, strSellRates);


                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                    fn_LoadDataToGrid();
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

        private void txtGold95_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
                btnCNGia_Click(sender, null);
        }       

    }
}