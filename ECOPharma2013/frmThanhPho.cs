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
    public partial class frmThanhPho : Form
    {
        frmMain frmMain;
        public frmThanhPho(frmMain _frmMain)
        {
            InitializeComponent();
            frmMain = _frmMain;
        }

        private void frmThanhPho_Load(object sender, EventArgs e)
        {
            try
            {
                CSQLThanhPho xlthanhpho = new CSQLThanhPho();
                this.rgvThanhPho.DataSource = xlthanhpho.LayThongTinThanhPho(frmMain.IsXemTatCa_);
            }
            catch (Exception ex) { throw ex; }
        }

        private void rgvThanhPho_DoubleClick(object sender, EventArgs e)
        {
            if (rgvThanhPho.CurrentRow.Cells["colTPID"].Value == null)
            {
                return;
            }
            CSQLThanhPho tp = new CSQLThanhPho();
            frmMain.IsSuaThanhPho = true;
            if (frmMain.frmThanhPhoEditisOpen_ == false)
            {
                frmMain.MaThanhPhoCanSua_ = rgvThanhPho.CurrentRow.Cells["colTPID"].Value.ToString();
                frmMain.BangThanhPhoCanSua_ = tp.LayThongTinThanhPhoTheoMa(frmMain.MaThanhPhoCanSua_);
                frmMain.fThanhPhoEdit_ = new frmThanhPhoEdit(frmMain);
                frmMain.frmThanhPhoEditisOpen_ = true;
                frmMain.fThanhPhoEdit_.ShowDialog();
                return;
            }
            else if (frmMain.frmThanhPhoEditisOpen_ == true)
            {
                frmMain.fThanhPhoEdit_.Select();
                return;
            } 
        }

        private void rgvThanhPho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(frmMain.fThanhPho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.frmMain.MaThanhPhoCanSua_ = rgvThanhPho.CurrentRow.Cells["colTPID"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa thành phố có mã: ['" + this.frmMain.MaThanhPhoCanSua_ + "']?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLThanhPho xl = new CSQLThanhPho();
                    int kq = xl.XoaThanhPho(this.frmMain.MaThanhPhoCanSua_);
                    if (kq == 1)
                        rgvThanhPho.DataSource = xl.LayThongTinThanhPho(this.frmMain.IsXemTatCa_);
                    else
                        MessageBox.Show("Xóa thông tin thành phố: ['" + this.frmMain.MaThanhPhoCanSua_ + "'] thất bại!");
                }
            }
        }

        private void rgvThanhPho_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = CColor.MauGVRow[1];
            }
        }

    }
}
