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
    public partial class SatışPenceresi : Form
    {
        public SatışPenceresi()
        {
            InitializeComponent();
        }

        Baglanti bgl = new Baglanti();
        DataSet daset = new DataSet();

        string KartNoTemizle(string text)
        {
            text = text.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("_", "");
            return text;
        }
        bool KartNoUzunlukKontrol(string kartno)
        {
            if (kartno.Length == 16)
                return true;
            else
                return false;
        }
        bool SayisalDegerKontrol(string deger)
        {
            foreach (char chr in deger)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
        int SayiBasamaklariTopla(int sayi)
        {
            int toplam = 0;
            while (sayi > 0)
            {
                toplam += sayi % 10;
                sayi /= 10;
            }
            return toplam;
        }
        bool Kredi_Kart_Lunh_Algoritmasi(string kartno)
        {
            kartno = KartNoTemizle(kartno); // kart numarasını temizledik.

            if (KartNoUzunlukKontrol(kartno) == false) // uzunluğu kontrol ettik
                return false;
            else if (SayisalDegerKontrol(kartno) == false) // sayısal değerleri kontrol ettik
                return false;
            else
            {
                int ciftlerin_toplami = 0;
                int teklerin_toplami = 0;
                for (int i = 0; i < kartno.Length; i++)
                {
                    int eleman = Convert.ToInt32(kartno[i].ToString());
                    if (i % 2 == 0)
                        ciftlerin_toplami += SayiBasamaklariTopla(eleman * 2);
                    else
                        teklerin_toplami += eleman;
                }
                int sonuc = (teklerin_toplami + ciftlerin_toplami) % 10;
                if (sonuc == 0)
                    return true;
                else
                    return false;
            }
        }




        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            if (Kredi_Kart_Lunh_Algoritmasi(txtKartNo.Text) == true)
            {
                string bos = "-";
                if (MessageBox.Show("Satış İşlemi Gerçekleştirilsin Mi ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection baglanti = new SqlConnection(bgl.Adres);
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into Satışlar(tckimliknumarası,adsoyad,telefon,adres,email,yas,cinsiyet,arabamarka,arabaseri,arabamodel,arabarenk,ödemetipi,alınannakit,kartnumarası,kartadsoyad,kartsonkullanım,kartcvv,arabafiyat) values (@tckimliknumarası,@adsoyad,@telefon,@adres,@email,@yas,@cinsiyet,@arabamarka,@arabaseri,@arabamodel,@arabarenk,@ödemetipi,@alınannakit,@kartnumarası,@kartadsoyad,@kartsonkullanım,@kartcvv,@arabafiyat)", baglanti);
                    komut.Parameters.AddWithValue("@tckimliknumarası", Sözleşme.müsteriTC);
                    komut.Parameters.AddWithValue("@adsoyad", Sözleşme.müsteriAdıSoyadı);
                    komut.Parameters.AddWithValue("@telefon", Sözleşme.müsteriTelefon);
                    komut.Parameters.AddWithValue("@adres", Sözleşme.müsteriAdres);
                    komut.Parameters.AddWithValue("@email", Sözleşme.müsteriEmail);
                    komut.Parameters.AddWithValue("@yas", Sözleşme.müsteriYas);
                    komut.Parameters.AddWithValue("@cinsiyet", Sözleşme.müsteriCinsiyet);
                    komut.Parameters.AddWithValue("@arabamarka", Sözleşme.arabamarka);
                    komut.Parameters.AddWithValue("@arabaseri", Sözleşme.arabaseri);
                    komut.Parameters.AddWithValue("@arabamodel", Sözleşme.arabamodel);
                    komut.Parameters.AddWithValue("@arabarenk", Sözleşme.arabarengi);
                    komut.Parameters.AddWithValue("@ödemetipi", lblsatıştürü.Text);
                    komut.Parameters.AddWithValue("@alınannakit", bos);
                    komut.Parameters.AddWithValue("@kartnumarası", label6.Text);
                    komut.Parameters.AddWithValue("@kartadsoyad", label13.Text);
                    komut.Parameters.AddWithValue("@kartsonkullanım", label11.Text);
                    komut.Parameters.AddWithValue("@kartcvv", label14.Text);
                    komut.Parameters.AddWithValue("@arabafiyat", txtArabaFiyatı.Text);
                    komut.ExecuteNonQuery();
                    comboAy.SelectedIndex = -1;
                    ComboYıl.SelectedIndex = -1;
                    txtAdsoyad_.Clear();
                    txtcvv.Clear();
                    txtKartNo.Clear();
                    baglanti.Close();
                    if (MessageBox.Show("Satış İşlemi Başarıyla Gerçekleşmiştir.\n Allah Kaza Bela Vermesin :)", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Hide();
                        gunaPanel2.BringToFront();
                        gunaPanel2.Show();
                    }
                }
            }
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            label6.Text = txtKartNo.Text;
        }

        private void maskedTextBox2_KeyUp_1(object sender, KeyEventArgs e)
        {
            label14.Text = txtcvv.Text;
        }

        private void gunaComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label11.Text = comboAy.Text + "/" + ComboYıl.Text;
        }

        private void gunaTextBox2_TextChanged_1(object sender, EventArgs e)
        {
            label13.Text = txtAdsoyad_.Text;
        }

        private void gunaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label11.Text = comboAy.Text + "/" + ComboYıl.Text;
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            Hide();
            gunaPanel2.BringToFront();
            gunaPanel2.Show();
        }

        private void gunaPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            lblsatıştürü.Text = "Nakit";
            gunaGroupBox1.Visible = false;
            gunaGroupBox2.Visible = true;
        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            lblsatıştürü.Text = "Kredi Kartı";
            gunaGroupBox1.Visible = true;
            gunaGroupBox2.Visible = false;

        }

        private void SatışPenceresi_Load(object sender, EventArgs e)
        {
            txtAdSoyad.Text = Sözleşme.müsteriAdıSoyadı;
            gunaPictureBox1.Image = Image.FromFile(Sözleşme.resim);
            label7.Text = Sözleşme.arabaadı;
            label3.Text = Sözleşme.arabarengi;
            txtArabaFiyatı.Text = Sözleşme.arabafiyatı;
            gunaGroupBox1.Visible = false;
            gunaGroupBox2.Visible = false;
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            string bos = "-";
            if (MessageBox.Show("Satış İşlemi Gerçekleştirilsin Mi ?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                SqlConnection baglanti = new SqlConnection(bgl.Adres);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Satışlar(tckimliknumarası,adsoyad,telefon,adres,email,yas,cinsiyet,arabamarka,arabaseri,arabamodel,arabarenk,ödemetipi,alınannakit,kartnumarası,kartadsoyad,kartsonkullanım,kartcvv,arabafiyat) values (@tckimliknumarası,@adsoyad,@telefon,@adres,@email,@yas,@cinsiyet,@arabamarka,@arabaseri,@arabamodel,@arabarenk,@ödemetipi,@alınannakit,@kartnumarası,@kartadsoyad,@kartsonkullanım,@kartcvv,@arabafiyat)", baglanti);
                komut.Parameters.AddWithValue("@tckimliknumarası", Sözleşme.müsteriTC);
                komut.Parameters.AddWithValue("@adsoyad", Sözleşme.müsteriAdıSoyadı);
                komut.Parameters.AddWithValue("@telefon", Sözleşme.müsteriTelefon);
                komut.Parameters.AddWithValue("@adres", Sözleşme.müsteriAdres);
                komut.Parameters.AddWithValue("@email", Sözleşme.müsteriEmail);
                komut.Parameters.AddWithValue("@yas", Sözleşme.müsteriYas);
                komut.Parameters.AddWithValue("@cinsiyet", Sözleşme.müsteriCinsiyet);
                komut.Parameters.AddWithValue("@arabamarka", Sözleşme.arabamarka);
                komut.Parameters.AddWithValue("@arabaseri", Sözleşme.arabaseri);
                komut.Parameters.AddWithValue("@arabamodel", Sözleşme.arabamodel);
                komut.Parameters.AddWithValue("@arabarenk", Sözleşme.arabarengi);
                komut.Parameters.AddWithValue("@ödemetipi", lblsatıştürü.Text);
                komut.Parameters.AddWithValue("@alınannakit", txtAlınanNakit.Text);
                komut.Parameters.AddWithValue("@kartnumarası", bos);
                komut.Parameters.AddWithValue("@kartadsoyad", bos);
                komut.Parameters.AddWithValue("@kartsonkullanım", bos);
                komut.Parameters.AddWithValue("@kartcvv", bos);
                komut.Parameters.AddWithValue("@arabafiyat", txtArabaFiyatı.Text);
                komut.ExecuteNonQuery();
                txtAdSoyad.Clear();
                txtAlınanNakit.Clear();
                baglanti.Close();
                if (MessageBox.Show("Satış İşlemi Başarıyla Gerçekleşmiştir.\n Allah Kaza Bela Vermesin :)", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Hide();
                    gunaPanel2.BringToFront();
                    gunaPanel2.Show();
                }
            }
           
        }

        private void txtAlınanNakit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
