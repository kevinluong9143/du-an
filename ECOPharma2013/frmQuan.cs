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
    public partial class frmQuan : Form
    {
        frmMain _frmMain;
        CSQLQuan xlquan = null;
        //public frmQuan()
        //{
        //    InitializeComponent();
        //}

        public frmQuan(frmMain frmmain)
        {
            InitializeComponent();
            _frmMain = frmmain;
        }

        private void frmQuan_Load(object sender, EventArgs e)
        {
            xlquan = new CSQLQuan();
            rgvQuan.DataSource = xlquan.LayDanhSachQuanLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void rgvQuan_DoubleClick(object sender, EventArgs e)
        {
            if (rgvQuan.CurrentRow.Cells["colQuanID"].Value == null)
            {
                return;
            }
            _frmMain.IsSuaQuan_ = true;
            if (_frmMain.frmQuanEditisOpen_ == false)
            {
                _frmMain.MaQuanCanSua_ = rgvQuan.CurrentRow.Cells["colQuanID"].Value.ToString();
                _frmMain.BangQuanCanSua_ = xlquan.LayQuanTheoMa(_frmMain.MaQuanCanSua_);
                _frmMain.fQuanEdit_ = new frmQuanEdit(_frmMain);                
                _frmMain.frmQuanEditisOpen_ = true;
                _frmMain.fQuanEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmQuanEditisOpen_ == true)
            {
                _frmMain.fQuanEdit_.Select();
                return;
            }               
        }

        private void rgvQuan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(_frmMain.fQuan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this._frmMain.MaQuanCanSua_ = rgvQuan.CurrentRow.Cells["colQuanID"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Quận có mã: ['" + this._frmMain.MaQuanCanSua_ + "']?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLQuan xlq = new CSQLQuan();
                    int kq = xlq.XoaThongTinQuan(this._frmMain.MaQuanCanSua_);
                    if (kq == 1)
                        rgvQuan.DataSource = xlq.LayDanhSachQuanLenLuoi(this._frmMain.IsXemTatCa_);
                    else
                        MessageBox.Show("Xóa thông tin Quận: ['" + this._frmMain.MaQuanCanSua_ + "'] thất bại!");
                }
            }
        }

        private void rgvQuan_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
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
