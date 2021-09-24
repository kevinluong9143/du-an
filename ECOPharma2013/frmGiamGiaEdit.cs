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
    public partial class frmGiamGiaEdit : Form
    {
        frmMain _frmMain;
        public frmGiamGiaEdit()
        {
            InitializeComponent();
        }
        public frmGiamGiaEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmGiamGiaEdit_Load(object sender, EventArgs e)
        {
            if (_frmMain.BangGiamGiaCanSua_ != null && _frmMain.BangGiamGiaCanSua_.Rows.Count > 0)
            {
                CSQLGiamGia giamgia = new CSQLGiamGia();

                giamgia.SMaGG = _frmMain.BangGiamGiaCanSua_.Rows[0]["GGID"].ToString();
                giamgia.STenGG = _frmMain.BangGiamGiaCanSua_.Rows[0]["TenGG"].ToString();
                giamgia.DMucGiam = decimal.Parse(_frmMain.BangGiamGiaCanSua_.Rows[0]["MucGiam"].ToString());
                giamgia.SGhiChu = _frmMain.BangGiamGiaCanSua_.Rows[0]["GhiChu"].ToString();
                giamgia.BKhongSuDung = (bool)_frmMain.BangGiamGiaCanSua_.Rows[0]["KhongSuDung"];
                this.txtTenGiamGia.Text = giamgia.STenGG;
                this.txtGhiChu.Text = giamgia.SGhiChu;
                this.txtMucGiam.Text = giamgia.DMucGiam.ToString();
                this.ckKhongDung.Checked = giamgia.BKhongSuDung;
            }
        }

        private void btnGiamGiaThemMoi_Click(object sender, EventArgs e)
        {
            this._frmMain.MaGiamGiaCanSua_ = null;
            this._frmMain.fGiamGiaEdit_.txtTenGiamGia.Text = "";
            this._frmMain.fGiamGiaEdit_.txtMucGiam.Text = "";
            this._frmMain.fGiamGiaEdit_.txtGhiChu.Text = "";
            this._frmMain.fGiamGiaEdit_.ckKhongDung.Checked = false;

        }

        private void btnGiamGiaLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fGiamGia.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (txtTenGiamGia.Text=="")
            {
                MessageBox.Show("Tên Giảm Giá Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                return;
            }
            if (txtMucGiam.Text=="")
            {
                MessageBox.Show("Mức Giảm Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                return;
            }
            if (this._frmMain.MaGiamGiaCanSua_ != null && this._frmMain.MaGiamGiaCanSua_.CompareTo("") > 0)
            {
                CXuLyChuoi xlc = new CXuLyChuoi();
                CSQLGiamGia giamgia = new CSQLGiamGia();
                giamgia.SMaGG = this._frmMain.MaGiamGiaCanSua_;
                giamgia.STenGG = xlc.TrimChuoi(this.txtTenGiamGia.Text);
                giamgia.DMucGiam = decimal.Parse(this.txtMucGiam.Text);
                giamgia.SGhiChu = xlc.TrimDoanVan(this.txtGhiChu.Text);
                giamgia.DLastUD = DateTime.Now;
                giamgia.DNgayTao = DateTime.Now;
                giamgia.BKhongSuDung = this.ckKhongDung.Checked;
                giamgia.SuserID = CStaticBien.SmaTaiKhoan;

                int kq = giamgia.SuaThongTinGiamGia(giamgia);
                if (kq == 1)
                {
                    _frmMain.fGiamGia.rgvGiamGia.DataSource = giamgia.LayDanhSachGiamGiaLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                    txtTenGiamGia.Focus();
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Sửa thông tin thất bại.";
                }
            }
            else
            {
                CXuLyChuoi xlc = new CXuLyChuoi();
                CSQLGiamGia giamgia = new CSQLGiamGia();
                giamgia.STenGG =xlc.TrimChuoi(txtTenGiamGia.Text);
                giamgia.DMucGiam = decimal.Parse(this.txtMucGiam.Text);
                giamgia.SGhiChu =xlc.TrimDoanVan(txtGhiChu.Text);
                giamgia.BKhongSuDung = ckKhongDung.Checked;
                giamgia.DNgayTao = DateTime.Now;
                giamgia.DLastUD = DateTime.Now;
                giamgia.SuserID = CStaticBien.SmaTaiKhoan;

                string maquantrave = giamgia.ThemMoiGiamGia(giamgia);
                if (maquantrave != null)
                {
                    this._frmMain.MaGiamGiaCanSua_ = maquantrave;
                    this._frmMain.fGiamGia.rgvGiamGia.DataSource = giamgia.LayDanhSachGiamGiaLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                    txtTenGiamGia.Focus();
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Thêm thất bại.";
                }
            }
        }

        private void btnGiamGiaDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmGiamGiaEditisOpen_ = false;
            this.Close();
        }

        private void txtMucGiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void frmGiamGiaEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnGiamGiaDong_Click(sender,  e);
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnGiamGiaThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnGiamGiaLuu_Click(sender, e);
            }
        }
        
    }
}
