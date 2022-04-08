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
    public partial class AraçListele : Form
    {
        public AraçListele()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();
        DataTable dt = new DataTable();
        DataSet daset = new DataSet();

        private void ArabaListele()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Araba", baglanti);
            adtr.Fill(daset, "Araba");
            gunaDataGridView1.DataSource = daset.Tables["Araba"];
            baglanti.Close();
        }
        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (gunaComboBox1.SelectedIndex==0)
            {
                gunaComboBox2.Items.Clear();
                gunaComboBox2.Items.Add("RS5");
                gunaComboBox2.Items.Add("RS6");
                gunaComboBox2.Items.Add("RS7");

            }
            if (gunaComboBox1.SelectedIndex == 1)
            {
                gunaComboBox2.Items.Clear();
                gunaComboBox2.Items.Add("A6");
                gunaComboBox2.Items.Add("A7");
                gunaComboBox2.Items.Add("A8");

            }
            if (gunaComboBox1.SelectedIndex == 2)
            {
                gunaComboBox2.Items.Clear();
                gunaComboBox2.Items.Add("Q6");
                gunaComboBox2.Items.Add("Q7");
                gunaComboBox2.Items.Add("Q8");

            }
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Araba where arabaseri like'" + gunaComboBox1.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            dt.Clear();
            dt.Load(read);
            gunaDataGridView1.DataSource = dt;
            

            baglanti.Close();
        }

        private void gunaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Araba where arabamodel like'" + gunaComboBox2.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            dt.Clear();
            dt.Load(read);
            gunaDataGridView1.DataSource = dt;

            baglanti.Close();
        }

        private void AraçListele_Load(object sender, EventArgs e)
        {
            ArabaListele();
            gunaDataGridView1.Columns[0].Visible = false; //KOLON GİZLEME
            gunaDataGridView1.Columns[6].Visible = false; //KOLON GİZLEME
            gunaDataGridView1.Columns[1].HeaderText = "Araba Markası";
            gunaDataGridView1.Columns[2].HeaderText = "Araba Serisi";
            gunaDataGridView1.Columns[3].HeaderText = "Araba Modeli";
            gunaDataGridView1.Columns[4].HeaderText = "Araba Rengi";
            gunaDataGridView1.Columns[5].HeaderText = "Araba Fiyatı";
        }
    }
}
