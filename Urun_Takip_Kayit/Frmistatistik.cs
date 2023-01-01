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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=CANAVAR;Initial Catalog=DbUrun;Integrated Security=True");
        private void Frmistatistik_Load(object sender, EventArgs e)
        { 
            
            //KATEGORİ ADETİ
            baglanti.Open();
            SqlCommand komutKategori = new SqlCommand("Select Count(*) from TBLKATEGORI", baglanti);
            
            SqlDataReader dr = komutKategori.ExecuteReader();
            while (dr.Read())
            {
                lblKategori.Text = dr[0].ToString();
                
            }

            baglanti.Close();
            //URUN ADETİ
            baglanti.Open();
            SqlCommand komutUrun = new SqlCommand("Select Count(UrunId) from TBLURUNLER", baglanti);

            SqlDataReader dr2 = komutUrun.ExecuteReader();
            while (dr2.Read())
            {
                lblUrun.Text = dr2[0].ToString();

            }
            baglanti.Close();

            //EN FAZLA STOK HANGİ ÜRÜNÜN

            baglanti.Open();
            SqlCommand komutmaxstok = new SqlCommand("Select * from TBLURUNLER where Stok=(select max(stok) from TBLURUNLER)", baglanti);

            SqlDataReader dr3 = komutmaxstok.ExecuteReader();
            while (dr3.Read())
            {
                lblMaxStok.Text = dr3[1].ToString();

            }
            baglanti.Close();

            //TOPLAM BİLGİSAYAR SAYISI
            baglanti.Open();
            SqlCommand komutPcToplam = new SqlCommand("select count(*) from TBLURUNLER where kategori=1", baglanti);

            SqlDataReader dr5 = komutPcToplam.ExecuteReader();
            while (dr5.Read())
            {
                lblPcToplam.Text = dr5[0].ToString();

            }
            baglanti.Close();



            //EN DÜŞÜK STOK HANGİ ÜRÜN

            baglanti.Open();
            SqlCommand komutMinStok = new SqlCommand("Select * from TBLURUNLER where Stok=(select min(stok) from TBLURUNLER)", baglanti);

            SqlDataReader dr4 = komutMinStok.ExecuteReader();
            while (dr4.Read())
            {
                lblMinStok.Text = dr4[1].ToString();

            }
            baglanti.Close();


            //EN YÜKSEK FİYATLI ÜRÜN
            baglanti.Open();
            SqlCommand komutMaxFiyat = new SqlCommand("Select max(SatisFiyati) from TBLURUNLER", baglanti);

            SqlDataReader dr6 = komutMaxFiyat.ExecuteReader();
            while (dr6.Read())
            {
                lblMaxFiyat.Text = dr6[0].ToString() + "₺";

            }
            baglanti.Close();


            //EN DÜŞÜK FİYATLI ÜRÜN
            baglanti.Open();
            SqlCommand komutMinFiyat = new SqlCommand("Select min(SatisFiyati) from TBLURUNLER", baglanti);

            SqlDataReader dr7 = komutMinFiyat.ExecuteReader();
            while (dr7.Read())
            {
                lblMinFiyat.Text = dr7[0].ToString() + "₺";

            }
            baglanti.Close();

            //TOPLAM KAR ORANI
            baglanti.Open();
            SqlCommand komutToplamKar = new SqlCommand("Select sum(Stok*(SatisFiyati - AlisFiyati)) from TBLURUNLER", baglanti);

            SqlDataReader dr8 = komutToplamKar.ExecuteReader();
            while (dr8.Read())
            {
                lblToplamKar.Text = dr8[0].ToString() + "₺";

            }
            baglanti.Close();

        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            Frmistatistik.ActiveForm.Hide();
            
            
        }
    }
    }

