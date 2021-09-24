using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.DuLieu;
using ECOPharma2013.SQL;
using System.Transactions;

namespace ECOPharma2013
{
    public partial class frmNhanTraHangXacNhan : Form
    {
        frmMain fmain;
        public frmNhanTraHangXacNhan()
        {
            InitializeComponent();
        }
        public frmNhanTraHangXacNhan(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        public void LoadLenLuoi()
        {
            CSQLNhanTraHang nth = new CSQLNhanTraHang();
            try 
            {
                rgvPhieuTra.DataSource = nth.LayLenLuoiXacNhan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmNhanTraHangXacNhan_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void XacNhan()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNhanTraHangXacNhan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNhanTraHang nth = new CSQLNhanTraHang();
            try
            {
                for (int i = 0; i < rgvPhieuTra.Rows.Count; i++)
                {
                    rgvPhieuTra.Rows[i].Cells[0].EndEdit();
                    if (rgvPhieuTra.Rows[i].Cells[0].Value != null)
                    {
                        bool chon = (bool)rgvPhieuTra.Rows[i].Cells[0].Value;
                        if (chon == true)
                        {
                            TransactionOptions options = new TransactionOptions();
                            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            options.Timeout = new TimeSpan(0, 1, 0);
                            using (TransactionScope giaotac = new TransactionScope(TransactionScopeOption.Required, options))
                            {
                                nth.XacNhan(rgvPhieuTra.Rows[i].Cells["colNTHID"].Value.ToString(), CStaticBien.SmaTaiKhoan, DateTime.Now);
                                giaotac.Complete();
                            }
                        }
                    }
                }
                LoadLenLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
