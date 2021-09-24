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
    public partial class frmUser : Form
    {
        frmMain _frmMain;
        public frmUser()
        {
            InitializeComponent();
        }

        public frmUser(frmMain fMain)
        {
            InitializeComponent();
            _frmMain = fMain;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            CSQLUser user_ = new CSQLUser();
            rgvUser.DataSource = user_.LayDSUserLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void rgvUser_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_User();
        }
        public void SelectRows_User()
        {
            CSQLUser user_ = new CSQLUser();
            if (rgvUser.CurrentRow.Cells["colUserID"].Value == null)
            {
                return;
            }
            if (_frmMain.frmUserEditisOpen_ == false)
            {
                _frmMain.MaUserCanSua_ = rgvUser.CurrentRow.Cells["colUserID"].Value.ToString();
                _frmMain.BangUserCanSua_ = user_.LayMatKhauTheoMa(_frmMain.MaUserCanSua_);
                _frmMain.fUserEdit_ = new frmUserEdit(_frmMain);
                _frmMain.frmUserEditisOpen_ = true;
                _frmMain.fUserEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmUserEditisOpen_ == true)
            {
                _frmMain.fUserEdit_.Select();
                return;
            }
        }
    }
}
