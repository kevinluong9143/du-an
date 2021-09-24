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
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Runtime.InteropServices;
using Telerik.WinControls.UI;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_TraHang : Form
    {
        public Fr_BC_TraHang()
        {
            InitializeComponent();
        }

        private void RW_BC_TraHang_Load(object sender, EventArgs e)
        {
        }

        private void Fr_BC_TraHang_Load(object sender, EventArgs e)
        {
            radMultiColumnComboBoxMaSP_TH.Enabled = false;
            LayDanhSachNhaThuocLenCombobox();
            LayDSMaSP_TenSPLenMultiColumnCombobox();
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
            CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
            cboNhaThuoc.DisplayMember = "TenNT";
            cboNhaThuoc.ValueMember = "NTID";
            cboNhaThuoc.DataSource = chct.LayDSNhaThuoc();
            cboNhaThuoc.SelectedIndex = -1;
        }

        private void LayDSMaSP_TenSPLenMultiColumnCombobox()
        {
            try
            {
                CSQLSanPham sp_ = new CSQLSanPham();
                this.radMultiColumnComboBoxMaSP_TH.DataSource = sp_.SanPham_LayDSSanPhamlenMutiCombo();
                this.radMultiColumnComboBoxMaSP_TH.DisplayMember = "TenSP";
                this.radMultiColumnComboBoxMaSP_TH.ValueMember = "SPID";
                radMultiColumnComboBoxMaSP_TH.EditorControl.Columns["SPID"].IsVisible = false;
                radMultiColumnComboBoxMaSP_TH.EditorControl.Columns["MaSP"].Width = 65;
                radMultiColumnComboBoxMaSP_TH.EditorControl.Columns["TenSP"].Width = 455;
                this.radMultiColumnComboBoxMaSP_TH.AutoFilter = true;
                FilterDescriptor descriptorMaSP = new FilterDescriptor("MaSP", FilterOperator.Contains, null);
                this.radMultiColumnComboBoxMaSP_TH.EditorControl.FilterDescriptors.Add(descriptorMaSP);
                FilterDescriptor descriptorTenSP = new FilterDescriptor("TenSP", FilterOperator.Contains, null);
                this.radMultiColumnComboBoxMaSP_TH.EditorControl.FilterDescriptors.Add(descriptorTenSP);
                this.radMultiColumnComboBoxMaSP_TH.DropDownStyle = RadDropDownStyle.DropDown;
                radMultiColumnComboBoxMaSP_TH.MultiColumnComboBoxElement.DropDownWidth = 510;
                radMultiColumnComboBoxMaSP_TH.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.radMultiColumnComboBoxMaSP_TH.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                radMultiColumnComboBoxMaSP_TH.SelectedIndex = -1;
            }
            catch { }
        }
        string tieude;
        private void btnXem_Click(object sender, EventArgs e)
        {
            rgvTraHangChiTiet.SummaryRowsTop.Clear();
            string TuNgay = Convert.ToDateTime(dtTuNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string DenNgay = Convert.ToDateTime(dtDenNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            #region Xử lý Báo Cáo Trả Hàng NT trên Công ty
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            
            if (radbtntatCaNT.IsChecked != true && cboNhaThuoc.SelectedValue != null)
            {
                string tennt = nhathuoc.LayNhaThuocTheoMa(cboNhaThuoc.SelectedValue.ToString()).Rows[0]["TenNT"].ToString();
                tieude = "BÁO CÁO TRẢ HÀNG " + tennt + "";
            }

            if (ckcSP.Checked == true && radMultiColumnComboBoxMaSP_TH.SelectedValue != null)
            {
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                DataTable dtbTraHangCT_InCty = new DataTable();
                if (RbtNT.IsChecked == true)
                {
                    //lấy data trả hàng theo nhà thuốc và theo sản phẩm
                    dtbTraHangCT_InCty = tonkhoct_.BaoCaoTraHang_LoadDSTuNgay_DenNgay_NTid_SPid(TuNgay, DenNgay, radMultiColumnComboBoxMaSP_TH.SelectedValue.ToString(), cboNhaThuoc.SelectedValue.ToString());
                    if (dtbTraHangCT_InCty != null && dtbTraHangCT_InCty.Rows.Count > 0)
                    {
                        //XuatReport_TH_TungNT(dtbTraHangCT_InCty,tieude);
                        rgvTraHangChiTiet.DataSource = dtbTraHangCT_InCty;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                    }
                }
                else if (radbtntatCaNT.IsChecked == true)
                {
                    //lấy data trả hàng tất cả nhà thuốc theo sản phẩm
                    dtbTraHangCT_InCty = tonkhoct_.BaoCaoTraHang_LoadDSTuNgay_DenNgay_SPid_FullNhaThuoc(TuNgay, DenNgay, radMultiColumnComboBoxMaSP_TH.SelectedValue.ToString());
                    tieude = "BÁO CÁO TRẢ HÀNG SẢN PHẨM";
                    if (dtbTraHangCT_InCty != null && dtbTraHangCT_InCty.Rows.Count > 0)
                    {
                        //XuatReport_TH_CacNT(tieude, dtbTraHangCT_InCty);
                        rgvTraHangChiTiet.DataSource = dtbTraHangCT_InCty;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn điều kiện nhà thuốc hoặc tất cả nhà thuốc!");
                }
            }
            else if (ckcSP.Checked == false && RbtNT.IsChecked == true && cboNhaThuoc.SelectedValue != null)
            {
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                DataTable dtbTraHangCT_InCty = new DataTable();
                //lấy data bán hàng theo nhà thuốc 
                dtbTraHangCT_InCty = tonkhoct_.BaoCaoTraHang_LoadDSTuNgay_DenNgay_NTid(TuNgay, DenNgay, cboNhaThuoc.SelectedValue.ToString());
                if (dtbTraHangCT_InCty != null && dtbTraHangCT_InCty.Rows.Count > 0)
                {
                    //XuatReport_TH_TungNT(dtbTraHangCT_InCty, tieude);
                    rgvTraHangChiTiet.DataSource = dtbTraHangCT_InCty;
                }
                else
                {
                    MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin sản phẩm để kiểm tra!");
            }
            TinhTonKhiFilter();
            #endregion
            TinhTonKhiFilter();
            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }
        //private void XuatReport_TH_CacNT(string tieude, DataTable dtbTraHangCT_InCty)
        //{
        //    Report_BC_TraHang_CacNT check = new Report_BC_TraHang_CacNT();
        //    check.SetDataSource(dtbTraHangCT_InCty);
        //    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
        //    pdv.Value = tieude;
        //    ParameterValues pv = new ParameterValues();
        //    pv.Add(pdv);
        //    check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);

        //    ParameterDiscreteValue pdv_tungay = new ParameterDiscreteValue();
        //    pdv_tungay.Value = dtTuNgay.Value;
        //    ParameterValues pv_tungay = new ParameterValues();
        //    pv_tungay.Add(pdv_tungay);
        //    check.DataDefinition.ParameterFields["TuNgay"].ApplyCurrentValues(pv_tungay);

        //    ParameterDiscreteValue pdv_denngay = new ParameterDiscreteValue();
        //    pdv_denngay.Value = dtDenNgay.Value;
        //    ParameterValues pv_denngay = new ParameterValues();
        //    pv_denngay.Add(pdv_denngay);
        //    check.DataDefinition.ParameterFields["DenNgay"].ApplyCurrentValues(pv_denngay);

        //    RW_BC_TraHang.ReportSource = check;
        //}

        //private void XuatReport_TH_TungNT(DataTable dtbTraHangCT_InCty, string tieude)
        //{
        //    Report_BC_TraHang check = new Report_BC_TraHang();
        //    check.SetDataSource(dtbTraHangCT_InCty);
        //    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
        //    pdv.Value = tieude;
        //    ParameterValues pv = new ParameterValues();
        //    pv.Add(pdv);
        //    check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);

        //    ParameterDiscreteValue pdv_tungay = new ParameterDiscreteValue();
        //    pdv_tungay.Value = dtTuNgay.Value;
        //    ParameterValues pv_tungay = new ParameterValues();
        //    pv_tungay.Add(pdv_tungay);
        //    check.DataDefinition.ParameterFields["TuNgay"].ApplyCurrentValues(pv_tungay);

        //    ParameterDiscreteValue pdv_denngay = new ParameterDiscreteValue();
        //    pdv_denngay.Value = dtDenNgay.Value;
        //    ParameterValues pv_denngay = new ParameterValues();
        //    pv_denngay.Add(pdv_denngay);
        //    check.DataDefinition.ParameterFields["DenNgay"].ApplyCurrentValues(pv_denngay);

        //    RW_BC_TraHang.ReportSource = check;
        //}

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void RbtNT_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (RbtNT.IsChecked == true)
            {
                cboNhaThuoc.Enabled = true;
            }
            else
            {
                cboNhaThuoc.SelectedIndex = -1;
                cboNhaThuoc.Enabled = false;
            }
        }

        private void ckcSP_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (ckcSP.IsChecked == true)
            {
                radMultiColumnComboBoxMaSP_TH.Enabled = true;
            }
            else
            {
                radMultiColumnComboBoxMaSP_TH.SelectedIndex = -1;
                radMultiColumnComboBoxMaSP_TH.Enabled = false;
            }
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
            if (rgvTraHangChiTiet.Rows.Count > 0)
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenIn("Fr_BC_TraHang") == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    Fr_DangXuLy.ShowFormCho();
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvTraHangChiTiet);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\tempBaoCaoTraHang.xls";
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

        private void TinhTonKhiFilter()
        {
            rgvTraHangChiTiet.MasterTemplate.ShowTotals = true;

            //GridViewSummaryItem summaryItemIn = new GridViewSummaryItem();
            //summaryItemIn.Name = "colSLBan";
            //summaryItemIn.Aggregate = GridAggregateFunction.Sum;
            //summaryItemIn.FormatString = "{0:N2}";

            GridViewSummaryItem summaryTotal = new GridViewSummaryItem();
            summaryTotal.Name = "colTTTraCoTAXDaTinhPhiTraHang";
            summaryTotal.Aggregate = GridAggregateFunction.Sum;
            summaryTotal.FormatString = "{0:N2}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            //summaryRowItem.Add(summaryItemIn);
            summaryRowItem.Add(summaryTotal);

            this.rgvTraHangChiTiet.SummaryRowsTop.Add(summaryRowItem);
        }
    }
}
