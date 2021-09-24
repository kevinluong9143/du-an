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
using Telerik.WinControls.UI;

namespace ECOPharma2013
{
    public partial class frmBangDanhMuc : Form
    {
        frmMain _frmMain;
        public frmBangDanhMuc()
        {
            InitializeComponent();
        }
        public frmBangDanhMuc(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        CSQLBangDanhMuc bdm_ = new CSQLBangDanhMuc();
        private void frmBangDanhMuc_Load(object sender, EventArgs e)
        {
            if (bdm_.LayDanhSachLenLuoi() != null && bdm_.LayDanhSachLenLuoi().Rows.Count > 0)
            {
                rgvBangDM.DataSource = bdm_.LayDanhSachLenLuoi();
            }

        }
        public void addnewrow()
        {
            CSQLBangDanhMuc bdm_ = new CSQLBangDanhMuc();
            bdm_.Stenbang = rgvBangDM.CurrentRow.Cells[0].Value.ToString();
            bdm_.Smota = rgvBangDM.CurrentRow.Cells[1].Value.ToString();
            int maquantrave = bdm_.ThemMoi(bdm_);
            if (maquantrave > 0)
            {
                rgvBangDM.DataSource = bdm_.LayDanhSachLenLuoi();
                toolStripStatusThongBaoLoi.Text = "Thêm thành công.";
            }

        }
        private void rgvBangDM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //Khi row đang nằm chỗ thêm mới
                if (rgvBangDM.CurrentColumn.Index == 0)
                {
                    if (rgvBangDM.CurrentRow.Cells[0].Value == null)
                    {
                        toolStripStatusThongBaoLoi.Text = "Vui lòng nhập tên bảng";
                        rgvBangDM.CurrentRow.IsSelected = true;
                        rgvBangDM.CurrentRow.Cells[0].IsSelected = true;
                        rgvBangDM.CurrentRow.Cells[0].BeginEdit();

                    }
                    else
                    {
                        toolStripStatusThongBaoLoi.Text = "";
                        rgvBangDM.CurrentRow.IsSelected = true;
                        rgvBangDM.CurrentRow.Cells[1].IsSelected = true;
                        rgvBangDM.CurrentRow.Cells[1].BeginEdit();
                    }
                }
                //Xử lý Kho xuất
                else
                {
                    if (rgvBangDM.CurrentRow.Cells[1].Value == null)
                    {
                        toolStripStatusThongBaoLoi.Text = "Vui lòng chọn kho xuất";
                        rgvBangDM.CurrentRow.IsSelected = true;
                        rgvBangDM.CurrentRow.Cells[1].IsSelected = true;
                        rgvBangDM.CurrentRow.Cells[1].BeginEdit();

                    }
                    else
                    {
                        addnewrow();
                        rgvBangDM.CurrentRow.Cells[0].Value = "";
                        rgvBangDM.CurrentRow.Cells[1].Value = "";
                    }
                }
            }
        }
        private void rgvBangDM_UserAddedRow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {
            int a = rgvBangDM.Rows.Count;
            GridViewRowInfo row = rgvBangDM.Rows[a - 1];
            rgvBangDM.Rows.Remove(row);

            rgvBangDM.CurrentRow.IsSelected = true;
            rgvBangDM.CurrentRow.Cells[0].IsSelected = true;
            rgvBangDM.CurrentRow.Cells[0].BeginEdit();
            toolStripStatusThongBaoLoi.Text = "Xin vui lòng nhập lại";
        }
    }
}
