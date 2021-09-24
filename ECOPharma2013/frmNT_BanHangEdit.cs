using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls.Data;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;
using ECOPharma2013.Printer_POS;
using Telerik.WinControls.UI;
using System.Threading;

namespace ECOPharma2013
{
    public partial class frmNT_BanHangEdit : Form
    {
        frmMain fmain;
        string SKhoXuatMacDinhID;
        string SNSXID;
        string sBHCTid;
        public frmNT_BanHangEdit(frmMain _fmain)
        {
            InitializeComponent();
            fmain = _fmain;
        }
        bool ktmasp;
        private void frmNT_BanHangEdit_Load(object sender, EventArgs e)
        {
            KiemTraDanhSachChiTietKho(fmain.BHID_NT_BanHang_);

            //Chọn page view mặc định.
            #region default pageview
            rpvMain.SelectedPage = rpvBanHang;
            #endregion default pageview
            //Lấy ca hiện tại.
            #region Lấy ca theo máy thu ngân
            CSQLNT_KetCa kc = new CSQLNT_KetCa();
            CStaticBien.iSoCa = kc.KiemTraVaLaySoCa(CStaticBien.STenMayThuNgan);
            #endregion Lấy ca theo máy thu ngân
            if (CStaticBien.iSoCa != -1)
            {
                //Lấy ds khách hàng
                #region Lấy DS khách hàng lên combo
                CSQLKhachHang kh = new CSQLKhachHang();
                DataTable dtbkh = kh.LayDSKhachHang();
                if (dtbkh != null && dtbkh.Rows.Count > 0)
                {
                    mcboKhachHang.DisplayMember = "TenKH";
                    mcboKhachHang.ValueMember = "MaKH";
                    mcboKhachHang.DataSource = dtbkh;
                }
                #endregion Lấy DS khách hàng lên combo

                //Lấy DS phiếu tạm tính
                #region Lấy ds phiếu tạm tính
                CSQLNT_BanHang bh = new CSQLNT_BanHang();
                rgvDSTamTinh.DataSource = bh.LayDanhSachTamTinhCoTongGiaBan(CStaticBien.STenMayThuNgan);
                #endregion Lấy ds phiếu tạm tính

                //Lấy DS Giảm giá lên combo
                #region Lấy ds giảm giá lên combo
                LayDSGiamGiaLenCombobox();
                #endregion Lấy ds giảm giá lên combo

                //Lấy DS nhân viên lên combo
                #region Lấy DS nhân viên lên combo
                if (CStaticBien.SMaBoPhan.Length == 0)
                {
                    CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                    CStaticBien.SMaBoPhan = chht.LayMaBPThongTinChiNhanh();
                }
                CSQLNhanVien nv = new CSQLNhanVien();
                radMultiColumnComboBoxTenNV.DataSource = nv.LayDSNhanVienTheoBoPhan(CStaticBien.SMaBoPhan);
                radMultiColumnComboBoxTenNV.EditorControl.Columns["NVID"].IsVisible = false;
                radMultiColumnComboBoxTenNV.EditorControl.TableElement.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
                radMultiColumnComboBoxTenNV.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                radMultiColumnComboBoxTenNV.AutoFilter = true;
                FilterDescriptor descriptor12 = new FilterDescriptor(this.radMultiColumnComboBoxTenNV.DisplayMember, FilterOperator.Contains, null);
                radMultiColumnComboBoxTenNV.EditorControl.FilterDescriptors.Add(descriptor12);
                radMultiColumnComboBoxTenNV.DropDownStyle = RadDropDownStyle.DropDown;
                radMultiColumnComboBoxTenNV.MultiColumnComboBoxElement.DropDownWidth = 250;
                radMultiColumnComboBoxTenNV.MultiColumnComboBoxElement.DropDownHeight = 300;
                radMultiColumnComboBoxTenNV.SelectedIndex = -1;
                #endregion Lấy DS nhân viên lên combo

                if (tamtinh == true)
                {
                    LayDSMaSP_TenSPLenMultiColumnCombobox();
                }
                else
                {
                    //đưa điều kiện kiểm tra để radMultiColumnComboboxMaSP không kiểm tra chi tiết khi gọi datasource lên 
                    ktmasp = true;
                    this.radMultiColumnComboboxMaSP.DataSource = bh.LayDSMaSP_TenSPLenMultiColumnComboBox(cbkHangDacBiet.Checked);
                    radMultiColumnComboboxMaSP.SelectedIndex = -1;
                }
                //Lấy thông tin phiếu bán chi tiết theo BHID
                #region Lấy ds phiếu bán hàng chi tiết theo BHID
                if (fmain.SoPhieuNT_BanHang_ != null && fmain.BHID_NT_BanHang_ != null && fmain.SoPhieuNT_BanHang_.Length > 0 && fmain.BHID_NT_BanHang_.Length > 0)
                {
                    txtSoPhieu.Text = fmain.SoPhieuNT_BanHang_;
                    CSQLNT_BanHangCT bhct = new CSQLNT_BanHangCT();
                    rgvChiTiet.DataSource = bhct.LayLenLuoi(fmain.BHID_NT_BanHang_);
                    txtTongTien.Text = bh.LayTongTienThanhToan(fmain.BHID_NT_BanHang_);
                    radMultiColumnComboBoxTenNV.SelectedValue = new Guid(bh.LayNVBanHangTheoBHID(fmain.BHID_NT_BanHang_));

                    if (bh.IsDaThanhToan(fmain.BHID_NT_BanHang_) == 1)
                    {
                        btnAdd.Enabled = false;
                        rbtnHuyPhieu.Enabled = false;
                        rbtnHuySP.Enabled = false;
                        rbtnInPhieu.Enabled = false;
                        //rbtnInTam.Enabled = false;
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                        rbtnHuyPhieu.Enabled = true;
                        rbtnHuySP.Enabled = true;
                        rbtnInPhieu.Enabled = true;
                        rbtnInTam.Enabled = true;
                    }
                }
                else
                {
                    radMultiColumnComboBoxTenNV.Focus();
                }
                #endregion Lấy ds phiếu bán hàng chi tiết theo BHID
            }
            else
            {
                MessageBox.Show("Không thể lấy được ca, xin hãy thoát ra!", "Lỗi", MessageBoxButtons.OK);
            }

            
            //SendKeys.Send(Keys.Down.ToString());
            rgvSPHoatChat.DataSource = null;
            cboGiamGia.Enabled = false;
            ckGiamGia.Enabled = true;
            ckGiamGia.Checked = false;
            radMultiColumnComboBoxTenNV.Focus();

            Thread _LoadPosPrinter = new Thread(new ThreadStart(LoadPosPrinter));
            _LoadPosPrinter.Start();
        }

        private void LoadPosPrinter()
        {
            xuly_ = new XuLyMayInPos(this, statusTB);
        }

        private void KiemTraDanhSachChiTietKho(string BHid)
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            CSQLNT_BanHang bh = new CSQLNT_BanHang();

            if (fmain.SoPhieuNT_BanHang_ != null && fmain.BHID_NT_BanHang_ != null && fmain.SoPhieuNT_BanHang_.Length > 0 && fmain.BHID_NT_BanHang_.Length > 0) {
                CSQLNT_BanHangCT bhct = new CSQLNT_BanHangCT();
                if (bhct.LayLenLuoi(fmain.BHID_NT_BanHang_).Rows.Count > 0) {
                    Boolean IsHangDacBiet = bhct.KiemTraCoHangDacBiet(BHid);

                    if (IsHangDacBiet)
                    {
                        cbkHangDacBiet.Checked = true;

                        if (cbkHangDacBiet.Checked && !chht.KiemTraTrangThaiXemKhoDacBiet())
                        {
                            MessageBox.Show("Vui lòng làm mới lại danh sách Trả hàng");
                            KTmayin = false;
                            fmain.frmNT_BanHangEditisOpen_ = false;
                            fmain.BHID_NT_BanHang_ = "";
                            fmain.SoPhieuNT_BanHang_ = "";
                            fmain.fNT_BanHang.LoadLenLuoi();
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        cbkHangDacBiet.Checked = false;
                    }
                    cbkHangDacBiet.Enabled = false;
                }
                else
                {
                    cbkHangDacBiet.Enabled = true;
                    cbkHangDacBiet.Checked = bh.IsKhoDacBiet(BHid);
                }
            }
            else
            {
                cbkHangDacBiet.Enabled = true;
                cbkHangDacBiet.Visible = chht.KiemTraTrangThaiXemKhoDacBiet();
            }

            cbkHangDacBiet.Visible = chht.KiemTraTrangThaiXemKhoDacBiet();
        }

        #region khởi tạo các giá trị lên form
        private void LayDSGiamGiaLenCombobox()
        {
            CSQLGiamGia gg = new CSQLGiamGia();
            cboGiamGia.DisplayMember = "TenGG";
            cboGiamGia.ValueMember = "GGID";
            cboGiamGia.DataSource = gg.LayDanhSachGiamGiaLenLuoi(fmain.IsXemTatCa_);
        }
         
        private void LayDSMaSP_TenSPLenMultiColumnCombobox()
        {
            try
            {
                ktmasp = true;
                CSQLNT_BanHang bh = new CSQLNT_BanHang();
                this.radMultiColumnComboboxMaSP.DataSource = bh.LayDSMaSP_TenSPLenMultiColumnComboBox(cbkHangDacBiet.Checked);
                this.radMultiColumnComboboxMaSP.DisplayMember = "TenSP";
                this.radMultiColumnComboboxMaSP.ValueMember = "SPNSXID";
                this.radMultiColumnComboboxMaSP.AutoFilter = true;

                this.radMultiColumnComboboxMaSP.Refresh();
                FilterDescriptor descriptorMaSP = new FilterDescriptor("MaSP", FilterOperator.IsEqualTo, null);
                this.radMultiColumnComboboxMaSP.EditorControl.FilterDescriptors.Add(descriptorMaSP);
                FilterDescriptor descriptorTenSP = new FilterDescriptor("TenSP", FilterOperator.StartsWith, null);
                this.radMultiColumnComboboxMaSP.EditorControl.FilterDescriptors.Add(descriptorTenSP);
                this.radMultiColumnComboboxMaSP.DropDownStyle = RadDropDownStyle.DropDown;
                this.radMultiColumnComboboxMaSP.MultiColumnComboBoxElement.DropDownWidth = 730;
                this.radMultiColumnComboboxMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.radMultiColumnComboboxMaSP.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                radMultiColumnComboboxMaSP.SelectedIndex = -1;

                mcboMaSP.DisplayMember = "TenSP";
                mcboMaSP.ValueMember = "SPNSXID";
                mcboMaSP.DataSource = bh.LayDSMaSP_TenSPLenMultiColumnComboBox();
                mcboMaSP.SelectedIndex = -1;
                mcboMaSP.AutoFilter = true;
                FilterDescriptor descriptor_HC_MaSP = new FilterDescriptor("MaSP", FilterOperator.IsEqualTo, string.Empty);
                mcboMaSP.EditorControl.FilterDescriptors.Add(descriptor_HC_MaSP);
                FilterDescriptor descriptor_HC_TenSP = new FilterDescriptor("TenSP", FilterOperator.StartsWith, string.Empty);
                mcboMaSP.EditorControl.FilterDescriptors.Add(descriptor_HC_TenSP);
                mcboMaSP.MultiColumnComboBoxElement.DropDownWidth = 730;
                mcboMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.mcboMaSP.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;

                #region format tĩnh radMultiColumnComboboxMaSP
                //radMultiColumnComboBoxTenSP.DisplayMember = "TenSP";
                //radMultiColumnComboBoxTenSP.ValueMember = "SPNSXID";
                //radMultiColumnComboBoxTenNV.ValueMember = "NVID";
                //radMultiColumnComboBoxTenNV.DisplayMember = "HoTen";
                //radMultiColumnComboboxMaSP.EditorControl.Columns["MaSP"].HeaderText = "Mã SP";
                //radMultiColumnComboboxMaSP.EditorControl.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                //radMultiColumnComboboxMaSP.EditorControl.Columns["SLTon"].HeaderText = "TSL Tồn";
                //radMultiColumnComboboxMaSP.EditorControl.Columns["DVChuan"].HeaderText = "Đơn vị bán";
                //radMultiColumnComboboxMaSP.EditorControl.Columns["GiaBan"].HeaderText = "Giá bán";
                //radMultiColumnComboboxMaSP.EditorControl.Columns["TenNSX"].HeaderText = "Tên NSX";
                //radMultiColumnComboboxMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                //radMultiColumnComboboxMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
                //radMultiColumnComboboxMaSP.EditorControl.Columns["SPID"].IsVisible = false;
                //radMultiColumnComboboxMaSP.EditorControl.Columns["MaSP"].Width = 40;
                //radMultiColumnComboboxMaSP.EditorControl.Columns["TenSP"].Width = 265;
                //radMultiColumnComboboxMaSP.EditorControl.Columns["TenNSX"].Width = 150;
                //radMultiColumnComboboxMaSP.EditorControl.Columns["SLTon"].Width = 65;
                //radMultiColumnComboboxMaSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
                //radMultiColumnComboboxMaSP.EditorControl.Columns["DVChuan"].Width = 55;
                //radMultiColumnComboboxMaSP.EditorControl.Columns["GiaBan"].Width = 70;
                //radMultiColumnComboboxMaSP.EditorControl.Columns["GiaBan"].FormatString = "{0:N2}";

                //radMultiColumnComboBoxTenSP.DataSource = bh.LayDSMaSP_TenSPLenMultiColumnComboBox();
                //radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["MaSP"].HeaderText = "Mã SP";
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["SLTon"].HeaderText = "TSL Tồn";
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["DVChuan"].HeaderText = "Đơn vị bán";
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["GiaBan"].HeaderText = "Giá bán";
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["TenNSX"].HeaderText = "Tên NSX";

                //radMultiColumnComboBoxTenSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["NSXID"].IsVisible = false;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["SPID"].IsVisible = false;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["MaSP"].Width = 40;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["TenSP"].Width = 265;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["TenNSX"].Width = 150;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["SLTon"].Width = 65;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["DVChuan"].Width = 55;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["GiaBan"].Width = 70;
                //radMultiColumnComboBoxTenSP.EditorControl.Columns["GiaBan"].FormatString = "{0:N2}";
                //radMultiColumnComboBoxTenSP.AutoFilter = true;
                //FilterDescriptor descriptor1 = new FilterDescriptor(this.radMultiColumnComboBoxTenSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
                //radMultiColumnComboBoxTenSP.EditorControl.FilterDescriptors.Add(descriptor1);
                //radMultiColumnComboBoxTenSP.DropDownStyle = RadDropDownStyle.DropDown;
                //radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownWidth = 680;
                //radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;
                #endregion
                #region format tĩnh mcboMa_TenSP
                //mcboTenSP.DisplayMember = "TenSP";
                //mcboTenSP.ValueMember = "SPNSXID";
                //mcboTenSP.DataSource = bh.LayDSMaSP_TenSPLenMultiColumnComboBox();
                //mcboTenSP.SelectedIndex = -1;
                //mcboTenSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                //mcboTenSP.EditorControl.Columns["NSXID"].IsVisible = false;
                //mcboTenSP.EditorControl.Columns["SPID"].IsVisible = false;
                //mcboTenSP.EditorControl.Columns["MaSP"].Width = 40;
                //mcboTenSP.EditorControl.Columns["TenSP"].Width = 265;
                //mcboTenSP.EditorControl.Columns["TenNSX"].Width = 150;
                //mcboTenSP.EditorControl.Columns["SLTon"].Width = 65;
                //mcboTenSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
                //mcboTenSP.EditorControl.Columns["DVChuan"].Width = 55;
                //mcboTenSP.EditorControl.Columns["GiaBan"].Width = 70;
                //mcboTenSP.EditorControl.Columns["GiaBan"].FormatString = "{0:N2}";
                //mcboTenSP.EditorControl.Columns["MaSP"].HeaderText = "Mã SP";
                //mcboTenSP.EditorControl.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                //mcboTenSP.EditorControl.Columns["SLTon"].HeaderText = "TSL Tồn";
                //mcboTenSP.EditorControl.Columns["DVChuan"].HeaderText = "Đơn vị bán";
                //mcboTenSP.EditorControl.Columns["GiaBan"].HeaderText = "Giá bán";
                //mcboTenSP.EditorControl.Columns["TenNSX"].HeaderText = "Tên NSX";
                //mcboTenSP.MultiColumnComboBoxElement.DropDownWidth = 680;
                //mcboTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;
                //mcboMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                //mcboMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
                //mcboMaSP.EditorControl.Columns["SPID"].IsVisible = false;
                //mcboMaSP.EditorControl.Columns["MaSP"].Width = 40;
                //mcboMaSP.EditorControl.Columns["TenSP"].Width = 265;
                //mcboMaSP.EditorControl.Columns["TenNSX"].Width = 150;
                //mcboMaSP.EditorControl.Columns["SLTon"].Width = 65;
                //mcboMaSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
                //mcboMaSP.EditorControl.Columns["DVChuan"].Width = 55;
                //mcboMaSP.EditorControl.Columns["GiaBan"].Width = 70;
                //mcboMaSP.EditorControl.Columns["GiaBan"].FormatString = "{0:N2}";
                //mcboMaSP.EditorControl.Columns["MaSP"].HeaderText = "Mã SP";
                //mcboMaSP.EditorControl.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                //mcboMaSP.EditorControl.Columns["SLTon"].HeaderText = "TSL Tồn";
                //mcboMaSP.EditorControl.Columns["DVChuan"].HeaderText = "Đơn vị bán";
                //mcboMaSP.EditorControl.Columns["GiaBan"].HeaderText = "Giá bán";
                //mcboMaSP.EditorControl.Columns["TenNSX"].HeaderText = "Tên NSX";
                #endregion format tĩnh mcboMa_TenSP
            }
            catch { }
        }

        private void radMultiColumnComboboxMaSP_SelectedValueChanged(object sender, EventArgs e)
        {
            if(ktmasp == true)
            {
                ktmasp = false;
                return;
            }
            if (radMultiColumnComboboxMaSP.SelectedValue != null && radMultiColumnComboboxMaSP.SelectedIndex != -1)
            {
                //Lấy Danh sách Đơn vị tính của sản phẩm
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                DataTable dtbdvt = hsqd.LayDVTTheoSPID(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                cboDVBan.DisplayMember = "TenTuDVT";
                cboDVBan.ValueMember = "TuDVTID";
                cboDVBan.DataSource = dtbdvt;
                CSQLSanPham sp = new CSQLSanPham();
                DataTable dtb = sp.SanPham_LayDVNhap_DVXuat_DVBan_DVChuan_TheoSPID(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    cboDVBan.SelectedValue = dtb.Rows[0]["DVBan"].ToString();
                }
                else
                {
                    cboDVBan.SelectedIndex = 0;
                }

                CSQLNT_BanHang bh = new CSQLNT_BanHang();
                //Lấy kho xuất mặc định của sản phẩm
                SKhoXuatMacDinhID = bh.LayKhoXuatMacDinhCuaSanPham(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());

                if (SKhoXuatMacDinhID != null && SKhoXuatMacDinhID.Length > 0)
                {
                    statusTB.Text = "";
                    //Lấy Danh sách Lot theo SPID
                    DataTable dtblot = new DataTable();
                    CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                    if (cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet()) {
                        dtblot = bh.LayDSLotDacBietTheoSPID(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
                    } else {
                        dtblot = bh.LayDSLotTheoSPID(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), SKhoXuatMacDinhID, radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
                    }
                    if (dtblot != null && dtblot.Rows.Count > 0)
                    {
                        cboSoLo.DisplayMember = "Lot";
                        cboSoLo.ValueMember = "Lot";
                        cboSoLo.DataSource = dtblot;
                        cboSoLo.SelectedIndex = -1;
                    }
                    else
                    {
                        statusTB.Text = "Kho xuất mặc định hiện tại không có hàng!";
                        cboSoLo.DataSource = null;
                        dtHanDung.Value = DateTime.Now;
                        lblSLTonKho.Text = "";
                        lblSLCoTheBan.Text = "";
                        cboDVBan.DataSource = null;
                        return;
                    }
                }
                else
                {
                    statusTB.Text = "Bạn phải thiết lập kho xuất mặc định cho sản phẩm!";
                    cboSoLo.DataSource = null;
                    dtHanDung.Value = DateTime.Now;
                    lblSLTonKho.Text = "";
                    lblSLCoTheBan.Text = "";
                    cboDVBan.DataSource = null;
                    return;
                }
            }
            else
            {
                cboSoLo.DataSource = null;
                dtHanDung.Value = DateTime.Now;
                lblSLTonKho.Text = "";
                lblSLCoTheBan.Text = "";
                cboDVBan.DataSource = null;
                return;
            }

            //Tổng tồn của sản phẩm
            //DienTongTonVaolblTongTon();
            lblTongTon.Text = Math.Round(double.Parse(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SLTon"].Value.ToString())).ToString();
        }

        private void DienTongTonVaolblTongTon()
        {
            try
            {
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                CSQLTonKho TK = new CSQLTonKho();
                DataTable dtbSLTon;
                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();

                if (cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet())
                {
                    CSQLNT_BanHang bh = new CSQLNT_BanHang();
                    dtbSLTon = bh.NTTonKho_LaySLTon_DVTid(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                }
                else
                {
                    dtbSLTon = TK.NTTonKho_LaySLTon_DVTid(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                }
                decimal tyle = hsqd.TinhTyLeHSQD(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboDVBan.SelectedValue.ToString());
                string tongton = (Math.Round((decimal.Parse(dtbSLTon.Rows[0]["tslton"].ToString()) * tyle), 2)).ToString();
                string[] c = tongton.Split('.');
                if (c[1].CompareTo("00") == 0)
                {
                    lblTongTon.Text = c[0].ToString();
                }
                else
                {
                    lblTongTon.Text = tongton;
                }
            }
            catch
            {
                lblTongTon.Text = "0";
            }
        }

        private void TinhTienTamThoi()
        {
            try
            {
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                decimal tyle = hsqd.TinhTyLeHSQD(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboDVBan.SelectedValue.ToString());
                string tongton = (Math.Round((decimal.Parse(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["GiaBan"].Value.ToString()) / tyle * decimal.Parse(txtSLBan.Text)), 2)).ToString();
                txtThanhTien.Text = Convert.ToDecimal(tongton).ToString("#,###"); ;
            }
            catch
            {
                txtThanhTien.Text = "";
            }
        }

        private void mcboMaSP_SelectedValueChanged(object sender, EventArgs e)
        {
            if (mcboMaSP.SelectedValue != null && mcboMaSP.SelectedIndex != -1)
            {
                ////Lấy tên sp
                //if (mcboTenSP.SelectedValue == null || (mcboTenSP.SelectedValue != null && mcboMaSP.SelectedValue.ToString().CompareTo(mcboTenSP.SelectedValue.ToString()) != 0))
                //{
                //    mcboTenSP.SelectedValue = mcboMaSP.SelectedValue;
                //}
                //if (txtHCMaSP.Text.Length == 5)

                {
                    txtHCMaSP.Text = mcboMaSP.EditorControl.CurrentRow.Cells["MaSP"].Value.ToString();
                    CSQLNT_BanHang bh = new CSQLNT_BanHang();
                    try
                    {
                        rgvSPHoatChat.DataSource = bh.NT_BanHang_HoatChat_LayDSSanPhamLenLuoiHC(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), ",");
                        rgvSPHoatChat.Focus();
                    }
                    catch (ApplicationException ex)
                    {
                        //statusTB.Text = ex.Message;
                        statusTB.Text = "Không có sản phẩm nào có hoạt chất tương đương!";
                    }
                    catch (Exception ex)
                    {
                        //statusTB.Text = ex.Message;
                    }
                }
                //else
                //{
                //    rgvSPHoatChat.DataSource = null;
                //    statusTB.Text = "";
                //}
            }

        }

        private void cboDVBan_SelectedValueChanged(object sender, EventArgs e)
        {
            CSQLNT_BanHang bh = new CSQLNT_BanHang();
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            DataTable dtbtkct;
            CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();

            if (cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet()) {
                if (cboDVBan.SelectedValue != null && cboDVBan.SelectedIndex != -1 && radMultiColumnComboboxMaSP.SelectedValue != null && radMultiColumnComboboxMaSP.SelectedIndex != -1 && cboSoLo.SelectedValue != null && cboSoLo.SelectedIndex != -1)
                {
                    decimal tyle = hsqd.TinhTyLeHSQD(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboDVBan.SelectedValue.ToString());
                    dtbtkct = bh.LayNTTKCTTheoSPIDKhoLot(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboSoLo.SelectedValue.ToString(), radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());

                    if (dtbtkct != null && dtbtkct.Rows.Count > 0)
                    {
                        string slcotheban = (Math.Round((decimal.Parse(dtbtkct.Rows[0]["SLCoTheBan"].ToString()) * tyle), 2)).ToString();
                        string[] a = slcotheban.Split('.');
                        if (a.Length == 1 || a[1].CompareTo("00") == 0)
                        {
                            lblSLCoTheBan.Text = a[0].ToString();
                        }
                        else
                        {
                            lblSLCoTheBan.Text = slcotheban;
                        }
                        string sltonkho = (Math.Round((decimal.Parse(dtbtkct.Rows[0]["SLTon"].ToString()) * tyle), 2)).ToString();
                        string[] b = sltonkho.Split('.');
                        if (b.Length == 1 || b[1].CompareTo("00") == 0)
                        {
                            lblSLTonKho.Text = b[0].ToString();
                        }
                        else
                        {
                            lblSLTonKho.Text = sltonkho;
                        }
                    }
                    DienTongTonVaolblTongTon();
                }
                else
                {
                    DienTongTonVaolblTongTon();
                }
            } else { 
                if (cboDVBan.SelectedValue != null && cboDVBan.SelectedIndex != -1 && radMultiColumnComboboxMaSP.SelectedValue != null && radMultiColumnComboboxMaSP.SelectedIndex != -1 && cboSoLo.SelectedValue != null && cboSoLo.SelectedIndex != -1)
                {
                    decimal tyle = hsqd.TinhTyLeHSQD(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboDVBan.SelectedValue.ToString());
                    dtbtkct = bh.LayNTTKCTTheoSPIDKhoLot(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), SKhoXuatMacDinhID, cboSoLo.SelectedValue.ToString(), radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
                    if (dtbtkct != null && dtbtkct.Rows.Count > 0)
                    {
                        CSQLTonKho TK = new CSQLTonKho();
                        DataTable dtbSLTon = TK.NTTonKho_LaySLTon_DVTid(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());

                        string slcotheban = (Math.Round((decimal.Parse(dtbtkct.Rows[0]["SLCoTheBan"].ToString()) * tyle), 2)).ToString();
                        string[] a = slcotheban.Split('.');
                        if (a.Length == 1 || a[1].CompareTo("00") == 0)
                        {
                            lblSLCoTheBan.Text = a[0].ToString();
                        }
                        else
                        {
                            lblSLCoTheBan.Text = slcotheban;
                        }
                        string sltonkho = (Math.Round((decimal.Parse(dtbtkct.Rows[0]["SLTon"].ToString()) * tyle), 2)).ToString();
                        string[] b = sltonkho.Split('.');
                        if (b.Length == 1 || b[1].CompareTo("00") == 0)
                        {
                            lblSLTonKho.Text = b[0].ToString();
                        }
                        else
                        {
                            lblSLTonKho.Text = sltonkho;
                        }
                        string tongton = (Math.Round((decimal.Parse(dtbSLTon.Rows[0]["tslton"].ToString()) * tyle), 2)).ToString();
                        //string tongton = (Math.Round((decimal.Parse(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SLTon"].Value.ToString()) * tyle), 2)).ToString();
                        string[] c = tongton.Split('.');
                        if (c.Length == 1 || c[1].CompareTo("00") == 0)
                        {
                            lblTongTon.Text = c[0].ToString();
                        }
                        else
                        {
                            lblTongTon.Text = tongton;
                        }
                    }
                }
                else
                {
                    //Tổng tồn của sản phẩm
                    DienTongTonVaolblTongTon();
                }
                TinhTienTamThoi();
            }
        }
       
        private void cboSoLo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (radMultiColumnComboboxMaSP.SelectedValue != null && radMultiColumnComboboxMaSP.SelectedIndex != -1 && cboSoLo.SelectedValue != null && cboSoLo.SelectedIndex != -1)
                {
                    CSQLNT_BanHang bh = new CSQLNT_BanHang();
                    DataTable dtbtkct = new DataTable();
                    CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                    if (cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet()) {
                        dtbtkct = bh.LayNTTKCTTheoSPIDKhoLot(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboSoLo.SelectedValue.ToString(), radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
                    } else { 
                       dtbtkct = bh.LayNTTKCTTheoSPIDKhoLot(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), SKhoXuatMacDinhID, cboSoLo.SelectedValue.ToString(), radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
                    }
                    dtHanDung.Format = DateTimePickerFormat.Custom;
                    dtHanDung.CustomFormat = "dd/MM/yyyy";
                    dtHanDung.Value = DateTime.Parse(dtbtkct.Rows[0]["Date"].ToString());
                    SNSXID = dtbtkct.Rows[0]["NSXID"].ToString();

                    CSQLTonKho TK = new CSQLTonKho();
                    DataTable dtbSLTon = TK.NTTonKho_LaySLTon_DVTid(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());

                    CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                    decimal tyle = hsqd.TinhTyLeHSQD(radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboDVBan.SelectedValue.ToString());

                    string slcotheban = (Math.Round((decimal.Parse(dtbtkct.Rows[0]["SLCoTheBan"].ToString()) * tyle), 2)).ToString();

                    string[] a = slcotheban.Split('.');

                    if (a.Length == 1 || a[1].CompareTo("00") == 0)
                    {
                        lblSLCoTheBan.Text = a[0].ToString();
                    }
                    else
                    {
                        lblSLCoTheBan.Text = slcotheban;
                    }
                    string sltonkho = (Math.Round((decimal.Parse(dtbtkct.Rows[0]["SLTon"].ToString()) * tyle), 2)).ToString();
                    string[] b = sltonkho.Split('.');
                    if (b.Length == 1 || b[1].CompareTo("00") == 0)
                    {
                        lblSLTonKho.Text = b[0].ToString();
                    }
                    else
                    {
                        lblSLTonKho.Text = sltonkho;
                    }
                }
                else
                {
                    lblSLCoTheBan.Text = "0";
                    lblSLTonKho.Text = "0";
                    lblTongTon.Text = "0";
                }
            }
            catch { }
        }

        #endregion
        private void btnDong_Click(object sender, EventArgs e)
        {
            //if (xuly_.printer != null)
            //{
            //    xuly_.NgatKetNoiMayIn(xuly_.printer);
            //}
            KTmayin = false;
            fmain.frmNT_BanHangEditisOpen_ = false;
            fmain.BHID_NT_BanHang_ = "";
            fmain.SoPhieuNT_BanHang_ = "";
            fmain.fNT_BanHang.LoadLenLuoi();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_BanHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            if (!chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            ktmasp = true;
            #region Thêm master (NTBanHang)
            CSQLNT_BanHang banhang = new CSQLNT_BanHang();
            if (fmain.BHID_NT_BanHang_ == null || fmain.BHID_NT_BanHang_.Length == 0)
            {
                //Kiểm tra Tên Bán chính đã chọn hay chưa
                if (radMultiColumnComboBoxTenNV.SelectedIndex != -1)
                {
                    string[] mangbh = banhang.Them(CStaticBien.STenMayThuNgan, CStaticBien.SmaTaiKhoan, radMultiColumnComboBoxTenNV.EditorControl.CurrentRow.Cells["NVID"].Value.ToString(), CStaticBien.iSoCa, "11111111-1111-1111-1111-111111111111", chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked);
                    if (mangbh != null)
                    {
                        fmain.SoPhieuNT_BanHang_ = mangbh[0];
                        fmain.BHID_NT_BanHang_ = mangbh[1];
                        txtSoPhieu.Text = fmain.SoPhieuNT_BanHang_;
                    }
                    else
                    {
                        txtSoPhieu.Text = "";
                        return;
                    }
                }
                else
                {
                    statusTB.Text = "Bạn chưa chọn ['Bán chính']!";
                    return;
                }
            }
            else
            {
                banhang.CapNhat(fmain.BHID_NT_BanHang_, chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked);
            }
            #endregion

            #region Thêm detail (NTBanHangCT)
            //Kiểm tra Đã có phiếu bán hàng master hay chưa (fmain_SoPhieuNT_BanHang)
            if (fmain.SoPhieuNT_BanHang_ != null && fmain.SoPhieuNT_BanHang_.Length > 0)
            {
                //KiemTraThongTinPhieuBanHangChiTiet();
                if (radMultiColumnComboboxMaSP.SelectedValue == null || radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString().Length == 0)
                {
                    statusTB.Text = "Bạn chưa chọn Sản phẩm!";
                    //radMultiColumnComboBoxTenSP.Focus();
                    return;
                }
                if (txtSLBan.Text.Length == 0)
                {
                    statusTB.Text = "Bạn chưa nhập Số lượng bán!";
                    txtSLBan.Focus();
                    return;
                }
                CSQLNT_BanHangCT bhct = new CSQLNT_BanHangCT();

                if (sBHCTid == null || sBHCTid.Length == 0) //Sua detail
                {
                    sBHCTid = "00000000-0000-0000-0000-000000000000";
                }

                int kq;

                if (chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked) {
                    kq = bhct.ThemHangDacBiet(fmain.BHID_NT_BanHang_, radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), decimal.Parse(txtSLBan.Text), cboDVBan.SelectedValue.ToString(), cboSoLo.Text, dtHanDung.Value, cboGiamGia.SelectedValue.ToString(), radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString(), sBHCTid, CStaticBien.STenMayThuNgan);
                } else { 
                    kq = bhct.Them(fmain.BHID_NT_BanHang_, radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), SKhoXuatMacDinhID, decimal.Parse(txtSLBan.Text), cboDVBan.SelectedValue.ToString(), cboSoLo.Text, dtHanDung.Value, cboGiamGia.SelectedValue.ToString(), radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString(), sBHCTid, CStaticBien.STenMayThuNgan);
                }

                if (kq > 0)
                {
                    statusTB.Text = "Thêm item thành công!";
                    rgvChiTiet.DataSource = bhct.LayLenLuoi(fmain.BHID_NT_BanHang_);
                    CSQLNT_BanHang bh = new CSQLNT_BanHang();
                    //rgvDSTamTinh.DataSource = bh.LayDanhSachTamTinh(CStaticBien.STenMayThuNgan);
                    RefreshForm();
                    txtTongTien.Text = bh.LayTongTienThanhToan(fmain.BHID_NT_BanHang_);
                    sBHCTid = "00000000-0000-0000-0000-000000000000";
                    KiemTraDanhSachChiTietKho(fmain.BHID_NT_BanHang_);
                }
                else
                {
                    statusTB.Text = "Thêm item thất bại!";
                    sBHCTid = "00000000-0000-0000-0000-000000000000";
                }
                //DUNGLV ADD DISABLE Combobox start
                radMultiColumnComboboxMaSP.Enabled = true;
                //DUNGLV ADD DISABLE Combobox end
            }
            #endregion
        }

        private void RefreshForm()
        {
            CSQLNT_BanHang bh = new CSQLNT_BanHang();
            this.radMultiColumnComboboxMaSP.DataSource = bh.LayDSMaSP_TenSPLenMultiColumnComboBox(cbkHangDacBiet.Checked);
            //radMultiColumnComboboxMaSP.Refresh();
            radMultiColumnComboboxMaSP.SelectedIndex = -1;
            //radMultiColumnComboBoxTenSP.SelectedIndex = -1;
            txtSLBan.Text = "";
            lblSLCoTheBan.Text = "0";
            lblSLTonKho.Text = "0";
            lblTongTon.Text = "0";
        }

        private void KiemTraThongTinPhieuBanHangChiTiet()
        {
            if (radMultiColumnComboboxMaSP.SelectedValue == null || radMultiColumnComboboxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString().Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn Sản phẩm!";
                //radMultiColumnComboBoxTenSP.Focus();
                return;
            }
            if (txtSLBan.Text.Length == 0)
            {
                statusTB.Text = "Bạn chưa nhập Số lượng bán!";
                txtSLBan.Focus();
                return;
            }
        }

        public void btnThemMoi_Click(object sender, EventArgs e)
        {
            sBHCTid = "00000000-0000-0000-0000-000000000000";
            fmain.BHID_NT_BanHang_ = "";
            fmain.SoPhieuNT_BanHang_ = "";
            //txtMaNV.Text = "";
            txtSLBan.Text = "";
            txtSoPhieu.Text = "";
            txtTongTien.Text = "";
            lblSLCoTheBan.Text = "0";
            lblSLTonKho.Text = "0";
            lblTongTon.Text = "0";
            rgvChiTiet.DataSource = null;
            btnAdd.Enabled = true;
            rbtnHuyPhieu.Enabled = true;
            rbtnHuySP.Enabled = true;
            rbtnInPhieu.Enabled = true;
            rbtnInTam.Enabled = true;
            rpvMain.SelectedPage = rpvBanHang;
            cboGiamGia.SelectedIndex = 0;
            cbkHangDacBiet.Checked = false;

            CSQLNT_KetCa kc = new CSQLNT_KetCa();
            int soca = kc.KiemTraVaLaySoCa(CStaticBien.STenMayThuNgan);
            if (soca != -1)
            {
                //Lấy ds khách hàng
                CSQLKhachHang kh = new CSQLKhachHang();
                DataTable dtbkh = kh.LayDSKhachHang();
                if (dtbkh != null && dtbkh.Rows.Count > 0)
                {
                    mcboKhachHang.DisplayMember = "TenKH";
                    mcboKhachHang.ValueMember = "MaKH";
                    mcboKhachHang.DataSource = dtbkh;
                }
                //End Lấy ds Khách hàng
                CSQLNT_BanHang bh = new CSQLNT_BanHang();
                rgvDSTamTinh.DataSource = bh.LayDanhSachTamTinhCoTongGiaBan(CStaticBien.STenMayThuNgan);
                CStaticBien.iSoCa = soca;
                //LayDSGiamGiaLenCombobox();
                //LayDSMaSP_TenSPLenMultiColumnCombobox();

                this.radMultiColumnComboboxMaSP.DataSource = bh.LayDSMaSP_TenSPLenMultiColumnComboBox(cbkHangDacBiet.Checked);
                radMultiColumnComboboxMaSP.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Không thể lấy được ca, xin hãy thoát ra!", "Lỗi", MessageBoxButtons.OK);
            }
            rgvSPHoatChat.DataSource = null;
            cboGiamGia.Enabled = false;
            ckGiamGia.Enabled = true;
            ckGiamGia.Checked = false;
            //radMultiColumnComboboxMaSP.Focus();

            KiemTraDanhSachChiTietKho(fmain.BHID_NT_BanHang_);
        }

        private void rbtnHuySP_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_BanHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (fmain.BHID_NT_BanHang_ != null && fmain.BHID_NT_BanHang_.Length > 0 && rgvChiTiet.Rows.Count > 0 && rgvChiTiet.CurrentRow != null)
            {
                CSQLNT_BanHangCT bhct = new CSQLNT_BanHangCT();
                int kq = bhct.Xoa(rgvChiTiet.CurrentRow.Cells["colBHCTid"].Value.ToString());
                if (kq > 0)
                {
                    rgvChiTiet.DataSource = bhct.LayLenLuoi(fmain.BHID_NT_BanHang_);
                    statusTB.Text = "Xóa thành công";
                    CSQLNT_BanHang bh = new CSQLNT_BanHang();
                    txtTongTien.Text = bh.LayTongTienThanhToan(fmain.BHID_NT_BanHang_);
                }
                else
                    statusTB.Text = "Xóa thất bại";
            }
            else
            {
                statusTB.Text = "Không có dữ liệu để hủy!";
            }
            //DUNGLV ADD DISABLE Combobox start
            radMultiColumnComboboxMaSP.Enabled = true;
            //DUNGLV ADD DISABLE Combobox end
        }

        private void rbtnInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (fmain.frmNT_ThanhToanEditisOpen_ == true)
                {
                    fmain.fNT_ThanhToanEdit_.Select();
                    return;
                }
                fmain.fNT_ThanhToanEdit_ = new frmNT_ThanhToanEdit(fmain);
                rbtnHuySP.Enabled = false;
                rbtnHuyPhieu.Enabled = false;
                //fmain.fNT_ThanhToanEdit_.NhanDuLieu(fmain.BHID_NT_BanHang_);
                CSQLNhanVien nv = new CSQLNhanVien();
                string tennv_ = nv.LayThongTinNhanVienTheoMa(radMultiColumnComboBoxTenNV.EditorControl.CurrentRow.Cells["NVID"].Value.ToString()).Rows[0]["HoTen"].ToString();
                fmain.fNT_ThanhToanEdit_.TruyenBien(txtSoPhieu.Text, tennv_, fmain.BHID_NT_BanHang_);

                fmain.fNT_ThanhToanEdit_.ShowDialog();
                if (fmain.fNT_ThanhToanEdit_.Dathanhtoan == true)
                {
                    btnThemMoi_Click(sender, e);
                }
                else
                {
                    rbtnHuySP.Enabled = true;
                    rbtnHuyPhieu.Enabled = true;
                }
                //btnThemMoi_Click(sender, e); 
                //DUNGLV ADD DISABLE Combobox start
                radMultiColumnComboboxMaSP.Enabled = true;
                //DUNGLV ADD DISABLE Combobox end
            }
            catch (Exception ex)
            {
                statusTB.Text = "Lỗi khi lấy dữ liệu: " + ex.Message;
            }
        }
        bool tamtinh = true;
        private void rgvDSTamTinh_DoubleClick(object sender, EventArgs e)
        {
            fmain.BHID_NT_BanHang_ = rgvDSTamTinh.CurrentRow.Cells["colBHid"].Value.ToString();
            fmain.SoPhieuNT_BanHang_ = rgvDSTamTinh.CurrentRow.Cells["colSoCT"].Value.ToString();
            tamtinh = false;
            frmNT_BanHangEdit_Load(sender, e);
            rpvMain.SelectedPage = rpvBanHang;
            radMultiColumnComboBoxTenNV.Focus();
        }

        private void rgvChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                radMultiColumnComboboxMaSP.SelectedValue = rgvChiTiet.CurrentRow.Cells["colSPID"].Value;
                txtSLBan.Text = rgvChiTiet.CurrentRow.Cells["colSLBan"].Value.ToString();
                cboDVBan.SelectedValue = rgvChiTiet.CurrentRow.Cells["colDVBanID"].Value;
                cboGiamGia.SelectedValue = rgvChiTiet.CurrentRow.Cells["colGiamGia"].Value;
            }
            catch (Exception ex) { statusTB.Text = ex.Message; }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            if (txtTongTien.Text.Length > 0)
            {
                txtTongTien.Text = Convert.ToDecimal(txtTongTien.Text).ToString("#,###");
                txtTongTien.Select(txtTongTien.TextLength, 0);
            }
        }

        private void txtSLBan_TextChanged(object sender, EventArgs e)
        {
            if (txtSLBan.Text.Length > 0)
            {
                try
                {
                    txtSLBan.Text = Convert.ToDecimal(txtSLBan.Text).ToString("####");
                    txtSLBan.Select(txtSLBan.TextLength, 0);
                    TinhTienTamThoi();
                }
                catch { }
            }
        }

        private void rpvBanHangEdit_KeyDown(object sender, KeyEventArgs e)
        {
            CSQLNT_BanHang bh = new CSQLNT_BanHang();
            if (e.KeyCode == Keys.Escape)
            {
                return;
            }
            if (e.KeyCode == Keys.F1)
            {
                radMultiColumnComboBoxTenNV.Focus();
                return;
            }
            if (e.KeyCode == Keys.F2)
            {
                radMultiColumnComboboxMaSP.Focus();
                return;
            }
            if (e.KeyCode == Keys.F3)
            {
                txtSLBan.Focus();
            }
            if (e.KeyCode == Keys.F4)
            {
                ckGiamGia.Focus();

            }
            if (e.Control && e.KeyCode == Keys.E)
            {
                rpvMain.SelectedPage = rpvBanHang;
                return;
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                rpvMain.SelectedPage = rpvPhieuTamTinh;

                //rgvDSTamTinh.DataSource = bh.LayDanhSachTamTinh(CStaticBien.STenMayThuNgan);
                rgvDSTamTinh.Focus();
                return;
            }
            if (e.Control && e.KeyCode == Keys.H)
            {
                rpvMain.SelectedPage = rpvHoatChat;
                if (radMultiColumnComboboxMaSP.SelectedValue != null && radMultiColumnComboboxMaSP.SelectedValue.ToString().Length > 0)
                {
                    mcboMaSP.SelectedValue = radMultiColumnComboboxMaSP.SelectedValue;
                    return;
                }
                else
                {
                    //mcboTenSP.Focus();
                }
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnThemMoi_Click(sender, e);
                return;
            }

            bool kt = false;
            if (e.KeyCode == Keys.F7)
            {
                if (fmain.BHID_NT_BanHang_ != null && fmain.BHID_NT_BanHang_.Length > 0)
                {
                    kt = bh.NT_BanHang_KiemTraDonDaThanhToan(fmain.BHID_NT_BanHang_);
                    if (kt == false)
                    {
                        rbtnInTam_Click(sender, e);
                        return;
                    }
                }
                else
                { statusTB.Text = "Phiếu in tạm không tồn tại!"; }
            }
            if (e.KeyCode == Keys.F8)
            {
                if (fmain.BHID_NT_BanHang_ != null && fmain.BHID_NT_BanHang_.Length > 0)
                {
                    kt = bh.NT_BanHang_KiemTraDonDaThanhToan(fmain.BHID_NT_BanHang_);
                    if (kt == false)
                    {
                        rbtnHuyPhieu_Click(sender, e);
                        return;
                    }
                }
                else
                { statusTB.Text = "Không có phiếu bán hàng để hủy!"; }
            }
            if (e.KeyCode == Keys.F9)
            {
                if (fmain.BHID_NT_BanHang_ != null && fmain.BHID_NT_BanHang_.Length > 0)
                {
                    kt = bh.NT_BanHang_KiemTraDonDaThanhToan(fmain.BHID_NT_BanHang_);
                    if (kt == false)
                    {
                        rbtnInPhieu_Click(sender, e);
                        if (fmain.fNT_ThanhToanEdit_.Dathanhtoan == true)
                        {
                            btnThemMoi_Click(sender, e);
                            return;
                        }
                    }
                }
                else
                { statusTB.Text = "Phiếu in tạm không tồn tại!"; }
                return;
            }
            //if (e.KeyCode == Keys.Delete)
            //{
            //    if (fmain.BHID_NT_BanHang_ != null && fmain.BHID_NT_BanHang_.Length > 0)
            //    {
            //        kt = bh.NT_BanHang_KiemTraDonDaThanhToan(fmain.BHID_NT_BanHang_);
            //        if (kt == false)
            //        {
            //            rbtnHuySP_Click(sender, e);
            //        }
            //    }
            //    else
            //    { statusTB.Text = "Không có dữ liệu để xóa!"; }
            //}
            if (e.KeyCode == Keys.F5)
            {
                if (btnAdd.Enabled == true)
                {
                    btnAdd_Click(sender, e);
                    radMultiColumnComboboxMaSP.Focus();
                    SendKeys.Send("{Escape}");
                    return;
                }
                else
                {
                    statusTB.Text = "Đơn hàng đã thanh toán, không thể thêm chi tiết!";
                }
            }
        }

        private void rbtnHuyPhieu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXoa(fmain.fNT_BanHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (MessageBox.Show("Bạn có muốn hủy số phiếu này không???", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (fmain.BHID_NT_BanHang_ != null && fmain.BHID_NT_BanHang_.Length > 0)
                {
                    CSQLNT_BanHang bh = new CSQLNT_BanHang();
                    int kq = bh.HuyPhieuBH(fmain.BHID_NT_BanHang_);
                    if (kq > 0)
                    {
                        btnThemMoi_Click(sender, e);
                    }
                    else
                    {
                        statusTB.Text = "Hủy phiếu thất bại!";
                    }
                }
                else
                {
                    statusTB.Text = "Không có dữ liệu để hủy phiếu!";
                }
                //DUNGLV ADD DISABLE Combobox start
                radMultiColumnComboboxMaSP.Enabled = true;
                //DUNGLV ADD DISABLE Combobox end
            }
            else
            {
                return;
            }

        }

        InTam intam_ = new InTam();
        bool intam = false;
        XuLyMayInPos xuly_ = new XuLyMayInPos();
        bool KTmayin = false;

        ThanhToan sales_ = new ThanhToan();
        bool thanhtoan = false;
        bool inLoDate;
        private void rbtnInTam_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(fmain.fNT_BanHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                CSQLNT_BanHang bh = new CSQLNT_BanHang();
                CSQLNhaThuoc nhathuoc_ = new CSQLNhaThuoc();
                CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
                CSQLNT_BanHangCT banhangct_ = new CSQLNT_BanHangCT();
                CSQLNhanVien nv = new CSQLNhanVien();
                string tennv_;
                if (radMultiColumnComboBoxTenNV.SelectedValue == null)
                {
                    statusTB.Text = "Vui lòng chọn bán chính!";
                    return;
                }
                else
                {
                    tennv_ = nv.LayThongTinNhanVienTheoMa(radMultiColumnComboBoxTenNV.EditorControl.CurrentRow.Cells["NVID"].Value.ToString()).Rows[0]["HoTen"].ToString();
                }

                DataTable dtbnhathuoc = nhathuoc_.LayNhaThuocTheoMa(chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString());
                string tennhathuoc_ = dtbnhathuoc.Rows[0]["TenNT"].ToString();
                string telnhathuoc_ = dtbnhathuoc.Rows[0]["Tel"].ToString();
                DataTable dtbthanhtoan = bh.LayTienThanhToan_Nhan_TraLaiTheoBHID(fmain.BHID_NT_BanHang_);
                DataTable dtbbhct_ = banhangct_.LayINCHITIET(fmain.BHID_NT_BanHang_);
                PosDeviceTag tag = xuly_.currentDevice;
                if (tag != null)
                {
                    if (bh.IsDaThanhToan(fmain.BHID_NT_BanHang_) == 1)
                    {
                        DialogResult result = MessageBox.Show("Bạn muốn in có Số lô - Hạn dùng không???", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            inLoDate = true;
                        }
                        else if (result == DialogResult.No)
                        {
                            inLoDate = false;
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                        //if (MessageBox.Show("Bạn muốn in có Số lô - Hạn dùng không???", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        //    inLoDate = true;
                        //}
                        //else
                        //{
                        //    inLoDate = false;
                        //}
                        string sp_ = dtbthanhtoan.Rows[0]["SoCT"].ToString();
                        decimal phaithu_ = decimal.Parse(dtbthanhtoan.Rows[0]["TTBanCoTAXDaGiamGia"].ToString());
                        decimal danhan_ = decimal.Parse(dtbthanhtoan.Rows[0]["TTNhan"].ToString());
                        decimal tra_ = decimal.Parse(dtbthanhtoan.Rows[0]["TTTraLai"].ToString());
                        try
                        {
                            sales_.ChonMayIn(xuly_, tennhathuoc_, telnhathuoc_, sp_, CStaticBien.STenMayThuNgan, tennv_,
         CStaticBien.StaiKhoan, dtbbhct_, phaithu_, danhan_, tra_, inLoDate, true);
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
                                intam_.InTamCuaBanHang(xuly_, tennhathuoc_, telnhathuoc_, txtSoPhieu.Text, CStaticBien.STenMayThuNgan, tennv_, CStaticBien.StaiKhoan, dtbbhct_, decimal.Parse(txtTongTien.Text), true);
                                intam = true;
                            }
                            else
                            {
                                intam_.InTamCuaBanHang(xuly_, tennhathuoc_, telnhathuoc_, txtSoPhieu.Text, CStaticBien.STenMayThuNgan, tennv_, CStaticBien.StaiKhoan, dtbbhct_, decimal.Parse(txtTongTien.Text), false);
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
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }

        }

        private void radMultiColumnComboBoxTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                radMultiColumnComboboxMaSP.Focus();
            }
        }

        private void radMultiColumnComboboxMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                RadTextBoxItem rtbi = radMultiColumnComboboxMaSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                rtbi.SelectionLength = 0;
                txtSLBan.Focus();
                txtSLBan.SelectAll();
            }
        }

        private void cboDVBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSLBan.Focus();
            }
        }
        private void txtSLBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (txtSLBan.Text.Length == 0)
                {
                    statusTB.Text = "Bạn phải nhập số lượng bán!";
                    txtSLBan.Focus();
                }
                else
                    cboSoLo.Focus();
            }
        }

        private void cboSoLo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboGiamGia.Focus();
            }
        }

        private void cboGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAdd.Focus();
            }
        }

        private bool _dataCellClicked = false;
        private void rgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            if (_dataCellClicked) 
            { 
                CSQLSanPham_NSX sp_nsx = new CSQLSanPham_NSX();
                radMultiColumnComboboxMaSP.SelectedValue = new Guid(sp_nsx.SanPham_NSX_LaySPNSXIDTheoSPID_NSXID(rgvChiTiet.CurrentRow.Cells["colSPID"].Value.ToString(), rgvChiTiet.CurrentRow.Cells["colNSXID"].Value.ToString()));
                //radMultiColumnComboboxMaSP.SelectedValue = rgvChiTiet.CurrentRow.Cells["colSPID"].Value;
                //DUNGLV ADD DISABLE Combobox start
                radMultiColumnComboboxMaSP.Enabled = false;
                //DUNGLV ADD DISABLE Combobox end
                txtSLBan.Text = rgvChiTiet.CurrentRow.Cells["colSLBan"].Value.ToString();
                cboDVBan.SelectedValue = rgvChiTiet.CurrentRow.Cells["colDVBanID"].Value;
                cboSoLo.SelectedValue = rgvChiTiet.CurrentRow.Cells["colLot"].Value;
                sBHCTid = rgvChiTiet.CurrentRow.Cells["colBHCTID"].Value.ToString();
                cboGiamGia.SelectedValue = rgvChiTiet.CurrentRow.Cells["colGiamGia"].Value.ToString();
            }
        }

        private void radMultiColumnComboBoxTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radMultiColumnComboBoxTenNV.SelectedValue != null && radMultiColumnComboBoxTenNV.SelectedIndex != -1)
            {
                CSQLNhanVien nv = new CSQLNhanVien();
                txtMaNV.Text = nv.LayThongTinNhanVienTheoMa(radMultiColumnComboBoxTenNV.EditorControl.CurrentRow.Cells["NVID"].Value.ToString()).Rows[0]["MaNV"].ToString();
                //cboBanChinh.DroppedDown = true;
            }
            else
            {
                txtMaNV.Text = "";
            }
        }

        private void rgvSPHoatChat_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            VeManHinhBanHang();
        }

        private void VeManHinhBanHang()
        {
            try
            {
                CSQLSanPham_NSX sp_nsx = new CSQLSanPham_NSX();
                radMultiColumnComboboxMaSP.SelectedValue = new Guid(rgvSPHoatChat.CurrentRow.Cells["colSPNSXID"].Value.ToString());
                //radMultiColumnComboboxMaSP.SelectedValue = new Guid(rgvSPHoatChat.CurrentRow.Cells["colSPID"].Value.ToString());
                rpvMain.SelectedPage = rpvBanHang;
                rgvSPHoatChat.DataSource = null;
                mcboMaSP.SelectedIndex = -1;
                //mcboTenSP.SelectedIndex = -1;
                txtSLBan.Focus();
            }
            catch (Exception Ex)
            {
                statusTB.Text = "Đã có lỗi phát sinh khi chọn sản phẩm từ form hoạt chất: " + Ex.Message;
            }
        }

        private void rgvDSTamTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rgvDSTamTinh_DoubleClick(sender, e);
            }
        }

        private void rgvSPHoatChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VeManHinhBanHang();
            }
        }

        private void ckGiamGia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckGiamGia.Checked == true)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    fmain.fTKXacNhan = new frmTKXacNhan(fmain);
                    if (qtc.KiemTraQuyenThem_Sua(fmain.fTKXacNhan.Name) == false)
                    {
                        fmain.fTKXacNhan.ShowDialog();
                    }
                    else
                    {
                        this.KichHoatGiamGia(true);
                    }


                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        public void KichHoatGiamGia(bool trangthai)
        {
            cboGiamGia.Enabled = trangthai;
            if (trangthai == true)
                ckGiamGia.Enabled = false;
            else
                ckGiamGia.Enabled = true;
            ckGiamGia.Checked = trangthai;
        }

        private void cboSoLo_TextChanged(object sender, EventArgs e)
        {
            if (cboSoLo.Text.Length == 0)
            {
                lblSLCoTheBan.Text = "0";
                lblSLTonKho.Text = "0";
            }
        }

        private void rgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            CSQLNT_BanHang bh = new CSQLNT_BanHang();
            if (e.KeyCode == Keys.Delete)
            {
                if (fmain.BHID_NT_BanHang_ != null && fmain.BHID_NT_BanHang_.Length > 0)
                {
                    bool kt = bh.NT_BanHang_KiemTraDonDaThanhToan(fmain.BHID_NT_BanHang_);
                    if (kt == false)
                    {
                        rbtnHuySP_Click(sender, e);
                    }
                    else
                    { statusTB.Text = "Đơn hàng đã được thanh toán. Không thể xóa được!"; }

                }
                else
                { 
                    statusTB.Text = "Không có dữ liệu để xóa!"; 
                }

                KiemTraDanhSachChiTietKho(fmain.BHID_NT_BanHang_);
            }
        }

        private void cboSoLo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Escape)
            {
                cboSoLo.SelectedIndex = -1;
                dtHanDung.Format = DateTimePickerFormat.Custom;
                dtHanDung.CustomFormat = " ";
            }
        }

        private void cbkHangDacBiet_CheckedChanged(object sender, EventArgs e)
        {
            LayDSMaSP_TenSPLenMultiColumnCombobox();
        }

        private void rgvChiTiet_MouseDown(object sender, MouseEventArgs e)
        {
            _dataCellClicked = false;
            GridDataCellElement cell = this.rgvChiTiet.ElementTree.GetElementAtPoint(e.Location) as GridDataCellElement;
            if (cell != null)
            {
                _dataCellClicked = true;
            }
        }
    }
}
