using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.Report1;
using ECOPharma2013.SQL;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_NT_NhapXuatTon : Form
    {
        DateTime _tu;
        DateTime _den;
        DataTable _inan;
        string _spid;
        bool _chonsp, _InFill;
        public Fr_NT_NhapXuatTon(DateTime Tu, DateTime Den, string Spid, bool chonsp)
        {
            InitializeComponent();
            _tu = Tu;
            _den = Den;
            _spid = Spid;
            _chonsp = chonsp;
        }
        public Fr_NT_NhapXuatTon(DataTable dtbinan, bool infill, bool chonsp)
        {
            InitializeComponent();
            _inan = dtbinan;
            _InFill = infill;
            _chonsp = chonsp;
        }
        public Fr_NT_NhapXuatTon(DateTime Tu, DateTime Den)
        {
            InitializeComponent();
            _tu = Tu;
            _den = Den;
        }
        public Fr_NT_NhapXuatTon(DataTable dtbinan, bool infill)
        {
            InitializeComponent();
            _inan = dtbinan;
            _InFill = infill;
        }
        private void RW_NhapXuatTon_Load(object sender, EventArgs e)
        {
            if (_chonsp == true)
            {
                CSQLNT_NhapXuatTon nxt = new CSQLNT_NhapXuatTon();
                Report_NXT_Tu_Den_MaSP check = new Report_NXT_Tu_Den_MaSP();
                if (_InFill == true)
                {
                    check.SetDataSource(_inan);
                }
                else
                {
                    check.SetDataSource(nxt.LayDSNT_NhapXuatTonTuNgay_DenNgay_MaSP(_tu, _den, _spid));
                }
                RW_NhapXuatTon.ReportSource = check;
            }
            else
            {
                CSQLNT_NhapXuatTon nxt = new CSQLNT_NhapXuatTon();
                Report_NXT_Tu_Den_MaSP check = new Report_NXT_Tu_Den_MaSP();
                if (_InFill == true)
                {
                    check.SetDataSource(_inan);
                }
                else
                {
                    check.SetDataSource(nxt.LayDSNT_NhapXuatTonTuNgay_DenNgay(_tu, _den));
                }
                RW_NhapXuatTon.ReportSource = check;
            }
        }

        private void Fr_NT_NhapXuatTon_Load(object sender, EventArgs e)
        {

        }
    }
}
