namespace GoldRT
{
    partial class frmGenCode
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
            this.lstProductCode = new DevExpress.XtraEditors.ListBoxControl();
            this.btnPrintStamp = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstProductCode)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Size = new System.Drawing.Size(180, 120);
            this.layoutControl1.TabIndex = 0;
            // 
            // lstProductCode
            // 
            this.lstProductCode.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProductCode.Appearance.Options.UseFont = true;
            this.lstProductCode.Location = new System.Drawing.Point(5, 7);
            this.lstProductCode.Name = "lstProductCode";
            this.lstProductCode.Size = new System.Drawing.Size(253, 263);
            this.lstProductCode.TabIndex = 0;
            // 
            // btnPrintStamp
            // 
            this.btnPrintStamp.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintStamp.Appearance.Options.UseFont = true;
            this.btnPrintStamp.ImageIndex = 0;
            this.btnPrintStamp.Location = new System.Drawing.Point(81, 276);
            this.btnPrintStamp.Name = "btnPrintStamp";
            this.btnPrintStamp.Size = new System.Drawing.Size(90, 27);
            this.btnPrintStamp.StyleController = this.layoutControl1;
            this.btnPrintStamp.TabIndex = 40;
            this.btnPrintStamp.Text = "In tem";
            this.btnPrintStamp.Visible = false;
            this.btnPrintStamp.Click += new System.EventHandler(this.btnPrintStamp_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageIndex = 5;
            this.btnClose.Location = new System.Drawing.Point(174, 276);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 27);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "&Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmGenCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 307);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrintStamp);
            this.Controls.Add(this.lstProductCode);
            this.Name = "frmGenCode";
            this.Text = "Mã hàng";
            this.Load += new System.EventHandler(this.frmGenCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstProductCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ListBoxControl lstProductCode;
        private DevExpress.XtraEditors.SimpleButton btnPrintStamp;
        private DevExpress.XtraEditors.SimpleButton btnClose;

    }
}