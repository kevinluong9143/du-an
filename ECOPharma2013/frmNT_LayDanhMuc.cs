using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;
using Telerik.WinControls.UI;
using System.Transactions;

namespace ECOPharma2013
{
    public partial class frmNT_LayDanhMuc : Form
    {
        frmMain _frmMain;
        public frmNT_LayDanhMuc()
        {
            InitializeComponent();
        }
        public frmNT_LayDanhMuc(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        CSQLBangDanhMuc bdm_ = new CSQLBangDanhMuc();

        private void frmNT_LayDanhMuc_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }

        public void LoadDanhMuc()
        {
            rgvDanhMuc.DataSource = bdm_.LayDanhSachLenLuoi();
            for (int i = 0; i < rgvDanhMuc.Rows.Count; i++)
            {
                rgvDanhMuc.Rows[i].Cells[0].Value = true;
            }
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_LayDanhMuc.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                CRmtServer KetNoiServer = new CRmtServer();
                if (KetNoiServer.KiemTraKetNoiRmtServer() == false)
                {
                    MessageBox.Show("Kết nối server không thành công. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    Fr_DangXuLy.ShowFormCho();

                    #region
                    for (int i = 0; i < rgvDanhMuc.Rows.Count; i++)
                    {
                        rgvDanhMuc.Rows[i].Cells[0].EndEdit();

                        //1.Bộ Phận
                        #region Update danh mục Bộ Phận
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOBoPhan") == 0)
                        {
                            //using (TransactionScope giaotac_BT = new TransactionScope())
                            //{
                            CSQLBoPhan bp_ = new CSQLBoPhan();
                            //Insert DS Bộ Phận chưa thêm mới

                            int maxthemmoint = bp_.BoPhan_LayMaxThemMoiNT();
                            int maxthemmoieco = bp_.BoPhan_LayMaxThemMoiECO();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSBoPhanChuaThem = bp_.BoPhan_LayDSBoPhanChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSBoPhanChuaThem != null && dtbDSBoPhanChuaThem.Rows.Count > 0)
                                {
                                    bp_.BoPhan_DongBoThemDanhMuc(dtbDSBoPhanChuaThem);
                                }
                            }

                            //Update DS Bộ Phận chưa cập nhật
                            int maxcapnhateco = bp_.BoPhan_LayMaxCapNhatECO();
                            int maxcapnhatnt = bp_.BoPhan_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSBoPhanChuaCapNhat = bp_.BoPhan_LayDSBoPhanChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSBoPhanChuaCapNhat != null && dtbDSBoPhanChuaCapNhat.Rows.Count > 0)
                                {
                                    bp_.BoPhan_DongBoSuaDanhMuc(dtbDSBoPhanChuaCapNhat);
                                }
                            }
                            //    giaotac_BT.Complete();
                            //}
                        }
                        #endregion Update danh mục Bộ Phận

                        //2.Bộ Phận CT
                        #region Update danh mục Bộ Phận
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOBoPhanCT") == 0)
                        {
                            //using (TransactionScope giaotac_BTCT = new TransactionScope())
                            //{
                            CSQLBoPhan bp_ = new CSQLBoPhan();
                            //Insert DS Bộ Phận CT chưa thêm mới
                            int maxthemmoieco = bp_.BoPhanCT_LayMaxThemMoiECO();
                            int maxthemmoint = bp_.BoPhanCT_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSBoPhanCTChuaThem = bp_.BoPhanCT_LayDSBoPhanCTChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSBoPhanCTChuaThem != null && dtbDSBoPhanCTChuaThem.Rows.Count > 0)
                                {
                                    bp_.BoPhanCT_DongBoThemDanhMuc(dtbDSBoPhanCTChuaThem);
                                }
                            }

                            //Update DS Bộ Phận CT chưa cập nhật
                            int maxcapnhateco = bp_.BoPhanCT_LayMaxCapNhatECO();
                            int maxcapnhatnt = bp_.BoPhanCT_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSBoPhanCTChuaCapNhat = bp_.BoPhanCT_LayDSBoPhanCTChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSBoPhanCTChuaCapNhat != null && dtbDSBoPhanCTChuaCapNhat.Rows.Count > 0)
                                {
                                    bp_.BoPhanCT_DongBoSuaDanhMuc(dtbDSBoPhanCTChuaCapNhat);
                                }
                            }
                            //    giaotac_BTCT.Complete();
                            //}
                        }
                        #endregion Update danh mục Bộ Phận

                        //3.Quốc Gia
                        #region Update danh mụcquốc gia
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOQuocGia") == 0)
                        {
                            //using (TransactionScope giaotac_QG = new TransactionScope())
                            //{
                            CSQLQuocGia quocgia_ = new CSQLQuocGia();
                            //Insert DS Quốc Gia chưa thêm mới
                            int maxthemmoieco = quocgia_.QuocGia_LayMaxThemMoiECO();
                            int maxthemmoint = quocgia_.QuocGia_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSQuocGiaChuaThem = quocgia_.QuocGia_LayDSQuocGiaChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSQuocGiaChuaThem != null && dtbDSQuocGiaChuaThem.Rows.Count > 0)
                                {
                                    quocgia_.QuocGia_DongBoThemDanhMuc(dtbDSQuocGiaChuaThem);
                                }
                            }
                            //Update DS Quốc Gia chưa cập nhật
                            int maxcapnhateco = quocgia_.QuocGia_LayMaxCapNhatECO();
                            int maxcapnhatnt = quocgia_.QuocGia_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSQuocGiaChuaCapNhat = quocgia_.QuocGia_LayDSQuocGiaChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSQuocGiaChuaCapNhat != null && dtbDSQuocGiaChuaCapNhat.Rows.Count > 0)
                                {
                                    quocgia_.QuocGia_DongBoSuaDanhMuc(dtbDSQuocGiaChuaCapNhat);
                                }
                            }
                            //    giaotac_QG.Complete();
                            //}
                        }
                        #endregion Update danh mục quốc gia

                        //4.Quận
                        #region Update danh mục quận
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOQuan") == 0)
                        {
                            //using (TransactionScope giaotac_Q = new TransactionScope())
                            //{
                            CSQLQuan quan_ = new CSQLQuan();
                            //Insert DS Quận chưa thêm mới
                            int maxthemmoieco = quan_.Quan_LayMaxThemMoiECO();
                            int maxthemmoint = quan_.Quan_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSQuanChuaThem = quan_.Quan_LayDSQuanChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSQuanChuaThem != null && dtbDSQuanChuaThem.Rows.Count > 0)
                                {
                                    quan_.Quan_DongBoThemDanhMuc(dtbDSQuanChuaThem);
                                }
                            }

                            //Update DS Quận chưa cập nhật
                            int maxcapnhateco = quan_.Quan_LayMaxCapNhatECO();
                            int maxcapnhatnt = quan_.Quan_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSQuanChuaCapNhat = quan_.Quan_LayDSQuanChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSQuanChuaCapNhat != null && dtbDSQuanChuaCapNhat.Rows.Count > 0)
                                {
                                    quan_.Quan_DongBoSuaDanhMuc(dtbDSQuanChuaCapNhat);
                                }
                            }
                            //    giaotac_Q.Complete();
                            //}

                        }
                        #endregion Update danh mục quận

                        //5.Thành Phố
                        #region Update danh mục Thành Phố
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOThanhPho") == 0)
                        {
                            //using (TransactionScope giaotac_TP = new TransactionScope())
                            //{
                            CSQLThanhPho tp_ = new CSQLThanhPho();
                            //Insert DS Thành Phố chưa thêm mới
                            int maxthemmoieco = tp_.ThanhPho_LayMaxThemMoiECO();
                            int maxthemmoint = tp_.ThanhPho_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSThanhPhoChuaThem = tp_.ThanhPho_LayDSThanhPhoChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSThanhPhoChuaThem != null && dtbDSThanhPhoChuaThem.Rows.Count > 0)
                                {
                                    tp_.ThanhPho_DongBoThemDanhMuc(dtbDSThanhPhoChuaThem);
                                }
                            }
                            //Update DS Thành Phố chưa cập nhật
                            int maxcapnhateco = tp_.ThanhPho_LayMaxCapNhatECO();
                            int maxcapnhatnt = tp_.ThanhPho_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSThanhPhoChuaCapNhat = tp_.ThanhPho_LayDSThanhPhoChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSThanhPhoChuaCapNhat != null && dtbDSThanhPhoChuaCapNhat.Rows.Count > 0)
                                {
                                    tp_.ThanhPho_DongBoSuaDanhMuc(dtbDSThanhPhoChuaCapNhat);
                                }
                            }
                            //    giaotac_TP.Complete();
                            //}

                        }
                        #endregion Update danh mục Thành Phố

                        //6.Nhân Viên
                        #region Update danh mục Nhân Viên
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECONhanVien") == 0)
                        {
                            //using (TransactionScope giaotac_NV = new TransactionScope())
                            //{
                            CSQLNhanVien nv_ = new CSQLNhanVien();
                            //Insert DS Nhân Viên chưa thêm mới
                            int maxthemmoieco = nv_.NhanVien_LayMaxThemMoiECO();
                            int maxthemmoint = nv_.NhanVien_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSNhanVienChuaThem = nv_.NhanVien_LayDSNhanVienChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSNhanVienChuaThem != null && dtbDSNhanVienChuaThem.Rows.Count > 0)
                                {
                                    nv_.NhanVien_DongBoThemDanhMuc(dtbDSNhanVienChuaThem);
                                }
                            }
                            //Update DS Nhân Viên chưa cập nhật
                            int maxcapnhateco = nv_.NhanVien_LayMaxCapNhatECO();
                            int maxcapnhatnt = nv_.NhanVien_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSNhanVienChuaCapNhat = nv_.NhanVien_LayDSNhanVienChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSNhanVienChuaCapNhat != null && dtbDSNhanVienChuaCapNhat.Rows.Count > 0)
                                {
                                    nv_.NhanVien_DongBoSuaDanhMuc(dtbDSNhanVienChuaCapNhat);
                                }
                            }
                            //    giaotac_NV.Complete();
                            //}

                        }
                        #endregion Update danh mục Nhân Viên

                        //7.Nhóm Người Dùng
                        #region Update danh mục Nhóm Người Dùng
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECONhomNguoiDung") == 0)
                        {
                            //using (TransactionScope giaotac_TP = new TransactionScope())
                            //{
                            CSQLNhomNguoiDung nndung_ = new CSQLNhomNguoiDung();
                            //Insert DS Nhóm Người Dùng chưa thêm mới
                            int maxthemmoieco = nndung_.NhomNguoiDung_LayMaxThemMoiECO();
                            int maxthemmoint = nndung_.NhomNguoiDung_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSNhomNguoiDungChuaThem = nndung_.NhomNguoiDung_LayDSNhomNguoiDungChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSNhomNguoiDungChuaThem != null && dtbDSNhomNguoiDungChuaThem.Rows.Count > 0)
                                {
                                    nndung_.NhomNguoiDung_DongBoThemDanhMuc(dtbDSNhomNguoiDungChuaThem);
                                }
                            }
                            //Update DS Nhóm Người Dùng chưa cập nhật
                            int maxcapnhateco = nndung_.NhomNguoiDung_LayMaxCapNhatECO();
                            int maxcapnhatnt = nndung_.NhomNguoiDung_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSNhomNguoiDungChuaCapNhat = nndung_.NhomNguoiDung_LayDSNhomNguoiDungChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSNhomNguoiDungChuaCapNhat != null && dtbDSNhomNguoiDungChuaCapNhat.Rows.Count > 0)
                                {
                                    nndung_.NhomNguoiDung_DongBoSuaDanhMuc(dtbDSNhomNguoiDungChuaCapNhat);
                                }
                            }
                            //    giaotac_TP.Complete();
                            //}

                        }
                        #endregion Update danh mục Nhóm Người Dùng

                        //8.Quyền Truy Cập
                        #region Update danh mục Quyền Truy Cập
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOQuyenTruyCap") == 0)
                        {
                            //using (TransactionScope giaotac_NV = new TransactionScope())
                            //{
                            CSQLQuyenTruyCap quyentc_ = new CSQLQuyenTruyCap();
                            //Insert DS Quyền Truy Cập chưa thêm mới
                            int maxthemmoieco = quyentc_.QuyenTruyCap_LayMaxThemMoiECO();
                            int maxthemmoint = quyentc_.QuyenTruyCap_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSQuyenTruyCapChuaThem = quyentc_.QuyenTruyCap_LayDSQuyenTruyCapChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSQuyenTruyCapChuaThem != null && dtbDSQuyenTruyCapChuaThem.Rows.Count > 0)
                                {
                                    quyentc_.QuyenTruyCap_DongBoThemDanhMuc(dtbDSQuyenTruyCapChuaThem);
                                }
                            }
                            //Update DS Quyền Truy Cập chưa cập nhật
                            int maxcapnhateco = quyentc_.QuyenTruyCap_LayMaxCapNhatECO();
                            int maxcapnhatnt = quyentc_.QuyenTruyCap_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSQuyenTruyCapChuaCapNhat = quyentc_.QuyenTruyCap_LayDSQuyenTruyCapChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSQuyenTruyCapChuaCapNhat != null && dtbDSQuyenTruyCapChuaCapNhat.Rows.Count > 0)
                                {
                                    quyentc_.QuyenTruyCap_DongBoSuaDanhMuc(dtbDSQuyenTruyCapChuaCapNhat);
                                }
                            }
                            //    giaotac_NV.Complete();
                            //}

                        }
                        #endregion Update danh mục Quyền Truy Cập

                        //9.User
                        #region Update danh mục user
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOUser") == 0)
                        {
                            //using (TransactionScope giaotac_user = new TransactionScope())
                            //{
                            CSQLUser user_ = new CSQLUser();
                            //Insert DS User chưa thêm mới
                            int maxthemmoieco = user_.User_LayMaxThemMoiECO();
                            int maxthemmoint = user_.User_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSUserChuaThem = user_.User_LayDSUserChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSUserChuaThem != null && dtbDSUserChuaThem.Rows.Count > 0)
                                {
                                    user_.User_DongBoThemDanhMuc(dtbDSUserChuaThem);
                                }
                            }

                            //Update DS User chưa cập nhật
                            int maxcapnhateco = user_.User_LayMaxCapNhatECO();
                            int maxcapnhatnt = user_.User_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSUserChuaCapNhat = user_.User_LayDSUserChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSUserChuaCapNhat != null && dtbDSUserChuaCapNhat.Rows.Count > 0)
                                {
                                    user_.User_DongBoSuaDanhMuc(dtbDSUserChuaCapNhat);
                                }
                            }
                            //    giaotac_user.Complete();
                            //}

                        }
                        #endregion Update danh mục User

                        //10.Giảm Giá
                        #region Update danh mục giảm giá
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOGiamGia") == 0)
                        {
                            //using (TransactionScope giaotac_GG = new TransactionScope())
                            //{
                            CSQLGiamGia giamgia = new CSQLGiamGia();
                            //Insert DS Giảm Giá chưa thêm mới
                            int maxthemmoieco = giamgia.GiamGia_LayMaxThemMoiECO();
                            int maxthemmoint = giamgia.GiamGia_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSGiamGiaChuaThem = giamgia.GiamGia_LayDSGiamGiaChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSGiamGiaChuaThem != null && dtbDSGiamGiaChuaThem.Rows.Count > 0)
                                {
                                    giamgia.GiamGia_DongBoThemDanhMuc(dtbDSGiamGiaChuaThem);
                                }
                            }

                            //Update DS Giảm Giá chưa cập nhật
                            int maxcapnhateco = giamgia.GiamGia_LayMaxCapNhatECO();
                            int maxcapnhatnt = giamgia.GiamGia_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSGiamGiaChuaCapNhat = giamgia.GiamGia_LayDSGiamGiaChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSGiamGiaChuaCapNhat != null && dtbDSGiamGiaChuaCapNhat.Rows.Count > 0)
                                {
                                    giamgia.GiamGia_DongBoSuaDanhMuc(dtbDSGiamGiaChuaCapNhat);
                                }
                            }
                            //    giaotac_GG.Complete();
                            //}

                        }
                        #endregion Update danh mục giảm giá

                        //11.Phân Loại Giá
                        #region Update danh mục phân loại giá
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOPhanLoaiGia") == 0)
                        {
                            //using (TransactionScope giaotac_PLG = new TransactionScope())
                            //{
                            CSQLPhanLoaiGia plg_ = new CSQLPhanLoaiGia();
                            //Insert DS Phân Loại Giá chưa thêm mới
                            int maxthemmoieco = plg_.PhanloaiGia_LayMaxThemMoiECO();
                            int maxthemmoint = plg_.PhanloaiGia_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSPhanloaiGiaChuaThem = plg_.PhanloaiGia_LayDSPhanloaiGiaChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSPhanloaiGiaChuaThem != null && dtbDSPhanloaiGiaChuaThem.Rows.Count > 0)
                                {
                                    plg_.PhanloaiGia_DongBoThemDanhMuc(dtbDSPhanloaiGiaChuaThem);
                                }
                            }

                            //Update DS Phân Loại Giá chưa cập nhật
                            int maxcapnhateco = plg_.PhanloaiGia_LayMaxCapNhatECO();
                            int maxcapnhatnt = plg_.PhanloaiGia_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSPhanloaiGiaChuaCapNhat = plg_.PhanloaiGia_LayDSPhanloaiGiaChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSPhanloaiGiaChuaCapNhat != null && dtbDSPhanloaiGiaChuaCapNhat.Rows.Count > 0)
                                {
                                    plg_.PhanloaiGia_DongBoSuaDanhMuc(dtbDSPhanloaiGiaChuaCapNhat);
                                }
                            }
                            //    giaotac_PLG.Complete();
                            //}

                        }
                        #endregion Update danh mục phân loại giá

                        //12.Nhà Thuốc
                        #region Update danh mục Nhà Thuốc
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECONhaThuoc") == 0)
                        {
                            //using (TransactionScope giaotac_NT = new TransactionScope())
                            //{
                            CSQLNhaThuoc nt_ = new CSQLNhaThuoc();
                            //Insert DS Nhà Thuốc chưa thêm mới
                            int maxthemmoieco = nt_.NhaThuoc_LayMaxThemMoiECO();
                            int maxthemmoint = nt_.NhaThuoc_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSNhaThuocChuaThem = nt_.NhaThuoc_LayDSNhaThuocChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSNhaThuocChuaThem != null && dtbDSNhaThuocChuaThem.Rows.Count > 0)
                                {
                                    nt_.NhaThuoc_DongBoThemDanhMuc(dtbDSNhaThuocChuaThem);
                                }
                            }
                            //Update DS Nhà Thuốc chưa cập nhật
                            int maxcapnhateco = nt_.NhaThuoc_LayMaxCapNhatECO();
                            int maxcapnhatnt = nt_.NhaThuoc_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSNhaThuocChuaCapNhat = nt_.NhaThuoc_LayDSNhaThuocChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSNhaThuocChuaCapNhat != null && dtbDSNhaThuocChuaCapNhat.Rows.Count > 0)
                                {
                                    nt_.NhaThuoc_DongBoSuaDanhMuc(dtbDSNhaThuocChuaCapNhat);
                                }
                            }
                            //    giaotac_NT.Complete();
                            //}
                        }
                        #endregion Update danh mục Nhà Thuốc

                        //13.NPP
                        #region Update danh muc NPP
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECONPP") == 0)
                        {
                            //using (TransactionScope giaotac_NPP = new TransactionScope())
                            //{
                            CSQLNPP NPP = new CSQLNPP();
                            //Insert DS NPP chưa thêm mới
                            int maxthemmoieco = NPP.NPP_LayMaxThemMoiECO();
                            int maxthemmoint = NPP.NPP_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSNPPChuaThem = NPP.NPP_LayDSNPPChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSNPPChuaThem != null && dtbDSNPPChuaThem.Rows.Count > 0)
                                {
                                    NPP.NPP_DongBoThemDanhMuc(dtbDSNPPChuaThem);
                                }
                            }

                            //Update DS NPP chưa cập nhật
                            int maxcapnhateco = NPP.NPP_LayMaxCapNhatECO();
                            int maxcapnhatnt = NPP.NPP_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSNPPChuaCapNhat = NPP.NPP_LayDSNPPChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSNPPChuaCapNhat != null && dtbDSNPPChuaCapNhat.Rows.Count > 0)
                                {
                                    NPP.NPP_DongBoSuaDanhMuc(dtbDSNPPChuaCapNhat);
                                }
                            }
                            //    giaotac_NPP.Complete();
                            //}
                        }
                        #endregion Update danh muc NPP

                        //14.NSX
                        #region update danh muc NSX
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECONSX") == 0)
                        {
                            //using (TransactionScope giaotac_NSX = new TransactionScope())
                            //{
                            CSQLNSX NSX = new CSQLNSX();
                            //Insert DS NSX chưa thêm mới
                            int maxthemmoieco = NSX.NSX_LayMaxThemMoiECO();
                            int maxthemmoint = NSX.NSX_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSNSXChuaThem = NSX.NSX_LayDSNSXChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSNSXChuaThem != null && dtbDSNSXChuaThem.Rows.Count > 0)
                                {
                                    NSX.NSX_DongBoThemDanhMuc(dtbDSNSXChuaThem);
                                }
                            }

                            //Update DS NSX chưa cập nhật
                            int maxcapnhateco = NSX.NSX_LayMaxCapNhatECO();
                            int maxcapnhatnt = NSX.NSX_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSNSXChuaCapNhat = NSX.NSX_LayDSNSXChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSNSXChuaCapNhat != null && dtbDSNSXChuaCapNhat.Rows.Count > 0)
                                {
                                    NSX.NSX_DongBoSuaDanhMuc(dtbDSNSXChuaCapNhat);
                                }
                            }
                            //    giaotac_NSX.Complete();
                            //}
                        }
                        #endregion Update danh muc nsx

                        //15.Kho
                        #region Update Danh mục kho
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOKho") == 0)
                        {
                            //using (TransactionScope giaotac_DBC = new TransactionScope())
                            //{
                            CSQLKho kho = new CSQLKho();
                            //Insert DS kho chưa thêm mới
                            int maxthemmoieco = kho.Kho_LayMaxThemMoiECO();
                            int maxthemmoint = kho.Kho_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSkhoChuaThem = kho.Kho_LayDSKhoChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSkhoChuaThem != null && dtbDSkhoChuaThem.Rows.Count > 0)
                                {
                                    kho.Kho_DongBoThemDanhMuc(dtbDSkhoChuaThem);
                                }
                            }

                            //Update DS kho chưa cập nhật
                            int maxcapnhateco = kho.Kho_LayMaxCapNhatECO();
                            int maxcapnhatnt = kho.Kho_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSkhoChuaCapNhat = kho.Kho_LayDSKhoChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSkhoChuaCapNhat != null && dtbDSkhoChuaCapNhat.Rows.Count > 0)
                                {
                                    kho.Kho_DongBoSuaDanhMuc(dtbDSkhoChuaCapNhat);
                                }
                            }
                            //    giaotac_DBC.Complete();
                            //}
                        }
                        #endregion update danh mục kho

                        //16.Dạng bào chế
                        #region Update Danh mục dạng bào chế
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECODBC") == 0)
                        {
                            //using (TransactionScope giaotac_DBC = new TransactionScope())
                            //{
                            CSQLDBC DBC = new CSQLDBC();
                            //Insert DS DBC chưa thêm mới
                            int maxthemmoieco = DBC.DBC_LayMaxThemMoiECO();
                            int maxthemmoint = DBC.DBC_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSDBCChuaThem = DBC.DBC_LayDSDBCChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSDBCChuaThem != null && dtbDSDBCChuaThem.Rows.Count > 0)
                                {
                                    DBC.DBC_DongBoThemDanhMuc(dtbDSDBCChuaThem);
                                }
                            }

                            //Update DS DBC chưa cập nhật
                            int maxcapnhateco = DBC.DBC_LayMaxCapNhatECO();
                            int maxcapnhatnt = DBC.DBC_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSDBCChuaCapNhat = DBC.DBC_LayDSDBCChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSDBCChuaCapNhat != null && dtbDSDBCChuaCapNhat.Rows.Count > 0)
                                {
                                    DBC.DBC_DongBoSuaDanhMuc(dtbDSDBCChuaCapNhat);
                                }
                            }
                            //    giaotac_DBC.Complete();
                            //}
                        }
                        #endregion update danh mục dang bào chế

                        //17.Hoạt Chất (Chuyển thành Phân loại thuốc)
                        #region Update danh mục hoạt chất
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOHoatChat") == 0)
                        {
                            //using (TransactionScope giaotac_HC = new TransactionScope())
                            //{
                            CSQLHoatChat hc_ = new CSQLHoatChat();
                            //Insert DS HoatChat chưa thêm mới
                            int maxthemmoieco = hc_.HoatChat_LayMaxThemMoiECO();
                            int maxthemmoint = hc_.HoatChat_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSHoatChatChuaThem = hc_.HoatChat_LayDSHoatChatChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSHoatChatChuaThem != null && dtbDSHoatChatChuaThem.Rows.Count > 0)
                                {
                                    hc_.HoatChat_DongBoThemDanhMuc(dtbDSHoatChatChuaThem);
                                }
                            }

                            //Update DS HoatChat chưa cập nhật
                            int maxcapnhateco = hc_.HoatChat_LayMaxCapNhatECO();
                            int maxcapnhatnt = hc_.HoatChat_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSHoatChatChuaCapNhat = hc_.HoatChat_LayDSHoatChatChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSHoatChatChuaCapNhat != null && dtbDSHoatChatChuaCapNhat.Rows.Count > 0)
                                {
                                    hc_.HoatChat_DongBoSuaDanhMuc(dtbDSHoatChatChuaCapNhat);
                                }
                            }
                            //    giaotac_HC.Complete();
                            //}
                        }
                        #endregion Update danh mục hoạt chất

                        //18.Đơn vị tính
                        #region Update danh mục đơn vị tính
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECODVT") == 0)
                        {
                            //using (TransactionScope giaotac_DVT = new TransactionScope())
                            //{
                            CSQLDonViTinh dvt = new CSQLDonViTinh();
                            //Insert DS DVT chưa thêm mới
                            int maxthemmoieco = dvt.DVT_LayMaxThemMoiECO();
                            int maxthemmoint = dvt.DVT_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSDvtChuaThem = dvt.DVT_LayDSDVTChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSDvtChuaThem != null && dtbDSDvtChuaThem.Rows.Count > 0)
                                {
                                    dvt.DVT_DongBoThemDanhMuc(dtbDSDvtChuaThem);
                                }
                            }

                            //Update DS DVT chưa cập nhật
                            int maxcapnhateco = dvt.DVT_LayMaxCapNhatECO();
                            int maxcapnhatnt = dvt.DVT_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSDVTChuaCapNhat = dvt.DVT_LayDSDVTChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSDVTChuaCapNhat != null && dtbDSDVTChuaCapNhat.Rows.Count > 0)
                                {
                                    dvt.DVT_DongBoSuaDanhMuc(dtbDSDVTChuaCapNhat);
                                }
                            }
                            //    giaotac_DVT.Complete();
                            //}
                        }
                        #endregion Update danh mục đơn vị tính

                        //19.Nhóm sản phẩm
                        #region Update danh mục nhóm sản phẩm
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECONhomSP") == 0)
                        {
                            //using (TransactionScope giaotac_NSP = new TransactionScope())
                            //{
                            CSQLNhomSP nsp = new CSQLNhomSP();
                            //Insert DS DVT chưa thêm mới
                            int maxthemmoieco = nsp.NSP_LayMaxThemMoiECO();
                            int maxthemmoint = nsp.NSP_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSNSPChuaThem = nsp.NSP_LayDSNSPChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSNSPChuaThem != null && dtbDSNSPChuaThem.Rows.Count > 0)
                                {
                                    nsp.NSP_DongBoThemDanhMuc(dtbDSNSPChuaThem);
                                }
                            }

                            //Update DS DVT chưa cập nhật
                            int maxcapnhateco = nsp.NSP_LayMaxCapNhatECO();
                            int maxcapnhatnt = nsp.NSP_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSNSPChuaCapNhat = nsp.NSP_LayDSNSPChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSNSPChuaCapNhat != null && dtbDSNSPChuaCapNhat.Rows.Count > 0)
                                {
                                    nsp.NSP_DongBoSuaDanhMuc(dtbDSNSPChuaCapNhat);
                                }
                            }
                            //    giaotac_NSP.Complete();
                            //}
                        }
                        #endregion Update danh mục nhóm sản phẩm

                        //20.SanPham
                        #region Update danh muc san pham, định giá
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOSanPham") == 0)
                        {
                            //TransactionOptions options_SP = new TransactionOptions();
                            //options_SP.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            //options_SP.Timeout = new TimeSpan(0, 10, 0);
                            //using (TransactionScope giaotac_SP = new TransactionScope(TransactionScopeOption.Required,options_SP))
                            //{
                            CSQLSanPham SanPham = new CSQLSanPham();
                            CSQLNT_SanPham_Kho nt_sp_kho = new CSQLNT_SanPham_Kho();
                            CSQLNTThayDoiGiaSP tdgsp = new CSQLNTThayDoiGiaSP();
                            CSQLDinhGia dinhgia = new CSQLDinhGia();
                            string tDGSPid = "";
                            try
                            {
                                tDGSPid = tdgsp.NTThayDoiGiaSP_Them();
                            }
                            catch {
                                Fr_DangXuLy.DongFormCho();
                            }
                            try
                            {                                
                                if (tDGSPid != null && tDGSPid.Length > 0)
                                {
                                    //Insert DS SanPham chưa thêm mới
                                    int maxthemmoieco = SanPham.SanPham_LayMaxThemMoiECO();
                                    int maxthemmoint = SanPham.SanPham_LayMaxThemMoiNT();
                                    if (maxthemmoieco > maxthemmoint)
                                    {
                                        DataTable dtbDSSanPhamChuaThem = SanPham.SanPham_LayDSSanPhamChuaThemMoiTaiNT(maxthemmoint);
                                        if (dtbDSSanPhamChuaThem != null && dtbDSSanPhamChuaThem.Rows.Count > 0)
                                        {
                                            SanPham.SanPham_DongBoThemDanhMuc(dtbDSSanPhamChuaThem, tDGSPid);
                                            //nt_sp_kho.NT_SP_Kho_DongBoThemDanhMuc(dtbDSSanPhamChuaThem, tDGSPid);
                                        }
                                    }

                                    //Update DS SanPham chưa cập nhật
                                    int maxcapnhateco = SanPham.SanPham_LayMaxCapNhatECO();
                                    int maxcapnhatnt = SanPham.SanPham_LayMaxCapNhatNT();
                                    if (maxcapnhateco > maxcapnhatnt)
                                    {
                                        DataTable dtbDSSanPhamChuaCapNhat = SanPham.SanPham_LayDSSanPhamChuaCapNhatTaiNT(maxcapnhatnt);
                                        if (dtbDSSanPhamChuaCapNhat != null && dtbDSSanPhamChuaCapNhat.Rows.Count > 0)
                                        {
                                            SanPham.SanPham_DongBoSuaDanhMuc(dtbDSSanPhamChuaCapNhat, tDGSPid);
                                            //nt_sp_kho.NT_SP_Kho_DongBoSuaDanhMuc(dtbDSSanPhamChuaCapNhat, tDGSPid);
                                        }
                                    }
                                }
                            }
                            catch { }

                            try
                            {
                                //Insert DS Định giá chưa thêm mới
                                CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
                                string ttcn_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();

                                int dinhgia_maxthemmoieco = dinhgia.DinhGia_LayMaxThemMoiECO(ttcn_);
                                int dinhgia_maxthemmoint = dinhgia.DinhGia_LayMaxThemMoiNT(ttcn_);
                                if (dinhgia_maxthemmoieco > dinhgia_maxthemmoint)
                                {
                                    DataTable dtbDSDinhGiaChuaThem = dinhgia.DinhGia_LayDSDinhGiaChuaThemMoiTaiNT(dinhgia_maxthemmoint, ttcn_);
                                    if (dtbDSDinhGiaChuaThem != null && dtbDSDinhGiaChuaThem.Rows.Count > 0)
                                    {
                                        dinhgia.DinhGia_DongBoThemDanhMuc(dtbDSDinhGiaChuaThem, tDGSPid);
                                    }
                                }

                                //Update DS Định giá chưa cập nhật
                                int dinhgia_maxcapnhateco = dinhgia.DinhGia_LayMaxCapNhatECO(ttcn_);
                                int dinhgia_maxcapnhatnt = dinhgia.DinhGia_LayMaxCapNhatNT(ttcn_);
                                if (dinhgia_maxcapnhateco > dinhgia_maxcapnhatnt)
                                {
                                    DataTable dtbDSDinhGiaChuaCapNhat = dinhgia.DinhGia_LayDSDinhGiaChuaCapNhatTaiNT(dinhgia_maxcapnhatnt, ttcn_);
                                    if (dtbDSDinhGiaChuaCapNhat != null && dtbDSDinhGiaChuaCapNhat.Rows.Count > 0)
                                    {
                                        dinhgia.DinhGia_DongBoSuaDanhMuc(dtbDSDinhGiaChuaCapNhat, tDGSPid);
                                    }
                                }
                            }
                            catch { }
                            tdgsp.NTThayDoiGiaSP_XoaCTKhongCoNoiDung(tDGSPid);
                            //    giaotac_SP.Complete();
                            //}
                        }
                        #endregion update danh muc san pham, định giá

                        //21.SanPham_Kho
                        #region Update danh muc SanPham_Kho
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOSanPham_Kho") == 0)
                        {
                            //TransactionOptions options_SP_NSX = new TransactionOptions();
                            //options_SP_NSX.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            //options_SP_NSX.Timeout = new TimeSpan(0, 5, 0);
                            //using (TransactionScope giaotac_SP_NSX = new TransactionScope(TransactionScopeOption.Required, options_SP_NSX))
                            //{
                            CSQLSanPham_Kho sp_kho = new CSQLSanPham_Kho();
                            //Insert DS sp_kho chưa thêm mới
                            int maxthemmoieco = sp_kho.SP_Kho_LayMaxThemMoiECO();
                            int maxthemmoint = sp_kho.SP_Kho_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSsp_khoChuaThem = sp_kho.SP_Kho_LayDSSP_KhoChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSsp_khoChuaThem != null && dtbDSsp_khoChuaThem.Rows.Count > 0)
                                {
                                    sp_kho.SP_Kho_DongBoThemDanhMuc(dtbDSsp_khoChuaThem);
                                }
                            }

                            //Update DS sp_kho chưa cập nhật
                            int maxcapnhateco = sp_kho.SP_Kho_LayMaxCapNhatECO();
                            int maxcapnhatnt = sp_kho.SP_Kho_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSsp_khoChuaCapNhat = sp_kho.SP_Kho_LayDSSP_KhoChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSsp_khoChuaCapNhat != null && dtbDSsp_khoChuaCapNhat.Rows.Count > 0)
                                {
                                    sp_kho.SP_Kho_DongBoSuaDanhMuc(dtbDSsp_khoChuaCapNhat);
                                }
                            }
                            //    giaotac_SP_NSX.Complete();
                            //}
                        }
                        #endregion Update danh muc SanPham_Kho

                        //22.SanPham_NSX
                        #region Update danh muc SanPham_NSX
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("SanPham_NSX") == 0)
                        {
                            //TransactionOptions options_SP_NSX = new TransactionOptions();
                            //options_SP_NSX.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            //options_SP_NSX.Timeout = new TimeSpan(0, 5, 0);
                            //using (TransactionScope giaotac_SP_NSX = new TransactionScope(TransactionScopeOption.Required, options_SP_NSX))
                            //{
                            CSQLSanPham_NSX SanPham_NSX = new CSQLSanPham_NSX();
                            //Insert DS SanPham_NSX chưa thêm mới
                            int maxthemmoieco = SanPham_NSX.SanPham_NSX_LayMaxThemMoiECO();
                            int maxthemmoint = SanPham_NSX.SanPham_NSX_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSSanPham_NSXChuaThem = SanPham_NSX.SanPham_NSX_LayDSSanPham_NSXChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSSanPham_NSXChuaThem != null && dtbDSSanPham_NSXChuaThem.Rows.Count > 0)
                                {
                                    SanPham_NSX.SanPham_NSX_DongBoThemDanhMuc(dtbDSSanPham_NSXChuaThem);
                                }
                            }

                            //Update DS SanPham_NSX chưa cập nhật
                            int maxcapnhateco = SanPham_NSX.SanPham_NSX_LayMaxCapNhatECO();
                            int maxcapnhatnt = SanPham_NSX.SanPham_NSX_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSSanPham_NSXChuaCapNhat = SanPham_NSX.SanPham_NSX_LayDSSanPham_NSXChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSSanPham_NSXChuaCapNhat != null && dtbDSSanPham_NSXChuaCapNhat.Rows.Count > 0)
                                {
                                    SanPham_NSX.SanPham_NSX_DongBoSuaDanhMuc(dtbDSSanPham_NSXChuaCapNhat);
                                }
                            }
                            //    giaotac_SP_NSX.Complete();
                            //}
                        }
                        #endregion Update danh muc SanPham_NSX

                        //23.Hệ Số Quy Đổi
                        #region Update danh mục Hệ Số Quy Đổi
                        if (rgvDanhMuc.Rows[i].Cells[0].Value != null && (bool)rgvDanhMuc.Rows[i].Cells[0].Value == true && rgvDanhMuc.Rows[i].Cells[1].Value.ToString().CompareTo("ECOHeSoQuiDoi") == 0)
                        {
                            //TransactionOptions options_HSQD = new TransactionOptions();
                            //options_HSQD.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            //options_HSQD.Timeout = new TimeSpan(0, 5, 0);
                            //using (TransactionScope giaotac_HSQD = new TransactionScope(TransactionScopeOption.Required, options_HSQD))
                            //{
                            CSQLHeSoQuyDoi hsqd_ = new CSQLHeSoQuyDoi();
                            //Insert DS Hệ Số Quy Đổi chưa thêm mới
                            int maxthemmoieco = hsqd_.HeSoQuiDoi_LayMaxThemMoiECO();
                            int maxthemmoint = hsqd_.HeSoQuiDoi_LayMaxThemMoiNT();
                            if (maxthemmoieco > maxthemmoint)
                            {
                                DataTable dtbDSHeSoQuiDoiChuaThem = hsqd_.HeSoQuiDoi_LayDSHeSoQuiDoiChuaThemMoiTaiNT(maxthemmoint);
                                if (dtbDSHeSoQuiDoiChuaThem != null && dtbDSHeSoQuiDoiChuaThem.Rows.Count > 0)
                                {
                                    hsqd_.HeSoQuiDoi_DongBoThemDanhMuc(dtbDSHeSoQuiDoiChuaThem);
                                }
                            }

                            //Update DS Hệ Số Quy Đổi chưa cập nhật
                            int maxcapnhateco = hsqd_.HeSoQuiDoi_LayMaxCapNhatECO();
                            int maxcapnhatnt = hsqd_.HeSoQuiDoi_LayMaxCapNhatNT();
                            if (maxcapnhateco > maxcapnhatnt)
                            {
                                DataTable dtbDSHeSoQuiDoiChuaCapNhat = hsqd_.HeSoQuiDoi_LayDSHeSoQuiDoiChuaCapNhatTaiNT(maxcapnhatnt);
                                if (dtbDSHeSoQuiDoiChuaCapNhat != null && dtbDSHeSoQuiDoiChuaCapNhat.Rows.Count > 0)
                                {
                                    hsqd_.HeSoQuiDoi_DongBoSuaDanhMuc(dtbDSHeSoQuiDoiChuaCapNhat);
                                }
                            }
                            //    giaotac_HSQD.Complete();
                            //}
                        }
                        #endregion Update danh mục Hệ Số Quy Đổi
                        rgvDanhMuc.Rows[i].Cells[0].Value = false;
                    }
                    #endregion

                    Fr_DangXuLy.DongFormCho();
                    //giaotac.Complete();
                    MessageBox.Show("Danh mục đã cập nhật hoàn tất!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng liên hệ IT! Thông tin lỗi như sau: " + ex.Message);
                _frmMain.KT = true;
            }
        }
    }
}
