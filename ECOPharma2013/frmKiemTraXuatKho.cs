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
using System.Transactions;
using ECOPharma2013.Report1;

namespace ECOPharma2013
{
    public partial class frmKiemTraXuatKho : Form
    {
        frmMain _frmMain;
        public frmKiemTraXuatKho()
        {
            InitializeComponent();
        }
        public frmKiemTraXuatKho(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        CSQLPhieuXuat phieuxuat_ = new CSQLPhieuXuat();
        CSQLKiemTraXuatKho kiemtraxuatkho_ = new CSQLKiemTraXuatKho();
        private void frmKiemTraXuatKho_Load(object sender, EventArgs e)
        {
            DataTable dataKTXK = kiemtraxuatkho_.KiemTraXuatKho_LoadLenLuoi_IsXong(false);
            if (dataKTXK.Rows.Count > 0)
            {
                rgvKiemTraXuatKho.DataSource = dataKTXK;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fKiemTraXuatKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLKiemTraXuatKho ktxk_ = new CSQLKiemTraXuatKho();
            DataTable dtbktxk = new DataTable();
            Fr_DangXuLy.ShowFormCho();
            try
            {
                //Lấy database phiếu xuất vào kiểm tra xuất kho
                #region
                try
                {
                    dtbktxk = phieuxuat_.LayPhieuXuat_SoLanIn_IsKiemTraXuatKho(0, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chưa lấy được Phiếu Xuất.");                
                }
                #endregion

                if (dtbktxk != null & dtbktxk.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbktxk.Rows.Count; i++)
                    {
                        string pxid_ = dtbktxk.Rows[i]["PXid"].ToString();
                        string sopx_ = dtbktxk.Rows[i]["SoPX"].ToString();
                        string userKT = CStaticBien.SmaTaiKhoan;

                        //insert từ Phiếu Xuất vào Kiểm Tra xuất kho
                        if (ktxk_.KiemTraTonTaiSoPX(sopx_))
                        {
                        }
                        else
                        {
                            phieuxuat_.LayPhieuXuat_InsertKTXK_PxID(userKT, pxid_);
                        }
                        
                        // insert từ phiếu xuất CT vào Kiểm tra xuất kho CT
                        #region
                        phieuxuat_.LayPhieuXuat_InsertKTXKCT(pxid_);
                        #endregion

                        // update đã kiểm tra xuất kho trong Phiếu Xuất
                        #region
                        phieuxuat_.LayPhieuXuat_UpdateIsKiemTraXuatKho_PX(pxid_);
                        #endregion
                    }
                    rgvKiemTraXuatKho.DataSource = kiemtraxuatkho_.KiemTraXuatKho_LoadLenLuoi_IsXong(false);

                }
                else
                {
                    MessageBox.Show("Chưa có Phiếu Xuất để cập nhật.");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Fr_DangXuLy.DongFormCho();
        }

        private void rgvKiemTraXuatKho_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (rgvKiemTraXuatKho.CurrentRow.Cells["colKTid"].Value == null)
            {
                return;
            }

            if (_frmMain.frmKiemTraXuatKhoEditisOpen_ == false)
            {
                _frmMain.MaKiemTraXuatKho_ = rgvKiemTraXuatKho.CurrentRow.Cells["colKTid"].Value.ToString();
                _frmMain.IsXong = bool.Parse(rgvKiemTraXuatKho.CurrentRow.Cells["colIsXong"].Value.ToString());
                _frmMain.BangKiemTraXuatKho_ = kiemtraxuatkho_.KiemTraXuatKho_LayKTXKTheoMa(_frmMain.MaKiemTraXuatKho_);
                _frmMain.fKiemTraXuatKhoEdit_ = new frmKiemTraXuatKhoEdit(_frmMain);
                _frmMain.frmKiemTraXuatKhoEditisOpen_ = true;

                _frmMain.fKiemTraXuatKhoEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmKiemTraXuatKhoEditisOpen_ == true)
            {
                _frmMain.fKiemTraXuatKhoEdit_.Select();
                return;
            }
        }

        private void xácNhậnThựcXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fKiemTraXuatKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLKiemTraXuatKho ktxk_ = new CSQLKiemTraXuatKho();
            if (ktxk_.XacNhanThucXuat() > 0)
            {
                MessageBox.Show("Đã cập nhật thành công!");
                rgvKiemTraXuatKho.DataSource = kiemtraxuatkho_.KiemTraXuatKho_LoadLenLuoi_IsXong(false);
            }
            else
            {
                MessageBox.Show("Không có phiếu xuất hoặc cập nhật thất bại!");
            }
        }
    }
}
