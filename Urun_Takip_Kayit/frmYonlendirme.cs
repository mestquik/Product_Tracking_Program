using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Kayit
{
    public partial class frmYonlendirme : Form
    {
        public frmYonlendirme()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            frmUrun frmurun = new frmUrun();
            frmurun.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Frmistatistik frmist = new Frmistatistik();
            frmist.Show();
        }

        private void frmYonlendirme_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            frmUrun frmurun = new frmUrun();
            frmurun.Show();
            
        }

        private void pnlKategori_Click(object sender, EventArgs e)
        {
            Form1 frmKategori = new Form1();
            frmKategori.Show();
        }

        private void pnpIstatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik frmist = new Frmistatistik();
            frmist.Show();
        }

        private void pnlGrafik_Click(object sender, EventArgs e)
        {
            frmGrafik frmgrafik = new frmGrafik();
            frmgrafik.Show();
        }

        private void pnlLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblKategori_Click(object sender, EventArgs e)
        {
            Form1 frmKategori = new Form1();
            frmKategori.Show();
        }

        private void lblIstatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik frmist = new Frmistatistik();
            frmist.Show();
        }

        private void lblGrafik_Click(object sender, EventArgs e)
        {
            frmGrafik frmgrafik = new frmGrafik();
            frmgrafik.Show();
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            frmmusteri musteriform = new frmmusteri();
            musteriform.Show();

        }
    }
}
