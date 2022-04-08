using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace araç_satış
{
    public partial class LoginEkranı : Form
    {
        public LoginEkranı()
        {
            InitializeComponent();
        }

        Baglanti bgl = new Baglanti();

        public static string KullanıcıAd = string.Empty;
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            panel2.SendToBack();
            panel2.Visible = true;
            panel2.BringToFront();
            guna2ImageButton1.Visible = true;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            guna2ImageButton1.Visible = false;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            panel2.SendToBack();
            panel2.Visible = true;
            panel2.BringToFront();
            guna2ImageButton1.Visible = true;
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programdan Çıkmak İstediğinize Emin Misiniz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            
            SqlConnection baglanti = new SqlConnection(bgl.Adres);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from AudiGiris where kullaniciadi ='" + gunaTextBox1.Text + "' and sifre = '" + gunaTextBox2.Text + "'", baglanti);
            SqlDataReader reader = komut.ExecuteReader();

            if (reader.Read())
            {
                KullanıcıAd = reader[0].ToString();
               
                    Hide();
                    AnaSayfa a = new AnaSayfa();
                   a.Show();
                

            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                gunaTextBox1.Clear();
                gunaTextBox1.Focus();
                gunaTextBox2.Clear();
            }

            baglanti.Close();
        }

        private void LoginEkranı_Load(object sender, EventArgs e)
        {
            gunaTextBox1.Focus();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            if (txtTC.Text.Length == 11)
            {
                char[] rakamlar = txtTC.Text.ToCharArray();
                int kural1 = 0, hane11 = rakamlar[10], hane10 = rakamlar[9];
                //kural1: ilk 10 rakamın toplamının birler basamağı, 11. rakamı vermektedir.
                for (int i = 0; i < 10; i++)
                {
                    kural1 += Convert.ToInt32(rakamlar[i].ToString());
                }
                char[] birlerbasamagikural1 = kural1.ToString().ToCharArray();

                int kural2tek = 0, kural2cift = 0;
                //kural2:  1, 3, 5, 7 ve 9. rakamın toplamının 7 katı ile 2, 4, 6 ve 8. rakamın toplamının 9 katının toplamının birler basamağı 10. rakamı vermektedir.
                for (int i = 0; i < 10; i += 2)
                {
                    kural2tek += Convert.ToInt32(rakamlar[i].ToString());
                }
                for (int i = 1; i < 9; i += 2)
                {
                    kural2cift += Convert.ToInt32(rakamlar[i].ToString());
                }
                char[] birlerbasamagikural2 = ((7 * kural2tek) + (9 * kural2cift)).ToString().ToCharArray();

                int kural3 = 0;
                //1, 3, 5, 7 ve 9. rakamın toplamının 8 katının birler basamağı 11. rakamı vermektedir.
                for (int i = 0; i < 10; i += 2)
                {
                    kural3 += Convert.ToInt32(rakamlar[i].ToString());
                }
                char[] birlerbasamagikural3 = (8 * kural3).ToString().ToCharArray();

                if ((birlerbasamagikural1[birlerbasamagikural1.Length - 1] == hane11) && (birlerbasamagikural2[birlerbasamagikural2.Length - 1] == hane10) && (birlerbasamagikural3[birlerbasamagikural3.Length - 1] == hane11))
                {
                    if (gunaCheckBox1.Checked==true)
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("insert into AudiGiris(kullaniciadi,sifre,ad,soyad,tc) values (@kullaniciadi,@sifre,@ad,@soyad,@tc)", baglanti);
                        komut.Parameters.AddWithValue("@kullaniciadi", txtkullanıcıadı.Text);
                        komut.Parameters.AddWithValue("@sifre", txtsifre.Text);
                        komut.Parameters.AddWithValue("@ad", txtad.Text);
                        komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                        komut.Parameters.AddWithValue("@tc", txtTC.Text);
                        txtad.Clear();
                        txtsifre.Clear();
                        txtkullanıcıadı.Clear();
                        txtsoyad.Clear();
                        txtTC.Clear();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Kayıt İşlemi Başarıyla Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Kullanıcı ve Gizlilik Sözleşmesini Kabul Ediniz !!!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                            
                }
                else
                {

                    MessageBox.Show("TC Kimlik Numarası Geçerli Değildir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTC.Focus();
                }
            }
            

        }
    }
}
