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
    public partial class frmNT_BanHang : Form
    {
        frmMain fmain;
        public frmNT_BanHang(frmMain _fMain)
        {
            InitializeComponent();
            fmain = _fMain;
        }

        private void frmNT_BanHang_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            CSQLNT_BanHang bh = new CSQLNT_BanHang();
            rgvDSPhieuBanHang.DataSource = bh.LayLenLuoi(fmain.IsXemTatCa_, CStaticBien.STenMayThuNgan);
        }

        public void SelectRows_NTBanHang()
        {
            if (rgvDSPhieuBanHang.CurrentRow.Cells["colBHid"].Value == null)
            {
                return;
            }
            if (fmain.frmNT_BanHangEditisOpen_ == true)
            {
                fmain.fNT_BanHangEdit_.Select();
                return;
            }
            else
            {
                fmain.fNT_BanHangEdit_ = new frmNT_BanHangEdit(fmain);
                fmain.BHID_NT_BanHang_ = rgvDSPhieuBanHang.CurrentRow.Cells["colBHid"].Value.ToString();
                fmain.SoPhieuNT_BanHang_ = rgvDSPhieuBanHang.CurrentRow.Cells["colSoCT"].Value.ToString();
                fmain.fNT_BanHangEdit_.ShowDialog();
            }
        }
        public void RefreshRGVBanHang()
        {
            CSQLNT_BanHang bh = new CSQLNT_BanHang();
            rgvDSPhieuBanHang.DataSource = bh.LayLenLuoi(fmain.IsXemTatCa_, CStaticBien.STenMayThuNgan);
        }

        private void inPhiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rgvDSPhieuBanHang_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NTBanHang();
        }
    }
}
