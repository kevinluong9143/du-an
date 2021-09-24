﻿using System;
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
using ECOPharma2013.From_Report;

namespace ECOPharma2013
{
    public partial class frmDonHangXuatEdit : Form
    {
        frmMain fmain;
        public frmDonHangXuatEdit()
        {
            InitializeComponent();
        }
        public frmDonHangXuatEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        string DHID = "00000000-0000-0000-0000-000000000000", SODH, DHCTID;
        int CURROW_Index = 0;
        public void NhanThongTinTuFormDonHangXuat(string dhid, string sodh)
        {
            DHID = dhid;
            SODH = sodh;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            fmain.fDonHangXuat.LoadLenLuoi();
            fmain.BangDonHangXuatCanSua_ = null;
            fmain.MaDonHangXuatCanSua_ = "";
            fmain.frmDonHangXuatEditisOpen_ = false;
            this.Close();

        }

        private void frmDonHangXuatEdit_Load(object sender, EventArgs e)
        {
            KiemTraDanhSachChiTietKho(DHID);
            txtSLDapUng.Text = "0";
            txtSLTon.Text = "0";
            txtSLCoTheXuat.Text = "0";
            LayDSNhaThuoc();
            
            if (DHID != null && DHID.Length > 0 && DHID.CompareTo("00000000-0000-0000-0000-000000000000") != 0)
            {
                //Lấy thông tin donhangxuat và đơn hàng xuất chi tiết vào form
                LayThongTinDonHangXuat(DHID);
                btnImport.Enabled = false;
                CSQLDonHangXuat dhx = new CSQLDonHangXuat();

                if (dhx.KiemTraXacNhanDonHang(SODH) == true)
                {
                    ckDuyetDonHang.Enabled = false;
                    // DungLV add Xuat Chi Dinh Don Hang start
                    cbIsXuatChiDinh.Enabled = false;
                    // DungLV add Xuat Chi Dinh Don Hang end
                    btnLuu.Enabled = false;
                    btnAdd.Enabled = false;
                }
                else
                {
                    ckDuyetDonHang.Enabled = true;
                    btnLuu.Enabled = true;
                    // DungLV add Xuat Chi Dinh Don Hang start
                    if (ckDonHangKhan.Checked == true && ckDonHangKhan.Enabled == true)
                        cbIsXuatChiDinh.Enabled = true;
                    else
                    {
                        cbIsXuatChiDinh.Enabled = false;
                    }
                    // DungLV add Xuat Chi Dinh Don Hang end
                    LayTenSPToAutoCompleCombobox();
                }

                IsNT();
            }
            else
            {
                // DungLV add Xuat Chi Dinh Don Hang start
                cbIsXuatChiDinh.Enabled = false;
                cbIsXuatThuCong.Enabled = true;
                // DungLV add Xuat Chi Dinh Don Hang end
                LayTenSPToAutoCompleCombobox();
            }
            cboNSX.SelectedIndex = -1;
            cboKho.SelectedIndex = -1;
            cboNhaThuoc.Focus();
            rgvDonHangChiTiet.CellFormatting += new CellFormattingEventHandler(rgvDonHangChiTiet_CellFormatting);
            Fr_DangXuLy.DongFormCho();
        }

        void rgvDonHangChiTiet_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                if (e.CellElement.ColumnInfo.Name == "colSTT" && string.IsNullOrEmpty(e.CellElement.Text))
                {
                    e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
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

        //Hàm lấy ds nhà thuốc lên combobox nhà thuốc
        private void LayDSNhaThuoc()
        {
            CSQLNhaThuoc nt = new CSQLNhaThuoc();
            DataTable dtb = nt.NhaThuoc_LayDSNhaThuocLenCBBox();
            cboNhaThuoc.ValueMember = "NTID";
            cboNhaThuoc.DisplayMember = "TenNT";
            cboNhaThuoc.DataSource = dtb;
            cboNhaThuoc.SelectedIndex = -1;
        }


        //Hàm hiển thị picture khẩn cấp khi chọn vào ckbox DonHangKhan
        private void ckDonHangKhan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckDonHangKhan.Checked == true)
                {
                    picCapCuu.Visible = true;
                    btnImport.Enabled = false;
                    // DungLV add Xuat Chi Dinh Don Hang start
                    cbIsXuatChiDinh.Enabled = true;
                    // DungLV add Xuat Chi Dinh Don Hang end
                }
                else
                {
                    picCapCuu.Visible = false;
                    btnImport.Enabled = true;
                    // DungLV add Xuat Chi Dinh Don Hang start
                    cbIsXuatChiDinh.Checked = false;
                    cbIsXuatChiDinh.Enabled = false;
                    // DungLV add Xuat Chi Dinh Don Hang end
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }


        #region Khoi tao du lieu len form
        #region MultiColumnCombobox MaSP, TenSP
        #region  Xử lý lấy dữ liệu lên MultiColumnCombobox
        private void LayTenSPToAutoCompleCombobox()
        {
            CSQLDonHangXuatCT tk = new CSQLDonHangXuatCT();
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            DataTable dtbMaSP_TenSP = tk.LayMaSP_TenSP(cbkHangDacBiet.Checked);

            radMultiColumnComboBoxMaSP.ValueMember = "SPNSXID";
            radMultiColumnComboBoxMaSP.DisplayMember = "MaSP";
            radMultiColumnComboBoxMaSP.DataSource = dtbMaSP_TenSP;

            radMultiColumnComboBoxTenSP.ValueMember = "SPNSXID";
            radMultiColumnComboBoxTenSP.DisplayMember = "TenSP";
            radMultiColumnComboBoxTenSP.DataSource = dtbMaSP_TenSP;
            radMultiColumnComboBoxMaSP.SelectedIndex = -1;
            radMultiColumnComboBoxTenSP.SelectedIndex = -1;

            radMultiColumnComboBoxMaSP.EditorControl.Columns["SPID"].IsVisible = false;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["DVTID_Chuan"].IsVisible = false;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["MaSP"].Width = 65;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["TenSP"].Width = 250;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["TenNSX"].Width = 150;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["SLTon"].Width = 65;
            radMultiColumnComboBoxMaSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
            radMultiColumnComboBoxMaSP.EditorControl.Columns["DVChuan"].Width = 65;
            radMultiColumnComboBoxMaSP.AutoFilter = true;
            FilterDescriptor descriptor = new FilterDescriptor(this.radMultiColumnComboBoxMaSP.DisplayMember, FilterOperator.IsEqualTo, string.Empty);
            this.radMultiColumnComboBoxMaSP.EditorControl.FilterDescriptors.Add(descriptor);
            this.radMultiColumnComboBoxMaSP.DropDownStyle = RadDropDownStyle.DropDown;
            radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownWidth = 630;
            radMultiColumnComboBoxMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;

            radMultiColumnComboBoxTenSP.EditorControl.Columns["SPID"].IsVisible = false;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["NSXID"].IsVisible = false;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["DVTID_Chuan"].IsVisible = false;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["MaSP"].Width = 65;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["TenSP"].Width = 250;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["TenNSX"].Width = 150;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["SLTon"].Width = 65;
            radMultiColumnComboBoxTenSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
            radMultiColumnComboBoxTenSP.EditorControl.Columns["DVChuan"].Width = 65;
            radMultiColumnComboBoxTenSP.AutoFilter = true;
            FilterDescriptor descriptor1 = new FilterDescriptor(this.radMultiColumnComboBoxTenSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
            this.radMultiColumnComboBoxTenSP.EditorControl.FilterDescriptors.Add(descriptor1);
            this.radMultiColumnComboBoxTenSP.DropDownStyle = RadDropDownStyle.DropDown;
            radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownWidth = 630;
            radMultiColumnComboBoxTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;

        }
        #endregion
        #region  Xử lý khi chọn MaSP khác giữa 2 MultiColumnCombobox
        private void radMultiColumnComboBoxMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radMultiColumnComboBoxTenSP.SelectedValue == null || (radMultiColumnComboBoxTenSP.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedValue.ToString().CompareTo(radMultiColumnComboBoxTenSP.SelectedValue.ToString()) != 0))
                {
                    radMultiColumnComboBoxTenSP.SelectedValue = radMultiColumnComboBoxMaSP.SelectedValue;
                }
                if (radMultiColumnComboBoxMaSP.SelectedValue != null)
                {
                    //fmain.MaSP_DHXCanChon_ = radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString();
                    LayNSXLenCboNSX(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                    txtSLDapUng.Focus();
                }
                else
                {
                    radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                    radMultiColumnComboBoxMaSP.SelectedValue = null;
                    cboNSX.SelectedIndex = -1;
                    cbxSoLo.SelectedIndex = -1;
                    cboDVT.SelectedIndex = -1;
                    cboKho.SelectedIndex = -1;
                    txtSLCoTheXuat.Text = "";
                    txtSLDapUng.Text = "";
                    txtSLDat.Text = "";
                    txtSLTon.Text = "";
                    txtDVC.Text = "";
                }
                RadMultiColumnComboBox comboBox = (RadMultiColumnComboBox)sender;
                RadTextBoxItem rtbi = (RadTextBoxItem)comboBox.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                rtbi.SelectionLength = 0;
            }
            catch
            {
                statusTB.Text = "";
            }
        }
        private void radMultiColumnComboBoxTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radMultiColumnComboBoxTenSP.SelectedValue != null && radMultiColumnComboBoxTenSP.SelectedIndex != -1)
            {
                //Lấy mã sp
                if (radMultiColumnComboBoxMaSP.SelectedValue == null || (radMultiColumnComboBoxMaSP.SelectedValue != null && radMultiColumnComboBoxTenSP.SelectedValue.ToString().CompareTo(radMultiColumnComboBoxMaSP.SelectedValue.ToString()) != 0))
                {
                    radMultiColumnComboBoxMaSP.SelectedValue = radMultiColumnComboBoxTenSP.SelectedValue;
                }
            }
            RadMultiColumnComboBox comboBox = (RadMultiColumnComboBox)sender;
            RadTextBoxItem rtbi = (RadTextBoxItem)comboBox.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
            rtbi.SelectionLength = 0;
        }
        #endregion
        #endregion
        #region  Lấy thông tin sản phẩm để làm source autocomplete cho txt - Đã hủy
        //private void LayIDMaTenSPToAutoComplete()
        //{
        //    AutoCompleteStringCollection tenSPTonKho = new AutoCompleteStringCollection();
        //    AutoCompleteStringCollection maSPTonKho = new AutoCompleteStringCollection();
        //    CSQLTonKho tk = new CSQLTonKho();
        //    DataTable dtb = tk.LayMaSP_TenSP();
        //    foreach (DataRow dr in dtb.Rows)
        //    {
        //        tenSPTonKho.Add((string)dr["TenSP"]);
        //        maSPTonKho.Add((string)dr["MaSP"]);
        //    }
        //    txtTenSP.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    txtTenSP.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    txtTenSP.AutoCompleteCustomSource = tenSPTonKho;

        //    txtMaSP.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    txtMaSP.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    txtMaSP.AutoCompleteCustomSource = maSPTonKho;
        //}
        #endregion
        #region Lấy thông tin lên ColumnCombobox Nhà Sản Xuất
        private void LayNSXLenCboNSX(string spid)
        {
            if (spid != null && spid.Length > 0)
            {
                CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                cboNSX.DisplayMember = "TenNSX";
                cboNSX.ValueMember = "NSXID";
                cboNSX.DataSource = spnsx.LayNSXVaoCBX(spid);
                cboNSX.SelectedValue = new Guid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
            }
            else
                cboNSX.DataSource = null;
        }
        #endregion
        #region Lấy thông tin lên combobox Kho
        private void LayKho(string spid, string nsxid)
        {
            if (spid != null && spid.Length > 0 && nsxid != null && nsxid.Length > 0)
            {
                CSQLDonHangXuatCT tkct = new CSQLDonHangXuatCT();
                DataTable dtb = tkct.LayTTKho(spid, nsxid);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                    CSQLKho kho = new CSQLKho();
                    if (cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet())
                    {
                        string mabp_ = chht.LayDanhSachCauHinhHeThong().Rows[0]["MaBP"].ToString();
                        string MaBPcon = "";
                        CSQLBoPhan bp_ = new CSQLBoPhan();
                        DataTable bpct_ = bp_.TimMaBPChaTheoMa(mabp_);
                        string mabpcha = bpct_.Rows[0]["MaBPCha"].ToString();
                        if (mabpcha != null && mabpcha.Length > 0)
                        {
                            MaBPcon = mabpcha;
                        }
                        else
                        {
                            MaBPcon = mabp_;
                        }

                        cboKho.DisplayMember = "TenKho";
                        cboKho.ValueMember = "KhoID";
                        cboKho.DataSource = kho.LayKhoDacBiet_TongCongTy(MaBPcon);
                    }
                    else
                    {
                        statusTB.Text = "";
                        cboKho.DataSource = dtb;
                        cboKho.DisplayMember = "TenKho";
                        cboKho.ValueMember = "KhoID";
                        CSQLSanPham_Kho spk = new CSQLSanPham_Kho();
                        string khoid = spk.LayMaKhoMacDinhKhiXuat(spid);
                        if (khoid != null && khoid.Length > 0)
                        {
                            cboKho.SelectedValue = khoid;
                            statusTB.Text = "";
                        }
                        else
                        {
                            cboKho.SelectedIndex = -1;
                            statusTB.Text = "Thông báo: Chưa có kho xuất mặc định cho sản phẩm này!";
                            txtTongSL.Text = "0";
                            txtDVC.Text = "";
                            return;
                        }
                    }
                }
                else
                {
                    cboKho.DataSource = null;
                    statusTB.Text = "Thông báo: Chưa có kho nào chứa sản phẩm của nhà sản xuất này!";
                    txtTongSL.Text = "0";
                    txtDVC.Text = "";
                    return;
                }
            }
            else
            {
                cboKho.DataSource = null;
                statusTB.Text = "Thông báo: Không xác định được sản phẩm hoặc nhà sản xuất để lấy kho!";
                return;
            }
        }
        #endregion
        #region Lấy thông tin lên DVT
        private void LayThongTinDVTKhiKhoIDThayDoi(string spid, string khoid)
        {
            if (spid != null && khoid != null && spid.Length > 0 && khoid.Length > 0)
            {
                //Lấy danh sách DVT từ bảng hệ số qui đổi
                cboDVT.DisplayMember = "TenTuDVT";
                cboDVT.ValueMember = "TuDVTID";
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                DataTable dsdvt = hsqd.LayDVTTheoSPID(spid);
                if (dsdvt != null && dsdvt.Rows.Count > 0)
                {
                    cboDVT.DataSource = dsdvt;
                }
                else
                {
                    cboDVT.DataSource = null;
                    txtDVC.Text = "";
                    dtHanDung.Value = DateTime.MaxValue;
                    txtSLTon.Text = "0";
                    txtSLCoTheXuat.Text = "0";
                    txtTongSL.Text = "0";
                    //txtSLCoTheXuatTheoSP.Text = "0";
                    txtDVC.Text = cboDVT.Text;
                }
                //Lấy dvchuan từ bảng Tồn kho chi tiết để làm dv mặc định
                //CSQLTonKhoCT tkct = new CSQLTonKhoCT();
                //DataTable dtb = tkct.LayTTKDVT(spid, khoid);

                CSQLSanPham sp = new CSQLSanPham();
                DataTable dtb = sp.SanPham_LayDVNhap_DVXuat_DVBan_DVChuan_TheoSPID(spid);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    cboDVT.SelectedValue = dtb.Rows[0]["DVXuat"].ToString();
                    txtDVC.Text = cboDVT.Text;
                    try
                    {
                        decimal tyle = (decimal)hsqd.TinhTyLeHSQD(spid, cboDVT.SelectedValue.ToString());
                        txtTongSL.Text = (decimal.Parse(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["TSLTon"].Value.ToString()) * tyle).ToString();
                    }
                    catch
                    {
                        txtTongSL.Text = "0";
                        txtDVC.Text = "";
                        txtSLTon.Text = "0";
                        txtSLCoTheXuat.Text = "0";
                        txtSLCoTheXuatTheoSP.Text = "0";
                        txtDVC.Text = cboDVT.Text;
                    }

                }
                else
                {
                    cboDVT.SelectedIndex = 0;
                    txtDVC.Text = "";
                    txtSLTon.Text = "0";
                    txtSLCoTheXuat.Text = "0";
                    txtTongSL.Text = "0";
                    //txtSLCoTheXuatTheoSP.Text = "0";
                    txtDVC.Text = cboDVT.Text;
                }
            }
            else
            {
                cboDVT.DataSource = null;
                txtDVC.Text = "";
                txtSLTon.Text = "0";
                txtSLCoTheXuat.Text = "0";
                txtTongSL.Text = "0";
                //txtSLCoTheXuatTheoSP.Text = "0";
                txtDVC.Text = cboDVT.Text;
            }
        }
        #endregion
        #region Lấy thông tin lên cbxLo
        private void LayThongTinLenCbxLo(string spid, string khoid, string nsxid)
        {
            if (spid == null || spid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn sản phẩm!";
                return;
            }
            else statusTB.Text = "";


            if (nsxid == null || nsxid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn nhà sản xuất!";
                return;
            }
            else statusTB.Text = "";
            if (khoid == null || khoid.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn kho!"; return;
            }
            else statusTB.Text = "";

            cbxSoLo.DisplayMember = "Lot";
            cbxSoLo.ValueMember = "Lot";
            CSQLDonHangXuatCT tkct = new CSQLDonHangXuatCT();
            DataTable dtb = tkct.LayLoTheoSPID_KhoID(spid, khoid, nsxid);
            if (dtb.Rows.Count > 0)
            {
                cbxSoLo.DataSource = dtb;
            }
            else
            {
                txtSLTon.Text = "0";
                txtSLCoTheXuat.Text = "0";
                txtTongSL.Text = "0";
                txtDVC.Text = cboDVT.Text;
            }
        }
        #endregion
        #region Lấy thông tin lên dtHanDung, slton, slcothexuat
        private void LayThongTinDate(string spid, string khoid, string lot, string nsxid)
        {
            CSQLHeSoQuyDoi hsqd_ = new CSQLHeSoQuyDoi();
            CSQLTonKhoCT aTonKhoCT = new CSQLTonKhoCT();
            decimal hsqd = (decimal)hsqd_.TinhTyLeHSQD(spid, cboDVT.SelectedValue.ToString());

            try
            {
                CSQLDonHangXuatCT tk = new CSQLDonHangXuatCT();

                string Lot = "";
                if (cbxSoLo.Text != string.Empty)
                {
                    Lot = cbxSoLo.SelectedValue.ToString();
                }

                DataTable dtb = tk.LayDate_SLTon_SLCoTheXuat_TheoLo(spid, khoid, Lot, nsxid);
                if (dtb != null && dtb.Rows.Count > 0)
                {

                    try
                    {
                        dtHanDung.Value = DateTime.Parse(dtb.Rows[0][0].ToString());
                    }
                    catch
                    {
                        dtHanDung.Value = DateTime.Now;
                    }
                    //txtSLTon.Text = String.Format("{0:0,0.00}", Math.Round(decimal.Parse(dtb.Rows[0][1].ToString()) * hsqd));
                    //txtSLCoTheXuat.Text = String.Format("{0:0,0.00}", Math.Round(decimal.Parse(dtb.Rows[0][2].ToString()) * hsqd));

                    txtSLTon.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(dtb.Rows[0][1].ToString()) * hsqd), 2));
                    txtSLCoTheXuat.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(dtb.Rows[0][2].ToString()) * hsqd), 2));

                    txtDVC.Text = cboDVT.Text;
                }
                else
                {
                    dtHanDung.Value = DateTime.Now;
                    txtSLTon.Text = "0.00";
                    txtSLCoTheXuat.Text = "0.00";
                    txtDVC.Text = cboDVT.Text;
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }

            txtTongSL.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SLTon"].Value.ToString()) * hsqd), 2));
            txtSLCoTheXuatTheoSP.Text = String.Format("{0:0,0.00}", Math.Round((aTonKhoCT.LayTongSLCoTheXuatTheoSPid(spid, khoid, nsxid)), 2));
            fmain.MaSP_DHXCanChon_ = spid;
        }
        #endregion

        private void cbxSoLo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSoLo.DataSource != null)
            {
                //LayThongTinDate(radMultiColumnComboBoxMaSP.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cbxSoLo.SelectedValue.ToString());
                LayThongTinDate(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString(), cbxSoLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());

                if (txtSLDapUng.Text != "" && decimal.Parse(txtSLDapUng.Text) > 0 && (decimal.Parse(txtSLDapUng.Text) > decimal.Parse(txtSLCoTheXuat.Text)))
                {
                    if (MessageBox.Show("Số lượng đáp ứng đã vượt quá số lượng xuất của Lô. \nVui lòng chọn số lượng thích hợp!!!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        txtSLDapUng.Text = "";
                        txtSLDapUng.Focus();
                    }
                }
                else { txtSLDapUng.Focus(); }
            }
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fDonHangXuat.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            if (!chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            try
            {
                if (cboNhaThuoc.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn nhà thuốc!";
                    cboNhaThuoc.Focus();
                    return;
                }
                else statusTB.Text = "";
                if (radMultiColumnComboBoxMaSP.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn sản phẩm!";
                    radMultiColumnComboBoxTenSP.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (cboNSX.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn nhà sản xuất!";
                    cboNSX.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (cboKho.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn kho!";
                    cboKho.Focus();
                    return;
                }
                else statusTB.Text = "";

                if (txtSLDapUng.Text.Length == 0)
                {
                    statusTB.Text = "Thông báo: Bạn chưa nhập Số lượng đáp ứng!";
                    txtSLDapUng.Focus();
                    txtSLDapUng.SelectAll();
                    return;
                }
                else statusTB.Text = "";

                //if (cbxSoLo.SelectedValue == null)
                //{
                //    statusTB.Text = "Thông báo: Bạn chưa chọn Lô cho sản phẩm!";
                //    cbxSoLo.Focus();
                //    return;
                //}
                //else statusTB.Text = "";

                //Thêm Master
                if (DHID != null && DHID.Length > 0 && DHID.CompareTo("00000000-0000-0000-0000-000000000000") == 0)
                {
                    #region Thêm đơn hàng xuất
                    CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                    dhx.SDHID = DHID;
                    dhx.SNoiDH = "";
                    dhx.SXuatChoNT = cboNhaThuoc.SelectedValue.ToString();
                    dhx.SNoiDH = "00000000-0000-0000-0000-000000000000";
                    dhx.DNgayDuyetDH = dtNgayDatHang.Value;
                    dhx.DNgayTao = DateTime.Now;
                    dhx.DLastUD = DateTime.Now;
                    if (ckDuyetDonHang.Checked == true)
                        dhx.BDuyetDH = true;
                    else
                        dhx.BDuyetDH = false;
                    if (ckDonHangKhan.Checked == true)
                        dhx.BDonKhan = true;
                    else
                        dhx.BDonKhan = false;

                    if (cbIsXuatThuCong.Checked == true)
                        dhx.SIsXuatThuCong = true;
                    else
                        dhx.SIsXuatThuCong = false;

                    dhx.BDaXacNhanDH = false;
                    dhx.BDaXuatDu = false;
                    dhx.BIsXoa = false;
                    dhx.SGhiChu = txtGhiChu.Text;
                    dhx.SUserNhap = CStaticBien.SmaTaiKhoan;
                    dhx.SUserDuyet = CStaticBien.SmaTaiKhoan;
                    dhx.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                    dhx.SUserXoa = "00000000-0000-0000-0000-000000000000";
                    dhx.DNgayXacNhan = DateTime.Parse("1/1/1774");

                    string[] kq = dhx.Them(dhx);
                    if (kq[0].Length > 0 && kq[1].Length > 0)
                    {
                        SODH = txtSoDonHang.Text = kq[0];
                        DHID = kq[1];
                        DHX_ = DHX_.LayThongTinLenDHXCTedit(DHID);
                        groupBox2.Enabled = true;
                        fmain.fDonHangXuat.rgvDonHangXuat_LayDLLenLuoi(dhx.LayDLLenLuoi(fmain.IsXemTatCa_));
                        if (fmain.DSDonHangXuatXacNhanIsOpen == true)
                        {
                            CSQLDonHangXuat dhxxn = new CSQLDonHangXuat();
                            fmain.fDonHangXuatXacNhan.rgvDSXacNhanDonHang_LayDuLieu(dhxxn.LayDLLenLuoiXacNhan());
                        }
                    }
                    else
                    {
                        statusTB.Text = "Thêm đơn hàng xuất thất bại!";
                    }
                    #endregion
                }
                else
                {
                    #region Sửa đơn hàng xuất
                    CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                    dhx.SDHID = DHID;
                    dhx.SSoDonHang = txtSoDonHang.Text;
                    dhx.SNoiDH = "00000000-0000-0000-0000-000000000000";
                    dhx.SXuatChoNT = cboNhaThuoc.SelectedValue.ToString();
                    dhx.SNoiDH = cboNhaThuoc.SelectedValue.ToString();
                    dhx.DNgayDuyetDH = dtNgayDatHang.Value;
                    dhx.DNgayTao = DateTime.Now;
                    dhx.DLastUD = DateTime.Now;
                    if (ckDuyetDonHang.Checked == true)
                        dhx.BDuyetDH = true;
                    else
                        dhx.BDuyetDH = false;
                    if (ckDonHangKhan.Checked == true)
                        dhx.BDonKhan = true;
                    else
                        dhx.BDonKhan = false;
                    if (cbIsXuatThuCong.Checked == true)
                        dhx.SIsXuatThuCong = true;
                    else
                        dhx.SIsXuatThuCong = false;

                    dhx.BDaXacNhanDH = false;
                    dhx.BDaXuatDu = false;
                    dhx.BIsXoa = false;
                    dhx.SGhiChu = txtGhiChu.Text;
                    dhx.SUserNhap = CStaticBien.SmaTaiKhoan;
                    dhx.SUserDuyet = CStaticBien.SmaTaiKhoan;
                    dhx.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                    dhx.SUserXoa = "00000000-0000-0000-0000-000000000000";
                    dhx.DNgayXacNhan = DateTime.Parse("1/1/1774");

                    int kq = dhx.Sua(dhx);
                    if (kq == 1)
                    {
                        statusTB.Text = "Sửa đơn hàng xuất thành công!";
                        fmain.fDonHangXuat.rgvDonHangXuat_LayDLLenLuoi(dhx.LayDLLenLuoi(fmain.IsXemTatCa_));
                        if (fmain.DSDonHangXuatXacNhanIsOpen == true)
                        {
                            CSQLDonHangXuat dhxxn = new CSQLDonHangXuat();
                            fmain.fDonHangXuatXacNhan.rgvDSXacNhanDonHang_LayDuLieu(dhxxn.LayDLLenLuoiXacNhan());
                        }
                    }
                    else
                    {
                        statusTB.Text = "Sửa đơn hàng xuất thất bại!";
                    }
                    #endregion
                }

                //Thêm CT

                CSQLDonHangXuatCT dhxct = new CSQLDonHangXuatCT();
                if (DHCTID == null || DHCTID == string.Empty)
                    dhxct.SDHCTid = "00000000-0000-0000-0000-000000000000";
                else
                    dhxct.SDHCTid = DHCTID;
                if (DHID != null && DHID.Length > 0)
                    dhxct.SDHid = DHID;
                dhxct.SSPid = radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString();
                dhxct.SKhoid = cboKho.SelectedValue.ToString();
                dhxct.FSLDat = decimal.Parse(txtSLDat.Text);
                dhxct.FSLDapUng = decimal.Parse(txtSLDapUng.Text);
                dhxct.SDVT = cboDVT.SelectedValue.ToString();
                if (cbxSoLo.SelectedValue != null)
                {
                    dhxct.SLot = cbxSoLo.SelectedValue.ToString();
                    dhxct.DDate = dtHanDung.Value;
                }
                else
                {
                    dhxct.SLot = "";
                    dhxct.DDate = DateTime.Now;
                }
                dhxct.SNSXID = cboNSX.SelectedValue.ToString();
                string kq1 = dhxct.Them(dhxct);
                if (kq1 != null && kq1.Length > 0)
                {
                    rgvDonHangChiTiet.DataSource = dhxct.LayTTDHXTheoDHXid(DHID);

                    DHCTID = "00000000-0000-0000-0000-000000000000";
                    radMultiColumnComboBoxMaSP.SelectedIndex = -1;
                    radMultiColumnComboBoxTenSP.SelectedIndex = -1;
                    cboKho.SelectedIndex = -1;
                    txtSLCoTheXuat.Text = "";
                    txtSLDapUng.Text = "";
                    txtSLDat.Text = "";
                    txtSLTon.Text = "";
                    txtTongSL.Text = "";
                    txtSLCoTheXuatTheoSP.Text = "";
                    cboNSX.SelectedIndex = -1;
                    cboDVT.SelectedIndex = -1;
                    cbxSoLo.SelectedValue = -1;
                    dtHanDung.Value = DateTime.Now;
                    btnImport.Enabled = false;
                    if (DHX_.SNoiDH.CompareTo(DHX_.SXuatChoNT) == 0)
                        rgvDonHangChiTiet.Focus();
                    else
                        radMultiColumnComboBoxMaSP.Focus();
                    if (rgvDonHangChiTiet.Rows.Count > 1)
                        rgvDonHangChiTiet.CurrentRow = rgvDonHangChiTiet.Rows[CURROW_Index + 1];
                    statusTB.Text = "Thêm thành công";
                }
                else
                {
                    statusTB.Text = "Thêm thất bại";
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }

            KiemTraDanhSachChiTietKho(DHID);
        }

        private void KiemTraDanhSachChiTietKho(string DHID)
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            if (!DHID.Equals("00000000-0000-0000-0000-000000000000"))
            {
                CSQLDonHangXuatCT dhxct = new CSQLDonHangXuatCT();

                if (dhxct.LayTTDHXTheoDHXid(DHID).Rows.Count > 0)
                {
                    Boolean IsHangDacBiet = dhxct.KiemTraCoHangDacBiet(DHID);

                    if (IsHangDacBiet)
                    {
                        cbkHangDacBiet.Checked = true;

                        if (cbkHangDacBiet.Checked && !chht.KiemTraTrangThaiXemKhoDacBiet())
                        {
                            MessageBox.Show("Vui lòng làm mới lại danh sách Đơn hàng");
                            fmain.frmDonHangXuatEditisOpen_ = false;
                            fmain.fDonHangXuat.LoadLenLuoi();
                            this.Close();
                        }
                    }

                    cbkHangDacBiet.Enabled = false;
                }
                else
                {
                    cbkHangDacBiet.Enabled = true;
                    CSQLDonHangXuat aDonHangXuat = new CSQLDonHangXuat();
                    cbkHangDacBiet.Checked = aDonHangXuat.IsKhoDacBiet(DHID);
                }
            }
            else
            {
                cbkHangDacBiet.Visible = chht.KiemTraTrangThaiXemKhoDacBiet();
            }

            cbkHangDacBiet.Visible = chht.KiemTraTrangThaiXemKhoDacBiet();
        }

        CSQLDonHangXuat DHX_ = new CSQLDonHangXuat();
        private void LayThongTinDonHangXuat(string dhid)
        {
            if (dhid != null && dhid.Length > 0 && dhid.CompareTo("00000000-0000-0000-0000-000000000000") != 0)
            {
                //Lấy thông tin đơn hàng xuất theo dhid                
                DHX_ = DHX_.LayThongTinLenDHXCTedit(dhid);
                txtSoDonHang.Text = DHX_.SSoDonHang;
                cboNhaThuoc.SelectedValue = DHX_.SXuatChoNT;
                dtNgayDatHang.Value = DHX_.DNgayTao;
                ckDuyetDonHang.Checked = DHX_.BDuyetDH;
                txtGhiChu.Text = DHX_.SGhiChu;
                ckDonHangKhan.Checked = DHX_.BDonKhan;
                // DungLV add Xuat Chi Dinh Don Hang Start
                cbIsXuatChiDinh.Checked = DHX_.SIsXuatCoChiDinh;
                cbIsXuatThuCong.Checked = DHX_.SIsXuatThuCong;
                // DungLV add Xuat Chi Dinh Don Hang End
                //Lấy thông tin đơn hàng xuất CT theo sodh
                if (DHX_.SDHID != null && DHX_.SDHID.Length > 0)
                {
                    CSQLDonHangXuatCT dhxct = new CSQLDonHangXuatCT();
                    DataTable dtbdhxct = dhxct.LayTTDHXTheoDHXid(DHID);
                    if (dtbdhxct != null && dtbdhxct.Rows.Count > 0)
                    {
                        rgvDonHangChiTiet.DataSource = dtbdhxct;
                    }
                }
            }
        }

        /// <summary>
        /// Nếu check vào dấu duyệt đơn hàng, tất cả cá control khác sẽ ẩn đi, không thể chỉnh sửa thông tin gì nữa.
        /// Ngược lại cho phép chỉnh sửa. Tuy nhiên khi đơn hàng đã xác nhận xong thì không thể điều chỉnh được nữa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckDuyetDonHang_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyetDonHang.Checked == true)
            {
                ThayDoiTrangThaiControls(false);
            }
            else
            {
                ThayDoiTrangThaiControls(true);
            }
        }

        private void ThayDoiTrangThaiControls(bool trangthai)
        {
            txtGhiChu.Enabled = trangthai;
            txtSLDapUng.Enabled = trangthai;
            txtSLDat.Enabled = trangthai;
            txtGhiChu.Enabled = trangthai;
            cboDVT.Enabled = trangthai;
            cboKho.Enabled = trangthai;
            cboNhaThuoc.Enabled = trangthai;
            cboNSX.Enabled = trangthai;
            cbxSoLo.Enabled = trangthai;
            dtHanDung.Enabled = trangthai;
            dtNgayDatHang.Enabled = trangthai;
            ckDonHangKhan.Enabled = trangthai;
            // DungLV add Xuat Chi Dinh Don Hang start
            cbIsXuatThuCong.Enabled = trangthai;
            if (!trangthai)
                cbIsXuatChiDinh.Enabled = trangthai;
            else
                if (ckDonHangKhan.Checked == true)
                    cbIsXuatChiDinh.Enabled = true;
                else
                {
                    cbIsXuatChiDinh.Checked = false;
                    cbIsXuatChiDinh.Enabled = false;
                }
            // DungLV add Xuat Chi Dinh Don Hang end
            radMultiColumnComboBoxMaSP.Enabled = trangthai;
            radMultiColumnComboBoxTenSP.Enabled = trangthai;
            //mccboMaSP.Enabled = trangthai;
            //mccbxTenSP.Enabled = trangthai;
            btnAdd.Enabled = trangthai;
            //btnLuu.Enabled = trangthai;

            IsNT();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            ckDuyetDonHang.Enabled = true;
            ThayDoiTrangThaiControls(true);
            txtSoDonHang.Text = "";
            txtSLCoTheXuat.Text = "";
            txtSLTon.Text = "";
            txtGhiChu.Text = "";
            txtSLDapUng.Text = "";
            txtSLDat.Text = "";
            txtGhiChu.Text = "";
            cboDVT.SelectedIndex = -1;
            cboKho.SelectedIndex = -1;
            cboNhaThuoc.SelectedIndex = -1;
            cboNSX.SelectedIndex = -1;
            cbxSoLo.SelectedIndex = -1;
            dtHanDung.Value = DateTime.Now;
            dtHanDung.Enabled = false;
            dtNgayDatHang.Value = DateTime.Now;
            ckDonHangKhan.Checked = false;
            radMultiColumnComboBoxMaSP.SelectedIndex = -1;
            radMultiColumnComboBoxTenSP.SelectedIndex = -1;
            rgvDonHangChiTiet.DataSource = null;
            ckDuyetDonHang.Checked = false;
            dtHanDung.Enabled = false;

            DHID = "00000000-0000-0000-0000-000000000000";
            SODH = "";
            DHCTID = null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fDonHangXuat.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            if (!chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            try
            {
                if (cboNhaThuoc.SelectedValue == null)
                {
                    statusTB.Text = "Thông báo: Bạn chưa chọn nhà thuốc!";
                    return;
                }
                else statusTB.Text = "";
                //Thêm Master
                if (DHID != null && DHID.Length > 0 && DHID.CompareTo("00000000-0000-0000-0000-000000000000") == 0)
                {
                    #region Thêm đơn hàng xuất
                    CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                    dhx.SDHID = DHID;
                    dhx.SNoiDH = "";
                    dhx.SXuatChoNT = cboNhaThuoc.SelectedValue.ToString();
                    dhx.SNoiDH = "00000000-0000-0000-0000-000000000000";
                    dhx.DNgayDuyetDH = dtNgayDatHang.Value;
                    dhx.DNgayTao = DateTime.Now;
                    dhx.DLastUD = DateTime.Now;
                    if (ckDuyetDonHang.Checked == true)
                        dhx.BDuyetDH = true;
                    else
                        dhx.BDuyetDH = false;
                    if (ckDonHangKhan.Checked == true)
                        dhx.BDonKhan = true;
                    else
                        dhx.BDonKhan = false;
                    dhx.BDaXacNhanDH = false;
                    dhx.BDaXuatDu = false;
                    dhx.BIsXoa = false;
                    dhx.SGhiChu = txtGhiChu.Text;
                    dhx.SUserNhap = CStaticBien.SmaTaiKhoan;
                    dhx.SUserDuyet = CStaticBien.SmaTaiKhoan;
                    dhx.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                    dhx.SUserXoa = "00000000-0000-0000-0000-000000000000";
                    dhx.DNgayXacNhan = DateTime.Parse("1/1/1774");
                    dhx.SIsKhoDacBiet = cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet();
                    // DungLV add Xuat Chi Dinh Don Hang Start
                    if (cbIsXuatChiDinh.Checked == true)
                        dhx.SIsXuatCoChiDinh = true;
                    else
                        dhx.SIsXuatCoChiDinh = false;

                    if (cbIsXuatThuCong.Checked == true)
                        dhx.SIsXuatThuCong = true;
                    else
                        dhx.SIsXuatThuCong = false;
                    // DungLV add Xuat Chi Dinh Don Hang End

                    string[] kq = dhx.Them(dhx);
                    if (kq[0].Length > 0 && kq[1].Length > 0)
                    {
                        SODH = txtSoDonHang.Text = kq[0];
                        //fmain.MaDonHangXuatCanSua_ = dhx.LayDHXIDTheoSoDH(kq);
                        DHID = kq[1];
                        groupBox2.Enabled = true;
                        btnImport.Enabled = false;
                        fmain.fDonHangXuat.rgvDonHangXuat_LayDLLenLuoi(dhx.LayDLLenLuoi(fmain.IsXemTatCa_));
                        if (fmain.DSDonHangXuatXacNhanIsOpen == true)
                        {
                            CSQLDonHangXuat dhxxn = new CSQLDonHangXuat();
                            fmain.fDonHangXuatXacNhan.rgvDSXacNhanDonHang_LayDuLieu(dhxxn.LayDLLenLuoiXacNhan());
                        }
                    }
                    else
                    {
                        statusTB.Text = "Thêm đơn hàng xuất thất bại!";
                    }
                    #endregion
                }
                else
                {
                    #region Sửa đơn hàng xuất
                    CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                    dhx.SDHID = DHID;
                    dhx.SSoDonHang = txtSoDonHang.Text;
                    dhx.SNoiDH = "";
                    dhx.SXuatChoNT = cboNhaThuoc.SelectedValue.ToString();
                    dhx.SNoiDH = "00000000-0000-0000-0000-000000000000";
                    dhx.DNgayDuyetDH = dtNgayDatHang.Value;
                    dhx.DNgayTao = DateTime.Now;
                    dhx.DLastUD = DateTime.Now;
                    if (ckDuyetDonHang.Checked == true)
                        dhx.BDuyetDH = true;
                    else
                        dhx.BDuyetDH = false;
                    if (ckDonHangKhan.Checked == true)
                        dhx.BDonKhan = true;
                    else
                        dhx.BDonKhan = false;
                    dhx.BDaXacNhanDH = false;
                    dhx.BDaXuatDu = false;
                    dhx.BIsXoa = false;
                    dhx.SGhiChu = txtGhiChu.Text;
                    dhx.SUserNhap = CStaticBien.SmaTaiKhoan;
                    dhx.SUserDuyet = CStaticBien.SmaTaiKhoan;
                    dhx.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                    dhx.SUserXoa = "00000000-0000-0000-0000-000000000000";
                    dhx.DNgayXacNhan = DateTime.Parse("1/1/1774");
                    dhx.SIsKhoDacBiet = cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet();
                    // DungLV add Xuat Chi Dinh Don Hang Start
                    if (cbIsXuatChiDinh.Checked == true)
                        dhx.SIsXuatCoChiDinh = true;
                    else
                        dhx.SIsXuatCoChiDinh = false;

                    if (cbIsXuatThuCong.Checked == true)
                        dhx.SIsXuatThuCong = true;
                    else
                        dhx.SIsXuatThuCong = false;
                    // DungLV add Xuat Chi Dinh Don Hang End

                    int kq = dhx.Sua(dhx);
                    if (kq == 1)
                    {
                        fmain.fDonHangXuat.rgvDonHangXuat_LayDLLenLuoi(dhx.LayDLLenLuoi(fmain.IsXemTatCa_));
                        statusTB.Text = "Sửa đơn hàng xuất thành công!";
                        if (fmain.DSDonHangXuatXacNhanIsOpen == true)
                        {
                            CSQLDonHangXuat dhxxn = new CSQLDonHangXuat();
                            fmain.fDonHangXuatXacNhan.rgvDSXacNhanDonHang_LayDuLieu(dhxxn.LayDLLenLuoiXacNhan());
                        }
                    }
                    else
                    {
                        statusTB.Text = "Sửa đơn hàng xuất thất bại!";
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        private void rgvDonHangChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                if (!chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                string DHXCTid = rgvDonHangChiTiet.CurrentRow.Cells["colDHCTid"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLDonHangXuatCT dhxct = new CSQLDonHangXuatCT();
                    int kq = dhxct.Xoa(DHXCTid);
                    if (kq > 0)
                    {
                        CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                        string dhxid = dhx.LayDHXIDTheoSoDH(txtSoDonHang.Text);
                        rgvDonHangChiTiet.DataSource = dhxct.LayTTDHXTheoDHXid(dhxid);
                    }
                    else
                        statusTB.Text = "Xóa thất bại";
                }

                KiemTraDanhSachChiTietKho(DHID);
            }
            if (e.KeyCode == Keys.Enter)
            {
                LayTTLenControl();
            }
        }

        private void cboDVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CSQLHeSoQuyDoi hsqd_ = new CSQLHeSoQuyDoi();
                CSQLTonKhoCT tk = new CSQLTonKhoCT();
                DataTable dtb = tk.LayDate_SLTon_SLCoTheXuat_TheoLo(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString(), cbxSoLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                decimal hsqd = hsqd_.TinhTyLeHSQD(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboDVT.SelectedValue.ToString());
                txtSLTon.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(dtb.Rows[0][1].ToString()) * hsqd), 2));
                txtSLCoTheXuat.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(dtb.Rows[0][2].ToString()) * hsqd), 2));
                txtTongSL.Text = String.Format("{0:0,0.00}", Math.Round((decimal.Parse(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SLTon"].Value.ToString()) * hsqd), 2));
                //txtSLCoTheXuatTheoSP.Text = String.Format("{0:0,0.00}", Math.Round((tk.LayTongSLCoTheXuatTheoSPid(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString(), cboNSX.SelectedValue.ToString()) * hsqd), 2));
                txtDVC.Text = cboDVT.Text;
            }
            catch { }
        }

        private void txtSLDat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '-')
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnAdd.Focus();
            }
        }

        private void cboKho_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboKho != null && cboKho.SelectedValue.ToString().Length > 0)
                {
                    LayThongTinDVTKhiKhoIDThayDoi(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString());
                    LayThongTinLenCbxLo(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboKho.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                }
                else
                {
                    //statusTB.Text = "Hàng chưa được nhập vào kho này";
                    cboDVT.DataSource = null;
                    cbxSoLo.DataSource = null;
                    cbxSoLo.Text = "";
                    dtHanDung.Value = DateTime.Now;
                    txtSLTon.Text = "";
                    txtSLCoTheXuat.Text = "";
                }
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        private void cboNSX_SelectedValueChanged(object sender, EventArgs e)
        {
            if (radMultiColumnComboBoxMaSP.SelectedValue != null && radMultiColumnComboBoxMaSP.SelectedValue.ToString().Length > 0 && cboNSX.SelectedValue != null && cboNSX.SelectedValue.ToString().Length > 0)
                LayKho(radMultiColumnComboBoxMaSP.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), cboNSX.SelectedValue.ToString());
        }

        private void txtSLDapUng_Leave(object sender, EventArgs e)
        {
            try
            {
                #region Mới
                if (decimal.Parse(txtSLDapUng.Text) > 0 && (decimal.Parse(txtSLDapUng.Text) <= decimal.Parse(txtSLCoTheXuat.Text)))
                {
                }
                else if (decimal.Parse(txtSLDapUng.Text) > 0 && (decimal.Parse(txtSLDapUng.Text) >= decimal.Parse(txtSLCoTheXuat.Text)) && (decimal.Parse(txtSLDapUng.Text) <= decimal.Parse(txtSLTon.Text)))
                {
                }
                //else if (decimal.Parse(txtSLDapUng.Text) > 0 && (decimal.Parse(txtSLDapUng.Text) > (decimal.Parse(txtSLTon.Text) - decimal.Parse(txtSLCoTheXuat.Text))))
                //{
                //    if (MessageBox.Show("Số lượng đáp ứng đã vượt quá số lượng xuất của Lô. \nVui lòng chọn số lượng - số lô thích hợp!!!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                //    {
                //        txtSLDapUng.Text = "";
                //        txtSLDapUng.Focus();
                //    }
                //}
                else
                {
                    if (cbxSoLo.SelectedValue != null)
                    {
                        if (MessageBox.Show("Số lượng đáp ứng đã vượt quá số lượng xuất của Lô. \nVui lòng chọn số lượng - số lô thích hợp. \nNếu muốn xuất theo 'Tổng SL có thể xuất/SP' thì Delete số lô.", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            txtSLDapUng.Text = "";
                            txtSLDapUng.Focus();
                        }
                    }
                    else
                    { statusTB.Text = "Thông báo: Số lượng đáp ứng đã vượt quá số lượng tồn hoặc bé hơn 0, bạn vẫn muốn xuất hàng!"; }
                }

                if ((DHX_.SNoiDH != null && DHX_.SXuatChoNT != null && DHX_.SNoiDH.CompareTo(DHX_.SXuatChoNT) != 0) || (DHX_.SNoiDH == null && DHX_.SXuatChoNT == null))
                {
                    txtSLDat.Text = txtSLDapUng.Text;
                }
                #endregion


                #region Cũ
                //if (decimal.Parse(txtSLDapUng.Text) > 0 && (decimal.Parse(txtSLDapUng.Text) <= decimal.Parse(txtTongSL.Text)))
                //{

                //}
                //else
                //{
                //    statusTB.Text = "Thông báo: Số lượng đáp ứng đã vượt quá số lượng tồn hoặc bé hơn 0, bạn vẫn muốn xuất hàng!";
                  
                //}

                //if ((DHX_.SNoiDH != null && DHX_.SXuatChoNT != null && DHX_.SNoiDH.CompareTo(DHX_.SXuatChoNT) != 0) || (DHX_.SNoiDH == null && DHX_.SXuatChoNT == null))
                //{
                //    txtSLDat.Text = txtSLDapUng.Text;
                //}
                #endregion
            }
            catch
            {
            }
        }

        private void cboNhaThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dtNgayDatHang.Focus();
            }
        }

        private void dtNgayDatHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtGhiChu.Focus();
            }
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ckDonHangKhan.Focus();
            }
        }

        private void ckDonHangKhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                radMultiColumnComboBoxMaSP.Focus();
            }
        }

        private void radMultiColumnComboBoxMaSP_Enter(object sender, EventArgs e)
        {
            radMultiColumnComboBoxTenSP.Focus();
        }


        private void radMultiColumnComboBoxMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                radMultiColumnComboBoxTenSP.Focus();
            }
        }

        private void radMultiColumnComboBoxTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboNSX.Focus();
            }
        }

        private void cboNSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboKho.Focus();
            }
        }

        private void cboKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbxSoLo.Focus();
            }
        }

        private void cbxSoLo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboDVT.Focus();
            }
        }

        private void cboDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSLDapUng.Focus();

            }
        }


        private void rbtnIn_Click(object sender, EventArgs e)
        {
            InDonHangXuat(DHID);
        }

        public void InDonHangXuat(string dhxid)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(fmain.fDonHangXuat.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLDonHangXuatCT dhxct_ = new CSQLDonHangXuatCT();
            if (dhxid != null && dhxid.Length > 0)
            {
                DataTable DonHangXuatCT_ = dhxct_.IN_DHX_DHXCT(dhxid);
                bool donkhan = bool.Parse(DonHangXuatCT_.Rows[0]["DonKhan"].ToString());
                bool daxuatdu = bool.Parse(DonHangXuatCT_.Rows[0]["DaXuatDu"].ToString());
                Fr_DonHangXuat check = new Fr_DonHangXuat(DonHangXuatCT_, donkhan, daxuatdu);
                check.Show();
            }
        }

        private void rgvDonHangChiTiet_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            LayTTLenControl();

            try
            {
                LayThongTinDate(rgvDonHangChiTiet.CurrentRow.Cells["colSPID"].Value.ToString(), cboKho.SelectedValue.ToString(), cbxSoLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
            }
            catch
            {
                LayThongTinDate(rgvDonHangChiTiet.CurrentRow.Cells["colSPID"].Value.ToString(), cboKho.SelectedValue.ToString(), "", cboNSX.SelectedValue.ToString());
            }
        }

        private void LayTTLenControl()
        {
            try
            {
                txtSLDapUng.Text = "0";
                CURROW_Index = rgvDonHangChiTiet.CurrentRow.Index;
                DHCTID = rgvDonHangChiTiet.CurrentRow.Cells["colDHCTID"].Value.ToString();
                fmain.MaSP_DHXCanChon_ = rgvDonHangChiTiet.CurrentRow.Cells["colSPID"].Value.ToString();
                CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                string spid = spnsx.SanPham_NSX_LaySPNSXIDTheoSPID_NSXID(rgvDonHangChiTiet.CurrentRow.Cells["colSPID"].Value.ToString(), rgvDonHangChiTiet.CurrentRow.Cells["colNSXID"].Value.ToString());
                radMultiColumnComboBoxMaSP.SelectedValue = new Guid(spid);
                radMultiColumnComboBoxTenSP.SelectedValue = new Guid(spid);
                cboKho.SelectedValue = new Guid(rgvDonHangChiTiet.CurrentRow.Cells["colMaKho"].Value.ToString());
                try
                {
                    cbxSoLo.SelectedValue = rgvDonHangChiTiet.CurrentRow.Cells["colLot"].Value.ToString();
                }
                catch
                {
                    cbxSoLo.SelectedValue = "00000000-0000-0000-0000-000000000000";
                }
              
                if (rgvDonHangChiTiet.CurrentRow.Cells["colSLDapUng"].Value.ToString().CompareTo("") != 0)
                    txtSLDapUng.Text = String.Format("{0:N2}", decimal.Parse(rgvDonHangChiTiet.CurrentRow.Cells["colSLDapUng"].Value.ToString()));
                else
                    txtSLDapUng.Text = "0";
                txtSLDat.Text = String.Format("{0:N2}", decimal.Parse(rgvDonHangChiTiet.CurrentRow.Cells["colSLDat"].Value.ToString()));
                cboDVT.SelectedValue = rgvDonHangChiTiet.CurrentRow.Cells["colDVT"].Value.ToString();
                
                try
                {
                    dtHanDung.Value = DateTime.Parse(rgvDonHangChiTiet.CurrentRow.Cells["colDate"].Value.ToString());
                }
                catch
                {
                    dtHanDung.Value = DateTime.Now;
                }

                try
                {
                    LayThongTinDate(rgvDonHangChiTiet.CurrentRow.Cells["colSPID"].Value.ToString(), cboKho.SelectedValue.ToString(), cbxSoLo.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                }
                catch
                {
                    LayThongTinDate(rgvDonHangChiTiet.CurrentRow.Cells["colSPID"].Value.ToString(), cboKho.SelectedValue.ToString(), "", cboNSX.SelectedValue.ToString());
                }
                txtSLDapUng.Focus();
                txtSLDapUng.SelectAll();
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        private void rgvDonHangChiTiet_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            //if (rgvDonHangChiTiet.CurrentCell.ColumnInfo.Name.CompareTo("colSLDapUng") == 0)
            //{
            //    rgvDonHangChiTiet.CurrentRow.Cells["colSLDapUng"].EndEdit();
            //    if (rgvDonHangChiTiet.CurrentRow.Cells["colSLDapUng"].Value != null && rgvDonHangChiTiet.CurrentRow.Cells["colSLDapUng"].Value.ToString().CompareTo("") > 0)
            //    {
            //        CSQLDonHangXuatCT dhxct = new CSQLDonHangXuatCT();
            //        if (DHCTID == null || DHCTID == string.Empty)
            //            dhxct.SDHCTid = "00000000-0000-0000-0000-000000000000";
            //        else
            //            dhxct.SDHCTid = DHCTID;
            //        if (DHID != null && DHID.Length > 0)
            //            dhxct.SDHid = DHID;
            //        dhxct.SSPid = rgvDonHangChiTiet.CurrentRow.Cells["colSPID"].Value.ToString();
            //        dhxct.SKhoid = rgvDonHangChiTiet.CurrentRow.Cells["colMaKho"].Value.ToString();
            //        dhxct.FSLDat = decimal.Parse(rgvDonHangChiTiet.CurrentRow.Cells["colSlDat"].Value.ToString());
            //        dhxct.FSLDapUng = decimal.Parse(rgvDonHangChiTiet.CurrentRow.Cells["colSlDapUng"].Value.ToString());
            //        dhxct.SDVT = rgvDonHangChiTiet.CurrentRow.Cells["colDVT"].Value.ToString();
            //        if (rgvDonHangChiTiet.CurrentRow.Cells["colLot"].Value != null)
            //        {
            //        dhxct.SLot = rgvDonHangChiTiet.CurrentRow.Cells["colLot"].Value.ToString();
            //        dhxct.DDate = DateTime.Parse(rgvDonHangChiTiet.CurrentRow.Cells["colDate"].Value.ToString());
            //        }
            //        else
            //        {
            //            dhxct.SLot = "";
            //            dhxct.DDate = DateTime.Now;
            //        }
            //        dhxct.SNSXID = rgvDonHangChiTiet.CurrentRow.Cells["colNSXID"].Value.ToString();
            //        try
            //        {
            //            string kq1 = dhxct.Them(dhxct);
            //            if (kq1 != null && kq1.Length > 0)
            //            {
            //                DHCTID = null;
            //                //rgvDonHangChiTiet.DataSource = dhxct.LayTTDHXTheoDHXid(DHID);
            //                statusTB.Text = "Thêm thành công";
            //                radMultiColumnComboBoxMaSP.SelectedIndex = -1;
            //                radMultiColumnComboBoxTenSP.SelectedIndex = -1;
            //                cboKho.SelectedIndex = -1;
            //                txtSLCoTheXuat.Text = "";
            //                txtSLDapUng.Text = "";
            //                txtSLDat.Text = "";
            //                txtSLTon.Text = "";
            //                txtTongSL.Text = "";
            //                cboNSX.SelectedIndex = -1;
            //                cboDVT.SelectedIndex = -1;
            //                cbxSoLo.SelectedValue = -1;
            //                dtHanDung.Value = DateTime.Now;
            //                rgvDonHangChiTiet.Focus();
            //            }
            //            else
            //            {
            //                statusTB.Text = "Thêm thất bại";
            //            }
            //        }
            //        catch (ApplicationException ex)
            //        {
            //            throw ex;
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
            //    }
            //}
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (rgvDonHangChiTiet.Rows.Count > 0)
            {
                ExportToExcelML exporter = new ExportToExcelML(this.rgvDonHangChiTiet);
                exporter.ExportVisualSettings = true;

                string tempPath = Path.GetTempPath();
                tempPath += @"\tempDonHangXuat" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
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
                desktopPath += @"\DonHangMuaXuat" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";

                wb.SaveAs(desktopPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
                wb.Close();
                app.Quit();

                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(app);

                File.Delete(tempPath);
                MessageBox.Show("File đã xuất thành công, kiểm tra lại file trên desktop!");
            }
        }

        private void cbkHangDacBiet_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void IsNT()
        {
            if (DHID != null && DHID.Length > 0 && DHID.CompareTo("00000000-0000-0000-0000-000000000000") != 0)
            {
                CSQLDonHangXuat dhx = new CSQLDonHangXuat();

                if (dhx.IsNT(DHID))
                {
                    radMultiColumnComboBoxMaSP.Enabled = radMultiColumnComboBoxTenSP.Enabled = false;
                }
            }
        }

        private void txtSLCoTheXuatTheoSP_Click(object sender, EventArgs e)
        {
            if (fmain.frmDonHangXuatRePortIsOpen == true)
            {
                fmain.fDonHangXuatReport.Select();
                return;
            }
            fmain.fDonHangXuatReport = new frmDonHangXuatReport(fmain);
            fmain.fDonHangXuatReport.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            CSQLNhanTraHang nth_ = new CSQLNhanTraHang();
            if (txtSPTra.Text == "")
            {
                MessageBox.Show("Số phiếu trả hàng chưa có. Xin vui lòng kiểm tra lại .", "Xác nhận");
                return;
            }

            string[] kqnth = nth_.KiemTraTonTaiSoPTH(txtSPTra.Text);
            if (Convert.ToBoolean(kqnth[0]) == true)
            {
                Fr_DangXuLy.ShowFormCho();
                cboNhaThuoc.SelectedValue = kqnth[1];
                cboNhaThuoc.Enabled = false;
                cbkHangDacBiet.Enabled = false;
                btnAdd.Enabled = false;
                btnImport.Enabled = false;

                CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                if (DHID == null || DHID.Equals("00000000-0000-0000-0000-000000000000"))
                {
                    string[] kq = dhx.DonHangXuat_ThemImport(cboNhaThuoc.SelectedValue.ToString(), txtGhiChu.Text, CStaticBien.SmaTaiKhoan, ckDonHangKhan.Checked, dtNgayDatHang.Value);
                    DHID = kq[0];
                    txtSoDonHang.Text = kq[1];
                }
                if (DHID != null && DHID.Length > 0 && rgvDonHangChiTiet.Rows.Count == 0)
                {
                    CSQLDonHangXuatCT dhxct = new CSQLDonHangXuatCT();
                    string ketqua = dhxct.ImportMulti(DHID, txtSPTra.Text);
                    if (!ketqua.Equals("OK"))
                    {
                        string Title = "Lỗi";
                        string Message = "Dữ liệu chưa được import";
                        Fr_DangXuLy.DongFormCho();
                        MessageBox.Show(Message, Title);
                    }
                    else
                    {
                        Fr_DangXuLy.DongFormCho();
                    }
                    rgvDonHangChiTiet.DataSource = dhxct.LayTTDHXTheoDHXid(DHID);
                }
            }
            else
            {
                MessageBox.Show("Số phiếu trả hàng này không có dữ liệu. Xin vui lòng kiểm tra lại .", "Xác nhận");
                return;
            }
        }

    }
}

