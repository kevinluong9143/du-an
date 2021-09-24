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
    public partial class frmSanPham_NSX : Form
    {
        frmMain _frmMain;

        public frmSanPham_NSX()
        {
            InitializeComponent();
        }
        public frmSanPham_NSX(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        private void frmSanPham_NSX_Load(object sender, EventArgs e)
        {
            CSQLSanPham_NSX sanpham_nsx = new CSQLSanPham_NSX();
            
            rgvSP_NSX.DataSource = sanpham_nsx.LayDanhSachSanPham_NSXLenLuoi(_frmMain.IsXemTatCa_);
            LaySanPhamVaoCombobox();
            LayNSXCombobox();
        }
        
        void LaySanPhamVaoCombobox()
        {
            CSQLSanPham sp = new CSQLSanPham();
            ((GridViewMultiComboBoxColumn)rgvSP_NSX.Columns["colSPID"]).DataSource = sp.SanPham_LayDSSPLenMultiColumnCombobox();
            ((GridViewMultiComboBoxColumn)rgvSP_NSX.Columns["colSPID"]).DisplayMember = "TenSP";
            ((GridViewMultiComboBoxColumn)rgvSP_NSX.Columns["colSPID"]).ValueMember = "SPID";
        }
        void LayNSXCombobox()
        {
            CSQLNSX nsx = new CSQLNSX();
            ((GridViewMultiComboBoxColumn)rgvSP_NSX.Columns["colNSXID"]).DataSource = nsx.LayDSNSXLenMultiColumnCombobox();
            ((GridViewMultiComboBoxColumn)rgvSP_NSX.Columns["colNSXID"]).DisplayMember = "TenNSX";
            ((GridViewMultiComboBoxColumn)rgvSP_NSX.Columns["colNSXID"]).ValueMember = "NSXID";        
        }

        CSQLSanPham sanpham = new CSQLSanPham();
        CSQLSanPham_NSX sanpham_nsx = new CSQLSanPham_NSX();
        public void editrow()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fSanPham_NSX.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                sanpham_nsx.SMaSPNSX = _frmMain.MaSP_NSXCanSua_;
                sanpham_nsx.SMaSP = rgvSP_NSX.CurrentRow.Cells[1].Value.ToString();
                sanpham_nsx.SSPid = rgvSP_NSX.CurrentRow.Cells[2].Value.ToString();
                sanpham_nsx.SNSXid = rgvSP_NSX.CurrentRow.Cells[3].Value.ToString();
                sanpham_nsx.SGhiChu = rgvSP_NSX.CurrentRow.Cells[4].Value.ToString();
                sanpham_nsx.BKhongSuDung = (bool)rgvSP_NSX.CurrentRow.Cells[5].Value;
                sanpham_nsx.BMacDinh = (bool)rgvSP_NSX.CurrentRow.Cells[6].Value;
                sanpham_nsx.DLastUD = DateTime.Now;
                sanpham_nsx.SUserID = CStaticBien.SmaTaiKhoan;
                int kq = sanpham_nsx.SuaThongTinSanPham_NSX(sanpham_nsx);
                if (kq == 1)
                {
                    rgvSP_NSX.DataSource = sanpham_nsx.LayDanhSachSanPham_NSXLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
                }
            }
            catch { }
        }
        public void addnewrow()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fSanPham_NSX.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                sanpham_nsx.SMaSP = rgvSP_NSX.CurrentRow.Cells[1].Value.ToString();
                sanpham_nsx.SSPid = rgvSP_NSX.CurrentRow.Cells[2].Value.ToString();
                sanpham_nsx.SNSXid = rgvSP_NSX.CurrentRow.Cells[3].Value.ToString();
                sanpham_nsx.SGhiChu = rgvSP_NSX.CurrentRow.Cells[4].Value.ToString();
                sanpham_nsx.BKhongSuDung = (bool)rgvSP_NSX.CurrentRow.Cells[5].Value;
                sanpham_nsx.BMacDinh = (bool)rgvSP_NSX.CurrentRow.Cells[6].Value;
                sanpham_nsx.DLastUD = DateTime.Now;
                sanpham_nsx.DNgayTao = DateTime.Now;
                sanpham_nsx.SUserID = CStaticBien.SmaTaiKhoan;
                string maquantrave = sanpham_nsx.ThemMoiSanPham_NSX(sanpham_nsx);
                if (maquantrave != null)
                {
                    this._frmMain.MaSP_NSXCanSua_ = maquantrave;
                    rgvSP_NSX.DataSource = sanpham_nsx.LayDanhSachSanPham_NSXLenLuoi(_frmMain.IsXemTatCa_);
                    toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                    _frmMain.MaSP_NSXCanSua_ = null;
                }
            }
            catch { }
        }

        private void rgvSP_NSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fSanPham_NSX.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    // thêm mới sản phẩm - nsx
                    #region
                    if (rgvSP_NSX.CurrentRow.Index == -1)
                    {
                        // Thêm Mã Sản Phẩm
                        #region
                        if (rgvSP_NSX.CurrentColumn.Index == 1)
                        {
                            string Masp_ = rgvSP_NSX.CurrentRow.Cells[1].Value.ToString();
                            //Kiểm tra sản phẩm có tồn tại hay không
                            if (sanpham.LaySanPhamTheoMaSP(Masp_).Rows.Count > 0)
                            {
                                string spid_ = sanpham.LaySanPhamTheoMaSP(Masp_).Rows[0]["SPID"].ToString();
                                rgvSP_NSX.CurrentRow.Cells[2].Value = spid_;
                                rgvSP_NSX.CurrentRow.IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[3].IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[3].BeginEdit();
                            }
                            // Không có trong database thì chọn lại
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "Sản Phẩm này không tồn tại";
                                rgvSP_NSX.CurrentRow.IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[1].IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[1].BeginEdit();
                            }
                        }
                        #endregion

                        // Thêm Tên Sản Phẩm
                        #region
                        else if (rgvSP_NSX.CurrentColumn.Index == 2)
                        {
                            if (rgvSP_NSX.CurrentRow.Cells[2].Value == null)
                            {
                                rgvSP_NSX.CurrentRow.IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[2].IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[2].BeginEdit();

                            }
                            //khi mã sản phẩm chưa chọn mà chọn tên sản phẩm
                            else
                            {
                                string spid_ = rgvSP_NSX.CurrentRow.Cells[2].Value.ToString();
                                string masp_ = sanpham.LaySanPhamTheoSPID(spid_).Rows[0]["MaSP"].ToString();
                                rgvSP_NSX.CurrentRow.Cells[1].Value = masp_;
                                rgvSP_NSX.CurrentRow.IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[3].IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[3].BeginEdit();
                            }
                        }
                        #endregion

                        // Thêm Nhà Sản Xuất
                        #region
                        else if (rgvSP_NSX.CurrentColumn.Index == 3)
                        {
                            string Masp_ = rgvSP_NSX.CurrentRow.Cells[1].Value.ToString();
                            string Mansx_ = rgvSP_NSX.CurrentRow.Cells[3].Value.ToString();
                            //Kiểm tra Mã SP có trùng tên với Mã SP trong database hay không
                            if (sanpham_nsx.KiemTraNSX(Masp_, Mansx_) == 0)
                            {
                                rgvSP_NSX.CurrentRow.IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[4].IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[4].BeginEdit();
                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "Nhà Sản Xuất này đã tồn tại";
                                rgvSP_NSX.CurrentRow.IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[3].IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[3].BeginEdit();
                                Guid ma = new Guid("00000000-0000-0000-0000-000000000000");
                                rgvSP_NSX.CurrentRow.Cells[3].Value = ma;
                            }
                        }
                        #endregion

                        //Thêm Ghi chú
                        #region
                        //else if (rgvSP_NSX.CurrentColumn.Index == 4)
                        else
                        {
                            if (rgvSP_NSX.CurrentRow.Cells[4].Value == null)
                            {
                                rgvSP_NSX.CurrentRow.Cells[4].Value = "";
                                rgvSP_NSX.CurrentRow.Cells[5].Value = false;
                                rgvSP_NSX.CurrentRow.Cells[6].Value = false;
                            }
                            else
                            {
                                //rgvSP_NSX.CurrentRow.IsSelected = true;
                                //rgvSP_NSX.CurrentRow.Cells[5].IsSelected = true;
                                //rgvSP_NSX.CurrentRow.Cells[5].BeginEdit();
                                rgvSP_NSX.CurrentRow.Cells[5].Value = false;
                                rgvSP_NSX.CurrentRow.Cells[6].Value = false;
                            }
                            addnewrow();
                            Guid ma = new Guid("00000000-0000-0000-0000-000000000000");
                            rgvSP_NSX.CurrentRow.Cells[1].Value = "";
                            rgvSP_NSX.CurrentRow.Cells[2].Value = ma;
                            rgvSP_NSX.CurrentRow.Cells[3].Value = ma;
                            rgvSP_NSX.CurrentRow.Cells[4].Value = "";
                            rgvSP_NSX.CurrentRow.Cells[5].Value = false;
                            //rgvSP_NSX.CurrentRow.Cells[6].Value = false;
                            rgvSP_NSX.DataSource = sanpham_nsx.LayDanhSachSanPham_NSXLenLuoi(_frmMain.IsXemTatCa_);
                        }
                        #endregion

                        //Thêm mặc định
                        #region
                        //else if (rgvSP_NSX.CurrentColumn.Index == 5)
                        //{
                        //    rgvSP_NSX.CurrentRow.IsSelected = true;
                        //    rgvSP_NSX.CurrentRow.Cells[5].IsSelected = true;
                        //    rgvSP_NSX.CurrentRow.Cells[5].EndEdit();

                        //    if (rgvSP_NSX.CurrentRow.Cells[5].Value == null)
                        //    {
                        //        rgvSP_NSX.CurrentRow.Cells[5].Value = false;
                        //    }
                        //    else
                        //    {
                        //        if ((bool)rgvSP_NSX.CurrentRow.Cells[5].Value == true)
                        //        {
                        //            string masp_ = rgvSP_NSX.CurrentRow.Cells[1].Value.ToString();
                        //            //Kiểm tra xem tất Sản Phẩm này đã có SP-NSX nào được chọn mặc định chưa
                        //            if (sanpham_nsx.LaySanPham_NSXTheoMaSP_CoMacDinh(masp_, true).Rows.Count > 0)
                        //            {
                        //sanpham_nsx.SMaSPNSX = sanpham_nsx.LaySanPham_NSXTheoMaSP_CoMacDinh(masp_, true).Rows[0]["SPNSXid"].ToString();
                        //                sanpham_nsx.BMacDinh = false;
                        //                sanpham_nsx.DLastUD = DateTime.Now;
                        //                sanpham_nsx.SUserID = CStaticBien.SmaTaiKhoan;
                        //                sanpham_nsx.SuaMacDinhSanPham_NSX(sanpham_nsx);
                        //            }
                        //        }
                        //        rgvSP_NSX.CurrentRow.IsSelected = true;
                        //        rgvSP_NSX.CurrentRow.Cells[6].IsSelected = true;
                        //        rgvSP_NSX.CurrentRow.Cells[6].BeginEdit();
                        //    }
                        //}
                        //#endregion

                        //else
                        //#region Thêm Không Sử Dụng
                        //{
                        //    rgvSP_NSX.CurrentRow.IsSelected = true;
                        //    rgvSP_NSX.CurrentRow.Cells[5].IsSelected = true;
                        //    rgvSP_NSX.CurrentRow.Cells[5].EndEdit();
                        //    if (rgvSP_NSX.CurrentRow.Cells[5].Value == null)
                        //    {
                        //        rgvSP_NSX.CurrentRow.Cells[5].Value = false;
                        //    }
                        //    else
                        //    {
                        //        addnewrow();
                        //        Guid ma = new Guid("00000000-0000-0000-0000-000000000000");
                        //        rgvSP_NSX.CurrentRow.Cells[1].Value = "";
                        //        rgvSP_NSX.CurrentRow.Cells[2].Value = ma;
                        //        rgvSP_NSX.CurrentRow.Cells[3].Value = ma;
                        //        rgvSP_NSX.CurrentRow.Cells[4].Value = "";
                        //        rgvSP_NSX.CurrentRow.Cells[5].Value = false;
                        //        //rgvSP_NSX.CurrentRow.Cells[6].Value = false;
                        //        rgvSP_NSX.DataSource = sanpham_nsx.LayDanhSachSanPham_NSXLenLuoi(_frmMain.IsXemTatCa_);
                        //    }
                        //}
                        #endregion

                    }
                    #endregion
                    else
                    // chỉnh sửa sản phẩm - nsx
                    #region
                    {
                        //sửa nhà sản xuất
                        #region
                        if (rgvSP_NSX.CurrentColumn.Index == 3)
                        {
                            string Masp_ = rgvSP_NSX.CurrentRow.Cells[1].Value.ToString();
                            string Mansx_ = rgvSP_NSX.CurrentRow.Cells[3].Value.ToString();
                            //Kiểm tra Mã SP có trùng tên với Mã SP trong database hay không
                            if (sanpham_nsx.KiemTraNSX(Masp_, Mansx_) == 0)
                            {
                                _frmMain.MaSP_NSXCanSua_ = rgvSP_NSX.CurrentRow.Cells[0].Value.ToString();
                                editrow();
                            }
                            else
                            {
                                MessageBox.Show("Nhà Sản Xuất này đã tồn tại");
                                rgvSP_NSX.CurrentRow.IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[3].IsSelected = true;
                                rgvSP_NSX.CurrentRow.Cells[3].BeginEdit();
                            }
                        }
                        #endregion
                        //Sửa Ghi chú
                        else if (rgvSP_NSX.CurrentColumn.Index == 4)
                        {
                            _frmMain.MaSP_NSXCanSua_ = rgvSP_NSX.CurrentRow.Cells[0].Value.ToString();
                            editrow();
                        }
                        //Sửa mặc định
                        #region
                        //else if (rgvSP_NSX.CurrentColumn.Index == 5)
                        //{
                        //    rgvSP_NSX.CurrentRow.IsSelected = true;
                        //    rgvSP_NSX.CurrentRow.Cells[5].IsSelected = true;
                        //    rgvSP_NSX.CurrentRow.Cells[5].EndEdit();

                        //    if ((bool)rgvSP_NSX.CurrentRow.Cells[5].Value == true)
                        //    {
                        //        string masp_ = rgvSP_NSX.CurrentRow.Cells[1].Value.ToString();
                        //        //Kiểm tra xem tất Sản Phẩm này đã có SP-NSX nào được chọn mặc đinh chưa
                        //        if (sanpham_nsx.LaySanPham_NSXTheoMaSP_CoMacDinh(masp_, true).Rows.Count > 0)
                        //        {
                        //            sanpham_nsx.SMaSPNSX = sanpham_nsx.LaySanPham_NSXTheoMaSP_CoMacDinh(masp_, true).Rows[0]["SPNSXid"].ToString();
                        //            sanpham_nsx.BMacDinh = false;
                        //            sanpham_nsx.DLastUD = DateTime.Now;
                        //            sanpham_nsx.SUserID = CStaticBien.SmaTaiKhoan;
                        //            sanpham_nsx.SuaMacDinhSanPham_NSX(sanpham_nsx);
                        //        }
                        //        else
                        //        {
                        //            sanpham_nsx.SMaSPNSX = rgvSP_NSX.CurrentRow.Cells[0].Value.ToString();
                        //            sanpham_nsx.BMacDinh = true;
                        //            sanpham_nsx.DLastUD = DateTime.Now;
                        //            sanpham_nsx.SUserID = CStaticBien.SmaTaiKhoan;
                        //            sanpham_nsx.SuaMacDinhSanPham_NSX(sanpham_nsx);
                        //        }
                        //    }
                        //    _frmMain.MaSP_NSXCanSua_ = rgvSP_NSX.CurrentRow.Cells[0].Value.ToString();
                        //    editrow();
                        //}
                        #endregion
                        else
                        //sửa không sử dụng
                        {
                            rgvSP_NSX.CurrentRow.IsSelected = true;
                            rgvSP_NSX.CurrentRow.Cells[5].IsSelected = true;
                            rgvSP_NSX.CurrentRow.Cells[5].EndEdit();
                            _frmMain.MaSP_NSXCanSua_ = rgvSP_NSX.CurrentRow.Cells[0].Value.ToString();
                            rgvSP_NSX.CurrentRow.Cells[6].Value = false;
                            //if ((bool)rgvSP_NSX.CurrentRow.Cells[5].Value == true && (bool)rgvSP_NSX.CurrentRow.Cells[6].Value == true)
                            //{
                            //    string masp_ = rgvSP_NSX.CurrentRow.Cells[1].Value.ToString();
                            //    editrow();

                            //    sanpham_nsx.SMaSPNSX = _frmMain.MaSP_NSXCanSua_;
                            //    sanpham_nsx.BMacDinh = false;
                            //    sanpham_nsx.DLastUD = DateTime.Now;
                            //    sanpham_nsx.SUserID = CStaticBien.SmaTaiKhoan;
                            //sanpham_nsx.SuaMacDinhSanPham_NSX(sanpham_nsx);

                            //    // add mặc định TRUE khi không có sp-nsx mặc định
                            //    sanpham_nsx.SMaSPNSX = sanpham_nsx.LaySanPham_NSXTheoMaSP_KhongMacDinh(_frmMain.MaSP_NSXCanSua_, masp_, false, false).Rows[0]["SPNSXid"].ToString();
                            //    sanpham_nsx.BMacDinh = true;
                            //    sanpham_nsx.DLastUD = DateTime.Now;
                            //    sanpham_nsx.SUserID = CStaticBien.SmaTaiKhoan;
                            //    sanpham_nsx.SuaMacDinhSanPham_NSX(sanpham_nsx);
                            //    rgvSP_NSX.DataSource = sanpham_nsx.LayDanhSachSanPham_NSXLenLuoi(_frmMain.IsXemTatCa_);
                            //}
                            //else
                            //{
                                editrow();
                            //}
                        }
                    }
                    #endregion
                }
            }
            catch { }
        }

        private void rgvSP_NSX_UserAddedRow(object sender, GridViewRowEventArgs e)
            {
            
            int a = rgvSP_NSX.Rows.Count;
            GridViewRowInfo row = rgvSP_NSX.Rows[a-1];
            rgvSP_NSX.Rows.Remove(row);

            rgvSP_NSX.CurrentRow.IsSelected = true;
            rgvSP_NSX.CurrentRow.Cells[1].IsSelected = true;
            rgvSP_NSX.CurrentRow.Cells[1].BeginEdit();
            toolStripStatusThongBaoLoi.Text = "Dữ liệu chưa cập nhật. Xin vui lòng nhập lại";
        }

        private void rgvSP_NSX_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (rgvSP_NSX.CurrentColumn.Index == 2)
            {
                CSQLSanPham sp_ = new CSQLSanPham();
                RadMultiColumnComboBoxElement SPID = this.rgvSP_NSX.ActiveEditor as RadMultiColumnComboBoxElement;
                SPID.DisplayMember = "TenSP";
                SPID.ValueMember = "SPID";
                SPID.DataSource = sp_.SanPham_LayDSSPLenMultiColumnCombobox();
                SPID.SelectedIndex = -1;
                SPID.EditorControl.Columns["SPid"].IsVisible = false;
                SPID.EditorControl.Columns["MaSP"].Width = 45;
                SPID.EditorControl.Columns["TenSP"].Width = 270;
                SPID.AutoFilter = true;
                FilterDescriptor descriptor = new FilterDescriptor(SPID.DisplayMember, FilterOperator.StartsWith, string.Empty);
                SPID.EditorControl.FilterDescriptors.Add(descriptor);
                SPID.DropDownStyle = RadDropDownStyle.DropDown;
                SPID.AutoSizeDropDownToBestFit = false;
                SPID.DropDownWidth = 350;
                SPID.DropDownHeight = 300;
                
                LaySanPhamVaoCombobox();
            }
            else if (rgvSP_NSX.CurrentColumn.Index == 3)
            {
                CSQLNSX nsx = new CSQLNSX();
                RadMultiColumnComboBoxElement NSXid = this.rgvSP_NSX.ActiveEditor as RadMultiColumnComboBoxElement;
                NSXid.DisplayMember = "TenNSX";
                NSXid.ValueMember = "NSXID";
                NSXid.DataSource = nsx.LayDSNSXLenMultiColumnCombobox();
                NSXid.SelectedIndex = -1;
                NSXid.EditorControl.Columns["NSXID"].IsVisible = false;
                NSXid.EditorControl.Columns["QGid"].IsVisible = false;
                NSXid.EditorControl.Columns["TenNSX"].BestFit();
                NSXid.EditorControl.Columns["TenQuocGia"].BestFit();
                NSXid.AutoFilter = true;
                FilterDescriptor descriptor1 = new FilterDescriptor(NSXid.DisplayMember, FilterOperator.Contains, string.Empty);
                NSXid.EditorControl.FilterDescriptors.Add(descriptor1);
                NSXid.DropDownStyle = RadDropDownStyle.DropDown;
                NSXid.AutoSizeDropDownToBestFit = false;
                NSXid.DropDownWidth = 320;
                LayNSXCombobox();
            } 

        }

            //private void rgvSP_NSX_RowFormatting(object sender, RowFormattingEventArgs e)
            //{
            //    if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
            //    {
            //        e.RowElement.DrawFill = true;
            //        e.RowElement.GradientStyle = GradientStyles.Solid;
            //        e.RowElement.BackColor = CColor.MauGVRow;
            //    }
            //}

    }
}
