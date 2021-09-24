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
    public partial class frmDBC : Form
    {
        private frmMain _fMain;
        CSQLDBC xldbc = null;
        public frmDBC()
        {
            InitializeComponent();
        }
        public frmDBC(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        private void frmDBC_Load(object sender, EventArgs e)
        {
            xldbc = new CSQLDBC();
            rgvDBC.DataSource = xldbc.LayDanhSachDBCLenLuoi(_fMain.IsXemTatCa_);
        }

        public void SelectRows_DBC()
        {
            if (rgvDBC.CurrentRow.Cells["colDBCID"].Value == null)
            {
                return;
            }
            _fMain.IsSuaDBC_ = true;
            if (_fMain.frmDBCEditisOpen_ == false)
            {
                _fMain.MaDBCCanSua_ = rgvDBC.CurrentRow.Cells["colDBCID"].Value.ToString();
                _fMain.BangDBCCanSua_ = xldbc.LayDBCTheoMa(_fMain.MaDBCCanSua_);
                _fMain.fDBCEdit_ = new frmDBCEdit(_fMain);
                _fMain.frmDBCEditisOpen_ = true;

                _fMain.fDBCEdit_.ShowDialog();
                return;
            }
            else if (_fMain.frmDBCEditisOpen_ == true)
            {
                _fMain.fDBCEdit_.Select();
                return;
            }
        }

        private void rgvDBC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(_fMain.fDBC.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string dbc = rgvDBC.CurrentRow.Cells["colTenDBC"].Value.ToString();
                if (MessageBox.Show("Bạn có  muốn xóa dạng bào chế  " + dbc.ToUpper() +" không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLDBC xldbc = new CSQLDBC();
                    _fMain.MaDBCCanXoa_ = rgvDBC.CurrentRow.Cells["colDBCID"].Value.ToString();
                    int kq = xldbc.XoaThongTinDBC(_fMain.MaDBCCanXoa_);
                    if (kq == 1)
                    {
                        rgvDBC.DataSource = xldbc.LayDanhSachDBCLenLuoi(_fMain.IsXemTatCa_);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void rgvDBC_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = CColor.MauGVRow[1];
            }
        }

        private void rgvDBC_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_DBC();
        }

        

        
    }
}
