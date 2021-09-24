namespace ECOPharma2013
{
    partial class frmBaoCaoNhaThuoc
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Báo Cáo Tồn Kho Nhà Thuốc", 3, 3);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Báo Cáo Các Sản Phẩm Cận Date");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Báo Cáo Số Phiếu Hủy", 1, 1);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Báo Cáo Các Sản Phẩm Ít Bán", 2, 2);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Báo Cáo Hàng Âm", 4, 4);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Báo Cáo Sản Phẩm Chi Tiết", 5, 5);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Báo Cáo Tổng Số Lượng Xuất", 6, 6);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Báo Cáo Phiếu Nhập Kho", 7, 7);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Báo Cáo Thay Đổi Giá Bán", 8, 8);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoNhaThuoc));
            this.rtvBaoCaoNT = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtvBaoCaoNT
            // 
            this.rtvBaoCaoNT.BackColor = System.Drawing.SystemColors.Control;
            this.rtvBaoCaoNT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtvBaoCaoNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtvBaoCaoNT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtvBaoCaoNT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.rtvBaoCaoNT.ImageIndex = 0;
            this.rtvBaoCaoNT.ImageList = this.imageList1;
            this.rtvBaoCaoNT.Location = new System.Drawing.Point(3, 58);
            this.rtvBaoCaoNT.Name = "rtvBaoCaoNT";
            treeNode1.ImageIndex = 3;
            treeNode1.Name = "Báo Cáo Tồn Kho Nhà Thuốc";
            treeNode1.SelectedImageIndex = 3;
            treeNode1.Text = "Báo Cáo Tồn Kho Nhà Thuốc";
            treeNode2.Name = "Báo Cáo Các Sản Phẩm Cận Date";
            treeNode2.Text = "Báo Cáo Các Sản Phẩm Cận Date";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "Báo Cáo Số Phiếu Hủy";
            treeNode3.SelectedImageIndex = 1;
            treeNode3.Text = "Báo Cáo Số Phiếu Hủy";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "Báo Cáo Các Sản Phẩm Ít Bán";
            treeNode4.SelectedImageIndex = 2;
            treeNode4.Text = "Báo Cáo Các Sản Phẩm Ít Bán";
            treeNode5.ImageIndex = 4;
            treeNode5.Name = "Báo Cáo Hàng Âm";
            treeNode5.SelectedImageIndex = 4;
            treeNode5.Text = "Báo Cáo Hàng Âm";
            treeNode6.ImageIndex = 5;
            treeNode6.Name = "Báo Cáo Sản Phẩm Chi Tiết";
            treeNode6.SelectedImageIndex = 5;
            treeNode6.Text = "Báo Cáo Sản Phẩm Chi Tiết";
            treeNode7.ImageIndex = 6;
            treeNode7.Name = "Báo Cáo Tổng Số Lượng Xuất ";
            treeNode7.SelectedImageIndex = 6;
            treeNode7.Text = "Báo Cáo Tổng Số Lượng Xuất";
            treeNode8.ImageIndex = 7;
            treeNode8.Name = "Báo Cáo Phiếu Nhập Kho";
            treeNode8.SelectedImageIndex = 7;
            treeNode8.Text = "Báo Cáo Phiếu Nhập Kho";
            treeNode9.ImageIndex = 8;
            treeNode9.Name = "Báo Cáo Thay Đổi Giá Bán";
            treeNode9.SelectedImageIndex = 8;
            treeNode9.Text = "Báo Cáo Thay Đổi Giá Bán";
            this.rtvBaoCaoNT.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            this.rtvBaoCaoNT.SelectedImageIndex = 0;
            this.rtvBaoCaoNT.Size = new System.Drawing.Size(860, 403);
            this.rtvBaoCaoNT.TabIndex = 1;
            this.rtvBaoCaoNT.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.rtvBaoCaoNT_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CanDate.png");
            this.imageList1.Images.SetKeyName(1, "HuyPhieu.png");
            this.imageList1.Images.SetKeyName(2, "ItBan.png");
            this.imageList1.Images.SetKeyName(3, "TonKho.png");
            this.imageList1.Images.SetKeyName(4, "HangAm.png");
            this.imageList1.Images.SetKeyName(5, "drug40.png");
            this.imageList1.Images.SetKeyName(6, "N-X-T.png");
            this.imageList1.Images.SetKeyName(7, "NhapKho30.png");
            this.imageList1.Images.SetKeyName(8, "LoaiGia30.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rtvBaoCaoNT, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(866, 464);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(860, 49);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmBaoCaoNhaThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 464);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmBaoCaoNhaThuoc";
            this.Text = "Báo Cáo Tại Nhà Thuốc";
            this.Load += new System.EventHandler(this.frmBaoCaoNhaThuoc_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView rtvBaoCaoNT;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}