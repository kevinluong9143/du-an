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
    public partial class Fr_BC_NT_NhapKho : Form
    {
        public Fr_BC_NT_NhapKho()
        {
            InitializeComponent();
        }


        private void Fr_BC_NT_NhapKho_Load(object sender, EventArgs e)
        {
            dtDenNgay.Value = DateTime.Now;
            XuLyTuNgay();
        }
        private void XuLyTuNgay()
        {
            DateTime denngay = dtDenNgay.Value;
            DateTime ngaytruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
            dtTuNgay.Value = ngaytruoc;
        
        }
        

        DataTable dtbNhapKhoCT_InCty = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {
            rgvNhapKhoChiTiet.SummaryRowsTop.Clear();
            rgvNhapKhoChiTiet.DataSource = null;
            string TuNgay = Convert.ToDateTime(dtTuNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string DenNgay = Convert.ToDateTime(dtDenNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");

            CSQLNT_NhapKho ntnhapkho_ = new CSQLNT_NhapKho();

                dtbNhapKhoCT_InCty = ntnhapkho_.BaoCaoNhapKho_LoadDSTuNgay_DenNgay(TuNgay, DenNgay);

                if (dtbNhapKhoCT_InCty != null && dtbNhapKhoCT_InCty.Rows.Count > 0)
                {
                    rgvNhapKhoChiTiet.DataSource = dtbNhapKhoCT_InCty;

                }
                else
                {
                    MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                }
           
            //TinhTonKhiFilter();
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
            if (rgvNhapKhoChiTiet.Rows.Count > 0)
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvNhapKhoChiTiet);
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
            rgvNhapKhoChiTiet.MasterTemplate.ShowTotals = true;

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

            this.rgvNhapKhoChiTiet.SummaryRowsTop.Add(summaryRowItem);            
        }



    }
}
