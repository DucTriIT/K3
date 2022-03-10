namespace GoldRT
{
    partial class frmDebtByDate
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.grdDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldCcyDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.dtpDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.dtpTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnIn);
            this.layoutControl1.Controls.Add(this.grdDanhSach);
            this.layoutControl1.Controls.Add(this.btnTimKiem);
            this.layoutControl1.Controls.Add(this.dtpDenNgay);
            this.layoutControl1.Controls.Add(this.dtpTuNgay);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1011, 475);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Location = new System.Drawing.Point(841, 442);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(164, 27);
            this.btnIn.StyleController = this.layoutControl1;
            this.btnIn.TabIndex = 26;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // grdDanhSach
            // 
            this.grdDanhSach.EmbeddedNavigator.Name = "";
            this.grdDanhSach.Location = new System.Drawing.Point(4, 34);
            this.grdDanhSach.MainView = this.gridView1;
            this.grdDanhSach.Name = "grdDanhSach";
            this.grdDanhSach.Size = new System.Drawing.Size(1004, 400);
            this.grdDanhSach.TabIndex = 25;
            this.grdDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdDanhSach.Click += new System.EventHandler(this.grdDanhSach_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CustName,
            this.GoldCcyDesc,
            this.Amount});
            this.gridView1.GridControl = this.grdDanhSach;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupFormat = "{0} [#image]{1} {2}";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CustName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // CustName
            // 
            this.CustName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            this.CustName.AppearanceCell.Options.UseFont = true;
            this.CustName.AppearanceHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.CustName.AppearanceHeader.Options.UseFont = true;
            this.CustName.Caption = "Khách hàng";
            this.CustName.FieldName = "CustName";
            this.CustName.Name = "CustName";
            this.CustName.Visible = true;
            this.CustName.VisibleIndex = 0;
            this.CustName.Width = 94;
            // 
            // GoldCcyDesc
            // 
            this.GoldCcyDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            this.GoldCcyDesc.AppearanceCell.Options.UseFont = true;
            this.GoldCcyDesc.AppearanceHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.GoldCcyDesc.AppearanceHeader.Options.UseFont = true;
            this.GoldCcyDesc.Caption = "Vàng/Tiền";
            this.GoldCcyDesc.FieldName = "GoldCcyDesc";
            this.GoldCcyDesc.Name = "GoldCcyDesc";
            this.GoldCcyDesc.Visible = true;
            this.GoldCcyDesc.VisibleIndex = 0;
            this.GoldCcyDesc.Width = 83;
            // 
            // Amount
            // 
            this.Amount.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            this.Amount.AppearanceCell.Options.UseFont = true;
            this.Amount.AppearanceHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.Amount.AppearanceHeader.Options.UseFont = true;
            this.Amount.Caption = "Công nợ";
            this.Amount.DisplayFormat.FormatString = "#,##0.##";
            this.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.FieldName = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.SummaryItem.DisplayFormat = "#,##0.##";
            this.Amount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 1;
            this.Amount.Width = 73;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.Location = new System.Drawing.Point(828, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(180, 25);
            this.btnTimKiem.StyleController = this.layoutControl1;
            this.btnTimKiem.TabIndex = 24;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.EditValue = null;
            this.dtpDenNgay.Location = new System.Drawing.Point(515, 4);
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
            this.dtpDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpDenNgay.Size = new System.Drawing.Size(308, 25);
            this.dtpDenNgay.StyleController = this.layoutControl1;
            this.dtpDenNgay.TabIndex = 23;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.EditValue = null;
            this.dtpTuNgay.Location = new System.Drawing.Point(75, 4);
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
            this.dtpTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpTuNgay.Size = new System.Drawing.Size(364, 25);
            this.dtpTuNgay.StyleController = this.layoutControl1;
            this.dtpTuNgay.TabIndex = 22;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1011, 475);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.dtpTuNgay;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(440, 30);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "Từ ngày";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(66, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.dtpDenNgay;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(440, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(384, 30);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "Đến ngày";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.Control = this.btnTimKiem;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(824, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(85, 27);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(185, 30);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.grdDanhSach;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(1009, 405);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AllowHotTrack = false;
            this.layoutControlItem5.Control = this.btnIn;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(834, 435);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Size = new System.Drawing.Size(175, 38);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 435);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(834, 38);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmDebtByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 475);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmDebtByDate";
            this.Text = "Tra cứu nợ khách  theo ngày";
            this.Load += new System.EventHandler(this.frmDebtByDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit dtpTuNgay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dtpDenNgay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl grdDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn CustName;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCcyDesc;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}