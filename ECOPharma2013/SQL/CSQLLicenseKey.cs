using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ECOPharma2013.DuLieu;
using GetActiveCode;
using CreateDllLicenseKey;

namespace ECOPharma2013.SQL
{
    class CSQLLicenseKey
    {
        public string LicenseKey { get; set; }

        public CSQLLicenseKey()
        {
            FileInfo file = new FileInfo(@"C:\Windows\LicenseInfo.con");
            StreamReader reader = file.OpenText();
            CStaticBien._LicenseKey = reader.ReadLine().Split(':')[1];
            CStaticBien.STenMayThuNgan = reader.ReadLine().Split(':')[1];
            reader.Close();

            try
            {
                //TestConn();
                if (KiemTraLicense()==false)
                {
                    frmRegistration fRegistration = new frmRegistration();
                    fRegistration.ShowDialog();
                }
            }
            catch (Exception)
            {
                frmRegistration fRegistration = new frmRegistration();
                fRegistration.ShowDialog();
            }
        }

        public static bool KiemTraLicense()
        {
            CreateLicenseKey XacNhanLicense = new CreateLicenseKey();
            CreateActiveCode ActiveCode = new CreateActiveCode();
            string sActiveCode = ActiveCode.GetCode();
            if (CStaticBien.STenMayThuNgan == "")
            {
                return false;
            }

            if (sActiveCode == XacNhanLicense.KiemTraLicenseKey(CStaticBien._LicenseKey))
            {
                return true;
            }
            else
                return false;
            
        }

        public static void GhiFileConfig(string sLicenseKey,string sThuNganID)
        {
            FileInfo file = new FileInfo(@"C:\Windows\LicenseInfo.con");
            StreamWriter writer = new StreamWriter(@"C:\Windows\LicenseInfo.con");
            writer.WriteLine("LicenseKey:" + sLicenseKey);
            writer.WriteLine("ThuNganID:" + sThuNganID);
            writer.Close();
        }
    }
}
