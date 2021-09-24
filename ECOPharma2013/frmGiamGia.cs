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
    public partial class frmGiamGia : Form
    {
        private frmMain _fMain;
        CSQLGiamGia xlgiamgia = null;

        public frmGiamGia()
        {
            InitializeComponent();
        }
        public frmGiamGia(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }


        private void frmGiamGia_Load(object sender, EventArgs e)
        {
            xlgiamgia = new CSQLGiamGia();
            rgvGiamGia.DataSource =xlgiamgia.LayDanhSachGiamGiaLenLuoi(_fMain.IsXemTatCa_);
        }

        public void rgvGiamGia_DoubleClick(object sender, EventArgs e)
        {
            if (rgvGiamGia.CurrentRow.Cells["colGGID"].Value == null)
            {
                return;
            }
            _fMain.IsSuaGiamGia_ = true;
            if (_fMain.frmGiamGiaEditisOpen_ == false)
            {
                _fMain.MaGiamGiaCanSua_ = rgvGiamGia.CurrentRow.Cells["colGGID"].Value.ToString();
                _fMain.BangGiamGiaCanSua_ = xlgiamgia.LayGiamGiaTheoMa(_fMain.MaGiamGiaCanSua_);
                _fMain.fGiamGiaEdit_ = new frmGiamGiaEdit(_fMain);
                _fMain.frmGiamGiaEditisOpen_ = true;

                _fMain.fGiamGiaEdit_.ShowDialog();
                return;
            }
            else if (_fMain.frmGiamGiaEditisOpen_ == true)
            {
                _fMain.fGiamGiaEdit_.Select();
                return;
            }
        }

        private void rgvGiamGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(_fMain.fGiamGia.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string gg = rgvGiamGia.CurrentRow.Cells["colTenGG"].Value.ToString();
                if (MessageBox.Show("Bạn có  muốn xóa dữ liệu "+gg.ToUpper()+" không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLGiamGia xlgiamgia = new CSQLGiamGia();
                    _fMain.MaGiamGiaCanXoa_ = rgvGiamGia.CurrentRow.Cells["colGGID"].Value.ToString();
                    int kq = xlgiamgia.XoaThongTinGiamGia(_fMain.MaGiamGiaCanXoa_);
                    if (kq == 1)
                    {
                        rgvGiamGia.DataSource = xlgiamgia.LayDanhSachGiamGiaLenLuoi(_fMain.IsXemTatCa_);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void rgvGiamGia_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
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
