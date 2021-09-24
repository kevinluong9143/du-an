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
    public partial class frmNT_ChuyenHangEdit : Form
    {
        frmMain fmain;
        CSQLCauHinhHeThong chht_ = new CSQLCauHinhHeThong();
        public frmNT_ChuyenHangEdit()
        {
            InitializeComponent();
        }
        public frmNT_ChuyenHangEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void btnChuyenHangDong_Click(object sender, EventArgs e)
        {
            CHID = null;
            SOPCH = null;
            fmain.frmNT_ChuyenHangEditisOpen_ = false;
            if (fmain.DSNT_ChuyenHangXacNhanIsOpen == true)
            {
                fmain.fNT_ChuyenHangXacNhan_.LayDSLenLuoiXacNhan();
            }
            if (fmain.DSNT_ChuyenHangisOpen == true)
            {
                fmain.fNT_ChuyenHang.LayDSChuyenHangLenLuoi(fmain.IsXemTatCa_);
            }
            this.Close();
        }

        //Khai báo toàn cục biến CHID (chuyển hàng id)
        string CHID;
        string SOPCH;
        string CHCTID;
        //Khai báo biến toàn cục slton, slcothechuyen
        string slton = "0.00";
        string slcothexuat = "0.00";

        /// <summary>
        /// Hàm dùng lấy chid, sopch từ form chuyển hàng để chỉnh sửa
        /// </summary>
        /// <param name="_chid"></param>
        /// <param name="_sopch"></param>
        public void NhanCHID_SoPCH(string _chid, string _sopch)
        {
            CHID = _chid;
            SOPCH = _sopch;
        }


        ///Phân vùng các hàm hỗ trợ trong form ChuyenHangEdit
        #region Các hàm hỗ trợ
        //1. Lấy danh sách nhà thuốc để chọn khi chuyển hàng lên combobox.
        void LayDanhSachNhaThuocLenCombobox()
        {
            CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
            cboNhaThuoc.DisplayMember = "TenNT";
            cboNhaThuoc.ValueMember = "NTID";
            cboNhaThuoc.DataSource = chct.LayDSNhaThuoc();
            cboNhaThuoc.SelectedIndex = -1;
        }

        //2. Lấy danh sách masp, tên thuốc, nsx vào multicolumncombobox
        void LayDanhSachSanPhamLenMultiColumnCombobox()
        {
            CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
            mcboMaSP.ValueMember = "SPID";
            mcboMaSP.DisplayMember = "MaSP";
            
            mcboTenSP.ValueMember = "SPID";
            mcboTenSP.DisplayMember = "TenSP";
            if (chkHangDacBiet.Checked == true)
            {
                mcboMaSP.DataSource = chct.LayDSThongTinSanPham(true);
                mcboTenSP.DataSource = chct.LayDSThongTinSanPham(true);
            }
            else
            {
                mcboMaSP.DataSource = chct.LayDSThongTinSanPham(false);
                mcboTenSP.DataSource = chct.LayDSThongTinSanPham(false);
            }

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
            CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
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
            CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();

            cboKho.DisplayMember = "TenKho";
            cboKho.ValueMember = "KhoID";

            try {
                if(chkHangDacBiet.Checked==true)
                    cboKho.DataSource = chct.LayDSKho(spid, nsxid, true);
                else
                    cboKho.DataSource = chct.LayDSKho(spid, nsxid, false);
                statusTB.Text = "";
            }
            catch {
                cboKho.DataSource = null;
                statusTB.Text = "Không lấy được kho của sản phẩm";
                return;
            }
        }

        //Lấy Lot theo MaSP, NSX, KhoID
        void LayLot(string spid, string nsxid, string khoid)
        {
            CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
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
            CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();

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
            CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
            try
            {
                DataTable dtb = chct.LayDateSLTonSLCoTheXuat(spid, nsxid, khoid, lot, dvtid);

                if (dtb != null && dtb.Rows.Count > 0)
                {
                    dtHanDung.Value = (DateTime)dtb.Rows[0]["date"];
                    txtSLTon.Text = slton = String.Format("{0,0:N2}", decimal.Parse(dtb.Rows[0]["slton"].ToString()));
                    txtSLCoTheXuat.Text = slcothexuat = String.Format("{0,0:N2}", decimal.Parse(dtb.Rows[0]["slcotheban"].ToString()));
                    txtDVC.Text = cboDVT.Text;
                    //txtTongSL.Text = mcboMaSP.EditorControl.CurrentRow.Cells["SLTon"].Value.ToString();

                    txtTongSL.Text = String.Format("{0,0:N2}", decimal.Parse(dtb.Rows[0]["TSLTON"].ToString()));
                    //MessageBox.Show(slton +"/"+ slcotheban);
                }
                else
                {
                    txtSLTon.Text = slton = "";
                    txtSLCoTheXuat.Text = slcothexuat = "";
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

        ///Phân vùng xử lý các sự kiện khi lấy dữ liệu tại form chuyển hàng edit
        #region Xử lý sự kiện lấy dữ liệu lên form


        /// <summary>
        /// 1. FORM LOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNT_ChuyenHangEdit_Load(object sender, EventArgs e)
        {
            bool XemKhoDacBiet = (bool)chht_.LayDanhSachCauHinhHeThong().Rows[0]["IsXemKhoDacBiet"];
            if (XemKhoDacBiet == true)
                chkHangDacBiet.Show();
            else
                chkHangDacBiet.Hide();
            LayDanhSachNhaThuocLenCombobox();
            LayDanhSachSanPhamLenMultiColumnCombobox();

            if (CHID != null && CHID.Length > 0)
            {
                //1. Lấy thông tin chuyển hàng (master)
                CSQLNT_ChuyenHang ch = new CSQLNT_ChuyenHang();
                try
                {
                    DataTable dtb1ch = ch.LayChuyenHang(CHID);
                    if (dtb1ch != null && dtb1ch.Rows.Count > 0)
                    {
                        chkHangDacBiet.Enabled = false;
                        txtSoPC.Text = dtb1ch.Rows[0]["SoPCH"].ToString();
                        cboNhaThuoc.SelectedValue = dtb1ch.Rows[0]["Destination"].ToString();
                        dtNgayTao.Value = DateTime.Parse(dtb1ch.Rows[0]["NgayTao"].ToString());
                        txtGhiChu.Text = dtb1ch.Rows[0]["GhiChu"].ToString();
                        ckDuyetPhieu.Checked = bool.Parse(dtb1ch.Rows[0]["DaXetDuyet"].ToString());
                        chkHangDacBiet.Checked = (bool)dtb1ch.Rows[0]["IsKhoDacBiet"];
                        if (bool.Parse(dtb1ch.Rows[0]["DaXacNhan"].ToString()) == false)
                            ckDuyetPhieu.Enabled = true;
                        else
                            ckDuyetPhieu.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi khi lấy thông tin chuyển hàng (master)", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }

                //2. Lấy thông tin chuyển hàng chi tiết (detail)
                if (CHID != null && CHID.Length > 0)
                {
                    CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
                    rgvChuyenHangCT.DataSource = chct.LayLenLuoi(CHID);
                }
                else
                    chkHangDacBiet.Enabled = true;

                //3. Enable các control chức năng
                if (ckDuyetPhieu.Checked == true)
                {
                    cboNhaThuoc.Enabled = false;
                    txtGhiChu.Enabled = false;
                    mcboMaSP.Enabled = false;
                    mcboTenSP.Enabled = false;
                    txtSL.Enabled = false;
                    cboDVT.Enabled = false;
                    cboKho.Enabled = false;
                    cboSoLo.Enabled = false;
                    btnAdd.Enabled = false;
                }
                else
                {
                    cboNhaThuoc.Enabled = true;
                    txtGhiChu.Enabled = true;
                    mcboMaSP.Enabled = true;
                    mcboTenSP.Enabled = true;
                    txtSL.Enabled = true;
                    cboDVT.Enabled = true;
                    cboKho.Enabled = true;
                    cboSoLo.Enabled = true;
                    btnAdd.Enabled = true;
                }
            }
            //Focus vào cbonhathuoc
            cboNhaThuoc.Focus();
        }
 
        /// <summary>
        /// 2. XỬ LÝ KHI THAY ĐỔI VALUE TRONG MCBOMASP: MASP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                txtSLTon.Text = slton = "";
                txtSLCoTheXuat.Text = slcothexuat = "";
                txtDVC.Text = "";
                txtTongSL.Text = "";
            }
        }

        /// <summary>
        /// 3. XỬ LÝ KHI THAY ĐỔI VALUE TRONG MCBOTENSP: TENSP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 4. XỬ LÝ KHI THAY ĐỔI VALUE TRONG CBONSX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 5. XỬ LÝ KHI THAY ĐỔI VALUE TRONG CBOKHO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 6. XỬ LÝ KHI THAY ĐỔI VALUE TRONG CBOSOLO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    slton = "0.00";
                    slcothexuat = "0.00";
                }
            }
            catch {}
        }

        /// <summary>
        /// XỬ LÝ KHI THAY ĐỔI VALUE TRONG CBODONVITINH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDVT_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                if (cboSoLo.SelectedValue != null && cboSoLo.SelectedIndex != -1)
                {
                    LayDateSLTonSLCoTheBan(mcboMaSP.SelectedValue.ToString(), cboNSX.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cboSoLo.SelectedValue.ToString(), cboDVT.SelectedValue.ToString());
                }
                else
                {
                    dtHanDung.Value = DateTime.Now;
                    slton = "0.00";
                    slcothexuat = "0.00";
                }
            }
            catch { }
        }

        /// <summary>
        /// XỬ LÝ DỜI TRỎ CHUỘT SANG ĐẦU DÒNG KHI THOÁT KHỎI MCBOTENSP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mcboTenSP_Leave(object sender, EventArgs e)
        {
            //Chuyển con trỏ chuột ra đầu dòng mcboTenSP
            RadTextBoxItem rtbi = mcboTenSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
            rtbi.SelectionLength = 0;
        }

        /// <summary>
        /// XỬ LÝ BÔI ĐEN TẤT CẢ TEXT KHI CHỌN MCBOTENSP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mcboTenSP_Enter(object sender, EventArgs e)
        {
            //Bôi đen tất cả text khi vào mcbotensp
            RadTextBoxItem rtbi = mcboTenSP.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem;
            rtbi.SelectAll();
        }

        /// <summary>
        /// XỬ LÝ KHÔNG CHO NHẬP CHỮ TRONG TXTSOLUONGXUAT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// XỬ LÝ KHI RỜI KHỎI TEXTBOX TXTSL: FORMAT KIỂU SỐ, KIỂM TRA SỐ CÓ ÂM HAY KHÔNG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSL_Leave(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// XỬ LÝ KHI VÀO TEXTBOX TXTSL: FORMAT KIỂU SỐ (VD: 1,000.00 -> 1,000)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSL_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSL.Text = String.Format("{0,0:N0}", decimal.Parse(txtSL.Text));
                txtSL.SelectAll();
            }
            catch { }
        }
        #endregion Xử lý sự kiện lấy dữ liệu lên form

        #region CÁC HÀM XỬ LÝ INSERT, UPDATE, DELETE
        #region XỬ LÝ CHUYỂN HÀNG (MASTER)
        /// <summary>
        /// XỬ LÝ LƯU ĐƠN CHUYỂN HÀNG (MASTER)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_ChuyenHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                //Kiểm tra các tham số đầu vào
                #region Kiểm tra các tham số đầu vào chuyenhangnt (master)
                if (cboNhaThuoc.SelectedValue == null || cboNhaThuoc.SelectedIndex == -1)
                {
                    statusTB.Text = "Bạn chưa chọn nhà thuốc!";
                    if (MessageBox.Show("Bạn chưa chọn nhà thuốc, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                    {
                        cboNhaThuoc.Focus();
                    }
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }
                #endregion Kiểm tra các tham số đầu vào chuyenhangnt (master)

                CSQLNT_ChuyenHang ch = new CSQLNT_ChuyenHang();
                if (CHID != null && CHID.Length > 0) //Sửa chuyển hàng master
                {
                    DataTable dtb = ch.SuaChuyenHang(CHID, cboNhaThuoc.SelectedValue.ToString(), txtGhiChu.Text, DateTime.Now, CStaticBien.SmaTaiKhoan, ckDuyetPhieu.Checked, DateTime.Now, CStaticBien.SmaTaiKhoan, chkHangDacBiet.Checked);
                    if (dtb != null && dtb.Rows.Count > 0)
                    {
                        cboNhaThuoc.SelectedValue = new Guid(dtb.Rows[0]["Destination"].ToString());
                        dtNgayTao.Value = DateTime.Parse(dtb.Rows[0]["NgayTao"].ToString());
                        txtGhiChu.Text = dtb.Rows[0]["GhiChu"].ToString();
                        ckDuyetPhieu.Checked = bool.Parse(dtb.Rows[0]["DaXetDuyet"].ToString());
                        chkHangDacBiet.Checked = bool.Parse(dtb.Rows[0]["IsKhoDacBiet"].ToString());
                        statusTB.Text = "Sửa thông tin thành công";
                    }
                    else
                    {
                        statusTB.Text = "Sửa thông tin thất bại";
                    }
                }
                else //Thêm chuyển hàng master
                {
                    string[] chid_sopch = ch.ThemChuyenHang(cboNhaThuoc.SelectedValue.ToString(), txtGhiChu.Text, dtNgayTao.Value, CStaticBien.SmaTaiKhoan, chkHangDacBiet.Checked);
                    CHID = chid_sopch[0];
                    SOPCH = chid_sopch[1];
                    txtSoPC.Text = SOPCH;
                    if (CHID.Length > 0)
                    {
                        statusTB.Text = "Thêm thành công!";
                        if (fmain.DSNT_ChuyenHangXacNhanIsOpen == true)
                        {
                            fmain.fNT_ChuyenHangXacNhan_.LayDSLenLuoiXacNhan();
                        }
                        if (fmain.DSNT_ChuyenHangisOpen == true)
                        {
                            fmain.fNT_ChuyenHang.LayDSChuyenHangLenLuoi(fmain.IsXemTatCa_);
                        }
                    }
                    else
                        statusTB.Text = "Thêm thất bại!";
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); 
            }
        }
        #endregion XỬ LÝ CHUYỂN HÀNG (MASTER)

        #region XỬ LÝ CHUYỂN HÀNG CHI TIẾT (DETAIL)
        /// <summary>
        /// XỬ LÝ LƯU ĐƠN CHUYỂN HÀNG CHI TIẾT (DETAILS)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_ChuyenHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            
            //1. Thêm chuyển hàng master
            ////1.1.Kiểm tra các tham số đầu vào master
            #region Kiểm tra các tham số đầu vào chuyenhangnt (master)
            if (cboNhaThuoc.SelectedValue == null || cboNhaThuoc.SelectedIndex == -1)
            {
                statusTB.Text = "Bạn chưa chọn nhà thuốc!";
                if (MessageBox.Show("Bạn chưa chọn nhà thuốc, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    cboNhaThuoc.Focus();
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
            CSQLNT_ChuyenHang ch = new CSQLNT_ChuyenHang();
            if (CHID != null && CHID.Length > 0) //Sửa chuyển hàng master
            {
                DataTable dtb = ch.SuaChuyenHang(CHID, cboNhaThuoc.SelectedValue.ToString(), txtGhiChu.Text, DateTime.Now, CStaticBien.SmaTaiKhoan, ckDuyetPhieu.Checked, DateTime.Now, CStaticBien.SmaTaiKhoan, chkHangDacBiet.Checked);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    cboNhaThuoc.SelectedValue = new Guid(dtb.Rows[0]["Destination"].ToString());
                    dtNgayTao.Value = DateTime.Parse(dtb.Rows[0]["NgayTao"].ToString());
                    txtGhiChu.Text = dtb.Rows[0]["GhiChu"].ToString();
                    ckDuyetPhieu.Checked = bool.Parse(dtb.Rows[0]["DaXetDuyet"].ToString());
                    chkHangDacBiet.Checked = bool.Parse(dtb.Rows[0]["IsKhoDacBiet"].ToString());
                }
            }
            else //Thêm chuyển hàng master
            {
                string[] chid_sopch = ch.ThemChuyenHang(cboNhaThuoc.SelectedValue.ToString(), txtGhiChu.Text, dtNgayTao.Value, CStaticBien.SmaTaiKhoan, chkHangDacBiet.Checked);
                CHID = chid_sopch[0];
                SOPCH = chid_sopch[1];
                txtSoPC.Text = SOPCH;
                if (CHID.Length > 0)
                {
                    statusTB.Text = "Thêm thành công!";
                    if (fmain.DSNT_ChuyenHangXacNhanIsOpen == true)
                    {
                        fmain.fNT_ChuyenHangXacNhan_.LayDSLenLuoiXacNhan();
                    }
                    if (fmain.DSNT_ChuyenHangisOpen == true)
                    {
                        fmain.fNT_ChuyenHang.LayDSChuyenHangLenLuoi(fmain.IsXemTatCa_);
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
                if (MessageBox.Show("Bạn chưa chọn sản phẩm, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
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
                if (MessageBox.Show("Bạn chưa chọn kho, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
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
                if (MessageBox.Show("Bạn chưa chọn đơn vị tính, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
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
                if (MessageBox.Show("Bạn chưa chọn số lô, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    cboSoLo.Focus();
                }
                return;
            }
            else
            {
                statusTB.Text = "";
            }

            if (txtSL.Text.Length ==0)
            {
                statusTB.Text = "Bạn chưa chọn số lượng!";
                if (MessageBox.Show("Bạn chưa chọn số lượng, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    txtSL.Focus();
                }
                return;
            }
            else
            {
                statusTB.Text = "";
            }

            if (decimal.Parse(txtSL.Text) > decimal.Parse(slcothexuat))
            {
                statusTB.Text = "Số lượng không được lớn hơn số lượng có thể xuất!";
                if (MessageBox.Show("Số lượng không được lớn hơn số lượng có thể xuất, nhấn OK để chọn, Cancel nếu không muốn chọn.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
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
            if (CHID != null && CHID.Length > 0)
            {
                if (CHCTID == null || (CHCTID != null && CHCTID.Length == 0))
                {
                    CHCTID = "00000000-0000-0000-0000-000000000000";
                }
                CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
                try
                {
                    int kq = chct.NTChuyenHangCT_Them(CHID, mcboMaSP.SelectedValue.ToString(), cboNSX.SelectedValue.ToString(), decimal.Parse(txtSL.Text), cboDVT.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cboSoLo.SelectedValue.ToString(), dtHanDung.Value, CHCTID);
                    if (kq > 0)
                    {
                        statusTB.Text = "Thêm thành công!";
                        rgvChuyenHangCT.DataSource = chct.LayLenLuoi(CHID);
                        chkHangDacBiet.Enabled = false;
                        //Giải phóng biến nhớ
                        CHCTID = null;
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
        }

        /// <summary>
        /// XỬ LÝ SỰ KIỆN DOUBLE CLICK TRONG RGVCHUYENHANGCT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rgvChuyenHangCT_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                CHCTID = rgvChuyenHangCT.CurrentRow.Cells["colCHCTID"].Value.ToString();
                CHID = rgvChuyenHangCT.CurrentRow.Cells["colCHID"].Value.ToString();
                mcboMaSP.SelectedValue = new Guid(rgvChuyenHangCT.CurrentRow.Cells["colSPID"].Value.ToString());
                cboNSX.SelectedValue = new Guid(rgvChuyenHangCT.CurrentRow.Cells["colNSXID"].Value.ToString());
                cboKho.SelectedValue = new Guid(rgvChuyenHangCT.CurrentRow.Cells["colkhoid"].Value.ToString());
                cboDVT.SelectedValue = new Guid(rgvChuyenHangCT.CurrentRow.Cells["colDVTID"].Value.ToString());
                cboSoLo.SelectedValue = rgvChuyenHangCT.CurrentRow.Cells["colLot"].Value.ToString();
                dtHanDung.Value = DateTime.Parse(rgvChuyenHangCT.CurrentRow.Cells["colDate"].Value.ToString());
                txtSL.Text = String.Format("{0,0:N2}", decimal.Parse(rgvChuyenHangCT.CurrentRow.Cells["colSLChuyen"].Value.ToString()));
                txtSL.Focus();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); 
            }
        }
        #endregion XỬ LÝ CHUYỂN HÀNG CHI TIẾT (DETAIL)

        private void rgvChuyenHangCT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    CSQLNT_ChuyenHangCT chct = new CSQLNT_ChuyenHangCT();
                    if (chct.NTChuyenHangCT_Xoa(rgvChuyenHangCT.CurrentRow.Cells["colCHCTID"].Value.ToString()) > 0)
                    {
                        DataTable chnt_ = chct.LayLenLuoi(CHID);
                        if (chnt_.Rows.Count == 0)
                        { chkHangDacBiet.Enabled = true; }
                        rgvChuyenHangCT.DataSource = chnt_;
                    }
                    else
                        statusTB.Text = "Xóa thất bại!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }                
            }
        }

        #endregion CÁC HÀM XỬ LÝ INSERT, UPDATE, DELETE

        #region XỬ LÝ KHI NHẤN PHÍM ENTER
        private void cboNhaThuoc_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// Hàm xử lý khi nhấn vào nút thêm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            CHID = null;
            CHCTID = null;
            SOPCH = null;
            chkHangDacBiet.Enabled = true;
            cboNhaThuoc.SelectedIndex = -1;
            txtGhiChu.Text = "" ;
            txtSoPC.Text = "";
            mcboMaSP.SelectedIndex = -1;
            mcboTenSP.SelectedIndex = -1;
            txtSL.Text = "";
            cboNSX.SelectedIndex = -1;
            rgvChuyenHangCT.DataSource = null;
            ckDuyetPhieu.Checked = false;
            dtNgayTao.Value = DateTime.Now;
        }

        private void ckDuyetPhieu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyetPhieu.Checked == true)
            {
                cboNhaThuoc.Enabled = false;
                txtGhiChu.Enabled = false;
                mcboMaSP.Enabled = false;
                mcboTenSP.Enabled = false;
                txtSL.Enabled = false;
                cboDVT.Enabled = false;
                cboKho.Enabled = false;
                cboSoLo.Enabled = false;
                btnAdd.Enabled = false;
            }
            else
            {
                cboNhaThuoc.Enabled = true;
                txtGhiChu.Enabled = true;
                mcboMaSP.Enabled = true;
                mcboTenSP.Enabled = true;
                txtSL.Enabled = true;
                cboDVT.Enabled = true;
                cboKho.Enabled = true;
                cboSoLo.Enabled = true;
                btnAdd.Enabled = true;
            }
        }
        private void rbtnIn_Click(object sender, EventArgs e)
        {
            InChuyenHang(CHID);
        }

        public void InChuyenHang(string chid_)
        {

            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_ChuyenHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNT_ChuyenHang ntch_ = new CSQLNT_ChuyenHang();
            if (chid_ != null && chid_.Length > 0)
            {
                DataTable NTChuyenHangCT_ = ntch_.IN_NTCH_NTCHCT(chid_);
                if (NTChuyenHangCT_ != null && NTChuyenHangCT_.Rows.Count > 0)
                {
                    Fr_NTChuyenHang check = new Fr_NTChuyenHang(NTChuyenHangCT_);
                    check.Show();
                }
            }
        }

        private void chkHangDacBiet_CheckedChanged(object sender, EventArgs e)
        {
            LayDanhSachSanPhamLenMultiColumnCombobox();
        }
    }
}
