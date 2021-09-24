using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using ECOPharma2013.From_Report;

namespace ECOPharma2013
{
    public partial class frmNhapKhoEdit : Form
    {
        frmMain _frmMain;
        public frmNhapKhoEdit()
        {
            InitializeComponent();
        }
        public frmNhapKhoEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        private void frmNhapKhoEdit_Load(object sender, EventArgs e)
        {
            LayDSMaSP_TenSPLenMultiColumnCombobox();
            LayKhoVaoCombobox();
            LayNhaThuocVaoCombobox();

            KiemTraDanhSachChiTietKho(_frmMain.MaNhapKhoCanSua_);

            if (_frmMain.BangNhapKhoCanSua_ != null && _frmMain.BangNhapKhoCanSua_.Rows.Count > 0)
            {
                #region Kiểm Tra Nhóm người dùng
                CSQLUser aUser = new CSQLUser();
                Guid NhomNguoiDung_Tao = aUser.LayThongTinNhomND(_frmMain.BangNhapKhoCanSua_.Rows[0]["UserNhap"].ToString());
                Guid NhomNguoiDung_Mo = new Guid(CStaticBien.sNhomTaiKhoan);

                if (!NhomNguoiDung_Mo.Equals(NhomNguoiDung_Tao))
                {
                    txtSoSeri.Enabled = txtSoChungTu.Enabled = dtNgayChungTu.Enabled = radMultiColumnComboBoxNCC.Enabled = cboNhaThuoc.Enabled = txtGhiChu.Enabled = false;
                    radMultiColumnComboBoxMaSP.Enabled = radMultiColumnComboBoxTenSP.Enabled = cboKho.Enabled = txtSLMua.Enabled = txtSLFree.Enabled = cboDVT.Enabled = txtSoLo.Enabled = dtHanDung.Enabled = cboNSX.Enabled = false;
                    //ckDaNhapXong.Enabled = 
                }
                #endregion

                CSQLNhapKhoChiTiet nhapkhoct_ = new CSQLNhapKhoChiTiet();
                txtSoSeri.Text = _frmMain.BangNhapKhoCanSua_.Rows[0]["SoSeriCT"].ToString();
                txtSoChungTu.Text = _frmMain.BangNhapKhoCanSua_.Rows[0]["SoCTN"].ToString();
                if (_frmMain.BangNhapKhoCanSua_.Rows[0]["NgayCTN"].ToString().Length > 0)
                    dtNgayChungTu.Value = (DateTime)_frmMain.BangNhapKhoCanSua_.Rows[0]["NgayCTN"];
                else
                    dtNgayChungTu.Value = DateTime.Now;
                ckDaNhapXong.Checked = (bool)_frmMain.BangNhapKhoCanSua_.Rows[0]["NhapXong"];
                txtGhiChu.Text = _frmMain.BangNhapKhoCanSua_.Rows[0]["GhiChu"].ToString();
                radMultiColumnComboBoxNCC.SelectedValue = new Guid(_frmMain.BangNhapKhoCanSua_.Rows[0]["NPPID"].ToString());
                cboNhaThuoc.SelectedValue = _frmMain.BangNhapKhoCanSua_.Rows[0]["XuatChoNT"].ToString();

                if (nhapkhoct_.LayNhapKhoChiTietTheoPN(_frmMain.MaNhapKhoCanSua_).Rows.Count > 0)
                {
                    rgvChiTietPhieuNhap.CellFormatting += new CellFormattingEventHandler(rgvChiTietPhieuNhap_CellFormatting);
                    rgvChiTietPhieuNhap.DataSource = nhapkhoct_.LayDanhSachNhapKhoChiTietLenLuoi(_frmMain.MaNhapKhoCanSua_);
                    this.rgvChiTietPhieuNhap.MasterTemplate.ShowTotals = true;
                    GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                    summaryItem.Name = "colTTGiaMuaDaChietKhauCoTAX";
                    summaryItem.Aggregate = GridAggregateFunction.Sum;
                    summaryItem.FormatString = "{0:N4}";
                    GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                    summaryRowItem.Add(summaryItem);

                    GridViewSummaryItem summaryChuaTaxDaChietKhau = new GridViewSummaryItem();
                    summaryChuaTaxDaChietKhau.Name = "colTTGiaMuaChuaTaxDaChietKhau";
                    summaryChuaTaxDaChietKhau.Aggregate = GridAggregateFunction.Sum;
                    summaryChuaTaxDaChietKhau.FormatString = "{0:N4}";
                    summaryRowItem.Add(summaryChuaTaxDaChietKhau);

                    this.rgvChiTietPhieuNhap.SummaryRowsTop.Add(summaryRowItem);
                    this.rgvChiTietPhieuNhap.SummaryRowsBottom.Add(summaryRowItem);
                }
            }
            if (_frmMain.IsSuaNhapKho_ == true && _frmMain.XNnhapkho == false)
            {
                btnAdd.Enabled = false;
                btnNhapKhoThemMoi.Enabled = false;
                btnNhapKhoLuu.Enabled = false;
            }
            if (_frmMain.IsSuaNhapKho_ == true && _frmMain.XNnhapkho == true)
            {
                btnAdd.Enabled = false;
                btnNhapKhoThemMoi.Enabled = false;
                btnNhapKhoLuu.Enabled = false;
                ckDaNhapXong.Enabled = false;
            }
            rgvChiTietPhieuNhap.CellFormatting += new CellFormattingEventHandler(rgvChiTietPhieuNhap_CellFormatting);
            //MultiColumnComboBox_MaSP.SelectedValue = "";
            //cboKho.SelectedValue = "";
            //cboDVT.SelectedValue = "";
            //cboNSX.SelectedValue = "";
        }

        void rgvChiTietPhieuNhap_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "colSTT" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void btnNhapKhoThemMoi_Click(object sender, EventArgs e)
        {
            _frmMain.MaNhapKhoCanSua_ = "00000000-0000-0000-0000-000000000000";
            _frmMain.kiemtraphieunhapkho = true;
            themmoipn_ = true;
            rgvChiTietPhieuNhap.DataSource = null;
            txtSoSeri.Text = "";
            txtSoChungTu.Text = "";
            ckDaNhapXong.Checked = false;
            txtGhiChu.Text = "";
            radMultiColumnComboBoxMaSP.SelectedIndex = -1;
            radMultiColumnComboBoxTenSP.SelectedIndex = -1;
            txtSLMua.Text = "";
            txtSLFree.Text = "0";
            txtTongSL.Text = "";
            txtSoLo.Text = "";
            LayKhoVaoCombobox();
            radMultiColumnComboBoxNCC.SelectedIndex = -1;
            LayNhaThuocVaoCombobox();
            txtSoSeri.Focus();
        }
        bool themmoipn_ = true;
        bool KT_Trung;
        private void btnNhapKhoLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNhapKho.Name) == false)
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

            try
            {
                if (txtSoSeri.Text.Length > 12)
                {
                    toolStripStatusThongBaoLoi.Text = "Số Seri không được nhiều hơn 12 ký tự!";
                    return;
                }
                else toolStripStatusThongBaoLoi.Text = "";

                if (txtSoChungTu.Text.Length == 0)
                {
                    toolStripStatusThongBaoLoi.Text = "Bạn phải nhập thông tin số chứng từ nhập!";
                    return;
                }
                else toolStripStatusThongBaoLoi.Text = "";

                if (radMultiColumnComboBoxNCC.SelectedValue == null)
                {
                    toolStripStatusThongBaoLoi.Text = "Bạn phải chọn nhà cung cấp!";
                    return;
                }
                else toolStripStatusThongBaoLoi.Text = "";
                txtSoChungTu_Leave(sender, e);
                if (KT_Trung == false)
                {
                    //if ((this._frmMain.MaNhapKhoCanSua_ != null && this._frmMain.MaNhapKhoCanSua_.CompareTo("") > 0) || themmoipn_ == false)
                    if ((this._frmMain.MaNhapKhoCanSua_ != null && this._frmMain.MaNhapKhoCanSua_.CompareTo("") > 0))
                    {
                        #region chỉnh sửa
                        CXuLyChuoi xlc = new CXuLyChuoi();
                        CSQLNhapKho nhapkho = new CSQLNhapKho();
                        //if (this._frmMain.MaNhapKhoCanSua_ != null && this._frmMain.MaNhapKhoCanSua_.CompareTo("") > 0)
                        //{
                        nhapkho.SMaPN = this._frmMain.MaNhapKhoCanSua_;
                        //}
                        //else if (themmoipn_ == false)
                        //{
                        //    nhapkho.SMaPN = nhapkho.LayNhapKhoTheoSoCTN(txtSoChungTu.Text).Rows[0]["PNid"].ToString();
                        //}
                        nhapkho.SSoSeri = xlc.TrimTen(txtSoSeri.Text);
                        nhapkho.SSoCTN = xlc.TrimTen(txtSoChungTu.Text);
                        nhapkho.DNgayCTN = dtNgayChungTu.Value;
                        nhapkho.SNPPid = radMultiColumnComboBoxNCC.SelectedValue.ToString();
                        if (cboNhaThuoc.SelectedValue == null)
                        {
                            nhapkho.BDirect = false;
                            nhapkho.SXuatChoNT = "00000000-0000-0000-0000-000000000000";
                        }
                        else
                        {
                            nhapkho.BDirect = true;
                            nhapkho.SXuatChoNT = cboNhaThuoc.SelectedValue.ToString();
                        }
                        nhapkho.BNhapXong = ckDaNhapXong.Checked;
                        nhapkho.SGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
                        nhapkho.DLastUD = DateTime.Now;
                        nhapkho.SUserNhap = CStaticBien.SmaTaiKhoan;
                        nhapkho.SIsKhoDacBiet = cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet();

                        int kq = nhapkho.SuaThongTinNhapKho(nhapkho);
                        if (kq == 1)
                        {
                            _frmMain.fNhapKho.rgvDSPhieuNhap.DataSource = nhapkho.LayDanhSachNhapKhoLenLuoi(_frmMain.IsXemTatCa_);
                            if (_frmMain.DSNhapKhoXacNhanIsOpen == true)
                            {
                                _frmMain.fNhapKhoXacNhan.rgvDSPhieuNhapXacNhan.DataSource = nhapkho.LayDanhSachNhapKhoXacNhanLenLuoi(true, false);
                            }
                            toolStripStatusThongBaoLoi.Text = "Sửa thông tin thành công!";
                        }
                        else
                        {
                            toolStripStatusThongBaoLoi.Text = "Sửa thông tin thất bại.";
                        }
                        #endregion
                    }
                    else if (themmoipn_ == true)
                    {
                        #region thêm mới
                        CXuLyChuoi xlc = new CXuLyChuoi();
                        CSQLNhapKho nhapkho = new CSQLNhapKho();
                        nhapkho.SSoSeri = xlc.TrimTen(txtSoSeri.Text);
                        nhapkho.SSoCTN = xlc.TrimTen(txtSoChungTu.Text);
                        nhapkho.DNgayCTN = dtNgayChungTu.Value;
                        nhapkho.SNPPid = radMultiColumnComboBoxNCC.SelectedValue.ToString();
                        if (cboNhaThuoc.SelectedValue == null)
                        {
                            nhapkho.BDirect = false;
                            nhapkho.SXuatChoNT = "00000000-0000-0000-0000-000000000000";
                        }
                        else
                        {
                            nhapkho.BDirect = true;
                            nhapkho.SXuatChoNT = cboNhaThuoc.SelectedValue.ToString();
                        }
                        nhapkho.BNhapXong = ckDaNhapXong.Checked;
                        nhapkho.SGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
                        nhapkho.DLastUD = DateTime.Now;
                        nhapkho.DNgayTao = DateTime.Now;
                        nhapkho.SUserNhap = CStaticBien.SmaTaiKhoan;
                        nhapkho.SIsKhoDacBiet = cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet();

                        string maquantrave = nhapkho.ThemMoiNhapKho(nhapkho);
                        if (maquantrave != null)
                        {
                            _frmMain.MaNhapKhoCanSua_ = maquantrave;
                            _frmMain.fNhapKho.rgvDSPhieuNhap.DataSource = nhapkho.LayDanhSachNhapKhoLenLuoi(_frmMain.IsXemTatCa_);
                            if (nhapkho.LayDanhSachNhapKhoXacNhanLenLuoi(true, false).Rows.Count > 0)
                            {
                                _frmMain.fNhapKhoXacNhan.rgvDSPhieuNhapXacNhan.DataSource = nhapkho.LayDanhSachNhapKhoXacNhanLenLuoi(true, false);
                            }
                            toolStripStatusThongBaoLoi.Text = "Thêm thông tin thành công.";
                            themmoipn_ = false;
                            _frmMain.kiemtraphieunhapkho = false;
                        }
                        else
                        {
                            toolStripStatusThongBaoLoi.Text = "Thêm thông tin thất bại.";
                        }
                        #endregion
                    }
                }
            }
            catch { }
        }
        private void btnNhapKhoDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmNhapKhoEditisOpen_ = false;
            btnAdd.Enabled = true;
            btnNhapKhoThemMoi.Enabled = true;
            btnNhapKhoLuu.Enabled = true;
            ckDaNhapXong.Enabled = true;
            _frmMain.IsSuaNhapKho_ = false;
            this.Close();
        }
        string MaBPcon;
        void LayKhoVaoCombobox()
        {
            CSQLKho kho = new CSQLKho();
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            string mabp_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();
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
            cboKho.DataSource = kho.LayKhoLenCBO_TongCongTy(MaBPcon);
            cboKho.DisplayMember = "TenKho";
            cboKho.ValueMember = "KhoID";
            cboKho.SelectedIndex = -1;
        }
        void LayDVTVaoCombobox(string spid)
        {
            CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
            //cboDVT.DataSource = dvt.LoadDSDVTLenLuoi(_frmMain.IsXemTatCa_);
            cboDVT.DataSource = hsqd.LayHSQDTheoSPID(spid);
            cboDVT.DisplayMember = "TentuDVT";
            cboDVT.ValueMember = "tuDVTID";
            cboDVT.SelectedIndex = -1;
            CSQLSanPham sp = new CSQLSanPham();
            DataTable dtb = sp.SanPham_LayDVNhap_DVXuat_DVBan_DVChuan_TheoSPID(spid);
            try
            {
                cboDVT.SelectedValue = dtb.Rows[0]["DVNhap"].ToString();
                toolStripStatusThongBaoLoi.Text = "";
            }
            catch
            {
                toolStripStatusThongBaoLoi.Text = "Không lấy được đơn vị nhập!";
                return;
            }
        }
        void LayNhaThuocVaoCombobox()
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            cboNhaThuoc.DataSource = nhathuoc.LayDanhSachNhaThuocLenLuoi(_frmMain.IsXemTatCa_);
            cboNhaThuoc.DisplayMember = "TenNT";
            cboNhaThuoc.ValueMember = "NTID";
            cboNhaThuoc.SelectedIndex = -1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNhapKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNhapKhoChiTiet nhapkhoct_ = new CSQLNhapKhoChiTiet();
            CSQLSanPham sanpham_ = new CSQLSanPham();
            CSQLNhapKho nhapkho_ = new CSQLNhapKho();
            CSQLHeSoQuyDoi hsqd_ = new CSQLHeSoQuyDoi();

            //Kiểm tra đầu vào từ form
            #region kiểm tra input
            if (txtSoChungTu.Text.Length == 0)
            {
                toolStripStatusThongBaoLoi.Text = "Bạn phải nhập thông tin số chứng từ nhập!";
                txtSoChungTu.Focus();
                return;
            }
            else toolStripStatusThongBaoLoi.Text = "";

            if (radMultiColumnComboBoxNCC.SelectedValue == null)
            {
                toolStripStatusThongBaoLoi.Text = "Bạn phải chọn nhà cung cấp!";
                radMultiColumnComboBoxNCC.Focus();
                return;
            }
            else toolStripStatusThongBaoLoi.Text = "";

            if (radMultiColumnComboBoxMaSP.SelectedValue == null)
            {
                toolStripStatusThongBaoLoi.Text = "Bạn phải chọn sản phẩm!";
                radMultiColumnComboBoxTenSP.Focus();
                return;
            }
            else toolStripStatusThongBaoLoi.Text = "";

            if (cboKho.SelectedValue == null)
            {
                toolStripStatusThongBaoLoi.Text = "Bạn chưa chọn kho nhập cho sản phẩm!";
                cboKho.Focus();
                return;
            }
            else toolStripStatusThongBaoLoi.Text = "";

            if (txtSLMua.Text.Length == 0)
            {
                toolStripStatusThongBaoLoi.Text = "Bạn chưa nhập số lượng mua!";
                txtSLMua.Focus();
                return;
            }
            else toolStripStatusThongBaoLoi.Text = "";

            if (txtSoLo.Text.Length > 0)
            {
                nhapkhoct_.SLot = txtSoLo.Text;
                toolStripStatusThongBaoLoi.Text = "";
            }
            else
            {
                toolStripStatusThongBaoLoi.Text = "Bạn chưa nhập số lô!";
                txtSoLo.Focus();
                return;
            }
            CSQLKho kho = new CSQLKho();
            if (kho.KiemTraNhomKho(cboKho.SelectedValue.ToString()) != 2)
            {//Kiểm tra kho thường
                if (dtHanDung.Value > DateTime.Now)
                {
                    nhapkhoct_.DDate = dtHanDung.Value;
                    toolStripStatusThongBaoLoi.Text = "";
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Hạn dùng phải lớn hơn ngày hiện tại!";
                    dtHanDung.Focus();
                    return;
                }
            }
            else
            {
                nhapkhoct_.DDate = dtHanDung.Value;
                toolStripStatusThongBaoLoi.Text = "";
            }

            if (cboNSX.SelectedValue != null)
            {
                nhapkhoct_.SMaNSX = cboNSX.SelectedValue.ToString();
                toolStripStatusThongBaoLoi.Text = "";
            }
            else
            {
                toolStripStatusThongBaoLoi.Text = "Bạn chưa chọn nhà sản xuất hoặc nhà sản xuất chưa được xác định!";
                cboNSX.Focus();
                return;
            }
            #endregion Kiem tra Input

            //Kiểm tra tồn tại trong sản phẩm kho hay chua
            CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
            if (sp_kho.SP_Kho_KiemTraTonTaiSP(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString()) == 0)
            {
                if (MessageBox.Show(this, "Sản phẩm này chưa thiết lập sản phẩm - kho. \n Liên hệ phòng IDP để bổ sung thiết lập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    return;
                }
            }
            
            // Kiểm tra phiếu nhập kho có tạo chưa, nếu chưa thì tạo mới
            #region
            if (_frmMain.kiemtraphieunhapkho == true)
            {
                CXuLyChuoi xlc = new CXuLyChuoi();
                nhapkho_.SSoSeri = xlc.TrimTen(txtSoSeri.Text);
                nhapkho_.SSoCTN = xlc.TrimTen(txtSoChungTu.Text);
                nhapkho_.DNgayCTN = dtNgayChungTu.Value;
                nhapkho_.SNPPid = radMultiColumnComboBoxNCC.SelectedValue.ToString();
                if (cboNhaThuoc.SelectedValue == null)
                {
                    nhapkho_.BDirect = false;
                    nhapkho_.SXuatChoNT = "00000000-0000-0000-0000-000000000000";
                }
                else
                {
                    nhapkho_.BDirect = true;
                    nhapkho_.SXuatChoNT = cboNhaThuoc.SelectedValue.ToString();
                }
                nhapkho_.BNhapXong = ckDaNhapXong.Checked;
                nhapkho_.SGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
                nhapkho_.DLastUD = DateTime.Now;
                nhapkho_.DNgayTao = DateTime.Now;
                nhapkho_.SUserNhap = CStaticBien.SmaTaiKhoan;
                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                nhapkho_.SIsKhoDacBiet = cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet();

                string maquantrave = nhapkho_.ThemMoiNhapKho(nhapkho_);
                if (maquantrave != null)
                {
                    this._frmMain.MaNhapKhoCanSua_ = maquantrave;
                    this._frmMain.fNhapKho.rgvDSPhieuNhap.DataSource = nhapkho_.LayDanhSachNhapKhoLenLuoi(_frmMain.IsXemTatCa_);
                    _frmMain.kiemtraphieunhapkho = false;
                    themmoipn_ = false;
                }
            }
            #endregion

            //Add sản phẩm vào bảng nhập kho chi tiết

            if ((new CSQLNhapKho()).IsXacNhan(_frmMain.MaNhapKhoCanSua_))
            {
                MessageBox.Show("Phiếu nhập này đã Xác nhận, vui lòng kiểm tra lại");
                return;
            }

            //Sửa Bảng Nhập Kho Chi Tiết
            if (this._frmMain.MaNhapKhoChiTietCanSua_ != null && this._frmMain.MaNhapKhoChiTietCanSua_.CompareTo("") > 0)
            {
                int kq = nhapkhoct_.XoaThongTinNhapKhoChiTiet(_frmMain.MaNhapKhoChiTietCanSua_, CStaticBien.SmaTaiKhoan);
            }

            //nhapkhoct_.SPNid = nhapkho_.LayNhapKhoTheoSoCTN(txtSoChungTu.Text).Rows[0]["PNid"].ToString();
            nhapkhoct_.SPNid = _frmMain.MaNhapKhoCanSua_;
            //nhapkhoct_.SSPid = sanpham_.LaySanPhamTheoMaSP(radMultiColumnComboBoxMaSP.SelectedValue.ToString()).Rows[0]["SPID"].ToString();
            //nhapkhoct_.SNSPid = sanpham_.LaySanPhamTheoMaSP(radMultiColumnComboBoxMaSP.SelectedValue.ToString()).Rows[0]["NhomID"].ToString();
            DataTable dtbsp = sanpham_.LaySanPhamTheoSPID(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
            nhapkhoct_.SSPid = dtbsp.Rows[0]["SPID"].ToString();
            nhapkhoct_.SNSPid = dtbsp.Rows[0]["NhomID"].ToString();
            nhapkhoct_.SMaKho = cboKho.SelectedValue.ToString();

            //Kiểm tra đơn vị tính có trùng đơn vị chuẩn của sản phẩm hay không.
            #region
            DataTable dtbthongtinsanpham = sanpham_.LaySanPhamTheoSPID(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
            //            DataTable dtbthongtinsanpham = sanpham_.LaySanPhamTheoMaSP(radMultiColumnComboBoxMaSP.SelectedValue.ToString());
            if (cboDVT.SelectedValue.ToString() == dtbthongtinsanpham.Rows[0]["DVChuan"].ToString())
            {
                nhapkhoct_.FSLMua = decimal.Parse(txtSLMua.Text);
                nhapkhoct_.FSLFree = decimal.Parse(txtSLFree.Text);
                nhapkhoct_.FTongSL = decimal.Parse(txtTongSL.Text);
                nhapkhoct_.SDVT = cboDVT.SelectedValue.ToString();
                //nhapkhoct_.FGiaMuaChuaTAX = decimal.Parse(dtbthongtinsanpham.Rows[0]["GiaMuaChuaTaxHT"].ToString());
                //nhapkhoct_.FTTGiaMuaChuaTAX = decimal.Parse(dtbthongtinsanpham.Rows[0]["GiaMuaChuaTaxHT"].ToString()) * nhapkhoct_.FSLMua;
                //nhapkhoct_.FTAX = decimal.Parse(dtbthongtinsanpham.Rows[0]["TaxHT"].ToString());
                //nhapkhoct_.FTTTAX = (nhapkhoct_.FTTGiaMuaChuaTAX * nhapkhoct_.FTAX) / 100;
                //nhapkhoct_.FTTGiaMuaCoTAX = nhapkhoct_.FTTGiaMuaChuaTAX + nhapkhoct_.FTTTAX;
            }
            else
            {
                //decimal tylequidoi = hsqd_.TinhTyLeHSQD_Thuan(nhapkhoct_.SSPid, cboDVT.SelectedValue.ToString());
                //DataTable dtbThongtinsp1 = sanpham_.LaySanPhamTheoSPID(radMultiColumnComboBoxMaSP.SelectedValue.ToString());
                //                DataTable dtbThongtinsp1 = sanpham_.LaySanPhamTheoMaSP(radMultiColumnComboBoxMaSP.SelectedValue.ToString());
                //if (tylequidoi > 0)
                //{
                nhapkhoct_.FSLMua = decimal.Parse(txtSLMua.Text);
                nhapkhoct_.FSLFree = decimal.Parse(txtSLFree.Text);
                nhapkhoct_.FTongSL = decimal.Parse(txtTongSL.Text);
                nhapkhoct_.SDVT = cboDVT.SelectedValue.ToString();
                //decimal SLMuaQuyDoi = decimal.Parse(txtSLMua.Text) * tylequidoi;
                //nhapkhoct_.FGiaMuaChuaTAX = decimal.Parse(dtbThongtinsp1.Rows[0]["GiaMuaChuaTaxHT"].ToString());
                //nhapkhoct_.FTTGiaMuaChuaTAX = decimal.Parse(dtbThongtinsp1.Rows[0]["GiaMuaChuaTaxHT"].ToString()) * SLMuaQuyDoi;
                //nhapkhoct_.FTAX = decimal.Parse(dtbThongtinsp1.Rows[0]["TaxHT"].ToString());
                //nhapkhoct_.FTTTAX = (nhapkhoct_.FTTGiaMuaChuaTAX * nhapkhoct_.FTAX) / 100;
                //nhapkhoct_.FTTGiaMuaCoTAX = nhapkhoct_.FTTGiaMuaChuaTAX + nhapkhoct_.FTTTAX;
                //}
                //else
                //{
                //    MessageBox.Show("Chưa Tạo Hệ Số Quy Đổi Cho Đơn Vị Tính Này");
                //    return;
                //}
            }
            #endregion

            try
            {
                if (rgvChiTietPhieuNhap.RowCount > 0 && rgvChiTietPhieuNhap.CurrentRow.Cells["GhiChu"].Value.ToString().Length > 0)
                    nhapkhoct_.SGhiChu = rgvChiTietPhieuNhap.CurrentRow.Cells["GhiChu"].Value.ToString();
                else
                    nhapkhoct_.SGhiChu = "";
            }

            catch { nhapkhoct_.SGhiChu = ""; }

            nhapkhoct_.SUserNhap = CStaticBien.SmaTaiKhoan;
            //Kiểm tra trùng lô, khác date
            if (nhapkhoct_.KiemTraTrungLoKhacDate(nhapkhoct_.SSPid, nhapkhoct_.SLot, nhapkhoct_.DDate, nhapkhoct_.SMaNSX) == 0)
            {
                toolStripStatusThongBaoLoi.Text = "Sản phẩm bạn nhập trùng lô nhưng khác date, kiểm tra lại!";
                return;
            }

            string manhapkho = nhapkhoct_.ThemMoiNhapKhoChiTiet(nhapkhoct_);
            if (manhapkho != null)
            {
                rgvChiTietPhieuNhap.DataSource = nhapkhoct_.LayDanhSachNhapKhoChiTietLenLuoi(nhapkhoct_.SPNid);
                this.rgvChiTietPhieuNhap.MasterTemplate.ShowTotals = true;
                GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                summaryItem.Name = "colTTGiaMuaDaChietKhauCoTAX";
                summaryItem.Aggregate = GridAggregateFunction.Sum;
                summaryItem.FormatString = "{0:N4}";
                GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                summaryRowItem.Add(summaryItem);


                GridViewSummaryItem summaryChuaTaxDaChietKhau = new GridViewSummaryItem();
                summaryChuaTaxDaChietKhau.Name = "colTTGiaMuaChuaTaxDaChietKhau";
                summaryChuaTaxDaChietKhau.Aggregate = GridAggregateFunction.Sum;
                summaryChuaTaxDaChietKhau.FormatString = "{0:N4}";
                summaryRowItem.Add(summaryChuaTaxDaChietKhau);

                if (this._frmMain.MaNhapKhoChiTietCanSua_ != null && this._frmMain.MaNhapKhoChiTietCanSua_.CompareTo("") > 0)
                {
                    toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                }
                radMultiColumnComboBoxMaSP.SelectedIndex = -1;
                radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                txtSLMua.Text = "";
                txtSLFree.Text = "0";
                txtTongSL.Text = "";
                txtSoLo.Text = "";
                cboKho.SelectedIndex = -1;
                cboNSX.SelectedIndex = -1;
                _frmMain.MaNhapKhoChiTietCanSua_ = null;
                dtHanDung.Value = DateTime.Now;
                cboDVT.SelectedIndex = -1;
                radMultiColumnComboBoxTenSP.Focus();
            }
            else
            {
                toolStripStatusThongBaoLoi.Text = "Thêm thất bại.";
            }
            rgvChiTietPhieuNhap.CurrentRow = rgvChiTietPhieuNhap.Rows[rgvChiTietPhieuNhap.Rows.Count - 1];
            radMultiColumnComboBoxTenSP.Focus();

            KiemTraDanhSachChiTietKho(_frmMain.MaNhapKhoCanSua_);
        }

        private void KiemTraDanhSachChiTietKho(string PNid)
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            CSQLNhapKhoChiTiet aNhapKhoChiTiet = new CSQLNhapKhoChiTiet();

            if (!string.IsNullOrEmpty(PNid)) { 
                if (aNhapKhoChiTiet.LayNhapKhoChiTietTheoPN(_frmMain.MaNhapKhoCanSua_).Rows.Count > 0)
                {
                    Boolean IsHangDacBiet = aNhapKhoChiTiet.KiemTraDanhSachChiTiet(PNid);
                    cbkHangDacBiet.Enabled = false;

                    if (IsHangDacBiet)
                    {
                        cbkHangDacBiet.Checked = true;


                        if (cbkHangDacBiet.Checked && !chht.KiemTraTrangThaiXemKhoDacBiet())
                        {
                            MessageBox.Show("Vui lòng làm mới lại danh sách Nhập kho");
                            _frmMain.frmNhapKhoEditisOpen_ = false;
                            _frmMain.fNhapKho.rgvDSPhieuNhap_LoadLenLuoi();
                            this.Close();
                        }
                    }
                }
                else {
                    cbkHangDacBiet.Enabled = true;
                }

                CSQLKho kho = new CSQLKho();
                string mabp_ = chht.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();
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

                if (cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet())
                {
                    cboKho.DataSource = kho.LayKhoDacBiet_TongCongTy(MaBPcon);
                }
                else
                {
                    cboKho.DataSource = kho.LayKhoLenCBO_TongCongTy(MaBPcon);
                }
            }

            cbkHangDacBiet.Visible = chht.KiemTraTrangThaiXemKhoDacBiet();
        }

        private void txtSLMua_TextChanged(object sender, EventArgs e)
        {
            if (txtSLMua.Text != "")
            {
                txtTongSL.Text = (decimal.Parse(txtSLMua.Text) + decimal.Parse(txtSLFree.Text)).ToString();
            }
        }
        private void txtSLFree_TextChanged(object sender, EventArgs e)
        {
            if (txtSLMua.Text != "")
            {
                txtTongSL.Text = (decimal.Parse(txtSLMua.Text) + decimal.Parse(txtSLFree.Text)).ToString();
            }
        }

        private void ckDaNhapXong_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDaNhapXong.Checked == false && _frmMain.IsSuaNhapKho_ == true)
            {
                _frmMain.IsSuaNhapKho_ = false;
                btnAdd.Enabled = true;
                btnNhapKhoLuu.Enabled = true;
                btnNhapKhoThemMoi.Enabled = true;
            }
        }

        private void txtSLMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSLFree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rgvChiTietPhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            CSQLNhapKho nk  = new CSQLNhapKho();
            if (ckDaNhapXong.Checked == false && !nk.IsXacNhan(_frmMain.MaNhapKhoCanSua_))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    #region Kiểm Tra Nhóm người dùng và người dùng
                    CSQLUser aUser = new CSQLUser();
                    Guid NhomNguoiDung_Tao = aUser.LayThongTinNhomND(_frmMain.BangNhapKhoCanSua_.Rows[0]["UserNhap"].ToString());
                    Guid NhomNguoiDung_Mo = new Guid(CStaticBien.sNhomTaiKhoan);

                    if (!NhomNguoiDung_Mo.Equals(NhomNguoiDung_Tao))
                    {
                        return;
                    }
                    else if (!_frmMain.BangNhapKhoCanSua_.Rows[0]["UserNhap"].ToString().ToLower().Equals(CStaticBien.SmaTaiKhoan.ToLower()))
                    {
                        return;
                    }
                    #endregion

                    if (MessageBox.Show("Bạn thật sự muốn xóa Sản Phẩm này chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CSQLNhapKhoChiTiet nhapkhoct_ = new CSQLNhapKhoChiTiet();
                        _frmMain.MaNhapKhoChiTietCanSua_ = rgvChiTietPhieuNhap.CurrentRow.Cells["colPNCTid"].Value.ToString();
                        int kq = nhapkhoct_.XoaThongTinNhapKhoChiTiet(_frmMain.MaNhapKhoChiTietCanSua_, CStaticBien.SmaTaiKhoan);
                        string PhieuNhap_ = rgvChiTietPhieuNhap.CurrentRow.Cells["colPNid"].Value.ToString();
                        rgvChiTietPhieuNhap.DataSource = nhapkhoct_.LayDanhSachNhapKhoChiTietLenLuoi(PhieuNhap_);
                    }
                    else
                    {
                        return;
                    }

                    KiemTraDanhSachChiTietKho(_frmMain.MaNhapKhoCanSua_);
                }
            }
        }

        #region lấy sản phẩm lên multicolumncombo
        private void LayDSMaSP_TenSPLenMultiColumnCombobox()
        {
            try
            {
                CSQLSanPham sp = new CSQLSanPham();
                CSQLNhanVien nv = new CSQLNhanVien();
                CSQLNPP npp = new CSQLNPP();
                radMultiColumnComboBoxMaSP.DisplayMember = "MaSP";
                radMultiColumnComboBoxMaSP.ValueMember = "SPNSXID";
                radMultiColumnComboBoxTenSP.DisplayMember = "TenSP";
                radMultiColumnComboBoxTenSP.ValueMember = "SPNSXID";
                radMultiColumnComboBoxNCC.DisplayMember = "TenNPP";
                radMultiColumnComboBoxNCC.ValueMember = "NPPID";

                radMultiColumnComboBoxMaSP.DataSource = sp.SanPham_NSX_LayDSSPLenMultiColumnCombobox();
                radMultiColumnComboBoxTenSP.DataSource = sp.SanPham_NSX_LayDSSPLenMultiColumnCombobox();
                radMultiColumnComboBoxNCC.DataSource = npp.LoadDSNPPLenMComboBox();

                radMultiColumnComboBoxMaSP.SelectedIndex = -1;
                radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                radMultiColumnComboBoxNCC.SelectedIndex = -1;

                radMultiColumnComboBoxMaSP.EditorControl.Columns["SPID"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                //radMultiColumnComboBoxMaSP.EditorControl.Columns["MaSP"].BestFit();
                //radMultiColumnComboBoxMaSP.EditorControl.Columns["TenSP"].BestFit();
                //radMultiColumnComboBoxMaSP.EditorControl.Columns["TenNSX"].BestFit();
                radMultiColumnComboBoxMaSP.EditorControl.Columns["MaSP"].Width = 65;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["TenSP"].Width = 250;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["TenNSX"].Width = 150;
                radMultiColumnComboBoxMaSP.AutoFilter = true;
                FilterDescriptor descriptor = new FilterDescriptor(this.radMultiColumnComboBoxMaSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
                radMultiColumnComboBoxMaSP.EditorControl.FilterDescriptors.Add(descriptor);
                radMultiColumnComboBoxMaSP.DropDownStyle = RadDropDownStyle.DropDown;
                radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownWidth = 500;
                radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;

                radMultiColumnComboBoxTenSP.EditorControl.Columns["NSXID"].IsVisible = false;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["SPID"].IsVisible = false;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["MaSP"].BestFit();
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["TenSP"].BestFit();
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["TenNSX"].BestFit();
                radMultiColumnComboBoxTenSP.EditorControl.Columns["MaSP"].Width = 65;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["TenSP"].Width = 250;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["TenNSX"].Width = 150;
                radMultiColumnComboBoxTenSP.AutoFilter = true;
                FilterDescriptor descriptor1 = new FilterDescriptor(this.radMultiColumnComboBoxTenSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
                radMultiColumnComboBoxTenSP.EditorControl.FilterDescriptors.Add(descriptor1);
                radMultiColumnComboBoxTenSP.DropDownStyle = RadDropDownStyle.DropDown;
                radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownWidth = 500;
                radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;

                radMultiColumnComboBoxNCC.EditorControl.Columns["NPPID"].IsVisible = false;
                radMultiColumnComboBoxNCC.EditorControl.Columns["TenNPP"].Width = 320;

                radMultiColumnComboBoxNCC.AutoFilter = true;
                radMultiColumnComboBoxNCC.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.Suggest;
                FilterDescriptor descriptor12 = new FilterDescriptor(radMultiColumnComboBoxNCC.DisplayMember, FilterOperator.Contains, string.Empty);

                radMultiColumnComboBoxNCC.EditorControl.MasterTemplate.FilterDescriptors.Add(descriptor12);
                radMultiColumnComboBoxNCC.DropDownStyle = RadDropDownStyle.DropDown;

                radMultiColumnComboBoxNCC.MultiColumnComboBoxElement.DropDownWidth = 350;
                radMultiColumnComboBoxNCC.MultiColumnComboBoxElement.DropDownHeight = 300;
            }
            catch (Exception ex) {
                //MessageBox.Show("Lỗi hiển thị NCC: " + ex.Message);
            }
        }
        #endregion

        private void radMultiColumnComboBoxMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radMultiColumnComboBoxMaSP.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedIndex != -1)
            {
                //Lấy tên sp
                if (radMultiColumnComboBoxTenSP.SelectedValue == null || (radMultiColumnComboBoxTenSP.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedValue.ToString().CompareTo(radMultiColumnComboBoxTenSP.SelectedValue.ToString()) != 0))
                {
                    radMultiColumnComboBoxTenSP.SelectedValue = radMultiColumnComboBoxMaSP.SelectedValue;
                    RadMultiColumnComboBox comboBox = (RadMultiColumnComboBox)sender;
                    RadTextBoxItem rtbi = (RadTextBoxItem)comboBox.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                    rtbi.SelectionLength = 0;
                }
                #region
                CSQLSanPham sanpham_ = new CSQLSanPham();
                CSQLSanPham_NSX sanpham_nsx_ = new CSQLSanPham_NSX();
                CSQLSanPham_Kho sp_kho_ = new CSQLSanPham_Kho();
                if (radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString() != "")
                {
                    //DataTable dtb = sanpham_.LaySanPhamTheoMaSP(radMultiColumnComboBoxMaSP.SelectedValue.ToString());
                    //DataTable dtb = sanpham_.LaySanPhamTheoSPID(radMultiColumnComboBoxMaSP.SelectedValue.ToString());
                    DataTable dtb = sanpham_.LaySanPhamTheoSPID(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());

                    if (dtb != null && dtb.Rows.Count > 0)
                    {
                        //txtTenSP.Text = dtb.Rows[0]["TenSP"].ToString();
                        cboDVT.SelectedValue = dtb.Rows[0]["DVChuan"].ToString();
                        string spid_ = dtb.Rows[0]["SPID"].ToString();

                        //DataTable dtbspnsx = sanpham_nsx_.LaySanPham_NSXTheoMaSP_CoMacDinh(radMultiColumnComboBoxMaSP.SelectedValue.ToString(), true);
                        DataTable dtbspnsx = sanpham_nsx_.LaySanPham_NSXTheoSPID_CoMacDinh(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), true);

                        if (dtbspnsx != null && dtbspnsx.Rows.Count > 0)
                        {
                            cboNSX.DataSource = sanpham_nsx_.LaySanPham_NSXTheoSPid(spid_);
                            cboNSX.DisplayMember = "TenNSX";
                            cboNSX.ValueMember = "NSXid";
                            cboNSX.SelectedIndex = -1;
                            //cboNSX.SelectedValue = sanpham_nsx_.LaySanPham_NSXTheoMaSP_CoMacDinh(radMultiColumnComboBoxMaSP.SelectedValue.ToString(), true).Rows[0]["NSXid"].ToString();
                            //cboNSX.SelectedValue = dtbspnsx.Rows[0]["NSXid"].ToString();//Lay nsxmacdinh
                            cboNSX.SelectedValue = new Guid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());

                        }
                        else
                        {
                            toolStripStatusThongBaoLoi.Text = "Chưa Tạo Mối Quan Hệ Sản Phẩm - Nhà Sản Xuất";
                            cboNSX.Text = "";
                            cboNSX.DataSource = sanpham_nsx_.LaySanPham_NSXTheoSPid(spid_);
                            cboNSX.DisplayMember = "TenNSX";
                            cboNSX.ValueMember = "NSXid";
                            cboNSX.SelectedIndex = -1;
                        }

                        // viết lấy kho mặc định ở đây
                        CSQLSanPham_Kho spk = new CSQLSanPham_Kho();
                        string khoid = spk.LayMaKhoMacDinhKhiNhap(spid_);
                        if (khoid != null && khoid.Length > 0)
                            cboKho.SelectedValue = khoid;
                        else
                        {
                            toolStripStatusThongBaoLoi.Text = "Chưa tạo kho mặc định";
                            cboKho.SelectedIndex = -1;
                        }

                        LayDVTVaoCombobox(spid_);
                    }
                }
                else
                {
                    radMultiColumnComboBoxMaSP.SelectedIndex = -1;
                    cboKho.SelectedValue = "";
                    cboDVT.SelectedValue = "";
                    cboNSX.SelectedValue = "";
                }
                #endregion
                //txtSLMua.Focus();
            }
        }

        private void radMultiColumnComboBoxTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radMultiColumnComboBoxTenSP.SelectedValue != null && radMultiColumnComboBoxTenSP.SelectedIndex != -1)
            {
                //Lấy mã sp
                if (radMultiColumnComboBoxMaSP.SelectedValue == null || (radMultiColumnComboBoxMaSP.SelectedValue != null && radMultiColumnComboBoxTenSP.SelectedValue.ToString().CompareTo(radMultiColumnComboBoxMaSP.SelectedValue.ToString()) != 0))
                {
                    radMultiColumnComboBoxMaSP.SelectedValue = radMultiColumnComboBoxTenSP.SelectedValue;
                    RadMultiColumnComboBox comboBox = (RadMultiColumnComboBox)sender;
                    RadTextBoxItem rtbi = (RadTextBoxItem)comboBox.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                    rtbi.SelectionLength = 0;
                }
            }
        }
        string MaPNidNull = "00000000-0000-0000-0000-000000000000";
        private void txtSoChungTu_Leave(object sender, EventArgs e)
        {
            CSQLNhapKho np_ = new CSQLNhapKho();
            txtSoChungTu.Text = txtSoChungTu.Text.ToUpper();
            if (txtSoChungTu.Text != "")
            {
                if (this._frmMain.MaNhapKhoCanSua_ != null && this._frmMain.MaNhapKhoCanSua_.CompareTo("") > 0)
                {
                    if (np_.KiemTraTrungSoChungTu(txtSoChungTu.Text, _frmMain.MaNhapKhoCanSua_) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Số Chứng Từ này đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtSoChungTu.Focus();
                    }
                    else
                    {
                        KT_Trung = false;
                    }
                }
                else
                {
                    if (np_.KiemTraTrungSoChungTu(txtSoChungTu.Text, MaPNidNull) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Số Chứng Từ này đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtSoChungTu.Focus();
                    }
                    else
                    {
                        KT_Trung = false;
                    }
                }
            }
        }

        private void rgvChiTietPhieuNhap_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            CSQLNhapKhoChiTiet nhapkhochitiet = new CSQLNhapKhoChiTiet();
            if (rgvChiTietPhieuNhap.CurrentRow.Cells["colPNCTid"].Value == null)
            {
                return;
            }
            else
            {
                _frmMain.MaNhapKhoChiTietCanSua_ = rgvChiTietPhieuNhap.CurrentRow.Cells["colPNCTid"].Value.ToString();
                _frmMain.BangNhapKhoChiTietCanSua_ = nhapkhochitiet.LayNhapKhoChiTietTheoPNCT(_frmMain.MaNhapKhoChiTietCanSua_);
                LayDVTVaoCombobox(_frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["SPID"].ToString());
                LayKhoVaoCombobox();
                if (_frmMain.BangNhapKhoChiTietCanSua_ != null && _frmMain.BangNhapKhoChiTietCanSua_.Rows.Count > 0)
                {
                    CSQLNhapKhoChiTiet nhapkhoct_ = new CSQLNhapKhoChiTiet();
                    //radMultiColumnComboBoxMaSP.SelectedIndex = 0;
                    CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                    string spnsxid = spnsx.SanPham_NSX_LaySPNSXIDTheoSPID_NSXID(_frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["SPID"].ToString(), _frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["MaNSX"].ToString());
                    if (spnsxid != null && spnsxid.Length > 0)
                        radMultiColumnComboBoxMaSP.SelectedValue = new Guid(spnsxid);
                    else
                    {
                        toolStripStatusThongBaoLoi.Text = "Không lấy được SanPham_NSX ID!";
                        return;
                    }
                    //txtMaSP.Text = _frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["MaSP"].ToString();
                    //txtTenSP.Text = _frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["TenSP"].ToString();
                    cboKho.SelectedValue = _frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["MaKho"].ToString();
                    txtSLMua.Text = String.Format("{0:N2}", decimal.Parse(_frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["SLMua"].ToString()));
                    txtSLFree.Text = String.Format("{0:N2}", decimal.Parse(_frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["SLFree"].ToString()));
                    txtTongSL.Text = String.Format("{0:N2}", decimal.Parse(_frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["TongSL"].ToString()));
                    cboDVT.SelectedValue = _frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["DVT"].ToString();
                    txtSoLo.Text = _frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["Lot"].ToString();
                    if (_frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["Date"].ToString().Length > 0)
                        dtHanDung.Value = (DateTime)_frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["Date"];
                    else
                        dtHanDung.Value = DateTime.Now;
                    cboNSX.SelectedValue = _frmMain.BangNhapKhoChiTietCanSua_.Rows[0]["MaNSX"].ToString();
                }
            }
        }

        private void radMultiColumnComboBoxTenSP_SelectedValueChanged(object sender, EventArgs e)
        {
            RadMultiColumnComboBox comboBox = (RadMultiColumnComboBox)sender;
            RadTextBoxItem rtbi = (RadTextBoxItem)comboBox.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
            rtbi.SelectionLength = 0;
        }

        private void txtSLMua_Leave(object sender, EventArgs e)
        {
            txtSLMua.SelectAll();
        }

        private void txtSLFree_Leave(object sender, EventArgs e)
        {
            txtSLFree.SelectAll();
        }

        private void txtSoLo_Leave(object sender, EventArgs e)
        {
            txtSoLo.SelectAll();
        }

        private void radMultiColumnComboBoxMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSLMua.Focus();
            }
        }

        private void txtSLMua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSoLo.Focus();
            }
        }

        private void txtSoLo_KeyDown(object sender, KeyEventArgs e)
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

        private void frmNhapKhoEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnNhapKhoThemMoi_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                ckDaNhapXong.Checked = true;
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnNhapKhoLuu_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnNhapKhoDong_Click(sender, e);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            InDonHangNhap(_frmMain.MaNhapKhoCanSua_);
        }

        private void InDonHangNhap(string NKid_)
        {
            CSQLNhapKhoChiTiet nkct_ = new CSQLNhapKhoChiTiet();
            if (NKid_ != null && NKid_.Length > 0)
            {
                DataTable DonHangNhapCT_ = nkct_.LayNhapKhoChiTietTheoPN(NKid_);
                Fr_DonHangNhap check = new Fr_DonHangNhap(DonHangNhapCT_);
                check.Show();
            }
        }

        private void txtSoSeri_Leave(object sender, EventArgs e)
        {
            txtSoSeri.Text = txtSoSeri.Text.ToUpper();
        }

        private void cbkHangDacBiet_CheckedChanged(object sender, EventArgs e)
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            CSQLKho kho = new CSQLKho();
            string mabp_ = chht.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();
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

            if (cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet())
            {
                cboKho.DataSource = kho.LayKhoDacBiet_TongCongTy(MaBPcon);
            }
            else
            {
                cboKho.DataSource = kho.LayKhoLenCBO_TongCongTy(MaBPcon);
            }
        }
    }
}

