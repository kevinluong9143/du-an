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

namespace ECOPharma2013
{
    public partial class frmHeSoQuiDoi : Form
    {
        frmMain _frmMain;
        public frmHeSoQuiDoi(frmMain fmain)
        {
            InitializeComponent();
            _frmMain = fmain;
        }

        public void SelectRows_HSQD(object sender, EventArgs e)
        {
            if (rgvDSHSQD.CurrentRow.Cells["colHSQDid"].Value == null)
            {
                return;
            }
            CSQLHeSoQuyDoi nv = new CSQLHeSoQuyDoi();
            _frmMain.IsSuaHeSoQuiDoi = true;
            if (_frmMain.frmHeSoQuiDoiEditisOpen_ == false)
            {
                _frmMain.MaHeSoQuyDoiCanSua_ = rgvDSHSQD.CurrentRow.Cells["colHSQDid"].Value.ToString();

                _frmMain.frmHeSoQuiDoiEditisOpen_ = true;
                _frmMain.fHeSoQuiDoiEdit_ = new frmHeSoQuiDoiEdit(_frmMain);
                _frmMain.fHeSoQuiDoiEdit_.LaySPIDTuFormKhac(rgvDSHSQD.CurrentRow.Cells["colSPid"].Value.ToString(), sender, e);
                _frmMain.fHeSoQuiDoiEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmHeSoQuiDoiEditisOpen_ == true)
            {
                _frmMain.fHeSoQuiDoiEdit_.Select();
                return;
            }
        }

        private void frmHeSoQuiDoi_Load(object sender, EventArgs e)
        {
            CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
            rgvDSHSQD.DataSource = hsqd.LayLenLuoi();
        }

        public void rgvDSHSQD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(_frmMain.fHeSoQuiDoi.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                CSQLHeSoQuyDoi xlhsqd = new CSQLHeSoQuyDoi();
                _frmMain.MaHeSoQuyDoiCanSua_ = rgvDSHSQD.CurrentRow.Cells[0].Value.ToString();
                if (xlhsqd.KiemTraSPTonKho(rgvDSHSQD.CurrentRow.Cells[1].Value.ToString()) == 0)
                {
                    if (xlhsqd.CapHeSoQuiDoiLonNhat(rgvDSHSQD.CurrentRow.Cells[1].Value.ToString()).CompareTo(_frmMain.MaHeSoQuyDoiCanSua_) == 0)
                    {
                        _frmMain.MaHeSoQuyDoiCanSua_ = rgvDSHSQD.CurrentRow.Cells[0].Value.ToString();
                        if (MessageBox.Show("Bạn có thực sự muốn xóa hệ số qui đổi có mã: ['" + _frmMain.MaHeSoQuyDoiCanSua_ + "']?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int kq = xlhsqd.Xoa(_frmMain.MaHeSoQuyDoiCanSua_);
                            if (kq == 1)
                            {
                                _frmMain.MaHeSoQuyDoiCanSua_ = "";
                                _frmMain.fHeSoQuiDoi.rgvDSHSQD.DataSource = xlhsqd.LayLenLuoi();
                                _frmMain.fHeSoQuiDoi.rgvDSHSQD.CurrentRow = null;
                            }
                            else
                                MessageBox.Show("Xóa hệ số qui đổi: ['" + _frmMain.MaHeSoQuyDoiCanSua_ + "'] thất bại!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Để đảm bảo logic, không thể xóa hệ số quy đổi này.");
                    }
                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã lưu trong bảng tồn kho, không thể xóa!");
                }
            }
        }

        private void rgvDSHSQD_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_HSQD(sender, e);
        }
    }
}
