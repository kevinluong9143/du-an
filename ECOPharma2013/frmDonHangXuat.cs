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
    public partial class frmDonHangXuat : Form
    {
        frmMain fmain;
        public frmDonHangXuat(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        public void SelectRows_XuatKho()
        {
            if (rgvDSDonHangXuat.CurrentRow.Cells["colDHid"].Value == null)
            {
                return;
            }
            if (fmain.frmDonHangXuatEditisOpen_ == true)
            {
                fmain.fDonHangXuatEdit_.Select();
                return;
            }
            else
            {
                fmain.fDonHangXuatEdit_ = new frmDonHangXuatEdit(fmain);
                string sodh = rgvDSDonHangXuat.CurrentRow.Cells["colSoDHCHUNG"].Value.ToString();
                fmain.MaDonHangXuatCanSua_ = rgvDSDonHangXuat.CurrentRow.Cells["colDHid"].Value.ToString();
                if (sodh != null && sodh.Length > 0)
                    fmain.fDonHangXuatEdit_.txtSoDonHang.Text = sodh;
                fmain.fDonHangXuatEdit_.ShowDialog();
            }
        }

        private void frmDonHangXuat_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            CSQLDonHangXuat dhx = new CSQLDonHangXuat();
            rgvDSDonHangXuat.DataSource = dhx.LayDLLenLuoi(fmain.IsXemTatCa_);
        }
        public void rgvDonHangXuat_LayDLLenLuoi(DataTable bangDonHangXuat)
        {
            rgvDSDonHangXuat.DataSource = bangDonHangXuat;
        }

        public void rgvDSDonHangXuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fmain.fDonHangXuat.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string DHid = rgvDSDonHangXuat.CurrentRow.Cells["colDHid"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                    int kq = dhx.Xoa(DHid, CStaticBien.SmaTaiKhoan);
                    if (kq > 0)
                    {
                        rgvDSDonHangXuat.DataSource = dhx.LayDLLenLuoi(fmain.IsXemTatCa_);
                    }
                    else
                        MessageBox.Show("Xóa thất bại");
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                //SelectRows_XuatKho();
                HienFormDonHangXuatCT();
            }
        }

        private void rgvDSDonHangXuat_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //SelectRows_XuatKho();
            HienFormDonHangXuatCT();
        }

        public void HienFormDonHangXuatCT()
        {
            try
            {
                Fr_DangXuLy.ShowFormCho();
                if (rgvDSDonHangXuat.Rows.Count > 0)
                {
                    int currowindex = rgvDSDonHangXuat.CurrentRow.Index;
                    if (fmain.frmNT_DatHangEditisOpen_ == true)
                    {
                        fmain.fDonHangXuatEdit_.NhanThongTinTuFormDonHangXuat(rgvDSDonHangXuat.CurrentRow.Cells["colDHID"].Value.ToString(), rgvDSDonHangXuat.CurrentRow.Cells["colSoDHChung"].Value.ToString());
                        fmain.fDonHangXuatEdit_.Select();
                        return;
                    }
                    else
                    {
                        fmain.fDonHangXuatEdit_ = new frmDonHangXuatEdit(fmain);
                        fmain.fDonHangXuatEdit_.NhanThongTinTuFormDonHangXuat(rgvDSDonHangXuat.CurrentRow.Cells["colDHID"].Value.ToString(), rgvDSDonHangXuat.CurrentRow.Cells["colSoDHChung"].Value.ToString());
                        fmain.fDonHangXuatEdit_.ShowDialog();
                    }
                    rgvDSDonHangXuat.CurrentRow = rgvDSDonHangXuat.Rows[currowindex];
                }
                Fr_DangXuLy.DongFormCho();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
