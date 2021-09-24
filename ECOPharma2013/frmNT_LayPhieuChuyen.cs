using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using System.Transactions;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmNT_LayPhieuChuyen : Form
    {
        public frmNT_LayPhieuChuyen()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmNT_LayPhieuChuyen(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }
        string ttcn_;
        private void btnTaiVe_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_LayPhieuChuyen.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CRmtServer KetNoiServer = new CRmtServer();
            if (KetNoiServer.KiemTraKetNoiRmtServer() == false)
            {
                MessageBox.Show("Kết nối server tổng công ty không thành công. Vui lòng kiểm tra lại.");
                return;
            }
            else
            {
                Fr_DangXuLy.ShowFormCho();
                #region
                CSQLSanPham SanPham = new CSQLSanPham();
                int maxthemmoieco = SanPham.SanPham_LayMaxThemMoiECO();
                int maxthemmoint = SanPham.SanPham_LayMaxThemMoiNT();
                if (maxthemmoieco > maxthemmoint)
                {
                    MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm mới cập nhật phiếu chuyển được");
                    Fr_DangXuLy.DongFormCho();
                    return;
                }
                int maxcapnhateco = SanPham.SanPham_LayMaxCapNhatECO();
                int maxcapnhatnt = SanPham.SanPham_LayMaxCapNhatNT();
                if (maxcapnhateco > maxcapnhatnt)
                {
                    MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm mới cập nhật phiếu chuyển được");
                    Fr_DangXuLy.DongFormCho();
                    return;
                }
                CSQLSanPham_NSX SanPham_NSX = new CSQLSanPham_NSX();
                int maxthemmoispnsxeco = SanPham_NSX.SanPham_NSX_LayMaxThemMoiECO();
                int maxthemmoispnsxnt = SanPham_NSX.SanPham_NSX_LayMaxThemMoiNT();
                if (maxthemmoispnsxeco > maxthemmoispnsxnt)
                {
                    MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm - NSX mới có thể cập nhật phiếu chuyển được");
                    Fr_DangXuLy.DongFormCho();
                    return;
                }
                int maxcapnhatspnseco = SanPham_NSX.SanPham_NSX_LayMaxCapNhatECO();
                int maxcapnhatspnsnt = SanPham_NSX.SanPham_NSX_LayMaxCapNhatNT();
                if (maxcapnhatspnseco > maxcapnhatspnsnt)
                {
                    MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm - NSX mới có thể cập nhật phiếu chuyển được");
                    Fr_DangXuLy.DongFormCho();
                    return;
                }
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();

                int maxcapnhathsqdeco = hsqd.HeSoQuiDoi_LayMaxCapNhatECO();
                int maxcapnhathsqdnt = hsqd.HeSoQuiDoi_LayMaxCapNhatNT();
                if (maxcapnhathsqdeco > maxcapnhathsqdnt)
                {
                    MessageBox.Show("Bạn phải cập nhật danh mục hệ số qui đổi mới cập nhật phiếu chuyển được");
                    Fr_DangXuLy.DongFormCho();
                    return;
                }
                int maxthemmoihsqdeco = hsqd.HeSoQuiDoi_LayMaxThemMoiECO();
                int maxthemmoihsqdnt = hsqd.HeSoQuiDoi_LayMaxThemMoiNT();
                if (maxthemmoihsqdeco > maxthemmoihsqdnt)
                {
                    MessageBox.Show("Bạn phải cập nhật danh mục hệ số qui đổi mới cập nhật phiếu chuyển được");
                    Fr_DangXuLy.DongFormCho();
                    return;
                }
                CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
                int maxthemmoisp_khoeco = sp_kho.SP_Kho_LayMaxThemMoiECO();
                int maxthemmoisp_khont = sp_kho.SP_Kho_LayMaxThemMoiNT();
                if (maxthemmoisp_khoeco > maxthemmoisp_khont)
                {
                    MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm kho mới cập nhật phiếu chuyển được");
                    Fr_DangXuLy.DongFormCho();
                    return;
                }
                #endregion
                fmain.fWaiting = new Fr_Waiting(fmain);
                fmain.fWaiting.Show();

                for (int i = 0; i < rgvPhieuChuyen.Rows.Count; i++)
                {
                    rgvPhieuChuyen.Rows[i].Cells["ColChon"].EndEdit();
                    if (rgvPhieuChuyen.Rows[i].Cells["ColChon"].Value != null && (bool)rgvPhieuChuyen.Rows[i].Cells["ColChon"].Value == true)
                    {
                        CSQLNT_NhanPhieuChuyen npc = new CSQLNT_NhanPhieuChuyen();
                        CSQLNT_LayPhieuChuyen lpc = new CSQLNT_LayPhieuChuyen();

                        if (npc.KiemTraTonTai(rgvPhieuChuyen.Rows[i].Cells["colNCHID"].Value.ToString()))
                        {
                            try
                            {
                                lpc.CapNhatPhieuChuyenTaiTongCongTy(rgvPhieuChuyen.Rows[i].Cells["colNCHID"].Value.ToString());
                            }
                            catch (Exception ex)
                            {
                                statusTB.Text = "Chưa cập nhật trạng thái phiếu chuyển hàng tại tổng công ty!";
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            DataTable dtbNPCCT = lpc.LayPhieuChuyenChiTietTuTongCty(rgvPhieuChuyen.Rows[i].Cells["colNCHID"].Value.ToString());
                            #region
                            if (dtbNPCCT != null && dtbNPCCT.Rows.Count > 0)
                            {
                                string kq = npc.Them(rgvPhieuChuyen.Rows[i].Cells["colNCHID"].Value.ToString(),
                                            rgvPhieuChuyen.Rows[i].Cells["colSoPCH"].Value.ToString(),
                                            DateTime.Parse(rgvPhieuChuyen.Rows[i].Cells["colNgayChungTu"].Value.ToString()),
                                            rgvPhieuChuyen.Rows[i].Cells["colfromm"].Value.ToString(),
                                            rgvPhieuChuyen.Rows[i].Cells["colGhiChu"].Value.ToString(),
                                            CStaticBien.SmaTaiKhoan,
                                            (bool)rgvPhieuChuyen.Rows[i].Cells["colIsKhoDacBiet"].Value, dtbNPCCT);

                                if (kq.Equals("OK"))
                                {
                                    try
                                    {
                                        lpc.CapNhatPhieuChuyenTaiTongCongTy(rgvPhieuChuyen.Rows[i].Cells["colNCHID"].Value.ToString());
                                    }
                                    catch (Exception ex)
                                    {
                                        statusTB.Text = "Chưa cập nhật trạng thái phiếu chuyển hàng tại tổng công ty!";
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    statusTB.Text = kq;
                                    MessageBox.Show(kq, "Lỗi");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Phiếu chuyển chưa cập nhật được. Vui lòng cập nhật lại!");
                                return;
                            }
                            #endregion
                        }
                    }
                }

                #region LoadPhieuChuyen
                CSQLNT_LayPhieuChuyen nt_LayPhieuChuyen = new CSQLNT_LayPhieuChuyen();
                try
                {
                    ttcn_ = nt_LayPhieuChuyen.LayThongTinChiNhanh();
                    rgvPhieuChuyen.DataSource = nt_LayPhieuChuyen.LayPhieuChuyenTuTongCTy(ttcn_);
                }
                catch (Exception ex)
                {
                    statusTB.Text = "Lấy phiếu chuyển hàng tại tổng công ty thất bại!";
                    statusTB.Text = ex.Message;
                }
                #endregion LoadPhieuChuyen

            }
            Fr_DangXuLy.DongFormCho();
            fmain.KT = true;
        }
        
        private void frmNT_LayPhieuChuyen_Load(object sender, EventArgs e)
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
                    try
                    {
                        LoadPhieuChuyen();
                    }
                    catch(Exception ex)
                    {
                        statusTB.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        public void LoadPhieuChuyen()
        {
            CSQLNT_LayPhieuChuyen nt_LayPhieuChuyen = new CSQLNT_LayPhieuChuyen();
            ttcn_ = nt_LayPhieuChuyen.LayThongTinChiNhanh();
            rgvPhieuChuyen.DataSource = nt_LayPhieuChuyen.LayPhieuChuyenTuTongCTy(ttcn_);
        }
    }
}
