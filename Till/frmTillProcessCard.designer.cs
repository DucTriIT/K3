namespace GoldRT
{
    partial class frmTillProcessCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTillProcessCard));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtCashAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtCardAmount = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.txtIDCard = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtHoTenChuThe = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBankName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtOutDate = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTenChuThe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtOutDate);
            this.layoutControl1.Controls.Add(this.txtBankName);
            this.layoutControl1.Controls.Add(this.txtHoTenChuThe);
            this.layoutControl1.Controls.Add(this.btnProcess);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.txtCashAmount);
            this.layoutControl1.Controls.Add(this.txtCardAmount);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.txtIDCard);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(392, 263);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnProcess
            // 
            this.btnProcess.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Appearance.Options.UseFont = true;
            this.btnProcess.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnProcess.ImageIndex = 3;
            this.btnProcess.ImageList = this.imageCollection;
            this.btnProcess.Location = new System.Drawing.Point(176, 233);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(116, 27);
            this.btnProcess.StyleController = this.layoutControl1;
            this.btnProcess.TabIndex = 28;
            this.btnProcess.Text = "Thanh toán";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageIndex = 0;
            this.btnClose.ImageList = this.imageCollection;
            this.btnClose.Location = new System.Drawing.Point(297, 233);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 27);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCashAmount
            // 
            this.txtCashAmount.Location = new System.Drawing.Point(144, 184);
            this.txtCashAmount.Name = "txtCashAmount";
            this.txtCashAmount.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtCashAmount.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCashAmount.Properties.Appearance.Options.UseBackColor = true;
            this.txtCashAmount.Properties.Appearance.Options.UseFont = true;
            this.txtCashAmount.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCashAmount.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtCashAmount.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCashAmount.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtCashAmount.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCashAmount.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtCashAmount.Properties.DisplayFormat.FormatString = "#,##0.##";
            this.txtCashAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCashAmount.Properties.EditFormat.FormatString = "#,##0.##";
            this.txtCashAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCashAmount.Properties.Mask.EditMask = "n0";
            this.txtCashAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCashAmount.Properties.ReadOnly = true;
            this.txtCashAmount.Size = new System.Drawing.Size(245, 25);
            this.txtCashAmount.StyleController = this.layoutControl1;
            this.txtCashAmount.TabIndex = 4;
            // 
            // txtCardAmount
            // 
            this.txtCardAmount.EditValue = 0;
            this.txtCardAmount.Location = new System.Drawing.Point(144, 154);
            this.txtCardAmount.Name = "txtCardAmount";
            this.txtCardAmount.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtCardAmount.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCardAmount.Properties.Appearance.Options.UseBackColor = true;
            this.txtCardAmount.Properties.Appearance.Options.UseFont = true;
            this.txtCardAmount.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCardAmount.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtCardAmount.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCardAmount.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtCardAmount.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCardAmount.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtCardAmount.Properties.DisplayFormat.FormatString = "{0:#,##0}";
            this.txtCardAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCardAmount.Properties.EditFormat.FormatString = "{0:#,##0}";
            this.txtCardAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCardAmount.Properties.Mask.EditMask = "n0";
            this.txtCardAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCardAmount.Properties.NullText = "0";
            this.txtCardAmount.Size = new System.Drawing.Size(245, 25);
            this.txtCardAmount.StyleController = this.layoutControl1;
            this.txtCardAmount.TabIndex = 3;
            this.txtCardAmount.EditValueChanged += new System.EventHandler(this.txtCardAmount_EditValueChanged);
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = 0;
            this.textEdit1.Location = new System.Drawing.Point(144, 124);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.textEdit1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.textEdit1.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.textEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            this.textEdit1.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.textEdit1.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.textEdit1.Properties.DisplayFormat.FormatString = "{0:#,##0}";
            this.textEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit1.Properties.EditFormat.FormatString = "{0:#,##0}";
            this.textEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit1.Properties.Mask.EditMask = "n0";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Properties.NullText = "0";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(245, 25);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 2;
            // 
            // txtIDCard
            // 
            this.txtIDCard.Location = new System.Drawing.Point(144, 4);
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtIDCard.Properties.Appearance.Options.UseFont = true;
            this.txtIDCard.Size = new System.Drawing.Size(245, 25);
            this.txtIDCard.StyleController = this.layoutControl1;
            this.txtIDCard.TabIndex = 1;
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
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(392, 263);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtIDCard;
            this.layoutControlItem1.CustomizationFormText = "Thẻ ID";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(390, 30);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "Thẻ ID";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(135, 20);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.textEdit1;
            this.layoutControlItem2.CustomizationFormText = "Số tiền thanh toán";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(390, 30);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "Số tiền thanh toán";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(135, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtCardAmount;
            this.layoutControlItem3.CustomizationFormText = "Tiền trả bằng thẻ";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 150);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(390, 30);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "Tiền trả bằng thẻ";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(135, 20);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtCashAmount;
            this.layoutControlItem4.CustomizationFormText = "Thanh toán tiền mặt";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 180);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(390, 30);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "Thanh toán tiền mặt";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(135, 20);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AllowHotTrack = false;
            this.layoutControlItem5.Control = this.btnClose;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(293, 229);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Size = new System.Drawing.Size(97, 32);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AllowHotTrack = false;
            this.layoutControlItem6.Control = this.btnProcess;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(172, 229);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem6.Size = new System.Drawing.Size(121, 32);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 229);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(172, 32);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 210);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem2.Size = new System.Drawing.Size(390, 19);
            this.emptySpaceItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtHoTenChuThe
            // 
            this.txtHoTenChuThe.Location = new System.Drawing.Point(144, 34);
            this.txtHoTenChuThe.Name = "txtHoTenChuThe";
            this.txtHoTenChuThe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtHoTenChuThe.Properties.Appearance.Options.UseFont = true;
            this.txtHoTenChuThe.Size = new System.Drawing.Size(245, 25);
            this.txtHoTenChuThe.StyleController = this.layoutControl1;
            this.txtHoTenChuThe.TabIndex = 2;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AllowHotTrack = false;
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.txtHoTenChuThe;
            this.layoutControlItem7.CustomizationFormText = "Họ tên chủ thẻ";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem7.Size = new System.Drawing.Size(390, 30);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem7.Text = "Họ tên chủ thẻ";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(135, 20);
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(144, 64);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBankName.Properties.Appearance.Options.UseFont = true;
            this.txtBankName.Size = new System.Drawing.Size(245, 25);
            this.txtBankName.StyleController = this.layoutControl1;
            this.txtBankName.TabIndex = 2;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AllowHotTrack = false;
            this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.txtBankName;
            this.layoutControlItem8.CustomizationFormText = "Ngân hàng";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Size = new System.Drawing.Size(390, 30);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem8.Text = "Ngân hàng";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(135, 20);
            // 
            // txtOutDate
            // 
            this.txtOutDate.Location = new System.Drawing.Point(144, 94);
            this.txtOutDate.Name = "txtOutDate";
            this.txtOutDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOutDate.Properties.Appearance.Options.UseFont = true;
            this.txtOutDate.Size = new System.Drawing.Size(245, 25);
            this.txtOutDate.StyleController = this.layoutControl1;
            this.txtOutDate.TabIndex = 2;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AllowHotTrack = false;
            this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem9.Control = this.txtOutDate;
            this.layoutControlItem9.CustomizationFormText = "Ngày hết hạn";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.Size = new System.Drawing.Size(390, 30);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem9.Text = "Ngày hết hạn";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(135, 20);
            // 
            // frmTillProcessCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 263);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTillProcessCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán bằng thẻ";
            this.Load += new System.EventHandler(this.frmTillProcessCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTenChuThe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtIDCard;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtCashAmount;
        private DevExpress.XtraEditors.TextEdit txtCardAmount;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.TextEdit txtOutDate;
        private DevExpress.XtraEditors.TextEdit txtBankName;
        private DevExpress.XtraEditors.TextEdit txtHoTenChuThe;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}