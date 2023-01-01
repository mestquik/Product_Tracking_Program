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
    public partial class frmmusteri : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=CANAVAR;Initial Catalog=DbUrun;Integrated Security=True");
        public frmmusteri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLMUSTERITableAdapter tb = new DataSet1TableAdapters.TBLMUSTERITableAdapter();
        private void btnListele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLMUSTERI", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            
           
            
        }

        private void btnKaydett_Click(object sender, EventArgs e)
        {
            tb.MusteriEkle(txtMusteriAd.Text, txtMusteriSoyad.Text, txtSehir.Text,Decimal.Parse( txtBakiye.Text));
            MessageBox.Show("Müşteri Listeye kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            tb.MusteriSil(int.Parse(txtMusteriID.Text));
            MessageBox.Show("Müşteri başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMusteriID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMusteriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMusteriSoyad.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            

                
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            tb.MusteriGuncellee(txtMusteriAd.Text, txtMusteriSoyad.Text, txtSehir.Text, decimal.Parse(txtBakiye.Text), int.Parse(txtMusteriID.Text));
            MessageBox.Show("Müşteri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if(rdbAd.Checked == true)
            {
                dataGridView1.DataSource = tb.AdaGoreListele(txtAra.Text);
            }
            else if(rdbSoyad.Checked == true)
            {
                dataGridView1.DataSource = tb.SoyadaGoreListele(txtAra.Text);
            }
            else if (rdbSehir.Checked == true)
            {
                dataGridView1.DataSource = tb.SehreGoreListele(txtAra.Text);
            }

        }

        private void frmmusteri_Load(object sender, EventArgs e)
        {

        }
    }
}
