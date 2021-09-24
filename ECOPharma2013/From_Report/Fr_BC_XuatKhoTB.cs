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
using ECOPharma2013.SQL;
using Telerik.WinControls.Data;
using Telerik.WinControls;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_XuatKhoTB : Form
    {
        public Fr_BC_XuatKhoTB()
        {
            InitializeComponent();
        }

        private void RW_BC_XKTB_Load(object sender, EventArgs e)
        {
        }

        private void Fr_BC_XuatKhoTB_Load(object sender, EventArgs e)
        {
            cboNhom.Enabled = false;
            RbtnSanPham.IsChecked = true;
            LayDSMaSP_TenSPLenMultiColumnCombobox();
            LayDSNhomSPLenCBO();
            dtDenNgay.Value = DateTime.Now;
            XuLyTuNgay();
        }

        private void XuLyTuNgay()
        {
            DateTime denngay = dtDenNgay.Value;
            DateTime ngaytruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
            dtTuNgay.Value = ngaytruoc;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            #region Xử lý Báo Cáo Xuất Kho Trung Bình
            string tieude, spid, nhomid;
            bool iskiemtra;
            if (RbtnSanPham.IsChecked == true && radMultiColumnComboboxMaTenSP.SelectedValue != null && RbtnNhomSanPham.IsChecked == false)
            {
                tieude = "BÁO CÁO XUẤT KHO TRUNG BÌNH";
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                DataTable dtbXuatKhoTB = new DataTable();
                spid = radMultiColumnComboboxMaTenSP.SelectedValue.ToString();
                nhomid = "00000000-0000-0000-0000-000000000000";
                iskiemtra = true;
                dtbXuatKhoTB = tonkhoct_.BaoCaoXuatKhoTB_LoadDSTuNgay_DenNgay(dtTuNgay.Value, dtDenNgay.Value, spid, nhomid, iskiemtra);
                if (dtbXuatKhoTB != null && dtbXuatKhoTB.Rows.Count > 0)
                {
                    XuatReport(tieude, spid, nhomid, iskiemtra, dtbXuatKhoTB);
                }
                else
                {
                    MessageBox.Show("Dữ liệu tồn không có. Vui lòng kiểm tra lại!");
                }
            }
            else if (RbtnSanPham.IsChecked == false && RbtnNhomSanPham.IsChecked == true && cboNhom.SelectedValue != null)
            {
                CSQLNhomSP nsp = new CSQLNhomSP();
                string tennhomSP = nsp.LayNhomCanSua(cboNhom.SelectedValue.ToString()).Rows[0]["TenNSP"].ToString();
                tieude = "BÁO CÁO XUẤT KHO TRUNG BÌNH " + tennhomSP + "";
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                DataTable dtbXuatKhoTB = new DataTable();
                spid = "00000000-0000-0000-0000-000000000000";
                nhomid = cboNhom.SelectedValue.ToString();
                iskiemtra = false;
                dtbXuatKhoTB = tonkhoct_.BaoCaoXuatKhoTB_LoadDSTuNgay_DenNgay(dtTuNgay.Value, dtDenNgay.Value, spid, nhomid, iskiemtra);
                if (dtbXuatKhoTB != null && dtbXuatKhoTB.Rows.Count > 0)
                {
                    XuatReport(tieude, spid, nhomid, iskiemtra, dtbXuatKhoTB);
                }
                else
                {
                    MessageBox.Show("Dữ liệu tồn không có. Vui lòng kiểm tra lại!");
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu thông tin chưa đầy đủ. Vui lòng kiểm tra lại !");
            }
            #endregion

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        private Report_BC_XuatKhoTB XuatReport(string _tieudein, string spid, string nhomid, bool iskiemtra, DataTable dtbXuatKhoTB)
        {
            Report_BC_XuatKhoTB check = new Report_BC_XuatKhoTB();
            check.SetDataSource(dtbXuatKhoTB);

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = _tieudein;
            ParameterValues pv = new ParameterValues();
            pv.Add(pdv);
            check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);

            ParameterDiscreteValue pdv_tungay = new ParameterDiscreteValue();
            pdv_tungay.Value = dtTuNgay.Value;
            ParameterValues pv_tungay = new ParameterValues();
            pv_tungay.Add(pdv_tungay);
            check.DataDefinition.ParameterFields["@TuNgay"].ApplyCurrentValues(pv_tungay);

            ParameterDiscreteValue pdv_denngay = new ParameterDiscreteValue();
            pdv_denngay.Value = dtDenNgay.Value;
            ParameterValues pv_denngay = new ParameterValues();
            pv_denngay.Add(pdv_denngay);
            check.DataDefinition.ParameterFields["@DenNgay"].ApplyCurrentValues(pv_denngay);

            ParameterDiscreteValue pdv_spid = new ParameterDiscreteValue();
            pdv_spid.Value = spid;
            ParameterValues pv_spid = new ParameterValues();
            pv_spid.Add(pdv_spid);
            check.DataDefinition.ParameterFields["@SPID"].ApplyCurrentValues(pv_spid);

            ParameterDiscreteValue pdv_nhomid = new ParameterDiscreteValue();
            pdv_nhomid.Value = nhomid;
            ParameterValues pv_nhomid = new ParameterValues();
            pv_nhomid.Add(pdv_nhomid);
            check.DataDefinition.ParameterFields["@NSPid"].ApplyCurrentValues(pv_nhomid);

            ParameterDiscreteValue pdv_isKiemTra = new ParameterDiscreteValue();
            pdv_isKiemTra.Value = iskiemtra;
            ParameterValues pv_isKiemTra = new ParameterValues();
            pv_isKiemTra.Add(pdv_isKiemTra);
            check.DataDefinition.ParameterFields["@DKKiemTra"].ApplyCurrentValues(pv_isKiemTra);

            RW_BC_XKTB.ReportSource = check;
            return check;
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

        public void LayDSNhomSPLenCBO()
        {
            CSQLNhomSP nhomsp = new CSQLNhomSP();
            cboNhom.DisplayMember = "TENNSP";
            cboNhom.ValueMember = "NSPID";
            cboNhom.DataSource = nhomsp.LoadDSNhomSPLenLuoi(true);
            cboNhom.SelectedIndex = -1;
        }

        private void RbtnNhomSanPham_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (RbtnNhomSanPham.IsChecked == true)
            {
                radMultiColumnComboboxMaTenSP.SelectedIndex = -1;
                radMultiColumnComboboxMaTenSP.Enabled = false;
                cboNhom.Enabled = true;
            }
            else
            {
                cboNhom.Enabled = false;
                radMultiColumnComboboxMaTenSP.Enabled = true;
            }
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

    }
}
