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
    public partial class frmNT_LayPhieuDieuChinhHSD : Form
    {
        frmMain _frmMain;
        public frmNT_LayPhieuDieuChinhHSD()
        {
            InitializeComponent();
        }
        public frmNT_LayPhieuDieuChinhHSD(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        string ttcn_;
        private void frmNT_LayPhieuDieuChinhHSD_Load(object sender, EventArgs e)
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
                    CSQLNT_LayPhieuDieuChinhHSD nt_layphieudchsd_ = new CSQLNT_LayPhieuDieuChinhHSD();
                    ttcn_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
                    rgvPhieuDieuChinh.DataSource = nt_layphieudchsd_.LoadDanhSachLenLuoi(ttcn_);
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }
        string maDCHDid, MaPhieuDieuChinh;
        private void rbtnTaiVe_Click(object sender, EventArgs e)
        {
            //CQuyenTruyCap qtc = new CQuyenTruyCap();
            //if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_LayPhieuDieuChinhTonKho.Name) == false)
            //{
            //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
            //    return;
            //}

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
            CSQLNT_DieuChinhHSD nt_dchsd_ = new CSQLNT_DieuChinhHSD();
            CSQLNT_DieuChinhHSDCT nt_dchsdct_ = new CSQLNT_DieuChinhHSDCT();
            CSQLDieuChinhHSD dchsd_ = new CSQLDieuChinhHSD();
            CSQLNT_LayPhieuDieuChinhHSD nt_layphieudchsd_ = new CSQLNT_LayPhieuDieuChinhHSD();
            DataTable dtbnt_dchsdct = new DataTable();

            TransactionOptions options_LPX = new TransactionOptions();
            options_LPX.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options_LPX.Timeout = new TimeSpan(0, 20, 0);
            using (TransactionScope giaotac = new TransactionScope(TransactionScopeOption.Required, options_LPX))
            {
                try
                {
                    for (int i = 0; i < rgvPhieuDieuChinh.Rows.Count; i++)
                    {
                        rgvPhieuDieuChinh.Rows[i].Cells[0].EndEdit();
                        if (rgvPhieuDieuChinh.Rows[i].Cells[0].Value != null && (bool)rgvPhieuDieuChinh.Rows[i].Cells[0].Value == true)
                        {
                            //insert ECODieuChinhHanSuDung
                            #region
                            nt_dchsd_.SDCHDid = rgvPhieuDieuChinh.Rows[i].Cells[1].Value.ToString();
                            nt_dchsd_.SSoPDC = rgvPhieuDieuChinh.Rows[i].Cells[2].Value.ToString();
                            nt_dchsd_.DNgayChinh = DateTime.Parse(rgvPhieuDieuChinh.Rows[i].Cells[3].Value.ToString());
                            nt_dchsd_.SMaNTid = rgvPhieuDieuChinh.Rows[i].Cells[4].Value.ToString();
                            nt_dchsd_.SGhiChu = rgvPhieuDieuChinh.Rows[i].Cells[6].Value.ToString();
                            nt_dchsd_.BHangDacBiet = (bool)rgvPhieuDieuChinh.Rows[i].Cells[7].Value;
                            nt_dchsd_.DNgayNhan = DateTime.Now;
                            nt_dchsd_.SUserNhan = CStaticBien.SmaTaiKhoan;
                            using (TransactionScope giaotac_ThemNK = new TransactionScope(TransactionScopeOption.RequiresNew))
                            {
                                try
                                {
                                    nt_dchsd_.ThemMoi(nt_dchsd_);
                                    giaotac_ThemNK.Complete();
                                }
                                catch (System.Transactions.TransactionAbortedException ex)
                                {
                                    MessageBox.Show("Chưa insert được NTNhanDieuChinhTonKho.");
                                }
                            }
                            maDCHDid = rgvPhieuDieuChinh.Rows[i].Cells[1].Value.ToString();
                            MaPhieuDieuChinh = rgvPhieuDieuChinh.Rows[i].Cells[2].Value.ToString();
                            #endregion

                            //insert ECODieuChinhTonKhoCT
                            #region
                            TransactionOptions options_LayDataNKCT = new TransactionOptions();
                            options_LayDataNKCT.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            options_LayDataNKCT.Timeout = new TimeSpan(0, 5, 0);
                            using (TransactionScope giaotac_dtbPXCT = new TransactionScope(TransactionScopeOption.RequiresNew, options_LayDataNKCT))
                            {
                                try
                                {
                                    dtbnt_dchsdct = nt_dchsdct_.LayTT_DCHDCT_Theo_DCHDid(maDCHDid);
                                    giaotac_dtbPXCT.Complete();
                                }
                                catch (System.Transactions.TransactionAbortedException ex)
                                {
                                    MessageBox.Show("Chưa lấy được database ECODieuChinhTonKhoCT từ công ty.");
                                }
                            }

                            if (dtbnt_dchsdct != null && dtbnt_dchsdct.Rows.Count > 0)
                            {
                                for (int ii = 0; ii < dtbnt_dchsdct.Rows.Count; ii++)
                                {
                                    //CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();//Phần Tân thêm lấy kho mặc định khi nhập
                                    nt_dchsdct_.SDCHDid = maDCHDid;
                                    nt_dchsdct_.SSPid = dtbnt_dchsdct.Rows[ii]["SPid"].ToString();
                                    nt_dchsdct_.SNSXID = dtbnt_dchsdct.Rows[ii]["NSXid"].ToString();
                                    nt_dchsdct_.SKho = dtbnt_dchsdct.Rows[ii]["KhoID"].ToString();
                                    nt_dchsdct_.SLot = dtbnt_dchsdct.Rows[ii]["Lot"].ToString();
                                    nt_dchsdct_.DDateSai = DateTime.Parse(dtbnt_dchsdct.Rows[ii]["DateSai"].ToString());
                                    nt_dchsdct_.DDateDung = DateTime.Parse(dtbnt_dchsdct.Rows[ii]["DateDung"].ToString());

                                    using (TransactionScope giaotac_ThemNKCT = new TransactionScope(TransactionScopeOption.RequiresNew))
                                    {
                                        try
                                        {
                                            nt_dchsdct_.ThemMoi(nt_dchsdct_);
                                            giaotac_ThemNKCT.Complete();
                                        }
                                        catch (System.Transactions.TransactionAbortedException ex)
                                        {
                                            MessageBox.Show("Lỗi insert NTDieuChinhTonKhoCT.");
                                        }
                                    }
                                }
                            }
                            #endregion

                            //Update ChiNhanhDaTaiVe
                            #region
                            TransactionOptions options_UpdateKTXK = new TransactionOptions();
                            options_UpdateKTXK.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            options_UpdateKTXK.Timeout = new TimeSpan(0, 5, 0);
                            using (TransactionScope giaotac_UpdateKTXK = new TransactionScope(TransactionScopeOption.RequiresNew, options_UpdateKTXK))
                            {
                                try
                                {
                                    dchsd_.Update_ChiNhanhDaTaiVe(MaPhieuDieuChinh);
                                    giaotac_UpdateKTXK.Complete();
                                }
                                catch (System.Transactions.TransactionAbortedException ex)
                                {
                                    MessageBox.Show("Chưa Update được ChiNhanhDaTaiVe trong ECODieuChinhHanDung.");
                                }
                            }
                            #endregion
                        }
                    }
                    rgvPhieuDieuChinh.DataSource = nt_layphieudchsd_.LoadDanhSachLenLuoi(ttcn_);
                    _frmMain.KT = true;
                    giaotac.Complete();
                    MessageBox.Show("Phiếu điều chỉnh tồn kho đã cập nhật hoàn tất!");
                }
                catch (System.Transactions.TransactionAbortedException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion
        }
    }
}
