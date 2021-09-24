using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using Microsoft.PointOfService;

namespace ECOPharma2013.Printer_POS
{
    class XacNhan_Declarations
    {
        public void PrintDeclare(XuLyMayInPos xuly_, string tennt, string dienthoai, string terminal, string tenthungan, string SoCa, int t500k, int t200k, int t100k, int t50k, int t20k, int t10k, int t5k, int t2k, int t1k, int t500, int t200, decimal tienquy, decimal tienketca)
        {
            PosDeviceTag tag = xuly_.EnableThietBi();
            if (tag != null)
            {
                try
                {
                    InTieuDe(xuly_, "XAC NHAN - DECLARE", terminal, xuly_.ConvertToUnSign(tenthungan), DateTime.Now, SoCa);

                    InChiTiet(xuly_, 500000, "X", t500k, "=");
                    InChiTiet(xuly_, 200000, "X", t200k, "=");
                    InChiTiet(xuly_, 100000, "X", t100k, "=");
                    InChiTiet(xuly_, 50000, "X", t50k, "=");
                    InChiTiet(xuly_, 20000, "X", t20k, "=");
                    InChiTiet(xuly_, 10000, "X", t10k, "=");
                    InChiTiet(xuly_, 5000, "X", t5k, "=");
                    InChiTiet(xuly_, 2000, "X", t2k, "=");
                    InChiTiet(xuly_, 1000, "X", t1k, "=");
                    InChiTiet(xuly_, 500, "X", t500, "=");
                    InChiTiet(xuly_, 200, "X", t200, "=");

                    InTongCong(xuly_, tienketca, tienquy, "ECO PHARMACY", xuly_.ConvertToUnSign(tennt), dienthoai);

                    xuly_.Disable(tag);
                }
                catch
                {
                    xuly_.Disable(tag);
                    throw;
                }
            }
        }

        private void InTongCong(XuLyMayInPos xuly_, decimal tienket, decimal quy, string companyName, string tent_, string tell)
        {
            string offSetString = new string(' ', xuly_.CreateRecLineChars() / 5);

            xuly_.InChinhSua(new string('-', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(offSetString + String.Format("TIEN KET CA     {0}", xuly_.CatBoBot(tienket.ToString("#,###").PadLeft(11), 11)));
            xuly_.InChinhSua(offSetString + String.Format("TIEN QUY        {0}", xuly_.CatBoBot(quy.ToString("#,###").PadLeft(11), 11)));
            xuly_.InChinhSua(new string('-', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(offSetString + String.Format("TONG TIEN       {0}", xuly_.CatBoBot((tienket + quy).ToString("#,###").PadLeft(11), 11)));

            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(xuly_.InDam_ChinhSize_CanhGiua(companyName));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("www.ecopharma.com.vn")));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("MST: 0102637020-001")));
            xuly_.InChinhSua(xuly_.InCanhGiua(tent_));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("SO DT: {0}", tell)));
            xuly_.InChinhSua(xuly_.CatGiay());
        }

        private void InChiTiet(XuLyMayInPos xuly_, int gia, string nhan, int soluong, string bang)
        {
            xuly_.InBinhThuong(xuly_.CatBoBot(gia.ToString("#,###").PadLeft(7), 7));
            xuly_.InBinhThuong(xuly_.CatBoBot(nhan.PadLeft(3), 3));
            xuly_.InBinhThuong(xuly_.CatBoBot(soluong.ToString().PadLeft(6), 6));
            xuly_.InBinhThuong(xuly_.CatBoBot(bang.PadLeft(4), 4));
            xuly_.InChinhSua(xuly_.CatBoBot((gia * soluong).ToString("#,###").PadLeft(13), 13));
        }

        private void InTieuDe(XuLyMayInPos xuly_, string companyName, string tenmaytn, string tenthungan_, DateTime datetime, string sales)
        {

            xuly_.InChinhSua(xuly_.InCanhGiua(companyName));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("MAY THU NGAN: {0}", tenmaytn)));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(xuly_.InCanhGiua(String.Format("NV KET CA: {0}", tenthungan_)));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(String.Format("{0:dddd, dd/MM/yyyy hh:mm:ss tt}", datetime));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(String.Format("SO KET CA: {0}", sales));
            xuly_.InChinhSua(new string(' ', (xuly_.CreateRecLineChars())));
            xuly_.InChinhSua(new string('*', (xuly_.CreateRecLineChars())));
        }
    }
}
