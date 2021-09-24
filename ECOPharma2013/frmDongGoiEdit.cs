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
    public partial class frmDongGoiEdit : Form
    {
        frmMain fmain;
        string dgid;
        string dgctid;
        public frmDongGoiEdit(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            fmain.frmDongGoiEditisOpen_ = false;
            this.Close();
        }
        public void _SoPX_SoDH(string donggoiid, string sopx, string sodh)
        {
            lblPhieuXuat.Text = sopx;
            lblDonHang.Text = sodh;
            dgid = donggoiid;
            if (dgid.Length > 0)
            {
                CSQLDongGoiCT dgct = new CSQLDongGoiCT();
                DataTable dtb = dgct.LayLenLuoi_TheoDGID(dgid);
                if (dtb != null && dtb.Rows.Count > 0)
                    rgvDongGoiCT.DataSource = dtb;

                CSQLDongGoi dg = new CSQLDongGoi();
                DataTable dtbdg = dg.LayThongTin_TheoDGID(dgid);
                if (dtbdg != null && dtbdg.Rows.Count > 0)
                {
                    if (dtbdg.Rows[0]["IsXong"].ToString().Length>0&&bool.Parse(dtbdg.Rows[0]["IsXong"].ToString()) == true)
                    {
                        txtSL.Enabled = false;
                        cboDVT.Enabled = false;
                        btnLuu.Enabled = false;
                        btnXacNhanXong.Enabled = false;
                    }
                    else
                    {
                        txtSL.Enabled = true;
                        cboDVT.Enabled = true;
                        btnLuu.Enabled = true;
                        btnXacNhanXong.Enabled = true;
                    }
                }
            }
        }

        private void frmDongGoiEdit_Load(object sender, EventArgs e)
        {
            btnXacNhanXong.Enabled = false;
            CSQLDonViTinh dvt = new CSQLDonViTinh();
            cboDVT.DisplayMember = "TenDVT";
            cboDVT.ValueMember = "DVTID";
            cboDVT.DataSource = dvt.LayDonViTinhLenDrdl();
            cboDVT.SelectedIndex = -1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fDongGoi.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLDongGoi dg = new CSQLDongGoi();
            if (dg.KiemTraDaXacNhan(dgid) == false)
            {
                CSQLDongGoiCT dgct = new CSQLDongGoiCT();
                if (dgctid != null && dgctid.Length > 0 && txtSL.Text.Length > 0 && cboDVT.SelectedIndex != -1) //trường hợp sửa đóng gói chi tiết
                {
                    int kq = dgct.Sua(dgctid, decimal.Parse(txtSL.Text), cboDVT.SelectedValue.ToString());
                    if (kq > 0)
                    {
                        statusTB.Text = "Sửa thành công";
                        rgvDongGoiCT.DataSource = dgct.LayLenLuoi_TheoDGID(dgid);
                        btnXacNhanXong.Enabled = true;
                        btnLuu.Enabled = false;
                        dgctid = "";
                    }
                    else
                    {
                        statusTB.Text = "Sửa thất bại";
                    }
                }
                else //Trường hợp thêm đóng gói chi tiết
                {
                    if (dgid != null && dgid.Length > 0 && txtSL.Text.Length > 0 && cboDVT.SelectedIndex != -1)
                    {
                        int kq = dgct.Them(dgid, decimal.Parse(txtSL.Text), cboDVT.SelectedValue.ToString());
                        if (kq > 0)
                        {
                            statusTB.Text = "Thêm thành công";

                            dg.CapNhatNgayDongGoi(dgid, CStaticBien.SmaTaiKhoan);
                            rgvDongGoiCT.DataSource = dgct.LayLenLuoi_TheoDGID(dgid);
                            btnXacNhanXong.Enabled = true;
                            btnLuu.Enabled = false;
                        }
                        else
                        {
                            statusTB.Text = "Thêm thất bại";
                        }
                    }
                }
            }
        }

        private void btnXacNhanXong_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fDongGoi.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (dgid != null && dgid.Length > 0)
            {
                CSQLDongGoi dg = new CSQLDongGoi();
                int kq = dg.CapNhatXacNhanXong(dgid, CStaticBien.SmaTaiKhoan);
                if (kq > 0)
                {
                    fmain.fDongGoi.RefreshRGVDongGoi();
                    statusTB.Text = "Cập nhật thành công";
                    txtSL.Enabled = false;
                    cboDVT.Enabled = false;
                    btnLuu.Enabled = false;
                    btnXacNhanXong.Enabled = false;
                }
                else
                {
                    statusTB.Text = "Cập nhật thất bại";    
                } 
            }
            CSQLDongGoi dg_ = new CSQLDongGoi();
            fmain.fDongGoi.rgvDongGoi.DataSource = dg_.LayDSDongGoi(this.fmain.IsXemTatCa_);
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                statusTB.Text = "Bạn không được nhập chữ!";
                e.Handled = true;
            }
        }

        private void rgvDongGoiCT_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                dgctid = rgvDongGoiCT.CurrentRow.Cells["colDGCTID"].Value.ToString();
                txtSL.Text = String.Format("{0:N2}", decimal.Parse(rgvDongGoiCT.CurrentRow.Cells["colSLDongGoi"].Value.ToString()));
                cboDVT.SelectedValue = rgvDongGoiCT.CurrentRow.Cells["colDVTid"].Value.ToString();
            }
            catch { }
        }

        private void frmDongGoiEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (btnLuu.Enabled == true)
                {
                    if (cboDVT.SelectedValue != null)
                    {
                        btnLuu_Click(sender, e);
                        txtSL.Text = "";
                        cboDVT.SelectedIndex = -1;
                        txtSL.Focus();
                    }
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                if (btnXacNhanXong.Enabled == true)
                {
                    btnXacNhanXong_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnDong_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSL.Text != "")
                {
                    cboDVT.Focus();
                    btnLuu.Enabled = true;
                    btnXacNhanXong.Enabled = false;
                    //cboDVT.DroppedDown = true;
                }
            }
        }

        private void rgvDongGoiCT_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void rgvDongGoiCT_KeyDown(object sender, KeyEventArgs e)
        {
            CSQLDongGoi dg = new CSQLDongGoi();
            if (e.KeyCode == Keys.Delete && dgid!=null && dgid.Length>0 && dg.KiemTraDaXacNhan(dgid)==false)
            {
                if (MessageBox.Show("Bạn thật sự muốn xóa thông tin này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLDongGoiCT dgct = new CSQLDongGoiCT();
                    int kq = dgct.Xoa(rgvDongGoiCT.CurrentRow.Cells["colDGCTid"].Value.ToString());
                    rgvDongGoiCT.DataSource = dgct.LayLenLuoi_TheoDGID(dgid);
                }
                else
                {
                    return;
                }
            }
        }
        
    }
}
