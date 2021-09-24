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
    public partial class frmPhanLoaiGia : Form
    {
        private frmMain _fMain;
        CSQLPhanLoaiGia xlphanloaigia = null;

        public frmPhanLoaiGia()
        {
            InitializeComponent();
        }
        public frmPhanLoaiGia(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }
        private void frmPhanLoaiGia_Load(object sender, EventArgs e)
        {
            xlphanloaigia = new CSQLPhanLoaiGia();
            rgvPhanLoaiGia.DataSource = xlphanloaigia.LayDanhSachPhanloaiGiaLenLuoi(_fMain.IsXemTatCa_);
        }

        public void rgvPhanLoaiGia_DoubleClick(object sender, EventArgs e)
        {
            if (rgvPhanLoaiGia.CurrentRow.Cells["colLGID"].Value == null)
            {
                return;
            }
            _fMain.IsSuaPhanLoaiGia_ = true;
            if (_fMain.frmPhanLoaiGiaEditisOpen_ == false)
            {
                _fMain.MaPhanLoaiGiaCanSua_ = rgvPhanLoaiGia.CurrentRow.Cells["colLGID"].Value.ToString();
                _fMain.BangPhanLoaiGiaCanSua_ = xlphanloaigia.LayPhanloaiGiaTheoMa(_fMain.MaPhanLoaiGiaCanSua_);
                _fMain.fPhanLoaiGiaEdit_ = new frmPhanLoaiGiaEdit(_fMain);
                _fMain.frmPhanLoaiGiaEditisOpen_ = true;

                _fMain.fPhanLoaiGiaEdit_.ShowDialog();
                return;
            }
            else if (_fMain.frmPhanLoaiGiaEditisOpen_ == true)
            {
                _fMain.fPhanLoaiGiaEdit_.Select();
                return;
            }
        }

        private void rgvPhanLoaiGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(_fMain.fPhanLoaiGia.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string plg = rgvPhanLoaiGia.CurrentRow.Cells["colTenLG"].Value.ToString();
                if (MessageBox.Show("Bạn có  muốn xóa dữ liệu "+plg.ToUpper()+" không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLPhanLoaiGia xlphanloaigia = new CSQLPhanLoaiGia();
                    _fMain.MaPhanLoaiGiaCanXoa_ = rgvPhanLoaiGia.CurrentRow.Cells["colLGID"].Value.ToString();
                    int kq = xlphanloaigia.XoaThongTinPhanloaiGia(_fMain.MaPhanLoaiGiaCanXoa_);
                    if (kq == 1)
                    {
                        rgvPhanLoaiGia.DataSource = xlphanloaigia.LayDanhSachPhanloaiGiaLenLuoi(_fMain.IsXemTatCa_);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void rgvPhanLoaiGia_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = CColor.MauGVRow[1];
            }
        }
    }
}
