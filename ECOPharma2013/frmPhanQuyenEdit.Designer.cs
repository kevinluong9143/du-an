namespace ECOPharma2013
{
    partial class frmPhanQuyenEdit
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn4 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanQuyenEdit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rgvQuyen = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNhom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMenu = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.rbtnLuu = new System.Windows.Forms.ToolStripButton();
            this.rbtnDong = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnDong = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listNghiepVu = new Telerik.WinControls.UI.RadListControl();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvQuyen.MasterTemplate)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listNghiepVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rgvQuyen);
            this.groupBox1.Location = new System.Drawing.Point(374, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 535);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quyền Truy Cập";
            // 
            // rgvQuyen
            // 
            this.rgvQuyen.BackColor = System.Drawing.SystemColors.Control;
            this.rgvQuyen.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvQuyen.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.rgvQuyen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvQuyen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvQuyen.Location = new System.Drawing.Point(3, 20);
            // 
            // rgvQuyen
            // 
            this.rgvQuyen.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "QuyenID";
            gridViewTextBoxColumn1.HeaderText = "QuyenID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colQuyenID";
            gridViewTextBoxColumn2.FieldName = "NhomNDID";
            gridViewTextBoxColumn2.HeaderText = "NhomID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colNhomNDID";
            gridViewTextBoxColumn3.FieldName = "TenForm";
            gridViewTextBoxColumn3.HeaderText = "Nghiệp Vụ";
            gridViewTextBoxColumn3.Name = "colTenForm";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 250;
            gridViewCheckBoxColumn1.FieldName = "Xem";
            gridViewCheckBoxColumn1.HeaderText = "Xem";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colXem";
            gridViewCheckBoxColumn1.Width = 80;
            gridViewCheckBoxColumn2.FieldName = "Them_Sua";
            gridViewCheckBoxColumn2.HeaderText = "Thêm/Sửa";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "colThem_Sua";
            gridViewCheckBoxColumn2.Width = 80;
            gridViewCheckBoxColumn3.FieldName = "Xoa";
            gridViewCheckBoxColumn3.HeaderText = "Xóa";
            gridViewCheckBoxColumn3.MinWidth = 20;
            gridViewCheckBoxColumn3.Name = "colXoa";
            gridViewCheckBoxColumn3.Width = 80;
            gridViewCheckBoxColumn4.FieldName = "Inn";
            gridViewCheckBoxColumn4.HeaderText = "In";
            gridViewCheckBoxColumn4.MinWidth = 20;
            gridViewCheckBoxColumn4.Name = "colInn";
            gridViewCheckBoxColumn4.Width = 80;
            gridViewTextBoxColumn4.FieldName = "MenuID";
            gridViewTextBoxColumn4.HeaderText = "MenuID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colMenuID";
            gridViewTextBoxColumn5.FieldName = "FormID";
            gridViewTextBoxColumn5.HeaderText = "FormID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "colFormID";
            this.rgvQuyen.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2,
            gridViewCheckBoxColumn3,
            gridViewCheckBoxColumn4,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.rgvQuyen.Name = "rgvQuyen";
            this.rgvQuyen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvQuyen.ShowGroupPanel = false;
            this.rgvQuyen.Size = new System.Drawing.Size(586, 512);
            this.rgvQuyen.TabIndex = 0;
            this.rgvQuyen.Text = "radGridView1";
            this.rgvQuyen.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvQuyen_CellEndEdit);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Location = new System.Drawing.Point(0, 614);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(978, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(13, 20);
            this.statusTB.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhóm Người Dùng:";
            // 
            // cboNhom
            // 
            this.cboNhom.FormattingEnabled = true;
            this.cboNhom.Location = new System.Drawing.Point(194, 30);
            this.cboNhom.Name = "cboNhom";
            this.cboNhom.Size = new System.Drawing.Size(266, 26);
            this.cboNhom.TabIndex = 3;
            this.cboNhom.SelectedIndexChanged += new System.EventHandler(this.cboNhom_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(567, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Menu:";
            // 
            // cboMenu
            // 
            this.cboMenu.FormattingEnabled = true;
            this.cboMenu.Location = new System.Drawing.Point(640, 30);
            this.cboMenu.Name = "cboMenu";
            this.cboMenu.Size = new System.Drawing.Size(266, 26);
            this.cboMenu.TabIndex = 5;
            this.cboMenu.SelectedIndexChanged += new System.EventHandler(this.cboMenu_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rbtnLuu,
            this.rbtnDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(978, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // rbtnLuu
            // 
            this.rbtnLuu.Image = ((System.Drawing.Image)(resources.GetObject("rbtnLuu.Image")));
            this.rbtnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rbtnLuu.Name = "rbtnLuu";
            this.rbtnLuu.Size = new System.Drawing.Size(53, 24);
            this.rbtnLuu.Text = "Lưu";
            this.rbtnLuu.Click += new System.EventHandler(this.rbtnLuu_Click);
            // 
            // rbtnDong
            // 
            this.rbtnDong.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDong.Image")));
            this.rbtnDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rbtnDong.Name = "rbtnDong";
            this.rbtnDong.Size = new System.Drawing.Size(66, 24);
            this.rbtnDong.Text = "Đóng";
            this.rbtnDong.Click += new System.EventHandler(this.rbtnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(53, 24);
            this.btnLuu.Text = "Lưu";
            // 
            // btnDong
            // 
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(66, 24);
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listNghiepVu);
            this.groupBox2.Location = new System.Drawing.Point(0, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 535);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nghiệp Vụ";
            // 
            // listNghiepVu
            // 
            this.listNghiepVu.CaseSensitiveSort = true;
            this.listNghiepVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listNghiepVu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNghiepVu.ItemHeight = 22;
            this.listNghiepVu.Location = new System.Drawing.Point(3, 20);
            this.listNghiepVu.Name = "listNghiepVu";
            this.listNghiepVu.Size = new System.Drawing.Size(330, 512);
            this.listNghiepVu.TabIndex = 0;
            this.listNghiepVu.Text = "radListControl1";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(341, 251);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 25);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = ">>";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmPhanQuyenEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 636);
            this.ControlBox = false;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cboMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboNhom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPhanQuyenEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân Quyền";
            this.Load += new System.EventHandler(this.frmPhanQuyenEdit_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvQuyen.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvQuyen)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listNghiepVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private Telerik.WinControls.UI.RadGridView rgvQuyen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNhom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMenu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnDong;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadListControl listNghiepVu;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private System.Windows.Forms.ToolStripButton rbtnDong;
        private System.Windows.Forms.ToolStripButton rbtnLuu;
    }
}