using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GoldRT
{
    public partial class ucPOStatisticPrdt : UserControl
    {
        string _strID = "";

        public ucPOStatisticPrdt(string strDate, DataSet ds, string strID)
        {
            InitializeComponent();
            grdcDanhSach.DataSource = ds.Tables[0];
            _strID = strID;

            //Load thông tin khách hàng
            lblTrnDate.Text = strDate;
            lblCustName.Text = ds.Tables[1].Rows[0]["CustName"].ToString();
            lblAddress.Text = ds.Tables[1].Rows[0]["Address"].ToString();
        }

        private void btnInBangKe_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strParams, strValues;

            strParams = "";
            strValues = "";

            ds = clsCommon.ExecuteDatasetSP("rptBangKeToaHang", _strID);
            Functions.fn_ShowReport(ds, "rptBangKeToaHang.rpt", strParams, strValues);
        }
    }
}
