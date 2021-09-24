using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GetActiveCode;
using CreateDllLicenseKey;
using ECOPharma2013.DuLieu;
using ECOPharma2013.SQL;

namespace ECOPharma2013
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            CreateActiveCode ActiveCode = new CreateActiveCode();
            txtActiveCode.Text = ActiveCode.GetCode();
            txtLicenseKey.Text = CStaticBien._LicenseKey;
            txtThuNgan.Text = CStaticBien.STenMayThuNgan;
            txtLicenseKey.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtLicenseKey.Text.Trim() == "")
            {
                return;
            }

            if (txtLicenseKey.Text.Length != 32)
            {
                return;
            }
            
            CStaticBien._LicenseKey = txtLicenseKey.Text.Trim();
            CStaticBien.STenMayThuNgan = txtThuNgan.Text.Trim();

            try
            {
                //CServer.TestConn();
                if (CSQLLicenseKey.KiemTraLicense() == true)
                {
                    CSQLLicenseKey.GhiFileConfig(CStaticBien._LicenseKey,CStaticBien.STenMayThuNgan);
                    MessageBox.Show("Đăng Ký Thành Công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi Đăng Ký, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Ghi file
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
