using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ECOPharma2013.DuLieu;


namespace ECOPharma2013
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Tools.AlreadyRunning()) { return; }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
            Application.Run(new frmDangNhap());
            //Application.Run(new frmPhanQuyenEdit());
            //Application.Run(new frmRegistration());
            //Application.Run(new frmNT_DatHangEditAccess());
           
        }
    }
}
