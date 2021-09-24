using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using ECOPharma2013.DuLieu;
using ECOPharma2013.From_Report;
using System.IO;
using System.Runtime.InteropServices;
using Telerik.WinControls.UI.Export;

namespace ECOPharma2013
{
    public partial class frmNT_DatHangEditAccess : Form
    {
        public frmNT_DatHangEditAccess()
        {
            InitializeComponent();
        }
        frmMain fmain;

        public frmNT_DatHangEditAccess(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }

        string DHID, SODH, sodhctid;
        bool matien;
        public void NhanThongTinDatHang(string dhid, string sodh)
        {
            DHID = dhid;
            SODH = sodh;
        }


        private void rbtnDong_Click(object sender, EventArgs e)
        {
            if (fmain.DSNT_DatHangXacNhanIsOpen == true)
            {
                fmain.fNT_DatHangXacNhan.LoadLenLuoi();
            }
            fmain.fNT_DatHang.LoadLenLuoi();
            fmain.frmNT_DatHangEditAccessisOpen_ = false;
            this.Close();
        }


        private void frmNT_DatHangEdit_Load(object sender, EventArgs e)
        {
            matien = true;
            btnTienTien.Enabled = false;
            CSQLCauHinhHeThong chht_ = new CSQLCauHinhHeThong();
            string ttcn_ = chht_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
            CSQLNhaThuoc nt_ = new CSQLNhaThuoc();
            string dinhmuctonNT = nt_.LayDinhMucTonNhaThuocTheoMa(ttcn_);
            txtDinhMucCuaHang.Text = Convert.ToDecimal(dinhmuctonNT).ToString("#,###");
            LayDSNhomSPLenCBO();
            LayDSSanPhamLenMCBO();

            KiemTraDanhSachChiTietKho(DHID);

            if (DHID!=null && DHID != string.Empty)
            {
                matien = false;
                //1. Lấy thông tin chuyển hàng (master)
                CSQLNT_DatHang ch = new CSQLNT_DatHang();
                try
                {
                    DataTable dtb1dh = ch.LayDatHang(DHID);
                    if (dtb1dh != null && dtb1dh.Rows.Count > 0)
                    {
                        txtSoDH.Text = dtb1dh.Rows[0]["SoDH"].ToString();                        
                        dtNgayDH.Value = DateTime.Parse(dtb1dh.Rows[0]["NgayTao"].ToString());
                        txtGhiChu.Text = dtb1dh.Rows[0]["GhiChu"].ToString();

                        DataTable dtbDatHangDM = ch.LayDatHang_DinhMuc(txtSoDH.Text);
                        if (dtbDatHangDM != null && dtbDatHangDM.Rows.Count > 0)
                        {
                            txtDinhMucCuaHang.Text = Convert.ToDecimal(dtbDatHangDM.Rows[0]["DinhMucTonCuaHang"].ToString()).ToString("#,###");
                            txtTonChuaDat.Text = Convert.ToDecimal(dtbDatHangDM.Rows[0]["TongTienTonCuaHang"].ToString()).ToString("#,###");
                            txtTienDatHang.Text = Convert.ToDecimal(dtbDatHangDM.Rows[0]["TongTienDatHang"].ToString()).ToString("#,###");
                            txtTongTienDat.Text = Convert.ToDecimal(dtbDatHangDM.Rows[0]["TongTienSauKhiDatHang"].ToString()).ToString("#,###");
                            txtDuoi_QuaDM.Text = Convert.ToDecimal(dtbDatHangDM.Rows[0]["DuoiOrQuaDM"].ToString()).ToString("#,###"); 
                        }
                        if (bool.Parse(dtb1dh.Rows[0]["DonKhan"].ToString()) == false)
                        {
                            rdbtnChuKy.Checked = true;
                            rdbtnChuKy.Enabled = true;
                            rdbtnKhan.Enabled = false;
                            mcboMaSP.Enabled = false;
                            mcboTenSP.Enabled = false;
                            txtSLDat.Enabled = false;
                        }
                        else
                        {
                            rdbtnKhan.Checked = true;
                            rdbtnChuKy.Enabled = false;
                            rdbtnKhan.Enabled = true;
                            mcboMaSP.Enabled = true;
                            mcboTenSP.Enabled = true;
                            txtSLDat.Enabled = true;
                        }
                        ckDuyet.Checked = bool.Parse(dtb1dh.Rows[0]["DuyetDH"].ToString());

                        if (bool.Parse(dtb1dh.Rows[0]["DaXacNhanDH"].ToString()) == false)
                        {
                            ckDuyet.Enabled = true;
                            btnTienTien.Enabled = true;
                        }
                        else
                        {
                            ckDuyet.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi khi lấy thông tin chuyển hàng (master)", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
                
                //2. Lấy thông tin chuyển hàng chi tiết (detail)
                if (DHID != string.Empty)
                {
                    CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                    MasterTemplate.DataSource = dhct.LoadLenLuoi(DHID);
                }

                //3. Enable các control chức năng               
                cboDVXuat.Enabled = false;
                cboNSX.Enabled = false;                
                btnOk.Enabled = false;
                cboNhom.Enabled = false;
                rdbtnChuKy.Enabled = false;
                rdbtnKhan.Enabled = false;
                if (ckDuyet.Checked == true)
                {
                    txtGhiChu.Enabled = false;
                    btnAdd.Enabled = false;
                }
                else
                {
                    txtGhiChu.Enabled = true;
                    btnAdd.Enabled = true;
                }
            }

            HienThiCanhBaoSanPhamCanDate();
        }

        private void KiemTraDanhSachChiTietKho(string DHID)
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            CSQLNT_DatHang ch = new CSQLNT_DatHang();

            if (DHID != null && DHID != string.Empty)
            {
                cbkHangDacBiet.Checked = ch.IsKhoDacBiet(DHID);

                if (cbkHangDacBiet.Checked && !chht.KiemTraTrangThaiXemKhoDacBiet())
                {
                    MessageBox.Show("Vui lòng làm mới lại danh sách Đặt hàng");

                    fmain.fNT_DatHang.LoadLenLuoi();
                    fmain.frmNT_DatHangEditAccessisOpen_ = false;
                    this.Close();
                }

                CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                if (dhct.LoadLenLuoi(DHID).Rows.Count > 0) {
                    cbkHangDacBiet.Enabled = false;
                }
                else
                {
                    cbkHangDacBiet.Enabled = true;
                }
            }
            else
            {
                cbkHangDacBiet.Visible = chht.KiemTraTrangThaiXemKhoDacBiet();
            }
        }

        private void HienThiCanhBaoSanPhamCanDate()
        {
            foreach (GridViewRowInfo row in MasterTemplate.Rows)
            {
                string svalue = row.Cells["colDate"].Value.ToString();
                if (!string.IsNullOrEmpty(svalue))
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        GridViewCellInfo cell = row.Cells[i];

                        cell.Style.CustomizeFill = true;
                        cell.Style.DrawFill = true;
                        cell.Style.ForeColor = Color.White;
                        cell.Style.GradientStyle = GradientStyles.Solid;
                        cell.Style.BackColor = Color.DeepSkyBlue;
                    }
                }
            }
        }

        #region Hàm hỗ trợ
        public void LayDSNhomSPLenCBO()
        {
            CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
            cboNhom.DisplayMember = "TENNSP";
            cboNhom.ValueMember = "NSPID";
            try
            {
                cboNhom.DataSource = dhct.LoadDSNhomSPLenCBO();
                cboNhom.SelectedIndex = -1;
            }
            catch (Exception Exception) 
            { 
                MessageBox.Show(Exception.Message); 
            }
        }

        public void LayDSSanPhamLenMCBO()
        {
            try
            {
                CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();

                mcboMaSP.ValueMember = "SPID";
                mcboMaSP.DisplayMember = "MaSP";

                mcboTenSP.ValueMember = "SPID";
                mcboTenSP.DisplayMember = "TenSP";

                mcboMaSP.DataSource = dhct.LoadDSSanPhamLenCBO();
                mcboTenSP.DataSource = dhct.LoadDSSanPhamLenCBO();

                mcboMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                mcboMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
                mcboMaSP.EditorControl.Columns["SPID"].IsVisible = false;
                mcboMaSP.EditorControl.Columns["DVXuatID"].IsVisible = false;
                mcboMaSP.EditorControl.Columns["NhomID"].IsVisible = false;
                mcboMaSP.EditorControl.Columns["MaSP"].Width = 40;
                mcboMaSP.EditorControl.Columns["TenSP"].Width = 265;
                mcboMaSP.EditorControl.Columns["TenNSX"].Width = 150;
                mcboMaSP.EditorControl.Columns["DVXuat"].Width = 55;
                mcboMaSP.EditorControl.Columns["TenNSP"].Width = 80;
                mcboMaSP.AutoFilter = true;
                FilterDescriptor descriptor = new FilterDescriptor(this.mcboMaSP.DisplayMember, FilterOperator.IsEqualTo, string.Empty);
                this.mcboMaSP.EditorControl.FilterDescriptors.Add(descriptor);
                this.mcboMaSP.DropDownStyle = RadDropDownStyle.DropDown;
                mcboMaSP.MultiColumnComboBoxElement.DropDownWidth = 680;
                mcboMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;

                mcboTenSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
                mcboTenSP.EditorControl.Columns["NSXID"].IsVisible = false;
                mcboTenSP.EditorControl.Columns["SPID"].IsVisible = false;
                mcboTenSP.EditorControl.Columns["DVXuatID"].IsVisible = false;
                mcboTenSP.EditorControl.Columns["NhomID"].IsVisible = false;
                mcboTenSP.EditorControl.Columns["MaSP"].Width = 40;
                mcboTenSP.EditorControl.Columns["TenSP"].Width = 265;
                mcboTenSP.EditorControl.Columns["TenNSX"].Width = 150;
                mcboTenSP.EditorControl.Columns["DVXuat"].Width = 55;
                mcboTenSP.EditorControl.Columns["TenNSP"].Width = 80;
                mcboTenSP.AutoFilter = true;
                FilterDescriptor descriptor1 = new FilterDescriptor(this.mcboTenSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
                this.mcboTenSP.EditorControl.FilterDescriptors.Add(descriptor1);
                this.mcboTenSP.DropDownStyle = RadDropDownStyle.DropDown;
                mcboTenSP.MultiColumnComboBoxElement.DropDownWidth = 680;
                mcboTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;

                mcboMaSP.SelectedIndex = -1;
                mcboTenSP.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        public void LayDSDVTLenMCBO()
        {
            if (mcboMaSP.SelectedValue != null && mcboMaSP.SelectedValue.ToString().Length > 0)
            {
                try
                {
                    CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                    cboDVXuat.DisplayMember = "TENDVT";
                    cboDVXuat.ValueMember = "DVTID";
                    cboDVXuat.DataSource = dhct.LoadDSDVTLenCBO(mcboMaSP.SelectedValue.ToString());
                    if (cboDVXuat.Items.Count > 0)
                    {
                        cboDVXuat.SelectedValue = new Guid(mcboMaSP.EditorControl.CurrentRow.Cells["DVXuatID"].Value.ToString());
                    }

                    cboNhomSP.DisplayMember = "TENNSP";
                    cboNhomSP.ValueMember = "NhomID";
                    cboNhomSP.DataSource = dhct.LoadDSNhomSanPhamLenCBO(mcboMaSP.SelectedValue.ToString());
                    if (cboNhomSP.Items.Count > 0)
                    {
                        cboNhomSP.SelectedValue = new Guid(mcboMaSP.EditorControl.CurrentRow.Cells["NhomID"].Value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Lấy nhà sản xuất
        void LayDanhSachNSXLenCombobox(string spid)
        {
            if (spid.Length > 0)
            {
                CSQLNT_TraHangVeCtyCT chct = new CSQLNT_TraHangVeCtyCT();
                cboNSX.DisplayMember = "TenNSX";
                cboNSX.ValueMember = "NSXID";
                try
                {
                    cboNSX.DataSource = chct.LayDSNhaSanXuat(spid);
                    statusTB.Text = "";
                }
                catch
                {
                    cboNSX.DataSource = null;
                    statusTB.Text = "Không lấy được nhà sản xuất của sản phẩm!";
                    return;
                }
            }
        }

        #endregion Hàm hỗ trợ

        private void mcboMaSP_SelectedValueChanged(object sender, EventArgs e)
        {
            if (mcboMaSP.SelectedValue != null && mcboMaSP.SelectedIndex != -1)
            {
                //2.1 Lấy tên sản phẩm vào multi-column-combobox
                if (mcboTenSP.SelectedValue == null || (mcboTenSP.SelectedValue != null && mcboMaSP.SelectedValue.ToString().CompareTo(mcboTenSP.SelectedValue.ToString()) != 0))
                {
                    mcboTenSP.SelectedValue = mcboMaSP.SelectedValue;
                }

                //2.2 Lấy nhà sản xuất vào combobox
                LayDanhSachNSXLenCombobox(mcboMaSP.SelectedValue.ToString());
                cboNSX.SelectedValue = new Guid(mcboMaSP.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
                cboNSX.SelectionLength = 0;

                //2.3 Lấy danh sách DVT vào combobox
                LayDSDVTLenMCBO();

                //2.4 Chuyển con trỏ chuột ra đầu dòng mcboTenSP
                RadTextBoxItem rtbi = mcboTenSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                rtbi.SelectionLength = 0;

                //2.5 Lấy thông tin lịch sử
                CSQLNT_DatHangCT dhct_ = new CSQLNT_DatHangCT();
                rgvLichSu.DataSource = dhct_.XemThongTinCacChuKyTruoc(mcboMaSP.SelectedValue.ToString());
            }
            else
            {
                cboNSX.SelectedIndex = -1;
                cboDVXuat.SelectedIndex = -1;
                txtSLDat.Text = "";
            }
        }

        private void mcboTenSP_SelectedValueChanged(object sender, EventArgs e)
        {
            if (mcboTenSP.SelectedValue != null && mcboTenSP.SelectedIndex != -1)
            {
                //3.1 Lấy tên sp
                if (mcboMaSP.SelectedValue == null || (mcboMaSP.SelectedValue != null && mcboTenSP.SelectedValue.ToString().CompareTo(mcboMaSP.SelectedValue.ToString()) != 0))
                {
                    mcboMaSP.SelectedValue = mcboTenSP.SelectedValue;
                }
            }
        }

        private void cboDVXuat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboDVXuat.SelectedValue != null && cboDVXuat.SelectedIndex != -1)
            {
                CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                try
                {
                    txtSLTon.Text = dhct.LaySLDeNghi(mcboMaSP.SelectedValue.ToString(), cboDVXuat.SelectedValue.ToString(), cboNSX.SelectedValue.ToString()).ToString("N2");
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

        private void rdbtnChuKy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnChuKy.Checked == true)
            {
                rdbtnKhan.Checked = false;
                cboNhom.Enabled = true;
                btnOk.Enabled = true;
                btnAdd.Enabled = false;
                mcboMaSP.Enabled = false;
                mcboTenSP.Enabled = false;
                txtSLDat.Enabled = false;
            }
        }

        private void rdbtnKhan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnKhan.Checked == true)
            {
                rdbtnChuKy.Checked = false;
                cboNhom.Enabled = false;
                btnOk.Enabled = false;
                btnAdd.Enabled = true;
                mcboMaSP.Enabled = true;
                mcboTenSP.Enabled = true;
                txtSLDat.Enabled = true;

                try
                {
                    CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                    if (DHID != null && DHID != string.Empty)
                    {
                        if (dhct.LoadLenLuoi(DHID).Rows.Count > 0)
                        {
                            cbkHangDacBiet.Enabled = false;
                        }
                        else
                        {
                            cbkHangDacBiet.Enabled = true;
                        }
                    }
                    else
                        cbkHangDacBiet.Enabled = true;
                }catch{
                    cbkHangDacBiet.Enabled = true;
                }
            }
            else
            {
                cbkHangDacBiet.Checked = cbkHangDacBiet.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_DatHang.Name) == false)
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

            #region kiểm tra điều kiện nhập
            if (rdbtnKhan.Checked != true && rdbtnChuKy.Checked != true)
            {
                err.SetError(rdbtnChuKy, "Bạn chưa chọn kiểu đặt hàng!");
                err.SetError(rdbtnKhan, "Bạn chưa chọn kiểu đặt hàng!");
                rdbtnKhan.Focus();
                return;
            }
            else
            {
                err.SetError(rdbtnChuKy, "");
                err.SetError(rdbtnKhan, "");
            }
            if (mcboMaSP.SelectedValue == null || mcboMaSP.SelectedIndex == -1)
            {
                err.SetError(mcboMaSP, "Bạn chưa chọn sản phẩm!");
                mcboMaSP.Focus();
                return;
            }
            else
            {
                err.SetError(mcboMaSP, "");
            }
            if (txtSLDat.Text == string.Empty)
            {
                err.SetError(mcboMaSP, "Bạn chưa nhập số lượng đặt!");
                txtSLDat.Focus();
                return;
            }
            else
            {
                err.SetError(txtSLDat, "");
            }
            #endregion
            //Thêm master
            #region master
            if (DHID != null && DHID.Length > 0)
            {
                //Sửa đơn hàng master
                CSQLNT_DatHang dh = new CSQLNT_DatHang();
                if (dh.Sua(DHID, txtGhiChu.Text, ckDuyet.Checked, CStaticBien.SmaTaiKhoan, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet()) > 0)
                {
                    statusTB.Text = "Sửa đơn hàng thành công!";
                }
                else
                {
                    statusTB.Text = "Sửa đơn hàng thất bại";
                }
            }
            else
            {
                //Thêm đơn hàng master
                CSQLNT_DatHang dh = new CSQLNT_DatHang();
                string[] dhid_sodh = dh.Them(rdbtnKhan.Checked, txtGhiChu.Text, DateTime.Now, CStaticBien.SmaTaiKhoan, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet());
                 if (dhid_sodh != null)
                    {
                        DHID = dhid_sodh[0];
                        SODH = dhid_sodh[1];
                        DataTable dtb1dh = dh.LayDatHang(DHID);
                        if (dtb1dh != null && dtb1dh.Rows.Count > 0)
                        {
                            txtSoDH.Text = dtb1dh.Rows[0]["SoDH"].ToString();
                            dtNgayDH.Value = DateTime.Parse(dtb1dh.Rows[0]["NgayTao"].ToString());
                            txtGhiChu.Text = dtb1dh.Rows[0]["GhiChu"].ToString();
                            ckDuyet.Checked = bool.Parse(dtb1dh.Rows[0]["DuyetDH"].ToString());

                            if (bool.Parse(dtb1dh.Rows[0]["DaXacNhanDH"].ToString()) == false)
                            {
                                ckDuyet.Enabled = true;
                            }
                            else
                            {
                                ckDuyet.Enabled = false;
                            }
                            if (bool.Parse(dtb1dh.Rows[0]["DonKhan"].ToString()) == false)
                            {
                                rdbtnChuKy.Checked = true;
                            }
                            else
                            {
                                rdbtnKhan.Checked = true;
                            }

                        }
                    }
                
            }
            #endregion master

            //Thêm detail
            #region
            if (DHID != null && DHID.Length > 0)
            {
                CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                DataTable dtDetail = (DataTable)MasterTemplate.DataSource;
                if (dtDetail!=null && dtDetail.Rows.Count > 0 && dtDetail.Select("SPID='" + mcboMaSP.SelectedValue.ToString() + "'").Count() > 0)
                {
                    statusTB.Text = "Sản phẩm này đã tồn tại trong đơn hàng, vui lòng kiểm tra lại!";
                    return;
                }

                string kq = dhct.ThemKhan(DHID, mcboMaSP.SelectedValue.ToString(), int.Parse(txtSLDat.Text), cboDVXuat.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                if (kq != String.Empty)
                {
                    statusTB.Text = "Thêm chi tiết (đơn khẩn) thành công!";
                    MasterTemplate.DataSource = dhct.LoadLenLuoi(DHID);
                    HienThiCanhBaoSanPhamCanDate();
                    mcboMaSP.SelectedIndex = -1;
                    mcboTenSP.SelectedIndex = -1;
                    txtSLDat.Text = "";
                    txtSLTon.Text = "";
                    mcboTenSP.Focus();
                }

                else
                {
                    statusTB.Text = "Thêm chi tiết (đơn khẩn) thất bại";
                }
            }

            #endregion

            KiemTraDanhSachChiTietKho(DHID);
        }

        private void MasterTemplate_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (MasterTemplate.CurrentCell.ColumnInfo.Name.CompareTo("colSLDat") == 0)
            {
                if (MasterTemplate.CurrentRow.Cells["colSLDat"].Value != null && MasterTemplate.CurrentRow.Cells["colSLDat"].Value.ToString().CompareTo("") > 0)
                {
                    CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                    int kq = dhct.SuaSLDat(MasterTemplate.CurrentRow.Cells["colDHCTID"].Value.ToString(), decimal.Parse(MasterTemplate.CurrentRow.Cells["colSLDat"].Value.ToString()));
                    if (kq > 0)
                    {
                        statusTB.Text = "Sửa số lượng đặt thành công!";
                        if (!MasterTemplate.CurrentCell.ColumnInfo.IsSorted)
                        {
                            MasterTemplate.GridNavigator.SelectNextRow(1);
                        }
                    }
                    else
                    {
                        statusTB.Text = "Sửa số lượng đặt thất bại!";
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                btnTienTien.Enabled = true;
                if (rdbtnChuKy.Checked != true && rdbtnKhan.Checked != true)
                {
                    err.SetError(rdbtnChuKy, "Bạn chưa chọn kiểu đặt hàng!");
                    err.SetError(rdbtnKhan, "Bạn chưa chọn kiểu đặt hàng!");
                    rdbtnChuKy.Focus();
                    return;
                }
                else
                {
                    err.SetError(rdbtnChuKy, "");
                    err.SetError(rdbtnKhan, "");
                }
                if (cboNhom.SelectedValue == null || cboNhom.SelectedIndex == -1)
                {
                    err.SetError(cboNhom, "Bạn chưa chọn nhóm!");
                    cboNhom.Focus();
                    return;
                }
                else
                {
                    err.SetError(cboNhom, "");
                }
                Fr_DangXuLy.ShowFormCho();
                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                //Thêm master

                #region master
                if (DHID != null && DHID.Length > 0)
                {
                    //Sửa đơn hàng master
                    CSQLNT_DatHang dh = new CSQLNT_DatHang();
                    if (dh.Sua(DHID, txtGhiChu.Text, ckDuyet.Checked, CStaticBien.SmaTaiKhoan, false) > 0)
                    {
                        statusTB.Text = "Sửa đơn hàng thành công!";
                    }
                    else
                    {
                        statusTB.Text = "Sửa đơn hàng thất bại";
                    }
                }
                else
                {
                    //Thêm đơn hàng master
                    CSQLNT_DatHang dh = new CSQLNT_DatHang();
                    string[] dhid_sodh = dh.Them(rdbtnKhan.Checked, txtGhiChu.Text, DateTime.Now, CStaticBien.SmaTaiKhoan, false, cboNhom.SelectedValue.ToString());
                    if (dhid_sodh != null)
                    {
                        DHID = dhid_sodh[0];
                        SODH = dhid_sodh[1];
                        DataTable dtb1dh = dh.LayDatHang(DHID);
                        if (dtb1dh != null && dtb1dh.Rows.Count > 0)
                        {
                            txtSoDH.Text = dtb1dh.Rows[0]["SoDH"].ToString();
                            dtNgayDH.Value = DateTime.Parse(dtb1dh.Rows[0]["NgayTao"].ToString());
                            txtGhiChu.Text = dtb1dh.Rows[0]["GhiChu"].ToString();
                            ckDuyet.Checked = bool.Parse(dtb1dh.Rows[0]["DuyetDH"].ToString());

                            if (bool.Parse(dtb1dh.Rows[0]["DaXacNhanDH"].ToString()) == false)
                            {
                                ckDuyet.Enabled = true;
                            }
                            else
                            {
                                ckDuyet.Enabled = false;
                            }
                            if (bool.Parse(dtb1dh.Rows[0]["DonKhan"].ToString()) == false)
                            {
                                rdbtnChuKy.Checked = true;
                            }
                            else
                            {
                                rdbtnKhan.Checked = true;
                            }

                        }
                    }
                }
                cboNhom.Enabled = false;
                rdbtnChuKy.Enabled = false;
                rdbtnKhan.Enabled = false;
                btnOk.Enabled = false;
                #endregion master

                //Thêm detail
                #region detail
                if (DHID != string.Empty)
                {
                    statusTB.Text = "";
                    CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        string kq = dhct.ThemChuKy(DHID, cboNhom.SelectedValue.ToString());
                        if (kq.Equals("OK"))
                        {
                            statusTB.Text = "Thêm đặt hàng chi tiết (theo chu kỳ) thành công!";
                            MasterTemplate.DataSource = dhct.LoadLenLuoi(DHID);
                            HienThiCanhBaoSanPhamCanDate();
                            this.Cursor = Cursors.Arrow;
                        }
                        else
                        {
                            statusTB.Text = "Thêm đặt hàng chi tiết (theo chu kỳ) thất bại: " + kq;
                            this.Cursor = Cursors.Arrow;
                        }
                    }
                    catch (ApplicationException ex)
                    {
                        MessageBox.Show("Đã có lỗi phát sinh khi thêm đặt hàng chi tiết (theo chu kỳ) " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi phát sinh khi thêm đặt hàng chi tiết (theo chu kỳ) " + ex.Message);
                    }
                }
                #endregion detail
            }
            catch { }
            finally
            {
                Fr_DangXuLy.DongFormCho();
            }
        }

        private void ckDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyet.Checked == true)
            {
                txtGhiChu.Enabled = false;
                this.MasterTemplate.Columns["colSLDat"].ReadOnly = true;
                mcboMaSP.Enabled = false;
                mcboTenSP.Enabled = false;
                txtSLDat.Enabled = false;

            }
            else
            {
                txtGhiChu.Enabled = true;
                this.MasterTemplate.Columns["colSLDat"].ReadOnly = false;
                mcboMaSP.Enabled = true;
                mcboTenSP.Enabled = true;
                txtSLDat.Enabled = true;

            }
        }

        private void rbtnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_DatHang.Name) == false)
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

            #region kiểm tra điều kiện nhập
            if (rdbtnKhan.Checked != true && rdbtnChuKy.Checked != true && rbtnDatTheoPos.Checked != true)
            {
                err.SetError(rdbtnChuKy, "Bạn chưa chọn kiểu đặt hàng!");
                err.SetError(rdbtnKhan, "Bạn chưa chọn kiểu đặt hàng!");
                return;
            }
            else
            {
                err.SetError(rdbtnChuKy, "");
                err.SetError(rdbtnKhan, "");
            }
            if (rdbtnKhan.Checked == true && MasterTemplate.Rows.Count == 0)
            {
                if (mcboMaSP.SelectedValue == null || mcboMaSP.SelectedIndex == -1)
                {
                    err.SetError(mcboMaSP, "Bạn chưa chọn sản phẩm!");
                    mcboMaSP.Focus();
                    return;
                }
                else
                {
                    err.SetError(mcboMaSP, "");
                }
                if (txtSLDat.Text == string.Empty)
                {
                    err.SetError(txtSLDat, "Bạn chưa nhập số lượng đặt!");
                    txtSLDat.Focus();
                    return;
                }
                else
                {
                    err.SetError(txtSLDat, "");
                }
            }

            if (rdbtnChuKy.Checked == true && MasterTemplate.Rows.Count == 0)
            {
                if (cboNhom.SelectedValue == null || cboNhom.SelectedIndex == -1)
                {
                    err.SetError(cboNhom, "Bạn chưa chọn nhóm!");
                    cboNhom.Focus();
                    return;
                }
                else
                {
                    err.SetError(cboNhom, "");
                }
            }
            #endregion
            //Thêm master
            #region master
            if (DHID != null && DHID.Length > 0)
            {
                //Sửa đơn hàng master
                CSQLNT_DatHang dh = new CSQLNT_DatHang();
                if (dh.Sua(DHID, txtGhiChu.Text, ckDuyet.Checked, CStaticBien.SmaTaiKhoan, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet()) > 0)
                {
                    statusTB.Text = "Sửa đơn hàng thành công!";
                }
                else
                {
                    statusTB.Text = "Sửa đơn hàng thất bại";
                }
            }
            else
            {
                //Thêm đơn hàng master
                CSQLNT_DatHang dh = new CSQLNT_DatHang();
                string[] dhid_sodh = dh.Them(rdbtnKhan.Checked, txtGhiChu.Text, DateTime.Now, CStaticBien.SmaTaiKhoan, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet(), cboNhom.SelectedValue.ToString());
                if (dhid_sodh != null)
                {
                    DHID = dhid_sodh[0];
                    SODH = dhid_sodh[1];
                    DataTable dtb1dh = dh.LayDatHang(DHID);
                    if (dtb1dh != null && dtb1dh.Rows.Count > 0)
                    {
                        txtSoDH.Text = dtb1dh.Rows[0]["SoDH"].ToString();
                        dtNgayDH.Value = DateTime.Parse(dtb1dh.Rows[0]["NgayTao"].ToString());
                        txtGhiChu.Text = dtb1dh.Rows[0]["GhiChu"].ToString();
                        ckDuyet.Checked = bool.Parse(dtb1dh.Rows[0]["DuyetDH"].ToString());

                        if (bool.Parse(dtb1dh.Rows[0]["DaXacNhanDH"].ToString()) == false)
                        {
                            ckDuyet.Enabled = true;
                        }
                        else
                        {
                            ckDuyet.Enabled = false;
                        }
                        if (bool.Parse(dtb1dh.Rows[0]["DonKhan"].ToString()) == false)
                        {
                            rdbtnChuKy.Checked = true;
                        }
                        else
                        {
                            rdbtnKhan.Checked = true;
                        }

                    }
                }
            }
            #endregion master
            if (rdbtnKhan.Checked == false)
            {
                btnTienTien_Click(sender, e);
            }
        }

        private void rbtnThemMoi_Click(object sender, EventArgs e)
        {
            matien = true;
            btnTienTien.Enabled = false;
            SODH = "";
            DHID = "";
            txtSoDH.Text = "";
            dtNgayDH.Value = DateTime.Now;
            rdbtnChuKy.Checked = false;
            rdbtnKhan.Checked = false;
            cboNhom.SelectedIndex = -1;
            mcboMaSP.SelectedIndex = -1;
            mcboTenSP.SelectedIndex = -1;
            txtSLDat.Text = "";
            txtSLTon.Text = "";
            txtGhiChu.Text = "";
            ckDuyet.Checked = false;
            cboDVXuat.SelectedIndex = -1;
            cboNSX.SelectedIndex = -1;

            btnAdd.Enabled = true;
            btnOk.Enabled = true;
            rdbtnChuKy.Enabled = true;
            rdbtnKhan.Enabled = true;
            cboNhom.Enabled = true;
            txtGhiChu.Enabled = true;
            txtSLDat.Enabled = true;
            mcboMaSP.Enabled = true;
            mcboTenSP.Enabled = true;
            MasterTemplate.DataSource = null;
        }

        private void MasterTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            if (rdbtnKhan.Checked == true)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    sodhctid = MasterTemplate.CurrentRow.Cells["colDHCTid"].Value.ToString();

                    try
                    {
                        CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                        if (!chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked)
                        {
                            MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                            return;
                        }

                        CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                        if (dhct.Xoa(sodhctid) > 0)
                        {
                            MasterTemplate.DataSource = dhct.LoadLenLuoi(DHID);
                            kt = false;
                        }
                        else
                            statusTB.Text = "Xóa thất bại!";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi khi xóa chi tiết đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }

                    KiemTraDanhSachChiTietKho(DHID);
                }
            }
        }

        private void rbtnIn_Click(object sender, EventArgs e)
        {
            InDatHang(DHID);
        }

        public void InDatHang(string dhid_)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_DatHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNT_DatHangCT dhct_ = new CSQLNT_DatHangCT();
            if (dhid_ != null && dhid_.Length > 0)
            {
                DataTable DatHangCT_ = dhct_.IN_DH_DHCT(dhid_);
                bool donkhan = bool.Parse(DatHangCT_.Rows[0]["DonKhan"].ToString());
                Fr_DatHang check = new Fr_DatHang(DatHangCT_, donkhan);
                check.Show();
            }
        }

        private void btnLayTT_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDatTheoPos.Checked == true)
                {
                    string nhomspid = null;
                    DataTable ListCycle = Tim_CyclesNo();
                    DataTable dtb = new DataTable();
                    CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                    //Fr_DangXuLy.ShowFormCho();
                    foreach (DataRow dr in ListCycle.Rows)
                    {                      

                        dtb = Tim_Order(int.Parse(dr[0].ToString()));
                        foreach (DataRow drdhct in dtb.Rows)
                        {
                            if (DHID == null || DHID.Length == 0)
                            {
                                //Lấy nhóm sản phẩm
                                int groupno = int.Parse(dr["GroupNo"].ToString());
                                
                                switch (groupno)
                                {
                                    case 1:
                                        { 
                                            nhomspid = "B2AFBA45-6B5F-4980-807D-6DDE1F8C10CF";
                                            break;
                                        }
                                    case 2:
                                        {
                                            nhomspid = "2CE82C38-C009-46B8-827F-2C0A40491553";
                                            break;
                                        }
                                    case 3:
                                        {
                                            nhomspid = "C622DBB7-8440-4062-B56E-8FB79F7A50EB";
                                            break;
                                        }
                                    case 4:
                                        {
                                            nhomspid = "754D16E4-2BB1-4650-933E-6CCCA30FBCF5";
                                            break;
                                        }
                                    case 5:
                                        {
                                            nhomspid = "BF325C6B-8074-41CE-8453-61E5E8B2CC90";
                                            break;
                                        }                                    
                                }
                                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                                CSQLNT_DatHang dh = new CSQLNT_DatHang();
                                //DHID = dh.Them(false, "Đơn hàng lấy từ DB IMS", DateTime.Now, CStaticBien.SmaTaiKhoan)[0];
                                DHID = dh.Them(false, "Đơn hàng lấy từ DB IMS cycle: " + dr["CycleNo"].ToString(), DateTime.Now, "6DF1A759-5EAF-4B09-B053-22C337732653", cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet(), nhomspid)[0];
                            }
                            string sldat = drdhct["SLDat"].ToString();
                            string SLDeNghi = drdhct["SLDeNghi"].ToString();
                            if (sldat.Length == 0)
                            {
                                if (SLDeNghi.Length > 0)
                                    sldat = SLDeNghi;
                                else
                                    sldat = "0";
                            }
                            if (SLDeNghi.Length == 0)
                                SLDeNghi = "0";

                            dhct.ThemDatHangCTTheoDBACC(DHID, drdhct["MaSP"].ToString(), decimal.Parse(sldat), decimal.Parse(SLDeNghi));
                        }
                        DHID = null;
                    }
                    
                    if (DHID != null && DHID.Length > 0)
                    {
                        cboNhom.SelectedValue = nhomspid;
                        MasterTemplate.DataSource = dhct.LoadLenLuoi(DHID);
                        statusTB.Text = "";
                    }
                    else
                    {
                        rbtnDong_Click(sender, e);
                        MessageBox.Show("Đã lấy xong đơn đặt hàng, vui lòng kiểm tra & duyệt đơn hàng mới tạo!");
                        //statusTB.Text = "Thêm đặt hàng thất bại!";
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //finally
            //{
            //    Fr_DangXuLy.DongFormCho();
            //}
        }

        // tìm số Cycles trong 1 Ngày
        public DataTable Tim_CyclesNo()
        {
            CDuLieuAccess dlacc = new CDuLieuAccess();
            string sql = @"SELECT Cycles.CycleNo, Cycles.GroupNo, Cycles.DateProcessed FROM Cycles
WHERE ((Cycles.DateProcessed)>=#" 
                //+ DateTime.Now.ToShortDateString() 
                //+ "11/27/2009"
                + dtNgayLayThongTin.Value.ToShortDateString()
                + " 12:00:00 AM# and (Cycles.DateProcessed)<= #"
                + dtNgayLayThongTin.Value.ToShortDateString()
                //+ DateTime.Now.ToShortDateString() 
                //+ "11/27/2009"
                + " 11:59:59 PM#)";
            return dlacc.LoadDataMDB(sql);
        }

        // Tìm Order
        public DataTable Tim_Order(int a)
        {
            CDuLieuAccess dlacc = new CDuLieuAccess();
//            string sql = @"SELECT Orders.Order as SLDat, Orders.CycleNo, Orders.ItemNo as MaSP, Orders.sOrder as SLDeNghi
//                        FROM Orders WHERE ((((Orders.Order)>=0) or ((Orders.sOrder)>0)) AND ((Orders.CycleNo)=" + a + "))"
//                        + @" union SELECT Orders.Order as SLDat, Orders.CycleNo, Orders.ItemNo as MaSP, Orders.sOrder as SLDeNghi
//                        FROM Orders WHERE ((((Orders.Order)>=0) and ((Orders.sOrder) is null)))";

            string sql = @"(SELECT Orders.Order as SLDat, Orders.CycleNo, Orders.ItemNo as MaSP, Orders.sOrder as SLDeNghi
                            FROM Orders WHERE ((((Orders.Order)>=0) or ((Orders.sOrder)>0)) AND ((Orders.CycleNo)=" + a + ")))"
                           + @"Union all
                            (SELECT Orders.Order as SLDat, Orders.CycleNo, Orders.ItemNo as MaSP, Orders.sOrder as SLDeNghi
                            FROM Orders WHERE ((((Orders.Order)>=0) and ((Orders.sOrder) is null))))";
            return dlacc.LoadDataMDB(sql);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExportToExcelML exporter = new ExportToExcelML(this.MasterTemplate);
            exporter.ExportVisualSettings = true;

            string tempPath = Path.GetTempPath();
            tempPath += @"\tempDatHang" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString()+DateTime.Now.Year.ToString()+DateTime.Now.Hour.ToString()+DateTime.Now.Minute.ToString()  +".xls";
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
            desktopPath += @"\DatHang"+DateTime.Now.Day.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Year.ToString()+DateTime.Now.Hour.ToString()+DateTime.Now.Minute.ToString()+".xls";

            wb.SaveAs(desktopPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
            wb.Close();
            app.Quit();

            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(app);

            File.Delete(tempPath);
            MessageBox.Show("File đã xuất thành công, kiểm tra lại file trên desktop!");
        }
        bool kt = false;
        private void MasterTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                CSQLNT_DatHangCT dhct_ = new CSQLNT_DatHangCT();
                rgvLichSu.DataSource = dhct_.XemThongTinCacChuKyTruoc(MasterTemplate.CurrentRow.Cells["colSPID"].Value.ToString());
            }
            catch { }
        }

        private void MasterTemplate_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                CSQLNT_DatHangCT dhct_ = new CSQLNT_DatHangCT();
                if (kt == false)
                {
                    string spid = MasterTemplate.CurrentRow.Cells["colSPID"].Value.ToString();
                    sodhctid = MasterTemplate.CurrentRow.Cells["colDHCTid"].Value.ToString();
                }
                rgvLichSu.DataSource = dhct_.XemThongTinCacChuKyTruoc(MasterTemplate.CurrentRow.Cells["colSPID"].Value.ToString());
                
            }
            catch 
            { }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                OnKeyPress(new KeyPressEventArgs((Char)Keys.Delete));
                kt = true;
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void btnTienTien_Click(object sender, EventArgs e)
        {
            CSQLNT_DatHang dh_ = new CSQLNT_DatHang();
            DataTable dtbTongTienHang = dh_.LayTongTienSauKhiDatHang();

            txtTonChuaDat.Text = Convert.ToDecimal(dtbTongTienHang.Rows[0]["TongTienTonCuaHang"].ToString()).ToString("#,###");
            decimal TonChuaDat = Convert.ToDecimal(txtTonChuaDat.Text);
            decimal TienDatHang;
            txtTienDatHang.Text = Convert.ToDecimal(dtbTongTienHang.Rows[0]["TongTienDatHang"].ToString()).ToString("#,###");
            if (txtTienDatHang.Text == "")
            {
                MessageBox.Show("Bạn chưa đặt hàng. Vui lòng Kiểm Tra lại.");
                return;
            }
            else
            {
                TienDatHang = Convert.ToDecimal(txtTienDatHang.Text);
            }
            txtTongTienDat.Text = Convert.ToDecimal(dtbTongTienHang.Rows[0]["TongTienSauKhiDatHang"].ToString()).ToString("#,###");
            decimal TongTienDat = Convert.ToDecimal(txtTongTienDat.Text);

            string xulydinhmuc = txtDinhMucCuaHang.Text.Replace(",", "");
            decimal TienDinhMuc = Convert.ToDecimal(xulydinhmuc);

            string xulyttdathang = txtTongTienDat.Text.Replace(",", "");
            decimal TienTongDat = Convert.ToDecimal(xulyttdathang);

            decimal TienDuoi_Qua = TienDinhMuc - TienTongDat;
            txtDuoi_QuaDM.Text = TienDuoi_Qua.ToString("#,###");

            if (matien == false)
            {
                dh_.Sua_DonHang_DinhMuc(txtSoDH.Text, TienDinhMuc, TonChuaDat, TienDatHang, TongTienDat, TienDuoi_Qua);
            }
            else
            { 
                dh_.Them_DonHang_DinhMuc(txtSoDH.Text, TienDinhMuc, TonChuaDat, TienDatHang, TongTienDat, TienDuoi_Qua);
                matien = false;

            }
        }

        private void MasterTemplate_MouseHover(object sender, EventArgs e)
        {
            /*Point clientPos = MasterTemplate.PointToClient(Control.MousePosition);
            MessageBox.Show(clientPos.X+"");

            MouseEventArgs args = (MouseEventArgs)e;*/
        }
    }
}
