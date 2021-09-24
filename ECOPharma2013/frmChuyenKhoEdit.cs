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
    public partial class frmChuyenKhoEdit : Form
    {
        frmMain _frmMain;
        string slton;
        public frmChuyenKhoEdit()
        {
            InitializeComponent();
        }
        public frmChuyenKhoEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        string MaBPcon;
        void LayDenKhoVaoCombobox()
        {
            CSQLBoPhan bp_ = new CSQLBoPhan();
            CSQLKho kho = new CSQLKho();
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            string mabp_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();
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
            cboDenKho.DisplayMember = "TenKho";
            cboDenKho.ValueMember = "KhoID";
            cboDenKho.DataSource = kho.LayKhoLenCBO_TongCongTy(MaBPcon);
            cboDenKho.SelectedIndex = -1;
        }

        #region  Xử lý lấy dữ liệu lên MultiColumnCombobox
        private void LayTenSPToAutoCompleCombobox()
        {
            CSQLTonKho tk = new CSQLTonKho();
            DataTable tonkho = tk.LayMaSP_TenSP();
            if (tonkho != null && tonkho.Rows.Count > 0)
            {
                radMultiColumnComboBoxMaSP.ValueMember = "SPNSXID";
                radMultiColumnComboBoxMaSP.DisplayMember = "MaSP";
                radMultiColumnComboBoxMaSP.DataSource = tonkho;

                radMultiColumnComboBoxTenSP.ValueMember = "SPNSXID";
                radMultiColumnComboBoxTenSP.DisplayMember = "TenSP";
                radMultiColumnComboBoxTenSP.DataSource = tonkho;
            }
            else
            {
                radMultiColumnComboBoxMaSP.ValueMember = "SPNSXID";
                radMultiColumnComboBoxMaSP.DisplayMember = "MaSP";
                radMultiColumnComboBoxMaSP.DataSource = tk.LayMaSP_TenSP_NT();
                radMultiColumnComboBoxTenSP.ValueMember = "SPNSXID";
                radMultiColumnComboBoxTenSP.DisplayMember = "TenSP";
                radMultiColumnComboBoxTenSP.DataSource = tk.LayMaSP_TenSP_NT();
            }

            radMultiColumnComboBoxMaSP.SelectedIndex = -1;
            radMultiColumnComboBoxTenSP.SelectedIndex = -1;

            radMultiColumnComboBoxMaSP.EditorControl.Columns["SPID"].IsVisible = false;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["DVTID_Chuan"].IsVisible = false;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["MaSP"].Width = 65;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["TenSP"].Width = 250;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["TenNSX"].Width = 150;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["SLTon"].Width = 65;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
            radMultiColumnComboBoxMaSP.EditorControl.Columns["DVChuan"].Width = 65;
            radMultiColumnComboBoxMaSP.AutoFilter = true;
            FilterDescriptor descriptor = new FilterDescriptor(this.radMultiColumnComboBoxMaSP.DisplayMember, FilterOperator.IsEqualTo, string.Empty);
            this.radMultiColumnComboBoxMaSP.EditorControl.FilterDescriptors.Add(descriptor);
            this.radMultiColumnComboBoxMaSP.DropDownStyle = RadDropDownStyle.DropDown;
            radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownWidth = 630;
            radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;

            radMultiColumnComboBoxTenSP.EditorControl.Columns["SPID"].IsVisible = false;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["NSXID"].IsVisible = false;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["DVTID_Chuan"].IsVisible = false;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["MaSP"].Width = 65;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["TenSP"].Width = 250;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["TenNSX"].Width = 150;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["SLTon"].Width = 65;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
            radMultiColumnComboBoxTenSP.EditorControl.Columns["DVChuan"].Width = 65;
            radMultiColumnComboBoxTenSP.AutoFilter = true;
            FilterDescriptor descriptor1 = new FilterDescriptor(this.radMultiColumnComboBoxTenSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
            this.radMultiColumnComboBoxTenSP.EditorControl.FilterDescriptors.Add(descriptor1);
            this.radMultiColumnComboBoxTenSP.DropDownStyle = RadDropDownStyle.DropDown;
            radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownWidth = 630;
            radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;

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
                }
                else
                {
                    radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                    radMultiColumnComboBoxMaSP.SelectedValue = null;
                    cboNSX.SelectedIndex = -1;
                    cboLo.SelectedIndex = -1;
                    cboDVT.SelectedIndex = -1;
                    cboTuKho.SelectedIndex = -1;
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

        #region Lấy thông tin lên combobox Kho
        private void LayKho(string spid, string nsxid)
        {
            DataTable dtb = new DataTable();
            if (spid != null && spid.Length > 0 && nsxid != null && nsxid.Length > 0)
            {
                CSQLTonKhoCT tkct = new CSQLTonKhoCT();
                //CSQLTonKho tk = new CSQLTonKho();
                //DataTable tonkho = tk.LayMaSP_TenSP();
                CSQLNhaThuoc nt_ = new CSQLNhaThuoc();
                int Nhomloai = nt_.LayNhomLoaiNhaThuoc();
                if (Nhomloai == 1)
                {
                    dtb = tkct.LayTTKho(spid, nsxid);
                }
                else
                {
                    dtb = tkct.LayTTKho_NT(spid, nsxid);
                }
                if (dtb != null && dtb.Rows.Count > 0)
                {

                    cboTuKho.DisplayMember = "TenKho";
                    cboTuKho.ValueMember = "KhoID";
                    cboTuKho.DataSource = dtb;
                    statusTB.Text = "";
                }
                else
                {
                    cboTuKho.DataSource = null;
                    statusTB.Text = "Thông báo: Chưa có kho nào chứa sản phẩm của nhà sản xuất này!";

                    return;
                }
            }
            else
            {
                cboTuKho.DataSource = null;
                statusTB.Text = "Thông báo: Không xác định được sản phẩm hoặc nhà sản xuất để lấy kho!";
                return;
            }
        }
        #endregion

        #region Lấy thông tin lên DVT
        private void LayThongTinDVTKhiKhoIDThayDoi(string spid, string khoid)
        {
            if (spid != null && khoid != null && spid.Length > 0 && khoid.Length > 0)
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
        private void LayThongTinLenCbxLo(string spid, string khoid, string nsxid)
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
            if (khoid == null || khoid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn kho!"; return;
            }
            else statusTB.Text = "";

            cboLo.DisplayMember = "Lot";
            cboLo.ValueMember = "Lot";
            DataTable dtb = new DataTable();
            CSQLTonKhoCT tkct = new CSQLTonKhoCT();
            //CSQLTonKho tk = new CSQLTonKho();
            //DataTable tonkho = tk.LayMaSP_TenSP();
            //if (tonkho != null && tonkho.Rows.Count > 0)
            CSQLNhaThuoc nt_ = new CSQLNhaThuoc();
            int Nhomloai = nt_.LayNhomLoaiNhaThuoc();
            if (Nhomloai == 1)
            {
                dtb = tkct.LayLoTheoSPID_KhoID(spid, khoid, nsxid);
            }
            else
            {
                dtb = tkct.LayLoTheoSPID_KhoID_NT(spid, khoid, nsxid);
            }
            if (dtb.Rows.Count > 0)
            {
                cboLo.DataSource = dtb;
            }
            else
            {
                txtSL.Text = "0";
            }
        }
        #endregion

        #region Lấy thông tin lên dtHanDung, slton, slcothexuat
        private void LayThongTinDate(string spid, string khoid, string lot, string nsxid)
        {
            try
            {
                DataTable dtb = new DataTable();
                CSQLHeSoQuyDoi hsqd_ = new CSQLHeSoQuyDoi();
                CSQLTonKhoCT tkct = new CSQLTonKhoCT();
                //CSQLTonKho tk = new CSQLTonKho();
                //DataTable tonkho = tk.LayMaSP_TenSP();
                //if (tonkho != null && tonkho.Rows.Count > 0)
                CSQLNhaThuoc nt_ = new CSQLNhaThuoc();
                int Nhomloai = nt_.LayNhomLoaiNhaThuoc();
                if (Nhomloai == 1)
                {
                    dtb = tkct.LayDate_SLTon_SLCoTheXuat_TheoLo(spid, khoid, lot, nsxid);
                }
                else
                {
                    dtb = tkct.LayDate_SLTon_SLCoTheXuat_TheoLo_NT(spid, khoid, lot, nsxid);
                }
                decimal hsqd = (decimal)hsqd_.TinhTyLeHSQD(spid, cboDVT.SelectedValue.ToString());
                dtHanDung.Value = DateTime.Parse(dtb.Rows[0][0].ToString());
                slton = String.Format("{0:0,0.00}", Math.Round(decimal.Parse(dtb.Rows[0][1].ToString()) * hsqd));
                radLabel1.Text = string.Concat(slton, " ", cboDVT.Text);
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }
        #endregion

        private void btnChuyenKhoDong_Click(object sender, EventArgs e)
        {
            _frmMain.BangChuyenKho_ = null;
            _frmMain.MaChuyenKho_ = "";
            _frmMain.frmChuyenKhoEditisOpen_ = false;
            this.Close();
        }

        private void cboLo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboLo.DataSource != null)
            {
                LayThongTinDate(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboTuKho.SelectedValue.ToString(), cboLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
            }
        }

        private void cboTuKho_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTuKho != null && cboTuKho.SelectedValue != null)
                {
                    LayThongTinDVTKhiKhoIDThayDoi(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboTuKho.SelectedValue.ToString());

                    LayThongTinLenCbxLo(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboTuKho.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                }
                else
                {
                    cboDVT.DataSource = null;
                    cboLo.DataSource = null;
                    cboLo.Text = "";
                    dtHanDung.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        private void cboNSX_SelectedValueChanged(object sender, EventArgs e)
        {
            if (radMultiColumnComboBoxMaSP.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedValue.ToString().Length > 0 && cboNSX.SelectedValue != null && cboNSX.SelectedValue.ToString().Length > 0)
                LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNSX.SelectedValue.ToString());
        }

        private void cboDVT_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboDVT.SelectedValue != null && cboDVT.SelectedIndex != -1 && radMultiColumnComboBoxMaSP.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedIndex != -1 && cboLo.SelectedValue != null && cboLo.SelectedIndex != -1)
            {
                LayThongTinDate(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboTuKho.SelectedValue.ToString(), cboLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());   
            }
        }

        private void frmChuyenKhoEdit_Load(object sender, EventArgs e)
        {
            LayTenSPToAutoCompleCombobox();
            LayDenKhoVaoCombobox();
            //cboNSX.SelectedIndex = -1;
            //cboTuKho.SelectedIndex = -1;

            if (_frmMain.BangChuyenKho_ != null && _frmMain.BangChuyenKho_.Rows.Count > 0)
            {
                CSQLChuyenKhoCT chuyenkhoct_ = new CSQLChuyenKhoCT();
                txtSoPC.Text = _frmMain.BangChuyenKho_.Rows[0]["SoPCK"].ToString();
                dtNgayTao.Value = (DateTime)_frmMain.BangChuyenKho_.Rows[0]["NgayTao"];
                ckDuyetPhieuChuyen.Checked = (bool)_frmMain.BangChuyenKho_.Rows[0]["DaXetDuyet"];
                txtGhiChu.Text = _frmMain.BangChuyenKho_.Rows[0]["GhiChu"].ToString();

                DataTable Bangckchitiet = chuyenkhoct_.LayTTCKCTTheoCKid(_frmMain.MaChuyenKho_);
                if (Bangckchitiet != null && Bangckchitiet.Rows.Count > 0)
                {
                    rgvChuyenKhoCT.CellFormatting += new CellFormattingEventHandler(rgvChuyenKhoCT_CellFormatting);
                    rgvChuyenKhoCT.DataSource = Bangckchitiet;
                }

                if ((bool)_frmMain.BangChuyenKho_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangChuyenKho_.Rows[0]["DaXacNhan"] == false)
                {
                    //rgvChuyenKhoCT.Enabled = false;
                    btnAdd.Enabled = false;
                    btnThem.Enabled = false;
                    //btnLuu.Enabled = false;
                }
                if ((bool)_frmMain.BangChuyenKho_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangChuyenKho_.Rows[0]["DaXacNhan"] == true)
                {
                    //rgvChuyenKhoCT.Enabled = false;
                    btnAdd.Enabled = false;
                    btnThem.Enabled = false;
                    btnLuu.Enabled = false;
                    ckDuyetPhieuChuyen.Enabled = false;
                }
            }
            rgvChuyenKhoCT.CellFormatting += new CellFormattingEventHandler(rgvChuyenKhoCT_CellFormatting);
        }

        void rgvChuyenKhoCT_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "colSTT" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CSQLKho kho_ = new CSQLKho();
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fChuyenKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            txtSL_Leave(sender, e);
            cboDenKho_Leave(sender, e);
            try
            {
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

                if (cboTuKho.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn từ kho!";
                    cboTuKho.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (cboDenKho.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn đến kho!";
                    cboDenKho.Focus();
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

                if (cboLo.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn Lô cho sản phẩm!";
                    cboLo.Focus();
                    return;
                }

                if (cboTuKho.SelectedValue.ToString().CompareTo(cboDenKho.SelectedValue.ToString())==0)
                {
                    statusTB.Text = "Thông báo: Bạn phải chọn kho đến khác kho đi!";
                    cboLo.Focus();
                    return;
                }

                else statusTB.Text = "";

                //Thêm Master
                if (txtSoPC.Text.Length == 0)
                {
                    #region Thêm chuyển kho
                    CSQLChuyenKho ck = new CSQLChuyenKho();
                    ck.SGhiChu = txtGhiChu.Text;
                    ck.DNgayTao = DateTime.Now;
                    ck.SUserTao = CStaticBien.SmaTaiKhoan;
                    ck.DLastUD = DateTime.Now;
                    ck.SUserUD = CStaticBien.SmaTaiKhoan;

                    if (ckDuyetPhieuChuyen.Checked == true)
                    {
                        ck.BDaXetDuyet = true;
                        ck.DNgayXetDuyet = DateTime.Now;
                        ck.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
                    }
                    else
                    {
                        ck.BDaXetDuyet = false;
                        ck.DNgayXetDuyet = DateTime.Parse("1/1/1774");
                        ck.SUserXetDuyet = "00000000-0000-0000-0000-000000000000";
                    }
                    
                    ck.BDaXacNhan = false;
                    ck.DNgayXacNhan = DateTime.Parse("1/1/1774"); ;
                    ck.SUserXacNhan = "00000000-0000-0000-0000-000000000000";

                    ck.BIsXoa = false;
                    ck.DNgayXoa = DateTime.Parse("1/1/1774");
                    ck.SUserXoa = "00000000-0000-0000-0000-000000000000";

                    string kq = ck.Them(ck);
                    if (kq.Length > 0)
                    {
                        txtSoPC.Text = kq;
                        _frmMain.MaChuyenKho_ = ck.LayCKIDTheoSoPCK(txtSoPC.Text);
                        groupBox2.Enabled = true;
                        _frmMain.fChuyenKho.rgvChuyenKho.DataSource = ck.LoadChuyenKhoLenLuoi(_frmMain.IsXemTatCa_);
                        statusTB.Text = "Thêm thành công";
                        if (_frmMain.DSChuyenKhoXacNhanIsOpen == true)
                        {
                            CSQLChuyenKho xlchuyenkho = new CSQLChuyenKho();
                            _frmMain.fChuyenKhoXacNhan.rgvChuyenKho.DataSource = xlchuyenkho.LayDanhSachChuyenKhoXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Thêm chuyển kho thất bại!";
                    }
                    #endregion
                }
                else
                {
                    #region Sửa chuyển kho
                    CSQLChuyenKho ck = new CSQLChuyenKho();
                    ck.SChuyenKhoID= ck.LayCKIDTheoSoPCK(txtSoPC.Text);
                    ck.SSoPCK = txtSoPC.Text;
                    ck.SGhiChu = txtGhiChu.Text;
                    ck.DLastUD = DateTime.Now;
                    ck.SUserUD = CStaticBien.SmaTaiKhoan;

                    if (ckDuyetPhieuChuyen.Checked == true)
                    {
                        ck.BDaXetDuyet = true;
                        ck.DNgayXetDuyet = DateTime.Now;
                        ck.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
                    }
                    else
                    {
                        ck.BDaXetDuyet = false;
                        ck.DNgayXetDuyet = DateTime.Parse("1/1/1774");
                        ck.SUserXetDuyet = "00000000-0000-0000-0000-000000000000";
                    }

                    int kq = ck.Sua(ck);
                    if (kq == 1)
                    {
                        statusTB.Text = "Sửa chuyển kho thành công!";
                        _frmMain.fChuyenKho.rgvChuyenKho.DataSource = ck.LoadChuyenKhoLenLuoi(_frmMain.IsXemTatCa_);
                        if (_frmMain.DSChuyenKhoXacNhanIsOpen == true)
                        {
                            CSQLChuyenKho xlchuyenkho = new CSQLChuyenKho();
                           _frmMain.fChuyenKhoXacNhan.rgvChuyenKho.DataSource = xlchuyenkho.LayDanhSachChuyenKhoXacNhanLenLuoi(true, false);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Sửa chuyển kho thất bại!";
                    }
                    #endregion
                }
                CSQLChuyenKhoCT ckct = new CSQLChuyenKhoCT();
                CSQLChuyenKho ck1 = new CSQLChuyenKho();
                CSQLKho ktkho_ = new CSQLKho();
                #region Sửa Bảng chuyển Kho Chi Tiết
                if (_frmMain.MaChuyenKhoChiTietCanSua_ != null && _frmMain.MaChuyenKhoChiTietCanSua_.CompareTo("") > 0)
                {
                    int kq = ckct.XoaTTChuyenKhoCT(_frmMain.MaChuyenKhoChiTietCanSua_);
                }
                #endregion

                #region Thêm Chuyển Kho CT
                string ckid = ck1.LayCKIDTheoSoPCK(txtSoPC.Text);

                bool KhoDacBiet = (bool)ck1.LayChuyenKhoTheoMa(ckid).Rows[0]["IsKhoDacBiet"];
                if(KhoDacBiet == true)
                {
                    string NhomKhoTu = ckct.LayTTCKCTTheoCKid(ckid).Rows[0]["FrommKhoID"].ToString();
                    string NhomKhoDen = ckct.LayTTCKCTTheoCKid(ckid).Rows[0]["DestinationKhoID"].ToString();

                    bool isKhoDacBietTu = kho_.IsKhoDacBiet(NhomKhoTu);
                    bool isKhoDacBietDen = kho_.IsKhoDacBiet(NhomKhoDen);

                    if (isKhoDacBietTu && !kho_.IsKhoDacBiet(cboTuKho.SelectedValue.ToString()))
                    {
                        statusTB.Text = "Thông báo: Từ Kho chưa chọn đúng Kho Biệt Trữ với phát sinh trước!";
                        cboTuKho.Focus();
                        return;
                    }

                    if (isKhoDacBietDen && !kho_.IsKhoDacBiet(cboDenKho.SelectedValue.ToString()))
                    {
                        statusTB.Text = "Thông báo: Đến Kho chưa chọn đúng Kho Biệt Trữ với phát sinh trước!";
                        cboDenKho.Focus();
                        return;
                    }
                }
                else
                {
                    if (rgvChuyenKhoCT.Rows.Count > 0 && kho_.IsKhoDacBiet(cboTuKho.SelectedValue.ToString()) == true)
                    {
                        statusTB.Text = "Thông báo: Từ Kho của phát sinh trước không chọn Kho Biệt Trữ thì phát sinh này không được chọn Kho Biệt Trữ !";
                        cboTuKho.Focus();
                        return;
                    }
                    else if (rgvChuyenKhoCT.Rows.Count > 0 && kho_.IsKhoDacBiet(cboDenKho.SelectedValue.ToString()) == true)
                    {
                        statusTB.Text = "Thông báo: Đến Kho của phát sinh trước không chọn Kho Biệt Trữ thì phát sinh này không được chọn Kho Biệt Trữ !";
                        cboTuKho.Focus();
                        return;
                    }
                }
                if (ckid != null  && ckid.Length > 0)
                {
                    ckct.SCKid = ckid;
                    ckct.SSPid = radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString();
                    ckct.SNSXID = cboNSX.SelectedValue.ToString();
                    ckct.DecSLChuyen = decimal.Parse(txtSL.Text);
                    ckct.SDVT = cboDVT.SelectedValue.ToString();
                    ckct.STuKho = cboTuKho.SelectedValue.ToString();
                    ckct.SDenKho = cboDenKho.SelectedValue.ToString();
                    ckct.SLot = cboLo.SelectedValue.ToString();
                    ckct.DDate = dtHanDung.Value;
                    
                    string kq1 = ckct.Them(ckct);
                    if (kq1 != null && kq1.Length > 0)
                    {
                        rgvChuyenKhoCT.DataSource = ckct.LayTTCKCTTheoCKid(ckid);
                        _frmMain.fChuyenKho.rgvChuyenKho.DataSource = ck1.LoadChuyenKhoLenLuoi(_frmMain.IsXemTatCa_);
                     
                        radMultiColumnComboBoxMaSP.SelectedIndex = -1;
                        radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                        cboTuKho.SelectedIndex = -1;
                        cboDenKho.SelectedIndex = -1;
                        txtSL.Text = "";
                        radLabel1.Text = "";
                        cboNSX.SelectedIndex = -1;
                        cboDVT.SelectedIndex = -1;
                        cboLo.SelectedValue = -1;
                        dtHanDung.Value = DateTime.Now;
                        radMultiColumnComboBoxMaSP.Focus();
                        statusTB.Text = "Thêm thành công";
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

        private void ckDuyetPhieuChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyetPhieuChuyen.Checked == true)
            {
                ThayDoiTrangThaiControls(false);
            }
            else
            {
                ThayDoiTrangThaiControls(true);
            }
        }

        private void ThayDoiTrangThaiControls(bool trangthai)
        {
            txtGhiChu.Enabled = trangthai;
            txtSL.Enabled = trangthai;
            cboDVT.Enabled = trangthai;
            cboTuKho.Enabled = trangthai;
            cboDenKho.Enabled = trangthai;
            cboNSX.Enabled = trangthai;
            cboLo.Enabled = trangthai;
            radMultiColumnComboBoxMaSP.Enabled = trangthai;
            radMultiColumnComboBoxTenSP.Enabled = trangthai;
            btnDeleteAll.Enabled = trangthai;
            btnAdd.Enabled = trangthai;
            txtImport.Enabled = trangthai;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if(qtc.KiemTraQuyenThem_Sua(_frmMain.fChuyenKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                if ((this._frmMain.MaChuyenKho_ != null && this._frmMain.MaChuyenKho_.CompareTo("") > 0))
                {
                    #region chỉnh sửa
                    CXuLyChuoi xlc = new CXuLyChuoi();
                    CSQLChuyenKho ck = new CSQLChuyenKho();
                    ck.SChuyenKhoID = this._frmMain.MaChuyenKho_;
                    ck.SSoPCK = txtSoPC.Text;
                    ck.SGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
                    ck.DLastUD = DateTime.Now;
                    ck.SUserUD = CStaticBien.SmaTaiKhoan;
                    if (ckDuyetPhieuChuyen.Checked == true)
                    {
                        ck.BDaXetDuyet = true;
                        ck.DNgayXetDuyet = DateTime.Now;
                        ck.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
                    }
                    else
                    {
                        ck.BDaXetDuyet = false;
                        ck.DNgayXetDuyet = DateTime.Parse("1/1/1774");
                        ck.SUserXetDuyet = "00000000-0000-0000-0000-000000000000";
                    }
                    int kq = ck.Sua(ck);
                    if (kq == 1)
                    {
                        _frmMain.fChuyenKho.rgvChuyenKho.DataSource = ck.LoadChuyenKhoLenLuoi(_frmMain.IsXemTatCa_);
                        statusTB.Text = "Sửa chuyển kho thành công!";
                        if (_frmMain.DSChuyenKhoXacNhanIsOpen == true)
                        {
                            CSQLChuyenKho xlchuyenkho = new CSQLChuyenKho();
                            _frmMain.fChuyenKhoXacNhan.rgvChuyenKho.DataSource = xlchuyenkho.LayDanhSachChuyenKhoXacNhanLenLuoi(true, false);
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
                    CXuLyChuoi xlc = new CXuLyChuoi();
                    CSQLChuyenKho ck = new CSQLChuyenKho();
                    ck.SGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
                    ck.DNgayTao = DateTime.Now;
                    ck.SUserTao = CStaticBien.SmaTaiKhoan;
                    ck.DLastUD = DateTime.Now;
                    ck.SUserUD = CStaticBien.SmaTaiKhoan;

                    if (ckDuyetPhieuChuyen.Checked == true)
                    {
                        ck.BDaXetDuyet = true;
                        ck.DNgayXetDuyet = DateTime.Now;
                        ck.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
                    }
                    else
                    {
                        ck.BDaXetDuyet = false;
                        ck.DNgayXetDuyet = DateTime.Parse("1/1/1774");
                        ck.SUserXetDuyet = "00000000-0000-0000-0000-000000000000";
                    }

                    ck.BDaXacNhan = false;
                    ck.DNgayXacNhan = DateTime.Parse("1/1/1774"); ;
                    ck.SUserXacNhan = "00000000-0000-0000-0000-000000000000";

                    ck.BIsXoa = false;
                    ck.DNgayXoa = DateTime.Parse("1/1/1774");
                    ck.SUserXoa = "00000000-0000-0000-0000-000000000000";
                    string maquantrave = ck.Them(ck);
                    if (maquantrave != null)
                    {
                        txtSoPC.Text = maquantrave;
                        _frmMain.MaChuyenKho_ = ck.LayCKIDTheoSoPCK(txtSoPC.Text);
                        _frmMain.fChuyenKho.rgvChuyenKho.DataSource = ck.LoadChuyenKhoLenLuoi(_frmMain.IsXemTatCa_);
                        statusTB.Text = "Thêm chuyển kho thành công.";
                        if (_frmMain.DSChuyenKhoXacNhanIsOpen == true)
                        {
                            CSQLChuyenKho xlchuyenkho = new CSQLChuyenKho();
                            _frmMain.fChuyenKhoXacNhan.rgvChuyenKho.DataSource = xlchuyenkho.LayDanhSachChuyenKhoXacNhanLenLuoi(true, false);
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
        }

        /// <summary>
        /// Xử lý không cho nhập số lượng lớn hơn số lượng tồn kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSL_Leave(object sender, EventArgs e)
        {
            if (txtSL.Text != "")
            {
                if (Convert.ToDecimal(txtSL.Text) > Convert.ToDecimal(slton))
                {
                    statusTB.Text = "Thông báo: Số lượng lớn hơn số lượng tồn!";
                    txtSL.Focus();
                }
                else
                {
                    statusTB.Text = " ";
                }
            }
        }

        private void rgvChuyenKhoCT_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (rgvChuyenKhoCT.CurrentRow.Cells["colCKCTid"].Value == null)
            {
                return;
            }
            else
            {
                _frmMain.MaChuyenKhoChiTietCanSua_ = rgvChuyenKhoCT.CurrentRow.Cells["colCKCTid"].Value.ToString();
                CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                string spid = spnsx.SanPham_NSX_LaySPNSXIDTheoSPID_NSXID(rgvChuyenKhoCT.CurrentRow.Cells["colSPID"].Value.ToString(), rgvChuyenKhoCT.CurrentRow.Cells["colNSXID"].Value.ToString());
                radMultiColumnComboBoxMaSP.SelectedValue = new Guid(spid);
                radMultiColumnComboBoxTenSP.SelectedValue = new Guid(spid);
                cboTuKho.SelectedValue = rgvChuyenKhoCT.CurrentRow.Cells["colFrommKhoID"].Value.ToString();
                cboDenKho.SelectedValue = new Guid(rgvChuyenKhoCT.CurrentRow.Cells["colDestinationKhoID"].Value.ToString());
                txtSL.Text = String.Format("{0:N2}", decimal.Parse(rgvChuyenKhoCT.CurrentRow.Cells["colSLChuyen"].Value.ToString()));
                cboDVT.SelectedValue = rgvChuyenKhoCT.CurrentRow.Cells["colDVTid"].Value.ToString();
                cboLo.SelectedValue = rgvChuyenKhoCT.CurrentRow.Cells["colLot"].Value.ToString();
                dtHanDung.Value = DateTime.Parse(rgvChuyenKhoCT.CurrentRow.Cells["colDate"].Value.ToString());
                txtSL.Focus();
                //LayThongTinDate(rgvChuyenKhoCT.CurrentRow.Cells["colSPID"].Value.ToString(), cboTuKho.SelectedValue.ToString(), cboLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
            }
        }
        /// <summary>
        /// Xử lý chọn tất cả khi Shift + Tab, Focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSL_Enter(object sender, EventArgs e)
        {
            txtSL.SelectAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _frmMain.MaChuyenKhoChiTietCanSua_ = null;
            _frmMain.MaChuyenKho_ = null;
            rgvChuyenKhoCT.DataSource = null;
            txtSoPC.Text = "";
            txtGhiChu.Text = "";
            radMultiColumnComboBoxMaSP.SelectedIndex = -1;
            radMultiColumnComboBoxTenSP.SelectedIndex = -1;
            txtSL.Text = "";
            cboDVT.SelectedIndex = -1;
            cboTuKho.SelectedIndex = -1;
            cboDenKho.SelectedIndex = -1;
            cboLo.SelectedIndex = -1;
            cboNSX.SelectedIndex = -1;
            LayDenKhoVaoCombobox();
            radMultiColumnComboBoxMaSP.Focus();
        }
        /// <summary>
        /// Xử lý không cho cùng chuyển kho cho chính mình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDenKho_Leave(object sender, EventArgs e)
        {
            if (cboDenKho.SelectedValue != null)
            {
                if (cboTuKho.SelectedValue.ToString() == cboDenKho.SelectedValue.ToString())
                {
                    statusTB.Text = "Thông báo: Kho được nhận chuyển không được trùng với kho chuyển!";
                    cboDenKho.Focus();
                }
                else
                {
                    statusTB.Text = " ";
                }
            }
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
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '-')
            {
                MessageBox.Show("Chỉ được nhập số!");
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (txtSL.Text.Length == 0)
                {
                    statusTB.Text = "Bạn phải nhập số lượng chuyển!";
                    txtSL.Focus();
                    SendKeys.Send("{Tab}");
                }
                else
                    cboDenKho.Focus();
            }
        }

        private void cboDenKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboLo.Focus();
            }
        }

        private void cboLo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(_frmMain.fChuyenKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            InChuyenKho(_frmMain.MaChuyenKho_);
        }

        public void InChuyenKho(string ckid)
        {            
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            string TenChiNhanh_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TenChiNhanh"].ToString();
            CSQLChuyenKhoCT ckct_ = new CSQLChuyenKhoCT();
            if (ckid != null && ckid.Length > 0)
            {
                DataTable ChuyenKhoCT_ = ckct_.In_CK_CKCTT(ckid);
                Fr_ChuyenKho check = new Fr_ChuyenKho(ChuyenKhoCT_, TenChiNhanh_);
                check.Show();
            }
        }

        private void rgvChuyenKhoCT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    CSQLChuyenKhoCT dhct = new CSQLChuyenKhoCT();
                    if (dhct.XoaTTChuyenKhoCT(rgvChuyenKhoCT.CurrentRow.Cells["colCKCTID"].Value.ToString()) > 0)
                        rgvChuyenKhoCT.DataSource = dhct.LayTTCKCTTheoCKid(_frmMain.MaChuyenKho_);
                    else
                        statusTB.Text = "Xóa thất bại!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi khi xóa chi tiết chuyển kho", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
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
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fChuyenKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            txtSL_Leave(sender, e);
            cboDenKho_Leave(sender, e);

            if (txtImport.Text.Length > 0)
            {
                CSQLNhapKhoChiTiet nhapkhoct_ = new CSQLNhapKhoChiTiet();
                Fr_DangXuLy.ShowFormCho();
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + txtImport.Text + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");

                conn.Open();

                string strQuery = "SELECT * FROM [Sheet1$]";

                System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);

                System.Data.DataSet ds = new System.Data.DataSet();

                adapter.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    #region Tạo Phiếu Master
                    if (string.IsNullOrEmpty(txtSoPC.Text)) { 
                        CSQLChuyenKho ck = new CSQLChuyenKho();
                        ck.SGhiChu = txtGhiChu.Text;
                        ck.DNgayTao = DateTime.Now;
                        ck.SUserTao = CStaticBien.SmaTaiKhoan;
                        ck.DLastUD = DateTime.Now;
                        ck.SUserUD = CStaticBien.SmaTaiKhoan;

                        if (ckDuyetPhieuChuyen.Checked == true)
                        {
                            ck.BDaXetDuyet = true;
                            ck.DNgayXetDuyet = DateTime.Now;
                            ck.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
                        }
                        else
                        {
                            ck.BDaXetDuyet = false;
                            ck.DNgayXetDuyet = DateTime.Parse("1/1/1774");
                            ck.SUserXetDuyet = "00000000-0000-0000-0000-000000000000";
                        }

                        ck.BDaXacNhan = false;
                        ck.DNgayXacNhan = DateTime.Parse("1/1/1774"); ;
                        ck.SUserXacNhan = "00000000-0000-0000-0000-000000000000";

                        ck.BIsXoa = false;
                        ck.DNgayXoa = DateTime.Parse("1/1/1774");
                        ck.SUserXoa = "00000000-0000-0000-0000-000000000000";

                        string kq = ck.Them(ck);
                        if (kq.Length > 0)
                        {
                            txtSoPC.Text = kq;
                            _frmMain.MaChuyenKho_ = ck.LayCKIDTheoSoPCK(txtSoPC.Text);
                            groupBox2.Enabled = true;
                            _frmMain.fChuyenKho.rgvChuyenKho.DataSource = ck.LoadChuyenKhoLenLuoi(_frmMain.IsXemTatCa_);
                            statusTB.Text = "Thêm thành công";
                            if (_frmMain.DSChuyenKhoXacNhanIsOpen == true)
                            {
                                CSQLChuyenKho xlchuyenkho = new CSQLChuyenKho();
                                _frmMain.fChuyenKhoXacNhan.rgvChuyenKho.DataSource = xlchuyenkho.LayDanhSachChuyenKhoXacNhanLenLuoi(true, false);
                            }
                        }
                        else
                        {
                            statusTB.Text = "Thêm chuyển kho thất bại!";
                        }
                    }
                    #endregion

                    string ketqua = nhapkhoct_.ImportDanhSach(ds.Tables[0], txtSoPC.Text);
                    Fr_DangXuLy.DongFormCho();
                    if (!ketqua.Equals("OK"))
                    {
                        string Title = "";
                        string Message = "";
                        switch (ketqua.Split('-')[0].ToLower())
                        {
                            case "trunglokhacdate":
                                Title = "Trùng lô khác date";
                                Message = "Mã: " + ketqua.Split('-')[1];
                                break;
                            case "soluong":
                                Title = "Số lượng vượt mực tồn kho";
                                Message = "Mã: " + ketqua.Split('-')[1];
                                break;
                            case "khongtontai":
                                Title = "Mã sản phẩm không tồn tại";
                                Message = "Mã: " + ketqua.Split('-')[1];
                                break;
                            case "trunglo":
                                Title = "Trùng kho";
                                Message = "Mã: " + ketqua.Split('-')[1];
                                break;
                            case "multi":
                                Title = "Dulicate";
                                Message = "Mã: " + ketqua.Split('-')[1];
                                break;
                            case "saidvt":
                                Title = "Đơn vị tính không chính xác";
                                Message = "Mã: " + ketqua.Split('-')[1];
                                break;
                            case "saikhotu":
                                Title = "Kho đi không chính xác";
                                Message = "Mã: " + ketqua.Split('-')[1];
                                break;
                            case "saikhoden":
                                Title = "Kho đến không chính xác";
                                Message = "Mã: " + ketqua.Split('-')[1];
                                break;
                            default:
                                Title = "Lỗi không xác định";
                                Message = "Mã: " + ketqua;
                                break;
                        }

                        MessageBox.Show(Message, Title);
                        statusTB.Text = Title + ": " + Message;
                    }
                    else
                    {
                        CSQLChuyenKho ck1 = new CSQLChuyenKho();
                        CSQLChuyenKhoCT ckct = new CSQLChuyenKhoCT();

                        string ckid = ck1.LayCKIDTheoSoPCK(txtSoPC.Text);
                        rgvChuyenKhoCT.DataSource = ckct.LayTTCKCTTheoCKid(ckid);
                        statusTB.Text = "Import file thành công !";
                    }

                    
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            CSQLChuyenKho ck = new CSQLChuyenKho();
            string ckid = ck.LayCKIDTheoSoPCK(txtSoPC.Text);
            CSQLChuyenKhoCT chct = new CSQLChuyenKhoCT();

            string kq = chct.DeleteAll(ckid);

            if (!kq.Equals("OK"))
            {
                MessageBox.Show(kq, "Thông báo");
                return;
            }
            else
            {
                rgvChuyenKhoCT.DataSource = chct.LayTTCKCTTheoCKid(_frmMain.MaChuyenKho_);
            }
        }
    }
}
