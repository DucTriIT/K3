namespace GoldRT
{
    partial class frmRTChangeProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRTChangeProduct));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.txtPay = new DevExpress.XtraEditors.TextEdit();
            this.txtSMDT = new DevExpress.XtraEditors.TextEdit();
            this.pnlChangeProdcut = new DevExpress.XtraEditors.PanelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangeProduct_OK = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.txtPayAmount_After = new DevExpress.XtraEditors.TextEdit();
            this.txtPayMount = new DevExpress.XtraEditors.TextEdit();
            this.txtBillCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChangeProdcut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount_After.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayMount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnIn);
            this.layoutControl1.Controls.Add(this.txtPay);
            this.layoutControl1.Controls.Add(this.txtSMDT);
            this.layoutControl1.Controls.Add(this.pnlChangeProdcut);
            this.layoutControl1.Controls.Add(this.btnThoat);
            this.layoutControl1.Controls.Add(this.btnChangeProduct_OK);
            this.layoutControl1.Controls.Add(this.txtPayAmount_After);
            this.layoutControl1.Controls.Add(this.txtPayMount);
            this.layoutControl1.Controls.Add(this.txtBillCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1105, 555);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(1004, 4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(41, 26);
            this.btnIn.StyleController = this.layoutControl1;
            this.btnIn.TabIndex = 8;
            this.btnIn.Text = "In HĐ";
            this.btnIn.UseWaitCursor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // txtPay
            // 
            this.txtPay.Enabled = false;
            this.txtPay.Location = new System.Drawing.Point(846, 7);
            this.txtPay.Name = "txtPay";
            this.txtPay.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtPay.Properties.Appearance.Options.UseBackColor = true;
            this.txtPay.Properties.DisplayFormat.FormatString = "#,##0";
            this.txtPay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPay.Properties.EditFormat.FormatString = "#,##0";
            this.txtPay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPay.Properties.Mask.EditMask = "n0";
            this.txtPay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPay.Size = new System.Drawing.Size(99, 20);
            this.txtPay.StyleController = this.layoutControl1;
            this.txtPay.TabIndex = 6;
            // 
            // txtSMDT
            // 
            this.txtSMDT.Enabled = false;
            this.txtSMDT.Location = new System.Drawing.Point(1104, 2);
            this.txtSMDT.Name = "txtSMDT";
            this.txtSMDT.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtSMDT.Properties.Appearance.Options.UseBackColor = true;
            this.txtSMDT.Properties.Mask.EditMask = "n0";
            this.txtSMDT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSMDT.Size = new System.Drawing.Size(0, 20);
            this.txtSMDT.StyleController = this.layoutControl1;
            this.txtSMDT.TabIndex = 9;
            // 
            // pnlChangeProdcut
            // 
            this.pnlChangeProdcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChangeProdcut.Location = new System.Drawing.Point(2, 33);
            this.pnlChangeProdcut.Name = "pnlChangeProdcut";
            this.pnlChangeProdcut.Size = new System.Drawing.Size(1102, 521);
            this.pnlChangeProdcut.TabIndex = 8;
            this.pnlChangeProdcut.Text = "panelControl1";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1050, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(41, 26);
            this.btnThoat.StyleController = this.layoutControl1;
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseWaitCursor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnChangeProduct_OK
            // 
            this.btnChangeProduct_OK.ImageList = this.imageCollection;
            this.btnChangeProduct_OK.Location = new System.Drawing.Point(953, 4);
            this.btnChangeProduct_OK.Name = "btnChangeProduct_OK";
            this.btnChangeProduct_OK.Size = new System.Drawing.Size(46, 26);
            this.btnChangeProduct_OK.StyleController = this.layoutControl1;
            this.btnChangeProduct_OK.TabIndex = 6;
            this.btnChangeProduct_OK.Text = "Đổi trả";
            this.btnChangeProduct_OK.UseWaitCursor = true;
            this.btnChangeProduct_OK.Click += new System.EventHandler(this.btnChangeProduct_OK_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // txtPayAmount_After
            // 
            this.txtPayAmount_After.Enabled = false;
            this.txtPayAmount_After.Location = new System.Drawing.Point(631, 7);
            this.txtPayAmount_After.Name = "txtPayAmount_After";
            this.txtPayAmount_After.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtPayAmount_After.Properties.Appearance.Options.UseBackColor = true;
            this.txtPayAmount_After.Properties.Mask.EditMask = "n0";
            this.txtPayAmount_After.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPayAmount_After.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPayAmount_After.Size = new System.Drawing.Size(91, 20);
            this.txtPayAmount_After.StyleController = this.layoutControl1;
            this.txtPayAmount_After.TabIndex = 5;
            // 
            // txtPayMount
            // 
            this.txtPayMount.Enabled = false;
            this.txtPayMount.Location = new System.Drawing.Point(417, 7);
            this.txtPayMount.Name = "txtPayMount";
            this.txtPayMount.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtPayMount.Properties.Appearance.Options.UseBackColor = true;
            this.txtPayMount.Properties.Mask.EditMask = "n0";
            this.txtPayMount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPayMount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPayMount.Size = new System.Drawing.Size(90, 20);
            this.txtPayMount.StyleController = this.layoutControl1;
            this.txtPayMount.TabIndex = 5;
            // 
            // txtBillCode
            // 
            this.txtBillCode.Enabled = false;
            this.txtBillCode.Location = new System.Drawing.Point(120, 7);
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtBillCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtBillCode.Size = new System.Drawing.Size(173, 20);
            this.txtBillCode.StyleController = this.layoutControl1;
            this.txtBillCode.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1105, 555);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 14F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtBillCode;
            this.layoutControlItem1.CustomizationFormText = "Hóa đơn";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(297, 31);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "Hóa đơn";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(108, 20);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(1092, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 31);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHotTrack = false;
            this.layoutControlItem2.Control = this.txtPayMount;
            this.layoutControlItem2.CustomizationFormText = "Tiền HĐ:";
            this.layoutControlItem2.Location = new System.Drawing.Point(297, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(214, 31);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "Tiền HĐ:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(108, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.Control = this.txtPayAmount_After;
            this.layoutControlItem3.CustomizationFormText = "Tiền HĐ sau khi đổi trả";
            this.layoutControlItem3.Location = new System.Drawing.Point(511, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(215, 31);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "Tiền HĐ sau khi đổi trả";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(108, 20);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AllowHotTrack = false;
            this.layoutControlItem4.Control = this.btnChangeProduct_OK;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(949, 0);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(51, 27);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(51, 31);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AllowHotTrack = false;
            this.layoutControlItem5.Control = this.btnThoat;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(1046, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(46, 27);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Size = new System.Drawing.Size(46, 31);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AllowHotTrack = false;
            this.layoutControlItem6.Control = this.pnlChangeProdcut;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem6.Size = new System.Drawing.Size(1103, 522);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AllowHotTrack = false;
            this.layoutControlItem7.Control = this.txtSMDT;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(1102, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 21);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(1, 21);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem7.Size = new System.Drawing.Size(1, 31);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AllowHotTrack = false;
            this.layoutControlItem8.Control = this.txtPay;
            this.layoutControlItem8.CustomizationFormText = "Thanh toán";
            this.layoutControlItem8.Location = new System.Drawing.Point(726, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem8.Size = new System.Drawing.Size(223, 31);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem8.Text = "Thanh toán";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(108, 20);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AllowHotTrack = false;
            this.layoutControlItem9.Control = this.btnIn;
            this.layoutControlItem9.CustomizationFormText = "In HĐ";
            this.layoutControlItem9.Location = new System.Drawing.Point(1000, 0);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(46, 27);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem9.Size = new System.Drawing.Size(46, 31);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem9.Text = "In HĐ";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // frmRTChangeProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1105, 555);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmRTChangeProduct";
            this.Text = "Đổi,trả hàng đã mua";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRTChangeProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChangeProdcut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount_After.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayMount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtPayMount;
        private DevExpress.XtraEditors.TextEdit txtBillCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.PanelControl pnlChangeProdcut;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnChangeProduct_OK;
        private DevExpress.XtraEditors.TextEdit txtPayAmount_After;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit txtSMDT;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.TextEdit txtPay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.Utils.ImageCollection imageCollection;
    }
}