using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using Messages;

namespace GoldRT
{
    public partial class frmExportExcel : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dsExcel;

        public frmExportExcel()
        {
            InitializeComponent();
        }        

        public frmExportExcel(DataTable dsExcel)
        {
            InitializeComponent();
            _dsExcel = dsExcel;
        }

        private void frmExportExcel_Load(object sender, System.EventArgs e)
         {
             Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            //fn_LoadDataToCombo();
             this.grdControl.DataSource = this._dsExcel;
         }

        //private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboSection.SelectedIndex > 0)
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            ds = clsCommon.ExecuteDatasetSP("[T_SECTION_Get]", ((ItemList)cboSection.SelectedItem).ID);
        //            ds = clsCommon.LoadComboSP("I_SECTION_GROUP", ((ItemList)cboSection.SelectedItem).ID);
        //            Functions.BindDropDownList(cboGoldCode, ds, "GoldDesc", "GoldCode", "", true);
        //            cboGoldCode.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0]["GoldCode"].ToString(), cboGoldCode, 0);
        //        }
        //        catch { }
        //        finally
        //        {
        //            ds.Clear();
        //            ds = null;
        //        }
        //    }
        //}

        #region Private

        //private void fn_LoadDataToCombo()
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = clsCommon.LoadComboSP("T_SECTION", "");
        //        Functions.BindDropDownList(cboSection, ds, "SectionName", "SectionID", "", true);
        //        ds.Clear();

        //        ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
        //        Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
        //        ds.Clear();
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        ds.Dispose();
        //    }
        //}

        #endregion

        #region Events

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
            if (fileName != "")
            {
                ExportTo(new ExportXlsProvider(fileName));
            }
        }

        #endregion

        #region Privates Export Excel

        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = "ds_hang_xuat";
            dlg.Title = "Export To " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

        private void ExportTo(IExportProvider provider)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.FindForm().Refresh();
            BaseExportLink link = grdDanhsach.CreateExportLink(provider);
            ((GridViewExportLink)link).ExpandAll = false;
            link.Progress += Export_Progress;
            link.ExportTo(true);
            provider.Dispose();
            link.Progress -= Export_Progress;

            Cursor.Current = currentCursor;
            ThongBao.Show("Thông báo", "Xuất file Excel thành công", "OK", ICon.Information);
        }

        private void Export_Progress(object sender, ProgressEventArgs e)
        {
            if (e.Phase == ExportPhase.Link)
            {
                progressBarControl2.Position = e.Position;
                this.Update();
            }
        }

        #endregion          
       
    }
}