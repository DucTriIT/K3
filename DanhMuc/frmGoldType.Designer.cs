namespace GoldRT
{
    partial class frmGoldType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoldType));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtGoldAge = new DevExpress.XtraEditors.TextEdit();
            this.grdControl = new DevExpress.XtraGrid.GridControl();
            this.grdDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GoldCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SectionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Notes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldTypeChr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PriceUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PriceCcy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnitDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ccy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Subtract = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Group = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TruGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TruLai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoldAge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtGoldAge);
            this.layoutControl1.Controls.Add(this.grdControl);
            this.layoutControl1.Controls.Add(this.btnThoat);
            this.layoutControl1.Controls.Add(this.btnXoa);
            this.layoutControl1.Controls.Add(this.btnSua);
            this.layoutControl1.Controls.Add(this.btnThem);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem17});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(983, 456);
            this.layoutControl1.TabIndex = 22;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtGoldAge
            // 
            this.txtGoldAge.Location = new System.Drawing.Point(653, 121);
            this.txtGoldAge.Name = "txtGoldAge";
            this.txtGoldAge.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtGoldAge.Properties.Appearance.Options.UseFont = true;
            this.txtGoldAge.Properties.DisplayFormat.FormatString = "{0:#.##}";
            this.txtGoldAge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGoldAge.Properties.EditFormat.FormatString = "{0:#.##}";
            this.txtGoldAge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGoldAge.Properties.Mask.EditMask = "n2";
            this.txtGoldAge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGoldAge.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtGoldAge.Size = new System.Drawing.Size(127, 24);
            this.txtGoldAge.StyleController = this.layoutControl1;
            this.txtGoldAge.TabIndex = 33;
            // 
            // grdControl
            // 
            this.grdControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdControl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdControl.Location = new System.Drawing.Point(6, 30);
            this.grdControl.MainView = this.grdDanhSach;
            this.grdControl.Name = "grdControl";
            this.grdControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdControl.Size = new System.Drawing.Size(971, 389);
            this.grdControl.TabIndex = 6;
            this.grdControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDanhSach});
            // 
            // grdDanhSach
            // 
            this.grdDanhSach.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 12F);
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
            this.GoldCode,
            this.GoldDesc,
            this.SectionName,
            this.Notes,
            this.OrderBy,
            this.GoldTypeChr,
            this.Active,
            this.PriceUnit,
            this.PriceCcy,
            this.UnitDesc,
            this.Ccy,
            this.GoldAge,
            this.Subtract,
            this.Add,
            this.Group,
            this.TruGia,
            this.TruLai});
            this.grdDanhSach.GridControl = this.grdControl;
            this.grdDanhSach.GroupCount = 1;
            this.grdDanhSach.Images = this.imageList1;
            this.grdDanhSach.Name = "grdDanhSach";
            this.grdDanhSach.OptionsBehavior.AutoExpandAllGroups = true;
            this.grdDanhSach.OptionsBehavior.Editable = false;
            this.grdDanhSach.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdDanhSach.OptionsView.ShowGroupPanel = false;
            this.grdDanhSach.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.SectionName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdDanhSach.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdDanhSach_FocusedRowChanged);
            // 
            // GoldCode
            // 
            this.GoldCode.Caption = "Mã ";
            this.GoldCode.FieldName = "GoldCode";
            this.GoldCode.Name = "GoldCode";
            this.GoldCode.Visible = true;
            this.GoldCode.VisibleIndex = 0;
            this.GoldCode.Width = 78;
            // 
            // GoldDesc
            // 
            this.GoldDesc.Caption = "Tên loại";
            this.GoldDesc.FieldName = "GoldDesc";
            this.GoldDesc.Name = "GoldDesc";
            this.GoldDesc.Visible = true;
            this.GoldDesc.VisibleIndex = 1;
            this.GoldDesc.Width = 82;
            // 
            // SectionName
            // 
            this.SectionName.Caption = "Nhóm hàng ";
            this.SectionName.FieldName = "SectionName";
            this.SectionName.Name = "SectionName";
            this.SectionName.Width = 273;
            // 
            // Notes
            // 
            this.Notes.Caption = "Đổi";
            this.Notes.FieldName = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.Width = 97;
            // 
            // OrderBy
            // 
            this.OrderBy.Caption = "Độ ưu tiên";
            this.OrderBy.FieldName = "OrderBy";
            this.OrderBy.Name = "OrderBy";
            this.OrderBy.Visible = true;
            this.OrderBy.VisibleIndex = 6;
            this.OrderBy.Width = 82;
            // 
            // GoldTypeChr
            // 
            this.GoldTypeChr.Caption = "GoldTypeChr";
            this.GoldTypeChr.FieldName = "GoldTypeChr";
            this.GoldTypeChr.Name = "GoldTypeChr";
            // 
            // Active
            // 
            this.Active.Caption = "Hoạt động";
            this.Active.ColumnEdit = this.repositoryItemImageComboBox1;
            this.Active.FieldName = "Active";
            this.Active.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.Active.ImageIndex = 2;
            this.Active.Name = "Active";
            this.Active.Visible = true;
            this.Active.VisibleIndex = 7;
            this.Active.Width = 83;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "1", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", 3)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemImageComboBox1.SmallImages = this.imageList1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "unchecked.gif");
            this.imageList1.Images.SetKeyName(4, "checked.gif");
            // 
            // PriceUnit
            // 
            this.PriceUnit.Caption = "PriceUnit";
            this.PriceUnit.FieldName = "PriceUnit";
            this.PriceUnit.Name = "PriceUnit";
            // 
            // PriceCcy
            // 
            this.PriceCcy.Caption = "PriceCcy";
            this.PriceCcy.FieldName = "PriceCcy";
            this.PriceCcy.Name = "PriceCcy";
            // 
            // UnitDesc
            // 
            this.UnitDesc.Caption = "Đơn vị tính";
            this.UnitDesc.FieldName = "UnitDesc";
            this.UnitDesc.Name = "UnitDesc";
            this.UnitDesc.Visible = true;
            this.UnitDesc.VisibleIndex = 4;
            this.UnitDesc.Width = 88;
            // 
            // Ccy
            // 
            this.Ccy.Caption = "Tiền tệ";
            this.Ccy.FieldName = "Ccy";
            this.Ccy.Name = "Ccy";
            this.Ccy.Visible = true;
            this.Ccy.VisibleIndex = 5;
            this.Ccy.Width = 143;
            // 
            // GoldAge
            // 
            this.GoldAge.Caption = "Tuổi vàng";
            this.GoldAge.FieldName = "GoldAge";
            this.GoldAge.GroupFormat.FormatString = "{0:#.##}";
            this.GoldAge.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.GoldAge.Name = "GoldAge";
            this.GoldAge.Width = 86;
            // 
            // Subtract
            // 
            this.Subtract.Caption = "HS trừ vào";
            this.Subtract.FieldName = "Subtract";
            this.Subtract.Name = "Subtract";
            this.Subtract.Width = 95;
            // 
            // Add
            // 
            this.Add.Caption = "HS cộng ra";
            this.Add.FieldName = "Add";
            this.Add.Name = "Add";
            this.Add.Width = 95;
            // 
            // Group
            // 
            this.Group.Caption = "Nhóm vàng";
            this.Group.FieldName = "Group";
            this.Group.Name = "Group";
            this.Group.Width = 76;
            // 
            // TruGia
            // 
            this.TruGia.Caption = "Giá vip";
            this.TruGia.DisplayFormat.FormatString = "n0";
            this.TruGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TruGia.FieldName = "TruGia";
            this.TruGia.Name = "TruGia";
            this.TruGia.Visible = true;
            this.TruGia.VisibleIndex = 3;
            this.TruGia.Width = 70;
            // 
            // TruLai
            // 
            this.TruLai.Caption = "Giá thường";
            this.TruLai.DisplayFormat.FormatString = "n0";
            this.TruLai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TruLai.FieldName = "TruLai";
            this.TruLai.Name = "TruLai";
            this.TruLai.Visible = true;
            this.TruLai.VisibleIndex = 2;
            this.TruLai.Width = 89;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageIndex = 5;
            this.btnThoat.ImageList = this.imageCollection;
            this.btnThoat.Location = new System.Drawing.Point(897, 422);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(82, 28);
            this.btnThoat.StyleController = this.layoutControl1;
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.ImageIndex = 2;
            this.btnXoa.ImageList = this.imageCollection;
            this.btnXoa.Location = new System.Drawing.Point(815, 422);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 28);
            this.btnXoa.StyleController = this.layoutControl1;
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "&Xoá";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.ImageIndex = 1;
            this.btnSua.ImageList = this.imageCollection;
            this.btnSua.Location = new System.Drawing.Point(733, 422);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 28);
            this.btnSua.StyleController = this.layoutControl1;
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "&Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.ImageIndex = 0;
            this.btnThem.ImageList = this.imageCollection;
            this.btnThem.Location = new System.Drawing.Point(651, 422);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 28);
            this.btnThem.StyleController = this.layoutControl1;
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thê&m";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.AllowHotTrack = false;
            this.layoutControlItem17.Control = this.txtGoldAge;
            this.layoutControlItem17.CustomizationFormText = "Tuổi vàng";
            this.layoutControlItem17.Location = new System.Drawing.Point(537, 90);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(163, 30);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(240, 30);
            this.layoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem17.Text = "Tuổi vàng";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(103, 20);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(983, 456);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem13,
            this.layoutControlItem12,
            this.layoutControlItem10,
            this.layoutControlItem8,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup3.Size = new System.Drawing.Size(981, 454);
            this.layoutControlGroup3.Text = "Danh sách đồ dùng";
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.AllowHotTrack = false;
            this.layoutControlItem13.Control = this.grdControl;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(975, 393);
            this.layoutControlItem13.Text = "layoutControlItem13";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextToControlDistance = 0;
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.AllowHotTrack = false;
            this.layoutControlItem12.Control = this.btnThem;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new System.Drawing.Point(647, 393);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 1, 2);
            this.layoutControlItem12.Size = new System.Drawing.Size(82, 31);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Text = "layoutControlItem12";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextToControlDistance = 0;
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AllowHotTrack = false;
            this.layoutControlItem10.Control = this.btnSua;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(729, 393);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 1, 2);
            this.layoutControlItem10.Size = new System.Drawing.Size(82, 31);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "layoutControlItem10";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AllowHotTrack = false;
            this.layoutControlItem8.Control = this.btnXoa;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(811, 393);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 1, 2);
            this.layoutControlItem8.Size = new System.Drawing.Size(82, 31);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AllowHotTrack = false;
            this.layoutControlItem7.Control = this.btnThoat;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(893, 393);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(82, 31);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 1, 2);
            this.layoutControlItem7.Size = new System.Drawing.Size(82, 31);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 393);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(647, 31);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmGoldType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 456);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGoldType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đồ dùng";
            this.Load += new System.EventHandler(this.frmPdtGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGoldAge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraGrid.GridControl grdControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn GoldDesc;
        private DevExpress.XtraGrid.Columns.GridColumn SectionName;
        private DevExpress.XtraGrid.Columns.GridColumn Active;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCode;
        private DevExpress.XtraGrid.Columns.GridColumn Notes;
        private DevExpress.XtraGrid.Columns.GridColumn OrderBy;
        private DevExpress.XtraGrid.Columns.GridColumn GoldTypeChr;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraGrid.Columns.GridColumn PriceUnit;
        private DevExpress.XtraGrid.Columns.GridColumn PriceCcy;
        private DevExpress.XtraGrid.Columns.GridColumn UnitDesc;
        private DevExpress.XtraGrid.Columns.GridColumn Ccy;
        private DevExpress.XtraEditors.TextEdit txtGoldAge;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraGrid.Columns.GridColumn GoldAge;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Subtract;
        private DevExpress.XtraGrid.Columns.GridColumn Add;
        private DevExpress.XtraGrid.Columns.GridColumn Group;
        private DevExpress.XtraGrid.Columns.GridColumn TruGia;
        private DevExpress.XtraGrid.Columns.GridColumn TruLai;
    }
}