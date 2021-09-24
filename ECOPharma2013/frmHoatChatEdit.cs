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
    public partial class frmHoatChatEdit : Form
    {
        frmMain fmain;
        public frmHoatChatEdit(frmMain _frmain)
        {
            InitializeComponent();
            fmain = _frmain;
        }

        private void frmHoatChatEdit_Load(object sender, EventArgs e)
        {
            if (fmain.BangHoatChatCanSua_ != null && fmain.BangHoatChatCanSua_.Rows.Count > 0  )
            {
                txtHoatChat.Text = fmain.BangHoatChatCanSua_.Rows[0]["TenHC"].ToString();
                txtGhiChu.Text = fmain.BangHoatChatCanSua_.Rows[0]["GhiChu"].ToString();
                ckKhongDung.Checked =(bool)fmain.BangHoatChatCanSua_.Rows[0]["KhongSuDung"];
            }
        }

        private void btnHCLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fHoatChat.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try 
            {
                if (KiemTraGiaTriNull() ==true)
                {
                    if (fmain.MaHoatChatCanSua_ != null && fmain.MaHoatChatCanSua_.Length > 0)
                    {
                        //sửa hoạt chất
                        CXuLyChuoi xlc = new CXuLyChuoi();
                        CSQLHoatChat hc = new CSQLHoatChat();
                        hc.SHCID = fmain.MaHoatChatCanSua_;
                        hc.STenHC = xlc.TrimTen(txtHoatChat.Text);
                        hc.SGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
                        hc.BKhongSuDung = ckKhongDung.Checked;
                        hc.DLastUD = DateTime.Now;
                        hc.DNgayTao = DateTime.Now;
                        hc.SUserID = CStaticBien.SmaTaiKhoan;

                        int kq = hc.SuaHoatChat(hc);
                        if (kq > 0)
                        {
                            fmain.fHoatChat.rgvHoatChat.DataSource = hc.LayHoatChatLenLuoi(fmain.IsXemTatCa_);
                            statusTB.Text = "Sửa hoạt chất thành công!";
                            txtHoatChat.Focus();
                        }
                        else
                        {
                            statusTB.Text = "Sửa hoạt chất thất bại!";
                        }

                    }
                    else
                    {
                        //thêm hoạt chất
                        CXuLyChuoi xlc = new CXuLyChuoi();
                        CSQLHoatChat hc = new CSQLHoatChat();
                        hc.SHCID = "";
                        hc.STenHC = xlc.TrimTen(txtHoatChat.Text);
                        hc.SGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
                        hc.BKhongSuDung = ckKhongDung.Checked;
                        hc.DLastUD = DateTime.Now;
                        hc.DNgayTao = DateTime.Now;
                        hc.SUserID = CStaticBien.SmaTaiKhoan;

                        string kq = hc.ThemHoatChat(hc);
                        if (kq.Length > 0)
                        {
                            if (fmain.DSHoatChatIsOpen == true)
                            {
                                fmain.MaHoatChatCanSua_ = kq;
                                fmain.fHoatChat.rgvHoatChat.DataSource = hc.LayHoatChatLenLuoi(fmain.IsXemTatCa_);
                            }
                            statusTB.Text = "Thêm hoạt chất thành công!";
                            txtHoatChat.Focus();
                        }
                        else
                        {
                            statusTB.Text = "Thêm hoạt chất thất bại!";
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnHCDong_Click(object sender, EventArgs e)
        {
            fmain.MaHoatChatCanSua_ = "";
            fmain.BangHoatChatCanSua_ = null;
            fmain.frmHoatChatEditisOpen_ = false;
            this.Close();
        }

        private void frmHoatChatEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                fmain.MaHoatChatCanSua_ = "";
                fmain.BangHoatChatCanSua_ = null;
                fmain.frmHoatChatEditisOpen_ = false;
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnHCThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnHCLuu_Click(sender, e);
            }

        }
        bool KiemTraGiaTriNull()
        {
            bool kq = false;
            if (txtHoatChat.Text.Length == 0)
            {
                //statusTB.Text = "Bạn phải bắt buộc phải điền vào ['Tên hoạt chất']";
                txtHoatChat.Focus();
                MessageBox.Show("['Hoạt chất'] không được để trống. Vui lòng kiềm tra lại!");
                kq = false;
            }
            else
            {
                kq = true;
            }

            return kq;
        }

        private void btnHCThemMoi_Click(object sender, EventArgs e)
        {
            txtHoatChat.Text = "";
            txtGhiChu.Text = "";
            ckKhongDung.Checked = false;
            fmain.MaHoatChatCanSua_ = "";
            fmain.BangHoatChatCanSua_ = null;
            txtHoatChat.Focus();
        }
    }
}
