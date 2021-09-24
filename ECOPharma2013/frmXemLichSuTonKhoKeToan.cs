using ECOPharma2013.From_Report;
using ECOPharma2013.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI.Export;

namespace ECOPharma2013
{
    public partial class frmXemLichSuTonKhoKeToan : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        frmMain _frmMain;

        public frmXemLichSuTonKhoKeToan()
        {
        }

        public frmXemLichSuTonKhoKeToan(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;

            SendMessage(txtKey.Handle, EM_SETCUEBANNER, 0, "Mã/Tên sản phẩm");

            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            cboTenChiNhanh.DisplayMember = "TenNT";
            cboTenChiNhanh.ValueMember = "NTID";
            cboTenChiNhanh.DataSource = nhathuoc.LayDanhSachNhaThuocLenLuoi(_frmMain.IsXemTatCa_);
            cboTenChiNhanh.SelectedIndex = 9;

            dtNgay.MinDate = DateTime.Parse("2015/05/30");
            dtNgay.MaxDate = DateTime.Now;
            dtNgay.Value = DateTime.Now;

            LayThongTinLenLuoi(dtNgay.Value, "");
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string Key = txtKey.Text.Trim();
            if (rbtnXemTatCa.Checked)
            {
                Key = "";
            }
            if (cbXemChiTiet.Checked)
                LayThongTinLenLuoiChiTiet(dtNgay.Value, Key);
            else 
                LayThongTinLenLuoi(dtNgay.Value, Key);
        }
        
        private void LayThongTinLenLuoi(DateTime Ngay, string Key)
        {
            CSQLLSTonKhoKeToan aLSTonKhoKeToan = new CSQLLSTonKhoKeToan();
            DataTable dt = new DataTable();
            // DungLV hidden column ExDate and Lot Start
            rgvLichSuTonKho.Columns["colLot"].IsVisible = false;
            rgvLichSuTonKho.Columns["colExDate"].IsVisible = false;
            // DungLV hidden column ExDate and Lot End
            if (cboTenChiNhanh.SelectedValue.ToString().Equals("f08f270f-de84-480d-95f9-0b9cc1285f37"))
            {//Công ty
                dt = aLSTonKhoKeToan.LayThongTinLenLuoi(Ngay, Key);
            }
            else
            {//Nhà thuốc
                dt = aLSTonKhoKeToan.LayThongTinNhaThuocLenLuoi(Ngay, Key, cboTenChiNhanh.SelectedValue.ToString());
            }

            rgvLichSuTonKho.DataSource = dt;
        }
        // DungLV Add method lay thong tin len luoi chi tiet start
        private void LayThongTinLenLuoiChiTiet(DateTime Ngay, string Key)
        {
            CSQLLSTonKhoKeToan aLSTonKhoKeToan = new CSQLLSTonKhoKeToan();
            DataTable dt = new DataTable();
            // DungLV display column ExDate and Lot Start
            rgvLichSuTonKho.Columns["colLot"].IsVisible = true;
            rgvLichSuTonKho.Columns["colExDate"].IsVisible = true;
            // DungLV display column ExDate and Lot End
            if (cboTenChiNhanh.SelectedValue.ToString().Equals("f08f270f-de84-480d-95f9-0b9cc1285f37"))
            {//Công ty
                dt = aLSTonKhoKeToan.LayThongTinLenLuoiChiTiet(Ngay, Key);
            }
            else
            {//Nhà thuốc
                dt = aLSTonKhoKeToan.LayThongTinNhaThuocLenLuoiChiTiet(Ngay, Key, cboTenChiNhanh.SelectedValue.ToString());
            }

            rgvLichSuTonKho.DataSource = dt;
        }
        // DungLV Add method lay thong tin len luoi chi tiet End
        private void btnIn_Click(object sender, EventArgs e)
        {
            string Key = txtKey.Text.Trim();
            if (rbtnXemTatCa.Checked)
            {
                Key = "";
            }

            Fr_LichXuTonKhoKeToan aLichXuTonKhoKeToan = new Fr_LichXuTonKhoKeToan(dtNgay.Value, Key, cboTenChiNhanh.SelectedValue.ToString());
            aLichXuTonKhoKeToan.Show();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelML exporter = new ExportToExcelML(this.rgvLichSuTonKho);
            exporter.ExportVisualSettings = true;

            string tempPath = Path.GetTempPath();
            tempPath += @"\tempExport_" + cboTenChiNhanh.GetItemText(cboTenChiNhanh.SelectedItem) +"_"+DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
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
            //DungLV Thêm lịch sử tồn kho chi tiết start
            if (cbXemChiTiet.Checked)
                desktopPath += @"\LichSuTonKhoKeToanChiTiet_" + cboTenChiNhanh.GetItemText(cboTenChiNhanh.SelectedItem) + "_Ngay_" + dtNgay.Value.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xls";
            else
                desktopPath += @"\LichSuTonKhoKeToan_" + cboTenChiNhanh.GetItemText(cboTenChiNhanh.SelectedItem) + "_Ngay_" + dtNgay.Value.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xls";
            //desktopPath += @"\LichSuTonKhoKeToan_" + cboTenChiNhanh.GetItemText(cboTenChiNhanh.SelectedItem) + "_Ngay_" + dtNgay.Value.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xls";
            //DungLV Thêm lịch sử tồn kho chi tiết end
            wb.SaveAs(desktopPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
            wb.Close();
            app.Quit();

            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(app);

            File.Delete(tempPath);
            MessageBox.Show("File đã xuất thành công, kiểm tra lại file trên desktop!");
        }

        private void rbtnChonSP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnChonSP.Checked)
            {
                txtKey.Enabled = true;
            }
            else
            {
                txtKey.Enabled = false;
            }
        }

        private void cbXemChiTiet_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
