using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmNhaThuocEdit : Form
    {
        frmMain _frmMain;

        public frmNhaThuocEdit()
        {
            InitializeComponent();
        }
        public frmNhaThuocEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNhaThuocEdit_Load(object sender, EventArgs e)
        {
            LayThanhPhoVaoCombobox();
            LayQuanVaoCombobox();
            LayLoaiGiaVaoCombobox();
            LayNhanVienVaoCombobox();

            if (_frmMain.BangNhaThuocCanSua_ != null && _frmMain.BangNhaThuocCanSua_.Rows.Count > 0)
            {
                CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
                nhathuoc.SNTID = _frmMain.BangNhaThuocCanSua_.Rows[0]["NTID"].ToString();
                nhathuoc.SMaNT = _frmMain.BangNhaThuocCanSua_.Rows[0]["MaNT"].ToString();
                nhathuoc.STenNT = _frmMain.BangNhaThuocCanSua_.Rows[0]["TenNT"].ToString();
                nhathuoc.SDiaChi = _frmMain.BangNhaThuocCanSua_.Rows[0]["DiaChi"].ToString();
                nhathuoc.SQuanID = _frmMain.BangNhaThuocCanSua_.Rows[0]["QuanID"].ToString();
                nhathuoc.STPID = _frmMain.BangNhaThuocCanSua_.Rows[0]["TPID"].ToString();
                nhathuoc.STel = _frmMain.BangNhaThuocCanSua_.Rows[0]["Tel"].ToString();
                nhathuoc.SFax = _frmMain.BangNhaThuocCanSua_.Rows[0]["Fax"].ToString();
                nhathuoc.SNTEmail = _frmMain.BangNhaThuocCanSua_.Rows[0]["NTEmail"].ToString();
                nhathuoc.SPIC = _frmMain.BangNhaThuocCanSua_.Rows[0]["PIC"].ToString();
                nhathuoc.SDTDD = _frmMain.BangNhaThuocCanSua_.Rows[0]["DTDD"].ToString();
                nhathuoc.SPICEmail = _frmMain.BangNhaThuocCanSua_.Rows[0]["PICEmail"].ToString();
                nhathuoc.SLGID = _frmMain.BangNhaThuocCanSua_.Rows[0]["LGID"].ToString();
                nhathuoc.INhomLoai = int.Parse(_frmMain.BangNhaThuocCanSua_.Rows[0]["NhomLoai"].ToString());
                nhathuoc.DMaxTon = decimal.Parse(_frmMain.BangNhaThuocCanSua_.Rows[0]["MaxTon"].ToString());
                nhathuoc.DSaiSo = decimal.Parse(_frmMain.BangNhaThuocCanSua_.Rows[0]["SaiSo"].ToString());
                nhathuoc.SGhiChu = _frmMain.BangNhaThuocCanSua_.Rows[0]["GhiChu"].ToString();
                nhathuoc.BKhongSuDung = (bool)_frmMain.BangNhaThuocCanSua_.Rows[0]["KhongSuDung"];

                txtMaNT.Text = nhathuoc.SMaNT;
                txtTenNT.Text = nhathuoc.STenNT;
                txtDiaChi.Text = nhathuoc.SDiaChi;
                cboQuan.SelectedValue = nhathuoc.SQuanID;
                cboTP.SelectedValue = nhathuoc.STPID;
                txtTel.Text = nhathuoc.STel;
                txtFax.Text = nhathuoc.SFax;
                txtEmailNT.Text = nhathuoc.SNTEmail;
                cboCHT.SelectedValue = nhathuoc.SPIC;
                txtDTDD.Text = nhathuoc.SDTDD;
                txtEmailCHT.Text = nhathuoc.SPICEmail;
                cboLoaiGia.SelectedValue = nhathuoc.SLGID;
                txtMaxTon.Text = nhathuoc.DMaxTon.ToString();
                txtsaiso.Text = nhathuoc.DSaiSo.ToString();
                txtNhomLoai.Text = nhathuoc.INhomLoai.ToString();
                txtGhiChu.Text = nhathuoc.SGhiChu;
                ckKhongDung.Checked = nhathuoc.BKhongSuDung;
            }
        }
        void LayThanhPhoVaoCombobox()
        {
            CSQLThanhPho tp = new CSQLThanhPho();
            cboTP.DataSource = tp.LayThongTinThanhPho(_frmMain.IsXemTatCa_);
            cboTP.DisplayMember = "TenTP";
            cboTP.ValueMember = "TPID";
            cboTP.SelectedIndex = -1;
        }
        void LayQuanVaoCombobox()
        {
            CSQLQuan quan = new CSQLQuan();
            cboQuan.DataSource = quan.LayDanhSachQuanLenLuoi(_frmMain.IsXemTatCa_);
            cboQuan.DisplayMember = "TenQ";
            cboQuan.ValueMember = "QuanID";
            cboQuan.SelectedIndex = -1;
        }
        void LayLoaiGiaVaoCombobox()
        {
            CSQLPhanLoaiGia lg = new CSQLPhanLoaiGia();
            cboLoaiGia.DataSource = lg.LayDanhSachPhanloaiGiaLenLuoi(_frmMain.IsXemTatCa_);
            cboLoaiGia.DisplayMember = "TenLG";
            cboLoaiGia.ValueMember = "LGID";
            cboLoaiGia.SelectedIndex = -1;
        }
        void LayNhanVienVaoCombobox()
        {
            CSQLNhanVien nhanvien = new CSQLNhanVien();
            cboCHT.DataSource = nhanvien.LayThongTinNhanVienLenLuoi(_frmMain.IsXemTatCa_);
            cboCHT.DisplayMember = "HoTen";
            cboCHT.ValueMember = "NVID";
            cboCHT.SelectedIndex = -1;
        }

        private void btnNTLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNhaThuoc.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (txtTenNT.Text == "")
            {
                MessageBox.Show("Tên Nhà Thuốc Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                txtTenNT.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa Chỉ Nhà Thuốc Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                txtDiaChi.Focus();
                return;
            }
            if (txtMaxTon.Text == "")
            {
                MessageBox.Show("Định Mức Tồn Nhà Thuốc Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                txtMaxTon.Focus();
                return;
            }
            if (txtsaiso.Text == "")
            {
                MessageBox.Show("Sai Số Nhà Thuốc Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                txtsaiso.Focus();
                return;
            }
            if (cboCHT.SelectedValue == null)
            {
                MessageBox.Show("Cửa Hàng Trưởng Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                cboCHT.Focus();
                return;
            }
            if (cboQuan.SelectedValue == null)
            {
                MessageBox.Show("Thông Tin Quận Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                cboQuan.Focus();
                return;
            }
            if (cboTP.SelectedValue == null)
            {
                MessageBox.Show("Thông Tin Thành Phố Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                cboTP.Focus();
                return;
            }
            //if (cboLoaiGia.SelectedValue == null)
            //{
            //    MessageBox.Show("Thông Tin Loại Giá Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
            //    return;
            //}
            if (txtNhomLoai.Text == "")
            {
                MessageBox.Show("Nhóm Loại Nhà Thuốc Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                txtNhomLoai.Focus();
                return;
            }
            if (this._frmMain.MaNhaThuocCanSua_ != null && this._frmMain.MaNhaThuocCanSua_.CompareTo("") > 0)
            {
                CXuLyChuoi xlc = new CXuLyChuoi();
                CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
                nhathuoc.SNTID = this._frmMain.MaNhaThuocCanSua_;
                nhathuoc.STenNT= xlc.TrimTen(txtTenNT.Text) ;
                nhathuoc.SDiaChi = xlc.TrimTen(txtDiaChi.Text);
                nhathuoc.SQuanID = cboQuan.SelectedValue.ToString();
                nhathuoc.STPID = cboTP.SelectedValue.ToString();
                nhathuoc.STel = txtTel.Text.Trim();
                nhathuoc.SFax = txtFax.Text.Trim();
                nhathuoc.SNTEmail = txtEmailNT.Text.Trim();
                nhathuoc.SPIC = cboCHT.SelectedValue.ToString();
                nhathuoc.SDTDD = txtDTDD.Text.Trim();
                nhathuoc.SPICEmail = txtEmailCHT.Text;
                if (cboLoaiGia.SelectedValue != null)
                {
                    nhathuoc.SLGID = cboLoaiGia.SelectedValue.ToString();
                }
                else
                {
                    nhathuoc.SLGID = "00000000-0000-0000-0000-000000000000";
                }
                nhathuoc.DMaxTon = decimal.Parse( txtMaxTon.Text);
                nhathuoc.DSaiSo = decimal.Parse(txtsaiso.Text);
                nhathuoc.SGhiChu =xlc.TrimDoanVan(txtGhiChu.Text);
                nhathuoc.DLastUD = DateTime.Now;
                nhathuoc.BKhongSuDung = ckKhongDung.Checked;
                nhathuoc.SUserID = CStaticBien.SmaTaiKhoan;
                nhathuoc.INhomLoai = int.Parse(txtNhomLoai.Text);

                int kq = nhathuoc.SuaThongTinNhaThuoc(nhathuoc);
                if (kq == 1)
                {
                    _frmMain.fNhaThuoc.rgvNhaThuoc.DataSource = nhathuoc.LayDanhSachNhaThuocLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                    txtTenNT.Focus();
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Sửa thông tin thất bại.";
                }
            }
            else
            {
                CXuLyChuoi xlc = new CXuLyChuoi();
                CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc(); 
                nhathuoc.STenNT =xlc.TrimTen(txtTenNT.Text);
                nhathuoc.SDiaChi =xlc.TrimTen(txtDiaChi.Text);
                nhathuoc.SQuanID = cboQuan.SelectedValue.ToString();
                nhathuoc.STPID = cboTP.SelectedValue.ToString();
                nhathuoc.STel = txtTel.Text.Trim();
                nhathuoc.SFax = txtFax.Text.Trim();
                nhathuoc.SNTEmail = txtEmailNT.Text.Trim();
                nhathuoc.SPIC = cboCHT.SelectedValue.ToString();
                nhathuoc.SDTDD = txtDTDD.Text.Trim();
                nhathuoc.SPICEmail = txtEmailCHT.Text.Trim();
                if (cboLoaiGia.SelectedValue != null)
                {
                    nhathuoc.SLGID = cboLoaiGia.SelectedValue.ToString();
                }
                else
                {
                    nhathuoc.SLGID = "00000000-0000-0000-0000-000000000000";
                }
                nhathuoc.DMaxTon = decimal.Parse(txtMaxTon.Text);
                nhathuoc.DSaiSo = decimal.Parse(txtsaiso.Text);
                nhathuoc.DLastUD = DateTime.Now;
                nhathuoc.DNgayTao = DateTime.Now;
                nhathuoc.SGhiChu =xlc.TrimDoanVan(txtGhiChu.Text);
                nhathuoc.BKhongSuDung = ckKhongDung.Checked;
                nhathuoc.SUserID = CStaticBien.SmaTaiKhoan;
                nhathuoc.INhomLoai = int.Parse(txtNhomLoai.Text);

                string maquantrave = nhathuoc.ThemMoiNhaThuoc(nhathuoc);
                if (maquantrave != null)
                {
                    this._frmMain.MaNhaThuocCanSua_ = maquantrave;
                    this._frmMain.fNhaThuoc.rgvNhaThuoc.DataSource = nhathuoc.LayDanhSachNhaThuocLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                    txtTenNT.Focus();
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Thêm thất bại.";
                }
            }
        }

        private void btnNTDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmNhaThuocEditisOpen_ = false;
                //txtTenNT.Text = "";
                //txtDiaChi.Text = "";
                //txtTel.Text = "";
                //txtFax.Text = "";
                //txtEmailNT.Text = "";
                //txtDTDD.Text = "";
                //txtEmailCHT.Text = "";
                //txtMaxTon.Text = "";
                //txtsaiso.Text = "";
                //txtGhiChu.Text = "";
                //ckKhongDung.Checked = false;
                //LayThanhPhoVaoCombobox();
                //LayQuanVaoCombobox();
                //LayLoaiGiaVaoCombobox();
                //LayNhanVienVaoCombobox();
            this.Close();
        }

        private void txtMaxTon_TextChanged(object sender, EventArgs e)
        {
            if (txtMaxTon.Text.Length > 0)
            {
                txtMaxTon.Text = Convert.ToDecimal(txtMaxTon.Text).ToString("#,###");
                txtMaxTon.Select(txtMaxTon.TextLength, 0);
            }
        }

        private void txtMaxTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsaiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void btnNTThemMoi_Click(object sender, EventArgs e)
        {
            this._frmMain.MaNhaThuocCanSua_ = null;
            txtTenNT.Text = "";
            txtDiaChi.Text = "";
            txtTel.Text = "";
            txtFax.Text = "";
            txtEmailNT.Text = "";
            txtDTDD.Text = "";
            txtEmailCHT.Text = "";
            txtMaxTon.Text = "";
            txtsaiso.Text = "";
            txtGhiChu.Text = "";
            txtNhomLoai.Text = "";
            ckKhongDung.Checked = false;
            LayThanhPhoVaoCombobox();
            LayQuanVaoCombobox();
            LayLoaiGiaVaoCombobox();
            LayNhanVienVaoCombobox();

        }

        private void frmNhaThuocEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _frmMain.frmNhaThuocEditisOpen_ = false;
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnNTThemMoi_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.L)
            {
                btnNTLuu_Click(sender, e);
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDTDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemNhanhQuan_Click(object sender, EventArgs e)
        {
            _frmMain.fQuanEdit_ = new frmQuanEdit(_frmMain);
            _frmMain.frmQuanEditisOpen_ = true;
            LayQuanVaoCombobox();
            _frmMain.fQuanEdit_.ShowDialog();
        }

        private void btnThemNhanhTP_Click(object sender, EventArgs e)
        {
            _frmMain.fThanhPhoEdit_ = new frmThanhPhoEdit(_frmMain);
            _frmMain.frmThanhPhoEditisOpen_ = true;
            LayThanhPhoVaoCombobox();
            _frmMain.fThanhPhoEdit_.ShowDialog();
        }

        private void btnThemNhanhCHT_Click(object sender, EventArgs e)
        {
            _frmMain.fNhanVienEdit_ = new frmNhanVienEdit(_frmMain);
            _frmMain.frmNhanVienEditisOpen_ = true;
            LayNhanVienVaoCombobox();
            _frmMain.fNhanVienEdit_.ShowDialog();
        }

        private void txtNhomLoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsaiso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtsaiso.Text) > 50)
                {
                    MessageBox.Show("Sai số không được nhập quá 50%. Xác Nhận");
                    txtsaiso.Focus();
                }
            }
            catch { }
        }


    }
}
