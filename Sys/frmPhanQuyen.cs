using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils;
using DevExpress.XtraBars;
using Messages;

namespace GoldRT
{
    public partial class frmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        frmMain frmMain;
        
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        public frmPhanQuyen(frmMain frm)
        {
            InitializeComponent();

            frmMain = frm;
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("SYS_GROUPS", null);
            Functions.BindDropDownList(cboGroup, ds, "GroupName", "GroupID", "", false);
            ds.Clear();
            ds.Dispose();
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            fn_LoadDataToCombo();
            fn_LoadDataToTreeView();
        }



        private void tvMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeListHitInfo hInfo = tvMenu.CalcHitInfo(new Point(e.X, e.Y));
                if (hInfo.HitInfoType == HitInfoType.StateImage)
                    SetCheckedNode(hInfo.Node);
            }
        }
        private void SetCheckedNode(TreeListNode node)
        {

            CheckState check = CheckState.Unchecked;
            switch (node.GetValue("Check").ToString())
            {
                case "Unchecked":
                    check = CheckState.Unchecked;
                    break;
                case "Checked":
                    check = CheckState.Checked;
                    break;
                case "Indeterminate":
                    check = CheckState.Indeterminate;
                    break;
            }  
            if (check == CheckState.Indeterminate || check == CheckState.Unchecked) check = CheckState.Checked;
            else check = CheckState.Unchecked;
            tvMenu.FocusedNode = node;
            tvMenu.BeginUpdate();
            node["Check"] = check;
            //StatusBarDisplayText(tvMenu.FocusedNode);
            SetCheckedChildNodes(node, check);
            SetCheckedParentNodes(node, check);
            tvMenu.EndUpdate();
        }

        private void tvMenu_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            CheckState check = CheckState.Unchecked;

            switch (e.Node.GetValue("Check").ToString())
            { 
                case "Unchecked":
                    check = CheckState.Unchecked;
                    break;
                case "Checked":
                    check = CheckState.Checked;
                    break;
                case "Indeterminate":
                    check = CheckState.Indeterminate;
                    break;
            }       
            if (check == CheckState.Unchecked)
                e.NodeImageIndex = 0;
            else if (check == CheckState.Checked)
                e.NodeImageIndex = 1;
            else e.NodeImageIndex = 2;
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i]["Check"] = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    if (!(check.ToString() == node.ParentNode.Nodes[i]["Check"].ToString()))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode["Check"] = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            fn_LoadDataToTreeView();
        }


        private void fn_LoadDataToTreeView()
        {
            DataSet ds = new DataSet();            
            string strGroupID = cboGroup.SelectedItem != null ? ((ItemList)cboGroup.SelectedItem).ID : "";

            this.Cursor = Cursors.WaitCursor;

            try 
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_MENUS_LstAll]", strGroupID);

                tvMenu.DataSource = ds.Tables[0];
                tvMenu.ExpandAll();
            }
            catch (Exception ex) 
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally 
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private string fn_getAllNodes(TreeListNode node)
        {
            string strResult = "";
            
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                if (node.Nodes[i]["Check"].ToString() != "Unchecked")
                {
                    strResult += node.Nodes[i]["MenuID"].ToString() + "@" + fn_getAllNodes(node.Nodes[i]);
                }
                //fn_getAllNodes(node.Nodes[i]);
            }
            return strResult;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string strMenuID = "", strGroupID = "";
            DataSet ds = new DataSet(); 

            this.Cursor = Cursors.WaitCursor;

            try
            {
                strGroupID = ((ItemList)cboGroup.SelectedItem).ID;
                for (int i = 0; i < tvMenu.Nodes.Count; i++)
                {
                    if (tvMenu.Nodes[i]["Check"].ToString() != "Unchecked")
                    {
                        strMenuID += tvMenu.Nodes[i]["MenuID"] + "@" + fn_getAllNodes(tvMenu.Nodes[i]);
                    }
                }

                ds = clsCommon.ExecuteDatasetSP("[SYS_MENUS_UpdByGroupID]",strGroupID, strMenuID,"", null);

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Cập nhật thành công", "OK", ICon.Information);
                }
                else
                {
                    ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["ErrorDesc"].ToString(), "OK", ICon.Error);
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnUpdateMenu_Click(object sender, EventArgs e)
        {

        }
    }
}