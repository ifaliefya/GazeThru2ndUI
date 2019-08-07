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

        KendaliTombol kendali;

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
            wx.Add(0); //add btHome
            wy.Add(0);

            wx[0] = 1520; //posisi awal btnTentang
            wy[0] = 650;
            wx[1] = 200; //posisi awal btnKegiatan
            wy[1] = 350;
            wx[2] = 700; //posisi awal btnPrestasi 700; 300
            wy[2] = 170;
            wx[3] = 1086; //posisi awal btnhome 1086; 773
            wy[3] = 773;

            kendali = new KendaliTombol();
            kendali.TambahTombol(btnHome, new FungsiTombol(HomeTekan));
            kendali.TambahTombol(btnKegiatan, new FungsiTombol(KgtnTekan));
            kendali.TambahTombol(btnPrestasi, new FungsiTombol(PrestasiTekan));
            kendali.TambahTombol(btnTentang, new FungsiTombol(TentangTekan));

            kendali.Start();
        }

        private static formInformasi Instance;
        public static formInformasi getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new formInformasi();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTentang.Location = new Point((int)wx[0], (int)wy[0]);
            btnKegiatan.Location = new Point((int)wx[1], (int)wy[1]);
            btnPrestasi.Location = new Point((int)wx[2], (int)wy[2]);
            btnHome.Location = new Point((int)wx[3], (int)wy[3]);

            progressBarTentang.Location = new Point((int)wx[0], (int)wy[0]);
            progressBarKegiatan.Location = new Point((int)wx[1], (int)wy[1]);
            progressBarPrestasi.Location = new Point((int)wx[2], (int)wy[2]);
            progressBarHome.Location = new Point((int)wx[3], (int)wy[3]);

            if (lap == 0)
            {
                wy[0]--;
                wy[1]++;
                wx[2]++;
                wx[3]--;
            }
            if (lap == 1)
            {
                wy[0]++;
                wy[1]--;
                wx[2]--;
                wx[3]++;
            }

            if (wx[3] == 786)
            {
                lap = 1;
            }
            if (wx[3] == 1086)
            {
                lap = 0;
            }

            kendali.CekTombol();
        }
        private void HomeTekan(ArgumenKendaliTombol e)
        {
            PresenceCheck.Visible = false;
            if (e.CekMata)
            {
                PresenceCheck.Visible = true;
            }

            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if(e.status)
            {
                formUser FormUser = formUser.getInstance();
                FormUser.Show();                
                kendali.Close();
                timer1.Stop();
                this.Close();
            }

            progressBarHome.Value = e.DataKor;
        }

        private void KgtnTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                formKegiatan FormKegiatan = formKegiatan.getInstance();
                FormKegiatan.Show();                
                kendali.Close();
                timer1.Stop();
                this.Close();
            }

            progressBarKegiatan.Value = e.DataKor;
        }

        private void PrestasiTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                formPrestasi FormPrestasi = formPrestasi.getInstance();
                FormPrestasi.Show();                
                kendali.Close();
                timer1.Stop();
                this.Close();
            }

            progressBarPrestasi.Value = e.DataKor;
        }

        private void TentangTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                formTentang FormTentang = formTentang.getInstance();
                FormTentang.Show();                
                kendali.Close();
                timer1.Stop();
                this.Close();
            }

            progressBarTentang.Value = e.DataKor;
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
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            formUser FormUser = new formUser(); 
            FormUser.Show();
            this.Hide();           
        }

        private void btnTentang_Click(object sender, EventArgs e)
        {
            formTentang FormTentang = new formTentang();
            FormTentang.Show();
            this.Close();
        }

        private void btnPrestasi_Click(object sender, EventArgs e)
        {
            formPrestasi FormPrestasi = new formPrestasi();
            FormPrestasi.Show();
            this.Close();
        }

        private void btnKegiatan_Click(object sender, EventArgs e)
        {
            formKegiatan FormKegiatan = new formKegiatan();
            FormKegiatan.Show();
            this.Close();
        } 
    }
}
