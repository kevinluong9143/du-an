using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;

namespace ECOPharma2013
{
    public partial class frmNT_LichSuGiaBan : Form
    {
        frmMain fmain;
        public frmNT_LichSuGiaBan(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }
        public void LoadLenLuoi()
        {
            try
            {
                CSQLNT_LichSuGiaBan LSGiaBan = new CSQLNT_LichSuGiaBan();
                rgvLichSuGiaBan.DataSource = LSGiaBan.LoadLenLuoi();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmNT_LichSuGiaBan_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLenLuoi();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
