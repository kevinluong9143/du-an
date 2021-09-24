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
    public partial class frmKiemTraXuatKhoEdit : Form
    {
        frmMain _frmMain;
        public frmKiemTraXuatKhoEdit()
        {
            InitializeComponent();
        }
        public frmKiemTraXuatKhoEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        CSQLKiemTraXuatKho ktxk_ = new CSQLKiemTraXuatKho();
        CSQLKiemTraXuatKhoCT ktxk_CT = new CSQLKiemTraXuatKhoCT();
        DataTable KTXK_CT = new DataTable();

        private void frmKiemTraXuatKhoEdit_Load(object sender, EventArgs e)
        {
            KTXK_CT= ktxk_CT.KiemTraXuatKhoCT_LayKTXKCT_TheoMa(_frmMain.MaKiemTraXuatKho_);
            if (_frmMain.IsXong == true)
            {
                btnLuu.Enabled = false;
                ckDaKiemTraXong.Enabled = false;
                rgvKiemTraXuatKho.ReadOnly = true;
                rgvKiemTraXuatKho.DataSource = KTXK_CT;
            }
            else
            {
                rgvKiemTraXuatKho.DataSource = KTXK_CT;
                btnLuu.Enabled = false;
                ckDaKiemTraXong.Enabled = false;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            _frmMain.frmKiemTraXuatKhoEditisOpen_ = false;
            this.Close();
        }
        int i = 0;
        private void rgvKiemTraXuatKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fKiemTraXuatKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                if (e.KeyChar == 13)
                {
                    if (rgvKiemTraXuatKho.CurrentColumn.Index == 12)
                    {
                        rgvKiemTraXuatKho.Rows[i].IsSelected = true;
                        rgvKiemTraXuatKho.Rows[i].Cells[12].IsSelected = true;
                        rgvKiemTraXuatKho.Rows[i].Cells[12].EndEdit();

                        if (decimal.Parse(rgvKiemTraXuatKho.Rows[i].Cells[9].Value.ToString()) != decimal.Parse(rgvKiemTraXuatKho.Rows[i].Cells[12].Value.ToString()))
                        {
                            MessageBox.Show("Số lượng chưa đúng với số lượng thực tế");
                            rgvKiemTraXuatKho.Rows[i].IsSelected = true;
                            rgvKiemTraXuatKho.Rows[i].Cells[12].IsSelected = true;
                            rgvKiemTraXuatKho.Rows[i].Cells[12].BeginEdit();
                        }
                        else
                        {
                            rgvKiemTraXuatKho.Rows[i].IsSelected = true;
                            rgvKiemTraXuatKho.Rows[i].Cells[13].IsSelected = true;
                            rgvKiemTraXuatKho.Rows[i].Cells[13].BeginEdit();
                        }
                        return;
                    }
                    if (rgvKiemTraXuatKho.CurrentColumn.Index == 13)
                    {
                        rgvKiemTraXuatKho.Rows[i].IsSelected = true;
                        rgvKiemTraXuatKho.Rows[i].Cells[13].IsSelected = true;
                        rgvKiemTraXuatKho.Rows[i].Cells[13].EndEdit();

                        if (rgvKiemTraXuatKho.CurrentRow.Cells[10].Value.ToString() != rgvKiemTraXuatKho.CurrentRow.Cells[13].Value.ToString())
                        {
                            MessageBox.Show("Số Lô chưa đúng Số Lô thực tế");
                            rgvKiemTraXuatKho.Rows[i].IsSelected = true;
                            rgvKiemTraXuatKho.Rows[i].Cells[13].IsSelected = true;
                            rgvKiemTraXuatKho.Rows[i].Cells[13].BeginEdit();
                        }
                        else
                        {
                            if (i != KTXK_CT.Rows.Count - 1)
                            {
                                rgvKiemTraXuatKho.Rows[i + 1].IsSelected = true;
                                rgvKiemTraXuatKho.Rows[i + 1].Cells[12].IsSelected = true;
                                rgvKiemTraXuatKho.Rows[i + 1].Cells[12].BeginEdit();
                                i = i + 1;
                            }
                            else
                            {
                                ckDaKiemTraXong.Enabled = true;
                                ckDaKiemTraXong.Focus();
                            }
                        }
                        return;
                    }
                }
            }
            catch { }
        }

        private void ckDaKiemTraXong_CheckedChanged(object sender, EventArgs e)
        {
            if (KTXK_CT.Rows.Count > 0)
            {
                ProgressBarKiemTra.Minimum = 0;
                ProgressBarKiemTra.Value = 0;
                for (int i = 0; i < KTXK_CT.Rows.Count; i++)
                {
                    ProgressBarKiemTra.Maximum = KTXK_CT.Rows.Count;
                    if (decimal.Parse(rgvKiemTraXuatKho.Rows[i].Cells[9].Value.ToString()) != decimal.Parse(rgvKiemTraXuatKho.Rows[i].Cells[12].Value.ToString()) && rgvKiemTraXuatKho.CurrentRow.Cells[10].Value.ToString() != rgvKiemTraXuatKho.CurrentRow.Cells[13].Value.ToString())
                    {
                        MessageBox.Show("Mặt hàng " + rgvKiemTraXuatKho.Rows[i].Cells[6].Value.ToString() + " có số lượng và hạn dùng chưa chính xác.");
                        return;
                    }
                    ProgressBarKiemTra.Value += 1;
                }
                ckDaKiemTraXong.Enabled = false;
                btnLuu.Enabled = true;
                lblTB.Text="Đã kiểm tra xong.";
            }
        }
        int update_1, upadte_2;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fKiemTraXuatKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            for (int i = 0; i < KTXK_CT.Rows.Count; i++)
            {
                string MaKTCTid_ = KTXK_CT.Rows[i]["KTCTid"].ToString();
                decimal SLthucte_ = decimal.Parse(KTXK_CT.Rows[i]["SLThucTe"].ToString());
                string Lotthucte_ = KTXK_CT.Rows[i]["LotThucTe"].ToString();
               update_1 = ktxk_CT.Update_SoLuong_Date(MaKTCTid_, SLthucte_, Lotthucte_);
            }
            upadte_2 = ktxk_.Update_IsXong_Date(_frmMain.MaKiemTraXuatKho_);
            if (update_1 == 1 && upadte_2 == 1)
            {
                lblTB.Text = "Thêm thông tin thành công.";
                _frmMain.fKiemTraXuatKho.rgvKiemTraXuatKho.DataSource = ktxk_.KiemTraXuatKho_LoadLenLuoi_IsXong(false);
                btnLuu.Enabled = false;
            }
        }

        private void frmKiemTraXuatKhoEdit_KeyDown(object sender, KeyEventArgs e)
        {
            //CQuyenTruyCap qtc = new CQuyenTruyCap();
            //if (qtc.KiemTraQuyenThem_Sua(_frmMain.fKiemTraXuatKho.Name) == false)
            //{
            //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
            //    return;
            //}
            if (e.KeyCode == Keys.F6)
            {
                ckDaKiemTraXong.Checked = true;
            }
            if (e.KeyCode == Keys.F5)
            {
                btnLuu_Click(sender,  e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnDong_Click(sender, e);
            }
        }

    }
}
