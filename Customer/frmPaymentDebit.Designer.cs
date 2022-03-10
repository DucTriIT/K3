namespace GoldRT
{
    partial class frmPaymentDebit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentDebit));
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cboCust = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldDebit = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTienKhachTra = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewDebit = new DevExpress.XtraEditors.TextEdit();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCust.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldDebit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTienKhachTra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDebit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.CustomizationFormText = "Tên khách hàng";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 31);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(144, 31);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(568, 31);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "Tên khách hàng";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(109, 20);
            // 
            // cboCust
            // 
            this.cboCust.Location = new System.Drawing.Point(135, 21);
            this.cboCust.Name = "cboCust";
            this.cboCust.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCust.Properties.Appearance.Options.UseFont = true;
            this.cboCust.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCust.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCust.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCust.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCust.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cboCust.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cboCust.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cboCust.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCust.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCust.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCust.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCust.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCust.Size = new System.Drawing.Size(234, 25);
            this.cboCust.TabIndex = 1;
            this.cboCust.SelectedIndexChanged += new System.EventHandler(this.cboCust_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Khách hàng";
            // 
            // txtOldDebit
            // 
            this.txtOldDebit.Location = new System.Drawing.Point(135, 55);
            this.txtOldDebit.Name = "txtOldDebit";
            this.txtOldDebit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldDebit.Properties.Appearance.Options.UseFont = true;
            this.txtOldDebit.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldDebit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtOldDebit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtOldDebit.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldDebit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtOldDebit.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtOldDebit.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldDebit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtOldDebit.Properties.DisplayFormat.FormatString = "#,##0";
            this.txtOldDebit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOldDebit.Properties.EditFormat.FormatString = "#,##0";
            this.txtOldDebit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOldDebit.Properties.Mask.EditMask = "n0";
            this.txtOldDebit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOldDebit.Properties.ReadOnly = true;
            this.txtOldDebit.Size = new System.Drawing.Size(234, 25);
            this.txtOldDebit.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(24, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiền nợ cũ";
            // 
            // txtTienKhachTra
            // 
            this.txtTienKhachTra.Location = new System.Drawing.Point(135, 89);
            this.txtTienKhachTra.Name = "txtTienKhachTra";
            this.txtTienKhachTra.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKhachTra.Properties.Appearance.Options.UseFont = true;
            this.txtTienKhachTra.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKhachTra.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtTienKhachTra.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtTienKhachTra.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKhachTra.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtTienKhachTra.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtTienKhachTra.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKhachTra.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtTienKhachTra.Properties.DisplayFormat.FormatString = "#,##0";
            this.txtTienKhachTra.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTienKhachTra.Properties.EditFormat.FormatString = "#,##0";
            this.txtTienKhachTra.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTienKhachTra.Properties.Mask.EditMask = "n0";
            this.txtTienKhachTra.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTienKhachTra.Size = new System.Drawing.Size(234, 25);
            this.txtTienKhachTra.TabIndex = 5;
            this.txtTienKhachTra.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtTienKhachTra_EditValueChanging);
            this.txtTienKhachTra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTienKhachTra_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(24, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiền khách trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(24, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nợ còn lại";
            // 
            // txtNewDebit
            // 
            this.txtNewDebit.Location = new System.Drawing.Point(135, 123);
            this.txtNewDebit.Name = "txtNewDebit";
            this.txtNewDebit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewDebit.Properties.Appearance.Options.UseFont = true;
            this.txtNewDebit.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewDebit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtNewDebit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtNewDebit.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewDebit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNewDebit.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtNewDebit.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewDebit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtNewDebit.Properties.DisplayFormat.FormatString = "#,##0";
            this.txtNewDebit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNewDebit.Properties.EditFormat.FormatString = "#,##0";
            this.txtNewDebit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNewDebit.Properties.Mask.EditMask = "n0";
            this.txtNewDebit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNewDebit.Properties.ReadOnly = true;
            this.txtNewDebit.Size = new System.Drawing.Size(234, 25);
            this.txtNewDebit.TabIndex = 5;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Appearance.Options.UseFont = true;
            this.btnCapNhat.ImageIndex = 10;
            this.btnCapNhat.ImageList = this.imageCollection;
            this.btnCapNhat.Location = new System.Drawing.Point(160, 174);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(119, 37);
            this.btnCapNhat.TabIndex = 19;
            this.btnCapNhat.Text = "&Thanh toán";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
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
            this.btnClose.ImageIndex = 5;
            this.btnClose.ImageList = this.imageCollection;
            this.btnClose.Location = new System.Drawing.Point(285, 174);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 37);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "&Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPaymentDebit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 223);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNewDebit);
            this.Controls.Add(this.txtTienKhachTra);
            this.Controls.Add(this.txtOldDebit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCust);
            this.Name = "frmPaymentDebit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán nợ";
            this.Load += new System.EventHandler(this.frmPaymentDebit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCust.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldDebit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTienKhachTra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDebit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ComboBoxEdit cboCust;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtOldDebit;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtTienKhachTra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtNewDebit;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.Utils.ImageCollection imageCollection;
    }
}