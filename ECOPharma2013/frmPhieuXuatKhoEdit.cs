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
using Telerik.WinControls;
using ECOPharma2013.Report1;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace ECOPharma2013
{
    public partial class frmPhieuXuatKhoEdit : Telerik.WinControls.UI.RadForm
    {
        frmMain _frmMain;
        public frmPhieuXuatKhoEdit()
        {
            InitializeComponent();
        }
        public frmPhieuXuatKhoEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        // DungLV add Xuat Chi Dinh Don Hang Start
        bool Khan_BS, Khan, Khan_XCD_BS, Khan_XCD, Thuong, Thuong_BS = false;
        // DungLV add Xuat Chi Dinh Don Hang End
        bool IsPhieuCuoi;
        private void frmPhieuXuatKhoEdit_Load(object sender, EventArgs e)
        {
            rgvPhieuXuatChiTiet.ReadOnly = true;
            CSQLPhieuXuat px_=new CSQLPhieuXuat();
            lblXuatDen.Text = _frmMain.BangPhieuXuatKho_DS_.Rows[0]["TenNT"].ToString();
            lblSoDH.Text = _frmMain.BangPhieuXuatKho_DS_.Rows[0]["SoDH"].ToString();
            lblSoPX.Text = _frmMain.BangPhieuXuatKho_DS_.Rows[0]["SoPX"].ToString();
            if (bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["DonKhan"].ToString()) == true)
            {
                if (bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["BoSung"].ToString()) == true)
                {
                    // DungLV add Xuat Chi Dinh Don Hang start
                    if ((_frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsXuatCoChiDinh"].ToString() != null && _frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsXuatCoChiDinh"].ToString().Length > 0) ? bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsXuatCoChiDinh"].ToString()) : false)
                    {
                        lblLoaiDH.Text = "Khẩn - Chỉ Định - Bổ Sung";
                        Khan_XCD_BS = true;
                    }
                    else
                    {
                        // DungLV add Xuat Chi Dinh Don Hang End
                        lblLoaiDH.Text = "Khẩn - Bổ Sung";
                        Khan_BS = true;
                    }
                    IsPhieuCuoi = bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsPhieuCuoi"].ToString());
                }
                else
                {
                    // DungLV add Xuat Chi Dinh Don Hang start
                    if ((_frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsXuatCoChiDinh"].ToString() != null && _frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsXuatCoChiDinh"].ToString().Length > 0) ? bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsXuatCoChiDinh"].ToString()) : false)
                    {
                        lblLoaiDH.Text = "Khẩn - Xuất Có Chỉ Định";
                        Khan_XCD = true;
                    }
                    else
                    {
                        // DungLV add Xuat Chi Dinh Don Hang End
                        lblLoaiDH.Text = "Khẩn";
                        Khan = true;
                    }
                    IsPhieuCuoi = bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsPhieuCuoi"].ToString());
                }
            }
            else if (bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["Direct"].ToString()) == true)
            {
                lblLoaiDH.Text = "Trực Tiếp";
                IsPhieuCuoi = bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsPhieuCuoi"].ToString());
            }
            else
            {
                if (bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["BoSung"].ToString()) == true)
                {
                    lblLoaiDH.Text = "Thường - Bổ Sung";
                    Thuong_BS = true;
                    IsPhieuCuoi = bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsPhieuCuoi"].ToString());
                }
                else
                {
                    lblLoaiDH.Text = "Thường";
                    Thuong = true;
                    IsPhieuCuoi = bool.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["IsPhieuCuoi"].ToString());
                }
            }

            rgvPhieuXuatChiTiet.DataSource = px_.LayPhieuXuat_TheoSoLanIn_PXid(_frmMain.MaPhieuXuatKho_DS_);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int donhang_;
        
        private void btnIn_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(_frmMain.fPhieuXuatKho_DS.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLPhieuXuat phieuxuat_ = new CSQLPhieuXuat();
            PrintDialog ChonMayIn = new PrintDialog();
            ChonMayIn.AllowPrintToFile = true;
            ChonMayIn.AllowSelection = true;
            ChonMayIn.AllowSomePages = true;
            ChonMayIn.PrintToFile = true;
            if (ChonMayIn.ShowDialog() == DialogResult.OK)
            {
                string MayInDuocChon = ChonMayIn.PrinterSettings.PrinterName;
                int slin = int.Parse(_frmMain.BangPhieuXuatKho_DS_.Rows[0]["SoLanIn"].ToString()) + 1;
                phieuxuat_.UpdateECOPhieuXuat_SoLanIn(_frmMain.MaPhieuXuatKho_DS_, slin);
                if (Khan == true)
                {
                    donhang_ = 2;
                    InPhieuXuat(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi);
                    //InDonKhan(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
                }
                else if (Khan_BS == true)
                {
                    donhang_ = 1;
                    InPhieuXuat(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi);
                    //InDonKhan_BoSung(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
                }
                else if (Thuong == true)
                {
                    donhang_ = 5;
                    InPhieuXuat(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi);
                    //InBinhThuong(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
                }
                else if (Thuong_BS == true)
                {
                    donhang_ = 4;
                    InPhieuXuat(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi);
                    //InBinhThuong_BoSung(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
                }
                // DungLV add Xuat Chi Dinh Don Hang start
                else if (Khan_XCD)
                {
                    donhang_ = 6;
                    InPhieuXuat(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi);
                }
                else if (Khan_XCD_BS)
                {
                    donhang_ = 7;
                    InPhieuXuat(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi);
                }
                // DungLV add Xuat Chi Dinh Don Hang End
                else
                {
                    donhang_ = 3;
                    InPhieuXuat(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi);
                    //InTrucTiep(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
                }
            }
            _frmMain.fPhieuXuatKho_DS.rgvDSPhieuXK.DataSource = phieuxuat_.LayDanhSachLenLuoi(_frmMain.IsXemTatCa_);
        }

        private static void InPhieuXuat(string TenMayIn, CSQLPhieuXuat phieuxuat_, string pxid_, int donhang_, bool IsPhieuCuoi_)
        {
            Report_PhieuXuatHang check = new Report_PhieuXuatHang();
            check.SetDataSource(phieuxuat_.LayPhieuXuat_TheoSoLanIn_PXid(pxid_));

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            if (donhang_ == 1)
            {
                pdv.Value = "Khẩn - Bổ Sung";
            }
            else if (donhang_ == 2)
            {
                pdv.Value = "Khẩn";
            }
            else if (donhang_ == 3)
            {
                pdv.Value = "Trực Tiếp";
            }
            else if (donhang_ == 4)
            {
                pdv.Value = "Thường - Bổ Sung";
            }
            // DungLV add Xuat Chi Dinh Don Hang start
            else if (donhang_ == 6)
            {
                pdv.Value = "Khẩn - Xuất Có Chỉ Định";
            }
            else if (donhang_ == 7)
            {
                pdv.Value = "Khẩn - Chỉ Định - Bổ Sung";
            }
            // DungLV add Xuat Chi Dinh Don Hang End
            else
            {
                pdv.Value = "Thường";
            }
            ParameterValues pv = new ParameterValues();
            pv.Add(pdv);
            check.DataDefinition.ParameterFields["DonHang"].ApplyCurrentValues(pv);

            ParameterDiscreteValue pdv_1 = new ParameterDiscreteValue();
            if (IsPhieuCuoi_ == true)
            {
                pdv_1.Value = true;
            }
            else
            {
                pdv_1.Value = false;
            }
            ParameterValues pv_1 = new ParameterValues();
            pv_1.Add(pdv_1);
            check.DataDefinition.ParameterFields["IsPhieuCuoi"].ApplyCurrentValues(pv_1);

            check.PrintOptions.PrinterName = TenMayIn;
            check.PrintToPrinter(1, true, 1, 1000);
        }
        //    private static void InBinhThuong( string TenMayIn, CSQLPhieuXuat phieuxuat_, string pxid_)
        //{
        //    Report_PhieuXuatHangThuong check = new Report_PhieuXuatHangThuong();
        //    check.SetDataSource(phieuxuat_.LayPhieuXuat_TheoSoLanIn_PXid(pxid_));
        //    check.PrintOptions.PrinterName = TenMayIn;
        //    check.PrintToPrinter(1, true, 1, 1000);
        //}
        //private static void InBinhThuong_BoSung(string TenMayIn, CSQLPhieuXuat phieuxuat_, string pxid_)
        //{
        //    Report_PhieuXuatHangThuong_BoSung check = new Report_PhieuXuatHangThuong_BoSung();
        //    check.SetDataSource(phieuxuat_.LayPhieuXuat_TheoSoLanIn_PXid(pxid_));
        //    check.PrintOptions.PrinterName = TenMayIn;
        //    check.PrintToPrinter(1, true, 1, 1000);
        //}
        //private static void InTrucTiep(string TenMayIn, CSQLPhieuXuat phieuxuat_, string pxid_)
        //{
        //    Report_PhieuXuatHangTrucTiep check = new Report_PhieuXuatHangTrucTiep();
        //    check.SetDataSource(phieuxuat_.LayPhieuXuat_TheoSoLanIn_PXid(pxid_));
        //    check.PrintOptions.PrinterName = TenMayIn;
        //    check.PrintToPrinter(1, true, 1, 1000);
        //}
        //private static void InDonKhan(string TenMayIn, CSQLPhieuXuat phieuxuat_, string pxid_)
        //{
        //    Report_PhieuXuatHangKhan check = new Report_PhieuXuatHangKhan();
        //    check.SetDataSource(phieuxuat_.LayPhieuXuat_TheoSoLanIn_PXid(pxid_));
        //    check.PrintOptions.PrinterName = TenMayIn;
        //    check.PrintToPrinter(1, true, 1, 1000);
        //}
        //private static void InDonKhan_BoSung(string TenMayIn, CSQLPhieuXuat phieuxuat_, string pxid_)
        //{
        //    Report_PhieuXuatHangKhan_BoSung check = new Report_PhieuXuatHangKhan_BoSung();
        //    check.SetDataSource(phieuxuat_.LayPhieuXuat_TheoSoLanIn_PXid(pxid_));
        //    check.PrintOptions.PrinterName = TenMayIn;
        //    check.PrintToPrinter(1, true, 1, 1000);
        //}

        private void frmPhieuXuatKhoEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnDong_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                btnIn_Click(sender, e);
            }
        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(_frmMain.fPhieuXuatKho_DS.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLPhieuXuat phieuxuat_ = new CSQLPhieuXuat();
            string soPhieuXuat = phieuxuat_.getPhieuXuatId(_frmMain.MaPhieuXuatKho_DS_);
            if (Khan == true)
            {
                donhang_ = 2;
                ExportPhieuXuat(phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi, soPhieuXuat);
                //InDonKhan(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
            }
            else if (Khan_BS == true)
            {
                donhang_ = 1;
                ExportPhieuXuat(phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi, soPhieuXuat);
                //InDonKhan_BoSung(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
            }
            else if (Thuong == true)
            {
                donhang_ = 5;
                ExportPhieuXuat(phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi, soPhieuXuat);
                //InBinhThuong(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
            }
            else if (Thuong_BS == true)
            {
                donhang_ = 4;
                ExportPhieuXuat(phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi, soPhieuXuat);
                //InBinhThuong_BoSung(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
            }
            // DungLV add Xuat Chi Dinh Don Hang start
            else if (Khan_XCD)
            {
                donhang_ = 6;
                ExportPhieuXuat(phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi, soPhieuXuat);
            }
            else if (Khan_XCD_BS)
            {
                donhang_ = 7;
                ExportPhieuXuat(phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi, soPhieuXuat);
            }
            // DungLV add Xuat Chi Dinh Don Hang End
            else
            {
                donhang_ = 3;
                ExportPhieuXuat(phieuxuat_, _frmMain.MaPhieuXuatKho_DS_, donhang_, IsPhieuCuoi, soPhieuXuat);
                //InTrucTiep(MayInDuocChon, phieuxuat_, _frmMain.MaPhieuXuatKho_DS_);
            }
            _frmMain.fPhieuXuatKho_DS.rgvDSPhieuXK.DataSource = phieuxuat_.LayDanhSachLenLuoi(_frmMain.IsXemTatCa_);
        }

        private static void ExportPhieuXuat(CSQLPhieuXuat phieuxuat_, string pxid_, int donhang_, bool IsPhieuCuoi_, string soPhieuXuat)
        {
            Report_PhieuXuatHang check = new Report_PhieuXuatHang();
            check.SetDataSource(phieuxuat_.LayPhieuXuat_TheoSoLanIn_PXid(pxid_));

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            if (donhang_ == 1)
            {
                pdv.Value = "Khẩn - Bổ Sung";
            }
            else if (donhang_ == 2)
            {
                pdv.Value = "Khẩn";
            }
            else if (donhang_ == 3)
            {
                pdv.Value = "Trực Tiếp";
            }
            else if (donhang_ == 4)
            {
                pdv.Value = "Thường - Bổ Sung";
            }
            // DungLV add Xuat Chi Dinh Don Hang start
            else if (donhang_ == 6)
            {
                pdv.Value = "Khẩn - Xuất Có Chỉ Định";
            }
            else if (donhang_ == 7)
            {
                pdv.Value = "Khẩn - Chỉ Định - Bổ Sung";
            }
            // DungLV add Xuat Chi Dinh Don Hang End
            else
            {
                pdv.Value = "Thường";
            }
            ParameterValues pv = new ParameterValues();
            pv.Add(pdv);
            check.DataDefinition.ParameterFields["DonHang"].ApplyCurrentValues(pv);

            ParameterDiscreteValue pdv_1 = new ParameterDiscreteValue();
            if (IsPhieuCuoi_ == true)
            {
                pdv_1.Value = true;
            }
            else
            {
                pdv_1.Value = false;
            }
            ParameterValues pv_1 = new ParameterValues();
            pv_1.Add(pdv_1);
            check.DataDefinition.ParameterFields["IsPhieuCuoi"].ApplyCurrentValues(pv_1);
            if (soPhieuXuat != "" && soPhieuXuat.Length > 0)
            {
                check.ExportToDisk(ExportFormatType.Excel, "C:\\" + soPhieuXuat + ".xls");
                MessageBox.Show("File được export tại C:\\" + soPhieuXuat + ".xls");
            }
            else
            {
                check.ExportToDisk(ExportFormatType.Excel, "C:\\" + pxid_ + ".xls");
                MessageBox.Show("File được export tại C:\\" + pxid_ + ".xls");
            }
        }

    }
}
