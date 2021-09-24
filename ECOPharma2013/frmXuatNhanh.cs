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
    public partial class frmXuatNhanh : Form
    {
        public frmXuatNhanh()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmXuatNhanh(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void frmXuatNhanh_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            try
            {
                CSQLXuatNhanh xn = new CSQLXuatNhanh();
                radGridView1.DataSource = xn.LoadLenLuoi(fmain.IsXemTatCa_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            HienFormXuatNhanhEdit();
        }
        public void HienFormXuatNhanhEdit()
        {
            try
            {
                if (radGridView1.Rows.Count > 0)
                {
                    if (fmain.frmXuatNhanhEditisOpen_ == true)
                    {
                        fmain.fXuatNhanhEdit_.NhanThongTinXuatNhanh(radGridView1.CurrentRow.Cells["colXNID"].Value.ToString(), radGridView1.CurrentRow.Cells["colSoPXN"].Value.ToString());
                        fmain.fXuatNhanhEdit_.Select();
                        return;
                    }
                    else
                    {
                        fmain.fXuatNhanhEdit_ = new frmXuatNhanhEdit(fmain);
                        fmain.fXuatNhanhEdit_.NhanThongTinXuatNhanh(radGridView1.CurrentRow.Cells["colXNID"].Value.ToString(), radGridView1.CurrentRow.Cells["colSoPXN"].Value.ToString());
                        fmain.fXuatNhanhEdit_.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (radGridView1.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenXoa(fmain.fXuatNhanh.Name) == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }

                    if (MessageBox.Show("Bạn có thực sự muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CSQLXuatNhanh xn = new CSQLXuatNhanh();
                        int kq = xn.Xoa(radGridView1.CurrentRow.Cells["colXNID"].Value.ToString(), CStaticBien.SmaTaiKhoan);
                        if (kq > 0)
                            LoadLenLuoi();
                        else
                        {
                            MessageBox.Show("Chưa xóa được thông tin xuất nhanh");
                        }
                    }
                }
            }
        }
    }
}
