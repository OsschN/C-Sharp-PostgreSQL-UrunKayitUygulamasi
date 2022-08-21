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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglantı = new NpgsqlConnection("server=localHost; port=5432; Database=URUN; " +
          "user ID=postgres; password=nw8szqepo351365");


        private void Form2_Load(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from kategoriler", baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "kategoriad"; //combobox onunde calısan yazı
            comboBox1.ValueMember = "kategoriİd"; //combobox arkasında calısan 
            comboBox1.DataSource = dt;
            baglantı.Close();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * From urunler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlCommand k1 = new NpgsqlCommand("insert into urunler (urunİd,urunad,urunstok,urunalısfiyat,urunsatısfiyat,urunkategori) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglantı);
            k1.Parameters.AddWithValue("@p1", int.Parse(TxtUrunİd.Text));
            k1.Parameters.AddWithValue("@p2", TxtUrunAd.Text);
            k1.Parameters.AddWithValue("@p3", int.Parse(numericUpDown1.Value.ToString()));
            k1.Parameters.AddWithValue("@p4", int.Parse(TxtAlışFiyat.Text));
            k1.Parameters.AddWithValue("@p5", int.Parse(TxtSatışFiyat.Text));
            k1.Parameters.AddWithValue("@p6", int.Parse(comboBox1.SelectedValue.ToString()));
            k1.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Ürün Başarıyla Eklenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlCommand k2 = new NpgsqlCommand("delete from urunler where urunİd=@p1", baglantı);
            k2.Parameters.AddWithValue("@p1", int.Parse(TxtUrunİd.Text));
            k2.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Ürün Başarıyla Silinmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            NpgsqlCommand k3 = new NpgsqlCommand("update urunler set urunad=@p1,urunstok=@p2,urunalısfiyat=@p3,urunsatısfiyat=@p4,urunkategori=@p5 where urunİd=@p6", baglantı);
            k3.Parameters.AddWithValue("@p6", int.Parse(TxtUrunİd.Text));
            k3.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
            k3.Parameters.AddWithValue("@p2", int.Parse(numericUpDown1.Value.ToString()));
            k3.Parameters.AddWithValue("@p3", int.Parse(TxtAlışFiyat.Text));
            k3.Parameters.AddWithValue("@p4", int.Parse(TxtSatışFiyat.Text));
            k3.Parameters.AddWithValue("@p5", int.Parse(comboBox1.SelectedValue.ToString()));
            k3.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kategori Başarıyla Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
