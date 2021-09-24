using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLMenu
    {
        private string MenuID;

        public string cMenuID
        {
            get { return MenuID; }
            set { MenuID = value; }
        }
        private string TenMenu;

        public string sTenMenu
        {
            get { return TenMenu; }
            set { TenMenu = value; }
        }
        private bool KhongSuDung;

        public bool bKhongSuDung
        {
            get { return KhongSuDung; }
            set { KhongSuDung = value; }
        }

        public DataTable LoadDSMenuLenCombobox()
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@FalseHoatDong", SqlDbType.Bit) };
            thamsoinput[0].Value = false;

            return LopDL.LoadTable("Menu_LoadDSMenuLenCombobox", thamsoinput);
        }
    }
}
