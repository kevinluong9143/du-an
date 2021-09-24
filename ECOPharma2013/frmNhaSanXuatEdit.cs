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
using System.Net.Mail;
using Telerik.WinControls.Data;
using Telerik.WinControls;

namespace ECOPharma2013
{
    public partial class frmNhaSanXuatEdit : Form
    {
        frmMain fmain;
        public frmNhaSanXuatEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void btnNSXDong_Click(object sender, EventArgs e)
        {
            fmain.BangNhaSanXuatCanSua_ = null;
            fmain.MaNhaSanXuatCanSua_ = "";
            fmain.frmNhaSanXuatEditisOpen_ = false;
            this.Close();
        }

        private void btnNSXThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtTenNSX.Text = "";
                this.txtDTDD.Text = "";
                this.txtDiaChi.Text = "";
                this.txtEmailNLH.Text = "";
                this.txtEmailNSX.Text = "";
                this.txtFax.Text = "";
                this.txtGhiChu.Text = "";
                this.txtNLH.Text = "";
                this.txtTel.Text = "";
                this.txtTenNSX.Text = "";
                this.cboQuan.SelectedIndex = -1;
                this.cboThanhPho.SelectedIndex = -1;
                cboQuocGia.SelectedIndex = -1;
                fmain.MaNhaSanXuatCanSua_ = "";
                fmain.BangNhaSanXuatCanSua_ = null;
                txtTenNSX.Focus();
            }
            catch (Exception ex) { throw ex; }
        }

        CSQLNSX LayTTNSXTuForm()
        {
            CXuLyChuoi xlc = new CXuLyChuoi();
            CSQLNSX nsx = new CSQLNSX();
            nsx.STenNSX = xlc.TrimTen(this.txtTenNSX.Text);
            nsx.SDTDD = this.txtDTDD.Text.Trim();
            nsx.SDiaChi = xlc.TrimTen(this.txtDiaChi.Text);
            nsx.SPICEmail = this.txtEmailNLH.Text.Trim();
            nsx.SNSXEmail = this.txtEmailNSX.Text.Trim();
            nsx.SFax = this.txtFax.Text.Trim();
            nsx.SGhiChu = xlc.TrimDoanVan(this.txtGhiChu.Text);
            nsx.SPIC = xlc.TrimDoanVan(this.txtNLH.Text);
            nsx.STel = this.txtTel.Text.Trim();
            if (this.cboQuan.SelectedValue != null)
                nsx.SQuanID = this.cboQuan.SelectedValue.ToString();
            else
                nsx.SQuanID = "00000000-0000-0000-0000-000000000000";
            if (this.cboThanhPho.SelectedValue != null)
                nsx.STPID = this.cboThanhPho.SelectedValue.ToString();
            else
                nsx.STPID = "00000000-0000-0000-0000-000000000000";
            nsx.SNSXID = fmain.MaNhaSanXuatCanSua_;
            nsx.DNgayTao = DateTime.Now;
            nsx.DLastUD = DateTime.Now;
            nsx.SUserID = CStaticBien.SmaTaiKhoan;
            if (this.cboQuocGia.SelectedValue != null)
                nsx.SQGid = this.cboQuocGia.SelectedValue.ToString();
            else
                nsx.SQGid = "00000000-0000-0000-0000-000000000000";
            nsx.BKhongSuDung = ckKhongDung.Checked;
            return nsx;
        }

        void DuaTTNSXRaForm()
        {
            if (fmain.BangNhaSanXuatCanSua_ != null && fmain.BangNhaSanXuatCanSua_.Rows.Count > 0)
            {
                this.txtTenNSX.Text = fmain.BangNhaSanXuatCanSua_.Rows[0]["TenNSX"].ToString();
                this.txtDTDD.Text = fmain.BangNhaSanXuatCanSua_.Rows[0]["DTDD"].ToString();
                this.txtDiaChi.Text = fmain.BangNhaSanXuatCanSua_.Rows[0]["DiaChi"].ToString();
                this.txtEmailNLH.Text = fmain.BangNhaSanXuatCanSua_.Rows[0]["PICEmail"].ToString();
                this.txtEmailNSX.Text = fmain.BangNhaSanXuatCanSua_.Rows[0]["NSXEmail"].ToString();
                this.txtFax.Text = fmain.BangNhaSanXuatCanSua_.Rows[0]["Fax"].ToString();
                this.txtGhiChu.Text = fmain.BangNhaSanXuatCanSua_.Rows[0]["GhiChu"].ToString();
                this.txtNLH.Text = fmain.BangNhaSanXuatCanSua_.Rows[0]["PIC"].ToString();
                this.txtTel.Text = fmain.BangNhaSanXuatCanSua_.Rows[0]["Tel"].ToString();
                this.cboQuan.SelectedValue = fmain.BangNhaSanXuatCanSua_.Rows[0]["QuanID"].ToString();
                this.cboThanhPho.SelectedValue = fmain.BangNhaSanXuatCanSua_.Rows[0]["TPID"].ToString();
                this.cboQuocGia.SelectedValue = fmain.BangNhaSanXuatCanSua_.Rows[0]["QGID"].ToString();
                ckKhongDung.Checked = (bool)fmain.BangNhaSanXuatCanSua_.Rows[0]["KhongSuDung"];
            }
        }

        private void btnNSXLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNhaSanXuat.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (KiemTraNull() == true)
            {
                if (fmain.MaNhaSanXuatCanSua_ != null && fmain.MaNhaSanXuatCanSua_.Length > 0)
                {
                    //Sửa nhà sản xuất
                    CSQLNSX NSX = new CSQLNSX();
                    NSX = LayTTNSXTuForm();
                    string kq = NSX.SuaNSX(NSX);
                    if (kq.Equals("OK"))
                    {
                        fmain.fNhaSanXuat.rgvNSX.DataSource = NSX.LayNSXLenLuoi(fmain.IsXemTatCa_);
                        statusTB.Text = "Sửa thành công!";
                        txtTenNSX.Focus();
                    }
                    else
                        statusTB.Text = "Sửa thất bại: " + kq;
                }
                else
                {
                    //Thêm nhà sản xuất
                    CSQLNSX NSX = new CSQLNSX();
                    NSX = LayTTNSXTuForm();
                    string kq = NSX.ThemNSX(NSX);
                    if (kq.Length > 0)
                    {
                        if (fmain.DSNSXIsOpen == true)
                        {
                            fmain.MaNhaSanXuatCanSua_ = kq;
                            fmain.fNhaSanXuat.rgvNSX.DataSource = NSX.LayNSXLenLuoi(fmain.IsXemTatCa_);
                            statusTB.Text = "Thêm thành công!";
                            txtTenNSX.Focus();
                        }
                        else
                            statusTB.Text = "Thêm thành công!";
                    }
                    else
                    {
                        statusTB.Text = "Thêm thất bại!";
                    }
                }
            }
        }

        private void frmNhaSanXuatEdit_Load(object sender, EventArgs e)
        {
            LayThanhPhoVaoCombobox();
            LayQuanVaoCombobox();
            LayQuocGiaVaoCombobox();
            DuaTTNSXRaForm();
        }
        void LayThanhPhoVaoCombobox()
        {
            CSQLThanhPho tp = new CSQLThanhPho();
            cboThanhPho.DisplayMember = "TenTP";
            cboThanhPho.ValueMember = "TPID";
            cboThanhPho.DataSource = tp.LayThongTinThanhPho(fmain.IsXemTatCa_);
            cboThanhPho.SelectedIndex = -1;
        }
        void LayQuanVaoCombobox()
        {
            CSQLQuan quan = new CSQLQuan();
            cboQuan.DisplayMember = "TenQ";
            cboQuan.ValueMember = "QuanID";
            cboQuan.DataSource = quan.LayDanhSachQuanLenLuoi(fmain.IsXemTatCa_);
            cboQuan.SelectedIndex = -1;
        }
        void LayQuocGiaVaoCombobox()
        {
            CSQLQuocGia qg_ = new CSQLQuocGia();
            cboQuocGia.DisplayMember = "TenQuocGia";
            cboQuocGia.ValueMember = "QGID";
            cboQuocGia.DataSource = qg_.LayDSQuocGiaLenLuoi(fmain.IsXemTatCa_);
            cboQuocGia.SelectedIndex = -1;
        }
        private void txtEmailNSX_Leave(object sender, EventArgs e)
        {
            if (txtEmailNLH.Text.Length == 0)
            {
                statusTB.Text = "Bạn chưa nhập email!";
                return;
            }
            if (IsEmailValid(txtEmailNSX.Text) == false)
            {
                //lblEmailTB.Text = "Bạn chưa nhập email hay email không hợp lệ!";
                statusTB.Text = "Email không hợp lệ!";
            }
            //else
            //{
            //    lblEmailTB.Text = "Bạn chưa nhập email hay email không hợp lệ!";
            //    txtEmailNSX.Focus();
            //}
        }

        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                if (emailaddress != null && emailaddress.Length>0)
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
            if (txtEmailNLH.Text.Length == 0)
            {
                statusTB.Text = "Bạn chưa nhập email!";
                return;
            }
            if (IsEmailValid(txtEmailNLH.Text) == true)
            {
                statusTB.Text = "Email không hợp lệ!";
            }
            //else
            //{
            //    lblEmailNLHTB.Text = "Bạn chưa nhập email hay email không hợp lệ!";
            //    txtEmailNLH.Focus();
            //}
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == 8)
                { e.Handled = false;
                return;
                }
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void txtDTDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void frmNhaSanXuatEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                fmain.BangNhaSanXuatCanSua_ = null;
                fmain.MaNhaSanXuatCanSua_ = "";
                fmain.frmNhaSanXuatEditisOpen_ = false;
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnNSXThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnNSXLuu_Click(sender, e);
            }
        }
        
        bool KiemTraNull()
        {
            if (txtTenNSX.Text.Length == 0)
            {
                txtTenNSX.Focus();
                MessageBox.Show("['Tên NSX'] không được để trống. Vui lòng kiềm tra lại!");
                return false;
            }
            else
                return true;
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
                this.cboThanhPho.DataSource = tp.LayThongTinThanhPho(fmain.IsXemTatCa_);
                cboThanhPho.SelectedIndex = -1;
                fmain.fThanhPhoEdit_.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnThemNhanhQuocGia_Click(object sender, EventArgs e)
        {
            try
            {
                fmain.fQuocGiaEdit_ = new frmQuocGiaEdit(fmain);
                fmain.frmQuocGiaEditisOpen_ = true;
                CSQLQuocGia qg_ = new CSQLQuocGia();
                this.cboQuocGia.DataSource = qg_.LayDSQuocGiaLenLuoi(fmain.IsXemTatCa_);
                cboQuocGia.SelectedIndex = -1;
                fmain.fQuocGiaEdit_.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
