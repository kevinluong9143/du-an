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
    public partial class frmNhomSP : Form
    {
        private frmMain _fMain;
        CSQLNhomSP LopCSQLNhomSP;

        public frmNhomSP(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        public void RefreshLuoiDSNhomSP()
        {
            rgvNhomSP.DataSource = LopCSQLNhomSP.LoadDSNhomSPLenLuoi(_fMain.IsXemTatCa_);
        }

        public void frmNhomSP_Load(object sender, EventArgs e)
        {
            LopCSQLNhomSP = new CSQLNhomSP();
            RefreshLuoiDSNhomSP();
        }

        public void rgvNhomSP_DoubleClick(object sender, EventArgs e)
        {
            if (rgvNhomSP.CurrentRow.Cells["colNSPID"].Value == null)
            {
                return;
            }
            _fMain.IsSuaNhomSP = true;

            if (_fMain.frmNhomSPEditisOpen_ == false)
            {
                _fMain.MaNhomSPCanSua_ = rgvNhomSP.CurrentRow.Cells["colNSPID"].Value.ToString();
                _fMain.BangNhomSPCanSua_ = LopCSQLNhomSP.LayNhomCanSua(_fMain.MaNhomSPCanSua_);
                _fMain.fNhomSPEdit_ = new frmNhomSPEdit(_fMain);
                _fMain.fNhomSPEdit_.Show();
                _fMain.frmNhomSPEditisOpen_ = true;
                return;
            }
            else if (_fMain.frmNhomSPEditisOpen_ == true)
            {
                _fMain.fNhomSPEdit_.Select();
                return;
            }
        }


        public void XoaNhomSP()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXoa(_fMain.fNhomSP_.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (rgvNhomSP.CurrentRow.Cells["colNSPID"].Value == null)
            {
                return;
            }

            _fMain.MaNhomSPCanSua_ = rgvNhomSP.CurrentRow.Cells["colNSPID"].Value.ToString();

            if (MessageBox.Show(this, "Nhóm sản phẩm này sẽ bị xóa! Nhấn YES để xóa, nhấn NO không xóa.", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //xóa hết cả cha và con
                string KQ = LopCSQLNhomSP.XoaNhomSP(_fMain.MaNhomSPCanSua_);
                if (KQ == "")
                {
                    MessageBox.Show("Xóa thành công !");
                }
                else
                    MessageBox.Show(KQ);
            }
        }
        private void rgvNhomSP_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete))
            {
                XoaNhomSP();
                frmNhomSP_Load(sender, e);
            }
        }
    }
}
