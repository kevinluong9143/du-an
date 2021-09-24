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
using Telerik.WinControls.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using ECOPharma2013.From_Report;

namespace ECOPharma2013
{
    public partial class frmDieuChinhTonEdit : Form
    {
        frmMain _frmMain;
        CSQLCauHinhHeThong chht_ = new CSQLCauHinhHeThong();
        static string DCTKID;
        public frmDieuChinhTonEdit()
        {
            InitializeComponent();
        }
        public frmDieuChinhTonEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
            if (_frmMain.MaDieuChinhTon_ == null || (_frmMain.MaDieuChinhTon_ != null && _frmMain.MaDieuChinhTon_.Length == 0))
                DCTKID = "00000000-0000-0000-0000-000000000000";
            else
                DCTKID = _frmMain.MaDieuChinhTon_;
        }
        string ttcn_;
        private void frmDieuChinhTonEdit_Load(object sender, EventArgs e)
        {
            try
            {
                ttcn_ = chht_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
                bool XemKhoDacBiet = (bool)chht_.LayDanhSachCauHinhHeThong().Rows[0]["IsXemKhoDacBiet"];
                if (XemKhoDacBiet == true)
                    chkHangDacBiet.Show();
                else
                    chkHangDacBiet.Hide();
                LayDanhSachNhaThuocLenCombobox();
                LayTenSPToAutoCompleCombobox();
                cboNSX.Enabled = false;
                if (_frmMain.BangDieuChinhTon_ != null && _frmMain.BangDieuChinhTon_.Rows.Count > 0)
                {
                    chkHangDacBiet.Enabled = false;
                    CSQLDieuChinhTonCT dcckct_ = new CSQLDieuChinhTonCT();
                    txtSoPhieu.Text = _frmMain.BangDieuChinhTon_.Rows[0]["SoPDC"].ToString();
                    dtNgayCT.Value = (DateTime)_frmMain.BangDieuChinhTon_.Rows[0]["NgayTao"];
                    cboNT.SelectedValue = _frmMain.BangDieuChinhTon_.Rows[0]["NTid"];
                    ckDuyet.Checked = (bool)_frmMain.BangDieuChinhTon_.Rows[0]["DaXetDuyet"];
                    chkHangDacBiet.Checked = (bool)_frmMain.BangDieuChinhTon_.Rows[0]["IsKhoDacBiet"];
                    txtGhiChu.Text = _frmMain.BangDieuChinhTon_.Rows[0]["GhiChu"].ToString();

                    DataTable Bangdctkchitiet = dcckct_.LayTT_DCTKCT_Theo_DCTKid(DCTKID);
                    if (Bangdctkchitiet != null && Bangdctkchitiet.Rows.Count > 0)
                    {
                        LayKhoNhapVaoCombobox(cboNT.SelectedValue.ToString());
                        rgvChiTiet.CellFormatting += new CellFormattingEventHandler(rgvChiTiet_CellFormatting);
                        rgvChiTiet.DataSource = Bangdctkchitiet;
                    }
                    else
                        chkHangDacBiet.Enabled = true;

                    if ((bool)_frmMain.BangDieuChinhTon_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangDieuChinhTon_.Rows[0]["DaXacNhan"] == false)
                    {
                        this.rgvChiTiet.Columns["colLot"].ReadOnly = true;
                        this.rgvChiTiet.Columns["colKhoID"].ReadOnly = true;
                        btnAdd.Enabled = false;
                        rbtnThemMoi.Enabled = false;
                        cboNT.Enabled = false;
                    }
                    if ((bool)_frmMain.BangDieuChinhTon_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangDieuChinhTon_.Rows[0]["DaXacNhan"] == true)
                    {
                        this.rgvChiTiet.Columns["colLot"].ReadOnly = true;
                        this.rgvChiTiet.Columns["colKhoID"].ReadOnly = true;
                        btnAdd.Enabled = false;
                        rbtnThemMoi.Enabled = false;
                        rbtnLuu.Enabled = false;
                        ckDuyet.Enabled = false;
                        cboNT.Enabled = false;
                    }
                }
                rgvChiTiet.CellFormatting += new CellFormattingEventHandler(rgvChiTiet_CellFormatting);
            }
            catch { }
        }

        void rgvChiTiet_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "colSTT" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }
        void LayDanhSachNhaThuocLenCombobox()
        {
            CSQLNhaThuoc nt = new CSQLNhaThuoc();
            cboNT.DisplayMember = "TenNT";
            cboNT.ValueMember = "NTID";
            cboNT.DataSource = nt.NhaThuoc_LayDSNhaThuocLenCBBox();
            cboNT.SelectedIndex = -1;
        }

        #region  Lấy danh sách masp, tên thuốc, nsx vào multicolumncombobox
        private void LayTenSPToAutoCompleCombobox()
        {
            try
            {
                CSQLDieuChinhTonCT dctct = new CSQLDieuChinhTonCT();

                radMultiColumnComboBoxMaSP.ValueMember = "SPNSXID";
                radMultiColumnComboBoxMaSP.DisplayMember = "MaSP";
                radMultiColumnComboBoxMaSP.DataSource = dctct.LayMaSP_TenSP();

                radMultiColumnComboBoxTenSP.ValueMember = "SPNSXID";
                radMultiColumnComboBoxTenSP.DisplayMember = "TenSP";
                radMultiColumnComboBoxTenSP.DataSource = dctct.LayMaSP_TenSP();
                radMultiColumnComboBoxMaSP.SelectedIndex = -1;
                radMultiColumnComboBoxTenSP.SelectedIndex = -1;

                radMultiColumnComboBoxMaSP.EditorControl.Columns["SPID"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["DVTID_Chuan"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["KhoNhapNTid"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["KhoNhapid"].IsVisible = false;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["MaSP"].Width = 65;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["TenSP"].Width = 250;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["TenNSX"].Width = 150;
                radMultiColumnComboBoxMaSP.EditorControl.Columns["DVChuan"].Width = 65;
                radMultiColumnComboBoxMaSP.AutoFilter = true;
                FilterDescriptor descriptor = new FilterDescriptor(this.radMultiColumnComboBoxMaSP.DisplayMember, FilterOperator.IsEqualTo, string.Empty);
                this.radMultiColumnComboBoxMaSP.EditorControl.FilterDescriptors.Add(descriptor);
                this.radMultiColumnComboBoxMaSP.DropDownStyle = RadDropDownStyle.DropDown;
                radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownWidth = 565;
                radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;

                radMultiColumnComboBoxTenSP.EditorControl.Columns["SPID"].IsVisible = false;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["NSXID"].IsVisible = false;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["DVTID_Chuan"].IsVisible = false;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["KhoNhapNTid"].IsVisible = false;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["KhoNhapid"].IsVisible = false;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["MaSP"].Width = 65;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["TenSP"].Width = 250;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["TenNSX"].Width = 150;
                radMultiColumnComboBoxTenSP.EditorControl.Columns["DVChuan"].Width = 65;
                radMultiColumnComboBoxTenSP.AutoFilter = true;
                FilterDescriptor descriptor1 = new FilterDescriptor(this.radMultiColumnComboBoxTenSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
                this.radMultiColumnComboBoxTenSP.EditorControl.FilterDescriptors.Add(descriptor1);
                this.radMultiColumnComboBoxTenSP.DropDownStyle = RadDropDownStyle.DropDown;
                radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownWidth = 565;
                radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;
            }
            catch { }
        }
        #endregion

        #region  Xử lý khi chọn MaSP khác giữa 2 MultiColumnCombobox
        private void radMultiColumnComboBoxMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radMultiColumnComboBoxTenSP.SelectedValue == null || (radMultiColumnComboBoxTenSP.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedValue.ToString().CompareTo(radMultiColumnComboBoxTenSP.SelectedValue.ToString()) != 0))
                {
                    radMultiColumnComboBoxTenSP.SelectedValue = radMultiColumnComboBoxMaSP.SelectedValue;
                }
                if (radMultiColumnComboBoxMaSP.SelectedValue != null)
                {
                    LayNSXLenCboNSX(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                    LayThongTinDVT(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                    LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNT.SelectedValue.ToString());
                    LayThongTinLenCbxLo(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNSX.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cboNT.SelectedValue.ToString());
                    LayKhoNhapVaoCombobox(cboNT.SelectedValue.ToString());
                }
                else
                {
                    radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                    radMultiColumnComboBoxMaSP.SelectedValue = null;
                    cboNSX.SelectedIndex = -1;
                    cboLot.SelectedIndex = -1;
                    cboDVT.SelectedIndex = -1;
                    cboKho.SelectedIndex = -1;
                    txtSL.Text = "";
                }
                RadMultiColumnComboBox comboBox = (RadMultiColumnComboBox)sender;
                RadTextBoxItem rtbi = (RadTextBoxItem)comboBox.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                rtbi.SelectionLength = 0;
            }
            catch
            {
                statusTB.Text = "";
            }
        }
        private void radMultiColumnComboBoxTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radMultiColumnComboBoxTenSP.SelectedValue != null && radMultiColumnComboBoxTenSP.SelectedIndex != -1)
            {
                //Lấy mã sp
                if (radMultiColumnComboBoxMaSP.SelectedValue == null || (radMultiColumnComboBoxMaSP.SelectedValue != null && radMultiColumnComboBoxTenSP.SelectedValue.ToString().CompareTo(radMultiColumnComboBoxMaSP.SelectedValue.ToString()) != 0))
                {
                    radMultiColumnComboBoxMaSP.SelectedValue = radMultiColumnComboBoxTenSP.SelectedValue;
                }
            }
            RadMultiColumnComboBox comboBox = (RadMultiColumnComboBox)sender;
            RadTextBoxItem rtbi = (RadTextBoxItem)comboBox.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
            rtbi.SelectionLength = 0;
        }
        #endregion

        #region Lấy thông tin lên ColumnCombobox Nhà Sản Xuất
        private void LayNSXLenCboNSX(string spid)
        {
            if (spid != null && spid.Length > 0)
            {
                CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                cboNSX.DisplayMember = "TenNSX";
                cboNSX.ValueMember = "NSXID";
                cboNSX.DataSource = spnsx.LayNSXVaoCBX(spid);
                cboNSX.SelectedValue = new Guid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
            }
            else
                cboNSX.DataSource = null;
        }
        #endregion

        #region Lấy thông tin lên DVT
        private void LayThongTinDVT(string spid)
        {
            if (spid != null && spid.Length > 0)
            {
                //Lấy danh sách DVT từ bảng hệ số qui đổi
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                DataTable dsdvt = hsqd.LayDVTTheoSPID(spid);

                cboDVT.DisplayMember = "TenTuDVT";
                cboDVT.ValueMember = "TuDVTID";
                cboDVT.DataSource = dsdvt;
                cboDVT.SelectedValue = new Guid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["DVTID_Chuan"].Value.ToString());
            }
            else
            {
                cboDVT.DataSource = null;
                txtSL.Text = "0";
            }
        }
        #endregion

        #region Lấy thông tin lên cbxLo
        private void LayThongTinLenCbxLo(string spid, string nsxid, string Khoid, string ntid)
        {
            if (spid == null || spid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn sản phẩm!";
                return;
            }
            else statusTB.Text = "";

            if (nsxid == null || nsxid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn nhà sản xuất!";
                return;
            }
            else statusTB.Text = "";

            if (Khoid == null || Khoid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn Kho!";
                return;
            }
            else statusTB.Text = "";

            cboLot.DisplayMember = "Lot";
            cboLot.ValueMember = "Lot";
            CSQLTonKhoCT tkct = new CSQLTonKhoCT();
            DataTable dtb = new DataTable();
            CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
            if (ntid == ttcn_)
            {
                dtb = tkct.LayLoTheoSPID_NSXID_KHOID(spid, nsxid, Khoid);
            }
            else
            {
                string khonhapcty_ = sp_kho.LayKhoNhapCTY_Theo_KhoNhapNT(spid, Khoid);
                dtb = tkct.LayLoTheoSPID_NSXID_KHOID(spid, nsxid, khonhapcty_);
            }
            if (dtb.Rows.Count > 0)
            {
                cboLot.DataSource = dtb;
            }
            else
            {
                cboLot.DataSource = null;
                txtSL.Text = "0";
            }
        }
        #endregion

        #region Lấy thông tin lên dtHanDung
        private void LayThongTinDate(string spid, string lot, string nsxid)
        {
            try
            {
                CSQLHeSoQuyDoi hsqd_ = new CSQLHeSoQuyDoi();
                CSQLTonKhoCT tk = new CSQLTonKhoCT();
                DataTable dtb = tk.LayDateTheoSP_Lot(spid, lot, nsxid);
                dtHanDung.Value = DateTime.Parse(dtb.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }
        #endregion

        #region Lấy thông tin lên combobox Kho
        private void LayKho(string spid, string ntid)
        {
            try
            {
                if (spid != null && spid.Length > 0 && ntid != null && ntid.Length > 0)
                {
                    CSQLKho kho = new CSQLKho();
                    DataTable dtb = new DataTable();
                    if (ntid == ttcn_)
                    {
                        if (chkHangDacBiet.Checked == true)
                            dtb = kho.LoadDSKho_DeDieuChinhTon(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapid"].Value.ToString(), true);
                        else
                            dtb = kho.LoadDSKho_DeDieuChinhTon(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapid"].Value.ToString(), false);
                    }
                    else
                    {
                        if (chkHangDacBiet.Checked == true)
                            dtb = kho.LoadDSKho_DeDieuChinhTon(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapNTid"].Value.ToString(), true);
                        else
                            dtb = kho.LoadDSKho_DeDieuChinhTon(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapNTid"].Value.ToString(), false);
                    }
                    if (dtb != null && dtb.Rows.Count > 0)
                    {
                        cboKho.DisplayMember = "TenKho";
                        cboKho.ValueMember = "KhoID";
                        cboKho.DataSource = dtb;
                        if (ntid == ttcn_)
                        {
                            cboKho.SelectedValue = new Guid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapid"].Value.ToString());
                        }
                        else
                        {
                            cboKho.SelectedValue = new Guid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["KhoNhapNTid"].Value.ToString());
                        }
                        statusTB.Text = "";
                    }
                    else
                    {
                        cboKho.DataSource = null;
                        statusTB.Text = "Thông báo: Chưa có kho nào chứa sản phẩm của nhà sản xuất này hoặc bạn chưa chọn nơi điều chỉnh!";
                        return;
                    }
                }
                else
                {
                    cboKho.DataSource = null;
                    statusTB.Text = "Thông báo: Không xác định được sản phẩm hoặc nhà sản xuất để lấy kho!";
                    return;
                }
            }
            catch { }
        }
        #endregion
        string MaBPcon;
        #region Lấy thông kho Nhập cho Lưới
        void LayKhoNhapVaoCombobox(string ntid)
        {
            if (ntid != null && ntid.Length > 0)
            {
                CSQLKho kho = new CSQLKho();
                DataTable dtb = new DataTable();
                string mabp_ = chht_.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();
                CSQLBoPhan bp_ = new CSQLBoPhan();
                DataTable bpct_ = bp_.TimMaBPChaTheoMa(mabp_);
                string mabpcha = bpct_.Rows[0]["MaBPCha"].ToString();
                if (mabpcha != null && mabpcha.Length > 0)
                {
                    MaBPcon = mabpcha;
                }
                else
                {
                    MaBPcon = mabp_;
                }
                if (ntid == ttcn_)
                {
                    if (chkHangDacBiet.Checked == true)
                        dtb = kho.LoadKho_TongCongTy_NhapXuat(MaBPcon, true);
                    else
                        dtb = kho.LoadKho_TongCongTy_NhapXuat(MaBPcon, false);
                }
                else
                {
                    if (chkHangDacBiet.Checked == true)
                        dtb = kho.LoadKho_NhaThuoc_NhapXuat(MaBPcon, true);
                    else
                        dtb = kho.LoadKho_NhaThuoc_NhapXuat(MaBPcon, false);
                }
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    ((GridViewComboBoxColumn)rgvChiTiet.Columns["colTenKho"]).DataSource = dtb;
                    ((GridViewComboBoxColumn)rgvChiTiet.Columns["colTenKho"]).DisplayMember = "TenKho";
                    ((GridViewComboBoxColumn)rgvChiTiet.Columns["colTenKho"]).ValueMember = "KhoID";
                    statusTB.Text = "";
                }
            }
        }
        #endregion

        //private void cboNSX_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (radMultiColumnComboBoxMaSP.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedValue.ToString().Length > 0 && cboNSX.SelectedValue != null && cboNSX.SelectedValue.ToString().Length > 0)
        //        LayThongTinLenCbxLo(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNSX.SelectedValue.ToString());
        //}

        private void cboLot_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLot.DataSource != null)
            {
                try
                {
                    LayThongTinDate(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboLot.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                }
                catch { }
            }
        }
        private void cboNT_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboNT.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedValue != null)
            {
                LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNT.SelectedValue.ToString());
                LayKhoNhapVaoCombobox(cboNT.SelectedValue.ToString());
            }
            if (cboNT.DataSource != null && rgvChiTiet != null && rgvChiTiet.Rows.Count > 0)
            {
                LayKhoNhapVaoCombobox(cboNT.SelectedValue.ToString());
                CSQLNhaThuoc nt_ = new CSQLNhaThuoc();
                CSQLDieuChinhTon dctk = new CSQLDieuChinhTon();
                string MaNTChuaThayDoi = dctk.LayDieuChinhTonKhoTheoMa(DCTKID).Rows[0]["NTid"].ToString();
                int nhomloaiChuaThayDoi = int.Parse(nt_.LayNhaThuocTheoMa(MaNTChuaThayDoi).Rows[0]["NhomLoai"].ToString());
                int nhomloaiDaThayDoi = int.Parse(nt_.LayNhaThuocTheoMa(cboNT.SelectedValue.ToString()).Rows[0]["NhomLoai"].ToString());
                if (nhomloaiDaThayDoi != nhomloaiChuaThayDoi)
                {
                    rbtnLuu_Click(sender, e);
                }
            }
        }
        private void rbtnThemMoi_Click(object sender, EventArgs e)
        {
            _frmMain.MaDieuChinhTonChiTietCanSua_ = null;
            chkHangDacBiet.Enabled = true;
            DCTKID = null;
            rgvChiTiet.DataSource = null;
            txtSoPhieu.Text = "";
            txtGhiChu.Text = "";
            radMultiColumnComboBoxMaSP.SelectedIndex = -1;
            radMultiColumnComboBoxTenSP.SelectedIndex = -1;
            txtSL.Text = "";
            cboNT.SelectedIndex = -1;
            cboDVT.SelectedIndex = -1;
            cboKho.SelectedIndex = -1;
            cboLot.SelectedIndex = -1;
            cboNSX.SelectedIndex = -1;
            LayDanhSachNhaThuocLenCombobox();
            txtImport.Text = "";
            cboNT.Focus();
        }
        private void rbtnDong_Click(object sender, EventArgs e)
        {
            _frmMain.BangDieuChinhTon_ = null;
            DCTKID = "";
            _frmMain.frmDieuChinhTonEditisOpen_ = false;
            this.Close();
        }
        bool khotrong = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fDieuChinhTon.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                if (cboNT.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn nơi điều chỉnh!";
                    cboNT.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (radMultiColumnComboBoxMaSP.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn sản phẩm!";
                    radMultiColumnComboBoxTenSP.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (cboNSX.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn nhà sản xuất!";
                    cboNSX.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (cboKho.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn kho điều chỉnh!";
                    cboKho.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (cboDVT.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn đơn vị tính!";
                    cboDVT.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (txtSL.Text.Length == 0)
                {
                    statusTB.Text = "Thông báo: Bạn chưa nhập Số lượng đáp ứng!";
                    txtSL.Focus();
                    txtSL.SelectAll();
                    return;
                }
                else statusTB.Text = "";

                if (cboLot.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn Lô cho sản phẩm!";
                    cboLot.Focus();
                    return;
                }
                else statusTB.Text = "";

                /*var a = rgvChiTiet.Rows.FirstOrDefault(x => x.Cells["colSPID"].Value.ToString() == radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString()
                    && x.Cells["colLot"].Value.ToString() == cboLot.Text
                    && String.Format("{0:yyyy-MM-dd}", x.Cells["colDate"].Value) != String.Format("{0:yyyy-MM-dd}", dtHanDung.Value)
                                                  );
                if (a!=null)
                {
                    MessageBox.Show("Bạn không thể nhập sản phẩm cùng lô nhưng khác date (Xin kiểm tra lại)!");
                    return;
                }*/
                //Kiểm tra trùng lô khác date
                CSQLNhapKhoChiTiet nhapkhoct_ = new CSQLNhapKhoChiTiet();
                string SPid = radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString();
                string Lot = cboLot.Text;
                DateTime Date = dtHanDung.Value;
                string NSXid = cboNSX.SelectedValue.ToString();

                if (nhapkhoct_.KiemTraLotDateDieuChinhTonKho(SPid, Lot, Date, NSXid) == 0)
                {
                    MessageBox.Show("Bạn không thể nhập sản phẩm cùng lô nhưng khác date (Xin kiểm tra lại)!");
                    return;
                }

                //Thêm Master
                if (txtSoPhieu.Text.Length == 0)
                {
                    #region Thêm điều chỉnh tồn kho
                    CSQLDieuChinhTon dctk_ = new CSQLDieuChinhTon();
                    dctk_.SGhiChu = txtGhiChu.Text;
                    dctk_.SMaNTid = cboNT.SelectedValue.ToString();
                    dctk_.DNgayTao = dtNgayCT.Value;
                    dctk_.SUserTao = CStaticBien.SmaTaiKhoan;
                    dctk_.DLastUD = DateTime.Now;
                    dctk_.SUserUD = CStaticBien.SmaTaiKhoan;

                    if (ckDuyet.Checked == true)
                    {
                        dctk_.BDaXetDuyet = true;
                        dctk_.DNgayXetDuyet = DateTime.Now;
                        dctk_.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
                    }
                    else
                    {
                        dctk_.BDaXetDuyet = false;
                        dctk_.DNgayXetDuyet = DateTime.Parse("1/1/1774");
                        dctk_.SUserXetDuyet = "00000000-0000-0000-0000-000000000000";
                    }

                    dctk_.BDaXacNhan = false;
                    dctk_.DNgayXacNhan = DateTime.Parse("1/1/1774"); ;
                    dctk_.SUserXacNhan = "00000000-0000-0000-0000-000000000000";

                    dctk_.BIsXoa = false;
                    dctk_.DNgayXoa = DateTime.Parse("1/1/1774");
                    dctk_.SUserXoa = "00000000-0000-0000-0000-000000000000";
                    dctk_.BHangDacBiet = chkHangDacBiet.Checked;
                    string kq = dctk_.Them(dctk_);
                    if (kq.Length > 0)
                    {
                        txtSoPhieu.Text = kq;
                        DCTKID = dctk_.LayDCTKidTheoSoPDC(txtSoPhieu.Text);
                        txtSoPhieu.Text = kq;
                        _frmMain.MaDieuChinhTon_ = dctk_.LayDCTKidTheoSoPDC(txtSoPhieu.Text);
                        groupBox2.Enabled = true;
                        _frmMain.fDieuChinhTon.rgvPhieuDCTon.DataSource = dctk_.LoadDieuChinhTonLenLuoi(_frmMain.IsXemTatCa_);
                        if (_frmMain.DSDieuChinhTonXacNhanIsOpen == true)
                        {
                            CSQLDieuChinhTon xldctk = new CSQLDieuChinhTon();
                            _frmMain.fDieuChinhTonXacNhan.rgvPhieuDieuChinh.DataSource = xldctk.LayDanhSachDieuChinhTonKhoXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Thêm điều chỉnh tồn thất bại!";
                    }
                    #endregion
                }
                else
                {
                    #region Sửa điều chỉnh tồn kho
                    CSQLDieuChinhTon dctk = new CSQLDieuChinhTon();
                    DataTable dbdctk_ = dctk.LayDieuChinhTonKhoTheoMa(_frmMain.MaDieuChinhTon_);
                    int kq = SuaDieuChinhTonKho();
                    if (kq == 1)
                    {
                        CSQLDieuChinhTonCT dctkct_ = new CSQLDieuChinhTonCT();
                        statusTB.Text = "Sửa điều chỉnh tồn thành công!";
                        _frmMain.fDieuChinhTon.rgvPhieuDCTon.DataSource = dctk.LoadDieuChinhTonLenLuoi(_frmMain.IsXemTatCa_);
                        if (_frmMain.DSDieuChinhTonXacNhanIsOpen == true)
                        {
                            CSQLDieuChinhTon xldctk = new CSQLDieuChinhTon();
                            _frmMain.fDieuChinhTonXacNhan.rgvPhieuDieuChinh.DataSource = xldctk.LayDanhSachDieuChinhTonKhoXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Sửa chuyển kho thất bại!";
                    }
                    #endregion
                }
                CSQLDieuChinhTonCT dctkct = new CSQLDieuChinhTonCT();
                CSQLDieuChinhTon dctk1 = new CSQLDieuChinhTon();

                #region Sửa Điều Chỉnh Tồn Kho Chi Tiết
                if (_frmMain.MaDieuChinhTonChiTietCanSua_ != null && _frmMain.MaDieuChinhTonChiTietCanSua_.CompareTo("") > 0)
                {
                    int kq = dctkct.XoaTTDieuChinhTonKhoCT(_frmMain.MaDieuChinhTonChiTietCanSua_);
                }
                #endregion

                #region Thêm Điều Chỉnh Tồn Kho CT

                string dctkid = dctk1.LayDCTKidTheoSoPDC(txtSoPhieu.Text);

                CSQLKho kho_ = new CSQLKho();
                string khodacbiet = kho_.KiemTraNhomKhoDacBiet(cboKho.SelectedValue.ToString());
                if (chkHangDacBiet.Checked == true && khodacbiet == null)
                {
                    MessageBox.Show("Khi chọn Hàng Đặc Biệt thì chỉ được điều chỉnh những sản phẩm tại Kho Đặc Biệt!", "Xác nhận");
                    return;

                }
                if (chkHangDacBiet.Checked == false && khodacbiet != null)
                {
                    MessageBox.Show("Khi không chọn Hàng Đặc Biệt thì không được điều chỉnh những sản phẩm tại Kho Đặc Biệt!", "Xác nhận");
                    return;
                }

                if (dctkid != null && dctkid.Length > 0)
                {
                    dctkct.SDCTKid = dctkid;
                    dctkct.SSPid = radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString();
                    dctkct.SMaNTid = cboNT.SelectedValue.ToString();
                    dctkct.SNSXID = cboNSX.SelectedValue.ToString();
                    dctkct.DecSLCanChinh = decimal.Parse(txtSL.Text);
                    dctkct.SDVT = cboDVT.SelectedValue.ToString();
                    if (khotrong == true)
                    {
                        dctkct.SKho = "00000000-0000-0000-0000-000000000000";
                        khotrong = false;
                    }
                    else
                    {
                        dctkct.SKho = cboKho.SelectedValue.ToString();
                    }
                    dctkct.SLot = cboLot.Text;
                    dctkct.DDate = dtHanDung.Value;

                    string kq1 = dctkct.Them(dctkct);
                    if (kq1 != null && kq1.Length > 0)
                    {
                        rgvChiTiet.DataSource = dctkct.LayTT_DCTKCT_Theo_DCTKid(dctkid);
                        _frmMain.fDieuChinhTon.rgvPhieuDCTon.DataSource = dctk1.LoadDieuChinhTonLenLuoi(_frmMain.IsXemTatCa_);
                        chkHangDacBiet.Enabled = false;
                        radMultiColumnComboBoxMaSP.SelectedIndex = -1;
                        radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                        txtSL.Text = "";
                        cboNSX.SelectedIndex = -1;
                        cboDVT.SelectedIndex = -1;
                        cboLot.DataSource = null;
                        cboKho.DataSource = null;
                        dtHanDung.Value = DateTime.Now;
                        statusTB.Text = "Thêm thành công";
                        radMultiColumnComboBoxMaSP.Focus();
                    }
                    else
                    {
                        statusTB.Text = "Thêm thất bại";
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }
        private void rbtnLuu_Click(object sender, EventArgs e)
        {
            Fr_DangXuLy.ShowFormCho();
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fDieuChinhTon.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                if ((DCTKID != null && DCTKID.CompareTo("") > 0))
                {
                    CSQLDieuChinhTon dctk = new CSQLDieuChinhTon();
                    DataTable dbdctk_ = dctk.LayDieuChinhTonKhoTheoMa(DCTKID);
                    #region chỉnh sửa
                    int kq = -1;
                    if (dbdctk_.Rows[0]["NTid"].ToString() == ttcn_ && cboNT.SelectedValue.ToString() == ttcn_ || dbdctk_.Rows[0]["NTid"].ToString() != ttcn_ && cboNT.SelectedValue.ToString() != ttcn_)
                    {
                        kq = SuaDieuChinhTonKho();

                        if (rgvChiTiet.Rows.Count > 0)
                        {
                            DataTable dtDataSource = new DataTable();
                            dtDataSource = (DataTable)rgvChiTiet.DataSource;

                            CSQLDieuChinhTonCT dctkct_ = new CSQLDieuChinhTonCT();
                            string message = dctkct_.UpdateKho_DieuChinhTonKhoCTMulti(DCTKID, cboNT.SelectedValue.ToString(), dtDataSource);
                            if (!message.Equals("OK"))
                            {
                                Fr_DangXuLy.DongFormCho();
                                MessageBox.Show(message);
                                return;
                            }
                        }
                    }
                    if (dbdctk_.Rows[0]["NTid"].ToString() != ttcn_ && cboNT.SelectedValue.ToString() == ttcn_ || dbdctk_.Rows[0]["NTid"].ToString() == ttcn_ && cboNT.SelectedValue.ToString() != ttcn_)
                    {
                        if (MessageBox.Show("Kho điều chỉnh sẽ được bỏ trống. Bạn có chắc chắn chọn Nơi Được Điều Chỉnh này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ckDuyet.Checked = false;
                            kq = SuaDieuChinhTonKho();
                            dctk.UpdatGiaKhiThayDoiNhaThuoc(DCTKID, cboNT.SelectedValue.ToString());
                            dctk.UpdateKho_DieuChinhTonKho(DCTKID);
                        }
                        else
                        {
                            cboNT.SelectedValue = dbdctk_.Rows[0]["NTid"].ToString();
                            return;
                        }
                    }
                    if (kq == 1)
                    {
                        CSQLDieuChinhTonCT dctkct = new CSQLDieuChinhTonCT();
                        _frmMain.fDieuChinhTon.rgvPhieuDCTon.DataSource = dctk.LoadDieuChinhTonLenLuoi(_frmMain.IsXemTatCa_);
                        rgvChiTiet.DataSource = dctkct.LayTT_DCTKCT_Theo_DCTKid(DCTKID);
                        statusTB.Text = "Sửa chuyển kho thành công!";
                        if (_frmMain.DSDieuChinhTonXacNhanIsOpen == true)
                        {
                            CSQLDieuChinhTon xldctk = new CSQLDieuChinhTon();
                            _frmMain.fDieuChinhTonXacNhan.rgvPhieuDieuChinh.DataSource = xldctk.LayDanhSachDieuChinhTonKhoXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Sửa chuyển kho thất bại.";
                    }
                }
                    #endregion
                else
                {
                    #region thêm mới
                    CSQLDieuChinhTon dctk_ = new CSQLDieuChinhTon();
                    dctk_.SGhiChu = txtGhiChu.Text;
                    dctk_.SMaNTid = cboNT.SelectedValue.ToString();
                    dctk_.DNgayTao = dtNgayCT.Value;
                    dctk_.SUserTao = CStaticBien.SmaTaiKhoan;
                    dctk_.DLastUD = DateTime.Now;
                    dctk_.SUserUD = CStaticBien.SmaTaiKhoan;

                    if (ckDuyet.Checked == true)
                    {
                        dctk_.BDaXetDuyet = true;
                        dctk_.DNgayXetDuyet = DateTime.Now;
                        dctk_.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
                    }
                    else
                    {
                        dctk_.BDaXetDuyet = false;
                        dctk_.DNgayXetDuyet = DateTime.Parse("1/1/1774");
                        dctk_.SUserXetDuyet = "00000000-0000-0000-0000-000000000000";
                    }

                    dctk_.BDaXacNhan = false;
                    dctk_.DNgayXacNhan = DateTime.Parse("1/1/1774"); ;
                    dctk_.SUserXacNhan = "00000000-0000-0000-0000-000000000000";

                    dctk_.BIsXoa = false;
                    dctk_.DNgayXoa = DateTime.Parse("1/1/1774");
                    dctk_.SUserXoa = "00000000-0000-0000-0000-000000000000";
                    dctk_.BHangDacBiet = chkHangDacBiet.Checked;

                    string maquantrave = dctk_.Them(dctk_);
                    if (maquantrave != null)
                    {
                        txtSoPhieu.Text = maquantrave;
                        DCTKID = dctk_.LayDCTKidTheoSoPDC(txtSoPhieu.Text);
                        _frmMain.fDieuChinhTon.rgvPhieuDCTon.DataSource = dctk_.LoadDieuChinhTonLenLuoi(_frmMain.IsXemTatCa_);
                        statusTB.Text = "Thêm chuyển kho thành công.";
                        if (_frmMain.DSDieuChinhTonXacNhanIsOpen == true)
                        {
                            CSQLDieuChinhTon xldctk = new CSQLDieuChinhTon();
                            _frmMain.fDieuChinhTonXacNhan.rgvPhieuDieuChinh.DataSource = xldctk.LayDanhSachDieuChinhTonKhoXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Thêm chuyển kho thất bại.";
                    }
                    #endregion
                }
            }
            catch { }

            Fr_DangXuLy.DongFormCho();
        }
        private int SuaDieuChinhTonKho()
        {
            CSQLDieuChinhTon dctk = new CSQLDieuChinhTon();
            CSQLDieuChinhTonCT dctkct = new CSQLDieuChinhTonCT();
            dctk.SDCTKid = dctk.LayDCTKidTheoSoPDC(txtSoPhieu.Text);
            dctk.SSoPDC = txtSoPhieu.Text;
            dctk.SMaNTid = cboNT.SelectedValue.ToString();
            dctk.SGhiChu = txtGhiChu.Text;
            dctk.DLastUD = DateTime.Now;
            dctk.SUserUD = CStaticBien.SmaTaiKhoan;

            if (ckDuyet.Checked == true)
            {
                dctk.BDaXetDuyet = true;
            }
            else
            {
                dctk.BDaXetDuyet = false;
            }
            dctk.DNgayXetDuyet = DateTime.Now;
            dctk.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
            dctk.BHangDacBiet = chkHangDacBiet.Checked;
            int kq = dctk.Sua(dctk);
            return kq;
        }
        private void radMultiColumnComboBoxMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                RadTextBoxItem rtbi = radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                rtbi.SelectionLength = 0;
                txtSL.Focus();
            }
        }
        private void radMultiColumnComboBoxTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                RadTextBoxItem rtbi = radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                rtbi.SelectionLength = 0;
                txtSL.Focus();
            }
        }
        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '-')
            //{
            //    MessageBox.Show("Chỉ được nhập số!");
            //    e.Handled = true;
            //}
            if (e.KeyChar == 13)
            {
                if (txtSL.Text.Length == 0)
                {
                    statusTB.Text = "Bạn phải nhập số lượng chuyển!";
                    txtSL.Focus();
                    SendKeys.Send("{Tab}");
                }
                else
                    cboDVT.Focus();
            }
        }
        private void cboDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboKho.Focus();
            }
        }
        private void cboKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboLot.Focus();
            }
        }
        private void cboLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAdd.Focus();
            }
        }
        private void btnAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAdd_Click(sender, e);
            }
        }
        private void ckDuyet_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckDuyet.Checked == true)
                {
                    CSQLDieuChinhTonCT dctkct = new CSQLDieuChinhTonCT();
                    //if (dctkct.LayTT_DCTKCT_Theo_DCTKid(dctkid).Rows[0]["KhoID"].ToString() == "")

                    if (DCTKID.Length > 0 && dctkct.LayTT_DCTKCT_Theo_DCTKid(DCTKID).Rows[0]["KhoID"].ToString() == "")
                    {
                        statusTB.Text = "Bạn không được bỏ trống kho điều chỉnh!";
                        ckDuyet.Checked = false;
                        return;
                    }
                    ThayDoiTrangThaiControls(false);
                    this.rgvChiTiet.Columns["colLot"].ReadOnly = true;
                    this.rgvChiTiet.Columns["colKhoID"].ReadOnly = true;
                }
                else
                {
                    ThayDoiTrangThaiControls(true);
                    this.rgvChiTiet.Columns["colLot"].ReadOnly = false;
                    this.rgvChiTiet.Columns["colKhoID"].ReadOnly = false;
                }
            }
            catch { }
        }
        private void ThayDoiTrangThaiControls(bool trangthai)
        {
            txtGhiChu.Enabled = trangthai;
            txtSL.Enabled = trangthai;
            cboDVT.Enabled = trangthai;
            cboNT.Enabled = trangthai;
            cboKho.Enabled = trangthai;
            cboLot.Enabled = trangthai;
            dtHanDung.Enabled = trangthai;
            radMultiColumnComboBoxMaSP.Enabled = trangthai;
            radMultiColumnComboBoxTenSP.Enabled = trangthai;
            btnAdd.Enabled = trangthai;
            txtImport.Enabled = trangthai;
            btnImport.Enabled = trangthai;
            btnDeleteAll.Enabled = trangthai;
        }
        private void rgvChiTiet_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (rgvChiTiet.CurrentRow.Cells["colDCTKCTid"].Value == null)
            {
                return;
            }
            else
            {
                _frmMain.MaDieuChinhTonChiTietCanSua_ = rgvChiTiet.CurrentRow.Cells["colDCTKCTid"].Value.ToString();
                CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                string spid = spnsx.SanPham_NSX_LaySPNSXIDTheoSPID_NSXID(rgvChiTiet.CurrentRow.Cells["colSPID"].Value.ToString(), rgvChiTiet.CurrentRow.Cells["colNSXid"].Value.ToString());
                radMultiColumnComboBoxMaSP.SelectedValue = new Guid(spid);
                radMultiColumnComboBoxTenSP.SelectedValue = new Guid(spid);
                if (rgvChiTiet.CurrentRow.Cells["colKhoID"].Value.ToString() == "")
                {
                    cboKho.SelectedValue = -1;
                }
                else
                {
                    cboKho.SelectedValue = new Guid(rgvChiTiet.CurrentRow.Cells["colKhoID"].Value.ToString());
                }
                txtSL.Text = String.Format("{0:N2}", decimal.Parse(rgvChiTiet.CurrentRow.Cells["colSLCanChinh"].Value.ToString()));
                cboDVT.SelectedValue = rgvChiTiet.CurrentRow.Cells["colDVTid"].Value.ToString();

                cboLot.Text = rgvChiTiet.CurrentRow.Cells["colLot"].Value.ToString();
                dtHanDung.Value = DateTime.Parse(rgvChiTiet.CurrentRow.Cells["colDate"].Value.ToString());
                txtSL.Focus();
                //LayThongTinDate(rgvChuyenKhoCT.CurrentRow.Cells["colSPID"].Value.ToString(), cboTuKho.SelectedValue.ToString(), cboLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
            }
        }
        private void rbtnIn_Click(object sender, EventArgs e)
        {
            InDieuChinhTon(DCTKID);
        }
        public void InDieuChinhTon(string tkid)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(_frmMain.fDieuChinhTon.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            CSQLDieuChinhTonCT dctkct_ = new CSQLDieuChinhTonCT();
            if (tkid != null && tkid.Length > 0)
            {
                DataTable DCTKCT_ = dctkct_.IN_DCTK_DCTKCT(tkid);
                Fr_DieuChinhTonKho check = new Fr_DieuChinhTonKho(DCTKCT_);
                check.Show();
            }
        }
        private void txtImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Excel (.xls)|*.xls|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtImport.Text = openFileDialog1.FileName;
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (txtImport.Text.Length > 0)
            {
                CSQLNhapKhoChiTiet nhapkhoct_ = new CSQLNhapKhoChiTiet();
                Fr_DangXuLy.ShowFormCho();
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + txtImport.Text + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");

                conn.Open();

                //string strQuery = "SELECT * FROM [" + Table + "]";
                string strQuery = "SELECT * FROM [Sheet1$]";

                System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);

                System.Data.DataSet ds = new System.Data.DataSet();

                adapter.Fill(ds);
                conn.Close();
                //rgvChiTiet.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0 && cboNT.SelectedValue != null)
                {
                    CSQLDieuChinhTon dct = new CSQLDieuChinhTon();
                    if (DCTKID == null || DCTKID.Equals("00000000-0000-0000-0000-000000000000"))
                    {
                        DCTKID = dct.DieuChinhTon_ThemImport(cboNT.SelectedValue.ToString(), txtGhiChu.Text, CStaticBien.SmaTaiKhoan, chkHangDacBiet.Checked);
                    }

                    if (DCTKID != null && DCTKID.Length > 0)
                    {
                        CSQLDieuChinhTonCT dctct = new CSQLDieuChinhTonCT();
                        string ketqua = dctct.ImportMulti(ds.Tables[0], cboNT.SelectedValue.ToString(), DCTKID);
                        if (!ketqua.Equals("OK"))
                        {
                            string Title = "";
                            string Message = "";
                            Fr_DangXuLy.DongFormCho();
                            switch (ketqua.Split('-')[0].ToLower())
                            {
                                case "trunglokhacdateimport":
                                    Title = "Trùng lô khác date trong file Import";
                                    Message = "Mã: " + ketqua.Split('-')[1];
                                    break;
                                case "trunglokhacdatetonkhoct":
                                    Title = "Trùng lô khác date với tồn kho";
                                    Message = "Mã: " + ketqua.Split('-')[1];
                                    break;
                                case "trunglokhacdatedieuchinhtonkho":
                                    Title = "Trùng lô khác date với điều chỉnh tồn kho";
                                    Message = "Mã: " + ketqua.Split('-')[1];
                                    break;
                                case "error":
                                    Title = "Lỗi";
                                    Message = "Mã: " + ketqua.Split('-')[1];
                                    break;
                                default:
                                    Title = "Lỗi không xác định";
                                    Message = ketqua;
                                    break;
                            }
                            MessageBox.Show(Message, Title);
                        }
                        else
                        {
                            #region OLD
                            /*for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (string.IsNullOrEmpty(ds.Tables[0].Rows[i]["MaSP"].ToString())) {
                                break;
                            }
                            try
                            {
                                

                                DataTable dtSanPham = nhapkhoct_.GetSPidFromMaSP(ds.Tables[0].Rows[i]["MaSP"].ToString());

                                string SPid = dtSanPham.Rows[0]["SPid"].ToString();
                                string Lot = ds.Tables[0].Rows[i]["LOT"].ToString();
                                DateTime Date = DateTime.Parse(ds.Tables[0].Rows[i]["Date"].ToString());
                                string NSXid = dtSanPham.Rows[0]["NSXid"].ToString();

                                if (nhapkhoct_.KiemTraLotDateDieuChinhTonKho(SPid, Lot, Date, NSXid) == 0)
                                {
                                    loitrunglokhacdate += "\n Mã:" + ds.Tables[0].Rows[i]["MaSP"].ToString() + " Cùng lô khác hạn dùng ở dòng "+(i+1);
                                }
                                else { 
                                    int kq = dctct.Import(ds.Tables[0].Rows[i]["MaSP"].ToString(),
                                                    decimal.Parse(ds.Tables[0].Rows[i]["SLCanChinh"].ToString()),
                                                    ds.Tables[0].Rows[i]["LOT"].ToString(),
                                                    DateTime.Parse(ds.Tables[0].Rows[i]["Date"].ToString()),
                                                    cboNT.SelectedValue.ToString(),
                                                    DCTKID,
                                                    CStaticBien.SmaTaiKhoan);
                                    rgvChiTiet.DataSource = dctct.LayTT_DCTKCT_Theo_DCTKid(DCTKID);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "\n Lỗi tại dòng:" + (i + 1));
                            }
                        }
                        if (loitrunglokhacdate.Length > 0)
                        {
                            MessageBox.Show("Đã phát sinh các trường hợp trùng lô khác date sau: " + loitrunglokhacdate + "\n Kiểm tra lại file excel và import lại!");
                            dct.XoaThongTinDieuChinhTonKho(DCTKID);
                            rbtnThemMoi_Click(sender, e);
                            return;
                        }*/
                            #endregion
                            DataTable dt = dct.LayDieuChinhTonKhoTheoMa(DCTKID);
                            txtSoPhieu.Text = dt.Rows[0]["SoPDC"].ToString();
                            dtNgayCT.Value = DateTime.Parse(dt.Rows[0]["NgayTao"].ToString());
                            txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                            ckDuyet.Checked = bool.Parse(dt.Rows[0]["DaXetDuyet"].ToString());

                            rgvChiTiet.DataSource = dctct.LayTT_DCTKCT_Theo_DCTKid(DCTKID);
                            LayKhoNhapVaoCombobox(cboNT.SelectedValue.ToString());
                            Fr_DangXuLy.DongFormCho();
                        }
                    }
                }
            }

        }
        private void chkHangDacBiet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHangDacBiet.Checked == true && cboNT.SelectedValue != null)
            {
                if (radMultiColumnComboBoxMaSP.SelectedValue != null)
                {
                    LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNT.SelectedValue.ToString());
                }
                LayKhoNhapVaoCombobox(cboNT.SelectedValue.ToString());
            }
            else if (chkHangDacBiet.Checked == false && cboNT.SelectedValue != null)
            {
                if (radMultiColumnComboBoxMaSP.SelectedValue != null)
                {
                    LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNT.SelectedValue.ToString());
                }
                LayKhoNhapVaoCombobox(cboNT.SelectedValue.ToString());
            }
        }
        private void rgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {

                    CSQLDieuChinhTonCT dctkct = new CSQLDieuChinhTonCT();
                    string dctkctid_canxoa = rgvChiTiet.CurrentRow.Cells["colDCTKCTid"].Value.ToString();
                    string dctkid_canxoa = rgvChiTiet.CurrentRow.Cells["colDCTKid"].Value.ToString();
                    if (dctkct.XoaTTDieuChinhTonKhoCT(dctkctid_canxoa) > 0)
                    {
                        DataTable dctonkhoct = dctkct.LayTT_DCTKCT_Theo_DCTKid(dctkid_canxoa);
                        if (dctonkhoct.Rows.Count == 0)
                        { chkHangDacBiet.Enabled = true; }
                        rgvChiTiet.DataSource = dctonkhoct;
                    }
                    else
                        statusTB.Text = "Xóa thất bại!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi khi xóa chi tiết chuyển kho", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            CSQLDieuChinhTonCT dctkct = new CSQLDieuChinhTonCT();

            string kq = dctkct.XoatTatCa(DCTKID);

            if (!kq.Equals("OK"))
            {
                MessageBox.Show(kq, "Thông báo");
                return;
            }
            else
            {
                rgvChiTiet.DataSource = dctkct.LayTT_DCTKCT_Theo_DCTKid(DCTKID);
            }
        }
    }
}
