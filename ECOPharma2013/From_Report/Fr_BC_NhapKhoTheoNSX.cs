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
    public partial class Fr_BC_NhapKhoTheoNSX : Form
    {
        public Fr_BC_NhapKhoTheoNSX()
        {
            InitializeComponent();
        }


        private void Fr_BC_NhapKhoTheoNSX_Load(object sender, EventArgs e)
        {
            LayDanhSachNhaThuocLenCombobox();
            dtDenNgay.Value = DateTime.Now;
            XuLyTuNgay();
        }
        private void XuLyTuNgay()
        {
            DateTime denngay = dtDenNgay.Value;
            DateTime ngaytruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
            dtTuNgay.Value = ngaytruoc;
        
        }
        void LayDanhSachNhaThuocLenCombobox()
        {
           // CSQLNPP npp_ = new CSQLNPP();
            CSQLNSX nsx_ = new CSQLNSX();
            radMultiColumnComboBoxNCC.DisplayMember = "TenNSX";
            radMultiColumnComboBoxNCC.ValueMember = "nsxid";
            radMultiColumnComboBoxNCC.DataSource = nsx_.LayNSXLenLuoi(true);
            radMultiColumnComboBoxNCC.SelectedIndex = -1;
            radMultiColumnComboBoxNCC.EditorControl.Columns["NSXID"].IsVisible = false;
            radMultiColumnComboBoxNCC.EditorControl.Columns["TenNSX"].Width = 320;

            radMultiColumnComboBoxNCC.AutoFilter = true;
            radMultiColumnComboBoxNCC.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.Suggest;
            FilterDescriptor descriptor12 = new FilterDescriptor(radMultiColumnComboBoxNCC.DisplayMember, FilterOperator.Contains, string.Empty);

            radMultiColumnComboBoxNCC.EditorControl.MasterTemplate.FilterDescriptors.Add(descriptor12);
            radMultiColumnComboBoxNCC.DropDownStyle = RadDropDownStyle.DropDown;

            radMultiColumnComboBoxNCC.MultiColumnComboBoxElement.DropDownWidth = 350;
            radMultiColumnComboBoxNCC.MultiColumnComboBoxElement.DropDownHeight = 300;
        }

        DataTable dtbNhapKhoCT_InCty = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {
            rgvNhapKhoChiTiet.SummaryRowsTop.Clear();
            rgvNhapKhoChiTiet.DataSource = null;
            rgvChiTietThang.DataSource = null;
            string TuNgay = Convert.ToDateTime(dtTuNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string DenNgay = Convert.ToDateTime(dtDenNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");

            CSQLNhapKhoChiTiet nhapkhoct_ = new CSQLNhapKhoChiTiet();

            if (rbtNCC.IsChecked == true)
            {
                if(ckcThang.Checked==true)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenThem_Sua("Fr_BC_NhapKhoTheoNCC") == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    rgvChiTietThang.Show();
                    dtbNhapKhoCT_InCty = nhapkhoct_.BaoCaoNhapKho_ChiTietTheoThang_NSX(TuNgay, DenNgay, radMultiColumnComboBoxNCC.SelectedValue.ToString());
                    if (dtbNhapKhoCT_InCty != null && dtbNhapKhoCT_InCty.Rows.Count > 0)
                    {
                        rgvChiTietThang.DataSource = dtbNhapKhoCT_InCty;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                        return;
                    }
                }

                rgvChiTietThang.Hide();
                rgvNhapKhoChiTiet.Show();
                if (radMultiColumnComboBoxNCC.SelectedValue != null)
                {
                    dtbNhapKhoCT_InCty = nhapkhoct_.BaoCaoNhapKho_LoadDSTuNgay_DenNgay_NSX(TuNgay, DenNgay, radMultiColumnComboBoxNCC.SelectedValue.ToString());

                    if (dtbNhapKhoCT_InCty != null && dtbNhapKhoCT_InCty.Rows.Count > 0)
                    {
                        rgvNhapKhoChiTiet.DataSource = dtbNhapKhoCT_InCty;

                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                    }
                }
            }
            else if (radbtntatcaNCC.IsChecked == true)
            {
                ckcThang.Checked = false;
                rgvChiTietThang.Hide();
                rgvNhapKhoChiTiet.Show();
                dtbNhapKhoCT_InCty = nhapkhoct_.BaoCaoNhapKho_LoadDSTuNgay_DenNgay(TuNgay, DenNgay);
                if (dtbNhapKhoCT_InCty != null && dtbNhapKhoCT_InCty.Rows.Count > 0)
                {
                    rgvNhapKhoChiTiet.DataSource = dtbNhapKhoCT_InCty;
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
            if (rgvChiTietThang.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_NhapKhoTheoNCC") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvChiTietThang);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\tempChiTietTheoThang.xls";
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


        private void rbtNCC_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtNCC.IsChecked == true)
            {
                radMultiColumnComboBoxNCC.Enabled = true;
            }
            else
            {
                radMultiColumnComboBoxNCC.SelectedIndex = -1;
                radMultiColumnComboBoxNCC.Enabled = false;
            }
        }

    }
}
