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
    public partial class frmNT_TraHangVeCty : Form
    {
        public frmNT_TraHangVeCty()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmNT_TraHangVeCty(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }


        private void frmNT_TraHangVeCty_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLenLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadLenLuoi()
        {
            CSQLNT_TraHangVeCty thvcty = new CSQLNT_TraHangVeCty();
            try
            {
                rgvTraHang.DataSource = thvcty.LayDSLenLuoi(fmain.IsXemTatCa_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void HienFormTraHangVeCtyEdit()
        {
            try
            {
                if (fmain.frmNT_TraHangVeCTyEditisOpen_ == true)
                {
                    fmain.MaNT_TraHangVeCty_ = rgvTraHang.CurrentRow.Cells["colTHID"].Value.ToString();
                    fmain.fNT_TraHangVeCtyEdit.NhanTHID_SoPTH(rgvTraHang.CurrentRow.Cells["colTHID"].Value.ToString(), rgvTraHang.CurrentRow.Cells["colSoPTH"].Value.ToString());
                    fmain.fNT_TraHangVeCtyEdit.Select();
                    return;
                }
                else
                {
                    fmain.MaNT_TraHangVeCty_ = rgvTraHang.CurrentRow.Cells["colTHID"].Value.ToString();
                    fmain.fNT_TraHangVeCtyEdit = new frmNT_TraHangVeCtyEdit(fmain);
                    fmain.fNT_TraHangVeCtyEdit.NhanTHID_SoPTH(rgvTraHang.CurrentRow.Cells["colTHID"].Value.ToString(), rgvTraHang.CurrentRow.Cells["colSoPTH"].Value.ToString());
                    fmain.fNT_TraHangVeCtyEdit.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void rgvTraHangVeCty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fmain.fNT_TraHangVeCty.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string chid = rgvTraHang.CurrentRow.Cells["colTHid"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNT_TraHangVeCty ch = new CSQLNT_TraHangVeCty();
                    try
                    {
                        int kq = ch.XoaToanBo(chid);
                        if (kq > 0)
                        {
                            rgvTraHang.DataSource = ch.LayDSLenLuoi(fmain.IsXemTatCa_);
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

        private void rgvTraHangVeCty_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            HienFormTraHangVeCtyEdit();
        }

        //public void TraHangVeCty_XoaToanBo()
        //{
        //    CSQLNT_TraHangVeCty ch = new CSQLNT_TraHangVeCty();
        //    try
        //    {
        //        if(rgvTraHangVeCty.CurrentRow.Cells["colCHID"].Value.ToString()!=null && rgvTraHangVeCty.CurrentRow.Cells["colCHID"].Value.ToString().Length>0)
        //            ch.XoaToanBo(rgvTraHangVeCty.CurrentRow.Cells["colCHID"].Value.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        //    }
        //}
    }
}
