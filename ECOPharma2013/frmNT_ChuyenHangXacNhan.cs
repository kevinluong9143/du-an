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
using System.Transactions;

namespace ECOPharma2013
{
    public partial class frmNT_ChuyenHangXacNhan : Form
    {
        frmMain fmain;
        public frmNT_ChuyenHangXacNhan()
        {
            InitializeComponent();
        }
        public frmNT_ChuyenHangXacNhan(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void frmNT_ChuyenHangXacNhan_Load(object sender, EventArgs e)
        {
            LayDSLenLuoiXacNhan();      
        }

        public void LayDSLenLuoiXacNhan()
        {
            CSQLNT_ChuyenHang ch = new CSQLNT_ChuyenHang();
            try
            {
                rgvChuyenHang.DataSource = ch.LayChuyenHangLenLuoiXacNhan(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            } 
        }

        public void ChuyenHangXacNhan_XacNhan()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_ChuyenHangXacNhan_.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNT_ChuyenHang ch = new CSQLNT_ChuyenHang();
            try
            {
                for (int i = 0; i < rgvChuyenHang.Rows.Count; i++)
                {
                    rgvChuyenHang.Rows[i].Cells[0].EndEdit();
                    if (rgvChuyenHang.Rows[i].Cells[0].Value != null)
                    {
                        bool chon = (bool)rgvChuyenHang.Rows[i].Cells[0].Value;
                        if (chon == true)
                        {
                            CRmtServer KetNoiServer = new CRmtServer();
                            if (KetNoiServer.KiemTraKetNoiRmtServer() == false)
                            {
                                MessageBox.Show("Kết nối server tổng công ty không thành công. Vui lòng kiểm tra lại.");
                                return;
                            }
                            else
                            {
                                CSQLNhanChuyenHang nch = new CSQLNhanChuyenHang();
                                CSQLNhanChuyenHangCT nchct = new CSQLNhanChuyenHangCT();
                                CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
                                //1. Xác Nhận Phiếu Chuyển
                                Fr_DangXuLy.ShowFormCho();
                                DateTime NGAYXACNHAN = ch.XacNhanChuyenHang(rgvChuyenHang.Rows[i].Cells["colCHID"].Value.ToString(), DateTime.Now, CStaticBien.SmaTaiKhoan);

                                //2. INSERT VÀO REMOTE DATABASE TỔNG CTY, UPDATE ĐÃ CHUYỂN 
                                DataTable dtbchct = chct.LayDanhSach(rgvChuyenHang.Rows[i].Cells["colCHID"].Value.ToString());

                                string kq = nch.Them(rgvChuyenHang.Rows[i].Cells["colSoPCH"].Value.ToString(),
                                                       NGAYXACNHAN,
                                                       rgvChuyenHang.Rows[i].Cells["colFromm"].Value.ToString(),
                                                       rgvChuyenHang.Rows[i].Cells["colDestination"].Value.ToString(),
                                                       rgvChuyenHang.Rows[i].Cells["colGhiChu"].Value.ToString(),
                                                       (bool)rgvChuyenHang.Rows[i].Cells["colIsKhoDacBiet"].Value, dtbchct);

                                if (kq.Equals("OK"))
                                {
                                    //3. CẬP NHẬT TRẠNG THÁI ĐÃ CHUYỂN VỂ CTY
                                    ch.CapNhatIsDaChuyenVeCty(rgvChuyenHang.Rows[i].Cells["colCHID"].Value.ToString());
                                }
                                else
                                {
                                    MessageBox.Show(kq, "Lỗi Cập Nhật Server");
                                }
                                
                                Fr_DangXuLy.DongFormCho();
                            }
                        }
                    }
                }
                rgvChuyenHang.DataSource = ch.LayChuyenHangLenLuoiXacNhan(fmain.IsXemTatCa_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }  
        }
    }
}
