using System;
using System.Data;
using System.Windows.Forms;
using Messages;

namespace GoldRT.Query.ucQueryRTTran
{
    public partial class ucFX : UserControl
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

        public ucFX()
        {
            InitializeComponent();
            strBillCode = "";
            strCustName = "";
            strFromDate = "";
            strToDate = "";
        }

        public ucFX(string _BillCode, string _CustName, string _FromDate, string _ToDate)
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
                ds = clsCommon.ExecuteDatasetSP("[TRN_FX_Lst]",
                    "", strFromDate,
                    strToDate,
                    "", "", "", "", "", "", "", "", "0", "", "", "");

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
            f_loadDataToGrid();
        }

        #endregion

    }
}
