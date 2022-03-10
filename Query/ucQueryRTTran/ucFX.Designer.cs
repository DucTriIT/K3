namespace GoldRT.Query.ucQueryRTTran
{
    partial class ucFX
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TrnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SellBuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rcboSellBuy = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.Ccy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.XRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fcy_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lcy_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboSellBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.Caption = "Status";
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            // 
            // IsPaid
            // 
            this.IsPaid.Caption = "IsPaid";
            this.IsPaid.FieldName = "IsPaid";
            this.IsPaid.Name = "IsPaid";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDanhSach);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(975, 569);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDanhSach
            // 
            this.grdDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDanhSach.EmbeddedNavigator.Name = "";
            this.grdDanhSach.Location = new System.Drawing.Point(7, 7);
            this.grdDanhSach.MainView = this.grvDanhSach;
            this.grdDanhSach.Name = "grdDanhSach";
            this.grdDanhSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rcboSellBuy});
            this.grdDanhSach.Size = new System.Drawing.Size(962, 556);
            this.grdDanhSach.TabIndex = 25;
            this.grdDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.grvDanhSach.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.grvDanhSach.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.DetailTip.Options.UseFont = true;
            this.grvDanhSach.Appearance.Empty.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.Empty.Options.UseFont = true;
            this.grvDanhSach.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.EvenRow.Options.UseFont = true;
            this.grvDanhSach.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.FilterCloseButton.Options.UseFont = true;
            this.grvDanhSach.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.FilterPanel.Options.UseFont = true;
            this.grvDanhSach.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.FixedLine.Options.UseFont = true;
            this.grvDanhSach.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDanhSach.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDanhSach.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grvDanhSach.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grvDanhSach.Appearance.FooterPanel.Options.UseFont = true;
            this.grvDanhSach.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvDanhSach.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.GroupButton.Options.UseFont = true;
            this.grvDanhSach.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grvDanhSach.Appearance.GroupFooter.Options.UseFont = true;
            this.grvDanhSach.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.GroupPanel.Options.UseFont = true;
            this.grvDanhSach.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.GroupRow.Options.UseFont = true;
            this.grvDanhSach.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDanhSach.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDanhSach.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.HorzLine.Options.UseFont = true;
            this.grvDanhSach.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.OddRow.Options.UseFont = true;
            this.grvDanhSach.Appearance.Preview.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.Preview.Options.UseFont = true;
            this.grvDanhSach.Appearance.Row.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.Row.Options.UseFont = true;
            this.grvDanhSach.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.RowSeparator.Options.UseFont = true;
            this.grvDanhSach.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDanhSach.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.TopNewRow.Options.UseFont = true;
            this.grvDanhSach.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 10F);
            this.grvDanhSach.Appearance.VertLine.Options.UseFont = true;
            this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TrnID,
            this.TrnDate,
            this.TrnTime,
            this.CustName,
            this.SellBuy,
            this.Ccy,
            this.XRate,
            this.Fcy_Amount,
            this.Lcy_Amount,
            this.StatusName,
            this.IsPaid,
            this.Status,
            this.FullName});
            this.grvDanhSach.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.Status;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "C";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Bisque;
            styleFormatCondition2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.Appearance.Options.UseFont = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.IsPaid;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "Y";
            this.grvDanhSach.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.grvDanhSach.GridControl = this.grdDanhSach;
            this.grvDanhSach.Name = "grvDanhSach";
            this.grvDanhSach.OptionsBehavior.Editable = false;
            this.grvDanhSach.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvDanhSach.OptionsView.ShowFooter = true;
            this.grvDanhSach.OptionsView.ShowGroupPanel = false;
            // 
            // TrnID
            // 
            this.TrnID.Caption = "TrnID";
            this.TrnID.FieldName = "TrnID";
            this.TrnID.Name = "TrnID";
            // 
            // TrnDate
            // 
            this.TrnDate.Caption = "Ngày";
            this.TrnDate.FieldName = "TrnDate";
            this.TrnDate.Name = "TrnDate";
            this.TrnDate.Visible = true;
            this.TrnDate.VisibleIndex = 0;
            this.TrnDate.Width = 119;
            // 
            // TrnTime
            // 
            this.TrnTime.Caption = "Giờ";
            this.TrnTime.FieldName = "TrnTime";
            this.TrnTime.Name = "TrnTime";
            this.TrnTime.Visible = true;
            this.TrnTime.VisibleIndex = 1;
            this.TrnTime.Width = 55;
            // 
            // CustName
            // 
            this.CustName.Caption = "Khách hàng";
            this.CustName.FieldName = "CustName";
            this.CustName.Name = "CustName";
            this.CustName.Visible = true;
            this.CustName.VisibleIndex = 2;
            this.CustName.Width = 134;
            // 
            // SellBuy
            // 
            this.SellBuy.Caption = "Mua/Bán";
            this.SellBuy.ColumnEdit = this.rcboSellBuy;
            this.SellBuy.FieldName = "SellBuy";
            this.SellBuy.Name = "SellBuy";
            this.SellBuy.OptionsColumn.AllowEdit = false;
            this.SellBuy.OptionsColumn.AllowFocus = false;
            this.SellBuy.Visible = true;
            this.SellBuy.VisibleIndex = 3;
            this.SellBuy.Width = 106;
            // 
            // rcboSellBuy
            // 
            this.rcboSellBuy.AutoHeight = false;
            this.rcboSellBuy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rcboSellBuy.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Mua", "B", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Bán", "S", -1)});
            this.rcboSellBuy.Name = "rcboSellBuy";
            // 
            // Ccy
            // 
            this.Ccy.Caption = "Tên hàng";
            this.Ccy.FieldName = "Ccy";
            this.Ccy.Name = "Ccy";
            this.Ccy.Visible = true;
            this.Ccy.VisibleIndex = 4;
            this.Ccy.Width = 102;
            // 
            // XRate
            // 
            this.XRate.Caption = "Giá";
            this.XRate.DisplayFormat.FormatString = "{0:#,##0}";
            this.XRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.XRate.FieldName = "XRate";
            this.XRate.Name = "XRate";
            this.XRate.Visible = true;
            this.XRate.VisibleIndex = 5;
            this.XRate.Width = 104;
            // 
            // Fcy_Amount
            // 
            this.Fcy_Amount.Caption = "Số lượng";
            this.Fcy_Amount.DisplayFormat.FormatString = "{0:#,##0}";
            this.Fcy_Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Fcy_Amount.FieldName = "Fcy_Amount";
            this.Fcy_Amount.Name = "Fcy_Amount";
            this.Fcy_Amount.SummaryItem.DisplayFormat = "{0:#,##0}";
            this.Fcy_Amount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.Fcy_Amount.Visible = true;
            this.Fcy_Amount.VisibleIndex = 6;
            this.Fcy_Amount.Width = 101;
            // 
            // Lcy_Amount
            // 
            this.Lcy_Amount.Caption = "Thành tiền";
            this.Lcy_Amount.DisplayFormat.FormatString = "{0:#,##0}";
            this.Lcy_Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Lcy_Amount.FieldName = "Lcy_Amount";
            this.Lcy_Amount.Name = "Lcy_Amount";
            this.Lcy_Amount.SummaryItem.DisplayFormat = "{0:#,##0}";
            this.Lcy_Amount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.Lcy_Amount.Visible = true;
            this.Lcy_Amount.VisibleIndex = 7;
            this.Lcy_Amount.Width = 158;
            // 
            // StatusName
            // 
            this.StatusName.Caption = "Tình trạng";
            this.StatusName.FieldName = "StatusName";
            this.StatusName.Name = "StatusName";
            this.StatusName.Visible = true;
            this.StatusName.VisibleIndex = 8;
            this.StatusName.Width = 129;
            // 
            // FullName
            // 
            this.FullName.Caption = "Người thực hiện";
            this.FullName.FieldName = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 9;
            this.FullName.Width = 158;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(975, 569);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.Control = this.grdDanhSach;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(973, 567);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // ucFX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucFX";
            this.Size = new System.Drawing.Size(975, 569);
            this.Load += new System.EventHandler(this.ucCRT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboSellBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        public DevExpress.XtraGrid.GridControl grdDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn TrnID;
        private DevExpress.XtraGrid.Columns.GridColumn CustName;
        private DevExpress.XtraGrid.Columns.GridColumn StatusName;
        private DevExpress.XtraGrid.Columns.GridColumn IsPaid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn TrnDate;
        private DevExpress.XtraGrid.Columns.GridColumn SellBuy;
        private DevExpress.XtraGrid.Columns.GridColumn Ccy;
        private DevExpress.XtraGrid.Columns.GridColumn XRate;
        private DevExpress.XtraGrid.Columns.GridColumn Fcy_Amount;
        private DevExpress.XtraGrid.Columns.GridColumn Lcy_Amount;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rcboSellBuy;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn TrnTime;
    }
}
