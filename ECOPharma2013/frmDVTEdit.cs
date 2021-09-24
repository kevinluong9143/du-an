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
    public partial class frmDVTEdit : Form
    {
        private frmMain _fMain;
        CSQLDonViTinh LopSQLDVT;


        public frmDVTEdit(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        private void btnDVTDong_Click(object sender, EventArgs e)
        {
            _fMain.frmDVTEditisOpen_ = false;
            _fMain.IsSuaDVT_ = false;
            this.Close();
        }

        private void frmDVTEdit_Load(object sender, EventArgs e)
        {
            _fMain.frmDVTEditisOpen_ = true;
            LopSQLDVT = new CSQLDonViTinh();


            if (_fMain.IsSuaDVT_ == true)
            {
                txtTenDVT.Text = _fMain.BangDVTCanSua_.Rows[0]["TenDVT"].ToString();
                txtGhiChu.Text = _fMain.BangDVTCanSua_.Rows[0]["GhiChu"].ToString();
                ckKhongDung.Checked = bool.Parse(_fMain.BangDVTCanSua_.Rows[0]["KhongSuDung"].ToString());
            }
            txtTenDVT.Focus();
        }

        public bool DuLieuIsNull()
        {
            if (LopSQLDVT.sTenDVT == "")
            {
                statusTB.Text = "Chưa có tên Đơn Vị Tính";
                return true;
            }

            return false;
        }

        public void LayDuLieutuForm()
        {
            CXuLyChuoi xlc = new CXuLyChuoi();
            LopSQLDVT = new CSQLDonViTinh();
            LopSQLDVT.sTenDVT = xlc.TrimTen(txtTenDVT.Text);
            LopSQLDVT.sGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
            LopSQLDVT.bIsKhongDung = ckKhongDung.Checked;
            LopSQLDVT.sUserID = CStaticBien.SmaTaiKhoan;

            if (_fMain.IsSuaDVT_ == true)
            {
                LopSQLDVT.sMaDVT = _fMain.MaDVTCanSua_;
            }
        }
        private void btnDVTLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_fMain.fDVT.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            LayDuLieutuForm();
            if (DuLieuIsNull())
            {
                return;
            }
            string MaDVTMoiTao = "";
            if (_fMain.IsSuaDVT_ == false)
            {
                MaDVTMoiTao = LopSQLDVT.LuuDVT(LopSQLDVT);
                _fMain.MaDVTCanSua_ = MaDVTMoiTao;

                _fMain.IsSuaDVT_ = true;
                // Refresh lai du lieu tren combobox
                if (MaDVTMoiTao == "")
                {
                    statusTB.Text = "Lưu KHÔNG thành công !";
                }
                else
                {
                    statusTB.Text = "Đã lưu thành công !";
                    txtTenDVT.Focus();
                }
            }
            else
            {
                //goi ham để update
                string KQSua = LopSQLDVT.SuaDVT(LopSQLDVT);
                
                if (KQSua == "")
                {
                    statusTB.Text = "Đã lưu thành công !";
                    txtTenDVT.Focus();
                }
                else
                {
                    statusTB.Text = "Lưu KHÔNG thành công !";
                    MessageBox.Show(KQSua);
                }
            }
            txtTenDVT.Focus();
            _fMain.fDVT.RefreshLuoiDSDVT();   
        }

        private void btnDVTThemMoi_Click(object sender, EventArgs e)
        {
            _fMain.IsSuaDVT_ = false;
            txtTenDVT.Clear();
            txtGhiChu.Clear();
            ckKhongDung.Checked = false;
            txtTenDVT.Focus();
        }

        private void frmDVTEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnDVTDong_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnDVTThemMoi_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnDVTLuu_Click(sender, e);
            }
        }
    }
}
