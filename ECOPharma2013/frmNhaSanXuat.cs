using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;


namespace ECOPharma2013
{
    public partial class frmNhaSanXuat : Form
    {
        frmMain fmain;
        public frmNhaSanXuat(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        public void SelectRows_NSX()
        {
            if (rgvNSX.CurrentRow.Cells["colNSXID"].Value == null)
            {
                return;
            }
            CSQLNSX npp = new CSQLNSX();
            fmain.IsSuaNhanVien = true;
            if (fmain.frmNhaSanXuatEditisOpen_ == false)
            {
                fmain.MaNhaSanXuatCanSua_ = rgvNSX.CurrentRow.Cells["colNSXID"].Value.ToString();
                fmain.BangNhaSanXuatCanSua_ = npp.LayNSXTheoMa(fmain.MaNhaSanXuatCanSua_);
                fmain.frmNhaSanXuatEditisOpen_ = true;
                fmain.fNhaSanXuatEdit_ = new frmNhaSanXuatEdit(fmain);
                fmain.fNhaSanXuatEdit_.ShowDialog();
                return;
            }
            else if (fmain.frmNhaSanXuatEditisOpen_ == true)
            {
                fmain.fNhaSanXuatEdit_.Select();
                return;
            }
        }

        private void frmNhaSanXuat_Load(object sender, EventArgs e)
        {
            CSQLNSX nsx = new CSQLNSX();
            rgvNSX.DataSource = nsx.LayNSXLenLuoi(fmain.IsXemTatCa_);
        }

        private void rgvNSX_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = CColor.MauGVRow[1];
            }
        }

        private void rgvNSX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fmain.fNhaSanXuat.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.fmain.MaNhaSanXuatCanSua_ = rgvNSX.CurrentRow.Cells["colNSXID"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa nhà sản xuất có mã: ['" + this.fmain.MaNhaSanXuatCanSua_ + "']?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNSX xlnsx = new CSQLNSX();
                    string kq = xlnsx.XoaNSX(this.fmain.MaNhaSanXuatCanSua_);
                    if (kq.Equals("OK"))
                        rgvNSX.DataSource = xlnsx.LayNSXLenLuoi(this.fmain.IsXemTatCa_);
                    else
                        MessageBox.Show("Lỗi: " + kq);
                }
            }
        }

        private void ExportToExcel_NSX_Click(object sender, EventArgs e)
        {
            //CSQLNSX nsx_ = new CSQLNSX();
            //DataTable dtb = nsx_.LayNSXLenLuoi(fmain.IsXemTatCa_);
            //ExporttoExcel export = new ExporttoExcel();
            //bool kq = export.exportDataToExcel("ECO Pharmacy", "Date Extracted :", dtb);
            //if (kq == true)
            //{
            //    MessageBox.Show("Dữ liệu đã xuất.", "Thông Báo");
            //}
            //else
            //    MessageBox.Show("Fail");
        }

        private void rgvNSX_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NSX();
        }
    }
}
