namespace ECOPharma2013.From_Report
{
    partial class Fr_TonKhoCty
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
            this.RW_TonKhoCty = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_TonKhoCty
            // 
            this.RW_TonKhoCty.ActiveViewIndex = -1;
            this.RW_TonKhoCty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_TonKhoCty.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_TonKhoCty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_TonKhoCty.Location = new System.Drawing.Point(0, 0);
            this.RW_TonKhoCty.Name = "RW_TonKhoCty";
            this.RW_TonKhoCty.Size = new System.Drawing.Size(968, 626);
            this.RW_TonKhoCty.TabIndex = 0;
            this.RW_TonKhoCty.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Fr_TonKhoCty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.RW_TonKhoCty);
            this.Name = "Fr_TonKhoCty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tồn Kho Tổng Công Ty";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_TonKhoCty_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RW_TonKhoCty;
    }
}