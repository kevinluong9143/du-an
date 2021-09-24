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

namespace ECOPharma2013
{
    public partial class frmNhanVienEdit : Form
    {
        frmMain frmMain;
        string sNVID;
        public frmNhanVienEdit(frmMain _frmMain)
        {
            InitializeComponent();
            frmMain = _frmMain;
        }

        private void btnNVDong_Click(object sender, EventArgs e)
        {
            frmMain.frmNhanVienEditisOpen_ = false;
            frmMain.BangNhanVienCanSua_ = null;
            frmMain.MaNhanVienCanSua_ = "";
            this.Close();
        }

        public void RefreshForm()
        {
            frmMain.BangNhanVienCanSua_ = null;
            frmMain.MaNhanVienCanSua_ = null;
            this.txtMaNV.Text = "";
            this.txtCMND.Text = "";
            this.txtDTDD.Text = "";
            this.txtEmail.Text = "";
            this.txtGhiChu.Text = "";
            this.txtMST.Text = "";
            this.txtSoThe.Text = "";
            this.txtTenNV.Text = "";
            this.cboBoPhan.SelectedIndex = -1;
            this.cboGioiTinh.SelectedIndex = -1;
            this.dtpkNgayCap.Value = DateTime.Now;
            this.dtpkNgaySinh.Value = DateTime.Now;
            this.ckKhongDung.Checked = false;
            this.txtMaDinhDanh.Text = "";
            this.statusTB.Text = "";
            txtTenNV.Focus();
        }


        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void txtSoThe_KeyPress(object sender, KeyPressEventArgs e)
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

        void LayGioiTinhVaoCombobox()
        {
            CSQLGioiTinh gt = new CSQLGioiTinh();
            cboGioiTinh.ValueMember = "GTID";
            cboGioiTinh.DisplayMember = "GioiTinh";
            cboGioiTinh.DataSource = gt.LayGioiTinh();
            cboGioiTinh.SelectedIndex = -1;
        }
        void LayThanhPhoVaoCombobox()
        {
            CSQLThanhPho tp = new CSQLThanhPho();
            cboNoiCap.DisplayMember = "TenTP";
            cboNoiCap.ValueMember = "TPID";
            cboNoiCap.DataSource = tp.LayThongTinThanhPho(frmMain.IsXemTatCa_);
            cboNoiCap.SelectedIndex = -1;
        }
        void LayBoPhanVaoCombobox()
        {
            CSQLBoPhan bp = new CSQLBoPhan();
            cboBoPhan.DisplayMember = "TenBP";
            cboBoPhan.ValueMember = "MaBP";
            cboBoPhan.DataSource = bp.LoadDSBoPhanLenCombobox();
            cboBoPhan.SelectedIndex = -1;
        }
        private void frmNhanVienEdit_Load(object sender, EventArgs e)
        {
            LayGioiTinhVaoCombobox();
            LayThanhPhoVaoCombobox();
            LayBoPhanVaoCombobox();

            DienDLVaoForm();
        }

        private void DienDLVaoForm()
        {
            if (frmMain.BangNhanVienCanSua_ != null && frmMain.BangNhanVienCanSua_.Rows.Count > 0)
            {
                sNVID = frmMain.BangNhanVienCanSua_.Rows[0]["NVID"].ToString();
                this.txtMaNV.Text = frmMain.BangNhanVienCanSua_.Rows[0]["MaNV"].ToString();
                this.txtCMND.Text = frmMain.BangNhanVienCanSua_.Rows[0]["CMND"].ToString();
                this.txtDTDD.Text = frmMain.BangNhanVienCanSua_.Rows[0]["DTDD"].ToString();
                this.txtEmail.Text = frmMain.BangNhanVienCanSua_.Rows[0]["Email"].ToString();
                this.txtGhiChu.Text = frmMain.BangNhanVienCanSua_.Rows[0]["GhiChu"].ToString();
                this.txtMaDinhDanh.Text = frmMain.BangNhanVienCanSua_.Rows[0]["MaDinhDanh"].ToString();
                this.txtMST.Text = frmMain.BangNhanVienCanSua_.Rows[0]["MST"].ToString();
                this.txtSoThe.Text = frmMain.BangNhanVienCanSua_.Rows[0]["SoThe"].ToString();
                this.txtTenNV.Text = frmMain.BangNhanVienCanSua_.Rows[0]["HoTen"].ToString();
                this.cboBoPhan.SelectedValue = frmMain.BangNhanVienCanSua_.Rows[0]["BPID"].ToString();
                this.cboGioiTinh.SelectedValue = frmMain.BangNhanVienCanSua_.Rows[0]["GTID"].ToString();
                this.cboNoiCap.SelectedValue = frmMain.BangNhanVienCanSua_.Rows[0]["NoiCap"].ToString();
                this.ckKhongDung.Checked = (bool)frmMain.BangNhanVienCanSua_.Rows[0]["KhongSuDung"];
                if (frmMain.BangNhanVienCanSua_.Rows[0]["NgayCap"] != null && frmMain.BangNhanVienCanSua_.Rows[0]["NgayCap"].ToString().CompareTo("")>0)
                {
                    dtpkNgayCap.Value = (DateTime)frmMain.BangNhanVienCanSua_.Rows[0]["NgayCap"];
                }
                if (frmMain.BangNhanVienCanSua_.Rows[0]["NgaySinh"] != null && frmMain.BangNhanVienCanSua_.Rows[0]["NgaySinh"].ToString().CompareTo("") > 0)
                {
                    dtpkNgaySinh.Value = (DateTime)frmMain.BangNhanVienCanSua_.Rows[0]["NgaySinh"];
                }
            }
        }

        private void btnNVThemMoi_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
        bool KT_Trung = false;
        private void btnNVLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(frmMain.fNhanVien.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                txtMaNV_Leave(sender, e);
                txtCMND_Leave(sender, e);
                txtSoThe_Leave(sender, e);
                txtMST_Leave(sender, e);
                txtMaDinhDanh_Leave(sender, e);
                if (KT_Trung == false)
                {
                    if (KiemTraNull() != false)
                    {
                        if (this.frmMain.MaNhanVienCanSua_ != null && this.frmMain.MaNhanVienCanSua_.CompareTo("") > 0)
                        {
                            //Sửa nhân viên
                            CSQLNhanVien nv = new CSQLNhanVien();
                            LayDLNVTuForm(nv);
                            int kq = nv.SuaNhanVien(nv);
                            if (kq > 0)
                            {
                                frmMain.fNhanVien.rgvNhanVien.DataSource = nv.LayThongTinNhanVienLenLuoi(frmMain.IsXemTatCa_);
                                statusTB.Text = "Sửa thành công!";
                                txtTenNV.Focus();
                            }
                            else
                            {
                                statusTB.Text = "Sửa thất bại!";
                            }
                        }
                        else
                        {

                            //Thêm nhân viên
                            CSQLNhanVien nv = new CSQLNhanVien();
                            LayDLNVTuForm(nv);
                            CSQLNhanVien qlnv = new CSQLNhanVien();
                            string nvid = qlnv.ThemNhanVien(nv);
                           
                            if (nvid.Length > 0 && nvid != null)
                            {
                                if (frmMain.DSNhanVienIsOpen == true)
                                {
                                    frmMain.MaNhanVienCanSua_ = nvid;
                                    sNVID = nvid;
                                    txtMaNV.Text = qlnv.LayThongTinNhanVienTheoMa(nvid).Rows[0]["MaNV"].ToString();
                                    frmMain.fNhanVien.rgvNhanVien.DataSource = nv.LayThongTinNhanVienLenLuoi(frmMain.IsXemTatCa_);
                                }
                                statusTB.Text = "Thêm thành công!";
                                txtTenNV.Focus();
                            }
                            else
                            {
                                statusTB.Text = "Thêm nhân viên thất bại!";
                            }

                        }
                    }
                }
                else
                {
                    KT_Trung = false;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void LayDLNVTuForm(CSQLNhanVien nv)
        {
            CXuLyChuoi xlc = new CXuLyChuoi();
            //nv.SNVID = this.txtMaNV.Text.Trim();
            if (sNVID != null && sNVID.Length == 0)
            {
                nv.SNVID = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                nv.SNVID = sNVID;
            }
            if (cboBoPhan.SelectedValue != null)
            {
                nv.SBPID = this.cboBoPhan.SelectedValue.ToString();
            }
            else
            {
                nv.SBPID = "00000000-0000-0000-0000-000000000000";
            }
            nv.SSoThe = this.txtSoThe.Text.Trim();
            nv.SMST = this.txtMST.Text.Trim();
            nv.SHoTen =xlc.TrimTen(this.txtTenNV.Text);
            if (cboGioiTinh.SelectedValue != null)
            {
                nv.SGioiTinhID = this.cboGioiTinh.SelectedValue.ToString();
            }
            else
            {
                nv.SGioiTinhID = "2";
            }

            if (dtpkNgaySinh.Value.Date != DateTime.Now.Date)
            {
                nv.DNgaySinh = dtpkNgaySinh.Value;
            }
            else
                nv.DNgaySinh = DateTime.Parse("1/1/1774");
            nv.SCMND = txtCMND.Text.Trim();
            if (dtpkNgayCap.Value.Date != DateTime.Now.Date)
            {
                nv.DNgayCap = dtpkNgayCap.Value;
            }
            else
                nv.DNgayCap = DateTime.Parse("1/1/1774");

            if (cboNoiCap.SelectedValue != null)
            {
                nv.SNoiCap = cboNoiCap.SelectedValue.ToString();
            }
            else
            {
                nv.SNoiCap = "00000000-0000-0000-0000-000000000000";
            }
            nv.SDTDD = txtDTDD.Text.Trim();
            nv.SEmail = txtEmail.Text.Trim();
            nv.SGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
            nv.BKhongSuDung = ckKhongDung.Checked;
            nv.DLastUD = DateTime.Now;
            nv.DNgayTao = DateTime.Now;
            nv.SUserID = CStaticBien.SmaTaiKhoan;
            nv.SMaNV = txtMaNV.Text.Trim();
            nv.SMaDinhDanh = txtMaDinhDanh.Text.Trim();
        }

        private void txtMaDinhDanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (IsEmailValid(txtEmail.Text) == true)
            {
                lblEmailTB.Text = "Email hợp lệ!";
            }
            else
            {
                lblEmailTB.Text = "Email không hợp lệ!";
                txtEmail.Focus();
            }
        }
        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                //if (emailaddress != null && emailaddress.Length > 0)
                if (emailaddress.Length > 0)
                {
                    MailAddress m = new MailAddress(emailaddress);
                    return true;
                }
                else
                    return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void frmNhanVienEdit_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode == Keys.Escape)
            {
                frmMain.frmNhanVienEditisOpen_ = false;
                frmMain.BangNhanVienCanSua_ = null;
                frmMain.MaNhanVienCanSua_ = "";
                this.Close();
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnNVThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnNVLuu_Click(sender, e);
            }
        }

        private void txtTenNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                frmMain.frmNhanVienEditisOpen_ = false;
                frmMain.BangNhanVienCanSua_ = null;
                frmMain.MaNhanVienCanSua_ = "";
                this.Close();
            }
        }

        bool KiemTraNull()
        {
            bool kq;
            if (txtTenNV.Text.Length == 0)
            {
                txtTenNV.Focus();
                //statusTB.Text = "Bạn phải nhập thông tin ['Tên nhân viên']!";
                MessageBox.Show("['Họ Tên'] không được để trống. Vui lòng kiềm tra lại!");
                return false;
            }
            else kq = true;

            //if (dtpkNgaySinh.Value == DateTime.Now)
            //{
            //    dtpkNgaySinh.Focus();
            //    //statusTB.Text = "Bạn phải chọn thông tin ['Ngày sinh'] cho phù hợp!";
            //    MessageBox.Show("Bạn phải chọn thông tin ['Ngày sinh'] cho phù hợp!");
            //    return false;
            //}
            //else kq = true;

            if (cboGioiTinh.SelectedIndex == -1)
            {
                cboGioiTinh.Focus();
                //statusTB.Text = "Bạn phải chọn thông tin ['Giới tính'] cho phù hợp!";
                MessageBox.Show("Bạn phải chọn thông tin ['Giới tính'] cho phù hợp!");
                return false;
            }
            else kq = true;

            //if (txtCMND.Text.Length == 0)
            //{
            //    txtCMND.Focus();
            //    //statusTB.Text = "Bạn phải nhập thông tin ['Số CMND']!";
            //    MessageBox.Show("Bạn phải nhập thông tin ['Số CMND']!");
            //    return false;
            //}
            //else kq = true;

            //if (dtpkNgayCap.Value.Date == DateTime.Now.Date)
            //{
            //    dtpkNgayCap.Focus();
            //    //statusTB.Text = "Bạn phải chọn thông tin ['Ngày cấp'] cho phù hợp!";
            //    MessageBox.Show("Bạn phải chọn thông tin ['Ngày cấp'] cho phù hợp!");
            //    return false;
            //}
            //else kq = true;

            //if (cboNoiCap.SelectedIndex == -1)
            //{
            //    cboNoiCap.Focus();
            //    //statusTB.Text = "Bạn phải chọn thông tin ['Nơi cấp'] cho phù hợp!";
            //    MessageBox.Show("Bạn phải chọn thông tin ['Nơi cấp'] cho phù hợp!");
            //    return false;
            //}
            //else kq = true;


            if (cboBoPhan.SelectedIndex == -1)
            {
                cboBoPhan.Focus();
                //statusTB.Text = "Bạn phải chọn thông tin ['Bộ phận'] cho phù hợp!";
                MessageBox.Show("Bạn phải chọn thông tin ['Bộ phận'] cho phù hợp!");
                return false;
            }
            else kq = true;

            return kq;
        }

        private void btnThemNhanhNoiCap_Click(object sender, EventArgs e)
        {
            try {
                frmMain.fThanhPhoEdit_ = new frmThanhPhoEdit(frmMain);
                frmMain.frmThanhPhoEditisOpen_ = true;
                CSQLThanhPho tp = new CSQLThanhPho();
                this.cboNoiCap.DataSource = tp.LayThongTinThanhPho(frmMain.IsXemTatCa_);
                frmMain.fThanhPhoEdit_.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnThemBoPhan_Click(object sender, EventArgs e)
        {
            try 
            {
                frmMain.fBoPhanEdit_ = new frmBoPhanEdit(frmMain);
                frmMain.frmBoPhanEditisOpen_ = true;
                CSQLBoPhan bp = new CSQLBoPhan();
                this.cboBoPhan.DataSource = bp.LoadDSBoPhanLenCombobox();
                frmMain.fBoPhanEdit_.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        string MaNVidNull = "00000000-0000-0000-0000-000000000000";
        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            CSQLNhanVien nv_ = new CSQLNhanVien();
            txtMaNV.Text = txtMaNV.Text.ToUpper();
            if (txtMaNV.Text != "")
            {
                if (this.frmMain.MaNhanVienCanSua_ != null && this.frmMain.MaNhanVienCanSua_.CompareTo("") > 0)
                {
                    if (nv_.KiemTraTrungMaNV(txtMaNV.Text, frmMain.MaNhanVienCanSua_) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Nhân Viên đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtMaNV.Focus();
                    }
                }
                else
                {
                    if (nv_.KiemTraTrungMaNV(txtMaNV.Text, MaNVidNull) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Nhân Viên đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtMaNV.Focus();
                    }
                }
            }
        }

        private void txtSoThe_Leave(object sender, EventArgs e)
        {
            CSQLNhanVien nv_ = new CSQLNhanVien();
            txtSoThe.Text = txtSoThe.Text.ToUpper();
            if (txtSoThe.Text != "")
            {
                if (this.frmMain.MaNhanVienCanSua_ != null && this.frmMain.MaNhanVienCanSua_.CompareTo("") > 0)
                {
                    if (nv_.KiemTraTrungSoThe(txtSoThe.Text, frmMain.MaNhanVienCanSua_) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Thẻ đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtSoThe.Focus();
                    }
                }
                else
                {
                    if (nv_.KiemTraTrungSoThe(txtSoThe.Text, MaNVidNull) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Thẻ đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtSoThe.Focus();
                    }
                }
            }
        }

        private void txtMST_Leave(object sender, EventArgs e)
        {
            CSQLNhanVien nv_ = new CSQLNhanVien();
            txtMST.Text = txtMST.Text.ToUpper();
            if (txtMST.Text != "")
            {
                if (this.frmMain.MaNhanVienCanSua_ != null && this.frmMain.MaNhanVienCanSua_.CompareTo("") > 0)
                {
                    if (nv_.KiemTraTrungMST(txtMST.Text, frmMain.MaNhanVienCanSua_) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Số Thuế đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtMST.Focus();
                    }
                }
                else
                {
                    if (nv_.KiemTraTrungMST(txtMST.Text, MaNVidNull) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Số Thuế đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtMST.Focus();
                    }
                }
            }
        }

        private void txtMaDinhDanh_Leave(object sender, EventArgs e)
        {
            CSQLNhanVien nv_ = new CSQLNhanVien();
            txtMaDinhDanh.Text = txtMaDinhDanh.Text.ToUpper();
            if (txtMaDinhDanh.Text != "")
            {
                if (this.frmMain.MaNhanVienCanSua_ != null && this.frmMain.MaNhanVienCanSua_.CompareTo("") > 0)
                {
                    if (nv_.KiemTraTrungMaDinhDanh(txtMaDinhDanh.Text, frmMain.MaNhanVienCanSua_) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Định Danh đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtMaDinhDanh.Focus();
                    }
                }
                else
                {
                    if (nv_.KiemTraTrungMaDinhDanh(txtMaDinhDanh.Text, MaNVidNull) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Định Danh đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtMaDinhDanh.Focus();
                    }
                }
            }
        }

        private void txtCMND_Leave(object sender, EventArgs e)
        {
            CSQLNhanVien nv_ = new CSQLNhanVien();
            txtCMND.Text = txtCMND.Text.ToUpper();
            if (txtCMND.Text != "")
            {
                if (this.frmMain.MaNhanVienCanSua_ != null && this.frmMain.MaNhanVienCanSua_.CompareTo("") > 0)
                {
                    if (nv_.KiemTraTrungCMND(txtCMND.Text, frmMain.MaNhanVienCanSua_) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Số CMND đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtCMND.Focus();
                    }
                }
                else
                {
                    if (nv_.KiemTraTrungCMND(txtCMND.Text, MaNVidNull) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Số CMND đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtCMND.Focus();
                    }
                }
            }
        }
    }
}
