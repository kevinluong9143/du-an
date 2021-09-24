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
    public partial class frmQuanEdit : Form
    {
        frmMain _frmMain;
        public frmQuanEdit()
        {
            InitializeComponent();
        }
        public frmQuanEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void btnQuanDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmQuanEditisOpen_ = false;
            this._frmMain.MaQuanCanSua_ = "";
            this._frmMain.BangQuanCanSua_ = null;
            this.txtGhiChu.Text = "";
            this.txtTenQuan.Text = "";
            this.ckKhongDung.Checked = false;
            this.Close();
        }

        private void frmQuanEdit_Load(object sender, EventArgs e)
        {
            if (_frmMain.BangQuanCanSua_ != null && _frmMain.BangQuanCanSua_.Rows.Count>0)
            {
                CSQLQuan quan = new CSQLQuan();
                quan.SMaQuan = _frmMain.BangQuanCanSua_.Rows[0]["QuanID"].ToString();
                quan.STenQuan = _frmMain.BangQuanCanSua_.Rows[0]["TenQ"].ToString();
                quan.SGhiChu = _frmMain.BangQuanCanSua_.Rows[0]["GhiChu"].ToString();
                quan.BKhongSuDung = (bool)_frmMain.BangQuanCanSua_.Rows[0]["KhongSuDung"];
                this.txtTenQuan.Text = quan.STenQuan;
                this.txtGhiChu.Text = quan.SGhiChu;
                this.ckKhongDung.Checked = quan.BKhongSuDung;
            }
        }

        private void btnQuanThemMoi_Click(object sender, EventArgs e)
        {
            this._frmMain.MaQuanCanSua_ = null;
            this._frmMain.fQuanEdit_.txtTenQuan.Text = "";
            this._frmMain.fQuanEdit_.txtGhiChu.Text = "";
            this._frmMain.fQuanEdit_.ckKhongDung.Checked = false;
            txtTenQuan.Focus();
        }

        private void btnQuanLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fQuan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (KiemTraNull() == true)
            {
                if (this._frmMain.MaQuanCanSua_ != null && this._frmMain.MaQuanCanSua_.CompareTo("") > 0)
                {
                    CXuLyChuoi xlchuoi = new CXuLyChuoi();
                    CSQLQuan quan = new CSQLQuan();
                    quan.SMaQuan = this._frmMain.MaQuanCanSua_;
                    quan.STenQuan = xlchuoi.TrimTen(this.txtTenQuan.Text);
                    quan.SGhiChu = xlchuoi.TrimDoanVan(this.txtGhiChu.Text);
                    quan.BKhongSuDung = this.ckKhongDung.Checked;
                    int kq = quan.SuaThongTinQuan(quan);
                    if (kq == 1)
                    {
                        if (this._frmMain.DSQuanIsOpen == true)
                        {
                            _frmMain.fQuan.rgvQuan.DataSource = quan.LayDanhSachQuanLenLuoi(_frmMain.IsXemTatCa_);
                            toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                            txtTenQuan.Focus();
                        }
                        else
                        {
                            toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                            txtTenQuan.Focus();
                        }
                    }
                    else
                    {
                        toolStripStatusThongBaoLoi.Text = "Sửa thông tin thất bại.";
                    }

                }
                else
                {
                    CXuLyChuoi xlchuoi = new CXuLyChuoi();
                    CSQLQuan quan = new CSQLQuan();
                    quan.STenQuan = xlchuoi.TrimTen(txtTenQuan.Text);
                    quan.SGhiChu =xlchuoi.TrimDoanVan(txtGhiChu.Text);
                    quan.BKhongSuDung = ckKhongDung.Checked;
                    string maquantrave = quan.ThemMoiQuan(quan);
                    if (maquantrave != null)
                    {
                        if (this._frmMain.DSQuanIsOpen == true)
                        {
                            this._frmMain.MaQuanCanSua_ = maquantrave;
                            this._frmMain.fQuan.rgvQuan.DataSource = quan.LayDanhSachQuanLenLuoi(_frmMain.IsXemTatCa_);
                            toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                            txtTenQuan.Focus();
                        }
                        else
                        {
                            toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                            txtTenQuan.Focus();
                        }
                    }
                    else
                    {
                        toolStripStatusThongBaoLoi.Text = "Thêm thất bại.";
                    }
                }
            }
        }

        private void frmQuanEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _frmMain.frmQuanEditisOpen_ = false;
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnQuanThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnQuanLuu_Click(sender, e);
            }
        }

        bool KiemTraNull()
        {
            if (txtTenQuan.Text.Length == 0)
            {
                txtTenQuan.Focus();
                MessageBox.Show("['Tên quận'] không được để trống. Vui lòng kiểm tra lại!");
                return false;
            }
            else return true;
        }
    }
}
