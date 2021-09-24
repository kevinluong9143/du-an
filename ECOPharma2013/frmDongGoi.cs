using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;

namespace ECOPharma2013
{
    public partial class frmDongGoi : Form
    {
        frmMain fmain;
        public frmDongGoi(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void frmDongGoi_Load(object sender, EventArgs e)
        {
            CSQLDongGoi dg = new CSQLDongGoi();
            dg.DoDuLieuTuKiemTraXuatSangDongGoi();
            rgvDongGoi.DataSource = dg.LayDSDongGoi(this.fmain.IsXemTatCa_);
        }
        public void RefreshRGVDongGoi()
        {
            CSQLDongGoi dg = new CSQLDongGoi();
            rgvDongGoi.DataSource = dg.LayDSDongGoi(fmain.IsXemTatCa_);
        }

        private void ToolStripMenuItemLamMoi_Click(object sender, EventArgs e)
        {
            fmain.fWaiting = new Fr_Waiting(fmain);
            fmain.fWaiting.Show();
            RefreshRGVDongGoi();
            fmain.KT = true;
        }

        private void rgvDongGoi_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_DongGoi();
        }

        public void SelectRows_DongGoi()
        {
            if (rgvDongGoi.CurrentRow.Cells["colDGid"].Value == null)
            {
                return;
            }
            if (fmain.frmDongGoiEditisOpen_ == true)
            {
                fmain.fDongGoiEdit_.Select();
                return;
            }
            else
            {
                fmain.fDongGoiEdit_ = new frmDongGoiEdit(fmain);

                //truyền dl sang form DongGoiCT
                fmain.fDongGoiEdit_._SoPX_SoDH(rgvDongGoi.CurrentRow.Cells[0].Value.ToString(), rgvDongGoi.CurrentRow.Cells[2].Value.ToString(), rgvDongGoi.CurrentRow.Cells[3].Value.ToString());
                fmain.fDongGoiEdit_.ShowDialog();
            }
        }

    }
}
