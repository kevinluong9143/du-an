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
    public partial class frmTKXacNhan : Form
    {
        public frmTKXacNhan()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmTKXacNhan(frmMain _fmain)
        {
            InitializeComponent();
            fmain = _fmain;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            //CQuyenTruyCap qtc = new CQuyenTruyCap();
            //if (qtc.KiemTraQuyenThem_Sua(fmain.fTKXacNhan.Name) == false)
            //{
            //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
            //    return;
            //}
            try
            {
                CSQLUser user = new CSQLUser();
                if (txtTK.Text.Length > 0)
                {
                    int kq = user.TKXacNhan_ChungThuc(txtTK.Text, txtMK.Text, fmain.fTKXacNhan.Name);
                    if (kq == 1)
                    {
                        if (fmain.fNT_BanHangEdit_ != null)
                        {
                            this.fmain.fNT_BanHangEdit_.KichHoatGiamGia(true);
                            this.Close();
                        }
                    }
                    else 
                    {
                        lblThongBao.Text = "Bạn không có quyền truy cập chức năng này!";
                    }
                }
                else
                {
                    lblThongBao.Text = "Tài khoản hoặc mật khẩu nhập không đúng!";
                }
            }
            catch {  }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.fmain.fNT_BanHangEdit_.KichHoatGiamGia(false);
            this.Close();
        }
    }
}
