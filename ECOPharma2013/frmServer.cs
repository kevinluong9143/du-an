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
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            txtServerName.Text= CStaticBien._Server;
            txtUser.Text = CStaticBien._UserName;
            txtPass.Text = CStaticBien._Password;
            txtDatabase.Text = CStaticBien._Database;
            txtServerName.Focus();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            CStaticBien._Server = txtServerName.Text.Trim();
            CStaticBien._UserName = txtUser.Text.Trim();
            CStaticBien._Password = txtPass.Text.Trim();
            CStaticBien._Database = txtDatabase.Text.Trim();
            try
            {
                CServer.TestConn();
                MessageBox.Show("Kết nối thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CStaticBien._Server = txtServerName.Text.Trim();
            CStaticBien._UserName = txtUser.Text.Trim();
            CStaticBien._Password = txtPass.Text.Trim();
            CStaticBien._Database = txtDatabase.Text.Trim();

            CServer.GhiFileConfig(CStaticBien._Server,CStaticBien._UserName,CStaticBien._Password,CStaticBien._Database);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
