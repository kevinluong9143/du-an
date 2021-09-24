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
using ECOPharma2013.Printer_POS;
using Microsoft.PointOfService;
using System.Threading;

namespace ECOPharma2013
{
    public partial class frmNT_ThanhToanEdit : Form
    {
        frmMain fmain;
        string _BHID;
        string sophieu, nvban;
        public bool Dathanhtoan = false;
        XuLyMayInPos xuly_;
        public frmNT_ThanhToanEdit(frmMain fmain_)
        {
            InitializeComponent();
            fmain = fmain_;
        }
        //public void NhanDuLieu(string bhid)
        //{
        //    _BHID = bhid;
        //}
       
        private void frmNT_ThanhToanEdit_Load(object sender, EventArgs e)
        {
            xuly_ = new XuLyMayInPos(this, statusTB);
            txtPhaiThu.Enabled = false;
            txtDaNhan.Focus();
            if (_BHID != null && _BHID.Length > 0)
            {
                
                CSQLNT_BanHang bh = new CSQLNT_BanHang();
                txtPhaiThu.Text = bh.LayTongTienThanhToan(_BHID);
                
            }
            else
            {
                statusTB.Text = "Đơn hàng chưa tồn tại. Không thể thanh toán!";
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            fmain.frmNT_ThanhToanEditisOpen_ = false;
            this.Close();
        }

        
        bool thanhtoan = false;
        decimal tientrakhach, phaithu, danhan, tralai;
        private void btnDaThu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_BanHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (txtTraKhach.Text.Length > 0 && tientrakhach < 0)
            {
                txtTraKhach.Text = "Bạn phải nhận đủ tiền!";
                txtDaNhan.Focus();
                return;
            }
            else statusTB.Text = "";
            //if (txtTraKhach.Text.Length > 0)
            //{
            //    string xulytext = txtTraKhach.Text.Replace(",", "");
            //    decimal tientrakhach = Convert.ToDecimal(xulytext);

                if (tientrakhach >= 0)
                {
                    //Tiến hành tính tiền
                    CSQLNT_BanHang bh = new CSQLNT_BanHang();
                    string kq = bh.ThanhToan(fmain.BHID_NT_BanHang_, decimal.Parse(txtDaNhan.Text), CStaticBien.SmaTaiKhoan);
                    if (kq.Equals("OK"))
                    {
                        statusTB.Text = "Thanh toán thành công!";
                        btnDaThu.Enabled = false;
                        phaithu = decimal.Parse(txtPhaiThu.Text);
                        danhan = decimal.Parse(txtDaNhan.Text);
                        tralai = decimal.Parse(txtTraKhach.Text);
                        //Code in phiếu tại đây                        
                        Thread _threadInPhieu = new Thread(InPhieu);
                        _threadInPhieu.Start();
                        //InPhieu();
                        //Thoát ra và gọi frm thêm mới bán hàng
                        Dathanhtoan = true;
                        btnQuayLai_Click(sender, e); 
                    }
                    else { 
                        statusTB.Text = "Lỗi: " + kq;
                        MessageBox.Show(kq, "Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải thu đủ tiền!", "Nhắc nhở", MessageBoxButtons.OK);
                    txtTraKhach.Text = "";
                    return;
                }
        }

        private void InPhieu()
        {
            ThanhToan sales_ = new ThanhToan();

            CSQLNhaThuoc nhathuoc_ = new CSQLNhaThuoc();
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            CSQLNT_BanHangCT banhangct_ = new CSQLNT_BanHangCT();
            DataTable dtbnhathuoc = nhathuoc_.LayNhaThuocTheoMa(chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString());
            string tennhathuoc_ = dtbnhathuoc.Rows[0]["TenNT"].ToString();
            string telnhathuoc_ = dtbnhathuoc.Rows[0]["Tel"].ToString();
            DataTable dtbbhct_ = banhangct_.LayINCHITIET(_BHID);

            PosDeviceTag tag = xuly_.currentDevice;
            if (tag != null)
            {
                try
                {
                    sales_.ChonMayIn(xuly_, tennhathuoc_, telnhathuoc_, sophieu, CStaticBien.STenMayThuNgan, nvban,
 CStaticBien.StaiKhoan, dtbbhct_, phaithu, danhan, tralai, chkInChiTiet.Checked, false);
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

        private void txtDaNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhaiThu_TextChanged(object sender, EventArgs e)
        {
            if (txtPhaiThu.Text.Length > 0)
            {
                txtPhaiThu.Text = Convert.ToDecimal(txtPhaiThu.Text).ToString("#,###");
                txtPhaiThu.Select(txtPhaiThu.TextLength, 0);
            }
        }

        private void txtDaNhan_TextChanged(object sender, EventArgs e)
        {
            if (txtDaNhan.Text.Length > 0)
            {
                txtDaNhan.Text = Convert.ToDecimal(txtDaNhan.Text).ToString("#,###");
                txtDaNhan.Select(txtDaNhan.TextLength, 0);

                string xulydanhan = txtDaNhan.Text.Replace(",", "");
                decimal tiendanhan = Convert.ToDecimal(xulydanhan);

                string xulyphaithu = txtPhaiThu.Text.Replace(",", "");
                decimal tienphaithu = Convert.ToDecimal(xulyphaithu);

                tientrakhach = tiendanhan - tienphaithu;
                if (txtDaNhan.Text.Length > 0 && tientrakhach < 0)
                {
                    txtTraKhach.Text = tientrakhach.ToString("#,###");
                    statusTB.Text = "Bạn phải nhận đủ tiền";
                    txtDaNhan.Focus();
                    return;
                }
                else
                {
                    if (tientrakhach == 0)
                    {
                        txtTraKhach.Text = tientrakhach.ToString();
                    }
                    else
                    {
                        txtTraKhach.Text = tientrakhach.ToString("#,###");
                    }
                    statusTB.Text = "";
                    //btnDaThu.Focus();
                }
            }
        }


        public void TruyenBien(string phieuxuat, string nhanvienbanthuoc, string bhid)
        {
            sophieu = phieuxuat;
            nvban = nhanvienbanthuoc;
            _BHID = bhid;
        }

        private void frmNT_ThanhToanEdit_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode == Keys.F9)
            {
                btnDaThu_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnQuayLai_Click(sender, e);
            }
        }

    }
}
