using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Messages;
using System.Drawing.Drawing2D;
using DevExpress.Utils.Menu;
using DevExpress.Utils;
namespace GoldRT
{
    
    public partial class frmBangGia : DevExpress.XtraEditors.XtraForm
    {

        private DataTable tem = null;
        	

        public frmBangGia()
        {
            InitializeComponent();
            dateEdit1.EditValue = DateTime.Now;
            
        
        }
    
        
        private IDXMenuManager menuManager;
        public IDXMenuManager MenuManager
        {
            get { return menuManager; }
            set { menuManager = value; }
        }
        public static event EventHandler mnuClick;
       
        private DXPopupMenu CreatePopupMenu()
        {
            DXPopupMenu menu = new DXPopupMenu();

            menu.Items.Add(new DXMenuItem("Left to right", mnuClick));
            menu.Items.Add(new DXMenuItem("Right to left", mnuClick));
            menu.Items.Add(new DXMenuItem("Bouncing", mnuClick));
            return menu;
           
            
        }
        
        public void fn_Refresh()
        {
            frmBangGia_Load(null, null);
        }
       
        private void Option_ScrollingText()
        {
            scrollingText1.BackgroundBrush = 
				new LinearGradientBrush(this.scrollingText1.ClientRectangle, 
				Color.Red, Color.Blue, 
				LinearGradientMode.Horizontal);


			
			scrollingText1.ForeColor = Color.Yellow;			
		
			scrollingText1.ScrollText = clsSystem.ShopName;
        }
        private void frmBangGia_Load(object sender, EventArgs e)
        {

            mnuClick += new EventHandler(frmBangGia_mnuClick);
            Option_ScrollingText();    
            DataSet ds = new DataSet();
            try
            {
                decimal i = 1;
                ds = clsCommon.ExecuteDatasetSP("BangGia_Lst");
                tem = ds.Tables[0].Copy();
                tem.Columns.Add("Order", typeof(decimal));
                foreach (DataRow row in tem.Rows)
                {
                    row["Order"] = i;
                    i++;
                }
                grdGiaVang.DataSource = tem; //ds.Tables[0];
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToGrid: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

      

        void frmBangGia_mnuClick(object sender,EventArgs e)
        {
            DXMenuItem dxmenu = sender as DXMenuItem;
            if(dxmenu.Caption=="Left to right")
            scrollingText1.ScrollDirection = ScrollingTextControl.ScrollDirection.LeftToRight;
            else if(dxmenu.Caption=="Right to left")
            scrollingText1.ScrollDirection = ScrollingTextControl.ScrollDirection.RightToLeft;
        else scrollingText1.ScrollDirection = ScrollingTextControl.ScrollDirection.Bouncing;
        }

     

        

        

        private void grvGiaVang_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvGiaVang.OptionsBehavior.Editable)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (ThongBao.Show("Thông báo", "Bạn có chắc chắn là muốn xóa không?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                    {
                        int i = grvGiaVang.FocusedRowHandle;
                        grvGiaVang.DeleteRow(i);
                    }
                }
            }
        }

        GridHitInfo downHitInfo = null;
        private void grvGiaVang_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow)
                downHitInfo = hitInfo;
        }

        private void grvGiaVang_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(downHitInfo, DragDropEffects.All);
                    downHitInfo = null;
                }
            }			
        }

        private void grdGiaVang_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.MainView as GridView;
            GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
            int sourceRow = downHitInfo.RowHandle;
            int targetRow = hitInfo.RowHandle;
            MoveRow(sourceRow, targetRow);
        }

        const string OrderFieldName = "Order";
        private void MoveRow(int sourceRow, int targetRow)
        {
            if (sourceRow == targetRow || sourceRow == targetRow + 1) return;

            GridView view = grvGiaVang;
            DataRow row1 = view.GetDataRow(targetRow);
            DataRow row2 = view.GetDataRow(targetRow + 1);
            DataRow dragRow = view.GetDataRow(sourceRow);
            decimal val1 = (decimal)row1[OrderFieldName];
            if (row2 == null)
                dragRow[OrderFieldName] = val1 + 1;
            else
            {
                decimal val2 = (decimal)row2[OrderFieldName];
                dragRow[OrderFieldName] = (val1 + val2) / 2;
            }
        }

        private void grdGiaVang_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            if (downHitInfo != null)
            {
                GridControl grid = sender as GridControl;
                GridView view = grid.MainView as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle)
                    e.Effect = DragDropEffects.Move;
            }
        }

        private void grdGiaVang_Click(object sender, EventArgs e)
        {

        }
        
        private void scrollingText1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MenuManagerHelper.ShowMenu(CreatePopupMenu(), this.LookAndFeel, menuManager, scrollingText1, e.Location);
                
            }
        }

        

       
    }
}