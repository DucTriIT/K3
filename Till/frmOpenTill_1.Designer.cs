namespace GoldRT
{
    partial class frmOpenTill_1
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
            this.btnOpenTill = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtTill = new DevExpress.XtraEditors.TextEdit();
            this.picProduct = new DevExpress.XtraEditors.PictureEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenTill
            // 
            this.btnOpenTill.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenTill.Appearance.Options.UseFont = true;
            this.btnOpenTill.Location = new System.Drawing.Point(8, 131);
            this.btnOpenTill.Name = "btnOpenTill";
            this.btnOpenTill.Size = new System.Drawing.Size(413, 31);
            this.btnOpenTill.StyleController = this.layoutControl1;
            this.btnOpenTill.TabIndex = 1;
            this.btnOpenTill.Text = "Mở quầy";
            this.btnOpenTill.Click += new System.EventHandler(this.btnOpenTill_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtTill);
            this.layoutControl1.Controls.Add(this.picProduct);
            this.layoutControl1.Controls.Add(this.btnOpenTill);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(428, 169);
            this.layoutControl1.TabIndex = 8;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtTill
            // 
            this.txtTill.Location = new System.Drawing.Point(159, 92);
            this.txtTill.Name = "txtTill";
            this.txtTill.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTill.Properties.Appearance.Options.UseFont = true;
            this.txtTill.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTill.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtTill.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTill.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtTill.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTill.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtTill.Properties.PasswordChar = '|';
            this.txtTill.Size = new System.Drawing.Size(262, 28);
            this.txtTill.StyleController = this.layoutControl1;
            this.txtTill.TabIndex = 0;
            this.txtTill.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTill_KeyPress);
            // 
            // picProduct
            // 
            this.picProduct.BackgroundImage = global::SuperX.Properties.Resources.barcode;
            this.picProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picProduct.Location = new System.Drawing.Point(159, 8);
            this.picProduct.Name = "picProduct";
            this.picProduct.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picProduct.Properties.Appearance.Options.UseBackColor = true;
            this.picProduct.Properties.NullText = "{rỗng}";
            this.picProduct.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picProduct.Size = new System.Drawing.Size(262, 73);
            this.picProduct.StyleController = this.layoutControl1;
            this.picProduct.TabIndex = 35;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(428, 169);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.btnOpenTill;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Size = new System.Drawing.Size(424, 42);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AllowHotTrack = false;
            this.layoutControlItem5.Control = this.picProduct;
            this.layoutControlItem5.CustomizationFormText = "   ";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Size = new System.Drawing.Size(424, 84);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Text = "   ";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(146, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 14.25F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtTill;
            this.layoutControlItem1.CustomizationFormText = "Mã quầy thu ngân";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(424, 39);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "Mã quầy thu ngân";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(146, 20);
            // 
            // frmOpenTill_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 169);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmOpenTill_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mở quầy thu ngân đầu ngày";
            this.Load += new System.EventHandler(this.frmOpenTill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOpenTill;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.PictureEdit picProduct;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtTill;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}