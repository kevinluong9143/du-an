using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmNhapKhoXacNhan : Form
    {
        frmMain _frmMain;
        public frmNhapKhoXacNhan()
        {
            InitializeComponent();
        }
        public frmNhapKhoXacNhan(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNhapKhoXacNhan_Load(object sender, EventArgs e)
        {
            CSQLNhapKho xlnhapkho = new CSQLNhapKho();
            rgvDSPhieuNhapXacNhan.DataSource = xlnhapkho.LayDanhSachNhapKhoXacNhanLenLuoi(true,false);
        }
    }
}
