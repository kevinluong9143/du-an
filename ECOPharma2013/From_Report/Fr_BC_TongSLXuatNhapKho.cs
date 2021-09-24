using ECOPharma2013.DuLieu;
using ECOPharma2013.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI.Export;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_TongSLXuatNhapKho : Form
    {
        public Fr_BC_TongSLXuatNhapKho()
        {
            InitializeComponent();
            radFrom.MaxDate = radTo.Value = radTo.MaxDate = DateTime.Now;
            radFrom.Value = radTo.Value.AddMonths(-1);

            CSQLNSX lopNSX = new CSQLNSX();
            DataTable bangNSX = lopNSX.LayNSXLenLuoi(false);
            DataTable dtNSX = new DataTable();
            dtNSX.Columns.Add("nsxid");
            dtNSX.Columns.Add("tennsx");
            CopyColumns(bangNSX, dtNSX, "nsxid", "tennsx");

            if (bangNSX.Rows.Count > 0)
            {
                radNSX.DataSource = dtNSX;
                radNSX.DisplayMember = "TenNSX";
                radNSX.ValueMember = "NSXID";
                radNSX.EditorControl.Columns["NSXID"].IsVisible = false;
                radNSX.EditorControl.Columns["TenNSX"].Width = 455;
                radNSX.AutoFilter = true;
                FilterDescriptor descriptorTenNSX = new FilterDescriptor("TenNSX", FilterOperator.Contains, null);
                radNSX.EditorControl.FilterDescriptors.Add(descriptorTenNSX);
                radNSX.DropDownStyle = RadDropDownStyle.DropDown;
                radNSX.MultiColumnComboBoxElement.DropDownWidth = 475;
                radNSX.MultiColumnComboBoxElement.DropDownHeight = 300;
                radNSX.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                radNSX.SelectedIndex = -1;
            }

            CSQLNPP lopNPP = new CSQLNPP();
            DataTable bangNPP = lopNPP.LayNPPLenLuoi(true);
            DataTable dtNPP = new DataTable();
            dtNPP.Columns.Add("nppid");
            dtNPP.Columns.Add("tennpp");
            CopyColumns(bangNPP, dtNPP, "nppid", "tennpp");

            if (dtNPP.Rows.Count > 0)
            {
                radNCC.DataSource = dtNPP;
                radNCC.DisplayMember = "tennpp";
                radNCC.ValueMember = "nppid";
                radNCC.EditorControl.Columns["nppid"].IsVisible = false;
                radNCC.EditorControl.Columns["tennpp"].Width = 455;
                radNCC.AutoFilter = true;
                FilterDescriptor descriptorTenNPP = new FilterDescriptor("tennpp", FilterOperator.Contains, null);
                radNCC.EditorControl.FilterDescriptors.Add(descriptorTenNPP);
                radNCC.DropDownStyle = RadDropDownStyle.DropDown;
                radNCC.MultiColumnComboBoxElement.DropDownWidth = 475;
                radNCC.MultiColumnComboBoxElement.DropDownHeight = 300;
                radNCC.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                radNCC.SelectedIndex = -1;
            }
        }

        private void CopyColumns(DataTable source, DataTable dest, params string[] columns)
        {
            foreach (DataRow sourcerow in source.Rows)
            {
                DataRow destRow = dest.NewRow();
                foreach (string colname in columns)
                {
                    destRow[colname] = sourcerow[colname];
                }
                dest.Rows.Add(destRow);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();

            string NSXId = "";
            try {
                if (!radNSX.Text.Equals("")) { 
                    NSXId = radNSX.SelectedValue.ToString();
                }
            }
            catch (Exception ex) { }

            string NPPId = "";
            try {
                if (!radNCC.Text.Equals("")) {
                    NPPId = radNCC.SelectedValue.ToString();
                }
            }
            catch (Exception ex) { }

            rgvChiTiet.DataSource = tonkhoct_.TongSLNhapXuatKho(radFrom.Value.Date, radTo.Value.Date, NSXId, NPPId);
            
            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (rgvChiTiet.Rows.Count > 0)
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenIn("Fr_BC_TongSLXuatNhapKho") == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    Fr_DangXuLy.ShowFormCho();
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvChiTiet);
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
                    Fr_DangXuLy.DongFormCho();
                    MessageBox.Show("File đã xuất thành công, kiểm tra lại file tại : " + f.FileName);
                }
            }
        }
    }
}
