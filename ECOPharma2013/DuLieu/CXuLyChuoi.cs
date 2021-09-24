using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ECOPharma2013.DuLieu
{
    class CXuLyChuoi
    {
        public string TrimChuoi(string chuoi)
        {
            chuoi = chuoi.Trim();
            string[] mangchuoi = chuoi.Split(' ');
            string chuoioutput = "";
            for (int i = 0; i < mangchuoi.Length; i++)
            {
                mangchuoi[i].Trim();
                if (mangchuoi[i].ToString().CompareTo("") > 0)
                {
                    if (mangchuoi[i].ToString().CompareTo(".") == 0)
                    {
                        chuoioutput += mangchuoi[i];
                    }
                    else
                    {
                        chuoioutput += " " + mangchuoi[i];
                    }
                }
            }
            chuoioutput = chuoioutput.Trim();
            return chuoioutput;
        }

        string TrimChuoiVietHoaDauDong(string chuoi)
        {
            
            if (chuoi.Length > 0)
            {
                string outstring = TrimChuoi(chuoi);
                if (outstring.Length > 0)
                {
                    string dauMuc = outstring.Substring(0, 1);
                    dauMuc = dauMuc.ToUpper();
                    string duoi = outstring.Substring(1, outstring.Length - 1);
                    outstring = dauMuc + duoi;
                    return outstring;
                }
            }
            return "";
        }

        public string TrimDoanVan(string chuoi)
        {
            string [] temp = chuoi.Split('.');
            string kq = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if(i==temp.Length-1)
                    kq += TrimChuoiVietHoaDauDong(temp[i]);
                else
                    kq += TrimChuoiVietHoaDauDong(temp[i])+". ";
            }
            return kq;
        }

        public string TrimTen(string chuoi)
        {
            TextInfo text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
            string outstring = TrimChuoi(chuoi);
            outstring = text.ToTitleCase(outstring);
            return outstring;
        }
    }
}
