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
using System.Data.Sql;

namespace araç_satış
{
    public partial class Satışlar : Form
    {
        public Satışlar()
        {
            InitializeComponent();
        }

        Baglanti bgl = new Baglanti();
        DataTable dt = new DataTable();
        DataSet daset = new DataSet();
        private void SatışlarıListele()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Satışlar", baglanti);
            adtr.Fill(daset, "Satışlar");
            gunaDataGridView1.DataSource = daset.Tables["Satışlar"];
            gunaDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            baglanti.Close();
        }

        private void Satışlar_Load(object sender, EventArgs e)
        {
            SatışlarıListele();
            gunaDataGridView1.Columns[0].HeaderText = "Satış No";
            gunaDataGridView1.Columns[1].HeaderText = "TC Kimlik Numarası";
            gunaDataGridView1.Columns[2].HeaderText = "Ad Soyad";
            gunaDataGridView1.Columns[3].HeaderText = "Telefon";
            gunaDataGridView1.Columns[4].HeaderText = "Adres";
            gunaDataGridView1.Columns[5].HeaderText = "E-Mail";
            gunaDataGridView1.Columns[6].HeaderText = "Yaş";
            gunaDataGridView1.Columns[7].HeaderText = "Cinsiyet";
            gunaDataGridView1.Columns[8].HeaderText = "Araba Markası";
            gunaDataGridView1.Columns[9].HeaderText = "Araba Seri";
            gunaDataGridView1.Columns[10].HeaderText = "Araba Model";
            gunaDataGridView1.Columns[11].HeaderText = "Araba Renk";
            gunaDataGridView1.Columns[12].HeaderText = "Ödeme Tipi";
            gunaDataGridView1.Columns[13].HeaderText = "Alınan Nakit";
            gunaDataGridView1.Columns[14].HeaderText = "Kart Numarası";
            gunaDataGridView1.Columns[15].HeaderText = "Kart Ad Soyad";
            gunaDataGridView1.Columns[16].HeaderText = "Kart Son Kullanım Tarihi";
            gunaDataGridView1.Columns[17].HeaderText = "Kart CVV";
            gunaDataGridView1.Columns[18].HeaderText = "Araba Fiyatı";

          

        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            if (MessageBox.Show("Bu kaydı silmek istiyor musunuz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Satışlar where satisid=@satisid", baglanti);
                komut.Parameters.AddWithValue("@satisid", gunaDataGridView1.CurrentRow.Cells["satisid"].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                daset.Tables["Satışlar"].Clear();
                SatışlarıListele();
                gunaDataGridView1.Refresh();
            }
        }
    }
}
