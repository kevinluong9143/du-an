﻿namespace ECOPharma2013.From_Report
{
    partial class Fr_DonHangNhap
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
            this.RW_DonHangNhap = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_DonHangNhap
            // 
            this.RW_DonHangNhap.ActiveViewIndex = -1;
            this.RW_DonHangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_DonHangNhap.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_DonHangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_DonHangNhap.Location = new System.Drawing.Point(0, 0);
            this.RW_DonHangNhap.Name = "RW_DonHangNhap";
            this.RW_DonHangNhap.Size = new System.Drawing.Size(968, 626);
            this.RW_DonHangNhap.TabIndex = 0;
            this.RW_DonHangNhap.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RW_DonHangNhap.Load += new System.EventHandler(this.Fr_DonHangNhap_Load);
            // 
            // Fr_DonHangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.RW_DonHangNhap);
            this.Name = "Fr_DonHangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn Hàng Nhập";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_DonHangNhap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RW_DonHangNhap;
    }
}