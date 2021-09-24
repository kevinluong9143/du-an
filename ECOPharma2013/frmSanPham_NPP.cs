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
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace ECOPharma2013
{
    public partial class frmSanPham_NPP : Form
    {
        frmMain _frmMain;
        public frmSanPham_NPP()
        {
            InitializeComponent();
        }
        public frmSanPham_NPP(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmSanPham_NPP_Load(object sender, EventArgs e)
        {
            CSQLSanPham_NPP sanpham_npp = new CSQLSanPham_NPP();
            rgvSP_NPP.DataSource = sanpham_npp.LayDanhSachSanPham_NPPLenLuoi(_frmMain.IsXemTatCa_);
            LaySanPhamVaoCombobox();
            LayNSXCombobox();
            LayNPPCombobox();
        }

        void LaySanPhamVaoCombobox()
        {
            CSQLSanPham_NSX sp_nsx = new CSQLSanPham_NSX();
            ((GridViewMultiComboBoxColumn)rgvSP_NPP.Columns["colSPID"]).DataSource = sp_nsx.SP_NSX_LayDS_LenMultiColumnCombobox();
            ((GridViewMultiComboBoxColumn)rgvSP_NPP.Columns["colSPID"]).DisplayMember = "TenSP";
            ((GridViewMultiComboBoxColumn)rgvSP_NPP.Columns["colSPID"]).ValueMember = "SPID";
        }
        void LayNPPCombobox()
        {
            CSQLNPP npp = new CSQLNPP();
            ((GridViewMultiComboBoxColumn)rgvSP_NPP.Columns["colNPPID"]).DataSource = npp.LoadDSNPPLenMComboBox();
            ((GridViewMultiComboBoxColumn)rgvSP_NPP.Columns["colNPPID"]).DisplayMember = "tennpp";
            ((GridViewMultiComboBoxColumn)rgvSP_NPP.Columns["colNPPID"]).ValueMember = "nppid";
        }
        //void LayNSXCombobox(string spid)
        //{
        //    CSQLSanPham_NSX sp_nsx = new CSQLSanPham_NSX();
            
        //    ((GridViewComboBoxColumn)rgvSP_NPP.CurrentRow.Cells[3].Value).DisplayMember = "TenNSX";
        //    ((GridViewComboBoxColumn)rgvSP_NPP.CurrentRow.Cells[3].Value).ValueMember = "NSXID";
        //    ((GridViewComboBoxColumn)rgvSP_NPP.CurrentRow.Cells[3].Value).DataSource = sp_nsx.LayNSXVaoCBX(spid);
        //}
        void LayNSXCombobox()
        {
            CSQLNSX nsx = new CSQLNSX();
            ((GridViewComboBoxColumn)rgvSP_NPP.Columns["colNSXID"]).DataSource = nsx.LayDSNSXLenMultiColumnCombobox();
            ((GridViewComboBoxColumn)rgvSP_NPP.Columns["colNSXID"]).DisplayMember = "TenNSX";
            ((GridViewComboBoxColumn)rgvSP_NPP.Columns["colNSXID"]).ValueMember = "NSXID";
        }

        #region Xử lý MultiComboBox
        RadMultiColumnComboBoxElement SPID;
        private void MasterTemplate_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (rgvSP_NPP.CurrentColumn.Index == 2)
            {
                CSQLSanPham_NSX sp_nsx = new CSQLSanPham_NSX();
                SPID = this.rgvSP_NPP.ActiveEditor as RadMultiColumnComboBoxElement;
                SPID.DisplayMember = "TenSP";
                SPID.ValueMember = "SPID";
                SPID.DataSource = sp_nsx.SP_NSX_LayDS_LenMultiColumnCombobox();
                SPID.SelectedIndex = -1;
                SPID.EditorControl.Columns["SPid"].IsVisible = false;
                SPID.EditorControl.Columns["NSXid"].IsVisible = false;
                SPID.EditorControl.Columns["MaSP"].Width = 45;
                SPID.EditorControl.Columns["TenSP"].Width = 270;
                SPID.EditorControl.Columns["TenNSX"].Width = 200;
                
                SPID.AutoFilter = true;
                FilterDescriptor descriptor = new FilterDescriptor(SPID.DisplayMember, FilterOperator.StartsWith, string.Empty);
                SPID.EditorControl.FilterDescriptors.Add(descriptor);
                SPID.DropDownStyle = RadDropDownStyle.DropDown;
                SPID.AutoSizeDropDownToBestFit = false;
                SPID.DropDownWidth = 550;
                SPID.DropDownHeight = 300;
                LaySanPhamVaoCombobox();
            }
            
            else if (rgvSP_NPP.CurrentColumn.Index == 4)
            {
                CSQLNPP npp = new CSQLNPP();
                RadMultiColumnComboBoxElement NPPid = this.rgvSP_NPP.ActiveEditor as RadMultiColumnComboBoxElement;
                NPPid.DisplayMember = "tennpp";
                NPPid.ValueMember = "nppid";
                NPPid.DataSource = npp.LoadDSNPPLenMComboBox();
                NPPid.SelectedIndex = -1;
                NPPid.EditorControl.Columns["nppid"].IsVisible = false;
                NPPid.EditorControl.Columns["tennpp"].Width = 300;
                NPPid.AutoFilter = true;
                FilterDescriptor descriptor1 = new FilterDescriptor(NPPid.DisplayMember, FilterOperator.Contains, string.Empty);
                NPPid.EditorControl.FilterDescriptors.Add(descriptor1);
                NPPid.DropDownStyle = RadDropDownStyle.DropDown;
                NPPid.AutoSizeDropDownToBestFit = false;
                NPPid.DropDownWidth = 300;
                NPPid.DropDownHeight = 300;
                LayNPPCombobox();
            } 
        }
        #endregion

        CSQLSanPham_NPP sanpham_npp = new CSQLSanPham_NPP();
        public void addnewrow()
        {
            sanpham_npp.SSPid = rgvSP_NPP.CurrentRow.Cells[2].Value.ToString();
            sanpham_npp.SNSXid = rgvSP_NPP.CurrentRow.Cells[3].Value.ToString();
            sanpham_npp.SNPPid = rgvSP_NPP.CurrentRow.Cells[4].Value.ToString();
            if (rgvSP_NPP.CurrentRow.Cells[5].Value == null)
            {
                rgvSP_NPP.CurrentRow.Cells[5].Value = "";
                sanpham_npp.SGhiChu1 = rgvSP_NPP.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                sanpham_npp.SGhiChu1 = rgvSP_NPP.CurrentRow.Cells[5].Value.ToString();
            }
            if (rgvSP_NPP.CurrentRow.Cells[6].Value == null)
            {
                rgvSP_NPP.CurrentRow.Cells[6].Value = "";
                sanpham_npp.SGhiChu2 = rgvSP_NPP.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                sanpham_npp.SGhiChu2 = rgvSP_NPP.CurrentRow.Cells[6].Value.ToString();
            }
            if (rgvSP_NPP.CurrentRow.Cells[7].Value == null)
            {
                rgvSP_NPP.CurrentRow.Cells[7].Value = "";
                sanpham_npp.SGhiChu3 = rgvSP_NPP.CurrentRow.Cells[7].Value.ToString();
            }
            else
            {
                sanpham_npp.SGhiChu3 = rgvSP_NPP.CurrentRow.Cells[7].Value.ToString();
            }
            sanpham_npp.BMacDinh = (bool)rgvSP_NPP.CurrentRow.Cells[8].Value;
            sanpham_npp.BKhongSuDung = (bool)rgvSP_NPP.CurrentRow.Cells[9].Value;
            sanpham_npp.DLastUD = DateTime.Now;
            sanpham_npp.DNgayTao = DateTime.Now;
            sanpham_npp.SUserID = CStaticBien.SmaTaiKhoan;
            string maquantrave = sanpham_npp.ThemMoiSanPham_NPP(sanpham_npp);
            if (maquantrave != null)
            {
                this._frmMain.MaSP_NPPCanSua_ = maquantrave;
                rgvSP_NPP.DataSource = sanpham_npp.LayDanhSachSanPham_NPPLenLuoi(_frmMain.IsXemTatCa_);
                toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                _frmMain.MaSP_NPPCanSua_ = null;
                LamTuoiLaiTuDau();
            }

        }

        private void LamTuoiLaiTuDau()
        {
            Guid ma = new Guid("00000000-0000-0000-0000-000000000000");
            rgvSP_NPP.CurrentRow.Cells[1].Value = "";
            rgvSP_NPP.CurrentRow.Cells[2].Value = ma;
            rgvSP_NPP.CurrentRow.Cells[3].Value = ma;
            rgvSP_NPP.CurrentRow.Cells[4].Value = ma;
            rgvSP_NPP.CurrentRow.Cells[5].Value = "";
            rgvSP_NPP.CurrentRow.Cells[6].Value = "";
            rgvSP_NPP.CurrentRow.Cells[7].Value = "";
            rgvSP_NPP.CurrentRow.Cells[8].Value = false;
            rgvSP_NPP.CurrentRow.Cells[9].Value = false;
        }
        public void editrow()
        {
            //CQuyenTruyCap qtc = new CQuyenTruyCap();
            //if (qtc.KiemTraQuyenThem_Sua(_frmMain.fSanPham_Kho.Name) == false)
            //{
            //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
            //    return;
            //}
            sanpham_npp.SMaSPNPP = _frmMain.MaSP_NPPCanSua_;
            sanpham_npp.SSPid = rgvSP_NPP.CurrentRow.Cells[2].Value.ToString();
            sanpham_npp.SNSXid = rgvSP_NPP.CurrentRow.Cells[3].Value.ToString();
            sanpham_npp.SNPPid = rgvSP_NPP.CurrentRow.Cells[4].Value.ToString();
            sanpham_npp.SGhiChu1 = rgvSP_NPP.CurrentRow.Cells[5].Value.ToString();
            sanpham_npp.SGhiChu2 = rgvSP_NPP.CurrentRow.Cells[6].Value.ToString();
            sanpham_npp.SGhiChu3 = rgvSP_NPP.CurrentRow.Cells[7].Value.ToString();
            sanpham_npp.BMacDinh = (bool)rgvSP_NPP.CurrentRow.Cells[8].Value;
            sanpham_npp.BKhongSuDung = (bool)rgvSP_NPP.CurrentRow.Cells[9].Value;
            sanpham_npp.DLastUD = DateTime.Now;
            sanpham_npp.SUserID = CStaticBien.SmaTaiKhoan;
            int kq = sanpham_npp.SuaThongTinSanPham_NPP(sanpham_npp);
            if (kq == 1)
            {
                rgvSP_NPP.DataSource = sanpham_npp.LayDanhSachSanPham_NPPLenLuoi(_frmMain.IsXemTatCa_);
                toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
            }
        }

        private void rgvSP_NPP_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            int a = rgvSP_NPP.Rows.Count;
            GridViewRowInfo row = rgvSP_NPP.Rows[a - 1];
            rgvSP_NPP.Rows.Remove(row);
            rgvSP_NPP.CurrentRow.IsSelected = true;
            rgvSP_NPP.CurrentRow.Cells[1].IsSelected = true;
            rgvSP_NPP.CurrentRow.Cells[1].BeginEdit();

            toolStripStatusThongBaoLoi.Text = "Dữ liệu chưa cập nhật. Xin vui lòng nhập lại";
        }

        CSQLSanPham sanpham = new CSQLSanPham();
        CSQLSanPham_NSX sanpham_nsx = new CSQLSanPham_NSX();
        private void rgvSP_NPP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //CQuyenTruyCap qtc = new CQuyenTruyCap();
            //if (qtc.KiemTraQuyenThem_Sua(_frmMain.fSanPham_Kho.Name) == false)
            //{
            //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
            //    return;
            //}
            try
            {
                if (e.KeyChar == 13)
                {
                    //Khi row đang nằm chỗ thêm mới
                    #region
                    if (rgvSP_NPP.CurrentRow.Index == -1)
                    {
                        // Xử lý Mã Sản Phẩm
                        #region
                        if (rgvSP_NPP.CurrentColumn.Index == 1)
                        {
                            string Masp_ = rgvSP_NPP.CurrentRow.Cells[1].Value.ToString();
                            //Kiểm tra sản phẩm có tồn tại hay không
                            if (sanpham.LaySanPhamTheoMaSP(Masp_).Rows.Count > 0)
                            {
                                string spid_ = sanpham.LaySanPhamTheoMaSP(Masp_).Rows[0]["SPID"].ToString();
                                //LayNSXCombobox(spid_);
                                string nsxid_ = sanpham_nsx.SP_NSX_LayNSXMacDinh(spid_);
                                rgvSP_NPP.CurrentRow.Cells[2].Value = spid_;
                                rgvSP_NPP.CurrentRow.Cells[3].Value = nsxid_;
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].BeginEdit();
                            }
                            // Không có trong database thì chọn lại
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "Sản Phẩm này không tồn tại";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[1].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[1].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Tên Sản Phẩm
                        #region
                        else if (rgvSP_NPP.CurrentColumn.Index == 2)
                        {
                            
                            string spid_ = rgvSP_NPP.CurrentRow.Cells[2].Value.ToString();

                            if (rgvSP_NPP.CurrentRow.Cells[2].Value == null)
                            {
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[2].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[2].BeginEdit();

                            }
                            //khi mã sản phẩm chưa chọn mà chọn tên sản phẩm
                            else
                            {
                                string masp_ = SPID.EditorControl.CurrentRow.Cells["MaSP"].Value.ToString();
                                //LayNSXCombobox(spid_);
                                string nsxid_ = SPID.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString();
                                
                                rgvSP_NPP.CurrentRow.Cells[1].Value = masp_;
                                rgvSP_NPP.CurrentRow.Cells[3].Value = nsxid_;
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Nhà Sản Xuất
                        #region
                        else if (rgvSP_NPP.CurrentColumn.Index == 3)
                        {
                            if (rgvSP_NPP.CurrentRow.Cells[3].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho nhập";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[3].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[3].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Nhà Phân Phối
                        #region
                        else if (rgvSP_NPP.CurrentColumn.Index == 4)
                        {
                            if (rgvSP_NPP.CurrentRow.Cells[4].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho xuất.";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[5].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[5].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Ghi Chú 1
                        #region
                        else if (rgvSP_NPP.CurrentColumn.Index == 5)
                        {
                            if (rgvSP_NPP.CurrentRow.Cells[5].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_NPP.CurrentRow.Cells[5].Value = "";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[6].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[6].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[6].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[6].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Ghi Chú 2
                        #region
                        else if (rgvSP_NPP.CurrentColumn.Index == 6)
                        {
                            if (rgvSP_NPP.CurrentRow.Cells[6].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_NPP.CurrentRow.Cells[6].Value = "";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[7].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[7].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[7].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[7].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Ghi Chú 3
                        #region
                        else if (rgvSP_NPP.CurrentColumn.Index == 7)
                        {
                            if (rgvSP_NPP.CurrentRow.Cells[7].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_NPP.CurrentRow.Cells[7].Value = "";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[8].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[8].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[8].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[8].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử Lý Mặc Định
                        #region
                        else
                        {
                            CSQLSanPham_NPP sp_npp = new CSQLSanPham_NPP();
                            CSQLSanPham sp_ = new CSQLSanPham();
                            string spid_ = sp_.LaySanPhamTheoMaSP(rgvSP_NPP.CurrentRow.Cells[1].Value.ToString()).Rows[0]["SPID"].ToString();
                            string mansx_ = rgvSP_NPP.CurrentRow.Cells[3].Value.ToString();
                            string manpp_ = rgvSP_NPP.CurrentRow.Cells[4].Value.ToString();

                            if (rgvSP_NPP.CurrentRow.Cells[8].Value == null)
                            {
                                if (sp_npp.LaySP_NPPTheoSPID_NSXID_NPPID(spid_, mansx_, manpp_, false).Rows.Count > 0)
                                {
                                    toolStripStatusThongBaoLoi.Text = "Sản Phẩm-Nhà Phân Phối đã được tạo. Bạn không thể tạo thêm";
                                    LamTuoiLaiTuDau();
                                    rgvSP_NPP.CurrentRow.Cells[2].IsSelected = true;
                                    rgvSP_NPP.CurrentRow.Cells[2].BeginEdit();
                                    return;
                                }
                                else if (sp_npp.LaySP_NPPTheoSPID_NSXID_NPPID(spid_, mansx_, manpp_, true).Rows.Count > 0)
                                {
                                    toolStripStatusThongBaoLoi.Text = "Sản Phẩm-Nhà Phân Phối đã được chọn làm Mặc Định. Bạn không thể tạo thêm";
                                    LamTuoiLaiTuDau();
                                    rgvSP_NPP.CurrentRow.Cells[2].IsSelected = true;
                                    rgvSP_NPP.CurrentRow.Cells[2].BeginEdit();
                                    return;
                                }
                                else
                                {
                                    rgvSP_NPP.CurrentRow.Cells[8].Value = false;
                                    rgvSP_NPP.CurrentRow.Cells[9].Value = false;
                                    addnewrow();
                                }
                            }
                            else
                            {
                                if (rgvSP_NPP.CurrentRow.Cells[4].Value == null || rgvSP_NPP.CurrentRow.Cells[4].Value.ToString() == "00000000-0000-0000-0000-000000000000")
                                {
                                    toolStripStatusThongBaoLoi.Text = "Không được để trống nhà phân phối khi chọn Mặc Định cho Sản Phẩm-Nhà Phân Phối.";
                                    rgvSP_NPP.CurrentRow.Cells[8].Value = false;

                                    rgvSP_NPP.CurrentRow.IsSelected = true;
                                    rgvSP_NPP.CurrentRow.Cells[4].IsSelected = true;
                                    rgvSP_NPP.CurrentRow.Cells[4].BeginEdit();
                                    return;
                                }
                                else
                                {
                                    if (sp_npp.LaySP_NPPTheoSPID_NSXID(spid_, mansx_, true).Rows.Count > 0)
                                    {
                                        if (sp_npp.LaySP_NPPTheoSPID_NSXID_NPPID(spid_, mansx_, manpp_, true).Rows.Count > 0)
                                        {
                                            toolStripStatusThongBaoLoi.Text = "Sản Phẩm-Nhà Phân Phối đã được chọn làm Mặc Định.";
                                            LamTuoiLaiTuDau();
                                            rgvSP_NPP.CurrentRow.Cells[2].IsSelected = true;
                                            rgvSP_NPP.CurrentRow.Cells[2].BeginEdit();
                                            return;
                                        }
                                        else if (sp_npp.LaySP_NPPTheoSPID_NSXID_NPPID(spid_, mansx_, manpp_, false).Rows.Count > 0)
                                        {
                                            toolStripStatusThongBaoLoi.Text = "Sản Phẩm-Nhà Phân Phối đã được tạo. Bạn không thể tạo thêm";
                                            LamTuoiLaiTuDau();
                                            rgvSP_NPP.CurrentRow.Cells[2].IsSelected = true;
                                            rgvSP_NPP.CurrentRow.Cells[2].BeginEdit();
                                            return;
                                        }
                                        else
                                        {
                                            if ((bool)rgvSP_NPP.CurrentRow.Cells[8].Value == true)
                                            {
                                                if (MessageBox.Show("Sản Phẩm_Nhà Phân Phối này đang có Mặc Định khác. Bạn có muốn thay đổi lại Mặc Định cho Sản Phẩm_Nhà Phân Phối mới tạo này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                                {
                                                    sp_npp.SMaSPNPP = sp_npp.LaySP_NPPTheoSPID_NSXID(spid_, mansx_, true).Rows[0]["SPNPPid"].ToString();
                                                    sp_npp.BMacDinh = false;
                                                    sp_npp.DLastUD = DateTime.Now;
                                                    sp_npp.SUserID = CStaticBien.SmaTaiKhoan;
                                                    sp_npp.SuaMacDinhSP_NPP(sp_npp);
                                                    rgvSP_NPP.CurrentRow.Cells[9].Value = false;
                                                    addnewrow();
                                                    return;
                                                }
                                                else
                                                {
                                                    rgvSP_NPP.CurrentRow.Cells[8].Value = false;
                                                    rgvSP_NPP.CurrentRow.Cells[9].Value = false;
                                                    addnewrow();
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                rgvSP_NPP.CurrentRow.Cells[9].Value = false;
                                                addnewrow();
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (sp_npp.LaySP_NPPTheoSPID_NSXID_NPPID(spid_, mansx_, manpp_, false).Rows.Count > 0)
                                        {
                                            toolStripStatusThongBaoLoi.Text = "Sản Phẩm-Nhà Phân Phối đã được tạo. Bạn không thể tạo thêm";
                                            LamTuoiLaiTuDau();
                                            rgvSP_NPP.CurrentRow.Cells[2].IsSelected = true;
                                            rgvSP_NPP.CurrentRow.Cells[2].BeginEdit();
                                            return;
                                        }
                                        else
                                        {
                                            rgvSP_NPP.CurrentRow.Cells[9].Value = false;
                                            addnewrow();
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion

                    //Khi row đang nằm chỗ chỉnh sửa
                    #region
                    else
                    {
                        CSQLSanPham_NPP sp_npp = new CSQLSanPham_NPP();
                        DataTable dtbsp_kho = sp_npp.LaySanPham_NPPTheoMa(rgvSP_NPP.CurrentRow.Cells[0].Value.ToString());

                        // Xử lý Nhà Sản Xuất
                        #region
                        ////if (rgvSP_NPP.CurrentColumn.Index == 3)
                        ////{
                        ////    //LayNSXCombobox(rgvSP_NPP.CurrentRow.Cells[2].Value.ToString());
                        ////    int xnt = rgvSP_NPP.CurrentRow.Index;
                        ////    if (rgvSP_NPP.CurrentRow.Cells[3].Value == null)
                        ////    {
                        ////        rgvSP_NPP.CurrentRow.IsSelected = true;
                        ////        rgvSP_NPP.CurrentRow.Cells[3].IsSelected = true;
                        ////        rgvSP_NPP.CurrentRow.Cells[3].BeginEdit();
                        ////    }
                        ////    else if (rgvSP_NPP.CurrentRow.Cells[3].Value.ToString() == "")
                        ////    {
                        ////        toolStripStatusThongBaoLoi.Text = "Không được xóa Nhà Sản Xuất.";
                        ////        FocusRows(xnt);
                        ////        return;
                        ////    }
                        ////    else
                        ////    {
                        ////        string maspid_ = rgvSP_NPP.CurrentRow.Cells[2].ToString();
                        ////        string mansx_ = rgvSP_NPP.CurrentRow.Cells[3].ToString();
                        ////        string manpp_ = rgvSP_NPP.CurrentRow.Cells[4].ToString();
                        ////        bool macdinh_ = bool.Parse(rgvSP_NPP.CurrentRow.Cells[8].ToString());

                        ////        if (sp_npp.LaySP_NPPTheoSPID_NSXID_NPPID(maspid_, mansx_, manpp_, macdinh_).Rows.Count > 0)
                        ////        {
                        ////            toolStripStatusThongBaoLoi.Text = "Sản Phẩm-Nhà Phân Phối đã được tạo. Bạn không thể tạo thêm";
                        ////            rgvSP_NPP.CurrentRow.Cells[3].IsSelected = true;
                        ////            rgvSP_NPP.CurrentRow.Cells[3].BeginEdit();
                        ////            return;
                        ////        }
                        ////        else
                        ////        {
                        ////            _frmMain.MaSP_NPPCanSua_ = rgvSP_NPP.CurrentRow.Cells[0].Value.ToString();
                        ////            editrow();
                        ////            return;
                        ////        }
                        ////    }

                        ////}
                        #endregion

                        // Xử lý Nhà Phân Phối
                        #region
                        if (rgvSP_NPP.CurrentColumn.Index == 4)
                        {
                            int xnt = rgvSP_NPP.CurrentRow.Index;
                            if (rgvSP_NPP.CurrentRow.Cells[4].Value == null)
                            {
                                rgvSP_NPP.CurrentRow.IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].IsSelected = true;
                                rgvSP_NPP.CurrentRow.Cells[4].BeginEdit();
                            }
                            else if (rgvSP_NPP.CurrentRow.Cells[4].Value.ToString() == "")
                            {
                                toolStripStatusThongBaoLoi.Text = "Không được xóa Nhà Sản Xuất.";
                                FocusRows(xnt);
                                return;
                            }
                            else
                            {
                                string maspid_ = rgvSP_NPP.CurrentRow.Cells[2].Value.ToString();
                                string mansx_ = rgvSP_NPP.CurrentRow.Cells[3].Value.ToString();
                                string manpp_ = rgvSP_NPP.CurrentRow.Cells[4].Value.ToString();

                                if (sp_npp.LaySP_NPPTheoSPID_NSXID_NPPID(maspid_, mansx_, manpp_, true).Rows.Count > 0 || sp_npp.LaySP_NPPTheoSPID_NSXID_NPPID(maspid_, mansx_, manpp_, false).Rows.Count > 0)
                                {
                                    toolStripStatusThongBaoLoi.Text = "Sản Phẩm đã có Nhà Phân Phối này. Bạn không thể tạo thêm";
                                    rgvSP_NPP.CurrentRow.Cells[4].IsSelected = true;
                                    rgvSP_NPP.CurrentRow.Cells[4].BeginEdit();
                                    return;
                                }
                                else
                                {
                                    _frmMain.MaSP_NPPCanSua_ = rgvSP_NPP.CurrentRow.Cells[0].Value.ToString();
                                    editrow();
                                    return;
                                }
                            }
                        #endregion
                        }
                        // Xử lý Ghi Chú 1
                        #region
                        if (rgvSP_NPP.CurrentColumn.Index == 5)
                        {
                            if (rgvSP_NPP.CurrentRow.Cells[5].Value == null)
                            {
                                rgvSP_NPP.CurrentRow.Cells[5].Value = "";
                            }
                            _frmMain.MaSP_NPPCanSua_ = rgvSP_NPP.CurrentRow.Cells[0].Value.ToString();
                            editrow();
                        #endregion
                        }
                        // Xử lý Ghi Chú 2
                        #region
                        if (rgvSP_NPP.CurrentColumn.Index == 6)
                        {
                            if (rgvSP_NPP.CurrentRow.Cells[6].Value == null)
                            {
                                rgvSP_NPP.CurrentRow.Cells[6].Value = "";
                            }
                            _frmMain.MaSP_NPPCanSua_ = rgvSP_NPP.CurrentRow.Cells[0].Value.ToString();
                            editrow();
                        #endregion
                        }
                        // Xử lý Sửa Ghi Chú 3
                        #region
                        if (rgvSP_NPP.CurrentColumn.Index == 7)
                        {
                            if (rgvSP_NPP.CurrentRow.Cells[7].Value == null)
                            {
                                rgvSP_NPP.CurrentRow.Cells[7].Value = "";
                            }
                            _frmMain.MaSP_KhoCanSua_ = rgvSP_NPP.CurrentRow.Cells[0].Value.ToString();
                            editrow();
                        #endregion
                        }
                        //Xử lý Sửa Mặc Định
                        #region
                        if (rgvSP_NPP.CurrentColumn.Index == 8)
                        {
                            _frmMain.MaSP_NPPCanSua_ = rgvSP_NPP.CurrentRow.Cells[0].Value.ToString();
                            if ((bool)rgvSP_NPP.CurrentRow.Cells[8].Value == true)
                            {
                                if (sp_npp.LaySP_NPPTheoSPID_NSXID(dtbsp_kho.Rows[0]["SPID"].ToString(), dtbsp_kho.Rows[0]["NSXID"].ToString(), true).Rows.Count > 0)
                                {
                                    if (MessageBox.Show("Sản Phẩm_Nhà Phân Phối này đang có Mặc Định khác. Bạn có muốn thay đổi lại Mặc Định cho Sản Phẩm_Nhà Phân Phối mới tạo này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        sp_npp.SMaSPNPP = sp_npp.LaySP_NPPTheoSPID_NSXID(dtbsp_kho.Rows[0]["SPID"].ToString(), dtbsp_kho.Rows[0]["NSXID"].ToString(), true).Rows[0]["SPNPPid"].ToString();
                                        sp_npp.BMacDinh = false;
                                        sp_npp.DLastUD = DateTime.Now;
                                        sp_npp.SUserID = CStaticBien.SmaTaiKhoan;
                                        sp_npp.SuaMacDinhSP_NPP(sp_npp);
                                        rgvSP_NPP.CurrentRow.Cells[9].Value = false;
                                        editrow();
                                        return;
                                    }
                                    else
                                    {
                                        rgvSP_NPP.CurrentRow.Cells[8].Value = false;
                                        return;
                                    }
                                }
                                else
                                {
                                    rgvSP_NPP.CurrentRow.Cells[9].Value = false;
                                    editrow();
                                    return;
                                }
                            }
                            else
                            {
                                if (sp_npp.LaySP_NPPTheoSPID_NSXID_KhacSPNPPid(_frmMain.MaSP_NPPCanSua_, dtbsp_kho.Rows[0]["SPID"].ToString(), dtbsp_kho.Rows[0]["NSXID"].ToString(), true).Rows.Count > 0)
                                {
                                    return;
                                }
                                else
                                {
                                    sp_npp.SMaSPNPP = sp_npp.LaySP_NPPTheoSPID_NSXID_KhacSPNPPid(_frmMain.MaSP_NPPCanSua_, dtbsp_kho.Rows[0]["SPID"].ToString(), dtbsp_kho.Rows[0]["NSXID"].ToString(), false).Rows[0]["SPNPPid"].ToString();
                                    sp_npp.BMacDinh = true;
                                    sp_npp.DLastUD = DateTime.Now;
                                    sp_npp.SUserID = CStaticBien.SmaTaiKhoan;
                                    sp_npp.SuaMacDinhSP_NPP(sp_npp);
                                    rgvSP_NPP.CurrentRow.Cells[9].Value = false;
                                    editrow();
                                    return;
                                }
                            }
                        #endregion
                        }
                        //Xử lý Không Sử Dụng
                        #region
                        if (rgvSP_NPP.CurrentColumn.Index == 9)
                        {
                            _frmMain.MaSP_NPPCanSua_ = rgvSP_NPP.CurrentRow.Cells[0].Value.ToString();
                            if ((bool)rgvSP_NPP.CurrentRow.Cells[9].Value == true)
                            {
                                if (sp_npp.LaySP_NPPTheoSPID_NSXID_NPPID(dtbsp_kho.Rows[0]["SPID"].ToString(), dtbsp_kho.Rows[0]["NSXID"].ToString(), dtbsp_kho.Rows[0]["NPPID"].ToString(), true).Rows.Count > 0)
                                {
                                    rgvSP_NPP.CurrentRow.Cells[8].Value = false;
                                    editrow();

                                    sp_npp.SMaSPNPP = sp_npp.LaySP_NPPTheoSPID_NSXID_KhacSPNPPid(_frmMain.MaSP_NPPCanSua_, dtbsp_kho.Rows[0]["SPID"].ToString(), dtbsp_kho.Rows[0]["NSXID"].ToString(), false).Rows[0]["SPNPPid"].ToString();
                                    sp_npp.BMacDinh = true;
                                    sp_npp.DLastUD = DateTime.Now;
                                    sp_npp.SUserID = CStaticBien.SmaTaiKhoan;
                                    sp_npp.SuaMacDinhSP_NPP(sp_npp);
                                    rgvSP_NPP.DataSource = sanpham_npp.LayDanhSachSanPham_NPPLenLuoi(_frmMain.IsXemTatCa_);
                                    return;
                                }
                                else
                                {
                                    editrow();
                                    return;
                                }
                            }
                            else
                            {
                                editrow();
                                return;
                            }
                        }
                        #endregion
                    }
                    #endregion
                }

            }
            catch { }
        }

        private void FocusRows(int xnt)
        {
            rgvSP_NPP.DataSource = sanpham_npp.LayDanhSachSanPham_NPPLenLuoi(_frmMain.IsXemTatCa_);
            rgvSP_NPP.CurrentRow = rgvSP_NPP.Rows[xnt];
        }
    
    }
}