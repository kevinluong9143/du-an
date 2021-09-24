using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.DuLieu;
using ECOPharma2013.SQL;


namespace ECOPharma2013
{
    public partial class frmDangNhap : Form
    {
        
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public frmMain fMain;
        public frmDangNhap(frmMain fmain)
        {
            InitializeComponent();
            fMain = fmain;
        }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblTBTK.Text = "";
            lblTBMK.Text = "";
            CSQLDangNhap LopDN = new CSQLDangNhap();
            string TK = txtTK.Text.Trim();
            if (TK == "")
            {
                lblTBTK.Text = "Tài khoản không hợp lệ !";
                MessageBox.Show("Tài khoản không hợp lệ !");
                txtTK.Focus();
                return;
            }
            string MK = txtMK.Text.Trim();
            DataTable TableTimTK = new DataTable();
            TableTimTK = LopDN.KiemTraTK(TK);
            if (TableTimTK.Rows.Count <= 0)
            {
                lblTBTK.Text = "Tài khoản không hợp lệ !";
                MessageBox.Show("Tài khoản không hợp lệ !");
                txtTK.Focus();
                return;
            }

            DataTable TableTimMK = new DataTable();
            TableTimMK = LopDN.KiemTraMK(TK, MK);
            if (TableTimMK.Rows.Count <= 0)
            {
                lblTBMK.Text = "Mật khẩu không hợp lệ !";
                MessageBox.Show("Mật khẩu không hợp lệ !");
                txtMK.Focus();
                return;
            }

            //nếu chạy duoc toi day nghia ma TK va MK da hop le
            CStaticBien.StaiKhoan = TK;
            CStaticBien.SmatKhau = MK;
            CStaticBien.SNVid = TableTimMK.Rows[0]["NVID"].ToString();
            CStaticBien.SmaTaiKhoan = TableTimMK.Rows[0]["UserID"].ToString();
            CStaticBien.sNhomTaiKhoan = TableTimMK.Rows[0]["NhomNDid"].ToString();
            fMain = new frmMain(this);
            fMain.Show();
            this.Hide();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMK.Focus();
            }
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.Focus();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            lblTBMK.Visible = false;
            try
            {
                CServer LopServer = new CServer();
            }
            catch (Exception)
            {
                frmServer fServer = new frmServer();
                fServer.ShowDialog();
            }
        }

        public void ResetForm()
        {
            try 
            {
                txtMK.Text = "";
                txtTK.Text = "";
            }
            catch { }
        }
    }
}
