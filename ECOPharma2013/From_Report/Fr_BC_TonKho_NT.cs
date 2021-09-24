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
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Runtime.InteropServices;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_TonKho_NT : Form
    {
        public Fr_BC_TonKho_NT()
        {
            InitializeComponent();
        }

        private void RW_BC_TonKho_Load(object sender, EventArgs e)
        {
            //if (_dk == 1)
            //{
            //    _dk = 0;
            //    Report_BC_TonKho check = new Report_BC_TonKho();
            //    check.SetDataSource(_inan);
            //    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            //    pdv.Value = _tieudein;
            //    ParameterValues pv = new ParameterValues();
            //    pv.Add(pdv);
            //    check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
            //    RW_BC_TonKho.ReportSource = check;
            //}
            //else if (_dk == 2)
            //{
            //    _dk = 0;
            //    Report_BC_TonKho_HangAm check = new Report_BC_TonKho_HangAm();
            //    check.SetDataSource(_inan);
            //    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            //    pdv.Value = _tieudein;
            //    ParameterValues pv = new ParameterValues();
            //    pv.Add(pdv);
            //    check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
            //    RW_BC_TonKho.ReportSource = check;
            //}
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);

            rgvTonKhoChiTiet.SummaryRowsTop.Clear();
            if(radbtnTCty.IsChecked == true)
            {
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                DataTable dtbTonKhoCT = tonkhoct_.LoadDataTonKhoNT();
                if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                {
                    rgvTonKhoChiTiet.DataSource = dtbTonKhoCT;
                    rgvTonKhoChiTiet.Columns["colLot"].IsVisible = true;
                    rgvTonKhoChiTiet.Columns["colDate"].IsVisible = true;
                    rgvTonKhoChiTiet.Columns["colGiaMua"].IsVisible = true;
                    rgvTonKhoChiTiet.Columns["colTenNSX"].IsVisible = true;
                    rgvTonKhoChiTiet.Columns["colTenKho"].IsVisible = true;
                }
                else
                {
                    MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                }
                TinhTonKhiFilter();
                return;
            }
            if(radbtntatCaNT.IsChecked==true)
            {
                CSQLTonKho tonkho_ = new CSQLTonKho();
                DataTable dtbTonKho = tonkho_.LayDataNTTonKho();
                if (dtbTonKho != null && dtbTonKho.Rows.Count > 0)
                {
                    rgvTonKhoChiTiet.DataSource = dtbTonKho;
                    rgvTonKhoChiTiet.Columns["colLot"].IsVisible = false;
                    rgvTonKhoChiTiet.Columns["colDate"].IsVisible = false;
                    rgvTonKhoChiTiet.Columns["colGiaMua"].IsVisible = false;
                    rgvTonKhoChiTiet.Columns["colTenNSX"].IsVisible = false;
                    rgvTonKhoChiTiet.Columns["colTenKho"].IsVisible = false;
                }
                else
                {
                    MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                }
                TinhTonKhiFilter();
                return;
            }
            if (radbtnTonHetDate.IsChecked == true)
            {
                CSQLTonKhoCT tonkho_ = new CSQLTonKhoCT();
                DataTable dtbTonKho = tonkho_.LayDataNTTonKho_HetDate();

                if (dtbTonKho != null && dtbTonKho.Rows.Count > 0)
                {
                    rgvTonKhoChiTiet.DataSource = dtbTonKho;
                    rgvTonKhoChiTiet.Columns["colLot"].IsVisible = true;
                    rgvTonKhoChiTiet.Columns["colDate"].IsVisible = true;
                    rgvTonKhoChiTiet.Columns["colGiaMua"].IsVisible = true;
                    rgvTonKhoChiTiet.Columns["colTenNSX"].IsVisible = true;
                    rgvTonKhoChiTiet.Columns["colTenKho"].IsVisible = true;
                }
                else
                {
                    MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                }
                TinhTonKhiFilter();
                return;
            }
        }

        private void TinhTonKhiFilter()
        {
            rgvTonKhoChiTiet.MasterTemplate.ShowTotals = true;
            GridViewSummaryItem summaryTotal = new GridViewSummaryItem();
            summaryTotal.Name = "colTongTienGiaMua";
            summaryTotal.Aggregate = GridAggregateFunction.Sum;
            summaryTotal.FormatString = "{0:N2}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryTotal);

            this.rgvTonKhoChiTiet.SummaryRowsTop.Add(summaryRowItem);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (rgvTonKhoChiTiet.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_TonKho_NT") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                ExportToExcelML exporter = new ExportToExcelML(this.rgvTonKhoChiTiet);
                exporter.ExportVisualSettings = true;

                string tempPath = Path.GetTempPath();
                tempPath += @"\TonKho" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
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
                desktopPath += @"\TonKho" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";

                wb.SaveAs(desktopPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
                wb.Close();
                app.Quit();

                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(app);

                File.Delete(tempPath);
                MessageBox.Show("File đã xuất thành công, kiểm tra lại file trên desktop!");
            }
        }
    }
}
