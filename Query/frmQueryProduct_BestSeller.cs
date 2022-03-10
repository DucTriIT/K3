using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace GoldRT
{
    public partial class frmQueryProduct_BestSeller : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryProduct_BestSeller()
        {
            InitializeComponent();
        }

        private void frmQueryProduct_BestSeller_Load(object sender, EventArgs e)
        {
            dtpTuNgay.DateTime = DateTime.Now;
            dtpDenNgay.DateTime = DateTime.Now;
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            fn_LoadDataToComboo();
            fn_LoadDataToGrid();
            rdg.SelectedIndexChanged += new EventHandler(rdg_SelectedIndexChanged);
            rdg1.SelectedIndexChanged += new EventHandler(rdg1_SelectedIndexChanged);
            rdg2.SelectedIndexChanged += new EventHandler(rdg2_SelectedIndexChanged);
           // chklb.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(chklb_ItemCheck);
           // chkbl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(chkbl1_ItemCheck);
           // chklb2.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(chklb2_ItemCheck);
            txtSM.EditValueChanged += new EventHandler(txtSM_EditValueChanged);
            txtSMTren.EditValueChanged += new EventHandler(txtSMTren_EditValueChanged);
            txtSMDuoi.EditValueChanged += new EventHandler(txtSMDuoi_EditValueChanged);
            txtTopBot.EditValueChanged += new EventHandler(txtTopBot_EditValueChanged);
           
        }
        private void fn_loaddefault()
        {
            if (rdg.SelectedIndex < 0)
            {
                txtSM.Enabled = false;
                txtSM.Text = string.Empty;
            }
            if (rdg1.SelectedIndex < 0)
            {
                txtTopBot.Enabled = false;
                txtTopBot.Text = string.Empty;
            }
            if (rdg2.SelectedIndex < 0)
            {
                txtSMTren.Enabled = false;
                txtSMTren.Text = string.Empty;
                txtSMDuoi.Enabled = false;
                txtSMDuoi.Text = string.Empty;
            }

        }
        void rdg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdg.SelectedIndex < 0)
                return;
            rdg1.SelectedIndex = -1;
            rdg2.SelectedIndex = -1;
            fn_loaddefault();
            
            txtSM.Enabled = true;
           txtSM.Focus();
        }
        void rdg1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdg1.SelectedIndex<0)
            return;
            rdg.SelectedIndex = -1;
            rdg2.SelectedIndex = -1;
            fn_loaddefault();
            txtTopBot.Enabled = true;
            txtTopBot.Focus();
        }
        void rdg2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdg2.SelectedIndex < 0)
                return;
            rdg.SelectedIndex = -1;
            rdg1.SelectedIndex=-1;
            fn_loaddefault();
            txtSMTren.Enabled = true;
            txtSMDuoi.Enabled = true;
            txtSMTren.Focus();
        }

    //    void chklb2_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
     //   {
     //       if (e.Index ==0)
     //       { txtSMTren.Enabled = (e.State == CheckState.Checked) ? true : false; txtSMTren.Focus(); txtSMDuoi.Enabled = e.State == CheckState.Checked ? true : false; }
    //       
    //    }

       // void chkbl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
     //   {
     //       if (e.Index == 0)
       //     {

        //        txtSM.Enabled = (e.State == CheckState.Checked) ? true : false;
        //        txtSM.Focus();
        //    }
        //
       //     if (e.Index == 1)
         //   { txtTopBot.Enabled = (e.State == CheckState.Checked) ? true : false; txtTopBot.Focus(); }
     //   }

        void txtTopBot_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTopBot.EditValue.ToString()))
            {
                gridDanhsach.ActiveFilterString = "";
                fn_LoadDataToGrid();
                if (rdg1.SelectedIndex == 0)
                    gridDanhsach.Columns["SoMon"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                else gridDanhsach.Columns["SoMon"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                if (rdg1.SelectedIndex == 1)
                {
                    gridDanhsach.ActiveFilterString = "[STT]<=" + decimal.Parse(txtTopBot.EditValue.ToString());
                }
                else
                {

                    int i = gridDanhsach.RowCount;
                    if (i > int.Parse(txtTopBot.EditValue.ToString()))
                    {
                        int j = i - int.Parse(txtTopBot.EditValue.ToString());
                        gridDanhsach.ActiveFilterString = "[STT]>" + j;
                    }
                }
            }


        }

        void txtSMDuoi_EditValueChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSMDuoi.EditValue.ToString()))
            {
            if(!string.IsNullOrEmpty(txtSMTren.Text.Trim()))
                gridDanhsach.ActiveFilterString = "[SoMon]>=" + decimal.Parse(txtSMTren.EditValue.ToString()) + " AND [SoMon]<=" + decimal.Parse(txtSMDuoi.Text.Trim());
            else gridDanhsach.ActiveFilterString = "[SoMon]<=" + decimal.Parse(txtSMDuoi.EditValue.ToString());
             }
        }
        void txtSMTren_EditValueChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSMTren.EditValue.ToString()))
            {
            gridDanhsach.ActiveFilterString = "[SoMon]>=" + decimal.Parse(txtSMTren.Text.Trim());
            if(!string.IsNullOrEmpty(txtSMDuoi.Text.Trim()))
            gridDanhsach.ActiveFilterString = "[SoMon]>=" + decimal.Parse(txtSMTren.Text.Trim())+" And [SoMon]<=" + decimal.Parse(txtSMDuoi.Text.Trim());
            }
        }

        void txtSM_EditValueChanged(object sender, EventArgs e)
        {
            if (rdg.SelectedIndex < 0)
                return;
        if(rdg.SelectedIndex==0)
           gridDanhsach.ActiveFilterString = "[SoMon]>=" + decimal.Parse(txtSM.EditValue.ToString());
        else 
            gridDanhsach.ActiveFilterString = "[SoMon]<=" + decimal.Parse(txtSM.EditValue.ToString());
        }
 
        void chklb_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {

            if (e.Index == 0 )
            {
               
                txtSM.Enabled = (e.State == CheckState.Checked)? true:false;
                txtSM.Focus();
            }
          
              if(e.Index==1)
            { txtTopBot.Enabled = (e.State == CheckState.Checked) ? true : false; txtTopBot.Focus(); }
            
        }
        private void fn_LoadDataToComboo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("I_PRODUCT_GROUP", "");
                Functions.BindDropDownList(cboProductGroup, ds, "GroupName", "GroupID", "", true);
                ds.Clear();

               
            }
            catch
            {
            }
            finally
            {
                ds.Dispose();
            }
        }



        private void gridDanhSach_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            
        }
        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_BestSell_List]", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"), ((ItemList)cboProductGroup.SelectedItem).ID );
                gridControl1.DataSource = ds.Tables[0];
            }
            catch
            { }
            finally { ds.Dispose(); }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void gridDanhsach_CustomColumnDisplayText_1(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
           
        }
        
        private void gridDanhsach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                gridControl.DataSource = null;
                return;
            }
            string s = gridDanhsach.GetFocusedRowCellValue("GroupID").ToString();
            DataSet ds = new DataSet();
            try
            {
                
                ds = clsCommon.ExecuteDatasetSP("[TRN_PRODUCT_BestSell_List]", dtpTuNgay.DateTime.ToString("dd/MM/yyyy"), dtpDenNgay.DateTime.ToString("dd/MM/yyyy"), s.Trim());
                gridControl.DataSource = ds.Tables[1];
            }
            catch { }
            finally
            { ds.Dispose(); }

        }

        private void grdDanhSach_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "STTM")
            {
                if (e.ListSourceRowIndex >= 0)
                {
                    e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
                }
            }
        }

      



        
    }
}