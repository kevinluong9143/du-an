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
    public partial class frmBoPhan : Form
    {
        CSQLBoPhan LopCSQLBoPhan;
        private frmMain _fMain;
        

        //public frmBoPhanEdit fBoPhanEdit_;

        public frmBoPhan(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        public void frmBoPhan_Load(object sender, EventArgs e)
        {
            LopCSQLBoPhan = new CSQLBoPhan();
            rgvBoBan.DataSource= LopCSQLBoPhan.LoadDSBoPhanLenLuoi(_fMain.IsXemTatCa_);
        }

        public void SelectRows_BoPhan()
        {
            if (rgvBoBan.CurrentRow.Cells["colRecordBPCT"].Value == null)
            {
                return;
            }

            _fMain.IsSuaBoPhan_ = true;

            if (_fMain.frmBoPhanEditisOpen_ == false)
            {
                _fMain.MaBPCanSua_ = rgvBoBan.CurrentRow.Cells["colMaBP"].Value.ToString();
                _fMain.BangBoPhanCanSua_ = LopCSQLBoPhan.LayBoPhanCanSua(_fMain.MaBPCanSua_);
                _fMain.fBoPhanEdit_ = new frmBoPhanEdit(_fMain);
                _fMain.fBoPhanEdit_.Show();
                _fMain.frmBoPhanEditisOpen_ = true;
                return;
            }
            else if (_fMain.frmBoPhanEditisOpen_ == true)
            {
                _fMain.fBoPhanEdit_.Select();
                return;
            }
        }

        public void XoaBoPhan()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXoa(_fMain.fBoPhan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (rgvBoBan.CurrentRow.Cells["colRecordBPCT"].Value == null)
                {
                    return;
                }

                _fMain.MaBPCanSua_ = rgvBoBan.CurrentRow.Cells["colMaBP"].Value.ToString();
                if (LopCSQLBoPhan.KiemTraRangBuocTruocKhiXoa(_fMain.MaBPCanSua_)==true)//nghia là có bộ phận con tồn tài trong bộ phận cha này
                {
                    if (MessageBox.Show(this, "Bộ phận này có tồn tại Bộ phận con bên trong ! Nhấn YES để xóa cả Bộ phận cha và con, nhấn NO thì không xóa.", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //xóa hết cả cha và con
                        string KQ=LopCSQLBoPhan.XoaBoPhan(_fMain.MaBPCanSua_);
                        if ( KQ== "")
                        {
                            MessageBox.Show("Xóa thành công !");
                        }
                        else
                            MessageBox.Show(KQ);
                    }
                }
                else if (LopCSQLBoPhan.KiemTraRangBuocTruocKhiXoa(_fMain.MaBPCanSua_) == false)
                { 
                    //xóa một bộ phận này
                    string KQ = LopCSQLBoPhan.XoaBoPhan(_fMain.MaBPCanSua_);
                    if (KQ == "")
                    {
                        MessageBox.Show("Xóa thành công !");
                    }
                    else
                        MessageBox.Show(KQ);
                }
                //load lại danh sach bo phan len form
                //frmBoPhan_Load(sender, e);
        }

        private void rgvBoBan_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Delete))
            {
                XoaBoPhan();
                frmBoPhan_Load(sender, e);
            }
        }

        private void rgvBoBan_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_BoPhan();
        }
    }
}
