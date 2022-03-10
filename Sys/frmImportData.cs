using System;

namespace GoldRT
{
    public partial class frmImportData : DevExpress.XtraEditors.XtraForm
    {
        public frmImportData()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importDataToExcel1_DataSetExport(object sender, GoldRT.Query.ucQueryRTTran.ImportDataToExcel.DataSetExportEventArgs e)
        {

        }
    }
}