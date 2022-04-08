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
using System.Text.RegularExpressions;

namespace araç_satış
{
    public partial class MüşteriEkle : Form
    {
        public MüşteriEkle()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();
        DataSet daset = new DataSet();
        static bool EmailKontrol(string inputEmail)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            return (new Regex(strRegex)).IsMatch(inputEmail);
        }

        private void MüşteriListele()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Müşteri", baglanti);
            adtr.Fill(daset, "Müşteri");
            gunaDataGridView1.DataSource = daset.Tables["Müşteri"];
            baglanti.Close();
        }
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);

            if (txtTc.Text != "" && txtAdres.Text !="" && txtAdSoyad.Text!="" && txtEmail.Text!=""&& txtTelefon.Text!=""&& txtYas.Text!="")
            {
                if (txtTc.Text.Length == 11)
                {
                    char[] rakamlar = txtTc.Text.ToCharArray();
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
                        string mail = txtEmail.Text;
                        bool kontrol = EmailKontrol(mail);
                        if (kontrol == true)
                        {
                            if (txtTelefon.Text.Length == 11)
                            {
                                baglanti.Open();
                                SqlCommand komut = new SqlCommand("insert into Müşteri(tc,adsoyad,adres,yas,cinsiyet,telefon,email) values (@tc,@adsoyad,@adres,@yas,@cinsiyet,@telefon,@email)", baglanti);
                                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                                komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                                komut.Parameters.AddWithValue("@yas", txtYas.Text);
                                komut.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.Text);
                                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                                komut.Parameters.AddWithValue("@email", txtEmail.Text);
                                komut.ExecuteNonQuery();
                                baglanti.Close();
                                MessageBox.Show("Üye Kaydı Yapıldı.", "Bilgi");
                                txtAdSoyad.Clear();
                                txtEmail.Clear();
                                txtTc.Clear();
                                txtTelefon.Clear();
                                txtYas.Clear();
                                txtAdres.Clear();
                                comboCinsiyet.SelectedIndex = -1;
                                daset.Tables["Müşteri"].Clear();
                                MüşteriListele();
                                gunaDataGridView1.Refresh();

                            }
                            else
                            {
                                MessageBox.Show("Telefon Numarası Eksik veya Hatalı Girilmiştir.\nLütfen Telefon Numaranızı 11 Haneli Olacak Şekilde Giriniz..!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtTelefon.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("E-mail Adresiniz Eksik veya Hatalı Girilmiştir.\nLütfen Tekrar Deneyiniz..!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmail.Focus();
                        }
                    }
                    else
                    {

                        MessageBox.Show("TC Kimlik Numarası Geçerli Değildir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTc.Focus();
                    }
                }
                else
                {
                    MessageBox.Show(" TC Kimlik Numaranızı Eksik Girdiniz Lütfen Kontrol Ediniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTc.Focus();
                }
            }
            else
            {

                MessageBox.Show(" Bilgileri Eksiksiz Ve Doğru Şekilde Doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MüşteriEkle_Load(object sender, EventArgs e)
        {
            MüşteriListele();
            gunaDataGridView1.Columns[0].HeaderText = "TC Kimlik Numarası";
            gunaDataGridView1.Columns[1].HeaderText = "Ad Soyad";
            gunaDataGridView1.Columns[2].HeaderText = "Adres";
            gunaDataGridView1.Columns[3].HeaderText = "Yaş";
            gunaDataGridView1.Columns[4].HeaderText = "Cinsiyet";
            gunaDataGridView1.Columns[5].HeaderText = "Telefon Numarası";
            gunaDataGridView1.Columns[6].HeaderText = "E-mail";

        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            if (MessageBox.Show("Bu kaydı güncellemek istiyor musunuz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Müşteri set adsoyad=@adsoyad,adres=@adres,yas=@yas,cinsiyet=@cinsiyet,telefon=@telefon,email=@email where tc=@tc", baglanti);
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                komut.Parameters.AddWithValue("@yas", txtYas.Text);
                komut.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@email", txtEmail.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme işlemi gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                daset.Tables["Müşteri"].Clear();
                MüşteriListele();
                txtTc.Clear();
                txtAdSoyad.Clear();
                txtYas.Clear();
                txtTelefon.Clear();
                comboCinsiyet.SelectedIndex = -1;
                txtEmail.Clear();
                gunaDataGridView1.Refresh();

            }
        }

        private void gunaDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtTc.Text = gunaDataGridView1.CurrentRow.Cells["tc"].Value.ToString();

        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            
            /**baglanti.Open();
            
            daset.Tables["Müşteri"].Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Müşteri where tc like '" + txtTc.Text + "'", baglanti);
            adtr.Fill(daset, "Müşteri");
            gunaDataGridView1.DataSource = daset.Tables["Müşteri"];
            baglanti.Close();*/
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Müşteri where tc like'" + txtTc.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtYas.Text = read["yas"].ToString();
                comboCinsiyet.Text = read["cinsiyet"].ToString();
                txtAdres.Text = read["adres"].ToString();
                txtTelefon.Text = read["telefon"].ToString();
                txtEmail.Text = read["email"].ToString();

            }
            if (txtTc.Text == "")
            {
                txtAdSoyad.Clear();
                txtYas.Clear();
                txtTelefon.Clear();
                comboCinsiyet.SelectedIndex = -1;
                txtEmail.Clear();
                txtAdres.Clear();
            }
            baglanti.Close();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            if (MessageBox.Show("Bu kaydı silmek istiyor musunuz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Müşteri where tc=@tc", baglanti);
                komut.Parameters.AddWithValue("@tc", gunaDataGridView1.CurrentRow.Cells["tc"].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                daset.Tables["Müşteri"].Clear();
                MüşteriListele();
                txtTc.Clear();
                gunaDataGridView1.Refresh();
            }
        }
    }
}
