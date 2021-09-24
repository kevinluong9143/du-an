﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;
using System.Drawing.Printing;
using System.IO;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.Runtime.InteropServices;
using ECOPharma2013.From_Report;

namespace ECOPharma2013
{
    public partial class frmNT_NhapKhoEdit : Form
    {
        frmMain _frmMain;
        public frmNT_NhapKhoEdit()
        {
            InitializeComponent();
        }
        public frmNT_NhapKhoEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        CSQLNT_NhapKho nt_nhapkho = new CSQLNT_NhapKho();
        CSQLNT_NhapKhoChiTiet nt_nhapkhoct = new CSQLNT_NhapKhoChiTiet();
        private void frmNT_NhapKhoEdit_Load(object sender, EventArgs e)
        {
            try
            {
                if (_frmMain.BangNT_NhapKho_ != null && _frmMain.BangNT_NhapKho_.Rows.Count > 0)
                {
                    if (bool.Parse(_frmMain.BangNT_NhapKho_.Rows[0]["XNPhieuNhap"].ToString()) == true || bool.Parse(_frmMain.BangNT_NhapKho_.Rows[0]["IsKhoDacBiet"].ToString()))
                    {
                        btnLuu.Enabled = false;
                        ((GridViewComboBoxColumn)MasterTemplate.Columns["colMaKho"]).ReadOnly = true;
                    }
                    lblSoCT.Text = _frmMain.BangNT_NhapKho_.Rows[0]["SoCTN"].ToString();
                    lblSoDH.Text = _frmMain.BangNT_NhapKho_.Rows[0]["SoDH"].ToString();
                    lblNgayNhap.Text = _frmMain.BangNT_NhapKho_.Rows[0]["NgayNhap"].ToString();
                    lblLoaiPhatSinh.Text = _frmMain.BangNT_NhapKho_.Rows[0]["LoaiPhatSinh"].ToString();
                    lblNhapTu.Text = _frmMain.BangNT_NhapKho_.Rows[0]["TenNT"].ToString();
                    ckDaXN.Checked = bool.Parse(_frmMain.BangNT_NhapKho_.Rows[0]["XNPhieuNhap"].ToString());

                    if (nt_nhapkhoct.LayDanhSachLenLuoi(_frmMain.MaNT_NhapKho_).Rows.Count > 0)
                    {
                        MasterTemplate.DataSource = nt_nhapkhoct.LayDanhSachLenLuoi(_frmMain.MaNT_NhapKho_);
                        MasterTemplate.CellFormatting += new CellFormattingEventHandler(MasterTemplate_CellFormatting);
                        LayKhoNhapVaoCombobox();
                        this.MasterTemplate.MasterTemplate.ShowTotals = true;
                        GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                        summaryItem.Name = "colTTGiaNKCoTAX";
                        summaryItem.Aggregate = GridAggregateFunction.Sum;
                        summaryItem.FormatString = "{0:N2}";
                        GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                        summaryRowItem.Add(summaryItem);
                        this.MasterTemplate.SummaryRowsTop.Add(summaryRowItem);
                        this.MasterTemplate.SummaryRowsBottom.Add(summaryRowItem);
                    }
                   
                }
                //LayKhoNhapVaoCombobox();
            }
            catch { }
        }

        void MasterTemplate_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "colSTT" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmNT_NhapKhoEditisOpen_ = false;
            this.Close(); 
        }
        string MaBPcon;
        void LayKhoNhapVaoCombobox()
        {
            try
            {
                CSQLKho kho_ = new CSQLKho();
                CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
                string mabp_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();
                CSQLBoPhan bp_ = new CSQLBoPhan();
                DataTable bpct_ = bp_.TimMaBPChaTheoMa(mabp_);
                string mabpcha = bpct_.Rows[0]["MaBPCha"].ToString();
                if (mabpcha != null && mabpcha.Length > 0)
                {
                    MaBPcon = mabpcha;
                }
                else
                {
                    MaBPcon = mabp_;
                }
                ((GridViewComboBoxColumn)MasterTemplate.Columns["colMaKho"]).DataSource = kho_.LoadKho_TongCongTy_NhapXuat(MaBPcon, bool.Parse(_frmMain.BangNT_NhapKho_.Rows[0]["IsKhoDacBiet"].ToString()));
                ((GridViewComboBoxColumn)MasterTemplate.Columns["colMaKho"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)MasterTemplate.Columns["colMaKho"]).ValueMember = "KhoID";
            }
            catch { }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_NhapKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            DataTable NT_nkct = nt_nhapkhoct.LayDanhSachLenLuoi(_frmMain.MaNT_NhapKho_);
            nt_nhapkhoct.ChinhSuaKhoNhap(NT_nkct);
        }

        private void MasterTemplate_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_NhapKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            if (MasterTemplate.CurrentCell.ColumnInfo.Name.CompareTo("colMaKho") == 0)
            {
                if (MasterTemplate.CurrentRow.Cells["colMaKho"].Value != null && MasterTemplate.CurrentRow.Cells["colMaKho"].Value.ToString().CompareTo("") > 0)
                {
                    CSQLNT_NhapKhoChiTiet dg = new CSQLNT_NhapKhoChiTiet();
                    int kq = dg.ChinhSuaKhoNhap(MasterTemplate.CurrentRow.Cells["colPNCTID"].Value.ToString(), MasterTemplate.CurrentRow.Cells["colMaKho"].Value.ToString());
                    if (kq > 0)
                    {
                        statusTB.Text = "Sửa thông tin kho thành công!";
                    }
                    else
                    {
                        statusTB.Text = "Sửa thông tin kho thất bại!";
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (rgvPhieuNhapChiTiet.Rows.Count > 0)
            {
                ExportToExcelML exporter = new ExportToExcelML(this.rgvPhieuNhapChiTiet);
                exporter.ExportVisualSettings = true;

                string tempPath = Path.GetTempPath();
                tempPath += @"\tempNhapKhoNhaThuoc" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
                exporter.RunExport(tempPath);

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                if (app == null)
                {
                    Console.WriteLine("EXCEL không thể kích hoạt. Kiểm tra lại cài đặt office và các tham chiếu đã chính xác hay chưa.");
                    return;
                }

                app.Visible = false;
                app.Interactive = false;

                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(tempPath);

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                desktopPath += @"\NhapKhoNhaThuoc" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";

                wb.SaveAs(desktopPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
                wb.Close();
                app.Quit();

                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(app);

                File.Delete(tempPath);
                MessageBox.Show("File đã xuất thành công, kiểm tra lại file trên desktop!");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_frmMain.BangNT_NhapKho_ != null && _frmMain.BangNT_NhapKho_.Rows.Count > 0)
            {
                DataTable DonHangNhapCT_ = nt_nhapkhoct.LayDanhSachLenLuoi(_frmMain.MaNT_NhapKho_);
                Fr_NT_NhapKho check = new Fr_NT_NhapKho(DonHangNhapCT_);
                check.Show();
            }
        }

    }
}
