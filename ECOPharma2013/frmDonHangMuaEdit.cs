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
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmDonHangMuaEdit : Form
    {
        public frmDonHangMuaEdit()
        {
            InitializeComponent();
        }
        frmMain fmain;
        string PNID, SODHMUA, PNCTID = "00000000-0000-0000-0000-000000000000";
        public frmDonHangMuaEdit(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        public void NhanThongTin(string pnid, string sodhmua)
        {
            PNID = pnid;
            SODHMUA = sodhmua;
        }


        private void frmDonHangMuaEdit_Load(object sender, EventArgs e)
        {
            try
            {
                //Lấy thông tin lên controls
                #region
                try
                {
                    this.McboSanPham.DisplayMember = "TenSP";
                    this.McboSanPham.ValueMember = "SPNSXID";
                    CSQLDonHangMuaTongCT dhmtongct = new CSQLDonHangMuaTongCT();
                    McboSanPham.DataSource = dhmtongct.LaySanPhamLenMCBO();
                    this.McboSanPham.AutoFilter = true;
                    FilterDescriptor descriptorMaSP = new FilterDescriptor("MaSP", FilterOperator.IsEqualTo, null);
                    this.McboSanPham.EditorControl.FilterDescriptors.Add(descriptorMaSP);
                    FilterDescriptor descriptorTenSP = new FilterDescriptor("TenSP", FilterOperator.StartsWith, null);
                    this.McboSanPham.EditorControl.FilterDescriptors.Add(descriptorTenSP);
                    this.McboSanPham.DropDownStyle = RadDropDownStyle.DropDown;
                    this.McboSanPham.MultiColumnComboBoxElement.DropDownWidth = 730;
                    this.McboSanPham.MultiColumnComboBoxElement.DropDownHeight = 300;
                    this.McboSanPham.EditorControl.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;

                    CSQLNSX nsx = new CSQLNSX();
                    cboNSX.DisplayMember = "TenNSX";
                    cboNSX.ValueMember = "NSXID";
                    cboNSX.DataSource = nsx.LayDSNSXLenMultiColumnCombobox();

                    CSQLNPP npp = new CSQLNPP();
                    McboNCC.DisplayMember = "TenNPP";
                    McboNCC.ValueMember = "NPPID";
                    McboNCC.DataSource = npp.LoadDSNPPLenMComboBox();
                    this.McboNCC.AutoFilter = true;
                    FilterDescriptor descriptorTenNPP = new FilterDescriptor("TenNPP", FilterOperator.StartsWith, null);
                    this.McboNCC.EditorControl.FilterDescriptors.Add(descriptorTenNPP);
                    this.McboNCC.DropDownStyle = RadDropDownStyle.DropDown;

                    McboSanPham.SelectedIndex = -1;
                    cboNSX.SelectedIndex = -1;
                    McboNCC.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi phát sinh khi lấy sản phẩm!\n" + ex.Message);
                }
                #endregion


                if (PNID != null && PNID.Length > 0)
                {
                    //Lấy thông tin master
                    CSQLDonHangMua dhm = new CSQLDonHangMua();
                    DataTable dtb = dhm.LayDHMTheoPNID(PNID);
                    txtSoDHMua.Text = dtb.Rows[0]["SoDHMua"].ToString();
                    McboNCC.SelectedValue = new Guid(dtb.Rows[0]["NPPid"].ToString());
                    if (bool.Parse(dtb.Rows[0]["isYeuCauNhapKho"].ToString()) == true)
                    {
                        ckYeuCau.Checked = true;
                    }
                    else
                    {
                        ckYeuCau.Checked = false;
                    }
                    if (dtb.Rows[0]["TinhTrang"].ToString().CompareTo("3") == 0)
                    {
                        ckYeuCau.Enabled = false;
                        btnAdd.Enabled = false;
                        btnLuu.Enabled = false;
                    }
                    else
                    {
                        ckYeuCau.Enabled = true;
                        btnAdd.Enabled = true;
                        btnLuu.Enabled = true;
                    }

                    //Lấy thông tin detail
                    CSQLNhapKhoChiTiet nkct = new CSQLNhapKhoChiTiet();
                    rgvChiTietPhieuNhap.DataSource = nkct.LayNhapKhoChiTietTheoPN(PNID);
                }
            }
            catch { }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.PNID = "";
            this.SODHMUA = "";
            fmain.fDonHangMua.LoadLenLuoi();
            fmain.frmDonHangMuaEditisOpen_ = false;
            this.Close();
        }

        private void McboSanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            if (McboSanPham.SelectedIndex != -1)
            {
                cboNSX.SelectedValue = new Guid(McboSanPham.EditorControl.CurrentRow.Cells["NSXID"].Value.ToString());
                CSQLDonHangMuaTongCT dhmtongct = new CSQLDonHangMuaTongCT();
                cboDVT.DataSource = dhmtongct.LayDVTTheoSPID(McboSanPham.EditorControl.CurrentRow.Cells["SPID"].Value.ToString());
                cboDVT.DisplayMember = "TenDVT";
                cboDVT.ValueMember = "DVTID";
                if (McboSanPham.EditorControl.CurrentRow.Cells["DVNhap"].Value.ToString().Length > 0)
                    cboDVT.SelectedValue = McboSanPham.EditorControl.CurrentRow.Cells["DVNhap"].Value.ToString();
                else
                    cboDVT.SelectedValue = -1;
            }
            else
            {
                cboDVT.SelectedValue = -1;
                cboNSX.SelectedIndex = -1;
            }

        }

        private void rgvChiTietPhieuNhap_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                PNCTID = rgvChiTietPhieuNhap.CurrentRow.Cells["colPNCTID"].Value.ToString();
                CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                string spnsxid = spnsx.SanPham_NSX_LaySPNSXIDTheoSPID_NSXID(rgvChiTietPhieuNhap.CurrentRow.Cells["colSPID"].Value.ToString(), rgvChiTietPhieuNhap.CurrentRow.Cells["colMaNSX"].Value.ToString());
                McboSanPham.SelectedValue = new Guid(spnsxid);
                txtSLYeuCau.Text = String.Format("{0:N2}", decimal.Parse(rgvChiTietPhieuNhap.CurrentRow.Cells["colSLyeuCau"].Value.ToString()));
                txtGhiChu.Text = rgvChiTietPhieuNhap.CurrentRow.Cells["GhiChu"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn thông tin từ lưới!\n" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ckYeuCau.Checked == false)
            {
                if (McboSanPham.SelectedIndex == -1)
                {
                    statusTB.Text = "Bạn phải chọn sản phẩm!";
                    McboSanPham.Focus();
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }
                if (txtSLYeuCau.Text.Length == 0)
                {
                    statusTB.Text = "Bạn phải nhập vào số lượng";
                    txtSLYeuCau.Focus();
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }
                if (cboDVT.SelectedIndex == -1)
                {
                    statusTB.Text = "Bạn phải chọn đơn vị tính!";
                    cboDVT.Focus();
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }

                if (cboNSX.SelectedIndex == -1)
                {
                    statusTB.Text = "Bạn phải chọn nhà sản xuất!";
                    cboNSX.Focus();
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }

                CSQLDonHangMuaCT dhmct = new CSQLDonHangMuaCT();
                if (dhmct.CapNhat(PNCTID, PNID, McboSanPham.EditorControl.CurrentRow.Cells["SPID"].Value.ToString(), decimal.Parse(txtSLYeuCau.Text), cboDVT.SelectedValue.ToString(), txtGhiChu.Text, cboNSX.SelectedValue.ToString()) > 0)
                {
                    //Lấy thông tin detail
                    CSQLNhapKhoChiTiet nkct = new CSQLNhapKhoChiTiet();
                    rgvChiTietPhieuNhap.DataSource = nkct.LayNhapKhoChiTietTheoPN(PNID);
                    PNCTID = "00000000-0000-0000-0000-000000000000";
                    McboSanPham.SelectedIndex = -1;
                    cboDVT.SelectedIndex = -1;
                    txtGhiChu.Text = "";
                    txtSLYeuCau.Text = "";
                }
            }
        }

        //Key down rgvChiTiet
        private void MasterTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            if (ckYeuCau.Checked == false)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    CSQLDonHangMuaCT dhmct = new CSQLDonHangMuaCT();
                    if (dhmct.Xoa(rgvChiTietPhieuNhap.CurrentRow.Cells["colPNCTID"].Value.ToString()) > 0)
                    {
                        CSQLNhapKhoChiTiet nkct = new CSQLNhapKhoChiTiet();
                        rgvChiTietPhieuNhap.DataSource = nkct.LayNhapKhoChiTietTheoPN(PNID);
                        PNCTID = "00000000-0000-0000-0000-000000000000";
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (PNID.Length > 0)
            {
                if (McboNCC.SelectedIndex == -1)
                {
                    statusTB.Text = "Bạn phải chọn nhà phân phối!";
                    McboNCC.Focus();
                    return;
                }
                else
                {
                    statusTB.Text = "";
                }

                //Update master
                CSQLDonHangMua dhm = new CSQLDonHangMua();
                int kq = dhm.CapNhatYeuCauNhapKho(PNID, CStaticBien.SmaTaiKhoan, ckYeuCau.Checked);
                if (kq > 0)
                {
                    statusTB.Text = "Cập nhật yêu cầu nhập kho thành công";
                }
            }
        }

        private void txtSLYeuCau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }
    }
}
