using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmXuatNhanhXacNhan : Form
    {
        public frmXuatNhanhXacNhan()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmXuatNhanhXacNhan(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void frmXuatNhanhXacNhan_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            try
            {
                CSQLXuatNhanh xn = new CSQLXuatNhanh();
                rgvPhieuXuat.DataSource = xn.LoadLenLuoiXacNhan();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void XacNhan()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fXuatNhanhXacNhan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                CSQLXuatNhanh xn = new CSQLXuatNhanh();
                for (int i = 0; i < rgvPhieuXuat.Rows.Count; i++)
                {
                    rgvPhieuXuat.Rows[i].Cells[0].EndEdit();
                    if (rgvPhieuXuat.Rows[i].Cells[0].Value != null)
                    {
                        bool chon = (bool)rgvPhieuXuat.Rows[i].Cells[0].Value;
                        if (chon == true)
                        {
                            int kq = xn.XacNhan(rgvPhieuXuat.Rows[i].Cells["colXNID"].Value.ToString(), CStaticBien.SmaTaiKhoan);
                            if (kq > 0)
                                rgvPhieuXuat.DataSource = xn.LoadLenLuoiXacNhan();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
