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
    public partial class frmDonHangMua : Form
    {
        public frmDonHangMua()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmDonHangMua(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void frmDonHangMua_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            CSQLDonHangMua dhm = new CSQLDonHangMua();
            try 
            {
                rgvDSDHMua.DataSource = dhm.LoadLenLuoi(fmain.IsXemTatCa_);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi phát sinh khi lấy DS đơn hàng mua: \n" + ex.Message);
            }
        }

        private void rgvDSDHMua_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            HienFormChiTiet();
        }

        public void HienFormChiTiet()
        {
            if (rgvDSDHMua.CurrentRow != null)
            {
                if (fmain.frmDonHangMuaEditisOpen_ == true)
                {
                    fmain.fDonHangMuaEdit.Select();
                }
                else
                {
                    fmain.fDonHangMuaEdit = new frmDonHangMuaEdit(fmain);
                    fmain.fDonHangMuaEdit.NhanThongTin(rgvDSDHMua.CurrentRow.Cells["colPNID"].Value.ToString(), rgvDSDHMua.CurrentRow.Cells["colSoDHMua"].Value.ToString());
                    fmain.fDonHangMuaEdit.Show();
                }
            }
        }
    }
}
