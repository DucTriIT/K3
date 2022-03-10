namespace GoldRT
{
    partial class frmTillTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTillTransfer));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cboFromTill = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.grdControl = new DevExpress.XtraGrid.GridControl();
            this.grdDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TillTxnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TillID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldCcy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoldCcyDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TillBal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TillBal_Diamond = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Amount_Diamond = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtAmount_Diamond = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cboToTill = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblFromTill = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFromTill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtAmount_Diamond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboToTill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cboFromTill);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.btnThucHien);
            this.layoutControl1.Controls.Add(this.btnCapNhat);
            this.layoutControl1.Controls.Add(this.btnThoat);
            this.layoutControl1.Controls.Add(this.grdControl);
            this.layoutControl1.Controls.Add(this.cboToTill);
            this.layoutControl1.Controls.Add(this.lblFromTill);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(754, 483);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cboFromTill
            // 
            this.cboFromTill.Location = new System.Drawing.Point(202, 6);
            this.cboFromTill.Name = "cboFromTill";
            this.cboFromTill.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromTill.Properties.Appearance.Options.UseFont = true;
            this.cboFromTill.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromTill.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboFromTill.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromTill.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboFromTill.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromTill.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboFromTill.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromTill.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboFromTill.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFromTill.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboFromTill.Size = new System.Drawing.Size(222, 24);
            this.cboFromTill.StyleController = this.layoutControl1;
            this.cboFromTill.TabIndex = 5;
            this.cboFromTill.SelectedIndexChanged += new System.EventHandler(this.cboFromTill_SelectedIndexChanged);
            this.cboFromTill.EditValueChanged += new System.EventHandler(this.cboFromTill_EditValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ImageIndex = 12;
            this.btnPrint.ImageList = this.imageCollection;
            this.btnPrint.Location = new System.Drawing.Point(580, 452);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 28);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "&In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // btnThucHien
            // 
            this.btnThucHien.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucHien.Appearance.Options.UseFont = true;
            this.btnThucHien.ImageIndex = 10;
            this.btnThucHien.ImageList = this.imageCollection;
            this.btnThucHien.Location = new System.Drawing.Point(105, 452);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(104, 28);
            this.btnThucHien.StyleController = this.layoutControl1;
            this.btnThucHien.TabIndex = 30;
            this.btnThucHien.Text = "&Hoàn tất";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Appearance.Options.UseFont = true;
            this.btnCapNhat.ImageIndex = 3;
            this.btnCapNhat.ImageList = this.imageCollection;
            this.btnCapNhat.Location = new System.Drawing.Point(3, 452);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(98, 28);
            this.btnCapNhat.StyleController = this.layoutControl1;
            this.btnCapNhat.TabIndex = 28;
            this.btnCapNhat.Text = "&Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageIndex = 5;
            this.btnThoat.ImageList = this.imageCollection;
            this.btnThoat.Location = new System.Drawing.Point(671, 452);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 28);
            this.btnThoat.StyleController = this.layoutControl1;
            this.btnThoat.TabIndex = 27;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // grdControl
            // 
            this.grdControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdControl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdControl.Location = new System.Drawing.Point(3, 62);
            this.grdControl.MainView = this.grdDanhSach;
            this.grdControl.Name = "grdControl";
            this.grdControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxtAmount,
            this.rtxtAmount_Diamond});
            this.grdControl.Size = new System.Drawing.Size(748, 386);
            this.grdControl.TabIndex = 26;
            this.grdControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDanhSach});
            // 
            // grdDanhSach
            // 
            this.grdDanhSach.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.grdDanhSach.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.grdDanhSach.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.DetailTip.Options.UseFont = true;
            this.grdDanhSach.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.Empty.Options.UseFont = true;
            this.grdDanhSach.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.EvenRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.FilterCloseButton.Options.UseFont = true;
            this.grdDanhSach.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.FilterPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.FixedLine.Options.UseFont = true;
            this.grdDanhSach.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.FocusedCell.Options.UseFont = true;
            this.grdDanhSach.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.FocusedRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.FooterPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.GroupButton.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.GroupFooter.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.GroupPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.GroupRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdDanhSach.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.HorzLine.Options.UseFont = true;
            this.grdDanhSach.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.OddRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.Preview.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.Preview.Options.UseFont = true;
            this.grdDanhSach.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.Row.Options.UseFont = true;
            this.grdDanhSach.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.RowSeparator.Options.UseFont = true;
            this.grdDanhSach.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.SelectedRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.TopNewRow.Options.UseFont = true;
            this.grdDanhSach.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDanhSach.Appearance.VertLine.Options.UseFont = true;
            this.grdDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TillTxnID,
            this.TillID,
            this.GoldCcy,
            this.GoldCcyDesc,
            this.TillBal,
            this.TillBal_Diamond,
            this.Amount,
            this.Amount_Diamond,
            this.Status,
            this.Type});
            this.grdDanhSach.GridControl = this.grdControl;
            this.grdDanhSach.Name = "grdDanhSach";
            this.grdDanhSach.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdDanhSach.OptionsView.ShowGroupPanel = false;
            this.grdDanhSach.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdDanhSach_RowUpdated);
            // 
            // TillTxnID
            // 
            this.TillTxnID.Caption = "TillTxnID";
            this.TillTxnID.FieldName = "TillTxnID";
            this.TillTxnID.Name = "TillTxnID";
            // 
            // TillID
            // 
            this.TillID.Caption = "TillID";
            this.TillID.FieldName = "TillID";
            this.TillID.Name = "TillID";
            // 
            // GoldCcy
            // 
            this.GoldCcy.Caption = "GoldCcy";
            this.GoldCcy.FieldName = "GoldCcy";
            this.GoldCcy.Name = "GoldCcy";
            // 
            // GoldCcyDesc
            // 
            this.GoldCcyDesc.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.GoldCcyDesc.AppearanceCell.Options.UseBackColor = true;
            this.GoldCcyDesc.Caption = "Loại vàng/ NT";
            this.GoldCcyDesc.FieldName = "GoldCcyDesc";
            this.GoldCcyDesc.Name = "GoldCcyDesc";
            this.GoldCcyDesc.OptionsColumn.AllowEdit = false;
            this.GoldCcyDesc.OptionsColumn.AllowFocus = false;
            this.GoldCcyDesc.Visible = true;
            this.GoldCcyDesc.VisibleIndex = 0;
            this.GoldCcyDesc.Width = 125;
            // 
            // TillBal
            // 
            this.TillBal.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.TillBal.AppearanceCell.Options.UseBackColor = true;
            this.TillBal.Caption = "Số dư";
            this.TillBal.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.TillBal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TillBal.FieldName = "TillBal";
            this.TillBal.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TillBal.Name = "TillBal";
            this.TillBal.OptionsColumn.AllowEdit = false;
            this.TillBal.OptionsColumn.AllowFocus = false;
            this.TillBal.Tag = "1";
            this.TillBal.Visible = true;
            this.TillBal.VisibleIndex = 1;
            this.TillBal.Width = 96;
            // 
            // TillBal_Diamond
            // 
            this.TillBal_Diamond.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.TillBal_Diamond.AppearanceCell.Options.UseBackColor = true;
            this.TillBal_Diamond.Caption = "TL hột";
            this.TillBal_Diamond.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.TillBal_Diamond.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TillBal_Diamond.FieldName = "TillBal_Diamond";
            this.TillBal_Diamond.Name = "TillBal_Diamond";
            this.TillBal_Diamond.OptionsColumn.AllowEdit = false;
            this.TillBal_Diamond.Tag = "1";
            this.TillBal_Diamond.Width = 73;
            // 
            // Amount
            // 
            this.Amount.Caption = "SL chuyển";
            this.Amount.ColumnEdit = this.rtxtAmount;
            this.Amount.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.FieldName = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Tag = "1";
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 2;
            this.Amount.Width = 103;
            // 
            // rtxtAmount
            // 
            this.rtxtAmount.AutoHeight = false;
            this.rtxtAmount.DisplayFormat.FormatString = "{0:#,##0.##}";
            this.rtxtAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtAmount.EditFormat.FormatString = "{0:#,##0.##}";
            this.rtxtAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtAmount.Name = "rtxtAmount";
            // 
            // Amount_Diamond
            // 
            this.Amount_Diamond.Caption = "TL hột chuyển";
            this.Amount_Diamond.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.Amount_Diamond.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount_Diamond.FieldName = "Amount_Diamond";
            this.Amount_Diamond.Name = "Amount_Diamond";
            this.Amount_Diamond.Tag = "1";
            this.Amount_Diamond.Width = 107;
            // 
            // Status
            // 
            this.Status.Caption = "Status";
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            // 
            // Type
            // 
            this.Type.Caption = "Type";
            this.Type.FieldName = "Type";
            this.Type.Name = "Type";
            // 
            // rtxtAmount_Diamond
            // 
            this.rtxtAmount_Diamond.AutoHeight = false;
            this.rtxtAmount_Diamond.DisplayFormat.FormatString = "{0:#,##0.##}";
            this.rtxtAmount_Diamond.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtAmount_Diamond.EditFormat.FormatString = "{0:#,##0.##}";
            this.rtxtAmount_Diamond.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtAmount_Diamond.Name = "rtxtAmount_Diamond";
            this.rtxtAmount_Diamond.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rtxtAmount_Diamond_EditValueChanging);
            // 
            // cboToTill
            // 
            this.cboToTill.Location = new System.Drawing.Point(199, 37);
            this.cboToTill.Name = "cboToTill";
            this.cboToTill.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToTill.Properties.Appearance.Options.UseFont = true;
            this.cboToTill.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToTill.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboToTill.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToTill.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboToTill.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToTill.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboToTill.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToTill.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboToTill.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboToTill.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboToTill.Size = new System.Drawing.Size(285, 24);
            this.cboToTill.StyleController = this.layoutControl1;
            this.cboToTill.TabIndex = 4;
            this.cboToTill.EditValueChanged += new System.EventHandler(this.cboToTill_EditValueChanged);
            // 
            // lblFromTill
            // 
            this.lblFromTill.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromTill.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFromTill.Location = new System.Drawing.Point(434, 6);
            this.lblFromTill.Name = "lblFromTill";
            this.lblFromTill.Size = new System.Drawing.Size(314, 24);
            this.lblFromTill.StyleController = this.layoutControl1;
            this.lblFromTill.TabIndex = 29;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem2,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem8,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(754, 483);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.cboToTill;
            this.layoutControlItem1.CustomizationFormText = "Quầy nhận";
            this.layoutControlItem1.Location = new System.Drawing.Point(105, 34);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(380, 25);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(380, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(380, 25);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Quầy nhận";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(88, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.Control = this.grdControl;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 59);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(752, 390);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.Control = this.btnThoat;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(668, 449);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(84, 32);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(84, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(84, 32);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AllowHotTrack = false;
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.lblFromTill;
            this.layoutControlItem5.CustomizationFormText = "Quầy chuyển";
            this.layoutControlItem5.Location = new System.Drawing.Point(428, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(206, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Size = new System.Drawing.Size(324, 34);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AllowHotTrack = false;
            this.layoutControlItem6.Control = this.btnThucHien;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(102, 449);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(108, 32);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(108, 32);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(108, 32);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(210, 449);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(367, 32);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AllowHotTrack = false;
            this.layoutControlItem7.Control = this.btnPrint;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(577, 449);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(91, 32);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(91, 32);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(91, 32);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(485, 34);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(267, 25);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 34);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem3.Size = new System.Drawing.Size(105, 25);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem4.Size = new System.Drawing.Size(105, 34);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AllowHotTrack = false;
            this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.cboFromTill;
            this.layoutControlItem8.CustomizationFormText = "Quầy chuyển";
            this.layoutControlItem8.Location = new System.Drawing.Point(105, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem8.Size = new System.Drawing.Size(323, 34);
            this.layoutControlItem8.Text = "Quầy chuyển";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(88, 18);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.btnCapNhat;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 449);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(102, 32);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(102, 32);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(102, 32);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmTillTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 483);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmTillTransfer";
            this.Text = "Thu/ chi giữa các Quầy";
            this.Load += new System.EventHandler(this.frmTillTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboFromTill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtAmount_Diamond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboToTill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ComboBoxEdit cboToTill;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl grdControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn TillTxnID;
        private DevExpress.XtraGrid.Columns.GridColumn TillID;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCcyDesc;
        private DevExpress.XtraGrid.Columns.GridColumn TillBal;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnThucHien;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtAmount;
        private DevExpress.XtraGrid.Columns.GridColumn GoldCcy;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Columns.GridColumn TillBal_Diamond;
        private DevExpress.XtraGrid.Columns.GridColumn Amount_Diamond;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtAmount_Diamond;
        private DevExpress.XtraEditors.ComboBoxEdit cboFromTill;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LabelControl lblFromTill;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}