using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace araç_satış
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }
        int cpt = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            gunaCirclePictureBox6.Visible = false;
            gunaCirclePictureBox7.Visible = false;


            gunaDataGridView1.Rows.Add(2);

            gunaDataGridView1.Rows[0].Cells[0].Value = Image.FromFile(@"car\1.png");
            gunaDataGridView1.Rows[1].Cells[0].Value = Image.FromFile(@"car\2.png");
            gunaDataGridView1.Rows[2].Cells[0].Value = Image.FromFile(@"car\3.png");




            gunaDataGridView1.Rows[0].Cells[1].Value = "Audi RS6";
            gunaDataGridView1.Rows[1].Cells[1].Value = "Audi Q8";
            gunaDataGridView1.Rows[2].Cells[1].Value = "Audi A8";


            gunaLabel2.Text = "Audi RS6";
            gunaLabel1.Text = "Motor Özellikleri";
            gunaLabel3.Text = "\nGüç çıkışı: 441 kW (600 hp). \nMaksimum tork: 800 Nm. \nYakıt tüketimi, ortalama: 11.7-11.5 l/100 km. \nCO₂ emisyonları, ortalama: 268-263 g/km. \nSilindir cc: 3996 cc3.";
            gunaLabel4.Text = "TFSI quattro tiptronic";
            gunaLabel6.Text = "3.6 s¹";
            gunaLabel9.Text = "2150 kg";
            gunaLabel11.Text = "550 lt";
            gunaLabel13.Text = "Siyah";
            guna2RatingStar1.Value = 4;
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            gunaAdvenceButton1.Checked = true;
            gunaAdvenceButton2.Checked = false;
            gunaAdvenceButton3.Checked = false;
            gunaAdvenceButton4.Checked = false;

            MüşteriEkle a = new MüşteriEkle();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            gunaPanel4.Controls.Add(a);
            a.Show();
            a.BringToFront();
            gunaAdvenceButton7.Checked = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            gunaPanel1.BringToFront();
            gunaPanel1.Show();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            if (cpt > 1)
            {
                cpt--;
                gunaPictureBox_car.Image = (Image)gunaDataGridView1.Rows[cpt - 1].Cells[0].Value;

                gunaPictureBox_car1.Load(@"car\" + cpt.ToString() + ".png");
                gunaPictureBox_car2.Load(@"car\" + cpt.ToString() + cpt.ToString() + ".png");
                gunaPictureBox_car3.Load(@"car\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + ".png");
                gunaPictureBox_car1.Image = gunaPictureBox_car.Image;


            }
            if (cpt == 1)
            {
                gunaCirclePictureBox5.Visible = true;
                gunaCirclePictureBox6.Visible = false;
                gunaCirclePictureBox7.Visible = false;
                gunaLabel2.Text = "Audi RS6";
                gunaLabel1.Text = "Motor Özellikleri";
                gunaLabel3.Text = "\nGüç çıkışı: 441 kW (600 hp). \nMaksimum tork: 800 Nm. \nYakıt tüketimi, ortalama: 11.7-11.5 l/100 km. \nCO₂ emisyonları, ortalama: 268-263 g/km. \nSilindir cc: 3996 cc3.";
                gunaLabel4.Text = "TFSI quattro tiptronic";
                gunaLabel6.Text = "3.6 s¹";
                gunaLabel9.Text = "2150 kg";
                gunaLabel11.Text = "550 lt";
                gunaLabel13.Text = "Siyah";
                guna2RatingStar1.Value = 4;

            }
            if (cpt == 2)
            {
                gunaCirclePictureBox5.Visible = false;
                gunaCirclePictureBox6.Visible = false;
                gunaCirclePictureBox7.Visible = true;
                gunaLabel2.Text = "Audi Q8";
                gunaLabel1.Text = "Motor Özellikleri";
                gunaLabel3.Text = "\nGüç çıkışı: 286 hp (210 kW). \nMaksimum tork: 600 Nm. \nYakıt tüketimi, ortalama: 8.8-8.3 l/100 km. \nCO₂ emisyonları, ortalama: 229-219 g/km. \nSilindir cc: 2967 cc3.";
                gunaLabel4.Text = "50 TDI quattro tiptronic";
                gunaLabel6.Text = "6.1 s¹";
                gunaLabel9.Text = "2245 kg";
                gunaLabel11.Text = "605 lt";
                gunaLabel13.Text = "Siyah";
                guna2RatingStar1.Value = 5;
            }
            if (cpt == 3)
            {
                gunaCirclePictureBox5.Visible = false;
                gunaCirclePictureBox6.Visible = true;
                gunaCirclePictureBox7.Visible = false;
                gunaLabel2.Text = "Audi A8 L";
                gunaLabel1.Text = "Motor Özellikleri";
                gunaLabel3.Text = "\nGüç çıkışı: 340 hp (250 kW). \nMaksimum tork: 500 Nm. \nYakıt tüketimi, ortalama: 10.3-9.4 l/100 km. \nCO₂ emisyonları, ortalama: 234-214 g/km. \nSilindir cc: 2995 cc3.";
                gunaLabel4.Text = "55 TFSI quattro tiptronic";
                gunaLabel6.Text = "5.7 s¹";
                gunaLabel9.Text = "2055 kg";
                gunaLabel11.Text = "505 lt";
                gunaLabel13.Text = "Siyah";
                guna2RatingStar1.Value = 3;

            }
        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {

            if (cpt < gunaDataGridView1.Rows.Count)
            {
                cpt++;
                gunaPictureBox_car.Image = (Image)gunaDataGridView1.Rows[cpt - 1].Cells[0].Value;

                gunaPictureBox_car1.Load(@"car\" + cpt.ToString() + ".png");
                gunaPictureBox_car2.Load(@"car\" + cpt.ToString() + cpt.ToString() + ".png");
                gunaPictureBox_car3.Load(@"car\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + ".png");
                gunaPictureBox_car1.Image = gunaPictureBox_car.Image;
                gunaLabel13.Text = "Siyah";


            }
            if (cpt == 1)
            {
                gunaCirclePictureBox5.Visible = true;
                gunaCirclePictureBox6.Visible = false;
                gunaCirclePictureBox7.Visible = false;
                gunaLabel2.Text = "Audi RS6";
                gunaLabel1.Text = "Motor Özellikleri";
                gunaLabel3.Text = "\nGüç çıkışı: 600 hp (441 kW). \nMaksimum tork: 800 Nm. \nYakıt tüketimi, ortalama: 13.1-12.5 l/100 km. \nCO₂ emisyonları, ortalama: 297-283 g/km. \nSilindir cc: 3996 cc3.";
                gunaLabel4.Text = "TFSI quattro tiptronic";
                gunaLabel6.Text = "3.6 s¹";
                gunaLabel9.Text = "2150 kg";
                gunaLabel11.Text = "550 lt";
                gunaLabel13.Text = "Siyah";
                guna2RatingStar1.Value = 4;


            }
            if (cpt == 2)
            {
                gunaCirclePictureBox5.Visible = false;
                gunaCirclePictureBox6.Visible = false;
                gunaCirclePictureBox7.Visible = true;
                gunaLabel2.Text = "Audi Q8";
                gunaLabel1.Text = "Motor Özellikleri";
                gunaLabel3.Text = "\nGüç çıkışı: 286 hp (210 kW). \nMaksimum tork: 600 Nm. \nYakıt tüketimi, ortalama: 8.8-8.3 l/100 km. \nCO₂ emisyonları, ortalama: 229-219 g/km. \nSilindir cc: 2967 cc3.";
                gunaLabel4.Text = "50 TDI quattro tiptronic";
                gunaLabel6.Text = "6.1 s¹";
                gunaLabel9.Text = "2245 kg";
                gunaLabel11.Text = "605 lt";
                gunaLabel13.Text = "Siyah";
                guna2RatingStar1.Value = 5;
            }
            if (cpt == 3)
            {
                gunaCirclePictureBox5.Visible = false;
                gunaCirclePictureBox6.Visible = true;
                gunaCirclePictureBox7.Visible = false;
                gunaLabel2.Text = "Audi A8 L";
                gunaLabel1.Text = "Motor Özellikleri";
                gunaLabel3.Text = "\nGüç çıkışı: 340 hp (250 kW). \nMaksimum tork: 500 Nm. \nYakıt tüketimi, ortalama: 10.3-9.4 l/100 km. \nCO₂ emisyonları, ortalama: 234-214 g/km. \nSilindir cc: 2995 cc3.";
                gunaLabel4.Text = "55 TFSI quattro tiptronic";
                gunaLabel6.Text = "5.7 s¹";
                gunaLabel9.Text = "2055 kg";
                gunaLabel11.Text = "505 lt";
                gunaLabel13.Text = "Siyah";
                guna2RatingStar1.Value = 3;

            }
        }

        private void gunaPictureBox_car1_Click(object sender, EventArgs e)
        {
            gunaPictureBox_car.Image = gunaPictureBox_car1.Image;
        }

        private void gunaPictureBox_car2_Click(object sender, EventArgs e)
        {
            gunaPictureBox_car.Image = gunaPictureBox_car2.Image;
        }

        private void gunaPictureBox_car3_Click_1(object sender, EventArgs e)
        {
            gunaPictureBox_car.Image = gunaPictureBox_car3.Image;
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            gunaPictureBox_car.Load(@"car\" + cpt.ToString() + ".png");
            gunaPictureBox_car1.Load(@"car\" + cpt.ToString() + ".png");
            gunaPictureBox_car2.Load(@"car\" + cpt.ToString() + cpt.ToString() + ".png");
            gunaPictureBox_car3.Load(@"car\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + ".png");
            gunaLabel13.Text = "Siyah";
        }

        private void gunaCirclePictureBox2_Click_1(object sender, EventArgs e)
        {
            gunaPictureBox_car.Load(@"car\" + cpt.ToString() + "g.png");
            gunaPictureBox_car1.Load(@"car\" + cpt.ToString() + "g.png");
            gunaPictureBox_car2.Load(@"car\" + cpt.ToString() + cpt.ToString() + "g.png");
            gunaPictureBox_car3.Load(@"car\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + "g.png");
            gunaLabel13.Text = "Gri";
        }

        private void gunaCirclePictureBox3_Click_1(object sender, EventArgs e)
        {
            gunaPictureBox_car.Load(@"car\" + cpt.ToString() + "m.png");
            gunaPictureBox_car1.Load(@"car\" + cpt.ToString() + "m.png");
            gunaPictureBox_car2.Load(@"car\" + cpt.ToString() + cpt.ToString() + "m.png");
            gunaPictureBox_car3.Load(@"car\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + "m.png");
            gunaLabel13.Text = "Mavi";

        }

        private void gunaCirclePictureBox4_Click(object sender, EventArgs e)
        {
            gunaPictureBox_car.Load(@"car\" + cpt.ToString() + "k.png");
            gunaPictureBox_car1.Load(@"car\" + cpt.ToString() + "k.png");
            gunaPictureBox_car2.Load(@"car\" + cpt.ToString() + cpt.ToString() + "k.png");
            gunaPictureBox_car3.Load(@"car\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + "k.png");
            gunaLabel13.Text = "Kırmızı";
        }

        private void gunaCirclePictureBox5_Click_1(object sender, EventArgs e)
        {
            gunaPictureBox_car.Load(@"car\" + cpt.ToString() + "s.png");
            gunaPictureBox_car1.Load(@"car\" + cpt.ToString() + "s.png");
            gunaPictureBox_car2.Load(@"car\" + cpt.ToString() + cpt.ToString() + "s.png");
            gunaPictureBox_car3.Load(@"car\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + "s.png");
            gunaLabel13.Text = "Sarı";
        }

        private void gunaCirclePictureBox6_Click_1(object sender, EventArgs e)
        {
            gunaPictureBox_car.Load(@"car\" + cpt.ToString() + "s.png");
            gunaPictureBox_car1.Load(@"car\" + cpt.ToString() + "s.png");
            gunaPictureBox_car2.Load(@"car\" + cpt.ToString() + cpt.ToString() + "s.png");
            gunaPictureBox_car3.Load(@"car\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + "s.png");
            gunaLabel13.Text = "Bej";
        }

        private void gunaCirclePictureBox7_Click(object sender, EventArgs e)
        {
            gunaPictureBox_car.Load(@"car\" + cpt.ToString() + "s.png");
            gunaPictureBox_car1.Load(@"car\" + cpt.ToString() + "s.png");
            gunaPictureBox_car2.Load(@"car\" + cpt.ToString() + cpt.ToString() + "s.png");
            gunaPictureBox_car3.Load(@"car\" + cpt.ToString() + cpt.ToString() + cpt.ToString() + "s.png");
            gunaLabel13.Text = "Turuncu";
        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            gunaAdvenceButton7.Checked = true;
            gunaPanel1.BringToFront();
            gunaPanel1.Show();
            gunaAdvenceButton1.Checked = false;
            gunaAdvenceButton2.Checked = false;
            gunaAdvenceButton3.Checked = false;
            gunaAdvenceButton4.Checked = false;
            
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {

            gunaAdvenceButton2.Checked = true;
            gunaAdvenceButton1.Checked = false;
            gunaAdvenceButton3.Checked = false;
            gunaAdvenceButton4.Checked = false;
            gunaAdvenceButton7.Checked = false;
            AraçListele a = new AraçListele();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            gunaPanel4.Controls.Add(a);
            a.Show();
            a.BringToFront();
            
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            gunaAdvenceButton2.Checked = false;
            gunaAdvenceButton1.Checked = false;
            gunaAdvenceButton3.Checked = true;
            gunaAdvenceButton4.Checked = false;
            gunaAdvenceButton7.Checked = false;
            Sözleşme a = new Sözleşme();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            gunaPanel4.Controls.Add(a);
            a.Show();
            a.BringToFront();
            
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            gunaAdvenceButton2.Checked = false;
            gunaAdvenceButton1.Checked = false;
            gunaAdvenceButton3.Checked = false;
            gunaAdvenceButton4.Checked = true;
            gunaAdvenceButton7.Checked = false;
            Satışlar a = new Satışlar();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            gunaPanel4.Controls.Add(a);
            a.Show();
            a.BringToFront();
        }


        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
