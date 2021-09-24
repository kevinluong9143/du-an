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
    public partial class frmNhomSPEdit : Form
    {
        private frmMain _fMain;
        CSQLNhomSP LopSQLNhomSP;
        public frmNhomSPEdit(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        private void frmNhomSPEdit_Load(object sender, EventArgs e)
        {
            if (_fMain.BangNhomSPCanSua_ != null && _fMain.BangNhomSPCanSua_.Rows.Count > 0)
            {
                LopSQLNhomSP = new CSQLNhomSP();
                LopSQLNhomSP.sMaNhomSP = _fMain.BangNhomSPCanSua_.Rows[0]["NSPID"].ToString();
                LopSQLNhomSP.sTenNhomSP = _fMain.BangNhomSPCanSua_.Rows[0]["TenNSP"].ToString();
                LopSQLNhomSP.sGhiChu = _fMain.BangNhomSPCanSua_.Rows[0]["GhiChu"].ToString();
                LopSQLNhomSP.bIsKhongDung = (bool)_fMain.BangNhomSPCanSua_.Rows[0]["KhongSuDung"];
                if (LopSQLNhomSP != null)
                {
                    txtTenNSP.Text = LopSQLNhomSP.sTenNhomSP;
                    txtGhiChu.Text = LopSQLNhomSP.sGhiChu;
                    ckKhongDung.Checked = LopSQLNhomSP.bIsKhongDung;
                }
            }

        }

        public bool DuLieuIsNull()
        {
            if (LopSQLNhomSP.sTenNhomSP == "")
            {
                statusTB.Text = "Chưa có tên Nhóm Sản Phẩm";
                return true;
            }

            return false;
        }

        public void LayDuLieutuForm()
        {
            CXuLyChuoi xlc = new CXuLyChuoi();
            LopSQLNhomSP = new CSQLNhomSP();
            LopSQLNhomSP.sTenNhomSP = xlc.TrimTen(txtTenNSP.Text);
            LopSQLNhomSP.sGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
            LopSQLNhomSP.bIsKhongDung = ckKhongDung.Checked;
            LopSQLNhomSP.sUserID = CStaticBien.SmaTaiKhoan;

            if (_fMain.IsSuaNhomSP == true)
            {
                LopSQLNhomSP.sMaNhomSP = _fMain.MaNhomSPCanSua_;
            }
        }

        private void btnNSPDong_Click(object sender, EventArgs e)
        {
            _fMain.frmNhomSPEditisOpen_ = false;
            _fMain.IsSuaNhomSP = false;
            this.Close();
        }

        private void btnNSPLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_fMain.fNhomSP_.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            LayDuLieutuForm();
            if (DuLieuIsNull())
            {
                return;
            }


            string MaNhomSPMoiTao = "";
            if (_fMain.IsSuaNhomSP == false)
            {
                MaNhomSPMoiTao = LopSQLNhomSP.LuuNhomSP(LopSQLNhomSP);
                _fMain.MaNhomSPCanSua_ = MaNhomSPMoiTao;

                _fMain.IsSuaNhomSP = true;
                // Refresh lai du lieu tren combobox
                if (MaNhomSPMoiTao == "")
                {
                    statusTB.Text = "Lưu KHÔNG thành công !";
                }
                else
                {
                    statusTB.Text = "Đã lưu thành công !";
                    txtTenNSP.Focus();
                }
            }
            else
            {
                //goi ham để update
                string KQSua = LopSQLNhomSP.SuaNhomSP(LopSQLNhomSP);

                if (KQSua == "")
                {
                    statusTB.Text = "Đã lưu thành công !";
                    txtTenNSP.Focus();
                }
                else
                {
                    statusTB.Text = "Lưu KHÔNG thành công !";
                    MessageBox.Show(KQSua);
                }
            }
            txtTenNSP.Focus();
            _fMain.fNhomSP_.RefreshLuoiDSNhomSP();  
        }

        private void btnNSPThemMoi_Click(object sender, EventArgs e)
        {
            _fMain.IsSuaNhomSP = false;
            txtTenNSP.Clear();
            txtGhiChu.Clear();
            ckKhongDung.Checked = false;
            txtTenNSP.Focus();
        }

        private void frmNhomSPEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnNSPDong_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnNSPThemMoi_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.L)
            {
                btnNSPLuu_Click(sender, e);
            }
        }
    }
}
