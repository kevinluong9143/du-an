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
    public partial class Fr_BC_BanHang : Form
    {
        public Fr_BC_BanHang()
        {
            InitializeComponent();
        }

        private void RW_BC_BanHang_Load(object sender, EventArgs e)
        {
            
            //if (_LayReport == true)
            //{
            //    Report_BC_BanHang check = new Report_BC_BanHang();
            //    check.SetDataSource(_inan);
            //    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            //    pdv.Value = _tieudein;
            //    ParameterValues pv = new ParameterValues();
            //    pv.Add(pdv);
            //    check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);

            //    ParameterDiscreteValue pdv_tungay = new ParameterDiscreteValue();
            //    pdv_tungay.Value = _TuNgay;
            //    ParameterValues pv_tungay = new ParameterValues();
            //    pv_tungay.Add(pdv_tungay);
            //    check.DataDefinition.ParameterFields["TuNgay"].ApplyCurrentValues(pv_tungay);

            //    ParameterDiscreteValue pdv_denngay = new ParameterDiscreteValue();
            //    pdv_denngay.Value = _DenNgay;
            //    ParameterValues pv_denngay = new ParameterValues();
            //    pv_denngay.Add(pdv_denngay);
            //    check.DataDefinition.ParameterFields["DenNgay"].ApplyCurrentValues(pv_denngay);

            //    RW_BC_BanHang.ReportSource = check;
            //}
            //else
            //{
            //    Report_BC_BanHang_CacNT check = new Report_BC_BanHang_CacNT();
            //    check.SetDataSource(_inan);
            //    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            //    pdv.Value = _tieudein;
            //    ParameterValues pv = new ParameterValues();
            //    pv.Add(pdv);
            //    check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);

            //    ParameterDiscreteValue pdv_tungay = new ParameterDiscreteValue();
            //    pdv_tungay.Value = _TuNgay;
            //    ParameterValues pv_tungay = new ParameterValues();
            //    pv_tungay.Add(pdv_tungay);
            //    check.DataDefinition.ParameterFields["TuNgay"].ApplyCurrentValues(pv_tungay);

            //    ParameterDiscreteValue pdv_denngay = new ParameterDiscreteValue();
            //    pdv_denngay.Value = _DenNgay;
            //    ParameterValues pv_denngay = new ParameterValues();
            //    pv_denngay.Add(pdv_denngay);
            //    check.DataDefinition.ParameterFields["DenNgay"].ApplyCurrentValues(pv_denngay);

            //    RW_BC_BanHang.ReportSource = check;
            //}
        }

        private void Fr_BC_BanHang_Load(object sender, EventArgs e)
        {
            radMultiColumnComboBoxMaSP_BH.Enabled = false;
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
                this.radMultiColumnComboBoxMaSP_BH.DataSource = sp_.SanPham_LayDSSanPhamlenMutiCombo();
                this.radMultiColumnComboBoxMaSP_BH.DisplayMember = "TenSP";
                this.radMultiColumnComboBoxMaSP_BH.ValueMember = "SPID";
                radMultiColumnComboBoxMaSP_BH.EditorControl.Columns["SPID"].IsVisible = false;
                radMultiColumnComboBoxMaSP_BH.EditorControl.Columns["MaSP"].Width = 65;
                radMultiColumnComboBoxMaSP_BH.EditorControl.Columns["TenSP"].Width = 455;
                this.radMultiColumnComboBoxMaSP_BH.AutoFilter = true;
                FilterDescriptor descriptorMaSP = new FilterDescriptor("MaSP", FilterOperator.Contains, null);
                this.radMultiColumnComboBoxMaSP_BH.EditorControl.FilterDescriptors.Add(descriptorMaSP);
                FilterDescriptor descriptorTenSP = new FilterDescriptor("TenSP", FilterOperator.Contains, null);
                this.radMultiColumnComboBoxMaSP_BH.EditorControl.FilterDescriptors.Add(descriptorTenSP);
                this.radMultiColumnComboBoxMaSP_BH.DropDownStyle = RadDropDownStyle.DropDown;
                radMultiColumnComboBoxMaSP_BH.MultiColumnComboBoxElement.DropDownWidth = 510;
                radMultiColumnComboBoxMaSP_BH.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.radMultiColumnComboBoxMaSP_BH.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                radMultiColumnComboBoxMaSP_BH.SelectedIndex = -1;
            }
            catch { }
        }
        string tieude;
        DataTable dtbBanHangCT_InCty = new DataTable();
        private void btnXem_Click(object sender, EventArgs e)
        {
            rgvBanHangChiTiet.SummaryRowsTop.Clear();

            string TuNgay = Convert.ToDateTime(dtTuNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string DenNgay = Convert.ToDateTime(dtDenNgay.Value.ToShortDateString()).ToString("yyyy-MM-dd");

            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            if (radbtntatCaNT.IsChecked != true && cboNhaThuoc.SelectedValue != null)
            {
                string tennt = nhathuoc.LayNhaThuocTheoMa(cboNhaThuoc.SelectedValue.ToString()).Rows[0]["TenNT"].ToString();
                tieude = "BÁO CÁO BÁN HÀNG " + tennt + "";
            }

            if (ckcSP.Checked == true && radMultiColumnComboBoxMaSP_BH.SelectedValue != null)
            {
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                
                if (RbtNT.IsChecked == true)
                {
                    #region              //lấy data bán hàng theo nhà thuốc và theo sản phẩm

                    dtbBanHangCT_InCty = tonkhoct_.BaoCaoBanHang_LoadDSTuNgay_DenNgay_NTid_SPid(TuNgay, DenNgay, radMultiColumnComboBoxMaSP_BH.SelectedValue.ToString(), cboNhaThuoc.SelectedValue.ToString());
                    if (dtbBanHangCT_InCty != null && dtbBanHangCT_InCty.Rows.Count > 0)
                    {
                        rgvBanHangChiTiet.DataSource = dtbBanHangCT_InCty;

                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                    }
                    #endregion
                }
                else if (radbtntatCaNT.IsChecked == true)
                {
                    #region  //lấy data bán hàng tất cả nhà thuốc theo sản phẩm
                    dtbBanHangCT_InCty = tonkhoct_.BaoCaoBanHang_LoadDSTuNgay_DenNgay_SPid_FullNhaThuoc(TuNgay, DenNgay, radMultiColumnComboBoxMaSP_BH.SelectedValue.ToString());
                    tieude = "BÁO CÁO BÁN HÀNG SẢN PHẨM";
                    if (dtbBanHangCT_InCty != null && dtbBanHangCT_InCty.Rows.Count > 0)
                    {
                        //XuatReportBH_CacNT(tieude, dtbBanHangCT_InCty);
                        rgvBanHangChiTiet.DataSource = dtbBanHangCT_InCty;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn điều kiện nhà thuốc hoặc tất cả nhà thuốc!");
                }
            }
            else if (ckcSP.Checked == false && RbtNT.IsChecked == true && cboNhaThuoc.SelectedValue != null)
            {
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();

                
                if (ckcPhieuHuy.Checked==true)
                {
                    #region //lấy data bán hàng theo nhà thuốc và số phieu huy
                    dtbBanHangCT_InCty = tonkhoct_.BaoCaoBanHang_LoadDSTuNgay_DenNgay_NTid_PhieuHuy(TuNgay, DenNgay, cboNhaThuoc.SelectedValue.ToString());
                    if (dtbBanHangCT_InCty != null && dtbBanHangCT_InCty.Rows.Count > 0)
                    {
                        //XuatReportBH_TungNT(tieude, dtbBanHangCT_InCty);
                        rgvBanHangChiTiet.DataSource = dtbBanHangCT_InCty;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                    }
                    TinhTonKhiFilter();
                    #endregion

                    return;             
                }
               
                #region //lấy data bán hàng theo nhà thuốc

                dtbBanHangCT_InCty = tonkhoct_.BaoCaoBanHang_LoadDSTuNgay_DenNgay_NTID(TuNgay, DenNgay, cboNhaThuoc.SelectedValue.ToString());
                if (dtbBanHangCT_InCty != null && dtbBanHangCT_InCty.Rows.Count > 0)
                {
                    //XuatReportBH_TungNT(tieude, dtbBanHangCT_InCty);
                    rgvBanHangChiTiet.DataSource = dtbBanHangCT_InCty;
                }
                else
                {
                    MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
                }

                #endregion
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin sản phẩm để kiểm tra!");
            }
            TinhTonKhiFilter();

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        //private void XuatReportBH_CacNT(string tieude, DataTable dtbBanHangCT_InCty)
        //{
        //    Report_BC_BanHang_CacNT check = new Report_BC_BanHang_CacNT();
        //    check.SetDataSource(dtbBanHangCT_InCty);
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
        //    RW_BC_BanHang.ReportSource = check;
        //}

        //private void XuatReportBH_TungNT(string tieude, DataTable dtbBanHangCT_InCty)
        //{
        //    Report_BC_BanHang check = new Report_BC_BanHang();
        //    check.SetDataSource(dtbBanHangCT_InCty);
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

        //    RW_BC_BanHang.ReportSource = check;
        //}

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckcSP_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (ckcSP.IsChecked == true)
            {
                radMultiColumnComboBoxMaSP_BH.Enabled = true;
                ckcPhieuHuy.Enabled = false;
            }
            else
            {
                radMultiColumnComboBoxMaSP_BH.SelectedIndex = -1;
                radMultiColumnComboBoxMaSP_BH.Enabled = false;
                ckcPhieuHuy.Enabled = true;
            }
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
            if (rgvBanHangChiTiet.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_BanHang") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Fr_DangXuLy.ShowFormCho();
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvBanHangChiTiet);
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

        private void TinhTonKhiFilter()
        {
            rgvBanHangChiTiet.MasterTemplate.ShowTotals = true;

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

            this.rgvBanHangChiTiet.SummaryRowsTop.Add(summaryRowItem);            
        }

        private void ckcPhieuHuy_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (ckcPhieuHuy.IsChecked == true)
            {
                ckcSP.Enabled = false;
                radMultiColumnComboBoxMaSP_BH.SelectedIndex = -1;
                radMultiColumnComboBoxMaSP_BH.Enabled = false;
                
            }
            else
            {
                ckcSP.Enabled = true;
                radMultiColumnComboBoxMaSP_BH.SelectedIndex = -1;
                radMultiColumnComboBoxMaSP_BH.Enabled = true;
                
            }
        }
    }
}
