namespace ECOPharma2013
{
    partial class FrmChuKyEdit
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDBCDong = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboNhomSP = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rbtnKetThucChuKy = new Telerik.WinControls.UI.RadButton();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnKetThucChuKy)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDBCDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(363, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDBCDong
            // 
            this.btnDBCDong.Image = global::ECOPharma2013.Properties.Resources.btnDBCDong_Image;
            this.btnDBCDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDBCDong.Name = "btnDBCDong";
            this.btnDBCDong.Size = new System.Drawing.Size(66, 24);
            this.btnDBCDong.Text = "Đóng";
            this.btnDBCDong.Click += new System.EventHandler(this.btnDBCDong_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.cboNhomSP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtnKetThucChuKy, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.09091F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(363, 66);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // cboNhomSP
            // 
            this.cboNhomSP.AutoCompleteDisplayMember = "TenNSP";
            this.cboNhomSP.AutoCompleteValueMember = "NSPID";
            this.cboNhomSP.DisplayMember = "TenNSP";
            this.cboNhomSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNhomSP.Location = new System.Drawing.Point(75, 3);
            this.cboNhomSP.Name = "cboNhomSP";
            this.cboNhomSP.ShowImageInEditorArea = true;
            this.cboNhomSP.Size = new System.Drawing.Size(285, 20);
            this.cboNhomSP.TabIndex = 0;
            this.cboNhomSP.ValueMember = "NSPID";
            // 
            // radLabel1
            // 
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(68, 16);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Chọn nhóm:";
            // 
            // rbtnKetThucChuKy
            // 
            this.rbtnKetThucChuKy.Location = new System.Drawing.Point(75, 29);
            this.rbtnKetThucChuKy.Name = "rbtnKetThucChuKy";
            this.rbtnKetThucChuKy.Size = new System.Drawing.Size(130, 24);
            this.rbtnKetThucChuKy.TabIndex = 2;
            this.rbtnKetThucChuKy.Text = "Kết thúc chu kỳ";
            this.rbtnKetThucChuKy.Click += new System.EventHandler(this.rbtnKetThucChuKy_Click);
            // 
            // FrmChuKyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 93);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChuKyEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết thúc chu kỳ";
            this.Load += new System.EventHandler(this.FrmChuKyEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnKetThucChuKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDBCDong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadDropDownList cboNhomSP;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton rbtnKetThucChuKy;
    }
}