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
    public partial class frmUrun : Form
    {
        public frmUrun()
        {
            InitializeComponent();

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=CANAVAR;Initial Catalog=DbUrun;Integrated Security=True");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        private void btnListele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutliste = new SqlCommand("Select UrunId,UrunAd,Stok,AlisFiyati,SatisFiyati,Ad,Kategori from TBLURUNLER inner join TBLKATEGORI on TBLURUNLER.kategori = TBLKATEGORI.ID", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komutliste);
            DataTable dt = new DataTable();
            da.Fill(dt);      
            dataGridView1.DataSource = dt;
            cmbKategori.DisplayMember = "Ad";
            dataGridView1.Columns["Kategori"].Visible = false;
            
            baglanti.Close();
            

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void frmUrun_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from TBLKATEGORI", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cmbKategori.DisplayMember = "Ad";
            cmbKategori.ValueMember = "ID";

            cmbKategori.DataSource = dt2;
            baglanti.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutt = new SqlCommand("INSERT INTO TBLURUNLER (UrunAd,Stok,AlisFiyati,SatisFiyati,Kategori) VALUES (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komutt.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komutt.Parameters.AddWithValue("@p2", nudStok.Value);
            komutt.Parameters.AddWithValue("@p3", txtUrunAlis.Text);
            komutt.Parameters.AddWithValue("@p4", txtUrunSatis.Text);
            komutt.Parameters.AddWithValue("@p5", cmbKategori.SelectedValue);  
            komutt.ExecuteNonQuery();        
            baglanti.Close();
            MessageBox.Show("Ürün başarıyla eklendi", "Bilgi");

        }

        

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from TBLURUNLER where UrunId=@p1", baglanti);
            komutsil.Parameters.AddWithValue("@p1", txturunID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün başarılı bir şekilde silindi.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txturunID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();        
            nudStok.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtUrunAlis.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUrunSatis.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbKategori.SelectedValue = (dataGridView1.Rows[e.RowIndex].Cells[6].Value).ToString();
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("update TBLURUNLER set UrunAd=@p1,Stok=@p2,AlisFiyati=@p3,SatisFiyati=@p4,Kategori=@p5 where UrunID=@p6 ", baglanti);
            komutguncelle.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", nudStok.Value);
            komutguncelle.Parameters.AddWithValue("@p3", txtUrunAlis.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txtUrunSatis.Text);
            komutguncelle.Parameters.AddWithValue("@p5", cmbKategori.SelectedValue);
            komutguncelle.Parameters.AddWithValue("@p6", txturunID.Text);
            
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Başarıyla güncellendi", "Bilgi");
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {

            Frmistatistik istatistik = new Frmistatistik();
            istatistik.Show();
            
        }
    }
}
