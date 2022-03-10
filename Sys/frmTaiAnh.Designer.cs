namespace GoldRT
{
    partial class frmTaiAnh
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
            this.picProduct = new DevExpress.XtraEditors.PictureEdit();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.hyperLinkEdit2 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.hyperLinkEdit3 = new DevExpress.XtraEditors.HyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picProduct
            // 
            this.picProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picProduct.Location = new System.Drawing.Point(-1, 1);
            this.picProduct.Name = "picProduct";
            this.picProduct.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.picProduct.Properties.NullText = "{Rỗng}";
            this.picProduct.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picProduct.Size = new System.Drawing.Size(233, 189);
            this.picProduct.TabIndex = 0;
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "Tải logo";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(2, 198);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hyperLinkEdit1.Properties.Appearance.Options.UseFont = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(78, 26);
            this.hyperLinkEdit1.TabIndex = 2;
            this.hyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEdit1_OpenLink);
            // 
            // hyperLinkEdit2
            // 
            this.hyperLinkEdit2.EditValue = "Huỷ";
            this.hyperLinkEdit2.Location = new System.Drawing.Point(94, 197);
            this.hyperLinkEdit2.Name = "hyperLinkEdit2";
            this.hyperLinkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hyperLinkEdit2.Properties.Appearance.Options.UseFont = true;
            this.hyperLinkEdit2.Size = new System.Drawing.Size(46, 28);
            this.hyperLinkEdit2.TabIndex = 3;
            this.hyperLinkEdit2.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEdit2_OpenLink);
            // 
            // hyperLinkEdit3
            // 
            this.hyperLinkEdit3.EditValue = "Thoát";
            this.hyperLinkEdit3.Location = new System.Drawing.Point(155, 197);
            this.hyperLinkEdit3.Name = "hyperLinkEdit3";
            this.hyperLinkEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hyperLinkEdit3.Properties.Appearance.Options.UseFont = true;
            this.hyperLinkEdit3.Size = new System.Drawing.Size(71, 28);
            this.hyperLinkEdit3.TabIndex = 4;
            this.hyperLinkEdit3.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEdit3_OpenLink);
            // 
            // frmTaiAnh
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(231, 236);
            this.Controls.Add(this.hyperLinkEdit3);
            this.Controls.Add(this.hyperLinkEdit2);
            this.Controls.Add(this.hyperLinkEdit1);
            this.Controls.Add(this.picProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmTaiAnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tải logo";
            this.Load += new System.EventHandler(this.frmTaiAnh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picProduct;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit2;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit3;

    }
}