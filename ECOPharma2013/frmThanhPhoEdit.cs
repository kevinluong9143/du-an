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
    public partial class frmThanhPhoEdit : Form
    {
        frmMain frmMain;
        public frmThanhPhoEdit(frmMain _frmMain)
        {
            InitializeComponent();
            frmMain = _frmMain;
        }

        private void btnTPDong_Click(object sender, EventArgs e)
        {
            frmMain.frmThanhPhoEditisOpen_ = false;
            frmMain.BangThanhPhoCanSua_ = null;
            frmMain.MaThanhPhoCanSua_ = "";
            this.Close();

        }

        private void btnTPThemMoi_Click(object sender, EventArgs e)
        {
            frmMain.BangThanhPhoCanSua_ = null;
            frmMain.MaThanhPhoCanSua_ = "";
            this.txtGhiChu.Text = "";
            this.txtTenTP.Text = "";
            this.ckKhongDung.Checked = false;
            txtTenTP.Focus();
        }

        private void btnTPLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(frmMain.fThanhPho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (KiemTraNull() == true)
            {
                if (this.frmMain.MaThanhPhoCanSua_ != null && this.frmMain.MaThanhPhoCanSua_.CompareTo("") > 0)
                {
                    //Sửa thông tin thành phố
                    CXuLyChuoi xlc = new CXuLyChuoi();
                    CSQLThanhPho tp = new CSQLThanhPho(frmMain.MaThanhPhoCanSua_, xlc.TrimTen(this.txtTenTP.Text),xlc.TrimDoanVan(this.txtGhiChu.Text), this.ckKhongDung.Checked);
                    int kq = tp.SuaThanhPho(tp);
                    if (kq > 0)
                    {
                        //frmMain.BangThanhPhoCanSua_ = null;
                        //frmMain.MaThanhPhoCanSua_ = "";
                        //this.txtGhiChu.Text = "";
                        //this.txtTenTP.Text = "";
                        //this.ckKhongDung.Checked = false;
                        if (frmMain.DSThanhPhoIsOpen == true)
                        {
                            this.statusTB.Text = "Sửa thông tin thành phố thành công!";
                            frmMain.fThanhPho.rgvThanhPho.DataSource = tp.LayThongTinThanhPho(frmMain.IsXemTatCa_);
                            txtTenTP.Focus();
                        }
                        else
                        {
                            this.statusTB.Text = "Sửa thông tin thành phố thành công!";
                            txtTenTP.Focus();
                        }
                    }
                    else
                        this.statusTB.Text = "Sửa thông tin thất bại!";
                }
                else
                {
                    //Thêm thông tin thành phố
                    CXuLyChuoi xlc = new CXuLyChuoi();
                    CSQLThanhPho tp = new CSQLThanhPho(null, xlc.TrimTen(this.txtTenTP.Text), xlc.TrimDoanVan(this.txtGhiChu.Text), this.ckKhongDung.Checked);
                    string matp = tp.ThemThanhPho(tp);
                    frmMain.MaThanhPhoCanSua_ = matp;
                    if (matp.CompareTo("") > 0 && matp != null)
                    {
                        if (frmMain.DSThanhPhoIsOpen == true)
                        {
                            //frmMain.BangThanhPhoCanSua_ = null;
                            //frmMain.MaThanhPhoCanSua_ = "";
                            //this.txtGhiChu.Text = "";
                            //this.txtTenTP.Text = "";
                            //this.ckKhongDung.Checked = false;
                            this.statusTB.Text = "Thêm thành phố mã: ['" + matp + "'] thành công!";
                            frmMain.fThanhPho.rgvThanhPho.DataSource = tp.LayThongTinThanhPho(frmMain.IsXemTatCa_);
                            txtTenTP.Focus();
                        }
                        else
                        {
                            this.statusTB.Text = "Thêm thành phố mã: ['" + matp + "'] thành công!";
                            txtTenTP.Focus();
                        }
                    }
                    else
                        this.statusTB.Text = "Thêm thất bại!";
                }
            }
        }

        private void frmThanhPhoEdit_Load(object sender, EventArgs e)
        {
            if (frmMain.BangThanhPhoCanSua_ != null && frmMain.BangThanhPhoCanSua_.Rows.Count > 0)
            {
                CSQLThanhPho qltp = new CSQLThanhPho();
                qltp.SMaThanhPho = frmMain.BangThanhPhoCanSua_.Rows[0]["TPID"].ToString();
                qltp.STenThanhPho = frmMain.BangThanhPhoCanSua_.Rows[0]["TenTP"].ToString();
                qltp.SGhiChu = frmMain.BangThanhPhoCanSua_.Rows[0]["GhiChu"].ToString();
                qltp.BKhongSuDung = (bool)frmMain.BangThanhPhoCanSua_.Rows[0]["KhongSuDung"];

                this.txtTenTP.Text = qltp.STenThanhPho;
                this.txtGhiChu.Text = qltp.SGhiChu;
                this.ckKhongDung.Checked = qltp.BKhongSuDung;
            }

        }

        private void frmThanhPhoEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                frmMain.frmThanhPhoEditisOpen_ = false;
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnTPThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnTPLuu_Click(sender, e);
            }
        }

        bool KiemTraNull()
        {
            if (txtTenTP.Text.Length == 0)
            {
                txtTenTP.Focus();
                MessageBox.Show("['Tên thành phố'] không được để trống. Vui lòng kiềm tra lại!");
                return false;
            }
            else
                return true;
        }
    }
}
