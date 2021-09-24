using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ECOPharma2013.SQL;
using ECOPharma2013.DuLieu;
using Microsoft.PointOfService;
using ECOPharma2013.Printer_POS;
using System.Threading;

namespace ECOPharma2013
{
    public partial class frmNT_ThanhToanTraHangEdit : Telerik.WinControls.UI.RadForm
    {
        frmMain fmain;
        string sophieu, nvban;
        XuLyMayInPos xuly_;
        public frmNT_ThanhToanTraHangEdit(frmMain _fmain)
        {
            InitializeComponent();
            fmain = _fmain;
        }

        //Các biến toàn cục
        string _TH_THID;
        string _TH_SoCTTra;

        //public void NhanDuLieu(string th_thid, string th_soCTTra)
        //{
        //    _TH_THID = th_thid;
        //    _TH_SoCTTra = th_soCTTra;
        //}

        private void frmNT_ThanhToanTraHangEdit_Load(object sender, EventArgs e)
        {
            xuly_ = new XuLyMayInPos(this, statusTB);
            try 
            {
                if (_TH_THID != null && _TH_SoCTTra != null)
                {
                    CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
                    txtTienTra.Text = Convert.ToDecimal(th.NT_TraHang_LayTongTienTheoTHID(_TH_THID).ToString()).ToString("#,###");
                }
                else
                {
                    //Không tồn tại trả hàng, thoát
                }
            }
            catch
            {
                return;
            }
        }
        
        bool thanhtoan = false;
        decimal tientra;
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTienTra.Text.Length > 0 &&_TH_THID != null && _TH_SoCTTra != null)
            {
                CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
                int kq = th.NT_TraHang_ThanhToan(_TH_THID, CStaticBien.SmaTaiKhoan, "11111111-1111-1111-1111-111111111111");
                if (kq > 0)
                {
                    btnThanhToan.Enabled = false;
                    tientra = decimal.Parse(txtTienTra.Text);
                    // code in phiếu tại đây
                    Thread inphieu = new Thread(InPhieuTraHang);
                    inphieu.Start();
                    //Thoát ra và gọi frm thêm mới bán hàng
                    
                    btnQuayLai_Click(sender, e);
                }
                else
                {
                    //statusTB.Text = "Thanh toán thất bại!";
                }

            }
        }
        private void InPhieuTraHang()
        {
            ThanhToan_TraHang sales_ = new ThanhToan_TraHang();

            CSQLNhaThuoc nhathuoc_ = new CSQLNhaThuoc();
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            CSQLNT_TraHangTuKhachCT trahangct_ = new CSQLNT_TraHangTuKhachCT();
            DataTable dtbnhathuoc = nhathuoc_.LayNhaThuocTheoMa(chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString());
            string tennhathuoc_ = dtbnhathuoc.Rows[0]["TenNT"].ToString();
            string telnhathuoc_ = dtbnhathuoc.Rows[0]["Tel"].ToString();
            DataTable dtbthct_ = trahangct_.NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoTHID(_TH_THID);

            PosDeviceTag tag = xuly_.currentDevice;
            if (tag != null)
            {
                try
                {
                    sales_.ThanhToan_TH(xuly_, tennhathuoc_, telnhathuoc_, sophieu, CStaticBien.STenMayThuNgan, nvban,
 CStaticBien.StaiKhoan, dtbthct_, tientra, chkInCT.Checked, false);
                    thanhtoan = true;
                }
                catch
                {
                    if (thanhtoan == false)
                    {
                        MessageBox.Show("Nguồn máy in bị tắt hoặc dây tín hiệu bị ngắt.\n Vui Lòng chọn in lại sau", "Xác Nhận");
                    }
                    else
                    {
                        thanhtoan = false;
                    }
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            fmain.frmNT_ThanhToanTraHangEditisOpen_ = false;
            this.Close();
        }
        public void TruyenBien(string phieuxuat, string nhanvienbanthuoc, string th_thid, string th_soCTTra)
        {
            sophieu = phieuxuat;
            nvban = nhanvienbanthuoc;
            _TH_THID = th_thid;
            _TH_SoCTTra = th_soCTTra;
        }

        private void frmNT_ThanhToanTraHangEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                btnThanhToan_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnQuayLai_Click(sender, e);
            }
        }
    }
}
