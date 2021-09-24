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
    public partial class Fr_BC_BienBanKiemKe : Form
    {
        public Fr_BC_BienBanKiemKe()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string TuNgay = Convert.ToDateTime(dtTuNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string DenNgay = Convert.ToDateTime(dtDenNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            CSQLDieuChinhTonCT dieuchinhtonkhoct_ = new CSQLDieuChinhTonCT();
            if (chkNoiChon.Checked == true && cboNhaThuoc.SelectedValue != null)
            {
                DataTable bbkk_ = dieuchinhtonkhoct_.BaoCaoKiemKe_LoadDSTuNgay_DenNgay_NTID(TuNgay, DenNgay, cboNhaThuoc.SelectedValue.ToString());
                if (bbkk_ != null && bbkk_.Rows.Count > 0)
                {
                    radLabelNoiDung.Text = "";
                    rgvBienBanKiemKe.DataSource = bbkk_;
                }
                else
                {
                    rgvBienBanKiemKe.DataSource = null;
                    MessageBox.Show("Không có số Phiếu Kiểm Kê trong khoảng thời gian đã chọn. Vui lòng kiểm tra lại!");
                }
            }
            else
            {
                DataTable dctonkhoct_ = dieuchinhtonkhoct_.BaoCaoKiemKe_LoadDataTheoSoPDC(txtSoPhieuDC.Text);
                if (dctonkhoct_ != null && dctonkhoct_.Rows.Count > 0)
                {
                    radLabelNoiDung.Text = dctonkhoct_.Rows[0]["GhiChu"].ToString();
                    rgvBienBanKiemKe.DataSource = dctonkhoct_;
                }
                else
                {
                    rgvBienBanKiemKe.DataSource = null;
                    MessageBox.Show("Không có số Phiếu Kiểm Kê này. Vui lòng kiểm tra lại!");
                }
            }

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }
        private void XuLyTuNgay()
        {
            DateTime denngay = dtDenNgay.Value;
            DateTime ngaytruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
            dtTuNgay.Value = ngaytruoc;

        }
        void LayDanhSachNhaThuocLenCombobox()
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            cboNhaThuoc.DisplayMember = "TenNT";
            cboNhaThuoc.ValueMember = "NTID";
            cboNhaThuoc.DataSource = nhathuoc.LayDanhSachNhaThuocLenLuoi(false);
            cboNhaThuoc.SelectedIndex = 9;
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
                if (qtc.KiemTraQuyenIn("Fr_BC_BienBanKiemKe") == false)
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

        private void Fr_BC_BienBanKiemKe_Load(object sender, EventArgs e)
        {
            LayDanhSachNhaThuocLenCombobox();
            dtDenNgay.Value = DateTime.Now;
            XuLyTuNgay();
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
    }
}
