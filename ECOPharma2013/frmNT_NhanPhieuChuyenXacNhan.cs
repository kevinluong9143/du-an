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
    public partial class frmNT_NhanPhieuChuyenXacNhan : Form
    {
        public frmNT_NhanPhieuChuyenXacNhan()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmNT_NhanPhieuChuyenXacNhan(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }

        private void frmNT_NhanPhieuChuyenXacNhan_Load(object sender, EventArgs e)
        {
            CSQLNT_NhanPhieuChuyen npc = new CSQLNT_NhanPhieuChuyen();

            try
            {
                rgvPhieuChuyen.DataSource = npc.LoadLenLuoiXacNhan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void XacNhanNhanPhieuChuyen()
        {
            CSQLNT_NhanPhieuChuyen npc = new CSQLNT_NhanPhieuChuyen();
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_NhanPhieuChuyenXacNhan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                CRmtServer KetNoiServer = new CRmtServer();
                if (KetNoiServer.KiemTraKetNoiRmtServer() == false)
                {
                    MessageBox.Show("Kết nối server tổng công ty không thành công. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    Fr_DangXuLy.ShowFormCho();
                    #region
                    for (int i = 0; i < rgvPhieuChuyen.Rows.Count; i++)
                    {
                        rgvPhieuChuyen.Rows[i].Cells[0].EndEdit();
                        if (rgvPhieuChuyen.Rows[i].Cells[0].Value != null)
                        {
                            bool chon = (bool)rgvPhieuChuyen.Rows[i].Cells["colChon"].Value;
                            if (chon == true)
                            {
                                int kq = npc.XacNhan(rgvPhieuChuyen.Rows[i].Cells["colNCHID"].Value.ToString(), DateTime.Now, CStaticBien.SmaTaiKhoan);
                                if (kq > 0)
                                    rgvPhieuChuyen.DataSource = npc.LoadLenLuoiXacNhan();
                            }
                        }

                    }
                    #endregion
                    Fr_DangXuLy.DongFormCho();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rgvPhieuChuyen.DataSource = npc.LoadLenLuoiXacNhan();
        }

        private void rgvPhieuChuyen_Click(object sender, EventArgs e)
        {

        }
    }
}
