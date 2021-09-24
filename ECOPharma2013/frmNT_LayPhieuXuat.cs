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
using System.Transactions;

namespace ECOPharma2013
{
    public partial class frmNT_LayPhieuXuat : Form
    {
        frmMain _frmMain;
        public frmNT_LayPhieuXuat()
        {
            InitializeComponent();
        }
        public frmNT_LayPhieuXuat(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        
        string ttcn_;
        private void frmNT_LayPhieuXuat_Load(object sender, EventArgs e)
        {
            try
            {
                CRmtServer KetNoiServer = new CRmtServer();
                if (KetNoiServer.KiemTraKetNoiRmtServer() == false)
                {
                    MessageBox.Show("Kết nối server không thành công. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    LoadPhieuXuat();
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        public void LoadPhieuXuat()
        {
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            CSQLNT_LayPhieuXuat nt_layphieuxuat_ = new CSQLNT_LayPhieuXuat();
            ttcn_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
            rgvDSLayPhieuXuat.DataSource = nt_layphieuxuat_.LoadDanhSachLenLuoi(ttcn_);
        }

        string MaPNid_;
        
        private void btnTaiVe_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_LayPhieuXuat.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLSanPham SanPham = new CSQLSanPham();
            int maxthemmoieco = SanPham.SanPham_LayMaxThemMoiECO();
            int maxthemmoint = SanPham.SanPham_LayMaxThemMoiNT();
            if (maxthemmoieco > maxthemmoint)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm mới cập nhật phiếu xuất được");
                return;
            }
            int maxcapnhateco = SanPham.SanPham_LayMaxCapNhatECO();
            int maxcapnhatnt = SanPham.SanPham_LayMaxCapNhatNT();
            if (maxcapnhateco > maxcapnhatnt)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm mới cập nhật phiếu xuất được");
                return;
            }
            CSQLSanPham_NSX SanPham_NSX = new CSQLSanPham_NSX();
            int maxthemmoispnsxeco = SanPham_NSX.SanPham_NSX_LayMaxThemMoiECO();
            int maxthemmoispnsxnt = SanPham_NSX.SanPham_NSX_LayMaxThemMoiNT();
            if (maxthemmoispnsxeco > maxthemmoispnsxnt)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm - NSX mới có thể cập nhật phiếu xuất được");
                return;
            }
            int maxcapnhatspnseco = SanPham_NSX.SanPham_NSX_LayMaxCapNhatECO();
            int maxcapnhatspnsnt = SanPham_NSX.SanPham_NSX_LayMaxCapNhatNT();
            if (maxcapnhatspnseco > maxcapnhatspnsnt)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm - NSX mới có thể cập nhật phiếu xuất được");
                return;
            }
            CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();

            int maxcapnhathsqdeco = hsqd.HeSoQuiDoi_LayMaxCapNhatECO();
            int maxcapnhathsqdnt = hsqd.HeSoQuiDoi_LayMaxCapNhatNT();
            if (maxcapnhathsqdeco > maxcapnhathsqdnt)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục hệ số qui đổi mới cập nhật phiếu xuất được");
                return;
            }
            int maxthemmoihsqdeco = hsqd.HeSoQuiDoi_LayMaxThemMoiECO();
            int maxthemmoihsqdnt = hsqd.HeSoQuiDoi_LayMaxThemMoiNT();
            if (maxthemmoihsqdeco > maxthemmoihsqdnt)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục hệ số qui đổi mới cập nhật phiếu xuất được");
                return;
            }
            CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
            int maxthemmoisp_khoeco = sp_kho.SP_Kho_LayMaxThemMoiECO();
            int maxthemmoisp_khont = sp_kho.SP_Kho_LayMaxThemMoiNT();
            if (maxthemmoisp_khoeco > maxthemmoisp_khont)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm kho mới cập nhật phiếu xuất được");
                return;
            }
            _frmMain.fWaiting = new Fr_Waiting(_frmMain);
            _frmMain.fWaiting.Show();
            CSQLNT_NhapKho nt_nhapkho_ = new CSQLNT_NhapKho();
            CSQLPhieuXuat phieuxuat_ = new CSQLPhieuXuat();
            CSQLKiemTraXuatKho ktxk_ = new CSQLKiemTraXuatKho();
            CSQLNT_NhapKhoChiTiet nt_nhapkhoct = new CSQLNT_NhapKhoChiTiet();
            CSQLNT_LayPhieuXuat nt_layphieuxuat_ = new CSQLNT_LayPhieuXuat();
            DataTable dtbnt_nhapkhoct = new DataTable();

            for (int i = 0; i < rgvDSLayPhieuXuat.Rows.Count; i++)
            {
                rgvDSLayPhieuXuat.Rows[i].Cells[0].EndEdit();
                #region điều kiện là True
                if (rgvDSLayPhieuXuat.Rows[i].Cells[0].Value != null && (bool)rgvDSLayPhieuXuat.Rows[i].Cells[0].Value == true)
                {
                    if (nt_nhapkho_.KiemTraTonTaiSoCTN(rgvDSLayPhieuXuat.Rows[i].Cells[2].Value.ToString()))
                    {
                        ktxk_.Update_IsChuyenChiNhanh(rgvDSLayPhieuXuat.Rows[i].Cells[1].Value.ToString());
                    }
                    else 
                    {
                        nt_nhapkho_.SSoCTN = rgvDSLayPhieuXuat.Rows[i].Cells[2].Value.ToString();
                        nt_nhapkho_.SSoHD = rgvDSLayPhieuXuat.Rows[i].Cells[3].Value.ToString();
                        nt_nhapkho_.DNgayNhap = DateTime.Parse(rgvDSLayPhieuXuat.Rows[i].Cells[10].Value.ToString());
                        nt_nhapkho_.SFromm = rgvDSLayPhieuXuat.Rows[i].Cells[4].Value.ToString();
                        nt_nhapkho_.BXNPhieuNhap = false;
                        nt_nhapkho_.SGhiChu = "";
                        nt_nhapkho_.SUserNhap = CStaticBien.SmaTaiKhoan;
                        nt_nhapkho_.SIsKhoDacBiet = Boolean.Parse(rgvDSLayPhieuXuat.Rows[i].Cells["colHangDacBiet"].Value.ToString());

                        dtbnt_nhapkhoct = nt_nhapkhoct.LoadECOPhieuXuatCT_theo_SoPX(rgvDSLayPhieuXuat.Rows[i].Cells[1].Value.ToString());
                        #region
                        if (dtbnt_nhapkhoct != null && dtbnt_nhapkhoct.Rows.Count > 0)
                        {
                            string kq = nt_nhapkho_.ThemMoi(nt_nhapkho_, dtbnt_nhapkhoct);
                            if (kq.Equals("OK"))
                            {
                                try
                                {
                                    ktxk_.Update_IsChuyenChiNhanh(rgvDSLayPhieuXuat.Rows[i].Cells[1].Value.ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Lỗi cập nhật lên Server");
                                }
                            }
                            else
                            {
                                MessageBox.Show(kq, "Lỗi");
                                return;
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Phiếu xuất chưa cập nhật được. Vui lòng cập nhật lại!");
                            rgvDSLayPhieuXuat.DataSource = nt_layphieuxuat_.LoadDanhSachLenLuoi(ttcn_);
                            return;
                        }
                        #endregion
                    }
                }
                #endregion
            }
            _frmMain.KT = true;
            MessageBox.Show("Phiếu xuất đã cập nhật hoàn tất!");
            rgvDSLayPhieuXuat.DataSource = nt_layphieuxuat_.LoadDanhSachLenLuoi(ttcn_);        
        }
    }
}

