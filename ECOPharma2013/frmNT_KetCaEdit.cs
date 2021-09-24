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
using ECOPharma2013.Printer_POS;

namespace ECOPharma2013
{
    public partial class frmNT_KetCaEdit : Form
    {
        frmMain _frmMain;
        public frmNT_KetCaEdit()
        {
            InitializeComponent();
        }
        public frmNT_KetCaEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        CSQLCauHinhHeThong chht_ = new CSQLCauHinhHeThong();
        CSQLNT_KetCa ketca_ = new CSQLNT_KetCa();
        decimal ttgiam_, ttcotaxchuagiam_, ttcotaxdagiam_, tttra_, ttcotaxchuatinhphitra_, ttcotaxdatinhphitra_, tongtienketca, tiencuaca ;
        int sobillban, sobilltra, sobillhuybanhang, sobillhuytrahang;
        XacNhan_Declarations InXacNhan = new XacNhan_Declarations();
        KetCa_CloseSales Inketca = new KetCa_CloseSales();
        XuLyMayInPos xuly_ = new XuLyMayInPos();

        private void frmNT_KetCaEdit_Load(object sender, EventArgs e)
        {
            xuly_ = new XuLyMayInPos(this, statusTB);
            panelKetCa.AutoScroll = true;
            txtSoCa.Enabled = false;
            txtTienQuyDauCa.Enabled = false;
            txtTongTienKetCa.Enabled = false;
            btnKetThucCa.Enabled = false;
            txtTenThuNgan.Enabled = false;

            if (_frmMain.BangNT_KetCa_ != null && _frmMain.BangNT_KetCa_.Rows.Count > 0 && _frmMain.IsDaXacNhan_ == true)
            {
                KhoaTextBox_Tien();
                btnXacNhan.Enabled = false;
                btnInLai.Enabled = true;
                btnInLai.Focus();
                txtTenThuNgan.Text = _frmMain.BangNT_KetCa_.Rows[0]["HoTen"].ToString();
                txtSoCa.Text = _frmMain.BangNT_KetCa_.Rows[0]["SoCa"].ToString();
                txtTienQuyDauCa.Text = _frmMain.BangNT_KetCa_.Rows[0]["TienBanDau"].ToString();
                txtTongTienKetCa.Text = _frmMain.BangNT_KetCa_.Rows[0]["TienKetCa"].ToString();
                txt500k.Text = _frmMain.BangNT_KetCa_.Rows[0]["T500000"].ToString();
                txt200k.Text = _frmMain.BangNT_KetCa_.Rows[0]["T200000"].ToString();
                txt100k.Text = _frmMain.BangNT_KetCa_.Rows[0]["T100000"].ToString();
                txt50k.Text = _frmMain.BangNT_KetCa_.Rows[0]["T50000"].ToString();
                txt20k.Text = _frmMain.BangNT_KetCa_.Rows[0]["T20000"].ToString();
                txt10k.Text = _frmMain.BangNT_KetCa_.Rows[0]["T10000"].ToString();
                txt5k.Text = _frmMain.BangNT_KetCa_.Rows[0]["T5000"].ToString();
                txt2k.Text = _frmMain.BangNT_KetCa_.Rows[0]["T2000"].ToString();
                txt1k.Text = _frmMain.BangNT_KetCa_.Rows[0]["T1000"].ToString();
                txt500.Text = _frmMain.BangNT_KetCa_.Rows[0]["T500"].ToString();
                txt200.Text = _frmMain.BangNT_KetCa_.Rows[0]["T200"].ToString();
            }
            else
            {
                txt500k.Focus();
                btnInLai.Enabled = false;
                CSQLUser user = new CSQLUser();
                txtTenThuNgan.Text = user.LayHoTenNhanVienTheoMa(CStaticBien.SmaTaiKhoan).Rows[0]["HoTen"].ToString();
                txtTienQuyDauCa.Text = chht_.LayDanhSachCauHinhHeThong().Rows[0]["TienQuy"].ToString();
                txtSoCa.Text = _frmMain.BangNT_KetCa_.Rows[0]["SoCa"].ToString();

            }
            Fr_DangXuLy.DongFormCho();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            //if (xuly_.printer != null)
            //{
            //    xuly_.NgatKetNoiMayIn(xuly_.printer);
            //}
            _frmMain.frmNT_KetCaEditisOpen_ = false;
            _frmMain.fNT_KetCa.LoadLenLuoi();
            this.Close();
        }
        bool xacnhan = false;
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_KetCa.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            btnDong.Enabled = false;
            CSQLNT_BanHang banhang_ = new CSQLNT_BanHang();
            CSQLNT_TraHangTuKhach trahang_ = new CSQLNT_TraHangTuKhach();
            DataTable dtbbanhang = banhang_.LayDanhSachTamTinh(CStaticBien.STenMayThuNgan, int.Parse(txtSoCa.Text));
            DataTable dtbtrahang = trahang_.LayDanhSachTamTinh(CStaticBien.STenMayThuNgan, int.Parse(txtSoCa.Text));

            CSQLNhaThuoc nhathuoc_ = new CSQLNhaThuoc();
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            DataTable dtbnhathuoc = nhathuoc_.LayNhaThuocTheoMa(chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString());
            string tennhathuoc_ = dtbnhathuoc.Rows[0]["TenNT"].ToString();
            string telnhathuoc_ = dtbnhathuoc.Rows[0]["Tel"].ToString();
            string tenthungan_ = txtTenThuNgan.Text;

            if (dtbbanhang != null && dtbbanhang.Rows.Count > 0)
            {
                if (MessageBox.Show("Phiếu tạm tính của BÁN HÀNG chưa được thanh toán hết.\n* Chọn YES ==>> Tất cả các phiếu tạm tính sẽ bị hủy.\n* Chọn NO ==>> Vui lòng quay lại phần Bán Hàng để thanh toán hết.", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < dtbbanhang.Rows.Count; i++)
                    {
                        string bhid_ = dtbbanhang.Rows[i]["BHid"].ToString();
                        banhang_.HuyPhieuBH(bhid_);
                    }
                }
                else
                {
                    btnDong.Enabled = true;
                    return;
                }
            }

            if (dtbtrahang != null && dtbtrahang.Rows.Count > 0)
            {
                if (MessageBox.Show("Phiếu tạm tính của TRẢ HÀNG chưa được thanh toán hết.\n* Chọn YES ==>> Tất cả các phiếu tạm tính sẽ bị hủy.\n* Chọn NO ==>> Vui lòng quay lại phần Bán Hàng để thanh toán hết.", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < dtbtrahang.Rows.Count; i++)
                    {
                        string THid_ = dtbtrahang.Rows[i]["THid"].ToString();
                        trahang_.NT_TraHang_HuyPhieu(THid_);
                    }
                }
                else
                {
                    btnDong.Enabled = true;
                    return;
                }
            }

            if (MessageBox.Show("Bạn thật sự muốn kết ca không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                #region  Xác nhận kết ca
                using (TransactionScope giaotac = new TransactionScope())
                {
                    try
                    {
                        ketca_.SCKCid = _frmMain.MaNT_KetCa_;
                        ketca_.STenMayThuNgan = CStaticBien.STenMayThuNgan;
                        ketca_.FTienBanDau = decimal.Parse(txtTienQuyDauCa.Text);
                        if (txt500k.Text == "")
                        {
                            ketca_.IT500k = 0;
                            txtTT500k.Text = "0";
                        }
                        else
                        {
                            ketca_.IT500k = int.Parse(txt500k.Text);
                        }
                        if (txt200k.Text == "")
                        {
                            ketca_.IT200k = 0;
                            txtTT200k.Text = "0";
                        }
                        else
                        {
                            ketca_.IT200k = int.Parse(txt200k.Text);
                        }
                        if (txt100k.Text == "")
                        {
                            ketca_.IT100k = 0;
                            txtTT100k.Text = "0";
                        }
                        else
                        {
                            ketca_.IT100k = int.Parse(txt100k.Text);
                        }
                        if (txt50k.Text == "")
                        {
                            ketca_.IT50k = 0;
                            txtTT50k.Text = "0";
                        }
                        else
                        {
                            ketca_.IT50k = int.Parse(txt50k.Text);
                        }
                        if (txt20k.Text == "")
                        {
                            ketca_.IT20k = 0;
                            txtTT20k.Text = "0";
                        }
                        else
                        {
                            ketca_.IT20k = int.Parse(txt20k.Text);
                        }
                        if (txt10k.Text == "")
                        {
                            ketca_.IT10k = 0;
                            txtTT10k.Text = "0";
                        }
                        else
                        {
                            ketca_.IT10k = int.Parse(txt10k.Text);
                        }
                        if (txt5k.Text == "")
                        {
                            ketca_.IT5k = 0;
                            txtTT5k.Text = "0";
                        }
                        else
                        {
                            ketca_.IT5k = int.Parse(txt5k.Text);
                        }
                        if (txt2k.Text == "")
                        {
                            ketca_.IT2k = 0;
                            txtTT2k.Text = "0";
                        }
                        else
                        {
                            ketca_.IT2k = int.Parse(txt2k.Text);
                        }
                        if (txt1k.Text == "")
                        {
                            ketca_.IT1k = 0;
                            txtTT1k.Text = "0";
                        }
                        else
                        {
                            ketca_.IT1k = int.Parse(txt1k.Text);
                        }
                        if (txt500.Text == "")
                        {
                            ketca_.IT500 = 0;
                            txtTT500.Text = "0";
                        }
                        else
                        {
                            ketca_.IT500 = int.Parse(txt500.Text);
                        }
                        if (txt200.Text == "")
                        {
                            ketca_.IT200 = 0;
                            txtTT200.Text = "0";
                        }
                        else
                        {
                            ketca_.IT200 = int.Parse(txt200.Text);
                        }

                        txtTongTienKetCa.Text = (decimal.Parse(txtTT500k.Text) + decimal.Parse(txtTT200k.Text) + decimal.Parse(txtTT100k.Text) + decimal.Parse(txtTT50k.Text) + decimal.Parse(txtTT20k.Text) + decimal.Parse(txtTT10k.Text) + decimal.Parse(txtTT5k.Text) + decimal.Parse(txtTT2k.Text) + decimal.Parse(txtTT1k.Text) + decimal.Parse(txtTT500.Text) + decimal.Parse(txtTT200.Text)).ToString();
                        
                        if (txtTongTienKetCa.Text == "")
                        { tongtienketca = 0; }
                        else
                        { tongtienketca = decimal.Parse(txtTongTienKetCa.Text); }
                        
                        DataTable LayTien = banhang_.LayDataTheoSoCa(int.Parse(txtSoCa.Text));

                        if (int.Parse(LayTien.Rows[0]["BHid"].ToString()) > 0 && LayTien.Rows.Count > 0)
                        {
                            tiencuaca = Convert.ToDecimal(LayTien.Rows[0]["TTBanCoTAXDaGiamGia"].ToString());
                        }
                        else
                        {
                            tiencuaca = 0;
                        }

                        if (tiencuaca != 0 && tongtienketca == 0)
                        {
                            MessageBox.Show("Số ca này đã có giao dịch bán hàng nhưng không có số liệu kết ca. Vui lòng kiểm tra lại.");
                            btnDong.Enabled = true;
                            return;
                        }
                        else if (tiencuaca == 0 && tongtienketca != 0)
                        {
                            MessageBox.Show("Số ca này đã không có giao dịch bán hàng nhưng có số liệu kết ca. Vui lòng kiểm tra lại.");
                            btnDong.Enabled = true;
                            return;
                        }
                        else
                        {
                            ketca_.FTienKetCa = tongtienketca;
                            ketca_.SUserID = CStaticBien.SmaTaiKhoan;

                            //update số tiền vào kết ca
                            ketca_.Update_SoLieuKetCa(ketca_);
                        }
                        giaotac.Complete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                #endregion

                KhoaTextBox_Tien();

                #region in xác nhận
                PosDeviceTag tag = xuly_.currentDevice;
                if (tag != null)
                {
                    try
                    {
                        InXacNhan.PrintDeclare(xuly_, tennhathuoc_, telnhathuoc_, CStaticBien.STenMayThuNgan, tenthungan_, txtSoCa.Text, ketca_.IT500k, ketca_.IT200k, ketca_.IT100k, ketca_.IT50k, ketca_.IT20k, ketca_.IT10k, ketca_.IT5k, ketca_.IT2k, ketca_.IT1k, ketca_.IT500, ketca_.IT200, decimal.Parse(txtTienQuyDauCa.Text), ketca_.FTienKetCa);
                        xacnhan = true;
                    }
                    catch
                    {
                        if (xacnhan == false)
                        {
                            MessageBox.Show("Nguồn máy in đang tắt hoặc dây USB bị mất kết nối.\n Vui Lòng chọn in lại sau", "Xác Nhận");
                        }
                        else
                        {
                            xacnhan = false;
                        }
                    }
                }
                #endregion

                statusTB.Text = "Đã xác nhận thành công";
                btnXacNhan.Enabled = false;
                btnKetThucCa.Enabled = true;
                btnKetThucCa.Focus();
            }
            else
            {
                return;
            }
        }

        private void KhoaTextBox_Tien()
        {
            txt500k.Enabled = false;
            txt200k.Enabled = false;
            txt100k.Enabled = false;
            txt50k.Enabled = false;
            txt20k.Enabled = false;
            txt10k.Enabled = false;
            txt5k.Enabled = false;
            txt2k.Enabled = false;
            txt1k.Enabled = false;
            txt500.Enabled = false;
            txt200.Enabled = false;
            txtTT500k.Enabled = false;
            txtTT200k.Enabled = false;
            txtTT100k.Enabled = false;
            txtTT50k.Enabled = false;
            txtTT20k.Enabled = false;
            txtTT10k.Enabled = false;
            txtTT5k.Enabled = false;
            txtTT2k.Enabled = false;
            txtTT1k.Enabled = false;
            txtTT500.Enabled = false;
            txtTT200.Enabled = false;
        }
        bool kc = false;
        private void btnKetThucCa_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_KetCa.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (qtc.KiemTraQuyenIn(_frmMain.fNT_KetCa.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNT_BanHang banhang_ = new CSQLNT_BanHang();
            CSQLNT_TraHangTuKhach trahang_ = new CSQLNT_TraHangTuKhach();
            DataTable dtbbanhang = banhang_.LayDataTheoSoCa(int.Parse(txtSoCa.Text));
            DataTable dtbtrahang = trahang_.LayDataTheoSoCa(int.Parse(txtSoCa.Text));
            DataTable dtbPhieuHuyBanHang = banhang_.LayPhieuHuyTheoSoCa(int.Parse(txtSoCa.Text));
            DataTable dtbPhieuHuyTraHang = trahang_.LayPhieuHuyTheoSoCa(int.Parse(txtSoCa.Text));

            CSQLNhaThuoc nhathuoc_ = new CSQLNhaThuoc();
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            DataTable dtbnhathuoc = nhathuoc_.LayNhaThuocTheoMa(chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString());
            string tennhathuoc_ = dtbnhathuoc.Rows[0]["TenNT"].ToString();
            string telnhathuoc_ = dtbnhathuoc.Rows[0]["Tel"].ToString();
            string tenthungan_ = txtTenThuNgan.Text;

            #region Lấy Tổng Số Tiền Giảm Giá và Tiền Trả Hàng
            if (int.Parse(dtbbanhang.Rows[0]["BHid"].ToString()) > 0 && dtbbanhang.Rows.Count > 0)
            {

                ttcotaxdagiam_ = Math.Round(Convert.ToDecimal(dtbbanhang.Rows[0]["TTBanCoTAXDaGiamGia"].ToString()), 0);
                ttcotaxchuagiam_ = Math.Round(Convert.ToDecimal(dtbbanhang.Rows[0]["TTBanCoTAXChuaGiamGia"].ToString()), 0);
                ttgiam_ = ttcotaxchuagiam_ - ttcotaxdagiam_;
                sobillban = int.Parse(dtbbanhang.Rows[0]["BHid"].ToString());
                sobillhuybanhang = int.Parse(dtbPhieuHuyBanHang.Rows[0]["BHid"].ToString());
            }
            else
            {
                ttgiam_ = 0;
                ttcotaxdagiam_ = 0;
                sobillban = 0;
                sobillhuybanhang = 0;
            }
            if (int.Parse(dtbtrahang.Rows[0]["THid"].ToString()) > 0 && dtbtrahang.Rows.Count > 0)
            {
                ttcotaxdatinhphitra_ = Math.Round(Convert.ToDecimal(dtbtrahang.Rows[0]["TTTraCoTAXDaTinhPhiTraHang"].ToString()), 0);
                ttcotaxchuatinhphitra_ = Math.Round(Convert.ToDecimal(dtbtrahang.Rows[0]["TTTraCoTAXChuaTinhPhiTraHang"].ToString()), 0);
                tttra_ = ttcotaxchuatinhphitra_ - ttcotaxdatinhphitra_;
                sobilltra = int.Parse(dtbtrahang.Rows[0]["THid"].ToString());
                sobillhuytrahang = int.Parse(dtbPhieuHuyTraHang.Rows[0]["THid"].ToString());
            }
            else
            {
                tttra_ = 0;
                ttcotaxdatinhphitra_ = 0;
                sobilltra = 0;
                sobillhuytrahang = 0;
            }
            #endregion

            #region kết ca
            PosDeviceTag tag = xuly_.currentDevice;
            if (tag != null)
            {
                try
                {
                    ketca_.Update_IsDaKetCa(_frmMain.MaNT_KetCa_);
                    Inketca.PrintCloseSales(xuly_, tennhathuoc_, telnhathuoc_, CStaticBien.STenMayThuNgan, tenthungan_, txtSoCa.Text, ttgiam_, tttra_, ttcotaxdagiam_, ttcotaxdatinhphitra_, decimal.Parse(txtTienQuyDauCa.Text), decimal.Parse(txtTongTienKetCa.Text), sobillban, sobilltra, sobillhuybanhang);
                    kc = true;
                    statusTB.Text = "Đã kết thúc thành công";
                }
                catch
                {
                    if (kc == false)
                    {
                        MessageBox.Show("Nguồn máy in đang tắt hoặc dây USB bị mất kết nối.\n Vui Lòng chọn in lại sau", "Xác Nhận");
                    }
                    else
                    {
                        kc = false;
                    }
                }
            }
            #endregion
     
            btnKetThucCa.Enabled = false;
            btnInLai.Enabled = true;
            btnDong.Enabled = true;
            _frmMain.fNT_KetCa.rgvDSKetCa.DataSource = ketca_.LayDanhSachLenLuoi();
            //if (xuly_.printer != null)
            //{
            //    xuly_.NgatKetNoiMayIn(xuly_.printer);
            //}
            _frmMain.frmNT_KetCaEditisOpen_ = false;
            this.Close();

            Application.Restart(); 
        }

        private void txtTienQuyDauCa_TextChanged(object sender, EventArgs e)
        {
            if (txtTienQuyDauCa.Text.Length > 0)
            {
                txtTienQuyDauCa.Text = Convert.ToDecimal(txtTienQuyDauCa.Text).ToString("#,###");
                txtTienQuyDauCa.Select(txtTienQuyDauCa.TextLength, 0);
            }
        }
        #region Xử lý các kiểu nhập vào textbox
        private void txt500k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt200k.Focus();
            }
        }

        private void txt200k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt100k.Focus();
            }
        }

        private void txt100k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt50k.Focus();
            }
        }

        private void txt50k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt20k.Focus();
            }
        }

        private void txt20k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt10k.Focus();
            }
        }

        private void txt10k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt5k.Focus();
            }
        }

        private void txt5k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt2k.Focus();
            }
        }

        private void txt2k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt1k.Focus();
            }
        }

        private void txt1k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt500.Focus();
            }
        }

        private void txt500_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt200.Focus();
            }
        }

        private void txt200_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt500k_TextChanged(object sender, EventArgs e)
        {
            if (txt500k.Text == "")
            {
                txtTT500k.Text = "0";
            }
            else
            {
                txtTT500k.Text = (int.Parse(txt500k.Text) * 500000).ToString("#,###");
            }
        }

        private void txt200k_TextChanged(object sender, EventArgs e)
        {
            if (txt200k.Text == "")
            {
                txtTT200k.Text = "0";
            }
            else
            {
                txtTT200k.Text = (int.Parse(txt200k.Text) * 200000).ToString("#,###");
            }
        }

        private void txt100k_TextChanged(object sender, EventArgs e)
        {
            if (txt100k.Text == "")
            {
                txtTT100k.Text = "0";
            }
            else
            {
                txtTT100k.Text = (int.Parse(txt100k.Text) * 100000).ToString("#,###");
            }
        }

        private void txt50k_TextChanged(object sender, EventArgs e)
        {
            if (txt50k.Text == "")
            {
                txtTT50k.Text = "0";
            }
            else
            {
                txtTT50k.Text = (int.Parse(txt50k.Text) * 50000).ToString("#,###");
            }
        }

        private void txt20k_TextChanged(object sender, EventArgs e)
        {
            if (txt20k.Text == "")
            {
                txtTT20k.Text = "0";
            }
            else
            {
                txtTT20k.Text = (int.Parse(txt20k.Text) * 20000).ToString("#,###");
            }
        }

        private void txt10k_TextChanged(object sender, EventArgs e)
        {
            if (txt10k.Text == "")
            {
                txtTT10k.Text = "0";
            }
            else
            {
                txtTT10k.Text = (int.Parse(txt10k.Text) * 10000).ToString("#,###");
            }
        }

        private void txt5k_TextChanged(object sender, EventArgs e)
        {
            if (txt5k.Text == "")
            {
                txtTT5k.Text = "0";
            }
            else
            {
                txtTT5k.Text = (int.Parse(txt5k.Text) * 5000).ToString("#,###");
            }
        }

        private void txt2k_TextChanged(object sender, EventArgs e)
        {
            if (txt2k.Text == "")
            {
                txtTT2k.Text = "0";
            }
            else
            {
                txtTT2k.Text = (int.Parse(txt2k.Text) * 2000).ToString("#,###");
            }
        }

        private void txt1k_TextChanged(object sender, EventArgs e)
        {
            if (txt1k.Text == "")
            {
                txtTT1k.Text = "0";
            }
            else
            {
                txtTT1k.Text = (int.Parse(txt1k.Text) * 1000).ToString("#,###");
            }
        }

        private void txt500_TextChanged(object sender, EventArgs e)
        {
            if (txt500.Text == "")
            {
                txtTT500.Text = "0";
            }
            else
            {
                txtTT500.Text = (int.Parse(txt500.Text) * 500).ToString("#,###");
            }
        }

        private void txt200_TextChanged(object sender, EventArgs e)
        {
            if (txt200.Text == "")
            {
                txtTT200.Text = "0";
            }
            else
            {
                txtTT200.Text = (int.Parse(txt200.Text) * 200).ToString("#,###");
            }
        }
        #endregion

        private void txtTongTienKetCa_TextChanged(object sender, EventArgs e)
        {
            if (txtTongTienKetCa.Text.Length > 0)
            {
                txtTongTienKetCa.Text = Convert.ToDecimal(txtTongTienKetCa.Text).ToString("#,###");
                txtTongTienKetCa.Select(txtTongTienKetCa.TextLength, 0);
            }
        }
        bool inlaikc = false;
        private void btnInLai_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(_frmMain.fNT_KetCa.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            PosDeviceTag tag = xuly_.currentDevice;
            if (tag != null)
            {
                try
                {
                    InLaiKetCa();
                    inlaikc = true;
                }
                catch
                {
                    //xuly_.NgatKetNoiMayIn(xuly_.printer);
                }
                finally
                {
                    if (inlaikc == false)
                    {
                        if (MessageBox.Show("Máy in bị mất kết nối.\n* Chọn YES ==>> Vui lòng kiểm tra lại nguồn hoặc dây USB của máy in rồi mới được in.\n* Chọn NO ==>> Thì không cần in.", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //xuly_.KetNoiMayIn();
                            InLaiKetCa();
                        }
                    }
                    else
                    {
                        inlaikc = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Máy in đã mất kết nối không thể in được.\nVui Lòng kiểm tra lại máy in.", " Xác Nhận");
            }
        }

        private void InLaiKetCa()
        {
            CSQLNT_BanHang banhang_ = new CSQLNT_BanHang();
            CSQLNT_TraHangTuKhach trahang_ = new CSQLNT_TraHangTuKhach();

            CSQLNhaThuoc nhathuoc_ = new CSQLNhaThuoc();
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            DataTable dtbnhathuoc = nhathuoc_.LayNhaThuocTheoMa(chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString());
            string tennhathuoc_ = dtbnhathuoc.Rows[0]["TenNT"].ToString();
            string telnhathuoc_ = dtbnhathuoc.Rows[0]["Tel"].ToString();
            string tenthungan_ = txtTenThuNgan.Text;

            InXacNhan.PrintDeclare(xuly_, tennhathuoc_, telnhathuoc_, CStaticBien.STenMayThuNgan, tenthungan_, txtSoCa.Text, int.Parse(txt500k.Text), int.Parse(txt200k.Text), int.Parse(txt100k.Text), int.Parse(txt50k.Text), int.Parse(txt20k.Text), int.Parse(txt10k.Text), int.Parse(txt5k.Text), int.Parse(txt2k.Text), int.Parse(txt1k.Text), int.Parse(txt500.Text), int.Parse(txt200.Text), decimal.Parse(txtTienQuyDauCa.Text), decimal.Parse(txtTongTienKetCa.Text));

            DataTable dtbbanhang = banhang_.LayDataTheoSoCa(int.Parse(txtSoCa.Text));
            DataTable dtbtrahang = trahang_.LayDataTheoSoCa(int.Parse(txtSoCa.Text));
            DataTable dtbPhieuHuyBanHang = banhang_.LayPhieuHuyTheoSoCa(int.Parse(txtSoCa.Text));
            DataTable dtbPhieuHuyTraHang = trahang_.LayPhieuHuyTheoSoCa(int.Parse(txtSoCa.Text));

            if (int.Parse(dtbbanhang.Rows[0]["BHid"].ToString()) > 0 && dtbbanhang.Rows.Count > 0)
            {

                ttcotaxdagiam_ = Convert.ToDecimal(dtbbanhang.Rows[0]["TTBanCoTAXDaGiamGia"].ToString());
                ttcotaxchuagiam_ = Convert.ToDecimal(dtbbanhang.Rows[0]["TTBanCoTAXChuaGiamGia"].ToString());
                ttgiam_ = ttcotaxchuagiam_ - ttcotaxdagiam_;
                sobillban = int.Parse(dtbbanhang.Rows[0]["BHid"].ToString());
                sobillhuybanhang = int.Parse(dtbPhieuHuyBanHang.Rows[0]["BHid"].ToString());
            }
            else
            {
                ttgiam_ = 0;
                ttcotaxdagiam_ = 0;
                sobillban = 0;
                sobillhuybanhang = 0;
            }
            if (int.Parse(dtbtrahang.Rows[0]["THid"].ToString()) > 0 && dtbtrahang.Rows.Count > 0)
            {
                ttcotaxdatinhphitra_ = Convert.ToDecimal(dtbtrahang.Rows[0]["TTTraCoTAXDaTinhPhiTraHang"].ToString());
                ttcotaxchuatinhphitra_ = Convert.ToDecimal(dtbtrahang.Rows[0]["TTTraCoTAXChuaTinhPhiTraHang"].ToString());
                tttra_ = ttcotaxchuatinhphitra_ - ttcotaxdatinhphitra_;
                sobilltra = int.Parse(dtbtrahang.Rows[0]["THid"].ToString());
                sobillhuytrahang = int.Parse(dtbPhieuHuyTraHang.Rows[0]["THid"].ToString());
            }
            else
            {
                tttra_ = 0;
                ttcotaxdatinhphitra_ = 0;
                sobilltra = 0;
                sobillhuytrahang = 0;
            }
            Inketca.PrintCloseSales(xuly_, tennhathuoc_, telnhathuoc_, CStaticBien.STenMayThuNgan, tenthungan_, txtSoCa.Text, ttgiam_, tttra_, ttcotaxdagiam_, ttcotaxdatinhphitra_, decimal.Parse(txtTienQuyDauCa.Text), decimal.Parse(txtTongTienKetCa.Text), sobillban, sobilltra, sobillhuybanhang);
        }

    }
}
