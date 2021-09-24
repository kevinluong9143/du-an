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
    public partial class frmHoatChat : Form
    {
        frmMain fmain;
        public frmHoatChat(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        public void rgvHoatChat_DoubleClick(object sender, EventArgs e)
        {
            try {
                if (rgvHoatChat.Rows.Count>0 && rgvHoatChat.CurrentRow.Cells["colHCID"].Value == null)
                {
                    return;
                }
                CSQLHoatChat hc = new CSQLHoatChat();
                fmain.IsSuaHoatChat_ = true;
                if (fmain.frmHoatChatEditisOpen_ == false)
                {
                    fmain.MaHoatChatCanSua_ = rgvHoatChat.CurrentRow.Cells["colHCID"].Value.ToString();
                    fmain.BangHoatChatCanSua_ = hc.LayHoatChatTheoMa(fmain.MaHoatChatCanSua_);
                    fmain.frmHoatChatEditisOpen_ = true;
                    fmain.fHoatChatEdit_ = new frmHoatChatEdit(fmain);
                    fmain.fHoatChatEdit_.ShowDialog();
                    return;
                }
                else if (fmain.frmHoatChatEditisOpen_ == true)
                {
                    fmain.fHoatChatEdit_.Select();
                    return;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void frmHoatChat_Load(object sender, EventArgs e)
        {
            try {

                CSQLHoatChat hc = new CSQLHoatChat();
                rgvHoatChat.DataSource = hc.LayHoatChatLenLuoi(fmain.IsXemTatCa_);
            }
            catch (Exception Exception) { throw Exception; }
        }

        private void rgvHoatChat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenXoa(fmain.fHoatChat.Name) == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    this.fmain.MaHoatChatCanSua_ = rgvHoatChat.CurrentRow.Cells["colHCID"].Value.ToString();
                    if (MessageBox.Show("Bạn có thực sự muốn xóa hoạt chất có mã: ['" + this.fmain.MaHoatChatCanSua_ + "']?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CSQLHoatChat xlhc = new CSQLHoatChat();
                        int kq = xlhc.XoaHoatChat(this.fmain.MaHoatChatCanSua_);
                        if (kq == 1)
                            rgvHoatChat.DataSource = xlhc.LayHoatChatLenLuoi(this.fmain.IsXemTatCa_);
                        else
                            MessageBox.Show("Xóa thông tin hoạt chất: ['" + this.fmain.MaHoatChatCanSua_ + "'] thất bại!");
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    rgvHoatChat_DoubleClick(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rgvHoatChat_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
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
