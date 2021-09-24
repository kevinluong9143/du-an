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
    public partial class Fr_BC_SanPham : Form
    {
        int _dk;
        public Fr_BC_SanPham(int dk)
        {
            InitializeComponent();
            _dk = dk;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (chkNhaThuoc.Checked == true)
            {
                rgvSanPhamTatCaNT.Show();
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                DataTable dtbSanPham = tonkhoct_.BaoCaoSanPham_LoadDSTatCaNhaThuoc();
                rgvSanPhamTatCaNT.DataSource = dtbSanPham;

            }
            else
            {
                rgvSanPhamChiTiet.Show();
                rgvSanPhamTatCaNT.Hide();
                if (_dk == 1 && cboNhaThuoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nơi cần lấy thông tin chi tiết sản phẩm");
                }
                else if (_dk == 1 && cboNhaThuoc.SelectedValue != null)
                {
                    CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                    DataTable dtbSanPham = new DataTable();
                    dtbSanPham = tonkhoct_.BaoCaoSanPham_LoadDSTheo_NTID(cboNhaThuoc.SelectedValue.ToString());
                    rgvSanPhamChiTiet.DataSource = dtbSanPham;
                }
                else if (_dk == 2)
                {
                    CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                    DataTable dtbSanPham = new DataTable();
                    dtbSanPham = tonkhoct_.BaoCaoSanPham_LoadDSSanPhamCuaNT();
                    rgvSanPhamChiTiet.DataSource = dtbSanPham;
                    rgvSanPhamChiTiet.Columns["colGiaMuaChuaTaxHT"].IsVisible = false;
                    rgvSanPhamChiTiet.Columns["colGiaMuaCoChietKhauCoTax"].IsVisible = false;
                    rgvSanPhamChiTiet.Columns["colDVTNhap"].IsVisible = false;
                    rgvSanPhamChiTiet.Columns["colGiaMuaDVNhap"].IsVisible = false;
                }
            }

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        private void Fr_BC_SanPham_Load(object sender, EventArgs e)
        {
            LayDanhSachNhaThuocLenCombobox();
            if (_dk == 2)
            {
                cboNhaThuoc.Enabled = false;
            }
        }
        void LayDanhSachNhaThuocLenCombobox()
        {
            CSQLNhaThuoc nt = new CSQLNhaThuoc();
            cboNhaThuoc.DisplayMember = "TenNT";
            cboNhaThuoc.ValueMember = "NTID";
            cboNhaThuoc.DataSource = nt.NhaThuoc_LayDSNhaThuocLenCBBox();
            cboNhaThuoc.SelectedIndex = -1;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (chkNhaThuoc.Checked == true)
            {
                if (rgvSanPhamTatCaNT.Rows.Count > 0)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenIn("Fr_BC_SanPham") == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }

                    SaveFileDialog f = new SaveFileDialog();
                    f.Filter = "Excel file (*.xls)|*.xls";
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        Fr_DangXuLy.ShowFormCho();
                        ExportToExcelML exporter = new ExportToExcelML(this.rgvSanPhamTatCaNT);
                        exporter.ExportVisualSettings = true;

                        string tempPath = Path.GetTempPath();
                        tempPath += @"\tempSanPhamCT.xls";
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
            else
            {
                if (rgvSanPhamChiTiet.Rows.Count > 0)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenIn("Fr_BC_SanPham") == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }

                    SaveFileDialog f = new SaveFileDialog();
                    f.Filter = "Excel file (*.xls)|*.xls";
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcelML exporter = new ExportToExcelML(this.rgvSanPhamChiTiet);
                        exporter.ExportVisualSettings = true;

                        string tempPath = Path.GetTempPath();
                        tempPath += @"\tempSanPhamCT.xls";
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

        private void cboNhaThuoc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboNhaThuoc.SelectedValue != null && cboNhaThuoc.SelectedIndex != -1)
            {
                chkNhaThuoc.Checked = false;
            }
        }
    }
}
