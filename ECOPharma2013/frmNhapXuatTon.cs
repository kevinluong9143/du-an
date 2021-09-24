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
using Telerik.WinControls;
using ECOPharma2013.DuLieu;
using System.Drawing.Printing;
using System.IO;
using ECOPharma2013.From_Report;
using Telerik.WinControls.UI.Export;
using System.Runtime.InteropServices;

namespace ECOPharma2013
{
    public partial class frmNhapXuatTon : Form
    {
        frmMain _frmMain;
        public frmNhapXuatTon()
        {
            InitializeComponent();
        }
        public frmNhapXuatTon(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        int dt, mt, yt;
        private void frmNhapXuatTon_Load(object sender, EventArgs e)
        {
            dtDenNgay.Value = DateTime.Now;
            XuLyTuNgay();
        }

        private void XuLyTuNgay()
        {
            DateTime denngay = dtDenNgay.Value;
            DateTime ngaytruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
            //dt = denngay.Day;
            //mt = denngay.Month;
            //yt = denngay.Year;
            //dt -= 7;
            //if (dt <= 0)
            //{
            //    mt -= 1;
            //    if (mt < 1)
            //    {
            //        mt = 12;
            //        yt--;
            //    }
            //    dt = DateTime.DaysInMonth(yt, mt) + dt;
            //}
            //DateTime ngaytruoc = DateTime.Parse(mt.ToString() + "/" + dt.ToString() + "/" + yt.ToString());

            dtTuNgay.Value = ngaytruoc;
        }

        bool tinhton = true;
        public void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                CSQLNhapXuatTon nxt = new CSQLNhapXuatTon();
                CSQLSanPham sp = new CSQLSanPham();
                if (rbtnChonSP.Checked == true)
                {
                    string spid = sp.LaySanPhamTheoMaSP(txtSP.Text).Rows[0]["SPID"].ToString();
                    rgvNhapXuatTon.DataSource = nxt.LayDSNhapXuatTonTuNgay_DenNgay_MaSP(dtTuNgay.Value, dtDenNgay.Value, spid);
                }
                if (rbtnXemTatCa.Checked == true)
                {
                    rgvNhapXuatTon.DataSource = nxt.LayDSNhapXuatTonTuNgay_DenNgay(dtTuNgay.Value, dtDenNgay.Value);
                }
                if (tinhton == true)
                {
                    TinhTonKhiFilter();
                    tinhton = false;
                }
                rgvNhapXuatTon.CurrentRow = rgvNhapXuatTon.Rows[rgvNhapXuatTon.Rows.Count - 1];

            }
            catch { }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            CSQLNhapXuatTon nxt = new CSQLNhapXuatTon();
            CSQLSanPham sp = new CSQLSanPham();
            if (rbtnChonSP.Checked == true)
            {
                
                bool chonSP = rbtnChonSP.Checked;
                string spid = sp.LaySanPhamTheoMaSP(txtSP.Text).Rows[0]["SPID"].ToString();
                if (rgvNhapXuatTon.Rows.Count != rgvNhapXuatTon.ChildRows.Count)
                {
                    DataTable dt = ThietLapDataTableIn();
                    foreach (GridViewRowInfo row in rgvNhapXuatTon.ChildRows)
                    {
                        DataRow datarw;
                        datarw = dt.NewRow();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            datarw[i] = row.Cells[i].Value;
                        }
                        dt.Rows.Add(datarw);
                    }
                    Fr_NhapXuatTon check = new Fr_NhapXuatTon(dt, true, chonSP);
                    check.Show();
                }
                else
                {
                    Fr_NhapXuatTon check = new Fr_NhapXuatTon(dtTuNgay.Value, dtDenNgay.Value, spid, chonSP);
                    check.Show();
                }
            }
            if (rbtnXemTatCa.Checked == true)
            {
                if (rgvNhapXuatTon.Rows.Count != rgvNhapXuatTon.ChildRows.Count)
                {
                    DataTable dt = ThietLapDataTableIn();
                    foreach (GridViewRowInfo row in rgvNhapXuatTon.ChildRows)
                    {
                        DataRow datarw;
                        datarw = dt.NewRow();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            datarw[i] = row.Cells[i].Value;
                        }
                        dt.Rows.Add(datarw);
                    }
                    Fr_NhapXuatTon check = new Fr_NhapXuatTon(dt, true);
                    check.Show();
                }
                else
                {
                    Fr_NhapXuatTon check = new Fr_NhapXuatTon(dtTuNgay.Value, dtDenNgay.Value);
                    check.Show();
                }
            }
        }

        private static DataTable ThietLapDataTableIn()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NXTonID", typeof(string)));
            dt.Columns.Add(new DataColumn("NgayPhatSinh", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("SoChungTu", typeof(string)));
            dt.Columns.Add(new DataColumn("LoaiPhatSinh", typeof(string)));
            dt.Columns.Add(new DataColumn("SPid", typeof(string)));
            dt.Columns.Add(new DataColumn("MaSP", typeof(string)));
            dt.Columns.Add(new DataColumn("TenSP", typeof(string)));
            dt.Columns.Add(new DataColumn("SLNhap", typeof(float)));
            dt.Columns.Add(new DataColumn("SLXuat", typeof(float)));
            dt.Columns.Add(new DataColumn("SLTon", typeof(float)));
            dt.Columns.Add(new DataColumn("KhoID", typeof(string)));
            dt.Columns.Add(new DataColumn("TenKho", typeof(string)));
            dt.Columns.Add(new DataColumn("SLChuyen", typeof(float)));
            dt.Columns.Add(new DataColumn("DVT", typeof(string)));
            dt.Columns.Add(new DataColumn("TenDVT", typeof(string)));
            dt.Columns.Add(new DataColumn("Lot", typeof(string)));
            dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("MaNSX", typeof(string)));
            dt.Columns.Add(new DataColumn("TenNSX", typeof(string)));
            dt.Columns.Add(new DataColumn("Fromm", typeof(string)));
            dt.Columns.Add(new DataColumn("Tu", typeof(string)));
            dt.Columns.Add(new DataColumn("Destination", typeof(string)));
            dt.Columns.Add(new DataColumn("Den", typeof(string)));
            return dt;
        }

        private void txtSP_TextChanged(object sender, EventArgs e)
        {
            rbtnChonSP.Checked = true;
        }

        private void frmNhapXuatTon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXem_Click(sender, e);
            }
        }

        //private void rgvNhapXuatTon_RowFormatting(object sender, RowFormattingEventArgs e)
        //{
        //    //    if ((bool)e.RowElement.RowInfo.Cells["colKhongSuDung"].Value == true)
        //    //    {
        //    //        e.RowElement.DrawFill = true;
        //    //        e.RowElement.GradientStyle = GradientStyles.Solid;
        //    //        e.RowElement.BackColor = CColor.MauGVRow;
        //    //    }
        //}

        private void TinhTonKhiFilter()
        {
            rgvNhapXuatTon.MasterTemplate.ShowTotals = true;
            
            GridViewSummaryItem summaryItemIn = new GridViewSummaryItem();
            summaryItemIn.Name = "colSLNhap";
            summaryItemIn.Aggregate = GridAggregateFunction.Sum;
            summaryItemIn.FormatString = "{0:N2}";

            GridViewSummaryItem summaryItemSold = new GridViewSummaryItem();
            summaryItemSold.Name = "colSLXuat";
            summaryItemSold.Aggregate = GridAggregateFunction.Sum;
            summaryItemSold.FormatString = "{0:N2}";

            GridViewSummaryItem summaryItemOut = new GridViewSummaryItem();
            summaryItemOut.Name = "colSLChuyen";
            summaryItemOut.Aggregate = GridAggregateFunction.Sum;
            summaryItemOut.FormatString = "{0:N2}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItemIn);
            summaryRowItem.Add(summaryItemSold);
            summaryRowItem.Add(summaryItemOut);

            this.rgvNhapXuatTon.SummaryRowsTop.Add(summaryRowItem);
        }
        string spid;
        private void rgvNhapXuatTon_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (spid != rgvNhapXuatTon.CurrentRow.Cells["colSPid"].Value.ToString())
            {
                CSQLTonKho tonkho = new CSQLTonKho();
                //GridViewRowInfo row = rgvNhapXuatTon.ChildRows[0];
                //string d = row.Cells[4].Value.ToString();
                spid = rgvNhapXuatTon.CurrentRow.Cells["colSPid"].Value.ToString();
                DataTable dtb = tonkho.TonKho_LaySLTon_DVTid(spid);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    txtSLTon.Text = String.Format("{0:N2}", decimal.Parse(dtb.Rows[0]["tslton"].ToString()));
                    radLabel2.Text = dtb.Rows[0]["tendvt"].ToString();
                }
                else
                {
                    txtSLTon.Text = "";
                    radLabel2.Text = "";
                }                
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            ExportToExcelML exporter = new ExportToExcelML(this.rgvNhapXuatTon);
            exporter.ExportVisualSettings = true;

            string tempPath = Path.GetTempPath();
            tempPath += @"\tempExport" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
            exporter.RunExport(tempPath);

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            if (app == null)
            {
                Console.WriteLine("EXCEL không thể kích hoạt. Kiểm tra lại cài đặt office và các tham chiếu đã chính xác hay chưa.");
                return;
            }

            app.Visible = false;
            app.Interactive = false;

            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(tempPath);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            desktopPath += @"\NhapXuatTon" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";

            wb.SaveAs(desktopPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
            wb.Close();
            app.Quit();

            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(app);

            File.Delete(tempPath);
            MessageBox.Show("File đã xuất thành công, kiểm tra lại file trên desktop!");
        }
    }
}
