namespace GoldRT
{
    partial class frmBangGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangGia));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.scrollingText1 = new ScrollingTextControl.ScrollingText();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdGiaVang = new DevExpress.XtraGrid.GridControl();
            this.grvGiaVang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GoldCcy_G = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtGiaTri = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.GoldCcyDesc_G = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SellRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtSellRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.BuyRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtBuyRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Type_G = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceCcy_G = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Order = new DevExpress.XtraGrid.Columns.GridColumn();
            this.De = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaVang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGiaVang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtGiaTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtSellRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtBuyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.scrollingText1);
            this.layoutControl1.Controls.Add(this.labelControl2);
            this.layoutControl1.Controls.Add(this.grdGiaVang);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(792, 573);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // scrollingText1
            // 
            this.scrollingText1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollingText1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.scrollingText1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.scrollingText1.BorderColor = System.Drawing.Color.Black;
            this.scrollingText1.Cursor = System.Windows.Forms.Cursors.Default;
            this.scrollingText1.Font = new System.Drawing.Font("Tahoma", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollingText1.ForegroundBrush = null;
            this.scrollingText1.Location = new System.Drawing.Point(192, 8);
            this.scrollingText1.Name = "scrollingText1";
            this.scrollingText1.ScrollDirection = ScrollingTextControl.ScrollDirection.LeftToRight;
            this.scrollingText1.ScrollText = "Text to scroll";
            this.scrollingText1.ShowBorder = true;
            this.scrollingText1.Size = new System.Drawing.Size(595, 89);
            this.scrollingText1.StopScrollOnMouseOver = false;
            this.scrollingText1.TabIndex = 6;
            this.scrollingText1.Text = "TIEM VANG";
            this.scrollingText1.TextScrollDistance = 2;
            this.scrollingText1.TextScrollSpeed = 25;
            this.scrollingText1.VerticleTextPosition = ScrollingTextControl.VerticleTextPosition.Center;
            this.scrollingText1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.scrollingText1_MouseClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(617, 108);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(170, 31);
            this.labelControl2.StyleController = this.layoutControl1;
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "Đvị : Đồng/chỉ";
            // 
            // grdGiaVang
            // 
            this.grdGiaVang.AllowDrop = true;
            this.grdGiaVang.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdGiaVang.EmbeddedNavigator.Name = "";
            this.grdGiaVang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdGiaVang.Location = new System.Drawing.Point(8, 183);
            this.grdGiaVang.MainView = this.grvGiaVang;
            this.grdGiaVang.Name = "grdGiaVang";
            this.grdGiaVang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtGiaTri,
            this.rtSellRate,
            this.rtBuyRate});
            this.grdGiaVang.Size = new System.Drawing.Size(779, 366);
            this.grdGiaVang.TabIndex = 24;
            this.grdGiaVang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGiaVang});
            this.grdGiaVang.DragOver += new System.Windows.Forms.DragEventHandler(this.grdGiaVang_DragOver);
            this.grdGiaVang.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdGiaVang_DragDrop);
            this.grdGiaVang.Click += new System.EventHandler(this.grdGiaVang_Click);
            // 
            // grvGiaVang
            // 
            this.grvGiaVang.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvGiaVang.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.grvGiaVang.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.grvGiaVang.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.DetailTip.Options.UseFont = true;
            this.grvGiaVang.Appearance.Empty.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.Empty.Options.UseFont = true;
            this.grvGiaVang.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.EvenRow.Options.UseFont = true;
            this.grvGiaVang.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.FilterCloseButton.Options.UseFont = true;
            this.grvGiaVang.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.FilterPanel.Options.UseFont = true;
            this.grvGiaVang.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.FixedLine.Options.UseFont = true;
            this.grvGiaVang.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGiaVang.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.grvGiaVang.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGiaVang.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.FooterPanel.Options.UseFont = true;
            this.grvGiaVang.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.GroupButton.Options.UseFont = true;
            this.grvGiaVang.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvGiaVang.Appearance.GroupFooter.Options.UseFont = true;
            this.grvGiaVang.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.GroupPanel.Options.UseFont = true;
            this.grvGiaVang.Appearance.GroupRow.BorderColor = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvGiaVang.Appearance.GroupRow.Options.UseFont = true;
            this.grvGiaVang.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Silver;
            this.grvGiaVang.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Blue;
            this.grvGiaVang.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGiaVang.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGiaVang.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvGiaVang.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGiaVang.Appearance.HorzLine.BackColor = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.HorzLine.BackColor2 = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGiaVang.Appearance.HorzLine.Options.UseFont = true;
            this.grvGiaVang.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.OddRow.Options.UseFont = true;
            this.grvGiaVang.Appearance.Preview.BorderColor = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.Preview.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.Preview.Options.UseBorderColor = true;
            this.grvGiaVang.Appearance.Preview.Options.UseFont = true;
            this.grvGiaVang.Appearance.Row.BorderColor = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.Row.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.Row.Options.UseBorderColor = true;
            this.grvGiaVang.Appearance.Row.Options.UseFont = true;
            this.grvGiaVang.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grvGiaVang.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvGiaVang.Appearance.RowSeparator.Options.UseFont = true;
            this.grvGiaVang.Appearance.SelectedRow.BackColor = System.Drawing.Color.Transparent;
            this.grvGiaVang.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.grvGiaVang.Appearance.SelectedRow.BorderColor = System.Drawing.Color.Transparent;
            this.grvGiaVang.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvGiaVang.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.grvGiaVang.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGiaVang.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.TopNewRow.Options.UseFont = true;
            this.grvGiaVang.Appearance.VertLine.BackColor = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.VertLine.BackColor2 = System.Drawing.Color.Black;
            this.grvGiaVang.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGiaVang.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGiaVang.Appearance.VertLine.Options.UseFont = true;
            this.grvGiaVang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GoldCcy_G,
            this.GoldCcyDesc_G,
            this.SellRate,
            this.BuyRate,
            this.Type_G,
            this.colPriceCcy_G,
            this.GhiChu,
            this.Order,
            this.De});
            this.grvGiaVang.CustomizationFormBounds = new System.Drawing.Rectangle(689, 146, 208, 359);
            this.grvGiaVang.GridControl = this.grdGiaVang;
            this.grvGiaVang.Name = "grvGiaVang";
            this.grvGiaVang.NewItemRowText = "  ";
            this.grvGiaVang.OptionsCustomization.AllowRowSizing = true;
            this.grvGiaVang.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvGiaVang.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvGiaVang.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvGiaVang.OptionsSelection.UseIndicatorForSelection = false;
            this.grvGiaVang.OptionsView.RowAutoHeight = true;
            this.grvGiaVang.OptionsView.ShowGroupPanel = false;
            this.grvGiaVang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvGiaVang_KeyDown);
            this.grvGiaVang.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grvGiaVang_MouseMove);
            this.grvGiaVang.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvGiaVang_MouseDown);
            // 
            // GoldCcy_G
            // 
            this.GoldCcy_G.Caption = "GoldCcy_G";
            this.GoldCcy_G.ColumnEdit = this.rtGiaTri;
            this.GoldCcy_G.FieldName = "GoldCcy";
            this.GoldCcy_G.Name = "GoldCcy_G";
            this.GoldCcy_G.OptionsColumn.AllowEdit = false;
            this.GoldCcy_G.OptionsColumn.AllowFocus = false;
            this.GoldCcy_G.Width = 161;
            // 
            // rtGiaTri
            // 
            this.rtGiaTri.AutoHeight = false;
            this.rtGiaTri.Name = "rtGiaTri";
            // 
            // GoldCcyDesc_G
            // 
            this.GoldCcyDesc_G.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.GoldCcyDesc_G.AppearanceCell.BorderColor = System.Drawing.Color.Black;
            this.GoldCcyDesc_G.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 27F);
            this.GoldCcyDesc_G.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.GoldCcyDesc_G.AppearanceCell.Options.UseBackColor = true;
            this.GoldCcyDesc_G.AppearanceCell.Options.UseBorderColor = true;
            this.GoldCcyDesc_G.AppearanceCell.Options.UseFont = true;
            this.GoldCcyDesc_G.AppearanceCell.Options.UseForeColor = true;
            this.GoldCcyDesc_G.Caption = "LOẠI VÀNG";
            this.GoldCcyDesc_G.FieldName = "GoldCcyDesc";
            this.GoldCcyDesc_G.Name = "GoldCcyDesc_G";
            this.GoldCcyDesc_G.OptionsColumn.AllowFocus = false;
            this.GoldCcyDesc_G.Visible = true;
            this.GoldCcyDesc_G.VisibleIndex = 0;
            this.GoldCcyDesc_G.Width = 215;
            // 
            // SellRate
            // 
            this.SellRate.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SellRate.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 35F, System.Drawing.FontStyle.Bold);
            this.SellRate.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.SellRate.AppearanceCell.Options.UseBackColor = true;
            this.SellRate.AppearanceCell.Options.UseFont = true;
            this.SellRate.AppearanceCell.Options.UseForeColor = true;
            this.SellRate.Caption = "BÁN RA";
            this.SellRate.ColumnEdit = this.rtSellRate;
            this.SellRate.FieldName = "SellRate";
            this.SellRate.Name = "SellRate";
            this.SellRate.OptionsColumn.AllowFocus = false;
            this.SellRate.Visible = true;
            this.SellRate.VisibleIndex = 2;
            this.SellRate.Width = 252;
            // 
            // rtSellRate
            // 
            this.rtSellRate.AutoHeight = false;
            this.rtSellRate.Mask.EditMask = "n0";
            this.rtSellRate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rtSellRate.Mask.UseMaskAsDisplayFormat = true;
            this.rtSellRate.Name = "rtSellRate";
            // 
            // BuyRate
            // 
            this.BuyRate.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BuyRate.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 35F, System.Drawing.FontStyle.Bold);
            this.BuyRate.AppearanceCell.ForeColor = System.Drawing.Color.DarkGreen;
            this.BuyRate.AppearanceCell.Options.UseBackColor = true;
            this.BuyRate.AppearanceCell.Options.UseFont = true;
            this.BuyRate.AppearanceCell.Options.UseForeColor = true;
            this.BuyRate.Caption = "MUA VÀO";
            this.BuyRate.ColumnEdit = this.rtBuyRate;
            this.BuyRate.FieldName = "BuyRate";
            this.BuyRate.Name = "BuyRate";
            this.BuyRate.OptionsColumn.AllowFocus = false;
            this.BuyRate.Visible = true;
            this.BuyRate.VisibleIndex = 1;
            this.BuyRate.Width = 291;
            // 
            // rtBuyRate
            // 
            this.rtBuyRate.AutoHeight = false;
            this.rtBuyRate.Mask.EditMask = "n0";
            this.rtBuyRate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rtBuyRate.Mask.UseMaskAsDisplayFormat = true;
            this.rtBuyRate.Name = "rtBuyRate";
            // 
            // Type_G
            // 
            this.Type_G.Caption = "Type";
            this.Type_G.FieldName = "Type";
            this.Type_G.Name = "Type_G";
            this.Type_G.Width = 77;
            // 
            // colPriceCcy_G
            // 
            this.colPriceCcy_G.Caption = "ĐVT";
            this.colPriceCcy_G.FieldName = "PriceCcy";
            this.colPriceCcy_G.Name = "colPriceCcy_G";
            this.colPriceCcy_G.Width = 68;
            // 
            // GhiChu
            // 
            this.GhiChu.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.GhiChu.AppearanceCell.Font = new System.Drawing.Font("Arial", 27F);
            this.GhiChu.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(127)))));
            this.GhiChu.AppearanceCell.Options.UseBackColor = true;
            this.GhiChu.AppearanceCell.Options.UseFont = true;
            this.GhiChu.AppearanceCell.Options.UseForeColor = true;
            this.GhiChu.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.GhiChu.AppearanceHeader.Options.UseFont = true;
            this.GhiChu.Caption = "GHI CHÚ";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.OptionsColumn.AllowFocus = false;
            this.GhiChu.Width = 132;
            // 
            // Order
            // 
            this.Order.Caption = "Order";
            this.Order.FieldName = "Order";
            this.Order.Name = "Order";
            this.Order.Width = 87;
            // 
            // De
            // 
            this.De.Caption = "Loại dẻ";
            this.De.FieldName = "De";
            this.De.Name = "De";
            this.De.Width = 109;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(424, 105);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.dateEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.dateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.dateEdit1.Properties.Appearance.Options.UseFont = true;
            this.dateEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.dateEdit1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 25F);
            this.dateEdit1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dateEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 25F);
            this.dateEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dateEdit1.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 25F);
            this.dateEdit1.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dateEdit1.Properties.AppearanceDropDownHeaderHighlight.Font = new System.Drawing.Font("Arial", 25F);
            this.dateEdit1.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dateEdit1.Properties.AppearanceDropDownHighlight.Font = new System.Drawing.Font("Arial", 25F);
            this.dateEdit1.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dateEdit1.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 25F);
            this.dateEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            this.dateEdit1.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 25F);
            this.dateEdit1.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Properties.ReadOnly = true;
            this.dateEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateEdit1.Size = new System.Drawing.Size(185, 45);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 27;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(794, 556);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.Control = this.grdGiaVang;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 175);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(790, 377);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Lime;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem4.Control = this.dateEdit1;
            this.layoutControlItem4.CustomizationFormText = "BẢNG GIÁ VÀNG NGÀY : ";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 50);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(455, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(609, 50);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "BẢNG GIÁ VÀNG NGÀY:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(411, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.Control = this.labelControl2;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(609, 100);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(181, 50);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 150);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(790, 25);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(790, 25);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(790, 25);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AllowHotTrack = false;
            this.layoutControlItem5.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem5.Control = this.scrollingText1;
            this.layoutControlItem5.CustomizationFormText = "TIỆM VÀNG";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Size = new System.Drawing.Size(790, 100);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Text = "TIỆM VÀNG";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(179, 20);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmBangGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBangGia";
            this.Text = "Bảng giá vàng";
            this.Load += new System.EventHandler(this.frmBangGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaVang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGiaVang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtGiaTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtSellRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtBuyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdGiaVang;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGiaVang;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCcy_G;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtGiaTri;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCcyDesc_G;
        private DevExpress.XtraGrid.Columns.GridColumn SellRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtSellRate;
        private DevExpress.XtraGrid.Columns.GridColumn BuyRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtBuyRate;
        private DevExpress.XtraGrid.Columns.GridColumn Type_G;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceCcy_G;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn Order;
        private DevExpress.XtraGrid.Columns.GridColumn De;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private ScrollingTextControl.ScrollingText scrollingText1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}