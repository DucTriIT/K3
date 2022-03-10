using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GoldRT
{
    public partial class ucPOStatisticLst : UserControl
    {
        private string strID = "";

        public ucPOStatisticLst(string strDate, DataSet ds)
        {
            InitializeComponent();

            try
            {
                //Load thông tin khách hàng
                lblTrnDate.Text = strDate;
                lblCustName.Text = ds.Tables[0].Rows[0]["CustName"].ToString();
                lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                grdcGoldPO.DataSource = ds.Tables[1];
                grdcPrdtPO.DataSource = ds.Tables[2];

                //Load thông tin bảng kê thanh toán
                strID = ds.Tables[3].Rows[0]["POID"].ToString();
                lblOld_TaskPrice.Text = ds.Tables[3].Rows[0]["Old_TaskPrice"].ToString();
                lblTotal_TaskPrice.Text = ds.Tables[3].Rows[0]["Total_TaskPrice"].ToString();
                lblNew_TaskPrice.Text = ds.Tables[3].Rows[0]["New_TaskPrice"].ToString();
                lblTrn_PayAmount.Text = ds.Tables[3].Rows[0]["Trn_PayAmount"].ToString();
                lblRemain_Amount.Text = ds.Tables[3].Rows[0]["Remain_Amount"].ToString();

                grdcPayment.DataSource = ds.Tables[4];
                grdcDebt.DataSource = ds.Tables[5];

                lblTaskDebt.Text = ds.Tables[6].Rows[0]["Debt_Bal"].ToString();
            }
            catch { }
        }

        private void btnInBangKe_Click(object sender, EventArgs e)
        {
        //    DataSet ds = new DataSet();
        //    string strParams, strValues;
        //    double dTotal = 0;

        //    //strParams = "TuNgay@DenNgay";
        //    //strValues = strFromDate;
        //    //strValues += "@" + strToDate;

        //    ds = clsCommon.ExecuteDatasetSP("rptBangKeThanhToan", strID);
        //    dTotal = Math.Abs(double.Parse(ds.Tables[5].Rows[0]["TotalPaymentAmt"].ToString()));
        //    strParams = "ThanhTien";
        //    strValues = Gam.process(dTotal.ToString()).ToUpper() + "ĐỒNG";

        //    Functions.fn_ShowReport(ds, "rptBangKeThanhToan.rpt", strParams, strValues);
        
        
          DataSet ds = new DataSet();
            string strParams = "", strValues = "", ThuChi = "";
            double dTotal = 0, dTongGiao = 0, dPayAmount = 0, dTotalPhatsinh = 0, dTongket = 0;

            ds = clsCommon.ExecuteDatasetSP("rptBangKeThanhToan_Rutgon", strID);
            dTongket = 0;
           
            dTotal = Math.Abs(double.Parse(ds.Tables[11].Rows[ds.Tables[11].Rows.Count - 1]["TotalPaymentAmt"].ToString()));
            dTongGiao = Math.Abs(double.Parse(ds.Tables[11].Rows[ds.Tables[11].Rows.Count - 1]["TotalGoldWeight"].ToString()));
            strParams = "ThanhTien@TongGiao@dPayAmount@dTotalPhatsinh@TongketThuChi@ThuChi";
            strValues = VND.process(dTotal.ToString()).ToUpper() + "ĐỒNG@" + dTongGiao.ToString() + "@" + dPayAmount + "@" + dTotalPhatsinh + "@" + dTongket + "@" + ThuChi;

            Functions.fn_ShowReport(ds, "rptBangKeThanhToan_Rg.rpt", strParams, strValues);
        }
    }
}
