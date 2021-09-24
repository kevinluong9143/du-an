using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmNhanVien : Form
    {
        frmMain fmain;

        public frmNhanVien(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            CSQLNhanVien nv = new CSQLNhanVien();
            rgvNhanVien.DataSource = nv.LayThongTinNhanVienLenLuoi(fmain.IsXemTatCa_);
        }

        public void LayNhanVienLenLuoi(DataTable bangNhanVien)
        {
            rgvNhanVien.DataSource = bangNhanVien;
        }

        public void SelectRows_NhanVien()
        {
            if (rgvNhanVien.CurrentRow.Cells["colNVID"].Value == null)
            {
                return;
            }
            CSQLNhanVien nv = new CSQLNhanVien();
            fmain.IsSuaNhanVien = true;
            if (fmain.frmNhanVienEditisOpen_ == false)
            {
                fmain.MaNhanVienCanSua_ = rgvNhanVien.CurrentRow.Cells["colNVID"].Value.ToString();
                fmain.BangNhanVienCanSua_ = nv.LayThongTinNhanVienTheoMa(fmain.MaNhanVienCanSua_);
                fmain.frmNhanVienEditisOpen_ = true;
                fmain.fNhanVienEdit_ = new frmNhanVienEdit(fmain);
                fmain.fNhanVienEdit_.ShowDialog();
                return;
            }
            else if (fmain.frmNhanVienEditisOpen_ == true)
            {
                fmain.fNhanVienEdit_.Select();
                return;
            }
        }

        public void rgvNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fmain.fNhanVien.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.fmain.MaNhanVienCanSua_ = rgvNhanVien.CurrentRow.Cells["colNVID"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa nhân viên có mã: ['" + this.fmain.MaNhanVienCanSua_ + "']?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNhanVien xlnv = new CSQLNhanVien();
                    int kq = xlnv.XoaNhanVien(this.fmain.MaNhanVienCanSua_);
                    if (kq == 1)
                        rgvNhanVien.DataSource = xlnv.LayThongTinNhanVienLenLuoi(this.fmain.IsXemTatCa_);
                    else
                        MessageBox.Show("Xóa thông tin nhân viên: ['" + this.fmain.MaNhanVienCanSua_ + "'] thất bại!");
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                SelectRows_NhanVien();
            }

        }

        private void rgvNhanVien_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = CColor.MauGVRow[1];
            }
        }

        private void rgvNhanVien_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NhanVien();
        }
    }
}
