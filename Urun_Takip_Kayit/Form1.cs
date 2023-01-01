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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=CANAVAR;Initial Catalog=DbUrun;Integrated Security=True");
        private void btnListele_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("Select * from TBLKATEGORI",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Insert into TBLKATEGORI (Ad) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", textBox2.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(txtKategoriAdi.Text + " Başarılı bir şekilde eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("DELETE from TBLKATEGORI where ID=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı bir şekilde silindi.");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            
            SqlCommand komutara = new SqlCommand("select * from TBLKATEGORI where Ad=@p1", baglanti);
            komutara.Parameters.AddWithValue("@p1", textBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(komutara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update TBLKATEGORI  set Ad=@p1 where ID=@p2", baglanti);
            komut4.Parameters.AddWithValue("@p1", textBox2.Text);
            komut4.Parameters.AddWithValue("@p2", textBox1.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Tablo başarıyla güncellendi","Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    //Data Source = CANAVAR; Initial Catalog = DbUrun; Integrated Security = True
}
