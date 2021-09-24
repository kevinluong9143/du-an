using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLForm
    {
        private string FormID;

        public string sFormID
        {
            get { return FormID; }
            set { FormID = value; }
        }
        private string MenuID;

        public string sMenuID
        {
            get { return MenuID; }
            set { MenuID = value; }
        }
        private string TenForm;

        public string sTenForm
        {
            get { return TenForm; }
            set { TenForm = value; }
        }
        private bool KhongSuDung;

        public bool bKhongSuDung
        {
            get { return KhongSuDung; }
            set { KhongSuDung = value; }
        }

        public DataTable LoadDSNghiepVuLenList(string MaMenu,string MaNhomNguoiDung)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@FalseHoatDong", SqlDbType.Bit), new SqlParameter("@MenuID", SqlDbType.VarChar, 100), new SqlParameter("@NhomNDid", SqlDbType.VarChar, 50) };
            thamsoinput[0].Value = false;
            thamsoinput[1].Value = MaMenu;
            thamsoinput[2].Value = MaNhomNguoiDung;

            return LopDL.LoadTable("Form_LoadDSFormLenList", thamsoinput);
        }
    }
}
