namespace GoldRT
{
    partial class frmRPT01
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
            this.lblReport = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboSection = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboMainSection = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboSection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMainSection.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReport
            // 
            this.lblReport.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblReport.Appearance.Options.UseFont = true;
            this.lblReport.Appearance.Options.UseForeColor = true;
            this.lblReport.Location = new System.Drawing.Point(12, 6);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(92, 18);
            this.lblReport.TabIndex = 11;
            this.lblReport.Text = "labelControl1";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Location = new System.Drawing.Point(243, 90);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 27);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(162, 90);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 27);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 18);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Quầy nhỏ";
            // 
            // cboSection
            // 
            this.cboSection.Location = new System.Drawing.Point(87, 57);
            this.cboSection.Name = "cboSection";
            this.cboSection.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSection.Properties.Appearance.Options.UseFont = true;
            this.cboSection.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSection.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboSection.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboSection.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboSection.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSection.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboSection.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSection.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSection.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSection.Size = new System.Drawing.Size(231, 25);
            this.cboSection.TabIndex = 12;
            // 
            // cboMainSection
            // 
            this.cboMainSection.Location = new System.Drawing.Point(87, 30);
            this.cboMainSection.Name = "cboMainSection";
            this.cboMainSection.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMainSection.Properties.Appearance.Options.UseFont = true;
            this.cboMainSection.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMainSection.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboMainSection.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboMainSection.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboMainSection.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMainSection.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboMainSection.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMainSection.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboMainSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMainSection.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboMainSection.Size = new System.Drawing.Size(231, 25);
            this.cboMainSection.TabIndex = 14;
            this.cboMainSection.SelectedIndexChanged += new System.EventHandler(this.cboMainSection_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 18);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Quầy lớn";
            // 
            // frmRPT01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 123);
            this.Controls.Add(this.cboMainSection);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboSection);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelControl2);
            this.Name = "frmRPT01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rptReport01";
            this.Load += new System.EventHandler(this.frmRPT01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMainSection.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblReport;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboSection;
        private DevExpress.XtraEditors.ComboBoxEdit cboMainSection;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}