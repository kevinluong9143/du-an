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
    public partial class frmNT_TraHangVeCtyXacNhan : Form
    {
        public frmNT_TraHangVeCtyXacNhan()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmNT_TraHangVeCtyXacNhan(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }

        private void frmNT_TraHangVeCtyXacNhan_Load(object sender, EventArgs e)
        {
            LayDSLenLuoiXacNhan(); 
        }

        public void LayDSLenLuoiXacNhan()
        {
            CSQLNT_TraHangVeCty ch = new CSQLNT_TraHangVeCty();
            try
            {
                rgvPhieuTra.DataSource = ch.LayTraHangLenLuoiXacNhan(fmain.IsXemTatCa_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }


        public void TraHangXacNhan_XacNhan()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_TraHangVeCtyXacNhan.Name) == false)
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
                CSQLNT_TraHangVeCty ch = new CSQLNT_TraHangVeCty();
                try
                {
                    for (int i = 0; i < rgvPhieuTra.Rows.Count; i++)
                    {
                        rgvPhieuTra.Rows[i].Cells[0].EndEdit();
                        if (rgvPhieuTra.Rows[i].Cells[0].Value != null)
                        {
                            bool chon = (bool)rgvPhieuTra.Rows[i].Cells[0].Value;
                            if (chon == true)
                            {
                                //1. XÁC NHẬN TRẢ HÀNG, TRỪ TỒN, INSERT BẢNG NHẬP XUẤT TỒN
                                DateTime NGAYXACNHAN = ch.XacNhanTraHang(rgvPhieuTra.Rows[i].Cells["colTHID"].Value.ToString(), DateTime.Now, CStaticBien.SmaTaiKhoan);
                                
                                ////2. INSERT VÀO REMOTE DATABASE TỔNG CTY, UPDATE ĐÃ TRẢ
                                CSQLNhanTraHang nch = new CSQLNhanTraHang();
                                CSQLNhanTraHangCT nchct = new CSQLNhanTraHangCT();
                                CSQLNT_TraHangVeCtyCT chct = new CSQLNT_TraHangVeCtyCT();
                                DataTable dtbchct = chct.LayDanhSach(rgvPhieuTra.Rows[i].Cells["colTHID"].Value.ToString());

                                string kq = nch.Them(rgvPhieuTra.Rows[i].Cells["colSoPTH"].Value.ToString(),
                                                        NGAYXACNHAN,
                                                        rgvPhieuTra.Rows[i].Cells["colFromm"].Value.ToString(),
                                                        rgvPhieuTra.Rows[i].Cells["colGhiChu"].Value.ToString(),
                                                        int.Parse(rgvPhieuTra.Rows[i].Cells["colLoaiHangTra"].Value.ToString()),
                                                        Boolean.Parse(rgvPhieuTra.Rows[i].Cells["colHangDacBiet"].Value.ToString()), dtbchct);

                                if (kq.Equals("OK")) { 
                                    //3. CẬP NHẬT TRẠNG THÁI ĐÃ CHUYỂN VỂ CTY
                                    ch.CapNhatIsDaChuyenVeCty(rgvPhieuTra.Rows[i].Cells["colTHID"].Value.ToString());
                                }
                                else
                                {
                                    MessageBox.Show(kq, "Lỗi Cập Nhật Server");
                                }
                            }
                        }
                    }
                    rgvPhieuTra.DataSource = ch.LayTraHangLenLuoiXacNhan(fmain.IsXemTatCa_);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                #endregion
                Fr_DangXuLy.DongFormCho();
            }
        }
    }
}
