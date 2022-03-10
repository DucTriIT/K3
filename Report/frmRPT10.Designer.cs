namespace GoldRT
{
    partial class frmRPT10
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
            this.dtpTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboProductGroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboNCC = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNCC.Properties)).BeginInit();
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
            this.btnThoat.Location = new System.Drawing.Point(329, 100);
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
            this.btnPrint.Location = new System.Drawing.Point(248, 100);
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
            this.labelControl2.Location = new System.Drawing.Point(12, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 18);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Từ ngày";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.EditValue = null;
            this.dtpTuNgay.Location = new System.Drawing.Point(95, 61);
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
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 25);
            this.dtpTuNgay.TabIndex = 21;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(222, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 18);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Đến ngày";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.EditValue = null;
            this.dtpDenNgay.Location = new System.Drawing.Point(294, 61);
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
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 25);
            this.dtpDenNgay.TabIndex = 23;
            // 
            // cboProductGroup
            // 
            this.cboProductGroup.Location = new System.Drawing.Point(95, 30);
            this.cboProductGroup.Name = "cboProductGroup";
            this.cboProductGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductGroup.Properties.Appearance.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductGroup.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboProductGroup.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductGroup.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductGroup.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboProductGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProductGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProductGroup.Size = new System.Drawing.Size(110, 25);
            this.cboProductGroup.TabIndex = 29;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(10, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 18);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "Nhóm hàng";
            // 
            // cboNCC
            // 
            this.cboNCC.Location = new System.Drawing.Point(294, 30);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNCC.Properties.Appearance.Options.UseFont = true;
            this.cboNCC.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNCC.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboNCC.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboNCC.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboNCC.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNCC.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboNCC.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNCC.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboNCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNCC.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboNCC.Size = new System.Drawing.Size(110, 25);
            this.cboNCC.TabIndex = 30;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(222, 33);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 18);
            this.labelControl4.TabIndex = 31;
            this.labelControl4.Text = "Nhà CC";
            // 
            // frmRPT10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 136);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.cboNCC);
            this.Controls.Add(this.cboProductGroup);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelControl2);
            this.Name = "frmRPT10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "rptReport01";
            this.Load += new System.EventHandler(this.frmRPT10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNCC.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblReport;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtpTuNgay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtpDenNgay;
        private DevExpress.XtraEditors.ComboBoxEdit cboProductGroup;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboNCC;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}