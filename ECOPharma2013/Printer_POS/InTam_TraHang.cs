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
using ECOPharma2013.Printer_POS;
using System.Drawing.Printing;
using System.IO;
using Microsoft.PointOfService;

namespace ECOPharma2013.Printer_POS
{
    class InTam_TraHang
    {
        public void InTamCuaTraHang(XuLyMayInPos xuly_, string tennt, string dienthoai, string sott, string maytn, string nvban, string nhap, DataTable banhangct, decimal thu, bool InLoDate)
        {
            PosDeviceTag tag = xuly_.EnableThietBi();
            if (tag != null)
            {
                try
                {
                    PrintReceiptHeader(xuly_, "IN TAM TRA HANG", sott, maytn, xuly_.ConvertToUnSign(nvban), nhap, "MA SP", "TEN SP");

                    for (int i = 0; i < banhangct.Rows.Count; i++)
                    {
                        CSQLGiamGia giamgia_ = new CSQLGiamGia();
                        CSQLSanPham sp_ = new CSQLSanPham();
                        decimal tttra_ = decimal.Parse(banhangct.Rows[i]["TTPhiTraHang"].ToString());
                        string magg_ = banhangct.Rows[i]["PhiTraHang"].ToString();
                        string masp_ = banhangct.Rows[i]["MaSP"].ToString();
                        string tensp_ = sp_.LaySanPhamTheoMaSP(masp_).Rows[0]["TenSP"].ToString();
                        string tendvt_ = xuly_.ConvertToUnSign(banhangct.Rows[i]["TENDVT"].ToString());
                        string lot_ = banhangct.Rows[i]["LotBan"].ToString();
                        DateTime date_ = DateTime.Parse(banhangct.Rows[i]["DateBan"].ToString());
                        string sdate_ = date_.ToString("dd/MM/yyyy");

                        decimal SLTra_ = decimal.Parse(banhangct.Rows[i]["SLTra"].ToString());
                        decimal DonGiaTraChuaTAXChuaGiamGia_ = decimal.Parse(banhangct.Rows[i]["DonGiaTraChuaTAXChuaTinhPhiTraHang"].ToString());
                        decimal PhanTramTAX_ = decimal.Parse(banhangct.Rows[i]["PhanTramTAX"].ToString());
                        decimal DonGiaTracoTAX = DonGiaTraChuaTAXChuaGiamGia_ + ((DonGiaTraChuaTAXChuaGiamGia_ * PhanTramTAX_) / 100);
                        decimal TTTraCoTAX = SLTra_ * DonGiaTracoTAX;
                        decimal mucgiam_ = Math.Round(decimal.Parse(giamgia_.LayGiamGiaTheoMa(magg_).Rows[0]["MucGiam"].ToString()), 0);
                        decimal TTthucte_ = TTTraCoTAX - ((TTTraCoTAX * mucgiam_) / 100);
                        decimal TTgiamgia_ = TTTraCoTAX - TTthucte_;
                        string tengg_ = giamgia_.LayGiamGiaTheoMa(magg_).Rows[0]["TenGG"].ToString();
                        if (InLoDate == true)
                        {
                            if (tttra_ != 0 && tttra_ > 0)
                            {
                                InChiTietCoGiamGia(xuly_, masp_, tensp_, lot_, sdate_, SLTra_, tendvt_, "X", DonGiaTracoTAX, "=", TTTraCoTAX, mucgiam_, TTgiamgia_, TTthucte_);
                            }
                            else
                            {
                                InChiTietKoGiamGia(xuly_, masp_, tensp_, lot_, sdate_, SLTra_, tendvt_, "X", DonGiaTracoTAX, "=", TTTraCoTAX);
                            }
                        }
                        else
                        {
                            if (tttra_ != 0 && tttra_ > 0)
                            {
                                InChiTietKoLoDateCoGiamGia(xuly_, masp_, tensp_, SLTra_, tendvt_, "X", DonGiaTracoTAX, "=", TTTraCoTAX, mucgiam_, TTgiamgia_, TTthucte_);
                            }
                            else
                            {
                                InChiTietKoLoDateKoGiamGia(xuly_, masp_, tensp_, SLTra_, tendvt_, "X", DonGiaTracoTAX, "=", TTTraCoTAX);
                            }
                        }
                    }
                    PrintReceiptFooter(xuly_, thu, "ECO PHARMACY", xuly_.ConvertToUnSign(tennt), dienthoai);
                    xuly_.Disable(tag);
                }
                catch
                {
                    xuly_.Disable(tag);
                    throw;
                }
            }
        }

        public void PrintReceiptFooter(XuLyMayInPos xuly_, decimal thu_, string companyName, string tent_, string tell)
        {
            string offSetString = new string(' ', xuly_.CreateRecLineChars() / 4);

            xuly_.InChinhSua(new string('-', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(offSetString + String.Format("TONG TIEN     {0}", xuly_.CatBoBot(thu_.ToString("#,###").PadLeft(10), 10)));

            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(xuly_.InDam_ChinhSize_CanhGiua(companyName));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("www.ecopharma.com.vn")));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("MST: 0102637020-001")));
            xuly_.InChinhSua(xuly_.InCanhGiua(tent_));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("SO DT: {0}", tell)));
            xuly_.InChinhSua(xuly_.CatGiay());
        }

        public void InChiTietKoGiamGia(XuLyMayInPos xuly_, string itemCode, string Description, string lot, string date, decimal @slban, string dvt, string nhan, decimal @DonGiaBancoTAX, string bang, decimal @TTbancoTAX)
        {
            xuly_.InBinhThuong(xuly_.CatBoBot(itemCode.PadRight(6), 6));
            xuly_.InChinhSua(xuly_.CatBoBot(Description.PadLeft(9), 27));
            xuly_.InBinhThuong(String.Format("Lô: {0}", lot.PadLeft(3), 3));
            xuly_.InChinhSua(xuly_.InCanhPhai(String.Format("HD: {0}", date)));
            xuly_.InBinhThuong(xuly_.CatBoBot(@slban.ToString().PadRight(5), 3));
            xuly_.InBinhThuong(xuly_.CatBoBot(dvt.PadLeft(5), 5));
            xuly_.InBinhThuong(xuly_.CatBoBot(nhan.PadLeft(2), 2));
            xuly_.InBinhThuong(xuly_.CatBoBot(@DonGiaBancoTAX.ToString("#,###").PadLeft(8), 8));
            xuly_.InBinhThuong(xuly_.CatBoBot(bang.PadLeft(4), 4));
            xuly_.InChinhSua(xuly_.InCanhPhai(@TTbancoTAX.ToString("#,###")));
        }

        public void InChiTietCoGiamGia(XuLyMayInPos xuly_, string itemCode, string Description, string lot, string date, decimal @slban, string dvt, string nhan, decimal @DonGiaBancoTAX, string bang, decimal @TTbancoTAX, decimal @mucgiam_, decimal @ttgiam_, decimal @TTthucte_)
        {
            xuly_.InBinhThuong(xuly_.CatBoBot(itemCode.PadRight(6), 6));
            xuly_.InChinhSua(xuly_.CatBoBot(Description.PadLeft(9), 27));
            xuly_.InBinhThuong(String.Format("Lô: {0}", lot.PadLeft(3), 3));
            xuly_.InChinhSua(xuly_.InCanhPhai(String.Format("HD: {0}", date)));
            xuly_.InBinhThuong(xuly_.CatBoBot(@slban.ToString().PadRight(5), 3));
            xuly_.InBinhThuong(xuly_.CatBoBot(dvt.PadLeft(5), 5));
            xuly_.InBinhThuong(xuly_.CatBoBot(nhan.PadLeft(2), 2));
            xuly_.InBinhThuong(xuly_.CatBoBot(@DonGiaBancoTAX.ToString("#,###").PadLeft(8), 8));
            xuly_.InBinhThuong(xuly_.CatBoBot(bang.PadLeft(4), 4));
            xuly_.InChinhSua(xuly_.InCanhPhai(@TTbancoTAX.ToString("#,###")));
            xuly_.InBinhThuong(String.Format("PHI {0}%", @mucgiam_));
            xuly_.InBinhThuong(String.Format("   ({0})", @ttgiam_.ToString("#,###")));
            xuly_.InChinhSua(xuly_.InCanhPhai(@TTthucte_.ToString("#,###")));
        }

        public void PrintReceiptHeader(XuLyMayInPos xuly_, string recipt, string stt, string MaTN, string serverName, string cashierName, string masp, string tensp)
        {
            xuly_.InChinhSua(xuly_.InDam_ChinhSize_CanhGiua(recipt));
            xuly_.InChinhSua(String.Format("SO PHIEU: {0}", stt));
            xuly_.InChinhSua(String.Format("MAY TN  : {0}", MaTN));
            xuly_.InChinhSua(String.Format("NV B.H  : {0}", serverName.ToUpper()));
            xuly_.InChinhSua(String.Format("NV T.N  : {0}", cashierName.ToUpper()));
            xuly_.InChinhSua(new string('-', xuly_.CreateRecLineChars()));
            xuly_.InBinhThuong(xuly_.CatBoBot(masp.PadRight(6), 6));
            xuly_.InChinhSua(xuly_.CatBoBot(tensp.PadLeft(9), 27));
            xuly_.InChinhSua(new string('-', xuly_.CreateRecLineChars()));

        }

        public void InChiTietKoLoDateKoGiamGia(XuLyMayInPos xuly_, string itemCode, string Description, decimal @slban, string dvt, string nhan, decimal @DonGiaBancoTAX, string bang, decimal @TTbancoTAX)
        {
            xuly_.InBinhThuong(xuly_.CatBoBot(itemCode.PadRight(6), 6));
            xuly_.InChinhSua(xuly_.CatBoBot(Description.PadLeft(9), 27));
            xuly_.InBinhThuong(xuly_.CatBoBot(@slban.ToString().PadRight(5), 3));
            xuly_.InBinhThuong(xuly_.CatBoBot(dvt.PadLeft(5), 5));
            xuly_.InBinhThuong(xuly_.CatBoBot(nhan.PadLeft(2), 2));
            xuly_.InBinhThuong(xuly_.CatBoBot(@DonGiaBancoTAX.ToString("#,###").PadLeft(8), 8));
            xuly_.InBinhThuong(xuly_.CatBoBot(bang.PadLeft(4), 4));
            xuly_.InChinhSua(xuly_.InCanhPhai(@TTbancoTAX.ToString("#,###")));
        }

        public void InChiTietKoLoDateCoGiamGia(XuLyMayInPos xuly_, string itemCode, string Description, decimal @slban, string dvt, string nhan, decimal @DonGiaBancoTAX, string bang, decimal @TTbancoTAX, decimal @mucgiam_, decimal @ttgiam_, decimal @TTthucte_)
        {
            xuly_.InBinhThuong(xuly_.CatBoBot(itemCode.PadRight(6), 6));
            xuly_.InChinhSua(xuly_.CatBoBot(Description.PadLeft(9), 27));
            xuly_.InBinhThuong( xuly_.CatBoBot(@slban.ToString().PadRight(5), 3));
            xuly_.InBinhThuong(xuly_.CatBoBot(dvt.PadLeft(5), 5));
            xuly_.InBinhThuong(xuly_.CatBoBot(nhan.PadLeft(2), 2));
            xuly_.InBinhThuong(xuly_.CatBoBot(@DonGiaBancoTAX.ToString("#,###").PadLeft(8), 8));
            xuly_.InBinhThuong(xuly_.CatBoBot(bang.PadLeft(4), 4));
            xuly_.InChinhSua(xuly_.InCanhPhai(@TTbancoTAX.ToString("#,###")));
            xuly_.InBinhThuong(String.Format("PHI {0}%", @mucgiam_));
            xuly_.InBinhThuong(String.Format("   ({0})", @ttgiam_.ToString("#,###")));
            xuly_.InChinhSua(xuly_.InCanhPhai(@TTthucte_.ToString("#,###")));
        }
    }
}
