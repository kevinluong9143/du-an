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
    public partial class frmNT_NhanPhieuChuyen : Form
    {
        public frmNT_NhanPhieuChuyen()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmNT_NhanPhieuChuyen(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }

        private void frmNT_NhanPhieuChuyen_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            CSQLNT_NhanPhieuChuyen npc = new CSQLNT_NhanPhieuChuyen();
            try
            {
                rgvPhieuChuyen.DataSource = npc.LoadLenLuoi(fmain.IsXemTatCa_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void HienFormNhanPhieuChuyenEdit()
        {
            try
            {
                if (fmain.frmNT_ChuyenHangEditisOpen_ == true)
                {
                    fmain.fNT_NhanPhieuChuyenEdit.NhanCHID_SoPCH(rgvPhieuChuyen.CurrentRow.Cells["colNCHID"].Value.ToString(), rgvPhieuChuyen.CurrentRow.Cells["colSoPCH"].Value.ToString());
                    fmain.fNT_NhanPhieuChuyenEdit.Select();
                    return;
                }
                else
                {
                    fmain.fNT_NhanPhieuChuyenEdit = new frmNT_NhanPhieuChuyenEdit(fmain);
                    fmain.fNT_NhanPhieuChuyenEdit.NhanCHID_SoPCH(rgvPhieuChuyen.CurrentRow.Cells["colNCHID"].Value.ToString(), rgvPhieuChuyen.CurrentRow.Cells["colSoPCH"].Value.ToString());
                    fmain.fNT_NhanPhieuChuyenEdit.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rgvPhieuChuyen_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            HienFormNhanPhieuChuyenEdit();
        }
    }
}
