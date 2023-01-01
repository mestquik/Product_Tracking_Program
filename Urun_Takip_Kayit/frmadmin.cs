using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Urun_Takip_Kayit
{
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=CANAVAR;Initial Catalog=DbUrun;Integrated Security=True");
        private void frmadmin_Load(object sender, EventArgs e)
        {
            


        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand giris = new SqlCommand("select * from TBLADMIN where Kullanici=@p1 and Sifre=@p2", baglanti);
            giris.Parameters.AddWithValue("@p1", txtKullanici.Text);
            giris.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if(dr.Read())
            {
                frmYonlendirme fy = new frmYonlendirme();
                
                this.Hide();
                fy.Show();
                
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            baglanti.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmKayit kayit = new frmKayit();
            kayit.Show();
        }
    }
}
