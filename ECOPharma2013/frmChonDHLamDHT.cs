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
    public partial class frmChonDHLamDHT : Form
    {
        frmMain fmain = new frmMain();
        public frmChonDHLamDHT()
        {
            InitializeComponent();
        }
        public frmChonDHLamDHT(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }
        string dhmtid = "";

        private void btnDong_Click(object sender, EventArgs e)
        {
            fmain.frmChonDHLamDHTisOpen_ = false;
            this.Close();
        }

        private void frmChonDHLamDHT_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        private void LoadLenLuoi()
        {
            CSQLChonDHLamDHT dht = new CSQLChonDHLamDHT();
            rgvDHNhathuoc.DataSource = dht.LoadDuLieu();
        }


        private void btnTaoDHTong_Click(object sender, EventArgs e)
        {
            dhmtid = "";
            int kq = 0;
            foreach (GridViewDataRowInfo row in rgvDHNhathuoc.Rows)
            {
                if (row.Cells["colChon"].Value!=null && bool.Parse(row.Cells["colChon"].Value.ToString()) == true)
                {
                    if (dhmtid.Length == 0) //Thêm master
                    {
                        CSQLDonHangMuaTong dhmt = new CSQLDonHangMuaTong();
                        dhmtid = dhmt.Them(CStaticBien.SmaTaiKhoan);
                        //MessageBox.Show(dhmtid);
                    }
                    if (dhmtid.Length > 0) //Thêm detail
                    {
                        CSQLDonHangMuaTongCT dhmtct = new CSQLDonHangMuaTongCT();
                        if (dhmtct.Them(row.Cells["colDHID"].Value.ToString(), dhmtid, CStaticBien.SmaTaiKhoan)>0) 
                        //Cập nhật đơn hàng xuất
                        {
                            CSQLDonHangXuat dhx= new CSQLDonHangXuat();
                            kq = dhx.CapNhatDaTaoDonHangMuaTong(row.Cells["colDHID"].Value.ToString(), dhmtid);
                        }
                    }
                }
            }
            if (kq > 0)
            {
                LoadLenLuoi();
                MessageBox.Show("Đã tạo đơn hàng tổng!");
            }
        }

        private void btnTaoDHTuDo_Click(object sender, EventArgs e)
        {
            fmain.fDonHangMuaTong.HienFormChiTiet("", "");
        }
    }
}
