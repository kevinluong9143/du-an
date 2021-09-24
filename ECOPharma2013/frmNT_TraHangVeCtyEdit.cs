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
    public partial class frmNT_TraHangVeCtyEdit : Form
    {
        public frmNT_TraHangVeCtyEdit()
        {
            InitializeComponent();
        }
        frmMain fmain;
        public frmNT_TraHangVeCtyEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            fmain.frmNT_TraHangVeCTyEditisOpen_ = false;
            if (fmain.DSNT_TraHangVeCtyXacNhanIsOpen == true)
            {
                fmain.fNT_TraHangVeCtyXacNhan.LayDSLenLuoiXacNhan();
            }
            if (fmain.DSNT_TraHangVeCtyIsOpen == true)
            {
                fmain.fNT_TraHangVeCty.LoadLenLuoi();
            }
            this.Close();
        }

        string THID;
        string SOPTH;
        string THCTID;
        int LOAIHANGTRA;

        /// <summary>
        /// Hàm dùng lấy thid, sopth từ form trả hàng để chỉnh sửa
        /// </summary>
        /// <param name="_chid"></param>
        /// <param name="_sopch"></param>
        public void NhanTHID_SoPTH(string _thid, string _sopth)
        {
            THID = _thid;
            SOPTH = _sopth;
        }
        #region Các hàm hỗ trợ
        //1. Lấy danh sách nhà thuốc để chọn khi chuyển hàng lên combobox.
        void LayDanhSachNhaThuocLenCombobox()
        {
            CSQLNT_TraHangVeCtyCT chct = new CSQLNT_TraHangVeCtyCT();
            cboCompany.DisplayMember = "TenNT";
            cboCompany.ValueMember = "NTID";
            cboCompany.DataSource = chct.LayDSNhaThuoc();
            cboCompany.SelectedIndex = -1;
        }

        //2. Lấy danh sách masp, tên thuốc, nsx vào multicolumncombobox
        void LayDanhSachSanPhamLenMultiColumnCombobox()
        {
            CSQLNT_TraHangVeCtyCT chct = new CSQLNT_TraHangVeCtyCT();
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();

            mcboMaSP.ValueMember = "SPID";
            mcboMaSP.DisplayMember = "MaSP";

            mcboTenSP.ValueMember = "SPID";
            mcboTenSP.DisplayMember = "TenSP";

            mcboMaSP.DataSource = chct.LayDSThongTinSanPham(cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet());
            mcboTenSP.DataSource = chct.LayDSThongTinSanPham(cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet());

            mcboMaSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
            mcboMaSP.EditorControl.Columns["NSXID"].IsVisible = false;
            mcboMaSP.EditorControl.Columns["SPID"].IsVisible = false;
            mcboMaSP.EditorControl.Columns["MaSP"].Width = 40;
            mcboMaSP.EditorControl.Columns["TenSP"].Width = 265;
            mcboMaSP.EditorControl.Columns["TenNSX"].Width = 150;
            mcboMaSP.EditorControl.Columns["SLTon"].Width = 65;
            mcboMaSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
            mcboMaSP.EditorControl.Columns["DVChuan"].Width = 55;
            //mcboMaSP.EditorControl.Columns["GiaBan"].Width = 70;
            //mcboMaSP.EditorControl.Columns["GiaBan"].FormatString = "{0:N2}";
            mcboMaSP.AutoFilter = true;
            FilterDescriptor descriptor = new FilterDescriptor(this.mcboMaSP.DisplayMember, FilterOperator.IsEqualTo, string.Empty);
            this.mcboMaSP.EditorControl.FilterDescriptors.Add(descriptor);
            this.mcboMaSP.DropDownStyle = RadDropDownStyle.DropDown;
            mcboMaSP.MultiColumnComboBoxElement.DropDownWidth = 680;
            mcboMaSP.MultiColumnComboBoxElement.DropDownHeight = 300;


            mcboTenSP.EditorControl.Columns["SPNSXID"].IsVisible = false;
            mcboTenSP.EditorControl.Columns["NSXID"].IsVisible = false;
            mcboTenSP.EditorControl.Columns["SPID"].IsVisible = false;
            mcboTenSP.EditorControl.Columns["MaSP"].Width = 40;
            mcboTenSP.EditorControl.Columns["TenSP"].Width = 265;
            mcboTenSP.EditorControl.Columns["TenNSX"].Width = 150;
            mcboTenSP.EditorControl.Columns["SLTon"].Width = 65;
            mcboTenSP.EditorControl.Columns["SLTon"].FormatString = "{0:N2}";
            mcboTenSP.EditorControl.Columns["DVChuan"].Width = 55;
            //mcboTenSP.EditorControl.Columns["GiaBan"].Width = 70;
            //mcboTenSP.EditorControl.Columns["GiaBan"].FormatString = "{0:N2}";
            mcboTenSP.AutoFilter = true;
            FilterDescriptor descriptor1 = new FilterDescriptor(this.mcboTenSP.DisplayMember, FilterOperator.StartsWith, string.Empty);
            this.mcboTenSP.EditorControl.FilterDescriptors.Add(descriptor1);
            this.mcboTenSP.DropDownStyle = RadDropDownStyle.DropDown;
            mcboTenSP.MultiColumnComboBoxElement.DropDownWidth = 680;
            mcboTenSP.MultiColumnComboBoxElement.DropDownHeight = 300;

            mcboMaSP.SelectedIndex = -1;
            mcboTenSP.SelectedIndex = -1;
        }

        //Lấy nhà sản xuất
        void LayDanhSachNSXLenCombobox(string spid)
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

        //Lấy kho theo masp
        void LayDanhSachKhoLenCombobox(string spid, string nsxid)
        {
            CSQLNT_TraHangVeCtyCT chct = new CSQLNT_TraHangVeCtyCT();
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();

            cboKho.DisplayMember = "TenKho";
            cboKho.ValueMember = "KhoID";

            try
            {
                cboKho.DataSource = chct.LayDSKho(spid, nsxid, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet());
                statusTB.Text = "";
            }
            catch
            {
                cboKho.DataSource = null;
                statusTB.Text = "Không lấy được kho của sản phẩm";
                return;
            }
        }

        //Lấy Lot theo MaSP, NSX, KhoID
        void LayLot(string spid, string nsxid, string khoid)
        {
            CSQLNT_TraHangVeCtyCT chct = new CSQLNT_TraHangVeCtyCT();
            cboSoLo.DisplayMember = "Lot";
            cboSoLo.ValueMember = "Lot";
            try
            {
                cboSoLo.DataSource = chct.LayLot(spid, nsxid, khoid);
                statusTB.Text = "";
            }
            catch
            {
                cboSoLo.DataSource = null;
                statusTB.Text = "Không lấy được kho của sản phẩm";
                return;
            }
        }

        //Lấy đơn vị tính (DVXuat: Mặc định) cho sản phẩm
        void LayDonViTinh(string spid)
        {
            CSQLNT_TraHangVeCtyCT chct = new CSQLNT_TraHangVeCtyCT();

            cboDVT.DisplayMember = "TenDVT";
            cboDVT.ValueMember = "DVTID";

            try
            {
                cboDVT.DataSource = chct.LayDSDVT(spid);
                statusTB.Text = "";
                //LẤY ĐƠN VỊ XUẤT MẶC ĐỊNH CHO SẢN PHẨM
                string dvxuat = chct.LayDVXuat(spid);
                if (dvxuat.Length > 0)
                    cboDVT.SelectedValue = new Guid(dvxuat);
            }
            catch
            {
                cboDVT.DataSource = null;
                statusTB.Text = "Không lấy được đơn vị tính của sản phẩm";
                return;
            }
        }

        //Lấy date, slton, slcotheban
        void LayDateSLTonSLCoTheBan(string spid, string nsxid, string khoid, string lot, string dvtid)
        {
            CSQLNT_TraHangVeCtyCT chct = new CSQLNT_TraHangVeCtyCT();
            try
            {
                DataTable dtb = chct.LayDateSLTonSLCoTheXuat(spid, nsxid, khoid, lot, dvtid);

                if (dtb != null && dtb.Rows.Count > 0)
                {
                    dtHanDung.Value = (DateTime)dtb.Rows[0]["date"];
                    txtSLTon.Text = String.Format("{0,0:N2}", decimal.Parse(dtb.Rows[0]["slton"].ToString()));
                    txtSLCoTheXuat.Text = String.Format("{0,0:N2}", decimal.Parse(dtb.Rows[0]["slcotheban"].ToString()));
                    txtDVC.Text = cboDVT.Text;
                    //txtTongSL.Text = String.Format("{0,0:N2}",decimal.Parse(mcboMaSP.EditorControl.CurrentRow.Cells["SLTon"].Value.ToString()));
                    txtTongSL.Text = String.Format("{0,0:N2}", decimal.Parse(dtb.Rows[0]["TSLTON"].ToString()));
                    //MessageBox.Show(slton +"/"+ slcotheban);
                }
                else
                {
                    txtSLTon.Text = "";
                    txtSLCoTheXuat.Text = "";
                    txtDVC.Text = "";
                    txtTongSL.Text = "";
                }
            }
            catch
            {
                cboDVT.DataSource = null;
                statusTB.Text = "Không lấy được date, slton, slcothexuat của sản phẩm";
                return;
            }
        }
        #endregion Các hàm hỗ trợ

        #region Hàm lấy dữ liệu lên form
        private void frmNT_TraHangVeCtyEdit_Load(object sender, EventArgs e)
        {
            LayDanhSachNhaThuocLenCombobox();
            LayDanhSachSanPhamLenMultiColumnCombobox();

            KiemTraDanhSachChiTietKho(THID);

            if (THID != null && THID.Length > 0)
            {
                //1. Lấy thông tin chuyển hàng (master)
                CSQLNT_TraHangVeCty th = new CSQLNT_TraHangVeCty();
                try
                {
                    DataTable dtb1th = th.LayTraHang(THID);
                    if (dtb1th != null && dtb1th.Rows.Count > 0)
                    {
                        txtSPTra.Text = dtb1th.Rows[0]["SoPTH"].ToString();
                        cboCompany.SelectedValue = dtb1th.Rows[0]["Destination"].ToString();
                        dtNgayChungTu.Value = DateTime.Parse(dtb1th.Rows[0]["NgayTao"].ToString());
                        txtGhiChu.Text = dtb1th.Rows[0]["GhiChu"].ToString();
                        ckDuyet.Checked = bool.Parse(dtb1th.Rows[0]["DaXetDuyet"].ToString());
                        if (int.Parse(dtb1th.Rows[0]["LoaiHangTra"].ToString()) == 1)
                            rbtnBinhThuong.Checked = true;
                        else if (int.Parse(dtb1th.Rows[0]["LoaiHangTra"].ToString()) == 2)
                            rbtnBatThuong.Checked = true;
                        if (bool.Parse(dtb1th.Rows[0]["DaXacNhan"].ToString()) == false)
                            ckDuyet.Enabled = true;
                        else
                            ckDuyet.Enabled = false;
                        //DungLV thêm mới field isTraDacBiet 
                        if (bool.Parse(dtb1th.Rows[0]["IsTraDacBiet"].ToString()) == false)
                            cbIsTraDacBiet.Checked = false;
                        else 
                            cbIsTraDacBiet.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi khi lấy thông tin chuyển hàng (master)", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }

                //2. Lấy thông tin chuyển hàng chi tiết (detail)
                if (THID != null && THID.Length > 0)
                {
                    CSQLNT_TraHangVeCtyCT thct = new CSQLNT_TraHangVeCtyCT();
                    rgvChiTiet.DataSource = thct.LayLenLuoi(THID);
                }
				//DungLV thêm mới field isTraDacBiet 
                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                bool isTrangThaiDonTraLoi = chht.KiemTraTrangThaiDonTraLoi();
                bool isKhoDacBiet = chht.KiemTraTrangThaiXemKhoDacBiet();

                //3. Enable các control chức năng
                if (ckDuyet.Checked == true)
                {
                    cboCompany.Enabled = false;
                    txtGhiChu.Enabled = false;
                    mcboMaSP.Enabled = false;
                    mcboTenSP.Enabled = false;
                    txtSL.Enabled = false;
                    cboDVT.Enabled = false;
                    cboKho.Enabled = false;
                    cboSoLo.Enabled = false;
                    btnAdd.Enabled = false;
                    rbtnBinhThuong.Enabled = false;
                    rbtnBatThuong.Enabled = false;

                    if (isKhoDacBiet)
                    {
                        // DungLV thêm mới field isTraDacBiet 
                        cbkHangDacBiet.Visible = true;
                        cbkHangDacBiet.Enabled = false;
                    }
                    else
                    {
                        cbkHangDacBiet.Visible = false;
                    }

                    if (isTrangThaiDonTraLoi) { 
                        // DungLV thêm mới field isTraDacBiet 
                        cbIsTraDacBiet.Visible = true;
                        cbIsTraDacBiet.Enabled = false;
                    } else
                    {
                        cbIsTraDacBiet.Visible = false;
                    }
                    // DungLV thêm mới field isTraDacBiet 
                }
                else
                {
                    cboCompany.Enabled = true;
                    txtGhiChu.Enabled = true;
                    mcboMaSP.Enabled = true;
                    mcboTenSP.Enabled = true;
                    txtSL.Enabled = true;
                    cboDVT.Enabled = true;
                    cboKho.Enabled = true;
                    cboSoLo.Enabled = true;
                    btnAdd.Enabled = true;
                    rbtnBinhThuong.Enabled = true;
                    rbtnBatThuong.Enabled = true;
                    //DungLV thêm mới field isTraDacBiet 
                    if (isTrangThaiDonTraLoi)
                    {
                        // DungLV thêm mới field isTraDacBiet 
                        cbIsTraDacBiet.Visible = true;
                        cbIsTraDacBiet.Enabled = true;
                    }
                    else
                    {
                        cbIsTraDacBiet.Visible = false;
                    }

                    if (isKhoDacBiet)
                    {
                        // DungLV thêm mới field isTraDacBiet 
                        cbkHangDacBiet.Visible = true;
                        cbkHangDacBiet.Enabled = true;
                    }
                    else
                    {
                        cbkHangDacBiet.Visible = false;
                    }
                }
            }
            //Focus vào cbonhathuoc
            cboCompany.Focus();
        }

        private void KiemTraDanhSachChiTietKho(string THID)
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            CSQLNT_TraHangVeCty aTraHangVeCty = new CSQLNT_TraHangVeCty();
            bool isKhoDacBiet = chht.KiemTraTrangThaiXemKhoDacBiet();
            if (THID != null && THID.Length > 0)
            {
                CSQLNT_TraHangVeCtyCT thct = new CSQLNT_TraHangVeCtyCT();

                if (thct.LayLenLuoi(THID).Rows.Count > 0)
                {
                    Boolean IsHangDacBiet = thct.KiemTraCoHangDacBiet(THID);

                    if (IsHangDacBiet)
                    {
                        cbkHangDacBiet.Checked = true;

                        if (cbkHangDacBiet.Checked && !chht.KiemTraTrangThaiXemKhoDacBiet())
                        {
                            fmain.fNT_TraHangVeCty.LoadLenLuoi();
                            MessageBox.Show("Vui lòng làm mới lại danh sách Trả hàng");
                            fmain.frmNT_TraHangVeCTyEditisOpen_ = false;
                            this.Close();
                        }
                    }
                    if (isKhoDacBiet)
                    {
                        // DungLV thêm mới field isTraDacBiet 
                        cbkHangDacBiet.Visible = true;
                        cbkHangDacBiet.Enabled = true;
                    }
                    else
                    {
                        cbkHangDacBiet.Visible = false;
                    }
                   
                }
                else
                {
                    if (isKhoDacBiet)
                    {
                        // DungLV thêm mới field isTraDacBiet 
                        cbkHangDacBiet.Visible = true;
                        cbkHangDacBiet.Enabled = true;
                    }
                    else
                    {
                        cbkHangDacBiet.Visible = false;
                    }

                    cbkHangDacBiet.Checked = aTraHangVeCty.IsKhoDacBiet(THID);
                }
            }
            else
            {
                cbkHangDacBiet.Visible = chht.KiemTraTrangThaiXemKhoDacBiet();
                cbIsTraDacBiet.Visible = chht.KiemTraTrangThaiDonTraLoi();
            }
        }

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
                LayDonViTinh(mcboMaSP.SelectedValue.ToString());

                //2.4 Chuyển con trỏ chuột ra đầu dòng mcboTenSP
                RadTextBoxItem rtbi = mcboTenSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
                rtbi.SelectionLength = 0;
            }
            else
            {
                cboNSX.SelectedIndex = -1;
                cboDVT.SelectedIndex = -1;
                txtSLTon.Text = "";
                txtSLCoTheXuat.Text = "";
                txtDVC.Text = "";
                txtTongSL.Text = "";
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

        private void cboNSX_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboNSX.SelectedValue != null && cboNSX.SelectedIndex != -1)
            {
                //4.1 Lấy kho
                LayDanhSachKhoLenCombobox(mcboMaSP.SelectedValue.ToString(), cboNSX.SelectedValue.ToString());
            }
            else
            {
                cboKho.SelectedIndex = -1;
            }
        }

        private void cboKho_SelectedValueChanged(object sender, EventArgs e)
        {
            //5.1 LẤY LO, DATE CỦA SẢN PHẨM
            if (cboKho.SelectedValue != null && cboKho.SelectedIndex != -1)
            {
                LayLot(mcboMaSP.SelectedValue.ToString(), cboNSX.SelectedValue.ToString(), cboKho.SelectedValue.ToString());
            }
            else
            {
                cboSoLo.SelectedIndex = -1;
            }
        }

        private void cboSoLo_SelectedValueChanged(object sender, EventArgs e)
        {
            //6.1 LẤY DATE, SỐ LƯỢNG TỒN, SỐ LƯỢNG CÓ THỂ XUẤT
            try
            {
                if (cboSoLo.SelectedValue != null && cboSoLo.SelectedIndex != -1)
                {
                    LayDateSLTonSLCoTheBan(mcboMaSP.SelectedValue.ToString(), cboNSX.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cboSoLo.SelectedValue.ToString(), cboDVT.SelectedValue.ToString());
                }
                else
                {
                    dtHanDung.Value = DateTime.Now;
                    txtSLTon.Text = "0.00";
                    txtSLCoTheXuat.Text = "0.00";
                }
            }
            catch { }
        }

        private void cboDVT_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSoLo.SelectedValue != null && cboSoLo.SelectedIndex != -1)
                {
                    LayDateSLTonSLCoTheBan(mcboMaSP.SelectedValue.ToString(), cboNSX.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cboSoLo.SelectedValue.ToString(), cboDVT.SelectedValue.ToString());
                }
                else
                {
                    dtHanDung.Value = DateTime.Now;
                    txtSLTon.Text = "0.00";
                    txtSLCoTheXuat.Text = "0.00";
                }
            }
            catch { }
        }

        private void mcboTenSP_Leave(object sender, EventArgs e)
        {
            //Chuyển con trỏ chuột ra đầu dòng mcboTenSP
            RadTextBoxItem rtbi = mcboTenSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
            rtbi.SelectionLength = 0;
        }

        private void mcboTenSP_Enter(object sender, EventArgs e)
        {
            //Bôi đen tất cả text khi vào mcbotensp
            RadTextBoxItem rtbi = mcboTenSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
            rtbi.SelectAll();
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSL_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSL.Text.Length == 0 || decimal.Parse(txtSL.Text) <= 0)
                {
                    statusTB.Text = "Số lượng phải lớn hơn 0 (>0)";
                    if (MessageBox.Show("Bạn chưa nhập số lượng hoặc số lượng bé hơn 0!", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        txtSL.Focus();
                    }
                    return;
                }
                txtSL.Text = String.Format("{0,0:N2}", decimal.Parse(txtSL.Text));
            }
            catch { }
        }

        private void txtSL_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSL.Text = String.Format("{0,0:N0}", decimal.Parse(txtSL.Text));
                txtSL.SelectAll();
            }
            catch { }
        }



        private void rbtnBinhThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBinhThuong.Checked == true)
            {
                LOAIHANGTRA = 1;
                rbtnBatThuong.Checked = false;
            }
        }

        private void rbtnBatThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBatThuong.Checked == true)
            {
                LOAIHANGTRA = 2;
                rbtnBinhThuong.Checked = false;
            }
        }
        #endregion Hàm lấy dữ liệu lên form

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_TraHangVeCty.Name) == false)
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

            //1. Thêm chuyển hàng master
            ////1.1.Kiểm tra các tham số đầu vào master
            #region Kiểm tra các tham số đầu vào chuyenhangnt (master)
            if (cboCompany.SelectedValue == null || cboCompany.SelectedIndex == -1)
            {
                statusTB.Text = "Bạn chưa chọn nhà thuốc!";
                //if (MessageBox.Show("Bạn chưa chọn nhà thuốc, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                //{
                    cboCompany.Focus();
                //}
                return;
            }
            else
            {
                statusTB.Text = "";
            }
            #endregion Kiểm tra các tham số đầu vào chuyenhangnt (master)
            ////1.2.Thêm chuyển hàng master
            #region Thêm chuyển hàng master
            CSQLNT_TraHangVeCty ch = new CSQLNT_TraHangVeCty();
            if (THID != null && THID.Length > 0) //Sửa chuyển hàng master
            {
                // DungLV thêm mới field isTraDacBiet 
                DataTable dtb = ch.Sua(THID, cboCompany.SelectedValue.ToString(), txtGhiChu.Text, DateTime.Now, CStaticBien.SmaTaiKhoan, ckDuyet.Checked, DateTime.Now, CStaticBien.SmaTaiKhoan, LOAIHANGTRA, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet(), cbIsTraDacBiet.Checked && chht.KiemTraTrangThaiDonTraLoi());
                // DungLV thêm mới field isTraDacBiet 
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    cboCompany.SelectedValue = new Guid(dtb.Rows[0]["Destination"].ToString());
                    dtNgayChungTu.Value = DateTime.Parse(dtb.Rows[0]["NgayTao"].ToString());
                    txtGhiChu.Text = dtb.Rows[0]["GhiChu"].ToString();
                    ckDuyet.Checked = bool.Parse(dtb.Rows[0]["DaXetDuyet"].ToString());
                }
            }
            else //Thêm chuyển hàng master
            {
                // DungLV thêm mới field isTraDacBiet 
                string[] THID_SOPTH = ch.Them(cboCompany.SelectedValue.ToString(), txtGhiChu.Text, dtNgayChungTu.Value, CStaticBien.SmaTaiKhoan, LOAIHANGTRA, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet(), cbIsTraDacBiet.Checked && chht.KiemTraTrangThaiDonTraLoi());
                // DungLV thêm mới field isTraDacBiet 
                THID = THID_SOPTH[0];
                SOPTH = THID_SOPTH[1];
                txtSPTra.Text = SOPTH;
                if (THID.Length > 0)
                {
                    statusTB.Text = "Thêm thành công!";
                    if (fmain.DSNT_TraHangVeCtyXacNhanIsOpen == true)
                    {
                        fmain.fNT_TraHangVeCtyXacNhan.LayDSLenLuoiXacNhan();
                    }
                    if (fmain.DSNT_TraHangVeCtyIsOpen == true)
                    {
                        fmain.fNT_TraHangVeCty.LoadLenLuoi();
                    }
                }
                else
                    statusTB.Text = "Thêm thất bại!";
            }
            #endregion Thêm chuyển hàng master

            //2. Thêm chuyển hàng detail
            ////2.1.Kiểm tra các tham số đầu vào Detail
            #region Kiểm tra các tham số đầu vào chuyenhangctnt (detail)
            if (mcboMaSP.SelectedValue == null || mcboMaSP.SelectedIndex == -1)
            {
                statusTB.Text = "Bạn chưa chọn sản phẩm!";
                //if (MessageBox.Show("Bạn chưa chọn sản phẩm, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    mcboMaSP.Focus();
                }
                return;
            }
            else
            {
                statusTB.Text = "";
            }

            if (cboKho.SelectedValue == null || cboKho.SelectedIndex == -1)
            {
                statusTB.Text = "Bạn chưa chọn kho!";
                //if (MessageBox.Show("Bạn chưa chọn kho, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    cboKho.Focus();
                }
                return;
            }
            else
            {
                statusTB.Text = "";
            }

            if (cboDVT.SelectedValue == null || cboDVT.SelectedIndex == -1)
            {
                statusTB.Text = "Bạn chưa chọn đơn vị tính!";
                //if (MessageBox.Show("Bạn chưa chọn đơn vị tính, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    cboDVT.Focus();
                }
                return;
            }
            else
            {
                statusTB.Text = "";
            }

            if (cboSoLo.SelectedValue == null || cboSoLo.SelectedIndex == -1)
            {
                statusTB.Text = "Bạn chưa chọn số lô!";
                //if (MessageBox.Show("Bạn chưa chọn số lô, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    cboSoLo.Focus();
                }
                return;
            }
            else
            {
                statusTB.Text = "";
            }

            if (txtSL.Text.Length == 0)
            {
                statusTB.Text = "Bạn chưa chọn số lượng!";
                //if (MessageBox.Show("Bạn chưa chọn số lượng, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    txtSL.Focus();
                }
                return;
            }
            else
            {
                statusTB.Text = "";
            }

            if (decimal.Parse(txtSL.Text) > decimal.Parse(txtSLCoTheXuat.Text))
            {
                statusTB.Text = "Số lượng không được lớn hơn số lượng có thể xuất!";
                //if (MessageBox.Show("Số lượng không được lớn hơn số lượng có thể xuất, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    txtSL.Focus();
                }
                return;
            }
            else
            {
                statusTB.Text = "";
            }
            #endregion Kiểm tra các tham số đầu vào chuyenhangctnt (detail)
            ////2.2.Thêm/Sửa chuyển hàng ct (Detail)
            #region Thêm/Sửa chuyển hàng chi tiết (detail)
            if (THID != null && THID.Length > 0)
            {
                if (THCTID == null || (THCTID != null && THCTID.Length == 0))
                {
                    THCTID = "00000000-0000-0000-0000-000000000000";
                }
                CSQLNT_TraHangVeCtyCT thct = new CSQLNT_TraHangVeCtyCT();
                try
                {
                    int kq = thct.NTTraHangVeCtyCT_Them(THID, mcboMaSP.SelectedValue.ToString(), cboNSX.SelectedValue.ToString(), decimal.Parse(txtSL.Text), cboDVT.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cboSoLo.SelectedValue.ToString(), dtHanDung.Value, THCTID);
                    if (kq > 0)
                    {
                        statusTB.Text = "Thêm thành công!";
                        rgvChiTiet.DataSource = thct.LayLenLuoi(THID);

                        //Giải phóng biến nhớ
                        THCTID = null;
                        mcboMaSP.SelectedIndex = -1;
                        mcboTenSP.SelectedIndex = -1;
                        txtSL.Text = "";
                    }
                    else
                    {
                        statusTB.Text = "Thêm thất bại!";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            #endregion Thêm/Sửa chuyển hàng chi tiết (detail)

            KiemTraDanhSachChiTietKho(THID);
        }

        private void rgvChiTiet_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                THCTID = rgvChiTiet.CurrentRow.Cells["colTHCTID"].Value.ToString();
                THID = rgvChiTiet.CurrentRow.Cells["colTHID"].Value.ToString();
                mcboMaSP.SelectedValue = new Guid(rgvChiTiet.CurrentRow.Cells["colSPID"].Value.ToString());
                cboNSX.SelectedValue = new Guid(rgvChiTiet.CurrentRow.Cells["colNSXID"].Value.ToString());
                cboKho.SelectedValue = new Guid(rgvChiTiet.CurrentRow.Cells["colkhoid"].Value.ToString());
                cboDVT.SelectedValue = new Guid(rgvChiTiet.CurrentRow.Cells["colDVTID"].Value.ToString());
                cboSoLo.SelectedValue = rgvChiTiet.CurrentRow.Cells["colLot"].Value.ToString();
                dtHanDung.Value = DateTime.Parse(rgvChiTiet.CurrentRow.Cells["colDate"].Value.ToString());
                txtSL.Text = String.Format("{0,0:N2}", decimal.Parse(rgvChiTiet.CurrentRow.Cells["colSLTra"].Value.ToString()));
                txtSL.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void rgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                    if (!chht.KiemTraTrangThaiXemKhoDacBiet() && cbkHangDacBiet.Checked)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }

                    CSQLNT_TraHangVeCtyCT chct = new CSQLNT_TraHangVeCtyCT();
                    if (chct.NTTraHangVeCtyCT_Xoa(rgvChiTiet.CurrentRow.Cells["colTHCTID"].Value.ToString()) > 0)
                        rgvChiTiet.DataSource = chct.LayLenLuoi(THID);
                    else
                        statusTB.Text = "Xóa thất bại!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }

                KiemTraDanhSachChiTietKho(THID);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            THID = null;
            THCTID = null;
            SOPTH = null;
            cboCompany.SelectedIndex = -1;
            txtGhiChu.Text = "";
            txtSPTra.Text = "";
            mcboMaSP.SelectedIndex = -1;
            mcboTenSP.SelectedIndex = -1;
            txtSL.Text = "";
            cboNSX.SelectedIndex = -1;
            rgvChiTiet.DataSource = null;
            ckDuyet.Checked = false;
            dtNgayChungTu.Value = DateTime.Now;
            rbtnBatThuong.Enabled = false;
            rbtnBinhThuong.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_TraHangVeCty.Name) == false)
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

            //1. Thêm chuyển hàng master
            ////1.1.Kiểm tra các tham số đầu vào master
            #region Kiểm tra các tham số đầu vào chuyenhangnt (master)
            if (cboCompany.SelectedValue == null || cboCompany.SelectedIndex == -1)
            {
                statusTB.Text = "Bạn chưa chọn nhà thuốc!";
                if (MessageBox.Show("Bạn chưa chọn nhà thuốc, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    cboCompany.Focus();
                }
                return;
            }
            else
            {
                statusTB.Text = "";
            }
            #endregion Kiểm tra các tham số đầu vào chuyenhangnt (master)
            ////1.2.Thêm chuyển hàng master
            #region Thêm chuyển hàng master
            CSQLNT_TraHangVeCty ch = new CSQLNT_TraHangVeCty();
            if (THID != null && THID.Length > 0) //Sửa chuyển hàng master
            {
                // DungLV thêm mới field isTraDacBiet 
                DataTable dtb = ch.Sua(THID, cboCompany.SelectedValue.ToString(), txtGhiChu.Text, DateTime.Now, CStaticBien.SmaTaiKhoan, ckDuyet.Checked, DateTime.Now, CStaticBien.SmaTaiKhoan, LOAIHANGTRA, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet(), cbIsTraDacBiet.Checked && chht.KiemTraTrangThaiDonTraLoi());
                // DungLV thêm mới field isTraDacBiet 
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    cboCompany.SelectedValue = new Guid(dtb.Rows[0]["Destination"].ToString());
                    dtNgayChungTu.Value = DateTime.Parse(dtb.Rows[0]["NgayTao"].ToString());
                    txtGhiChu.Text = dtb.Rows[0]["GhiChu"].ToString();
                    ckDuyet.Checked = bool.Parse(dtb.Rows[0]["DaXetDuyet"].ToString());
                }
            }
            else //Thêm chuyển hàng master
            {
                // DungLV thêm mới field isTraDacBiet 
                string[] THID_SOPTH = ch.Them(cboCompany.SelectedValue.ToString(), txtGhiChu.Text, dtNgayChungTu.Value, CStaticBien.SmaTaiKhoan, LOAIHANGTRA, cbkHangDacBiet.Checked && chht.KiemTraTrangThaiXemKhoDacBiet(), cbIsTraDacBiet.Checked && chht.KiemTraTrangThaiDonTraLoi());
                // DungLV thêm mới field isTraDacBiet 
                THID = THID_SOPTH[0];
                SOPTH = THID_SOPTH[1];
                txtSPTra.Text = SOPTH;
                if (THID.Length > 0)
                {
                    
                    statusTB.Text = "Thêm thành công!";
                    if (fmain.DSNT_TraHangVeCtyXacNhanIsOpen == true)
                    {
                        fmain.fNT_TraHangVeCtyXacNhan.LayDSLenLuoiXacNhan();
                    }
                    if (fmain.DSNT_TraHangVeCtyIsOpen == true)
                    {
                        fmain.fNT_TraHangVeCty.LoadLenLuoi();
                    }
                }
                else
                    statusTB.Text = "Thêm thất bại!";
            }
            #endregion Thêm chuyển hàng master
        }

        private void ckDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyet.Checked == true)
            {
                cboCompany.Enabled = false;
                txtGhiChu.Enabled = false;
                mcboMaSP.Enabled = false;
                mcboTenSP.Enabled = false;
                txtSL.Enabled = false;
                cboDVT.Enabled = false;
                cboKho.Enabled = false;
                cboSoLo.Enabled = false;
                btnAdd.Enabled = false;
                rbtnBinhThuong.Enabled = false;
                rbtnBatThuong.Enabled = false;
            }
            else
            {
                cboCompany.Enabled = true;
                txtGhiChu.Enabled = true;
                mcboMaSP.Enabled = true;
                mcboTenSP.Enabled = true;
                txtSL.Enabled = true;
                cboDVT.Enabled = true;
                cboKho.Enabled = true;
                cboSoLo.Enabled = true;
                btnAdd.Enabled = true;
                rbtnBinhThuong.Enabled = true;
                rbtnBatThuong.Enabled = true;
            }
        }


        #region XỬ LÝ KHI NHẤN PHÍM ENTER
        private void cboCopany_KeyPress(object sender, KeyPressEventArgs e)
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
                mcboMaSP.Focus();
            }
        }

        private void mcboMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboKho.Focus();
            }
        }

        private void mcboTenSP_KeyPress(object sender, KeyPressEventArgs e)
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
                cboSoLo.Focus();
            }
        }

        private void cboSoLo_KeyPress(object sender, KeyPressEventArgs e)
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
                txtSL.Focus();
            }
        }
        #endregion XỬ LÝ KHI NHẤN PHÍM ENTER

        private void rbtnIn_Click(object sender, EventArgs e)
        {
            InNT_TraHangVeCty(THID);
        }

        public void InNT_TraHangVeCty(string thid_)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(fmain.fNT_TraHangVeCty.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNT_TraHangVeCtyCT thvectyct_ = new CSQLNT_TraHangVeCtyCT();
            if (thid_ != null && thid_.Length > 0)
            {
                DataTable THVECTY_CT_ = thvectyct_.IN_NTTH_NTTHCT(thid_);
                int loaihangtra = int.Parse(THVECTY_CT_.Rows[0]["LoaiHangTra"].ToString());
                Fr_TraHangVeCty check = new Fr_TraHangVeCty(THVECTY_CT_, loaihangtra);
                check.Show();
            }
        }

        private void cbkHangDacBiet_CheckedChanged(object sender, EventArgs e)
        {
            LayDanhSachSanPhamLenMultiColumnCombobox();
        }
    }
}
