using System;
using System.Data;
using System.Windows.Forms;
using Messages;
using DevExpress.XtraGrid;

namespace GoldRT.Query.ucQueryRTTran
{
    public partial class ucCRT : UserControl
    {

        #region "Private Variables"
        string strBillCode;
        string strCustName;
        string strFromDate;
        string strToDate;
        private string strCusID;
        DataSet ds = new DataSet();
        #endregion

        public DataSet DS
        {
            get{return ds;}
            set
            {
                ds = value;
            }
        }

        #region "Public Functions"

        public ucCRT()
        {
            InitializeComponent();
            strBillCode = "";
            strCustName = "";
            strFromDate = "";
            strToDate = "";
        }

        public ucCRT(string _BillCode, string _CustName, string _FromDate, string _ToDate, string _CusID)
        {
            InitializeComponent();
            strBillCode = _BillCode;
            strCustName = _CustName;
            strFromDate = _FromDate;
            strToDate = _ToDate;
            strCusID = _CusID;
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
                ds = clsCommon.ExecuteDatasetSP("TRN_RT_CHANGE_SELL_Lst", "", strBillCode.Trim(), strFromDate, strToDate,
                strCusID, strCustName.Trim(), "", "", "", "0");

                grdDanhSach.DataSource = ds.Tables[0];
                
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
                grvDanhSach.BestFitColumns();
            }
        }
        #endregion

        #region "Event Handlers"

        private void ucCRT_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.Controls);
            f_loadDataToGrid();
            if (clsSystem.IsPayCard)
            {
                this.PayCard.Visible = true;
                this.PayCard.VisibleIndex = 12;
            }
            else { this.PayCard.Visible = false; }
        }

        private void grvDanhSach_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && grvDanhSach.FocusedRowHandle > -1)
            {
                frmRTChange_Dtl frm = new frmRTChange_Dtl(grvDanhSach.GetFocusedRowCellValue("TrnID").ToString());
                frm.ShowDialog();
            }
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

                if (strFieldName.ToUpper() == "PayAmount".ToUpper())
                {
                    for (int i = 0; i < grvDanhSach.RowCount; i++)
                    {
                        if (grvDanhSach.GetRowCellValue(i, "TrnID") != null && strTrnID != grvDanhSach.GetRowCellValue(i, "TrnID").ToString())
                        {
                            strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                            dCalValue += Convert.ToDecimal(grvDanhSach.GetRowCellValue(i, "PayAmount").ToString());
                        }
                    }
                    e.TotalValue = dCalValue;
                }
                if (strFieldName.ToUpper() == "Type".ToUpper())
                {
                    for (int i = 0; i < grvDanhSach.RowCount; i++)
                    {
                        //if (grvDanhSach.GetRowCellValue(i, "TrnID") != null && strTrnID != grvDanhSach.GetRowCellValue(i, "TrnID").ToString())
                        //{
                        if (grvDanhSach.IsDataRow(i))
                        {
                            strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                            if (grvDanhSach.GetRowCellValue(i, "Type").ToString() == "Vàng mới")
                                dCalValue += Convert.ToDecimal(grvDanhSach.GetRowCellValue(i, "GoldWei").ToString());
                        }
                        // }
                    }
                    e.TotalValue = dCalValue;
                }

                if (strFieldName.ToUpper() == "GoldCode".ToUpper())
                {
                    for (int i = 0; i < grvDanhSach.RowCount; i++)
                    {
                        //if (grvDanhSach.GetRowCellValue(i, "TrnID") != null && strTrnID != grvDanhSach.GetRowCellValue(i, "TrnID").ToString())
                        //{
                        if (grvDanhSach.IsDataRow(i))
                        {
                            strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                            if (grvDanhSach.GetRowCellValue(i, "Type").ToString() == "Vàng cũ")
                                dCalValue += Convert.ToDecimal(grvDanhSach.GetRowCellValue(i, "GoldWei").ToString());
                        }
                        // }
                    }
                    e.TotalValue = dCalValue;
                }
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
                if (strFieldName.ToUpper() == "TrnTime".ToUpper())
                {
                    for (int i = 0; i < grvDanhSach.RowCount; i++)
                    {
                        if (grvDanhSach.GetRowCellValue(i, "ProductCode") != null && grvDanhSach.GetRowCellValue(i, "ProductCode").ToString() != "")
                        {
                            //strTrnID = grvDanhSach.GetRowCellValue(i, "TrnID").ToString();
                            dCalValue += decimal.Parse(grvDanhSach.GetRowCellValue(i, "SL").ToString());
                        }
                    }
                    e.TotalValue = dCalValue;
                }
            }            
        }
        
        #endregion

        private void grdDanhSach_Click(object sender, EventArgs e)
        {

        }

    }
}
