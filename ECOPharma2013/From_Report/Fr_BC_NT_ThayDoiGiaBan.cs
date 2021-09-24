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
using System.IO;
using System.Runtime.InteropServices;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_NT_ThayDoiGiaBan : Form
    {
        public Fr_BC_NT_ThayDoiGiaBan()
        {
            InitializeComponent();
        }

        private void XuLyTuNgay()
        {
            DateTime denngay = dtDenNgay.Value;
            DateTime ngaytruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
            dtTuNgay.Value = ngaytruoc;      
        }

        DataTable dtbLichSuGiaBan = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {
            Fr_DangXuLy.ShowFormCho();
            string TuNgay = Convert.ToDateTime(dtTuNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string DenNgay = Convert.ToDateTime(dtDenNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            CSQLNTThayDoiGiaSPCT px_ = new CSQLNTThayDoiGiaSPCT();
            dtbLichSuGiaBan = px_.BaoCaoNTTHAYDOIGIASPCT_TuNgay_DenNgay(TuNgay, DenNgay);
            if (dtbLichSuGiaBan != null && dtbLichSuGiaBan.Rows.Count > 0)
            {
                rgvThayDoiGiaCT.DataSource = dtbLichSuGiaBan;
            }
            else
            {
                MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
            }
            Fr_DangXuLy.DongFormCho();

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
            if (rgvThayDoiGiaCT.Rows.Count > 0)
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenIn("Fr_BC_NT_ThayDoiGiaBan") == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    Fr_DangXuLy.ShowFormCho();
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvThayDoiGiaCT);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\ThayDoiGiaSanPham.xls";
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
                    Fr_DangXuLy.DongFormCho();
                    MessageBox.Show("File đã xuất thành công, kiểm tra lại file tại : " + f.FileName);

                }
            }
        }

        private void Fr_BC_NT_ThayDoiGiaBan_Load(object sender, EventArgs e)
        {
            dtDenNgay.Value = DateTime.Now;
            XuLyTuNgay();
        }
   
    }
}
