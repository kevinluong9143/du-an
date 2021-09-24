using ECOPharma2013.DuLieu;
using ECOPharma2013.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_SLXemForm : Form
    {
        public Fr_BC_SLXemForm()
        {
            InitializeComponent();

            dtTuNgay.MaxDate = dtDenNgay.MaxDate = dtDenNgay.Value = DateTime.Now;
            dtTuNgay.Value = dtDenNgay.Value.AddMonths(-1);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            CSQLXemForm aXemForm = new CSQLXemForm();
            rgvDS.DataSource = aXemForm.XemSoLuotView(dtTuNgay.Value, dtDenNgay.Value);
            aXemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

        private void rgvDS_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            Fr_BC_SLXemForm_ChiTiet aChiTiet = new Fr_BC_SLXemForm_ChiTiet(dtTuNgay.Value, dtDenNgay.Value, rgvDS.CurrentRow.Cells["colFormView"].Value.ToString());
            aChiTiet.ShowDialog();
        }
    }
}
