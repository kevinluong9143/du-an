using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;
using ECOPharma2013.SQL;

namespace ECOPharma2013
{
    public partial class frmPhanQuyen : Form
    {
        
        private frmMain _fMain;

        public frmPhanQuyen(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            try
            {
                CSQLQuyenTruyCap qtc = new CSQLQuyenTruyCap();
                rgvPhanQuyen.DataSource = qtc.LoadLenLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rgvPhanQuyen_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            HienFormChiTiet();
        }

        public void HienFormChiTiet()
        {
            try
            {
                if (_fMain.frmPhanLoaiGiaEditisOpen_ == true)
                {
                    _fMain.fPhanQuyenEdit_.Select();
                    return;
                }
                else if (_fMain.frmPhanLoaiGiaEditisOpen_ == false)
                {
                    _fMain.fPhanQuyenEdit_ = new frmPhanQuyenEdit(_fMain);
                    _fMain.fPhanQuyenEdit_.NhanThongTinTuMaster(rgvPhanQuyen.CurrentRow.Cells["colNhomNDID"].Value.ToString(), rgvPhanQuyen.CurrentRow.Cells["colMenuID"].Value.ToString());
                    _fMain.frmPhanQuyenEditisOpen_ = true;
                    _fMain.fPhanQuyenEdit_.ShowDialog();
                }
            }
            catch { }
        }
    }
}
