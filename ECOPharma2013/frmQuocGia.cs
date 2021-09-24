using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmQuocGia : Form
    {
        frmMain _frmMain;
        public frmQuocGia()
        {
            InitializeComponent();
        }
        public frmQuocGia(frmMain frmmain)
        {
            InitializeComponent();
            _frmMain = frmmain;
        }

        public void rgvDSQuocGia_DoubleClick(object sender, EventArgs e)
        {
            CSQLQuocGia quocgia_ = new CSQLQuocGia();
            if (rgvDSQuocGia.CurrentRow.Cells["colQGID"].Value == null)
            {
                return;
            }
            _frmMain.IsSuaQuocGia_ = true;
            if (_frmMain.frmQuocGiaEditisOpen_ == false)
            {
                _frmMain.MaQuocGiaCanSua_ = rgvDSQuocGia.CurrentRow.Cells["colQGID"].Value.ToString();
                _frmMain.BangQuocGiaCanSua_ = quocgia_.LayQuocGiaTheoMa(_frmMain.MaQuocGiaCanSua_);
                _frmMain.fQuocGiaEdit_ = new frmQuocGiaEdit(_frmMain);
                _frmMain.frmQuocGiaEditisOpen_ = true;
                _frmMain.fQuocGiaEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmQuocGiaEditisOpen_ == true)
            {
                _frmMain.fQuocGiaEdit_.Select();
                return;
            }        
        }

        private void rgvDSQuocGia_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = CColor.MauGVRow[1];
            }
        }

        private void frmQuocGia_Load(object sender, EventArgs e)
        {
            CSQLQuocGia quocgia_ = new CSQLQuocGia();
            rgvDSQuocGia.DataSource = quocgia_.LayDSQuocGiaLenLuoi(_frmMain.IsXemTatCa_);
        }
    }
}
