﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using ECOPharma2013.DuLieu;
using Telerik.WinControls.UI;
using ECOPharma2013.Printer_POS;
using System.IO;
using Microsoft.PointOfService;
using ECOPharma2013.From_Report;
using System.Deployment.Application;
using System.Reflection;

//cung dinh ha
namespace ECOPharma2013
{
    public partial class frmMain : Form
    {
        private Timer timerXemKhoDacBiet; 
        //Cac biến kiểm tra không cho các form Danh sach mở nhieu form giong nhau cung mot thoi diem
        public bool DSBoPhanIsOpen = false;
        public bool DSNhomSPIsOpen = false;
        public bool DSNhanVienIsOpen = false;
        public bool DSNSXIsOpen = false;
        public bool DSNPPIsOpen = false;
        public bool DSKhachHangIsOpen = false;
        public bool DSThanhPhoIsOpen = false;
        public bool DSQuanIsOpen = false;
        public bool DSQuocGiaIsOpen = false;
        public bool DSHoatChatIsOpen = false;
        public bool DSDangBaoCheIsOpen = false;
        public bool DSDonViTinhIsOpen = false;
        public bool DSSanPhamIsOpen = false;
        public bool DSHeSoQuiDoiIsOpen = false;
        public bool DSNhaThuocIsOpen = false;
        public bool DSLoaiGiaIsOpen = false;
        public bool DSGiamGiaIsOpen = false;
        public bool DSKhoIsOpen = false;
        public bool DSDonHangMuaIsOpen = false;
        public bool DSNhapKhoIsOpen = false;
        public bool DSNhapKhoXacNhanIsOpen = false;
        public bool DSPhieuXuatKho_DSIsOpen = false;
        public bool DSPhanQuyenIsOpen = false;
        public bool DSDoiMatKhauIsOpen = false;
        public bool DSCauHinhHeThongIsOpen = false;
        public bool DSSanPham_NSXIsOpen = false;
        public bool DSSanPham_NPPIsOpen = false;
        public bool DSSanPham_KhoIsOpen = false;
        public bool DSDonHangXuatIsOpen = false;
        public bool DSDonHangMuaTongIsOpen = false;
        public bool DSDonHangXuatXacNhanIsOpen = false;       
        public bool DSNhapXuatTonIsOpen = false;
        public bool DSTonKhoKeToanIsOpen = false;
        public bool DSKiemTraXuatKhoIsOpen = false;
        public bool DSDongGoiIsOpen = false;
        public bool DSNT_SanPham_KhoIsOpen = false;
        public bool DSNT_LayPhieuXuatIsOpen = false;
        public bool DSNT_LayPhieuDieuChinhTonKhoIsOpen = false;
        public bool DSNT_LayPhieuDieuChinhHSDIsOpen = false;
        public bool DSNT_NhapKhoIsOpen = false;
        public bool DSNT_KetCaIsOpen = false;
        public bool DSNT_NhapKhoXacNhanIsOpen = false;
        public bool DSNT_BanHangIsOpen = false;
        public bool DSNT_NhapXuatTonIsOpen = false;
        public bool DSNT_TonKhoKeToanIsOpen = false;
        public bool DSBangDanhMucIsOpen = false;
        public bool DSNT_LayDanhMucIsOpen = false;
        public bool DSNT_TraHangisOpen = false;
        public bool DSNT_ChuyenHangisOpen = false;
        public bool DSNT_ChuyenHangXacNhanIsOpen = false;
        public bool DSChuyenKhoIsOpen = false;
        public bool DSChuyenKhoXacNhanIsOpen = false;
        public bool DSNhanCHuyenHangIsOpen = false;
        public bool DSNhanCHuyenHangXacNhanIsOpen = false;
        public bool DSNT_NhanPhieuChuyenIsOpen = false;
        public bool DSNT_LayPhieuChuyenIsOpen = false;
        public bool DSNT_NhanPhieuChuyenXacNhanIsOpen = false;
        public bool DSNT_TraHangVeCtyIsOpen = false;
        public bool DSNT_TraHangVeCtyXacNhanIsOpen = false;
        public bool DSNhanTraHangIsOpen = false;
        public bool DSNhanTraHangXacNhanIsOpen = false;
        public bool DSDieuChinhTonIsOpen = false;
        public bool DSDieuChinhTonXacNhanIsOpen = false;
        public bool DSNT_DieuChinhTonIsOpen = false;
        public bool DSNT_DieuChinhTonXacNhanIsOpen = false;
        public bool DSNT_DieuChinhHSDIsOpen = false;
        public bool DSNT_DieuChinhHSDXacNhanIsOpen = false;
        public bool DSNhomNguoiDungIsOpen = false;
        public bool DSNT_DatHangIsOpen = false;
        public bool DSNT_DatHangXacNhanIsOpen = false;
        public bool DSUserIsOpen = false;
        public bool DSXuatNhanhisOpen = false;
        public bool DSXuatNhanhXacNhanisOpen = false;
        public bool DSNT_ThayDoiGiaSPisOpen = false;
        public bool DSNT_LichSuGiaBanIsOpen = false;
        public bool DSDonHangMuaisOpen = false;
        public bool DSBaoCaoCtyisOpen = false;
        public bool DSBaoCaoNTisOpen = false;
        public bool DSChuKyisOpen = false;
        public bool DSDieuChinhHSDIsOpen = false;
        public bool DSDieuChinhHSDXacNhanIsOpen = false;
        public bool DSCauHinhNTIsOpen = false;

        //Cac bien kiem tra cac form nhap lieu da mo chua
        public bool frmBoPhanEditisOpen_ = false;
        public bool frmNhomSPEditisOpen_ = false;
        public bool frmSanPhamEditisOpen_ = false;
        public bool frmQuanEditisOpen_ = false;
        public bool frmDVTEditisOpen_ = false;
        public bool frmDBCEditisOpen_ = false;
        public bool frmThanhPhoEditisOpen_ = false;
        public bool frmQuocGiaEditisOpen_ = false;
        public bool frmGiamGiaEditisOpen_ = false;
        public bool frmKhoEditisOpen_ = false;
        public bool frmPhanLoaiGiaEditisOpen_ = false;
        public bool frmNhanVienEditisOpen_ = false;
        public bool frmHoatChatEditisOpen_ = false;
        public bool frmNhaThuocEditisOpen_ = false;
        public bool frmNhaPhanPhoiEditisOpen_ = false;
        public bool frmNhaSanXuatEditisOpen_ = false;
        public bool frmCauHinhHeThongEditisOpen_ = false;
        public bool frmCauHinhNTEditisOpen_ = false;
        public bool frmSanPham_NSXEditisOpen_ = false;
        public bool frmSanPham_NPPEditisOpen_ = false;
        public bool frmSanPham_KhoEditisOpen_ = false;
        public bool frmNhapKhoEditisOpen_ = false;
        public bool frmNhapKhoXacNhanEditisOpen_ = false;
        public bool frmHeSoQuiDoiEditisOpen_ = false;
        public bool frmDonHangXuatEditisOpen_ = false;
        public bool frmDonHangXuatRePortIsOpen = false;
        public bool frmPhieuXuatKhoisOpen_ = false;
        public bool frmPhieuXuatKho_DSisOpen_ = false;
        public bool frmPhieuXuatKhoEditisOpen_ = false;
        public bool frmNhapXuatTonEditisOpen_ = false;
        public bool frmTonKhoKeToanOpen_ = false;
        public bool frmKiemTraXuatKhoEditisOpen_ = false;
        public bool frmDongGoiEditisOpen_ = false;
        public bool frmNT_SanPham_KhoEditisOpen_ = false;
        public bool frmNT_LayPhieuXuatEditisOpen_ = false;
        public bool frmNT_LayPhieuDieuChinhTonKhoEditisOpen_ = false;
        public bool frmNT_LayPhieuDieuChinhHSDEditisOpen_ = false;
        public bool frmNT_NhapKhoEditisOpen_ = false;
        public bool frmNT_KetCaEditisOpen_ = false;
        public bool frmNT_BanHangEditisOpen_ = false;
        public bool frmNT_ThanhToanEditisOpen_ = false;
        public bool frmBangDanhMucisOpen_ = false;
        public bool frmNT_LayDanhMucisOpen_ = false;
        public bool frmNT_TraHangEditisOpen_ = false;
        public bool frmNT_ThanhToanTraHangEditisOpen_ = false;
        public bool frmNT_ChuyenHangEditisOpen_ = false;
        public bool frmNT_ChuyenHangXacNhanIsOpen_ = false;
        public bool frmChuyenKhoEditisOpen_ = false;
        public bool frmChuyenKhoXacNhanEditisOpen_ = false;
        public bool frmNhanChuyenHangEditisOpen_ = false;
        public bool frmNhanChuyenHangXacNhanEditisOpen_ = false;
        public bool frmNT_NhanPhieuChuyenEditisOpen_ = false;
        public bool frmNT_NhanPhieuChuyenXacNhanisOpen_ = false;
        public bool frmNT_TraHangVeCTyEditisOpen_ = false;
        public bool frmNT_TraHangVeCtyXacNhanIsOpen_ = false;
        public bool frmNhanTraHangEditisOpen_ = false;
        public bool frmNhanTraHangXacNhanisOpen_ = false;
        public bool frmDieuChinhTonEditisOpen_ = false;
        public bool frmDieuChinhTonXacNhanEditisOpen_ = false;
        public bool frmNT_DieuChinhTonEditisOpen_ = false;
        public bool frmNT_DieuChinhTonXacNhanEditisOpen_ = false;
        public bool frmNT_DieuChinhHSDEditisOpen_ = false;
        public bool frmNT_DieuChinhHSDXacNhanEditisOpen_ = false;
        public bool frmPhanQuyenEditisOpen_ = false;
        public bool frmNhomNguoiDungEditisOpen_ = false;
        public bool frmNT_DatHangEditisOpen_ = false;
        public bool frmNT_DatHangEditAccessisOpen_ = false;
        public bool frmNT_DatHangXacNhanisOpen_ = false;
        public bool frmDoiMatKhauEditisOpen_ = false;
        public bool frmUserEditisOpen_ = false;
        public bool frmXuatNhanhEditisOpen_ = false;
        public bool frmXuatNhanhXacNhanisOpen = false;
        public bool frmNT_ThayDoiGiaSPEditisOpen_ = false;
        public bool frmDonHangMuaTongEditisOpen_ = false;
        public bool frmChonDHLamDHTisOpen_ = false;
        public bool frmDonHangMuaEditisOpen_ = false;
        public bool frmBaoCaoCtyisOpen_ = false;
        public bool frmBaoCaoNTisOpen_ = false;
        public bool frmChuKyEditisOpen_ = false;
        public bool frmDieuChinhHSDEditisOpen_ = false;
        public bool frmDieuChinhHSDXacNhanEditisOpen_ = false;

        //Các biến khoi tao Pageview
        Telerik.WinControls.UI.RadPageViewPage pvBoPhan;
        Telerik.WinControls.UI.RadPageViewPage pvNhomSP;
        Telerik.WinControls.UI.RadPageViewPage pvSanPham;
        Telerik.WinControls.UI.RadPageViewPage pvDVT;
        Telerik.WinControls.UI.RadPageViewPage pvNhanVien;
        Telerik.WinControls.UI.RadPageViewPage pvDangBaoChe;
        Telerik.WinControls.UI.RadPageViewPage pvQuan;
        Telerik.WinControls.UI.RadPageViewPage pvThanhPho;
        Telerik.WinControls.UI.RadPageViewPage pvQuocGia;
        Telerik.WinControls.UI.RadPageViewPage pvGiamGia;
        Telerik.WinControls.UI.RadPageViewPage pvKho;
        Telerik.WinControls.UI.RadPageViewPage pvLoaiGia;
        Telerik.WinControls.UI.RadPageViewPage pvNhaThuoc;
        Telerik.WinControls.UI.RadPageViewPage pvHoatChat;
        Telerik.WinControls.UI.RadPageViewPage pvNhaPhanPhoi;
        Telerik.WinControls.UI.RadPageViewPage pvNhaSanXuat;
        Telerik.WinControls.UI.RadPageViewPage pvCauHinhHeThong;
        Telerik.WinControls.UI.RadPageViewPage pvCauHinhNT;
        Telerik.WinControls.UI.RadPageViewPage pvSanPham_NSX;
        Telerik.WinControls.UI.RadPageViewPage pvSanPham_NPP;
        Telerik.WinControls.UI.RadPageViewPage pvSanPham_Kho;
        Telerik.WinControls.UI.RadPageViewPage pvNhapKho;
        Telerik.WinControls.UI.RadPageViewPage pvNhapKhoXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvHeSoQuiDoi;
        Telerik.WinControls.UI.RadPageViewPage pvDonHangXuat;
        Telerik.WinControls.UI.RadPageViewPage pvDonHangXuatXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNhapXuatTon;
        Telerik.WinControls.UI.RadPageViewPage pvXemLichSuTonKhoKeToan;
        Telerik.WinControls.UI.RadPageViewPage pvTonKhoKeToan;
        Telerik.WinControls.UI.RadPageViewPage pvPhieuXuatKho;
        Telerik.WinControls.UI.RadPageViewPage pvKiemTraXuatKho;
        Telerik.WinControls.UI.RadPageViewPage pvDongGoi;
        Telerik.WinControls.UI.RadPageViewPage pvNT_SanPham_Kho;
        Telerik.WinControls.UI.RadPageViewPage pvNT_LayPhieuXuat;
        Telerik.WinControls.UI.RadPageViewPage pvNT_LayPhieuDieuChinhTonKho;
        Telerik.WinControls.UI.RadPageViewPage pvNT_LayPhieuDieuChinhHSD;
        Telerik.WinControls.UI.RadPageViewPage pvNT_NhapKho;
        Telerik.WinControls.UI.RadPageViewPage pvNT_KetCa;
        Telerik.WinControls.UI.RadPageViewPage pvNT_NhapKhoXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNT_BanHang;
        Telerik.WinControls.UI.RadPageViewPage pvNT_NhapXuatTon;
        Telerik.WinControls.UI.RadPageViewPage pvNT_TonKhoKeToan;
        Telerik.WinControls.UI.RadPageViewPage pvBangDanhMuc;
        Telerik.WinControls.UI.RadPageViewPage pvNT_LayDanhMuc;
        Telerik.WinControls.UI.RadPageViewPage pvNT_TraHang;
        Telerik.WinControls.UI.RadPageViewPage pvNT_ChuyenHang;
        Telerik.WinControls.UI.RadPageViewPage pvNT_ChuyenHangXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvChuyenKho;
        Telerik.WinControls.UI.RadPageViewPage pvChuyenKhoXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNhanChuyenHang;
        Telerik.WinControls.UI.RadPageViewPage pvNhanChuyenHangXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNT_NhanPhieuChuyen;
        Telerik.WinControls.UI.RadPageViewPage pvNT_LayPhieuChuyen;
        Telerik.WinControls.UI.RadPageViewPage pvNT_NhanPhieuChuyenXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNT_TraHangVeCty;
        Telerik.WinControls.UI.RadPageViewPage pvNT_TraHangVeCtyXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNhanTraHang;
        Telerik.WinControls.UI.RadPageViewPage pvNhanTraHangXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvDieuChinhTon;
        Telerik.WinControls.UI.RadPageViewPage pvDieuChinhTonXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNT_DieuChinhTon;
        Telerik.WinControls.UI.RadPageViewPage pvNT_DieuChinhTonXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNhomNguoiDung;
        Telerik.WinControls.UI.RadPageViewPage pvDoiMatKhau;
        Telerik.WinControls.UI.RadPageViewPage pvPhanQuyen;
        Telerik.WinControls.UI.RadPageViewPage pvNT_DatHang;
        Telerik.WinControls.UI.RadPageViewPage pvNT_DatHangXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvUser;
        Telerik.WinControls.UI.RadPageViewPage pvXuatNhanh;
        Telerik.WinControls.UI.RadPageViewPage pvXuatNhanhXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNT_ThayDoiGiaSP;
        Telerik.WinControls.UI.RadPageViewPage pvNT_LichSuGiaBan;
        Telerik.WinControls.UI.RadPageViewPage pvDonHangMuaTong;
        Telerik.WinControls.UI.RadPageViewPage pvDonHangMua;
        Telerik.WinControls.UI.RadPageViewPage pvBaoCaoCty;
        Telerik.WinControls.UI.RadPageViewPage pvBaoCaoNT;
        Telerik.WinControls.UI.RadPageViewPage pvChuKy;
        Telerik.WinControls.UI.RadPageViewPage pvDieuChinhHSD;
        Telerik.WinControls.UI.RadPageViewPage pvDieuChinhHSDXacNhan;
        Telerik.WinControls.UI.RadPageViewPage pvNT_DieuChinhHSD;
        Telerik.WinControls.UI.RadPageViewPage pvNT_DieuChinhHSDXacNhan;

        //Cac bien khoi tao form
        public frmDangNhap fDangNhap_;
        public frmBoPhanEdit fBoPhanEdit_;
        public frmBoPhan fBoPhan;
        public frmNhomSPEdit fNhomSPEdit_;
        public frmNhomSP fNhomSP_;
        public frmSanPham fSanPham;
        public frmSanPhamEdit fSanPhamEdit_;
        public frmDVT fDVT;
        public frmDVTEdit fDVTEdit_;        
        public frmDBC fDBC;
        public frmDBCEdit fDBCEdit_;
        public frmGiamGia fGiamGia;
        public frmGiamGiaEdit fGiamGiaEdit_;
        public frmKho fKho;
        public frmKhoEdit fKhoEdit_;
        public frmPhanLoaiGia fPhanLoaiGia;
        public frmPhanLoaiGiaEdit fPhanLoaiGiaEdit_;
        public frmNhaThuoc fNhaThuoc;
        public frmNhaThuocEdit fNhaThuocEdit_;
        public frmQuan fQuan;
        public frmQuanEdit fQuanEdit_;
        public frmQuocGia fQuocGia;
        public frmQuocGiaEdit fQuocGiaEdit_;
        public frmThanhPho fThanhPho;
        public frmThanhPhoEdit fThanhPhoEdit_;
        public frmNhanVien fNhanVien;
        public frmNhanVienEdit fNhanVienEdit_;
        public frmHoatChat fHoatChat;
        public frmHoatChatEdit fHoatChatEdit_;
        public frmNhaPhanPhoi fNhaPhanPhoi;
        public frmNhaPhanPhoiEdit fNhaPhanPhoiEdit_;
        public frmNhaSanXuat fNhaSanXuat;
        public frmNhaSanXuatEdit fNhaSanXuatEdit_;
        public frmCauHinhHeThong fCauHinhHeThong;
        public frmCauHinhDanhSachNhaThuoc fCauHinhNT;
        public frmSanPham_NSX fSanPham_NSX;
        public frmSanPham_NPP fSanPham_NPP;
        public frmSanPham_Kho fSanPham_Kho;
        public frmNhapKho fNhapKho;
        public frmNhapKhoEdit fNhapKhoEdit_;
        public frmNhapKhoXacNhan fNhapKhoXacNhan;
        public frmHeSoQuiDoi fHeSoQuiDoi;
        public frmHeSoQuiDoiEdit fHeSoQuiDoiEdit_;
        public frmDonHangXuat fDonHangXuat;
        public frmDonHangXuatEdit fDonHangXuatEdit_;
        public frmDonHangXuatXacNhan fDonHangXuatXacNhan;
        public frmPhieuXuatKho fPhieuXuatKho;
        public frmPhieuXuatKho_DS fPhieuXuatKho_DS;
        public frmPhieuXuatKhoEdit fPhieuXuatKhoEdit;
        public frmNhapXuatTon fNhapXuatTon;
        public frmXemLichSuTonKhoKeToan fXemLichSuTonKhoKeToan;
        public frmKiemTraXuatKho fKiemTraXuatKho;
        public frmKiemTraXuatKhoEdit fKiemTraXuatKhoEdit_;
        public Fr_Waiting fWaiting;
        public frmDongGoi fDongGoi;
        public frmDongGoiEdit fDongGoiEdit_;
        public frmNT_SanPham_Kho fNT_SanPham_Kho;
        public frmNT_LayPhieuXuat fNT_LayPhieuXuat;
        public frmNT_LayPhieuDieuChinhTon fNT_LayPhieuDieuChinhTonKho;
        public frmNT_LayPhieuDieuChinhHSD fNT_LayPhieuDieuChinhHSD;
        public frmNT_NhapKho fNT_NhapKho;
        public frmNT_NhapKhoEdit fNT_NhapKhoEdit_;
        public frmNT_KetCa fNT_KetCa;
        public frmNT_KetCaEdit fNT_KetCaEdit_;
        public frmNT_NhapKhoXacNhan fNT_NhapKhoXacNhan;
        public frmNT_BanHang fNT_BanHang;
        public frmNT_BanHangEdit fNT_BanHangEdit_;
        public frmNT_ThanhToanEdit fNT_ThanhToanEdit_;
        public frmNT_NhapXuatTon fNT_NhapXuatTon;
        public frmDonHangXuatReport fDonHangXuatReport;
        public frmBangDanhMuc fBangDanhMuc;
        public frmNT_LayDanhMuc fNT_LayDanhMuc;
        public frmNT_TraHang fNT_TraHang;
        public frmNT_TraHangEdit fNT_TraHangEdit_;
        public frmNT_ThanhToanTraHangEdit fNT_ThanhToanTraHangEdit_;
        public frmNT_ChuyenHang fNT_ChuyenHang;
        public frmNT_ChuyenHangEdit fNT_ChuyenHangEdit_;
        public frmNT_ChuyenHangXacNhan fNT_ChuyenHangXacNhan_;
        public frmChuyenKho fChuyenKho;
        public frmChuyenKhoEdit fChuyenKhoEdit_;
        public frmChuyenKhoXacNhan fChuyenKhoXacNhan;
        public frmNhanChuyenHang fNhanChuyenHang;
        public frmNhanChuyenHangEdit fNhanChuyenHangEdit_;
        public frmNhanChuyenHangXacNhan fNhanChuyenHangXacNhan;
        public frmNT_NhanPhieuChuyen fNT_NhanPhieuChuyen;
        public frmNT_NhanPhieuChuyenEdit fNT_NhanPhieuChuyenEdit;
        public frmNT_LayPhieuChuyen fNT_LayPhieuChuyen;
        public frmNT_NhanPhieuChuyenXacNhan fNT_NhanPhieuChuyenXacNhan;
        public frmNT_TraHangVeCty fNT_TraHangVeCty;
        public frmNT_TraHangVeCtyEdit fNT_TraHangVeCtyEdit;
        public frmNT_TraHangVeCtyXacNhan fNT_TraHangVeCtyXacNhan;
        public frmNhanTraHang fNhanTraHang;
        public frmNhanTraHangEdit fNhanTraHangEdit_;
        public frmNhanTraHangXacNhan fNhanTraHangXacNhan;
        public frmDieuChinhTon fDieuChinhTon;
        public frmDieuChinhTonEdit fDieuChinhTonEdit_;
        public frmDieuChinhTonXacNhan fDieuChinhTonXacNhan;
        public frmNT_DieuChinhTon fNT_DieuChinhTon;
        public frmNT_DieuChinhTonEdit fNT_DieuChinhTonEdit_;
        public frmNT_DieuChinhTonXacNhan fNT_DieuChinhTonXacNhan;
        public frmNT_DieuChinhHSD fNT_DieuChinhHSD;
        public frmNT_DieuChinhHSDEdit fNT_DieuChinhHSDEdit_;
        public frmNT_DieuChinhHSDXacNhan fNT_DieuChinhHSDXacNhan;
        public frmNhomNguoiDung fNhomNguoiDung;
        public frmNhomNguoiDungEdit fNhomNguoiDungEdit_;
        public frmPhanQuyen fPhanQuyen;
        public frmPhanQuyenEdit fPhanQuyenEdit_;
        public frmDoiMatKhau fDoiMatKhau_;
        public frmUser fUser;
        public frmUserEdit fUserEdit_;
        public frmNT_DatHang fNT_DatHang;
        public frmNT_DatHangEdit fNT_DatHangEdit_;
        public frmNT_DatHangEditAccess fNT_DatHangEditAccess_;
        public frmNT_DatHangXacNhan fNT_DatHangXacNhan;
        public Fr_DangXuLy fDangXuLy;
        public frmXuatNhanh fXuatNhanh;
        public frmXuatNhanhEdit fXuatNhanhEdit_;
        public frmXuatNhanhXacNhan fXuatNhanhXacNhan;
        public frmNT_ThayDoiGiaSP fNT_ThayDoiGiaSP;
        public frmNT_LichSuGiaBan fNT_LichSuGiaBan;
        public frmNT_ThayDoiGiaSPEdit fNT_ThayDoiGiaSPEdit;
        public frmTKXacNhan fTKXacNhan;
        public frmTraHang_TKXacNhan fTraHang_TKXacNhan;
        public frmDonHangMuaTong fDonHangMuaTong;
        public frmDonHangMuaTongEdit fDonHangMuaTongEdit;
        public frmChonDHLamDHT fChonDHLamDHT;
        public frmChonNPP fChonNPP;
        public frmDonHangMua fDonHangMua;
        public frmDonHangMuaEdit fDonHangMuaEdit;
        public frmBaoCaoCongTy fBaoCaoCty;
        public frmBaoCaoNhaThuoc fBaoCaoNT;
        public FrmChuKy fChuKy;
        public FrmChuKyEdit fChuKyEdit;
        public frmDieuChinhHSD fDieuChinhHSD;
        public frmDieuChinhHSDEdit fDieuChinhHSDEdit_;
        public frmDieuChinhHSDXacNhan fDieuChinhHSDXacNhan;

        //Cac bien dang flag
        public bool IsXemTatCa_ = false;

        //Cac bien cho form BoPhan
        public bool IsSuaBoPhan_ = false;
        public DataTable BangBoPhanCanSua_;
        public string MaBPCanSua_;

        //Cac bien cho form Phan Quyen
        public bool IsSuaPhanQuyen_ = false;

        //Cac bien cho form Nhom nguoi dung
        public bool IsSuaNhomNguoiDung_ = false;
        public DataTable BangNhomNguoiDungCanSua_;
        public string MaNhomNguoiDungCanSua_;


        //Cac bien cho form DVT
        public bool IsSuaDVT_ = false;
        public DataTable BangDVTCanSua_;
        public string MaDVTCanSua_;

        //Cac bien cho form SanPham
        public bool IsSuaSanPham_ = false;
        public DataTable BangSanPhamCanSua_;
        public string MaSPCanSua_;
        public int ChonMaSP_;

        //Cac bien cho form Nhom SP
        public bool IsSuaNhomSP = false;
        public DataTable BangNhomSPCanSua_;
        public string MaNhomSPCanSua_;

        //Tân: Cac bien cho form Quan
        public bool IsSuaQuan_ = false;
        public DataTable BangQuanCanSua_;
        public string MaQuanCanSua_;

        //Hà: Cac bien cho form Quốc Gia
        public bool IsSuaQuocGia_ = false;
        public DataTable BangQuocGiaCanSua_;
        public string MaQuocGiaCanSua_;
        public DataTable BangQuocGiaCanXoa_;
        public string MaQuocGiaCanXoa_;

        //Tân: Các biến cho form Thành phố
        public bool IsSuaThanhPho = false;
        public DataTable BangThanhPhoCanSua_;
        public string MaThanhPhoCanSua_;

        //Tân: Cac bien cho form Nhan vien
        public bool IsSuaNhanVien = false;
        public DataTable BangNhanVienCanSua_;
        public string MaNhanVienCanSua_;

        //Tân: Các biến cho form Hoat Chat
        public bool IsSuaHoatChat_ = false;
        public DataTable BangHoatChatCanSua_;
        public string MaHoatChatCanSua_;
        
        //Tân: Các biến cho form Nha Phan Phoi
        public bool IsSuaNhaPhanPhoi = false;
        public DataTable BangNhaPhanPhoiCanSua_;
        public string MaNhaPhanPhoiCanSua_;

        //Tân: Các biến cho form Nha San Xuat
        public bool IsSuaNhaSanXuat = false;
        public DataTable BangNhaSanXuatCanSua_;
        public string MaNhaSanXuatCanSua_;

        //Tân: Các biến cho form HeSoQuiDoi
        public bool IsSuaHeSoQuiDoi = false;
        public DataTable BangHeSoQuyDoiCanSua_;
        public string MaHeSoQuyDoiCanSua_;

        //Tân: Các biến cho form DonHangXuat
        public bool IsSuaDonHangXuat = false;
        public string MaDonHangXuatCanSua_;
        public DataTable BangDonHangXuatCanSua_;
        public string MaSP_DHXCanChon_;

        //Cac bien cho form Dang Bao Che
        public bool IsSuaDBC_ = false;
        public DataTable BangDBCCanSua_;
        public string MaDBCCanSua_;
        public DataTable BangDBCCanXoa_;
        public string MaDBCCanXoa_;

        //Cac bien cho form Giam Giá
        public bool IsSuaGiamGia_ = false;
        public DataTable BangGiamGiaCanSua_;
        public string MaGiamGiaCanSua_;
        public DataTable BangGiamGiaCanXoa_;
        public string MaGiamGiaCanXoa_;

        //Cac bien cho form Kho
        public bool IsSuaKho_ = false;
        public DataTable BangKhoCanSua_;
        public string MaKhoCanSua_;
        public DataTable BangKhoCanXoa_;
        public string MaKhoCanXoa_;

        //Cac bien cho form Phan Loại Giá
        public bool IsSuaPhanLoaiGia_ = false;
        public DataTable BangPhanLoaiGiaCanSua_;
        public string MaPhanLoaiGiaCanSua_;
        public DataTable BangPhanLoaiGiaCanXoa_;
        public string MaPhanLoaiGiaCanXoa_;

        //Cac bien cho form Phan Loại Giá
        public bool IsSuaNhaThuoc_ = false;
        public DataTable BangNhaThuocCanSua_;
        public string MaNhaThuocCanSua_;
        public DataTable BangNhaThuocCanXoa_;
        public string MaNhaThuocCanXoa_;

        //Cac bien cho form Mapping SP_NSX
        public string MaSP_NSXCanSua_;

        //Cac bien cho form Mapping SP_NPP
        public string MaSP_NPPCanSua_;
 
        //Cac bien cho form Mapping SP_Kho
        public string MaSP_KhoCanSua_;

        //Cac bien cho form Mapping NT SP_Kho
        public string MaNT_SP_KhoCanSua_;

        //Cac bien cho form NT_Lấy Phiếu Xuất
        public DataTable NT_LayPhieuXuat;
        public string MaNT_LayPhieuXuat;

        //Cac bien cho form NT_Lấy Danh Mục
        public DataTable NT_LayDanhMuc;
        public string MaNT_LayDanhMuc;

        //Cac bien cho form Nhap Kho
        public bool XNnhapkho = false;
        public bool IsSuaNhapKho_ = false;
        public bool kiemtraphieunhapkho = false;
        public DataTable BangNhapKhoCanSua_;
        public string MaNhapKhoCanSua_;
        public DataTable BangNhapKhoChiTietCanSua_;
        public string MaNhapKhoChiTietCanSua_;
        public DataTable BangNhapKhoCanXoa_;
        public string MaNhapKhoCanXoa_;


        //Cac bien cho form Phiếu Xuất Kho
        public bool IsBangPhieuXuatKho_ = false;
        public DataTable BangPhieuXuatKho_DS_;
        public string MaPhieuXuatKho_DS_;

        //Cac bien cho form NT_Nhap Kho
        public DataTable BangNT_NhapKho_;
        public string MaNT_NhapKho_;

        //Cac bien cho form NT_Ketca
        public DataTable BangNT_KetCa_;
        public string MaNT_KetCa_;
        public bool IsDaXacNhan_;

        //Cac bien cho form Nhap Kho Xac Nhan
        public DataTable BangNhapKhoXN_;
        public string MaNhapKhoXN_;

        //Cac bien cho form Nhap XuatTon
        public DataTable BangNhapXuatTon_;
        public string MaNhapXuatTon_;

        //Cac bien cho form KiemTraXuatKho
        public DataTable BangKiemTraXuatKho_;
        public string MaKiemTraXuatKho_;
        public bool IsXong;
        public bool KT = false;

        //Tân: Các biến toàn cục cho form NT_BanHangEdit
        public string SoPhieuNT_BanHang_;
        public string BHID_NT_BanHang_;

        //Cac bien cho form Chuyển Kho
        public DataTable BangChuyenKho_;
        public string MaChuyenKho_;
        public string MaChuyenKhoChiTietCanSua_;

        //Cac bien cho form Chuyển Kho Xac Nhan
        public DataTable BangChuyenKhoXN_;
        public string MaChuyenKhoXN_;

        //Cac bien cho form Nhận Chuyển Hàng
        public DataTable BangNhanChuyenHang_;
        public string MaNhanChuyenHang_;

        //Cac bien cho form Nhận Chuyển Hàng Xac Nhan
        public DataTable BangNhanChuyenHangXN_;
        public string MaNhanChuyenHangXN_;

        //Cac bien cho form Nhận Trả Hàng
        public DataTable BangNhanTraHang_;
        public string MaNhanTraHang_;
        public string SoPTH_;
        public int LoaiHangTra_;
        public bool KhoDacBiet_;

        //Cac bien cho form Nhận Trả Hàng Xac Nhan
        public DataTable BangNhanTraHangXN_;
        public string MaNhanTraHangXN_;

        //Cac bien cho form Điều Chỉnh Tồn
        public DataTable BangDieuChinhTon_;
        public string MaDieuChinhTon_;
        public string MaDieuChinhTonChiTietCanSua_;

        //Cac bien cho form Điều Chỉnh Tồn Xac Nhan
        public DataTable BangDieuChinhTonXN_;
        public string MaDieuChinhTonXN_;

        //Cac bien cho form NT Điều Chỉnh Tồn
        public DataTable BangNT_DieuChinhTon_;
        public string MaNT_DieuChinhTon_;

        //Cac bien cho form NT Điều Chỉnh Tồn Xac Nhan
        public DataTable BangNT_DieuChinhTonXN_;
        public string MaNT_DieuChinhTonXN_;

        //Cac bien cho form NT Điều Chỉnh Hạn Sử Dụng
        public DataTable BangNT_DieuChinhHSD_;
        public string MaNT_DieuChinhHSD_;

        //Cac bien cho form NT Điều Chỉnh Hạn Sử Dụng Xac Nhan
        public DataTable BangNT_DieuChinhHSDXN_;
        public string MaNT_DieuChinhHSDXN_;

        //Cac bien cho form Điều Chỉnh HSD
        public DataTable BangDieuChinhHSD_;
        public string MaDieuChinhHSD_;
        public string MaDieuChinhHSDChiTietCanSua_;

        //Cac bien cho form Điều Chỉnh HSD Xac Nhan
        public DataTable BangDieuChinhHSDXN_;
        public string MaDieuChinhHSDXN_;

        //Cac bien cho form NT_Chuyển Hàng
        public string MaNT_ChuyenHang_;

        //Cac bien cho form NT_Trả Hàng Về Cty
        public string MaNT_TraHangVeCty_;

        //Cac bien cho form User
        public DataTable BangUserCanSua_;
        public string MaUserCanSua_;

        //Cac bien cho form Báo Cáo
        public bool BCTK_Cty;
        public bool BCXK_TB;
        public bool BCBH_Cty;
        public bool BCTH_Cty;
        public bool BCBH_NT;
        public bool BCTH_NT;

        //Cac bien Class
        CSQLBoPhan LopCSQLBoPhan;
        CSQLDonViTinh LopCSQLDVT;
        CSQLNhomSP LopCSQLNhomSP;
        CSQLSanPham LopCSQLSanPham;
        CSQLQuyenTruyCap LopCSQLQuyenTruyCap;

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        } 

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(frmDangNhap fdangnhap)
        {
            InitializeComponent();
            fDangNhap_ = fdangnhap;
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < radStartMenu.CommandTabs.Count; i++)
            {
                radStartMenu.CommandTabs.ElementAt(i).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            }

            //kiem tra license key.
            try
            {
                CSQLLicenseKey LopLicense = new CSQLLicenseKey();
            }
            catch (Exception)
            {
                frmRegistration fRegistration = new frmRegistration();
                fRegistration.ShowDialog();
            }
            //

            DataTable BangMenu = new DataTable();
            LopCSQLQuyenTruyCap = new CSQLQuyenTruyCap();
            BangMenu = LopCSQLQuyenTruyCap.QuyenMenu(CStaticBien.sNhomTaiKhoan);
            for (int dong = 0; dong < BangMenu.Rows.Count; dong++)
            {
                for (int IndexMenu = 0; IndexMenu < radStartMenu.CommandTabs.Count; IndexMenu++)
                {
                    if (radStartMenu.CommandTabs.ElementAt(IndexMenu).Name.ToString() == BangMenu.Rows[dong]["MenuID"].ToString())
                    {
                        radStartMenu.CommandTabs.ElementAt(IndexMenu).Visibility = Telerik.WinControls.ElementVisibility.Visible;
                    }
                }
            }
            
            //MainPageView.Controls.Remove(pvBoPhan)

            //An: Tạo sổ Tồn kho kế toán KeToan_TaoSoTonKhoKeToan
            CSQLSoTonKhoKeToan aSoTonKhoKeToan = new CSQLSoTonKhoKeToan();
            string kqTao = aSoTonKhoKeToan.TaoSoTonKhoKeToan();
            if (!kqTao.Equals("OK") && !kqTao.Equals("EXIST")) {
                MessageBox.Show(kqTao);
            }
            //Cập nhật trạng thái Xem kho đặc biệt
            LoadIconXemKhoDacBiet();

            timerXemKhoDacBiet = new Timer();
            timerXemKhoDacBiet.Tick += new EventHandler(timerXemKhoDacBiet_Tick);
            timerXemKhoDacBiet.Interval = 30000; // in miliseconds
            timerXemKhoDacBiet.Start();
        }

        private void timerXemKhoDacBiet_Tick(object sender, EventArgs e)
        {
            LoadIconXemKhoDacBiet();
        }

        private void LoadIconXemKhoDacBiet()
        {
            CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
            if (chht.KiemTraTrangThaiXemKhoDacBiet())
            {
                sslLight.Image = Properties.Resources.green_Icon;
            }
            else
            {
                sslLight.Image = Properties.Resources.red_Icon;
            }

            string info = "Địa điểm: {0} - Nhân Viên: {1} ({2}) - Version: {3}";
            CSQLNhanVien aNhanVien = new CSQLNhanVien();
            sslInfo.Text = string.Format(info, UppercaseWords(chht.LayDanhSachCauHinhHeThong().Rows[0]["TenChiNhanh"].ToString()), aNhanVien.LayThongTinNhanVienTheoMa(CStaticBien.SNVid).Rows[0]["HoTen"].ToString(), CStaticBien.StaiKhoan, GetRunningVersion());
        }

        private Version GetRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        static string UppercaseWords(string value)
        {
            value = value.ToLower();

            char[] array = value.ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool KiemTraQuyenChiTiet(string frmName)
        {
            
            LopCSQLQuyenTruyCap=new CSQLQuyenTruyCap();
            DataTable BangQuyenChiTiet=new DataTable();
            BangQuyenChiTiet = LopCSQLQuyenTruyCap.QuyenChiTiet(CStaticBien.sNhomTaiKhoan,frmName);
            for (int i = 0; i < BangQuyenChiTiet.Rows.Count; i++)
            {
                return bool.Parse(BangQuyenChiTiet.Rows[0]["Xem"].ToString());
            }
            return false;
        }

        private void rbtnBoPhan_Click(object sender, EventArgs e)
        {
            fBoPhan = new frmBoPhan(this);

            if (KiemTraQuyenChiTiet(fBoPhan.Name.ToString()) == false)
            {
                MessageBox.Show("Bạn Chưa Có Quyền Truy Cập Chức Năng Này !");
                return;
            }
            if (DSBoPhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvBoPhan;
                return;
            }
            fBoPhan.TopLevel = false;
            fBoPhan.FormBorderStyle = FormBorderStyle.None;
            fBoPhan.Dock = DockStyle.Fill;

            pvBoPhan = new Telerik.WinControls.UI.RadPageViewPage();
            pvBoPhan.Text = "Bộ Phận";
            MainPageView.Pages.Add(pvBoPhan);
            pvBoPhan.Controls.Add(fBoPhan);
            fBoPhan.Show();
            MainPageView.SelectedPage = pvBoPhan;
            DSBoPhanIsOpen = true;           
        }

        private void rbtnNhanVien_Click(object sender, EventArgs e)
        {

            fNhanVien = new frmNhanVien(this);

            //if (KiemTraQuyenChiTiet(fNhanVien.Name.ToString()) == false)
            //{
            //    MessageBox.Show("Bạn Chưa Có Quyền Truy Cập Chức Năng Này !");
            //    return;
            //}

            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fNhanVien.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
                        
            if (DSNhanVienIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhanVien;
                return;
            }

            
            fNhanVien.TopLevel = false;
            fNhanVien.FormBorderStyle = FormBorderStyle.None;
            fNhanVien.Dock = DockStyle.Fill;

            pvNhanVien = new Telerik.WinControls.UI.RadPageViewPage();
            pvNhanVien.Text = "Nhân Viên";
            MainPageView.Pages.Add(pvNhanVien);
            pvNhanVien.Controls.Add(fNhanVien);
            fNhanVien.Show();
            MainPageView.SelectedPage = pvNhanVien;
            DSNhanVienIsOpen = true;
        }

        //Tân: Hiện form fNhaSanXuat vào pageview fmain
        #region
        private void rbtnNSX_Click(object sender, EventArgs e)
        {

            fNhaSanXuat = new frmNhaSanXuat(this);

            //if (KiemTraQuyenChiTiet(fNhaSanXuat.Name.ToString()) == false)
            //{
            //    MessageBox.Show("Bạn Chưa Có Quyền Truy Cập Chức Năng Này !");
            //    return;
            //}

            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fNhaSanXuat.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
               
            
            if (DSNSXIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhaSanXuat;
                return;
            }
            
            fNhaSanXuat.TopLevel = false;
            fNhaSanXuat.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fNhaSanXuat.Dock = DockStyle.Fill;

            pvNhaSanXuat = new Telerik.WinControls.UI.RadPageViewPage();
            pvNhaSanXuat.Text = "Nhà sản xuất";
            MainPageView.Pages.Add(pvNhaSanXuat);
            pvNhaSanXuat.Controls.Add(fNhaSanXuat);
            fNhaSanXuat.Show();
            MainPageView.SelectedPage = pvNhaSanXuat;
            DSNSXIsOpen = true;
        }
        #endregion

        private void rbtnDong_Click(object sender, EventArgs e)
        {
            if (MainPageView.SelectedPage == null)
            {
                return;
            }

            if (MainPageView.SelectedPage == pvBoPhan)
            {
                DSBoPhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDVT)
            {
                DSDonViTinhIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNhomSP)
            {
                DSNhomSPIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvSanPham)
            {
                DSSanPhamIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNhanVien)
            {
                DSNhanVienIsOpen = false;
            }

            if (MainPageView.SelectedPage == pvNhaSanXuat)
            {
                DSNSXIsOpen = false;
            }

            if (MainPageView.SelectedPage == pvNhaPhanPhoi)
            {
                DSNPPIsOpen = false;
            }

            if (MainPageView.SelectedPage == pvBaoCaoCty)
            {
                DSBaoCaoCtyisOpen = false;
            }
            if (MainPageView.SelectedPage == pvBaoCaoNT)
            {
                DSBaoCaoNTisOpen = false;
            }

            if (MainPageView.SelectedPage == pvThanhPho)
            {
                DSThanhPhoIsOpen = false;
            }

            if (MainPageView.SelectedPage == pvQuan)
            {
                DSQuanIsOpen = false;
            }

            if (MainPageView.SelectedPage == pvQuocGia)
            {
                DSQuocGiaIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvHoatChat)
            {
                DSHoatChatIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDangBaoChe)
            {
                DSDangBaoCheIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvHeSoQuiDoi)
            {
                DSHeSoQuiDoiIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNhaThuoc)
            {
                DSNhaThuocIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvLoaiGia)
            {
                DSLoaiGiaIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvGiamGia)
            {
                DSGiamGiaIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvKho)
            {
                DSKhoIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDonHangXuat)
            {
                DSDonHangXuatIsOpen = false;
            }
            
            //if (MainPageView.SelectedPage == pvDonHangMua)
            //{
            //    DSDonHangMuaIsOpen = false;
            //}

            if (MainPageView.SelectedPage == pvNhapKho)
            {
                DSNhapKhoIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNhapKhoXacNhan)
            {
                DSNhapKhoXacNhanIsOpen = false;
            }

            if (MainPageView.SelectedPage == pvPhieuXuatKho)
            {
                DSPhieuXuatKho_DSIsOpen = false;
            }

            if (MainPageView.SelectedPage == pvUser)
            {
                DSUserIsOpen = false;
            }

            if (MainPageView.SelectedPage == pvNhomNguoiDung)
            {
                DSNhomNguoiDungIsOpen = false;
            }
    
            //if (MainPageView.SelectedPage == pvPhanQuyen)
            //{
            //    DSPhanQuyenIsOpen = false;
            //}

            if (MainPageView.SelectedPage == pvDoiMatKhau)
            {
                DSDoiMatKhauIsOpen = false;
            }

            if (MainPageView.SelectedPage == pvCauHinhHeThong)
            {
                DSCauHinhHeThongIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvCauHinhNT)
            {
                DSCauHinhNTIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvSanPham_NSX)
            {
                DSSanPham_NSXIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvSanPham_NPP)
            {
                DSSanPham_NPPIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvSanPham_Kho)
            {
                DSSanPham_KhoIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDonHangXuatXacNhan)
            {
                DSDonHangXuatXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNhapXuatTon)
            {
                DSNhapXuatTonIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvKiemTraXuatKho)
            {
                DSKiemTraXuatKhoIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDongGoi)
            {
                DSDongGoiIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_LayPhieuXuat)
            {
                DSNT_LayPhieuXuatIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_LayPhieuDieuChinhTonKho)
            {
                DSNT_LayPhieuDieuChinhTonKhoIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_LayDanhMuc)
            {
                DSNT_LayDanhMucIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_SanPham_Kho)
            {
                DSNT_SanPham_KhoIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_NhapKho)
            {
                DSNT_NhapKhoIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_KetCa)
            {
                DSNT_KetCaIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_NhapKhoXacNhan)
            {
                DSNT_NhapKhoXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_BanHang)
            {
                DSNT_BanHangIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_NhapXuatTon)
            {
                DSNT_NhapXuatTonIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvBangDanhMuc)
            {
                DSBangDanhMucIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_TraHang)
            {
                DSNT_TraHangisOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_ChuyenHang)
            {
                DSNT_ChuyenHangisOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_ChuyenHangXacNhan)
            {
                DSNT_ChuyenHangXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvChuyenKho)
            {
                DSChuyenKhoIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvChuyenKhoXacNhan)
            {
                DSChuyenKhoXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNhanChuyenHang)
            {
                DSNhanCHuyenHangIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNhanChuyenHangXacNhan)
            {
                DSNhanCHuyenHangXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_NhanPhieuChuyen)
            {
                DSNT_NhanPhieuChuyenIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_LayPhieuChuyen)
            {
                DSNT_LayPhieuChuyenIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_LayPhieuDieuChinhHSD)
            {
                DSNT_LayPhieuDieuChinhHSDIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_NhanPhieuChuyenXacNhan)
            {
                DSNT_NhanPhieuChuyenXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_TraHangVeCty)
            {
                DSNT_TraHangVeCtyIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_TraHangVeCtyXacNhan)
            {
                DSNT_TraHangVeCtyXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNhanTraHang)
            {
                DSNhanTraHangIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNhanTraHangXacNhan)
            {
                DSNhanTraHangXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDieuChinhTon)
            {
                DSDieuChinhTonIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDieuChinhTonXacNhan)
            {
                DSDieuChinhTonXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_DieuChinhTon)
            {
                DSNT_DieuChinhTonIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_DieuChinhTonXacNhan)
            {
                DSNT_DieuChinhTonXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDieuChinhHSD)
            {
                DSDieuChinhHSDIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDieuChinhHSDXacNhan)
            {
                DSDieuChinhHSDXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_DieuChinhHSD)
            {
                DSNT_DieuChinhHSDIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_DieuChinhHSDXacNhan)
            {
                DSNT_DieuChinhHSDXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_DatHang)
            {
                DSNT_DatHangIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_DatHangXacNhan)
            {
                DSNT_DatHangXacNhanIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvXuatNhanh)
            {
                DSXuatNhanhisOpen = false;
            }
            if (MainPageView.SelectedPage == pvXuatNhanhXacNhan)
            {
                DSXuatNhanhXacNhanisOpen = false;
            }
            if (MainPageView.SelectedPage == pvPhanQuyen)
            {
                DSPhanQuyenIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDonHangMuaTong)
            {
                DSDonHangMuaTongIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvDonHangMua)
            {
                DSDonHangMuaIsOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_ThayDoiGiaSP)
            {
                DSNT_ThayDoiGiaSPisOpen = false;
            }
            if (MainPageView.SelectedPage == pvChuKy)
            {
                DSChuKyisOpen = false;
            }
            if (MainPageView.SelectedPage == pvNT_LichSuGiaBan)
            {
                DSNT_LichSuGiaBanIsOpen = false;
            }
            MainPageView.Controls.Remove(MainPageView.SelectedPage);
        }

        private void rbtnThemMoi_Click(object sender, EventArgs e)
        {
            if (MainPageView.SelectedPage == null)
            {
                return;
            }
            //Xử lý hiện form thêm Bộ phận khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvBoPhan) && (frmBoPhanEditisOpen_==false))
            {
                fBoPhanEdit_ = new frmBoPhanEdit(this);
                fBoPhanEdit_.Show();
                frmBoPhanEditisOpen_ = true;
                return;
            }
            else 
                
                if ((MainPageView.SelectedPage == pvBoPhan) && (frmBoPhanEditisOpen_ == true))
            {
                fBoPhanEdit_.Select();
                return;
            }
            #endregion

            //Sử lý hiện form thêm nhóm nguoi dung khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvNhomNguoiDung) && (frmNhomNguoiDungEditisOpen_ == false))
            {
                fNhomNguoiDungEdit_ = new frmNhomNguoiDungEdit(this);
                fNhomNguoiDungEdit_.Show();
                frmNhomNguoiDungEditisOpen_ = true;
                return;
            }
            else

                if ((MainPageView.SelectedPage == pvNhomNguoiDung) && (frmNhomNguoiDungEditisOpen_ == true))
                {
                    fNhomNguoiDungEdit_.Select();
                    return;
                }
            #endregion

            //Xử lý hiện form thêm Phân quyền khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvPhanQuyen) && (frmPhanQuyenEditisOpen_ == false))
            {
                fPhanQuyenEdit_ = new frmPhanQuyenEdit(this);
                fPhanQuyenEdit_.Show();
                frmPhanQuyenEditisOpen_ = true;
                return;
            }
            else

                if ((MainPageView.SelectedPage == pvPhanQuyen) && (frmPhanQuyenEditisOpen_ == true))
                {
                    fPhanQuyenEdit_.Select();
                    return;
                }
            #endregion

            //Xử lý hiện form thêm DVT khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvDVT) && (frmDVTEditisOpen_ == false))
            {
                fDVTEdit_ = new frmDVTEdit(this);
                fDVTEdit_.Show();
                frmDVTEditisOpen_ = true;
                return;
            }
            else if ((MainPageView.SelectedPage == pvDVT) && (frmDVTEditisOpen_ == true))
            {
                fDVTEdit_.Select();
                return;
            }
            #endregion

            //Xử lý hiện form thêm Nhom SP khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvNhomSP) && (frmNhomSPEditisOpen_ == false))
            {
                fNhomSPEdit_ = new frmNhomSPEdit(this);
                fNhomSPEdit_.Show();
                frmNhomSPEditisOpen_ = true;
                return;
            }
            else if ((MainPageView.SelectedPage == pvNhomSP) && (frmNhomSPEditisOpen_ == true))
            {
                fNhomSPEdit_.Select();
                return;
            }
            #endregion

            //Xử lý hiện form thêm SP khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvSanPham) && (frmSanPhamEditisOpen_ == false))
            {
                fSanPhamEdit_ = new frmSanPhamEdit(this);
                fSanPhamEdit_.Show();
                frmSanPhamEditisOpen_ = true;
                return;
            }
            else if ((MainPageView.SelectedPage == pvSanPham) && (frmSanPhamEditisOpen_ == true))
            {
                fSanPhamEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form thêm quận khi click btn thêm mới
            #region Xử lý danh mục quận
            if ((MainPageView.SelectedPage == pvQuan) && (frmQuanEditisOpen_ == false))
            {
                fQuanEdit_ = new frmQuanEdit(this);
                this.BangQuanCanSua_ = null;
                this.MaQuanCanSua_ = null;
                this.fQuanEdit_.txtTenQuan.Text = "";
                this.fQuanEdit_.txtGhiChu.Text = "";
                this.fQuanEdit_.ckKhongDung.Checked = false;
                fQuanEdit_.Show();
                frmQuanEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvQuan) && (frmQuanEditisOpen_ == true))
            {
                fQuanEdit_.Select();
                return;
            }
            #endregion
            
            //Tân: Xử lý hiện form thêm thành phố khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvThanhPho) && (frmThanhPhoEditisOpen_ == false))
            {
                fThanhPhoEdit_ = new frmThanhPhoEdit(this);
                this.MaThanhPhoCanSua_ = null;
                this.fThanhPhoEdit_.txtGhiChu.Text = "";
                this.fThanhPhoEdit_.txtTenTP.Text  = "";
                this.ckXemTatCa.Checked = false;
                fThanhPhoEdit_.Show();
                frmThanhPhoEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvThanhPho) && (frmThanhPhoEditisOpen_ == true))
            {
                fThanhPhoEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm dạng bào chế khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvDangBaoChe) && (frmDBCEditisOpen_ == false))
            {
                BangDBCCanSua_ = null;
                MaDBCCanSua_ = null;
                fDBCEdit_ = new frmDBCEdit(this);
                //fDBCEdit_.txtTenDBC.Text = "";
                //fDBCEdit_.txtGhiChu.Text = "";
                //fDBCEdit_.ckKhongDung.Checked = false;
                fDBCEdit_.Show();
                frmDBCEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvDangBaoChe) && (frmDBCEditisOpen_ == true))
            {
                fDBCEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm giảm giá khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvGiamGia) && (frmGiamGiaEditisOpen_ == false))
            {
                BangGiamGiaCanSua_ = null;
                MaGiamGiaCanSua_ = null;
                fGiamGiaEdit_ = new frmGiamGiaEdit(this);
                fGiamGiaEdit_.Show();
                frmGiamGiaEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvGiamGia) && (frmGiamGiaEditisOpen_ == true))
            {
                fGiamGiaEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm quốc gia khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvQuocGia) && (frmQuocGiaEditisOpen_ == false))
            {
                BangQuocGiaCanSua_ = null;
                MaQuocGiaCanSua_ = null;
                fQuocGiaEdit_ = new frmQuocGiaEdit(this);
                fQuocGiaEdit_.Show();
                frmQuocGiaEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvQuocGia) && (frmQuocGiaEditisOpen_ == true))
            {
                fQuocGiaEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm Kho khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvKho) && (frmKhoEditisOpen_ == false))
            {
                BangKhoCanSua_ = null;
                MaKhoCanSua_ = null;
                fKhoEdit_ = new frmKhoEdit(this);
                //fKhoEdit_.txtTenKho.Text = "";
                //fKhoEdit_.txtGhiChu.Text = "";
                //fKhoEdit_.ckKhongDung.Checked = false;
                fKhoEdit_.Show();
                frmKhoEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvKho) && (frmKhoEditisOpen_ == true))
            {
                fKhoEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm Phân Loại Giá khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvLoaiGia) && (frmPhanLoaiGiaEditisOpen_ == false))
            {
                BangPhanLoaiGiaCanSua_ = null;
                MaPhanLoaiGiaCanSua_ = null;
                fPhanLoaiGiaEdit_ = new frmPhanLoaiGiaEdit(this);
                //fPhanLoaiGiaEdit_.txtLoaiGia.Text = "";
                //fPhanLoaiGiaEdit_.txtGhiChu.Text = "";
                //fPhanLoaiGiaEdit_.ckKhongDung.Checked = false;
                fPhanLoaiGiaEdit_.Show();
                frmPhanLoaiGiaEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvLoaiGia) && (frmPhanLoaiGiaEditisOpen_ == true))
            {
                fPhanLoaiGiaEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form Thêm nhân viên khi click btn Thêm mới
            #region
            if ((MainPageView.SelectedPage == pvNhanVien) && (frmNhanVienEditisOpen_ == false))
            {
                fNhanVienEdit_ = new frmNhanVienEdit(this);
                fNhanVienEdit_.Show();
                frmNhanVienEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvNhanVien) && (frmNhanVienEditisOpen_ == true))
            {
                fNhanVienEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm nhà thuốc khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvNhaThuoc) && (frmNhaThuocEditisOpen_ == false))
            {
                BangNhaThuocCanSua_ = null;
                MaNhaThuocCanSua_ = null;
                fNhaThuocEdit_ = new frmNhaThuocEdit(this);
                fNhaThuocEdit_.Show();
                frmNhaThuocEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvNhaThuoc) && (frmNhaThuocEditisOpen_ == true))
            {
                fNhaThuocEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form Thêm hoạt chất khi click btn Thêm mới
            #region
            if ((MainPageView.SelectedPage == pvHoatChat) && (frmNhanVienEditisOpen_ == false))
            {
                fHoatChatEdit_ = new frmHoatChatEdit(this);
                fHoatChatEdit_.Show();
                frmHoatChatEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvHoatChat) && (frmNhanVienEditisOpen_ == true))
            {
                fHoatChatEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử ký hiện form Thêm nhà phân phối khi click vào btn Thêm mới
            #region
            if (MainPageView.SelectedPage == pvNhaPhanPhoi && frmNhaPhanPhoiEditisOpen_ == false)
            {
                fNhaPhanPhoiEdit_ = new frmNhaPhanPhoiEdit(this);
                fNhaPhanPhoiEdit_.Show();
                frmNhaPhanPhoiEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvNhaPhanPhoi && frmNhaPhanPhoiEditisOpen_ == true)
            {
                fNhaPhanPhoiEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử ký hiện form Thêm nhà Sản xuất khi click vào btn Thêm mới
            #region
            if (MainPageView.SelectedPage == pvNhaSanXuat && frmNhaSanXuatEditisOpen_ == false)
            {
                fNhaSanXuatEdit_ = new frmNhaSanXuatEdit(this);
                fNhaSanXuatEdit_.Show();
                frmNhaSanXuatEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvNhaSanXuat && frmNhaSanXuatEditisOpen_ == true)
            {
                fNhaSanXuatEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm nhập kho khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvNhapKho) && (frmNhapKhoEditisOpen_ == false))
            {
                BangNhapKhoCanSua_ = null;
                MaNhapKhoCanSua_ = null;
                kiemtraphieunhapkho = true;
                fNhapKhoEdit_ = new frmNhapKhoEdit(this);
                fNhapKhoEdit_.Show();
                frmNhapKhoEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvNhapKho) && (frmNhapKhoEditisOpen_ == true))
            {
                fNhapKhoEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử ký hiện form Thêm hệ số quy đổi edit khi click vào btn Thêm mới
            #region
            if (MainPageView.SelectedPage == pvHeSoQuiDoi && frmHeSoQuiDoiEditisOpen_ == false)
            {
                fHeSoQuiDoiEdit_ = new frmHeSoQuiDoiEdit(this);
                fHeSoQuiDoiEdit_.Show();
                frmHeSoQuiDoiEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvHeSoQuiDoi && frmHeSoQuiDoiEditisOpen_ == true)
            {
                fHeSoQuiDoiEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử ký hiện form Thêm Đơn hàng xuất edit khi click vào btn Thêm mới
            #region
            
            if (MainPageView.SelectedPage == pvDonHangXuat && frmDonHangXuatEditisOpen_ == false)
            {
                Fr_DangXuLy.ShowFormCho();
                fDonHangXuatEdit_ = new frmDonHangXuatEdit(this);
                fDonHangXuatEdit_.Show();
                frmDonHangXuatEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvDonHangXuat && frmDonHangXuatEditisOpen_ == true)
            {
                fDonHangXuatEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form Đóng gói edit khi click vào btn Thêm mới
            #region
            if (MainPageView.SelectedPage == pvDongGoi && frmDongGoiEditisOpen_ == false)
            {
                fDongGoiEdit_ = new frmDongGoiEdit(this);
                fDongGoiEdit_.Show();
                frmDongGoiEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvDongGoi && frmDongGoiEditisOpen_ == true)
            {
                fDongGoiEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form Bán hàng edit khi click vào btn Thêm mới
            #region
            if (MainPageView.SelectedPage == pvNT_BanHang && frmNT_BanHangEditisOpen_ == false)
            {
                fNT_BanHangEdit_ = new frmNT_BanHangEdit(this);
                fNT_BanHangEdit_.Show();
                frmNT_BanHangEditisOpen_ = true;
                return;
            }
            else if (MainPageView.SelectedPage == pvNT_BanHang && frmNT_BanHangEditisOpen_ == true)
            {
                fNT_BanHangEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form trả hàng edit khi click vào btn Thêm mới
            #region
            if (MainPageView.SelectedPage == pvNT_TraHang && frmNT_TraHangEditisOpen_ == false)
            {
                fNT_TraHangEdit_ = new frmNT_TraHangEdit(this);
                fNT_TraHangEdit_.Show();
                frmNT_TraHangEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvNT_TraHang && frmNT_TraHangEditisOpen_ == true)
            {
                fNT_TraHangEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm Phiếu Xuất Kho khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvPhieuXuatKho) && (frmPhieuXuatKhoisOpen_ == false))
            {
                fPhieuXuatKho = new frmPhieuXuatKho(this);
                fPhieuXuatKho.Show();
                frmPhieuXuatKhoisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvPhieuXuatKho) && (frmPhieuXuatKhoisOpen_ == true))
            {
                fPhieuXuatKho.Select();
                return;
            }
            #endregion
            
            //Tân: Xử lý hiện form chuyển hàng edit khi click btn thêm mới
            #region
            if (MainPageView.SelectedPage == pvNT_ChuyenHang && frmNT_ChuyenHangEditisOpen_ == false)
            {
                fNT_ChuyenHangEdit_ = new frmNT_ChuyenHangEdit(this);
                fNT_ChuyenHangEdit_.Show();
                frmNT_ChuyenHangEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvNT_ChuyenHang && frmNT_ChuyenHangEditisOpen_ == true)
            {
                fNT_ChuyenHangEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form chuyển hàng edit khi click btn thêm mới
            #region
            if (MainPageView.SelectedPage == pvNT_NhanPhieuChuyen && frmNT_NhanPhieuChuyenEditisOpen_ == false)
            {
                fNT_NhanPhieuChuyenEdit = new frmNT_NhanPhieuChuyenEdit(this);
                fNT_NhanPhieuChuyenEdit.Show();
                frmNT_NhanPhieuChuyenEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvNT_ChuyenHang && frmNT_NhanPhieuChuyenEditisOpen_ == true)
            {
                fNT_NhanPhieuChuyenEdit.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form trả hàng về cty edit khi click btn thêm mới
            #region
            if (MainPageView.SelectedPage == pvNT_TraHangVeCty && frmNT_TraHangVeCTyEditisOpen_ == false)
            {
                fNT_TraHangVeCtyEdit = new frmNT_TraHangVeCtyEdit(this);
                fNT_TraHangVeCtyEdit.Show();
                frmNT_TraHangVeCTyEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvNT_TraHangVeCty && frmNT_TraHangVeCTyEditisOpen_ == true)
            {
                fNT_TraHangVeCtyEdit.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form nhận trả hàng edit khi click btn thêm mới
            #region
            if (MainPageView.SelectedPage == pvNhanTraHang && frmNhanTraHangEditisOpen_ == false)
            {
                fNhanTraHangEdit_ = new frmNhanTraHangEdit(this);
                fNhanTraHangEdit_.Show();
                frmNhanTraHangEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvNhanTraHang && frmNhanTraHangEditisOpen_ == true)
            {
                fNhanTraHangEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form chu kỳ edit khi click btn thêm mới
            #region
            if (MainPageView.SelectedPage == pvChuKy && frmChuKyEditisOpen_ == false)
            {
                fChuKyEdit = new FrmChuKyEdit(this);
                fChuKyEdit.Show();
                frmChuKyEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvChuKy && frmChuKyEditisOpen_ == true)
            {
                fChuKyEdit.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form đặt hàng edit khi click btn thêm mới
            #region
            //if (MainPageView.SelectedPage == pvNT_DatHang && frmNT_DatHangEditisOpen_ == false)
            //{
            //    fNT_DatHangEdit_ = new frmNT_DatHangEdit(this);
            //    fNT_DatHangEdit_.Show();
            //    frmNT_DatHangEditisOpen_ = true;
            //}
            //else if (MainPageView.SelectedPage == pvNT_DatHang && frmNT_DatHangEditisOpen_ == true)
            //{
            //    fNT_DatHangEdit_.Select();
            //    return;
            //}
            if (MainPageView.SelectedPage == pvNT_DatHang && frmNT_DatHangEditAccessisOpen_ == false)
            {
                fNT_DatHangEditAccess_ = new frmNT_DatHangEditAccess(this);
                fNT_DatHangEditAccess_.Show();
                frmNT_DatHangEditAccessisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvNT_DatHang && frmNT_DatHangEditAccessisOpen_ == true)
            {
                fNT_DatHangEditAccess_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form xuất nhanh edit khi click btn thêm mới
            #region
            if (MainPageView.SelectedPage == pvXuatNhanh && frmXuatNhanhEditisOpen_ == false)
            {
                fXuatNhanhEdit_ = new frmXuatNhanhEdit(this);
                fXuatNhanhEdit_.Show();
                frmXuatNhanhEditisOpen_ = true;
            }
            else if (MainPageView.SelectedPage == pvXuatNhanh && frmXuatNhanhEditisOpen_ == true)
            {
                fXuatNhanhEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm chuyển kho khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvChuyenKho) && (frmChuyenKhoEditisOpen_ == false))
            {
                BangChuyenKho_ = null;
                MaChuyenKho_ = null;
                fChuyenKhoEdit_ = new frmChuyenKhoEdit(this);
                fChuyenKhoEdit_.Show();
                frmChuyenKhoEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvChuyenKho) && (frmChuyenKhoEditisOpen_ == true))
            {
                fChuyenKhoEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm Điều chỉnh tồn kho khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvDieuChinhTon) && (frmDieuChinhTonEditisOpen_ == false))
            {
                BangDieuChinhTon_ = null;
                MaDieuChinhTon_ = null;
                fDieuChinhTonEdit_ = new frmDieuChinhTonEdit(this);
                fDieuChinhTonEdit_.Show();
                frmDieuChinhTonEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvDieuChinhTon) && (frmDieuChinhTonEditisOpen_ == true))
            {
                fDieuChinhTonEdit_.Select();
                return;
            }
            #endregion
            //Hà: Xử lý hiện form thêm Điều chỉnh tồn kho khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvDieuChinhHSD) && (frmDieuChinhHSDEditisOpen_ == false))
            {
                BangDieuChinhHSD_ = null;
                MaDieuChinhHSD_ = null;
                fDieuChinhHSDEdit_ = new frmDieuChinhHSDEdit(this);
                fDieuChinhHSDEdit_.Show();
                frmDieuChinhHSDEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvDieuChinhHSD) && (frmDieuChinhHSDEditisOpen_ == true))
            {
                fDieuChinhHSDEdit_.Select();
                return;
            }
            #endregion

            //Hà: Xử lý hiện form thêm Tài Khoản khi click btn thêm mới
            #region
            if ((MainPageView.SelectedPage == pvUser) && (frmUserEditisOpen_ == false))
            {
                BangUserCanSua_ = null;
                MaUserCanSua_ = null;
                fUserEdit_ = new frmUserEdit(this);
                fUserEdit_.Show();
                frmUserEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvUser) && (frmUserEditisOpen_ == true))
            {
                fUserEdit_.Select();
                return;
            }
            #endregion

        }

               private void LoadDuLieuLenLuoi()
        {
            try
            {
                if (ckXemTatCa.Checked == true)
                {
                    IsXemTatCa_ = true;
                }
                else
                    IsXemTatCa_ = false;

                //Tân: Xử lý xem tất cả Bộ phận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvBoPhan)
                {
                    LopCSQLBoPhan = new CSQLBoPhan();
                    fBoPhan.rgvBoBan.DataSource = LopCSQLBoPhan.LoadDSBoPhanLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả DVT khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDVT)
                {
                    LopCSQLDVT = new CSQLDonViTinh();
                    fDVT.RefreshLuoiDSDVT();
                }
                #endregion

                //Tân: Xử lý xem tất cả NhomSP khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhomSP)
                {
                    LopCSQLNhomSP = new CSQLNhomSP();
                    fNhomSP_.RefreshLuoiDSNhomSP();
                }
                #endregion

                //Tân: Xử lý xem tất cả SanPham khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvSanPham)
                {
                    LopCSQLSanPham = new CSQLSanPham();
                    fSanPham.RefreshLuoiDSSanPham();
                }
                #endregion

                //Tân: Xử lý xem tất cả quận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvQuan)
                {
                    CSQLQuan xlquan = new CSQLQuan();
                    fQuan.rgvQuan.DataSource = xlquan.LayDanhSachQuanLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: Xử lý xem tất cả Dạng bào chế khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDangBaoChe)
                {
                    CSQLDBC xldbc = new CSQLDBC();
                    fDBC.rgvDBC.DataSource = xldbc.LayDanhSachDBCLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: Xử lý xem tất cả Giảm Giá khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvGiamGia)
                {
                    CSQLGiamGia xlgiamgia = new CSQLGiamGia();
                    fGiamGia.rgvGiamGia.DataSource = xlgiamgia.LayDanhSachGiamGiaLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: Xử lý xem tất cả Quốc Gia khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvQuocGia)
                {
                    CSQLQuocGia qg_ = new CSQLQuocGia();
                    fQuocGia.rgvDSQuocGia.DataSource = qg_.LayDSQuocGiaLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: Xử lý xem tất cả Phân Loại Giá khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvLoaiGia)
                {
                    CSQLPhanLoaiGia xlphanloaigia = new CSQLPhanLoaiGia();
                    fPhanLoaiGia.rgvPhanLoaiGia.DataSource = xlphanloaigia.LayDanhSachPhanloaiGiaLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: Xử lý xem tất cả Kho khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvKho)
                {
                    CSQLKho xlkho = new CSQLKho();
                    fKho.rgvKho.DataSource = xlkho.LayDanhSachKhoLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: Xử lý xem tất cả Nhà thuốc khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhaThuoc)
                {
                    CSQLNhaThuoc xlnhathuoc = new CSQLNhaThuoc();
                    fNhaThuoc.rgvNhaThuoc.DataSource = xlnhathuoc.LayDanhSachNhaThuocLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả thành phố khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvThanhPho)
                {
                    CSQLThanhPho xlthanhpho = new CSQLThanhPho();
                    fThanhPho.rgvThanhPho.DataSource = xlthanhpho.LayThongTinThanhPho(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả nhân viên khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhanVien)
                {
                    CSQLNhanVien xlnv = new CSQLNhanVien();
                    fNhanVien.rgvNhanVien.DataSource = xlnv.LayThongTinNhanVienLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả hoạt chất khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvHoatChat)
                {
                    CSQLHoatChat xlhc = new CSQLHoatChat();
                    fHoatChat.rgvHoatChat.DataSource = xlhc.LayHoatChatLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả NPP khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhaPhanPhoi)
                {
                    CSQLNPP xlnpp = new CSQLNPP();
                    fNhaPhanPhoi.rgvNPP.DataSource = xlnpp.LayNPPLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả NSX khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhaSanXuat)
                {
                    CSQLNSX xlnsx = new CSQLNSX();
                    fNhaSanXuat.rgvNSX.DataSource = xlnsx.LayNSXLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: Xử lý xem tất cả SP_NSX khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvSanPham_NSX)
                {
                    CSQLSanPham_NSX sanpham_nsx = new CSQLSanPham_NSX();

                    fSanPham_NSX.rgvSP_NSX.DataSource = sanpham_nsx.LayDanhSachSanPham_NSXLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: Xử lý xem tất cả SP_Kho khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvSanPham_Kho)
                {
                    CSQLSanPham_Kho sanpham_kho = new CSQLSanPham_Kho();
                    fSanPham_Kho.rgvSP_Kho.DataSource = sanpham_kho.LayDanhSachSanPham_KhoLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả Nhập Kho khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhapKho)
                {
                    fNhapKho.rgvDSPhieuNhap_LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả Nhập Kho Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhapKhoXacNhan)
                {
                    CSQLNhapKho xlnhapkho = new CSQLNhapKho();
                    fNhapKhoXacNhan.rgvDSPhieuNhapXacNhan.DataSource = xlnhapkho.LayDanhSachNhapKhoXacNhanLenLuoi(true, false);
                }
                #endregion

                //Tân: Xử lý xem tất cả Đơn hàng xuất khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDonHangXuat)
                {
                    CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                    fDonHangXuat.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả Đơn hàng xuất Xac Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDonHangXuatXacNhan)
                {
                    CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                    fDonHangXuatXacNhan.rgvDSXacNhanDonHang_LayDuLieu(dhx.LayDLLenLuoiXacNhan());
                }
                #endregion

                //Hà: Xử lý xem tất cả Phiếu Xuất Kho khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvPhieuXuatKho)
                {
                    //CSQLPhieuXuat px_ = new CSQLPhieuXuat();
                    //fPhieuXuatKho_DS.rgvDSPhieuXK.DataSource = px_.LayDanhSachLenLuoi(IsXemTatCa_);
                    fPhieuXuatKho_DS.LoadLenLuoi();
                }
                #endregion

                //Hà: Xử lý xem tất cả Kiểm Tra Xuất Kho khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvKiemTraXuatKho)
                {
                    CSQLKiemTraXuatKho ktxk_ = new CSQLKiemTraXuatKho();
                    fKiemTraXuatKho.rgvKiemTraXuatKho.DataSource = ktxk_.KiemTraXuatKho_LoadLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả Đóng gói khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDongGoi)
                {
                    fDongGoi.RefreshRGVDongGoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả Xuất nhanh khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvXuatNhanh)
                {
                    fXuatNhanh.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả Xuất nhanh Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvXuatNhanhXacNhan)
                {
                    fXuatNhanhXacNhan.LoadLenLuoi();
                }
                #endregion

                //Hà: Xử lý xem tất cả Chuyển Kho khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvChuyenKho)
                {
                    CSQLChuyenKho ck_ = new CSQLChuyenKho();
                    fChuyenKho.rgvChuyenKho.DataSource = ck_.LoadChuyenKhoLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: Xử lý xem tất cả Chuyển Kho Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvChuyenKhoXacNhan)
                {
                    CSQLChuyenKho xlchuyenkho = new CSQLChuyenKho();
                    fChuyenKhoXacNhan.rgvChuyenKho.DataSource = xlchuyenkho.LayDanhSachChuyenKhoXacNhanLenLuoi(true, false);
                }
                #endregion

                //Tân: Xử lý xem tất cả Nhận Trả Hàng khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhanTraHang)
                {
                    fNhanTraHang.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả Nhận Trả Hàng Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhanTraHangXacNhan)
                {
                    fNhanTraHangXacNhan.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả Nhận Chuyển Hàng khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhanChuyenHang)
                {
                    CSQLNhanChuyenHang nch_ = new CSQLNhanChuyenHang();
                    fNhanChuyenHang.rgvNhanChuyenHang.DataSource = nch_.LoadNhanChuyenHangLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả Nhận Chuyển Hàng Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhanChuyenHangXacNhan)
                {
                    CSQLNhanChuyenHang nch = new CSQLNhanChuyenHang();
                    fNhanChuyenHangXacNhan.rgvPhieuChuyenHang.DataSource = nch.LayDSNhanChuyenHangXacNhanLenLuoi(true, false);
                }
                #endregion

                //Tân: Xử lý xem tất cả Điều Chỉnh Tồn khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDieuChinhTon)
                {
                    CSQLDieuChinhTon dct_ = new CSQLDieuChinhTon();
                    fDieuChinhTon.rgvPhieuDCTon.DataSource = dct_.LoadDieuChinhTonLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả Điều Chỉnh Tồn Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDieuChinhTonXacNhan)
                {
                   // CSQLDieuChinhTon xldctk = new CSQLDieuChinhTon();
                   //fDieuChinhTonXacNhan.rgvPhieuDieuChinh.DataSource = xldctk.LayDanhSachDieuChinhTonKhoXacNhanLenLuoi(true, false);
                }
                #endregion

                //Tân: Xử lý xem tất cả User khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvUser)
                {
                    CSQLUser user_ = new CSQLUser();
                   fUser.rgvUser.DataSource = user_.LayDSUserLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả Nhóm Người Dùng khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNhomNguoiDung)
                {
                    CSQLNhomNguoiDung nndung_ = new CSQLNhomNguoiDung();
                   fNhomNguoiDung.rgvNhomNguoiDung.DataSource = nndung_.LayDSNhomNguoiDungLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả Phân Quyền khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvPhanQuyen)
                {
                    CSQLQuyenTruyCap qtc = new CSQLQuyenTruyCap();
                    fPhanQuyen.rgvPhanQuyen.DataSource = qtc.LoadLenLuoi();
                }
                #endregion

                //Hà: Xử lý xem tất cả NT_ Nhập Kho khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_NhapKho)
                {
                    CSQLNT_NhapKho nt_nhapkho = new CSQLNT_NhapKho();
                    fNT_NhapKho.rgvDSPhieuNhap.DataSource = nt_nhapkho.LayDanhSachLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_ Nhập Kho Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_NhapKhoXacNhan)
                {
                    CSQLNT_XacNhanNhapKho xnnk = new CSQLNT_XacNhanNhapKho();
                    fNT_NhapKhoXacNhan.rgvDSPhieuNhap.DataSource = xnnk.LayDSNTXacNhanNhapKhoLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_Thay Đổi Giá khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_ThayDoiGiaSP)
                {
                    fNT_ThayDoiGiaSP.LoadLenLuoi();
                }
                #endregion
                
                //Tân: Xử lý xem tất cả NT_Chuyển Hàng khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_ChuyenHang)
                {
                    fNT_ChuyenHang.LayDSChuyenHangLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_Chuyển Hàng Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_ChuyenHangXacNhan)
                {
                    //CSQLNT_ChuyenHang ch = new CSQLNT_ChuyenHang();
                    //fNT_ChuyenHangXacNhan_.rgvChuyenHang.DataSource = ch.LayChuyenHangLenLuoiXacNhan(false);
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_Nhận Phiếu Chuyển khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_NhanPhieuChuyen)
                {
                    fNT_NhanPhieuChuyen.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_Nhận Phiếu Chuyển Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_NhanPhieuChuyenXacNhan)
                {
                    //CSQLNT_NhanPhieuChuyen npc = new CSQLNT_NhanPhieuChuyen();
                    //fNT_NhanPhieuChuyenXacNhan.rgvPhieuChuyen.DataSource = npc.LoadLenLuoiXacNhan();
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_Trả Hàng Về Cty khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_TraHangVeCty)
                {
                    fNT_TraHangVeCty.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_Trả Hàng Về Cty Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_TraHangVeCtyXacNhan)
                {
                    //CSQLNT_TraHangVeCty ch = new CSQLNT_TraHangVeCty();
                    //fNT_TraHangVeCtyXacNhan.rgvPhieuTra.DataSource = ch.LayTraHangLenLuoiXacNhan(false);
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_Đặt Hàng khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_DatHang)
                {
                    fNT_DatHang.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_Đặt Hàng Xác Nhận khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_DatHangXacNhan)
                {
                    //fNT_DatHangXacNhan.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả DS don hang mua tong khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDonHangMuaTong)
                {
                    fDonHangMuaTong.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả Điều Chỉnh Hạn Dùng khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDieuChinhHSD)
                {
                    CSQLDieuChinhHSD dct_ = new CSQLDieuChinhHSD();
                    fDieuChinhHSD.rgvPhieuDCHSD.DataSource = dct_.LoadDieuChinhHSDLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả NT_ Điều Chỉnh Hạn Dùng khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_DieuChinhHSD)
                {
                    CSQLNT_DieuChinhHSD dct_ = new CSQLNT_DieuChinhHSD();
                    fNT_DieuChinhHSD.rgvDieuChinhTon.DataSource = dct_.LoadNT_DieuChinhHSDLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xử lý xem tất cả DS Don hang mua khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvDonHangMua)
                {
                    fDonHangMua.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả Bán hàng khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_BanHang)
                {
                    fNT_BanHang.RefreshRGVBanHang();
                }
                #endregion

                //Tân: Xử lý xem tất cả Trả hàng khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_TraHang)
                {
                    fNT_TraHang.RefreshrgvTraHang();
                }
                #endregion

                //Tân: Xử lý xem tất cả Kết Ca khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvNT_KetCa)
                {
                    fNT_KetCa.LoadLenLuoi();
                }
                #endregion

                //Tân: Xử lý xem tất cả Chu kỳ khi chọn vào checkbox ['Xem tất cả']
                #region
                if (MainPageView.SelectedPage == pvChuKy)
                {
                    fChuKy.LoadLenLuoi();
                }
                #endregion
            }
            catch { }
        }

        //Hà: Hiện form fDBC vào Pageview fMain
        #region
        private void rbtnDangBaoChe_Click(object sender, EventArgs e)
        {
            fDBC = new frmDBC(this);
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            //if (KiemTraQuyenChiTiet(fDBC.Name.ToString()) == false)
            if(qtc.KiemTraQuyenXem(fDBC.Name) == false)
            {
                MessageBox.Show("Bạn Chưa Có Quyền Truy Cập Chức Năng Này !");
                return;
            }
            
            if (DSDangBaoCheIsOpen == true)
            {
                MainPageView.SelectedPage = pvDangBaoChe;
                return;
            }

            
            fDBC.TopLevel = false;
            fDBC.FormBorderStyle = FormBorderStyle.None;
            fDBC.Dock = DockStyle.Fill;

            pvDangBaoChe = new Telerik.WinControls.UI.RadPageViewPage();
            pvDangBaoChe.Text = "Dạng Bào Chế";
            MainPageView.Pages.Add(pvDangBaoChe);
            pvDangBaoChe.Controls.Add(fDBC);
            fDBC.Show();
            MainPageView.SelectedPage = pvDangBaoChe;
            DSDangBaoCheIsOpen = true;   
        }
        #endregion

        //Tân: Hiện form fQuan vào Pageview fMain
        #region
        private void radButtonElementQuan_Click(object sender, EventArgs e)
        {
            fQuan = new frmQuan(this);
            //if (KiemTraQuyenChiTiet(fQuan.Name.ToString()) == false)
            //{
            //    MessageBox.Show("Bạn Chưa Có Quyền Truy Cập Chức Năng Này !");
            //    return;
            //}

            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fQuan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            
            if (DSQuanIsOpen == true)
            {
                MainPageView.SelectedPage = pvQuan;
                return;
            }

            
            fQuan.TopLevel = false;
            fQuan.FormBorderStyle = FormBorderStyle.None;
            fQuan.Dock = DockStyle.Fill;

            pvQuan = new Telerik.WinControls.UI.RadPageViewPage();
            pvQuan.Text = "Quận";
            MainPageView.Pages.Add(pvQuan);
            pvQuan.Controls.Add(fQuan);
            fQuan.Show();
            MainPageView.SelectedPage = pvQuan;
            DSQuanIsOpen = true;
        }
        #endregion

        private void rbtnDVT_Click(object sender, EventArgs e)
        {
            if (DSDonViTinhIsOpen == true)
            {
                MainPageView.SelectedPage = pvDVT;
                return;
            }
            else
            {
                fDVT = new frmDVT(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fDVT.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fDVT.TopLevel = false;
                fDVT.FormBorderStyle = FormBorderStyle.None;
                fDVT.Dock = DockStyle.Fill;

                pvDVT = new Telerik.WinControls.UI.RadPageViewPage();
                pvDVT.Text = "Đơn Vị Tính";
                MainPageView.Pages.Add(pvDVT);
                pvDVT.Controls.Add(fDVT);
                fDVT.Show();
                MainPageView.SelectedPage = pvDVT;
                DSDonViTinhIsOpen = true;
            }
        }
        
        //Tân: Hiện form fThanhPho vào pageview fMain
        #region
        private void rbtnThanhPho_Click(object sender, EventArgs e)
        {
            if (DSThanhPhoIsOpen == true)
            {
                MainPageView.SelectedPage = pvThanhPho;
                return;
            }
            else
            {
                fThanhPho = new frmThanhPho(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fThanhPho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fThanhPho.TopLevel = false;
                fThanhPho.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fThanhPho.Dock = DockStyle.Fill;

                pvThanhPho = new Telerik.WinControls.UI.RadPageViewPage();
                pvThanhPho.Text = "Thành phố";
                MainPageView.Pages.Add(pvThanhPho);
                pvThanhPho.Controls.Add(fThanhPho);
                fThanhPho.Show();
                MainPageView.SelectedPage = pvThanhPho;
                DSThanhPhoIsOpen = true;
            }
        }
        #endregion

        private void rbtnSua_Click(object sender, EventArgs e)
        {
            if (MainPageView.SelectedPage == null)
            {
                return;
            }

            //Tuấn Anh: hiện form sửa thông tin bophan khi click btnsua frmMain
            #region
            if (MainPageView.SelectedPage == pvBoPhan)
            {
                fBoPhan.SelectRows_BoPhan();
                return;
            }
            #endregion

            if (MainPageView.SelectedPage == pvDVT)
            {
                fDVT.rgvDVT_DoubleClick(sender, e);
                return;
            }

            if (MainPageView.SelectedPage == pvNhomSP)
            {
                fNhomSP_.rgvNhomSP_DoubleClick(sender, e);
                return;
            }

            if (MainPageView.SelectedPage == pvSanPham)
            {
                fSanPham.SelectRows_SanPham();
                return;
            }

            //end Tuấn Anh

            //Tân: Xử lý hiện form sửa thông tin quận khi click btnsua frmMain
            #region Xử lý danh mục QUẬN
            if ((MainPageView.SelectedPage == pvQuan) && (frmQuanEditisOpen_ == false))
            {
                CSQLQuan xlquan = new CSQLQuan();
                this.MaQuanCanSua_ = this.fQuan.rgvQuan.CurrentRow.Cells["colQuanID"].Value.ToString();
                this.BangQuanCanSua_ = xlquan.LayQuanTheoMa(this.MaQuanCanSua_);
                fQuanEdit_ = new frmQuanEdit(this);
                //fQuanEdit_.btnQuanThemMoi.Enabled = false;
                fQuanEdit_.Show();
                frmQuanEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvQuan) && (frmQuanEditisOpen_ == true))
            {
                fQuanEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form sửa thông tin thành phố khi click btnsua frmMain
            #region
            if ((MainPageView.SelectedPage == pvThanhPho) && (frmThanhPhoEditisOpen_ == false))
            {
                CSQLThanhPho xlThanhPho = new CSQLThanhPho();
                this.MaThanhPhoCanSua_ = this.fThanhPho.rgvThanhPho.CurrentRow.Cells["colTPID"].Value.ToString();
                this.BangThanhPhoCanSua_ = xlThanhPho.LayThongTinThanhPhoTheoMa(this.MaThanhPhoCanSua_);
                fThanhPhoEdit_ = new frmThanhPhoEdit(this);
                fThanhPhoEdit_.Show();
                frmThanhPhoEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvThanhPho) && (frmThanhPhoEditisOpen_ == true))
            {
                fThanhPhoEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form sửa thông tin nhân viên khi click btnSua FrmMain
            #region
            if ((MainPageView.SelectedPage == pvNhanVien) && (frmNhanVienEditisOpen_ == false))
            {
                CSQLNhanVien xlNhanVien = new CSQLNhanVien();
                this.MaNhanVienCanSua_ = this.fNhanVien.rgvNhanVien.CurrentRow.Cells["colNVID"].Value.ToString();
                this.BangNhanVienCanSua_ = xlNhanVien.LayThongTinNhanVienTheoMa(this.MaNhanVienCanSua_);
                fNhanVienEdit_ = new frmNhanVienEdit(this);
                fNhanVienEdit_.Show();
                frmNhanVienEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvNhanVien) && (frmNhanVienEditisOpen_ == true))
            {
                fNhanVienEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form sửa thông tin hoat chat khi click btnSua FrmMain
            #region
            if (MainPageView.SelectedPage == pvHoatChat && frmHoatChatEditisOpen_ == false)
            {
                fHoatChat.rgvHoatChat_DoubleClick(sender, e);
                //frmHoatChatEditisOpen_ = true;
            }
            else if ((MainPageView.SelectedPage == pvHoatChat) && (frmHoatChatEditisOpen_ == true))
            {
                fHoatChatEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form sửa thông tin Nha Phan Phoi khi click btnSua FrmMain
            #region
            if (MainPageView.SelectedPage == pvNhaPhanPhoi && frmNhaPhanPhoiEditisOpen_ == false)
            {
                fNhaPhanPhoi.SelectRows_NPP();
            }
            else if (MainPageView.SelectedPage == pvNhaPhanPhoi && frmNhaPhanPhoiEditisOpen_ == true)
            {
                fNhaPhanPhoiEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form sửa thông tin Nha San xuat khi click btnSua FrmMain
            #region
            if (MainPageView.SelectedPage == pvNhaSanXuat && frmNhaSanXuatEditisOpen_ == false)
            {
                fNhaSanXuat.SelectRows_NSX();
            }
            else if (MainPageView.SelectedPage == pvNhaSanXuat && frmNhaSanXuatEditisOpen_ == true)
            {
                fNhaSanXuatEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form sửa thông tin HeSoQuiDoi khi click btnSua FrmMain
            #region
            if (MainPageView.SelectedPage == pvHeSoQuiDoi && frmHeSoQuiDoiEditisOpen_ == false)
            {
                fHeSoQuiDoi.SelectRows_HSQD(sender, e);
            }
            else if (MainPageView.SelectedPage == pvNhaSanXuat && frmHeSoQuiDoiEditisOpen_ == true)
            {
                fHeSoQuiDoiEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin DonHangXuat khi click btnSua FrmMain
            #region
            if (MainPageView.SelectedPage == pvDonHangXuat && frmDonHangXuatEditisOpen_ == false)
                fDonHangXuat.SelectRows_XuatKho();
            else if (MainPageView.SelectedPage == pvDonHangXuat && frmDonHangXuatEditisOpen_ == true)
            {
                fDonHangXuatEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin DongGoi khi click btnSua FrmMain
            #region
            if (MainPageView.SelectedPage == pvDongGoi && frmDongGoiEditisOpen_ == false)
                fDongGoi.SelectRows_DongGoi();
            else if (MainPageView.SelectedPage == pvDongGoi && frmDongGoiEditisOpen_ == true)
            {
                fDongGoiEdit_.Select();
                return;
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin Bán hàng khi click btnSua FrmMain
            #region
            if (MainPageView.SelectedPage == pvNT_BanHang && frmNT_BanHangEditisOpen_ == false)
                fNT_BanHang.SelectRows_NTBanHang();
            else if (MainPageView.SelectedPage == pvNT_BanHang && frmNT_BanHangEditisOpen_ == true)
            {
                fNT_BanHangEdit_.Select();
                return;
            }
            #endregion

            //Hà: sửa dạng bào chế
            #region
            if ((MainPageView.SelectedPage == pvDangBaoChe) && (frmDBCEditisOpen_ == false))
            {
                fDBC.SelectRows_DBC();
            }
            #endregion

            //Hà: sửa Giảm giá
            #region
            if ((MainPageView.SelectedPage == pvGiamGia) && (frmGiamGiaEditisOpen_ == false))
            {
                fGiamGia.rgvGiamGia_DoubleClick(sender, e);
            }
            #endregion

            //Hà: sửa Quốc Gia
            #region
            if ((MainPageView.SelectedPage == pvQuocGia) && (frmQuocGiaEditisOpen_ == false))
            {
                fQuocGia.rgvDSQuocGia_DoubleClick(sender, e);
            }
            #endregion

            //Hà: sửa kho
            #region
            if ((MainPageView.SelectedPage == pvKho) && (frmKhoEditisOpen_ == false))
            {
                fKho.rgvKho_DoubleClick(sender, e);
            }
            #endregion

            //Hà: sửa Phan Loại Giá
            #region
            if ((MainPageView.SelectedPage == pvLoaiGia) && (frmPhanLoaiGiaEditisOpen_ == false))
            {
                fPhanLoaiGia.rgvPhanLoaiGia_DoubleClick(sender, e);
            }
            #endregion

            //Hà: sửa Nha Thuoc
            #region
            if ((MainPageView.SelectedPage == pvNhaThuoc) && (frmNhaThuocEditisOpen_ == false))
            {
                fNhaThuoc.SelectRows_NhaThuoc();
            }
            #endregion

            //Hà: sửa Nhập Kho
            #region
            if ((MainPageView.SelectedPage == pvNhapKho) && (frmNhapKhoEditisOpen_ == false))
            {
                fNhapKho.SelectRows_NhapKho();
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin ntchuyenhangnt khi click btnSua FrmMain
            #region
            if ((MainPageView.SelectedPage == pvNT_ChuyenHang) && (frmNT_ChuyenHangEditisOpen_ == false))
            {
                fNT_ChuyenHang.HienFormChuyenHangEdit();
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin ntchuyenhangnt khi click btnSua FrmMain
            #region
            if ((MainPageView.SelectedPage == pvNT_NhanPhieuChuyen) && (frmNT_NhanPhieuChuyenEditisOpen_ == false))
            {
                fNT_NhanPhieuChuyen.HienFormNhanPhieuChuyenEdit();
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin nttrahangvecty khi click btnSua FrmMain
            #region
            if ((MainPageView.SelectedPage == pvNT_TraHangVeCty) && (frmNT_TraHangVeCTyEditisOpen_ == false))
            {
                fNT_TraHangVeCty.HienFormTraHangVeCtyEdit();
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin nhantrahang khi click btnSua FrmMain
            #region
            if ((MainPageView.SelectedPage == pvNhanTraHang) && (frmNhanTraHangEditisOpen_ == false))
            {
                fNhanTraHang.HienFormNhanTraHangEdit();
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin dat hang khi click btnSua FrmMain
            #region
            if ((MainPageView.SelectedPage == pvNT_DatHang) && (frmNT_DatHangEditisOpen_ == false))
            {
                fNT_DatHang.HienFormDatHangEdit();
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin xuất nhanh khi click btnSua FrmMain
            #region
            if ((MainPageView.SelectedPage == pvXuatNhanh) && (frmXuatNhanhEditisOpen_ == false))
            {
                fXuatNhanh.HienFormXuatNhanhEdit();
            }
            #endregion

            //Hà: sửa Chuyển Kho
            #region
            if ((MainPageView.SelectedPage == pvChuyenKho) && (frmChuyenKhoEditisOpen_ == false))
            {
                fChuyenKho.SelectRows_ChuyenKho();
            }
            #endregion


            //Tân: Xử lý hiện form Sửa thông tin Phân quyền khi click btnSua FrmMain
            #region
            if ((MainPageView.SelectedPage == pvPhanQuyen) && (frmPhanQuyenEditisOpen_ == false))
            {
                fPhanQuyen.HienFormChiTiet();
            }
            #endregion

            //Tân: Xử lý hiện form Sửa thông tin Đơn hàng mua khi click btnSua FrmMain
            #region
            if ((MainPageView.SelectedPage == pvDonHangMua) && (frmDonHangMuaEditisOpen_ == false))
            {
                fDonHangMua.HienFormChiTiet();
            }
            #endregion
        }

        private void rbtnXoa_Click(object sender, EventArgs e)
        {
            if (MainPageView.SelectedPage == null)
            {
                return;
            }
            //Hà: Xóa dạng bào chế
            #region
            if ((MainPageView.SelectedPage == pvDangBaoChe) && (frmDBCEditisOpen_ == false))
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fDBC.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TenDBCXoa = this.fDBC.rgvDBC.CurrentRow.Cells["colTenDBC"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Dạng Bào Chế:\n " + TenDBCXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (frmDBCEditisOpen_ == false)
                    {
                        CSQLDBC xldbc = new CSQLDBC();
                        MaDBCCanXoa_ = fDBC.rgvDBC.CurrentRow.Cells["colDBCID"].Value.ToString();
                        int kq = xldbc.XoaThongTinDBC(MaDBCCanXoa_);
                        if (kq == 1)
                        {
                            fDBC.rgvDBC.DataSource = xldbc.LayDanhSachDBCLenLuoi(IsXemTatCa_);
                        } 
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Hà: Xóa giảm giá
            #region
            if ((MainPageView.SelectedPage == pvGiamGia) && (frmGiamGiaEditisOpen_ == false))
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fGiamGia.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TenGiamGiaXoa = this.fGiamGia.rgvGiamGia.CurrentRow.Cells["colTenGG"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Giảm Giá:\n " + TenGiamGiaXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (frmGiamGiaEditisOpen_ == false)
                    {
                        CSQLGiamGia xlgiamgia = new CSQLGiamGia();
                        MaGiamGiaCanXoa_ = fGiamGia.rgvGiamGia.CurrentRow.Cells["colGGID"].Value.ToString();
                        int kq = xlgiamgia.XoaThongTinGiamGia(MaGiamGiaCanXoa_);
                        if (kq == 1)
                        {
                            fGiamGia.rgvGiamGia.DataSource = xlgiamgia.LayDanhSachGiamGiaLenLuoi(IsXemTatCa_);
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Hà: Xóa Quốc Gia
            #region
            if ((MainPageView.SelectedPage == pvQuocGia) && (frmQuocGiaEditisOpen_ == false))
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fQuocGia.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TenQGXoa = this.fQuocGia.rgvDSQuocGia.CurrentRow.Cells["colTenQuocGia"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Quốc Gia:\n " + TenQGXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (frmQuocGiaEditisOpen_ == false)
                    {
                        CSQLQuocGia qg_ = new CSQLQuocGia();
                        MaQuocGiaCanXoa_ = fQuocGia.rgvDSQuocGia.CurrentRow.Cells["colQGID"].Value.ToString();
                        int kq = qg_.XoaThongTinQuocGia(MaQuocGiaCanXoa_);
                        if (kq == 1)
                        {
                            fQuocGia.rgvDSQuocGia.DataSource = qg_.LayDSQuocGiaLenLuoi(IsXemTatCa_);
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Hà: Xóa kho
            #region
            if ((MainPageView.SelectedPage == pvKho) && (frmKhoEditisOpen_ == false))
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fKho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TenKhoXoa = this.fKho.rgvKho.CurrentRow.Cells["colTenKho"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Kho:\n " + TenKhoXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (frmKhoEditisOpen_ == false)
                    {
                        CSQLKho xlkho = new CSQLKho();
                        MaKhoCanXoa_ = fKho.rgvKho.CurrentRow.Cells["colKhoID"].Value.ToString();
                        int kq = xlkho.XoaThongTinKho(MaKhoCanXoa_);
                        if (kq == 1)
                        {
                            fKho.rgvKho.DataSource = xlkho.LayDanhSachKhoLenLuoi(IsXemTatCa_);
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Hà: Xóa Phân Loại Giá
            #region
            if ((MainPageView.SelectedPage == pvLoaiGia) && (frmPhanLoaiGiaEditisOpen_ == false))
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fPhanLoaiGia.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TenPLGiaXoa = this.fPhanLoaiGia.rgvPhanLoaiGia.CurrentRow.Cells["colTenLG"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Phân Loại Giá:\n " + TenPLGiaXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (frmPhanLoaiGiaEditisOpen_ == false)
                    {
                        CSQLPhanLoaiGia xlphanloaigia = new CSQLPhanLoaiGia();
                        MaPhanLoaiGiaCanXoa_ = fPhanLoaiGia.rgvPhanLoaiGia.CurrentRow.Cells["colLGID"].Value.ToString();
                        int kq = xlphanloaigia.XoaThongTinPhanloaiGia(MaPhanLoaiGiaCanXoa_);
                        if (kq == 1)
                        {
                            fPhanLoaiGia.rgvPhanLoaiGia.DataSource = xlphanloaigia.LayDanhSachPhanloaiGiaLenLuoi(IsXemTatCa_);
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Hà: Xóa Nha Thuoc
            #region
            if ((MainPageView.SelectedPage == pvNhaThuoc) && (frmNhaThuocEditisOpen_ == false))
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fNhaThuoc.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TenNTXoa = this.fNhaThuoc.rgvNhaThuoc.CurrentRow.Cells["colTenNT"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Nhà Thuốc:\n " + TenNTXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (frmNhaThuocEditisOpen_ == false)
                    {
                        CSQLNhaThuoc xlnhathuoc = new CSQLNhaThuoc ();
                        MaNhaThuocCanXoa_ = fNhaThuoc.rgvNhaThuoc.CurrentRow.Cells["colNTID"].Value.ToString();
                        int kq = xlnhathuoc.XoaThongTinNhaThuoc(MaNhaThuocCanXoa_);
                        if (kq == 1)
                        {
                            fNhaThuoc.rgvNhaThuoc.DataSource = xlnhathuoc.LayDanhSachNhaThuocLenLuoi(IsXemTatCa_);
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Hà: Xóa Chuyển Kho
            #region
            if ((MainPageView.SelectedPage == pvChuyenKho) && (frmChuyenKhoEditisOpen_ == false))
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fChuyenKho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                if (MessageBox.Show("Bạn có  muốn xóa dữ liệu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (frmChuyenKhoEditisOpen_ == false)
                    {
                        CSQLChuyenKho ck_ = new CSQLChuyenKho();
                        MaChuyenKho_ = fChuyenKho.rgvChuyenKho.CurrentRow.Cells["colCKID"].Value.ToString();
                        int kq = ck_.XoaThongTinChuyenKho(MaChuyenKho_);
                        if (kq == 1)
                        {
                            fChuyenKho.rgvChuyenKho.DataSource = ck_.LoadChuyenKhoLenLuoi(IsXemTatCa_);
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Hà: Xóa Điều chỉnh tồn
            #region
            if ((MainPageView.SelectedPage == pvDieuChinhTon) && (frmDieuChinhTonEditisOpen_ == false))
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fDieuChinhTon.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                if (MessageBox.Show("Bạn có  muốn xóa dữ liệu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (frmDieuChinhTonEditisOpen_ == false)
                    {
                        CSQLDieuChinhTon dctk_ = new CSQLDieuChinhTon();
                        MaDieuChinhTon_ = fDieuChinhTon.rgvPhieuDCTon.CurrentRow.Cells["colDCTKID"].Value.ToString();
                        int kq = dctk_.XoaThongTinDieuChinhTonKho(MaDieuChinhTon_);
                        if (kq == 1)
                        {
                            fDieuChinhTon.rgvPhieuDCTon.DataSource = dctk_.LoadDieuChinhTonLenLuoi(IsXemTatCa_);
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Hà: Xóa Điều chỉnh HSD
            #region
            if ((MainPageView.SelectedPage == pvDieuChinhHSD) && (frmDieuChinhHSDEditisOpen_ == false))
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fDieuChinhHSD.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                if (MessageBox.Show("Bạn có  muốn xóa dữ liệu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (frmDieuChinhHSDEditisOpen_ == false)
                    {
                        CSQLDieuChinhHSD dchd_ = new CSQLDieuChinhHSD();
                        MaDieuChinhHSD_ = fDieuChinhHSD.rgvPhieuDCHSD.CurrentRow.Cells["colDCHDid"].Value.ToString();
                        int kq = dchd_.XoaThongTinDieuChinhHSD(MaDieuChinhHSD_);
                        if (kq == 1)
                        {
                            fDieuChinhHSD.rgvPhieuDCHSD.DataSource = dchd_.LoadDieuChinhHSDLenLuoi(IsXemTatCa_);
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            //Tân: Xử lý khi nhấn nút delete thông tin quận
            #region Xử lý danh mục QUẬN
            if (MainPageView.SelectedPage == pvQuan)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fQuan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.MaQuanCanSua_ = this.fQuan.rgvQuan.CurrentRow.Cells["colQuanID"].Value.ToString();
                string TenQuanXoa = this.fQuan.rgvQuan.CurrentRow.Cells["colTenQ"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa thông tin Quận:\n " + TenQuanXoa + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLQuan xlquan = new CSQLQuan();
                    int kq = xlquan.XoaThongTinQuan(this.MaQuanCanSua_);
                    if (kq == 1)
                    {
                        //MessageBox.Show("Xóa thông tin quận mã: ['" + this.MaQuanCanSua_ + "'] thành công!");
                        this.fQuan.rgvQuan.DataSource = xlquan.LayDanhSachQuanLenLuoi(this.IsXemTatCa_);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thông tin quận: ['" + TenQuanXoa + "'] thất bại!");
                    }
                }
            }
            #endregion

            //Tân: Xử lý khi nhấn nút delete thông tin thành phố
            #region
            if (MainPageView.SelectedPage == pvThanhPho)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fThanhPho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.MaThanhPhoCanSua_ = this.fThanhPho.rgvThanhPho.CurrentRow.Cells["colTPID"].Value.ToString();
                string TenTPXoa = this.fThanhPho.rgvThanhPho.CurrentRow.Cells["colTenTP"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Thành Phố:\n " + TenTPXoa + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLThanhPho xltp = new CSQLThanhPho();
                    int kq = xltp.XoaThanhPho(this.MaThanhPhoCanSua_);
                    if (kq == 1)
                    {
                        this.fThanhPho.rgvThanhPho.DataSource = xltp.LayThongTinThanhPho(this.IsXemTatCa_);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thông tin thành phố: ['" + TenTPXoa + "'] thất bại!");
                    }
                }
            }
            #endregion

            //Tân: xử lý khi nhấn nút delete thông tin nhân viên
            #region
            if (MainPageView.SelectedPage == pvNhanVien)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fNhanVien.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.MaNhanVienCanSua_ = this.fNhanVien.rgvNhanVien.CurrentRow.Cells["colNVID"].Value.ToString();
                string MaNhanVienXoa = this.fNhanVien.rgvNhanVien.CurrentRow.Cells["colMaNV"].Value.ToString();
                string TenNhanVienXoa = this.fNhanVien.rgvNhanVien.CurrentRow.Cells["colHoTen"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa nhân viên có mã:\n(" + MaNhanVienXoa + ") " + TenNhanVienXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNhanVien xlnv = new CSQLNhanVien();
                    int kq = xlnv.XoaNhanVien(this.MaNhanVienCanSua_);
                    if (kq == 1)
                        this.fNhanVien.rgvNhanVien.DataSource = xlnv.LayThongTinNhanVienLenLuoi(this.IsXemTatCa_);
                    else
                        MessageBox.Show("Xóa thông tin nhân viên: \n(" + MaNhanVienXoa + ") " + TenNhanVienXoa + " thất bại!");
                }
            }

            #endregion

            //Tân: Xử lý khi nhấn nút delete thông tin hoạt chất
            #region
            if (MainPageView.SelectedPage == pvHoatChat)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fHoatChat.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.MaHoatChatCanSua_ = this.fHoatChat.rgvHoatChat.CurrentRow.Cells["colHCID"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa hoạt chất có mã: ['" + this.MaHoatChatCanSua_ + "']?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLHoatChat xlhc = new CSQLHoatChat();
                    int kq = xlhc.XoaHoatChat(this.MaHoatChatCanSua_);
                    if (kq == 1)
                        this.fHoatChat.rgvHoatChat.DataSource = xlhc.LayHoatChatLenLuoi(this.IsXemTatCa_);
                    else
                        MessageBox.Show("Xóa thông tin hoạt chất: ['" + this.MaNhanVienCanSua_ + "'] thất bại!");
                }
            }
            #endregion

            //Tân: Xử lý khi nhấn nút delete thông tin NPP
            #region
            if (MainPageView.SelectedPage == pvNhaPhanPhoi)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fNhaPhanPhoi.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.MaNhaPhanPhoiCanSua_ = this.fNhaPhanPhoi.rgvNPP.CurrentRow.Cells["colNPPID"].Value.ToString();
                string TenNPPXoa = this.fNhaPhanPhoi.rgvNPP.CurrentRow.Cells["colTenNPP"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa nhà phân phối:\n " + TenNPPXoa + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNPP xlnpp = new CSQLNPP();
                    int kq = xlnpp.XoaNPP(this.MaNhaPhanPhoiCanSua_);
                    if (kq == 1)
                        this.fNhaPhanPhoi.rgvNPP.DataSource = xlnpp.LayNPPLenLuoi(IsXemTatCa_);
                    else
                        MessageBox.Show("Xóa thông tin nhà phân phối: ['" + TenNPPXoa + "'] thất bại!");
                }
            }
            #endregion

            //Tân: Xử lý khi nhấn nút delete thông tin NSX
            #region
            if (MainPageView.SelectedPage == pvNhaSanXuat)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fNhaSanXuat.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                this.MaNhaSanXuatCanSua_ = this.fNhaSanXuat.rgvNSX.CurrentRow.Cells["colNSXID"].Value.ToString();
                string TenNSXXoa = this.fNhaSanXuat.rgvNSX.CurrentRow.Cells["colTenNSX"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa nhà sản xuất:\n " + TenNSXXoa + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNSX xlnsx = new CSQLNSX();
                    string kq = xlnsx.XoaNSX(this.MaNhaSanXuatCanSua_);
                    if (kq.Equals("OK"))
                        this.fNhaSanXuat.rgvNSX.DataSource = xlnsx.LayNSXLenLuoi(IsXemTatCa_);
                    else
                        MessageBox.Show("Lỗi: " + kq);
                }
            }
            #endregion

            //Tân: Xử lý khi nhấn nút delete thông tin HeSoQuiDoi
            #region
            if (MainPageView.SelectedPage == pvHeSoQuiDoi)
            {
                KeyEventArgs keyevent = new KeyEventArgs(Keys.Delete);
                fHeSoQuiDoi.rgvDSHSQD_KeyDown(sender, keyevent);
            }
            #endregion

            //Tân: Xử lý khi nhấn nút delete thông tin DonHangXuat
            #region
            if (MainPageView.SelectedPage == pvDonHangXuat)
            {
                KeyEventArgs keyevent = new KeyEventArgs(Keys.Delete);
                fDonHangXuat.rgvDSDonHangXuat_KeyDown(sender, keyevent);
            }
            #endregion

            //Tân: Xử lý khi nhấn nút delete thông tin NTChuyenHangNT
            #region
            if (MainPageView.SelectedPage == pvNT_ChuyenHang)
            {
                KeyEventArgs keyevent = new KeyEventArgs(Keys.Delete);
                fNT_ChuyenHang.rgvChuyenHang_KeyDown(sender, keyevent);
            }
            #endregion

            //Tân: Xử lý khi nhấn nút delete thông tin NTTraHangVeCty
            #region
            if (MainPageView.SelectedPage == pvNT_TraHangVeCty)
            {
                KeyEventArgs keyevent = new KeyEventArgs(Keys.Delete);
                fNT_TraHangVeCty.rgvTraHangVeCty_KeyDown(sender, keyevent);
            }
            #endregion

            //Tân: Xử lý khi nhấn nút xóa thông tin NTDathang
            #region
            if (MainPageView.SelectedPage == pvNT_DatHang)
            {
                fNT_DatHang.Xoa();
            }
            #endregion

            //Anh
            #region
            if (MainPageView.SelectedPage == pvBoPhan)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fBoPhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TenBPXoa = this.fBoPhan.rgvBoBan.CurrentRow.Cells["colTenBP"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Bộ Phận:\n " + TenBPXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fBoPhan.XoaBoPhan();
                    fBoPhan.frmBoPhan_Load(sender, e);
                    return;
                }
            }
            

            if (MainPageView.SelectedPage == pvDVT)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fDVT.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TenDVTXoa = this.fDVT.rgvDVT.CurrentRow.Cells["colTenDVT"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Đơn Vị Tính:\n " + TenDVTXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fDVT.XoaDVT();
                    fDVT.frmDVT_Load(sender, e);
                    return;
                }
            }

            if (MainPageView.SelectedPage == pvNhomSP)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fNhomSP_.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TennhomSPXoa = this.fNhomSP_.rgvNhomSP.CurrentRow.Cells["colTenNSP"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Nhóm Sản Phẩm:\n " + TennhomSPXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fNhomSP_.XoaNhomSP();
                    fNhomSP_.frmNhomSP_Load(sender, e);
                    return;
                }
            }
            if (MainPageView.SelectedPage == pvSanPham)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(fSanPham.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string TenSPXoa = this.fSanPham.rgvSanPham.CurrentRow.Cells["colTenSP"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa Sản Phẩm:\n " + TenSPXoa + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fSanPham.XoaSanPham();
                    fSanPham.frmSanPham_Load(sender, e);
                    return;
                }
            }
            #endregion
        }

        //Hà: Hiện form fGiamGia vào Pageview fMain
        #region
        private void rbtnGiamGia_Click(object sender, EventArgs e)
        {
            if (DSGiamGiaIsOpen == true)
            {
                MainPageView.SelectedPage = pvGiamGia;
                return;
            }
            else
            {
                fGiamGia = new frmGiamGia(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fGiamGia.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fGiamGia.TopLevel = false;
                fGiamGia.FormBorderStyle = FormBorderStyle.None;
                fGiamGia.Dock = DockStyle.Fill;

                pvGiamGia = new Telerik.WinControls.UI.RadPageViewPage();
                pvGiamGia.Text = "Giảm Giá";
                MainPageView.Pages.Add(pvGiamGia);
                pvGiamGia.Controls.Add(fGiamGia);
                fGiamGia.Show();
                MainPageView.SelectedPage = pvGiamGia;
                DSGiamGiaIsOpen = true;
            }
        }
        #endregion

        //Hà: Hiện form fKho vào Pageview fMain
        #region
        private void rbtnKho_Click(object sender, EventArgs e)
        {
            if (DSKhoIsOpen == true)
            {
                MainPageView.SelectedPage = pvKho;
                return;
            }
            else
            {
                fKho = new frmKho(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fKho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fKho = new frmKho(this);
                fKho.TopLevel = false;
                fKho.FormBorderStyle = FormBorderStyle.None;
                fKho.Dock = DockStyle.Fill;

                pvKho = new Telerik.WinControls.UI.RadPageViewPage();
                pvKho.Text = "Kho";
                MainPageView.Pages.Add(pvKho);
                pvKho.Controls.Add(fKho);
                fKho.Show();
                MainPageView.SelectedPage = pvKho;
                DSKhoIsOpen = true;
            }
        }
        #endregion

        //Hà: Hiện form fphanloaigia vào Pageview fMain
        #region
        private void rbtnphanloaigia_Click(object sender, EventArgs e)
        {
            if (DSLoaiGiaIsOpen == true)
            {
                MainPageView.SelectedPage = pvLoaiGia;
                return;
            }
            else
            {
                fPhanLoaiGia = new frmPhanLoaiGia(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fPhanLoaiGia.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fPhanLoaiGia.TopLevel = false;
                fPhanLoaiGia.FormBorderStyle = FormBorderStyle.None;
                fPhanLoaiGia.Dock = DockStyle.Fill;

                pvLoaiGia = new Telerik.WinControls.UI.RadPageViewPage();
                pvLoaiGia.Text = "Phân Loại Giá";
                MainPageView.Pages.Add(pvLoaiGia);
                pvLoaiGia.Controls.Add(fPhanLoaiGia);
                fPhanLoaiGia.Show();
                MainPageView.SelectedPage = pvLoaiGia;
                DSLoaiGiaIsOpen = true;
            }

        }
        #endregion

        private void rbtnnhathuoc_Click(object sender, EventArgs e)
        {
            if (DSNhaThuocIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhaThuoc;
                return;
            }
            else
            {
                fNhaThuoc = new frmNhaThuoc(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhaThuoc.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhaThuoc.TopLevel = false;
                fNhaThuoc.FormBorderStyle = FormBorderStyle.None;
                fNhaThuoc.Dock = DockStyle.Fill;

                pvNhaThuoc = new Telerik.WinControls.UI.RadPageViewPage();
                pvNhaThuoc.Text = "Nhà Thuốc";
                MainPageView.Pages.Add(pvNhaThuoc);
                pvNhaThuoc.Controls.Add(fNhaThuoc);
                fNhaThuoc.Show();
                MainPageView.SelectedPage = pvNhaThuoc;
                DSNhaThuocIsOpen = true;
            }
        }

        private void rbtnHoatChat_Click(object sender, EventArgs e)
        {
            if (DSHoatChatIsOpen == true)
            {
                MainPageView.SelectedPage = pvHoatChat;
                return;
            }
            else
            {
                fHoatChat = new frmHoatChat(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fHoatChat.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fHoatChat.TopLevel = false;
                fHoatChat.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fHoatChat.Dock = DockStyle.Fill;

                pvHoatChat = new Telerik.WinControls.UI.RadPageViewPage();
                pvHoatChat.Text = "Phân loại";
                MainPageView.Pages.Add(pvHoatChat);
                pvHoatChat.Controls.Add(fHoatChat);
                fHoatChat.Show();
                MainPageView.SelectedPage = pvHoatChat;
                DSHoatChatIsOpen = true;
            }
        }

        private void rbtnNhaPhanPhoi_Click(object sender, EventArgs e)
        {
            if (DSNPPIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhaPhanPhoi;
                return;
            }
            else
            {
                fNhaPhanPhoi = new frmNhaPhanPhoi(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhaPhanPhoi.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhaPhanPhoi.TopLevel = false;
                fNhaPhanPhoi.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNhaPhanPhoi.Dock = DockStyle.Fill;

                pvNhaPhanPhoi = new Telerik.WinControls.UI.RadPageViewPage();
                pvNhaPhanPhoi.Text = "Nhà phân phối";
                MainPageView.Pages.Add(pvNhaPhanPhoi);
                pvNhaPhanPhoi.Controls.Add(fNhaPhanPhoi);
                fNhaPhanPhoi.Show();
                MainPageView.SelectedPage = pvNhaPhanPhoi;
                DSNPPIsOpen = true;
            }
        }

        private void rbtnNhomSP_Click(object sender, EventArgs e)
        {
            if (DSNhomSPIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhomSP;
                return;
            }
            else
            {
                fNhomSP_ = new frmNhomSP(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhomSP_.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhomSP_ = new frmNhomSP(this);
                fNhomSP_.TopLevel = false;
                fNhomSP_.FormBorderStyle = FormBorderStyle.None;
                fNhomSP_.Dock = DockStyle.Fill;

                pvNhomSP = new Telerik.WinControls.UI.RadPageViewPage();
                pvNhomSP.Text = "Nhóm Sản Phẩm";
                MainPageView.Pages.Add(pvNhomSP);
                pvNhomSP.Controls.Add(fNhomSP_);
                fNhomSP_.Show();
                MainPageView.SelectedPage = pvNhomSP;
                DSNhomSPIsOpen = true;
            }
        }

        private void rbtnSanPham_Click(object sender, EventArgs e)
        {
            if (DSSanPhamIsOpen == true)
            {
                MainPageView.SelectedPage = pvSanPham;
                return;
            }
            else
            {
                fSanPham = new frmSanPham(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fSanPham.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fSanPham.TopLevel = false;
                fSanPham.FormBorderStyle = FormBorderStyle.None;
                fSanPham.Dock = DockStyle.Fill;

                pvSanPham = new Telerik.WinControls.UI.RadPageViewPage();
                pvSanPham.Text = "Sản Phẩm";
                MainPageView.Pages.Add(pvSanPham);
                pvSanPham.Controls.Add(fSanPham);
                fSanPham.Show();
                MainPageView.SelectedPage = pvSanPham;
                DSSanPhamIsOpen = true;
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.T)
                {
                    rbtnThemMoi_Click(sender, e);
                }
                if (e.Control && e.KeyCode == Keys.S)
                {
                    rbtnSua_Click(sender, e);
                }
                if (e.Control && e.KeyCode == Keys.X)
                {
                    rbtnXoa_Click(sender, e);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if ((MainPageView.SelectedPage == pvNhapXuatTon) && (frmNhapXuatTonEditisOpen_ == false))
                    {
                        fNhapXuatTon.btnXem_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void rbtnCauHinh_Click(object sender, EventArgs e)
        {
            if (DSCauHinhHeThongIsOpen == true)
            {
                MainPageView.SelectedPage = pvCauHinhHeThong;
                return;
            }
            else
            {
                fCauHinhHeThong = new frmCauHinhHeThong(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fCauHinhHeThong.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fCauHinhHeThong.TopLevel = false;
                fCauHinhHeThong.FormBorderStyle = FormBorderStyle.None;
                fCauHinhHeThong.Dock = DockStyle.Fill;

                pvCauHinhHeThong = new Telerik.WinControls.UI.RadPageViewPage();
                pvCauHinhHeThong.Text = "Cấu Hình Hệ Thống";
                MainPageView.Pages.Add(pvCauHinhHeThong);
                pvCauHinhHeThong.Controls.Add(fCauHinhHeThong);
                fCauHinhHeThong.Show();
                MainPageView.SelectedPage = pvCauHinhHeThong;
                DSCauHinhHeThongIsOpen = true;
            }
        }

        private void rbtnNhapKho_Click(object sender, EventArgs e)
        {
            if (DSNhapKhoIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhapKho;
                return;
            }
            else
            {
                fNhapKho = new frmNhapKho(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhapKho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhapKho.TopLevel = false;
                fNhapKho.FormBorderStyle = FormBorderStyle.None;
                fNhapKho.Dock = DockStyle.Fill;

                pvNhapKho = new Telerik.WinControls.UI.RadPageViewPage();
                pvNhapKho.Text = "Nhập Kho";
                MainPageView.Pages.Add(pvNhapKho);
                pvNhapKho.Controls.Add(fNhapKho);
                fNhapKho.Show();
                MainPageView.SelectedPage = pvNhapKho;
                DSNhapKhoIsOpen = true;
            }
        }

        private void rbtnXacNhanNhapKho_Click(object sender, EventArgs e)
        {
            if (DSNhapKhoXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhapKhoXacNhan;
                return;
            }
            else
            {
                fNhapKhoXacNhan = new frmNhapKhoXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhapKhoXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhapKhoXacNhan.TopLevel = false;
                fNhapKhoXacNhan.FormBorderStyle = FormBorderStyle.None;
                fNhapKhoXacNhan.Dock = DockStyle.Fill;

                pvNhapKhoXacNhan = new Telerik.WinControls.UI.RadPageViewPage();
                pvNhapKhoXacNhan.Text = "Nhập Kho Xác Nhận";
                MainPageView.Pages.Add(pvNhapKhoXacNhan);
                pvNhapKhoXacNhan.Controls.Add(fNhapKhoXacNhan);
                fNhapKhoXacNhan.Show();
                MainPageView.SelectedPage = pvNhapKhoXacNhan;
                DSNhapKhoXacNhanIsOpen = true;
            }
        }

        private void rbtnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                //An: Kiểm tra sổ tồn kế toán
                CSQLSoTonKhoKeToan aSoTonKhoKeToan = new CSQLSoTonKhoKeToan();
                string kqKiemTraTon = aSoTonKhoKeToan.KiemTraSoTonKhoKeToanBiKhoa();
                if (!kqKiemTraTon.Equals("OK")) {
                    MessageBox.Show(kqKiemTraTon);
                    return;
                }
                //Hà: xác nhận nhập kho
                #region
                if ((MainPageView.SelectedPage == pvNhapKhoXacNhan) && (frmNhapKhoXacNhanEditisOpen_ == false))
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenThem_Sua(fNhapKhoXacNhan.Name) == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    CSQLNhapKho nhapkho = new CSQLNhapKho();
                    for (int i = 0; i < fNhapKhoXacNhan.rgvDSPhieuNhapXacNhan.Rows.Count; i++)
                    {
                        fNhapKhoXacNhan.rgvDSPhieuNhapXacNhan.Rows[i].Cells[0].EndEdit();
                        bool ChonXN = (bool)fNhapKhoXacNhan.rgvDSPhieuNhapXacNhan.Rows[i].Cells[0].Value;
                        nhapkho.SMaPN = fNhapKhoXacNhan.rgvDSPhieuNhapXacNhan.Rows[i].Cells[1].Value.ToString();
                        if (ChonXN == true)
                        {
                            nhapkho.BXNPhieuNhap = true;
                            nhapkho.DNgayXacNhan = DateTime.Now;
                            nhapkho.SUserXN = CStaticBien.SmaTaiKhoan;

                            int kq = nhapkho.SuaThongTinNhapKhoXacNhan(nhapkho);
                        }
                    }
                    fNhapKhoXacNhan.rgvDSPhieuNhapXacNhan.DataSource = nhapkho.LayDanhSachNhapKhoXacNhanLenLuoi(true, false);
                    fNhapKho.rgvDSPhieuNhap.DataSource = nhapkho.LayDanhSachNhapKhoLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Tân: Xác nhận Đơn hàng xuất
                #region
                if (MainPageView.SelectedPage == pvDonHangXuatXacNhan)
                {
                    fDonHangXuatXacNhan.XacNhanDonHangXuat(true);
                }
                #endregion

                //Tân: Xác nhận NT_NhapKhoXacNhan
                #region
                if (MainPageView.SelectedPage == pvNT_NhapKhoXacNhan)
                {
                    fNT_NhapKhoXacNhan.XacNhan();
                }
                #endregion

                //Tân: Xác nhận NT_ChuyenHangNT
                #region
                if (MainPageView.SelectedPage == pvNT_ChuyenHangXacNhan)
                {
                    fNT_ChuyenHangXacNhan_.ChuyenHangXacNhan_XacNhan();
                }
                #endregion

                //Tân: Xác nhận NT_NhanChuyenHangNT
                #region
                if (MainPageView.SelectedPage == pvNT_NhanPhieuChuyenXacNhan)
                {
                    fNT_NhanPhieuChuyenXacNhan.XacNhanNhanPhieuChuyen();
                }
                #endregion

                //Tân: Xác nhận NT_TRAHANGVECTY
                #region
                if (MainPageView.SelectedPage == pvNT_TraHangVeCtyXacNhan)
                {
                    fNT_TraHangVeCtyXacNhan.TraHangXacNhan_XacNhan();
                }
                #endregion

                //Tân: Xác nhận NT_NhanTraHang
                #region
                if (MainPageView.SelectedPage == pvNhanTraHangXacNhan)
                {
                    fNhanTraHangXacNhan.XacNhan();
                }
                #endregion

                //Tân: Xác nhận NT_Dathang
                #region
                if (MainPageView.SelectedPage == pvNT_DatHangXacNhan)
                {
                    fNT_DatHangXacNhan.XacNhan();
                }
                #endregion

                //Tân: Xác nhận xuất nhanh
                #region
                if (MainPageView.SelectedPage == pvXuatNhanhXacNhan)
                {
                    fXuatNhanhXacNhan.XacNhan();
                }
                #endregion

                //Hà: xác nhận chuyển kho
                #region
                if ((MainPageView.SelectedPage == pvChuyenKhoXacNhan) && (frmChuyenKhoXacNhanEditisOpen_ == false))
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenThem_Sua(fChuyenKhoXacNhan.Name) == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    CSQLChuyenKho chuyenkho = new CSQLChuyenKho();
                    for (int i = 0; i < fChuyenKhoXacNhan.rgvChuyenKho.Rows.Count; i++)
                    {
                        fChuyenKhoXacNhan.rgvChuyenKho.Rows[i].Cells[0].EndEdit();
                        if (fChuyenKhoXacNhan.rgvChuyenKho.Rows[i].Cells[0].Value != null)
                        {
                            bool ChonXN = (bool)fChuyenKhoXacNhan.rgvChuyenKho.Rows[i].Cells[0].Value;
                            chuyenkho.SChuyenKhoID = fChuyenKhoXacNhan.rgvChuyenKho.Rows[i].Cells[1].Value.ToString();
                            if (ChonXN == true)
                            {
                                chuyenkho.BDaXacNhan = true;
                                chuyenkho.DNgayXacNhan = DateTime.Now;
                                chuyenkho.SUserXacNhan = CStaticBien.SmaTaiKhoan;
                            }
                            else
                            {
                                chuyenkho.BDaXacNhan = false;
                                chuyenkho.DNgayXacNhan = DateTime.Parse("1/1/1774");
                                chuyenkho.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                            }
                            int kq = chuyenkho.SuaThongTinChuyenKhoXacNhan(chuyenkho);
                        }
                    }
                    fChuyenKhoXacNhan.rgvChuyenKho.DataSource = chuyenkho.LayDanhSachChuyenKhoXacNhanLenLuoi(true, false);
                    fChuyenKho.rgvChuyenKho.DataSource = chuyenkho.LoadChuyenKhoLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: xác nhận nhận chuyển hàng
                #region
                if ((MainPageView.SelectedPage == pvNhanChuyenHangXacNhan) && (frmNhanChuyenHangEditisOpen_ == false))
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenThem_Sua(fNhanChuyenHangXacNhan.Name) == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    CSQLNhanChuyenHang nch = new CSQLNhanChuyenHang();
                    for (int i = 0; i < fNhanChuyenHangXacNhan.rgvPhieuChuyenHang.Rows.Count; i++)
                    {
                        fNhanChuyenHangXacNhan.rgvPhieuChuyenHang.Rows[i].Cells[0].EndEdit();
                        if (fNhanChuyenHangXacNhan.rgvPhieuChuyenHang.Rows[i].Cells[0].Value != null)
                        {
                            bool ChonXN = (bool)fNhanChuyenHangXacNhan.rgvPhieuChuyenHang.Rows[i].Cells[0].Value;
                            nch.SNCHid = fNhanChuyenHangXacNhan.rgvPhieuChuyenHang.Rows[i].Cells[1].Value.ToString();
                            if (ChonXN == true)
                            {
                                nch.BDaXacNhan = true;
                                nch.DNgayXacNhan = DateTime.Now;
                                nch.SUserXacNhan = CStaticBien.SmaTaiKhoan;
                            }
                            else
                            {
                                nch.BDaXacNhan = false;
                                nch.DNgayXacNhan = DateTime.Parse("1/1/1774");
                                nch.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                            }
                            int kq = nch.SuaThongTinNhanChuyenHangXacNhan(nch);
                        }
                    }
                    fNhanChuyenHangXacNhan.rgvPhieuChuyenHang.DataSource = nch.LayDSNhanChuyenHangXacNhanLenLuoi(true, false);
                    fNhanChuyenHang.rgvNhanChuyenHang.DataSource = nch.LoadNhanChuyenHangLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: xác nhận điều chỉnh tồn kho
                #region
                if ((MainPageView.SelectedPage == pvDieuChinhTonXacNhan) && (frmDieuChinhTonEditisOpen_ == false))
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenThem_Sua(fDieuChinhTonXacNhan.Name) == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    CSQLDieuChinhTon dctk = new CSQLDieuChinhTon();
                    for (int i = 0; i < fDieuChinhTonXacNhan.rgvPhieuDieuChinh.Rows.Count; i++)
                    {
                        fDieuChinhTonXacNhan.rgvPhieuDieuChinh.Rows[i].Cells[0].EndEdit();
                        if (fDieuChinhTonXacNhan.rgvPhieuDieuChinh.Rows[i].Cells[0].Value != null)
                        {
                            bool ChonXN = (bool)fDieuChinhTonXacNhan.rgvPhieuDieuChinh.Rows[i].Cells[0].Value;
                            dctk.SDCTKid = fDieuChinhTonXacNhan.rgvPhieuDieuChinh.Rows[i].Cells[1].Value.ToString();
                            if (ChonXN == true)
                            {
                                dctk.BDaXacNhan = true;
                                dctk.DNgayXacNhan = DateTime.Now;
                                dctk.SUserXacNhan = CStaticBien.SmaTaiKhoan;
                            }
                            else
                            {
                                dctk.BDaXacNhan = false;
                                dctk.DNgayXacNhan = DateTime.Parse("1/1/1774");
                                dctk.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                            }
                            int kq = dctk.SuaThongTinDieuChinhTonKhoXacNhan(dctk);
                        }
                    }
                    fDieuChinhTonXacNhan.rgvPhieuDieuChinh.DataSource = dctk.LayDanhSachDieuChinhTonKhoXacNhanLenLuoi(true, false);
                    fDieuChinhTon.rgvPhieuDCTon.DataSource = dctk.LoadDieuChinhTonLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: xác nhận Nhà thuốc điều chỉnh tồn kho
                #region
                if ((MainPageView.SelectedPage == pvNT_DieuChinhTonXacNhan) && (frmNT_DieuChinhTonEditisOpen_ == false))
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenThem_Sua(fNT_DieuChinhTonXacNhan.Name) == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    CSQLNT_DieuChinhTon nt_dctk = new CSQLNT_DieuChinhTon();
                    for (int i = 0; i < fNT_DieuChinhTonXacNhan.rgvDieuChinh.Rows.Count; i++)
                    {
                        fNT_DieuChinhTonXacNhan.rgvDieuChinh.Rows[i].Cells[0].EndEdit();
                        if (fNT_DieuChinhTonXacNhan.rgvDieuChinh.Rows[i].Cells[0].Value != null)
                        {
                            bool ChonXN = (bool)fNT_DieuChinhTonXacNhan.rgvDieuChinh.Rows[i].Cells[0].Value;
                            nt_dctk.SDCTKid = fNT_DieuChinhTonXacNhan.rgvDieuChinh.Rows[i].Cells[1].Value.ToString();
                            if (ChonXN == true)
                            {
                                nt_dctk.BDaXacNhan = true;
                                nt_dctk.DNgayXacNhan = DateTime.Now;
                                nt_dctk.SUserXacNhan = CStaticBien.SmaTaiKhoan;
                            }
                            else
                            {
                                nt_dctk.BDaXacNhan = false;
                                nt_dctk.DNgayXacNhan = DateTime.Parse("1/1/1774");
                                nt_dctk.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                            }
                            int kq = nt_dctk.SuaThongTinDieuChinhTonKhoXacNhan(nt_dctk);
                        }
                    }
                    fNT_DieuChinhTonXacNhan.rgvDieuChinh.DataSource = nt_dctk.LayDanhSachNT_DieuChinhTonKhoXacNhanLenLuoi(true, false);
                    fNT_DieuChinhTon.rgvDieuChinhTon.DataSource = nt_dctk.LoadNT_DieuChinhTonLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: xác nhận điều chỉnh hạn sử dụng
                #region
                if ((MainPageView.SelectedPage == pvDieuChinhHSDXacNhan) && (frmDieuChinhHSDEditisOpen_ == false))
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenThem_Sua(fDieuChinhHSDXacNhan.Name) == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    CSQLDieuChinhHSD dchsd = new CSQLDieuChinhHSD();
                    for (int i = 0; i < fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.Rows.Count; i++)
                    {
                        fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.Rows[i].Cells[0].EndEdit();
                        if (fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.Rows[i].Cells[0].Value != null)
                        {
                            bool ChonXN = (bool)fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.Rows[i].Cells[0].Value;
                            dchsd.SDCHDid = fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.Rows[i].Cells[1].Value.ToString();
                            if (ChonXN == true)
                            {
                                dchsd.BDaXacNhan = true;
                                dchsd.DNgayXacNhan = DateTime.Now;
                                dchsd.SUserXacNhan = CStaticBien.SmaTaiKhoan;
                            }
                            else
                            {
                                dchsd.BDaXacNhan = false;
                                dchsd.DNgayXacNhan = DateTime.Parse("1/1/1774");
                                dchsd.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                            }
                            int kq = dchsd.SuaThongTinDieuChinhHSDXacNhan(dchsd);
                        }
                    }
                    fDieuChinhHSDXacNhan.rgvPhieuDieuChinh.DataSource = dchsd.LayDanhSachDieuChinhHSDXacNhanLenLuoi(true, false);
                    fDieuChinhHSD.rgvPhieuDCHSD.DataSource = dchsd.LoadDieuChinhHSDLenLuoi(IsXemTatCa_);
                }
                #endregion

                //Hà: xác nhận Nhà thuốc điều chỉnh hạn sử dụng
                #region
                if ((MainPageView.SelectedPage == pvNT_DieuChinhHSDXacNhan) && (frmNT_DieuChinhHSDEditisOpen_ == false))
                {
                    CQuyenTruyCap qtc = new CQuyenTruyCap();
                    if (qtc.KiemTraQuyenThem_Sua(fNT_DieuChinhHSDXacNhan.Name) == false)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                        return;
                    }
                    CSQLNT_DieuChinhHSD nt_dchsd = new CSQLNT_DieuChinhHSD();
                    for (int i = 0; i < fNT_DieuChinhHSDXacNhan.rgvDieuChinh.Rows.Count; i++)
                    {
                        fNT_DieuChinhHSDXacNhan.rgvDieuChinh.Rows[i].Cells[0].EndEdit();
                        if (fNT_DieuChinhHSDXacNhan.rgvDieuChinh.Rows[i].Cells[0].Value != null)
                        {
                            bool ChonXN = (bool)fNT_DieuChinhHSDXacNhan.rgvDieuChinh.Rows[i].Cells[0].Value;
                            nt_dchsd.SDCHDid = fNT_DieuChinhHSDXacNhan.rgvDieuChinh.Rows[i].Cells[1].Value.ToString();
                            if (ChonXN == true)
                            {
                                nt_dchsd.BDaXacNhan = true;
                                nt_dchsd.DNgayXacNhan = DateTime.Now;
                                nt_dchsd.SUserXacNhan = CStaticBien.SmaTaiKhoan;
                            }
                            else
                            {
                                nt_dchsd.BDaXacNhan = false;
                                nt_dchsd.DNgayXacNhan = DateTime.Parse("1/1/1774");
                                nt_dchsd.SUserXacNhan = "00000000-0000-0000-0000-000000000000";
                            }
                            int kq = nt_dchsd.SuaThongTinDieuChinhTonKhoXacNhan(nt_dchsd);
                        }
                    }
                    fNT_DieuChinhHSDXacNhan.rgvDieuChinh.DataSource = nt_dchsd.LayDanhSachNT_DieuChinhHSDXacNhanLenLuoi(true, false);
                    fNT_DieuChinhHSD.rgvDieuChinhTon.DataSource = nt_dchsd.LoadNT_DieuChinhHSDLenLuoi(IsXemTatCa_);
                }
                #endregion
            }
            catch { }
        }

        private void rbtnHSQD_Click(object sender, EventArgs e)
        {
            if (DSHeSoQuiDoiIsOpen == true)
            {
                MainPageView.SelectedPage = pvHeSoQuiDoi;
                return;
            }
            else
            {
                fHeSoQuiDoi = new frmHeSoQuiDoi(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fHeSoQuiDoi.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fHeSoQuiDoi.TopLevel = false;
                fHeSoQuiDoi.FormBorderStyle = FormBorderStyle.None;
                fHeSoQuiDoi.Dock = DockStyle.Fill;

                pvHeSoQuiDoi = new Telerik.WinControls.UI.RadPageViewPage();
                pvHeSoQuiDoi.Text = "Hệ số quy đổi";
                MainPageView.Pages.Add(pvHeSoQuiDoi);
                pvHeSoQuiDoi.Controls.Add(fHeSoQuiDoi);
                fHeSoQuiDoi.Show();
                MainPageView.SelectedPage = pvHeSoQuiDoi;
                DSHeSoQuiDoiIsOpen = true;
            }
        }

        private void rbtnDonHangXuat_Click(object sender, EventArgs e)
        {
            if (DSDonHangXuatIsOpen == true)
            {
                MainPageView.SelectedPage = pvDonHangXuat;
                return;
            }
            else
            {
                fDonHangXuat = new frmDonHangXuat(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fDonHangXuat.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fDonHangXuat.TopLevel = false;
                fDonHangXuat.FormBorderStyle = FormBorderStyle.None;
                fDonHangXuat.Dock = DockStyle.Fill;

                pvDonHangXuat = new Telerik.WinControls.UI.RadPageViewPage();
                pvDonHangXuat.Text = "Đơn hàng xuất";
                MainPageView.Pages.Add(pvDonHangXuat);
                pvDonHangXuat.Controls.Add(fDonHangXuat);
                fDonHangXuat.Show();
                MainPageView.SelectedPage = pvDonHangXuat;
                DSDonHangXuatIsOpen = true;
            }
        }

        private void rbtnXacNhanDonHangXuat_Click(object sender, EventArgs e)
        {
            if (DSDonHangXuatXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvDonHangXuatXacNhan;
                return;
            }
            else
            {
                fDonHangXuatXacNhan = new frmDonHangXuatXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fDonHangXuatXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fDonHangXuatXacNhan.TopLevel = false;
                fDonHangXuatXacNhan.FormBorderStyle = FormBorderStyle.None;
                fDonHangXuatXacNhan.Dock = DockStyle.Fill;

                pvDonHangXuatXacNhan = new Telerik.WinControls.UI.RadPageViewPage();
                pvDonHangXuatXacNhan.Text = "Xác nhận đơn hàng xuất";
                MainPageView.Pages.Add(pvDonHangXuatXacNhan);
                pvDonHangXuatXacNhan.Controls.Add(fDonHangXuatXacNhan);
                fDonHangXuatXacNhan.Show();
                MainPageView.SelectedPage = pvDonHangXuatXacNhan;
                DSDonHangXuatXacNhanIsOpen = true;
            }
        }

        private void rbtnSP_NSX_Click(object sender, EventArgs e)
        {
            if (DSSanPham_NSXIsOpen == true)
            {
                MainPageView.SelectedPage = pvSanPham_NSX;
                return;
            }
            else
            {
                fSanPham_NSX = new frmSanPham_NSX(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fSanPham_NSX.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fSanPham_NSX.TopLevel = false;
                fSanPham_NSX.FormBorderStyle = FormBorderStyle.None;
                fSanPham_NSX.Dock = DockStyle.Fill;

                pvSanPham_NSX = new Telerik.WinControls.UI.RadPageViewPage();
                pvSanPham_NSX.Text = "Sản Phẩm - Nhà Sản Xuất";
                MainPageView.Pages.Add(pvSanPham_NSX);
                pvSanPham_NSX.Controls.Add(fSanPham_NSX);
                fSanPham_NSX.Show();
                MainPageView.SelectedPage = pvSanPham_NSX;
                DSSanPham_NSXIsOpen = true;
            }
        }

        private void rbtnXuatKho_Click(object sender, EventArgs e)
        {
            if (DSPhieuXuatKho_DSIsOpen == true)
            {
                CSQLPhieuXuat px_ = new CSQLPhieuXuat();
                fPhieuXuatKho_DS.rgvDSPhieuXK.DataSource = px_.LayDanhSachLenLuoi(IsXemTatCa_);
                MainPageView.SelectedPage = pvPhieuXuatKho;
            }
            else
            {
                fPhieuXuatKho_DS = new frmPhieuXuatKho_DS(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fPhieuXuatKho_DS.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fPhieuXuatKho_DS.TopLevel = false;
                fPhieuXuatKho_DS.FormBorderStyle = FormBorderStyle.None;
                fPhieuXuatKho_DS.Dock = DockStyle.Fill;

                pvPhieuXuatKho = new Telerik.WinControls.UI.RadPageViewPage();
                pvPhieuXuatKho.Text = "DS Phiếu Xuất Kho";
                MainPageView.Pages.Add(pvPhieuXuatKho);
                pvPhieuXuatKho.Controls.Add(fPhieuXuatKho_DS);
                fPhieuXuatKho_DS.Show();
                MainPageView.SelectedPage = pvPhieuXuatKho;
                DSPhieuXuatKho_DSIsOpen = true;
            }
        }

        private void rbtnNhapXuatTon_Click(object sender, EventArgs e)
        {
            if (DSNhapXuatTonIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhapXuatTon;
                return;
            }
            else
            {
                fNhapXuatTon = new frmNhapXuatTon(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhapXuatTon.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhapXuatTon.TopLevel = false;
                fNhapXuatTon.FormBorderStyle = FormBorderStyle.None;
                fNhapXuatTon.Dock = DockStyle.Fill;

                pvNhapXuatTon = new Telerik.WinControls.UI.RadPageViewPage();
                pvNhapXuatTon.Text = "Nhập Xuất Tồn";
                MainPageView.Pages.Add(pvNhapXuatTon);
                pvNhapXuatTon.Controls.Add(fNhapXuatTon);
                fNhapXuatTon.Show();
                MainPageView.SelectedPage = pvNhapXuatTon;
                DSNhapXuatTonIsOpen = true;
            }
        }

        private void rbtnThucXuatKho_Click(object sender, EventArgs e)
        {
            if (DSKiemTraXuatKhoIsOpen == true)
            {
                CSQLKiemTraXuatKho kiemtraxuatkho_ = new CSQLKiemTraXuatKho();
                DataTable dataKTXK = kiemtraxuatkho_.KiemTraXuatKho_LoadLenLuoi_IsXong(false);
                fKiemTraXuatKho.rgvKiemTraXuatKho.DataSource = dataKTXK;
                MainPageView.SelectedPage = pvKiemTraXuatKho;
                return;
            }
            else
            {
                fKiemTraXuatKho = new frmKiemTraXuatKho(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fKiemTraXuatKho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fKiemTraXuatKho.TopLevel = false;
                fKiemTraXuatKho.FormBorderStyle = FormBorderStyle.None;
                fKiemTraXuatKho.Dock = DockStyle.Fill;

                pvKiemTraXuatKho = new Telerik.WinControls.UI.RadPageViewPage();
                pvKiemTraXuatKho.Text = "Kiểm Tra Xuất Kho";
                MainPageView.Pages.Add(pvKiemTraXuatKho);
                pvKiemTraXuatKho.Controls.Add(fKiemTraXuatKho);
                fKiemTraXuatKho.Show();
                MainPageView.SelectedPage = pvKiemTraXuatKho;
                DSKiemTraXuatKhoIsOpen = true;
            }
        }

        private void rbtnSanPham_Kho_Click(object sender, EventArgs e)
        {
            fSanPham_Kho = new frmSanPham_Kho(this);
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fSanPham_Kho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (DSSanPham_KhoIsOpen == true)
            {
                MainPageView.SelectedPage = pvSanPham_Kho;
                return;
            }
           
            fSanPham_Kho.TopLevel = false;
            fSanPham_Kho.FormBorderStyle = FormBorderStyle.None;
            fSanPham_Kho.Dock = DockStyle.Fill;

            pvSanPham_Kho = new Telerik.WinControls.UI.RadPageViewPage();
            pvSanPham_Kho.Text = "Sản Phẩm - Kho";
            MainPageView.Pages.Add(pvSanPham_Kho);
            pvSanPham_Kho.Controls.Add(fSanPham_Kho);
            fSanPham_Kho.Show();
            MainPageView.SelectedPage = pvSanPham_Kho;
            DSSanPham_KhoIsOpen = true;
        }

        private void rbtnDongGoi_Click(object sender, EventArgs e)
        {
            if (DSDongGoiIsOpen == true)
            {
                CSQLDongGoi dg = new CSQLDongGoi();
                dg.DoDuLieuTuKiemTraXuatSangDongGoi();
                fDongGoi.rgvDongGoi.DataSource = dg.LayDSDongGoi(IsXemTatCa_);
                MainPageView.SelectedPage = pvDongGoi;
                return;
            }
            else
            {
                fDongGoi = new frmDongGoi(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fDongGoi.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fDongGoi.TopLevel = false;
                fDongGoi.FormBorderStyle = FormBorderStyle.None;
                fDongGoi.Dock = DockStyle.Fill;

                pvDongGoi = new Telerik.WinControls.UI.RadPageViewPage();
                pvDongGoi.Text = "Đóng gói";
                MainPageView.Pages.Add(pvDongGoi);
                pvDongGoi.Controls.Add(fDongGoi);
                fDongGoi.Show();
                MainPageView.SelectedPage = pvDongGoi;
                DSDongGoiIsOpen = true;
            }
        }

        private void rbtnNT_SanPham_Kho_Click(object sender, EventArgs e)
        {
            if (DSNT_SanPham_KhoIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_SanPham_Kho;
                return;
            }
            fNT_SanPham_Kho = new frmNT_SanPham_Kho(this);
            fNT_SanPham_Kho.TopLevel = false;
            fNT_SanPham_Kho.FormBorderStyle = FormBorderStyle.None;
            fNT_SanPham_Kho.Dock = DockStyle.Fill;

            pvNT_SanPham_Kho = new Telerik.WinControls.UI.RadPageViewPage();
            pvNT_SanPham_Kho.Text = "NT-Sản Phẩm-Kho";
            MainPageView.Pages.Add(pvNT_SanPham_Kho);
            pvNT_SanPham_Kho.Controls.Add(fNT_SanPham_Kho);
            fNT_SanPham_Kho.Show();
            MainPageView.SelectedPage = pvNT_SanPham_Kho;
            DSNT_SanPham_KhoIsOpen = true;
        }

        private void rbtnNTLayDuLieu_Click(object sender, EventArgs e)
        {
            fNT_LayPhieuXuat = new frmNT_LayPhieuXuat(this);
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fNT_LayPhieuXuat.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (DSNT_LayPhieuXuatIsOpen == true)
            {
                CRmtServer KetNoiServer = new CRmtServer();
                if (KetNoiServer.KiemTraKetNoiRmtServer() == false)
                {
                    MessageBox.Show("Kết nối server không thành công. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
                    CSQLNT_LayPhieuXuat nt_layphieuxuat_ = new CSQLNT_LayPhieuXuat();
                    string ttcn_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
                   fNT_LayPhieuXuat.rgvDSLayPhieuXuat.DataSource = nt_layphieuxuat_.LoadDanhSachLenLuoi(ttcn_);
                }
                MainPageView.SelectedPage = pvNT_LayPhieuXuat;
                return;
            }
            
            fNT_LayPhieuXuat.TopLevel = false;
            fNT_LayPhieuXuat.FormBorderStyle = FormBorderStyle.None;
            fNT_LayPhieuXuat.Dock = DockStyle.Fill;

            pvNT_LayPhieuXuat = new Telerik.WinControls.UI.RadPageViewPage();
            pvNT_LayPhieuXuat.Text = "NT-Lấy Phiếu Xuất";
            MainPageView.Pages.Add(pvNT_LayPhieuXuat);
            pvNT_LayPhieuXuat.Controls.Add(fNT_LayPhieuXuat);
            fNT_LayPhieuXuat.Show();
            MainPageView.SelectedPage = pvNT_LayPhieuXuat;
            DSNT_LayPhieuXuatIsOpen = true;
        }

        private void rbtnNTNhapKho_Click(object sender, EventArgs e)
        {
            if (DSNT_NhapKhoIsOpen == true)
            {
                CSQLNT_NhapKho nt_nhapkho = new CSQLNT_NhapKho();
                fNT_NhapKho.rgvDSPhieuNhap.DataSource = nt_nhapkho.LayDanhSachLenLuoi(IsXemTatCa_);
                MainPageView.SelectedPage = pvNT_NhapKho;
                return;
            }
            else
            {
                fNT_NhapKho = new frmNT_NhapKho(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_NhapKho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_NhapKho.TopLevel = false;
                fNT_NhapKho.FormBorderStyle = FormBorderStyle.None;
                fNT_NhapKho.Dock = DockStyle.Fill;

                pvNT_NhapKho = new Telerik.WinControls.UI.RadPageViewPage();
                pvNT_NhapKho.Text = "NT-Nhập Kho";
                MainPageView.Pages.Add(pvNT_NhapKho);
                pvNT_NhapKho.Controls.Add(fNT_NhapKho);
                fNT_NhapKho.Show();
                MainPageView.SelectedPage = pvNT_NhapKho;
                DSNT_NhapKhoIsOpen = true;
            }
        }

        private void rbtnNTKetCa_Click(object sender, EventArgs e)
        {
            if (DSNT_KetCaIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_KetCa;
                return;
            }
            else
            {
                fNT_KetCa = new frmNT_KetCa(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_KetCa.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_KetCa.TopLevel = false;
                fNT_KetCa.FormBorderStyle = FormBorderStyle.None;
                fNT_KetCa.Dock = DockStyle.Fill;

                pvNT_KetCa = new Telerik.WinControls.UI.RadPageViewPage();
                pvNT_KetCa.Text = "Kết Ca";
                MainPageView.Pages.Add(pvNT_KetCa);
                pvNT_KetCa.Controls.Add(fNT_KetCa);
                fNT_KetCa.Show();
                MainPageView.SelectedPage = pvNT_KetCa;
                DSNT_KetCaIsOpen = true;
            }
        }

        private void rbtnNTXacNhanNhapKho_Click(object sender, EventArgs e)
        {
            if (DSNT_NhapKhoXacNhanIsOpen == true)
            {
                CSQLNT_XacNhanNhapKho xnnk = new CSQLNT_XacNhanNhapKho();
                fNT_NhapKhoXacNhan.rgvDSPhieuNhap.DataSource = xnnk.LayDSNTXacNhanNhapKhoLenLuoi();
                MainPageView.SelectedPage = pvNT_NhapKhoXacNhan;
                return;
            }
            else
            {
                fNT_NhapKhoXacNhan = new frmNT_NhapKhoXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_NhapKhoXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_NhapKhoXacNhan.TopLevel = false;
                fNT_NhapKhoXacNhan.FormBorderStyle = FormBorderStyle.None;
                fNT_NhapKhoXacNhan.Dock = DockStyle.Fill;

                pvNT_NhapKhoXacNhan = new RadPageViewPage();
                pvNT_NhapKhoXacNhan.Text = "Nhập kho xác nhận";
                MainPageView.Pages.Add(pvNT_NhapKhoXacNhan);
                pvNT_NhapKhoXacNhan.Controls.Add(fNT_NhapKhoXacNhan);
                fNT_NhapKhoXacNhan.Show();
                MainPageView.SelectedPage = pvNT_NhapKhoXacNhan;
                DSNT_NhapKhoXacNhanIsOpen = true;
            }
        }

        private void rbtnNTBanHang_Click(object sender, EventArgs e)
        {
            if (DSNT_BanHangIsOpen == true)
            {
                CSQLNT_BanHang bh = new CSQLNT_BanHang();
                fNT_BanHang.rgvDSPhieuBanHang.DataSource = bh.LayLenLuoi(IsXemTatCa_, CStaticBien.STenMayThuNgan);
                MainPageView.SelectedPage = pvNT_BanHang;
                return;
            }
            else
            {
                fNT_BanHang = new frmNT_BanHang(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_BanHang.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_BanHang.TopLevel = false;
                fNT_BanHang.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_BanHang.Dock = DockStyle.Fill;

                pvNT_BanHang = new RadPageViewPage();
                pvNT_BanHang.Text = "Bán hàng";
                MainPageView.Pages.Add(pvNT_BanHang);
                pvNT_BanHang.Controls.Add(fNT_BanHang);
                fNT_BanHang.Show();
                MainPageView.SelectedPage = pvNT_BanHang;
                DSNT_BanHangIsOpen = true;
            }
        }

        private void rbtnNTNhapXuatTon_Click(object sender, EventArgs e)
        {
            fNT_NhapXuatTon = new frmNT_NhapXuatTon();
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fNT_NhapXuatTon.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (DSNT_NhapXuatTonIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_NhapXuatTon;
                return;
            }
            fNT_NhapXuatTon.TopLevel = false;
            fNT_NhapXuatTon.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fNT_NhapXuatTon.Dock = DockStyle.Fill;

            pvNT_NhapXuatTon = new RadPageViewPage();
            pvNT_NhapXuatTon.Text = "Nhà thuốc nhập xuất tồn";
            MainPageView.Pages.Add(pvNT_NhapXuatTon);
            pvNT_NhapXuatTon.Controls.Add(fNT_NhapXuatTon);
            fNT_NhapXuatTon.Show();
            MainPageView.SelectedPage = pvNT_NhapXuatTon;
            DSNT_NhapXuatTonIsOpen = true;
        }

        private void rbtnBangDanhMuc_Click(object sender, EventArgs e)
        {
            fBangDanhMuc = new frmBangDanhMuc(this);
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fBangDanhMuc.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (DSBangDanhMucIsOpen == true)
            {
                MainPageView.SelectedPage = pvBangDanhMuc;
                return;
            }
            
            fBangDanhMuc.TopLevel = false;
            fBangDanhMuc.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fBangDanhMuc.Dock = DockStyle.Fill;

            pvBangDanhMuc = new RadPageViewPage();
            pvBangDanhMuc.Text = "Bảng Danh Mục";
            MainPageView.Pages.Add(pvBangDanhMuc);
            pvBangDanhMuc.Controls.Add(fBangDanhMuc);
            fBangDanhMuc.Show();
            MainPageView.SelectedPage = pvBangDanhMuc;
            DSBangDanhMucIsOpen = true;
        }

        private void rbtnNTLayDanhMuc_Click(object sender, EventArgs e)
        {
            fNT_LayDanhMuc = new frmNT_LayDanhMuc(this);
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fNT_LayDanhMuc.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            if (DSNT_LayDanhMucIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_LayDanhMuc;
                return;
            }
            
            fNT_LayDanhMuc.TopLevel = false;
            fNT_LayDanhMuc.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fNT_LayDanhMuc.Dock = DockStyle.Fill;

            pvNT_LayDanhMuc = new RadPageViewPage();
            pvNT_LayDanhMuc.Text = "Lấy Danh Mục";
            MainPageView.Pages.Add(pvNT_LayDanhMuc);
            pvNT_LayDanhMuc.Controls.Add(fNT_LayDanhMuc);
            fNT_LayDanhMuc.Show();
            MainPageView.SelectedPage = pvNT_LayDanhMuc;
            DSNT_LayDanhMucIsOpen = true;
        }

        private void rbtnTraHang_Click(object sender, EventArgs e)
        {
            if (DSNT_TraHangisOpen == true)
            {
                MainPageView.SelectedPage = pvNT_TraHang;
                return;
            }
            else
            {
                fNT_TraHang = new frmNT_TraHang(this);

                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_TraHang.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_TraHang.TopLevel = false;
                fNT_TraHang.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_TraHang.Dock = DockStyle.Fill;

                pvNT_TraHang = new RadPageViewPage();
                pvNT_TraHang.Text = "Trả hàng";
                MainPageView.Pages.Add(pvNT_TraHang);
                pvNT_TraHang.Controls.Add(fNT_TraHang);
                fNT_TraHang.Show();
                MainPageView.SelectedPage = pvNT_TraHang;
                DSNT_TraHangisOpen = true;
            }
        }

        public void HienFrmTraHang()
        {
            if (DSNT_TraHangisOpen == true)
            {
                MainPageView.SelectedPage = pvNT_TraHang;
                return;
            }
            fNT_TraHang = new frmNT_TraHang(this);
            fNT_TraHang.TopLevel = false;
            fNT_TraHang.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fNT_TraHang.Dock = DockStyle.Fill;

            pvNT_TraHang = new RadPageViewPage();
            pvNT_TraHang.Text = "Trả hàng";
            MainPageView.Pages.Add(pvNT_TraHang);
            pvNT_TraHang.Controls.Add(fNT_TraHang);
            fNT_TraHang.Show();
            MainPageView.SelectedPage = pvNT_TraHang;
            DSNT_TraHangisOpen = true;
        }

        private void radButtonElementQuocGia_Click(object sender, EventArgs e)
        {

            if (DSQuocGiaIsOpen == true)
            {
                MainPageView.SelectedPage = pvQuocGia;
                return;
            }
            else
            {
                fQuocGia = new frmQuocGia(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fQuocGia.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                fQuocGia.TopLevel = false;
                fQuocGia.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fQuocGia.Dock = DockStyle.Fill;

                pvQuocGia = new RadPageViewPage();
                pvQuocGia.Text = "Quốc Gia";
                MainPageView.Pages.Add(pvQuocGia);
                pvQuocGia.Controls.Add(fQuocGia);
                fQuocGia.Show();
                MainPageView.SelectedPage = pvQuocGia;
                DSQuocGiaIsOpen = true;
            }
        }

        private void rbtnNTChuyenHang_Click(object sender, EventArgs e)
        {
            if (DSNT_ChuyenHangisOpen == true)
            {
                MainPageView.SelectedPage = pvNT_ChuyenHang;
                return;
            }
            else
            {
                fNT_ChuyenHang = new frmNT_ChuyenHang(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_ChuyenHang.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_ChuyenHang.TopLevel = false;
                fNT_ChuyenHang.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_ChuyenHang.Dock = DockStyle.Fill;

                pvNT_ChuyenHang = new RadPageViewPage();
                pvNT_ChuyenHang.Text = "Chuyển hàng";
                MainPageView.Pages.Add(pvNT_ChuyenHang);
                pvNT_ChuyenHang.Controls.Add(fNT_ChuyenHang);
                fNT_ChuyenHang.Show();
                MainPageView.SelectedPage = pvNT_ChuyenHang;
                DSNT_ChuyenHangisOpen = true;
            }
        }

        private void rbtnNTXacNhanCH_Click(object sender, EventArgs e)
        {
            if (DSNT_ChuyenHangXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_ChuyenHangXacNhan;
                return;
            }
            else
            {
                fNT_ChuyenHangXacNhan_ = new frmNT_ChuyenHangXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_ChuyenHangXacNhan_.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_ChuyenHangXacNhan_.TopLevel = false;
                fNT_ChuyenHangXacNhan_.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_ChuyenHangXacNhan_.Dock = DockStyle.Fill;

                pvNT_ChuyenHangXacNhan = new RadPageViewPage();
                pvNT_ChuyenHangXacNhan.Text = "Xác nhận chuyển hàng";
                MainPageView.Pages.Add(pvNT_ChuyenHangXacNhan);
                pvNT_ChuyenHangXacNhan.Controls.Add(fNT_ChuyenHangXacNhan_);
                fNT_ChuyenHangXacNhan_.Show();
                MainPageView.SelectedPage = pvNT_ChuyenHangXacNhan;
                DSNT_ChuyenHangXacNhanIsOpen = true;
            }
        }

        private void rbtnChuyenKho_Click(object sender, EventArgs e)
        {
            if (DSChuyenKhoIsOpen == true)
            {
                MainPageView.SelectedPage = pvChuyenKho;
                return;
            }
            else
            {
                fChuyenKho = new frmChuyenKho(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fChuyenKho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fChuyenKho.TopLevel = false;
                fChuyenKho.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fChuyenKho.Dock = DockStyle.Fill;

                pvChuyenKho = new RadPageViewPage();
                pvChuyenKho.Text = "Chuyển Kho";
                MainPageView.Pages.Add(pvChuyenKho);
                pvChuyenKho.Controls.Add(fChuyenKho);
                fChuyenKho.Show();
                MainPageView.SelectedPage = pvChuyenKho;
                DSChuyenKhoIsOpen = true;
            }
        }

        private void rbtnXacNhanChuyenKho_Click(object sender, EventArgs e)
        {
            if (DSChuyenKhoXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvChuyenKhoXacNhan;
                return;
            }
            else
            {
                fChuyenKhoXacNhan = new frmChuyenKhoXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fChuyenKhoXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fChuyenKhoXacNhan.TopLevel = false;
                fChuyenKhoXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fChuyenKhoXacNhan.Dock = DockStyle.Fill;

                pvChuyenKhoXacNhan = new RadPageViewPage();
                pvChuyenKhoXacNhan.Text = "Chuyển Kho Xác Nhận";
                MainPageView.Pages.Add(pvChuyenKhoXacNhan);
                pvChuyenKhoXacNhan.Controls.Add(fChuyenKhoXacNhan);
                fChuyenKhoXacNhan.Show();
                MainPageView.SelectedPage = pvChuyenKhoXacNhan;
                DSChuyenKhoXacNhanIsOpen = true;
            }
        }

        private void rbtnNTChuyenKho_Click(object sender, EventArgs e)
        {
            if (DSChuyenKhoIsOpen == true)
            {
                MainPageView.SelectedPage = pvChuyenKho;
                return;
            }
            else
            {
                fChuyenKho = new frmChuyenKho(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fChuyenKho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fChuyenKho.TopLevel = false;
                fChuyenKho.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fChuyenKho.Dock = DockStyle.Fill;

                pvChuyenKho = new RadPageViewPage();
                pvChuyenKho.Text = "Chuyển Kho";
                MainPageView.Pages.Add(pvChuyenKho);
                pvChuyenKho.Controls.Add(fChuyenKho);
                fChuyenKho.Show();
                MainPageView.SelectedPage = pvChuyenKho;
                DSChuyenKhoIsOpen = true;
            }
        }

        private void rbtnNTXacNhanCK_Click(object sender, EventArgs e)
        {
            if (DSChuyenKhoXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvChuyenKhoXacNhan;
                return;
            }
            else
            {
                fChuyenKhoXacNhan = new frmChuyenKhoXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fChuyenKhoXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fChuyenKhoXacNhan.TopLevel = false;
                fChuyenKhoXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fChuyenKhoXacNhan.Dock = DockStyle.Fill;

                pvChuyenKhoXacNhan = new RadPageViewPage();
                pvChuyenKhoXacNhan.Text = "Chuyển Kho Xác Nhận";
                MainPageView.Pages.Add(pvChuyenKhoXacNhan);
                pvChuyenKhoXacNhan.Controls.Add(fChuyenKhoXacNhan);
                fChuyenKhoXacNhan.Show();
                MainPageView.SelectedPage = pvChuyenKhoXacNhan;
                DSChuyenKhoXacNhanIsOpen = true;
            }
        }

        private void rbtnNhanChuyenHang_Click(object sender, EventArgs e)
        {
            if (DSNhanCHuyenHangIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhanChuyenHang;
                return;
            }
            else
            {
                fNhanChuyenHang = new frmNhanChuyenHang(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhanChuyenHang.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhanChuyenHang.TopLevel = false;
                fNhanChuyenHang.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNhanChuyenHang.Dock = DockStyle.Fill;

                pvNhanChuyenHang = new RadPageViewPage();
                pvNhanChuyenHang.Text = "Nhận Chuyển Hàng";
                MainPageView.Pages.Add(pvNhanChuyenHang);
                pvNhanChuyenHang.Controls.Add(fNhanChuyenHang);
                fNhanChuyenHang.Show();
                MainPageView.SelectedPage = pvNhanChuyenHang;
                DSNhanCHuyenHangIsOpen = true;
            }
        }

        private void rbtnXacNhanChuyen_Click(object sender, EventArgs e)
        {
            if (DSNhanCHuyenHangXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhanChuyenHangXacNhan;
                return;
            }
            else
            {
                fNhanChuyenHangXacNhan = new frmNhanChuyenHangXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhanChuyenHangXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhanChuyenHangXacNhan.TopLevel = false;
                fNhanChuyenHangXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNhanChuyenHangXacNhan.Dock = DockStyle.Fill;

                pvNhanChuyenHangXacNhan = new RadPageViewPage();
                pvNhanChuyenHangXacNhan.Text = "Nhận Chuyển Hàng Xác Nhận";
                MainPageView.Pages.Add(pvNhanChuyenHangXacNhan);
                pvNhanChuyenHangXacNhan.Controls.Add(fNhanChuyenHangXacNhan);
                fNhanChuyenHangXacNhan.Show();
                MainPageView.SelectedPage = pvNhanChuyenHangXacNhan;
                DSNhanCHuyenHangXacNhanIsOpen = true;
            }
        }

        private void rbtnNTNhanChuyen_Click(object sender, EventArgs e)
        {
            if (DSNT_NhanPhieuChuyenIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_NhanPhieuChuyen;
                return;
            }
            else
            {
                fNT_NhanPhieuChuyen = new frmNT_NhanPhieuChuyen(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_NhanPhieuChuyen.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_NhanPhieuChuyen.TopLevel = false;
                fNT_NhanPhieuChuyen.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_NhanPhieuChuyen.Dock = DockStyle.Fill;

                pvNT_NhanPhieuChuyen = new RadPageViewPage();
                pvNT_NhanPhieuChuyen.Text = "Nhận phiếu chuyển";
                MainPageView.Pages.Add(pvNT_NhanPhieuChuyen);
                pvNT_NhanPhieuChuyen.Controls.Add(fNT_NhanPhieuChuyen);
                fNT_NhanPhieuChuyen.Show();
                MainPageView.SelectedPage = pvNT_NhanPhieuChuyen;
                DSNT_NhanPhieuChuyenIsOpen = true;
            }
        }

        private void rbtnLayPhieuChuyen_Click(object sender, EventArgs e)
        {
            if (DSNT_LayPhieuChuyenIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_LayPhieuChuyen;
                return;
            }
            else
            {
                fNT_LayPhieuChuyen = new frmNT_LayPhieuChuyen(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_LayPhieuChuyen.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_LayPhieuChuyen.TopLevel = false;
                fNT_LayPhieuChuyen.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_LayPhieuChuyen.Dock = DockStyle.Fill;

                pvNT_LayPhieuChuyen = new RadPageViewPage();
                pvNT_LayPhieuChuyen.Text = "Nhận phiếu chuyển";
                MainPageView.Pages.Add(pvNT_LayPhieuChuyen);
                pvNT_LayPhieuChuyen.Controls.Add(fNT_LayPhieuChuyen);
                fNT_LayPhieuChuyen.Show();
                MainPageView.SelectedPage = pvNT_LayPhieuChuyen;
                DSNT_LayPhieuChuyenIsOpen = true;
            }
        }

        private void rbtnNTXacNhanNC_Click(object sender, EventArgs e)
        {
            if (DSNT_NhanPhieuChuyenXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_NhanPhieuChuyenXacNhan;
                return;
            }
            else
            {
                fNT_NhanPhieuChuyenXacNhan = new frmNT_NhanPhieuChuyenXacNhan(this);

                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_NhanPhieuChuyenXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_NhanPhieuChuyenXacNhan.TopLevel = false;
                fNT_NhanPhieuChuyenXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_NhanPhieuChuyenXacNhan.Dock = DockStyle.Fill;

                pvNT_NhanPhieuChuyenXacNhan = new RadPageViewPage();
                pvNT_NhanPhieuChuyenXacNhan.Text = "Nhận phiếu chuyển xác nhận";
                MainPageView.Pages.Add(pvNT_NhanPhieuChuyenXacNhan);
                pvNT_NhanPhieuChuyenXacNhan.Controls.Add(fNT_NhanPhieuChuyenXacNhan);
                fNT_NhanPhieuChuyenXacNhan.Show();
                MainPageView.SelectedPage = pvNT_NhanPhieuChuyenXacNhan;
                DSNT_NhanPhieuChuyenXacNhanIsOpen = true;
            }
        }

        private void rbtnNTTraHang_Click(object sender, EventArgs e)
        {
            if (DSNT_TraHangVeCtyIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_TraHangVeCty;
                return;
            }
            else
            {
                fNT_TraHangVeCty = new frmNT_TraHangVeCty(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_TraHangVeCty.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_TraHangVeCty.TopLevel = false;
                fNT_TraHangVeCty.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_TraHangVeCty.Dock = DockStyle.Fill;

                pvNT_TraHangVeCty = new RadPageViewPage();
                pvNT_TraHangVeCty.Text = "Trả hàng về công ty";
                MainPageView.Pages.Add(pvNT_TraHangVeCty);
                pvNT_TraHangVeCty.Controls.Add(fNT_TraHangVeCty);
                fNT_TraHangVeCty.Show();
                MainPageView.SelectedPage = pvNT_TraHangVeCty;
                DSNT_TraHangVeCtyIsOpen = true;
            }
        }

        private void rbtnNTXacNhanTH_Click(object sender, EventArgs e)
        {
            if (DSNT_TraHangVeCtyXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_TraHangVeCtyXacNhan;
                return;
            }
            else
            {
                fNT_TraHangVeCtyXacNhan = new frmNT_TraHangVeCtyXacNhan(this);

                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_TraHangVeCtyXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_TraHangVeCtyXacNhan.TopLevel = false;
                fNT_TraHangVeCtyXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_TraHangVeCtyXacNhan.Dock = DockStyle.Fill;

                pvNT_TraHangVeCtyXacNhan = new RadPageViewPage();
                pvNT_TraHangVeCtyXacNhan.Text = "Xác nhận trả hàng về công ty";
                MainPageView.Pages.Add(pvNT_TraHangVeCtyXacNhan);
                pvNT_TraHangVeCtyXacNhan.Controls.Add(fNT_TraHangVeCtyXacNhan);
                fNT_TraHangVeCtyXacNhan.Show();
                MainPageView.SelectedPage = pvNT_TraHangVeCtyXacNhan;
                DSNT_TraHangVeCtyXacNhanIsOpen = true;
            }
        }

        private void rbtnNTraHang_Click(object sender, EventArgs e)
        {
            if (DSNhanTraHangIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhanTraHang;
                return;
            }
            else
            {
                fNhanTraHang = new frmNhanTraHang(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhanTraHang.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhanTraHang.TopLevel = false;
                fNhanTraHang.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNhanTraHang.Dock = DockStyle.Fill;

                pvNhanTraHang = new RadPageViewPage();
                pvNhanTraHang.Text = "Nhận trả hàng";
                MainPageView.Pages.Add(pvNhanTraHang);
                pvNhanTraHang.Controls.Add(fNhanTraHang);
                fNhanTraHang.Show();
                MainPageView.SelectedPage = pvNhanTraHang;
                DSNhanTraHangIsOpen = true;
            }
        }

        private void rbtnXacNhanTraHang_Click(object sender, EventArgs e)
        {

            if (DSNhanTraHangXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhanTraHangXacNhan;
                return;
            }
            else
            {
                fNhanTraHangXacNhan = new frmNhanTraHangXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhanTraHangXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhanTraHangXacNhan.TopLevel = false;
                fNhanTraHangXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNhanTraHangXacNhan.Dock = DockStyle.Fill;

                pvNhanTraHangXacNhan = new RadPageViewPage();
                pvNhanTraHangXacNhan.Text = "Xác nhận trả hàng về công ty";
                MainPageView.Pages.Add(pvNhanTraHangXacNhan);
                pvNhanTraHangXacNhan.Controls.Add(fNhanTraHangXacNhan);
                fNhanTraHangXacNhan.Show();
                MainPageView.SelectedPage = pvNhanTraHangXacNhan;
                DSNhanTraHangXacNhanIsOpen = true;
            }
        }

        private void rbtnDieuChinhTon_Click(object sender, EventArgs e)
        {
            if (DSDieuChinhTonIsOpen == true)
            {
                MainPageView.SelectedPage = pvDieuChinhTon;
                return;
            }
            else
            {
                fDieuChinhTon = new frmDieuChinhTon(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fDieuChinhTon.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fDieuChinhTon.TopLevel = false;
                fDieuChinhTon.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fDieuChinhTon.Dock = DockStyle.Fill;

                pvDieuChinhTon = new RadPageViewPage();
                pvDieuChinhTon.Text = "Điều Chỉnh Tồn Kho";
                MainPageView.Pages.Add(pvDieuChinhTon);
                pvDieuChinhTon.Controls.Add(fDieuChinhTon);
                fDieuChinhTon.Show();
                MainPageView.SelectedPage = pvDieuChinhTon;
                DSDieuChinhTonIsOpen = true;
            }
        }

        private void rbtnXacNhanDieuChinh_Click(object sender, EventArgs e)
        {
            if (DSDieuChinhTonXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvDieuChinhTonXacNhan;
                return;
            }
            else
            {
                fDieuChinhTonXacNhan = new frmDieuChinhTonXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fDieuChinhTonXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fDieuChinhTonXacNhan.TopLevel = false;
                fDieuChinhTonXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fDieuChinhTonXacNhan.Dock = DockStyle.Fill;

                pvDieuChinhTonXacNhan = new RadPageViewPage();
                pvDieuChinhTonXacNhan.Text = "Điều Chỉnh Tồn Kho Xác Nhận";
                MainPageView.Pages.Add(pvDieuChinhTonXacNhan);
                pvDieuChinhTonXacNhan.Controls.Add(fDieuChinhTonXacNhan);
                fDieuChinhTonXacNhan.Show();
                MainPageView.SelectedPage = pvDieuChinhTonXacNhan;
                DSDieuChinhTonXacNhanIsOpen = true;
            }
        }

        private void rbtnLayDieuChinh_Click(object sender, EventArgs e)
        {
            fNT_LayPhieuDieuChinhTonKho = new frmNT_LayPhieuDieuChinhTon(this);
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fNT_LayPhieuDieuChinhTonKho.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (DSNT_LayPhieuDieuChinhTonKhoIsOpen == true)
            {
                CRmtServer KetNoiServer = new CRmtServer();
                if (KetNoiServer.KiemTraKetNoiRmtServer() == false)
                {
                    MessageBox.Show("Kết nối server không thành công. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
                    CSQLNT_LayPhieuDieuChinhTon nt_layphieudcton_ = new CSQLNT_LayPhieuDieuChinhTon();
                    string ttcn_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
                    fNT_LayPhieuDieuChinhTonKho.rgvPhieuDieuChinh.DataSource = nt_layphieudcton_.LoadDanhSachLenLuoi(ttcn_);
                }
                MainPageView.SelectedPage = pvNT_LayPhieuDieuChinhTonKho;
                return;
            }
            
            fNT_LayPhieuDieuChinhTonKho.TopLevel = false;
            fNT_LayPhieuDieuChinhTonKho.FormBorderStyle = FormBorderStyle.None;
            fNT_LayPhieuDieuChinhTonKho.Dock = DockStyle.Fill;

            pvNT_LayPhieuDieuChinhTonKho = new Telerik.WinControls.UI.RadPageViewPage();
            pvNT_LayPhieuDieuChinhTonKho.Text = "NT-Lấy Phiếu Kiểm Kê";
            MainPageView.Pages.Add(pvNT_LayPhieuDieuChinhTonKho);
            pvNT_LayPhieuDieuChinhTonKho.Controls.Add(fNT_LayPhieuDieuChinhTonKho);
            fNT_LayPhieuDieuChinhTonKho.Show();
            MainPageView.SelectedPage = pvNT_LayPhieuDieuChinhTonKho;
            DSNT_LayPhieuDieuChinhTonKhoIsOpen = true;
        }

        private void rbtnChinhTon_Click(object sender, EventArgs e)
        {
            if (DSNT_DieuChinhTonIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_DieuChinhTon;
                return;
            }
            else
            {
                fNT_DieuChinhTon = new frmNT_DieuChinhTon(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_DieuChinhTon.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_DieuChinhTon = new frmNT_DieuChinhTon(this);
                fNT_DieuChinhTon.TopLevel = false;
                fNT_DieuChinhTon.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_DieuChinhTon.Dock = DockStyle.Fill;

                pvNT_DieuChinhTon = new RadPageViewPage();
                pvNT_DieuChinhTon.Text = "Điều Chỉnh Tồn Kho";
                MainPageView.Pages.Add(pvNT_DieuChinhTon);
                pvNT_DieuChinhTon.Controls.Add(fNT_DieuChinhTon);
                fNT_DieuChinhTon.Show();
                MainPageView.SelectedPage = pvNT_DieuChinhTon;
                DSNT_DieuChinhTonIsOpen = true;
            }
        }

        private void rbtnXacNhanChinhTon_Click(object sender, EventArgs e)
        {
            if (DSNT_DieuChinhTonXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_DieuChinhTonXacNhan;
                return;
            }
            else
            {
                fNT_DieuChinhTonXacNhan = new frmNT_DieuChinhTonXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_DieuChinhTonXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                fNT_DieuChinhTonXacNhan.TopLevel = false;
                fNT_DieuChinhTonXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_DieuChinhTonXacNhan.Dock = DockStyle.Fill;

                pvNT_DieuChinhTonXacNhan = new RadPageViewPage();
                pvNT_DieuChinhTonXacNhan.Text = "Điều Chỉnh Tồn Kho Xác Nhận";
                MainPageView.Pages.Add(pvNT_DieuChinhTonXacNhan);
                pvNT_DieuChinhTonXacNhan.Controls.Add(fNT_DieuChinhTonXacNhan);
                fNT_DieuChinhTonXacNhan.Show();
                MainPageView.SelectedPage = pvNT_DieuChinhTonXacNhan;
                DSNT_DieuChinhTonXacNhanIsOpen = true;
            }
        }

        private void rbtnPhanNhom_Click(object sender, EventArgs e)
        {
            if (DSNhomNguoiDungIsOpen == true)
            {
                MainPageView.SelectedPage = pvNhomNguoiDung;
                return;
            }
            else
            {
                fNhomNguoiDung = new frmNhomNguoiDung(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNhomNguoiDung.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNhomNguoiDung.TopLevel = false;
                fNhomNguoiDung.FormBorderStyle = FormBorderStyle.None;
                fNhomNguoiDung.Dock = DockStyle.Fill;
                pvNhomNguoiDung = new Telerik.WinControls.UI.RadPageViewPage();
                pvNhomNguoiDung.Text = "Nhóm Người Dùng";
                MainPageView.Pages.Add(pvNhomNguoiDung);
                pvNhomNguoiDung.Controls.Add(fNhomNguoiDung);
                fNhomNguoiDung.Show();
                MainPageView.SelectedPage = pvNhomNguoiDung;
                DSNhomNguoiDungIsOpen = true;
            }
        }

        private void rbtnPhanQuyen_Click(object sender, EventArgs e)
        {
            if (DSPhanQuyenIsOpen == true)
            {
                MainPageView.SelectedPage = pvPhanQuyen;
                return;
            }
            else
            {
                fPhanQuyen = new frmPhanQuyen(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fPhanQuyen.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                fPhanQuyen.TopLevel = false;
                fPhanQuyen.FormBorderStyle = FormBorderStyle.None;
                fPhanQuyen.Dock = DockStyle.Fill;

                pvPhanQuyen = new Telerik.WinControls.UI.RadPageViewPage();
                pvPhanQuyen.Text = "Phân Quyền";
                MainPageView.Pages.Add(pvPhanQuyen);
                pvPhanQuyen.Controls.Add(fPhanQuyen);
                fPhanQuyen.Show();
                MainPageView.SelectedPage = pvPhanQuyen;
                DSPhanQuyenIsOpen = true;
            }
        }

        private void rbtnKhachHang_Click(object sender, EventArgs e)
        {            
            //if (KiemTraQuyenChiTiet(fNhaPhanPhoi.Name.ToString()) == false)
            //{
            //    MessageBox.Show("Bạn Chưa Có Quyền Truy Cập Chức Năng Này !");
            //    return;
            //}
        }

        private void rbtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (DSDoiMatKhauIsOpen == true)
            {
                MainPageView.SelectedPage = pvDoiMatKhau;
                return;
            }
            else
            {
                fDoiMatKhau_ = new frmDoiMatKhau(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fDoiMatKhau_.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                fDoiMatKhau_.TopLevel = false;
                fDoiMatKhau_.FormBorderStyle = FormBorderStyle.None;
                fDoiMatKhau_.Dock = DockStyle.Fill;

                pvDoiMatKhau = new Telerik.WinControls.UI.RadPageViewPage();
                pvDoiMatKhau.Text = "Đổi Mật Khẩu";
                MainPageView.Pages.Add(pvDoiMatKhau);
                pvDoiMatKhau.Controls.Add(fDoiMatKhau_);
                fDoiMatKhau_.Show();
                MainPageView.SelectedPage = pvDoiMatKhau;
                DSDoiMatKhauIsOpen = true;
            }
        }

        private void rbtnDH_Click(object sender, EventArgs e)
        {
            if (DSNT_DatHangIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_DatHang;
                return;
            }
            else
            {
                fNT_DatHang = new frmNT_DatHang(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_DatHang.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_DatHang.TopLevel = false;
                fNT_DatHang.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_DatHang.Dock = DockStyle.Fill;

                pvNT_DatHang = new RadPageViewPage();
                pvNT_DatHang.Text = "Đặt Hàng";
                MainPageView.Pages.Add(pvNT_DatHang);
                pvNT_DatHang.Controls.Add(fNT_DatHang);
                fNT_DatHang.Show();
                MainPageView.SelectedPage = pvNT_DatHang;
                DSNT_DatHangIsOpen = true;
            }
        }

        private void rbtnXNDH_Click(object sender, EventArgs e)
        {
            if (DSNT_DatHangXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_DatHangXacNhan;
                return;
            }
            else
            {
                fNT_DatHangXacNhan = new frmNT_DatHangXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_DatHangXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_DatHangXacNhan.TopLevel = false;
                fNT_DatHangXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_DatHangXacNhan.Dock = DockStyle.Fill;

                pvNT_DatHangXacNhan = new RadPageViewPage();
                pvNT_DatHangXacNhan.Text = "Xác Nhận Đặt Hàng";
                MainPageView.Pages.Add(pvNT_DatHangXacNhan);
                pvNT_DatHangXacNhan.Controls.Add(fNT_DatHangXacNhan);
                fNT_DatHangXacNhan.Show();
                MainPageView.SelectedPage = pvNT_DatHangXacNhan;
                DSNT_DatHangXacNhanIsOpen = true;
            }
        }

        private void rbtnTaiKhoan_Click(object sender, EventArgs e)
        {
            if (DSUserIsOpen == true)
            {
                MainPageView.SelectedPage = pvUser;
                return;
            }
            else
            {
                fUser = new frmUser(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fUser.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fUser.TopLevel = false;
                fUser.FormBorderStyle = FormBorderStyle.None;
                fUser.Dock = DockStyle.Fill;

                pvUser = new Telerik.WinControls.UI.RadPageViewPage();
                pvUser.Text = "Đổi Mật Khẩu";
                MainPageView.Pages.Add(pvUser);
                pvUser.Controls.Add(fUser);
                fUser.Show();
                MainPageView.SelectedPage = pvUser;
                DSUserIsOpen = true;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MainPageView.SelectedPage == null)
            {
                return;
            }
            //Hà: in Chuyển Kho
            #region
            if ((MainPageView.SelectedPage == pvChuyenKho) && (frmChuyenKhoEditisOpen_ == false))
            {
                try
                {
                    fChuyenKhoEdit_ = new frmChuyenKhoEdit();
                    string ckid = fChuyenKho.rgvChuyenKho.CurrentRow.Cells["colCKid"].Value.ToString();
                    fChuyenKhoEdit_.InChuyenKho(ckid);
                }
                catch { }
            }
            #endregion

            //Hà: in Điều chỉnh tồn kho
            #region
            if ((MainPageView.SelectedPage == pvDieuChinhTon) && (frmDieuChinhTonEditisOpen_ == false))
            {
                fDieuChinhTonEdit_ = new frmDieuChinhTonEdit();
                string DCTKid_ = fDieuChinhTon.rgvPhieuDCTon.CurrentRow.Cells["colDCTKid"].Value.ToString();
                fDieuChinhTonEdit_.InDieuChinhTon(DCTKid_);
            }
            #endregion

            //Hà: in Đơn Hàng Xuất
            #region
            if ((MainPageView.SelectedPage == pvDonHangXuat) && (frmDonHangXuatEditisOpen_ == false))
            {
                fDonHangXuatEdit_ = new frmDonHangXuatEdit();
                string DCHXid_ = fDonHangXuat.rgvDSDonHangXuat.CurrentRow.Cells["colDHid"].Value.ToString();
                fDonHangXuatEdit_.InDonHangXuat(DCHXid_);
            }
            #endregion

            //Hà: in NT Chuyển Hàng
            #region
            if ((MainPageView.SelectedPage == pvNT_ChuyenHang) && (frmNT_ChuyenHangEditisOpen_ == false))
            {
                if (fNT_ChuyenHang.rgvChuyenHang.CurrentRow.Cells["colCHID"].Value.ToString() == null)
                {
                    return;
                }
                fNT_ChuyenHangEdit_ = new frmNT_ChuyenHangEdit();
                string CHID_ = fNT_ChuyenHang.rgvChuyenHang.CurrentRow.Cells["colCHID"].Value.ToString();
                fNT_ChuyenHangEdit_.InChuyenHang(CHID_);
            }
            #endregion

            //Hà: in NT Nhận Điều chỉnh tồn kho
            #region
            if ((MainPageView.SelectedPage == pvNT_DieuChinhTon) && (frmNT_DieuChinhTonEditisOpen_ == false))
            {
                fNT_DieuChinhTonEdit_ = new frmNT_DieuChinhTonEdit();
                string DCTKid_ = fNT_DieuChinhTon.rgvDieuChinhTon.CurrentRow.Cells["colDCTKid"].Value.ToString();
                fNT_DieuChinhTonEdit_.InNT_DieuChinhTon(DCTKid_);
            }
            #endregion

            //Hà: in NT Trả Hàng về cty
            #region
            if ((MainPageView.SelectedPage == pvNT_TraHangVeCty) && (frmNT_TraHangVeCTyEditisOpen_ == false))
            {
                fNT_TraHangVeCtyEdit = new frmNT_TraHangVeCtyEdit();
                string THid_ = fNT_TraHangVeCty.rgvTraHang.CurrentRow.Cells["colTHID"].Value.ToString();
                fNT_TraHangVeCtyEdit.InNT_TraHangVeCty(THid_);
            }
            #endregion

            //Hà: in Xuất Nhanh
            #region 
            if ((MainPageView.SelectedPage == pvXuatNhanh) && (frmXuatNhanhEditisOpen_ == false))
            {
                fXuatNhanhEdit_ = new frmXuatNhanhEdit();
                string xnid_ = fXuatNhanh.radGridView1.CurrentRow.Cells["colXNID"].Value.ToString();
                fXuatNhanhEdit_.InXuatNhanh(xnid_);
            }
            #endregion

            //Hà: in Đặt Hàng
            #region
            if ((MainPageView.SelectedPage == pvNT_DatHang) && (frmNT_DatHangEditisOpen_ == false))
            {
                fNT_DatHangEdit_ = new frmNT_DatHangEdit();
                string dhid_ = fNT_DatHang.rgvDatHang.CurrentRow.Cells["colDHID"].Value.ToString();
                fNT_DatHangEdit_.InDatHang(dhid_);
            }
            #endregion

            //Hà: in Thay Đổi Giá SP
            #region
            if ((MainPageView.SelectedPage == pvNT_ThayDoiGiaSP) && (frmNT_ThayDoiGiaSPEditisOpen_ == false))
            {
                fNT_ThayDoiGiaSPEdit = new frmNT_ThayDoiGiaSPEdit();
                string TDGid_ = fNT_ThayDoiGiaSP.rgvThayDoiGia.CurrentRow.Cells["colTDGID"].Value.ToString();
                fNT_ThayDoiGiaSPEdit.InThayDoiGiaSP(TDGid_);
            }
            #endregion
        }

        private void rbtnXuatNhanh_Click(object sender, EventArgs e)
        {
            if (DSXuatNhanhisOpen == true)
            {
                MainPageView.SelectedPage = pvXuatNhanh;
                return;
            }
            else
            {
                fXuatNhanh = new frmXuatNhanh(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fXuatNhanh.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                fXuatNhanh.TopLevel = false;
                fXuatNhanh.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fXuatNhanh.Dock = DockStyle.Fill;

                pvXuatNhanh = new RadPageViewPage();
                pvXuatNhanh.Text = "Xuất Nhanh";
                MainPageView.Pages.Add(pvXuatNhanh);
                pvXuatNhanh.Controls.Add(fXuatNhanh);
                fXuatNhanh.Show();
                MainPageView.SelectedPage = pvXuatNhanh;
                DSXuatNhanhisOpen = true;
            }
        }

        private void rbtnXacNhanXuatNhanh_Click(object sender, EventArgs e)
        {
            if (DSXuatNhanhXacNhanisOpen == true)
            {
                MainPageView.SelectedPage = pvXuatNhanhXacNhan;
                return;
            }
            else
            {
                fXuatNhanhXacNhan = new frmXuatNhanhXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fXuatNhanhXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fXuatNhanhXacNhan.TopLevel = false;
                fXuatNhanhXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fXuatNhanhXacNhan.Dock = DockStyle.Fill;

                pvXuatNhanhXacNhan = new RadPageViewPage();
                pvXuatNhanhXacNhan.Text = "Xác Nhận Xuất Nhanh";
                MainPageView.Pages.Add(pvXuatNhanhXacNhan);
                pvXuatNhanhXacNhan.Controls.Add(fXuatNhanhXacNhan);
                fXuatNhanhXacNhan.Show();
                MainPageView.SelectedPage = pvXuatNhanhXacNhan;
                DSXuatNhanhXacNhanisOpen = true;
            }
        }

        private void rbtnThayDoiGia_Click(object sender, EventArgs e)
        {
            if (DSNT_ThayDoiGiaSPisOpen == true)
            {
                MainPageView.SelectedPage = pvNT_ThayDoiGiaSP;
                return;
            }
            else
            {
                fNT_ThayDoiGiaSP = new frmNT_ThayDoiGiaSP(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_ThayDoiGiaSP.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                fNT_ThayDoiGiaSP.TopLevel = false;
                fNT_ThayDoiGiaSP.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_ThayDoiGiaSP.Dock = DockStyle.Fill;

                pvNT_ThayDoiGiaSP = new RadPageViewPage();
                pvNT_ThayDoiGiaSP.Text = "Thay đổi giá";
                MainPageView.Pages.Add(pvNT_ThayDoiGiaSP);
                pvNT_ThayDoiGiaSP.Controls.Add(fNT_ThayDoiGiaSP);
                fNT_ThayDoiGiaSP.Show();
                MainPageView.SelectedPage = pvNT_ThayDoiGiaSP;
                DSNT_ThayDoiGiaSPisOpen = true;
            }
        }

        private void rbtnBCTonCty_Click(object sender, EventArgs e)
        {
            if (DSBaoCaoCtyisOpen == true)
            {
                MainPageView.SelectedPage = pvBaoCaoCty;
                return;
            }
            else
            {
                fBaoCaoCty = new frmBaoCaoCongTy(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fBaoCaoCty.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fBaoCaoCty.TopLevel = false;
                fBaoCaoCty.FormBorderStyle = FormBorderStyle.None;
                fBaoCaoCty.Dock = DockStyle.Fill;

                pvBaoCaoCty = new Telerik.WinControls.UI.RadPageViewPage();
                pvBaoCaoCty.Text = "Nhóm Báo Cáo Trên Tổng Công Ty";
                MainPageView.Pages.Add(pvBaoCaoCty);
                pvBaoCaoCty.Controls.Add(fBaoCaoCty);
                fBaoCaoCty.Show();
                MainPageView.SelectedPage = pvBaoCaoCty;
                DSBaoCaoCtyisOpen = true;
            }

        }

        private void rbtnBCTonNT_Click(object sender, EventArgs e)
        {
            if (DSBaoCaoNTisOpen == true)
            {
                MainPageView.SelectedPage = pvBaoCaoNT;
                return;
            }
            else
            {
                fBaoCaoNT = new frmBaoCaoNhaThuoc(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fBaoCaoNT.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fBaoCaoNT.TopLevel = false;
                fBaoCaoNT.FormBorderStyle = FormBorderStyle.None;
                fBaoCaoNT.Dock = DockStyle.Fill;

                pvBaoCaoNT = new Telerik.WinControls.UI.RadPageViewPage();
                pvBaoCaoNT.Text = "Nhóm Báo Cáo Nhà Thuốc";
                MainPageView.Pages.Add(pvBaoCaoNT);
                pvBaoCaoNT.Controls.Add(fBaoCaoNT);
                fBaoCaoNT.Show();
                MainPageView.SelectedPage = pvBaoCaoNT;
                DSBaoCaoNTisOpen = true;
            }
        }

        private void rbtnSP_NPP_Click(object sender, EventArgs e)
        {
            if (DSSanPham_NPPIsOpen == true)
            {
                MainPageView.SelectedPage = pvSanPham_NPP;
                return;
            }
            else
            {
                fSanPham_NPP = new frmSanPham_NPP(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fSanPham_NPP.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fSanPham_NPP.TopLevel = false;
                fSanPham_NPP.FormBorderStyle = FormBorderStyle.None;
                fSanPham_NPP.Dock = DockStyle.Fill;

                pvSanPham_NPP = new Telerik.WinControls.UI.RadPageViewPage();
                pvSanPham_NPP.Text = "Sản Phẩm - Nhà Phân Phối";
                MainPageView.Pages.Add(pvSanPham_NPP);
                pvSanPham_NPP.Controls.Add(fSanPham_NPP);
                fSanPham_NPP.Show();
                MainPageView.SelectedPage = pvSanPham_NPP;
                DSSanPham_NPPIsOpen = true;
            }
        }

        private void rbtnDHTong_Click(object sender, EventArgs e)
        {
            if (DSDonHangMuaTongIsOpen == true)
            {
                MainPageView.SelectedPage = pvDonHangMuaTong;
                return;
            }
            else
            {
                fDonHangMuaTong = new frmDonHangMuaTong(this);

                //CQuyenTruyCap qtc = new CQuyenTruyCap();
                //if (qtc.KiemTraQuyenXem(fSanPham_NPP.Name) == false)
                //{
                //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                //    return;
                //}
                fDonHangMuaTong.TopLevel = false;
                fDonHangMuaTong.FormBorderStyle = FormBorderStyle.None;
                fDonHangMuaTong.Dock = DockStyle.Fill;

                pvDonHangMuaTong = new Telerik.WinControls.UI.RadPageViewPage();
                pvDonHangMuaTong.Text = "Đơn Hàng Mua Tổng";
                MainPageView.Pages.Add(pvDonHangMuaTong);
                pvDonHangMuaTong.Controls.Add(fDonHangMuaTong);
                fDonHangMuaTong.Show();
                MainPageView.SelectedPage = pvDonHangMuaTong;
                DSDonHangMuaTongIsOpen = true;
            }
        }

        private void rbtnDHMua_Click(object sender, EventArgs e)
        {
            if (DSDonHangMuaIsOpen == true)
            {
                MainPageView.SelectedPage = pvDonHangMua;
                return;
            }
            else
            {
                fDonHangMua = new frmDonHangMua(this);
                //CQuyenTruyCap qtc = new CQuyenTruyCap();
                //if (qtc.KiemTraQuyenXem(fSanPham_NPP.Name) == false)
                //{
                //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                //    return;
                //}
                fDonHangMua.TopLevel = false;
                fDonHangMua.FormBorderStyle = FormBorderStyle.None;
                fDonHangMua.Dock = DockStyle.Fill;

                pvDonHangMua = new Telerik.WinControls.UI.RadPageViewPage();
                pvDonHangMua.Text = "Đơn Hàng Mua";
                MainPageView.Pages.Add(pvDonHangMua);
                pvDonHangMua.Controls.Add(fDonHangMua);
                fDonHangMua.Show();
                MainPageView.SelectedPage = pvDonHangMua;
                DSDonHangMuaIsOpen = true;
            }
        }

        private void rbtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDuLieuLenLuoi();
        }

        private void ckXemTatCa_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            LoadDuLieuLenLuoi();
        }

        private void rbtnKetThucChuKy_Click(object sender, EventArgs e)
        {
            if (DSChuKyisOpen == true)
            {
                MainPageView.SelectedPage = pvChuKy;
                return;
            }
            else
            {
                fChuKy = new FrmChuKy(this);
                //CQuyenTruyCap qtc = new CQuyenTruyCap();
                //if (qtc.KiemTraQuyenXem(fSanPham_NPP.Name) == false)
                //{
                //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                //    return;
                //}
                fChuKy.TopLevel = false;
                fChuKy.FormBorderStyle = FormBorderStyle.None;
                fChuKy.Dock = DockStyle.Fill;

                pvChuKy = new Telerik.WinControls.UI.RadPageViewPage();
                pvChuKy.Text = "Kết thúc chu kỳ";
                MainPageView.Pages.Add(pvChuKy);
                pvChuKy.Controls.Add(fChuKy);
                fChuKy.Show();
                MainPageView.SelectedPage = pvChuKy;
                DSChuKyisOpen = true;
            }
        }

        private void ckXemTatCa_TextOrientationChanged(object sender, EventArgs e)
        {

        }

        private void rMenuDangXuat_Click(object sender, EventArgs e)
        {
            fDangNhap_.ResetForm();
            this.fDangNhap_.Show();            
            this.Close();
        }

        private void rbtnDieuChinhHSD_Click(object sender, EventArgs e)
        {
            if (DSDieuChinhHSDIsOpen == true)
            {
                MainPageView.SelectedPage = pvDieuChinhHSD;
                return;
            }
            else
            {
                fDieuChinhHSD = new frmDieuChinhHSD(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fDieuChinhHSD.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fDieuChinhHSD.TopLevel = false;
                fDieuChinhHSD.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fDieuChinhHSD.Dock = DockStyle.Fill;

                pvDieuChinhHSD = new RadPageViewPage();
                pvDieuChinhHSD.Text = "Điều Chỉnh HSD";
                MainPageView.Pages.Add(pvDieuChinhHSD);
                pvDieuChinhHSD.Controls.Add(fDieuChinhHSD);
                fDieuChinhHSD.Show();
                MainPageView.SelectedPage = pvDieuChinhHSD;
                DSDieuChinhHSDIsOpen = true;
            }
        }

        private void rbtnXacNhanDieuChinhHSD_Click(object sender, EventArgs e)
        {

            if (DSDieuChinhHSDXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvDieuChinhHSDXacNhan;
                return;
            }
            else
            {
                fDieuChinhHSDXacNhan = new frmDieuChinhHSDXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fDieuChinhHSDXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fDieuChinhHSDXacNhan.TopLevel = false;
                fDieuChinhHSDXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fDieuChinhHSDXacNhan.Dock = DockStyle.Fill;

                pvDieuChinhHSDXacNhan = new RadPageViewPage();
                pvDieuChinhHSDXacNhan.Text = "Điều Chỉnh HSD Xác Nhận";
                MainPageView.Pages.Add(pvDieuChinhHSDXacNhan);
                pvDieuChinhHSDXacNhan.Controls.Add(fDieuChinhHSDXacNhan);
                fDieuChinhHSDXacNhan.Show();
                MainPageView.SelectedPage = pvDieuChinhHSDXacNhan;
                DSDieuChinhHSDXacNhanIsOpen = true;
            }
        }

        private void radStartMenu_Click(object sender, EventArgs e)
        {

        }

        private void rbtnLayDieuChinhHSD_Click(object sender, EventArgs e)
        {
            fNT_LayPhieuDieuChinhHSD = new frmNT_LayPhieuDieuChinhHSD(this);
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenXem(fNT_LayPhieuDieuChinhHSD.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            if (DSNT_LayPhieuDieuChinhHSDIsOpen == true)
            {
                CRmtServer KetNoiServer = new CRmtServer();
                if (KetNoiServer.KiemTraKetNoiRmtServer() == false)
                {
                    MessageBox.Show("Kết nối server không thành công. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
                    CSQLNT_LayPhieuDieuChinhHSD nt_layphieudchsd_ = new CSQLNT_LayPhieuDieuChinhHSD();
                    string ttcn_ = chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString();
                    fNT_LayPhieuDieuChinhHSD.rgvPhieuDieuChinh.DataSource = nt_layphieudchsd_.LoadDanhSachLenLuoi(ttcn_);
                }
                MainPageView.SelectedPage = pvNT_LayPhieuDieuChinhHSD;
                return;
            }

            fNT_LayPhieuDieuChinhHSD.TopLevel = false;
            fNT_LayPhieuDieuChinhHSD.FormBorderStyle = FormBorderStyle.None;
            fNT_LayPhieuDieuChinhHSD.Dock = DockStyle.Fill;

            pvNT_LayPhieuDieuChinhHSD = new Telerik.WinControls.UI.RadPageViewPage();
            pvNT_LayPhieuDieuChinhHSD.Text = "NT-Lấy Phiếu Điều Chỉnh HSD";
            MainPageView.Pages.Add(pvNT_LayPhieuDieuChinhHSD);
            pvNT_LayPhieuDieuChinhHSD.Controls.Add(fNT_LayPhieuDieuChinhHSD);
            fNT_LayPhieuDieuChinhHSD.Show();
            MainPageView.SelectedPage = pvNT_LayPhieuDieuChinhHSD;
            DSNT_LayPhieuDieuChinhHSDIsOpen = true;
        }

        private void rbtnChinhHSD_Click(object sender, EventArgs e)
        {
            if (DSNT_DieuChinhHSDIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_DieuChinhHSD;
                return;
            }
            else
            {
                fNT_DieuChinhHSD = new frmNT_DieuChinhHSD(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_DieuChinhHSD.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fNT_DieuChinhHSD.TopLevel = false;
                fNT_DieuChinhHSD.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_DieuChinhHSD.Dock = DockStyle.Fill;

                pvNT_DieuChinhHSD = new RadPageViewPage();
                pvNT_DieuChinhHSD.Text = "Điều Chỉnh HSD";
                MainPageView.Pages.Add(pvNT_DieuChinhHSD);
                pvNT_DieuChinhHSD.Controls.Add(fNT_DieuChinhHSD);
                fNT_DieuChinhHSD.Show();
                MainPageView.SelectedPage = pvNT_DieuChinhHSD;
                DSNT_DieuChinhHSDIsOpen = true;
            }
        }

        private void rbtnXacNhanChinhHSD_Click(object sender, EventArgs e)
        {
            if (DSNT_DieuChinhHSDXacNhanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_DieuChinhHSDXacNhan;
                return;
            }
            else
            {
                fNT_DieuChinhHSDXacNhan = new frmNT_DieuChinhHSDXacNhan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_DieuChinhHSDXacNhan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                fNT_DieuChinhHSDXacNhan.TopLevel = false;
                fNT_DieuChinhHSDXacNhan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_DieuChinhHSDXacNhan.Dock = DockStyle.Fill;

                pvNT_DieuChinhHSDXacNhan = new RadPageViewPage();
                pvNT_DieuChinhHSDXacNhan.Text = "Điều Chỉnh HSD Xác Nhận";
                MainPageView.Pages.Add(pvNT_DieuChinhHSDXacNhan);
                pvNT_DieuChinhHSDXacNhan.Controls.Add(fNT_DieuChinhHSDXacNhan);
                fNT_DieuChinhHSDXacNhan.Show();
                MainPageView.SelectedPage = pvNT_DieuChinhHSDXacNhan;
                DSNT_DieuChinhHSDXacNhanIsOpen = true;
            }
        }

        private void rbtnNTLichSuGiaBan_Click(object sender, EventArgs e)
        {
            if (DSNT_LichSuGiaBanIsOpen == true)
            {
                MainPageView.SelectedPage = pvNT_LichSuGiaBan;
                return;
            }
            else
            {
                fNT_LichSuGiaBan = new frmNT_LichSuGiaBan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fNT_LichSuGiaBan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                fNT_LichSuGiaBan.TopLevel = false;
                fNT_LichSuGiaBan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fNT_LichSuGiaBan.Dock = DockStyle.Fill;

                pvNT_LichSuGiaBan = new RadPageViewPage();
                pvNT_LichSuGiaBan.Text = "Lịch Sử Giá Bán";
                MainPageView.Pages.Add(pvNT_LichSuGiaBan);
                pvNT_LichSuGiaBan.Controls.Add(fNT_LichSuGiaBan);
                fNT_LichSuGiaBan.Show();
                MainPageView.SelectedPage = pvNT_LichSuGiaBan;
                DSNT_LichSuGiaBanIsOpen = true;
            }
        }

        private void rbtnCauHinhDanhSachNhaThuoc_Click(object sender, EventArgs e)
        {
            if (DSCauHinhNTIsOpen == true)
            {
                MainPageView.SelectedPage = pvCauHinhNT;
                return;
            }
            else
            {
                fCauHinhNT = new frmCauHinhDanhSachNhaThuoc(this);
                fCauHinhNT.TopLevel = false;
                fCauHinhNT.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fCauHinhNT.Dock = DockStyle.Fill;

                pvCauHinhNT = new RadPageViewPage();
                pvCauHinhNT.Text = "Cấu Hình Danh Sách Nhà Thuốc";
                MainPageView.Pages.Add(pvCauHinhNT);
                pvCauHinhNT.Controls.Add(fCauHinhNT);
                fCauHinhNT.Show();
                MainPageView.SelectedPage = pvCauHinhNT;
                DSCauHinhNTIsOpen = true;
            }
        }

        private void radXemLichSuTonKho_Click(object sender, EventArgs e)
        {
            if (frmTonKhoKeToanOpen_ == true)
            {
                MainPageView.SelectedPage = pvXemLichSuTonKhoKeToan;
                return;
            }
            else
            {
                fXemLichSuTonKhoKeToan = new frmXemLichSuTonKhoKeToan(this);
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem(fXemLichSuTonKhoKeToan.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                fXemLichSuTonKhoKeToan.TopLevel = false;
                fXemLichSuTonKhoKeToan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fXemLichSuTonKhoKeToan.Dock = DockStyle.Fill;

                pvXemLichSuTonKhoKeToan = new RadPageViewPage();
                pvXemLichSuTonKhoKeToan.Text = "Xem lịch sử tồn kho kế toán";
                MainPageView.Pages.Add(pvXemLichSuTonKhoKeToan);
                pvXemLichSuTonKhoKeToan.Controls.Add(fXemLichSuTonKhoKeToan);
                fXemLichSuTonKhoKeToan.Show();
                MainPageView.SelectedPage = pvXemLichSuTonKhoKeToan;
                frmTonKhoKeToanOpen_ = true;
            }
        }
    }
}