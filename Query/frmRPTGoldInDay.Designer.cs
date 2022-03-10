namespace GoldRT
{
    partial class frmRPTGoldInDay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPTGoldInDay));
            this.grdGold = new DevExpress.XtraGrid.GridControl();
            this.grvGold = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GoldCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total_Weight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiamondWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Dirty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldWeightChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.txtCash = new DevExpress.XtraEditors.TextEdit();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCash.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // grdGold
            // 
            this.grdGold.EmbeddedNavigator.Name = "";
            this.grdGold.Location = new System.Drawing.Point(8, 63);
            this.grdGold.MainView = this.grvGold;
            this.grdGold.Name = "grdGold";
            this.grdGold.Size = new System.Drawing.Size(877, 507);
            this.grdGold.TabIndex = 8;
            this.grdGold.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGold});
            // 
            // grvGold
            // 
            this.grvGold.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvGold.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.grvGold.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.grvGold.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.DetailTip.Options.UseFont = true;
            this.grvGold.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.Empty.Options.UseFont = true;
            this.grvGold.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.EvenRow.Options.UseFont = true;
            this.grvGold.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.FilterCloseButton.Options.UseFont = true;
            this.grvGold.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.FilterPanel.Options.UseFont = true;
            this.grvGold.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.FixedLine.Options.UseFont = true;
            this.grvGold.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGold.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGold.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.FooterPanel.Options.UseFont = true;
            this.grvGold.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.GroupButton.Options.UseFont = true;
            this.grvGold.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.GroupFooter.Options.UseFont = true;
            this.grvGold.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.GroupPanel.Options.UseFont = true;
            this.grvGold.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.GroupRow.Options.UseFont = true;
            this.grvGold.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGold.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGold.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.HorzLine.Options.UseFont = true;
            this.grvGold.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.OddRow.Options.UseFont = true;
            this.grvGold.Appearance.Preview.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.Preview.Options.UseFont = true;
            this.grvGold.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.Row.Options.UseFont = true;
            this.grvGold.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.RowSeparator.Options.UseFont = true;
            this.grvGold.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGold.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.TopNewRow.Options.UseFont = true;
            this.grvGold.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grvGold.Appearance.VertLine.Options.UseFont = true;
            this.grvGold.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GoldCode,
            this.Total_Weight,
            this.DiamondWeight,
            this.Dirty,
            this.GoldWeight,
            this.GoldWeightChange});
            this.grvGold.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "C";
            this.grvGold.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.grvGold.GridControl = this.grdGold;
            this.grvGold.Name = "grvGold";
            this.grvGold.OptionsBehavior.Editable = false;
            this.grvGold.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvGold.OptionsView.ShowGroupPanel = false;
            // 
            // GoldCode
            // 
            this.GoldCode.Caption = "Loại vàng";
            this.GoldCode.FieldName = "GoldDesc";
            this.GoldCode.Name = "GoldCode";
            this.GoldCode.Visible = true;
            this.GoldCode.VisibleIndex = 0;
            this.GoldCode.Width = 87;
            // 
            // Total_Weight
            // 
            this.Total_Weight.Caption = "TL luôn hột/dơ";
            this.Total_Weight.FieldName = "Total_Weight";
            this.Total_Weight.Name = "Total_Weight";
            this.Total_Weight.Tag = "1";
            this.Total_Weight.Visible = true;
            this.Total_Weight.VisibleIndex = 1;
            // 
            // DiamondWeight
            // 
            this.DiamondWeight.Caption = "TL hột";
            this.DiamondWeight.FieldName = "DiamondWeight";
            this.DiamondWeight.Name = "DiamondWeight";
            this.DiamondWeight.Tag = "1";
            this.DiamondWeight.Visible = true;
            this.DiamondWeight.VisibleIndex = 2;
            // 
            // Dirty
            // 
            this.Dirty.Caption = "Dơ";
            this.Dirty.FieldName = "Dirty";
            this.Dirty.Name = "Dirty";
            this.Dirty.Tag = "1";
            this.Dirty.Visible = true;
            this.Dirty.VisibleIndex = 3;
            // 
            // GoldWeight
            // 
            this.GoldWeight.Caption = "TL vàng trước qui đổi";
            this.GoldWeight.FieldName = "GoldWeight";
            this.GoldWeight.Name = "GoldWeight";
            this.GoldWeight.Tag = "1";
            this.GoldWeight.Visible = true;
            this.GoldWeight.VisibleIndex = 4;
            this.GoldWeight.Width = 120;
            // 
            // GoldWeightChange
            // 
            this.GoldWeightChange.Caption = "TL vàng sau qui đổi";
            this.GoldWeightChange.FieldName = "GoldWeightChange";
            this.GoldWeightChange.Name = "GoldWeightChange";
            this.GoldWeightChange.Tag = "1";
            this.GoldWeightChange.Visible = true;
            this.GoldWeightChange.VisibleIndex = 5;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageIndex = 0;
            this.btnThoat.ImageList = this.imageCollection;
            this.btnThoat.Location = new System.Drawing.Point(794, 578);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(94, 27);
            this.btnThoat.StyleController = this.layoutControl1;
            this.btnThoat.TabIndex = 26;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.dtpDate);
            this.layoutControl1.Controls.Add(this.txtCash);
            this.layoutControl1.Controls.Add(this.btnThoat);
            this.layoutControl1.Controls.Add(this.btnView);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.grdGold);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(892, 609);
            this.layoutControl1.TabIndex = 31;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(346, 581);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 18);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "(VND)";
            this.labelControl1.Visible = false;
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = null;
            this.dtpDate.Location = new System.Drawing.Point(84, 5);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Properties.Appearance.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDropDownHeaderHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDropDownHighlight.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpDate.Size = new System.Drawing.Size(110, 25);
            this.dtpDate.StyleController = this.layoutControl1;
            this.dtpDate.TabIndex = 30;
            // 
            // txtCash
            // 
            this.txtCash.EditValue = "0";
            this.txtCash.Location = new System.Drawing.Point(146, 578);
            this.txtCash.Name = "txtCash";
            this.txtCash.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.Properties.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.txtCash.Properties.Appearance.Options.UseFont = true;
            this.txtCash.Properties.Appearance.Options.UseForeColor = true;
            this.txtCash.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCash.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCash.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCash.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtCash.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCash.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtCash.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCash.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtCash.Properties.Mask.EditMask = "n0";
            this.txtCash.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCash.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCash.Size = new System.Drawing.Size(192, 25);
            this.txtCash.StyleController = this.layoutControl1;
            this.txtCash.TabIndex = 29;
            this.txtCash.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Appearance.Options.UseFont = true;
            this.btnView.ImageIndex = 7;
            this.btnView.ImageList = this.imageCollection;
            this.btnView.Location = new System.Drawing.Point(199, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(92, 27);
            this.btnView.StyleController = this.layoutControl1;
            this.btnView.TabIndex = 25;
            this.btnView.Text = "&Xem";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ImageIndex = 2;
            this.btnPrint.ImageList = this.imageCollection;
            this.btnPrint.Location = new System.Drawing.Point(296, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 27);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 27;
            this.btnPrint.Text = "&In";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem2,
            this.layoutControlGroup2,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(892, 609);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.dtpDate;
            this.layoutControlItem1.CustomizationFormText = "Chọn ngày";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(194, 32);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(194, 32);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(194, 32);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "Chọn ngày";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(74, 20);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.Control = this.btnView;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(194, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(97, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(97, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(97, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.Control = this.btnPrint;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(291, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(92, 32);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(92, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(92, 32);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
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
            this.emptySpaceItem1.Location = new System.Drawing.Point(383, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem1.Size = new System.Drawing.Size(505, 32);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AllowHotTrack = false;
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txtCash;
            this.layoutControlItem5.CustomizationFormText = "Tiền mặt trong ngày";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 573);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 32);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(196, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Size = new System.Drawing.Size(338, 32);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Text = "Tiền mặt trong ngày";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(136, 20);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AllowHotTrack = false;
            this.layoutControlItem6.Control = this.btnThoat;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(789, 573);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(99, 32);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(99, 32);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.Size = new System.Drawing.Size(99, 32);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(393, 573);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem2.Size = new System.Drawing.Size(396, 32);
            this.emptySpaceItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup2.CustomizationFormText = "Dẻ thu trong ngày";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 32);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(888, 541);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Text = "Dẻ thu trong ngày";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.grdGold;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(111, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(882, 512);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AllowHotTrack = false;
            this.layoutControlItem7.Control = this.labelControl1;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(338, 573);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem7.Size = new System.Drawing.Size(55, 32);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // frmRPTGoldInDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 609);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmRPTGoldInDay";
            this.Text = "Dẻ, tiền mặt trong ngày";
            this.Load += new System.EventHandler(this.frmRPTGoldInDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCash.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdGold;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGold;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCode;
        private DevExpress.XtraGrid.Columns.GridColumn DiamondWeight;
        private DevExpress.XtraGrid.Columns.GridColumn GoldWeight;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.TextEdit txtCash;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn Total_Weight;
        private DevExpress.XtraGrid.Columns.GridColumn Dirty;
        private DevExpress.XtraGrid.Columns.GridColumn GoldWeightChange;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}