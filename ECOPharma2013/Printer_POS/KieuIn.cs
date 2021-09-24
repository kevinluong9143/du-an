using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECOPharma2013
{
    public class KieuIn
    {
        public string InCanhGiua(string chuoi)
        {
            string t = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'c', (byte)'A' }) + chuoi;
            return t;
        }
        public string InCanhPhai(string chuoi)
        {
            string t = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'r', (byte)'A' }) + chuoi;
            return t;
        }
    }
        
}
