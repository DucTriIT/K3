namespace GoldRT
{
    partial class frmOpenTill
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOpenTill = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cboTill = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTillName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtStatus = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTillName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(121, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã quầy thu ngân";
            // 
            // btnOpenTill
            // 
            this.btnOpenTill.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenTill.Appearance.Options.UseFont = true;
            this.btnOpenTill.Location = new System.Drawing.Point(172, 108);
            this.btnOpenTill.Name = "btnOpenTill";
            this.btnOpenTill.Size = new System.Drawing.Size(87, 29);
            this.btnOpenTill.TabIndex = 1;
            this.btnOpenTill.Text = "Mở quầy";
            this.btnOpenTill.Click += new System.EventHandler(this.btnOpenTill_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(265, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboTill
            // 
            this.cboTill.Location = new System.Drawing.Point(149, 14);
            this.cboTill.Name = "cboTill";
            this.cboTill.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTill.Properties.Appearance.Options.UseFont = true;
            this.cboTill.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTill.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboTill.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTill.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboTill.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTill.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboTill.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTill.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboTill.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTill.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTill.Size = new System.Drawing.Size(123, 25);
            this.cboTill.TabIndex = 3;
            this.cboTill.SelectedValueChanged += new System.EventHandler(this.cboTill_SelectedValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(125, 18);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Tên quầy thu ngân";
            // 
            // txtTillName
            // 
            this.txtTillName.Location = new System.Drawing.Point(149, 43);
            this.txtTillName.Name = "txtTillName";
            this.txtTillName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTillName.Properties.Appearance.Options.UseFont = true;
            this.txtTillName.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTillName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtTillName.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTillName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtTillName.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTillName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtTillName.Size = new System.Drawing.Size(201, 25);
            this.txtTillName.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 18);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Tình trạng";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(150, 72);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Properties.Appearance.Options.UseFont = true;
            this.txtStatus.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtStatus.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtStatus.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtStatus.Size = new System.Drawing.Size(201, 25);
            this.txtStatus.TabIndex = 7;
            // 
            // frmOpenTill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 149);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtTillName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboTill);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenTill);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmOpenTill";
            this.Text = "Mở quầy thu ngân đầu ngày";
            this.Load += new System.EventHandler(this.frmOpenTill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboTill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTillName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOpenTill;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.ComboBoxEdit cboTill;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTillName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtStatus;
    }
}