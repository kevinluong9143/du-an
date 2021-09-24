namespace ECOPharma2013
{
    partial class frmUserEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnDong = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.txtMK2 = new System.Windows.Forms.TextBox();
            this.txtMK1 = new System.Windows.Forms.TextBox();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNhom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radMultiColumnComboBoxTenNV = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMultiColumnComboBoxTenNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMultiColumnComboBoxTenNV.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMultiColumnComboBoxTenNV.EditorControl.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemMoi,
            this.btnLuu,
            this.btnDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(585, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.Image")));
            this.btnThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(101, 25);
            this.btnThemMoi.Text = "Thêm Mới";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(56, 25);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(68, 25);
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 289);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(585, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(14, 21);
            this.statusTB.Text = " ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckKhongDung);
            this.panel1.Controls.Add(this.txtMK2);
            this.panel1.Controls.Add(this.txtMK1);
            this.panel1.Controls.Add(this.txtTenDN);
            this.panel1.Controls.Add(this.lblMaNV);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboNhom);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radMultiColumnComboBoxTenNV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 261);
            this.panel1.TabIndex = 2;
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(205, 233);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(171, 24);
            this.ckKhongDung.TabIndex = 13;
            this.ckKhongDung.Text = "Khóa Tài Khoản Này";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            // 
            // txtMK2
            // 
            this.txtMK2.Location = new System.Drawing.Point(205, 151);
            this.txtMK2.Name = "txtMK2";
            this.txtMK2.PasswordChar = '*';
            this.txtMK2.Size = new System.Drawing.Size(236, 26);
            this.txtMK2.TabIndex = 11;
            // 
            // txtMK1
            // 
            this.txtMK1.Location = new System.Drawing.Point(205, 108);
            this.txtMK1.Name = "txtMK1";
            this.txtMK1.PasswordChar = '*';
            this.txtMK1.Size = new System.Drawing.Size(236, 26);
            this.txtMK1.TabIndex = 10;
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(205, 65);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(236, 26);
            this.txtTenDN.TabIndex = 9;
            this.txtTenDN.TextChanged += new System.EventHandler(this.txtTenDN_TextChanged);
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaNV.Location = new System.Drawing.Point(453, 24);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(15, 22);
            this.lblMaNV.TabIndex = 8;
            this.lblMaNV.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Thuộc Nhóm:";
            // 
            // cboNhom
            // 
            this.cboNhom.FormattingEnabled = true;
            this.cboNhom.Location = new System.Drawing.Point(205, 193);
            this.cboNhom.Name = "cboNhom";
            this.cboNhom.Size = new System.Drawing.Size(236, 28);
            this.cboNhom.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nhập Lại Mật Khẩu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật Khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Đăng Nhập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Nhân Viên:";
            // 
            // radMultiColumnComboBoxTenNV
            // 
            // 
            // radMultiColumnComboBoxTenNV.NestedRadGridView
            // 
            this.radMultiColumnComboBoxTenNV.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.radMultiColumnComboBoxTenNV.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMultiColumnComboBoxTenNV.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radMultiColumnComboBoxTenNV.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radMultiColumnComboBoxTenNV.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.radMultiColumnComboBoxTenNV.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.radMultiColumnComboBoxTenNV.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.radMultiColumnComboBoxTenNV.EditorControl.MasterTemplate.EnableGrouping = false;
            this.radMultiColumnComboBoxTenNV.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.radMultiColumnComboBoxTenNV.EditorControl.Name = "NestedRadGridView";
            this.radMultiColumnComboBoxTenNV.EditorControl.ReadOnly = true;
            this.radMultiColumnComboBoxTenNV.EditorControl.ShowGroupPanel = false;
            this.radMultiColumnComboBoxTenNV.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.radMultiColumnComboBoxTenNV.EditorControl.TabIndex = 0;
            this.radMultiColumnComboBoxTenNV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMultiColumnComboBoxTenNV.Location = new System.Drawing.Point(205, 22);
            this.radMultiColumnComboBoxTenNV.Name = "radMultiColumnComboBoxTenNV";
            // 
            // 
            // 
            this.radMultiColumnComboBoxTenNV.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radMultiColumnComboBoxTenNV.Size = new System.Drawing.Size(236, 27);
            this.radMultiColumnComboBoxTenNV.TabIndex = 0;
            this.radMultiColumnComboBoxTenNV.TabStop = false;
            this.radMultiColumnComboBoxTenNV.SelectedIndexChanged += new System.EventHandler(this.radMultiColumnComboBoxTenNV_SelectedIndexChanged);
            // 
            // frmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 315);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Tài Khoản Đăng Nhập";
            this.Load += new System.EventHandler(this.frmUserEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUserEdit_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMultiColumnComboBoxTenNV.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMultiColumnComboBoxTenNV.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMultiColumnComboBoxTenNV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private System.Windows.Forms.ToolStripButton btnThemMoi;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnDong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMK2;
        private System.Windows.Forms.TextBox txtMK1;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNhom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadMultiColumnComboBox radMultiColumnComboBoxTenNV;
        private System.Windows.Forms.CheckBox ckKhongDung;
    }
}