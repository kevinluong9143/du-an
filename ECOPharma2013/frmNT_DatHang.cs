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
    public partial class frmNT_DatHang : Form
    {
        public frmNT_DatHang()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmNT_DatHang(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }

        private void frmNT_DatHang_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            CSQLNT_DatHang dh = new CSQLNT_DatHang();
            try
            {
                rgvDatHang.DataSource = dh.LoadLenLuoi(fmain.IsXemTatCa_);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); 
            }
        }

        private void rgvDatHang_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            HienFormDatHangEdit();
        }

        public void HienFormDatHangEdit()
        {
            //try
            //{
            //    if (rgvDatHang.Rows.Count > 0)
            //    {
            //        if (fmain.frmNT_DatHangEditisOpen_ == true)
            //        {
            //            fmain.fNT_DatHangEdit_.NhanThongTinDatHang(rgvDatHang.CurrentRow.Cells["colDHID"].Value.ToString(), rgvDatHang.CurrentRow.Cells["colSoDH"].Value.ToString());
            //            fmain.fNT_DatHangEdit_.Select();
            //            return;
            //        }
            //        else
            //        {
            //            fmain.fNT_DatHangEdit_ = new frmNT_DatHangEdit(fmain);
            //            fmain.fNT_DatHangEdit_.NhanThongTinDatHang(rgvDatHang.CurrentRow.Cells["colDHID"].Value.ToString(), rgvDatHang.CurrentRow.Cells["colSoDH"].Value.ToString());
            //            fmain.fNT_DatHangEdit_.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            try
            {
                if (rgvDatHang.Rows.Count > 0)
                {
                    if (fmain.frmNT_DatHangEditAccessisOpen_ == true)
                    {
                        fmain.fNT_DatHangEditAccess_.NhanThongTinDatHang(rgvDatHang.CurrentRow.Cells["colDHID"].Value.ToString(), rgvDatHang.CurrentRow.Cells["colSoDH"].Value.ToString());
                        fmain.fNT_DatHangEditAccess_.Select();
                        return;
                    }
                    else
                    {
                        fmain.fNT_DatHangEditAccess_ = new frmNT_DatHangEditAccess(fmain);
                        fmain.fNT_DatHangEditAccess_.NhanThongTinDatHang(rgvDatHang.CurrentRow.Cells["colDHID"].Value.ToString(), rgvDatHang.CurrentRow.Cells["colSoDH"].Value.ToString());
                        fmain.fNT_DatHangEditAccess_.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Xoa()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXoa(fmain.fNT_DatHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNT_DatHang dh = new CSQLNT_DatHang();
            try
            {
                if (dh.Xoa(rgvDatHang.CurrentRow.Cells["colDHID"].Value.ToString(), CStaticBien.SmaTaiKhoan) > 0)
                {
                    LoadLenLuoi();
                }
                else
                {
                    MessageBox.Show("Đơn hàng có thể đã được duyệt / xác nhận / chuyển về tổng công ty, không thể xóa!");
                }

            }
            catch(Exception ex) {
                MessageBox.Show("Đã có lỗi phát sinh khi xóa đơn hàng: " + ex.Message);
            }
        }
    }
}
