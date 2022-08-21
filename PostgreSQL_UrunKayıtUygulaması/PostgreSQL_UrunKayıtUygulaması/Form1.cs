using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace PostgreSQL_UrunKayıtUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglantı = new NpgsqlConnection("server=localHost; port=5432; Database=URUN; " +
            "user ID=postgres; password=nw8szqepo351365");


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * From kategoriler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlCommand k1 = new NpgsqlCommand("insert into kategoriler (kategoriİd,kategoriad) values (@p1,@p2)", baglantı);
            k1.Parameters.AddWithValue("@p1", int.Parse(TxtKategoriİd.Text));
            k1.Parameters.AddWithValue("@p2", TxtKategoriAd.Text);
            k1.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kategori Başarıyla Eklenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlCommand k2 = new NpgsqlCommand("delete from kategoriler where kategoriİd=@p1", baglantı);
            k2.Parameters.AddWithValue("@p1", int.Parse(TxtKategoriİd.Text));
            k2.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kategori Başarıyla Silinmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlCommand k3 = new NpgsqlCommand("update kategoriler set kategoriad=@p1 where kategoriİd=@p2", baglantı);
            k3.Parameters.AddWithValue("@p2", int.Parse(TxtKategoriİd.Text));
            k3.Parameters.AddWithValue("@p1", TxtKategoriAd.Text);
            k3.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kategori Başarıyla Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnGeç_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Hide();
        }
    }
}
