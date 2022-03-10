namespace GoldRT
{
    partial class frmPOStatistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOStatistic));
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cboCust = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tvTrnLst = new DevExpress.XtraTreeList.TreeList();
            this.DisplayField = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.layoutRight = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCust.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvTrnLst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cboCust);
            this.layoutControl1.Controls.Add(this.tvTrnLst);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(303, 526);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cboCust
            // 
            this.cboCust.Location = new System.Drawing.Point(97, 33);
            this.cboCust.Name = "cboCust";
            this.cboCust.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCust.Properties.Appearance.Options.UseFont = true;
            this.cboCust.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCust.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCust.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCust.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCust.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCust.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCust.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCust.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCust.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCust.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCust.Size = new System.Drawing.Size(197, 25);
            this.cboCust.StyleController = this.layoutControl1;
            this.cboCust.TabIndex = 2;
            this.cboCust.Tag = "SYS_GROUPS";
            this.cboCust.SelectedIndexChanged += new System.EventHandler(this.cboCust_SelectedIndexChanged);
            // 
            // tvTrnLst
            // 
            this.tvTrnLst.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.Empty.Options.UseFont = true;
            this.tvTrnLst.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.EvenRow.Options.UseFont = true;
            this.tvTrnLst.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.FixedLine.Options.UseFont = true;
            this.tvTrnLst.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.FocusedCell.Options.UseFont = true;
            this.tvTrnLst.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.FocusedRow.Options.UseFont = true;
            this.tvTrnLst.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.FooterPanel.Options.UseFont = true;
            this.tvTrnLst.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.GroupButton.Options.UseFont = true;
            this.tvTrnLst.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.GroupFooter.Options.UseFont = true;
            this.tvTrnLst.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.HeaderPanel.Options.UseFont = true;
            this.tvTrnLst.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.HideSelectionRow.Options.UseFont = true;
            this.tvTrnLst.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.HorzLine.Options.UseFont = true;
            this.tvTrnLst.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.OddRow.Options.UseFont = true;
            this.tvTrnLst.Appearance.Preview.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.Preview.Options.UseFont = true;
            this.tvTrnLst.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.Row.Options.UseFont = true;
            this.tvTrnLst.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.SelectedRow.Options.UseFont = true;
            this.tvTrnLst.Appearance.TreeLine.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.TreeLine.Options.UseFont = true;
            this.tvTrnLst.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.Appearance.VertLine.Options.UseFont = true;
            this.tvTrnLst.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.DisplayField});
            this.tvTrnLst.Font = new System.Drawing.Font("Arial", 12F);
            this.tvTrnLst.KeyFieldName = "NodeID";
            this.tvTrnLst.Location = new System.Drawing.Point(10, 66);
            this.tvTrnLst.Name = "tvTrnLst";
            this.tvTrnLst.Size = new System.Drawing.Size(284, 451);
            this.tvTrnLst.TabIndex = 4;
            this.tvTrnLst.SelectionChanged += new System.EventHandler(this.tvTrnLst_SelectionChanged);
            this.tvTrnLst.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tvTrnLst_FocusedNodeChanged);
            // 
            // DisplayField
            // 
            this.DisplayField.Caption = "Ngày kết toa";
            this.DisplayField.FieldName = "DisplayField";
            this.DisplayField.Name = "DisplayField";
            this.DisplayField.OptionsColumn.AllowEdit = false;
            this.DisplayField.OptionsColumn.AllowFocus = false;
            this.DisplayField.OptionsColumn.AllowMove = false;
            this.DisplayField.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.DisplayField.Visible = true;
            this.DisplayField.VisibleIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(303, 526);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup2.CustomizationFormText = "Thông tin giao dịch";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(301, 524);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Text = "Thông tin giao dịch";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHotTrack = false;
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.cboCust;
            this.layoutControlItem3.CustomizationFormText = "Khách hàng";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 33);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(122, 33);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(295, 33);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "Khách hàng";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(82, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHotTrack = false;
            this.layoutControlItem1.Control = this.tvTrnLst;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 33);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(111, 31);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(295, 462);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(303, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 526);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // layoutRight
            // 
            this.layoutRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRight.Location = new System.Drawing.Point(309, 0);
            this.layoutRight.Name = "layoutRight";
            this.layoutRight.Root = this.layoutControlGroup3;
            this.layoutRight.Size = new System.Drawing.Size(420, 526);
            this.layoutRight.TabIndex = 2;
            this.layoutRight.Text = "layoutControl2";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup3.Size = new System.Drawing.Size(420, 526);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup3.Text = "layoutControlGroup3";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // frmPOStatistic
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 526);
            this.Controls.Add(this.layoutRight);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPOStatistic";
            this.Text = "TK Toa hàng";
            this.Load += new System.EventHandler(this.frmPOStatistic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboCust.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvTrnLst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraTreeList.TreeList tvTrnLst;
        private DevExpress.XtraEditors.ComboBoxEdit cboCust;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraLayout.LayoutControl layoutRight;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn DisplayField;
    }
}