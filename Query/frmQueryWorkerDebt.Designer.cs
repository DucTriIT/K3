namespace GoldRT
{
    partial class frmQueryWorkerDebt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryWorkerDebt));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.txtWorkerName = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grdDebt = new DevExpress.XtraGrid.GridControl();
            this.grvDebt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.WorkerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoldDesc_debt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoldWeight_Debt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDebt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDebt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.txtWorkerName);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.grdDebt);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(511, 406);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.ImageIndex = 7;
            this.btnSearch.ImageList = this.imageCollection;
            this.btnSearch.Location = new System.Drawing.Point(308, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 27);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // txtWorkerName
            // 
            this.txtWorkerName.Location = new System.Drawing.Point(63, 5);
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtWorkerName.Properties.Appearance.Options.UseFont = true;
            this.txtWorkerName.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.txtWorkerName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtWorkerName.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.txtWorkerName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtWorkerName.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.txtWorkerName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtWorkerName.Size = new System.Drawing.Size(240, 25);
            this.txtWorkerName.StyleController = this.layoutControl1;
            this.txtWorkerName.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageIndex = 0;
            this.btnClose.ImageList = this.imageCollection;
            this.btnClose.Location = new System.Drawing.Point(428, 375);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 27);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdDebt
            // 
            this.grdDebt.EmbeddedNavigator.Name = "";
            this.grdDebt.Location = new System.Drawing.Point(5, 37);
            this.grdDebt.MainView = this.grvDebt;
            this.grdDebt.Name = "grdDebt";
            this.grdDebt.Size = new System.Drawing.Size(502, 333);
            this.grdDebt.TabIndex = 18;
            this.grdDebt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDebt});
            // 
            // grvDebt
            // 
            this.grvDebt.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvDebt.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.grvDebt.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.grvDebt.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.DetailTip.Options.UseFont = true;
            this.grvDebt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.Empty.Options.UseFont = true;
            this.grvDebt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.EvenRow.Options.UseFont = true;
            this.grvDebt.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.FilterCloseButton.Options.UseFont = true;
            this.grvDebt.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.FilterPanel.Options.UseFont = true;
            this.grvDebt.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.FixedLine.Options.UseFont = true;
            this.grvDebt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDebt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDebt.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDebt.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.GroupButton.Options.UseFont = true;
            this.grvDebt.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.GroupFooter.Options.UseFont = true;
            this.grvDebt.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.GroupPanel.Options.UseFont = true;
            this.grvDebt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.GroupRow.Options.UseFont = true;
            this.grvDebt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDebt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDebt.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.HorzLine.Options.UseFont = true;
            this.grvDebt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.OddRow.Options.UseFont = true;
            this.grvDebt.Appearance.Preview.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.Preview.Options.UseFont = true;
            this.grvDebt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.Row.Options.UseFont = true;
            this.grvDebt.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.RowSeparator.Options.UseFont = true;
            this.grvDebt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDebt.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.TopNewRow.Options.UseFont = true;
            this.grvDebt.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 12F);
            this.grvDebt.Appearance.VertLine.Options.UseFont = true;
            this.grvDebt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.WorkerName,
            this.colGoldDesc_debt,
            this.colGoldWeight_Debt});
            this.grvDebt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "C";
            this.grvDebt.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.grvDebt.GridControl = this.grdDebt;
            this.grvDebt.Name = "grvDebt";
            this.grvDebt.NewItemRowText = "Click vào đây để nhập vàng cũ";
            this.grvDebt.OptionsBehavior.Editable = false;
            this.grvDebt.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvDebt.OptionsView.ShowFooter = true;
            this.grvDebt.OptionsView.ShowGroupPanel = false;
            // 
            // WorkerName
            // 
            this.WorkerName.Caption = "Tên thợ";
            this.WorkerName.FieldName = "WorkerName";
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.Visible = true;
            this.WorkerName.VisibleIndex = 0;
            // 
            // colGoldDesc_debt
            // 
            this.colGoldDesc_debt.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGoldDesc_debt.AppearanceCell.Options.UseFont = true;
            this.colGoldDesc_debt.AppearanceHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.colGoldDesc_debt.AppearanceHeader.Options.UseFont = true;
            this.colGoldDesc_debt.Caption = "Loại vàng";
            this.colGoldDesc_debt.FieldName = "GoldDesc";
            this.colGoldDesc_debt.Name = "colGoldDesc_debt";
            this.colGoldDesc_debt.Visible = true;
            this.colGoldDesc_debt.VisibleIndex = 1;
            // 
            // colGoldWeight_Debt
            // 
            this.colGoldWeight_Debt.Caption = "Nợ";
            this.colGoldWeight_Debt.DisplayFormat.FormatString = "#,##0.##";
            this.colGoldWeight_Debt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGoldWeight_Debt.FieldName = "Debt_GoldWeight";
            this.colGoldWeight_Debt.Name = "colGoldWeight_Debt";
            this.colGoldWeight_Debt.SummaryItem.DisplayFormat = "{0:#,##0.##}";
            this.colGoldWeight_Debt.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colGoldWeight_Debt.Tag = "1";
            this.colGoldWeight_Debt.Visible = true;
            this.colGoldWeight_Debt.VisibleIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(511, 406);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.Control = this.grdDebt;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(507, 338);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(423, 370);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(84, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(84, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(84, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 370);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.emptySpaceItem1.Size = new System.Drawing.Size(423, 32);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtWorkerName;
            this.layoutControlItem3.CustomizationFormText = "Tên thợ";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(303, 32);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "Tên thợ";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(53, 20);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.btnSearch;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(303, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(102, 32);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(102, 32);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(102, 32);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(405, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem2.Size = new System.Drawing.Size(102, 32);
            this.emptySpaceItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmQueryWorkerDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 406);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmQueryWorkerDebt";
            this.Text = "Tra cứu nợ thợ";
            this.Load += new System.EventHandler(this.frmQueryWorkerDebt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDebt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDebt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdDebt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDebt;
        private DevExpress.XtraGrid.Columns.GridColumn colGoldDesc_debt;
        private DevExpress.XtraGrid.Columns.GridColumn colGoldWeight_Debt;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtWorkerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn WorkerName;
    }
}