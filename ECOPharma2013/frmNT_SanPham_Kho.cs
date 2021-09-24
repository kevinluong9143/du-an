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

namespace ECOPharma2013
{
    public partial class frmNT_SanPham_Kho : Form
    {
        frmMain _frmMain;
        public frmNT_SanPham_Kho()
        {
            InitializeComponent();
        }
        public frmNT_SanPham_Kho(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        CSQLSanPham sanpham = new CSQLSanPham();
        CSQLNT_SanPham_Kho nt_sanpham_kho = new CSQLNT_SanPham_Kho();
        private void frmNT_SanPham_Kho_Load(object sender, EventArgs e)
        {
            rgvNT_SanPham_Kho.DataSource = nt_sanpham_kho.LoadDanhSachLenLuoi(_frmMain.IsXemTatCa_);
            LaySPVaoCombobox();
            LayKhoNhapVaoCombobox();
            LayKhoXuatVaoCombobox();
        }
        void LaySPVaoCombobox()
        {
            CSQLSanPham sp_ = new CSQLSanPham();
            ((GridViewComboBoxColumn)rgvNT_SanPham_Kho.Columns["colSPid"]).DataSource = sp_.LoadDSSanPhamLenLuoi(_frmMain.IsXemTatCa_);
            ((GridViewComboBoxColumn)rgvNT_SanPham_Kho.Columns["colSPid"]).DisplayMember = "TenSP";
            ((GridViewComboBoxColumn)rgvNT_SanPham_Kho.Columns["colSPid"]).ValueMember = "SPID";
        }
        void LayKhoNhapVaoCombobox()
        {
            CSQLKho kho_ = new CSQLKho();
            ((GridViewComboBoxColumn)rgvNT_SanPham_Kho.Columns["colKhoNhapID"]).DataSource = kho_.LayDanhSachKhoLenLuoi(_frmMain.IsXemTatCa_);
            ((GridViewComboBoxColumn)rgvNT_SanPham_Kho.Columns["colKhoNhapID"]).DisplayMember = "TenKho";
            ((GridViewComboBoxColumn)rgvNT_SanPham_Kho.Columns["colKhoNhapID"]).ValueMember = "KhoID";
        }
        void LayKhoXuatVaoCombobox()
        {
            CSQLKho kho_ = new CSQLKho();
            ((GridViewComboBoxColumn)rgvNT_SanPham_Kho.Columns["colKhoXuatID"]).DataSource = kho_.LayDanhSachKhoLenLuoi(_frmMain.IsXemTatCa_);
            ((GridViewComboBoxColumn)rgvNT_SanPham_Kho.Columns["colKhoXuatID"]).DisplayMember = "TenKho";
            ((GridViewComboBoxColumn)rgvNT_SanPham_Kho.Columns["colKhoXuatID"]).ValueMember = "KhoID";
        }
        public void addnewrow()
        {
            nt_sanpham_kho.SMaSP = rgvNT_SanPham_Kho.CurrentRow.Cells[1].Value.ToString();
            nt_sanpham_kho.SSPid = rgvNT_SanPham_Kho.CurrentRow.Cells[2].Value.ToString();
            nt_sanpham_kho.SKhoNhapID = rgvNT_SanPham_Kho.CurrentRow.Cells[3].Value.ToString();
            nt_sanpham_kho.SKhoXuatID = rgvNT_SanPham_Kho.CurrentRow.Cells[4].Value.ToString();
            nt_sanpham_kho.DLastUD = DateTime.Now;
            nt_sanpham_kho.DNgayTao = DateTime.Now;
            nt_sanpham_kho.SUserID = CStaticBien.SmaTaiKhoan;
            string maquantrave = nt_sanpham_kho.ThemMoi(nt_sanpham_kho);
            if (maquantrave != null)
            {
                rgvNT_SanPham_Kho.DataSource = nt_sanpham_kho.LoadDanhSachLenLuoi(_frmMain.IsXemTatCa_);
                toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
            }

        }
        public void editrow()
        {
            nt_sanpham_kho.SPKhoID = _frmMain.MaNT_SP_KhoCanSua_;
            nt_sanpham_kho.SMaSP = rgvNT_SanPham_Kho.CurrentRow.Cells[1].Value.ToString();
            nt_sanpham_kho.SSPid = rgvNT_SanPham_Kho.CurrentRow.Cells[2].Value.ToString();
            nt_sanpham_kho.SKhoNhapID = rgvNT_SanPham_Kho.CurrentRow.Cells[3].Value.ToString();
            nt_sanpham_kho.SKhoXuatID = rgvNT_SanPham_Kho.CurrentRow.Cells[4].Value.ToString();
            nt_sanpham_kho.DLastUD = DateTime.Now;
            nt_sanpham_kho.SUserID = CStaticBien.SmaTaiKhoan;
            int kq = nt_sanpham_kho.ChinhSua(nt_sanpham_kho);
            if (kq == 1)
            {
                rgvNT_SanPham_Kho.DataSource = nt_sanpham_kho.LoadDanhSachLenLuoi(_frmMain.IsXemTatCa_);
                toolStripStatusThongBaoLoi.Text = "Sửa thành công!";
            }
        }

        private void rgvNT_SanPham_Kho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //Khi row đang nằm chỗ thêm mới
                if (rgvNT_SanPham_Kho.CurrentRow.Index == -1)
                {
                    // Xử lý Mã Sản Phẩm
                    #region
                    if (rgvNT_SanPham_Kho.CurrentColumn.Index == 1)
                    {
                        string Masp_ = rgvNT_SanPham_Kho.CurrentRow.Cells[1].Value.ToString();
                        //Kiểm tra sản phẩm có tồn tại hay không
                        if (sanpham.LaySanPhamTheoMaSP(Masp_).Rows.Count > 0)
                        {
                            //Kiểm tra Mã SP có trùng tên với Mã SP trong database hay không
                            if (nt_sanpham_kho.KiemTraMaSP(Masp_) == 0)
                            {
                                string spid_ = sanpham.LaySanPhamTheoMaSP(Masp_).Rows[0]["SPID"].ToString();
                                rgvNT_SanPham_Kho.CurrentRow.Cells[2].Value = spid_;
                                rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                                rgvNT_SanPham_Kho.CurrentRow.Cells[3].IsSelected = true;
                                rgvNT_SanPham_Kho.CurrentRow.Cells[3].BeginEdit();
                            }
                            else
                            {
                                toolStripStatusThongBaoLoi.Text = "Sản Phẩm này đã tồn tại";
                                rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                                rgvNT_SanPham_Kho.CurrentRow.Cells[1].IsSelected = true;
                                rgvNT_SanPham_Kho.CurrentRow.Cells[1].BeginEdit();
                            }
                        }
                        // Đã có trong database thì chọn lại
                        else
                        {
                            rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[1].IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[1].BeginEdit();
                        }
                    #endregion
                    }
                    // Xử lý Tên Sản Phẩm
                    #region
                    else if (rgvNT_SanPham_Kho.CurrentColumn.Index == 2)
                    {
                        string spid_ = rgvNT_SanPham_Kho.CurrentRow.Cells[2].Value.ToString();

                        if (rgvNT_SanPham_Kho.CurrentRow.Cells[2].Value == null)
                        {
                            rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[2].IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[2].BeginEdit();

                        }
                        //khi mã sản phẩm chưa chọn mà chọn tên sản phẩm
                        else
                        {
                            string masp_ = sanpham.LaySanPhamTheoSPID(spid_).Rows[0]["MaSP"].ToString();
                            rgvNT_SanPham_Kho.CurrentRow.Cells[1].Value = masp_;
                            rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[3].IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[3].BeginEdit();
                        }
                    #endregion
                    }
                    // Xử lý Kho Nhập
                    #region
                    else if (rgvNT_SanPham_Kho.CurrentColumn.Index == 3)
                    {
                        if (rgvNT_SanPham_Kho.CurrentRow.Cells[3].Value == null)
                        {
                            toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho nhập";
                            rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[3].IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[3].BeginEdit();

                        }
                        else
                        {
                            toolStripStatusThongBaoLoi.Text = "";
                            rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[4].IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[4].BeginEdit();
                        }
                    #endregion
                    }
                    //Xử lý Kho xuất
                    #region
                    else
                    {
                        if (rgvNT_SanPham_Kho.CurrentRow.Cells[4].Value == null)
                        {
                            toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho xuất";
                            rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[4].IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[4].BeginEdit();

                        }
                        else
                        {
                            addnewrow();
                            Guid ma = new Guid("00000000-0000-0000-0000-000000000000");
                            rgvNT_SanPham_Kho.CurrentRow.Cells[1].Value = "";
                            rgvNT_SanPham_Kho.CurrentRow.Cells[2].Value = ma;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[3].Value = ma;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[4].Value = ma;
                        }
                    }
                    #endregion
                }
                //Khi row đang nằm chỗ chỉnh sửa
                else
                {
                    if (rgvNT_SanPham_Kho.CurrentColumn.Index == 3)
                    {
                        if (rgvNT_SanPham_Kho.CurrentRow.Cells[3].Value == null)
                        {
                            rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[3].IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[3].BeginEdit();
                        }
                        else
                        {
                            _frmMain.MaNT_SP_KhoCanSua_ = rgvNT_SanPham_Kho.CurrentRow.Cells[0].Value.ToString();
                            editrow();
                        }
                    }
                    if (rgvNT_SanPham_Kho.CurrentColumn.Index == 4)
                    {
                        if (rgvNT_SanPham_Kho.CurrentRow.Cells[4].Value == null)
                        {
                            rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[4].IsSelected = true;
                            rgvNT_SanPham_Kho.CurrentRow.Cells[4].BeginEdit();
                        }
                        else
                        {
                            _frmMain.MaNT_SP_KhoCanSua_ = rgvNT_SanPham_Kho.CurrentRow.Cells[0].Value.ToString();
                            editrow();
                        }
                    }

                }
            }
        }

        private void rgvNT_SanPham_Kho_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            int a = rgvNT_SanPham_Kho.Rows.Count;
            GridViewRowInfo row = rgvNT_SanPham_Kho.Rows[a - 1];
            rgvNT_SanPham_Kho.Rows.Remove(row);

            rgvNT_SanPham_Kho.CurrentRow.IsSelected = true;
            rgvNT_SanPham_Kho.CurrentRow.Cells[1].IsSelected = true;
            rgvNT_SanPham_Kho.CurrentRow.Cells[1].BeginEdit();
            toolStripStatusThongBaoLoi.Text = "Xin vui lòng nhập lại";
        }
    }
}
