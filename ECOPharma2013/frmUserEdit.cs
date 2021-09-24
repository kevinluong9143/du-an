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
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using Telerik.WinControls;

namespace ECOPharma2013
{
    public partial class frmUserEdit : Form
    {
        frmMain _frmMain;
        public frmUserEdit()
        {
            InitializeComponent();
        }
        public frmUserEdit(frmMain fMain)
        {
            InitializeComponent();
            _frmMain = fMain;
        }

        private void frmUserEdit_Load(object sender, EventArgs e)
        {
            LayTTNhomNguoiDung();
            LayDSNVLenMultiColumnCombobox();
            if (_frmMain.BangUserCanSua_ != null && _frmMain.BangUserCanSua_.Rows.Count > 0)
            {
                radMultiColumnComboBoxTenNV.SelectedValue = new Guid(_frmMain.BangUserCanSua_.Rows[0]["NVID"].ToString());
                lblMaNV.Text = _frmMain.BangUserCanSua_.Rows[0]["MaNV"].ToString();
                txtTenDN.Text = _frmMain.BangUserCanSua_.Rows[0]["UserName"].ToString();
                txtMK1.Text = _frmMain.BangUserCanSua_.Rows[0]["Pass"].ToString();
                txtMK2.Text = _frmMain.BangUserCanSua_.Rows[0]["Pass"].ToString();
                cboNhom.SelectedValue = _frmMain.BangUserCanSua_.Rows[0]["NhomNDid"].ToString();
                ckKhongDung.Checked = (bool)_frmMain.BangUserCanSua_.Rows[0]["KhongSuDung"];
            }
        }

        void LayDSNVLenMultiColumnCombobox()
        {
            CSQLNhanVien nv = new CSQLNhanVien();
            radMultiColumnComboBoxTenNV.ValueMember = "NVID";
            radMultiColumnComboBoxTenNV.DisplayMember = "HoTen";
            radMultiColumnComboBoxTenNV.DataSource = nv.LoadDSNVLenMComboBox();
            radMultiColumnComboBoxTenNV.SelectedIndex = -1;

            radMultiColumnComboBoxTenNV.EditorControl.Columns["NVID"].IsVisible = false;
            radMultiColumnComboBoxTenNV.EditorControl.Columns["HoTen"].Width = 250;
            radMultiColumnComboBoxTenNV.EditorControl.Columns["MaNV"].Width = 65;
            radMultiColumnComboBoxTenNV.EditorControl.TableElement.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            radMultiColumnComboBoxTenNV.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            radMultiColumnComboBoxTenNV.AutoFilter = true;
            FilterDescriptor descriptor12 = new FilterDescriptor(this.radMultiColumnComboBoxTenNV.DisplayMember, FilterOperator.Contains, string.Empty);
            this.radMultiColumnComboBoxTenNV.EditorControl.FilterDescriptors.Add(descriptor12);
            radMultiColumnComboBoxTenNV.DropDownStyle = RadDropDownStyle.DropDown;
            radMultiColumnComboBoxTenNV.MultiColumnComboBoxElement.DropDownWidth = 315;
            radMultiColumnComboBoxTenNV.MultiColumnComboBoxElement.DropDownHeight = 300;
        }

        void LayTTNhomNguoiDung()
        {
            CSQLNhomNguoiDung nndung_ = new CSQLNhomNguoiDung();
            cboNhom.DisplayMember = "TenNhom";
            cboNhom.ValueMember = "NhomNDid";
            cboNhom.DataSource = nndung_.LoadDSNhomNguoiDungLenCombobox();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            _frmMain.MaUserCanSua_ = null;
            txtTenDN.Text = "";
            lblMaNV.Text = "";
            radMultiColumnComboBoxTenNV.SelectedIndex = -1;
            txtMK1.Text = "";
            txtMK2.Text = "";
            cboNhom.SelectedIndex = -1;
            ckKhongDung.Checked = false;
            LayTTNhomNguoiDung();
            radMultiColumnComboBoxTenNV.Focus();
        }

         bool KiemTraNull()
        {
            if (radMultiColumnComboBoxTenNV.SelectedValue == null)
            {
                statusTB.Text = "Thông báo: Bạn chưa chọn Nhân Viên!";
                radMultiColumnComboBoxTenNV.Focus();
                return true;
            }
            if (cboNhom.SelectedValue == null)
            {
                statusTB.Text = "Thông báo: Bạn chưa chọn Nhóm Người Dùng!";
                cboNhom.Focus();
                return true;
            }
            if (txtTenDN.Text.Length == 0)
            {
                txtTenDN.Focus();
                statusTB.Text = "Thông báo: Chưa có tên Đăng Nhập";
                return true;
            }
            if (txtMK1.Text.Length != txtMK2.Text.Length)
            {
                txtMK2.Focus();
                statusTB.Text = "Thông báo: Mật Khẩu không giống nhau";
                return true;
            }
            
            return false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraNull() == false)
            {
                CSQLUser user_ = new CSQLUser();
                if (this._frmMain.MaUserCanSua_ != null && this._frmMain.MaUserCanSua_.CompareTo("") > 0)
                {
                    CXuLyChuoi xlchuoi = new CXuLyChuoi();
                    user_.SUserID = this._frmMain.MaUserCanSua_;
                    user_.SNVID = radMultiColumnComboBoxTenNV.SelectedValue.ToString();
                    user_.SUserName = xlchuoi.TrimTen(this.txtTenDN.Text);
                    user_.SPass = txtMK2.Text;
                    user_.SNhomND = cboNhom.SelectedValue.ToString();
                    user_.BKhongSuDung = this.ckKhongDung.Checked;
                    int kq = user_.SuaThongTin(user_);
                    if (kq == 1)
                    {
                        _frmMain.fUser.rgvUser.DataSource = user_.LayDSUserLenLuoi(_frmMain.IsXemTatCa_);
                        statusTB.Text = "Sửa thành công!";
                        txtTenDN.Focus();
                    }
                    else
                    {
                        statusTB.Text = "Sửa thông tin thất bại.";
                    }

                }
                else
                {
                    
                    CXuLyChuoi xlchuoi = new CXuLyChuoi();
                    user_.SNVID = radMultiColumnComboBoxTenNV.SelectedValue.ToString();
                    user_.SUserName = xlchuoi.TrimTen(this.txtTenDN.Text);
                    user_.SPass = txtMK2.Text;
                    user_.SNhomND = cboNhom.SelectedValue.ToString();
                    user_.BKhongSuDung = this.ckKhongDung.Checked;
                    string maquantrave = user_.ThemMoi(user_);
                    if (maquantrave != null)
                    {
                        this._frmMain.MaUserCanSua_ = maquantrave;
                        _frmMain.fUser.rgvUser.DataSource = user_.LayDSUserLenLuoi(_frmMain.IsXemTatCa_);
                        statusTB.Text = "Thêm thành công.";
                        txtTenDN.Focus();
                    }
                    else
                    {
                        statusTB.Text = "Thêm thất bại.";
                    }
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            _frmMain.BangUserCanSua_ = null;
            _frmMain.MaUserCanSua_ = "";
            _frmMain.frmUserEditisOpen_ = false;
            this.Close();
        }

        private void radMultiColumnComboBoxTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radMultiColumnComboBoxTenNV.SelectedValue != null)
            {
                lblMaNV.Text = radMultiColumnComboBoxTenNV.EditorControl.CurrentRow.Cells["MaNV"].Value.ToString();
            }
        }

        private void frmUserEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnLuu_Click(sender, e);
            }
        }

        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {
            CSQLUser user_ = new CSQLUser();
            if (user_.KiemTraTrungUser(txtTenDN.Text) > 0)
            {
                txtTenDN.Focus();
                statusTB.Text = "Thông báo: Tên đăng nhập này đã tồn tại.";
                return;
            }
        }
    }
}
