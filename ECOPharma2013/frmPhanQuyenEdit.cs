using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmPhanQuyenEdit : Form
    {
        CSQLNhomNguoiDung LopNhomNguoiDung;
        CSQLMenu LopMenu;
        CSQLForm LopForm;
        CSQLQuyenTruyCap LopQuyenTruyCap;
        private frmMain _fMain;
        string _nhomid;
        string _menuid;

        public frmPhanQuyenEdit(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        private void frmPhanQuyenEdit_Load(object sender, EventArgs e)
        {

            LopNhomNguoiDung = new CSQLNhomNguoiDung();

            cboNhom.DataSource = LopNhomNguoiDung.LoadDSNhomNguoiDungLenCombobox();
            cboNhom.DisplayMember = "TenNhom";
            cboNhom.ValueMember = "NhomNDid";
            cboNhom.SelectedIndex = -1;

            LopMenu = new CSQLMenu();
            cboMenu.DataSource = LopMenu.LoadDSMenuLenCombobox();
            cboMenu.DisplayMember = "TenMenu";
            cboMenu.ValueMember = "MenuID";
            cboMenu.SelectedIndex = -1;

            if (_menuid!=null&& _nhomid!=null&&_nhomid.Length > 0 && _menuid.Length > 0)
            {
                cboNhom.SelectedValue = new Guid(_nhomid);
                cboMenu.SelectedValue = _menuid;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            _fMain.frmPhanQuyenEditisOpen_ = false;
            _fMain.IsSuaPhanQuyen_ = false;
            this.Close();
        }

        private void LoadNghiepVuChuaPhanQuyenLenList(string MaMenu,string MaNhomNguoiDung)
        {
            LopForm = new CSQLForm();
            listNghiepVu.DataSource = LopForm.LoadDSNghiepVuLenList(MaMenu,MaNhomNguoiDung);
            listNghiepVu.DisplayMember = "TenForm";
            listNghiepVu.ValueMember = "FormID";
        }

        private void LoadDSQuyenLenLuoi(string MaMenu, string MaNhomNguoiDung)
        {
            LopQuyenTruyCap = new CSQLQuyenTruyCap();
            rgvQuyen.DataSource = LopQuyenTruyCap.LoadDSQuyenLenLuoi(MaNhomNguoiDung, MaMenu);
        }

        private void cboNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMenu.SelectedIndex == -1)
            {
                return;
            }
            LopQuyenTruyCap = new CSQLQuyenTruyCap();
            LopQuyenTruyCap.XoaQuyen();
            LoadNghiepVuChuaPhanQuyenLenList(cboMenu.SelectedValue.ToString(), cboNhom.SelectedValue.ToString());
            LoadDSQuyenLenLuoi(cboMenu.SelectedValue.ToString(), cboNhom.SelectedValue.ToString());
        }

        private void cboMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhom.SelectedIndex == -1)
            {
                return;
            }
            LopQuyenTruyCap = new CSQLQuyenTruyCap();
            LopQuyenTruyCap.XoaQuyen();
            LoadNghiepVuChuaPhanQuyenLenList(cboMenu.SelectedValue.ToString(),cboNhom.SelectedValue.ToString());
            LoadDSQuyenLenLuoi(cboMenu.SelectedValue.ToString(), cboNhom.SelectedValue.ToString());

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (listNghiepVu.SelectedIndex == -1)
            {
                return;
            }

            LopQuyenTruyCap = new CSQLQuyenTruyCap();
            LopQuyenTruyCap.InsertQuyen(cboNhom.SelectedValue.ToString(), cboMenu.SelectedValue.ToString(), listNghiepVu.SelectedValue.ToString());
            LoadDSQuyenLenLuoi(cboMenu.SelectedValue.ToString(), cboNhom.SelectedValue.ToString());
            LoadNghiepVuChuaPhanQuyenLenList(cboMenu.SelectedValue.ToString(), cboNhom.SelectedValue.ToString());
        }

        private void LayDuLieuTuLuoi()
        {
            CXuLyChuoi xlc = new CXuLyChuoi();
            LopQuyenTruyCap = new CSQLQuyenTruyCap();
            LopQuyenTruyCap.sQuyenID = rgvQuyen.CurrentRow.Cells["colQuyenID"].Value.ToString();
            LopQuyenTruyCap.sNhomNDID = rgvQuyen.CurrentRow.Cells["colNhomNDID"].Value.ToString();
            LopQuyenTruyCap.bXem = bool.Parse(rgvQuyen.CurrentRow.Cells["colXem"].Value.ToString());
            LopQuyenTruyCap.bThem_Sua = bool.Parse(rgvQuyen.CurrentRow.Cells["colThem_Sua"].Value.ToString());
            LopQuyenTruyCap.bXoa = bool.Parse(rgvQuyen.CurrentRow.Cells["colXoa"].Value.ToString());
            LopQuyenTruyCap.bInn = bool.Parse(rgvQuyen.CurrentRow.Cells["colInn"].Value.ToString());
            LopQuyenTruyCap.sMenuID = rgvQuyen.CurrentRow.Cells["colMenuID"].Value.ToString();
            LopQuyenTruyCap.sFormID = rgvQuyen.CurrentRow.Cells["colFormID"].Value.ToString();
        }

        private void rbtnDong_Click(object sender, EventArgs e)
        {
            
            _fMain.frmPhanQuyenEditisOpen_ = false;
            _fMain.IsSuaPhanQuyen_ = false;
            this.Close();
        }

        private void rbtnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_fMain.fPhanQuyen.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            if (rgvQuyen.Rows.Count <= 0)
            {
                return;
            }
            rgvQuyen.CurrentRow.Cells[rgvQuyen.CurrentColumn.Index].EndEdit();
            LayDuLieuTuLuoi();
            LopQuyenTruyCap.SuaQuyen(LopQuyenTruyCap);
            LopQuyenTruyCap.XoaQuyen();
            LoadDSQuyenLenLuoi(cboMenu.SelectedValue.ToString(), cboNhom.SelectedValue.ToString());
            LoadNghiepVuChuaPhanQuyenLenList(cboMenu.SelectedValue.ToString(), cboNhom.SelectedValue.ToString());
        }

        private void rgvQuyen_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
                LayDuLieuTuLuoi();
                LopQuyenTruyCap.SuaQuyen(LopQuyenTruyCap);
        }
        public void NhanThongTinTuMaster(string nhomid, string menuid)
        {
            _nhomid = nhomid;
            _menuid = menuid;
        }
    }
}
