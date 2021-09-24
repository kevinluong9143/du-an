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
    public partial class frmNhaPhanPhoi : Form
    {
        frmMain fmain;
        public frmNhaPhanPhoi(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

       public void SelectRows_NPP()
       {
           if (rgvNPP.CurrentRow.Cells["colNPPID"].Value == null)
           {
               return;
           }
           CSQLNPP npp = new CSQLNPP();
           fmain.IsSuaNhanVien = true;
           if (fmain.frmNhaPhanPhoiEditisOpen_ == false)
           {
               fmain.MaNhaPhanPhoiCanSua_ = rgvNPP.CurrentRow.Cells["colNPPID"].Value.ToString();
               fmain.BangNhaPhanPhoiCanSua_ = npp.LayNPPTheoMa(fmain.MaNhaPhanPhoiCanSua_);
               fmain.frmNhaPhanPhoiEditisOpen_ = true;
               fmain.fNhaPhanPhoiEdit_ = new frmNhaPhanPhoiEdit(fmain);
               fmain.fNhaPhanPhoiEdit_.ShowDialog();
               return;
           }
           else if (fmain.frmNhaPhanPhoiEditisOpen_ == true)
           {
               fmain.fNhaPhanPhoiEdit_.Select();
               return;
           }
       }

        private void frmNhaPhanPhoi_Load(object sender, EventArgs e)
        {
            CSQLNPP npp = new CSQLNPP();
            rgvNPP.DataSource = npp.LayNPPLenLuoi(fmain.IsXemTatCa_);
        }

        private void rgvNPP_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = CColor.MauGVRow[1];
            }
        }

        private void rgvNPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fmain.fNhaPhanPhoi.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.fmain.MaNhaPhanPhoiCanSua_ = rgvNPP.CurrentRow.Cells["colNPPID"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa nhà phân phối có mã: ['" + this.fmain.MaNhaPhanPhoiCanSua_ + "']?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNPP xlnpp = new CSQLNPP();
                    int kq = xlnpp.XoaNPP(this.fmain.MaNhaPhanPhoiCanSua_);
                    if (kq == 1)
                        rgvNPP.DataSource = xlnpp.LayNPPLenLuoi(this.fmain.IsXemTatCa_);
                    else
                        MessageBox.Show("Xóa thông tin nhà phân phối: ['" + this.fmain.MaNhaPhanPhoiCanSua_ + "'] thất bại!");
                }
            }
        }

        private void rgvNPP_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NPP();
        }
    }
}
