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
    public partial class Fr_BC_TongSoLuongBan : Form
    {
        public Fr_BC_TongSoLuongBan()
        {
            InitializeComponent();
        }
        private void XuLyTuNgay()
        {
            DateTime denngay = dtDenNgay.Value;
            DateTime ngaytruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
            dtTuNgay.Value = ngaytruoc;
        
        }

        DataTable nxton = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {

            string TuNgay = Convert.ToDateTime(dtTuNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string DenNgay = Convert.ToDateTime(dtDenNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");

            CSQLNT_NhapXuatTon lichsumuaban = new CSQLNT_NhapXuatTon();

            nxton = lichsumuaban.BaoCao_SLXuat_TuNgay_DenNgay(TuNgay, DenNgay);

            if (nxton != null && nxton.Rows.Count > 0)
            {
                rgvTongSLBan.DataSource = nxton;
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
            if (rgvTongSLBan.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_TongSoLuongBan") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                ExportToExcelML exporter = new ExportToExcelML(this.rgvTongSLBan);
                exporter.ExportVisualSettings = true;

                string tempPath = Path.GetTempPath();
                tempPath += @"\tempLichSuMuaBan" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
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
                desktopPath += @"\LichSuMuaBan" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";

                wb.SaveAs(desktopPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
                wb.Close();
                app.Quit();

                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(app);

                File.Delete(tempPath);
                MessageBox.Show("File đã xuất thành công, kiểm tra lại file trên desktop!");
            }
        }
        private void Fr_BC_TongSoLuongBan_Load(object sender, EventArgs e)
        {
            dtDenNgay.Value = DateTime.Now;
            XuLyTuNgay();
        }
    }
}
