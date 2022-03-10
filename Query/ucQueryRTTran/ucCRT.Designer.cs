namespace GoldRT.Query.ucQueryRTTran
{
    partial class ucCRT
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
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldWei = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiamondWei = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaskPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Discount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PayAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PayCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SL = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Status";
            this.gridColumn2.FieldName = "Status";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 50;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "IsPaid";
            this.gridColumn10.FieldName = "IsPaid";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 48;
            // 
            // grdDanhSach
            // 
            this.grdDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDanhSach.EmbeddedNavigator.Name = "";
            this.grdDanhSach.Location = new System.Drawing.Point(0, 0);
            this.grdDanhSach.MainView = this.grvDanhSach;
            this.grdDanhSach.Name = "grdDanhSach";
            this.grdDanhSach.Size = new System.Drawing.Size(1045, 569);
            this.grdDanhSach.TabIndex = 26;
            this.grdDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            this.grdDanhSach.Click += new System.EventHandler(this.grdDanhSach_Click);
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
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5,
            this.TrnTime,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn8,
            this.Type,
            this.GoldCode,
            this.GoldWei,
            this.DiamondWei,
            this.TaskPrice,
            this.Discount,
            this.PayAmount,
            this.gridColumn9,
            this.gridColumn10,
            this.FullName,
            this.gridColumn4,
            this.PayCard,
            this.SL});
            this.grvDanhSach.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.gridColumn2;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "C";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Bisque;
            styleFormatCondition2.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.Appearance.Options.UseFont = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.gridColumn10;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "Y";
            this.grvDanhSach.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.grvDanhSach.GridControl = this.grdDanhSach;
            this.grvDanhSach.GroupCount = 1;
            this.grvDanhSach.GroupFormat = "{0} [#image]{1} {2}";
            this.grvDanhSach.Name = "grvDanhSach";
            this.grvDanhSach.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvDanhSach.OptionsBehavior.Editable = false;
            this.grvDanhSach.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvDanhSach.OptionsView.AllowCellMerge = true;
            this.grvDanhSach.OptionsView.ColumnAutoWidth = false;
            this.grvDanhSach.OptionsView.ShowFooter = true;
            this.grvDanhSach.OptionsView.ShowGroupPanel = false;
            this.grvDanhSach.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn5, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvDanhSach.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grdDanhSach_CustomSummaryCalculate);
            this.grvDanhSach.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvDanhSach_MouseDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "TrnID";
            this.gridColumn1.FieldName = "TrnID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 42;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "CustID";
            this.gridColumn3.FieldName = "CustID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 51;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ngày";
            this.gridColumn5.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "TrnDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.SummaryItem.DisplayFormat = "Số HĐ:{0}";
            this.gridColumn5.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 55;
            // 
            // TrnTime
            // 
            this.TrnTime.Caption = "Giờ";
            this.TrnTime.FieldName = "TrnTime";
            this.TrnTime.Name = "TrnTime";
            this.TrnTime.SummaryItem.DisplayFormat = "{0:#,##0} món";
            this.TrnTime.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.TrnTime.Visible = true;
            this.TrnTime.VisibleIndex = 1;
            this.TrnTime.Width = 34;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Khách hàng";
            this.gridColumn7.FieldName = "CustName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 81;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số HĐ";
            this.gridColumn6.FieldName = "BillCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 54;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Mã hàng";
            this.gridColumn8.FieldName = "ProductCode";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 62;
            // 
            // Type
            // 
            this.Type.Caption = "Vàng G/dịch";
            this.Type.FieldName = "Type";
            this.Type.Name = "Type";
            this.Type.SummaryItem.DisplayFormat = "Vàng mới:{0:#,##0.####} ";
            this.Type.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.Type.Visible = true;
            this.Type.VisibleIndex = 5;
            this.Type.Width = 84;
            // 
            // GoldCode
            // 
            this.GoldCode.Caption = "Loại vàng";
            this.GoldCode.FieldName = "GoldCode";
            this.GoldCode.Name = "GoldCode";
            this.GoldCode.SummaryItem.DisplayFormat = "Vàng cũ:{0:#,##0.##}";
            this.GoldCode.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.GoldCode.Visible = true;
            this.GoldCode.VisibleIndex = 6;
            this.GoldCode.Width = 81;
            // 
            // GoldWei
            // 
            this.GoldWei.Caption = "TL vàng";
            this.GoldWei.DisplayFormat.FormatString = "{0:#,##0.##}";
            this.GoldWei.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.GoldWei.FieldName = "GoldWei";
            this.GoldWei.Name = "GoldWei";
            this.GoldWei.SummaryItem.DisplayFormat = "{0:#,##0.##}";
            this.GoldWei.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.GoldWei.Tag = "1";
            this.GoldWei.Visible = true;
            this.GoldWei.VisibleIndex = 7;
            this.GoldWei.Width = 56;
            // 
            // DiamondWei
            // 
            this.DiamondWei.Caption = "TL hột";
            this.DiamondWei.DisplayFormat.FormatString = "{0:#,##0.##}";
            this.DiamondWei.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DiamondWei.FieldName = "DiamondWei";
            this.DiamondWei.Name = "DiamondWei";
            this.DiamondWei.SummaryItem.DisplayFormat = "{0:#,##0.#0}";
            this.DiamondWei.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.DiamondWei.Tag = "1";
            this.DiamondWei.Visible = true;
            this.DiamondWei.VisibleIndex = 8;
            this.DiamondWei.Width = 48;
            // 
            // TaskPrice
            // 
            this.TaskPrice.Caption = "Tiền công/ bù";
            this.TaskPrice.DisplayFormat.FormatString = "{0:#,##0}";
            this.TaskPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TaskPrice.FieldName = "TaskPrice";
            this.TaskPrice.Name = "TaskPrice";
            this.TaskPrice.SummaryItem.DisplayFormat = "{0:#,##0}";
            this.TaskPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.TaskPrice.Visible = true;
            this.TaskPrice.VisibleIndex = 9;
            this.TaskPrice.Width = 90;
            // 
            // Discount
            // 
            this.Discount.Caption = "Tiền giảm";
            this.Discount.DisplayFormat.FormatString = "{0:#,##0}";
            this.Discount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Discount.FieldName = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.Discount.SummaryItem.DisplayFormat = "{0:#,##0}";
            this.Discount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.Discount.Visible = true;
            this.Discount.VisibleIndex = 10;
            this.Discount.Width = 68;
            // 
            // PayAmount
            // 
            this.PayAmount.Caption = "Thanh toán";
            this.PayAmount.DisplayFormat.FormatString = "{0:#,##0}";
            this.PayAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PayAmount.FieldName = "PayAmount";
            this.PayAmount.Name = "PayAmount";
            this.PayAmount.SummaryItem.DisplayFormat = "{0:#,##0}";
            this.PayAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.PayAmount.Visible = true;
            this.PayAmount.VisibleIndex = 11;
            this.PayAmount.Width = 76;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tình trạng";
            this.gridColumn9.FieldName = "StatusName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 12;
            this.gridColumn9.Width = 69;
            // 
            // FullName
            // 
            this.FullName.Caption = "Nhân viên";
            this.FullName.FieldName = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.OptionsFilter.AllowAutoFilter = false;
            this.FullName.OptionsFilter.AllowFilter = false;
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 13;
            this.FullName.Width = 68;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "TTT";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 45;
            // 
            // PayCard
            // 
            this.PayCard.Caption = "TT Thẻ";
            this.PayCard.DisplayFormat.FormatString = "{0:#,##0}";
            this.PayCard.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PayCard.FieldName = "PayCard";
            this.PayCard.Name = "PayCard";
            this.PayCard.SummaryItem.DisplayFormat = "{0:#,##0}";
            this.PayCard.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.PayCard.Width = 51;
            // 
            // SL
            // 
            this.SL.Caption = "SL";
            this.SL.DisplayFormat.FormatString = "#,##0";
            this.SL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SL.FieldName = "SL";
            this.SL.Name = "SL";
            this.SL.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.SL.Visible = true;
            this.SL.VisibleIndex = 14;
            this.SL.Width = 28;
            // 
            // ucCRT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdDanhSach);
            this.Name = "ucCRT";
            this.Size = new System.Drawing.Size(1045, 569);
            this.Load += new System.EventHandler(this.ucCRT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl grdDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn TaskPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
        private DevExpress.XtraGrid.Columns.GridColumn GoldWei;
        private DevExpress.XtraGrid.Columns.GridColumn DiamondWei;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn Discount;
        private DevExpress.XtraGrid.Columns.GridColumn TrnTime;
        private DevExpress.XtraGrid.Columns.GridColumn PayAmount;
        private DevExpress.XtraGrid.Columns.GridColumn PayCard;
        private DevExpress.XtraGrid.Columns.GridColumn SL;

    }
}
