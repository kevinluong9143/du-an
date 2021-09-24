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
    public partial class frmDonHangXuatXacNhan : Form
    {
        frmMain fmain;
        public frmDonHangXuatXacNhan(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }

        private void frmDonHangXuatXacNhan_Load(object sender, EventArgs e)
        {
            CSQLDonHangXuat dhx = new CSQLDonHangXuat();
            rgvDSXacNhanDonHang_LayDuLieu(dhx.LayDLLenLuoiXacNhan());
        }

        public void rgvDSXacNhanDonHang_LayDuLieu(DataTable _DSDonHang)
        {
            rgvDSDonHang.DataSource = _DSDonHang;
        }

        public void XacNhanDonHangXuat(bool tinhtrangxacnhan)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fDonHangXuatXacNhan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLDonHangXuat dhx = new CSQLDonHangXuat();
            for (int i = 0; i < rgvDSDonHang.Rows.Count; i++)
            {
                rgvDSDonHang.Rows[i].Cells["colChon"].EndEdit();
                if (rgvDSDonHang.Rows[i].Cells["colChon"].Value != null)
                {
                    bool chon = (bool)rgvDSDonHang.Rows[i].Cells["colChon"].Value;
                    if (chon == true)
                    {
                        int kq = dhx.XacNhanDonHangXuat(rgvDSDonHang.Rows[i].Cells["colDHid"].Value.ToString(), tinhtrangxacnhan, CStaticBien.SmaTaiKhoan);
                    }
                }
            }
            rgvDSXacNhanDonHang_LayDuLieu(dhx.LayDLLenLuoiXacNhan());
        }
    }
}
