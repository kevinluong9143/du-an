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

namespace ECOPharma2013
{
    public partial class frmChuyenKhoXacNhan : Form
    {
        frmMain _frmMain;
        public frmChuyenKhoXacNhan()
        {
            InitializeComponent();
        }
        public frmChuyenKhoXacNhan(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmChuyenKhoXacNhan_Load(object sender, EventArgs e)
        {
            CSQLChuyenKho xlchuyenkho = new CSQLChuyenKho();
            rgvChuyenKho.DataSource = xlchuyenkho.LayDanhSachChuyenKhoXacNhanLenLuoi(true, false);
        }

    }
}
