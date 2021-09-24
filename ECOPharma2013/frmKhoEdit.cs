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
    public partial class frmKhoEdit : Form
    {
        frmMain _frmMain;
        public frmKhoEdit()
        {
            InitializeComponent();
        }
        public frmKhoEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        private void frmKhoEdit_Load(object sender, EventArgs e)
        {
            LayBoPhanVaoCombobox();
            LayNhomKhoVaoCombobox();

            CSQLKho kho = new CSQLKho();
            if (_frmMain.BangKhoCanSua_ != null && _frmMain.BangKhoCanSua_.Rows.Count > 0)
            {
                kho.SMaKho = _frmMain.BangKhoCanSua_.Rows[0]["KhoID"].ToString();
                kho.SMaKhoERP = _frmMain.BangKhoCanSua_.Rows[0]["MaKho"].ToString();
                kho.STenKho = _frmMain.BangKhoCanSua_.Rows[0]["TenKho"].ToString();
                kho.SGhiChu = _frmMain.BangKhoCanSua_.Rows[0]["GhiChu"].ToString();
                kho.BKhongSuDung = (bool)_frmMain.BangKhoCanSua_.Rows[0]["KhongSuDung"];
                kho.SLoaiKhoID =_frmMain.BangKhoCanSua_.Rows[0]["LoaiKhoID"].ToString();
                kho.INhomKhoID = int.Parse(_frmMain.BangKhoCanSua_.Rows[0]["NhomKhoID"].ToString());
                this.txtMaKho.Text = kho.SMaKhoERP;
                this.txtTenKho.Text = kho.STenKho;
                this.txtGhiChu.Text = kho.SGhiChu;
                this.ckKhongDung.Checked = kho.BKhongSuDung;
                cboLoaiKho.SelectedValue = kho.SLoaiKhoID;
                cboNhomKho.SelectedValue = kho.INhomKhoID;
            }
        }

        void LayBoPhanVaoCombobox()
        {
            CSQLBoPhan bophan_ = new CSQLBoPhan();
            cboLoaiKho.DataSource = bophan_.LoadDS_MaBPCha();
            cboLoaiKho.DisplayMember = "TenBP";
            cboLoaiKho.ValueMember = "MaBPCha";
            cboLoaiKho.SelectedIndex = -1;
        }
        void LayNhomKhoVaoCombobox()
        {
            CSQLKho kho = new CSQLKho();
            cboNhomKho.DataSource = kho.LayNhomKho();
            cboNhomKho.DisplayMember = "NhomKho";
            cboNhomKho.ValueMember = "NhomKhoID";
            cboNhomKho.SelectedIndex = -1;
        }
        private void btnKhoThemMoi_Click(object sender, EventArgs e)
        {
            this._frmMain.MaKhoCanSua_ = null;
            this._frmMain.fKhoEdit_.txtTenKho.Text = "";
            this._frmMain.fKhoEdit_.txtGhiChu.Text = "";
            this._frmMain.fKhoEdit_.ckKhongDung.Checked = false;
            LayBoPhanVaoCombobox();
            LayNhomKhoVaoCombobox();
            txtTenKho.Focus();
        }

        private void btnKhoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenKho.Text == "")
                {
                    MessageBox.Show("Tên Kho Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                    return;
                }
                if (cboLoaiKho.SelectedValue == null)
                {
                    MessageBox.Show("Loại Kho Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                    return;
                }
                if (cboNhomKho.SelectedValue == null)
                {
                    MessageBox.Show("Nhóm Kho Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                    return;
                }
                if (this._frmMain.MaKhoCanSua_ != null && this._frmMain.MaKhoCanSua_.CompareTo("") > 0)
                {
                    CXuLyChuoi xlc = new CXuLyChuoi();
                    CSQLKho kho = new CSQLKho();
                    kho.SMaKho = this._frmMain.MaKhoCanSua_;
                    kho.STenKho = xlc.TrimTen(this.txtTenKho.Text);
                    kho.SGhiChu = xlc.TrimDoanVan(this.txtGhiChu.Text);
                    kho.DLastUD = DateTime.Now;
                    kho.DNgayTao = DateTime.Now;
                    kho.BKhongSuDung = this.ckKhongDung.Checked;
                    kho.SuserID = CStaticBien.SmaTaiKhoan;
                    kho.SLoaiKhoID = cboLoaiKho.SelectedValue.ToString();
                    kho.INhomKhoID = int.Parse(cboNhomKho.SelectedValue.ToString());


                    int kq = kho.SuaThongTinKho(kho);
                    if (kq == 1)
                    {
                        _frmMain.fKho.rgvKho.DataSource = kho.LayDanhSachKhoLenLuoi(_frmMain.IsXemTatCa_);
                        toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                        txtTenKho.Focus();
                    }
                    else
                    {
                        toolStripStatusThongBaoLoi.Text = "Sửa thông tin thất bại.";
                    }
                }
                else
                {
                    CSQLKho kho = new CSQLKho();
                    kho.STenKho = txtTenKho.Text;
                    kho.SGhiChu = txtGhiChu.Text;
                    kho.BKhongSuDung = ckKhongDung.Checked;
                    kho.DNgayTao = DateTime.Now;
                    kho.DLastUD = DateTime.Now;
                    kho.SuserID = CStaticBien.SmaTaiKhoan;
                    kho.SLoaiKhoID = cboLoaiKho.SelectedValue.ToString();
                    kho.INhomKhoID = int.Parse(cboNhomKho.SelectedValue.ToString());
                    string maquantrave = kho.ThemMoiKho(kho);
                    if (maquantrave != null)
                    {
                        this._frmMain.MaKhoCanSua_ = maquantrave;
                        this._frmMain.fKho.rgvKho.DataSource = kho.LayDanhSachKhoLenLuoi(_frmMain.IsXemTatCa_);
                        toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                        txtTenKho.Focus();
                    }
                    else
                    {
                        toolStripStatusThongBaoLoi.Text = "Thêm thất bại.";
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusThongBaoLoi.Text = ex.Message;
            }
        }

        private void btnKhoDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmKhoEditisOpen_ = false;
            this.txtGhiChu.Text = "";
            this.txtTenKho.Text = "";
            this.ckKhongDung.Checked = false;
            this.Close();
        }

        private void frmKhoEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _frmMain.frmKhoEditisOpen_ = false;
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnKhoThemMoi_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.L)
            {
                btnKhoLuu_Click(sender, e);
            }
        }
    }
}
