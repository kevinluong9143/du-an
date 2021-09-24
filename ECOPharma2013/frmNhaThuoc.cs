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
    public partial class frmNhaThuoc : Form
    {
        private frmMain _fMain;
        CSQLNhaThuoc xlnhathuoc = null;

        public frmNhaThuoc()
        {
            InitializeComponent();
        }

        public frmNhaThuoc(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        private void frmNhaThuoc_Load(object sender, EventArgs e)
        {
            xlnhathuoc = new CSQLNhaThuoc();
            rgvNhaThuoc.DataSource = xlnhathuoc.LayDanhSachNhaThuocLenLuoi(_fMain.IsXemTatCa_);

        }

        public void SelectRows_NhaThuoc()
        {
            if (rgvNhaThuoc.CurrentRow.Cells["colNTID"].Value == null)
            {
                return;
            }
            _fMain.IsSuaNhaThuoc_ = true;
            if (_fMain.frmNhaThuocEditisOpen_ == false)
            {
                _fMain.MaNhaThuocCanSua_ = rgvNhaThuoc.CurrentRow.Cells["colNTID"].Value.ToString();
                _fMain.BangNhaThuocCanSua_ = xlnhathuoc.LayNhaThuocTheoMa(_fMain.MaNhaThuocCanSua_);
                _fMain.fNhaThuocEdit_ = new frmNhaThuocEdit(_fMain);
                _fMain.frmNhaThuocEditisOpen_ = true;

                _fMain.fNhaThuocEdit_.ShowDialog();
                return;
            }
            else if (_fMain.frmNhaThuocEditisOpen_ == true)
            {
                _fMain.fNhaThuocEdit_.Select();
                return;
            }
        }

        private void rgvNhaThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(_fMain.fNhaThuoc.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string nhathuoc = rgvNhaThuoc.CurrentRow.Cells["colTenNT"].Value.ToString();
                if (MessageBox.Show("Bạn có muốn xóa nhà thuốc " + nhathuoc.ToUpper() + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNhaThuoc xlnhathuoc = new CSQLNhaThuoc();
                    _fMain.MaNhaThuocCanXoa_ = rgvNhaThuoc.CurrentRow.Cells["colNTID"].Value.ToString();
                    int kq = xlnhathuoc.XoaThongTinNhaThuoc(_fMain.MaNhaThuocCanXoa_);
                    if (kq == 1)
                    {
                        rgvNhaThuoc.DataSource = xlnhathuoc.LayDanhSachNhaThuocLenLuoi(_fMain.IsXemTatCa_);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void rgvNhaThuoc_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = CColor.MauGVRow[1];
            }
        }

        private void rgvNhaThuoc_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NhaThuoc();
        }
    }
}
