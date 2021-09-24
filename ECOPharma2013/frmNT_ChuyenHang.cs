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
    public partial class frmNT_ChuyenHang : Form
    {
        frmMain fmain;
        public frmNT_ChuyenHang()
        {
            InitializeComponent();
        }
        public frmNT_ChuyenHang(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void rgvChuyenHang_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            HienFormChuyenHangEdit();
        }

        private void frmNT_ChuyenHang_Load(object sender, EventArgs e)
        {
            LayDSChuyenHangLenLuoi(fmain.IsXemTatCa_);
        }

        public void LayDSChuyenHangLenLuoi(bool IsXemTatCa)
        {
            try 
            {
                CSQLNT_ChuyenHang ch = new CSQLNT_ChuyenHang();
                rgvChuyenHang.DataSource = ch.LayDSChuyenHangLenLuoi(IsXemTatCa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); 
            }
        }

        public void HienFormChuyenHangEdit()
        {
            try
            {
                if (fmain.frmNT_ChuyenHangEditisOpen_ == true)
                {
                    fmain.fNT_ChuyenHangEdit_.NhanCHID_SoPCH(rgvChuyenHang.CurrentRow.Cells["colCHID"].Value.ToString(), rgvChuyenHang.CurrentRow.Cells["colSoPCH"].Value.ToString());
                    fmain.fNT_ChuyenHangEdit_.Select();
                    return;
                }
                else
                {
                    fmain.fNT_ChuyenHangEdit_ = new frmNT_ChuyenHangEdit(fmain);
                    fmain.fNT_ChuyenHangEdit_.NhanCHID_SoPCH(rgvChuyenHang.CurrentRow.Cells["colCHID"].Value.ToString(), rgvChuyenHang.CurrentRow.Cells["colSoPCH"].Value.ToString());
                    fmain.fNT_ChuyenHangEdit_.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public void ChuyenHang_XoaToanBo()
        //{
        //    CSQLNT_ChuyenHang ch = new CSQLNT_ChuyenHang();
        //    try
        //    {
        //        if(rgvChuyenHang.CurrentRow.Cells["colCHID"].Value.ToString()!=null && rgvChuyenHang.CurrentRow.Cells["colCHID"].Value.ToString().Length>0)
        //            ch.XoaToanBo(rgvChuyenHang.CurrentRow.Cells["colCHID"].Value.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        //    }
        //}

        public void rgvChuyenHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fmain.fNT_ChuyenHang.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string chid = rgvChuyenHang.CurrentRow.Cells["colCHid"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNT_ChuyenHang ch = new CSQLNT_ChuyenHang();
                    try
                    {
                        int kq = ch.XoaToanBo(chid);
                        if (kq > 0)
                        {
                            rgvChuyenHang.DataSource = ch.LayDSChuyenHangLenLuoi(fmain.IsXemTatCa_);
                        }
                        else
                            MessageBox.Show("Xóa thất bại.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
        }
    }
}
