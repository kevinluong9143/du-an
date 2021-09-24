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
    public partial class Fr_BC_DinhMucTonKho : Form
    {
        public Fr_BC_DinhMucTonKho()
        {
            InitializeComponent();
        }


        DataTable dtbDinhMucTon = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtTuNgay.Value <= DateTime.Now)
            {
                Fr_DangXuLy.ShowFormCho();
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                dtbDinhMucTon = tonkhoct_.BaoCao_DinhMucTonKhoCacNT(dtTuNgay.Value);
                if (dtbDinhMucTon != null && dtbDinhMucTon.Rows.Count > 0)
                {
                    rgvDinhMucTonKho.DataSource = dtbDinhMucTon;
                }
                else
                {
                    MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                }
                Fr_DangXuLy.DongFormCho();

                CSQLXemForm xemForm = new CSQLXemForm();
                xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
            }
            MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (rgvDinhMucTonKho.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_DinhMucTonKho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvDinhMucTonKho);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\tempBaoCaoBanHang.xls";
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
        private void Fr_BC_DinhMucTonKho_Load(object sender, EventArgs e)
        {
            dtTuNgay.Value = DateTime.Now;
        }
    }
}
