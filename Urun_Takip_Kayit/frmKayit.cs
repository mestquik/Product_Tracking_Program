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
    public partial class frmKayit : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=CANAVAR;Initial Catalog=DbUrun;Integrated Security=True");
        public frmKayit()
        {
            InitializeComponent();
        }

        private void txtKullanici_Click(object sender, EventArgs e)
        {

            txtKullanici.Text = null;
            
        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            
            txtSifre.Text = "";
            

        }

        private void TxtSifreTekrar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtSifreTekrar_Click(object sender, EventArgs e)
        {
            TxtSifreTekrar.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtSifre.Text !=TxtSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglanti.Open();
                SqlCommand kayit = new SqlCommand("insert into TBLADMIN (kullanici,sifre) values (@p1,@p2)",baglanti);
                kayit.Parameters.AddWithValue("@p1", txtKullanici.Text);
                kayit.Parameters.AddWithValue("@p2", txtSifre.Text);
                kayit.ExecuteNonQuery();
                MessageBox.Show("Yeni kayıt oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                baglanti.Close();
                this.Hide();
            }
            
        }
    }
}
