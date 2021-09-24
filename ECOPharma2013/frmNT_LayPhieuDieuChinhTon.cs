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
    public partial class frmNT_LayPhieuDieuChinhTon : Form
    {
        frmMain _frmMain;
        public frmNT_LayPhieuDieuChinhTon()
        {
            InitializeComponent();
        }
        public frmNT_LayPhieuDieuChinhTon(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        string ttcn_;
        private void frmNT_LayPhieuDieuChinhTon_Load(object sender, EventArgs e)
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
                    CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
                    CSQLNT_LayPhieuDieuChinhTon nt_layphieudcton_ = new CSQLNT_LayPhieuDieuChinhTon();
                    ttcn_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
                    rgvPhieuDieuChinh.DataSource = nt_layphieudcton_.LoadDanhSachLenLuoi(ttcn_);
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }
        string maDCTKid, MaPhieuDieuChinh;
        private void rbtnTaiVe_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_LayPhieuDieuChinhTonKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            #region
            CSQLKho kho = new CSQLKho();
            int maxthemmoieco = kho.Kho_LayMaxThemMoiECO();
            int maxthemmoint = kho.Kho_LayMaxThemMoiNT();
            if (maxthemmoieco > maxthemmoint)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục Kho mới cập nhật phiếu điều chỉnh tồn kho được");
                return;
            }
            int maxcapnhateco = kho.Kho_LayMaxCapNhatECO();
            int maxcapnhatnt = kho.Kho_LayMaxCapNhatNT();
            if (maxcapnhateco > maxcapnhatnt)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục Kho mới cập nhật phiếu điều chỉnh tồn kho được");
                return;
            }
            CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
            int maxthemmoisp_khoeco = sp_kho.SP_Kho_LayMaxThemMoiECO();
            int maxthemmoisp_khont = sp_kho.SP_Kho_LayMaxThemMoiNT();
            if (maxthemmoisp_khoeco > maxthemmoisp_khont)
            {
                MessageBox.Show("Bạn phải cập nhật danh mục sản phẩm kho mới cập nhật phiếu điều chỉnh tồn được");
                return;
            }
            _frmMain.fWaiting = new Fr_Waiting(_frmMain);
            _frmMain.fWaiting.Show();
            CSQLNT_DieuChinhTon nt_dct_ = new CSQLNT_DieuChinhTon();
            CSQLNT_DieuChinhTonCT nt_dctct = new CSQLNT_DieuChinhTonCT();
            CSQLDieuChinhTon dct_ = new CSQLDieuChinhTon();
            CSQLNT_LayPhieuDieuChinhTon nt_layphieudcton_ = new CSQLNT_LayPhieuDieuChinhTon();
            DataTable dtbnt_dctct = new DataTable();

            for (int i = 0; i < rgvPhieuDieuChinh.Rows.Count; i++)
            {
                rgvPhieuDieuChinh.Rows[i].Cells[0].EndEdit();
                if (rgvPhieuDieuChinh.Rows[i].Cells[0].Value != null && (bool)rgvPhieuDieuChinh.Rows[i].Cells[0].Value == true)
                {
                    #region
                    if (nt_dct_.KiemTraTonTai(rgvPhieuDieuChinh.Rows[i].Cells[1].Value.ToString()))
                    {
                        dct_.Update_ChiNhanhDaTaiVe(rgvPhieuDieuChinh.Rows[i].Cells[2].Value.ToString());
                    }
                    else
                    {
                        nt_dct_.SDCTKid = rgvPhieuDieuChinh.Rows[i].Cells[1].Value.ToString();
                        nt_dct_.SSoPDC = rgvPhieuDieuChinh.Rows[i].Cells[2].Value.ToString();
                        nt_dct_.DNgayChinh = DateTime.Parse(rgvPhieuDieuChinh.Rows[i].Cells[3].Value.ToString());
                        nt_dct_.SMaNTid = rgvPhieuDieuChinh.Rows[i].Cells[4].Value.ToString();
                        nt_dct_.SGhiChu = rgvPhieuDieuChinh.Rows[i].Cells[6].Value.ToString();
                        nt_dct_.BHangDacBiet = (bool)rgvPhieuDieuChinh.Rows[i].Cells[7].Value;
                        nt_dct_.DNgayNhan = DateTime.Now;
                        nt_dct_.SUserNhan = CStaticBien.SmaTaiKhoan;

                        dtbnt_dctct = nt_dctct.LayTT_DCTKCT_Theo_DCTKid(nt_dct_.SDCTKid);
                        #region
                        if (dtbnt_dctct != null && dtbnt_dctct.Rows.Count > 0)
                        {
                            string kq = nt_dct_.ThemMoi(nt_dct_, dtbnt_dctct);

                            if (kq.Equals("OK"))
                            {
                                dct_.Update_ChiNhanhDaTaiVe(nt_dct_.SSoPDC);
                            }
                            else
                            {
                                MessageBox.Show(kq, "Lỗi");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Phiếu điều chỉnh tồn chưa cập nhật được. Vui lòng cập nhật lại!");
                            return;
                        }
                        #endregion
                    }
                    #endregion                            
                }
            }
            rgvPhieuDieuChinh.DataSource = nt_layphieudcton_.LoadDanhSachLenLuoi(ttcn_);
            _frmMain.KT = true;
            MessageBox.Show("Phiếu điều chỉnh tồn kho đã cập nhật hoàn tất!");
                
            #endregion
        }
    }
}
