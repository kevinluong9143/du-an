using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using ECOPharma2013.Report1;
using CrystalDecisions.Shared;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_SPItBan_NT : Form
    {
        public Fr_BC_SPItBan_NT()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string tieude = "BÁO CÁO CÁC SẢN PHẨM ĐÃ " + txtSoThang.Text + " THÁNG KHÔNG BÁN";
            CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
            DataTable dtbTonKhoCT_ItBan = tonkhoct_.LoadDataSanPhamItBan(int.Parse(txtSoThang.Text));
            if (dtbTonKhoCT_ItBan != null && dtbTonKhoCT_ItBan.Rows.Count > 0)
            {
                Report_BC_CanDate_ItBan check = new Report_BC_CanDate_ItBan();
                check.SetDataSource(dtbTonKhoCT_ItBan);
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();
                pdv.Value = tieude;
                ParameterValues pv = new ParameterValues();
                pv.Add(pdv);
                check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
                RW_BC_ItBan.ReportSource = check;
            }
            else
            {
                MessageBox.Show("Dữ liệu không có. Vui lòng kiểm tra lại!");
            }

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtSoThang.Focus();
            }
        }
    }
}
