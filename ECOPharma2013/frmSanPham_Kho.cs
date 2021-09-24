﻿using System;
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
    public partial class frmSanPham_Kho : Form
    {
        frmMain _frmMain;
        public frmSanPham_Kho()
        {
            InitializeComponent();
        }
        public frmSanPham_Kho(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        CSQLSanPham sanpham = new CSQLSanPham();
        CSQLSanPham_Kho sanpham_kho = new CSQLSanPham_Kho();
        private void frmSanPham_Kho_Load(object sender, EventArgs e)
        {
            rgvSP_Kho.DataSource = sanpham_kho.LayDanhSachSanPham_KhoLenLuoi(_frmMain.IsXemTatCa_);
            LaySPVaoCombobox();
            LayKhoCtyVaoCombobox();
        }
        void LaySPVaoCombobox()
        {
            CSQLSanPham sp_ = new CSQLSanPham();
            ((GridViewMultiComboBoxColumn)rgvSP_Kho.Columns["colSPid"]).DataSource = sp_.SanPham_LayDSSPLenMultiColumnCombobox();
            ((GridViewMultiComboBoxColumn)rgvSP_Kho.Columns["colSPid"]).DisplayMember = "TenSP";
            ((GridViewMultiComboBoxColumn)rgvSP_Kho.Columns["colSPid"]).ValueMember = "SPID";

        }
        string MaBPcon;
        #region Lấy thông tin các kho vào Lưới
        void LayKhoCtyVaoCombobox()
        {
            CSQLKho kho_ = new CSQLKho();
            CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            CSQLNhaThuoc nt_ = new CSQLNhaThuoc();
            string mabp_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();

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

            string ttcn_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
            int nhomloai = int.Parse(nt_.LayNhaThuocTheoMa(ttcn_).Rows[0]["NhomLoai"].ToString());
            if (nhomloai == 1)
            {

                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapID"]).DataSource = kho_.LoadKho_TongCongTy_NhapXuat(MaBPcon,false);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapID"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapID"]).ValueMember = "KhoID";


                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatID"]).DataSource = kho_.LoadKho_TongCongTy_NhapXuat(MaBPcon, false);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatID"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatID"]).ValueMember = "KhoID";

                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuID"]).DataSource = kho_.LoadKho_TongCongTy_Hu(MaBPcon);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuID"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuID"]).ValueMember = "KhoID";


                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapNTid"]).DataSource = kho_.LoadKho_NhaThuoc_NhapXuat(MaBPcon, false);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapNTid"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapNTid"]).ValueMember = "KhoID";


                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatNTid"]).DataSource = kho_.LoadKho_NhaThuoc_NhapXuat(MaBPcon, false);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatNTid"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatNTid"]).ValueMember = "KhoID";

                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuNTid"]).DataSource = kho_.LoadKho_NhaThuoc_Hu(MaBPcon);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuNTid"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuNTid"]).ValueMember = "KhoID";

            }
            else
            {

                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapid"]).DataSource = kho_.LoadKho_NhaThuoc_NhapXuat(MaBPcon, false);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapID"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapID"]).ValueMember = "KhoID";


                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatID"]).DataSource = kho_.LoadKho_NhaThuoc_NhapXuat(MaBPcon, false);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatID"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatID"]).ValueMember = "KhoID";

                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuID"]).DataSource = kho_.LoadKho_NhaThuoc_Hu(MaBPcon);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuID"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuID"]).ValueMember = "KhoID";


                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapNTid"]).DataSource = kho_.LoadKho_TongCongTy_NhapXuat(MaBPcon, false);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapNTid"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoNhapNTid"]).ValueMember = "KhoID";


                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatNTid"]).DataSource = kho_.LoadKho_TongCongTy_NhapXuat(MaBPcon, false);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatNTid"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoXuatNTid"]).ValueMember = "KhoID";

                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuNTid"]).DataSource = kho_.LoadKho_TongCongTy_Hu(MaBPcon);
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuNTid"]).DisplayMember = "TenKho";
                ((GridViewComboBoxColumn)rgvSP_Kho.Columns["colKhoHangHuNTid"]).ValueMember = "KhoID";
            }
        }
        #endregion

        public void addnewrow()
        {
            sanpham_kho.SMaSP = rgvSP_Kho.CurrentRow.Cells[1].Value.ToString();
            sanpham_kho.SSPid = rgvSP_Kho.CurrentRow.Cells[2].Value.ToString();
            sanpham_kho.SKhoNhapID = rgvSP_Kho.CurrentRow.Cells[3].Value.ToString();
            sanpham_kho.SKhoXuatID = rgvSP_Kho.CurrentRow.Cells[4].Value.ToString();
            sanpham_kho.SKhoHuID = rgvSP_Kho.CurrentRow.Cells[5].Value.ToString();
            sanpham_kho.SKhoNhapNTID = rgvSP_Kho.CurrentRow.Cells[6].Value.ToString();
            sanpham_kho.SKhoXuatNTID = rgvSP_Kho.CurrentRow.Cells[7].Value.ToString();
            sanpham_kho.SKhoHuNTID = rgvSP_Kho.CurrentRow.Cells[8].Value.ToString();
            sanpham_kho.BIsMacDinh = (bool)rgvSP_Kho.CurrentRow.Cells[9].Value;
            sanpham_kho.DLastUD = DateTime.Now;
            sanpham_kho.DNgayTao = DateTime.Now;
            sanpham_kho.SUserID = CStaticBien.SmaTaiKhoan;
            string maquantrave = sanpham_kho.ThemMoiSanPham_Kho(sanpham_kho);
            if (maquantrave != null)
            {
                //this._frmMain.MaSP_KhoCanSua_ = maquantrave;
                rgvSP_Kho.DataSource = sanpham_kho.LayDanhSachSanPham_KhoLenLuoi(_frmMain.IsXemTatCa_);
                toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
                _frmMain.MaSP_KhoCanSua_ = null;
                Guid ma = new Guid("00000000-0000-0000-0000-000000000000");
                rgvSP_Kho.CurrentRow.Cells[1].Value = "";
                rgvSP_Kho.CurrentRow.Cells[2].Value = ma;
                rgvSP_Kho.CurrentRow.Cells[3].Value = ma;
                rgvSP_Kho.CurrentRow.Cells[4].Value = ma;
                rgvSP_Kho.CurrentRow.Cells[5].Value = ma;
                rgvSP_Kho.CurrentRow.Cells[6].Value = ma;
                rgvSP_Kho.CurrentRow.Cells[7].Value = ma;
                rgvSP_Kho.CurrentRow.Cells[8].Value = ma;
                rgvSP_Kho.CurrentRow.Cells[9].Value = false;
            }

        }
        public void editrow()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fSanPham_Kho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            sanpham_kho.SPKhoID = _frmMain.MaSP_KhoCanSua_;
            sanpham_kho.SMaSP = rgvSP_Kho.CurrentRow.Cells[1].Value.ToString();
            sanpham_kho.SSPid = rgvSP_Kho.CurrentRow.Cells[2].Value.ToString();
            sanpham_kho.SKhoNhapID = rgvSP_Kho.CurrentRow.Cells[3].Value.ToString();
            sanpham_kho.SKhoXuatID = rgvSP_Kho.CurrentRow.Cells[4].Value.ToString();
            sanpham_kho.SKhoHuID = rgvSP_Kho.CurrentRow.Cells[5].Value.ToString();

            sanpham_kho.SKhoNhapNTID = rgvSP_Kho.CurrentRow.Cells[6].Value.ToString();
            sanpham_kho.SKhoXuatNTID = rgvSP_Kho.CurrentRow.Cells[7].Value.ToString();
            sanpham_kho.SKhoHuNTID = rgvSP_Kho.CurrentRow.Cells[8].Value.ToString();
            sanpham_kho.BIsMacDinh = (bool)rgvSP_Kho.CurrentRow.Cells[9].Value;
            sanpham_kho.DLastUD = DateTime.Now;
            sanpham_kho.SUserID = CStaticBien.SmaTaiKhoan;
            int kq = sanpham_kho.SuaThongTinSanPham_Kho(sanpham_kho);
            if (kq == 1)
            {
                rgvSP_Kho.DataSource = sanpham_kho.LayDanhSachSanPham_KhoLenLuoi(_frmMain.IsXemTatCa_);
                toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
            }
        }
        private void rgvSP_Kho_KeyPress(object sender, KeyPressEventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fSanPham_Kho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                if (e.KeyChar == 13)
                {
                    //Khi row đang nằm chỗ thêm mới
                    #region
                    if (rgvSP_Kho.CurrentRow.Index == -1)
                    {
                        // Xử lý Mã Sản Phẩm
                        #region
                        if (rgvSP_Kho.CurrentColumn.Index == 1)
                        {
                            #region Tạm thời khóa
                            //string Masp_ = rgvSP_Kho.CurrentRow.Cells[1].Value.ToString();
                            ////Kiểm tra sản phẩm có tồn tại hay không
                            //if (sanpham.LaySanPhamTheoMaSP(Masp_).Rows.Count > 0)
                            //{
                            //    //Kiểm tra Mã SP có trùng tên với Mã SP trong database hay không
                            //    if (sanpham_kho.KiemTraMaSP(Masp_) == 0)
                            //    {
                            //        string spid_ = sanpham.LaySanPhamTheoMaSP(Masp_).Rows[0]["SPID"].ToString();
                            //        rgvSP_Kho.CurrentRow.Cells[2].Value = spid_;
                            //        rgvSP_Kho.CurrentRow.IsSelected = true;
                            //        rgvSP_Kho.CurrentRow.Cells[3].IsSelected = true;
                            //        rgvSP_Kho.CurrentRow.Cells[3].BeginEdit();
                            //    }
                            //    else
                            //    {
                            //        toolStripStatusThongBaoLoi.Text = "Sản Phẩm này đã tồn tại";
                            //        rgvSP_Kho.CurrentRow.IsSelected = true;
                            //        rgvSP_Kho.CurrentRow.Cells[1].IsSelected = true;
                            //        rgvSP_Kho.CurrentRow.Cells[1].BeginEdit();
                            //    }
                            //}
                            //// Đã có trong database thì chọn lại
                            //else
                            //{
                            //    rgvSP_Kho.CurrentRow.IsSelected = true;
                            //    rgvSP_Kho.CurrentRow.Cells[1].IsSelected = true;
                            //    rgvSP_Kho.CurrentRow.Cells[1].BeginEdit();
                            //}
                            #endregion
                            string Masp_ = rgvSP_Kho.CurrentRow.Cells[1].Value.ToString();
                            //Kiểm tra sản phẩm có tồn tại hay không
                            if (sanpham.LaySanPhamTheoMaSP(Masp_).Rows.Count > 0)
                            {
                                string spid_ = sanpham.LaySanPhamTheoMaSP(Masp_).Rows[0]["SPID"].ToString();
                                rgvSP_Kho.CurrentRow.Cells[2].Value = spid_;
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[3].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[3].BeginEdit();
                            }
                            // Không có trong database thì chọn lại
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "Sản Phẩm này không tồn tại";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[1].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[1].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Tên Sản Phẩm
                        #region
                        else if (rgvSP_Kho.CurrentColumn.Index == 2)
                        {
                            string spid_ = rgvSP_Kho.CurrentRow.Cells[2].Value.ToString();

                            if (rgvSP_Kho.CurrentRow.Cells[2].Value == null)
                            {
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[2].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[2].BeginEdit();

                            }
                            //khi mã sản phẩm chưa chọn mà chọn tên sản phẩm
                            else
                            {
                                string masp_ = sanpham.LaySanPhamTheoSPID(spid_).Rows[0]["MaSP"].ToString();
                                rgvSP_Kho.CurrentRow.Cells[1].Value = masp_;
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[3].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[3].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Kho Nhập
                        #region
                        else if (rgvSP_Kho.CurrentColumn.Index == 3)
                        {
                            if (rgvSP_Kho.CurrentRow.Cells[3].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho nhập";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[3].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[3].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[4].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[4].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Kho Xuất
                        #region
                        else if (rgvSP_Kho.CurrentColumn.Index == 4)
                        {
                            if (rgvSP_Kho.CurrentRow.Cells[4].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho xuất.";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[4].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[4].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[5].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[5].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Kho Hư
                        #region
                        else if (rgvSP_Kho.CurrentColumn.Index == 5)
                        {
                            CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
                            CSQLSanPham sp_ = new CSQLSanPham();
                            if (rgvSP_Kho.CurrentRow.Cells[5].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho hư.";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[5].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[5].BeginEdit();
                            }
                            else
                            {
                                string spid_ = sp_.LaySanPhamTheoMaSP(rgvSP_Kho.CurrentRow.Cells[1].Value.ToString()).Rows[0]["SPID"].ToString();
                                if (sp_kho.LaySanPham_KhoTheoSPid(spid_).Rows.Count <= 0 || sp_kho.LaySP_KhoTheoSPID_CoMacDinh(spid_, true).Rows.Count > 0)
                                {
                                    if (MessageBox.Show("Bạn có muốn để trống thông tin kho Nhập-Xuất-Hư của Nhà Thuốc này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        rgvSP_Kho.CurrentRow.Cells[6].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                        rgvSP_Kho.CurrentRow.Cells[7].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                        rgvSP_Kho.CurrentRow.Cells[8].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                        rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                        addnewrow();
                                    }
                                    else
                                    {
                                        toolStripStatusThongBaoLoi.Text = "";
                                        rgvSP_Kho.CurrentRow.IsSelected = true;
                                        rgvSP_Kho.CurrentRow.Cells[6].IsSelected = true;
                                        rgvSP_Kho.CurrentRow.Cells[6].BeginEdit();
                                    }
                                }
                                else
                                {
                                    toolStripStatusThongBaoLoi.Text = "";
                                    rgvSP_Kho.CurrentRow.IsSelected = true;
                                    rgvSP_Kho.CurrentRow.Cells[6].IsSelected = true;
                                    rgvSP_Kho.CurrentRow.Cells[6].BeginEdit();
                                }
                            }
                        #endregion
                        }
                        // Xử lý Kho Nhập NT
                        #region
                        else if (rgvSP_Kho.CurrentColumn.Index == 6)
                        {
                            if (rgvSP_Kho.CurrentRow.Cells[6].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho nhập";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[6].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[6].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[7].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[7].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử lý Kho Xuất NT
                        #region
                        else if (rgvSP_Kho.CurrentColumn.Index == 7)
                        {
                            if (rgvSP_Kho.CurrentRow.Cells[7].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho xuất.";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[7].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[7].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[8].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[8].BeginEdit();
                            }
                        #endregion
                        }
                        //Xử lý Kho Hư NT
                        #region
                        else if (rgvSP_Kho.CurrentColumn.Index == 8)
                        {
                            if (rgvSP_Kho.CurrentRow.Cells[8].Value == null)
                            {
                                toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho hư.";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[8].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[8].BeginEdit();

                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "";
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[9].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[9].BeginEdit();
                            }
                        #endregion
                        }
                        // Xử Lý Mặc Định
                        #region
                        else
                        {
                            rgvSP_Kho.CurrentRow.IsSelected = true;
                            rgvSP_Kho.CurrentRow.Cells[9].IsSelected = true;
                            rgvSP_Kho.CurrentRow.Cells[9].EndEdit();

                            if (rgvSP_Kho.CurrentRow.Cells[9].Value == null)
                            {
                                rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                            }
                            else
                            {
                                CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
                                CSQLSanPham sp_ = new CSQLSanPham();

                                #region Mặc Định bằng Tru
                                if ((bool)rgvSP_Kho.CurrentRow.Cells[9].Value == true)
                                {
                                    string spid_ = sp_.LaySanPhamTheoMaSP(rgvSP_Kho.CurrentRow.Cells[1].Value.ToString()).Rows[0]["SPID"].ToString();

                                    //Kiểm tra xem tất Sản Phẩm này đã có SP-Kho nào được chọn mặc định chưa
                                    #region
                                    if (sp_kho.LaySP_KhoTheoSPID_CoMacDinh(spid_, true).Rows.Count > 0)
                                    {
                                        if (rgvSP_Kho.CurrentRow.Cells[6].Value == null || rgvSP_Kho.CurrentRow.Cells[7].Value == null || rgvSP_Kho.CurrentRow.Cells[8].Value == null || rgvSP_Kho.CurrentRow.Cells[6].Value.ToString() == "00000000-0000-0000-0000-000000000000" || rgvSP_Kho.CurrentRow.Cells[7].Value.ToString() == "00000000-0000-0000-0000-000000000000" || rgvSP_Kho.CurrentRow.Cells[8].Value.ToString() == "00000000-0000-0000-0000-000000000000")
                                        {
                                            toolStripStatusThongBaoLoi.Text = "Không được để trống các kho khi chọn Mặc Định cho Sản Phẩm-Kho.";
                                            rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                            if (rgvSP_Kho.CurrentRow.Cells[6].Value == null || rgvSP_Kho.CurrentRow.Cells[6].Value.ToString() == "00000000-0000-0000-0000-000000000000")
                                            {
                                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                                rgvSP_Kho.CurrentRow.Cells[6].IsSelected = true;
                                                rgvSP_Kho.CurrentRow.Cells[6].BeginEdit();
                                            }
                                            else
                                            {
                                                if (rgvSP_Kho.CurrentRow.Cells[7].Value == null || rgvSP_Kho.CurrentRow.Cells[7].Value.ToString() == "00000000-0000-0000-0000-000000000000")
                                                {
                                                    rgvSP_Kho.CurrentRow.IsSelected = true;
                                                    rgvSP_Kho.CurrentRow.Cells[7].IsSelected = true;
                                                    rgvSP_Kho.CurrentRow.Cells[7].BeginEdit();
                                                }
                                                else
                                                {
                                                    rgvSP_Kho.CurrentRow.IsSelected = true;
                                                    rgvSP_Kho.CurrentRow.Cells[8].IsSelected = true;
                                                    rgvSP_Kho.CurrentRow.Cells[8].BeginEdit();
                                                }
                                            }
                                            return;
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("Sản Phẩm_Kho này đã có Mặc Định. Bạn có muốn thay đổi lại Mặc Định cho Sản Phẩm_Kho này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                sp_kho.SPKhoID = sp_kho.LaySP_KhoTheoSPID_CoMacDinh(spid_, true).Rows[0]["SPKhoID"].ToString();
                                                sp_kho.BIsMacDinh = false;
                                                sp_kho.DLastUD = DateTime.Now;
                                                sp_kho.SUserID = CStaticBien.SmaTaiKhoan;
                                                sp_kho.SuaMacDinhSP_Kho(sp_kho);
                                            }
                                            else
                                            {
                                                rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                            }
                                        }
                                    }
                                    #endregion
                                    else
                                    {
                                        //Kiểm tra Kho Nhập-Xuất-Hư của NT có null khi chọn mặc định hay không  
                                        if (rgvSP_Kho.CurrentRow.Cells[6].Value == null || rgvSP_Kho.CurrentRow.Cells[7].Value == null || rgvSP_Kho.CurrentRow.Cells[8].Value == null)
                                        {
                                            if (MessageBox.Show("Không được để trống Kho Nhập-Xuất-Hư của Nhà Thuốc khi chọn Mặc Định. Bạn muốn lưu khi để trống Kho Nhập-Xuất-Hư và Mặc Định không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                rgvSP_Kho.CurrentRow.Cells[6].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                                rgvSP_Kho.CurrentRow.Cells[7].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                                rgvSP_Kho.CurrentRow.Cells[8].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                                rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                                addnewrow();
                                                return;
                                            }
                                            else
                                            {
                                                rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                                rgvSP_Kho.CurrentRow.Cells[6].IsSelected = true;
                                                rgvSP_Kho.CurrentRow.Cells[6].BeginEdit();
                                                return;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                else
                                #region Mặc Định bằng False
                                {
                                    if (rgvSP_Kho.CurrentRow.Cells[6].Value == null || rgvSP_Kho.CurrentRow.Cells[6].Value.ToString() == "00000000-0000-0000-0000-000000000000")
                                    {
                                        rgvSP_Kho.CurrentRow.Cells[6].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                        rgvSP_Kho.CurrentRow.Cells[7].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                        rgvSP_Kho.CurrentRow.Cells[8].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                        rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                    }
                                    else if (rgvSP_Kho.CurrentRow.Cells[7].Value == null || rgvSP_Kho.CurrentRow.Cells[7].Value.ToString() == "00000000-0000-0000-0000-000000000000")
                                    {
                                        rgvSP_Kho.CurrentRow.Cells[7].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                        rgvSP_Kho.CurrentRow.Cells[8].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                        rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                    }
                                    else
                                    {
                                        rgvSP_Kho.CurrentRow.Cells[8].Value = new Guid("00000000-0000-0000-0000-000000000000");
                                        rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                    }
                                }
                                #endregion
                            }
                            addnewrow();
                        }
                        #endregion
                    }
                    #endregion

                    //Khi row đang nằm chỗ chỉnh sửa
                    #region
                    else
                    {
                        CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
                        DataTable dtbsp_kho = sp_kho.LaySanPham_KhoTheoMa(rgvSP_Kho.CurrentRow.Cells[0].Value.ToString());
                        // Xử lý Sửa Kho Nhập
                        #region
                        if (rgvSP_Kho.CurrentColumn.Index == 3)
                        {
                            int xnt = rgvSP_Kho.CurrentRow.Index;
                            if (rgvSP_Kho.CurrentRow.Cells[3].Value == null)
                            {
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[3].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[3].BeginEdit();
                            }
                            else if (rgvSP_Kho.CurrentRow.Cells[3].Value.ToString() == "")
                            {
                                toolStripStatusThongBaoLoi.Text = "Không được xóa kho Hàng Nhập Công Ty.";
                                FocusRows(xnt);
                                return;
                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "Không được xóa kho Hàng Nhập Công Ty.";
                                _frmMain.MaSP_KhoCanSua_ = rgvSP_Kho.CurrentRow.Cells[0].Value.ToString();
                                editrow();
                            }
                        #endregion
                        }
                        // Xử lý Sửa Kho Xuất
                        #region
                        if (rgvSP_Kho.CurrentColumn.Index == 4)
                        {
                            int xnt = rgvSP_Kho.CurrentRow.Index;
                            if (rgvSP_Kho.CurrentRow.Cells[4].Value == null)
                            {
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[4].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[4].BeginEdit();
                            }
                            else if(rgvSP_Kho.CurrentRow.Cells[4].Value.ToString() == "" )
                            {
                                toolStripStatusThongBaoLoi.Text = "Không được xóa kho Hàng Xuất Công Ty.";
                                FocusRows(xnt);
                                return;
                            }
                            else
                            {

                                _frmMain.MaSP_KhoCanSua_ = rgvSP_Kho.CurrentRow.Cells[0].Value.ToString();
                                editrow();
                            }
                        #endregion
                        }
                        // Xử lý Sửa Kho Hư
                        #region
                        if (rgvSP_Kho.CurrentColumn.Index == 5)
                        {
                            int xnt = rgvSP_Kho.CurrentRow.Index;
                            if (rgvSP_Kho.CurrentRow.Cells[5].Value == null)
                            {
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[5].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[5].BeginEdit();
                            }
                            else if (rgvSP_Kho.CurrentRow.Cells[5].Value.ToString() == "")
                            {
                                toolStripStatusThongBaoLoi.Text = "Không được xóa kho Hàng Hư Công Ty.";
                                FocusRows(xnt);
                                return;
                            }
                            else
                            {
                                _frmMain.MaSP_KhoCanSua_ = rgvSP_Kho.CurrentRow.Cells[0].Value.ToString();
                                editrow();
                            }
                        #endregion
                        }
                        // Xử lý Sửa Kho Nhập NT
                        #region
                        if (rgvSP_Kho.CurrentColumn.Index == 6)
                        {
                            int xnt = rgvSP_Kho.CurrentRow.Index;
                            if (rgvSP_Kho.CurrentRow.Cells[6].Value == null)
                            {
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[6].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[6].BeginEdit();
                            }
                            else
                            {
                                if (dtbsp_kho.Rows[0]["KhoNhapNTid"].ToString() == "")
                                {
                                    rgvSP_Kho.CurrentRow.IsSelected = true;
                                    rgvSP_Kho.CurrentRow.Cells[7].IsSelected = true;
                                    rgvSP_Kho.CurrentRow.Cells[7].BeginEdit();
                                    return;
                                }
                                else if (rgvSP_Kho.CurrentRow.Cells[6].Value.ToString() == "" && (bool)rgvSP_Kho.CurrentRow.Cells[9].Value == true)
                                {
                                    toolStripStatusThongBaoLoi.Text = "Sản Phẩm-Kho đang có mặc định nên không thể xóa kho Hàng Nhập NT.";
                                    FocusRows(xnt);
                                    return;
                                }
                                else
                                {
                                    _frmMain.MaSP_KhoCanSua_ = rgvSP_Kho.CurrentRow.Cells[0].Value.ToString();
                                    editrow();
                                }
                            }
                        #endregion
                        }
                        // Xử lý Sửa Kho Xuất NT
                        #region
                        if (rgvSP_Kho.CurrentColumn.Index == 7)
                        {
                            int xnt = rgvSP_Kho.CurrentRow.Index;
                            if (rgvSP_Kho.CurrentRow.Cells[7].Value == null)
                            {
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[7].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[7].BeginEdit();
                            }
                            else
                            {
                                if (dtbsp_kho.Rows[0]["KhoXuatNTid"].ToString() == "")
                                {
                                    rgvSP_Kho.CurrentRow.IsSelected = true;
                                    rgvSP_Kho.CurrentRow.Cells[8].IsSelected = true;
                                    rgvSP_Kho.CurrentRow.Cells[8].BeginEdit();
                                    return;
                                }
                                else if (rgvSP_Kho.CurrentRow.Cells[7].Value.ToString() == "" && (bool)rgvSP_Kho.CurrentRow.Cells[9].Value == true)
                                {
                                    toolStripStatusThongBaoLoi.Text = "Sản Phẩm-Kho đang có mặc định nên không thể xóa kho Hàng Xuất NT.";
                                    FocusRows(xnt);
                                    return;
                                }
                                else
                                {
                                    _frmMain.MaSP_KhoCanSua_ = rgvSP_Kho.CurrentRow.Cells[0].Value.ToString();
                                    editrow();
                                }
                            }
                        #endregion
                        }
                        //Xử lý Sửa Kho Hư NT
                        #region
                        if (rgvSP_Kho.CurrentColumn.Index == 8)
                        {
                            int xnt = rgvSP_Kho.CurrentRow.Index;
                            if (rgvSP_Kho.CurrentRow.Cells[8].Value == null)
                            {
                                rgvSP_Kho.CurrentRow.IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[8].IsSelected = true;
                                rgvSP_Kho.CurrentRow.Cells[8].BeginEdit();
                            }
                            else
                            {
                                if (dtbsp_kho.Rows[0]["KhoHangHuNTid"].ToString() == "")
                                {
                                    rgvSP_Kho.CurrentRow.IsSelected = true;
                                    rgvSP_Kho.CurrentRow.Cells[9].IsSelected = true;
                                    rgvSP_Kho.CurrentRow.Cells[9].BeginEdit();
                                    return;
                                }
                                else if (rgvSP_Kho.CurrentRow.Cells[8].Value.ToString() == "" && (bool)rgvSP_Kho.CurrentRow.Cells[9].Value == true)
                                {
                                    toolStripStatusThongBaoLoi.Text = "Sản Phẩm-Kho đang có mặc định nên không thể xóa kho Hàng Hư NT.";
                                    FocusRows(xnt);
                                    return;
                                }
                                else
                                {
                                    _frmMain.MaSP_KhoCanSua_ = rgvSP_Kho.CurrentRow.Cells[0].Value.ToString();
                                    editrow();
                                }
                            }
                        #endregion
                        }
                        //Xử lý Sửa Mặc Định
                        #region
                        if (rgvSP_Kho.CurrentColumn.Index == 9)
                        {
                            rgvSP_Kho.CurrentRow.IsSelected = true;
                            rgvSP_Kho.CurrentRow.Cells[9].IsSelected = true;
                            rgvSP_Kho.CurrentRow.Cells[9].EndEdit();

                            if ((bool)rgvSP_Kho.CurrentRow.Cells[9].Value == true)
                            {
                                CSQLSanPham sp_ = new CSQLSanPham();
                                string spid_ = sp_.LaySanPhamTheoMaSP(rgvSP_Kho.CurrentRow.Cells[1].Value.ToString()).Rows[0]["SPID"].ToString();
                                if (rgvSP_Kho.CurrentRow.Cells[3].Value.ToString() == "" || rgvSP_Kho.CurrentRow.Cells[4].Value.ToString() == "" || rgvSP_Kho.CurrentRow.Cells[5].Value.ToString() == "")
                                {
                                    rgvSP_Kho.DataSource = sanpham_kho.LayDanhSachSanPham_KhoLenLuoi(_frmMain.IsXemTatCa_);
                                    return;
                                }
                                else
                                {
                                    #region SP_Kho này Đã có Mặc định chưa
                                    if (sp_kho.LaySP_KhoTheoSPID_CoMacDinh(spid_, true).Rows.Count > 0)
                                    {
                                        if (rgvSP_Kho.CurrentRow.Cells[6].Value.ToString() == "" || rgvSP_Kho.CurrentRow.Cells[7].Value.ToString() == "" || rgvSP_Kho.CurrentRow.Cells[8].Value.ToString() == "")
                                        {
                                            toolStripStatusThongBaoLoi.Text = "Không được để trống các kho khi chọn Mặc Định cho Sản Phẩm-Kho.";
                                            rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                            XuLyChonKhoNhaXuatHu();
                                            return;
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("Sản Phẩm_Kho này đã có Mặc Định.\nBạn có muốn thay đổi lại Mặc Định cho Sản Phẩm_Kho này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                sp_kho.SPKhoID = sp_kho.LaySP_KhoTheoSPID_CoMacDinh(spid_, true).Rows[0]["SPKhoID"].ToString();
                                                sp_kho.BIsMacDinh = false;
                                                sp_kho.DLastUD = DateTime.Now;
                                                sp_kho.SUserID = CStaticBien.SmaTaiKhoan;
                                                sp_kho.SuaMacDinhSP_Kho(sp_kho);
                                            }
                                            else
                                            {
                                                rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                            }
                                        }
                                    }
                                    #endregion
                                    else
                                    #region  SP_Kho này chưa có Mặc định chưa
                                    {
                                        //Kiểm tra Kho Nhập-Xuất-Hư của NT có null khi chọn mặc định hay không
                                        if (rgvSP_Kho.CurrentRow.Cells[6].Value.ToString() == "" || rgvSP_Kho.CurrentRow.Cells[7].Value.ToString() == "" || rgvSP_Kho.CurrentRow.Cells[8].Value.ToString() == "")
                                        {
                                            if (MessageBox.Show("Không được để trống Kho Nhập-Xuất-Hư của Nhà Thuốc khi chọn Mặc Định.\n Bạn muốn chỉnh sửa Kho Nhập-Xuất-Hư của Nhà Thuốc không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                                XuLyChonKhoNhaXuatHu();
                                                return;
                                            }
                                            else
                                            {
                                                rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                                return;
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                if (rgvSP_Kho.CurrentRow.Cells[3].Value.ToString() == "" || rgvSP_Kho.CurrentRow.Cells[4].Value.ToString() == "" || rgvSP_Kho.CurrentRow.Cells[5].Value.ToString() == "")
                                {
                                    toolStripStatusThongBaoLoi.Text = "Chỉnh sửa thất bại.";
                                    rgvSP_Kho.CurrentRow.Cells[9].Value = false;
                                    rgvSP_Kho.DataSource = sanpham_kho.LayDanhSachSanPham_KhoLenLuoi(_frmMain.IsXemTatCa_);
                                    return;
                                }
                            }
                            _frmMain.MaSP_KhoCanSua_ = rgvSP_Kho.CurrentRow.Cells[0].Value.ToString();
                            editrow();
                        }
                        #endregion
                    }
                    #endregion
                }
            }
            catch { }
        }

        private void XuLyChonKhoNhaXuatHu()
        {
            if (rgvSP_Kho.CurrentRow.Cells[6].Value.ToString() == "")
            {
                rgvSP_Kho.CurrentRow.IsSelected = true;
                rgvSP_Kho.CurrentRow.Cells[6].IsSelected = true;
                rgvSP_Kho.CurrentRow.Cells[6].BeginEdit();
            }
            else
            {
                if (rgvSP_Kho.CurrentRow.Cells[7].Value.ToString() == "")
                {
                    rgvSP_Kho.CurrentRow.IsSelected = true;
                    rgvSP_Kho.CurrentRow.Cells[7].IsSelected = true;
                    rgvSP_Kho.CurrentRow.Cells[7].BeginEdit();
                }
                else
                {
                    rgvSP_Kho.CurrentRow.IsSelected = true;
                    rgvSP_Kho.CurrentRow.Cells[8].IsSelected = true;
                    rgvSP_Kho.CurrentRow.Cells[8].BeginEdit();
                }
            }
        }

        private void FocusRows(int xnt)
        {
            rgvSP_Kho.DataSource = sanpham_kho.LayDanhSachSanPham_KhoLenLuoi(_frmMain.IsXemTatCa_);
            rgvSP_Kho.CurrentRow = rgvSP_Kho.Rows[xnt];
        }

        private void rgvSP_Kho_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            int a = rgvSP_Kho.Rows.Count;
            GridViewRowInfo row = rgvSP_Kho.Rows[a - 1];
            rgvSP_Kho.Rows.Remove(row);

            rgvSP_Kho.CurrentRow.IsSelected = true;
            rgvSP_Kho.CurrentRow.Cells[1].IsSelected = true;
            rgvSP_Kho.CurrentRow.Cells[1].BeginEdit();
            toolStripStatusThongBaoLoi.Text = "Xin vui lòng nhập lại";
        }

        private void rgvSP_Kho_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (rgvSP_Kho.CurrentColumn.Index == 2)
            {
                CSQLSanPham sp_ = new CSQLSanPham();
                RadMultiColumnComboBoxElement SPID = this.rgvSP_Kho.ActiveEditor as RadMultiColumnComboBoxElement;
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
                LaySPVaoCombobox();
            }
        }

    }
}