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
    public partial class frmDVT : Form
    {
        private frmMain _fMain;
        CSQLDonViTinh LopCSQLDVT;
        public frmDVT(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        public void RefreshLuoiDSDVT()
        {
            rgvDVT.DataSource = LopCSQLDVT.LoadDSDVTLenLuoi(_fMain.IsXemTatCa_);
        }

        public void frmDVT_Load(object sender, EventArgs e)
        {
            LopCSQLDVT = new CSQLDonViTinh();
            RefreshLuoiDSDVT();
        }

        public void rgvDVT_DoubleClick(object sender, EventArgs e)
        {
            if (rgvDVT.CurrentRow.Cells["colDVTID"].Value == null)
            {
                return;
            }
            _fMain.IsSuaDVT_ = true;

            if (_fMain.frmDVTEditisOpen_ == false)
            {
                _fMain.MaDVTCanSua_ = rgvDVT.CurrentRow.Cells["colDVTID"].Value.ToString();
                _fMain.BangDVTCanSua_ = LopCSQLDVT.LayDVTCanSua(_fMain.MaDVTCanSua_);
                _fMain.fDVTEdit_ = new frmDVTEdit(_fMain);
                _fMain.fDVTEdit_.Show();
                _fMain.frmDVTEditisOpen_ = true;
                return;
            }
            else if (_fMain.frmDVTEditisOpen_ == true)
            {
                _fMain.fDVTEdit_.Select();
                return;
            }
        }

        public void XoaDVT()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXoa(_fMain.fDVT.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (rgvDVT.CurrentRow.Cells["colDVTID"].Value == null)
            {
                return;
            }

            _fMain.MaDVTCanSua_ = rgvDVT.CurrentRow.Cells["colDVTID"].Value.ToString();

                if (MessageBox.Show(this, "Đơn vị tính này sẽ bị xóa! Nhấn YES để xóa, nhấn NO không xóa.", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //xóa hết cả cha và con
                    string KQ = LopCSQLDVT.XoaDVT(_fMain.MaDVTCanSua_);
                    if (KQ == "")
                    {
                        MessageBox.Show("Xóa thành công !");
                    }
                    else
                        MessageBox.Show(KQ);
                }
        }

        private void rgvDVT_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete))
            {
                XoaDVT();
                frmDVT_Load(sender, e);
            }
        }
    }
}
