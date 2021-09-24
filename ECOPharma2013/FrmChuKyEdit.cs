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

namespace ECOPharma2013
{
    public partial class FrmChuKyEdit : Form
    {
        frmMain fmain = new frmMain();
        public FrmChuKyEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        public FrmChuKyEdit()
        {
            InitializeComponent();
        }

        private void btnDBCDong_Click(object sender, EventArgs e)
        {
            fmain.fChuKy.LoadLenLuoi();
            fmain.frmChuKyEditisOpen_ = false;
            this.Close();
        }

        private void FrmChuKyEdit_Load(object sender, EventArgs e)
        {
            CSQLNhomSP nhomsp = new CSQLNhomSP();
            cboNhomSP.DataSource = nhomsp.LoadDSNhomSPLenLuoi(false);
            cboNhomSP.SelectedIndex = -1;
        }

        private void rbtnKetThucChuKy_Click(object sender, EventArgs e)
        {
            CSQLChuKy ck = new CSQLChuKy();
            try
            {
                int ketthucchuky = ck.KetThucChuKy(cboNhomSP.SelectedValue.ToString(), CStaticBien.SmaTaiKhoan);
                if (ketthucchuky > 0)
                {
                    MessageBox.Show("Kết thúc chu kỳ thành công");
                }
                else
                { MessageBox.Show("Kết thúc chu kỳ thất bại"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
