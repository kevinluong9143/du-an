using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.Report1;
using CrystalDecisions.Shared;
using ECOPharma2013.SQL;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_PhieuHuy : Form
    {
        public Fr_BC_PhieuHuy()
        {
            InitializeComponent();
        }

        private void RW_BC_PhieuHuy_Load(object sender, EventArgs e)
        {
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
            if (txtSoCa.Text == "")
            {
                MessageBox.Show("Không được bỏ trống số ca!");
            }
            else
            {
                DataTable dtbBC_PhieuHuy = tonkhoct_.LoadDataPhieuHuy(int.Parse(txtSoCa.Text));
                if (dtbBC_PhieuHuy != null && dtbBC_PhieuHuy.Rows.Count > 0)
                {
                    Report_BC_BanHangPhieuHuy check = new Report_BC_BanHangPhieuHuy();
                    check.SetDataSource(dtbBC_PhieuHuy);
                    RW_BC_PhieuHuy.ReportSource = check;
                }
                else
                {
                    MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                }
            }

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoCa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtSoCa.Focus();
            }
        }

        private void Fr_BC_PhieuHuy_Load(object sender, EventArgs e)
        {

        }
    }
}
