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

        KendaliTombol kendaliuser;
        
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

            wx[0] = 300; //lokasi awal btnInformasi
            wy[0] = 200;
            wx[1] = 1620; //lokasi awal btnPeta
            wy[1] = 430;
            wx[2] = 770; //lokasi awal btnBack
            wy[2] = 900;

            kendaliuser = new KendaliTombol();
            kendaliuser.TambahTombol(btnInfo, new FungsiTombol(InfoTekan));
            kendaliuser.TambahTombol(btnPeta, new FungsiTombol(PetaTekan));
            kendaliuser.TambahTombol(btnBack, new FungsiTombol(BackTekan));

            kendaliuser.Start();
        }

        private static formUser Instance;
        public static formUser getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new formUser();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
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
            if (wy[0] == 500)
            {
                lap = 1;
            }
            if (wy[0] == 200)
            {
                lap = 0;
            }

            kendaliuser.CekTombol();
        }

       private void btnBack_Click(object sender, EventArgs e)
        {
            formAwal FormHome = formAwal.getInstance();
            FormHome.Show();
            this.Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            formInformasi FormInformasi = new formInformasi();
            FormInformasi.Show();
            this.Close();
        }

        private void btnPeta_Click(object sender, EventArgs e)
        {
            formPeta FormPeta = new formPeta();
            FormPeta.Show();
            this.Close();
        }

        private void InfoTekan(ArgumenKendaliTombol e)
        {
            PresenceCheck.Visible = false;
            if (e.CekMata)
            {
                PresenceCheck.Visible = true;
            }

            //Console.WriteLine(e.korelasiX + "  " + e.korelasiY + "  " + e.mataX + "  " + e.mataY);
            if (e.mataX == null || e.mataY == null)
            {
                kendaliuser.NoLook();
            }

            if (e.status)
            {
                formInformasi FormInformasi = formInformasi.getInstance();
                FormInformasi.Show();
                kendaliuser.Close();
                timer1.Stop();
                this.Close();
            }
        }
        private void PetaTekan(ArgumenKendaliTombol e)
        {
            //Console.WriteLine(e.korelasiX + "  " + e.korelasiY + "  " + e.mataX + "  " + e.mataY);
            if (e.mataX == null || e.mataY == null)
            {
                kendaliuser.NoLook();
            }

            if (e.status)
            {
                formPeta FormPeta = formPeta.getInstance();
                FormPeta.Show();                
                kendaliuser.Close();
                timer1.Stop();
                this.Close();
            }
        }
        private void BackTekan(ArgumenKendaliTombol e)
        {
            //Console.WriteLine(e.korelasiX + "  " + e.korelasiY + "  " + e.mataX + "  " + e.mataY);
            if (e.mataX == null || e.mataY == null)
            {
                kendaliuser.NoLook();
            }

            if (e.status)
            {
                formAwal FormHome = formAwal.getInstance();
                FormHome.Show();                
                kendaliuser.Close();
                timer1.Stop();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
