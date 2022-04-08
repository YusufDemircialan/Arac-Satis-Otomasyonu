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
    public partial class Sözleşme : Form
    {
        public Sözleşme()
        {
            InitializeComponent();
        }

        Baglanti bgl = new Baglanti();
        DataTable dt = new DataTable();
        DataSet daset = new DataSet();
        public static string resim = string.Empty;
        public static string arabaadı = string.Empty;
        public static string arabarengi = string.Empty;
        public static string arabafiyatı = string.Empty;
        public static string arabamarka = string.Empty;
        public static string arabaseri = string.Empty;
        public static string arabamodel = string.Empty;
        public static string müsteriAdıSoyadı = string.Empty;
        public static string müsteriTC = string.Empty;
        public static string müsteriTelefon = string.Empty;
        public static string müsteriAdres = string.Empty;
        public static string müsteriEmail = string.Empty;
        public static string müsteriYas = string.Empty;
        public static string müsteriCinsiyet = string.Empty;

        private void ArabaListele()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Araba", baglanti);
            adtr.Fill(daset, "Araba");
            gunaDataGridView1.DataSource = daset.Tables["Araba"];
            gunaDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            baglanti.Close();
        }

        private void gunaGradientButton2_Click_1(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Sepet ", baglanti);
            komut.ExecuteNonQuery();
            SepetiListele();

            resim = gunaDataGridView1.CurrentRow.Cells["resim"].Value.ToString();
            arabarengi = comboRenk.Text;
            arabaadı = comboModel.Text;
            arabafiyatı = gunaDataGridView1.CurrentRow.Cells["arabafiyat"].Value.ToString();
            müsteriAdıSoyadı = txtAdSoyad.Text;
            müsteriAdres = txtAdres.Text;
            müsteriCinsiyet = txtCinsiyet.Text;
            müsteriEmail = txtEmail.Text;
            müsteriTelefon = txtTelefon.Text;
            müsteriYas = txtYas.Text;
            müsteriTC = txtTc.Text;
            arabamarka = txtMarka.Text;
            arabamodel = comboModel.Text;
            arabaseri = comboSeri.Text;

            baglanti.Close();
            SatışPenceresi stş = new SatışPenceresi();
            stş.Dock = DockStyle.Fill;
            stş.TopLevel = false;
            stş.FormBorderStyle = FormBorderStyle.None;
            gunaPanel2.Controls.Add(stş);
            stş.Show();
            stş.BringToFront();


        }

        private void gunaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Araba where arabamodel like'" + comboModel.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            dt.Clear();
            dt.Load(read);
            gunaDataGridView1.DataSource = dt;
            baglanti.Close();
        }

        public int tutucu = 0;
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Araç Sepete Eklensin Mi ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (txtAdSoyad.Text != "" && comboRenk.Text != "" && comboSeri.Text != "" && comboModel.Text != "")
                {
                    if (tutucu==0)
                    {
                        SqlConnection baglanti = new SqlConnection(bgl.Adres);
                        baglanti.Open();
                        SqlCommand komut2 = new SqlCommand("delete from Sepet", baglanti);
                        komut2.ExecuteNonQuery();
                        SqlCommand komut = new SqlCommand("insert into Sepet (tckimlikno,adsoyad,telefon,adres,email,yas,cinsiyet,arabamarka,arabaseri,arabamodel,arabarenk,arabafiyat,resim) values(@tckimlikno,@adsoyad,@telefon,@adres,@email,@yas,@cinsiyet,@arabamarka,@arabaseri,@arabamodel,@arabarenk,@arabafiyat,@resim)", baglanti);
                        komut.Parameters.AddWithValue("@tckimlikno", txtTc.Text);
                        komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                        komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                        komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                        komut.Parameters.AddWithValue("@email", txtEmail.Text);
                        komut.Parameters.AddWithValue("@yas", txtYas.Text);
                        komut.Parameters.AddWithValue("@cinsiyet", txtCinsiyet.Text);
                        komut.Parameters.AddWithValue("@arabamarka", txtMarka.Text);
                        komut.Parameters.AddWithValue("@arabaseri", comboSeri.Text);
                        komut.Parameters.AddWithValue("@arabamodel", comboModel.Text);
                        komut.Parameters.AddWithValue("@arabarenk", comboRenk.Text);                        
                        komut.Parameters.AddWithValue("@arabafiyat", arabafiyatı);                        
                        komut.Parameters.AddWithValue("@resim", resim);                        
                        komut.ExecuteNonQuery();
                        
                        baglanti.Close();

                        MessageBox.Show("Araba Sepete Eklendi.", "Ekleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SepetiListele();
                        
                        tutucu = 1;
                        if (tutucu==1)
                        {
                            gunaGradientButton2.Visible = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tek Seferde Birden Fazla Araç Satın Alamazsınız!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    
                }
                else
                {
                    MessageBox.Show("Müşteri Bilgilerini veya Araç Bilgilerini Eksik Girdiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTc.Focus();
                }

                

            }



            
        }
        private void SepetiListele()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Sepet", baglanti);
            adtr.Fill(daset, "Sepet");
            gunaDataGridView2.DataSource = daset.Tables["Sepet"];
            baglanti.Close();
        }
        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSeri.SelectedIndex == 0)
            {
                comboModel.Items.Clear();
                comboModel.Items.Add("RS5");
                comboModel.Items.Add("RS6");
                comboModel.Items.Add("RS7");

            }
            if (comboSeri.SelectedIndex == 1)
            {
                comboModel.Items.Clear();
                comboModel.Items.Add("A6");
                comboModel.Items.Add("A7");
                comboModel.Items.Add("A8");

            }
            if (comboSeri.SelectedIndex == 2)
            {
                comboModel.Items.Clear();
                comboModel.Items.Add("Q6");
                comboModel.Items.Add("Q7");
                comboModel.Items.Add("Q8");

            }
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Araba where arabaseri like'" + comboSeri.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            dt.Clear();
            dt.Load(read);
            gunaDataGridView1.DataSource = dt;


            baglanti.Close();
        }

        private void gunaComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Araba where arabarenk like'" + comboRenk.Text + "' and arabamodel like'"+comboModel.Text+"'", baglanti);
           
            
            SqlDataReader read = komut.ExecuteReader();
            
            dt.Clear();
            dt.Load(read);

            gunaDataGridView1.DataSource = dt;


            baglanti.Close();
        }
        
        private void Sözleşme_Load(object sender, EventArgs e)
        {
           


            ArabaListele();
            gunaDataGridView1.Columns[0].Visible = false; //KOLON GİZLEME
            gunaDataGridView1.Columns[6].Visible = false; //KOLON GİZLEME
            gunaDataGridView1.Columns[1].HeaderText = "Araba Markası";
            gunaDataGridView1.Columns[2].HeaderText = "Araba Serisi";
            gunaDataGridView1.Columns[3].HeaderText = "Araba Modeli";
            gunaDataGridView1.Columns[4].HeaderText = "Araba Rengi";
            gunaDataGridView1.Columns[5].HeaderText = "Araba Fiyatı";
            SepetiListele();
            gunaDataGridView2.Columns[0].HeaderText = "TC Kimlik Numarası";
            gunaDataGridView2.Columns[1].HeaderText = "Ad Soyad";
            gunaDataGridView2.Columns[2].HeaderText = "Telefon";
            gunaDataGridView2.Columns[3].HeaderText = "Adres";
            gunaDataGridView2.Columns[4].HeaderText = "E-Mail";
            gunaDataGridView2.Columns[5].HeaderText = "Yaş";
            gunaDataGridView2.Columns[6].HeaderText = "Cinsiyet";
            gunaDataGridView2.Columns[7].HeaderText = "Araba Markası";
            gunaDataGridView2.Columns[8].HeaderText = "Araba Serisi";
            gunaDataGridView2.Columns[9].HeaderText = "Araba Modeli";
            gunaDataGridView2.Columns[10].HeaderText = "Araba Rengi";



        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Müşteri where tc like'" + txtTc.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtYas.Text = read["yas"].ToString();
                txtCinsiyet.Text = read["cinsiyet"].ToString();
                txtAdres.Text = read["adres"].ToString();
                txtTelefon.Text = read["telefon"].ToString();
                txtEmail.Text = read["email"].ToString();

            }
            if (txtTc.Text == "")
            {
                txtAdSoyad.Clear();
                txtYas.Clear();
                txtTelefon.Clear();
                txtCinsiyet.Clear();
                txtEmail.Clear();
                txtAdres.Clear();
            }
            baglanti.Close();
        }

        private void gunaDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            
            
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            if (MessageBox.Show("Araç Sepetten Silinsin Mi ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Sepet where tckimlikno='" + gunaDataGridView2.CurrentRow.Cells["tckimlikno"].Value.ToString() + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Yapıldı", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                daset.Tables["Sepet"].Clear();
                SepetiListele();
                tutucu = 0;
                if (tutucu==0)
                {
                    gunaGradientButton2.Visible = false;
                }

            }
        }
    }

}





















