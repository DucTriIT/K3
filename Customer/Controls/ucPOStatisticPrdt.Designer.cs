namespace GoldRT
{
    partial class ucPOStatisticPrdt
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnInBangKe = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.grdcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grdDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaskPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiamondWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblAddress = new DevExpress.XtraEditors.LabelControl();
            this.lblCustName = new DevExpress.XtraEditors.LabelControl();
            this.lblTrnDate = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnInBangKe);
            this.layoutControl1.Controls.Add(this.labelControl5);
            this.layoutControl1.Controls.Add(this.grdcDanhSach);
            this.layoutControl1.Controls.Add(this.lblAddress);
            this.layoutControl1.Controls.Add(this.lblCustName);
            this.layoutControl1.Controls.Add(this.lblTrnDate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(685, 536);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnInBangKe
            // 
            this.btnInBangKe.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBangKe.Appearance.Options.UseFont = true;
            this.btnInBangKe.ImageIndex = 12;
            this.btnInBangKe.Location = new System.Drawing.Point(584, 503);
            this.btnInBangKe.Name = "btnInBangKe";
            this.btnInBangKe.Size = new System.Drawing.Size(95, 27);
            this.btnInBangKe.StyleController = this.layoutControl1;
            this.btnInBangKe.TabIndex = 30;
            this.btnInBangKe.Text = "&In bảng kê";
            this.btnInBangKe.Click += new System.EventHandler(this.btnInBangKe_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(5, 5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(0, 0);
            this.labelControl5.StyleController = this.layoutControl1;
            this.labelControl5.TabIndex = 24;
            this.labelControl5.Text = "dd/MM/yyyy";
            // 
            // grdcDanhSach
            // 
            this.grdcDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdcDanhSach.EmbeddedNavigator.Name = "";
            this.grdcDanhSach.Location = new System.Drawing.Point(10, 88);
            this.grdcDanhSach.MainView = this.grdDanhSach;
            this.grdcDanhSach.Name = "grdcDanhSach";
            this.grdcDanhSach.Size = new System.Drawing.Size(666, 401);
            this.grdcDanhSach.TabIndex = 17;
            this.grdcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.ProductCode,
            this.ProductDesc,
            this.TaskPrice,
            this.DiamondWeight,
            this.GoldWeight});
            this.grdDanhSach.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "C";
            this.grdDanhSach.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.grdDanhSach.GridControl = this.grdcDanhSach;
            this.grdDanhSach.GroupFormat = "[#image]{1} {2}";
            this.grdDanhSach.Name = "grdDanhSach";
            this.grdDanhSach.OptionsBehavior.Editable = false;
            this.grdDanhSach.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdDanhSach.OptionsView.ShowFooter = true;
            this.grdDanhSach.OptionsView.ShowGroupPanel = false;
            // 
            // ProductCode
            // 
            this.ProductCode.Caption = "Mã hàng";
            this.ProductCode.FieldName = "ProductCode";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.SummaryItem.DisplayFormat = "Số dòng = {0}";
            this.ProductCode.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.ProductCode.Visible = true;
            this.ProductCode.VisibleIndex = 0;
            // 
            // ProductDesc
            // 
            this.ProductDesc.Caption = "Tên hàng";
            this.ProductDesc.FieldName = "ProductDesc";
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.Visible = true;
            this.ProductDesc.VisibleIndex = 1;
            // 
            // TaskPrice
            // 
            this.TaskPrice.Caption = "Giá công";
            this.TaskPrice.FieldName = "TaskPrice";
            this.TaskPrice.Name = "TaskPrice";
            this.TaskPrice.Visible = true;
            this.TaskPrice.VisibleIndex = 4;
            // 
            // DiamondWeight
            // 
            this.DiamondWeight.Caption = "TL hột";
            this.DiamondWeight.FieldName = "DiamondWeight";
            this.DiamondWeight.Name = "DiamondWeight";
            this.DiamondWeight.Visible = true;
            this.DiamondWeight.VisibleIndex = 2;
            // 
            // GoldWeight
            // 
            this.GoldWeight.Caption = "TL vàng";
            this.GoldWeight.FieldName = "GoldWeight";
            this.GoldWeight.Name = "GoldWeight";
            this.GoldWeight.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.GoldWeight.Visible = true;
            this.GoldWeight.VisibleIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Appearance.Options.UseFont = true;
            this.lblAddress.Location = new System.Drawing.Point(423, 30);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(259, 19);
            this.lblAddress.StyleController = this.layoutControl1;
            this.lblAddress.TabIndex = 16;
            this.lblAddress.Text = "{rỗng}";
            // 
            // lblCustName
            // 
            this.lblCustName.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustName.Appearance.Options.UseFont = true;
            this.lblCustName.Location = new System.Drawing.Point(103, 30);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(216, 19);
            this.lblCustName.StyleController = this.layoutControl1;
            this.lblCustName.TabIndex = 15;
            this.lblCustName.Text = "{rỗng}";
            // 
            // lblTrnDate
            // 
            this.lblTrnDate.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrnDate.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblTrnDate.Appearance.Options.UseFont = true;
            this.lblTrnDate.Appearance.Options.UseForeColor = true;
            this.lblTrnDate.Location = new System.Drawing.Point(103, 4);
            this.lblTrnDate.Name = "lblTrnDate";
            this.lblTrnDate.Size = new System.Drawing.Size(579, 21);
            this.lblTrnDate.StyleController = this.layoutControl1;
            this.lblTrnDate.TabIndex = 14;
            this.lblTrnDate.Text = "{rỗng}";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.layoutControlItem14,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(685, 536);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.Control = this.lblTrnDate;
            this.layoutControlItem1.CustomizationFormText = "Ngày :";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(152, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(683, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "Ngày : ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(94, 20);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.lblCustName;
            this.layoutControlItem2.CustomizationFormText = "Khách hàng :";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(145, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(320, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "Khách hàng : ";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(94, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.lblAddress;
            this.layoutControlItem3.CustomizationFormText = "Địa chỉ :";
            this.layoutControlItem3.Location = new System.Drawing.Point(320, 26);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(145, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(363, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "Địa chỉ : ";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(94, 20);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 5);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(110, 5);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(683, 5);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 496);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem3.Size = new System.Drawing.Size(577, 38);
            this.emptySpaceItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.AllowHotTrack = false;
            this.layoutControlItem14.Control = this.btnInBangKe;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new System.Drawing.Point(577, 496);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem14.Size = new System.Drawing.Size(106, 38);
            this.layoutControlItem14.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem14.Text = "layoutControlItem14";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextToControlDistance = 0;
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.CustomizationFormText = "Thống kê dẻ đổi";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 55);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup3.Size = new System.Drawing.Size(683, 441);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup3.Text = "Bảng kê";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.grdcDanhSach;
            this.layoutControlItem4.CustomizationFormText = "Thống kê dẻ đổi";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Size = new System.Drawing.Size(677, 412);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "Thống kê dẻ đổi";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // ucPOStatisticPrdt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucPOStatisticPrdt";
            this.Size = new System.Drawing.Size(685, 536);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.layoutControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl lblAddress;
        private DevExpress.XtraEditors.LabelControl lblCustName;
        private DevExpress.XtraEditors.LabelControl lblTrnDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl grdcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDanhSach;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnInBangKe;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraGrid.Columns.GridColumn ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn ProductDesc;
        private DevExpress.XtraGrid.Columns.GridColumn TaskPrice;
        private DevExpress.XtraGrid.Columns.GridColumn DiamondWeight;
        private DevExpress.XtraGrid.Columns.GridColumn GoldWeight;
    }
}
