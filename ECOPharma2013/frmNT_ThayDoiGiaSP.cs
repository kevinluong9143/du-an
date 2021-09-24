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
    public partial class frmNT_ThayDoiGiaSP : Form
    {
        frmMain fmain;
        public frmNT_ThayDoiGiaSP(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }
        public frmNT_ThayDoiGiaSP()
        {
            InitializeComponent();
        }

        public void LoadLenLuoi()
        {
            try
            {
                CSQLNTThayDoiGiaSP tdg = new CSQLNTThayDoiGiaSP();
                rgvThayDoiGia.DataSource = tdg.LoadLenLuoi();
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

        public void HienFormEdit()
        {
            try
            {
                if (rgvThayDoiGia.Rows.Count > 0)
                {
                    if (fmain.frmNT_ThayDoiGiaSPEditisOpen_ == true)
                    {
                        fmain.fNT_ThayDoiGiaSPEdit.NhanThongTinThayDoiGia(rgvThayDoiGia.CurrentRow.Cells["colTDGID"].Value.ToString(), rgvThayDoiGia.CurrentRow.Cells["colSoCT"].Value.ToString());
                        fmain.fNT_ThayDoiGiaSPEdit.Select();
                        return;
                    }
                    else
                    {
                        fmain.fNT_ThayDoiGiaSPEdit = new frmNT_ThayDoiGiaSPEdit(fmain);
                        fmain.fNT_ThayDoiGiaSPEdit.NhanThongTinThayDoiGia(rgvThayDoiGia.CurrentRow.Cells["colTDGID"].Value.ToString(), rgvThayDoiGia.CurrentRow.Cells["colSoCT"].Value.ToString());
                        fmain.fNT_ThayDoiGiaSPEdit.ShowDialog();
                    }
                }
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

        private void frmNT_ThayDoiGiaSP_Load(object sender, EventArgs e)
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

        private void rgvThayDoiGia_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                HienFormEdit();
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
