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
    public partial class frmNhomNguoiDungEdit : Form
    {
        private frmMain _frmMain;
        CSQLNhomNguoiDung LopSQLNhomNguoiDung;

        public frmNhomNguoiDungEdit(frmMain fMain)
        {
            InitializeComponent();
            _frmMain = fMain;
        }

        private void frmNhomNguoiDungEdit_Load(object sender, EventArgs e)
        {
            if (_frmMain.BangNhomNguoiDungCanSua_ != null && _frmMain.BangNhomNguoiDungCanSua_.Rows.Count > 0)
            {

                txtTenNhom.Text = _frmMain.BangNhomNguoiDungCanSua_.Rows[0]["TenNhom"].ToString();
                ckKhongDung.Checked = (bool)_frmMain.BangNhomNguoiDungCanSua_.Rows[0]["IsKhongDung"];
                txtGhiChu.Text = _frmMain.BangNhomNguoiDungCanSua_.Rows[0]["GhiChu"].ToString();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmNhomNguoiDungEditisOpen_ = false;
            _frmMain.IsSuaNhomNguoiDung_ = false;
            this.Close();
        }

        public void LayDuLieutuForm()
        {
            CXuLyChuoi xlc = new CXuLyChuoi();
            LopSQLNhomNguoiDung = new CSQLNhomNguoiDung();
            LopSQLNhomNguoiDung.sTenNhom = xlc.TrimTen(txtTenNhom.Text);
            LopSQLNhomNguoiDung.sGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
            LopSQLNhomNguoiDung.bIsKhongDung = ckKhongDung.Checked;

            if (_frmMain.IsSuaNhomNguoiDung_ == true)
            {
                LopSQLNhomNguoiDung.sNhomNDid = _frmMain.MaNhomNguoiDungCanSua_;
            }
        }
        public bool KiemTraNull()
        {
            if (txtTenNhom.Text.Length == 0)
            {
                txtTenNhom.Focus();
                statusTB.Text = "Chưa có tên Nhóm Người Dùng";
                return true;
            }

            return false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNhomNguoiDung.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (KiemTraNull() == false)
            {
                if (this._frmMain.MaNhomNguoiDungCanSua_ != null && this._frmMain.MaNhomNguoiDungCanSua_.CompareTo("") > 0)
                {
                    CXuLyChuoi xlchuoi = new CXuLyChuoi();
                    LopSQLNhomNguoiDung = new CSQLNhomNguoiDung();
                    LopSQLNhomNguoiDung.sNhomNDid = this._frmMain.MaNhomNguoiDungCanSua_;
                    LopSQLNhomNguoiDung.sTenNhom = xlchuoi.TrimTen(this.txtTenNhom.Text);
                    LopSQLNhomNguoiDung.sGhiChu = xlchuoi.TrimDoanVan(this.txtGhiChu.Text);
                    LopSQLNhomNguoiDung.bIsKhongDung = this.ckKhongDung.Checked;
                    int kq = LopSQLNhomNguoiDung.SuaThongTinNhomNguoiDung(LopSQLNhomNguoiDung);
                    if (kq == 1)
                    {
                        _frmMain.fNhomNguoiDung.rgvNhomNguoiDung.DataSource = LopSQLNhomNguoiDung.LayDSNhomNguoiDungLenLuoi(_frmMain.IsXemTatCa_);
                        statusTB.Text = "Sửa thành công!";
                        txtTenNhom.Focus();
                    }
                    else
                    {
                        statusTB.Text = "Sửa thông tin thất bại.";
                    }

                }
                else
                {
                    CXuLyChuoi xlchuoi = new CXuLyChuoi();
                    LopSQLNhomNguoiDung = new CSQLNhomNguoiDung();
                    LopSQLNhomNguoiDung.sTenNhom = xlchuoi.TrimTen(txtTenNhom.Text);
                    LopSQLNhomNguoiDung.sGhiChu = xlchuoi.TrimDoanVan(txtGhiChu.Text);
                    LopSQLNhomNguoiDung.bIsKhongDung = ckKhongDung.Checked;
                    string maquantrave = LopSQLNhomNguoiDung.LuuNhomND(LopSQLNhomNguoiDung);
                    if (maquantrave != null)
                    {
                        this._frmMain.MaNhomNguoiDungCanSua_ = maquantrave;
                        _frmMain.fNhomNguoiDung.rgvNhomNguoiDung.DataSource = LopSQLNhomNguoiDung.LayDSNhomNguoiDungLenLuoi(_frmMain.IsXemTatCa_);
                        statusTB.Text = "Thêm thành công.";
                        txtTenNhom.Focus();
                    }
                    else
                    {
                        statusTB.Text = "Thêm thất bại.";
                    }
                }
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            this._frmMain.MaNhomNguoiDungCanSua_ = null;
            txtTenNhom.Text = "";
            txtGhiChu.Text = "";
            ckKhongDung.Checked = false;
            txtTenNhom.Focus();
        }
    }
}
