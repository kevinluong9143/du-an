using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;

namespace ECOPharma2013
{
    public partial class frmNhanTraHang : Form
    {
        frmMain fmain;
        public frmNhanTraHang()
        {
            InitializeComponent();
        }

        public frmNhanTraHang(frmMain frmMain)
        {
            InitializeComponent();
            fmain = frmMain;
        }

        public void LoadLenLuoi()
        {
            CSQLNhanTraHang th = new CSQLNhanTraHang();
            try
            {
                rgvPhieuTra.DataSource = th.LoadNhanTraHangLenLuoi(fmain.IsXemTatCa_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void HienFormNhanTraHangEdit()
        {
            CSQLNhanTraHang nth = new CSQLNhanTraHang();
            if (rgvPhieuTra.CurrentRow.Cells["colNTHID"].Value == null)
            {
                return;
            }
            if (fmain.frmNhanTraHangEditisOpen_ == false)
            {
                fmain.MaNhanTraHang_ = rgvPhieuTra.CurrentRow.Cells["colNTHID"].Value.ToString();
                fmain.SoPTH_ = rgvPhieuTra.CurrentRow.Cells["colSoPTH"].Value.ToString();
                fmain.LoaiHangTra_ = int.Parse(rgvPhieuTra.CurrentRow.Cells["colLoaiHangTra"].Value.ToString());
                fmain.KhoDacBiet_ = (bool)rgvPhieuTra.CurrentRow.Cells["colIsKhoDacBiet"].Value;
                fmain.BangNhanTraHang_ = nth.LayNhanTraHangTheoMa(fmain.MaNhanTraHang_);

                fmain.fNhanTraHangEdit_ = new frmNhanTraHangEdit(fmain);

                fmain.frmNhanTraHangEditisOpen_ = true;

                fmain.fNhanTraHangEdit_.ShowDialog();
                return;
            }
            else if (fmain.frmNhanTraHangEditisOpen_ == true)
            {
                fmain.fNhanTraHangEdit_.Select();
                return;
            }

            //try
            //{
            //    if (fmain.frmNhanTraHangEditisOpen_ == true)
            //    {
            //        fmain.fNhanTraHangEdit_.NhanTHID_SoPTH(rgvPhieuTra.CurrentRow.Cells["colNTHID"].Value.ToString(), rgvPhieuTra.CurrentRow.Cells["colSoPTH"].Value.ToString(), int.Parse(rgvPhieuTra.CurrentRow.Cells["colLoaiHangTra"].Value.ToString()));
            //        fmain.fNhanTraHangEdit_.Select();
            //        return;
            //    }
            //    else
            //    {
            //        fmain.fNhanTraHangEdit_ = new frmNhanTraHangEdit(fmain);
            //        fmain.fNhanTraHangEdit_.NhanTHID_SoPTH(rgvPhieuTra.CurrentRow.Cells["colNTHID"].Value.ToString(), rgvPhieuTra.CurrentRow.Cells["colSoPTH"].Value.ToString(), int.Parse(rgvPhieuTra.CurrentRow.Cells["colLoaiHangTra"].Value.ToString()));
            //        fmain.fNhanTraHangEdit_.ShowDialog();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void rgvPhieuTra_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            HienFormNhanTraHangEdit();
        }

        public void rgvPhieuTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                string chid = rgvPhieuTra.CurrentRow.Cells["colNTHid"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNhanTraHang th = new CSQLNhanTraHang();
                    try
                    {
                        //int kq = th.XoaToanBo(chid);
                        //if (kq > 0)
                        //{
                        //    rgvPhieuTra.DataSource = th.LoadNhanTraHangLenLuoi(fmain.IsXemTatCa_);
                        //}
                        //else
                        //    MessageBox.Show("Xóa thất bại.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
        }

        private void frmNhanTraHang_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

    }
}
