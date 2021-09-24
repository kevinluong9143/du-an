namespace ECOPharma2013.From_Report
{
    partial class Fr_NT_DieuChinhTonKho
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
            this.RW_NT_DieuChinhTonKho = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_NT_DieuChinhTonKho
            // 
            this.RW_NT_DieuChinhTonKho.ActiveViewIndex = -1;
            this.RW_NT_DieuChinhTonKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_NT_DieuChinhTonKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_NT_DieuChinhTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_NT_DieuChinhTonKho.Location = new System.Drawing.Point(0, 0);
            this.RW_NT_DieuChinhTonKho.Name = "RW_NT_DieuChinhTonKho";
            this.RW_NT_DieuChinhTonKho.Size = new System.Drawing.Size(968, 626);
            this.RW_NT_DieuChinhTonKho.TabIndex = 0;
            this.RW_NT_DieuChinhTonKho.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Fr_NT_DieuChinhTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.RW_NT_DieuChinhTonKho);
            this.Name = "Fr_NT_DieuChinhTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều Chỉnh Tồn Nhà Thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_NT_DieuChinhTonKho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RW_NT_DieuChinhTonKho;
    }
}