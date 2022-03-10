namespace GoldRT
{
    partial class frmPOProductLst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOProductLst));
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdProductPO = new DevExpress.XtraGrid.GridControl();
            this.grvProductPO = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductPOID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PODate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total_Weight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total_GoldWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total_TaskPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dtpFromDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.cboGoldType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dtpToDate = new DevExpress.XtraEditors.DateEdit();
            this.txtCustName = new DevExpress.XtraEditors.TextEdit();
            this.btnChoose = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.POTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProductPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGoldType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.Caption = "Status";
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.Control = this.grdProductPO;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(836, 321);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // grdProductPO
            // 
            this.grdProductPO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdProductPO.EmbeddedNavigator.Name = "";
            this.grdProductPO.Location = new System.Drawing.Point(8, 152);
            this.grdProductPO.MainView = this.grvProductPO;
            this.grdProductPO.Name = "grdProductPO";
            this.grdProductPO.Size = new System.Drawing.Size(831, 316);
            this.grdProductPO.TabIndex = 7;
            this.grdProductPO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProductPO});
            // 
            // grvProductPO
            // 
            this.grvProductPO.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvProductPO.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.grvProductPO.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.grvProductPO.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.DetailTip.Options.UseFont = true;
            this.grvProductPO.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.Empty.Options.UseFont = true;
            this.grvProductPO.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.EvenRow.Options.UseFont = true;
            this.grvProductPO.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.FilterCloseButton.Options.UseFont = true;
            this.grvProductPO.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.FilterPanel.Options.UseFont = true;
            this.grvProductPO.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.FixedLine.Options.UseFont = true;
            this.grvProductPO.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.FocusedCell.Options.UseFont = true;
            this.grvProductPO.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.FocusedRow.Options.UseFont = true;
            this.grvProductPO.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.FooterPanel.Options.UseFont = true;
            this.grvProductPO.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.GroupButton.Options.UseFont = true;
            this.grvProductPO.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.GroupFooter.Options.UseFont = true;
            this.grvProductPO.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.GroupPanel.Options.UseFont = true;
            this.grvProductPO.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.GroupRow.Options.UseFont = true;
            this.grvProductPO.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProductPO.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvProductPO.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.HorzLine.Options.UseFont = true;
            this.grvProductPO.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.OddRow.Options.UseFont = true;
            this.grvProductPO.Appearance.Preview.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.Preview.Options.UseFont = true;
            this.grvProductPO.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.Row.Options.UseFont = true;
            this.grvProductPO.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.RowSeparator.Options.UseFont = true;
            this.grvProductPO.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.SelectedRow.Options.UseFont = true;
            this.grvProductPO.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.TopNewRow.Options.UseFont = true;
            this.grvProductPO.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grvProductPO.Appearance.VertLine.Options.UseFont = true;
            this.grvProductPO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductPOID,
            this.CustID,
            this.PODate,
            this.GoldCode,
            this.GoldDesc,
            this.CustName,
            this.Total_Weight,
            this.Total_GoldWeight,
            this.Total_TaskPrice,
            this.Status,
            this.StatusName,
            this.UserName,
            this.POTime});
            this.grvProductPO.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.Status;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "C";
            this.grvProductPO.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.grvProductPO.GridControl = this.grdProductPO;
            this.grvProductPO.Name = "grvProductPO";
            this.grvProductPO.OptionsBehavior.Editable = false;
            this.grvProductPO.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvProductPO.OptionsView.ShowGroupPanel = false;
            this.grvProductPO.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.PODate, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvProductPO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvProductPO_MouseDown);
            // 
            // ProductPOID
            // 
            this.ProductPOID.Caption = "ProductPOID";
            this.ProductPOID.FieldName = "ProductPOID";
            this.ProductPOID.Name = "ProductPOID";
            // 
            // CustID
            // 
            this.CustID.Caption = "CustID";
            this.CustID.FieldName = "CustID";
            this.CustID.Name = "CustID";
            // 
            // PODate
            // 
            this.PODate.Caption = "Ngày";
            this.PODate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.PODate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.PODate.FieldName = "PODate";
            this.PODate.Name = "PODate";
            this.PODate.Visible = true;
            this.PODate.VisibleIndex = 0;
            this.PODate.Width = 108;
            // 
            // GoldCode
            // 
            this.GoldCode.Caption = "GoldCode";
            this.GoldCode.FieldName = "GoldCode";
            this.GoldCode.Name = "GoldCode";
            this.GoldCode.Width = 87;
            // 
            // GoldDesc
            // 
            this.GoldDesc.Caption = "Loại vàng";
            this.GoldDesc.FieldName = "GoldDesc";
            this.GoldDesc.Name = "GoldDesc";
            // 
            // CustName
            // 
            this.CustName.Caption = "Khách hàng";
            this.CustName.FieldName = "CustName";
            this.CustName.Name = "CustName";
            this.CustName.Visible = true;
            this.CustName.VisibleIndex = 2;
            this.CustName.Width = 220;
            // 
            // Total_Weight
            // 
            this.Total_Weight.Caption = "TL luôn hột";
            this.Total_Weight.FieldName = "Total_Weight";
            this.Total_Weight.Name = "Total_Weight";
            this.Total_Weight.Width = 125;
            // 
            // Total_GoldWeight
            // 
            this.Total_GoldWeight.Caption = "TL vàng";
            this.Total_GoldWeight.FieldName = "Total_GoldWeight";
            this.Total_GoldWeight.Name = "Total_GoldWeight";
            // 
            // Total_TaskPrice
            // 
            this.Total_TaskPrice.Caption = "Giá công";
            this.Total_TaskPrice.FieldName = "Total_TaskPrice";
            this.Total_TaskPrice.Name = "Total_TaskPrice";
            this.Total_TaskPrice.Visible = true;
            this.Total_TaskPrice.VisibleIndex = 3;
            this.Total_TaskPrice.Width = 145;
            // 
            // StatusName
            // 
            this.StatusName.Caption = "Tình trạng";
            this.StatusName.FieldName = "StatusName";
            this.StatusName.Name = "StatusName";
            this.StatusName.Visible = true;
            this.StatusName.VisibleIndex = 4;
            this.StatusName.Width = 130;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 471);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(100, 23);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 1, 2);
            this.emptySpaceItem1.Size = new System.Drawing.Size(750, 32);
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
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 121);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(842, 350);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Text = "Danh sách toa hàng";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.CustomizationFormText = "Thông tin tìm kiếm";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem8,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.layoutControlItem7,
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup3.Size = new System.Drawing.Size(842, 121);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup3.Text = "Thông tin tìm kiếm";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AllowHotTrack = false;
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.dtpFromDate;
            this.layoutControlItem6.CustomizationFormText = "Từ ngày";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(229, 30);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(229, 30);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.Size = new System.Drawing.Size(229, 30);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem6.Text = "Từ ngày";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(109, 20);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.EditValue = null;
            this.dtpFromDate.Location = new System.Drawing.Point(122, 31);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Properties.Appearance.Options.UseFont = true;
            this.dtpFromDate.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpFromDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpFromDate.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtpFromDate.Properties.AppearanceDropDownHeaderHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dtpFromDate.Properties.AppearanceDropDownHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dtpFromDate.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpFromDate.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtpFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpFromDate.Size = new System.Drawing.Size(110, 25);
            this.dtpFromDate.StyleController = this.layoutControl1;
            this.dtpFromDate.TabIndex = 20;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.cboGoldType);
            this.layoutControl1.Controls.Add(this.dtpFromDate);
            this.layoutControl1.Controls.Add(this.dtpToDate);
            this.layoutControl1.Controls.Add(this.txtCustName);
            this.layoutControl1.Controls.Add(this.grdProductPO);
            this.layoutControl1.Controls.Add(this.btnChoose);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(846, 507);
            this.layoutControl1.TabIndex = 19;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.ImageIndex = 7;
            this.btnSearch.ImageList = this.imageCollection;
            this.btnSearch.Location = new System.Drawing.Point(324, 91);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 27);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // cboGoldType
            // 
            this.cboGoldType.Location = new System.Drawing.Point(122, 61);
            this.cboGoldType.Name = "cboGoldType";
            this.cboGoldType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGoldType.Properties.Appearance.Options.UseFont = true;
            this.cboGoldType.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboGoldType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboGoldType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboGoldType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboGoldType.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboGoldType.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboGoldType.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboGoldType.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboGoldType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGoldType.Size = new System.Drawing.Size(297, 25);
            this.cboGoldType.StyleController = this.layoutControl1;
            this.cboGoldType.TabIndex = 21;
            // 
            // dtpToDate
            // 
            this.dtpToDate.EditValue = null;
            this.dtpToDate.Location = new System.Drawing.Point(538, 31);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Properties.Appearance.Options.UseFont = true;
            this.dtpToDate.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpToDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpToDate.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtpToDate.Properties.AppearanceDropDownHeaderHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dtpToDate.Properties.AppearanceDropDownHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dtpToDate.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpToDate.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtpToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpToDate.Size = new System.Drawing.Size(110, 25);
            this.dtpToDate.StyleController = this.layoutControl1;
            this.dtpToDate.TabIndex = 19;
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(538, 61);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCustName.Properties.Appearance.Options.UseFont = true;
            this.txtCustName.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCustName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtCustName.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCustName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtCustName.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCustName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtCustName.Size = new System.Drawing.Size(301, 25);
            this.txtCustName.StyleController = this.layoutControl1;
            this.txtCustName.TabIndex = 18;
            // 
            // btnChoose
            // 
            this.btnChoose.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnChoose.Appearance.Options.UseFont = true;
            this.btnChoose.ImageIndex = 4;
            this.btnChoose.ImageList = this.imageCollection;
            this.btnChoose.Location = new System.Drawing.Point(422, 90);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(84, 27);
            this.btnChoose.StyleController = this.layoutControl1;
            this.btnChoose.TabIndex = 17;
            this.btnChoose.Text = "Chọn";
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageIndex = 0;
            this.btnClose.ImageList = this.imageCollection;
            this.btnClose.Location = new System.Drawing.Point(755, 476);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(846, 507);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(750, 471);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(92, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(92, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(92, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AllowHotTrack = false;
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.dtpToDate;
            this.layoutControlItem5.CustomizationFormText = "Đến ngày";
            this.layoutControlItem5.Location = new System.Drawing.Point(416, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(229, 30);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(229, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Size = new System.Drawing.Size(229, 30);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Text = "Đến ngày";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(109, 20);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AllowHotTrack = false;
            this.layoutControlItem8.Control = this.btnSearch;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(316, 60);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Size = new System.Drawing.Size(100, 32);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 60);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 31);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(104, 31);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem2.Size = new System.Drawing.Size(316, 32);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(501, 60);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem3.Size = new System.Drawing.Size(335, 32);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(645, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem4.Size = new System.Drawing.Size(191, 30);
            this.emptySpaceItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(229, 0);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem5.Size = new System.Drawing.Size(187, 30);
            this.emptySpaceItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AllowHotTrack = false;
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.cboGoldType;
            this.layoutControlItem7.CustomizationFormText = "Loại vàng";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 30);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(169, 30);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.Size = new System.Drawing.Size(416, 30);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem7.Text = "Loại vàng";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(109, 20);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtCustName;
            this.layoutControlItem4.CustomizationFormText = "Tên khách hàng";
            this.layoutControlItem4.Location = new System.Drawing.Point(416, 30);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 30);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(169, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(420, 30);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "Tên khách hàng";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(109, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.Control = this.btnChoose;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(416, 60);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(85, 31);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(85, 31);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 1, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(85, 32);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // UserName
            // 
            this.UserName.Caption = "Nhân viên";
            this.UserName.FieldName = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 5;
            this.UserName.Width = 118;
            // 
            // POTime
            // 
            this.POTime.Caption = "Giờ";
            this.POTime.FieldName = "POTime";
            this.POTime.GroupFormat.FormatString = "hh:mm";
            this.POTime.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.POTime.Name = "POTime";
            this.POTime.Visible = true;
            this.POTime.VisibleIndex = 1;
            this.POTime.Width = 89;
            // 
            // frmPOProductLst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 507);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPOProductLst";
            this.ShowInTaskbar = false;
            this.Text = "Danh sách toa hàng";
            this.Load += new System.EventHandler(this.frmProductPOLst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProductPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGoldType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl grdProductPO;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProductPO;
        private DevExpress.XtraGrid.Columns.GridColumn ProductPOID;
        private DevExpress.XtraGrid.Columns.GridColumn CustID;
        private DevExpress.XtraGrid.Columns.GridColumn PODate;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCode;
        private DevExpress.XtraGrid.Columns.GridColumn GoldDesc;
        private DevExpress.XtraGrid.Columns.GridColumn CustName;
        private DevExpress.XtraGrid.Columns.GridColumn Total_Weight;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.DateEdit dtpFromDate;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cboGoldType;
        private DevExpress.XtraEditors.DateEdit dtpToDate;
        private DevExpress.XtraEditors.TextEdit txtCustName;
        private DevExpress.XtraEditors.SimpleButton btnChoose;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn Total_GoldWeight;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraGrid.Columns.GridColumn StatusName;
        private DevExpress.XtraGrid.Columns.GridColumn Total_TaskPrice;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn POTime;

    }
}