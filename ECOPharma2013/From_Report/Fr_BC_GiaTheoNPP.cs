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
    public partial class Fr_BC_GiaTheoNPP : Form
    {
        public Fr_BC_GiaTheoNPP()
        {
            InitializeComponent();
        }

        private void Fr_BC_GiaTheoNPP_Load(object sender, EventArgs e)
        {
            CSQLSanPham sp_ = new CSQLSanPham();
            this.cbbSanPham.DataSource = sp_.SanPham_LayDSSanPhamlenMutiCombo();
            this.cbbSanPham.DisplayMember = "TenSP";
            this.cbbSanPham.ValueMember = "SPID";
            cbbSanPham.EditorControl.Columns["SPID"].IsVisible = false;
            cbbSanPham.EditorControl.Columns["MaSP"].Width = 65;
            cbbSanPham.EditorControl.Columns["TenSP"].Width = 455;
            this.cbbSanPham.AutoFilter = true;
            FilterDescriptor descriptorMaSP = new FilterDescriptor("MaSP", FilterOperator.Contains, null);
            this.cbbSanPham.EditorControl.FilterDescriptors.Add(descriptorMaSP);
            FilterDescriptor descriptorTenSP = new FilterDescriptor("TenSP", FilterOperator.Contains, null);
            this.cbbSanPham.EditorControl.FilterDescriptors.Add(descriptorTenSP);
            this.cbbSanPham.DropDownStyle = RadDropDownStyle.DropDown;
            cbbSanPham.MultiColumnComboBoxElement.DropDownWidth = 510;
            cbbSanPham.MultiColumnComboBoxElement.DropDownHeight = 300;
            this.cbbSanPham.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
            cbbSanPham.SelectedIndex = -1;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cbbSanPham.Text != string.Empty)
            {
                CSQLLichSuThayDoiGiaMua aLSTDGM = new CSQLLichSuThayDoiGiaMua();
                DataTable dt = aLSTDGM.BaoCaoTheoSPid(new Guid(cbbSanPham.SelectedValue.ToString()));
                rgvChiTiet.DataSource = dt;

                CSQLXemForm xemForm = new CSQLXemForm();
                xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (rgvChiTiet.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_GiaTheoNPP") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
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
