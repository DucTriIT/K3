namespace GoldRT
{
    partial class frmQueryCustDebt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryCustDebt));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.txtTenKhachHang = new DevExpress.XtraEditors.TextEdit();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.grdDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CustID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTien = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnIn);
            this.layoutControl1.Controls.Add(this.txtTenKhachHang);
            this.layoutControl1.Controls.Add(this.btnThoat);
            this.layoutControl1.Controls.Add(this.btnTimKiem);
            this.layoutControl1.Controls.Add(this.gridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(678, 526);
            this.layoutControl1.TabIndex = 18;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.ImageIndex = 2;
            this.btnIn.ImageList = this.imageCollection;
            this.btnIn.Location = new System.Drawing.Point(505, 496);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(85, 27);
            this.btnIn.StyleController = this.layoutControl1;
            this.btnIn.TabIndex = 25;
            this.btnIn.Text = "&In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(121, 30);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhachHang.Properties.Appearance.Options.UseFont = true;
            this.txtTenKhachHang.Size = new System.Drawing.Size(451, 25);
            this.txtTenKhachHang.StyleController = this.layoutControl1;
            this.txtTenKhachHang.TabIndex = 24;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageIndex = 0;
            this.btnThoat.ImageList = this.imageCollection;
            this.btnThoat.Location = new System.Drawing.Point(593, 495);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 27);
            this.btnThoat.StyleController = this.layoutControl1;
            this.btnThoat.TabIndex = 23;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.ImageIndex = 7;
            this.btnTimKiem.ImageList = this.imageCollection;
            this.btnTimKiem.Location = new System.Drawing.Point(575, 29);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(99, 27);
            this.btnTimKiem.StyleController = this.layoutControl1;
            this.btnTimKiem.TabIndex = 22;
            this.btnTimKiem.Text = "Tìm &kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // gridControl
            // 
            this.gridControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(7, 90);
            this.gridControl.MainView = this.grdDanhSach;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtTien});
            this.gridControl.Size = new System.Drawing.Size(665, 398);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDanhSach});
            // 
            // grdDanhSach
            // 
            this.grdDanhSach.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.grdDanhSach.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.grdDanhSach.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.DetailTip.Options.UseFont = true;
            this.grdDanhSach.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.Empty.Options.UseFont = true;
            this.grdDanhSach.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.EvenRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.FilterCloseButton.Options.UseFont = true;
            this.grdDanhSach.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.FilterPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.FixedLine.Options.UseFont = true;
            this.grdDanhSach.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.FocusedCell.Options.UseFont = true;
            this.grdDanhSach.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.FocusedRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.FooterPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.GroupButton.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.GroupFooter.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.GroupPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.GroupRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.HorzLine.Options.UseFont = true;
            this.grdDanhSach.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.OddRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.Preview.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.Preview.Options.UseFont = true;
            this.grdDanhSach.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.Row.Options.UseFont = true;
            this.grdDanhSach.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.RowSeparator.Options.UseFont = true;
            this.grdDanhSach.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.SelectedRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.TopNewRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.VertLine.Options.UseFont = true;
            this.grdDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CustID,
            this.CustCode,
            this.CustName,
            this.VND});
            this.grdDanhSach.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "C";
            this.grdDanhSach.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.grdDanhSach.GridControl = this.gridControl;
            this.grdDanhSach.Name = "grdDanhSach";
            this.grdDanhSach.OptionsBehavior.Editable = false;
            this.grdDanhSach.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdDanhSach.OptionsView.ShowFooter = true;
            this.grdDanhSach.OptionsView.ShowGroupPanel = false;
            this.grdDanhSach.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CustName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdDanhSach.DoubleClick += new System.EventHandler(this.grdDanhSach_DoubleClick);
            // 
            // CustID
            // 
            this.CustID.Caption = "CustID";
            this.CustID.FieldName = "CustID";
            this.CustID.Name = "CustID";
            this.CustID.Width = 59;
            // 
            // CustCode
            // 
            this.CustCode.Caption = "Mã KH";
            this.CustCode.FieldName = "CustCode";
            this.CustCode.Name = "CustCode";
            this.CustCode.OptionsColumn.FixedWidth = true;
            this.CustCode.SummaryItem.DisplayFormat = "Số dòng = {0}";
            this.CustCode.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.CustCode.Width = 107;
            // 
            // CustName
            // 
            this.CustName.Caption = "Tên khách hàng";
            this.CustName.FieldName = "CustName";
            this.CustName.Name = "CustName";
            this.CustName.Visible = true;
            this.CustName.VisibleIndex = 0;
            this.CustName.Width = 134;
            // 
            // VND
            // 
            this.VND.Caption = "Tiền";
            this.VND.ColumnEdit = this.txtTien;
            this.VND.FieldName = "VND";
            this.VND.Name = "VND";
            this.VND.SummaryItem.DisplayFormat = "{0:n0}";
            this.VND.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.VND.Visible = true;
            this.VND.VisibleIndex = 1;
            this.VND.Width = 42;
            // 
            // txtTien
            // 
            this.txtTien.AutoHeight = false;
            this.txtTien.Mask.EditMask = "n0";
            this.txtTien.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTien.Mask.UseMaskAsDisplayFormat = true;
            this.txtTien.Name = "txtTien";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlItem4,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(678, 526);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 492);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(70, 30);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 1, 2);
            this.emptySpaceItem1.Size = new System.Drawing.Size(501, 32);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup2.CustomizationFormText = "Danh sách toa dẻ";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 60);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(676, 432);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Text = "Danh sách nợ";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.Control = this.gridControl;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(670, 403);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.CustomizationFormText = "Thông tin tìm kiếm";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem8});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup3.Size = new System.Drawing.Size(676, 60);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup3.Text = "Thông tin tìm kiếm";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txtTenKhachHang;
            this.layoutControlItem2.CustomizationFormText = "Tên khách hàng";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 31);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(144, 31);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(570, 31);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "Tên khách hàng";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(109, 20);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AllowHotTrack = false;
            this.layoutControlItem8.Control = this.btnTimKiem;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(570, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(100, 31);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(100, 31);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 1, 2);
            this.layoutControlItem8.Size = new System.Drawing.Size(100, 31);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.btnIn;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(501, 492);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(90, 32);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(90, 32);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(90, 32);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AllowHotTrack = false;
            this.layoutControlItem9.Control = this.btnThoat;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(591, 492);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(85, 31);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(85, 31);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 1, 2);
            this.layoutControlItem9.Size = new System.Drawing.Size(85, 32);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // frmQueryCustDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 526);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmQueryCustDebt";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem nợ";
            this.Load += new System.EventHandler(this.frmGoldPOLst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDanhSach;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraGrid.Columns.GridColumn CustName;
        private DevExpress.XtraGrid.Columns.GridColumn CustCode;
        private DevExpress.XtraEditors.TextEdit txtTenKhachHang;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn VND;
        private DevExpress.XtraGrid.Columns.GridColumn CustID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtTien;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}