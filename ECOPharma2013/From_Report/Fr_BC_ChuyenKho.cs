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
using ECOPharma2013.SQL;
using ECOPharma2013.DuLieu;
using Telerik.WinControls.UI.Export;
using System.Runtime.InteropServices;
using System.IO;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_ChuyenKho : Form
    {
        public Fr_BC_ChuyenKho()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            CSQLChuyenKhoCT chuyenkhoct_ = new CSQLChuyenKhoCT();
            DataTable dtbchuyenkhoct_ = chuyenkhoct_.BaoCaoChuyenKho_LoadDataTheoSoCK(txtSoPhieuDC.Text);
            if (dtbchuyenkhoct_ != null && dtbchuyenkhoct_.Rows.Count > 0)
            {
                radLabelNoiDung.Text = dtbchuyenkhoct_.Rows[0]["GhiChu"].ToString();
                rgvBienBanKiemKe.DataSource = dtbchuyenkhoct_;
            }
            else
            {
                rgvBienBanKiemKe.DataSource = null;
                MessageBox.Show("Không có số Phiếu Chuyển Kho này. Vui lòng kiểm tra lại!");
            }

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (rgvBienBanKiemKe.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_ChuyenKho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvBienBanKiemKe);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\BienBanKiemKeCT.xls";
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
    }
}
