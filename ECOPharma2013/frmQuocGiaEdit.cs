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
    public partial class frmQuocGiaEdit : Form
    {
        frmMain _frmMain;
        public frmQuocGiaEdit()
        {
            InitializeComponent();
        }
        public frmQuocGiaEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            _frmMain.MaQuocGiaCanSua_ = null;
            txtTenQG.Text = "";
            txtGhiChu.Text = "";
            ckKhongDung.Checked = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fQuocGia.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            
            if (txtTenQG.Text == "")
            {
                MessageBox.Show("Tên Quốc Gia Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                return;
            }
            if (this._frmMain.MaQuocGiaCanSua_ != null && this._frmMain.MaQuocGiaCanSua_.CompareTo("") > 0)
            {
                CSQLQuocGia qg_ = new CSQLQuocGia();
                qg_.SMaQuocGia = _frmMain.MaQuocGiaCanSua_;
                qg_.STenQuocGia = txtTenQG.Text;
                qg_.SGhiChu = txtGhiChu.Text;
                qg_.BKhongSuDung = this.ckKhongDung.Checked;

                int kq = qg_.SuaThongTinQuocGia(qg_);
                if (kq == 1)
                {
                    _frmMain.fQuocGia.rgvDSQuocGia.DataSource = qg_.LayDSQuocGiaLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                    txtTenQG.Focus();
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Sửa thông tin thất bại.";
                }
            }
            else
            {
                CSQLQuocGia qg_ = new CSQLQuocGia();
                qg_.STenQuocGia = txtTenQG.Text;
                qg_.SGhiChu = txtGhiChu.Text;
                qg_.BKhongSuDung = ckKhongDung.Checked;

                string maquantrave = qg_.ThemMoiQuocGia(qg_);
                if (maquantrave != null)
                {
                    this._frmMain.MaQuocGiaCanSua_ = maquantrave;
                    this._frmMain.fQuocGia.rgvDSQuocGia.DataSource = qg_.LayDSQuocGiaLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                    txtTenQG.Focus();
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Thêm thất bại.";
                }
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmQuocGiaEditisOpen_ = false;
            this.Close();
        }

        private void frmQuocGiaEdit_Load(object sender, EventArgs e)
        {
            if (_frmMain.BangQuocGiaCanSua_ != null && _frmMain.BangQuocGiaCanSua_.Rows.Count > 0)
            {
                CSQLQuocGia qg_ = new CSQLQuocGia();

                qg_.SMaQuocGia = _frmMain.BangQuocGiaCanSua_.Rows[0]["QGID"].ToString();
                qg_.STenQuocGia = _frmMain.BangQuocGiaCanSua_.Rows[0]["TenQuocGia"].ToString();
                qg_.SGhiChu = _frmMain.BangQuocGiaCanSua_.Rows[0]["GhiChu"].ToString();
                qg_.BKhongSuDung = (bool)_frmMain.BangQuocGiaCanSua_.Rows[0]["KhongSuDung"];
                this.txtTenQG.Text = qg_.STenQuocGia;
                this.txtGhiChu.Text = qg_.SGhiChu;
                this.ckKhongDung.Checked = qg_.BKhongSuDung;
            }
        }

        private void frmQuocGiaEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnDong_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnLuu_Click(sender, e);
            }
        }
    }
}
