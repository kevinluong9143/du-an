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
    public partial class frmDBCEdit : Form
    {
        //private frmMain _fMain;
        CSQLQuyenTruyCap LopCSQLQuyenTruyCap;
        frmMain _frmMain;
        public frmDBCEdit()
        {
            InitializeComponent();
        }

        public frmDBCEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        private void frmDBCEdit_Load(object sender, EventArgs e)
        {
            if (_frmMain.BangDBCCanSua_ != null && _frmMain.BangDBCCanSua_.Rows.Count > 0)
            {
                CSQLDBC dbc = new CSQLDBC();

                dbc.SMaDBC = _frmMain.BangDBCCanSua_.Rows[0]["DBCID"].ToString();
                dbc.STenDBC = _frmMain.BangDBCCanSua_.Rows[0]["TenDBC"].ToString();
                dbc.SGhiChu = _frmMain.BangDBCCanSua_.Rows[0]["GhiChu"].ToString();
                dbc.BKhongSuDung = (bool)_frmMain.BangDBCCanSua_.Rows[0]["KhongSuDung"];
                this.txtTenDBC.Text = dbc.STenDBC;
                this.txtGhiChu.Text = dbc.SGhiChu;
                this.ckKhongDung.Checked = dbc.BKhongSuDung;
            }
        }
        

        private void btnDBCThemMoi_Click(object sender, EventArgs e)
        {
            txtTenDBC.Focus();
            this._frmMain.MaDBCCanSua_ = null;
            this._frmMain.fDBCEdit_.txtTenDBC.Text = "";
            this._frmMain.fDBCEdit_.txtGhiChu.Text = "";
            this._frmMain.fDBCEdit_.ckKhongDung.Checked = false;
        }

        private bool KiemTraQuyenChiTiet(string frmName)
        {

            LopCSQLQuyenTruyCap = new CSQLQuyenTruyCap();
            DataTable BangQuyenChiTiet = new DataTable();
            BangQuyenChiTiet = LopCSQLQuyenTruyCap.QuyenChiTiet(CStaticBien.sNhomTaiKhoan, frmName);
            for (int i = 0; i < BangQuyenChiTiet.Rows.Count; i++)
            {
                return bool.Parse(BangQuyenChiTiet.Rows[0]["Them_Sua"].ToString());
            }

            return false;
        }

        private void btnDBCLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fDBC.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            if (txtTenDBC.Text == "")
            {
                MessageBox.Show("Tên Dạng Bào Chế Không Được Bỏ Trống. Xin vui lòng kiểm tra lại .", "Xác nhận");
                return;
            }
            if (this._frmMain.MaDBCCanSua_ != null && this._frmMain.MaDBCCanSua_.CompareTo("") > 0)
            {
                CXuLyChuoi xlc = new CXuLyChuoi();
                CSQLDBC dbc = new CSQLDBC();
                dbc.SMaDBC = this._frmMain.MaDBCCanSua_;
                dbc.STenDBC = xlc.TrimTen(txtTenDBC.Text);
                dbc.SGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
                dbc.DLastUD = DateTime.Now;
                dbc.DNgayTao = DateTime.Now;
                dbc.SUserID = CStaticBien.SmaTaiKhoan;
                dbc.BKhongSuDung = this.ckKhongDung.Checked;

                int kq = dbc.SuaThongTinDBC(dbc);
                if (kq == 1)
                {
                    _frmMain.fDBC.rgvDBC.DataSource = dbc.LayDanhSachDBCLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                    txtTenDBC.Focus();
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Sửa thông tin thất bại.";
                }
            }
            else
            {
                CSQLDBC dbc = new CSQLDBC();
                dbc.STenDBC = txtTenDBC.Text;
                dbc.SGhiChu = txtGhiChu.Text;
                dbc.BKhongSuDung = ckKhongDung.Checked;
                dbc.DNgayTao = DateTime.Now;
                dbc.DLastUD = DateTime.Now;
                dbc.SUserID = CStaticBien.SmaTaiKhoan;

                string maquantrave = dbc.ThemMoiDBC(dbc);
                if (maquantrave != null)
                {
                    this._frmMain.MaDBCCanSua_ = maquantrave;
                    this._frmMain.fDBC.rgvDBC.DataSource = dbc.LayDanhSachDBCLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                    //this.txtGhiChu.Text = "";
                    //this.txtTenDBC.Text = "";
                    //this.ckKhongDung.Checked = false;
                    //this._frmMain.MaDBCCanSua_ = null;
                    txtTenDBC.Focus();
                }
                else
                {
                    toolStripStatusThongBaoLoi.Text = "Thêm thất bại.";
                }
            }
        }

        private void btnDBCDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmDBCEditisOpen_ = false;
            this.txtGhiChu.Text = "";
            this.txtTenDBC.Text = "";
            this.ckKhongDung.Checked = false;
            this.Close();
        }

        private void frmDBCEdit_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Escape)
                {
                    _frmMain.frmDBCEditisOpen_ = false;
                    this.Close();
                }
                if (e.Control && e.KeyCode == Keys.T)
                {
                    btnDBCThemMoi_Click(sender, e);
                }

                if (e.Control && e.KeyCode == Keys.L)
                {
                    btnDBCLuu_Click(sender, e);
                }
        }
        
    }
}
