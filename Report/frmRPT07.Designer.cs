namespace GoldRT
{
    partial class frmRPT07
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPT07));
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblReport = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.txtQuy10 = new DevExpress.XtraEditors.TextEdit();
            this.btnInPhieu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuy10.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(23, 43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(146, 18);
            this.labelControl3.TabIndex = 30;
            this.labelControl3.Text = "Giá quy 10(Ngàn/chỉ)";
            // 
            // lblReport
            // 
            this.lblReport.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblReport.Appearance.Options.UseFont = true;
            this.lblReport.Appearance.Options.UseForeColor = true;
            this.lblReport.Location = new System.Drawing.Point(30, 11);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(92, 18);
            this.lblReport.TabIndex = 29;
            this.lblReport.Text = "labelControl1";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Location = new System.Drawing.Point(253, 74);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 27);
            this.btnThoat.TabIndex = 28;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(138, 74);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(109, 27);
            this.btnPrint.TabIndex = 27;
            this.btnPrint.Text = "In chi tiết";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtQuy10
            // 
            this.txtQuy10.EditValue = "0";
            this.txtQuy10.Location = new System.Drawing.Point(175, 40);
            this.txtQuy10.Name = "txtQuy10";
            this.txtQuy10.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtQuy10.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtQuy10.Properties.Appearance.Options.UseFont = true;
            this.txtQuy10.Properties.DisplayFormat.FormatString = "#.###.##";
            this.txtQuy10.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuy10.Properties.EditFormat.FormatString = "#.###.##";
            this.txtQuy10.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuy10.Properties.Mask.EditMask = "n0";
            this.txtQuy10.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQuy10.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtQuy10.Size = new System.Drawing.Size(202, 25);
            this.txtQuy10.TabIndex = 31;
            this.txtQuy10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuy10_KeyDown);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInPhieu.Appearance.Options.UseFont = true;
            this.btnInPhieu.Location = new System.Drawing.Point(45, 124);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(96, 27);
            this.btnInPhieu.TabIndex = 32;
            this.btnInPhieu.Text = "In phiếu";
            this.btnInPhieu.Visible = false;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // frmRPT07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 113);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.txtQuy10);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnPrint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRPT07";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRPT07";
            this.Load += new System.EventHandler(this.frmRPT07_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuy10.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblReport;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.TextEdit txtQuy10;
        private DevExpress.XtraEditors.SimpleButton btnInPhieu;
    }
}