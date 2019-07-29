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
using System.IO;


namespace GazethruApps
{


    public partial class formAwal : Form
    {

        List<double> wx;
        List<double> wy;
        int lap = 0;

        List<int> ShowID = new List<int>();
        int counter = 0;
        int maxCounter;
        int nowShowing;
        Object[] numb;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);
        KendaliTombol kendali;
        public formAwal()
        {
            InitializeComponent();

            PopulateViewID();

            kendali = new KendaliTombol();
            
            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);

            wx[0] = 1150; //lokasi awal 900; 830
            wy[0] = 900;

            kendali.TambahTombol(btnUser, new FungsiTombol(TombolUserTekan));

            kendali.Start();
        }

        private static formAwal Instance;
        public static formAwal getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new formAwal();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }

        public void PopulateViewID()
        {
            con.Open();
            string SelectQuery = "SELECT No FROM Slider WHERE Show = 1;";
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                numb = new object[read.FieldCount];
                ShowID.Add((int)read.GetValue(0));
            }
            con.Close();
            nowShowing = ShowID[0];
            maxCounter = ShowID.Count;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void formAwal_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnUser.Location = new Point((int)wx[0], (int)wy[0]);

            if (lap == 0) //titik awal
            {
                wx[0]++;         
            }

            if (lap == 1) //titik akhir, balik
            {
                wx[0]--;
            }

            if (wx[0] == 1450)
            {
                lap = 1; //titik akhir
            }

            if (wx[0] == 1150)
            {
                lap = 0;
            }

            kendali.CekTombol();
        }
        private void TombolUserTekan(ArgumenKendaliTombol eawal)
        {
            PresenceCheck.Visible = false;
            if (eawal.CekMata)
            {
                PresenceCheck.Visible = true;
            }

            if (eawal.mataX == null || eawal.mataY == null)
            {
                kendali.NoLook();
            }

            if (eawal.status)
            {
                formUser FormUser = formUser.getInstance();
                FormUser.Show();                                
                this.Hide();                
            }            
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            formUser FormUser = formUser.getInstance();
            FormUser.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin LoginAdmin = new AdminLogin();
            LoginAdmin.Show();
            this.Hide();
        }

        private void buttonAdmin2_Click(object sender, EventArgs e)
        {
            //AdminLogin LoginAdmin = new AdminLogin();
            //LoginAdmin.Show();
            AdminAwal test = new AdminAwal();
            test.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LoadNextImage(nowShowing);
        }

        public void LoadNextImage (int ViewShow)
        {
            con.Open();
            string SelectQuery = "SELECT * FROM Slider WHERE No=" + ViewShow;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                Byte[] img = (Byte[])(read["Gambar"]);
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            }
            else
            {
                pictureBox1.Image = null;
            }
            con.Close();
            if (counter == maxCounter-1)
            {
                counter = 0;
                nowShowing = ShowID[counter];
            }
            else
            {
                counter ++;
                nowShowing = ShowID[counter];
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }           
}

