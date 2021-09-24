using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using ECOPharma2013.Report1;
using CrystalDecisions.Shared;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Runtime.InteropServices;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_DonHangCho : Form
    {
        int _dk;
        public Fr_BC_DonHangCho()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            CSQLDonHangXuatCT dhxct_ = new CSQLDonHangXuatCT();
            DataTable dtbDonHangCho = new DataTable();
            dtbDonHangCho = dhxct_.DonHangXuatCT_DonHangChoTheoNhom(cboNhom.SelectedValue.ToString());
            rgvDonHangCho.DataSource = dtbDonHangCho;

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        private void Fr_BC_SanPham_Load(object sender, EventArgs e)
        {
            LayDanhSachNhaThuocLenCombobox();
        }
        void LayDanhSachNhaThuocLenCombobox()
        {
            CSQLNhomSP nt = new CSQLNhomSP();
            cboNhom.DisplayMember = "TenNSP";
            cboNhom.ValueMember = "NSPID";
            cboNhom.DataSource = nt.LoadDSNhomSPLenLuoi(false);
            cboNhom.SelectedIndex = -1;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (rgvDonHangCho.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_DonHangCho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvDonHangCho);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\tempDonHangCho.xls";
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
