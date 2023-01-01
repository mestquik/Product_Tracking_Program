using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Kayit
{
    public partial class frmGrafik : Form
    {
        public frmGrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=CANAVAR;Initial Catalog=DbUrun;Integrated Security=True");
        private void chart1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand grafik = new SqlCommand("select Ad, count(*) from TBLURUNLER inner join TBLKATEGORI on TBLURUNLER.Kategori = TBLKATEGORI.ID group by Ad", baglanti);
            SqlDataReader dr = grafik.ExecuteReader();

            while(dr.Read())
            {
                chart1.Series["Kategori"].Points.AddXY(dr[0],dr[1]);
                
            }
            baglanti.Close();
        }

    }
}
