using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ECOPharma2013.SQL;
using Telerik.WinControls.Data;
using ECOPharma2013.DuLieu;
using ECOPharma2013.Printer_POS;
using System.Threading;

namespace ECOPharma2013
{
    public partial class frmNT_TraHangEdit : Telerik.WinControls.UI.RadForm
    {
        string nvtrahang, bhctid, lot;
        DateTime handung;
        frmMain fmain;
        decimal slcothetra;
        string th_thid, th_socttra;
        static bool isDaThanhToan;
        static bool isHangDacBiet;
        int isCoQuyenTraHang = 0;
        XuLyMayInPos xuly_;
        public frmNT_TraHangEdit(frmMain _fmain)
        {
            InitializeComponent();
            fmain = _fmain;
        }

        private void btnLayPhieuBan_Click(object sender, EventArgs e)
        {
            isCoQuyenTraHang = 0;
            try
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                fmain.fTraHang_TKXacNhan = new frmTraHang_TKXacNhan(fmain);
                if (qtc.KiemTraQuyenThem_Sua(fmain.fTraHang_TKXacNhan.Name) == true)
                {
                    isCoQuyenTraHang = 1;
                }
                else
                {
                    isCoQuyenTraHang = 0;
                }
                txtSoPhieuBan.Enabled = false;
            }
            catch { }


            if (txtSoPhieuBan.Text.Length > 0)
            {
                //fmain.fTraHang_TKXacNhan = new frmTraHang_TKXacNhan(fmain);
                //fmain.fTraHang_TKXacNhan.ShowDialog();
                CSQLNT_BanHangCT bhct = new CSQLNT_BanHangCT();
                DataTable dtb = bhct.LayDSBanHangDaThanhToanTheoSoCT(txtSoPhieuBan.Text);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    isHangDacBiet = (bool)dtb.Rows[0]["IsKhoDacBiet"];
                    rgvChiTietPhieuBanGoc.DataSource = dtb;
                }

                CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
                DataTable dtbth = th.NT_TraHangTuKhach_LayDSTraHangTheoSoPhieuBan(txtSoPhieuBan.Text);
                if (dtbth != null && dtbth.Rows.Count > 0)
                {
                    rgvLSTraHang.DataSource = dtbth;
                }
                cboBanChinh.Focus();
            }
            else
            {
                txtSoPhieuBan.Focus();
            }
        }

        public void LayPhieuBan()
        {
            CSQLNT_BanHangCT bhct = new CSQLNT_BanHangCT();
            DataTable dtb = bhct.LayDSBanHangDaThanhToanTheoSoCT(txtSoPhieuBan.Text);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                rgvChiTietPhieuBanGoc.DataSource = dtb;
            }

            CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
            DataTable dtbth = th.NT_TraHangTuKhach_LayDSTraHangTheoSoPhieuBan(txtSoPhieuBan.Text);
            if (dtbth != null && dtbth.Rows.Count > 0)
            {
                rgvLSTraHang.DataSource = dtbth;
            }
            cboBanChinh.Focus();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            //if (xuly_.printer != null)
            //{
            //    xuly_.NgatKetNoiMayIn(xuly_.printer);
            //}
            fmain.frmNT_TraHangEditisOpen_ = false;
            fmain.fNT_TraHang.LoadLenLuoi();
            this.Close();
        }
       
        private void rgvChiTietPhieuBanGoc_DoubleClick(object sender, EventArgs e)
        {   
            radMultiColumnComboboxMaSP.SelectedValue = rgvChiTietPhieuBanGoc.CurrentRow.Cells["colSPid"].Value;
            radMultiColumnComboBoxTenSP.SelectedValue = rgvChiTietPhieuBanGoc.CurrentRow.Cells["colSPid"].Value;
            //cboDVTra.SelectedValue = rgvChiTietPhieuBanGoc.CurrentRow.Cells["colDVBanid"].Value;
            if (radMultiColumnComboboxMaSP.SelectedValue != null && txtSoPhieuBan.Text.Length > 0)
            {

                CSQLNT_TraHangTuKhach thtk = new CSQLNT_TraHangTuKhach();
                DataTable dtbDsTraHang = thtk.NT_TraHangTuKhach_LayDSTraHangTheoSoPhieuBan(txtSoPhieuBan.Text);
                rgvLSTraHang.DataSource = dtbDsTraHang;
                bhctid = rgvChiTietPhieuBanGoc.CurrentRow.Cells["colBHCTid"].Value.ToString();
                lot = rgvChiTietPhieuBanGoc.CurrentRow.Cells["colLot"].Value.ToString();
                txtSoLo.Text = lot;
                handung = DateTime.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["colDate"].Value.ToString());
                txtHanDung.Text = handung.ToString("dd/MM/yyyy");
                CSQLNT_TraHangTuKhachCT thtkct = new CSQLNT_TraHangTuKhachCT();
                DataTable dtb = thtkct.NT_TraHangTuKhach_LaySLCoTheTra(txtSoPhieuBan.Text, bhctid, radMultiColumnComboboxMaSP.SelectedValue.ToString(), lot, handung);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    try
                    {
                        slcothetra = decimal.Parse(dtb.Rows[0][0].ToString());
                        txtSLCoTheTra.Text = dtb.Rows[0][0].ToString();
                        cboDVTra.SelectedValue = dtb.Rows[0][1];
                    }
                    catch
                    {
                        statusTB.Text = "Không thế lấy được số lượng có thể trả!";
                    }
                }
                else
                {
                    statusTB.Text = "Không có số lượng có thể trả!";
                }
            }
            cboDVTra.Focus();
        }


        private void LayDSNhanVienLenCombobox()
        {
            if (CStaticBien.SMaBoPhan.Length == 0)
            {
                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                CStaticBien.SMaBoPhan = chht.LayMaBPThongTinChiNhanh();
            }

            CSQLNhanVien nv = new CSQLNhanVien();
            cboBanChinh.ValueMember = "NVID";
            cboBanChinh.DisplayMember = "HoTen";
            cboBanChinh.DataSource = nv.LayDSNhanVienTheoBoPhan(CStaticBien.SMaBoPhan);
            cboBanChinh.SelectedIndex = -1;
            if (nvtrahang!= null && nvtrahang.Length > 0)
            {
                cboBanChinh.SelectedValue = nvtrahang;
            }
        }
        private void LayDSPhiTraHangLenCombobox()
        {
            CSQLGiamGia gg = new CSQLGiamGia();
            cboPhiTraHang.DisplayMember = "TenGG";
            cboPhiTraHang.ValueMember = "GGID";
            cboPhiTraHang.DataSource = gg.LayDanhSachGiamGiaLenLuoi(fmain.IsXemTatCa_);
        }
        private void LayDSMaSP_TenSPLenMultiColumnCombobox()
        {
            CSQLNT_BanHang bh = new CSQLNT_BanHang();
            DataTable dtb = bh.LayDSMaSP_TenSPLenMultiColumnComboBox();
            radMultiColumnComboboxMaSP.DisplayMember = "MaSP";
            radMultiColumnComboboxMaSP.ValueMember = "SPID";
            radMultiColumnComboBoxTenSP.DisplayMember = "TenSP";
            radMultiColumnComboBoxTenSP.ValueMember = "SPID";
            radMultiColumnComboboxMaSP.DataSource = dtb;
            radMultiColumnComboBoxTenSP.DataSource = bh.LayDSMaSP_TenSPLenMultiColumnComboBox();
            radMultiColumnComboboxMaSP.SelectedIndex = -1;
            radMultiColumnComboBoxTenSP.SelectedIndex = -1;
            FilterDescriptor descriptor = new FilterDescriptor(this.radMultiColumnComboboxMaSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
            this.radMultiColumnComboboxMaSP.EditorControl.FilterDescriptors.Add(descriptor);
            this.radMultiColumnComboboxMaSP.DropDownStyle = RadDropDownStyle.DropDown;
            radMultiColumnComboboxMaSP.AutoFilter = true;

            FilterDescriptor descriptor1 = new FilterDescriptor(this.radMultiColumnComboBoxTenSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
            this.radMultiColumnComboBoxTenSP.EditorControl.FilterDescriptors.Add(descriptor1);
            this.radMultiColumnComboBoxTenSP.DropDownStyle = RadDropDownStyle.DropDown;
            radMultiColumnComboBoxTenSP.AutoFilter = true;
        }

        private void LayDSDVTCuaSanPham()
        {
            try
            {
                //Lấy Danh sách Đơn vị tính của sản phẩm
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                DataTable dtbdvt = hsqd.LayDVTTheoSPID(radMultiColumnComboboxMaSP.SelectedValue.ToString());
                cboDVTra.DisplayMember = "TenTuDVT";
                cboDVTra.ValueMember = "TuDVTID";
                cboDVTra.DataSource = dtbdvt;
                cboDVTra.SelectedIndex = -1;
            }
            catch
            {
                cboDVTra.DataSource = null;
            }
        }

        public void NhanDuLieuTuFrmTraHang(int ca)
        {
            CStaticBien.iSoCa = ca;
        }
        private void frmNT_TraHangEdit_Load(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_TraHang.Name) == true)
            {
                isCoQuyenTraHang = 1;
            }
            else
                isCoQuyenTraHang = 0;

            xuly_ = new XuLyMayInPos(this, statusTB);

            txtSoPhieuBan.Focus();

            int soca;
            if (CStaticBien.iSoCa == null || CStaticBien.iSoCa <= 0)
            {
                CSQLNT_KetCa kc = new CSQLNT_KetCa();
                soca = kc.KiemTraVaLaySoCa(CStaticBien.STenMayThuNgan);
                CStaticBien.iSoCa = soca;
            }
            else
            {
                soca = CStaticBien.iSoCa;
            }
            if (soca != null && soca != -1)
            {                
                LayDSNhanVienLenCombobox();
                LayDSPhiTraHangLenCombobox();
                LayDSMaSP_TenSPLenMultiColumnCombobox();
            }
            else
            {
                MessageBox.Show("Ca chưa tạo được, xin hãy thoát ra!", "Lỗi", MessageBoxButtons.OK);
            }
        }


        private void radMultiColumnComboboxMaSP_SelectedValueChanged(object sender, EventArgs e)
        {
            LayDSDVTCuaSanPham();
        }

        private void cboBanChinh_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cboDVTra_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (radMultiColumnComboboxMaSP.SelectedValue != null && slcothetra != null && slcothetra > 0 && cboDVTra.SelectedValue != null)
                {
                    CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                    decimal tyle = hsqd.TinhTyLeHSQD(radMultiColumnComboboxMaSP.SelectedValue.ToString(), cboDVTra.SelectedValue.ToString());
                    txtSLCoTheTra.Text =String.Format("{0:0,0.00}", Math.Round((decimal)(slcothetra * tyle)));
                }
            }
            catch { txtSLCoTheTra.Text = "0"; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isCoQuyenTraHang == 0)
            {
                fmain.fTraHang_TKXacNhan = new frmTraHang_TKXacNhan(fmain);
                fmain.fTraHang_TKXacNhan.ShowDialog();
            }
            if (isCoQuyenTraHang == 1)
            {
                Them_Click();
            }
        }

        public void IsXacNhanOK(int isOK)
        {
            isCoQuyenTraHang = isOK;
        }

        private void Them_Click()
        {
            try
            {
                if (txtSLTra.Text.Length > 0)
                {
                    if (decimal.Parse(txtSLTra.Text) <= decimal.Parse(txtSLCoTheTra.Text))
                    {
                        //Trả master
                        if (th_thid == null && cboBanChinh.SelectedValue != null)
                        {
                            if (cboBanChinh.SelectedValue != null)
                            {
                                CSQLNT_TraHangTuKhach thtk = new CSQLNT_TraHangTuKhach();
                                string[] kqthemth = thtk.NT_TraHangTuKhach_Them(txtSoPhieuBan.Text, CStaticBien.STenMayThuNgan, CStaticBien.SmaTaiKhoan, cboBanChinh.SelectedValue.ToString(), CStaticBien.iSoCa, "11111111-1111-1111-1111-111111111111", dtNgayTra.Value, cboPhiTraHang.SelectedValue.ToString(), isHangDacBiet);
                                th_thid = kqthemth[0];
                                th_socttra = kqthemth[1];
                                txtSoPhieuTra.Text = th_socttra;
                            }
                            else
                            {
                                statusTB.Text = "Bạn chưa chọn nv bán chính!";
                                return;
                            }
                        }

                        //Trả detail
                        if (th_thid.Length > 0 && bhctid.Length > 0 && cboBanChinh.SelectedValue != null)
                        {
                            //bhctid = rgvChiTietPhieuBanGoc.CurrentRow.Cells["colBHCTid"].Value.ToString();
                            lot = rgvChiTietPhieuBanGoc.CurrentRow.Cells["ColLot"].Value.ToString();
                            handung = DateTime.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["ColDate"].Value.ToString());
                            CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                            decimal tyleban = hsqd.TinhTyLeHSQD_Thuan(rgvChiTietPhieuBanGoc.CurrentRow.Cells["colSPID"].Value.ToString(), rgvChiTietPhieuBanGoc.CurrentRow.Cells["colDVBanID"].Value.ToString());

                            CSQLNT_TraHangTuKhachCT thtkct = new CSQLNT_TraHangTuKhachCT();
                            string kq = thtkct.Them( th_thid, bhctid,

                                    radMultiColumnComboboxMaSP.SelectedValue.ToString(),
                                    int.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["colSTT"].Value.ToString()),
                                    rgvChiTietPhieuBanGoc.CurrentRow.Cells["colMaKho"].Value.ToString(),
                                    decimal.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["ColSLBan"].Value.ToString()),
                                    rgvChiTietPhieuBanGoc.CurrentRow.Cells["colDVBanID"].Value.ToString(),
                                    rgvChiTietPhieuBanGoc.CurrentRow.Cells["ColLot"].Value.ToString(),
                                    DateTime.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["ColDate"].Value.ToString()),

                                decimal.Parse(txtSLTra.Text), 
                                cboDVTra.SelectedValue.ToString(),

                                    decimal.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["ColDonGiaVonChuaTax"].Value.ToString()) / tyleban,
                                    ((decimal.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["colDonGiaBanChuaTAXChuaGiamGia"].Value.ToString()) - (decimal.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["colDonGiaBanChuaTAXChuaGiamGia"].Value.ToString()) * decimal.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["colGiaTriGiamGia"].Value.ToString()) / 100)) / tyleban),//19
                                
                                cboPhiTraHang.SelectedValue.ToString(),

                                    decimal.Parse(rgvChiTietPhieuBanGoc.CurrentRow.Cells["ColPhanTramTax"].Value.ToString()),
                                    rgvChiTietPhieuBanGoc.CurrentRow.Cells["colNSXID"].Value.ToString()
                                );

                           // if (kq > 0)
                            if (kq.Equals("OK"))
                            {
                                rgvChiTietPhieuTra.DataSource = thtkct.NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoSoCTTra(th_socttra);
                                CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
                                txtTongTien.Text = Convert.ToDecimal(th.NT_TraHang_LayTongTienTheoTHID(th_thid).ToString()).ToString("#,###");
                                DataTable dtb = thtkct.NT_TraHangTuKhach_LaySLCoTheTra(txtSoPhieuBan.Text, bhctid , radMultiColumnComboboxMaSP.SelectedValue.ToString(),lot , handung );
                                radMultiColumnComboboxMaSP.SelectedIndex = -1;
                                radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                                txtSLTra.Text = "";
                                txtSoLo.Text = "";
                                txtHanDung.Text = "";
                                cboDVTra.SelectedIndex = -1;
                                if (dtb != null && dtb.Rows.Count > 0)
                                {
                                    try
                                    {
                                        slcothetra = decimal.Parse(dtb.Rows[0][0].ToString());
                                        txtSLCoTheTra.Text = dtb.Rows[0][0].ToString();
                                        cboDVTra.SelectedValue = dtb.Rows[0][1];
                                        rgvChiTietPhieuTra.Focus();
                                    }
                                    catch
                                    {
                                        statusTB.Text = "Không thế lấy được số lượng có thể trả!";
                                    }
                                }
                                else
                                {
                                    statusTB.Text = "Không xác định được số lượng có thể trả!";
                                }
                            }
                        }
                        else
                        {
                            statusTB.Text = "Bạn chưa chọn nv bán chính!";
                            return;
                        }
                    }
                    else
                    {
                        statusTB.Text = "Số lượng trả lớn hơn số lượng có thể bán! Hãy Kiểm tra lại!";
                    }
                }
                else
                {
                    statusTB.Text = "Bạn chưa nhập vào số lượng trả!";
                }
            }
            catch { }
        }

        private void btnHuySP_Click(object sender, EventArgs e)
        {
            try
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_TraHang.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                if (rgvChiTietPhieuTra.CurrentRow.Cells["colTHCTid"].Value != null)
                {
                    CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
                    //th.NT_TraHang_KiemTraThanhToan(rgvChiTietPhieuTra.CurrentRow.Cells["colTHCTid"].Value.ToString());
                    CSQLNT_TraHangTuKhachCT thct = new CSQLNT_TraHangTuKhachCT();
                    int kq = thct.NT_TraHangCT_Huy1CT(rgvChiTietPhieuTra.CurrentRow.Cells["colTHCTid"].Value.ToString());
                    if (kq > 0)
                    {
                        rgvChiTietPhieuTra.DataSource = thct.NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoSoCTTra(th_socttra);
                        //CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
                        txtTongTien.Text = Convert.ToDecimal(th.NT_TraHang_LayTongTienTheoTHID(th_thid).ToString()).ToString("#,###");
                        //try
                        //{
                        //    DataTable dtb = thct.NT_TraHangTuKhach_LaySLCoTheTra(txtSoPhieuBan.Text, radMultiColumnComboboxMaSP.SelectedValue.ToString());

                        //    if (dtb != null && dtb.Rows.Count > 0)
                        //    {
                        //        try
                        //        {
                        //            slcothetra = decimal.Parse(dtb.Rows[0][0].ToString());
                        //            txtSLCoTheTra.Text = dtb.Rows[0][0].ToString();
                        //            cboDVTra.SelectedValue = dtb.Rows[0][1];
                        //        }
                        //        catch
                        //        {
                        //            statusTB.Text = "Không thế lấy được số lượng có thể trả!";
                        //        }
                        //    }
                        //    else
                        //    {
                        //        statusTB.Text = "Không xác định được số lượng có thể trả!";
                        //    }
                        //}
                        //catch { return; }
                    }
                }
            }
            catch { }
        }

        private void rgvLSTraHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgvLSTraHang.CurrentRow.Cells["colSoCTTra"].Value != null && rgvLSTraHang.CurrentRow.Cells["colTHID"].Value != null)
                {
                    th_socttra = rgvLSTraHang.CurrentRow.Cells["colSoCTTra"].Value.ToString();
                    th_thid = rgvLSTraHang.CurrentRow.Cells["colTHID"].Value.ToString();
                    txtSoPhieuTra.Text = th_socttra;
                    frm_LayDSTraHangChiTiet(th_thid, th_socttra);
                }
            }
            catch { }
        }
        
        private void frm_LayDSTraHangChiTiet(string thid, string socttra)
        {
            //Lấy giá trị cho biến isDaThanhToan
            CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
            isDaThanhToan = th.NT_TraHang_KiemTraThanhToan(thid);
            if (isDaThanhToan == true)
            {
                btnHuyPhieu.Enabled = false;
                btnHuySP.Enabled = false;
                btnAdd.Enabled = false;
                btnThanhToan.Enabled = false;
                nvtrahang = th.NT_TraHangTuKhach_LayTienDaNhan_SoCTTra(thid).Rows[0]["NVBanHang"].ToString();
                //btnIn.Enabled = false;

            }
            else
            {            
                btnHuyPhieu.Enabled = true;
                btnHuySP.Enabled = true;
                btnAdd.Enabled = true;
                btnThanhToan.Enabled = true;
                btnIn.Enabled = true;
            }

            CSQLNT_TraHangTuKhachCT thct = new CSQLNT_TraHangTuKhachCT();
            rgvChiTietPhieuTra.DataSource = thct.NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoSoCTTra(socttra);
            txtTongTien.Text = Convert.ToDecimal(th.NT_TraHang_LayTongTienTheoTHID(thid).ToString()).ToString("#,###");
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fmain.fNT_TraHang.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
                if (th_thid.Length > 0)
                {
                    if (MessageBox.Show("Bạn thực sự muốn hủy phiếu!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int kq = th.NT_TraHang_HuyPhieu(th_thid);
                        if (kq > 0)
                        {
                            statusTB.Text = "Xóa thành công!";
                            ThemMoi();
                        }
                        else
                        {
                            statusTB.Text = "Xóa thất bại!";
                        }
                    }
                }
            }
            catch { }
        }

        public void ThemMoi()
        {
            txtSoPhieuBan.Enabled = true;
            isCoQuyenTraHang = 0;
            slcothetra = 0;
            th_socttra = null;
            th_thid = null;
            isDaThanhToan = false;
            txtMaNV.Text = "";
            txtSLCoTheTra.Text = "";
            txtSLTra.Text = "";
            txtSoPhieuBan.Text = "";
            txtSoPhieuTra.Text = "";
            txtTongTien.Text = "";
            cboBanChinh.SelectedIndex = -1;
            cboDVTra.DataSource = null;
            //radMultiColumnComboboxMaSP.DataSource = null;
            //radMultiColumnComboBoxTenSP.DataSource = null;
            rgvChiTietPhieuBan.DataSource = null;
            rgvChiTietPhieuBanGoc.DataSource = null;
            rgvChiTietPhieuTra.DataSource = null;
            rgvLSTraHang.DataSource = null;
            btnHuyPhieu.Enabled = true;
            btnHuySP.Enabled = true;
            btnAdd.Enabled = true;
            btnThanhToan.Enabled = true;
            btnIn.Enabled = true;
            radMultiColumnComboboxMaSP.SelectedIndex = -1;
            radMultiColumnComboBoxTenSP.SelectedIndex = -1;
            cboPhiTraHang.SelectedIndex = 0;
            txtSoPhieuBan.Focus();
        }

        public void btnThemMoi_Click(object sender, EventArgs e)
        {
            ThemMoi();
            statusTB.Text = "";
        }
        InTam_TraHang intam_tahang = new InTam_TraHang();
        bool intam = false;
        bool inLoDate;
        ThanhToan_TraHang sales_ = new ThanhToan_TraHang();
        bool thanhtoan = false;
        private void btnIn_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(fmain.fNT_TraHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNT_TraHangTuKhachCT thct = new CSQLNT_TraHangTuKhachCT();
            if (th_thid != null)
            {
                //Bảng cần in của anh em lấy ra đây
                //code In đặt đây
                CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
            
                CSQLNhaThuoc nhathuoc_ = new CSQLNhaThuoc();
                CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
                CSQLNT_BanHangCT banhangct_ = new CSQLNT_BanHangCT();
                CSQLNhanVien nv = new CSQLNhanVien();

                string tennv_ = nv.LayThongTinNhanVienTheoMa(cboBanChinh.SelectedValue.ToString()).Rows[0]["HoTen"].ToString();
                DataTable dtbnhathuoc = nhathuoc_.LayNhaThuocTheoMa(chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString());

                string tennhathuoc_ = dtbnhathuoc.Rows[0]["TenNT"].ToString();
                string telnhathuoc_ = dtbnhathuoc.Rows[0]["Tel"].ToString();

                DataTable bangTraHangCanIn = thct.NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoTHID(th_thid);
                DataTable dtbNTtrahang = th.NT_TraHangTuKhach_LayTienDaNhan_SoCTTra(th_thid);
                PosDeviceTag tag = xuly_.currentDevice;
                if (tag != null)
                {
                    isDaThanhToan = th.NT_TraHang_KiemTraThanhToan(th_thid);
                    if (isDaThanhToan == true)
                    {
                        if (MessageBox.Show("Bạn muốn in có Số lô - Hạn dùng không???", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            inLoDate = true;
                        }
                        else
                        {
                            inLoDate = false;
                        }
                        string sp_ = dtbNTtrahang.Rows[0]["SoCTTra"].ToString();
                        decimal tientra_ = decimal.Parse(dtbNTtrahang.Rows[0]["TTTraCoTAXDaTinhPhiTraHang"].ToString());

                        try
                        {
                            sales_.ThanhToan_TH(xuly_, tennhathuoc_, telnhathuoc_, sp_, CStaticBien.STenMayThuNgan, tennv_,
         CStaticBien.StaiKhoan, bangTraHangCanIn, tientra_, inLoDate, true);
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
                    else
                    {
                        try
                        {
                            if (MessageBox.Show("Bạn muốn in có Số lô - Hạn dùng không???", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                intam_tahang.InTamCuaTraHang(xuly_ ,tennhathuoc_, telnhathuoc_, txtSoPhieuTra.Text, CStaticBien.STenMayThuNgan, tennv_, CStaticBien.StaiKhoan, bangTraHangCanIn, decimal.Parse(txtTongTien.Text), true);
                                intam = true;
                            }
                            else
                            {
                                intam_tahang.InTamCuaTraHang(xuly_, tennhathuoc_, telnhathuoc_, txtSoPhieuTra.Text, CStaticBien.STenMayThuNgan, tennv_, CStaticBien.StaiKhoan, bangTraHangCanIn, decimal.Parse(txtTongTien.Text), false);
                                intam = true;
                            }
                        }
                        catch
                        {
                            if (intam == false)
                            {
                                MessageBox.Show("Nguồn máy in bị tắt hoặc dây tín hiệu bị ngắt.\n Vui Lòng chọn in lại sau", "Xác Nhận");
                            }
                            else
                            {
                                intam = false;
                            }
                        }
                    }
                }
                else
                {
                    statusTB.Text = " Máy in bị ngắt kết nối. Vui lòng kiểm tra.";
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (fmain.frmNT_ThanhToanTraHangEditisOpen_ == true)
            {
                fmain.fNT_ThanhToanTraHangEdit_.Select();
                return;
            }

            fmain.fNT_ThanhToanTraHangEdit_ = new frmNT_ThanhToanTraHangEdit(fmain);
            CSQLNhanVien nv = new CSQLNhanVien();
            //fmain.fNT_ThanhToanTraHangEdit_.NhanDuLieu(th_thid, th_socttra);
            string tennv_ = nv.LayThongTinNhanVienTheoMa(cboBanChinh.SelectedValue.ToString()).Rows[0]["HoTen"].ToString();
            fmain.fNT_ThanhToanTraHangEdit_.TruyenBien(txtSoPhieuTra.Text, tennv_, th_thid, th_socttra);
            fmain.fNT_ThanhToanTraHangEdit_.ShowDialog();
            btnThemMoi_Click(sender, e);
        }

        public void NhanThongTinTufrmTraHang(string soctban, string socttra, string thid, object sender, EventArgs e) 
        {
            txtSoPhieuBan.Text = soctban;
            btnLayPhieuBan_Click(sender, e);
            th_thid = thid;
            th_socttra = socttra;
            frm_LayDSTraHangChiTiet(th_thid, th_socttra);
            rgvLSTraHang_Click(sender, e);
        }

        private void frmNT_TraHangEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cboBanChinh.Focus();
            }
            if (e.KeyCode == Keys.F4)
            {
                cboPhiTraHang.Focus();
            }
            if (e.KeyCode == Keys.F5)
            {
                if (btnAdd.Enabled == true)
                {
                    btnAdd_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                if(btnIn.Enabled == true)
                    btnIn_Click(sender, e);
            }
            if (e.KeyCode == Keys.F8)
            {
                if (btnHuyPhieu.Enabled == true)
                    btnHuyPhieu_Click(sender, e);
            }
            if (e.KeyCode == Keys.F9)
            {
                if (btnThanhToan.Enabled == true)
                    btnThanhToan_Click(sender, e);
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (btnHuySP.Enabled == true)
                    btnHuySP_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnDong_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnThemMoi_Click(sender, e);
            }
        }

        private void txtSoPhieuBan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                btnLayPhieuBan_Click(sender, e);
        }

        private void rgvChiTietPhieuBanGoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rgvChiTietPhieuBanGoc_DoubleClick(sender, e);
            }
        }

        private void txtSLTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtSLTra.Text.Length > 0)
                    cboPhiTraHang.Focus();
                else
                    txtSLTra.Focus();
            }
        }
        private void txtSLTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ hoặc âm!");
                e.Handled = true;
            }
        }


    }
}
