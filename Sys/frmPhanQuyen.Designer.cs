namespace GoldRT
{
    partial class frmPhanQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanQuyen));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboGroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnUpdateMenu = new DevExpress.XtraEditors.SimpleButton();
            this.tvMenu = new DevExpress.XtraTreeList.TreeList();
            this.MenuDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCheck = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(34, 21);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nhóm NSD";
            // 
            // cboGroup
            // 
            this.cboGroup.Location = new System.Drawing.Point(162, 17);
            this.cboGroup.Margin = new System.Windows.Forms.Padding(4);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGroup.Properties.Appearance.Options.UseFont = true;
            this.cboGroup.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboGroup.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboGroup.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboGroup.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboGroup.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboGroup.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboGroup.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboGroup.Size = new System.Drawing.Size(495, 24);
            this.cboGroup.TabIndex = 1;
            this.cboGroup.Tag = "SYS_GROUPS";
            this.cboGroup.SelectedIndexChanged += new System.EventHandler(this.cboGroup_SelectedIndexChanged);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(18, 18);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // btnUpdateMenu
            // 
            this.btnUpdateMenu.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnUpdateMenu.Appearance.Options.UseFont = true;
            this.btnUpdateMenu.Location = new System.Drawing.Point(8, 644);
            this.btnUpdateMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateMenu.Name = "btnUpdateMenu";
            this.btnUpdateMenu.Size = new System.Drawing.Size(160, 42);
            this.btnUpdateMenu.TabIndex = 5;
            this.btnUpdateMenu.Text = "Update menu";
            this.btnUpdateMenu.Visible = false;
            this.btnUpdateMenu.Click += new System.EventHandler(this.btnUpdateMenu_Click);
            // 
            // tvMenu
            // 
            this.tvMenu.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.Empty.Options.UseFont = true;
            this.tvMenu.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.EvenRow.Options.UseFont = true;
            this.tvMenu.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.FixedLine.Options.UseFont = true;
            this.tvMenu.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.FocusedCell.Options.UseFont = true;
            this.tvMenu.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.FocusedRow.Options.UseFont = true;
            this.tvMenu.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.FooterPanel.Options.UseFont = true;
            this.tvMenu.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.GroupButton.Options.UseFont = true;
            this.tvMenu.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.GroupFooter.Options.UseFont = true;
            this.tvMenu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.HeaderPanel.Options.UseFont = true;
            this.tvMenu.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.HideSelectionRow.Options.UseFont = true;
            this.tvMenu.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.HorzLine.Options.UseFont = true;
            this.tvMenu.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.OddRow.Options.UseFont = true;
            this.tvMenu.Appearance.Preview.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.Preview.Options.UseFont = true;
            this.tvMenu.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.Row.Options.UseFont = true;
            this.tvMenu.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.SelectedRow.Options.UseFont = true;
            this.tvMenu.Appearance.TreeLine.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.TreeLine.Options.UseFont = true;
            this.tvMenu.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 12F);
            this.tvMenu.Appearance.VertLine.Options.UseFont = true;
            this.tvMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.MenuDesc,
            this.colCheck});
            this.tvMenu.KeyFieldName = "MenuID";
            this.tvMenu.Location = new System.Drawing.Point(8, 53);
            this.tvMenu.Margin = new System.Windows.Forms.Padding(4);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.tvMenu.RootValue = "";
            this.tvMenu.Size = new System.Drawing.Size(828, 522);
            this.tvMenu.StateImageList = this.imageList2;
            this.tvMenu.TabIndex = 6;
            this.tvMenu.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.tvMenu_GetStateImage);
            this.tvMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvMenu_MouseDown);
            // 
            // MenuDesc
            // 
            this.MenuDesc.Caption = "Chức năng";
            this.MenuDesc.FieldName = "MenuDesc";
            this.MenuDesc.MinWidth = 33;
            this.MenuDesc.Name = "MenuDesc";
            this.MenuDesc.OptionsColumn.AllowEdit = false;
            this.MenuDesc.OptionsColumn.AllowFocus = false;
            this.MenuDesc.OptionsColumn.AllowMove = false;
            this.MenuDesc.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.MenuDesc.Visible = true;
            this.MenuDesc.VisibleIndex = 0;
            // 
            // colCheck
            // 
            this.colCheck.Caption = "Check";
            this.colCheck.FieldName = "Check";
            this.colCheck.Name = "colCheck";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageIndex = 5;
            this.btnThoat.ImageList = this.imageCollection;
            this.btnThoat.Location = new System.Drawing.Point(707, 590);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(124, 42);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Appearance.Options.UseFont = true;
            this.btnCapNhat.ImageIndex = 3;
            this.btnCapNhat.ImageList = this.imageCollection;
            this.btnCapNhat.Location = new System.Drawing.Point(553, 590);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(146, 42);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "&Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // frmPhanQuyen
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 645);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.tvMenu);
            this.Controls.Add(this.btnUpdateMenu);
            this.Controls.Add(this.cboGroup);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhanQuyen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền chức năng";
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboGroup;
        private DevExpress.XtraEditors.SimpleButton btnUpdateMenu;
        private DevExpress.XtraTreeList.TreeList tvMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn MenuDesc;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCheck;
        private System.Windows.Forms.ImageList imageList2;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
    }
}