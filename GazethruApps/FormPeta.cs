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
    public partial class formPeta : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;

        public formPeta()
        {
            InitializeComponent();
            wx = new List<double>();
            wy = new List<double>();
            //add node

            //add nilai awal
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            formHome FormHome = new formHome();
            FormHome.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formInformasi FormInformasi = new formInformasi();
            FormInformasi.Show();
            this.Hide();
        }

        private void formPeta_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnDua.Location = new Point((int)wx[0], (int)wy[0]);
            btnTiga.Location = new Point((int)wx[1], (int)wy[1]);
            btnBack.Location = new Point((int)wx[2], (int)wy[2]);
            btnHome.Location = new Point((int)wx[3], (int)wy[3]);
        }
    }
}
