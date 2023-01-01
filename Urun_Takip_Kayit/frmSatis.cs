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
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLSATISLARTableAdapter ds = new DataSet1TableAdapters.TBLSATISLARTableAdapter();
        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=CANAVAR;Initial Catalog=DbUrun;Integrated Security=True");
        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("execute SatisListesi", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSatis_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLURUNLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            cmbUrun.ValueMember = "UrunId";
            cmbUrun.DisplayMember = "UrunAd";
            cmbUrun.DataSource = dt2;

            
            dataGridView1.DataSource = ds.SatisListesi();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ds.SatisEkle(int.Parse(cmbUrun.SelectedValue.ToString()), int.Parse(textMusteri.Text), byte.Parse(txtAdet1.Text), decimal.Parse(txtFiyat1.Text), decimal.Parse(txtToplam1.Text), DateTime.Parse(mskTarih.Text));
            MessageBox.Show("Başarıyla Kaydedildi", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double adet, fiyat, toplam;

            adet = Convert.ToDouble(txtAdet1.Text);
            fiyat = Convert.ToDouble(txtFiyat1.Text);
            toplam = adet * fiyat;
            txtToplam1.Text = toplam.ToString();



            


        }
    }
}
