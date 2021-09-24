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
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace ECOPharma2013
{
    public partial class frmDoiMatKhau : Form
    {
        frmMain _frmMain;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public frmDoiMatKhau(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            CSQLUser user_ = new CSQLUser();
            txtTK.Text = CStaticBien.StaiKhoan;
            txtMKht.Text = user_.LayMatKhauTheoMa(CStaticBien.SmaTaiKhoan).Rows[0]["Pass"].ToString(); ;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fDoiMatKhau_.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLUser user_ = new CSQLUser();
            if (txtMKmoi1.Text == txtMKmoi2.Text)
            {
                user_.SUserID = CStaticBien.SmaTaiKhoan;
                user_.SPass = txtMKmoi2.Text;
                int kq = user_.SuaMatKhau(user_);
                if (kq > 0)
                {
                    statusTB.Text = "Đổi mật khẩu thành công";
                }
                else
                {
                    statusTB.Text = "Đổi mật khẩu thất bại";
                }
            }
        }
    }
}
