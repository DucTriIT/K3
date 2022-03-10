using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Messages;

namespace GoldRT.Query.ucQueryRTTran
{
    public partial class ucBRT : UserControl
    {
        
        #region "Private Variables"
        string strBillCode;
        string strCustName;
        string strFromDate;
        string strToDate;
        DataSet ds = new DataSet();
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

        #endregion

        #region "Public Functions"
        public ucBRT()
        {
            InitializeComponent();
            strBillCode = "";
            strCustName = "";
            strFromDate = "";
            strToDate = "";
        }

        public ucBRT(string _BillCode, string _CustName, string _FromDate, string _ToDate)
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
                ds = clsCommon.ExecuteDatasetSP("[TRN_RT_BUYGOLD_Lst]", "",
                        strFromDate,
                        strToDate,
                        "", "", "", "", "0", "", "");

                grdDanhSach.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
            }
        }

        #endregion

        #region "Event Handlers"
        private void ucCRT_Load(object sender, EventArgs e)
        {
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            f_loadDataToGrid();
        }

        private void grvDanhSach_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    frmRTChange frm = new frmRTChange();
            //    frm.ShowDialog();
            //    if (grvDanhSach.FocusedRowHandle > -1)
            //        frm.fn_LoadDataToForm(grvDanhSach.GetFocusedRowCellValue("TrnID").ToString());
            //}
        }
        #endregion

    }
}
