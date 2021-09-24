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
    class ThanhToan
    {
        public void ChonMayIn(XuLyMayInPos xuly_, string tennt, string dienthoai, string sott, string maytn, string nvban, string nhap, DataTable banhangct, decimal thu, decimal nhan, decimal tra, bool inCT, bool inlai)
        {
            PosDeviceTag tag = xuly_.EnableThietBi();
            if (tag != null)
            {
                try { 
                    if (inlai == true)
                    {
                        PrintReceiptTwoHeader(xuly_, "HOA DON BAN HANG", "( IN LAI )", sott, maytn, xuly_.ConvertToUnSign(nvban), nhap, "MA SP", "TEN SP");
                    }
                    else
                    {
                        PrintReceiptHeader(xuly_, "HOA DON BAN HANG", sott, maytn, xuly_.ConvertToUnSign(nvban), nhap, "MA SP", "TEN SP");
                    }

                    for (int i = 0; i < banhangct.Rows.Count; i++)
                    {
                        decimal ttgiam_ = decimal.Parse(banhangct.Rows[i]["TTGiam"].ToString());
                        string magg_ = banhangct.Rows[i]["GiamGia"].ToString();
                        string masp_ = banhangct.Rows[i]["MaSP"].ToString();
                        string tensp_ = banhangct.Rows[i]["TenSP"].ToString();
                        string tendvt_ = xuly_.ConvertToUnSign(banhangct.Rows[i]["TENDVT"].ToString());
                        string lot_ = banhangct.Rows[i]["Lot"].ToString();
                        DateTime date_ = DateTime.Parse(banhangct.Rows[i]["Date"].ToString());
                        string sdate_ = date_.ToString("dd/MM/yyyy");
                        decimal SLBan_ = decimal.Parse(banhangct.Rows[i]["SLBan"].ToString());
                        decimal DonGiaBanChuaTAXChuaGiamGia_ = decimal.Parse(banhangct.Rows[i]["DonGiaBanChuaTAXChuaGiamGia"].ToString());
                        decimal PhanTramTAX_ = decimal.Parse(banhangct.Rows[i]["PhanTramTAX"].ToString());
                        decimal DonGiaBancoTAX = decimal.Parse(banhangct.Rows[i]["DonGiaBancoTAX"].ToString());
                        decimal TTbancoTAX = decimal.Parse(banhangct.Rows[i]["TTbancoTAX"].ToString());
                        decimal mucgiam_ = decimal.Parse(banhangct.Rows[i]["MucGiam"].ToString());
                        decimal TTthucte_ = decimal.Parse(banhangct.Rows[i]["TTThucTe"].ToString());
                        decimal TTgiamgia_ = decimal.Parse(banhangct.Rows[i]["TTGiamGia"].ToString());
                        string tengg_ = banhangct.Rows[i]["TenGG"].ToString();
                        if (inCT == true)
                        {
                            if (ttgiam_ != 0 && ttgiam_ > 0)
                            {
                                InChiTietCoGiamGia(xuly_, masp_, tensp_, lot_, sdate_, SLBan_, tendvt_, "X", DonGiaBancoTAX, "=", TTbancoTAX, mucgiam_, TTgiamgia_, TTthucte_);
                            }
                            else
                            {
                                InChiTietKoGiamGia(xuly_, masp_, tensp_, lot_, sdate_, SLBan_, tendvt_, "X", DonGiaBancoTAX, "=", TTbancoTAX);
                            }
                        }
                        else
                        {
                            if (ttgiam_ != 0 && ttgiam_ > 0)
                            {
                                InChiTietKoLoDateCoGiamGia(xuly_, masp_, tensp_, SLBan_, tendvt_, "X", DonGiaBancoTAX, "=", TTbancoTAX, mucgiam_, TTgiamgia_, TTthucte_);
                            }
                            else
                            {
                                InChiTietKoLoDateKoGiamGia(xuly_, masp_, tensp_, SLBan_, tendvt_, "X", DonGiaBancoTAX, "=", TTbancoTAX);

                            }
                        }
                    }
                    PrintReceiptFooter(xuly_, thu, nhan, tra, DateTime.Now, "Cam on quy khach!", "ECO PHARMACY", xuly_.ConvertToUnSign(tennt), dienthoai);
                    xuly_.Disable(tag);
                } catch{
                    xuly_.Disable(tag);
                    throw;
                }
            }
        }
        public void PrintReceiptFooter(XuLyMayInPos xuly_, decimal thu_, decimal nhan_, decimal tra_, DateTime dateTime, string footerText, string companyName, string tent_, string tell)
        {
            string offSetString = new string(' ', xuly_.CreateRecLineChars() / 4);
            xuly_.InChinhSua(new string('-', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(offSetString + String.Format("TONG TIEN     {0}", xuly_.CatBoBot(thu_.ToString("#,###").PadLeft(10), 10)));
            xuly_.InChinhSua(offSetString + String.Format("TIEN NHAN     {0}", xuly_.CatBoBot(nhan_.ToString("#,###").PadLeft(10), 10)));
            xuly_.InChinhSua(offSetString + new string('-', (xuly_.CreateRecLineChars())));
            if (tra_ == 0)
            {
                xuly_.InChinhSua(offSetString + String.Format("TRA LAI       {0}", xuly_.CatBoBot(tra_.ToString().PadLeft(10), 10)));
            }
            else
            {
                xuly_.InChinhSua(offSetString + String.Format("TRA LAI       {0}", xuly_.CatBoBot(tra_.ToString("#,###").PadLeft(10), 10)));
            }
            xuly_.InChinhSua(new string('-', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(String.Format("{0:dddd, dd/MM/yyyy hh:mm:ss tt}", dateTime));
            xuly_.InChinhSua(xuly_.InCanhGiua(footerText));

            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(xuly_.InDam_ChinhSize_CanhGiua(companyName));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("www.ecopharma.com.vn")));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("MST: 0102637020-001")));
            xuly_.InChinhSua(xuly_.InCanhGiua(tent_));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("SO DT: {0}", tell)));
            xuly_.InChinhSua(xuly_.CatGiay());
        }

        public void InChiTietKoLoDateKoGiamGia(XuLyMayInPos xuly_, string itemCode, string Description, decimal @slban, string dvt, string nhan, decimal @DonGiaBancoTAX, string bang, decimal @TTbancoTAX)
        {
            string offSetString = new string(' ', xuly_.CreateRecLineChars() / 8);
            string offSet = new string(' ', xuly_.CreateRecLineChars() / 4);
            xuly_.InBinhThuong(xuly_.CatBoBot(itemCode.PadRight(6), 6));
            xuly_.InChinhSua(xuly_.CatBoBot(Description.PadLeft(9), 27));
            xuly_.InBinhThuong(offSetString + String.Format(xuly_.CatBoBot(@slban.ToString("####").PadRight(5), 5)));
            xuly_.InBinhThuong(xuly_.CatBoBot(dvt.PadLeft(4), 4));
            xuly_.InBinhThuong(xuly_.CatBoBot(nhan.PadLeft(3), 3));
            xuly_.InBinhThuong(xuly_.CatBoBot(@DonGiaBancoTAX.ToString("#,###.##").PadLeft(16), 16));
            xuly_.InChinhSua(offSet + String.Format("   ={0}", xuly_.CatBoBot(@TTbancoTAX.ToString("#,###.##").PadLeft(18), 18)));
        }

        public void InChiTietKoLoDateCoGiamGia(XuLyMayInPos xuly_, string itemCode, string Description, decimal @slban, string dvt, string nhan, decimal @DonGiaBancoTAX, string bang, decimal @TTbancoTAX, decimal @mucgiam_, decimal @ttgiam_, decimal @TTthucte_)
        {

            string offSetString = new string(' ', xuly_.CreateRecLineChars() / 8);
            string offSet = new string(' ', xuly_.CreateRecLineChars() / 4);
            xuly_.InBinhThuong( xuly_.CatBoBot(itemCode.PadRight(6), 6));
            xuly_.InChinhSua(xuly_.CatBoBot(Description.PadLeft(9), 27));
            xuly_.InBinhThuong(offSetString + String.Format(xuly_.CatBoBot(@slban.ToString("####").PadRight(5), 5)));
            xuly_.InBinhThuong(xuly_.CatBoBot(dvt.PadLeft(4), 4));
            xuly_.InBinhThuong(xuly_.CatBoBot(nhan.PadLeft(3), 3));
            xuly_.InBinhThuong(xuly_.CatBoBot(@DonGiaBancoTAX.ToString("#,###.##").PadLeft(16), 16));
            xuly_.InChinhSua(offSet + String.Format("   ={0}", xuly_.CatBoBot(@TTbancoTAX.ToString("#,###.##").PadLeft(18), 18)));
            xuly_.InBinhThuong(String.Format("GIAM {0}%", @mucgiam_.ToString("#,###.##")));
            xuly_.InBinhThuong(String.Format("    ({0})", @ttgiam_.ToString("#,###.##")));
            xuly_.InChinhSua(xuly_.InCanhPhai(@TTthucte_.ToString("#,###.##")));
        }

        public void InChiTietKoGiamGia(XuLyMayInPos xuly_, string itemCode, string Description, string lot, string date, decimal @slban, string dvt, string nhan, decimal @DonGiaBancoTAX, string bang, decimal @TTbancoTAX)
        {
            string offSetString = new string(' ', xuly_.CreateRecLineChars() / 8);
            string offSet = new string(' ', xuly_.CreateRecLineChars() / 4);
            xuly_.InBinhThuong( xuly_.CatBoBot(itemCode.PadRight(6), 6));
            xuly_.InChinhSua( xuly_.CatBoBot(Description.PadLeft(9), 27));
            xuly_.InBinhThuong(String.Format("Lô: {0}", lot.PadLeft(3), 3));
            xuly_.InChinhSua( xuly_.InCanhPhai(String.Format("HD: {0}", date)));
            xuly_.InBinhThuong( offSetString + String.Format(xuly_.CatBoBot(@slban.ToString("####").PadRight(5), 5)));
            xuly_.InBinhThuong(xuly_.CatBoBot(dvt.PadLeft(4), 4));
            xuly_.InBinhThuong(xuly_.CatBoBot(nhan.PadLeft(3), 3));
            xuly_.InBinhThuong(xuly_.CatBoBot(@DonGiaBancoTAX.ToString("#,###.##").PadLeft(16), 16));
            xuly_.InChinhSua(offSet + String.Format("   ={0}", xuly_.CatBoBot(@TTbancoTAX.ToString("#,###.##").PadLeft(18), 18)));
        }

        public void InChiTietCoGiamGia(XuLyMayInPos xuly_, string itemCode, string Description, string lot, string date, decimal @slban, string dvt, string nhan, decimal @DonGiaBancoTAX, string bang, decimal @TTbancoTAX, decimal @mucgiam_, decimal @ttgiam_, decimal @TTthucte_)
        {
            string offSetString = new string(' ', xuly_.CreateRecLineChars() / 8);
            string offSet = new string(' ', xuly_.CreateRecLineChars() / 4);
            xuly_.InBinhThuong(xuly_.CatBoBot(itemCode.PadRight(6), 6));
            xuly_.InChinhSua( xuly_.CatBoBot(Description.PadLeft(9), 27));
            xuly_.InBinhThuong(String.Format("Lô: {0}", lot.PadLeft(3), 3));
            xuly_.InChinhSua(xuly_.InCanhPhai(String.Format("HD: {0}", date)));
            xuly_.InBinhThuong(offSetString + String.Format(xuly_.CatBoBot(@slban.ToString("####").PadRight(5), 5)));
            xuly_.InBinhThuong(xuly_.CatBoBot(dvt.PadLeft(4), 4));
            xuly_.InBinhThuong(xuly_.CatBoBot(nhan.PadLeft(3), 3));
            xuly_.InBinhThuong(xuly_.CatBoBot(@DonGiaBancoTAX.ToString("#,###.##").PadLeft(16), 16));
            xuly_.InChinhSua(offSet + String.Format("   ={0}", xuly_.CatBoBot(@TTbancoTAX.ToString("#,###.##").PadLeft(18), 18)));
            xuly_.InBinhThuong(String.Format("GIAM {0}%", @mucgiam_.ToString("#,###.##")));
            xuly_.InBinhThuong(String.Format("    ({0})", @ttgiam_.ToString("#,###.##")));
            xuly_.InChinhSua(xuly_.InCanhPhai(@TTthucte_.ToString("#,###.##")));
        }

        public void PrintReceiptHeader(XuLyMayInPos xuly_, string recipt, string stt, string MaTN, string serverName, string cashierName, string masp, string tensp)
        {
            xuly_.InChinhSua( xuly_.InDam_ChinhSize_CanhGiua(recipt));
            xuly_.InChinhSua(String.Format("SO PHIEU: {0}", stt));
            xuly_.InChinhSua(String.Format("MAY TN  : {0}", MaTN));
            xuly_.InChinhSua(String.Format("NV B.H  : {0}", serverName.ToUpper()));
            xuly_.InChinhSua(String.Format("NV T.N  : {0}", cashierName.ToUpper()));
            xuly_.InChinhSua(new string('-', xuly_.CreateRecLineChars()));
            xuly_.InBinhThuong(xuly_.CatBoBot(masp.PadRight(6), 6));
            xuly_.InChinhSua(xuly_.CatBoBot(tensp.PadLeft(9), 27));
            xuly_.InChinhSua(new string('-', xuly_.CreateRecLineChars()));
        }
        public void PrintReceiptTwoHeader(XuLyMayInPos xuly_, string recipt, string recipt1, string stt, string MaTN, string serverName, string cashierName, string masp, string tensp)
        {
            xuly_.InChinhSua(xuly_.InDam_ChinhSize_CanhGiua(recipt));
            xuly_.InChinhSua(xuly_.InDam_ChinhSize_CanhGiua(recipt1));
            xuly_.InChinhSua(String.Format("SO PHIEU: {0}", stt));
            xuly_.InChinhSua(String.Format("MAY TN  : {0}", MaTN));
            xuly_.InChinhSua(String.Format("NV B.H  : {0}", serverName.ToUpper()));
            xuly_.InChinhSua(String.Format("NV T.N  : {0}", cashierName.ToUpper()));
            xuly_.InChinhSua(new string('-', xuly_.CreateRecLineChars()));
            xuly_.InBinhThuong(xuly_.CatBoBot(masp.PadRight(6), 6));
            xuly_.InChinhSua(xuly_.CatBoBot(tensp.PadLeft(9), 27));
            xuly_.InChinhSua(new string('-', xuly_.CreateRecLineChars()));
        }
    }
}
