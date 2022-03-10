using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using DevExpress.XtraLayout;

namespace GoldRT
{
    public partial class frmPOStatistic : DevExpress.XtraEditors.XtraForm
    {
        public frmPOStatistic()
        {
            InitializeComponent();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.LoadComboSP("I_CUSTOMER", "NOTWALKINCUST");
                Functions.BindDropDownList(cboCust, ds, "CustInfo", "CustID", "", true);
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

        private void fn_LoadDataToTreeView()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[TRN_PO_PRODUCT_TreeLst]", ((ItemList)cboCust.SelectedItem).ID);
                tvTrnLst.DataSource = ds.Tables[0];
            }
            catch { }
            finally
            {
                ds.Dispose();
            }
        }

        private void frmPOStatistic_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            fn_LoadDataToTreeView();
        }

        private void tvTrnLst_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tvTrnLst_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (!e.Node.HasChildren && e.Node != e.OldNode)
            {
                this.Cursor = Cursors.WaitCursor;

                DataSet ds = new DataSet();
                string strID = e.Node.GetValue("NodeID").ToString();
                if (strID.IndexOf('@') == 0) //Bảng kê thanh toán
                {
                    strID = strID.Substring(1);
                    ds = clsCommon.ExecuteDatasetSP("[TRN_PO_STATISTIC_Payment]", ((ItemList)cboCust.SelectedItem).ID, strID);

                    layoutRight.Root.Clear();
                    ucPOStatisticLst ctrl = new ucPOStatisticLst(e.Node.ParentNode.GetDisplayText("DisplayField").ToString(), ds);
                    LayoutControlItem item = layoutRight.Root.AddItem("zbc", ctrl);
                    item.TextVisible = false;
                }
                else
                {
                    ds = clsCommon.ExecuteDatasetSP("[rptBangKeToaHang]", strID);
                    layoutRight.Root.Clear();
                    ucPOStatisticPrdt ctrl = new ucPOStatisticPrdt(e.Node.ParentNode.GetDisplayText("DisplayField").ToString(), ds, strID);
                    LayoutControlItem item = layoutRight.Root.AddItem("zbc", ctrl);
                    item.TextVisible = false;
                }

                this.Cursor = Cursors.Default;
            }
        }


    }
}