namespace ECOPharma2013.From_Report
{
    partial class Fr_NhapXuatTon
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
            this.RW_NhapXuatTon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_NhapXuatTon
            // 
            this.RW_NhapXuatTon.ActiveViewIndex = -1;
            this.RW_NhapXuatTon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_NhapXuatTon.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_NhapXuatTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_NhapXuatTon.Location = new System.Drawing.Point(0, 0);
            this.RW_NhapXuatTon.Name = "RW_NhapXuatTon";
            this.RW_NhapXuatTon.Size = new System.Drawing.Size(755, 391);
            this.RW_NhapXuatTon.TabIndex = 0;
            this.RW_NhapXuatTon.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RW_NhapXuatTon.Load += new System.EventHandler(this.RW_NhapXuatTon_Load);
            // 
            // Fr_NhapXuatTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 391);
            this.Controls.Add(this.RW_NhapXuatTon);
            this.Name = "Fr_NhapXuatTon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Xuất Tồn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer RW_NhapXuatTon;

    }
}