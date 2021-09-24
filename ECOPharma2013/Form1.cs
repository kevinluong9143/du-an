using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ECOPharma2013
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            
            float GiaTri=(float)1/(float)3;
            MessageBox.Show(GiaTri.ToString());

            string insert = "insert into Test (giatri) values(" + GiaTri + ")";
            ECOPharma2013.DuLieu.CDuLieu lop = new DuLieu.CDuLieu();
            SqlParameter[] thamso={new SqlParameter("@GiaTri", SqlDbType.Float)};
            thamso[0].Value=GiaTri;
            lop.Them(insert, null, null);
            
        }
    }
}
