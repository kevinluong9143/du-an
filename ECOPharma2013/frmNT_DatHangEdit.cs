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

namespace ECOPharma2013
{
    public partial class frmNT_DatHangEdit : Form
    {
        public frmNT_DatHangEdit()
        {
            InitializeComponent();
        }
        frmMain fmain;

        public frmNT_DatHangEdit(frmMain _frmmain)
        {
            InitializeComponent();
            fmain = _frmmain;
        }

        string DHID, SODH;

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
            fmain.frmNT_DatHangEditisOpen_ = false;
            this.Close();
        }


        private void frmNT_DatHangEdit_Load(object sender, EventArgs e)
        {
            
            LayDSNhomSPLenCBO();
            LayDSSanPhamLenMCBO();
            if (DHID!=null && DHID != string.Empty)
            {
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
                    rgvChiTiet.DataSource = dhct.LoadLenLuoi(DHID);
                }

                //3. Enable các control chức năng
               
                cboDVXuat.Enabled = false;
                cboNSX.Enabled = false;
                btnAdd.Enabled = false;
                btnOk.Enabled = false;
                cboNhom.Enabled = false;
                rdbtnChuKy.Enabled = false;
                rdbtnKhan.Enabled = false;
                if (ckDuyet.Checked == true)
                {
                    txtGhiChu.Enabled = false;
                }
                else
                {
                    txtGhiChu.Enabled = true;
                }
            }
            rgvChiTiet.CellFormatting += new CellFormattingEventHandler(rgvChiTiet_CellFormatting);
        }


        void rgvChiTiet_CellFormatting(object sender, CellFormattingEventArgs e)
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
                mcboMaSP.EditorControl.Columns["MaSP"].Width = 40;
                mcboMaSP.EditorControl.Columns["TenSP"].Width = 265;
                mcboMaSP.EditorControl.Columns["TenNSX"].Width = 150;
                mcboMaSP.EditorControl.Columns["DVXuat"].Width = 55;
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
                mcboTenSP.EditorControl.Columns["MaSP"].Width = 40;
                mcboTenSP.EditorControl.Columns["TenSP"].Width = 265;
                mcboTenSP.EditorControl.Columns["TenNSX"].Width = 150;
                mcboTenSP.EditorControl.Columns["DVXuat"].Width = 55;
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
                }
            }
            #endregion master

            //Thêm detail
            #region
            if (DHID != null && DHID.Length > 0)
            {
                CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                string kq = dhct.ThemKhan(DHID, mcboMaSP.SelectedValue.ToString(), int.Parse(txtSLDat.Text), cboDVXuat.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
                if (kq != String.Empty)
                {
                    statusTB.Text = "Thêm chi tiết (đơn khẩn) thành công!";
                    rgvChiTiet.DataSource = dhct.LoadLenLuoi(DHID);
                    mcboMaSP.SelectedIndex = -1;
                    mcboTenSP.SelectedIndex = -1;
                    txtSLDat.Text = "";
                    txtSLTon.Text = "";
                }

                else
                {
                    statusTB.Text = "Thêm chi tiết (đơn khẩn) thất bại";
                }
            }

            #endregion
        }

        private void MasterTemplate_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (rgvChiTiet.CurrentCell.ColumnInfo.Name.CompareTo("colSLDat") == 0)
            {
                if (rgvChiTiet.CurrentRow.Cells["colSLDat"].Value != null && rgvChiTiet.CurrentRow.Cells["colSLDat"].Value.ToString().CompareTo("") > 0)
                {
                    CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                    int kq = dhct.SuaSLDat(rgvChiTiet.CurrentRow.Cells["colDHCTID"].Value.ToString(), decimal.Parse(rgvChiTiet.CurrentRow.Cells["colSLDat"].Value.ToString()));
                    if (kq > 0)
                    {
                        statusTB.Text = "Sửa số lượng đặt thành công!";
                        rgvChiTiet.CurrentRow = rgvChiTiet.Rows[rgvChiTiet.CurrentRow.Index + 1];
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
                    string[] dhid_sodh = dh.Them(rdbtnKhan.Checked, txtGhiChu.Text, DateTime.Now, CStaticBien.SmaTaiKhoan,false , cboNhom.SelectedValue.ToString());
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
                            rgvChiTiet.DataSource = dhct.LoadLenLuoi(DHID);
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
                this.rgvChiTiet.Columns["colSLDat"].ReadOnly = true;
                mcboMaSP.Enabled = false;
                mcboTenSP.Enabled = false;
                txtSLDat.Enabled = false;

            }
            else
            {
                txtGhiChu.Enabled = true;
                this.rgvChiTiet.Columns["colSLDat"].ReadOnly = false;
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
            #region kiểm tra điều kiện nhập
            if (rdbtnKhan.Checked != true && rdbtnChuKy.Checked != true)
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
            if (rdbtnKhan.Checked == true && rgvChiTiet.Rows.Count==0)
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

            if (rdbtnChuKy.Checked == true && rgvChiTiet.Rows.Count == 0)
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
            #endregion master

        }

        private void rbtnThemMoi_Click(object sender, EventArgs e)
        {
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
            rgvChiTiet.DataSource = null;
        }

        private void rgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (rdbtnKhan.Checked == true)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    try
                    {
                        CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                        if (dhct.Xoa(rgvChiTiet.CurrentRow.Cells["colDHCTID"].Value.ToString()) > 0)
                            rgvChiTiet.DataSource = dhct.LoadLenLuoi(DHID);
                        else
                            statusTB.Text = "Xóa thất bại!";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi khi xóa chi tiết đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
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
    }
}
