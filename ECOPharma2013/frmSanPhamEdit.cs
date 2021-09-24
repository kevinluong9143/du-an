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
using Telerik.WinControls.Data;
using Telerik.WinControls;

namespace ECOPharma2013
{
    public partial class frmSanPhamEdit : Form
    {
        private frmMain _fMain;
        CSQLSanPham LopCSQLSanPham;
        public frmSanPhamEdit(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
            LopCSQLSanPham = new CSQLSanPham();
            DataTable BangDBC = new DataTable();
            BangDBC = LopCSQLSanPham.LoadDSDBCLenCombobox();
            if (BangDBC.Rows.Count > 0)
            {
                cboDBC.DataSource = BangDBC;
                cboDBC.DisplayMember = "TenDBC";
                cboDBC.ValueMember = "DBCID";
                cboDBC.SelectedIndex = -1;
            }

            CSQLNSX lopNSX = new CSQLNSX();
            DataTable bangNSX = lopNSX.LayNSXLenLuoi(false);
            if (bangNSX.Rows.Count > 0)
            {
                cboNSX.DataSource = bangNSX;
                cboNSX.DisplayMember = "TenNSX";
                cboNSX.ValueMember = "NSXID";
                cboNSX.SelectedIndex = -1;
            }

            #region Lấy thông tin phân loại lên combobox: cbophanloai
            CSQLHoatChat lopPhanLoai = new CSQLHoatChat();
            DataTable bangPhanLoai = lopPhanLoai.LayHoatChatLenLuoi(false);
            if (bangPhanLoai.Rows.Count > 0)
            {
                cboPhanLoai.DisplayMember = "TenHC";
                cboPhanLoai.ValueMember = "HCID";
                cboPhanLoai.DataSource = bangPhanLoai;
                cboPhanLoai.SelectedIndex = -1;
            }
            #endregion End Lấy thông tin phân loại lên combobox: cbophanloai

            DataTable BangDVTNhap = new DataTable();
            BangDVTNhap = LopCSQLSanPham.LoadDSDVTLenCombobox();

            DataTable BangDVTXuat = new DataTable();
            BangDVTXuat = LopCSQLSanPham.LoadDSDVTLenCombobox();

            DataTable BangDVTBan = new DataTable();
            BangDVTBan = LopCSQLSanPham.LoadDSDVTLenCombobox();

            DataTable BangDVChuanTon = new DataTable();
            BangDVChuanTon = LopCSQLSanPham.LoadDSDVTLenCombobox();
            if (BangDVTNhap.Rows.Count > 0)
            {
                cboDVNhap.DataSource = BangDVTNhap;
                cboDVNhap.DisplayMember = "TenDVT";
                cboDVNhap.ValueMember = "DVTID";
                cboDVNhap.SelectedIndex = -1;
            }
            if (BangDVTXuat.Rows.Count > 0)
            {
                cboDVXuat.DataSource = BangDVTXuat;
                cboDVXuat.DisplayMember = "TenDVT";
                cboDVXuat.ValueMember = "DVTID";
                cboDVXuat.SelectedIndex = -1;
            }
            if (BangDVTBan.Rows.Count > 0)
            {
                cboDVBan.DataSource = BangDVTBan;
                cboDVBan.DisplayMember = "TenDVT";
                cboDVBan.ValueMember = "DVTID";
                cboDVBan.SelectedIndex = -1;
            }
            if (BangDVChuanTon.Rows.Count > 0)
            {
                cboDVChuanTon.DataSource = BangDVChuanTon;
                cboDVChuanTon.DisplayMember = "TenDVT";
                cboDVChuanTon.ValueMember = "DVTID";
                cboDVChuanTon.SelectedIndex = -1;
            }

            DataTable BangNhomSP = new DataTable();
            BangNhomSP = LopCSQLSanPham.LoadDSNhomSPLenCombobox();
            if (BangNhomSP.Rows.Count > 0)
            {
                cboNhom.DataSource = BangNhomSP;
                cboNhom.DisplayMember = "TenNSP";
                cboNhom.ValueMember = "NSPID";
                cboNhom.SelectedIndex = -1;
            }
        }

        private void frmSanPhamEdit_Load(object sender, EventArgs e)
        {
            _fMain.frmSanPhamEditisOpen_ = true;
            LopCSQLSanPham = new CSQLSanPham();
            CSQLNPP aNPP = new CSQLNPP();
            cbxNPP.DataSource = aNPP.LoadDSNPPLenMComboBox();
            cbxNPP.DisplayMember = "tennpp";
            cbxNPP.ValueMember = "nppid";
            cbxNPP.EditorControl.Columns["nppid"].IsVisible = false;
            cbxNPP.EditorControl.Columns["tennpp"].Width = 455;
            cbxNPP.AutoFilter = true;
            FilterDescriptor descriptorTenNPP = new FilterDescriptor("tennpp", FilterOperator.Contains, null);
            cbxNPP.EditorControl.FilterDescriptors.Add(descriptorTenNPP);
            cbxNPP.DropDownStyle = RadDropDownStyle.DropDown;
            cbxNPP.MultiColumnComboBoxElement.DropDownWidth = 455;
            cbxNPP.MultiColumnComboBoxElement.DropDownHeight = 300;
            cbxNPP.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
            cbxNPP.SelectedIndex = -1;

            if (_fMain.IsSuaSanPham_ == true)
            {
                txtMaSP.Text = _fMain.BangSanPhamCanSua_.Rows[0]["MaSP"].ToString();
                txtMaVach.Text = _fMain.BangSanPhamCanSua_.Rows[0]["MaVach"].ToString();
                txtTenSP.Text = _fMain.BangSanPhamCanSua_.Rows[0]["TenSP"].ToString();
                txtHoatChat.Text = _fMain.BangSanPhamCanSua_.Rows[0]["HoatChat"].ToString();
                cboDBC.SelectedValue = _fMain.BangSanPhamCanSua_.Rows[0]["DBC"].ToString();
                txtHDSD.Text = _fMain.BangSanPhamCanSua_.Rows[0]["HDSD"].ToString();
                cboDVNhap.SelectedValue = _fMain.BangSanPhamCanSua_.Rows[0]["DVNhap"].ToString();
                cboDVXuat.SelectedValue = _fMain.BangSanPhamCanSua_.Rows[0]["DVXuat"].ToString();
                cboDVBan.SelectedValue = _fMain.BangSanPhamCanSua_.Rows[0]["DVBan"].ToString();
                cboNhom.SelectedValue = _fMain.BangSanPhamCanSua_.Rows[0]["NhomID"].ToString();
                cboPhanLoai.SelectedValue = _fMain.BangSanPhamCanSua_.Rows[0]["HCID"].ToString();
                ckKhongDung.Checked = bool.Parse(_fMain.BangSanPhamCanSua_.Rows[0]["KhongSuDung"].ToString());
                txtGiaMuaHT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(_fMain.BangSanPhamCanSua_.Rows[0]["GiaMuaChuaTaxHT"].ToString())));
                txtThueHT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(_fMain.BangSanPhamCanSua_.Rows[0]["TaxHT"].ToString())));
                txtGiaMuaKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(_fMain.BangSanPhamCanSua_.Rows[0]["GiaMuaChuaTAXKyTruoc"].ToString())));
                txtThueKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(_fMain.BangSanPhamCanSua_.Rows[0]["TAXKyTruoc"].ToString())));
                txtGhiChu.Text = _fMain.BangSanPhamCanSua_.Rows[0]["GhiChu"].ToString();
                cboDVChuanTon.SelectedValue = _fMain.BangSanPhamCanSua_.Rows[0]["DVChuan"].ToString();
                txtChietKhauHT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(_fMain.BangSanPhamCanSua_.Rows[0]["PhanTramChietKhauHT"].ToString())));
                txtChietKhauKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(_fMain.BangSanPhamCanSua_.Rows[0]["PhanTramChietKhauKyTruoc"].ToString())));
                //Tính toán giá mua đã chiết khấu HT cho SP
                if (txtChietKhauHT.Text.Length > 0 && txtGiaMuaHT.Text.Length > 0)
                {
                    txtGMDaChietKhauHT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(txtGiaMuaHT.Text) - decimal.Parse(txtGiaMuaHT.Text) * decimal.Parse(txtChietKhauHT.Text)/100));
                    txtGMcoThueHT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(txtGMDaChietKhauHT.Text) + (decimal.Parse(txtGMDaChietKhauHT.Text) * decimal.Parse(txtThueHT.Text) / 100)));
                }
                //Tính toán giá mua đã chiết khấu KT cho sp
                if(txtChietKhauKT.Text.Length > 0 && txtGiaMuaKT.Text.Length > 0)
                {
                    txtGMDaChietKhauKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(txtGiaMuaKT.Text) - decimal.Parse(txtGiaMuaKT.Text) * decimal.Parse(txtChietKhauKT.Text)/100));
                }
                

                //Lấy NSX đã lưu lên cboNSX
                CSQLSanPham_NSX lopsp_nsx = new CSQLSanPham_NSX();
                try
                {
                    cboNSX.SelectedValue = new Guid(lopsp_nsx.SP_NSX_LayNSXMacDinh(_fMain.MaSPCanSua_));
                    if (lopsp_nsx.KiemTraPhatSinh(txtTenSP.Text, cboNSX.SelectedValue.ToString()) > 0)
                    {
                        cboNSX.Enabled = false;
                        txtMaSP.Enabled = false;
                    }
                    else
                    {
                        cboNSX.Enabled = true;
                        txtMaSP.Enabled = true;
                    }
                }
                catch { } 

                
                if (LopCSQLSanPham.KiemTraMaSanPhamTonKho(_fMain.MaSPCanSua_) == false)
                {
                    cboDVChuanTon.Enabled = true;
                }
                else
                    cboDVChuanTon.Enabled = false;
                CSQLDinhGia dg = new CSQLDinhGia();
                rgvDinhGia.DataSource = dg.LayLenLuoiTheoSPID(_fMain.MaSPCanSua_);

                //Lấy thông tin NPP và Lý do
                CSQLLichSuThayDoiGiaMua aLSTDGM = new CSQLLichSuThayDoiGiaMua();
                DataTable dt = aLSTDGM.LayNPPHienTai(new Guid(_fMain.MaSPCanSua_));
                if (dt != null && dt.Rows.Count == 1)
                {
                    string NPPid = dt.Rows[0]["NPPid"].ToString();
                    int index = 0;
                    foreach (DataRow row in ((DataTable)cbxNPP.DataSource).Rows)
                    {
                        if (row["NPPid"].ToString().Equals(NPPid))
                        {
                            cbxNPP.SelectedIndex = index;
                            break;
                        }
                        index++;
                    }
                    txtLyDo.Text = dt.Rows[0]["LyDo"].ToString();
                }
            }
            else
            {
                txtGiaMuaHT.Text = "0";
                txtThueHT.Text = "0";
                txtGiaMuaKT.Text = "0";
                txtThueKT.Text = "0";
                cboNSX.Enabled = true;
                cbxDieuChinhGia.Checked = true;
                cbxDieuChinhGia.Enabled = false;
            }
            txtMaSP.Focus();
        }

        private void LayDuLieuTuForm()
        {
            CXuLyChuoi xlc = new CXuLyChuoi();
            LopCSQLSanPham = new CSQLSanPham();
            LopCSQLSanPham.sMaSP = txtMaSP.Text.Trim();
            LopCSQLSanPham.sMaVach = txtMaVach.Text.Trim();
            LopCSQLSanPham.sTenSP = xlc.TrimTen(txtTenSP.Text);
            if ((cboDBC.SelectedIndex >= 0)&&(cboDBC.Text!=""))
            {
                LopCSQLSanPham.sDBCid = cboDBC.SelectedValue.ToString();
            }
            else
                LopCSQLSanPham.sDBCid = "00000000-0000-0000-0000-000000000000";
            if ((cboDVNhap.SelectedIndex >= 0) && (cboDVNhap.Text!=""))
            {
                LopCSQLSanPham.sDVNhapID = cboDVNhap.SelectedValue.ToString();
            }
            else
                LopCSQLSanPham.sDVNhapID = "00000000-0000-0000-0000-000000000000";

            if ((cboDVXuat.SelectedIndex >= 0) && (cboDVXuat.Text!=""))
            {
                LopCSQLSanPham.sDVXuatID = cboDVXuat.SelectedValue.ToString();
            }
            else
                LopCSQLSanPham.sDVXuatID = "00000000-0000-0000-0000-000000000000";

            if ((cboDVBan.SelectedIndex >= 0) && (cboDVBan.Text!=""))
            {
                LopCSQLSanPham.sDVBanID = cboDVBan.SelectedValue.ToString();
            }
            else
                LopCSQLSanPham.sDVBanID = "00000000-0000-0000-0000-000000000000";

            if ((cboDVChuanTon.SelectedIndex >= 0) && (cboDVChuanTon.Text != ""))
                LopCSQLSanPham.sDVChuanID = cboDVChuanTon.SelectedValue.ToString();
            else
                LopCSQLSanPham.sDVChuanID = "00000000-0000-0000-0000-000000000000";

            LopCSQLSanPham.sHDSD = txtHDSD.Text.Trim();
            //if ((cboNSX.SelectedIndex >= 0) && (cboNSX.Text!=""))
            //{
            //    LopCSQLSanPham.sNSXid = cboNSX.SelectedValue.ToString();
            //}
            //else
            //    LopCSQLSanPham.sNSXid = "";
            if ((cboNhom.SelectedIndex >= 0) && (cboNhom.Text!=""))
            {
                LopCSQLSanPham.sNhomID = cboNhom.SelectedValue.ToString();
            }
            else
                LopCSQLSanPham.sNhomID = "";
            LopCSQLSanPham.dGiaMuaChuaTAXKyTruoc = decimal.Parse(txtGiaMuaKT.Text.Trim());
            LopCSQLSanPham.dTAXKyTruoc = decimal.Parse(txtThueKT.Text.Trim());
            LopCSQLSanPham.dGiaMuaChuaTAXHT = decimal.Parse(txtGiaMuaHT.Text.Trim());
            LopCSQLSanPham.dTAXHT = decimal.Parse(txtThueHT.Text.Trim());
            LopCSQLSanPham.sHoatChat = txtHoatChat.Text.Trim();
            LopCSQLSanPham.sGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
            LopCSQLSanPham.bKhongSuDung = ckKhongDung.Checked;
            LopCSQLSanPham.sUserID = CStaticBien.SmaTaiKhoan;
            LopCSQLSanPham.FChietKhau = decimal.Parse(txtChietKhauHT.Text);
            
            if (_fMain.IsSuaSanPham_ == true)
            {
                LopCSQLSanPham.sSPid = _fMain.MaSPCanSua_;
            }

            if ((cboPhanLoai.SelectedIndex >= 0) && (cboPhanLoai.Text != ""))
                LopCSQLSanPham.SPhanLoai = cboPhanLoai.SelectedValue.ToString();
            else
                LopCSQLSanPham.SPhanLoai = null;
        }

        public bool DuLieuIsNull()
        {
            if (LopCSQLSanPham.sMaSP == "")
            {
                MessageBox.Show("Chưa có Mã Sản Phẩm");
                statusTB.Text = "Chưa có Mã Sản Phẩm";
                txtMaSP.Focus();
                return true;
            }
            else statusTB.Text = "";

            if (LopCSQLSanPham.sTenSP == "")
            {
                MessageBox.Show("Chưa có Tên Sản Phẩm");
                statusTB.Text = "Chưa có Tên Sản Phẩm";
                txtTenSP.Focus();
                return true;
            }
            else statusTB.Text = "";
            if ((cboNhom.SelectedIndex < 0) || (cboNhom.Text == ""))
            {
                MessageBox.Show("Chưa có Nhóm Sản Phẩm");
                statusTB.Text = "Chưa có Nhóm Sản Phẩm";
                cboNhom.Focus();
                return true;
            }
            else statusTB.Text = "";
            if ((cboDVNhap.SelectedIndex < 0) || (cboDVNhap.Text == ""))
            {
                MessageBox.Show("Chưa có Đơn Vị Nhập");
                statusTB.Text = "Chưa có Đơn Vị Nhập";
                cboDVNhap.Focus();
                return true;
            }
            else statusTB.Text = "";
            if ((cboDVXuat.SelectedIndex < 0) || (cboDVXuat.Text == ""))
            {
                MessageBox.Show("Chưa có Đơn Vị Xuất");
                statusTB.Text = "Chưa có Đơn Vị Xuất";
                cboDVXuat.Focus();
                return true;
            }
            else statusTB.Text = "";
            if ((cboDVBan.SelectedIndex < 0) || (cboDVBan.Text == ""))
            {
                MessageBox.Show("Chưa có Đơn Vị Bán");
                statusTB.Text = "Chưa có Đơn Vị Bán";
                cboDVBan.Focus();
                return true;
            }
            else statusTB.Text = "";
            if (cboDVChuanTon.SelectedValue == null || cboDVChuanTon.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn bắt buộc phải chọn đơn vị chuẩn cho sản phẩm!");
                statusTB.Text = "Bạn bắt buộc phải chọn đơn vị chuẩn cho sản phẩm!";
                cboDVChuanTon.Focus();
                return true;
            }
            else statusTB.Text = "";

            if (cboNSX.SelectedValue == null || cboNSX.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn bắt buộc phải chọn nhà sản xuất cho sản phẩm!");
                statusTB.Text = "Bạn bắt buộc phải chọn nhà sản xuất cho sản phẩm!";
                cboNSX.Focus();
                return true;
            }
            else statusTB.Text = "";

            return false;
        }
        bool KT_Trung;
        private void btnSPLuu_Click(object sender, EventArgs e)
        {
            //Phân quyền chức năng
            #region Phân quyền
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_fMain.fSanPham.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            #endregion Phân quyền

            CSQLLichSuThayDoiGiaMua aLSTDGM = new CSQLLichSuThayDoiGiaMua();
            txtMaSP_Leave(sender, e);
            if (KT_Trung == false)
            {
                LayDuLieuTuForm();
                if (DuLieuIsNull())
                {
                    return;
                }
                string SPidMoiTao = "";
                if (_fMain.IsSuaSanPham_ == false) //Thêm sản phẩm
                {
                    #region Thêm sản phẩm
                    if (txtMarkUp.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn bắt buộc phải nhập vào ô MarkUp!");
                        statusTB.Text = "Bạn bắt buộc phải nhập vào ô MarkUp!";
                        txtMarkUp.Focus();
                        return;
                    }
                    else statusTB.Text = "";
                    DataTable BangSPTimDuoc = new DataTable();
                    BangSPTimDuoc = LopCSQLSanPham.KiemTraMaSPTruocKhiThem(LopCSQLSanPham.sMaSP);
                    if (BangSPTimDuoc.Rows.Count > 0)
                    {
                        MessageBox.Show("Lưu KHÔNG thành công. Mã Sản Phẩm này đã tồn tại trong hệ thống !");
                        statusTB.Text = "Lưu KHÔNG thành công. Mã Sản Phẩm này đã tồn tại trong hệ thống !";
                        return;
                    }
                    else statusTB.Text = "";
                    DataTable BangSPTimDuocBangMaVach = new DataTable();
                    BangSPTimDuocBangMaVach = LopCSQLSanPham.KiemTraMaVachTruocKhiThem(LopCSQLSanPham.sMaVach);
                    if (BangSPTimDuocBangMaVach.Rows.Count > 0)
                    {
                        MessageBox.Show("Lưu KHÔNG thành công. Mã Vạch này đã tồn tại trong hệ thống !");
                        statusTB.Text = "Lưu KHÔNG thành công. Mã Vạch này đã tồn tại trong hệ thống !";
                        return;
                    }
                    else statusTB.Text = "";

                    if (txtChietKhauHT.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập vào Chiết khấu, tối thiểu là 0!");
                        statusTB.Text = "Bạn phải nhập vào Chiết khấu, tối thiểu là 0!";
                        txtChietKhauHT.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(cbxNPP.Text))
                    {
                        MessageBox.Show("Bạn phải chọn NPP!");
                        statusTB.Text = "Bạn phải chọn NPP!";
                        cbxNPP.Focus();
                        return;
                    }
                    else statusTB.Text = "";

                    

                    SPidMoiTao = LopCSQLSanPham.LuuSanPham(LopCSQLSanPham);
                    //_fMain.MaSPCanSua_ = SPidMoiTao;
                    #region Thêm Lịch Sử Thay Đổi Giá Mua Theo NPP.
                    aLSTDGM.ThemMoi(new Guid(SPidMoiTao), Convert.ToDecimal(txtGiaMuaHT.Text), Convert.ToDecimal(txtChietKhauHT.Text), Convert.ToDecimal(txtThueHT.Text), new Guid(cbxNPP.SelectedValue.ToString()), txtLyDo.Text, new Guid(CStaticBien.SmaTaiKhoan));
                    GiaMuaHT = Convert.ToDecimal(txtGiaMuaHT.Text);
                    ChietKhauHT = Convert.ToDecimal(txtChietKhauHT.Text);
                    ThueHT = Convert.ToDecimal(txtThueHT.Text);
                    cbxDieuChinhGia.Checked = false;
                    cbxDieuChinhGia.Enabled = true;
                    cbxNPP.SelectedIndex = -1;
                    #endregion

                    _fMain.IsSuaSanPham_ = true;
                    if (SPidMoiTao == "")
                    {
                        MessageBox.Show("Lưu KHÔNG thành công !");
                        statusTB.Text = "Lưu KHÔNG thành công !";
                    }
                    else
                    {
                        _fMain.MaSPCanSua_ = SPidMoiTao;
                        statusTB.Text = "Đã lưu thành công !";
                        if (_fMain.MaSPCanSua_.Length > 0)
                        {
                            DataTable dtb = LopCSQLSanPham.LaySanPhamTheoSPID(_fMain.MaSPCanSua_);
                            try
                            {
                                CSQLDinhGia dg = new CSQLDinhGia();
                                int kqdg = dg.Them(SPidMoiTao, (decimal.Parse(txtMarkUp.Text)), DateTime.Now, CStaticBien.SmaTaiKhoan);
                                if (kqdg == 0)
                                {
                                    statusTB.Text = "Chưa thêm được định giá sản phẩm. Vui lòng kiểm tra lại thông tin đầu vào!";
                                }
                                else
                                {
                                    rgvDinhGia.DataSource = dg.LayLenLuoiTheoSPID(SPidMoiTao);
                                    txtMarkUp.Text = "";
                                }

                                //Thêm NSX vào bảng mapping
                                #region Mapping SP_NSX
                                //Kiểm tra xem sản phẩm và NSX này đã phát sinh chưa nếu phát sinh rồi thì không cho insert/edit vào DB
                                CSQLSanPham_NSX sp_nsx = new CSQLSanPham_NSX();
                                if (sp_nsx.KiemTraTonTai(txtTenSP.Text, cboNSX.SelectedValue.ToString()) > 0)
                                {
                                    MessageBox.Show("Sản phẩm của NSX này đã tồn tại, xin vui lòng chọn NSX khác!");
                                    return;
                                }
                                CSQLSanPham_NSX lopsp_nsx = new CSQLSanPham_NSX();
                                lopsp_nsx.SSPid = SPidMoiTao;
                                lopsp_nsx.SNSXid = cboNSX.SelectedValue.ToString();
                                lopsp_nsx.SMaSP = txtMaSP.Text;
                                lopsp_nsx.SGhiChu = "";
                                lopsp_nsx.DLastUD = DateTime.Now;
                                lopsp_nsx.BMacDinh = true;
                                lopsp_nsx.DNgayTao = DateTime.Now;
                                lopsp_nsx.SUserID = CStaticBien.SmaTaiKhoan;
                                string kqthemsp_nsx = lopsp_nsx.ThemMoiSanPham_NSX(lopsp_nsx);
                                if (kqthemsp_nsx.Length > 0)
                                {
                                    //Thêm thành công
                                }
                                else
                                {
                                    //Thêm thất bại
                                }
                                #endregion 

                                txtGiaMuaKT.Text = String.Format("{0:0,0.0000}", decimal.Parse(dtb.Rows[0]["GiaMuaChuaTaxKyTruoc"].ToString()));
                                txtThueKT.Text = String.Format("{0:0,0.0000}", decimal.Parse(dtb.Rows[0]["TaxKyTruoc"].ToString()));
                                txtChietKhauKT.Text = String.Format("{0:0,0.0000}", decimal.Parse(dtb.Rows[0]["PhanTramChietKhauKyTruoc"].ToString()));
                                //Tính toán giá mua đã chiết khấu HT cho SP
                                if (txtChietKhauHT.Text.Length > 0 && txtGiaMuaHT.Text.Length > 0)
                                {
                                    txtGMDaChietKhauHT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(txtGiaMuaHT.Text) - decimal.Parse(txtGiaMuaHT.Text) * decimal.Parse(txtChietKhauHT.Text) / 100));
                                    txtGMcoThueHT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(txtGMDaChietKhauHT.Text) + (decimal.Parse(txtGMDaChietKhauHT.Text) * decimal.Parse(txtThueHT.Text) / 100)));
                                }
                                //Tính toán giá mua đã chiết khấu KT cho sp
                                if (txtChietKhauKT.Text.Length > 0 && txtGiaMuaKT.Text.Length > 0)
                                {
                                    txtGMDaChietKhauKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(txtGiaMuaKT.Text) - decimal.Parse(txtGiaMuaKT.Text) * decimal.Parse(txtChietKhauKT.Text) / 100));
                                }
                            }
                            catch
                            {
                                txtGiaMuaKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse("0")));
                                txtThueKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse("0")));
                            }
                        }


                    }
                    #endregion                    
                }
                else //sua san pham
                {
                    #region Sửa sản phẩm
                    DataTable BangSPTimDuoc = new DataTable();
                    BangSPTimDuoc = LopCSQLSanPham.KiemTraMaSPTruocKhiSua(LopCSQLSanPham.sMaSP, LopCSQLSanPham.sSPid);
                    if (BangSPTimDuoc != null && BangSPTimDuoc.Rows.Count > 0)
                    {
                        MessageBox.Show("Lưu KHÔNG thàng công ! Trùng mã sản phẩm.");
                        statusTB.Text = "Lưu KHÔNG thàng công ! Trùng mã sản phẩm.";
                        return;
                    }

                    DataTable BangSPTimDuocBangMaVach = new DataTable();
                    BangSPTimDuocBangMaVach = LopCSQLSanPham.KiemTraMaVachTruocKhiSua(LopCSQLSanPham.sMaVach, LopCSQLSanPham.sSPid);
                    if (BangSPTimDuocBangMaVach.Rows.Count > 0)
                    {
                        MessageBox.Show("Lưu KHÔNG thành công. Trùng Mã Vạch!");
                        statusTB.Text = "Lưu KHÔNG thành công. Trùng Mã Vạch!";
                        return;
                    }
                    else statusTB.Text = "";

                    CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                    DataTable dtbhsqd = hsqd.LayHSQDTheoSPID(LopCSQLSanPham.sSPid);
                    if (dtbhsqd != null && dtbhsqd.Rows.Count > 0)
                    {
                        int kqdvnhap = -1, kqdvxuat = -1, kqdvban = -1, kqdvchuan = -1;
                        for (int i = 0; i < dtbhsqd.Rows.Count; i++)
                        {
                            if (dtbhsqd.Rows[i]["TuDVTid"].ToString().CompareTo(cboDVXuat.SelectedValue.ToString()) == 0)
                            {
                                kqdvxuat = i;
                            }
                            if (dtbhsqd.Rows[i]["TuDVTid"].ToString().CompareTo(cboDVNhap.SelectedValue.ToString()) == 0)
                            {
                                kqdvnhap = i;
                            }
                            if (dtbhsqd.Rows[i]["TuDVTid"].ToString().CompareTo(cboDVBan.SelectedValue.ToString()) == 0)
                            {
                                kqdvban = i;
                            }
                            if (dtbhsqd.Rows[i]["TuDVTid"].ToString().CompareTo(cboDVChuanTon.SelectedValue.ToString()) == 0)
                            {
                                kqdvchuan = i;
                            }
                        }
                        if (kqdvnhap == -1)
                        {
                            MessageBox.Show("Đơn vị nhập không tồn tại trong bảng hệ số qui đổi!");
                            statusTB.Text = "Đơn vị nhập không tồn tại trong bảng hệ số qui đổi!";
                            return;
                        }
                        else statusTB.Text = "";
                        if (kqdvxuat == -1)
                        {
                            MessageBox.Show("Đơn vị xuất không tồn tại trong bảng hệ số qui đổi!");
                            statusTB.Text = "Đơn vị xuất không tồn tại trong bảng hệ số qui đổi!";
                            return;
                        }
                        else statusTB.Text = "";
                        if (kqdvban == -1)
                        {
                            MessageBox.Show("Đơn vị bán không tồn tại trong bảng hệ số qui đổi!");
                            statusTB.Text = "Đơn vị bán không tồn tại trong bảng hệ số qui đổi!";
                            return;
                        }
                        else statusTB.Text = "";
                        if (kqdvchuan == -1)
                        {
                            MessageBox.Show("Đơn vị chuẩn không tồn tại trong bảng hệ số qui đổi!");
                            statusTB.Text = "Đơn vị chuẩn không tồn tại trong bảng hệ số qui đổi!";
                            return;
                        }
                        else statusTB.Text = ""; 
                    }

                    if (cbxDieuChinhGia.Checked && string.IsNullOrEmpty(cbxNPP.Text))
                    {
                        MessageBox.Show("Bạn phải chọn NPP!");
                        statusTB.Text = "Bạn phải chọn NPP!";
                        cbxNPP.Focus();
                        return;
                    }

                    if (cbxDieuChinhGia.Checked && string.IsNullOrEmpty(txtLyDo.Text))
                    {
                        MessageBox.Show("Bạn phải nhập lý do thay đổi giá!");
                        statusTB.Text = "Bạn phải nhập lý do thay đổi giá!";
                        txtLyDo.Focus();
                        return;
                    }

                    //goi ham để update
                    string KQSua = LopCSQLSanPham.SuaSanPham(LopCSQLSanPham);

                    if (cbxDieuChinhGia.Checked)
                    {
                        DataTable dtOLD = aLSTDGM.LayThongTinMoiNhatTheoSPid(new Guid(LopCSQLSanPham.sSPid));
                        if (dtOLD == null || dtOLD.Rows.Count==0)
                        {
                            aLSTDGM.ThemMoi(new Guid(LopCSQLSanPham.sSPid), Convert.ToDecimal(txtGiaMuaHT.Text), Convert.ToDecimal(txtChietKhauHT.Text), Convert.ToDecimal(txtThueHT.Text), new Guid(cbxNPP.SelectedValue.ToString()), txtLyDo.Text, new Guid(CStaticBien.SmaTaiKhoan));
                            GiaMuaHT = Convert.ToDecimal(txtGiaMuaHT.Text);
                            ChietKhauHT = Convert.ToDecimal(txtChietKhauHT.Text);
                            ThueHT = Convert.ToDecimal(txtThueHT.Text);
                        }
                        else
                        {
                            decimal GiaMuaOLD = Convert.ToDecimal(dtOLD.Rows[0]["GiaMua"].ToString());
                            decimal ChietKhauOLD = Convert.ToDecimal(dtOLD.Rows[0]["ChietKhau"].ToString());
                            decimal TaxOLD = Convert.ToDecimal(dtOLD.Rows[0]["Tax"].ToString());
                            Guid NPPOLD = new Guid(dtOLD.Rows[0]["NPPid"].ToString());

                            decimal GiaMuaNew = Convert.ToDecimal(txtGiaMuaHT.Text);
                            decimal ChietKhauNew = Convert.ToDecimal(txtChietKhauHT.Text);
                            decimal TaxNew = Convert.ToDecimal(txtThueHT.Text);
                            Guid NPPNew = new Guid(cbxNPP.SelectedValue.ToString());

                            if (GiaMuaNew != GiaMuaOLD || ChietKhauOLD != ChietKhauNew || TaxNew != TaxOLD || NPPNew != NPPOLD)
                            {
                                aLSTDGM.ThemMoi(new Guid(LopCSQLSanPham.sSPid), Convert.ToDecimal(txtGiaMuaHT.Text), Convert.ToDecimal(txtChietKhauHT.Text), Convert.ToDecimal(txtThueHT.Text), new Guid(cbxNPP.SelectedValue.ToString()), txtLyDo.Text, new Guid(CStaticBien.SmaTaiKhoan));
                                GiaMuaHT = Convert.ToDecimal(txtGiaMuaHT.Text);
                                ChietKhauHT = Convert.ToDecimal(txtChietKhauHT.Text);
                                ThueHT = Convert.ToDecimal(txtThueHT.Text);
                            }
                        }

                        cbxDieuChinhGia.Checked = false;
                        txtGiaMuaHT.Enabled = txtChietKhauHT.Enabled = txtThueHT.Enabled = cbxNPP.Enabled = txtLyDo.Enabled = false;
                        cbxNPP.SelectedIndex = -1;
                        txtLyDo.Text = "";
                    }

                    if (KQSua == "")
                    {
                        statusTB.Text = "Đã lưu thành công !";
                        if (LopCSQLSanPham.sSPid.Length > 0)
                        {
                            DataTable dtb = LopCSQLSanPham.LaySanPhamTheoSPID(LopCSQLSanPham.sSPid);
                            try
                            {
                                CSQLSanPham_NSX lopsp_nsx = new CSQLSanPham_NSX();
                                lopsp_nsx.SMaSPNSX = lopsp_nsx.LaySanPham_NSXTheoSPid(_fMain.MaSPCanSua_).Rows[0]["SPNSXID"].ToString();
                                lopsp_nsx.SSPid = _fMain.MaSPCanSua_;
                                lopsp_nsx.SNSXid = cboNSX.SelectedValue.ToString();
                                lopsp_nsx.SMaSP = txtMaSP.Text;
                                lopsp_nsx.SGhiChu = "";
                                lopsp_nsx.DLastUD = DateTime.Now;
                                lopsp_nsx.BMacDinh = true;
                                //if (ckKhongDung.Checked == true)
                                //    lopsp_nsx.BKhongSuDung = true;
                                //else
                                //    lopsp_nsx.BKhongSuDung = false;
                                lopsp_nsx.DNgayTao = DateTime.Now;
                                lopsp_nsx.SUserID = CStaticBien.SmaTaiKhoan;
                                int kqthemsp_nsx = lopsp_nsx.SuaThongTinSanPham_NSX(lopsp_nsx);
                                if (kqthemsp_nsx > 0)
                                {
                                    //label36.Text = "SO"; Sửa thành công
                                }
                                else
                                {
                                    //label36.Text = "SF"; Sửa thất bại
                                }

                                txtGiaMuaKT.Text = String.Format("{0:0,0.0000}", decimal.Parse(dtb.Rows[0]["GiaMuaChuaTaxKyTruoc"].ToString()));
                                txtThueKT.Text = String.Format("{0:0,0.0000}", decimal.Parse(dtb.Rows[0]["TaxKyTruoc"].ToString()));
                                txtChietKhauKT.Text = String.Format("{0:0,0.0000}", decimal.Parse(dtb.Rows[0]["PhanTramChietKhauKyTruoc"].ToString()));
                                //Tính toán giá mua đã chiết khấu HT cho SP
                                if (txtChietKhauHT.Text.Length > 0 && txtGiaMuaHT.Text.Length > 0)
                                {
                                    txtGMDaChietKhauHT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(txtGiaMuaHT.Text) - decimal.Parse(txtGiaMuaHT.Text) * decimal.Parse(txtChietKhauHT.Text) / 100));
                                    txtGMcoThueHT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(txtGMDaChietKhauHT.Text) + (decimal.Parse(txtGMDaChietKhauHT.Text) * decimal.Parse(txtThueHT.Text) / 100)));
                                }
                                //Tính toán giá mua đã chiết khấu KT cho sp
                                if (txtChietKhauKT.Text.Length > 0 && txtGiaMuaKT.Text.Length > 0)
                                {
                                    txtGMDaChietKhauKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse(txtGiaMuaKT.Text) - decimal.Parse(txtGiaMuaKT.Text) * decimal.Parse(txtChietKhauKT.Text) / 100));
                                }
                                CSQLDinhGia dg = new CSQLDinhGia();
                                rgvDinhGia.DataSource = dg.LayLenLuoiTheoSPID(LopCSQLSanPham.sSPid);
                            }
                            catch
                            {
                                txtGiaMuaKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse("0")));
                                txtThueKT.Text = String.Format("{0:0,0.0000}", (decimal.Parse("0")));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lưu KHÔNG thành công !");
                        statusTB.Text = "Lưu KHÔNG thành công !";
                        MessageBox.Show(KQSua);
                    }
                    #endregion

                    //Sửa thông tin định giá
                    if (rgvDinhGia.RowCount > 0)
                    {
                        for (int i = 0; i < rgvDinhGia.RowCount; i++)
                        {
                            if (rgvDinhGia.Rows[i].Cells["colMarkup"].Value != null && rgvDinhGia.Rows[i].Cells["colMarkup"].Value.ToString().CompareTo("") > 0)
                            {
                                CSQLDinhGia dg = new CSQLDinhGia();
                                int kq = dg.Sua(rgvDinhGia.Rows[i].Cells["colDGID"].Value.ToString(), decimal.Parse(rgvDinhGia.Rows[i].Cells["colMarkup"].Value.ToString()), CStaticBien.SmaTaiKhoan);
                                if (kq > 0)
                                {
                                    statusTB.Text = "Sửa định giá thành công!";
                                }
                            }
                        }
                    }
                }
                
                txtTenSP.Focus();
                _fMain.fSanPham.RefreshLuoiDSSanPham();
                GridViewRowInfo row = _fMain.fSanPham.rgvSanPham.Rows[_fMain.ChonMaSP_];
                _fMain.fSanPham.rgvSanPham.CurrentRow = row;
            }
        }

        private void btnSPDong_Click(object sender, EventArgs e)
        {
            //string dauvao = "6.25";
            //String.Format("{0:0,0.0000}", decimal.Parse(txtGiaMuaHT.Text.Trim()));
            //decimal t = decimal.Parse("6.45");
            //decimal lamtron = Math.Round(t, 1, MidpointRounding.AwayFromZero);
            //decimal kq = Math.Round(lamtron, 0);
            //MessageBox.Show(lamtron.ToString());
            //MessageBox.Show(kq.ToString());
            
            _fMain.frmSanPhamEditisOpen_ = false;
            _fMain.IsSuaSanPham_ = false;
            this.Close();
        }

        private void btnSPThemMoi_Click(object sender, EventArgs e)
        {
            _fMain.IsSuaSanPham_ = false;
            _fMain.BangSanPhamCanSua_ = null;
            _fMain.MaSPCanSua_ = "";
            txtMaSP.Clear();
            txtMaVach.Clear();
            txtTenSP.Clear();
            txtHoatChat.Clear();
            cboDBC.SelectedIndex = -1;
            txtHDSD.Clear();
            cboDVNhap.SelectedIndex = -1;
            cboDVXuat.SelectedIndex = -1;
            cboDVBan.SelectedIndex = -1;
            cboDVChuanTon.SelectedIndex = -1;
            cboNhom.SelectedIndex = -1;
            ckKhongDung.Checked = false;
            txtChietKhauHT.Text = "0";
            txtChietKhauKT.Text = "0";
            txtGMDaChietKhauHT.Text = "0";
            txtGMDaChietKhauKT.Text = "0";
            txtGiaMuaHT.Text = "0";
            txtThueHT.Text = "0";
            txtGiaMuaKT.Text = "0";
            txtThueKT.Text = "0";
            rgvDinhGia.DataSource = null;
            txtGhiChu.Clear();
            txtMaSP.Focus();
            cboDVChuanTon.Enabled = true;
            cboNSX.SelectedIndex = -1;
            cboNSX.Enabled = true;
        }

        private void txtGiaMuaHT_Leave(object sender, EventArgs e)
        {
            if (txtGiaMuaHT.Text.Trim() == "")
            {
                txtGiaMuaHT.Text = "0";
                return;
            }

            decimal KieuSo;
            bool isNum = decimal.TryParse(txtGiaMuaHT.Text.Trim(), out KieuSo);

            if (!isNum)
            {
                MessageBox.Show("Giá mua phải là giá trị số !");
                txtGiaMuaHT.Focus();
                return;
            }

            txtGiaMuaHT.Text = String.Format("{0:0,0.0000}", decimal.Parse(txtGiaMuaHT.Text.Trim()));

        }

        private void txtThueHT_Leave(object sender, EventArgs e)
        {
            if (txtThueHT.Text.Trim() == "")
            {
                txtThueHT.Text = "0";
                return;
            }

            decimal KieuSo;
            bool isNum = decimal.TryParse(txtThueHT.Text.Trim(), out KieuSo);

            if (!isNum)
            {
                MessageBox.Show("Thuế phải là giá trị số !");
                txtThueHT.Focus();
                return;
            }

            txtThueHT.Text = String.Format("{0:0,0.0000}", decimal.Parse(txtThueHT.Text.Trim()));
        }

        private void txtGiaMuaHT_Enter(object sender, EventArgs e)
        {
            if (txtGiaMuaHT.Text.Trim() == "0")
            {
                txtGiaMuaHT.Clear();
            }
            if (txtGiaMuaHT.Text.Trim() != "")
            {
                txtGiaMuaHT.Text = decimal.Parse(txtGiaMuaHT.Text.Trim()).ToString();
            }
        }

        private void txtThueHT_Enter(object sender, EventArgs e)
        {
            if (txtThueHT.Text.Trim() == "0")
            {
                txtThueHT.Clear();
            }
        }

        private void txtGiaMuaHT_TextChanged(object sender, EventArgs e)
        {
            TinhGia();
        }

        

        private void btnThietLapHeSoQuiDoi_Click(object sender, EventArgs e)
        {
            if (_fMain.MaSPCanSua_ != null && _fMain.MaSPCanSua_.Length > 0)
            {
                if (_fMain.frmHeSoQuiDoiEditisOpen_ == true)
                {
                    _fMain.fHeSoQuiDoiEdit_.Select();
                }
                else
                {
                    _fMain.IsSuaHeSoQuiDoi = true;
                    _fMain.frmHeSoQuiDoiEditisOpen_ = true;
                    //CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                    //_fMain.MaHeSoQuyDoiCanSua_ = hsqd.Lay1HSQDTheoSPID(_fMain.MaSPCanSua_);
                    _fMain.fHeSoQuiDoiEdit_ = new frmHeSoQuiDoiEdit(_fMain);
                    _fMain.fHeSoQuiDoiEdit_.LaySPIDTuFormKhac(_fMain.MaSPCanSua_,sender,e);
                    _fMain.fHeSoQuiDoiEdit_.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Bạn phải lưu sản phẩm trước mới có thiết lập hệ số quy đổi");
                statusTB.Text = "Bạn phải lưu sản phẩm trước mới có thiết lập hệ số quy đổi";
            }
        }

        private void txtMarkUp_Leave(object sender, EventArgs e)
        {

        }

        private void rgvDinhGia_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
            if (rgvDinhGia.CurrentCell.ColumnInfo.Name.CompareTo("colMarkup") == 0)
            {
                if (rgvDinhGia.CurrentRow.Cells["colMarkup"].Value != null && rgvDinhGia.CurrentRow.Cells["colMarkup"].Value.ToString().CompareTo("") > 0)
                {
                    CSQLDinhGia dg = new CSQLDinhGia();
                    int kq = dg.Sua(rgvDinhGia.CurrentRow.Cells["colDGID"].Value.ToString(), decimal.Parse(rgvDinhGia.CurrentRow.Cells["colMarkup"].Value.ToString()), CStaticBien.SmaTaiKhoan);
                    if (kq > 0)
                    {
                        statusTB.Text = "Sửa thông tin định giá tại nhà thuốc: ['" + rgvDinhGia.CurrentRow.Cells["colTenNT"].Value.ToString() + "'] thành công!";
                        rgvDinhGia.CurrentRow.Cells["colGiaBan"].Value = decimal.Parse(txtGMcoThueHT.Text) + (decimal.Parse(txtGMcoThueHT.Text) * decimal.Parse(rgvDinhGia.CurrentRow.Cells["colMarkup"].Value.ToString()) / 100);
                    }
                }
            }
        }

        private void frmSanPhamEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSPDong_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                btnSPThemMoi_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.L)
            {
                btnSPLuu_Click(sender, e);
            }
        }

        private void btnLSGiaMua_Click(object sender, EventArgs e)
        {
            frmLichSuGiaMuaBan flichsugiamua = new frmLichSuGiaMuaBan(_fMain);
            flichsugiamua.ShowDialog();
        }

        string MaSPidNull = "00000000-0000-0000-0000-000000000000";
        private void txtMaSP_Leave(object sender, EventArgs e)
        {
            CSQLSanPham sp_ = new CSQLSanPham();
            txtMaSP.Text = txtMaSP.Text.ToUpper();
            if (txtMaSP.Text != "")
            {
                if (this._fMain.MaSPCanSua_ != null && this._fMain.MaSPCanSua_.CompareTo("") > 0)
                {
                    if (sp_.KiemTraTrungMaSP(txtMaSP.Text, _fMain.MaSPCanSua_) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Sản Phẩm đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtMaSP.Focus();
                    }
                    else
                    {
                        KT_Trung = false;
                    }
                }
                else
                {
                    if (sp_.KiemTraTrungMaSP(txtMaSP.Text, MaSPidNull) > 0)
                    {
                        KT_Trung = true;
                        MessageBox.Show("Mã Sản Phẩm đã tồn tại! Vui lòng Kiểm tra lại.");
                        txtMaSP.Focus();
                    }
                    else
                    {
                        KT_Trung = false;
                    }
                }
            }
        }

        decimal TinhGiaMua_CK_Thue(decimal giaMua = 0, decimal phanTramChietKhau = 0, decimal phanTramThue = 0)
        {
            try
            {
                decimal ketqua = giaMua - (giaMua * phanTramChietKhau / 100) + ((giaMua - (giaMua * phanTramChietKhau / 100)) * phanTramThue / 100);
                return ketqua;
            }
            catch 
            {
                //Tới đây là có lỗi
                return 0;
            }

        }

        decimal TinhGiaMua_CK(decimal giaMua = 0, decimal ck = 0)
        {
            try
            {
                decimal ketqua = giaMua - (giaMua * ck / 100);
                return ketqua;
            }
            catch
            {
                //Tới đây là có lỗi
                return 0;
            }
        }

        private void TinhGia()
        {
            try
            {
                decimal giaMua = decimal.Parse(txtGiaMuaHT.Text);
                decimal chietKhau = decimal.Parse(txtChietKhauHT.Text);
                decimal thue = decimal.Parse(txtThueHT.Text);
                txtGMDaChietKhauHT.Text = string.Format("{0:N2}", TinhGiaMua_CK(giaMua, chietKhau));
                txtGMcoThueHT.Text = string.Format("{0:N2}", TinhGiaMua_CK_Thue(giaMua, chietKhau, thue));
            }
            catch
            {
                txtGMcoThueHT.Text = "0";
            }
            try
            {
                for (int i = 0; i < rgvDinhGia.RowCount; i++)
                {
                    rgvDinhGia.Rows[i].Cells["colGiaBan"].Value = decimal.Parse(txtGMcoThueHT.Text) + (decimal.Parse(txtGMcoThueHT.Text) * decimal.Parse(rgvDinhGia.Rows[i].Cells["colMarkup"].Value.ToString()) / 100);
                }
            }
            catch
            {

            }
        }

        private void radSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void txtChietKhauHT_TextChanged(object sender, EventArgs e)
        {
            TinhGia();
        }

        private void txtThueHT_TextChanged(object sender, EventArgs e)
        {
            TinhGia();
        }

        private void txtMarkUp_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if(rgvDinhGia.RowCount>0)
                {
                    for (int i = 0; i < rgvDinhGia.RowCount; i++)
                    {
                        rgvDinhGia.Rows[i].Cells["colMarkup"].Value = decimal.Parse(txtMarkUp.Text);
                        rgvDinhGia.Rows[i].Cells["colGiaBan"].Value = decimal.Parse(txtGMcoThueHT.Text) + (decimal.Parse(txtGMcoThueHT.Text) * decimal.Parse(rgvDinhGia.Rows[i].Cells["colMarkup"].Value.ToString()) / 100);
                    }
                }
            }
            catch { }
        }

        private void btnLuuMarkup_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgvDinhGia.RowCount > 0)
                {
                    for (int i = 0; i < rgvDinhGia.RowCount; i++)
                    {
                        if (rgvDinhGia.Rows[i].Cells["colMarkup"].Value != null && rgvDinhGia.Rows[i].Cells["colMarkup"].Value.ToString().CompareTo("") > 0)
                        {
                            CSQLDinhGia dg = new CSQLDinhGia();
                            int kq = dg.Sua(rgvDinhGia.Rows[i].Cells["colDGID"].Value.ToString(), decimal.Parse(rgvDinhGia.CurrentRow.Cells["colMarkup"].Value.ToString()), CStaticBien.SmaTaiKhoan);
                            if (kq > 0)
                            {
                                statusTB.Text = "Sửa định giá thành công!";
                            }
                        }
                    }
                }
            }
            catch { }
        }
        decimal GiaMuaHT;
        decimal ChietKhauHT;
        decimal ThueHT;
        private void cbxDieuChinhGia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDieuChinhGia.Checked)
            {
                GiaMuaHT = Convert.ToDecimal(txtGiaMuaHT.Text);
                ChietKhauHT = Convert.ToDecimal(txtChietKhauHT.Text);
                ThueHT = Convert.ToDecimal(txtThueHT.Text);

                txtGiaMuaHT.Enabled = txtChietKhauHT.Enabled = txtThueHT.Enabled = cbxNPP.Enabled = txtLyDo.Enabled = true;
            }
            else
            {
                txtGiaMuaHT.Text = String.Format("{0:0,0.0000}", GiaMuaHT);
                txtChietKhauHT.Text = String.Format("{0:0,0.0000}", ChietKhauHT);
                txtThueHT.Text = String.Format("{0:0,0.0000}", ThueHT);

                txtGiaMuaHT.Enabled = txtChietKhauHT.Enabled = txtThueHT.Enabled = cbxNPP.Enabled = txtLyDo.Enabled = false;
                cbxNPP.SelectedIndex = -1;
                txtLyDo.Text = "";
            }
        }
    }
}
