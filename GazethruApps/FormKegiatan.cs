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
    public partial class formKegiatan : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;

        public formKegiatan()
        {
            InitializeComponent();
            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0); //add btnPrev
            wy.Add(0);
            wx.Add(0); //add btnNext
            wy.Add(0);
            wx.Add(0); //add btnBack
            wy.Add(0);
            wx.Add(0); //add btnHome
            wy.Add(0);

            wx[0] = 70;//posisi awal btnPrev
            wy[0] = 300;
            wx[1] = 1150; //posisi awal btnNext
            wy[1] = 300;
            wx[2] = 100; //posisi awal btnBack
            wy[2] = 620;
            wx[3] = 1130; //posisi awal btnHome
            wy[3] = 620;
        }

        private void formKegiatan_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formInformasi formInformasi = new formInformasi();
            formInformasi.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnPrev.Location = new Point((int)wx[0], (int)wy[0]);
            btnNext.Location = new Point((int)wx[1], (int)wy[1]);
            btnBack.Location = new Point((int)wx[2], (int)wy[2]);
            btnHome.Location = new Point((int)wx[3], (int)wy[3]);

            if (lap==0)
            {
                wy[0]++;
                wy[1]--;
                wx[2]++;
                wx[3]--;
            }
            if(lap==1)
            {
                wy[0]--;
                wy[1]++;
                wx[2]--;
                wx[3]++;
            }
            if(wy[0]==340)
            {
                lap = 1;
            }
            if(wy[0]==260)
            {
                lap = 0;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            formHome FormHome = new formHome();
            FormHome.Show();
            this.Hide();
        }
    }
}
