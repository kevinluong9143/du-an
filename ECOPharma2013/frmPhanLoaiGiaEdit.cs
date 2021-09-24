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
    public partial class frmPhanLoaiGiaEdit : Form
    {
        frmMain _frmMain;
        public frmPhanLoaiGiaEdit()
        {
            InitializeComponent();
        }
        public frmPhanLoaiGiaEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        private void frmPhanLoaiGiaEdit_Load(object sender, EventArgs e)
        {
            if (_frmMain.BangPhanLoaiGiaCanSua_ != null && _frmMain.BangPhanLoaiGiaCanSua_.Rows.Count > 0)
            {
                CSQLPhanLoaiGia phanloaigia = new CSQLPhanLoaiGia();

                phanloaigia.SMaLG = _frmMain.BangPhanLoaiGiaCanSua_.Rows[0]["LGID"].ToString();
                phanloaigia.STenLG = _frmMain.BangPhanLoaiGiaCanSua_.Rows[0]["TenLG"].ToString();
                phanloaigia.DMarkUp = decimal.Parse(_frmMain.BangPhanLoaiGiaCanSua_.Rows[0]["MarkUp"].ToString());
                phanloaigia.SGhiChu = _frmMain.BangPhanLoaiGiaCanSua_.Rows[0]["GhiChu"].ToString();
                phanloaigia.BKhongSuDung = (bool)_frmMain.BangPhanLoaiGiaCanSua_.Rows[0]["KhongSuDung"];
                this.txtLoaiGia.Text = phanloaigia.STenLG;
                this.txtGhiChu.Text = phanloaigia.SGhiChu;
                this.txtMarkUp.Text = phanloaigia.DMarkUp.ToString();
                this.ckKhongDung.Checked = phanloaigia.BKhongSuDung;
            }
        }

        private void btnPLGThemMoi_Click(object sender, EventArgs e)
        {
            this._frmMain.MaPhanLoaiGiaCanSua_ = null;
            this._frmMain.fPhanLoaiGiaEdit_.txtLoaiGia.Text = "";
            this._frmMain.fPhanLoaiGiaEdit_.txtMarkUp.Text = "";
            this._frmMain.fPhanLoaiGiaEdit_.txtGhiChu.Text = "";
            this._frmMain.fPhanLoaiGiaEdit_.ckKhongDung.Checked = false;
        }

        private void btnPLGLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fPhanLoaiGia.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (txtLoaiGia.Text == "")
            {
                MessageBox.Show("Tên Loại Giá Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                return;
            }
            if (txtMarkUp.Text == "")
            {
                MessageBox.Show("Mức Giá Lời Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                return;
            }
            if (this._frmMain.MaPhanLoaiGiaCanSua_ != null && this._frmMain.MaPhanLoaiGiaCanSua_.CompareTo("") > 0)
            {
                CXuLyChuoi xlc = new CXuLyChuoi();
                CSQLPhanLoaiGia phanloaigia = new CSQLPhanLoaiGia();
                phanloaigia.SMaLG = this._frmMain.MaPhanLoaiGiaCanSua_;
                phanloaigia.STenLG = xlc.TrimTen(this.txtLoaiGia.Text);
                phanloaigia.DMarkUp = decimal.Parse(this.txtMarkUp.Text);
                phanloaigia.SGhiChu = xlc.TrimDoanVan(this.txtGhiChu.Text);
                phanloaigia.DLastUD = DateTime.Now;
                phanloaigia.DNgayTao = DateTime.Now;
                phanloaigia.BKhongSuDung = this.ckKhongDung.Checked;
                phanloaigia.SuserID = CStaticBien.SmaTaiKhoan;

                int kq = phanloaigia.SuaThongTinPhanloaiGia(phanloaigia);
                if (kq == 1)
                {
                    if (this._frmMain.DSLoaiGiaIsOpen == true)
                        {
                            _frmMain.fPhanLoaiGia.rgvPhanLoaiGia.DataSource = phanloaigia.LayDanhSachPhanloaiGiaLenLuoi(_frmMain.IsXemTatCa_);
                            toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                        }
                    else
                        toolStripStatusThongBaoLoi.Text = "Sửa thành công.";
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Sửa thông tin thất bại.";
                }
            }
            else
            {
                CXuLyChuoi xlc = new CXuLyChuoi();
                CSQLPhanLoaiGia phanloaigia = new CSQLPhanLoaiGia();
                phanloaigia.STenLG = xlc.TrimTen(txtLoaiGia.Text);
                phanloaigia.DMarkUp = decimal.Parse(this.txtMarkUp.Text);
                phanloaigia.SGhiChu =xlc.TrimDoanVan(txtGhiChu.Text);
                phanloaigia.BKhongSuDung = ckKhongDung.Checked;
                phanloaigia.DNgayTao = DateTime.Now;
                phanloaigia.DLastUD = DateTime.Now;
                phanloaigia.SuserID = CStaticBien.SmaTaiKhoan;

                string maquantrave = phanloaigia.ThemMoiPhanloaiGia(phanloaigia);
                if (maquantrave != null)
                {
                    if (this._frmMain.DSLoaiGiaIsOpen == true)
                    {
                        this._frmMain.MaPhanLoaiGiaCanSua_ = maquantrave;
                        this._frmMain.fPhanLoaiGia.rgvPhanLoaiGia.DataSource = phanloaigia.LayDanhSachPhanloaiGiaLenLuoi(_frmMain.IsXemTatCa_);
                        toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                        //this.txtGhiChu.Text = "";
                        //this.txtLoaiGia.Text = "";
                        //this.txtMarkUp.Text = "";
                        //this.ckKhongDung.Checked = false;
                        //this._frmMain.MaPhanLoaiGiaCanSua_ = null;
                    }
                    else
                        toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Thêm thất bại.";
                }
            }
        }

        private void btnPLGDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmPhanLoaiGiaEditisOpen_ = false;
            this.txtGhiChu.Text = "";
            this.txtLoaiGia.Text = "";
            this.txtMarkUp.Text = "";
            this.ckKhongDung.Checked = false;
            this.Close();
        }

        private void txtMarkUp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void frmPhanLoaiGiaEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _frmMain.frmPhanLoaiGiaEditisOpen_ = false;
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnPLGThemMoi_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.L)
            {
                btnPLGLuu_Click(sender, e);
            }
        }
    }
}
