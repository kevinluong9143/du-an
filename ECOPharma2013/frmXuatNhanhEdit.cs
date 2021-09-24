using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;
using ECOPharma2013.From_Report;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Runtime.InteropServices;

namespace ECOPharma2013
{
    public partial class frmXuatNhanhEdit : Form
    {
        public frmXuatNhanhEdit()
        {
            InitializeComponent();
        }
        frmMain fmain;
        string XNID, SoPXN, XNCTID;
        public frmXuatNhanhEdit(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }

        public void NhanThongTinXuatNhanh(string xnid, string sopxn)
        {
            XNID = xnid;
            SoPXN = sopxn;
        }

        private void rbtnDong_Click(object sender, EventArgs e)
        {
            fmain.frmXuatNhanhEditisOpen_ = false;
            this.Close();
        }

        private void frmXuatNhanhEdit_Load(object sender, EventArgs e)
        {
            LayLyDoXuatLenCBO();
            LayNPPLenCBO();
            KiemTraDanhSachChiTietKho(XNID);
            LayMaSP_TenSPLenMCBO();

            if (XNID != null && XNID.Length > 0)
            {
                CSQLXuatNhanh xn = new CSQLXuatNhanh();
                DataTable dtbxn = xn.Load1XuatNhanh(XNID);
                if (dtbxn != null && dtbxn.Rows.Count > 0)
                {
                    txtSoPXN.Text = dtbxn.Rows[0]["SoPXN"].ToString();
                    dtNgayTao.Value = DateTime.Parse(dtbxn.Rows[0]["NgayTao"].ToString());
                    cboLyDo.SelectedValue = dtbxn.Rows[0]["LDID"].ToString();
                    cboNPP.SelectedValue = new Guid(dtbxn.Rows[0]["XUATDENID"].ToString());
                    ckDuyetPhieuXuat.Checked = bool.Parse(dtbxn.Rows[0]["DAXETDUYET"].ToString());
                    txtGhiChu.Text = dtbxn.Rows[0]["GHICHU"].ToString();
                    if (bool.Parse(dtbxn.Rows[0]["DaxacNhan"].ToString()) == true)
                    {
                        ckDuyetPhieuXuat.Enabled = false;
                    }
                    else
                    {
                        ckDuyetPhieuXuat.Enabled = true;
                    }

                    CSQLXuatNhanhCT xnct = new CSQLXuatNhanhCT();
                    rgvChiTiet.DataSource = xnct.LoadLenLuoi(XNID);
                }
            }
        }

        private void KiemTraDanhSachChiTietKho(string XNID)
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();

            if (!string.IsNullOrEmpty(XNID))
            {
                CSQLXuatNhanhCT xnct = new CSQLXuatNhanhCT();
                if (xnct.LoadLenLuoi(XNID).Rows.Count > 0)
                {
                    Boolean IsHangDacBiet = xnct.KiemTraDanhSachChiTiet(XNID);
                    cbkHangDacBiet.Enabled = false;

                    if (IsHangDacBiet)
                    {
                        cbkHangDacBiet.Checked = true;

                        if (cbkHangDacBiet.Checked && !chht.KiemTraTrangThaiXemKhoDacBiet())
                        {
                            MessageBox.Show("Vui lòng làm mới lại danh sách Xuất nhanh");
                            fmain.frmXuatNhanhEditisOpen_ = false;
                            this.Close();
                        }
                    }
                }
                else
                {
                    cbkHangDacBiet.Enabled = true;
                    CSQLXuatNhanh aXuatNhanh = new CSQLXuatNhanh();
                    cbkHangDacBiet.Checked = aXuatNhanh.IsKhoDacBiet(XNID);
                }
            }
            else {
                cbkHangDacBiet.Visible = chht.KiemTraTrangThaiXemKhoDacBiet();
            }

            cbkHangDacBiet.Visible = chht.KiemTraTrangThaiXemKhoDacBiet();
        }

        #region khởi tạo xuất nhanh lên form(master)
        private void LayNPPLenCBO()
        {
            CSQLNPP npp_ = new CSQLNPP();
            cboNPP.DisplayMember = "TenNPP";
            cboNPP.ValueMember = "NPPID";
            cboNPP.DataSource = npp_.LoadDSNPPLenMComboBox();
            cboNPP.SelectedIndex = -1;
            cboNPP.EditorControl.Columns["NPPID"].IsVisible = false;
            cboNPP.EditorControl.Columns["TenNPP"].Width = 320;

            cboNPP.AutoFilter = true;
            cboNPP.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.Suggest;
            FilterDescriptor descriptor12 = new FilterDescriptor(cboNPP.DisplayMember, FilterOperator.Contains, string.Empty);

            cboNPP.EditorControl.MasterTemplate.FilterDescriptors.Add(descriptor12);
            cboNPP.DropDownStyle = RadDropDownStyle.DropDown;

            cboNPP.MultiColumnComboBoxElement.DropDownWidth = 350;
            cboNPP.MultiColumnComboBoxElement.DropDownHeight = 300;
        }

        private void LayLyDoXuatLenCBO()
        {
            CSQLXuatNhanh xn = new CSQLXuatNhanh();
            cboLyDo.ValueMember = "LDID";
            cboLyDo.DisplayMember = "LYDO";
            cboLyDo.DataSource = xn.LoadLyDoXuatLenCBO();
            cboLyDo.SelectedIndex = -1;
        }

        private void LayNhomKho()
        {



        }
        #endregion khởi tạo xuất nhanh lên form(master)

        #region Khởi tạo xuất nhanh chi tiết lên form
        #region  Xử lý lấy dữ liệu lên MultiColumnCombobox
        private void LayMaSP_TenSPLenMCBO()
        {
            CSQLTonKho tk = new CSQLTonKho();

            mcboMaSP.ValueMember = "SPNSXID";
            mcboMaSP.DisplayMember = "MaSP";
            mcboMaSP.DataSource = tk.LayMaSP_TenSP(cbkHangDacBiet.Checked);

            mcboTenSP.ValueMember = "SPNSXID";
            mcboTenSP.DisplayMember = "TenSP";
            mcboTenSP.DataSource = tk.LayMaSP_TenSP(cbkHangDacBiet.Checked);
            mcboMaSP.SelectedIndex = -1;
            mcboTenSP.SelectedIndex = -1;

            mcboMaSP.EditorControl.Columns["SPID"].IsVisible = false;
            mcboMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
            mcboMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
            mcboMaSP.EditorControl.Columns["DVTID_Chuan"].IsVisible = false;
            mcboMaSP.EditorControl.Columns["MaSP"].Width = 65;
            mcboMaSP.EditorControl.Columns["TenSP"].Width = 250;
            mcboMaSP.EditorControl.Columns["TenNSX"].Width = 150;
            mcboMaSP.EditorControl.Columns["SLTon"].Width = 65;
            mcboMaSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
            mcboMaSP.EditorControl.Columns["DVChuan"].Width = 65;
            mcboMaSP.AutoFilter = true;
            FilterDescriptor descriptor = new FilterDescriptor(this.mcboMaSP.DisplayMember, FilterOperator.IsEqualTo, string.Empty);
            this.mcboMaSP.EditorControl.FilterDescriptors.Add(descriptor);
            this.mcboMaSP.DropDownStyle = RadDropDownStyle.DropDown;
            mcboMaSP.MultiColumnComboBoxElement.DropDownWidth = 630;
            mcboMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;

            mcboTenSP.EditorControl.Columns["SPID"].IsVisible = false;
            mcboTenSP.EditorControl.Columns["NSXID"].IsVisible = false;
            mcboTenSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
            mcboTenSP.EditorControl.Columns["DVTID_Chuan"].IsVisible = false;
            mcboTenSP.EditorControl.Columns["MaSP"].Width = 65;
            mcboTenSP.EditorControl.Columns["TenSP"].Width = 250;
            mcboTenSP.EditorControl.Columns["TenNSX"].Width = 150;
            mcboTenSP.EditorControl.Columns["SLTon"].Width = 65;
            mcboTenSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
            mcboTenSP.EditorControl.Columns["DVChuan"].Width = 65;
            mcboTenSP.AutoFilter = true;
            FilterDescriptor descriptor1 = new FilterDescriptor(this.mcboTenSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
            this.mcboTenSP.EditorControl.FilterDescriptors.Add(descriptor1);
            this.mcboTenSP.DropDownStyle = RadDropDownStyle.DropDown;
            mcboTenSP.MultiColumnComboBoxElement.DropDownWidth = 630;
            mcboTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;

        }
        #endregion Xử lý lấy dữ liệu lên MultiColumnCombobox
        #region  Xử lý khi chọn MaSP khác giữa 2 MultiColumnCombobox
        private void mcboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboLyDo.SelectedValue != null && cboLyDo.SelectedValue.ToString().Length > 0 || mcboMaSP.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cboLyDo, "");
                    if (mcboTenSP.SelectedValue == null || (mcboTenSP.SelectedValue != null && mcboMaSP.SelectedValue.ToString().CompareTo(mcboTenSP.SelectedValue.ToString()) != 0))
                    {
                        mcboTenSP.SelectedValue = mcboMaSP.SelectedValue;
                    }
                    if (mcboMaSP.SelectedValue != null)
                    {
                        LayNSXLenCboNSX(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                        //txtSLDapUng.Focus();
                    }
                    else
                    {
                        mcboTenSP.SelectedIndex = -1;
                        mcboMaSP.SelectedValue = null;
                        cboNSX.SelectedIndex = -1;
                        cboSoLo.SelectedIndex = -1;
                        cboDVT.SelectedIndex = -1;
                        cboKho.SelectedIndex = -1;
                        txtSLCoTheXuat.Text = "";
                        //txtSLDapUng.Text = "";
                        txtSL.Text = "";
                        txtSLTon.Text = "";
                        txtDVC.Text = "";
                    }
                    RadMultiColumnComboBox comboBox = (RadMultiColumnComboBox)sender;
                    RadTextBoxItem rtbi = (RadTextBoxItem)comboBox.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                    rtbi.SelectionLength = 0;
                }
                else
                {
                    errorProvider1.SetError(cboLyDo, "Bạn phải chọn lý do trước!");
                    return;
                }
            }
            catch
            {
                statusTB.Text = "";
            }
        }
        private void mcboTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLyDo.SelectedValue != null && cboLyDo.SelectedValue.ToString().Length > 0 || mcboTenSP.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboLyDo, "");
                if (mcboTenSP.SelectedValue != null && mcboTenSP.SelectedIndex != -1)
                {
                    //Lấy mã sp
                    if (mcboMaSP.SelectedValue == null || (mcboMaSP.SelectedValue != null && mcboTenSP.SelectedValue.ToString().CompareTo(mcboMaSP.SelectedValue.ToString()) != 0))
                    {
                        mcboMaSP.SelectedValue = mcboTenSP.SelectedValue;
                    }
                }
                RadMultiColumnComboBox comboBox = (RadMultiColumnComboBox)sender;
                RadTextBoxItem rtbi = (RadTextBoxItem)comboBox.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                rtbi.SelectionLength = 0;
            }
            else
            {
                errorProvider1.SetError(cboLyDo, "Bạn phải chọn lý do trước!");
                return;
            }
        }
        #endregion Xử lý khi chọn MaSP khác giữa 2 MultiColumnCombobox
        #region Lấy thông tin lên ColumnCombobox Nhà Sản Xuất
        private void LayNSXLenCboNSX(string spid)
        {
            if (spid != null && spid.Length > 0)
            {
                CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                cboNSX.DisplayMember = "TenNSX";
                cboNSX.ValueMember = "NSXID";
                cboNSX.DataSource = spnsx.LayNSXVaoCBX(spid);
                cboNSX.SelectedValue = new Guid(mcboMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
            }
            else
                cboNSX.DataSource = null;
        }
        #endregion Lấy thông tin lên ColumnCombobox Nhà Sản Xuất
        #region Lấy thông tin lên combobox Kho
        private void LayKho(string spid, string nsxid, int nhomKho)
        {
            if (spid != null && spid.Length > 0 && nsxid != null && nsxid.Length > 0)
            {
                CSQLTonKhoCT tkct = new CSQLTonKhoCT();
                DataTable dtb = new DataTable();

                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                if (cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet())
                {
                    CSQLKho aKho = new CSQLKho();
                    string mabp_ = chht.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();
                    string MaBPcon = "";
                    CSQLBoPhan bp_ = new CSQLBoPhan();
                    DataTable bpct_ = bp_.TimMaBPChaTheoMa(mabp_);
                    string mabpcha = bpct_.Rows[0]["MaBPCha"].ToString();
                    if (mabpcha != null && mabpcha.Length > 0)
                    {
                        MaBPcon = mabpcha;
                    }
                    else
                    {
                        MaBPcon = mabp_;
                    }
                    
                    dtb = aKho.LayKhoDacBiet_TongCongTy(MaBPcon);
                }
                else
                {
                    dtb = tkct.LayTTKho(nhomKho);
                }

                if (dtb != null && dtb.Rows.Count > 0)
                {
                    statusTB.Text = "";
                    cboKho.DataSource = dtb;
                    cboKho.DisplayMember = "TenKho";
                    cboKho.ValueMember = "KhoID";
                    CSQLSanPham_Kho spk = new CSQLSanPham_Kho();
                    string khoid = spk.LayMaKhoMacDinhKhiXuat(spid);
                    if (khoid != null && khoid.Length > 0)
                    {
                        cboKho.SelectedValue = new Guid(khoid);
                        statusTB.Text = "";
                    }
                    else
                    {
                        cboKho.SelectedIndex = -1;
                        statusTB.Text = "Thông báo: Chưa có kho xuất mặc định cho sản phẩm này!";
                        txtTongSL.Text = "0";
                        txtDVC.Text = "";
                        return;
                    }
                }
                else
                {
                    cboKho.DataSource = null;
                    statusTB.Text = "Thông báo: Chưa có kho nào chứa sản phẩm của nhà sản xuất này!";
                    txtTongSL.Text = "0";
                    txtDVC.Text = "";
                    return;
                }
            }
            else
            {
                cboKho.DataSource = null;
                statusTB.Text = "Thông báo: Không xác định được sản phẩm hoặc nhà sản xuất để lấy kho!";
                return;
            }
        }
        #endregion Lấy thông tin lên combobox Kho
        #region Lấy thông tin lên DVT
        private void LayThongTinDVTKhiKhoIDThayDoi(string spid, string khoid)
        {
            if (spid != null && khoid != null && spid.Length > 0 && khoid.Length > 0)
            {
                //Lấy danh sách DVT từ bảng hệ số qui đổi
                cboDVT.DisplayMember = "TenTuDVT";
                cboDVT.ValueMember = "TuDVTID";
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                DataTable dsdvt = hsqd.LayDVTTheoSPID(spid);
                if (dsdvt != null && dsdvt.Rows.Count > 0)
                {
                    cboDVT.DataSource = dsdvt;
                }
                else
                {
                    cboDVT.DataSource = null;
                    txtDVC.Text = "";
                    dtHanDung.Value = DateTime.MaxValue;
                    txtSLTon.Text = "0";
                    txtSLCoTheXuat.Text = "0";
                    txtTongSL.Text = "0";
                    txtDVC.Text = cboDVT.Text;
                }
                //Lấy dvchuan từ bảng Tồn kho chi tiết để làm dv mặc định
                //CSQLTonKhoCT tkct = new CSQLTonKhoCT();
                //DataTable dtb = tkct.LayTTKDVT(spid, khoid);

                CSQLSanPham sp = new CSQLSanPham();
                DataTable dtb = sp.SanPham_LayDVNhap_DVXuat_DVBan_DVChuan_TheoSPID(spid);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    cboDVT.SelectedValue = dtb.Rows[0]["DVXuat"].ToString();
                    txtDVC.Text = cboDVT.Text;
                    try
                    {
                        decimal tyle = (decimal)hsqd.TinhTyLeHSQD(spid, cboDVT.SelectedValue.ToString());
                        txtTongSL.Text = (decimal.Parse(mcboMaSP.EditorControl.CurrentRow.Cells["TSLTon"].Value.ToString()) * tyle).ToString();
                    }
                    catch
                    {
                        txtTongSL.Text = "0";
                        txtDVC.Text = "";
                        txtSLTon.Text = "0";
                        txtSLCoTheXuat.Text = "0";
                        txtTongSL.Text = "0";
                        txtDVC.Text = cboDVT.Text;
                    }

                }
                else
                {
                    cboDVT.SelectedIndex = 0;
                    txtDVC.Text = "";
                    txtSLTon.Text = "0";
                    txtSLCoTheXuat.Text = "0";
                    txtTongSL.Text = "0";
                    txtDVC.Text = cboDVT.Text;
                }
            }
            else
            {
                cboDVT.DataSource = null;
                txtDVC.Text = "";
                txtSLTon.Text = "0";
                txtSLCoTheXuat.Text = "0";
                txtTongSL.Text = "0";
                txtDVC.Text = cboDVT.Text;
            }
        }
        #endregion Lấy thông tin lên DVT
        #region Lấy thông tin lên cbxLo
        private void LayThongTinLenCbxLo(string spid, string khoid, string nsxid)
        {
            if (spid == null || spid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn sản phẩm!";
                return;
            }
            else statusTB.Text = "";


            if (nsxid == null || nsxid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn nhà sản xuất!";
                return;
            }
            else statusTB.Text = "";
            if (khoid == null || khoid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn kho!"; return;
            }
            else statusTB.Text = "";

            cboSoLo.DisplayMember = "Lot";
            cboSoLo.ValueMember = "Lot";
            CSQLTonKhoCT tkct = new CSQLTonKhoCT();
            DataTable dtb = tkct.LayLoTheoSPID_KhoID(spid, khoid, nsxid);
            if (dtb.Rows.Count > 0)
            {
                cboSoLo.DataSource = dtb;
            }
            else
            {
                txtSLTon.Text = "0";
                txtSLCoTheXuat.Text = "0";
                txtTongSL.Text = "0";
                txtDVC.Text = cboDVT.Text;
            }
        }
        #endregion Lấy thông tin lên cbxLo
        #region Lấy thông tin lên dtHanDung, slton, slcothexuat
        private void LayThongTinDate(string spid, string khoid, string lot, string nsxid)
        {
            try
            {
                CSQLHeSoQuyDoi hsqd_ = new CSQLHeSoQuyDoi();
                CSQLTonKhoCT tk = new CSQLTonKhoCT();
                DataTable dtb = tk.LayDate_SLTon_SLCoTheXuat_TheoLo(spid, khoid, lot, nsxid);
                //if (hsqd_.LayHSQDTheoSPID_TuDVT(spid, cboDVT.SelectedValue.ToString()).Rows.Count > 0)
                //{
                decimal hsqd = (decimal)hsqd_.TinhTyLeHSQD(spid, cboDVT.SelectedValue.ToString());
                dtHanDung.Value = DateTime.Parse(dtb.Rows[0][0].ToString());
                //txtTongSL.Text = String.Format("{0:0,0.00}", Math.Round(decimal.Parse(mcboMaSP.EditorControl.CurrentRow.Cells["SLTon"].Value.ToString()) * hsqd));
                //txtSLTon.Text = String.Format("{0:0,0.00}", Math.Round(decimal.Parse(dtb.Rows[0][1].ToString()) * hsqd));
                //txtSLCoTheXuat.Text = String.Format("{0:0,0.00}", Math.Round(decimal.Parse(dtb.Rows[0][2].ToString()) * hsqd));
                try
                {
                    txtTongSL.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(mcboMaSP.EditorControl.CurrentRow.Cells["SLTon"].Value.ToString()) * hsqd), 2));
                }
                catch
                {
                    txtTongSL.Text = "null";
                }
                try
                {
                    txtSLTon.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(dtb.Rows[0][1].ToString()) * hsqd), 2));
                }
                catch
                {
                    txtSLTon.Text = "null";
                }
                try
                {
                    txtSLCoTheXuat.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(dtb.Rows[0][2].ToString()) * hsqd), 2));
                }
                catch
                {
                    txtSLCoTheXuat.Text = "null";
                }


                //txtTongSL.Text =String.Format("{0:0,0.00}", Math.Round(decimal.Parse(dtb.Rows[0][3].ToString()) * hsqd));

                txtDVC.Text = cboDVT.Text;
                //}

                //if (spid != null && khoid != null && lot != null && spid.Length > 0 && khoid.Length > 0 && lot.Length > 0)
                //{
                //    CSQLTonKhoCT tk = new CSQLTonKhoCT();
                //    DataTable dtb = tk.LayDate_SLTon_SLCoTheXuat_TheoLo(spid, khoid, lot);
                //    if (dtb != null && dtb.Rows.Count > 0)
                //    {
                //        dtHanDung.Value = DateTime.Parse(dtb.Rows[0][0].ToString());
                //        txtSLTon.Text = dtb.Rows[0][1].ToString();
                //        txtSLCoTheXuat.Text = dtb.Rows[0][2].ToString();
                //    }
                //}
            }
            catch (Exception ex)
            {
                txtSLTon.Text = "0.00";
                txtSLCoTheXuat.Text = "0.00";
                //statusTB.Text = ex.Message;
            }
        }
        #endregion Lấy thông tin lên dtHanDung, slton, slcothexuat

        private void cbxSoLo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoLo.DataSource != null)
            {
                //LayThongTinDate(radMultiColumnComboBoxMaSP.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cbxSoLo.SelectedValue.ToString());
                LayThongTinDate(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString(), cboSoLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
            }
        }

        private void cboDVT_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                CSQLHeSoQuyDoi hsqd_ = new CSQLHeSoQuyDoi();
                CSQLTonKhoCT tk = new CSQLTonKhoCT();
                DataTable dtb = tk.LayDate_SLTon_SLCoTheXuat_TheoLo(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString(), cboSoLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                decimal hsqd = hsqd_.TinhTyLeHSQD(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboDVT.SelectedValue.ToString());
                txtDVC.Text = cboDVT.Text;
                try
                {
                    txtTongSL.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(mcboMaSP.EditorControl.CurrentRow.Cells["SLTon"].Value.ToString()) * hsqd), 2));
                }
                catch
                {
                    txtTongSL.Text = "null";
                }
                try
                {
                    txtSLTon.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(dtb.Rows[0][1].ToString()) * hsqd), 2));
                }
                catch
                {
                    txtSLTon.Text = "null";
                }
                try
                {
                    txtSLCoTheXuat.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(dtb.Rows[0][2].ToString()) * hsqd), 2));
                }
                catch
                {
                    txtSLCoTheXuat.Text = "null";
                }
            }
            catch { }
        }

        private void cboKho_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboKho != null && cboKho.SelectedValue != null)
                {
                    LayThongTinDVTKhiKhoIDThayDoi(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString());
                    LayThongTinLenCbxLo(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                }
                else
                {
                    //statusTB.Text = "Hàng chưa được nhập vào kho này";
                    cboDVT.DataSource = null;
                    cboSoLo.DataSource = null;
                    cboSoLo.Text = "";
                    dtHanDung.Value = DateTime.Now;
                    txtSLTon.Text = "";
                    txtSLCoTheXuat.Text = "";
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        private void cboNSX_SelectedValueChanged(object sender, EventArgs e)
        {
            CSQLLyDoXuatNhanh nhomKho = new CSQLLyDoXuatNhanh();
            DataTable tblNhomKho = new DataTable();


            if (mcboMaSP.SelectedValue != null && mcboMaSP.SelectedValue.ToString().Length > 0 && cboNSX.SelectedValue != null && cboNSX.SelectedValue.ToString().Length > 0)
            {
                //lay nhóm lý do dựa vào mã lý do=>từ nhóm lý do sẽ lấy ra nhóm kho
                tblNhomKho = nhomKho.LayNhomKhoTuLyDo(int.Parse(cboLyDo.SelectedValue.ToString()));
                if (tblNhomKho.Rows.Count > 0)
                    //LayKho(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNSX.SelectedValue.ToString(), int.Parse(cboLyDo.SelectedValue.ToString()));
                    LayKho(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNSX.SelectedValue.ToString(), int.Parse(tblNhomKho.Rows[0][0].ToString()));
            }

        }
        #endregion Khởi tạo xuất nhanh chi tiết lên form

        private void rbtnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            string nppid = "00000000-0000-0000-0000-000000000000";
            if (qtc.KiemTraQuyenThem_Sua(fmain.fXuatNhanh.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            if (!chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            //try
            //{
            if (cboLyDo.SelectedIndex == -1)
            {
                cboLyDo.Focus();
                errorProvider1.SetError(cboLyDo, "Bạn phải chọn lý do xuất hàng!");
                return;
            }
            else
            {
                errorProvider1.SetError(cboLyDo, "");
            }

            if ((cboLyDo.SelectedValue.ToString() == "1" || cboLyDo.SelectedValue.ToString() == "2") && (cboNPP.SelectedValue == null))
            {
                cboNPP.Focus();
                errorProvider1.SetError(cboNPP, "Bạn phải chọn Nhà Cung Cấp");
                return;
            }

            if (cboLyDo.SelectedValue.ToString() == "1" || cboLyDo.SelectedValue.ToString() == "2")
            {
                nppid = cboNPP.SelectedValue.ToString();
            }
            else
            {
                nppid = "00000000-0000-0000-0000-000000000000";
            }
            if (XNID == null || XNID.CompareTo("") == 0)
            {
                CSQLXuatNhanh xn = new CSQLXuatNhanh();
                string[] kq = xn.Them(int.Parse(cboLyDo.SelectedValue.ToString()), nppid, txtGhiChu.Text, CStaticBien.SmaTaiKhoan, "00000000-0000-0000-0000-000000000000", cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet());
                if (kq[0] != string.Empty)
                {
                    statusTB.Text = "Thêm thành công";
                    txtSoPXN.Text = SoPXN = kq[1];
                    XNID = kq[0];
                }
                else
                {
                    statusTB.Text = "Thêm thất bại";
                }
            }
            else
            {
                CSQLXuatNhanh xn = new CSQLXuatNhanh();
                int kq = xn.Sua(int.Parse(cboLyDo.SelectedValue.ToString()), nppid, txtGhiChu.Text, CStaticBien.SmaTaiKhoan, ckDuyetPhieuXuat.Checked, XNID, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet());
                if (kq > 0)
                {
                    statusTB.Text = "Sửa thành công";
                }
                else
                {
                    statusTB.Text = "Sửa thất bại";
                }

            }
            // }
            //catch (ApplicationException Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fXuatNhanh.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            if (!chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            #region thêm master
            try
            {
                if (cboLyDo.SelectedIndex == -1)
                {
                    cboLyDo.Focus();
                    errorProvider1.SetError(cboLyDo, "Bạn phải chọn lý do xuất hàng!");
                    return;
                }
                else
                {
                    errorProvider1.SetError(cboLyDo, "");
                }

                if ((cboLyDo.SelectedValue == "1") && (cboNPP.SelectedValue == null))
                {
                    cboNPP.Focus();
                    errorProvider1.SetError(cboNPP, "Bạn phải chọn Nhà Cung Cấp");
                    return;
                }


                if (XNID == null || XNID.CompareTo("") == 0)
                {
                    CSQLXuatNhanh xn = new CSQLXuatNhanh();
                    string nppid = "00000000-0000-0000-0000-000000000000";
                    if (cboNPP.SelectedValue != null)
                    {
                        nppid = cboNPP.SelectedValue.ToString();
                    }
                    else
                    {
                        nppid = "00000000-0000-0000-0000-000000000000";
                    }
                    string[] kq = xn.Them(int.Parse(cboLyDo.SelectedValue.ToString()), nppid, txtGhiChu.Text, CStaticBien.SmaTaiKhoan, "00000000-0000-0000-0000-000000000000", cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet());
                    if (kq[0] != string.Empty)
                    {
                        statusTB.Text = "Thêm thành công";
                        txtSoPXN.Text = SoPXN = kq[1];
                        XNID = kq[0];
                    }
                    else
                    {
                        statusTB.Text = "Thêm thất bại";
                    }
                }
                else
                {
                    CSQLXuatNhanh xn = new CSQLXuatNhanh();
                    int kq = xn.Sua(int.Parse(cboLyDo.SelectedValue.ToString()), cboNPP.SelectedValue.ToString(), txtGhiChu.Text, CStaticBien.SmaTaiKhoan, ckDuyetPhieuXuat.Checked, XNID, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet());
                    if (kq > 0)
                    {
                        statusTB.Text = "Sửa thành công";
                    }
                    else
                    {
                        statusTB.Text = "Sửa thất bại";
                    }

                }
            }
            catch (ApplicationException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            #endregion thêm master

            #region thêm detail
            if (XNID != null)
            {
                CSQLXuatNhanhCT xnct = new CSQLXuatNhanhCT();

                #region Kiểm tra dữ liệu
                if (XNCTID == null || XNCTID.Length == 0) //Sua detail
                {
                    XNCTID = "00000000-0000-0000-0000-000000000000";
                }
                if (mcboMaSP.SelectedValue == null || mcboMaSP.SelectedIndex == -1)
                {
                    statusTB.Text = "Bạn chưa chọn sản phẩm trả!";
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }
                if (txtSL.Text.CompareTo("") == 0)
                {
                    statusTB.Text = "Bạn chưa nhập số lượng!";
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }
                if (cboKho.SelectedValue == null || cboKho.SelectedIndex == -1)
                {
                    statusTB.Text = "Bạn chưa chọn kho!";
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }
                if (cboNSX.SelectedValue == null || cboNSX.SelectedIndex == -1)
                {
                    statusTB.Text = "Bạn chưa chọn nhà sản xuất!";
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }
                if (cboSoLo.SelectedValue == null || cboSoLo.SelectedIndex == -1)
                {
                    statusTB.Text = "Bạn chưa chọn số lô!";
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }
                #endregion Kiểm tra dữ liệu

                CSQLKho aKho = new CSQLKho();
                if (cbkHangDacBiet.Checked && !aKho.IsKhoDacBiet(cboKho.SelectedValue.ToString()))
                {
                    MessageBox.Show("Vui lòng chọn kho đặc biệt");
                    return;
                }
                else if (!cbkHangDacBiet.Checked && aKho.IsKhoDacBiet(cboKho.SelectedValue.ToString()))
                {
                    MessageBox.Show("Vui lòng chọn kho khác");
                    return;
                }

                int kq = xnct.Them(XNID, mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString(), decimal.Parse(txtSL.Text), cboDVT.SelectedValue.ToString(), cboSoLo.SelectedValue.ToString(), dtHanDung.Value, cboNSX.SelectedValue.ToString(), XNCTID);
                if (kq > 0)
                {
                    rgvChiTiet.DataSource = xnct.LoadLenLuoi(XNID);
                    mcboMaSP.SelectedIndex = -1;
                    txtSL.Text = "";
                    cboDVT.SelectedIndex = -1;
                    cboKho.SelectedIndex = -1;
                    cboSoLo.SelectedIndex = -1;
                    cboNSX.SelectedIndex = -1;
                    dtHanDung.Value = DateTime.Now;
                    statusTB.Text = "Thêm chi tiết thành công!";
                }
                else
                {
                    statusTB.Text = "Thêm chi tiết thất bại!";
                }
            }
            #endregion thêm detail

            KiemTraDanhSachChiTietKho(XNID);
        }

        private void ckDuyetPhieuXuat_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyetPhieuXuat.Checked == true)
            {
                cboLyDo.Enabled = false;
                cboNPP.Enabled = false;
                txtGhiChu.Enabled = false;
                mcboMaSP.Enabled = false;
                mcboTenSP.Enabled = false;
                txtSL.Enabled = false;
                cboKho.Enabled = false;
                cboSoLo.Enabled = false;
                cboDVT.Enabled = false;
                btnAdd.Enabled = false;
                cbkHangDacBiet.Enabled = false;
            }
            else
            {
                cboLyDo.Enabled = true;
                cboNPP.Enabled = true;
                txtGhiChu.Enabled = true;
                mcboMaSP.Enabled = true;
                mcboTenSP.Enabled = true;
                txtSL.Enabled = true;
                cboKho.Enabled = true;
                cboSoLo.Enabled = true;
                cboDVT.Enabled = true;
                btnAdd.Enabled = true;
                cbkHangDacBiet.Enabled = true;
                KiemTraDanhSachChiTietKho(XNID);
            }
        }

        private void rgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && ckDuyetPhieuXuat.Checked == false)
            {
                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                if (!chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                CSQLXuatNhanhCT xnct = new CSQLXuatNhanhCT();
                int kq = xnct.Xoa(rgvChiTiet.CurrentRow.Cells["colXNCTID"].Value.ToString());
                if (kq > 0)
                {
                    statusTB.Text = "Xóa chi tiết thành công!";
                    rgvChiTiet.DataSource = xnct.LoadLenLuoi(XNID);
                }
                else
                {
                    statusTB.Text = "Xóa thất bại!";
                }

                KiemTraDanhSachChiTietKho(XNID);
            }
        }

        private void rgvChiTiet_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
            XNCTID = rgvChiTiet.CurrentRow.Cells["colXNCTID"].Value.ToString();
            string spnsxid = spnsx.SanPham_NSX_LaySPNSXIDTheoSPID_NSXID(rgvChiTiet.CurrentRow.Cells["colSPID"].Value.ToString(), rgvChiTiet.CurrentRow.Cells["colNSXID"].Value.ToString());
            mcboMaSP.SelectedValue = new Guid(spnsxid);
            txtSL.Text = rgvChiTiet.CurrentRow.Cells["colSLXuat"].Value.ToString();
        }

        private void rbtnThemMoi_Click(object sender, EventArgs e)
        {
            txtSoPXN.Text = "";
            dtNgayTao.Value = DateTime.Now;
            cboLyDo.SelectedIndex = -1;
            cboNPP.SelectedIndex = -1;
            txtGhiChu.Text = "";
            ckDuyetPhieuXuat.Checked = false;
            mcboMaSP.SelectedIndex = -1;
            mcboTenSP.SelectedIndex = -1;
            txtSL.Text = "";
            cboKho.SelectedIndex = -1;
            cboNSX.SelectedIndex = -1;
            cboSoLo.SelectedIndex = -1;
            txtSLCoTheXuat.Text = "";
            txtSLTon.Text = "";
            txtTongSL.Text = "";
            rgvChiTiet.DataSource = null;
            this.XNCTID = "";
            this.XNID = "";
            this.SoPXN = "";
        }

        private void txtSL_Leave(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(txtSL.Text) > decimal.Parse(txtSLTon.Text))
                {
                    MessageBox.Show("Bạn không thể xuất nhiều hơn số lượng tồn trong kho!");
                    statusTB.Text = "Bạn không thể xuất nhiều hơn số lượng tồn trong kho!";
                    txtSL.Text = txtSLTon.Text;
                    txtSL.Focus();
                    txtSL.SelectAll();
                }
            }
            catch { }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void rbtnIn_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(fmain.fXuatNhanh.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            InXuatNhanh(XNID);
        }

        public void InXuatNhanh(string xnid)
        {
            CSQLXuatNhanhCT xnct_ = new CSQLXuatNhanhCT();
            if (xnid != null && xnid.Length > 0)
            {
                DataTable XuatNhanhCT_ = xnct_.In_XN_XNCT(xnid);
                Fr_XuatNhanh check = new Fr_XuatNhanh(XuatNhanhCT_);
                check.Show();
            }
        }

        private void mcboMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboKho.Focus();
            }
        }

        private void cboKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSL.Focus();
            }
        }

        private void txtSL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboDVT.Focus();
            }
        }

        private void cboDVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSoLo.Focus();
            }
        }

        private void cboSoLo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtHanDung.Focus();
            }
        }

        private void dtHanDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
        }

        private void cbkHangDacBiet_CheckedChanged(object sender, EventArgs e)
        {
            LayMaSP_TenSPLenMCBO();
        }

        private void rbtnexport_Click(object sender, EventArgs e)
        {
            if (rgvChiTiet.Rows.Count > 0)
            {

                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenIn(fmain.fXuatNhanh.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Excel file (*.xls)|*.xls";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcelML exporter = new ExportToExcelML(this.rgvChiTiet);
                    exporter.ExportVisualSettings = true;

                    string tempPath = Path.GetTempPath();
                    tempPath += @"\XuatNhanh.xls";
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
    }
}
