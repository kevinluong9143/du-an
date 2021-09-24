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
    public partial class frmBoPhanEdit : Form
    {
        //cac bien lay du lieu tu form
        //string TenBPtuForm;
        //string GhiChutuForm;
        //int MaBPChatuForm = -1;
        //bool IsKhongDung = false;
        CSQLBoPhan LopBoPhanMoi;
        CSQLQuyenTruyCap LopCSQLQuyenTruyCap;
        string MaBPfrmTable="";
        string MaBPChafromForm = "";

        private frmMain _fMain;
        public frmBoPhanEdit(frmMain fMain)
        {
            InitializeComponent();
            _fMain = fMain;
        }

        private void btnBPDong_Click(object sender, EventArgs e)
        {
            _fMain.frmBoPhanEditisOpen_ = false;
            _fMain.IsSuaBoPhan_ = false;
            this.Close();
        }

        private bool DuLieuIsNull()
        {
            if (txtTenBP.Text.Trim() == "")
            {
                return true;
            }
            return false;
        }

        private void LayDuLieuTuForm()
        {
            CXuLyChuoi xlc = new CXuLyChuoi();
            LopBoPhanMoi = new CSQLBoPhan();
            LopBoPhanMoi.sTenBP = xlc.TrimTen(txtTenBP.Text);
            LopBoPhanMoi.sGhiChu = xlc.TrimDoanVan(txtGhiChu.Text);
            LopBoPhanMoi.bIsKhongDung = ckKhongDung.Checked;
            if (_fMain.IsSuaBoPhan_ == true)
            {
                LopBoPhanMoi.sMaBP = _fMain.MaBPCanSua_;
            }
            

            if (cboBoPhan.SelectedIndex >= 0)
            {
                MaBPChafromForm = cboBoPhan.SelectedValue.ToString();
            }
            else if ((cboBoPhan.SelectedIndex < 0)||(cboBoPhan.Text==""))
                MaBPChafromForm = "";
        }

        private bool KiemTraQuyenChiTiet(string frmName)
        {

            LopCSQLQuyenTruyCap = new CSQLQuyenTruyCap();
            DataTable BangQuyenChiTiet = new DataTable();
            BangQuyenChiTiet = LopCSQLQuyenTruyCap.QuyenChiTiet(CStaticBien.sNhomTaiKhoan, frmName);
            for (int i = 0; i < BangQuyenChiTiet.Rows.Count; i++)
            {
                return bool.Parse(BangQuyenChiTiet.Rows[0]["Them_Sua"].ToString());
            }

            return false;
        }

        private void btnBPLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_fMain.fBoPhan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            //if (KiemTraQuyenChiTiet(_fMain.fBoPhan.Name.ToString()) == false)
            //{
            //    MessageBox.Show("Bạn Chưa Có Quyền Truy Cập Chức Năng Này !");
            //    return;
            //}
            
            if (DuLieuIsNull() == true)
            {
                statusTB.Text = "Chưa có tên Bộ Phận !";
                txtTenBP.Focus();
                return;
            }

            LayDuLieuTuForm();

            string MaBPMoiTao="";
            if (_fMain.IsSuaBoPhan_ == false)
            {
                MaBPMoiTao = LopBoPhanMoi.LuuBoPhan(LopBoPhanMoi, MaBPChafromForm);
                if (_fMain.DSBoPhanIsOpen == true)
                {
                    _fMain.MaBPCanSua_ = MaBPMoiTao;

                    _fMain.IsSuaBoPhan_ = true;
                    // Refresh lai du lieu tren combobox
                    cboBoPhan.DataSource = LopBoPhanMoi.LoadDSBoPhanLenCombobox();
                    cboBoPhan.DisplayMember = "TenBP";
                    cboBoPhan.ValueMember = "MaBP";
                    if (MaBPMoiTao == "")
                    {
                        statusTB.Text = "Lưu KHÔNG thành công !";
                    }
                    else
                    {
                        MaBPfrmTable = MaBPMoiTao;
                        statusTB.Text = "Đã lưu thành công !";
                        txtTenBP.Focus();
                    }
                }
                else
                {
                    if (MaBPMoiTao == "")
                    {
                        statusTB.Text = "Lưu KHÔNG thành công !";
                    }
                    else
                    {
                        MaBPfrmTable = MaBPMoiTao;
                        statusTB.Text = "Đã lưu thành công !";
                        txtTenBP.Focus();
                    }
                }
            }
            else
            {
                //goi ham để update
                string KQSua = LopBoPhanMoi.SuaBoPhan(LopBoPhanMoi, MaBPChafromForm);
                if (MaBPChafromForm == "")
                {
                    cboBoPhan.SelectedIndex = -1;
                }
                else
                {
                    cboBoPhan.SelectedValue = MaBPChafromForm;
                }
                    

                if (KQSua == "")
                {
                    statusTB.Text = "Đã lưu thành công !";
                    txtTenBP.Focus();
                }
                else
                {
                    statusTB.Text = "Lưu KHÔNG thành công !";
                    MessageBox.Show(KQSua);
                }
            }

            txtTenBP.Focus();
            

            LopBoPhanMoi = new CSQLBoPhan();
            _fMain.fBoPhan.rgvBoBan.DataSource = LopBoPhanMoi.LoadDSBoPhanLenLuoi(_fMain.IsXemTatCa_);
            
        }

        private void btnBPThemMoi_Click(object sender, EventArgs e)
        {
            cboBoPhan.DataSource = LopBoPhanMoi.LoadDSBoPhanLenCombobox();
            cboBoPhan.DisplayMember = "TenBP";
            cboBoPhan.ValueMember = "MaBP";
            cboBoPhan.SelectedIndex = -1;

            _fMain.IsSuaBoPhan_ = false;
            txtTenBP.Clear();
            txtGhiChu.Clear();
            cboBoPhan.SelectedIndex = -1;
            ckKhongDung.Checked = false;
            txtTenBP.Focus();
            
        }

        private void frmBoPhanEdit_Load(object sender, EventArgs e)
        {
            _fMain.frmBoPhanEditisOpen_ = true;
            LopBoPhanMoi = new CSQLBoPhan();


            if (_fMain.IsSuaBoPhan_ == true)
            {
                cboBoPhan.DataSource = LopBoPhanMoi.LoadDSBoPhanLenCombobox_Sua(_fMain.BangBoPhanCanSua_.Rows[0]["MaBPCon"].ToString());
                cboBoPhan.DisplayMember = "TenBP";
                cboBoPhan.ValueMember = "MaBP";

                txtTenBP.Text = _fMain.BangBoPhanCanSua_.Rows[0]["TenBP"].ToString();
                txtGhiChu.Text = _fMain.BangBoPhanCanSua_.Rows[0]["GhiChu"].ToString();
                ckKhongDung.Checked = bool.Parse(_fMain.BangBoPhanCanSua_.Rows[0]["KhongSuDung"].ToString());
                //_fMain.MaBPCanSua_ = _fMain.BangBoPhanCanSua_.Rows[0]["MaBPCha"].ToString();
                //MessageBox.Show(_fMain.BangBoPhanCanSua_.Rows[0]["MaBPCha"].ToString());
                cboBoPhan.SelectedValue = _fMain.BangBoPhanCanSua_.Rows[0]["MaBPCha"].ToString();
            }
            else
            {
                cboBoPhan.DataSource = LopBoPhanMoi.LoadDSBoPhanLenCombobox();
                cboBoPhan.DisplayMember = "TenBP";
                cboBoPhan.ValueMember = "MaBP";
                cboBoPhan.SelectedIndex = -1;
            }
            txtTenBP.Focus();
        }

        private void txtTenBP_TextChanged(object sender, EventArgs e)
        {
            statusTB.Text = "";
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            statusTB.Text = "";
        }

        private void cboBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusTB.Text = "";
        }

        private void ckKhongDung_CheckedChanged(object sender, EventArgs e)
        {
            statusTB.Text = "";
        }
    }
}
