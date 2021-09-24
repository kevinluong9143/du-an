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
using System.Data.SqlClient;

namespace ECOPharma2013

{
    public partial class frmHeSoQuiDoiEdit : Form
    {
        //string ToanCuc_hsqdID;
        string ToanCuc_Currentspid;

        //Khai báo các biến sử dụng tạo hệ số quy đổi
        string dvnhap, dvxuat, dvban, dvchuan;

        frmMain _frmMain;
        public frmHeSoQuiDoiEdit(frmMain fmain)
        {
            InitializeComponent();
            _frmMain = fmain;
        }

        public void LaySPIDTuFormKhac(string spid, object sender, EventArgs e)
        {
            ToanCuc_Currentspid = spid;
            CSQLSanPham sp = new CSQLSanPham();
            rgvChuaThietLap.DataSource = sp.LaySanPhamTheoSPID(spid);
            rgvChuaThietLap.CurrentRow = rgvChuaThietLap.Rows[0];
            rgvChuaThietLap_Click(sender,e);
        }

        private void frmHeSoQuiDoiEdit_Load(object sender, EventArgs e)
        {
            CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
            if (ToanCuc_Currentspid == null)
            {
                LayDLLenrgvChuaThietLap();
                btnThemVaoLuoi.Enabled = true;
                btnHSQDLuu.Enabled = true;
            }
            else
            {
                if (hsqd.KiemTraSPTonKho(ToanCuc_Currentspid) > 0)
                {
                    btnThemVaoLuoi.Enabled = false;
                    btnHSQDLuu.Enabled = false;
                }
                else
                {
                    btnThemVaoLuoi.Enabled = true;
                    btnHSQDLuu.Enabled = true;
                }
            }
           
            
            groupBoxDonViChuanTon.Enabled = false;
            LayDLDVT();
            if (_frmMain.IsSuaHeSoQuiDoi == true)
            {               
                //groupBoxSPChuaCoHSQD.Enabled = false;
                if (_frmMain.MaHeSoQuyDoiCanSua_!=null && _frmMain.MaHeSoQuyDoiCanSua_.Length > 0)
                {
                    
                    DataTable dtb = hsqd.LayDSHSQDTheoHSQDID(_frmMain.MaHeSoQuyDoiCanSua_);
                    if (dtb != null && dtb.Rows.Count > 0)
                    {
                        rgvDaThietLap.DataSource = dtb;
                        for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
                        {
                            if (rgvDaThietLap.Rows[i].Cells[0].Value.ToString().CompareTo(_frmMain.MaHeSoQuyDoiCanSua_) == 0)
                            {
                                rgvDaThietLap.CurrentRow = rgvDaThietLap.Rows[i];
                                txtDienGiai.Text = rgvDaThietLap.Rows[i].Cells["DienGiai"].Value.ToString();
                                txtGiaTri.Text = rgvDaThietLap.Rows[i].Cells["GTQDThuan"].Value.ToString();

                                if (KiemTraHeSoKetThuc())
                                {
                                    cboTuDV.SelectedValue = rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString();
                                    cboTuDV.Enabled = true;
                                    cboSangDV.SelectedValue = rgvDaThietLap.Rows[i].Cells["SangDVTID"].Value.ToString();
                                    cboSangDV.Enabled = true;
                                }
                                else
                                {
                                    cboTuDV.SelectedValue = rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString();
                                    //cboTuDV.Enabled = false;
                                    cboTuDV.Enabled = true;
                                    cboSangDV.SelectedValue = rgvDaThietLap.Rows[i].Cells["SangDVTID"].Value.ToString();
                                    //cboSangDV.Enabled = false;
                                    cboSangDV.Enabled = true;
                                }
                                //Bind data vào cbxHeSoChuan/Ton
                                ToanCuc_Currentspid = rgvDaThietLap.Rows[i].Cells["SPID"].Value.ToString();
                                cboDVChuan.DataSource = hsqd.LayHSQDTheoSPID(rgvDaThietLap.Rows[i].Cells["SPID"].Value.ToString());
                                cboDVChuan.DisplayMember = "TenTuDVT";
                                cboDVChuan.ValueMember = "TuDVTID";
                                CSQLSanPham sp = new CSQLSanPham();
                                //Hiện cboDVChuan
                                if (sp.KiemTraMaSanPhamTonKho(ToanCuc_Currentspid) == false)
                                {
                                    cboDVChuan.Enabled = true;
                                }
                                else
                                    cboDVChuan.Enabled = false;

                                    //string dvt = sp.LayHeSoQuiDoiChuanTheoMaSP(rgvDaThietLap.Rows[i].Cells["SPID"].Value.ToString());
                                    string dvt = sp.LayHeSoQuiDoiChuanTheoMaSP(ToanCuc_Currentspid);
                                    if (dvt.Length > 0)
                                        cboDVChuan.SelectedValue = dvt;
                                    else
                                    {
                                        cboDVChuan.SelectedIndex = -1;
                                    }
                            }
                        }
                    }
                }
            }
            else
            {
                groupBoxSPChuaCoHSQD.Enabled = true;
            }


        }

        private void btnHSQDDong_Click(object sender, EventArgs e)
        {
            _frmMain.BangHeSoQuyDoiCanSua_ = null;
            _frmMain.MaHeSoQuyDoiCanSua_ = "";
            _frmMain.frmHeSoQuiDoiEditisOpen_ = false;
            _frmMain.IsSuaHeSoQuiDoi = false;
            this.Close();
        }


        //Các hàm lấy dữ liệu lên control của form
        #region
        void LayDLLenrgvChuaThietLap()
        {
            try
            {
                CSQLSanPham qlsp = new CSQLSanPham();
                DataTable dtb = qlsp.LaySanPhamChuaThietLapHSQD();
                if (dtb.Rows.Count > 0)
                {
                    rgvChuaThietLap.DataSource = qlsp.LaySanPhamChuaThietLapHSQD();
                    rgvChuaThietLap.CurrentRow = null;
                }
            }
            catch (Exception Exception){ MessageBox.Show(Exception.Message);}
        }

        void LayDLDVT()
        {
                CSQLDonViTinh dvt = new CSQLDonViTinh();
                cboTuDV.DataSource =  dvt.LayDonViTinhLenDrdl();
                cboTuDV.DisplayMember = "TenDVT";
                cboTuDV.ValueMember = "DVTID";
                cboSangDV.DataSource = dvt.LayDonViTinhLenDrdl();
                cboSangDV.DisplayMember = "TenDVT";
                cboSangDV.ValueMember = "DVTID";
                try
                {
                    cboTuDV.SelectedIndex = -1;
                }
                catch { statusTB.Text = ""; }
                try
                {
                    cboSangDV.SelectedIndex = -1;
                }
                catch { statusTB.Text = ""; }
        }
        #endregion



        private void rgvChuaThietLap_DoubleClick(object sender, EventArgs e)
        {

        }

        private void cboTuDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgvDaThietLap.Rows.Count > 0 && cboTuDV.Enabled == true)
            {
                TaoHSQD_B3_KiemTraTonTai_TuDVTid_TrongDS_TuDVTid();
                if (cboTuDV.SelectedValue.ToString().CompareTo(dvchuan) == 0)
                {
                    cboSangDV.Enabled = false;
                    cboSangDV.SelectedValue = cboTuDV.SelectedValue;
                    //txtGiaTri.Enabled = false;
                    txtGiaTri.Text = "1";
                }
                else
                {
                    txtGiaTri.Enabled = true;
                    cboSangDV.Enabled = true;
                }
            }
        }
        private void cboSangDV_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rgvDaThietLap.Rows.Count > 0 && cboSangDV.Enabled == true)
            {
                TaoHSQD_B4_KiemTraTonTai_SangDVTid_TrongDS_TuDVTid();
            }
        }

        private void btnThemVaoLuoi_Click(object sender, EventArgs e)
        {
            try
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                _frmMain.fHeSoQuiDoi = new frmHeSoQuiDoi(_frmMain);
                if (qtc.KiemTraQuyenThem_Sua(_frmMain.fHeSoQuiDoi.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                try
                {
                    if (cboTuDV.SelectedValue == null && cboTuDV.Enabled == true)
                    {
                        statusTB.Text = "Bạn chưa chọn Từ DVT!";
                        cboTuDV.Focus();
                        return;
                    }
                    if (cboSangDV.SelectedValue == null && cboSangDV.Enabled == true)
                    {
                        statusTB.Text = "Bạn chưa chọn Sang DVT!";
                        cboSangDV.Focus();
                        return;
                    }
                    if (txtGiaTri.Text.Length == 0)
                    {
                        statusTB.Text = "Bạn chưa nhập giá trị qui đổi!";
                        txtGiaTri.Focus();
                        return;
                    }

                    //Them hsqd
                    if (_frmMain.MaHeSoQuyDoiCanSua_.Length == 0)
                    {
                        TaoHSQD(ToanCuc_Currentspid);
                    }
                    //Sửa Hsqd
                    else
                    {
                        SuaHSQD();
                    }
                }
                catch (Exception ex)
                {
                    statusTB.Text = ex.Message;
                }
            }
            catch { }
        }

        //private void SuaHSQDChoSP()
        //{
        //    CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
        //    hsqd.Hsqdid = rgvDaThietLap.CurrentRow.Cells[0].Value.ToString();
        //    hsqd.Spid = rgvDaThietLap.CurrentRow.Cells[1].Value.ToString();
        //    hsqd.Diengiai = txtDienGiai.Text;
        //    hsqd.Tudvt = cboTuDV.SelectedValue.ToString();
        //    hsqd.Sangdvt = cboSangDV.SelectedValue.ToString();
        //    hsqd.Gtqdthuan = decimal.Parse(txtGiaTri.Text);
        //    //hsqd.Gtqdnguoc = 1 / decimal.Parse(txtGiaTri.Text);
        //    hsqd.Gtqdnguoc = (decimal)((decimal)1 / (decimal)(int.Parse(txtGiaTri.Text)));
        //    hsqd.Capdo = int.Parse(rgvDaThietLap.CurrentRow.Cells[11].Value.ToString());
        //    hsqd.Lastupdate = DateTime.Now;
        //    hsqd.Ngaytao = DateTime.Now;
        //    hsqd.Userid = CStaticBien.SmaTaiKhoan;
        //    int kq = hsqd.SuaHeSoQuiDoi(hsqd);
        //    if (kq == 1)
        //    {
        //        if (_frmMain.fHeSoQuiDoi != null)
        //            _frmMain.fHeSoQuiDoi.rgvDSHSQD.DataSource = hsqd.LayLenLuoi();
        //        rgvDaThietLap.DataSource = hsqd.LayHSQDTheoSPID(ToanCuc_Currentspid);
        //        rgvDaThietLap.CurrentRow = null;
        //    }
        //    else
        //    {
        //        statusTB.Text = "Cập nhật vào lưới thất bại!";
        //    }
        //}

        //private void ThemHSQDChoSP()
        //{
        //    CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
        //    if (rgvChuaThietLap.Enabled == true)
        //    {
        //        hsqd.Spid = rgvChuaThietLap.CurrentRow.Cells["colSPID"].Value.ToString();
        //    }
        //    else
        //    {
        //        if (_frmMain.MaSPCanSua_ != null && _frmMain.MaSPCanSua_.Length > 0)
        //            hsqd.Spid = _frmMain.MaSPCanSua_;
        //        else
        //            statusTB.Text = "Không thế xác định được Sản Phẩm ID";
        //    }
        //    hsqd.Diengiai = txtDienGiai.Text;
        //    hsqd.Tudvt = cboTuDV.SelectedValue.ToString();
        //    hsqd.Sangdvt = cboSangDV.SelectedValue.ToString();
        //    hsqd.Gtqdthuan = decimal.Parse(txtGiaTri.Text);
        //    hsqd.Gtqdnguoc = (decimal)((decimal)1 / (decimal)(int.Parse(txtGiaTri.Text)));
        //    hsqd.Capdo = rgvDaThietLap.RowCount;
        //    hsqd.Lastupdate = DateTime.Now;
        //    hsqd.Ngaytao = DateTime.Now;
        //    hsqd.Userid = CStaticBien.SmaTaiKhoan;
        //    string kq = hsqd.ThemHeSoQuiDoi(hsqd);
        //    if (kq != null && kq.Length > 0)
        //    {
        //        if (_frmMain.fHeSoQuiDoi!=null)
        //            _frmMain.fHeSoQuiDoi.rgvDSHSQD.DataSource = hsqd.LayLenLuoi();
        //        rgvDaThietLap.DataSource = hsqd.LayHSQDTheoSPID(ToanCuc_Currentspid);
        //        rgvDaThietLap.CurrentRow = null;
        //        statusTB.Text = "Thêm thành công";
        //    }
        //    else
        //    {
        //        statusTB.Text = "Cập nhật vào lưới thất bại!";
        //    }
        //}

        /// <summary>
        /// Hàm kiểm tra hệ số quy đổi đã có hệ số kết thúc chưa
        /// Nếu đã có trả về false
        /// Nếu chưa có trả về true
        /// </summary>
        /// <returns>
        /// true: Chưa có hệ số kết thúc
        /// false: Đã có hệ số kết thúc
        /// </returns>
        bool KiemTraHeSoKetThuc()
        {
            bool kq = true;
            if (rgvDaThietLap != null && rgvDaThietLap.Rows.Count > 0)
            {
                //for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
                //{
                if (rgvDaThietLap.Rows[rgvDaThietLap.Rows.Count - 1].Cells["TuDVTID"].Value.ToString().CompareTo(rgvDaThietLap.Rows[rgvDaThietLap.Rows.Count - 1].Cells["SangDVTID"].Value.ToString()) == 0)
                    {
                        kq = false;
                        //break;
                    }
                    else
                        kq = true;
                //}
            }
            return kq;
        }
        bool KiemTraLuoiTonTaiTuDVT()
        {
            //Kiểm tra xem giá trị đã nhập hay chưa
            bool kq = true;
            if (rgvDaThietLap != null && rgvDaThietLap.Rows.Count > 0 && _frmMain.MaHeSoQuyDoiCanSua_.Length == 0)
            {
                for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
                {
                    if (cboTuDV.SelectedValue!=null && cboTuDV.SelectedValue.ToString().CompareTo(rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString()) == 0)
                    {
                        kq = false;
                        break;
                    }
                    else
                        kq = true;
                }
            }
            return kq;
        }

        bool KiemTraLuoiTonTaiSangDVT()
        {
            //Kiểm tra xem giá trị đã nhập hay chưa
            bool kq = true;
            if (rgvDaThietLap != null && rgvDaThietLap.Rows.Count > 0)
            {
                for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
                {
                    if (cboSangDV.SelectedValue.ToString().CompareTo(rgvDaThietLap.Rows[i].Cells["SangDVTID"].Value.ToString()) == 0)
                        kq = false;
                    else
                       kq = true;
                }
            }
            return kq;
        }

        private void btnHSQDLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fHeSoQuiDoi.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            #region khong su dung
            //if (_frmMain.MaHeSoQuyDoiCanSua_ != null && _frmMain.MaHeSoQuyDoiCanSua_.Length > 0)
            //{
            //    //Sửa hsqd
            //}
            //else
            //{
            //    //Thêm hsqd
            //    for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
            //    {
            //        CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
            //        hsqd.Spid = rgvDaThietLap.Rows[i].Cells[1].Value.ToString();
            //        hsqd.Diengiai = rgvDaThietLap.Rows[i].Cells[4].Value.ToString();
            //        hsqd.Tudvt = rgvDaThietLap.Rows[i].Cells[5].Value.ToString();
            //        hsqd.Sangdvt = rgvDaThietLap.Rows[i].Cells[7].Value.ToString();
            //        hsqd.Gtqdthuan = decimal.Parse(rgvDaThietLap.Rows[i].Cells[9].Value.ToString());
            //        hsqd.Gtqdnguoc = decimal.Parse(rgvDaThietLap.Rows[i].Cells[10].Value.ToString());
            //        hsqd.Capdo = int.Parse(rgvDaThietLap.Rows[i].Cells[11].Value.ToString());
            //        hsqd.Lastupdate = DateTime.Now;
            //        hsqd.Ngaytao = DateTime.Now;
            //        hsqd.Userid = rgvDaThietLap.Rows[i].Cells[14].Value.ToString();
            //        string kq = hsqd.ThemHeSoQuiDoi(hsqd);
            //        if (kq.Length > 0)
            //        {
            //            rgvDaThietLap.Rows[i].Cells[0].Value = kq;
            //        }
            //        else
            //        {
            //            statusTB.Text = "Thêm thất bại!";
            //        }
            //    }
            //}
            #endregion
        }


        private void rgvChuaThietLap_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgvChuaThietLap.CurrentRow == null)
                {
                    statusTB.Text = "Bạn chưa chọn sản phẩm!";
                    return;
                }
                else
                    statusTB.Text = "";
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                _frmMain.MaHeSoQuyDoiCanSua_ = "";
                if (hsqd.KiemTraSPTonKho(rgvChuaThietLap.CurrentRow.Cells["colSPID"].Value.ToString()) == 0)
                {
                    cboTuDV.Enabled = true;
                    cboSangDV.Enabled = true;
                }
                //if (ToanCuc_Currentspid.Length == 0)
                //{
                //    statusTB.Text = "Không xác định được mã sản phẩm. Liên hệ IT!";
                //}
                //else statusTB.Text = "";
                ToanCuc_Currentspid = rgvChuaThietLap.CurrentRow.Cells["colSPID"].Value.ToString();
                #region Lấy ds dvban, dvnhap, dvxuat, dvban, dvchuan của sản phẩm
                CSQLSanPham sp = new CSQLSanPham();
                DataTable dtbdonvitonghop = sp.SanPham_LayDVNhap_DVXuat_DVBan_DVChuan_TheoSPID(ToanCuc_Currentspid);
                if (dtbdonvitonghop != null && dtbdonvitonghop.Rows.Count > 0)
                {
                    dvnhap = dtbdonvitonghop.Rows[0]["DVNhap"].ToString();
                    dvxuat = dtbdonvitonghop.Rows[0]["DVXuat"].ToString();
                    dvban = dtbdonvitonghop.Rows[0]["DVBan"].ToString();
                    dvchuan = dtbdonvitonghop.Rows[0]["DVChuan"].ToString();
                    statusTB.Text = "";
                }
                else 
                {
                    statusTB.Text = "Không lấy được đơn vị bán, đơn vị nhập, đơn vị xuất, đơn vị chuẩn của sản phẩm. Liên hệ IT!";
                }
                #endregion
                DataTable dtb = hsqd.LayHSQDTheoSPID(ToanCuc_Currentspid);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    rgvDaThietLap.DataSource = dtb;
                    rgvDaThietLap.CurrentRow = null;
                    _frmMain.MaHeSoQuyDoiCanSua_ = "";
                    txtDienGiai.Text = "";
                    txtGiaTri.Text = "";
                    if (!KiemTraHeSoKetThuc())
                        try
                        {
                            cboTuDV.SelectedIndex = -1;
                        }
                        catch { }
                    else
                    {
                        cboTuDV.SelectedValue = rgvDaThietLap.Rows[dtb.Rows.Count - 1].Cells["SangDVTID"].Value.ToString();
                    }
                    try
                    {
                        cboSangDV.SelectedIndex = -1;
                    }
                    catch { }
                }
                else
                {
                    rgvDaThietLap.DataSource = null;
                    _frmMain.MaHeSoQuyDoiCanSua_ = "";
                    txtDienGiai.Text = "";
                    txtGiaTri.Text = "";
                    cboTuDV.SelectedValue = dvnhap;
                    cboSangDV.SelectedIndex = -1;
                }


                //Kiểm tra điều kiện hiện groupbox DonViChuanTon
                #region Groupbox DonViChuan/Ton
                //if (!KiemTraHeSoKetThuc())
                //{
                //    //Hiện groupbox hệ số chuẩn/tồn
                //    groupBoxDonViChuanTon.Enabled = false;

                //    //Bind data vào cbxHeSoChuan/Ton
                //    cboDVChuan.DataSource = hsqd.LayHSQDTheoSPID(ToanCuc_Currentspid);
                //    cboDVChuan.DisplayMember = "TenTuDVT";
                //    cboDVChuan.ValueMember = "TuDVTID";
                //    cboDVChuan.SelectedIndex = -1;
                //}
                //else
                //{
                //    //Ẩn groupbox hệ số chuẩn/tồn
                //    groupBoxDonViChuanTon.Enabled = false;
                //    cboDVChuan.DataSource = null;
                //}
                CSQLDonViTinh dvt = new CSQLDonViTinh();
                cboDVChuan.DataSource = dvt.LayDonViTinhLenDrdl();
                cboDVChuan.DisplayMember = "TenDVT";
                cboDVChuan.ValueMember = "DVTID";
                cboDVChuan.SelectedValue = dvchuan;


                #endregion
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }

        private void rgvDaThietLap_Click(object sender, EventArgs e)
        {
            try 
            {
                if (rgvDaThietLap.CurrentRow.Index == rgvDaThietLap.Rows.Count - 1)
                {
                    cboTuDV.Enabled = true;
                    cboSangDV.Enabled = true;
                }
                else
                {
                    //cboTuDV.Enabled = false;
                    //cboSangDV.Enabled = false;
                    cboTuDV.Enabled = true;
                    cboSangDV.Enabled = true;
                }
                if (rgvDaThietLap.CurrentRow == null)
                {
                    statusTB.Text = "Hệ số chưa tồn tại hoặc bạn chưa chọn hệ số cụ thể!";
                    return;
                }
                else
                    statusTB.Text = "";
                _frmMain.MaHeSoQuyDoiCanSua_ = rgvDaThietLap.CurrentRow.Cells["HSQDID"].Value.ToString();
                //ToanCuc_hsqdID = rgvDaThietLap.CurrentRow.Cells["HSQDID"].Value.ToString();
                txtDienGiai.Text = rgvDaThietLap.CurrentRow.Cells["DienGiai"].Value.ToString();
                txtGiaTri.Text = String.Format("{0:N2}",decimal.Parse(rgvDaThietLap.CurrentRow.Cells["GTQDThuan"].Value.ToString()));
                cboTuDV.SelectedValue = rgvDaThietLap.CurrentRow.Cells["TuDVTID"].Value.ToString();
                cboSangDV.SelectedValue = rgvDaThietLap.CurrentRow.Cells["SangDVTID"].Value.ToString();
            }
            catch (Exception ex)
            {
                statusTB.Text = ex.Message;
            }
        }


        /// <summary>
        /// Hàm cập nhật Hệ số đơn vị chuẩn/tồn vào bảng sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fHeSoQuiDoi.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                CSQLSanPham qlsp = new CSQLSanPham();
                if (ToanCuc_Currentspid != null && ToanCuc_Currentspid.Length > 0 && cboDVChuan.SelectedValue != null)
                {
                    int kq = qlsp.CapNhatHeSoQuyDoiChuanTon(ToanCuc_Currentspid, cboDVChuan.SelectedValue.ToString(),CStaticBien.SmaTaiKhoan);
                    if (kq == 1)
                    {
                        LayDLLenrgvChuaThietLap();
                        statusTB.Text = "Cập nhật đơn vị chuẩn/Tồn thành công";
                    }
                    else
                        statusTB.Text = "Cập nhật đơn vị chuẩn/Tồn thất bại";
                }
                else
                {
                    statusTB.Text = "Dữ liệu đầu vào chưa đủ, kiểm tra lại";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rgvDaThietLap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CSQLHeSoQuyDoi xlhsqd = new CSQLHeSoQuyDoi();
                if (xlhsqd.KiemTraSPTonKho(ToanCuc_Currentspid) == 0)
                {
                    _frmMain.MaHeSoQuyDoiCanSua_ = rgvDaThietLap.CurrentRow.Cells[0].Value.ToString();
                    if (xlhsqd.CapHeSoQuiDoiLonNhat(ToanCuc_Currentspid).CompareTo(_frmMain.MaHeSoQuyDoiCanSua_) == 0)
                    {
                        if (MessageBox.Show("Bạn có thực sự muốn xóa hệ số qui đổi có mã: ['" + _frmMain.MaHeSoQuyDoiCanSua_ + "']?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            int kq = xlhsqd.Xoa(_frmMain.MaHeSoQuyDoiCanSua_);
                            if (kq == 1)
                            {
                                //ToanCuc_hsqdID = "";
                                _frmMain.MaHeSoQuyDoiCanSua_ = "";
                                rgvDaThietLap.DataSource = xlhsqd.LayHSQDTheoSPID(ToanCuc_Currentspid);
                                rgvDaThietLap.CurrentRow = null;
                                if (_frmMain.fHeSoQuiDoi != null)
                                {
                                    _frmMain.fHeSoQuiDoi.rgvDSHSQD.DataSource = xlhsqd.LayLenLuoi();
                                    _frmMain.fHeSoQuiDoi.rgvDSHSQD.CurrentRow = null;
                                }
                            }
                            else
                                statusTB.Text = "Xóa hệ số qui đổi: ['" + _frmMain.MaHeSoQuyDoiCanSua_ + "'] thất bại!";
                        }
                    }
                    else
                    {
                        statusTB.Text = "Để đảm bảo logic, không thể xóa hệ số quy đổi này.";
                    }
                }
                else
                {
                    statusTB.Text = "Sản phẩm này đã lưu trong bảng tồn kho, không thể xóa!";
                }

            }
        }

        private void rgvDaThietLap_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            //Kiểm tra điều kiện hiện groupbox DonViChuanTon
            #region Groupbox DonViChuan/Ton
            if (!KiemTraHeSoKetThuc())
            {
                //Hiện groupbox hệ số chuẩn/tồn
                groupBoxDonViChuanTon.Enabled = false;

                //Bind data vào cbxHeSoChuan/Ton
                CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
                cboDVChuan.DataSource = hsqd.LayHSQDTheoSPID(ToanCuc_Currentspid);
                cboDVChuan.DisplayMember = "TenTuDVT";
                cboDVChuan.ValueMember = "TuDVTID";
            }
            else
            {
                //Ẩn groupbox hệ số chuẩn/tồn
                groupBoxDonViChuanTon.Enabled = false;
                cboDVChuan.DataSource = null;
            }
            #endregion
        }

        private void btnHSQDThemMoi_Click(object sender, EventArgs e)
        {
            btnThemVaoLuoi.Enabled = true;
            btnHSQDLuu.Enabled = true;
            _frmMain.MaHeSoQuyDoiCanSua_ = "";
            ToanCuc_Currentspid = "";
            groupBoxDonViChuanTon.Enabled = false;
            rgvDaThietLap.DataSource = null;
            LayDLLenrgvChuaThietLap();
            txtDienGiai.Text = "";
            txtGiaTri.Text = "";
            cboSangDV.Enabled = true;
            cboSangDV.SelectedIndex = -1;
            cboTuDV.Enabled = true;
            cboTuDV.SelectedIndex = -1;
            groupBoxSPChuaCoHSQD.Enabled = true;
        }

        private void txtGiaTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Bạn không được nhập chữ!");
                e.Handled = true;
            }
        }

        //b1: Kiểm tra SP có tồn kho hay chưa, nếu chưa mới cho sửa hsqd

        private void TaoHSQD(string spid)
        {
            if (rgvDaThietLap.Rows.Count > 0)
            {
                //Kiểm tra nếu chưa tồn tại dvxuat, dvban, dvnhap, dvchuan trong ds Hệ số thì chưa cho tạo hs chốt
                #region Kiểm tra nếu chưa tồn tại dvxuat, dvban, dvnhap, dvchuan trong ds Hệ số thì chưa cho tạo hs chốt
                if (cboTuDV.SelectedValue.ToString().CompareTo(cboSangDV.SelectedValue.ToString()) == 0)
                {
                    int kqdvxuat = -1, kqdvban = -1, kqdvnhap = -1, kqdvchuan = -1;
                    for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
                    {
                        if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(dvxuat) == 0)
                        {
                            kqdvxuat = i;
                        }
                        if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(dvban) == 0)
                        {
                            kqdvban = i;
                        }
                        if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(dvnhap) == 0)
                        {
                            kqdvnhap = i;
                        }
                        if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(dvchuan) == 0)
                        {
                            kqdvchuan = i;
                        }
                    }
                    if (kqdvxuat == -1)
                    {
                        if (cboTuDV.SelectedValue.ToString().CompareTo(dvxuat) != 0)
                        {
                            statusTB.Text = "Bảng hệ số chưa có đơn vị xuất [" + dvxuat + "], không thể tạo hệ số chốt!";
                            return;
                        }
                    }
                    else statusTB.Text = "";
                    if (kqdvban == -1)
                    {
                        if (cboTuDV.SelectedValue.ToString().CompareTo(dvban) != 0)
                        {
                            statusTB.Text = "Bảng hệ số chưa có đơn vị bán[" + dvban + "], không thể tạo hệ số chốt!";
                            return;
                        }
                    }
                    else statusTB.Text = "";
                    if (kqdvnhap == -1)
                    {
                        if (cboTuDV.SelectedValue.ToString().CompareTo(dvnhap) != 0)
                        {
                            statusTB.Text = "Bảng hệ số chưa có đơn vị nhập[" + dvnhap + "], không thể tạo hệ số chốt!";
                            return;
                        }
                    }
                    else statusTB.Text = "";
                    if (kqdvchuan == -1)
                    {
                        if (cboTuDV.SelectedValue.ToString().CompareTo(dvchuan) != 0)
                        {
                            statusTB.Text = "Bảng hệ số chưa có đơn vị chuẩn[" + dvchuan + "], không thể tạo hệ số chốt!";
                            return;
                        }
                    }
                    else
                    { 
                        statusTB.Text = ""; 
                    }
                }
                #endregion

                //Kiểm tra hệ số chốt
                #region Kiểm tra hệ số chốt
                if (rgvDaThietLap.Rows[rgvDaThietLap.Rows.Count - 1].Cells["TuDVTID"].Value.ToString().CompareTo(rgvDaThietLap.Rows[rgvDaThietLap.Rows.Count - 1].Cells["SangDVTID"].Value.ToString()) == 0)
                {
                    statusTB.Text = "Hệ số chốt đã được tạo, không thể thêm hệ số qui đổi";
                    return;
                }
                else statusTB.Text = "";
                #endregion

                //Kiểm tra tuDVTid hiện tại đã có DS tuDVTid của SP hay chưa
                #region Kiểm tra tuDVTid hiện tại đã có DS tuDVTid của SP hay chưa
                for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
                {
                    if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(cboTuDV.SelectedValue.ToString()) == 0)
                    {
                        statusTB.Text = "Đơn vị tính này đã tồn tại trong danh sách HSQĐ, nhập đơn vị khác!";
                        cboTuDV.Focus();
                        return;
                    }
                    else
                    {
                        statusTB.Text = "";
                        cboSangDV.Focus();
                    }
                }
                #endregion

                //Kiểm tra sangDVTid hiện tại đã có trong ds TuDVT cấp độ trước chưa
                #region Kiểm tra sangDVTid hiện tại đã có trong ds TuDVT cấp độ trước chưa
                for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
                {
                    if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(cboSangDV.SelectedValue.ToString()) == 0)
                    {
                        statusTB.Text = "Đơn vị tính này đã tồn tại trong danh sách HSQĐ, nhập đơn vị khác!";
                        cboSangDV.Focus();
                        return;
                    }
                    else
                    {
                        statusTB.Text = "";
                        txtGiaTri.Focus();
                    }
                }
                #endregion
            }
            else
            {
                if (cboTuDV.SelectedValue.ToString().CompareTo(cboSangDV.ToString()) == 0)
                {
                    if (cboTuDV.SelectedValue.ToString().CompareTo(dvxuat) != 0)
                    {
                        statusTB.Text = "Bảng hệ số chưa có đơn vị xuất [" + dvxuat + "], không thể tạo hệ số chốt!";
                        return;
                    }
                    else statusTB.Text = "";
                    if (cboTuDV.SelectedValue.ToString().CompareTo(dvban) != 0)
                    {
                        statusTB.Text = "Bảng hệ số chưa có đơn vị bán[" + dvban + "], không thể tạo hệ số chốt!";
                        return;
                    }
                    else statusTB.Text = "";
                    if (cboTuDV.SelectedValue.ToString().CompareTo(dvnhap) != 0)
                    {
                        statusTB.Text = "Bảng hệ số chưa có đơn vị nhập[" + dvnhap + "], không thể tạo hệ số chốt!";
                        return;
                    }
                    else statusTB.Text = "";
                    if (cboTuDV.SelectedValue.ToString().CompareTo(dvchuan) != 0)
                    {
                        statusTB.Text = "Bảng hệ số chưa có đơn vị chuẩn[" + dvchuan + "], không thể tạo hệ số chốt!";
                        return;
                    }
                    else statusTB.Text = "";
                }
            }
            //Thêm Hệ số qui đổi
            #region Thêm Hệ số qui đổi
            CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
            hsqd.Spid = spid;
            hsqd.Diengiai = txtDienGiai.Text;
            hsqd.Tudvt = cboTuDV.SelectedValue.ToString();
            hsqd.Sangdvt = cboSangDV.SelectedValue.ToString();
            hsqd.Gtqdthuan = decimal.Parse(txtGiaTri.Text);
            hsqd.Gtqdnguoc = (decimal)((decimal)1 / (decimal)(int.Parse(txtGiaTri.Text)));
            hsqd.Capdo = rgvDaThietLap.RowCount;
            hsqd.Lastupdate = DateTime.Now;
            hsqd.Ngaytao = DateTime.Now;
            hsqd.Userid = CStaticBien.SmaTaiKhoan;
            string kq = hsqd.ThemHeSoQuiDoi(hsqd);
            if (kq != null && kq.Length > 0)
            {
                if (_frmMain.fHeSoQuiDoi != null)
                    _frmMain.fHeSoQuiDoi.rgvDSHSQD.DataSource = hsqd.LayLenLuoi();
                rgvDaThietLap.DataSource = hsqd.LayHSQDTheoSPID(ToanCuc_Currentspid);
                rgvDaThietLap.CurrentRow = null;
                statusTB.Text = "Thêm thành công";

                //Insert vào tồn kho (master) sản phẩm.
                if (hsqd.Tudvt == hsqd.Sangdvt)
                {
                    CSQLTonKho tk = new CSQLTonKho();
                    int kqluutonkho = tk.TonKho_Them(hsqd.Spid);
                }

                //Làm sạch form
                this.txtDienGiai.Text = "";
                this.txtGiaTri.Text = "";
                this.cboTuDV.SelectedValue = this.cboSangDV.SelectedValue;
            }
            else
            {
                statusTB.Text = "Cập nhật vào lưới thất bại!";
            }
            this.txtDienGiai.Focus();
            #endregion
        }

        private void SuaHSQD()
        {
            #region
            //if (rgvDaThietLap.Rows.Count > 0)
            //{
            //    //Kiểm tra nếu chưa tồn tại dvxuat, dvban, dvnhap, dvchuan trong ds Hệ số thì chưa cho tạo hs chốt
            //    #region Kiểm tra nếu chưa tồn tại dvxuat, dvban, dvnhap, dvchuan trong ds Hệ số thì chưa cho tạo hs chốt
            //    if (cboTuDV.SelectedValue.ToString().CompareTo(cboSangDV.SelectedValue.ToString()) == 0)
            //    {
            //        int kqdvxuat = -1, kqdvban = -1, kqdvnhap = -1, kqdvchuan = -1;
            //        for (int i = 0; i < rgvDaThietLap.Rows.Count - 1; i++)
            //        {
            //            if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(dvxuat) == 0)
            //            {
            //                kqdvxuat = i;
            //            }
            //            if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(dvban) == 0)
            //            {
            //                kqdvban = i;
            //            }
            //            if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(dvnhap) == 0)
            //            {
            //                kqdvnhap = i;
            //            }
            //            if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(dvchuan) == 0)
            //            {
            //                kqdvchuan = i;
            //            }
            //        }
            //        if (kqdvxuat == -1)
            //        {
            //                statusTB.Text = "Bảng hệ số chưa có đơn vị xuất [" + dvxuat + "], không thể tạo hệ số chốt!";
            //                return;
            //        }
            //        else statusTB.Text = "";
            //        if (kqdvban == -1)
            //        {
            //                statusTB.Text = "Bảng hệ số chưa có đơn vị bán[" + dvban + "], không thể tạo hệ số chốt!";
            //                return;
            //        }
            //        else statusTB.Text = "";
            //        if (kqdvnhap == -1)
            //        {
            //                statusTB.Text = "Bảng hệ số chưa có đơn vị nhập[" + dvnhap + "], không thể tạo hệ số chốt!";
            //                return;
            //        }
            //        else statusTB.Text = "";
            //        if (kqdvchuan == -1)
            //        {
            //            if (cboTuDV.SelectedValue.ToString().CompareTo(dvchuan) != 0)
            //            {
            //                statusTB.Text = "Bảng hệ số chưa có đơn vị chuẩn[" + dvchuan + "], không thể tạo hệ số chốt!";
            //                return;
            //            }
            //        }
            //        else statusTB.Text = "";
            //    }
            //    #endregion

            //    //Kiểm tra hệ số chốt
            //    #region Kiểm tra hệ số chốt
            //    if (rgvDaThietLap.Rows[rgvDaThietLap.Rows.Count - 1].Cells["TuDVTID"].Value.ToString().CompareTo(rgvDaThietLap.Rows[rgvDaThietLap.Rows.Count - 1].Cells["SangDVTID"].Value.ToString()) == 0)
            //    {
            //        statusTB.Text = "Hệ số chốt đã được tạo, không thể thêm hệ số qui đổi";
            //        return;
            //    }
            //    else statusTB.Text = "";
            //    #endregion

            //    //Kiểm tra tuDVTid hiện tại đã có DS tuDVTid của SP hay chưa
            //    #region Kiểm tra tuDVTid hiện tại đã có DS tuDVTid của SP hay chưa
            //    for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
            //    {
            //        if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(cboTuDV.SelectedValue.ToString()) == 0)
            //        {
            //            statusTB.Text = "Đơn vị tính này đã tồn tại trong danh sách HSQĐ, nhập đơn vị khác!";
            //            cboTuDV.Focus();
            //            return;
            //        }
            //        else
            //        {
            //            statusTB.Text = "";
            //            cboSangDV.Focus();
            //        }
            //    }
            //    #endregion

            //    //Kiểm tra sangDVTid hiện tại đã có trong ds TuDVT cấp độ trước chưa
            //    #region Kiểm tra sangDVTid hiện tại đã có trong ds TuDVT cấp độ trước chưa
            //    for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
            //    {
            //        if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(cboSangDV.SelectedValue.ToString()) == 0)
            //        {
            //            statusTB.Text = "Đơn vị tính này đã tồn tại trong danh sách HSQĐ, nhập đơn vị khác!";
            //            cboSangDV.Focus();
            //            return;
            //        }
            //        else
            //        {
            //            statusTB.Text = "";
            //            txtGiaTri.Focus();
            //        }
            //    }
            //    #endregion
            //}
            #endregion

            //Sửa hệ số qui đổi
            #region Sửa hệ số qui đổi
            CSQLHeSoQuyDoi hsqd = new CSQLHeSoQuyDoi();
            hsqd.Hsqdid = rgvDaThietLap.CurrentRow.Cells[0].Value.ToString();
            hsqd.Spid = rgvDaThietLap.CurrentRow.Cells[1].Value.ToString();
            hsqd.Diengiai = txtDienGiai.Text;
            hsqd.Tudvt = cboTuDV.SelectedValue.ToString();
            hsqd.Sangdvt = cboSangDV.SelectedValue.ToString();
            hsqd.Gtqdthuan = decimal.Parse(txtGiaTri.Text);
            //hsqd.Gtqdnguoc = 1 / decimal.Parse(txtGiaTri.Text);
            hsqd.Gtqdnguoc = (decimal)((decimal)1 / (decimal)(int.Parse(txtGiaTri.Text)));
            hsqd.Capdo = int.Parse(rgvDaThietLap.CurrentRow.Cells[11].Value.ToString());
            hsqd.Lastupdate = DateTime.Now;
            hsqd.Ngaytao = DateTime.Now;
            hsqd.Userid = CStaticBien.SmaTaiKhoan;
            int kq = hsqd.SuaHeSoQuiDoi(hsqd);
            if (kq == 1)
            {
                if (_frmMain.fHeSoQuiDoi != null)
                    _frmMain.fHeSoQuiDoi.rgvDSHSQD.DataSource = hsqd.LayLenLuoi();
                rgvDaThietLap.DataSource = hsqd.LayHSQDTheoSPID(ToanCuc_Currentspid);
                rgvDaThietLap.CurrentRow = null;
                //Làm sạch form
                this.txtDienGiai.Text = "";
                this.txtGiaTri.Text = "";
                this.cboTuDV.SelectedValue = this.cboSangDV.SelectedValue;
                _frmMain.MaHeSoQuyDoiCanSua_ = "";
            }
            else
            {
                statusTB.Text = "Cập nhật vào lưới thất bại!";
            }
            txtDienGiai.Focus();
            #endregion
        }


        private void TaoHSQD_B2_KiemTraHeSoChot()
        {
            if (rgvDaThietLap.Rows[rgvDaThietLap.Rows.Count - 1].Cells["TuDVTID"].Value == rgvDaThietLap.Rows[rgvDaThietLap.Rows.Count - 1].Cells["SangDVTID"].Value)
            {
                statusTB.Text = "Hệ số chốt đã được tạo, không thể thêm hệ số qui đổi";
                return;
            }
            else statusTB.Text = "";
        }
        private void TaoHSQD_B3_KiemTraTonTai_TuDVTid_TrongDS_TuDVTid()
        {
            for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
            {
                if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(cboTuDV.SelectedValue.ToString())==0)
                {
                    statusTB.Text = "Đơn vị tính này đã tồn tại trong danh sách HSQĐ, nhập đơn vị khác!";
                    cboTuDV.Focus();
                    return;
                }
                else
                {
                    statusTB.Text = "";
                    cboSangDV.Focus();
                }
            }
        }
        private void TaoHSQD_B4_KiemTraTonTai_SangDVTid_TrongDS_TuDVTid()
        {
            for (int i = 0; i < rgvDaThietLap.Rows.Count; i++)
            {
                if (rgvDaThietLap.Rows[i].Cells["TuDVTID"].Value.ToString().CompareTo(cboSangDV.SelectedValue.ToString()) == 0)
                {
                    statusTB.Text = "Đơn vị tính này đã tồn tại trong danh sách HSQĐ, nhập đơn vị khác!";
                    cboSangDV.Focus();
                    return;
                }
                else
                {
                    statusTB.Text = "";
                    txtGiaTri.Focus();
                }
            }
        }
    }
}
