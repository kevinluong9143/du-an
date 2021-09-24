namespace ECOPharma2013
{
    partial class frmNT_ThanhToanEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNT_ThanhToanEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhaiThu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDaNhan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTraKhach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQuayLai = new Telerik.WinControls.UI.RadButton();
            this.btnDaThu = new Telerik.WinControls.UI.RadButton();
            this.chkInChiTiet = new Telerik.WinControls.UI.RadCheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuayLai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDaThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 329);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(737, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(14, 21);
            this.statusTB.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tổng Tiền Phải Thu:";
            // 
            // txtPhaiThu
            // 
            this.txtPhaiThu.BackColor = System.Drawing.Color.Gold;
            this.txtPhaiThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhaiThu.Location = new System.Drawing.Point(352, 32);
            this.txtPhaiThu.Name = "txtPhaiThu";
            this.txtPhaiThu.ReadOnly = true;
            this.txtPhaiThu.Size = new System.Drawing.Size(259, 47);
            this.txtPhaiThu.TabIndex = 3;
            this.txtPhaiThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPhaiThu.TextChanged += new System.EventHandler(this.txtPhaiThu_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(21, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tổng Tiền Đã Nhận:";
            // 
            // txtDaNhan
            // 
            this.txtDaNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDaNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaNhan.Location = new System.Drawing.Point(352, 103);
            this.txtDaNhan.MaxLength = 10;
            this.txtDaNhan.Name = "txtDaNhan";
            this.txtDaNhan.Size = new System.Drawing.Size(259, 47);
            this.txtDaNhan.TabIndex = 5;
            this.txtDaNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDaNhan.TextChanged += new System.EventHandler(this.txtDaNhan_TextChanged);
            this.txtDaNhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDaNhan_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(28, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tiền Dư Trả Khách:";
            // 
            // txtTraKhach
            // 
            this.txtTraKhach.Enabled = false;
            this.txtTraKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraKhach.Location = new System.Drawing.Point(352, 174);
            this.txtTraKhach.Name = "txtTraKhach";
            this.txtTraKhach.ReadOnly = true;
            this.txtTraKhach.Size = new System.Drawing.Size(259, 47);
            this.txtTraKhach.TabIndex = 7;
            this.txtTraKhach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(617, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 39);
            this.label4.TabIndex = 8;
            this.label4.Text = "VNĐ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(617, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 39);
            this.label5.TabIndex = 8;
            this.label5.Text = "VNĐ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(617, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 39);
            this.label6.TabIndex = 8;
            this.label6.Text = "VNĐ";
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Image = ((System.Drawing.Image)(resources.GetObject("btnQuayLai.Image")));
            this.btnQuayLai.Location = new System.Drawing.Point(404, 245);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(188, 51);
            this.btnQuayLai.TabIndex = 10;
            this.btnQuayLai.Text = "Quay Lại - Esc";
            this.btnQuayLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // btnDaThu
            // 
            this.btnDaThu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaThu.Image = ((System.Drawing.Image)(resources.GetObject("btnDaThu.Image")));
            this.btnDaThu.Location = new System.Drawing.Point(192, 245);
            this.btnDaThu.Name = "btnDaThu";
            this.btnDaThu.Size = new System.Drawing.Size(188, 51);
            this.btnDaThu.TabIndex = 9;
            this.btnDaThu.Text = "Đã Thu - F9";
            this.btnDaThu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDaThu.Click += new System.EventHandler(this.btnDaThu_Click);
            // 
            // chkInChiTiet
            // 
            this.chkInChiTiet.Location = new System.Drawing.Point(12, 308);
            this.chkInChiTiet.Name = "chkInChiTiet";
            this.chkInChiTiet.Size = new System.Drawing.Size(70, 18);
            this.chkInChiTiet.TabIndex = 11;
            this.chkInChiTiet.Text = "In Chi Tiết";
            // 
            // frmNT_ThanhToanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 355);
            this.ControlBox = false;
            this.Controls.Add(this.chkInChiTiet);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnDaThu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTraKhach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDaNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPhaiThu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNT_ThanhToanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh Toán";
            this.Load += new System.EventHandler(this.frmNT_ThanhToanEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNT_ThanhToanEdit_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuayLai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDaThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhaiThu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDaNhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTraKhach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadButton btnDaThu;
        private Telerik.WinControls.UI.RadButton btnQuayLai;
        private Telerik.WinControls.UI.RadCheckBox chkInChiTiet;
    }
}