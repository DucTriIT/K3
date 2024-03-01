using System;
using System.Data;
using System.Windows.Forms;
using Messages;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
namespace GoldRT.Query.ucQueryRTTran
{
    public partial class ucSRT : UserControl
    {

        #region "Private Variables"
        private static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string strBillCode;
        string strCustName;
        string strFromDate;
        string strToDate;
        DataSet ds = new DataSet();
        decimal tt=0;
        #endregion

        #region Properties

        public DataSet DS
        {
            get { return ds; }
            set
            {
                ds = value;
            }
        }
        public decimal TT
        {
            get { return tt; }
            set { tt = value; }
        }

        #endregion

        #region "Public Functions"

        public ucSRT()
        {
            InitializeComponent();
            strBillCode = "";
            strCustName = "";
            strFromDate = "";
            strToDate = "";
        }

        public ucSRT(string _BillCode, string _CustName, string _FromDate, string _ToDate)
        {
            InitializeComponent();
            strBillCode = _BillCode;
            strCustName = _CustName;
            strFromDate = _FromDate;
            strToDate = _ToDate;
        }

        public void fnShowHour(bool isShow)
        {
            this.TrnTime.Visible = isShow;
            f_loadDataToGrid();
        }

        #endregion

        #region "Private Functions"

        private void f_loadDataToGrid()
        {          
            try
            {
                ds = clsCommon.ExecuteDatasetSP("TRN_RT_BUYSELL_SELL_Lst", "", strBillCode, strFromDate, strToDate,
                strCustName.Trim(), "", "", "", "0");

                grdDanhSach.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                grvDanhSach.BestFitColumns();
                ds.Dispose();
            }
        }

        #endregion

        #region "Event Handlers"
       
        private void ucCRT_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            f_loadDataToGrid();
            //if (clsSystem.IsPayCard)
            //{
            //    this.PayCard.Visible = true;
            //    this.PayCard.VisibleIndex = 13;
            //}
            //else { this.PayCard.Visible = false; }
        }

        private void grvDanhSach_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && e.Clicks == 2 && grvDanhSach.FocusedRowHandle > -1)
            //{
            //    frmRTBuySell_Dtl frm = new frmRTBuySell_Dtl(grvDanhSach.GetFocusedRowCellValue("TrnID").ToString());
            //    frm.ShowDialog();
            //}
        }
     
        private void grdDanhSach_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            decimal dCalValue = decimal.Zero;
            string strTrnID = "";
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                string strFieldName = ((GridSummaryItem)e.Item).FieldName;

                if (strFieldName.ToUpper() == "Discount".ToUpper())
                {
                    for (int i = 0; i < grvDanhSach.RowCount; i++)
                    {
                        if (grvDanhSach.GetRowCellValue(i, "TrnID") != null && strTrnID != grvDanhSach.GetRowCellValue(i, "TrnID").ToString())
                        {
                            strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                            dCalValue += Convert.ToDecimal(grvDanhSach.GetRowCellValue(i, "Discount").ToString());
                        }
                    }
                    e.TotalValue = dCalValue;
                }
                if (strFieldName.ToUpper() == "TG".ToUpper())
                {
                    for (int i = 0; i < grvDanhSach.RowCount; i++)
                    {
                        if (grvDanhSach.GetRowCellValue(i, "TrnID") != null && strTrnID != grvDanhSach.GetRowCellValue(i, "TrnID").ToString())
                        {
                            strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                            dCalValue += Convert.ToDecimal(grvDanhSach.GetRowCellValue(i, "TG").ToString());
                        }
                    }
                    e.TotalValue = dCalValue;
                }

                if (strFieldName.ToUpper() == "Amount".ToUpper())
                {
                    for (int i = 0; i < grvDanhSach.RowCount; i++)
                    {
                        if (grvDanhSach.GetRowCellValue(i, "TrnID") != null && strTrnID != grvDanhSach.GetRowCellValue(i, "TrnID").ToString())
                        {
                            strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                            dCalValue += Convert.ToDecimal(grvDanhSach.GetRowCellValue(i, "Amount").ToString());
                        }
                    }
                    e.TotalValue = dCalValue;
                    tt = dCalValue;
                }
                //if (strFieldName.ToUpper() == "TYPE".ToUpper())
                //{
                //    for (int i = 0; i < grvDanhSach.RowCount; i++)
                //    {
                //        //if (grvDanhSach.GetRowCellValue(i, "TrnID") != null && strTrnID != grvDanhSach.GetRowCellValue(i, "TrnID").ToString())
                //        //{
                //        if (grvDanhSach.IsDataRow(i))
                //        {
                //            strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                //            if (grvDanhSach.GetRowCellValue(i, "TYPE").ToString() == "Vàng bán")
                //                dCalValue += Convert.ToDecimal(grvDanhSach.GetRowCellValue(i, "GoldWei").ToString());
                //        }
                //        // }
                //    }
                //    e.TotalValue = dCalValue;
                //}

                //if (strFieldName.ToUpper() == "GoldCode".ToUpper())
                //{
                //    for (int i = 0; i < grvDanhSach.RowCount; i++)
                //    {
                //        //if (grvDanhSach.GetRowCellValue(i, "TrnID") != null && strTrnID != grvDanhSach.GetRowCellValue(i, "TrnID").ToString())
                //        //{
                //        if (grvDanhSach.IsDataRow(i))
                //        {
                //            strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                //            if (grvDanhSach.GetRowCellValue(i, "TYPE").ToString() == "Vàng mua")
                //                dCalValue += Convert.ToDecimal(grvDanhSach.GetRowCellValue(i, "GoldWei").ToString());
                //        }
                //        // }
                //    }
                //    e.TotalValue = dCalValue;
                //}

                if (strFieldName.ToUpper() == "TrnDate".ToUpper())
                {
                    for (int i = 0; i < grvDanhSach.RowCount; i++)
                    {
                        if (grvDanhSach.GetRowCellValue(i, "TrnID") != null && strTrnID != grvDanhSach.GetRowCellValue(i, "TrnID").ToString())
                        {
                            strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                            dCalValue += 1;
                        }
                    }
                    e.TotalValue = dCalValue;
                }
                if (strFieldName.ToUpper() == "SellAmount".ToUpper())
                {
                    for (int i = 0; i < grvDanhSach.RowCount; i++)
                    {
                        if (grvDanhSach.IsDataRow(i))                      
                        {
                            //strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                            dCalValue += decimal.Parse(grvDanhSach.GetRowCellValue(i, "SellAmount").ToString());
                        }
                    }
                    e.TotalValue = dCalValue;
                }
            }
        }

        #endregion       

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string id = grvDanhSach.GetFocusedDataRow()["TrnID"].ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    DataSet ds = clsCommon.ExecuteDatasetSP("[rptSRT_PrintBill]", id);
                    Functions.fn_ShowReport_CloseAfterPrint(ds, "InBillThanhToan.rdlc", "", "",false);
                }

            }
            catch(Exception ex)
            {
                log.Error(ex.ToString(), ex);
            }
        }

    }
}
