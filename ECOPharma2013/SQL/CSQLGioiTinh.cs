using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLGioiTinh
    {
        public CSQLGioiTinh() { }
        public DataTable LayGioiTinh()
        {
            CDuLieu xl = new CDuLieu();
            return xl.LoadTable("GioiTinh_LayGioiTinhLenCombobox", null);
        }
    }
}
