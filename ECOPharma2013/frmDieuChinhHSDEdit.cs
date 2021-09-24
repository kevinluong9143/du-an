using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls.Data;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;
using ECOPharma2013.Printer_POS;
using Telerik.WinControls.UI;
using ECOPharma2013.From_Report;

namespace ECOPharma2013
{
    public partial class frmDieuChinhHSDEdit : Form
    {
        frmMain _frmMain;
        CSQLCauHinhHeThong chht_ = new CSQLCauHinhHeThong();
        static string DCHSDID, ttcn_;
        public frmDieuChinhHSDEdit()
        {
            InitializeComponent();
        }
        public frmDieuChinhHSDEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
            if (_frmMain.MaDieuChinhHSD_ == null || (_frmMain.MaDieuChinhHSD_ != null && _frmMain.MaDieuChinhHSD_.Length == 0))
                DCHSDID = "00000000-0000-0000-0000-000000000000";
            else
                DCHSDID = _frmMain.MaDieuChinhHSD_; 
        }
        
        private void LayDSMaSP_TenSPLenMultiColumnCombobox()
        {
            try
            {
                CSQLDieuChinhHSDCT dctct = new CSQLDieuChinhHSDCT();
                radMultiColumnComboBoxMaSP.ValueMember = "SPNSXID";
                radMultiColumnComboBoxMaSP.DisplayMember = "TenSP";
                radMultiColumnComboBoxMaSP.DataSource = dctct.LayMaSP_TenSP();
                radMultiColumnComboBoxMaSP.EditorControl.Columns["SPID"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["DVTID_Chuan"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["KhoNhapNTid"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["KhoNhapid"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["MaSP"].Width = 65;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["TenSP"].Width = 250;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["TenNSX"].Width = 150;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["DVChuan"].Width = 65;
                radMultiColumnComboBoxMaSP.AutoFilter = true;
                FilterDescriptor descriptorMaSP = new FilterDescriptor("MaSP", FilterOperator.IsEqualTo, null);
                this.radMultiColumnComboBoxMaSP.EditorControl.FilterDescriptors.Add(descriptorMaSP);
                FilterDescriptor descriptorTenSP = new FilterDescriptor("TenSP", FilterOperator.StartsWith, null);
                this.radMultiColumnComboBoxMaSP.EditorControl.FilterDescriptors.Add(descriptorTenSP);
                this.radMultiColumnComboBoxMaSP.DropDownStyle = RadDropDownStyle.DropDown;
                this.radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownWidth = 550;
                this.radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.radMultiColumnComboBoxMaSP.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                radMultiColumnComboBoxMaSP.SelectedIndex = -1;
            }
            catch { }
        }  
        private void LayKho(string spid, string ntid)
        {
            try
            {
                if (spid != null && spid.Length > 0 && ntid != null && ntid.Length > 0)
                {
                    CSQLKho kho = new CSQLKho();
                    DataTable dtb = new DataTable();
                    if (ntid.ToLower().Equals(ttcn_.ToLower()))
                    {
                        if (chkHangDacBiet.Checked == true)
                            dtb = kho.LoadDSKho_DeDieuChinhTon(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapid"].Value.ToString(), true);
                        else
                            dtb = kho.LoadDSKho_DeDieuChinhTon(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapid"].Value.ToString(), false);
                    }
                    else
                    {
                        if (chkHangDacBiet.Checked == true)
                            dtb = kho.LoadDSKho_DeDieuChinhTon(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapNTid"].Value.ToString(), true);
                        else
                            dtb = kho.LoadDSKho_DeDieuChinhTon(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapNTid"].Value.ToString(), false);
                    }
                    if (dtb != null && dtb.Rows.Count > 0)
                    {
                        cboKho.DisplayMember = "TenKho";
                        cboKho.ValueMember = "KhoID";
                        cboKho.DataSource = dtb;
                        if (ntid.ToLower().Equals(ttcn_.ToLower()))
                        {
                            cboKho.SelectedValue = new Guid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapid"].Value.ToString());
                            CSQLTonKhoCT tk = new CSQLTonKhoCT();
                            DataTable dtbHanDung = tk.LayLoTheoSPID_NSXID_KHOID(spid, cboNSX.SelectedValue.ToString(), cboKho.SelectedValue.ToString());
                            cboLot.DisplayMember = "Lot";
                            cboLot.ValueMember = "Lot";

                            if (dtbHanDung != null && dtbHanDung.Rows.Count > 0) { 
                                dtHanDungSai.Value = DateTime.Parse(dtbHanDung.Rows[0]["Date"].ToString());
                                cboLot.DataSource = dtbHanDung;
                            }
                            cboLot.SelectedIndex = 1;
                }
                        else
                        {
                            cboKho.SelectedValue = new Guid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapNTid"].Value.ToString());
                            cboLot.DataSource = null;
                            dtHanDungSai.Value = DateTime.Now;
                        }
                        statusTB.Text = "";
                    }
                    else
                    {
                        cboKho.DataSource = null;
                        statusTB.Text = "Thông báo: Chưa có kho nào chứa sản phẩm của nhà sản xuất này hoặc bạn chưa chọn nơi điều chỉnh!";
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
            catch (Exception ex) {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void LayNSXLenCboNSX(string spid)
        {
            if (spid != null && spid.Length > 0)
            {
                CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                cboNSX.DisplayMember = "TenNSX";
                cboNSX.ValueMember = "NSXID";
                cboNSX.DataSource = spnsx.LayNSXVaoCBX(spid);
                cboNSX.SelectedValue = new Guid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
            }
            else
                cboNSX.DataSource = null;
        }
        private void frmDieuChinhHSDEdit_Load(object sender, EventArgs e)
        {
            try
            {   
                ttcn_ = chht_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
                bool XemKhoDacBiet = (bool)chht_.LayDanhSachCauHinhHeThong().Rows[0]["IsXemKhoDacBiet"];
                if (XemKhoDacBiet == true)
                    chkHangDacBiet.Show();
                else
                    chkHangDacBiet.Hide();
                
                LayDSMaSP_TenSPLenMultiColumnCombobox();
                cboNSX.Enabled = false;
                if (_frmMain.BangDieuChinhHSD_ != null && _frmMain.BangDieuChinhHSD_.Rows.Count > 0)
                {
                    chkHangDacBiet.Enabled = false;
                    CSQLDieuChinhHSDCT dchsdct = new CSQLDieuChinhHSDCT();
                    txtSoPhieu.Text = _frmMain.BangDieuChinhHSD_.Rows[0]["SoPDCHD"].ToString();
                    dtNgayCT.Value = (DateTime)_frmMain.BangDieuChinhHSD_.Rows[0]["NgayTao"];
                    ckDuyet.Checked = (bool)_frmMain.BangDieuChinhHSD_.Rows[0]["DaXetDuyet"];
                    chkHangDacBiet.Checked = (bool)_frmMain.BangDieuChinhHSD_.Rows[0]["IsKhoDacBiet"];
                    txtGhiChu.Text = _frmMain.BangDieuChinhHSD_.Rows[0]["GhiChu"].ToString();

                    DataTable Bangdchsdchitiet = dchsdct.LayTT_DCHSDCT_Theo_DCHSDid(DCHSDID);
                    if (Bangdchsdchitiet != null && Bangdchsdchitiet.Rows.Count > 0)
                        rgvChiTiet.DataSource = Bangdchsdchitiet;
                    else
                        chkHangDacBiet.Enabled = true;


                    if ((bool)_frmMain.BangDieuChinhHSD_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangDieuChinhHSD_.Rows[0]["DaXacNhan"] == false)
                    {
                        this.rgvChiTiet.Columns["colLot"].ReadOnly = true;
                        this.rgvChiTiet.Columns["colKhoID"].ReadOnly = true;
                        btnAdd.Enabled = false;
                        rbtnThemMoi.Enabled = false;
                    }
                    if ((bool)_frmMain.BangDieuChinhHSD_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangDieuChinhHSD_.Rows[0]["DaXacNhan"] == true)
                    {
                        this.rgvChiTiet.Columns["colLot"].ReadOnly = true;
                        this.rgvChiTiet.Columns["colKhoID"].ReadOnly = true;
                        btnAdd.Enabled = false;
                        rbtnThemMoi.Enabled = false;
                        rbtnLuu.Enabled = false;
                        ckDuyet.Enabled = false;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }  
        private void radMultiColumnComboBoxMaSP_SelectedValueChanged(object sender, EventArgs e)
        {
            if (radMultiColumnComboBoxMaSP.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedIndex != -1)
            {
                LayNSXLenCboNSX(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), "F08F270F-DE84-480D-95F9-0B9CC1285F37");
            }
        }
        private void cboLot_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (radMultiColumnComboBoxMaSP.SelectedValue != null && cboNSX.SelectedValue != null)
            {
                CSQLTonKhoCT tk = new CSQLTonKhoCT();
                DataTable dtbHanDung = tk.LayDateTheoSP_Lot(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboLot.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                dtHanDungSai.Value = DateTime.Parse(dtbHanDung.Rows[0]["Date"].ToString());
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenThem_Sua(_frmMain.fDieuChinhHSD.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                } 

                if (radMultiColumnComboBoxMaSP.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn sản phẩm!";
                    radMultiColumnComboBoxTenSP.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (cboNSX.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn nhà sản xuất!";
                    cboNSX.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (cboKho.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn kho điều chỉnh!";
                    cboKho.Focus();
                    return;
                }
                else statusTB.Text = "";

                CSQLDieuChinhHSD dchsd_ = new CSQLDieuChinhHSD();
                //Thêm Master
                if (txtSoPhieu.Text.Length == 0)
                {
                    #region Thêm điều chỉnh hạn sử dụng
                    dchsd_.SGhiChu = txtGhiChu.Text;
                    dchsd_.SMaNTid = "F08F270F-DE84-480D-95F9-0B9CC1285F37";
                    dchsd_.DNgayTao = dtNgayCT.Value;
                    dchsd_.SUserTao = CStaticBien.SmaTaiKhoan;
                    dchsd_.DLastUD = DateTime.Now;
                    dchsd_.SUserUD = CStaticBien.SmaTaiKhoan;
                    dchsd_.BHangDacBiet = chkHangDacBiet.Checked;
                    if (ckDuyet.Checked == true)
                    {
                        dchsd_.BDaXetDuyet = true;
                        dchsd_.DNgayXetDuyet = DateTime.Now;
                        dchsd_.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
                    }
                    else
                    {
                        dchsd_.BDaXetDuyet = false;
                        dchsd_.DNgayXetDuyet = DateTime.Parse("1/1/1774");
                        dchsd_.SUserXetDuyet = "00000000-0000-0000-0000-000000000000";
                    }

                    dchsd_.BDaXacNhan = false;
                    dchsd_.DNgayXacNhan = DateTime.Parse("1/1/1774"); ;
                    dchsd_.SUserXacNhan = "00000000-0000-0000-0000-000000000000";

                    dchsd_.BIsXoa = false;
                    dchsd_.DNgayXoa = DateTime.Parse("1/1/1774");
                    dchsd_.SUserXoa = "00000000-0000-0000-0000-000000000000";

                    string kq = dchsd_.Them(dchsd_);
                    if (kq.Length > 0)
                    {
                        txtSoPhieu.Text = kq;
                        DCHSDID = dchsd_.LayDCHSDidTheoSoPDCHD(txtSoPhieu.Text);                     
                        _frmMain.MaDieuChinhHSD_ = DCHSDID;
                        groupBox2.Enabled = true;
                        _frmMain.fDieuChinhHSD.rgvPhieuDCHSD.DataSource = dchsd_.LoadDieuChinhHSDLenLuoi(_frmMain.IsXemTatCa_);
                        if (_frmMain.DSDieuChinhHSDXacNhanIsOpen == true)
                        {
                            _frmMain.fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.DataSource = dchsd_.LayDanhSachDieuChinhHSDXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Thêm điều chỉnh hạn sử dụng thất bại!";
                    }
                    #endregion
                }
                else
                {
                    #region Sửa điều chỉnh tồn kho
                    DataTable dbdctk_ = dchsd_.LayDieuChinhHSDTheoMa(_frmMain.MaDieuChinhHSD_);
                    int kq = SuaDieuChinhHSD();
                    if (kq == 1)
                    {
                        statusTB.Text = "Sửa điều chỉnh hạn dùng thành công!";
                        _frmMain.fDieuChinhHSD.rgvPhieuDCHSD.DataSource = dchsd_.LoadDieuChinhHSDLenLuoi(_frmMain.IsXemTatCa_);
                        if (_frmMain.DSDieuChinhHSDXacNhanIsOpen == true)
                        {
                            _frmMain.fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.DataSource = dchsd_.LayDanhSachDieuChinhHSDXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Sửa điều chỉnh hạn dùng thất bại!";
                    }
                    #endregion
                }
                CSQLDieuChinhHSDCT dchsdct = new CSQLDieuChinhHSDCT();

                #region Sửa Điều Chỉnh Tồn Kho Chi Tiết
                if (_frmMain.MaDieuChinhHSDChiTietCanSua_ != null && _frmMain.MaDieuChinhHSDChiTietCanSua_.CompareTo("") > 0)
                {
                    int kq = dchsdct.XoaTTDieuChinhHSDCT(_frmMain.MaDieuChinhHSDChiTietCanSua_);
                }
                #endregion

                #region Thêm Điều Chỉnh Tồn Kho CT

                DCHSDID = dchsd_.LayDCHSDidTheoSoPDCHD(txtSoPhieu.Text);

                CSQLKho kho_ = new CSQLKho();
                string khodacbiet = kho_.KiemTraNhomKhoDacBiet(cboKho.SelectedValue.ToString());
                if (chkHangDacBiet.Checked == true && khodacbiet == null)
                {
                    MessageBox.Show("Khi chọn Hàng Đặc Biệt thì chỉ được điều chỉnh những sản phẩm tại Kho Đặc Biệt!", "Xác nhận");
                    return;

                }
                if (chkHangDacBiet.Checked == false && khodacbiet != null)
                {
                    MessageBox.Show("Khi không chọn Hàng Đặc Biệt thì không được điều chỉnh những sản phẩm tại Kho Đặc Biệt!", "Xác nhận");
                    return;
                }

                if (DCHSDID != null && DCHSDID.Length > 0)
                {
                    dchsdct.SDCHDid = DCHSDID;
                    dchsdct.SSPid = radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString();
                    dchsdct.SMaNTid = "F08F270F-DE84-480D-95F9-0B9CC1285F37";
                    dchsdct.SNSXID = cboNSX.SelectedValue.ToString();
                    dchsdct.SKho = cboKho.SelectedValue.ToString();
                    dchsdct.SLot = cboLot.Text;
                    dchsdct.DDateSai = dtHanDungSai.Value;
                    dchsdct.DDateDung = dtHanDungDung.Value;
                    string kq1 = dchsdct.Them(dchsdct);
                    if (kq1 != null && kq1.Length > 0)
                    {
                        rgvChiTiet.DataSource = dchsdct.LayTT_DCHSDCT_Theo_DCHSDid(DCHSDID);
                        _frmMain.fDieuChinhHSD.rgvPhieuDCHSD.DataSource = dchsd_.LoadDieuChinhHSDLenLuoi(_frmMain.IsXemTatCa_);
                        chkHangDacBiet.Enabled = false;
                        radMultiColumnComboBoxMaSP.SelectedIndex = -1;
                        cboNSX.SelectedIndex = -1;
                        cboLot.DataSource = null;
                        cboKho.DataSource = null;
                        dtHanDungSai.Value = DateTime.Now;
                        dtHanDungDung.Value = DateTime.Now;
                        statusTB.Text = "Thêm thành công";
                        radMultiColumnComboBoxMaSP.Focus();
                    }
                    else
                    {
                        statusTB.Text = "Thêm thất bại";
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }
        private int SuaDieuChinhHSD()
        {
            CSQLDieuChinhHSD dchsd = new CSQLDieuChinhHSD();
            dchsd.SDCHDid = dchsd.LayDCHSDidTheoSoPDCHD(txtSoPhieu.Text);
            dchsd.SSoPDCHD = txtSoPhieu.Text;
            dchsd.SMaNTid = "F08F270F-DE84-480D-95F9-0B9CC1285F37";
            dchsd.SGhiChu = txtGhiChu.Text;
            dchsd.DLastUD = DateTime.Now;
            dchsd.SUserUD = CStaticBien.SmaTaiKhoan;
            if (ckDuyet.Checked == true)
            {
                dchsd.BDaXetDuyet = true;
            }
            else
            {
                dchsd.BDaXetDuyet = false;
            }
            dchsd.DNgayXetDuyet = DateTime.Now;
            dchsd.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
            dchsd.BHangDacBiet = chkHangDacBiet.Checked;
            int kq = dchsd.Sua(dchsd);
            return kq;
        }
        string MaBPcon;
        private string LayKhoDacBiet(string ntid)
        {
            CSQLKho kho = new CSQLKho();
            DataTable dtb = new DataTable();
            string mabp_ = chht_.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();
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
            if (ntid.ToLower().Equals(ttcn_.ToLower()))
            {
                dtb = kho.LoadKho_TongCongTy_NhapXuat(MaBPcon, true);
            }
            else
            {
                dtb = kho.LoadKho_NhaThuoc_NhapXuat(MaBPcon, true);
            }
            return dtb.Rows[0]["KhoID"].ToString();
        }
        private void rbtnThemMoi_Click(object sender, EventArgs e)
        {
            chkHangDacBiet.Enabled = true;
            _frmMain.MaDieuChinhHSDChiTietCanSua_ = null;
            DCHSDID = null;
            rgvChiTiet.DataSource = null;
            txtSoPhieu.Text = "";
            txtGhiChu.Text = "";
            radMultiColumnComboBoxMaSP.SelectedIndex = -1;
            cboKho.SelectedIndex = -1;
            cboLot.SelectedIndex = -1;
            cboNSX.SelectedIndex = -1;
        }

        private void rbtnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fDieuChinhHSD.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                CSQLDieuChinhHSD dchsd_ = new CSQLDieuChinhHSD();
                CSQLDieuChinhHSDCT dchsdct = new CSQLDieuChinhHSDCT();
                if ((DCHSDID != null && DCHSDID.CompareTo("") > 0))
                {
                    #region chỉnh sửa
                    int kq = -1;
                    kq = SuaDieuChinhHSD();
                    if (kq == 1)
                    {
                        _frmMain.fDieuChinhHSD.rgvPhieuDCHSD.DataSource = dchsd_.LoadDieuChinhHSDLenLuoi(_frmMain.IsXemTatCa_);
                        rgvChiTiet.DataSource = dchsdct.LayTT_DCHSDCT_Theo_DCHSDid(DCHSDID);
                        statusTB.Text = "Sửa chuyển kho thành công!";
                        if (_frmMain.DSDieuChinhHSDXacNhanIsOpen == true)
                        {
                            _frmMain.fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.DataSource = dchsd_.LayDanhSachDieuChinhHSDXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Sửa chuyển kho thất bại.";
                    }
                }
                    #endregion
                else
                {
                    #region thêm mới
                    dchsd_.SGhiChu = txtGhiChu.Text;
                    dchsd_.SMaNTid = "F08F270F-DE84-480D-95F9-0B9CC1285F37";
                    dchsd_.DNgayTao = dtNgayCT.Value;
                    dchsd_.SUserTao = CStaticBien.SmaTaiKhoan;
                    dchsd_.DLastUD = DateTime.Now;
                    dchsd_.SUserUD = CStaticBien.SmaTaiKhoan;

                    if (ckDuyet.Checked == true)
                    {
                        dchsd_.BDaXetDuyet = true;
                        dchsd_.DNgayXetDuyet = DateTime.Now;
                        dchsd_.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
                    }
                    else
                    {
                        dchsd_.BDaXetDuyet = false;
                        dchsd_.DNgayXetDuyet = DateTime.Parse("1/1/1774");
                        dchsd_.SUserXetDuyet = "00000000-0000-0000-0000-000000000000";
                    }

                    dchsd_.BDaXacNhan = false;
                    dchsd_.DNgayXacNhan = DateTime.Parse("1/1/1774"); ;
                    dchsd_.SUserXacNhan = "00000000-0000-0000-0000-000000000000";

                    dchsd_.BIsXoa = false;
                    dchsd_.DNgayXoa = DateTime.Parse("1/1/1774");
                    dchsd_.SUserXoa = "00000000-0000-0000-0000-000000000000";
                    dchsd_.BHangDacBiet = chkHangDacBiet.Checked;
                    string maquantrave = dchsd_.Them(dchsd_);
                    if (maquantrave != null)
                    {
                        txtSoPhieu.Text = maquantrave;
                        DCHSDID = dchsd_.LayDCHSDidTheoSoPDCHD(txtSoPhieu.Text);
                        _frmMain.fDieuChinhHSD.rgvPhieuDCHSD.DataSource = dchsd_.LoadDieuChinhHSDLenLuoi(_frmMain.IsXemTatCa_);
                        statusTB.Text = "Thêm chuyển kho thành công.";
                        if (_frmMain.DSDieuChinhHSDXacNhanIsOpen == true)
                        {
                            _frmMain.fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.DataSource = dchsd_.LayDanhSachDieuChinhHSDXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Thêm chuyển kho thất bại.";
                    }
                    #endregion
                }
            }
            catch { }
        }

        private void rbtnDong_Click(object sender, EventArgs e)
        {
            _frmMain.BangDieuChinhHSD_ = null;
            DCHSDID = "";
            _frmMain.frmDieuChinhHSDEditisOpen_ = false;
            this.Close();
        }
        string khodacbiet;
        private void cboNT_SelectedValueChanged(object sender, EventArgs e)
        {
            CSQLDieuChinhHSD dchsd_ = new CSQLDieuChinhHSD();
            CSQLDieuChinhHSDCT dchsdct = new CSQLDieuChinhHSDCT();
            CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
            string DCHDid = dchsd_.LayDCHSDidTheoSoPDCHD(txtSoPhieu.Text);
            
            LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), "F08F270F-DE84-480D-95F9-0B9CC1285F37");
            
            if (DCHDid != null && DCHDid.Length > 0)
            {
                if ("F08F270F-DE84-480D-95F9-0B9CC1285F37" != null)
                {
                    if ("F08F270F-DE84-480D-95F9-0B9CC1285F37" == ttcn_)
                    {
                        if (chkHangDacBiet.Checked == true)
                            khodacbiet = LayKhoDacBiet("F08F270F-DE84-480D-95F9-0B9CC1285F37");
                        else
                        khodacbiet = sp_kho.LayMaKhoNhapMacDinh_KoSpid();
                        dchsd_.UpdatKhoKhiThayDoiNhaThuoc(DCHDid, khodacbiet);
                    }
                    else
                    {
                        if (chkHangDacBiet.Checked == true)
                            khodacbiet = LayKhoDacBiet("F08F270F-DE84-480D-95F9-0B9CC1285F37");
                        else
                            khodacbiet = sp_kho.LayMaKhoNhapNTMacDinh_KoSpid();
                        dchsd_.UpdatKhoKhiThayDoiNhaThuoc(DCHDid, khodacbiet);
                    }
                    rgvChiTiet.DataSource = dchsdct.LayTT_DCHSDCT_Theo_DCHSDid(DCHDid);

                }
            }

        }

        private void rgvChiTiet_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (rgvChiTiet.CurrentRow.Cells["colDCHDCTid"].Value == null)
            {
                return;
            }
            else
            {
                _frmMain.MaDieuChinhHSDChiTietCanSua_ = rgvChiTiet.CurrentRow.Cells["colDCHDCTid"].Value.ToString();
                CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                string spid = spnsx.SanPham_NSX_LaySPNSXIDTheoSPID_NSXID(rgvChiTiet.CurrentRow.Cells["colSPID"].Value.ToString(), rgvChiTiet.CurrentRow.Cells["colNSXid"].Value.ToString());
                radMultiColumnComboBoxMaSP.SelectedValue = new Guid(spid);
                if (rgvChiTiet.CurrentRow.Cells["colKhoID"].Value.ToString() == "")
                {
                    cboKho.SelectedValue = -1;
                }
                else
                {
                    cboKho.SelectedValue = new Guid(rgvChiTiet.CurrentRow.Cells["colKhoID"].Value.ToString());
                }

                cboLot.Text = rgvChiTiet.CurrentRow.Cells["colLot"].Value.ToString();
                dtHanDungSai.Value = DateTime.Parse(rgvChiTiet.CurrentRow.Cells["colDateSai"].Value.ToString());
                dtHanDungDung.Value = DateTime.Parse(rgvChiTiet.CurrentRow.Cells["colDateDung"].Value.ToString());
                cboLot.Focus();
                //LayThongTinDate(rgvChuyenKhoCT.CurrentRow.Cells["colSPID"].Value.ToString(), cboTuKho.SelectedValue.ToString(), cboLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
            }
        }

        private void radMultiColumnComboBoxMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                RadTextBoxItem rtbi = radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                rtbi.SelectionLength = 0;
                cboLot.Focus();
            }
        }

        private void cboLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dtHanDungSai.Focus();
            }
        }

        private void dtHanDungSai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dtHanDungDung.Focus();
            }
        }

        private void dtHanDungDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAdd.Focus();
            }
        }

        private void rgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (ckDuyet.Checked == false)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Bạn thật sự muốn xóa Sản Phẩm này chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CSQLDieuChinhHSDCT dchsdct_ = new CSQLDieuChinhHSDCT();
                        _frmMain.MaDieuChinhHSDChiTietCanSua_ = rgvChiTiet.CurrentRow.Cells["colDCHDCTid"].Value.ToString();
                        if (dchsdct_.XoaTTDieuChinhHSDCT(_frmMain.MaDieuChinhHSDChiTietCanSua_) > 0)
                        {
                            string DCHSDid_ = rgvChiTiet.CurrentRow.Cells["colDCHDid"].Value.ToString();
                            DataTable dchsdct = dchsdct_.LayTT_DCHSDCT_Theo_DCHSDid(DCHSDid_);
                            if (dchsdct.Rows.Count == 0)
                            { chkHangDacBiet.Enabled = true; }

                            rgvChiTiet.DataSource = dchsdct;
                        }
                        else
                            statusTB.Text = "Xóa thất bại!";
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void txtImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Excel (.xls)|*.xls|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtImport.Text = openFileDialog1.FileName;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (txtImport.Text.Length > 0)
            {
                CSQLNhapKhoChiTiet nhapkhoct_ = new CSQLNhapKhoChiTiet();
                Fr_DangXuLy.ShowFormCho();
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + txtImport.Text + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");

                conn.Open();

                string strQuery = "SELECT * FROM [Sheet1$]";

                System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);

                System.Data.DataSet ds = new System.Data.DataSet();

                adapter.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0 && "F08F270F-DE84-480D-95F9-0B9CC1285F37" != null)
                {
                    CSQLDieuChinhHSD dchsd = new CSQLDieuChinhHSD();
                    if (DCHSDID == null || DCHSDID.Equals("00000000-0000-0000-0000-000000000000"))
                    {                        
						DCHSDID = dchsd.DieuChinhHSD_ThemImport("F08F270F-DE84-480D-95F9-0B9CC1285F37", txtGhiChu.Text, CStaticBien.SmaTaiKhoan, chkHangDacBiet.Checked);
                    }

                    if (DCHSDID != null && DCHSDID.Length > 0)
                    {
                        CSQLDieuChinhHSDCT dctct = new CSQLDieuChinhHSDCT();
                        string ketqua = dctct.ImportMulti(ds.Tables[0], "F08F270F-DE84-480D-95F9-0B9CC1285F37", DCHSDID);
                        if (!ketqua.Equals("OK"))
                        {
                            string Title = "";
                            string Message = "";
                            Fr_DangXuLy.DongFormCho();
                            switch (ketqua.Split('-')[0].ToLower())
                            {
                                case "trunglotrungdateimport":
                                    Title = "Trùng lô Trùng date trong file Import";
                                    Message = "Mã & Lô: " + ketqua.Split('-')[1];
                                    break;
                                case "lokhongtontai":
                                    Title = "Lô import không tồn tại";
                                    Message = "Mã & Lô: " + ketqua.Split('-')[1];
                                    break;
                                case "error":
                                    Title = "Lỗi";
                                    Message = "Mã & Lô: " + ketqua.Split('-')[1];
                                    break;
                                default:
                                    Title = "Lỗi không xác định";
                                    Message = ketqua;
                                    break;
                            }
                            MessageBox.Show(Message, Title);
                        }
                        else
                        {
                            DataTable dt = dchsd.LayDieuChinhHSDTheoMa(DCHSDID);
                            txtSoPhieu.Text = dt.Rows[0]["SoPDCHD"].ToString();
                            dtNgayCT.Value = DateTime.Parse(dt.Rows[0]["NgayTao"].ToString());
                            txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                            ckDuyet.Checked = bool.Parse(dt.Rows[0]["DaXetDuyet"].ToString());

                            rgvChiTiet.DataSource = dctct.LayTT_DCHSDCT_Theo_DCHSDid(DCHSDID);
                            Fr_DangXuLy.DongFormCho();
                        }
                    }
                }
            }
        }

        private void chkHangDacBiet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHangDacBiet.Checked == true && "F08F270F-DE84-480D-95F9-0B9CC1285F37" != null)
            {
                if (radMultiColumnComboBoxMaSP.SelectedValue != null)
                {
                    LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), "F08F270F-DE84-480D-95F9-0B9CC1285F37");
                }
            }
            else if (chkHangDacBiet.Checked == false && "F08F270F-DE84-480D-95F9-0B9CC1285F37" != null)
            {
                if (radMultiColumnComboBoxMaSP.SelectedValue != null)
                {
                    LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), "F08F270F-DE84-480D-95F9-0B9CC1285F37");
                }
            }
        }

        private void ckDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyet.Checked == true)
            {
                ThayDoiTrangThaiControls(false);
            }
            else
            {
                ThayDoiTrangThaiControls(true);
            }
        }

        private void ThayDoiTrangThaiControls(bool trangthai)
        {
            btnDeleteAll.Enabled = txtGhiChu.Enabled = txtImport.Enabled = btnImport.Enabled = btnAdd.Enabled = trangthai;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            CSQLDieuChinhHSDCT dchsdct = new CSQLDieuChinhHSDCT();
            string kq = dchsdct.XoaTatCa(DCHSDID);

            if (!kq.Equals("OK"))
            {
                MessageBox.Show(kq, "Thông báo");
                return;
            }
            else
            {
                rgvChiTiet.DataSource = dchsdct.LayTT_DCHSDCT_Theo_DCHSDid(DCHSDID);
            }
        }

        private void rbtnIn_Click(object sender, EventArgs e)
        {
            CSQLDieuChinhTonCT dctkct_ = new CSQLDieuChinhTonCT();
            if (DCHSDID != null && DCHSDID.Length > 0)
            {
                Fr_DieuChinhHanSuDung check = new Fr_DieuChinhHanSuDung(DCHSDID);
                check.Show();
            }
        }
        
    }
}
