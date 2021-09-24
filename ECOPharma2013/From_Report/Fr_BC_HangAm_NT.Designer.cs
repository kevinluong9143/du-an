namespace ECOPharma2013.From_Report
{
    partial class Fr_BC_HangAm_NT
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
            this.RW_BC_HangAm = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_BC_HangAm
            // 
            this.RW_BC_HangAm.ActiveViewIndex = -1;
            this.RW_BC_HangAm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_BC_HangAm.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_BC_HangAm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_BC_HangAm.Location = new System.Drawing.Point(0, 0);
            this.RW_BC_HangAm.Name = "RW_BC_HangAm";
            this.RW_BC_HangAm.Size = new System.Drawing.Size(968, 626);
            this.RW_BC_HangAm.TabIndex = 1;
            this.RW_BC_HangAm.Load += new System.EventHandler(this.RW_BC_TonKho_Load);
            // 
            // Fr_BC_HangAm_NT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.RW_BC_HangAm);
            this.Name = "Fr_BC_HangAm_NT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Hàng Âm Nhà Thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RW_BC_HangAm;
    }
}