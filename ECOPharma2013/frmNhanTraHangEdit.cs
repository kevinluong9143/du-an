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
using Telerik.WinControls.UI;

namespace ECOPharma2013
{
    public partial class frmNhanTraHangEdit : Form
    {
        public frmNhanTraHangEdit()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmNhanTraHangEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void rbtnDong_Click(object sender, EventArgs e)
        {
            if (fmain.DSNhanTraHangIsOpen == true)
            {
                fmain.fNhanTraHang.LoadLenLuoi();
            }
            if (fmain.DSNhanTraHangXacNhanIsOpen == true)
            {
                fmain.fNhanTraHangXacNhan.LoadLenLuoi();
            }
            fmain.frmNhanTraHangEditisOpen_ = false;
            this.Close();
        }

        private void frmNhanTraHangEdit_Load(object sender, EventArgs e)
        {
            if (fmain.MaNhanTraHang_ != null && fmain.MaNhanTraHang_.Length > 0)
            {
                //LOAD MASTER
                #region
                CSQLNhanTraHang nth = new CSQLNhanTraHang();
                try
                {
                    DataTable dtb = nth.LayNhanTraHangTheoMa(fmain.MaNhanTraHang_);
                    if (dtb != null && dtb.Rows.Count > 0)
                    {
                        CSQLNhanTraHangCT npc = new CSQLNhanTraHangCT();
                        cbxKho.DisplayMember = "TenKho";
                        cbxKho.ValueMember = "KhoID";
                        cbxKho.DataSource = npc.LayKhoLenCBO(fmain.LoaiHangTra_, fmain.MaNhanTraHang_);
                        cbxKho.SelectedIndex = -1;

                        //cbxKho.Items.Insert(0, new object("00000000-0000-0000-0000-000000000000", "---Chọn kho---"));

                        txtSPTra.Text = fmain.SoPTH_ = dtb.Rows[0]["SoPTH"].ToString();
                        txtNoiTra.Text = dtb.Rows[0]["TenNoiTra"].ToString();
                        txtGhiChu.Text = dtb.Rows[0]["GhiChu"].ToString();
                        dtNgayChungTu.Value = DateTime.Parse(dtb.Rows[0]["NgayChungTu"].ToString());
                        if (bool.Parse(dtb.Rows[0]["DaXetDuyet"].ToString()) == true)
                        {
                            ckDuyet.Checked = true;
                            this.rgvChiTiet.Columns["colKho"].ReadOnly = true;
                        }
                        else
                        { 
                            ckDuyet.Checked = false;
                            this.rgvChiTiet.Columns["colKho"].ReadOnly = false;
                        }
                        if (int.Parse(dtb.Rows[0]["LoaiHangTra"].ToString()) == 1)
                            rbtnBinhThuong.Checked = true;
                        else if (int.Parse(dtb.Rows[0]["LoaiHangTra"].ToString()) == 2)
                            rbtnBatThuong.Checked = true;
                        if (bool.Parse(dtb.Rows[0]["DaXacNhanNhapKho"].ToString()) == true)
                        {
                            ckDuyet.Enabled = false;
                        }
                        else
                        {
                            ckDuyet.Enabled = true;
                        }

                        if (fmain.KhoDacBiet_ == true)
                        {
                            this.rgvChiTiet.Columns["colKho"].ReadOnly = true;
                        }
                        ((GridViewComboBoxColumn)this.rgvChiTiet.Columns["colKho"]).DataSource = npc.LayKhoLenCBO(fmain.LoaiHangTra_, fmain.MaNhanTraHang_);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion

                //Load detail
                #region
                try
                {
                    rgvChiTiet.DataSource = nth.LayNhanTraHangCT_TheoNTHid(fmain.MaNhanTraHang_);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }

        private void rbtnBinhThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBinhThuong.Checked == true)
                rbtnBatThuong.Checked = false;
        }

        private void rbtnBatThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBatThuong.Checked == true)
                rbtnBinhThuong.Checked = false;
        }

        private void rgvChiTiet_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            CSQLNhanTraHang nth = new CSQLNhanTraHang();
            if (rgvChiTiet.CurrentCell.ColumnInfo.Name.CompareTo("colKho") == 0)
            {
                if (rgvChiTiet.CurrentRow.Cells["colKho"].Value != null && rgvChiTiet.CurrentRow.Cells["colKho"].Value.ToString().CompareTo("") > 0)
                {
                    
                    CSQLNhanTraHangCT npcct = new CSQLNhanTraHangCT();
                    CSQLKho kho_ = new CSQLKho();
                    string khodacbiet = kho_.KiemTraNhomKhoDacBiet(rgvChiTiet.CurrentRow.Cells["colKho"].Value.ToString());
                    if (khodacbiet != null)
                    {
                       MessageBox.Show("Khi chọn Kho Đặc Biệt thì tất cả các sản phẩm sẽ chuyển qua Kho Đặc Biệt. Vui lòng chọn Kho Đặc Biệt trong phần chuyển tới kho!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question);
                       DataTable dtbkho = npcct.LayNhanTraHangCT_NTHCTid(rgvChiTiet.CurrentRow.Cells["colNTHCTID"].Value.ToString());
                       rgvChiTiet.CurrentRow.Cells["colKho"].Value = dtbkho.Rows[0]["KhoID"].ToString();
                    }
                    else
                    {
                        int kq = npcct.Sua(rgvChiTiet.CurrentRow.Cells["colNTHCTID"].Value.ToString(), rgvChiTiet.CurrentRow.Cells["colKho"].Value.ToString());
                        if (kq > 0)
                        {
                            statusTB.Text = "Sửa thông tin kho thành công!";
                        }
                    }         
                }
            }           
        }

        private void ckDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyet.Checked == true)
            {
                this.rgvChiTiet.Columns["colKho"].ReadOnly = true;
            }
            else
            {
                this.rgvChiTiet.Columns["colKho"].ReadOnly = false;
            }

        }

        private void rbtnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNhanTraHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNhanTraHang nth = new CSQLNhanTraHang();
            if (fmain.MaNhanTraHang_ != null && fmain.MaNhanTraHang_.Length > 0)
            {
                try
                {
                    Guid KhoDen = new Guid("00000000-0000-0000-0000-000000000000");
                    if (cbxKho.SelectedIndex != -1) {
                        KhoDen = new Guid(cbxKho.SelectedValue.ToString());
                    }
                    if (nth.UpdateDaXetDuyet(fmain.MaNhanTraHang_, CStaticBien.SmaTaiKhoan, ckDuyet.Checked, KhoDen) > 0)
                    {
                        statusTB.Text = "Sửa thành công!";
                        rgvChiTiet.DataSource = nth.LayNhanTraHangCT_TheoNTHid(fmain.MaNhanTraHang_);
                        this.rgvChiTiet.Columns["colKho"].ReadOnly = false;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void rbtnIn_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(fmain.fNhanTraHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
        }

    }
}
