namespace SuperX
{
    partial class ucPhong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhong));
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.picLoaiPhong = new System.Windows.Forms.PictureBox();
            this.picTrangThai = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoaiPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrangThai)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTenPhong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenPhong.Location = new System.Drawing.Point(0, 90);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(100, 41);
            this.lblTenPhong.TabIndex = 1;
            this.lblTenPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLoaiPhong
            // 
            this.picLoaiPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLoaiPhong.Image = ((System.Drawing.Image)(resources.GetObject("picLoaiPhong.Image")));
            this.picLoaiPhong.Location = new System.Drawing.Point(100, 90);
            this.picLoaiPhong.Name = "picLoaiPhong";
            this.picLoaiPhong.Size = new System.Drawing.Size(50, 41);
            this.picLoaiPhong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoaiPhong.TabIndex = 2;
            this.picLoaiPhong.TabStop = false;
            // 
            // picTrangThai
            // 
            this.picTrangThai.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTrangThai.Image = global::SuperX.Properties.Resources._1454839877_Open_Sign;
            this.picTrangThai.Location = new System.Drawing.Point(0, 0);
            this.picTrangThai.Name = "picTrangThai";
            this.picTrangThai.Size = new System.Drawing.Size(150, 90);
            this.picTrangThai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picTrangThai.TabIndex = 0;
            this.picTrangThai.TabStop = false;
            // 
            // ucPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picLoaiPhong);
            this.Controls.Add(this.lblTenPhong);
            this.Controls.Add(this.picTrangThai);
            this.Name = "ucPhong";
            this.Size = new System.Drawing.Size(150, 131);
            this.Load += new System.EventHandler(this.ucPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLoaiPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrangThai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTrangThai;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.PictureBox picLoaiPhong;
    }
}
