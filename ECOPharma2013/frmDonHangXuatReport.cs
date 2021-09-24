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
    public partial class frmDonHangXuatReport : Form
    {
        frmMain fmain;
        public frmDonHangXuatReport(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDonHangXuatReport_Load(object sender, EventArgs e)
        {
            if (fmain.MaSP_DHXCanChon_ != null && fmain.MaSP_DHXCanChon_.Length > 0)
            {
                CSQLDonHangXuatCT dhxct_ = new CSQLDonHangXuatCT();
                rgvLichSuDonHangXuat.DataSource = dhxct_.BaoCaoDonHang_DangChoVaChuaXacNhan(fmain.MaSP_DHXCanChon_);
            }
        }
    }
}
