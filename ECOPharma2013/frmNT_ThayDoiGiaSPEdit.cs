using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using ECOPharma2013.From_Report;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmNT_ThayDoiGiaSPEdit : Form
    {
        public frmNT_ThayDoiGiaSPEdit()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmNT_ThayDoiGiaSPEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        string TDGID, SODH;

        public void NhanThongTinThayDoiGia(string tdgid, string sodh)
        {
            TDGID = tdgid;
            SODH = sodh;
        }

        private void frmNT_ThayDoiGiaSPEdit_Load(object sender, EventArgs e)
        {
            if (TDGID != null || TDGID.Length > 0)
            {
                CSQLNTThayDoiGiaSP tdg = new CSQLNTThayDoiGiaSP();
                DataTable dtb = tdg.Load1Record(TDGID);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    txtSoCT.Text = dtb.Rows[0]["SoCT"].ToString();
                    dtNgay.Value = DateTime.Parse(dtb.Rows[0]["Ngay"].ToString());
                }
                CSQLNTThayDoiGiaSPCT tdgid = new CSQLNTThayDoiGiaSPCT();
                rgvThayDoiGiaCT.DataSource = tdgid.LoadLenLuoi(TDGID);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            fmain.frmNT_ThayDoiGiaSPEditisOpen_ = false;
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            InThayDoiGiaSP(TDGID);
        }

        public void InThayDoiGiaSP(string tdgid_)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(fmain.fNT_ThayDoiGiaSP.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            CSQLNTThayDoiGiaSPCT tdgct_ = new CSQLNTThayDoiGiaSPCT();
            if (tdgid_ != null && tdgid_.Length > 0)
            {
                DataTable ThaDoiGiaSPCT_ = tdgct_.In_TDGSP_TDGSPTT(tdgid_);
                Fr_NTThayDoiGiaSP check = new Fr_NTThayDoiGiaSP(ThaDoiGiaSPCT_);
                check.Show();
            }
        }

        private void btnCapNhatGia_Click(object sender, EventArgs e)
        {
            CSQLNTThayDoiGiaSPCT tdgct_ = new CSQLNTThayDoiGiaSPCT();
            if (tdgct_.NTThayDoiGiaSPCT_CapNhatGia() > 0)
            {
                CSQLNTThayDoiGiaSPCT tdgid = new CSQLNTThayDoiGiaSPCT();
                rgvThayDoiGiaCT.DataSource = tdgid.LoadLenLuoi(TDGID);
            }
        }
    }
}
