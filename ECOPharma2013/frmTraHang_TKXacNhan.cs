using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls.UI;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmTraHang_TKXacNhan : Form
    {
        public frmTraHang_TKXacNhan()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmTraHang_TKXacNhan(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            //CQuyenTruyCap qtc = new CQuyenTruyCap();
            //if (qtc.KiemTraQuyenThem_Sua(fmain.fTraHang_TKXacNhan.Name) == false)
            //{
            //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
            //    return;
            //}
            try
            {
                int isCoQuyen = 0;
                CSQLUser user = new CSQLUser();
                if (txtTK.Text.Length > 0)
                {
                    //isCoQuyen = user.TKXacNhan_ChungThuc(txtTK.Text, txtMK.Text);
                    isCoQuyen = user.TKXacNhan_ChungThuc(txtTK.Text, txtMK.Text, fmain.fTraHang_TKXacNhan.Name);
                    if (isCoQuyen == 1)
                    {
                        //fmain.HienFrmTraHang();
                        fmain.fNT_TraHangEdit_.IsXacNhanOK(isCoQuyen);
                        this.Close();
                    }
                    else
                    {
                        lblThongBao.Text = "Xác nhận không thành công!";
                    }
                }
                else
                {
                    lblThongBao.Text = "Tài khoản hoặc mật khẩu trống hay nhập không đúng!";
                }

            }
            catch { }
        }
    }
}
