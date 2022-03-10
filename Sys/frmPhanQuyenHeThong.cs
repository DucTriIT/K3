using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Messages;

namespace GoldRT
{
    public partial class frmPhanQuyenHeThong : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyenHeThong()
        {
            InitializeComponent();
        }
       
        private void frmPhanQuyenHeThong_Load(object sender, EventArgs e)
        {
            fn_LoadDataToTreeView();
            fn_LoadDataToCombo();
            fn_LoadValue();
        }

        private void fn_LoadValue()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_FUNCTION_lst]");
                cboTill.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[0][1].ToString(), cboTill, 0);
                chkTem.Checked = ds.Tables[0].Rows[1][1].ToString() == "1" ? true : false;
                chkHot.Checked = ds.Tables[0].Rows[2][1].ToString() == "1" ? true : false;
                chkShowLCD.Checked = ds.Tables[0].Rows[3][1].ToString() == "1" ? true : false;
                chkPOTaskPrice.Checked = ds.Tables[0].Rows[4][1].ToString() == "1" ? true : false;
                chkTaskPriceChange.Checked = ds.Tables[0].Rows[5][1].ToString() == "1" ? true : false;
                cboUnit.SelectedIndex = Functions.GetSelectedIndexCombo(ds.Tables[0].Rows[6][1].ToString(), cboUnit, 0);
                chkSMS.Checked = ds.Tables[0].Rows[7][1].ToString() == "1" ? true : false;
                ChkAllowPayCard.Checked = ds.Tables[0].Rows[8][1].ToString() == "1" ? true : false;
                chkScan.Checked = ds.Tables[0].Rows[9][1].ToString() == "1" ? true : false;
                chkHeSo.Checked = ds.Tables[0].Rows[10][1].ToString() == "1" ? true : false;
                chkDoiTra.Checked = ds.Tables[0].Rows[11][1].ToString() == "1" ? true : false;
                chkCatGia.Checked = ds.Tables[0].Rows[12][1].ToString() == "1" ? true : false;
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToCombo: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_LOADCOMBO]", "T_TILL", "");
                Functions.BindDropDownList(cboTill, ds, "TillName", "TillID", "", true);
                ds.Clear();
                cboUnit.Properties.Items.Add(new ItemList("Z", "Zem"));
                cboUnit.Properties.Items.Add(new ItemList("Ly", "Ly"));
                cboUnit.Properties.Items.Add(new ItemList("P", "Phân"));
                cboUnit.Properties.Items.Add(new ItemList("C", "Chỉ"));
                cboUnit.Properties.Items.Add(new ItemList("L", "Lượng"));
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToCombo: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

        private void fn_LoadDataToTreeView()
        {
            DataSet ds = new DataSet();
            //string strGroupID = cboGroup.SelectedItem != null ? ((ItemList)cboGroup.SelectedItem).ID : "";

            this.Cursor = Cursors.WaitCursor;

            try
            {
                ds = clsCommon.ExecuteDatasetSP("[SYS_MENUS_LstAll]","");

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

        private void tvMenu_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            CheckState check = CheckState.Unchecked;

            switch (e.Node.GetValue("Check").ToString())
            {
                case "UnChecked":
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
                case "UnChecked":
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
        string strMenuID2 ;

        string strMenuID;
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string strFun = "";
         
            DataSet ds = new DataSet();
            strMenuID2 = "";
            strMenuID = "";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //strGroupID = ((ItemList)cboGroup.SelectedItem).ID;
                for (int i = 0; i < tvMenu.Nodes.Count; i++)
                {
                    if (tvMenu.Nodes[i]["Check"].ToString() == "Checked" || tvMenu.Nodes[i]["Check"].ToString() == "Indeterminate")
                    {
                        strMenuID += tvMenu.Nodes[i]["MenuID"] + "@" + fn_getAllNodes(tvMenu.Nodes[i]);

                    }
                    else
                    {
                        strMenuID2 += tvMenu.Nodes[i]["MenuID"] + "@";
                        fn_getAllNodes(tvMenu.Nodes[i]);
                    }

                }
                
               
                strFun = ((ItemList)cboTill.SelectedItem).ID + "@" + (chkTem.Checked ? "1" : "0") + "@" + (chkHot.Checked ? "1" : "0")+
                    "@" + (chkShowLCD.Checked ? "1" : "0") + "@" + (chkPOTaskPrice.Checked ? "1" : "0") + "@"+(chkTaskPriceChange.Checked?"1":"0")
                    + "@" + ((ItemList)cboUnit.SelectedItem).ID + "@" + (chkSMS.Checked ? "1" : "0")+"@"+(ChkAllowPayCard.Checked?"1":"0")
                    + "@" + (chkScan.Checked ? "1" : "0") + "@" + (chkHeSo.Checked ? "1" : "0") +"@"+ (chkDoiTra.Checked ? "1" : "0")+"@"+(chkCatGia.Checked?"1":"0");


                ds = clsCommon.ExecuteDatasetSP("[SYS_MENUS_UpdByGroupID]", '2', strMenuID, strMenuID2, strFun);

                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Cập nhật thành công, vui lòng thoát ra đăng nhập lại", "OK", ICon.Information);
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

        private string fn_getAllNodes(TreeListNode node)
        {
            string strResult = "";

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                if (node.Nodes[i]["Check"].ToString() == "Checked" || node.Nodes[i]["Check"].ToString() == "Indeterminate")
                {
                    strResult += node.Nodes[i]["MenuID"].ToString() + "@" + fn_getAllNodes(node.Nodes[i]);
                }
                else 
                {
                    strMenuID2 += node.Nodes[i]["MenuID"].ToString() + "@";
                    fn_getAllNodes(node.Nodes[i]);
                    
                }
               

                
                   
                //fn_getAllNodes(node.Nodes[i]);
            }
            return strResult;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        
    }
}