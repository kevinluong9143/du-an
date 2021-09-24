﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.Report1;
using ECOPharma2013.SQL;
using CrystalDecisions.Shared;
using ECOPharma2013.DuLieu;
using Telerik.WinControls.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Runtime.InteropServices;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_TonKho_Cty : Form
    {
        public Fr_BC_TonKho_Cty()
        {
            InitializeComponent();
        }

        private void RW_BC_TonKho_Load(object sender, EventArgs e)
        {
           
            //if (_LayReport == true)
            //{
            //    Report_BC_TonKho check = new Report_BC_TonKho();
            //    check.SetDataSource(_inan);
            //    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            //    pdv.Value = _tieudein;
            //    ParameterValues pv = new ParameterValues();
            //    pv.Add(pdv);
            //    check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
            //    RW_BC_TonKho.ReportSource = check;
            //}
            //else
            //{
            //    Report_BC_TonKho_CacNT check = new Report_BC_TonKho_CacNT();
            //    check.SetDataSource(_inan);
            //    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            //    pdv.Value = _tieudein;
            //    ParameterValues pv = new ParameterValues();
            //    pv.Add(pdv);
            //    check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
            //    RW_BC_TonKho.ReportSource = check;
            //}
        }
        
        private void btnxem_Click(object sender, EventArgs e)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
            DataTable dtbTonKhoCT = new DataTable();
            btnExportToExcel.Enabled = true;
            rgvTonKhoChuaXN.DataSource = null;
            rgvTonKhoChiTiet.DataSource = null;
            RW_BC_TonKho.Hide();
            //rgvTonKhoChiTiet.Show();
            string tieude;
            if (ckcSP.Checked == true && radMultiColumnComboboxMaTenSP.SelectedValue != null)
                {
                   // rgvTonKhoChuaXN.Hide();
                    rgvTonKhoChiTiet.Show();  
                    if (RbtNT.IsChecked == true)
                    {
                        #region lấy data theo sản phẩm và nhà thuốc
                        dtbTonKhoCT = tonkhoct_.LoadDataTonKhoTheo_NT(radMultiColumnComboboxMaTenSP.SelectedValue.ToString(), cboNhaThuoc.SelectedValue.ToString(), "1");
                        string tennt = nhathuoc.LayNhaThuocTheoMa(cboNhaThuoc.SelectedValue.ToString()).Rows[0]["TenNT"].ToString();
                        tieude = "TỒN KHO " + tennt + "";
                        if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                        {
                            //XuatRaReport(dtbTonKhoCT, tieude);
                            rgvTonKhoChiTiet.DataSource = dtbTonKhoCT;
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                        }
                        #endregion
                    }
                    else if (radbtntatCaNT.IsChecked == true)
                    {
                        #region lấy data  tất cả nhà thuốc
                        dtbTonKhoCT = tonkhoct_.LoadDataTonKhoTheo_NT(radMultiColumnComboboxMaTenSP.SelectedValue.ToString(), "00000000-0000-0000-0000-000000000000", "3");
                        tieude = "TỒN KHO SẢN PHẨM TẤT CẢ NHÀ THUỐC";
                        if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                        {
                            //XuatRaReportCacNT(dtbTonKhoCT, tieude);
                            rgvTonKhoChiTiet.DataSource = dtbTonKhoCT;
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                        }
                        #endregion
                    }
                    else if (radbtnTCty.IsChecked == true)
                    {
                        #region Lấy data theo sản phẩm của tổng công ty
                        dtbTonKhoCT = tonkhoct_.LoadDataTonKhoTheoSPid_Cty(radMultiColumnComboboxMaTenSP.SelectedValue.ToString());
                        tieude = "TỒN KHO TỔNG CÔNG TY";
                        if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                        {
                            //XuatRaReport(dtbTonKhoCT, tieude);
                            rgvTonKhoChiTiet.DataSource = dtbTonKhoCT;
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
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
                   // rgvTonKhoChuaXN.Hide();
                    rgvTonKhoChiTiet.Show();  
                    #region lấy data từng nhà thuốc không chọn sản phẩm
                    dtbTonKhoCT = tonkhoct_.LoadDataTonKhoTheo_NT("00000000-0000-0000-0000-000000000000", cboNhaThuoc.SelectedValue.ToString(), "2");
                    string tennt = nhathuoc.LayNhaThuocTheoMa(cboNhaThuoc.SelectedValue.ToString()).Rows[0]["TenNT"].ToString();
                    tieude = "TỒN KHO " + tennt + "";
                    if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                    {
                        //XuatRaReport(dtbTonKhoCT, tieude);
                        rgvTonKhoChiTiet.DataSource = dtbTonKhoCT;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                    }
                    #endregion
                }
                else if (ckcSP.Checked == false && radbtntatCaNT.IsChecked == true)
                {
                   // rgvTonKhoChuaXN.Hide();
                    rgvTonKhoChiTiet.Show();  
                    #region lấy data tất cả nhà thuốc không chọn sản phẩm
                    dtbTonKhoCT = tonkhoct_.LoadDataTonKhoTheo_NT("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000", "4");
                    tieude = "TỒN KHO TẤT CẢ NHÀ THUỐC";
                    if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                    {
                        //XuatRaReportCacNT(dtbTonKhoCT, tieude);
                        rgvTonKhoChiTiet.DataSource = dtbTonKhoCT;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                    }
                    #endregion
                }
                else if (ckcSP.Checked == false && radbtnTCty.IsChecked == true)
                {
                    if (cbChuaNhapKho.Checked == true)
                    {
                        rgvTonKhoChiTiet.Hide();
                        rgvTonKhoChuaXN.Show();
                        #region lấy data tổng công ty không chọn sản phẩm
                        dtbTonKhoCT = tonkhoct_.LoadDataTonKhoChuaXN();
                        tieude = "TỒN KHO CHƯA XÁC NHẬN TỔNG CÔNG TY";
                        if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                        {
                            //XuatRaReport(dtbTonKhoCT, tieude);
                            rgvTonKhoChuaXN.DataSource = dtbTonKhoCT;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                        }
                        #endregion
                    }
                    else
                    {
                        //rgvTonKhoChuaXN.Hide();
                        rgvTonKhoChiTiet.Show();                        
                        #region lấy data tổng công ty không chọn sản phẩm
                        dtbTonKhoCT = tonkhoct_.LoadDataTonKho();
                        tieude = "TỒN KHO TỔNG CÔNG TY";
                        if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                        {
                            //XuatRaReport(dtbTonKhoCT, tieude);
                            rgvTonKhoChiTiet.DataSource = dtbTonKhoCT;
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                        }
                        #endregion
                    }

                }
                else
                {
                    MessageBox.Show("Dữ liệu thông tin chưa đầy đủ. Vui lòng kiểm tra lại !");
                }

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }
        //private void XuatRaReportCacNT(DataTable dtbTonKhoCT, string tieude)
        //{
        //    Report_BC_TonKho_CacNT check = new Report_BC_TonKho_CacNT();
        //    check.SetDataSource(dtbTonKhoCT);
        //    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
        //    pdv.Value = tieude;
        //    ParameterValues pv = new ParameterValues();
        //    pv.Add(pdv);
        //    check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
        //    RW_BC_TonKho.ReportSource = check;
        //}

        private void XuatRaReport(DataTable dtbTonKhoCT, string tieude)
        {
            Report_BC_TonKho check = new Report_BC_TonKho();
            check.SetDataSource(dtbTonKhoCT);
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = tieude;
            ParameterValues pv = new ParameterValues();
            pv.Add(pdv);
            check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
            RW_BC_TonKho.ReportSource = check;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fr_BC_TonKho_Cty_Load(object sender, EventArgs e)
        {
            radMultiColumnComboboxMaTenSP.Enabled = false;
            cboNhaThuoc.Enabled = false;
            radbtnTCty.IsChecked = true;
            radbtntatCaNT.Enabled = true;
            btnExportToExcel.Enabled = false;

            RW_BC_TonKho.Hide();

            LayDanhSachNhaThuocLenCombobox();
            LayDSMaSP_TenSPLenMultiColumnCombobox();
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
                this.radMultiColumnComboboxMaTenSP.DataSource = sp_.SanPham_LayDSSanPhamlenMutiCombo();
                this.radMultiColumnComboboxMaTenSP.DisplayMember = "TenSP";
                this.radMultiColumnComboboxMaTenSP.ValueMember = "SPID";
                radMultiColumnComboboxMaTenSP.EditorControl.Columns["SPID"].IsVisible = false;
                radMultiColumnComboboxMaTenSP.EditorControl.Columns["MaSP"].Width = 65;
                radMultiColumnComboboxMaTenSP.EditorControl.Columns["TenSP"].Width = 455;
                this.radMultiColumnComboboxMaTenSP.AutoFilter = true;
                FilterDescriptor descriptorMaSP = new FilterDescriptor("MaSP", FilterOperator.IsEqualTo, null);
                this.radMultiColumnComboboxMaTenSP.EditorControl.FilterDescriptors.Add(descriptorMaSP);
                FilterDescriptor descriptorTenSP = new FilterDescriptor("TenSP", FilterOperator.StartsWith, null);
                this.radMultiColumnComboboxMaTenSP.EditorControl.FilterDescriptors.Add(descriptorTenSP);
                this.radMultiColumnComboboxMaTenSP.DropDownStyle = RadDropDownStyle.DropDown;
                radMultiColumnComboboxMaTenSP.MultiColumnComboBoxElement.DropDownWidth = 510;
                radMultiColumnComboboxMaTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.radMultiColumnComboboxMaTenSP.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                radMultiColumnComboboxMaTenSP.SelectedIndex = -1;
            }
            catch { }
        }

        private void ckcSP_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (ckcSP.Checked == true)
            {
                radMultiColumnComboboxMaTenSP.Enabled = true;
                radbtntatCaNT.Enabled = true;
            }
            else
            {
                radMultiColumnComboboxMaTenSP.SelectedIndex = -1;
                radMultiColumnComboboxMaTenSP.Enabled = false;
                radbtntatCaNT.Enabled = false;
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
                cboNhaThuoc.Enabled = false;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (rgvTonKhoChiTiet.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_TonKho_Cty") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvTonKhoChiTiet);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\TonKho.xls";
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

            if (rgvTonKhoChuaXN.Rows.Count > 0)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn("Fr_BC_TonKho_Cty") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvTonKhoChuaXN);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\TonKhoChuaXN.xls";
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

        private void btnXuatRaReport_Click(object sender, EventArgs e)
        {

            RW_BC_TonKho.Show();
            if (radbtnTCty.IsChecked == true)
            {
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                #region Lấy data theo sản phẩm của tổng công ty
                DataTable dtbTonKhoCT = tonkhoct_.LoadDataTonKho();
                string tieude = "TỒN KHO TỔNG CÔNG TY";
                if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                {
                    XuatRaReport(dtbTonKhoCT, tieude);
                    //rgvTonKhoChiTiet.DataSource = dtbTonKhoCT;
                }
                else
                {
                    MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                }
                #endregion
            }
        }

        private void cbChuaNhapKho_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChuaNhapKho.Checked) {
                //btnExportToExcel.Enabled = true;
                radbtnTCty.PerformClick();
                //btnXuatRaReport.PerformLayout();
                btnXuatRaReport.Enabled = false;
                ckcSP.Checked = false;
                ckcSP.Enabled = false;
                //radbtntatCaNT.PerformLayout();
                radbtntatCaNT.Enabled = false;
                RbtNT.Enabled = false;
                radMultiColumnComboboxMaTenSP.Enabled = false;
            }
            else {
                btnXuatRaReport.Enabled = true;
                ckcSP.Enabled = true;
                radbtntatCaNT.Enabled = true;
                RbtNT.Enabled = true;
                radMultiColumnComboboxMaTenSP.Enabled = true;
            }
        }

    }
}