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
    public partial class frmSanPham : Form
    {
        private frmMain _fMain;
        CSQLSanPham LopCSQLSanPham;
        public frmSanPham(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        public void RefreshLuoiDSSanPham()
        {
            try
            {
                rgvSanPham.DataSource = LopCSQLSanPham.LoadDSSanPhamLenLuoi(_fMain.IsXemTatCa_);
            }
            catch { }
        }
        public void frmSanPham_Load(object sender, EventArgs e)
        {
            LopCSQLSanPham = new CSQLSanPham();
            RefreshLuoiDSSanPham();
        }

        public void SelectRows_SanPham()
        {
            if (rgvSanPham.CurrentRow.Cells["colSPID"].Value == null)
            {
                return;
            }
            _fMain.IsSuaSanPham_ = true;

            if (_fMain.frmSanPhamEditisOpen_ == false)
            {
                _fMain.MaSPCanSua_ = rgvSanPham.CurrentRow.Cells["colSPID"].Value.ToString();
                _fMain.ChonMaSP_ = rgvSanPham.CurrentRow.Index;
                _fMain.BangSanPhamCanSua_ = LopCSQLSanPham.LaySanPhamCanSua(_fMain.MaSPCanSua_);
                _fMain.fSanPhamEdit_ = new frmSanPhamEdit(_fMain);
                _fMain.fSanPhamEdit_.Show();
                _fMain.frmSanPhamEditisOpen_ = true;
                return;
            }
            else if (_fMain.frmSanPhamEditisOpen_ == true)
            {
                _fMain.fSanPhamEdit_.Select();
                return;
            }
        }

        public void XoaSanPham()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXoa(_fMain.fSanPham.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (rgvSanPham.CurrentRow.Cells["colSPID"].Value == null)
            {
                return;
            }

            _fMain.MaSPCanSua_ = rgvSanPham.CurrentRow.Cells["colSPID"].Value.ToString();

            if (MessageBox.Show(this, "Sản Phẩm này sẽ bị xóa! Nhấn YES để xóa, nhấn NO không xóa.", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string KQ = LopCSQLSanPham.XoaSanPham(_fMain.MaSPCanSua_);
                if (KQ == "")
                {
                    MessageBox.Show("Xóa thành công !");
                }
                else
                {
                    MessageBox.Show("Đối tượng đã tồn tại trong các nghiệp vụ khác. Không thể xóa!","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
        private void rgvSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete))
            {
                XoaSanPham();
                frmSanPham_Load(sender, e);
            }
        }
        
        private void ExportToExcel_SP_Click(object sender, EventArgs e)
        {
            //CSQLSanPham sp_ = new CSQLSanPham();
            //DataTable dtb = sp_.LoadDSSanPhamLenLuoi(_fMain.IsXemTatCa_);
            //ExporttoExcel export = new ExporttoExcel();
            //bool kq = export.exportDataToExcel("ECO Pharmacy", "Date Extracted :", dtb);
            //if (kq == true)
            //{
            //    MessageBox.Show("Dữ liệu đã xuất.", "Thông Báo");
            //}
            //else
            //    MessageBox.Show("Fail");
        }

        private void rgvSanPham_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_SanPham();
        }
    }
}
