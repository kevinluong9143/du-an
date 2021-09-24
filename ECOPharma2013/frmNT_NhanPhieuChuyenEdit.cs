using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls.UI;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmNT_NhanPhieuChuyenEdit : Form
    {
        public frmNT_NhanPhieuChuyenEdit()
        {
            InitializeComponent();
        }
        frmMain fmain;
        CSQLCauHinhHeThong chht_ = new CSQLCauHinhHeThong();
        public frmNT_NhanPhieuChuyenEdit(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
            CSQLNT_NhanPhieuChuyenCT npc = new CSQLNT_NhanPhieuChuyenCT();
            ((GridViewComboBoxColumn)this.rgvPhieuChuyenCT.Columns["colKho"]).DataSource = npc.LayKhoLenCBO();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            fmain.frmNT_NhanPhieuChuyenEditisOpen_ = false;
            this.Close();
        }

        //Khai báo toàn cục biến NCHID (chuyển hàng id)
        string NCHID;
        string SOPCH;

        /// <summary>
        /// Hàm dùng lấy nchid, sopch từ form chuyển hàng để chỉnh sửa
        /// </summary>
        /// <param name="_nchid"></param>
        /// <param name="_sopch"></param>
        public void NhanCHID_SoPCH(string _nchid, string _sopch)
        {
            NCHID = _nchid;
            SOPCH = _sopch;
        }

        private void frmNT_NhanPhieuChuyenEdit_Load(object sender, EventArgs e)
        {
            if (NCHID != null && NCHID.Length > 0)
            {
                CSQLNT_NhanPhieuChuyen npc = new CSQLNT_NhanPhieuChuyen();
                try 
                {
                    bool XemKhoDacBiet = (bool)chht_.LayDanhSachCauHinhHeThong().Rows[0]["IsXemKhoDacBiet"];
                    if (XemKhoDacBiet == true)
                        chkHangDacBiet.Show();
                    else
                        chkHangDacBiet.Hide();
                    DataTable dtbpc = npc.LayThongTinPhieuChuyen(NCHID);
                    if (dtbpc != null && dtbpc.Rows.Count > 0)
                    {
                        chkHangDacBiet.Enabled = false;
                        txtSoPC.Text = SOPCH;
                        txtNT.Text = dtbpc.Rows[0]["TenNT"].ToString();
                        txtGhiChu.Text = dtbpc.Rows[0]["GhiChu"].ToString();
                        dtNgayCT.Value = DateTime.Parse(dtbpc.Rows[0]["NgayChungTu"].ToString());
                        chkHangDacBiet.Checked = (bool)dtbpc.Rows[0]["ISKHODACBIET"];
                        if (bool.Parse(dtbpc.Rows[0]["DaXetDuyet"].ToString()) == true)
                        {
                            ckDuyetPhieu.Checked = true;
                            this.rgvPhieuChuyenCT.Columns["colKho"].ReadOnly = true;
                        }
                        else
                        {
                            ckDuyetPhieu.Checked = false;
                            this.rgvPhieuChuyenCT.Columns["colKho"].ReadOnly = false;
                        }

                        if (bool.Parse(dtbpc.Rows[0]["DAXACNHANNHAPKHO"].ToString()) == true)
                        {
                            ckDuyetPhieu.Enabled = false;
                        }
                        else
                        {
                            ckDuyetPhieu.Enabled = true;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                CSQLNT_NhanPhieuChuyenCT npcct = new CSQLNT_NhanPhieuChuyenCT();
                try
                {
                    rgvPhieuChuyenCT.DataSource = npcct.LoadLenLuoi(NCHID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ckDuyetPhieu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyetPhieu.Checked == true)
            {
                ckDuyetPhieu.Checked = true;
                this.rgvPhieuChuyenCT.Columns["colKho"].ReadOnly = true;
            }
            else
            {
                ckDuyetPhieu.Checked = false;
                this.rgvPhieuChuyenCT.Columns["colKho"].ReadOnly = false;
            }
        }

        private void MasterTemplate_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_NhanPhieuChuyen.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (rgvPhieuChuyenCT.CurrentCell.ColumnInfo.Name.CompareTo("colKho") == 0)
            {
                if (rgvPhieuChuyenCT.CurrentRow.Cells["colKho"].Value != null && rgvPhieuChuyenCT.CurrentRow.Cells["colKho"].Value.ToString().CompareTo("") > 0)
                {
                    CSQLNT_NhanPhieuChuyenCT npcct = new CSQLNT_NhanPhieuChuyenCT();
                    int kq = npcct.Sua(rgvPhieuChuyenCT.CurrentRow.Cells["colNCHCTID"].Value.ToString(), rgvPhieuChuyenCT.CurrentRow.Cells["colKho"].Value.ToString(), CStaticBien.SmaTaiKhoan);
                    if (kq > 0)
                    {
                        statusTB.Text = "Sửa thông tin kho: ['" + rgvPhieuChuyenCT.CurrentRow.Cells["colTenKho"].Value.ToString() + "'] thành công!";
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_NhanPhieuChuyen.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            if (NCHID!=null && NCHID.Length > 0)
            {
                CSQLNT_NhanPhieuChuyen npc = new CSQLNT_NhanPhieuChuyen();
                if (npc.Sua(NCHID, ckDuyetPhieu.Checked, CStaticBien.SmaTaiKhoan, chkHangDacBiet.Checked) > 0)
                {
                    statusTB.Text = "Sửa thông tin thành công!";
                }
                else
                {
                    statusTB.Text = "Sửa thông tin thất bại!";
                }
            }
        }

        private void rbtnIn_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(fmain.fNT_NhanPhieuChuyen.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
        }

    }
}
