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
    public partial class frmChonNPP : Form
    {
        frmMain fmain;
        string SPID;
        string DHMTONGCTID;
        public frmChonNPP(frmMain _frmMain)
        {
            InitializeComponent();
            _frmMain = fmain;
        }

        public void NhanDuLieu(string _dHMTongCTid, string _spid)
        {
            SPID = _spid;
            DHMTONGCTID = _dHMTongCTid;
        }

        private void frmChonNPP_Load(object sender, EventArgs e)
        {
            if (SPID != null && SPID.Length > 0)
            {
                CSQLChonNPP chonNPP = new CSQLChonNPP();
                rgvDSNPP.DataSource = chonNPP.Lay3NPPMuaGanNhat(SPID);
            }
        }

        private void rgvDSNPP_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //Lưu npp này cho vào bảng Đơn hàng mua tổng Edit
            LuuNPPVaoDHTongCT();
        }

        private void LuuNPPVaoDHTongCT()
        {
            if (DHMTONGCTID != null && DHMTONGCTID.Length > 0 && rgvDSNPP.Rows.Count > 0)
            {
                CSQLDonHangMuaTongCT dhmtct = new CSQLDonHangMuaTongCT();
                if (dhmtct.SuaNPP(DHMTONGCTID, rgvDSNPP.CurrentRow.Cells["NPPID"].Value.ToString(), CStaticBien.SmaTaiKhoan) > 0)
                {
                    this.Close();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChonNPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MasterTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LuuNPPVaoDHTongCT();
            }
        }
    }
}
