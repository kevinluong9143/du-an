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
    public partial class frmNT_NhapKhoXacNhan : Form
    {
        frmMain fmain;
        public frmNT_NhapKhoXacNhan(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void frmNT_NhapKhoXacNhan_Load(object sender, EventArgs e)
        {
            try
            {
                CSQLNT_XacNhanNhapKho xnnk = new CSQLNT_XacNhanNhapKho();
                rgvDSPhieuNhap.DataSource = xnnk.LayDSNTXacNhanNhapKhoLenLuoi();
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        public void XacNhan()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_NhapKhoXacNhan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            CSQLNT_XacNhanNhapKho xnnk = new CSQLNT_XacNhanNhapKho();
            for (int i = 0; i < rgvDSPhieuNhap.Rows.Count; i++)
            {
                rgvDSPhieuNhap.Rows[i].Cells[0].EndEdit();
                if (rgvDSPhieuNhap.Rows[i].Cells[0].Value != null)
                {
                    bool chon = (bool)rgvDSPhieuNhap.Rows[i].Cells[0].Value;
                    if (chon == true)
                    {
                        int kq = xnnk.XacNhanNhapKho(rgvDSPhieuNhap.Rows[i].Cells["colPNID"].Value.ToString(), true, CStaticBien.SmaTaiKhoan);
                        //if (kq == 0)
                        //{
                        //    MessageBox.Show("Số chứng từ nhập " + rgvDSPhieuNhap.Rows[i].Cells["ColSoCTN"].Value.ToString() + " có sản phẩm trùng lô khác date, vui lòng kiểm tra lại");
                        //}
                    }
                }
            }
            rgvDSPhieuNhap.DataSource = xnnk.LayDSNTXacNhanNhapKhoLenLuoi();
        }
    }
}
