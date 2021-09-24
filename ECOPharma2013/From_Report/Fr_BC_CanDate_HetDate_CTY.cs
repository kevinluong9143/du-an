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
    public partial class Fr_BC_CanDate_HetDate_CTY : Form
    {
        public Fr_BC_CanDate_HetDate_CTY()
        {
            InitializeComponent();
        }

        DataTable dtbTonKhoCT = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {

            CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();

            if (rbtCanHangDung.IsChecked == true)
            {
                dtbTonKhoCT = tonkhoct_.LoadDataCanDate_CTY(int.Parse(txtSoThang.Text));

                if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                {
                    rgvCanDat_HetDateChiTiet.DataSource = dtbTonKhoCT;

                }
                else
                {
                    MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                }
            }
            else if (rbtHetHanDung.IsChecked == true)
            {
                dtbTonKhoCT = tonkhoct_.LoadDataHetDate_CTY();

                if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                {
                    rgvCanDat_HetDateChiTiet.DataSource = dtbTonKhoCT;
                }
                else
                {
                    MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                }
            }

            //TinhTonKhiFilter();
            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        } 
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (rgvCanDat_HetDateChiTiet.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_CanDate_HetDate_CTY") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvCanDat_HetDateChiTiet);
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

        private void TinhTonKhiFilter()
        {
            rgvCanDat_HetDateChiTiet.MasterTemplate.ShowTotals = true;

            GridViewSummaryItem summaryItemIn = new GridViewSummaryItem();
            summaryItemIn.Name = "colSLBan";
            summaryItemIn.Aggregate = GridAggregateFunction.Sum;
            summaryItemIn.FormatString = "{0:N2}";

            GridViewSummaryItem summaryTotal = new GridViewSummaryItem();
            summaryTotal.Name = "colTTBanCoTAXDaGiamGia";
            summaryTotal.Aggregate = GridAggregateFunction.Sum;
            summaryTotal.FormatString = "{0:N2}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItemIn);
            summaryRowItem.Add(summaryTotal);

            this.rgvCanDat_HetDateChiTiet.SummaryRowsTop.Add(summaryRowItem);            
        }

        private void txtSoThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtSoThang.Focus();
            }
        }

        private void Fr_BC_CanDate_HetDate_CTY_Load(object sender, EventArgs e)
        {

        }
    }
}
