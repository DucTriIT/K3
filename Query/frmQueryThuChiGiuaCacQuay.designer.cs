namespace GoldRT
{
    partial class frmQueryThuChiGiuaCacQuay
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.dtpTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.dtpDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.grdDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TrnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FromTillName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ToTillName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldCcyDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount_Diamond = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrnDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldCcy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtGhiChu = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cboGoldCcy = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.cboChon = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.rtxtDiamondWeight = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink2 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGoldCcy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtDiamondWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Phiếu thu", "I", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Phiếu chi", "O", -1)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnIn);
            this.layoutControl1.Controls.Add(this.dtpTuNgay);
            this.layoutControl1.Controls.Add(this.dtpDenNgay);
            this.layoutControl1.Controls.Add(this.gridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1320, 518);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Location = new System.Drawing.Point(1198, 486);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(119, 29);
            this.btnIn.StyleController = this.layoutControl1;
            this.btnIn.TabIndex = 38;
            this.btnIn.Text = "&In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.EditValue = new System.DateTime(2011, 12, 11, 17, 53, 46, 625);
            this.dtpTuNgay.Location = new System.Drawing.Point(71, 6);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTuNgay.Properties.Appearance.Options.UseFont = true;
            this.dtpTuNgay.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTuNgay.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpTuNgay.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTuNgay.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpTuNgay.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTuNgay.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtpTuNgay.Properties.AppearanceDropDownHeaderHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTuNgay.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dtpTuNgay.Properties.AppearanceDropDownHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTuNgay.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dtpTuNgay.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTuNgay.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpTuNgay.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTuNgay.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtpTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpTuNgay.Size = new System.Drawing.Size(175, 24);
            this.dtpTuNgay.StyleController = this.layoutControl1;
            this.dtpTuNgay.TabIndex = 37;
            this.dtpTuNgay.EditValueChanged += new System.EventHandler(this.dtpTuNgay_EditValueChanged);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.EditValue = new System.DateTime(2011, 12, 11, 17, 53, 55, 515);
            this.dtpDenNgay.Location = new System.Drawing.Point(331, 6);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDenNgay.Properties.Appearance.Options.UseFont = true;
            this.dtpDenNgay.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDenNgay.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpDenNgay.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDenNgay.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpDenNgay.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDenNgay.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtpDenNgay.Properties.AppearanceDropDownHeaderHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDenNgay.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dtpDenNgay.Properties.AppearanceDropDownHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDenNgay.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dtpDenNgay.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDenNgay.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpDenNgay.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDenNgay.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtpDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpDenNgay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpDenNgay.Size = new System.Drawing.Size(165, 24);
            this.dtpDenNgay.StyleController = this.layoutControl1;
            this.dtpDenNgay.TabIndex = 36;
            this.dtpDenNgay.EditValueChanged += new System.EventHandler(this.dtpDenNgay_EditValueChanged);
            // 
            // gridControl
            // 
            this.gridControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridControl.Location = new System.Drawing.Point(6, 42);
            this.gridControl.MainView = this.grdDanhSach;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtSoTien,
            this.txtGhiChu,
            this.cboGoldCcy,
            this.cboChon,
            this.rtxtDiamondWeight,
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2});
            this.gridControl.Size = new System.Drawing.Size(1308, 437);
            this.gridControl.TabIndex = 34;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDanhSach});
            this.gridControl.DoubleClick += new System.EventHandler(this.gridControl_DoubleClick);
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
            this.grdDanhSach.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Red;
            this.grdDanhSach.Appearance.FooterPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grdDanhSach.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.GroupButton.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.GroupFooter.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.GroupPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grdDanhSach.Appearance.GroupRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.TrnID,
            this.FromTillName,
            this.ToTillName,
            this.TrnDate,
            this.FullName,
            this.GoldCcyDesc,
            this.Type,
            this.Amount,
            this.Amount_Diamond,
            this.TrnDesc,
            this.TrnTime,
            this.GoldCcy});
            this.grdDanhSach.CustomizationFormBounds = new System.Drawing.Rectangle(539, 422, 216, 206);
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.MistyRose;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "W";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "C";
            this.grdDanhSach.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.grdDanhSach.GridControl = this.gridControl;
            this.grdDanhSach.GroupCount = 1;
            this.grdDanhSach.Name = "grdDanhSach";
            this.grdDanhSach.NewItemRowText = "Nhấn vào đây để nhập dữ liệu";
            this.grdDanhSach.OptionsBehavior.AutoExpandAllGroups = true;
            this.grdDanhSach.OptionsBehavior.Editable = false;
            this.grdDanhSach.OptionsPrint.PrintFooter = false;
            this.grdDanhSach.OptionsView.ShowFooter = true;
            this.grdDanhSach.OptionsView.ShowGroupPanel = false;
            this.grdDanhSach.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TrnID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdDanhSach.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdDanhSach_FocusedRowChanged);
            // 
            // TrnID
            // 
            this.TrnID.Caption = "Số phiếu";
            this.TrnID.FieldName = "TrnID";
            this.TrnID.Name = "TrnID";
            this.TrnID.OptionsColumn.AllowEdit = false;
            this.TrnID.OptionsColumn.AllowFocus = false;
            this.TrnID.Visible = true;
            this.TrnID.VisibleIndex = 0;
            this.TrnID.Width = 160;
            // 
            // FromTillName
            // 
            this.FromTillName.Caption = "Từ quầy";
            this.FromTillName.FieldName = "FromTillName";
            this.FromTillName.Name = "FromTillName";
            this.FromTillName.OptionsColumn.AllowEdit = false;
            this.FromTillName.OptionsColumn.AllowFocus = false;
            this.FromTillName.Visible = true;
            this.FromTillName.VisibleIndex = 3;
            this.FromTillName.Width = 105;
            // 
            // ToTillName
            // 
            this.ToTillName.Caption = "Đến quầy";
            this.ToTillName.FieldName = "ToTillName";
            this.ToTillName.Name = "ToTillName";
            this.ToTillName.OptionsColumn.AllowEdit = false;
            this.ToTillName.OptionsColumn.AllowFocus = false;
            this.ToTillName.Visible = true;
            this.ToTillName.VisibleIndex = 4;
            this.ToTillName.Width = 105;
            // 
            // TrnDate
            // 
            this.TrnDate.Caption = "Ngày";
            this.TrnDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.TrnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TrnDate.FieldName = "TrnDate";
            this.TrnDate.Name = "TrnDate";
            this.TrnDate.OptionsColumn.AllowEdit = false;
            this.TrnDate.OptionsColumn.AllowFocus = false;
            this.TrnDate.Visible = true;
            this.TrnDate.VisibleIndex = 0;
            this.TrnDate.Width = 127;
            // 
            // FullName
            // 
            this.FullName.Caption = "Người thực hiện";
            this.FullName.FieldName = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.OptionsColumn.AllowEdit = false;
            this.FullName.OptionsColumn.AllowFocus = false;
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 2;
            this.FullName.Width = 118;
            // 
            // GoldCcyDesc
            // 
            this.GoldCcyDesc.Caption = "GoldCcyDesc";
            this.GoldCcyDesc.FieldName = "GoldCcyDesc";
            this.GoldCcyDesc.Name = "GoldCcyDesc";
            this.GoldCcyDesc.OptionsColumn.AllowEdit = false;
            this.GoldCcyDesc.OptionsColumn.AllowFocus = false;
            // 
            // Type
            // 
            this.Type.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.Type.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Type.AppearanceCell.Options.UseBackColor = true;
            this.Type.AppearanceCell.Options.UseFont = true;
            this.Type.Caption = "Hình thức";
            this.Type.FieldName = "Type";
            this.Type.Name = "Type";
            this.Type.OptionsColumn.AllowEdit = false;
            this.Type.OptionsColumn.AllowFocus = false;
            this.Type.Visible = true;
            this.Type.VisibleIndex = 5;
            this.Type.Width = 105;
            // 
            // Amount
            // 
            this.Amount.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.Amount.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount.AppearanceCell.Options.UseBackColor = true;
            this.Amount.AppearanceCell.Options.UseFont = true;
            this.Amount.Caption = "Số lượng";
            this.Amount.DisplayFormat.FormatString = "n0";
            this.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.FieldName = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.OptionsColumn.AllowEdit = false;
            this.Amount.OptionsColumn.AllowFocus = false;
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 7;
            this.Amount.Width = 180;
            // 
            // Amount_Diamond
            // 
            this.Amount_Diamond.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.Amount_Diamond.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount_Diamond.AppearanceCell.Options.UseBackColor = true;
            this.Amount_Diamond.AppearanceCell.Options.UseFont = true;
            this.Amount_Diamond.Caption = "Hột";
            this.Amount_Diamond.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount_Diamond.FieldName = "Amount_Diamond";
            this.Amount_Diamond.Name = "Amount_Diamond";
            this.Amount_Diamond.OptionsColumn.AllowEdit = false;
            this.Amount_Diamond.OptionsColumn.AllowFocus = false;
            this.Amount_Diamond.Width = 70;
            // 
            // TrnDesc
            // 
            this.TrnDesc.Caption = "Ghi chú";
            this.TrnDesc.FieldName = "TrnDesc";
            this.TrnDesc.Name = "TrnDesc";
            this.TrnDesc.OptionsColumn.AllowEdit = false;
            this.TrnDesc.OptionsColumn.AllowFocus = false;
            this.TrnDesc.Visible = true;
            this.TrnDesc.VisibleIndex = 8;
            this.TrnDesc.Width = 144;
            // 
            // TrnTime
            // 
            this.TrnTime.Caption = "Giờ";
            this.TrnTime.FieldName = "TrnTime";
            this.TrnTime.Name = "TrnTime";
            this.TrnTime.OptionsColumn.AllowEdit = false;
            this.TrnTime.OptionsColumn.AllowFocus = false;
            this.TrnTime.Visible = true;
            this.TrnTime.VisibleIndex = 1;
            this.TrnTime.Width = 80;
            // 
            // GoldCcy
            // 
            this.GoldCcy.Caption = "Loại";
            this.GoldCcy.FieldName = "GoldCcy";
            this.GoldCcy.Name = "GoldCcy";
            this.GoldCcy.OptionsColumn.AllowEdit = false;
            this.GoldCcy.OptionsColumn.AllowFocus = false;
            this.GoldCcy.Visible = true;
            this.GoldCcy.VisibleIndex = 6;
            this.GoldCcy.Width = 90;
            // 
            // txtSoTien
            // 
            this.txtSoTien.AutoHeight = false;
            this.txtSoTien.DisplayFormat.FormatString = "{0:#,##0.##}";
            this.txtSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoTien.EditFormat.FormatString = "{0:#,##0.##}";
            this.txtSoTien.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoTien.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoTien.Mask.UseMaskAsDisplayFormat = true;
            this.txtSoTien.Name = "txtSoTien";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.AutoHeight = false;
            this.txtGhiChu.Name = "txtGhiChu";
            // 
            // cboGoldCcy
            // 
            this.cboGoldCcy.AutoHeight = false;
            this.cboGoldCcy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGoldCcy.Name = "cboGoldCcy";
            // 
            // cboChon
            // 
            this.cboChon.AutoHeight = false;
            this.cboChon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboChon.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cboChon.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "False", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "True", 1)});
            this.cboChon.Name = "cboChon";
            // 
            // rtxtDiamondWeight
            // 
            this.rtxtDiamondWeight.AutoHeight = false;
            this.rtxtDiamondWeight.Mask.EditMask = "n2";
            this.rtxtDiamondWeight.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rtxtDiamondWeight.Name = "rtxtDiamondWeight";
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Công nợ khách hàng", "IOKH", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Thu chi khác", "IO", -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1320, 518);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.Control = this.gridControl;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(1318, 447);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.dtpTuNgay;
            this.layoutControlItem3.CustomizationFormText = "Từ ngày";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(250, 36);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(250, 36);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(250, 36);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Từ ngày";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 19);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.dtpDenNgay;
            this.layoutControlItem4.CustomizationFormText = "Đến ngày";
            this.layoutControlItem4.Location = new System.Drawing.Point(250, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(250, 36);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(250, 36);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Size = new System.Drawing.Size(250, 36);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Đến ngày";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(70, 19);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(500, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem2.Size = new System.Drawing.Size(818, 36);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.btnIn;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(1195, 483);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(123, 33);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 483);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(1195, 33);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink2});
            // 
            // printableComponentLink2
            // 
            this.printableComponentLink2.Component = this.gridControl;
            this.printableComponentLink2.Landscape = true;
            this.printableComponentLink2.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "",
                "Báo cáo thu chi giữa các quầy",
                ""}, new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near), null);
            this.printableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink2.PrintingSystemBase = this.printingSystem1;
            // 
            // frmQueryThuChiGiuaCacQuay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 518);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmQueryThuChiGiuaCacQuay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách thu chi giữa các quầy";
            this.Load += new System.EventHandler(this.frmTillInOutList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGoldCcy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtDiamondWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDanhSach;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cboGoldCcy;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtSoTien;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtDiamondWeight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cboChon;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dtpTuNgay;
        private DevExpress.XtraEditors.DateEdit dtpDenNgay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn FromTillName;
        private DevExpress.XtraGrid.Columns.GridColumn ToTillName;
        private DevExpress.XtraGrid.Columns.GridColumn TrnDate;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCcyDesc;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraGrid.Columns.GridColumn Amount_Diamond;
        private DevExpress.XtraGrid.Columns.GridColumn TrnDesc;
        private DevExpress.XtraGrid.Columns.GridColumn TrnTime;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCcy;
        private DevExpress.XtraGrid.Columns.GridColumn TrnID;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink2;
    }
}