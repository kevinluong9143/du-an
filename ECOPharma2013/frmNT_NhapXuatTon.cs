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
using Telerik.WinControls.Data;

namespace ECOPharma2013
{
    public partial class frmNT_NhapXuatTon : Form
    {
        frmMain _frmMain;
        public frmNT_NhapXuatTon()
        {
            InitializeComponent();
        }
        public frmNT_NhapXuatTon(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        private void frmNT_NhapXuatTon_Load(object sender, EventArgs e)
        {
            LayDSMaSP_TenSPLenMultiColumnCombobox();
            dtDenNgay.Value = DateTime.Now;
            XuLyTuNgay();
        }

        private void XuLyTuNgay()
        {
            DateTime denngay = dtDenNgay.Value;
            DateTime ngaytruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
            DateTime Thangtruoc = DateTime.Parse(denngay.Subtract(new TimeSpan(7, 0, 0, 0)).ToShortDateString());
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
        private void LayDSMaSP_TenSPLenMultiColumnCombobox()
        {
            try
            {
                CSQLSanPham sp_ = new CSQLSanPham();
                this.radMultiColumnComboBoxMaSP_BH.DataSource = sp_.SanPham_LayDSSanPhamlenMutiCombo();
                this.radMultiColumnComboBoxMaSP_BH.DisplayMember = "TenSP";
                this.radMultiColumnComboBoxMaSP_BH.ValueMember = "SPID";
                radMultiColumnComboBoxMaSP_BH.EditorControl.Columns["SPID"].IsVisible = false;
                radMultiColumnComboBoxMaSP_BH.EditorControl.Columns["MaSP"].Width = 65;
                radMultiColumnComboBoxMaSP_BH.EditorControl.Columns["TenSP"].Width = 455;
                this.radMultiColumnComboBoxMaSP_BH.AutoFilter = true;
                FilterDescriptor descriptorMaSP = new FilterDescriptor("MaSP", FilterOperator.Contains, null);
                this.radMultiColumnComboBoxMaSP_BH.EditorControl.FilterDescriptors.Add(descriptorMaSP);
                FilterDescriptor descriptorTenSP = new FilterDescriptor("TenSP", FilterOperator.Contains, null);
                this.radMultiColumnComboBoxMaSP_BH.EditorControl.FilterDescriptors.Add(descriptorTenSP);
                this.radMultiColumnComboBoxMaSP_BH.DropDownStyle = RadDropDownStyle.DropDown;
                radMultiColumnComboBoxMaSP_BH.MultiColumnComboBoxElement.DropDownWidth = 600;
                radMultiColumnComboBoxMaSP_BH.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.radMultiColumnComboBoxMaSP_BH.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                radMultiColumnComboBoxMaSP_BH.SelectedIndex = -1;
            }
            catch { }
        }
        bool tinhton = true;
        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                CSQLNT_NhapXuatTon nxt = new CSQLNT_NhapXuatTon();
                CSQLSanPham sp = new CSQLSanPham();
                if (rbtnChonSP.Checked == true)
                {
                    //string spid = sp.LaySanPhamTheoMaSP(txtSP.Text).Rows[0]["SPID"].ToString();
                    rgvNhapXuatTon.DataSource = nxt.LayDSNT_NhapXuatTonTuNgay_DenNgay_MaSP(dtTuNgay.Value, dtDenNgay.Value, radMultiColumnComboBoxMaSP_BH.SelectedValue.ToString());
                }
                if (rbtnXemTatCa.Checked == true)
                {
                    rgvNhapXuatTon.DataSource = nxt.LayDSNT_NhapXuatTonTuNgay_DenNgay(dtTuNgay.Value, dtDenNgay.Value);
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
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn("frmNT_NhapXuatTon") == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNT_NhapXuatTon nxt = new CSQLNT_NhapXuatTon();
            CSQLSanPham sp = new CSQLSanPham();
            if (rbtnChonSP.Checked == true)
            {
                bool chonSP = rbtnChonSP.Checked;
                //string spid = sp.LaySanPhamTheoMaSP(txtSP.Text).Rows[0]["SPID"].ToString();
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
                    Fr_NT_NhapXuatTon check = new Fr_NT_NhapXuatTon(dt, true, chonSP);
                    check.Show();
                }
                else
                {
                    Fr_NT_NhapXuatTon check = new Fr_NT_NhapXuatTon(dtTuNgay.Value, dtDenNgay.Value, radMultiColumnComboBoxMaSP_BH.SelectedValue.ToString(), chonSP);
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
                    Fr_NT_NhapXuatTon check = new Fr_NT_NhapXuatTon(dt, true);
                    check.Show();
                }
                else
                {
                    Fr_NT_NhapXuatTon check = new Fr_NT_NhapXuatTon(dtTuNgay.Value, dtDenNgay.Value);
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
            dt.Columns.Add(new DataColumn("mota", typeof(string)));
            return dt;
        }


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

                CSQLNT_NhapXuatTon aNhapXuatTon = new CSQLNT_NhapXuatTon();
                spid = rgvNhapXuatTon.CurrentRow.Cells["colSPid"].Value.ToString();
                DataTable dtb = aNhapXuatTon.LaySLTon(spid);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    txtTenSp.Text = rgvNhapXuatTon.CurrentRow.Cells["colTenSP"].Value.ToString();
                    txtSLTon.Text = String.Format("{0:N2}", decimal.Parse(dtb.Rows[0]["tslton"].ToString()));
                    radLabel2.Text = dtb.Rows[0]["tendvt"].ToString();
                    txtGiaBan.Text = String.Format("{0:N2}", decimal.Parse(dtb.Rows[0]["GiaBan"].ToString()));
                    radLabel3.Text = dtb.Rows[0]["tendvt"].ToString();
                }
                else
                {
                    txtTenSp.Text = "";
                    txtSLTon.Text = "";
                    radLabel2.Text = "";
                    txtGiaBan.Text = "";
                    radLabel3.Text = "";
                }

            }
        }

        private void frmNT_NhapXuatTon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXem_Click(sender, e);
            }
        }

        private void radMultiColumnComboBoxMaSP_BH_TextChanged(object sender, EventArgs e)
        {
            rbtnChonSP.Checked = true;
        }
    }
}
