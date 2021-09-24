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
using Telerik.WinControls.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Runtime.InteropServices;


namespace ECOPharma2013
{
    public partial class frmDonHangMuaTongEdit : Form
    {
        frmMain fmain;
        DataTable dsDonHangMuaTong = null;
        public frmDonHangMuaTongEdit()
        {
            InitializeComponent();
        }
        public frmDonHangMuaTongEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }
        string dhmtid, sodhtong;
        public void NhanDuLieuTuFormMaster(string _dhmtid, string _sodhtong)
        {
            dhmtid = _dhmtid;
            sodhtong = _sodhtong;
        }

        private void frmDonHangMuaTongEdit_Load(object sender, EventArgs e)
        {
            //Lấy thông tin lên controls
            #region
            try
            {
                this.mcboMaSP.DisplayMember = "TenSP";
                this.mcboMaSP.ValueMember = "SPNSXID";
                CSQLDonHangMuaTongCT dhmtongct = new CSQLDonHangMuaTongCT();
                mcboMaSP.DataSource = dhmtongct.LaySanPhamLenMCBO();
                this.mcboMaSP.AutoFilter = true;
                FilterDescriptor descriptorMaSP = new FilterDescriptor("MaSP", FilterOperator.IsEqualTo, null);
                this.mcboMaSP.EditorControl.FilterDescriptors.Add(descriptorMaSP);
                FilterDescriptor descriptorTenSP = new FilterDescriptor("TenSP", FilterOperator.StartsWith, null);
                this.mcboMaSP.EditorControl.FilterDescriptors.Add(descriptorTenSP);
                this.mcboMaSP.DropDownStyle = RadDropDownStyle.DropDown;
                this.mcboMaSP.MultiColumnComboBoxElement.DropDownWidth = 730;
                this.mcboMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;
                this.mcboMaSP.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;

                CSQLNPP npp = new CSQLNPP();
                mcboNPP.DisplayMember = "TenNPP";
                mcboNPP.ValueMember = "NPPID";
                mcboNPP.DataSource = npp.LayNPPLenLuoi(false);
                this.mcboNPP.AutoFilter = true;
                FilterDescriptor descriptorNPP = new FilterDescriptor("TenNPP", FilterOperator.StartsWith, null);
                this.mcboNPP.EditorControl.FilterDescriptors.Add(descriptorNPP);
                this.mcboNPP.DropDownStyle = RadDropDownStyle.DropDown;
                this.mcboNPP.MultiColumnComboBoxElement.DropDownWidth = 730;
                this.mcboNPP.MultiColumnComboBoxElement.DropDownHeight = 300;

                mcboMaSP.SelectedIndex = -1;
                mcboNPP.SelectedIndex = -1;
                cboDVT.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi phát sinh khi lấy thông tin lên MCBOMaSP: \n" + ex.Message);
            }
            #endregion

            //Lấy thông tin master
            CSQLDonHangMuaTong dhmtong = new CSQLDonHangMuaTong();
            if (dhmtid.Length > 0)
            {
                DataTable dtb = dhmtong.Lay1DonHangMuaTongTheoDHMTongID(dhmtid);
                if (dtb.Rows.Count > 0)
                {
                    if (dtb.Rows[0]["TinhTrangID"].ToString() == "2")
                    {
                        ckDuyetDH.Checked = true;
                        ckDuyetDH.Enabled = true;
                        btnTaoDHMua.Enabled = true;
                        btnThem.Enabled = false;
                    }
                    else if (dtb.Rows[0]["TinhTrangID"].ToString() == "3")
                    {
                        ckDuyetDH.Enabled = false;
                        btnTaoDHMua.Enabled = false;
                        btnThem.Enabled = false;
                        rgvDSCanMua.Columns["sldatmua"].ReadOnly = true;
                    }
                    else
                    {
                        ckDuyetDH.Checked = false;
                        ckDuyetDH.Enabled = true;
                        btnTaoDHMua.Enabled = true;
                        btnThem.Enabled = true;
                    }
                }
            }

            //Lấy detail
            LoadLenLuoi();
            LayDVTLenCbo();
            

        }
        public void LoadLenLuoi()
        {
            try
            {
                ((GridViewComboBoxColumn)rgvDSCanMua.Columns["colDVT"]).DisplayMember = "TenDVT";
                ((GridViewComboBoxColumn)rgvDSCanMua.Columns["colDVT"]).ValueMember = "DVTID";
                if (dhmtid.Length > 0)
                {
                    CSQLDonHangMuaTongCT dhmtongct = new CSQLDonHangMuaTongCT();
                    dsDonHangMuaTong = dhmtongct.LoadLenLuoi(dhmtid);
                    rgvDSCanMua.DataSource = dsDonHangMuaTong;
                    ((GridViewComboBoxColumn)rgvDSCanMua.Columns["colDVT"]).DataSource = dhmtongct.LayToanBoDVT();
                }
                else
                {
                    //MessageBox.Show("Không lấy được dữ liệu do không có mã (master)!");
                }

                if (sodhtong.Length > 0)
                {
                    lblSoDHT.Text = sodhtong;
                }
                else
                {
                    //MessageBox.Show("Không lấy được dữ liệu!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu lên lưới!\n" + ex.Message + "\n" + ex.InnerException.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            dhmtid = "";
            sodhtong = "";
            fmain.frmDonHangMuaTongEditisOpen_ = false;
            fmain.fDonHangMuaTong.LoadLenLuoi();
            this.Close();
        }

        public void LayDVTLenCbo()
        {
            CSQLDonHangMuaTongCT dhmtongct = new CSQLDonHangMuaTongCT();
            ((GridViewComboBoxColumn)rgvDSCanMua.Columns["colDVT"]).DataSource = dhmtongct.LayToanBoDVT();
        }


        public void LayDVTTheoSPID()
        {
            try
            {
                CSQLDonHangMuaTongCT dhmtongct = new CSQLDonHangMuaTongCT();

                ((GridViewComboBoxColumn)rgvDSCanMua.Columns["colDVT"]).DataSource = dhmtongct.LayDVTTheoSPID(rgvDSCanMua.CurrentRow.Cells["SPID"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lấy DVT: \n" + ex.Message);
            }
        }
        private void MasterTemplate_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column.Name == "colDVT")
            {
                LayDVTTheoSPID();
            }
        }

        private void rgvDSCanMua_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "colDVT")
            {
                LayDVTLenCbo();
            }

            if (e.Column.Name == "SLDatMua")
            {
                //Lưu dòng
                try
                {
                    CSQLDonHangMuaTongCT dhmtct = new CSQLDonHangMuaTongCT();
                    if (rgvDSCanMua.CurrentRow.Cells["DHMTongCTID"] != null && rgvDSCanMua.CurrentRow.Cells["SLDatMua"] != null && rgvDSCanMua.CurrentRow.Cells["SLDatMua"].Value.ToString().Length>0)
                    {
                        int kq = dhmtct.SuaSLDatMua(rgvDSCanMua.CurrentRow.Cells["DHMTongCTID"].Value.ToString(), decimal.Parse(rgvDSCanMua.CurrentRow.Cells["SLDatMua"].Value.ToString()), CStaticBien.SmaTaiKhoan);
                        if (kq > 0)
                        {
                            DataTable dtbkq = dhmtct.Lay1DonHangMuaTongCTTheoDHMTongID(rgvDSCanMua.CurrentRow.Cells["DHMTongCTID"].Value.ToString());
                            rgvDSCanMua.CurrentRow.Cells["TTGiaMuaChuaTaxChuaChietKhau"].Value = dtbkq.Rows[0]["TTGiaMuaChuaTaxChuaChietKhau"];
                            rgvDSCanMua.CurrentRow.Cells["TTChietKhau"].Value = dtbkq.Rows[0]["TTChietKhau"];
                            rgvDSCanMua.CurrentRow.Cells["TTGiaMuaChuaTaxDaChietKhau"].Value = dtbkq.Rows[0]["TTGiaMuaChuaTaxDaChietKhau"];
                            rgvDSCanMua.CurrentRow.Cells["TTTAX"].Value = dtbkq.Rows[0]["TTTAX"];
                            rgvDSCanMua.CurrentRow.Cells["TTGiaMuaDaChietKhauCoTAX"].Value = dtbkq.Rows[0]["TTGiaMuaDaChietKhauCoTAX"];
                            rgvDSCanMua.CurrentRow.Cells["NVUD"].Value = dtbkq.Rows[0]["NVUD"];
                            rgvDSCanMua.CurrentRow.Cells["LastUD"].Value = dtbkq.Rows[0]["LastUD"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi phát sinh khi sửa số lượng đặt: \n" + ex.Message);
                }
            }
            
        }

        private void rgvDSCanMua_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (ckDuyetDH.Checked == false)
            {
                HienFormChonNPP();
            }
        }

        private void HienFormChonNPP()
        {
            fmain.fChonNPP = new frmChonNPP(fmain);
            if (rgvDSCanMua.CurrentRow.Cells["DHMTONGCTID"] != null && rgvDSCanMua.CurrentRow.Cells["SPID"] != null && rgvDSCanMua.CurrentRow.Index!=-1)
            {
                fmain.fChonNPP.NhanDuLieu(rgvDSCanMua.CurrentRow.Cells["DHMTONGCTID"].Value.ToString(), rgvDSCanMua.CurrentRow.Cells["SPID"].Value.ToString());
                fmain.fChonNPP.ShowDialog();
                CSQLDonHangMuaTongCT dhmtongct = new CSQLDonHangMuaTongCT();
                DataTable dtbkq = dhmtongct.Lay1DonHangMuaTongCTTheoDHMTongID(rgvDSCanMua.CurrentRow.Cells["DHMTongCTID"].Value.ToString());
                if (dtbkq.Rows.Count > 0)
                {
                    rgvDSCanMua.CurrentRow.Cells["TenNPP"].Value = dtbkq.Rows[0]["TenNPP"];
                    rgvDSCanMua.CurrentRow.Cells["NPPID"].Value = dtbkq.Rows[0]["NPPID"];
                }
            }
        }

        private void rgvDSCanMua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                if(ckDuyetDH.Checked == false && ckDuyetDH.Enabled == true)
                    HienFormChonNPP();
            }
        }

        private void ckDuyetDH_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyetDH.Checked == true && ckDuyetDH.Enabled == true)
            {
                //update tinh trang cua don hang thanh 2 
                CSQLDonHangMuaTong dhmtong = new CSQLDonHangMuaTong();
                int kq = dhmtong.CapNhatTinhTrangDonHangMuaTong(dhmtid, CStaticBien.SmaTaiKhoan, 2);
                if (kq > 0)
                {
                    //Thành công
                }
                else
                {
                    MessageBox.Show("Cập nhật đơn hàng tổng thất bại");
                }
                rgvDSCanMua.Columns["sldatmua"].ReadOnly = true;
                btnThem.Enabled = false;
            }
            else if (ckDuyetDH.Checked == false && ckDuyetDH.Enabled == true)
            {
                //update tinh trang cua don hang thanh 1
                CSQLDonHangMuaTong dhmtong = new CSQLDonHangMuaTong();
                int kq = dhmtong.CapNhatTinhTrangDonHangMuaTong(dhmtid, CStaticBien.SmaTaiKhoan, 1);
                if (kq > 0)
                {
                    //Thành công
                }
                else
                {
                    MessageBox.Show("Cập nhật đơn hàng tổng thất bại");
                }
                rgvDSCanMua.Columns["sldatmua"].ReadOnly = false;
                btnThem.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
            }
        }

        private void btnTaoDHMua_Click(object sender, EventArgs e)
        {
            CSQLDonHangMuaTong dhmtong = new CSQLDonHangMuaTong();
            //
            //b1: Tao don hang mua theo nha phan phoi luu vao econhapkho & econhapkhoct
            //b2: cap nhat tinh trang cua don hang tong thanh 3
            //
            int kq = dhmtong.TaoDonDatHang(dhmtid, CStaticBien.SmaTaiKhoan);
            if (kq > 0)
            {
                MessageBox.Show("Thêm thành công");
            }
            
        }

        //Lấy ds dvt, npp
        private void mcboMaSP_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (mcboMaSP.SelectedValue != null || mcboMaSP.SelectedIndex != -1)
                {
                    CSQLDonHangMuaTongCT dhmtongct = new CSQLDonHangMuaTongCT();
                    cboDVT.DataSource = dhmtongct.LayDVTTheoSPID(mcboMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                    cboDVT.DisplayMember = "TenDVT";
                    cboDVT.ValueMember = "DVTID";
                    if (mcboMaSP.EditorControl.CurrentRow.Cells["DVNhap"].Value.ToString().Length > 0)
                        cboDVT.SelectedValue = mcboMaSP.EditorControl.CurrentRow.Cells["DVNhap"].Value.ToString();
                    else
                        cboDVT.SelectedValue = -1;
                    if (mcboMaSP.EditorControl.CurrentRow.Cells["NPPID"].Value.ToString().Length > 0)
                        mcboNPP.SelectedValue = mcboMaSP.EditorControl.CurrentRow.Cells["NPPID"].Value;
                    else
                        mcboNPP.SelectedValue = -1;
                }
                else
                {
                    mcboNPP.SelectedIndex = -1;
                    cboDVT.SelectedIndex = -1;
                }
            }
            catch (Exception ex) {MessageBox.Show("Lỗi khi lấy DVT, NPP: \n" + ex.Message);}
        }

        private void mcboMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                mcboMaSP.SelectedIndex = -1;
            }
        }

        private void txtSoLuongDat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ckDuyetDH.Checked == false && ckDuyetDH.Enabled == true)
            {
                if (mcboMaSP.SelectedValue == null || mcboMaSP.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm!");
                    mcboMaSP.Focus();
                    return;
                }
                if (txtSoLuongDat.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn số lượng!");
                    txtSoLuongDat.Focus();
                    return;
                }
                if (cboDVT.SelectedValue == null || cboDVT.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn chưa chọn DVT!");
                    cboDVT.Focus();
                    return;
                }
                if (mcboNPP.SelectedValue == null || mcboNPP.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn chưa chọn nhà phân phối!");
                    mcboNPP.Focus();
                    return;
                }
                //Them dhmt(master) nếu chưa có mã
                if (dhmtid.Length == 0 && sodhtong.Length == 0)
                {
                    CSQLDonHangMuaTong dhmt = new CSQLDonHangMuaTong();
                    dhmtid = dhmt.Them(CStaticBien.SmaTaiKhoan);
                    DataTable dtb = dhmt.Lay1DonHangMuaTongTheoDHMTongID(dhmtid);
                    sodhtong = lblSoDHT.Text = dtb.Rows[0]["SoDHMT"].ToString();
                }


                //Thêm dhmtchitiet
                CSQLDonHangMuaTongCT dhmtct = new CSQLDonHangMuaTongCT();
                int kq = dhmtct.Them(dhmtid, mcboMaSP.SelectedValue.ToString(), decimal.Parse(txtSoLuongDat.Text), cboDVT.SelectedValue.ToString(), mcboNPP.SelectedValue.ToString(), CStaticBien.SmaTaiKhoan);
                if (kq > 0)
                {
                    //MessageBox.Show("Thêm thành công");
                    LoadLenLuoi();
                    txtSoLuongDat.Text = "";
                    mcboMaSP.SelectedIndex = -1;
                    mcboNPP.SelectedIndex = -1;
                    cboDVT.SelectedIndex = -1;
                }
            }
        }

        private void rgvDSCanMua_UserDeletedRow(object sender, GridViewRowEventArgs e)
        {

        }

        private void rgvDSCanMua_UserDeletingRow(object sender, GridViewRowCancelEventArgs e)
        {
            CSQLDonHangMuaTongCT dhmtct = new CSQLDonHangMuaTongCT();
            if (rgvDSCanMua.RowCount > 0 && ckDuyetDH.Checked == false)
            {
                if (dhmtct.Xoa(rgvDSCanMua.CurrentRow.Cells["DHMTongCTID"].Value.ToString()) > 0)
                {
                    //MessageBox.Show("Xóa thành công");
                    LoadLenLuoi();
                }
            }
        }

        private void frmDonHangMuaTongEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
                btnThem_Click(sender, e);
        }

        private void mcboNPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                mcboNPP.SelectedIndex = -1;
            }
        }

        private void cboDVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cboDVT.SelectedIndex = -1;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (rgvDSCanMua.Rows.Count>0)
            {
                ExportToExcelML exporter = new ExportToExcelML(this.rgvDSCanMua);
                exporter.ExportVisualSettings = true;

                string tempPath = Path.GetTempPath();
                tempPath += @"\tempDonHangMuaTong" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
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
                desktopPath += @"\DonHangMuaTong" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";

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
}
