namespace GoldRT.Query.ucQueryRTTran
{
    partial class ucBRT
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
            this.CustID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiamondWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BuyRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(933, 569);
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
            this.grdDanhSach.Size = new System.Drawing.Size(920, 556);
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
            this.CustID,
            this.TrnDate,
            this.TrnTime,
            this.CustName,
            this.GoldDesc,
            this.GoldWeight,
            this.DiamondWeight,
            this.BuyRate,
            this.TotalAmount,
            this.StatusName,
            this.Status,
            this.IsPaid,
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
            this.grvDanhSach.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TrnDate, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvDanhSach.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvDanhSach_MouseDown);
            // 
            // TrnID
            // 
            this.TrnID.Caption = "TrnID";
            this.TrnID.FieldName = "TrnID";
            this.TrnID.Name = "TrnID";
            // 
            // CustID
            // 
            this.CustID.Caption = "CustID";
            this.CustID.FieldName = "CustID";
            this.CustID.Name = "CustID";
            // 
            // TrnDate
            // 
            this.TrnDate.Caption = "Ngày";
            this.TrnDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.TrnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TrnDate.FieldName = "TrnDate";
            this.TrnDate.Name = "TrnDate";
            this.TrnDate.Visible = true;
            this.TrnDate.VisibleIndex = 0;
            this.TrnDate.Width = 130;
            // 
            // TrnTime
            // 
            this.TrnTime.Caption = "Giờ";
            this.TrnTime.FieldName = "TrnTime";
            this.TrnTime.Name = "TrnTime";
            this.TrnTime.Visible = true;
            this.TrnTime.VisibleIndex = 1;
            this.TrnTime.Width = 65;
            // 
            // CustName
            // 
            this.CustName.Caption = "Khách hàng";
            this.CustName.FieldName = "CustName";
            this.CustName.Name = "CustName";
            this.CustName.Visible = true;
            this.CustName.VisibleIndex = 2;
            this.CustName.Width = 144;
            // 
            // GoldDesc
            // 
            this.GoldDesc.Caption = "Loại dẻ";
            this.GoldDesc.DisplayFormat.FormatString = "{0:#,##0.##}";
            this.GoldDesc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.GoldDesc.FieldName = "GoldDesc";
            this.GoldDesc.Name = "GoldDesc";
            this.GoldDesc.Visible = true;
            this.GoldDesc.VisibleIndex = 3;
            this.GoldDesc.Width = 102;
            // 
            // GoldWeight
            // 
            this.GoldWeight.Caption = "TL Vàng";
            this.GoldWeight.DisplayFormat.FormatString = "{0:#,##0.##}";
            this.GoldWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.GoldWeight.FieldName = "GoldWeight";
            this.GoldWeight.Name = "GoldWeight";
            this.GoldWeight.SummaryItem.DisplayFormat = "{0:#,##0.##}";
            this.GoldWeight.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.GoldWeight.Tag = "1";
            this.GoldWeight.Visible = true;
            this.GoldWeight.VisibleIndex = 4;
            this.GoldWeight.Width = 99;
            // 
            // DiamondWeight
            // 
            this.DiamondWeight.Caption = "Hột";
            this.DiamondWeight.DisplayFormat.FormatString = "{0:#,##0.##}";
            this.DiamondWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DiamondWeight.FieldName = "DiamondWeight";
            this.DiamondWeight.Name = "DiamondWeight";
            this.DiamondWeight.SummaryItem.DisplayFormat = "{0:#,##0.##}";
            this.DiamondWeight.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.DiamondWeight.Tag = "1";
            this.DiamondWeight.Visible = true;
            this.DiamondWeight.VisibleIndex = 5;
            this.DiamondWeight.Width = 79;
            // 
            // BuyRate
            // 
            this.BuyRate.Caption = "Giá mua";
            this.BuyRate.DisplayFormat.FormatString = "{0:#,##0}";
            this.BuyRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BuyRate.FieldName = "BuyRate";
            this.BuyRate.Name = "BuyRate";
            this.BuyRate.Visible = true;
            this.BuyRate.VisibleIndex = 6;
            this.BuyRate.Width = 103;
            // 
            // TotalAmount
            // 
            this.TotalAmount.Caption = "Thành tiền";
            this.TotalAmount.DisplayFormat.FormatString = "{0:#,##0}";
            this.TotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TotalAmount.FieldName = "TotalAmount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.SummaryItem.DisplayFormat = "{0:#,##0}";
            this.TotalAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.TotalAmount.Visible = true;
            this.TotalAmount.VisibleIndex = 7;
            this.TotalAmount.Width = 124;
            // 
            // StatusName
            // 
            this.StatusName.Caption = "Tình trạng";
            this.StatusName.FieldName = "StatusName";
            this.StatusName.Name = "StatusName";
            this.StatusName.Visible = true;
            this.StatusName.VisibleIndex = 8;
            this.StatusName.Width = 124;
            // 
            // FullName
            // 
            this.FullName.Caption = "Người thực hiện";
            this.FullName.FieldName = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 9;
            this.FullName.Width = 196;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(933, 569);
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
            this.layoutControlItem1.Size = new System.Drawing.Size(931, 567);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // ucBRT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucBRT";
            this.Size = new System.Drawing.Size(933, 569);
            this.Load += new System.EventHandler(this.ucCRT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn CustID;
        private DevExpress.XtraGrid.Columns.GridColumn TrnDate;
        private DevExpress.XtraGrid.Columns.GridColumn CustName;
        private DevExpress.XtraGrid.Columns.GridColumn GoldDesc;
        private DevExpress.XtraGrid.Columns.GridColumn StatusName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn BuyRate;
        private DevExpress.XtraGrid.Columns.GridColumn GoldWeight;
        private DevExpress.XtraGrid.Columns.GridColumn TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraGrid.Columns.GridColumn IsPaid;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn TrnTime;
        private DevExpress.XtraGrid.Columns.GridColumn DiamondWeight;
    }
}
