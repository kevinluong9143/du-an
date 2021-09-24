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
using Telerik.WinControls;

namespace ECOPharma2013
{
    public partial class frmKho : Form
    {
        private frmMain _fMain;
        CSQLKho xlkho = null;

        public frmKho()
        {
            InitializeComponent();
        }
        public frmKho(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            xlkho = new CSQLKho();
            rgvKho.DataSource = xlkho.LayDanhSachKhoLenLuoi(_fMain.IsXemTatCa_);
        }

        public void rgvKho_DoubleClick(object sender, EventArgs e)
        {
            if (rgvKho.CurrentRow.Cells["colKhoID"].Value == null)
            {
                return;
            }
            _fMain.IsSuaKho_ = true;
            if (_fMain.frmKhoEditisOpen_ == false)
            {
                _fMain.MaKhoCanSua_ = rgvKho.CurrentRow.Cells["colKhoID"].Value.ToString();
                _fMain.BangKhoCanSua_ = xlkho.LayKhoTheoMa(_fMain.MaKhoCanSua_);
                _fMain.fKhoEdit_ = new frmKhoEdit(_fMain);
                _fMain.frmKhoEditisOpen_ = true;

                _fMain.fKhoEdit_.ShowDialog();
                return;
            }
            else if (_fMain.frmGiamGiaEditisOpen_ == true)
            {
                _fMain.fGiamGiaEdit_.Select();
                return;
            }
        }

        private void rgvKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                string kho = rgvKho.CurrentRow.Cells["colTenKho"].Value.ToString();
                if (MessageBox.Show("Bạn có  muốn xóa kho "+ kho.ToUpper() +" không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLKho xlkho = new CSQLKho();
                    _fMain.MaKhoCanXoa_ = rgvKho.CurrentRow.Cells["colKhoID"].Value.ToString();
                    int kq = xlkho.XoaThongTinKho(_fMain.MaKhoCanXoa_);
                    if (kq == 1)
                    {
                        rgvKho.DataSource = xlkho.LayDanhSachKhoLenLuoi(_fMain.IsXemTatCa_);
                    }
                }
                else
                {
                    return;
                }
            }
           
        }

        private void rgvKho_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
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
