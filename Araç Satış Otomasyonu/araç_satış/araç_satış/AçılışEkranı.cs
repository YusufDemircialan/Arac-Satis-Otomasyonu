using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace araç_satış
{
    public partial class AçılışEkranı : Form
    {
        public AçılışEkranı()
        {
            InitializeComponent();
        }

        private void AçılışEkranı_Load(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + @"\ses.wav";
            ses.SoundLocation = dizin;
            ses.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + @"\ses.wav";
            ses.SoundLocation = dizin;

            panel1.Width += 2;
            if (panel1.Width >= 390)
            {
                timer1.Stop();
                LoginEkranı a = new LoginEkranı();
                a.Show();
                this.Hide();
                ses.Stop();
            }
        }
    }
}
