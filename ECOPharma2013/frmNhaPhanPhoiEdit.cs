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
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace ECOPharma2013
{
    public partial class frmNhaPhanPhoiEdit : Form
    {
        frmMain fmain;
        public frmNhaPhanPhoiEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void btnNPPDong_Click(object sender, EventArgs e)
        {
            fmain.BangNhaPhanPhoiCanSua_ = null;
            fmain.MaNhaPhanPhoiCanSua_ = "";
            fmain.frmNhaPhanPhoiEditisOpen_ = false;
            this.Close();
        }

        private void btnNPPThemMoi_Click(object sender, EventArgs e)
        {
            try 
            {
                this.txtTenNPP.Text = "";
                this.txtMST.Text = "";
                this.txtDTDD.Text = "";
                this.txtDiaChi.Text = "";
                this.txtEmailNLH.Text = "";
                this.txtEmailNPP.Text = "";
                this.txtFax.Text = "";
                this.txtGhiChu.Text = "";
                this.txtNLH.Text = "";
                this.txtTel.Text = "";
                this.txtTenNPP.Text = "";
                this.cboQuan.SelectedIndex = -1;
                this.cboTP.SelectedIndex = -1;
                fmain.MaNhaPhanPhoiCanSua_ = "";
                fmain.BangNhaPhanPhoiCanSua_ = null;
                txtTenNPP.Focus();
            }
            catch (Exception ex){throw ex;}
        }
        CSQLNPP LayTTNPPTuForm()
        {
            CXuLyChuoi xlc = new CXuLyChuoi();
            CSQLNPP npp = new CSQLNPP();
            npp.STenNPP = xlc.TrimTen(this.txtTenNPP.Text);
            npp.SMST = this.txtMST.Text.Trim();
            npp.SDTDD = this.txtDTDD.Text.Trim();
            npp.SDiaChi = xlc.TrimTen(this.txtDiaChi.Text);
            npp.SPICEmail = this.txtEmailNLH.Text.Trim();
            npp.SNPPEmail = this.txtEmailNPP.Text.Trim();
            npp.SFax = this.txtFax.Text.Trim();
            npp.SGhiChu = xlc.TrimDoanVan(this.txtGhiChu.Text);
            npp.SPIC = xlc.TrimTen(this.txtNLH.Text);
            npp.STel = this.txtTel.Text.Trim();
            if (this.cboQuan.SelectedValue != null)
                npp.SQuanID = this.cboQuan.SelectedValue.ToString();
            else
                npp.SQuanID = "00000000-0000-0000-0000-000000000000";
            if (this.cboTP.SelectedValue != null)
                npp.STPID = this.cboTP.SelectedValue.ToString();
            else
                npp.STPID = "00000000-0000-0000-0000-000000000000";
            npp.SNPPID = fmain.MaNhaPhanPhoiCanSua_;
            npp.DNgayTao = DateTime.Now;
            npp.DLastUD = DateTime.Now;
            npp.SUserID = CStaticBien.SmaTaiKhoan;
            npp.BKhongSuDung = ckKhongDung.Checked;
            return npp;
        }
        void DuaTTNPPRaForm()
        {
            if (fmain.BangNhaPhanPhoiCanSua_ != null && fmain.BangNhaPhanPhoiCanSua_.Rows.Count > 0)
            {
                this.txtMaNPP.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["MaNPP"].ToString();
                this.txtTenNPP.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["TenNPP"].ToString();
                this.txtMST.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["MST"].ToString();
                this.txtDTDD.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["DTDD"].ToString();
                this.txtDiaChi.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["DiaChi"].ToString();
                this.txtEmailNLH.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["PICEmail"].ToString();
                this.txtEmailNPP.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["NPPEmail"].ToString();
                this.txtFax.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["Fax"].ToString();
                this.txtGhiChu.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["GhiChu"].ToString();
                this.txtNLH.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["PIC"].ToString();
                this.txtTel.Text = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["Tel"].ToString();
                this.cboQuan.SelectedValue = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["QuanID"].ToString();
                this.cboTP.SelectedValue = fmain.BangNhaPhanPhoiCanSua_.Rows[0]["TPID"].ToString();
                ckKhongDung.Checked = (bool)fmain.BangNhaPhanPhoiCanSua_.Rows[0]["KhongSuDung"];
            }
        }

        bool KiemTraNull()
        {
            if (txtTenNPP.Text.Length == 0)
            {
                txtTenNPP.Focus();
                MessageBox.Show("['Tên NPP'] không được để trống. Vui lòng kiềm tra lại!");
                return false;
            }
            else return true;
        }
        private void btnNPPLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNhaPhanPhoi.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (KiemTraNull() == true)
            {
                if (fmain.MaNhaPhanPhoiCanSua_ != null && fmain.MaNhaPhanPhoiCanSua_.Length > 0)
                {
                    //Sửa nhà phân phối
                    CSQLNPP npp = new CSQLNPP();
                    npp = LayTTNPPTuForm();
                    int kq = npp.SuaNPP(npp);
                    if (kq == 1)
                    {
                        if (fmain.DSNPPIsOpen == true)
                        {
                            fmain.fNhaPhanPhoi.rgvNPP.DataSource = npp.LayNPPLenLuoi(fmain.IsXemTatCa_);
                            statusTB.Text = "Sửa thành công!";
                            txtTenNPP.Focus();
                        }
                        else
                            statusTB.Text = "Sửa thành công!";
                    }
                    else
                        statusTB.Text = "Sửa thất bại!";
                }
                else
                {
                    //Thêm nhà phân phối
                    CSQLNPP npp = new CSQLNPP();
                    npp = LayTTNPPTuForm();
                    string kq = npp.ThemNPP(npp);
                    if (kq.Length > 0)
                    {
                        fmain.MaNhaPhanPhoiCanSua_ = kq;
                        fmain.fNhaPhanPhoi.rgvNPP.DataSource = npp.LayNPPLenLuoi(fmain.IsXemTatCa_);
                        statusTB.Text = "Thêm thành công!";
                        txtTenNPP.Focus();
                    }
                    else
                    {
                        statusTB.Text = "Thêm thất bại!";
                    }
                }
            }
        }

        private void frmNhaPhanPhoiEdit_Load(object sender, EventArgs e)
        {
            LayThanhPhoVaoCombobox();
            LayQuanVaoCombobox();
            DuaTTNPPRaForm();
        }

        void LayThanhPhoVaoCombobox()
        {
            CSQLThanhPho tp = new CSQLThanhPho();
            cboTP.DisplayMember = "TenTP";
            cboTP.ValueMember = "TPID";
            cboTP.DataSource = tp.LayThongTinThanhPho(fmain.IsXemTatCa_);
            cboTP.SelectedIndex = -1;
        }
        void LayQuanVaoCombobox()
        {
            CSQLQuan quan = new CSQLQuan();
            cboQuan.DisplayMember = "TenQ";
            cboQuan.ValueMember = "QuanID";
            cboQuan.DataSource = quan.LayDanhSachQuanLenLuoi(fmain.IsXemTatCa_);
            cboQuan.SelectedIndex = -1;
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void txtDTDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void txtEmailNPP_Leave(object sender, EventArgs e)
        {
            if (IsEmailValid(txtEmailNPP.Text) == true)
            {
                lblEmailNPPTB.Text = "";
            }
            else
            {
                lblEmailNPPTB.Text = "Email không hợp lệ!";
                txtEmailNPP.Focus();
            }
        }

        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                if (emailaddress != null && emailaddress.Length > 0)
                {
                    MailAddress m = new MailAddress(emailaddress);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtEmailNLH_Leave(object sender, EventArgs e)
        {
            if (IsEmailValid(txtEmailNLH.Text) == true)
            {
                lblEmailNLHTB.Text = "";
            }
            else
            {
                lblEmailNLHTB.Text = "Email không hợp lệ!";
                txtEmailNLH.Focus();
            }
        }

        private void frmNhaPhanPhoiEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                fmain.BangNhaPhanPhoiCanSua_ = null;
                fmain.MaNhaPhanPhoiCanSua_ = "";
                fmain.frmNhaPhanPhoiEditisOpen_ = false;
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnNPPThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnNPPLuu_Click(sender, e);
            }
        }

        private void btnThemNhanhQuan_Click(object sender, EventArgs e)
        {
            try
            {
                fmain.fQuanEdit_ = new frmQuanEdit(fmain);
                fmain.frmQuanEditisOpen_ = true;
                CSQLQuan q = new CSQLQuan();
                this.cboQuan.DataSource = q.LayDanhSachQuanLenLuoi(fmain.IsXemTatCa_);
                cboQuan.SelectedIndex = -1;
                fmain.fQuanEdit_.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnThemNhanhThanhPho_Click(object sender, EventArgs e)
        {
            try
            {
                fmain.fThanhPhoEdit_ = new frmThanhPhoEdit(fmain);
                fmain.frmThanhPhoEditisOpen_ = true;
                CSQLThanhPho tp = new CSQLThanhPho();
                this.cboTP.DataSource = tp.LayThongTinThanhPho(fmain.IsXemTatCa_);
                cboTP.SelectedIndex = -1;
                fmain.fThanhPhoEdit_.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtMST_Leave(object sender, EventArgs e)
        {
            CSQLNPP npp_ = new CSQLNPP();
            txtMST.Text = txtMST.Text.ToUpper();
            if (txtMST.Text != "")
            {
                if (npp_.KiemTraTrungMST(txtMST.Text) == 1)
                {
                    MessageBox.Show("Mã Số Thuế đã tồn tại! Vui lòng Kiểm tra lại.");
                }
            }

        }
    }
}
