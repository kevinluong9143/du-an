using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmCauHinhHeThong : Form
    {
        frmMain _frmMain;

        public frmCauHinhHeThong()
        {
            InitializeComponent();
            ReLoadXemKhoDacBiet();
        }
        public frmCauHinhHeThong(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
            ReLoadXemKhoDacBiet();
        }
        string MaCauHinhHeThongCanXoa_;
        string maquantrave;
        private void DocTTServerLenForm()
        {
            CSQLCauHinhHeThong LopCHHT = new CSQLCauHinhHeThong();
            CMaHoa LopMaHoa = new CMaHoa();
            DataTable BangTTServer = new DataTable();
            BangTTServer = LopCHHT.LayThongTinServerTongCty();
            if (BangTTServer!= null && BangTTServer.Rows.Count > 0)
            {
                txtServerName.Text = LopMaHoa.GiaiMa(BangTTServer.Rows[0]["ServerPath"].ToString());
                txtUserName.Text =LopMaHoa.GiaiMa(BangTTServer.Rows[0]["UserData"].ToString());
                txtPass.Text = LopMaHoa.GiaiMa(BangTTServer.Rows[0]["PassData"].ToString());
                txtData.Text = LopMaHoa.GiaiMa(BangTTServer.Rows[0]["Data"].ToString());
            }
            else
                toolStripStatusThongBaoLoi.Text = "Chưa có thông tin Server Tổng trong Database";
        }

        private void frmCauHinhHeThong_Load(object sender, EventArgs e)
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();

            txtMaChiNhanh.Enabled = false;
            txtTenChiNhanh.Enabled = false;
            LayNhaThuocVaoCombobox();
            LayBoPhanVaoCombobox();
            DataTable chht_ = chht.LayDanhSachCauHinhHeThong();
            if (chht_ != null && chht_.Rows.Count > 0)
            {
                txtMaChiNhanh.Text = chht_.Rows[0]["TTCNid"].ToString();
                txtTenChiNhanh.Text = chht_.Rows[0]["TenChiNhanh"].ToString();
                txtTienQuy.Text = chht_.Rows[0]["TienQuy"].ToString();
                cboBoPhan.SelectedValue = chht_.Rows[0]["MaBP"].ToString();
                MaCauHinhHeThongCanXoa_ = txtMaChiNhanh.Text;
            }

            //Lay thông tin server tổng
            DocTTServerLenForm();
        }
        void LayBoPhanVaoCombobox()
        {
            CSQLBoPhan bophan_ = new CSQLBoPhan();
            cboBoPhan.DataSource = bophan_.LoadDSBoPhanLenCombobox();
            cboBoPhan.DisplayMember = "TenBP";
            cboBoPhan.ValueMember = "MaBP";
            cboBoPhan.SelectedIndex = -1;
        }
        void LayNhaThuocVaoCombobox()
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            cboTenChiNhanh.DataSource = nhathuoc.LayDanhSachNhaThuocLenLuoi(_frmMain.IsXemTatCa_);
            cboTenChiNhanh.DisplayMember = "TenNT";
            cboTenChiNhanh.ValueMember = "NTID";
            cboTenChiNhanh.SelectedIndex = -1;
        }

        private void cboTenChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenChiNhanh.Text = cboTenChiNhanh.Text;
            if (cboTenChiNhanh.SelectedValue != null)
            {
                txtMaChiNhanh.Text = cboTenChiNhanh.SelectedValue.ToString();
            }
            else
            {
                txtMaChiNhanh.Text = "";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            DataTable chht_ = chht.LayDanhSachCauHinhHeThong();
            if (chht_ != null && chht_.Rows.Count > 0)
            {
                int kq = chht.XoaThongTinCauHinhHeThong(MaCauHinhHeThongCanXoa_);
                chht.SMaTTCN = txtMaChiNhanh.Text;
                chht.STenChiNhanh = txtTenChiNhanh.Text;
                if (txtTienQuy.Text == "")
                {
                    chht.FTienQuy = 0;
                }
                else
                {
                    chht.FTienQuy = decimal.Parse(txtTienQuy.Text);
                }
                chht.SBoPhan = cboBoPhan.SelectedValue.ToString();
                try
                {
                    chht.IMucTonKho = int.Parse(txtMucTon.Text);
                    }
                catch { MessageBox.Show("Không được nhập chữ!"); txtMucTon.Focus();}
                try{
                    chht.IChuKyDatHang = int.Parse(txtChuKy.Text);}
                catch { MessageBox.Show("Không được nhập chữ!"); txtChuKy.Focus();}
                
                 maquantrave = chht.ThemMoiCauHinhHeThong(chht);
                if (maquantrave != null)
                {
                    MaCauHinhHeThongCanXoa_ = txtMaChiNhanh.Text;
                    toolStripStatusThongBaoLoi.Text = "Sửa thành công.";
                }
            }
            else
            {
                chht.SMaTTCN = txtMaChiNhanh.Text;
                chht.STenChiNhanh = txtTenChiNhanh.Text;
                if (txtTienQuy.Text == "")
                {
                    chht.FTienQuy = 0;
                }
                else
                {
                    chht.FTienQuy = decimal.Parse(txtTienQuy.Text);
                }
                chht.SBoPhan = cboBoPhan.SelectedValue.ToString();
                 maquantrave = chht.ThemMoiCauHinhHeThong(chht);
                if (maquantrave != null)
                {
                    MaCauHinhHeThongCanXoa_ = txtMaChiNhanh.Text;
                    toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                }
            }
        }

        private void txtTienQuy_TextChanged(object sender, EventArgs e)
        {
            if (txtTienQuy.Text.Length > 0)
            {
                txtTienQuy.Text = Convert.ToDecimal(txtTienQuy.Text).ToString("#,###");
                txtTienQuy.Select(txtTienQuy.TextLength, 0);
            }
        }

        private void txtTienQuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private string LuuTTServer()
        {
            
            CStaticBien._RmtServer = txtServerName.Text.Trim();
            CStaticBien._RmtUserName = txtUserName.Text.Trim();
            CStaticBien._RmtPassword = txtPass.Text.Trim();
            CStaticBien._RmtDatabase = txtData.Text.Trim();

            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            return chht.SuaThongTinServerTongCty(CStaticBien._RmtServer, CStaticBien._RmtUserName, CStaticBien._RmtPassword, CStaticBien._RmtDatabase);
        }

        private void tbtnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fCauHinhHeThong.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (LuuTTServer() == "")
            {
                toolStripStatusThongBaoLoi.Text = "Lưu thành công !";

            }
            else
                toolStripStatusThongBaoLoi.Text = "Lưu KHÔNG thành công !";
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            try
            {
                CStaticBien._RmtServer = txtServerName.Text.Trim();
                CStaticBien._RmtUserName = txtUserName.Text.Trim();
                CStaticBien._RmtPassword = txtPass.Text.Trim();
                CStaticBien._RmtDatabase = txtData.Text.Trim();
                
                SqlConnection RmtConn;
                CDuLieuRemote LopDLRmt = new CDuLieuRemote();
                RmtConn = LopDLRmt.RmtConnString();
                RmtConn.Open();
                if (RmtConn.State == ConnectionState.Open)
                {
                    RmtConn.Close();
                }
                RmtConn.Dispose();
                MessageBox.Show("Kết nối thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveKhoDacBiet_Click(object sender, EventArgs e)
        {
            try
            {
                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                // DungLV thêm mới field đơn trả hàng lỗi 
                // chht.CapNhatXemKhoDacBiet(cbxKhoDacBiet.Checked);
                chht.CapNhatXemKhoDacBiet(cbxKhoDacBiet.Checked, cbIsDonTraHang.Checked);
                // DungLV thêm mới field đơn trả hàng lỗi 
                ReLoadXemKhoDacBiet();

                MessageBox.Show("Cập nhật thành công !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ReLoadXemKhoDacBiet()
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            cbxKhoDacBiet.Checked = chht.KiemTraTrangThaiXemKhoDacBiet();
            // DungLV thêm mới field đơn trả hàng lỗi 
            cbIsDonTraHang.Checked = chht.KiemTraTrangThaiDonTraLoi();
            // DungLV thêm mới field đơn trả hàng lỗi 
        }

    }
}
