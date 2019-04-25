using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazethruApps
{
    public partial class formUser : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;

        public formUser()
        {
            InitializeComponent();
            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);

            wx[0] = 100; //lokasi awal btnInformasi
            wy[0] = 215;
            wx[1] = 1130; //lokasi awal btnPeta
            wy[1] = 215;
            wx[2] = 528; //lokasi awal btnBack
            wy[2] = 580;


        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnInfo.Location = new Point((int)wx[0], (int)wy[0]);
            btnPeta.Location = new Point((int)wx[1], (int)wy[1]);
            btnBack.Location = new Point((int)wx[2], (int)wy[2]);

            if (lap == 0)
            {
                wy[0]++;
                wy[1]--;
                wx[2]++;
            }
            if (lap == 1)
            {
                wy[0]--;
                wy[1]++;
                wx[2]--;
            }
            if (wy[0] == 260)
            {
                lap = 1;
            }
            if (wy[0] == 180)
            {
                lap = 0;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formHome FormHome = new formHome();
            FormHome.Show();
            this.Hide();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            formInformasi FormInformasi = new formInformasi();
            FormInformasi.Show();
            this.Hide();
        }

        private void btnPeta_Click(object sender, EventArgs e)
        {
            formPeta FormPeta = new formPeta();
            FormPeta.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            formHome FormHome = new formHome();
            FormHome.Show();
            this.Hide();
        }
    }
}
