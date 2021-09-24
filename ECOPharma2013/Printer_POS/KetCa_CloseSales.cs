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
using Telerik.WinControls.UI;
using Microsoft.PointOfService;

namespace ECOPharma2013.Printer_POS
{
    class KetCa_CloseSales
    {
        public void PrintCloseSales(XuLyMayInPos xuly_, string tennt, string dienthoai, string terminal, string tenthungan, string SoCa, decimal giamgia, decimal trahang, decimal TTBanCoTAXdaGiamGia, decimal ttcotaxdatinhphitra_, decimal tienquy, decimal tienketca, int sobill, int sobilltra, int sobillhuybanhang)
        {
            PosDeviceTag tag = xuly_.EnableThietBi();
            if (tag != null)
            {
                try
                {
                    InTieuDe(xuly_, "KET CA - CLOSE SALES", terminal, xuly_.ConvertToUnSign(tenthungan), DateTime.Now, SoCa, "TONG CONG");

                    InChiTiet(xuly_, tienketca, giamgia, trahang, TTBanCoTAXdaGiamGia, ttcotaxdatinhphitra_, tienquy, sobill, sobilltra, sobillhuybanhang, "ECO PHARMACY", xuly_.ConvertToUnSign(tennt), dienthoai);
                    xuly_.Disable(tag);
                }
                catch
                {
                    xuly_.Disable(tag);
                    throw;
                }
            }
        }

        private void InChiTiet(XuLyMayInPos xuly_, decimal tienketca_, decimal giamgia_, decimal trahang_, decimal tiencotaxdagiamgia_, decimal ttcotaxdatinhphitra_, decimal tienquy_, int sobill_, int sobilltra_, int sobillhuybanhang_, string companyName, string tent_, string tell)
        {
            string offSetString = new string(' ', xuly_.CreateRecLineChars() / 5);
            xuly_.InBinhThuong(offSetString + String.Format("TONG TIEN       {0}", xuly_.CatBoBot((tienketca_ + tienquy_).ToString("#,###").PadLeft(11), 11)));
            xuly_.InBinhThuong(offSetString + String.Format("TIEN QUY        {0}", xuly_.CatBoBot(tienquy_.ToString("#,###").PadLeft(11), 11)));
            xuly_.InChinhSua(new string('-', (xuly_.CreateRecLineChars())));
            xuly_.InBinhThuong(offSetString + String.Format("TIEN KET CA     {0}", xuly_.CatBoBot(tienketca_.ToString("#,###").PadLeft(11), 11)));
            xuly_.InBinhThuong(offSetString + String.Format("TIEN BAN POS    {0}", xuly_.CatBoBot((tiencotaxdagiamgia_ - ttcotaxdatinhphitra_).ToString("#,###").PadLeft(11), 11)));
            xuly_.InChinhSua(new string('-', (xuly_.CreateRecLineChars())));
            xuly_.InBinhThuong(offSetString + String.Format("DU/THIEU        {0}", xuly_.CatBoBot((tienketca_ - (tiencotaxdagiamgia_ - ttcotaxdatinhphitra_)).ToString("#,###").PadLeft(11), 11)));
            xuly_.InBinhThuong(offSetString + String.Format("SO PHIEU BAN    {0}", xuly_.CatBoBot((sobill_).ToString("#,###").PadLeft(11), 11)));
            xuly_.InBinhThuong(offSetString + String.Format("SO PHIEU TRA    {0}", xuly_.CatBoBot((sobilltra_).ToString("#,###").PadLeft(11), 11)));
            xuly_.InBinhThuong(offSetString + String.Format("SP HUY KHI BAN  {0}", xuly_.CatBoBot((sobillhuybanhang_).ToString("#,###").PadLeft(11), 11)));
            xuly_.InBinhThuong(offSetString + String.Format("TT DA GIAM GIA  {0}", xuly_.CatBoBot(giamgia_.ToString("#,###").PadLeft(11), 11)));
            xuly_.InBinhThuong(offSetString + String.Format("TT PHI TRA HANG {0}", xuly_.CatBoBot(trahang_.ToString("#,###").PadLeft(11), 11)));

            xuly_.InChinhSua(new string('-', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(xuly_.InDam_ChinhSize_CanhGiua(companyName));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("www.ecopharma.com.vn")));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("MST: 0102637020-001")));
            xuly_.InChinhSua(xuly_.InCanhGiua(tent_));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("SO DT: {0}", tell)));
            xuly_.InChinhSua(xuly_.CatGiay());

        }

        private void InTieuDe(XuLyMayInPos xuly_, string companyName, string tenmaytn, string tenthungan, DateTime datetime, string sales, string summary)
        {
            xuly_.InChinhSua(xuly_.InCanhGiua(companyName));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("MAY THU NGAN: {0}", tenmaytn)));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("NV KET CA: {0}", tenthungan)));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(String.Format("{0:dddd, dd/MM/yyyy hh:mm:ss tt}", datetime));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(String.Format("SO KET CA: {0}", sales));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(new string('*', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(xuly_.InCanhGiua(summary));
            xuly_.InChinhSua(new string('*', (xuly_.CreateRecLineChars())));
        }
    }
}
