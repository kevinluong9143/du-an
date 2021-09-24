using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.Report1;
using CrystalDecisions.Shared;
using ECOPharma2013.DuLieu;
using Telerik.WinControls.Data;
using Telerik.WinControls;
using ECOPharma2013.SQL;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using CrystalDecisions.Shared;
using System.IO;
using System.Runtime.InteropServices;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_LichSuGiaBan : Form
    {
        public Fr_BC_LichSuGiaBan()
        {
            InitializeComponent();
        }
        private void XuLyTuNgay()
        {
            DateTime denngay = dtDenNgay.Value;
            DateTime ngaytruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
            dtTuNgay.Value = ngaytruoc;
        
        }
        void LayDanhSachNhaThuocLenCombobox()
        {
            CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
            cboNhaThuoc.DisplayMember = "TenNT";
            cboNhaThuoc.ValueMember = "NTID";
            cboNhaThuoc.DataSource = chct.LayDSNhaThuoc();
            cboNhaThuoc.SelectedIndex = -1;
        }

        DataTable dtblichsumuaban = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {

            string TuNgay = Convert.ToDateTime(dtTuNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string DenNgay = Convert.ToDateTime(dtDenNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");

            CSQLLichSuGiaMuaBan lichsumuaban = new CSQLLichSuGiaMuaBan();

            dtblichsumuaban = lichsumuaban.BaoCaoLichSuGiaMuaBan_LoadDSTuNgay_DenNgay_NTid(TuNgay, DenNgay, cboNhaThuoc.SelectedValue.ToString());

            if (dtblichsumuaban != null && dtblichsumuaban.Rows.Count > 0)
            {
                rgvLichSuMuaBan.DataSource = dtblichsumuaban;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin sản phẩm để kiểm tra!");
            }

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RbtNT_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (RbtNT.IsChecked == true)
            {
                cboNhaThuoc.Enabled = true;
            }
            else
            {
                cboNhaThuoc.SelectedIndex = -1;
                cboNhaThuoc.Enabled = false;
            }
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtDenNgay.Value < dtTuNgay.Value)
            {
                MessageBox.Show("Đến ngày không được nhỏ hơn từ ngày");
                btnXem.Enabled = false;
            }
            else
            {
                btnXem.Enabled = true;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (rgvLichSuMuaBan.Rows.Count > 0)
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenIn("Fr_BC_LichSuGiaBan") == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvLichSuMuaBan);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\tempLichSuMuaBan.xls";
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
                    wb.SaveAs(f.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
                    wb.Close();
                    app.Quit();

                    Marshal.ReleaseComObject(wb);
                    Marshal.ReleaseComObject(app);

                    File.Delete(tempPath);
                    MessageBox.Show("File đã xuất thành công, kiểm tra lại file tại : " + f.FileName);
                }
            }
        }
        private void Fr_BC_LichSuGiaBan_Load(object sender, EventArgs e)
        {
            LayDanhSachNhaThuocLenCombobox();
            dtDenNgay.Value = DateTime.Now;
            XuLyTuNgay();
        }
    }
}
