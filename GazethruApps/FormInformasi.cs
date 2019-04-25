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
    public partial class formInformasi : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;

        public formInformasi()
        {
            InitializeComponent();
            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0); //add btnTentang
            wy.Add(0);
            wx.Add(0); //add btnKegiatan
            wy.Add(0);
            wx.Add(0); //add btnPrestasi
            wy.Add(0);
            wx.Add(0); //add btnBack
            wy.Add(0);
            wx.Add(0); //add btHome
            wy.Add(0);

            wx[0] = 100; //posisi awal btnTentang
            wy[0] = 215;
            wx[1] = 1130; //posisi awal btnKegiatan
            wy[1] = 215;
            wx[2] = 620; //posisi awal btnPrestasi
            wy[2] = 130;
            wx[3] = 100; //posisi awal btnBack
            wy[3] = 620;
            wx[4] = 1130; //posisi awal btnHome
            wy[4] = 620;
        }

        private void FormInformasi_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formUser FormUser = new formUser();
            FormUser.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            formHome FormHome = new formHome();
            FormHome.Show();
            this.Hide();
        }

        private void btnTentang_Click(object sender, EventArgs e)
        {
            formTentang FormTentang = new formTentang();
            FormTentang.Show();
            this.Hide();
        }

        private void btnPrestasi_Click(object sender, EventArgs e)
        {
            formPrestasi FormPrestasi = new formPrestasi();
            FormPrestasi.Show();
            this.Hide();
        }

        private void btnKegiatan_Click(object sender, EventArgs e)
        {
            formKegiatan FormKegiatan = new formKegiatan();
            FormKegiatan.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTentang.Location = new Point((int)wx[0], (int)wy[0]);
            btnKegiatan.Location = new Point((int)wx[1], (int)wy[1]);
            btnPrestasi.Location = new Point((int)wx[2], (int)wy[2]);
            btnBack.Location = new Point((int)wx[3], (int)wy[3]);
            btnHome.Location = new Point((int)wx[4], (int)wy[4]);

            if(lap==0)
            {
                wy[0]++;
                wy[1]--;
                wx[2]++;
                wx[3]++;
                wx[4]--;
            }
            if(lap==1)
            {
                wy[0]--;
                wy[1]++;
                wx[2]--;
                wx[3]--;
                wx[4]++;
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
    }
}
