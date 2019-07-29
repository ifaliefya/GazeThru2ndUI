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
    public partial class formPrestasi : Form
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

        public formPrestasi()
        {
            InitializeComponent();

            PopulateViewID();
            PopulateButton();
            LoadContent(nowShowing);

            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0); //prev
            wy.Add(0);
            wx.Add(0); //next
            wy.Add(0);
            wx.Add(0); //back
            wy.Add(0);
            wx.Add(0); //home
            wy.Add(0);

            wx[0] = 230;//posisi awal btnPrev 
            wy[0] = 170;
            wx[1] = 1620; //posisi awal btnNext
            wy[1] = 400;
            wx[2] = 300; //posisi awal btnBack 
            wy[2] = 900;
            wx[3] = 1620; //posisi awal btnHome
            wy[3] = 900;

            kendali = new KendaliTombol();
            kendali.TambahTombol(btnBack, new FungsiTombol(BackTekan));
            kendali.TambahTombol(btnHome, new FungsiTombol(HomeTekan));
            kendali.TambahTombol(btnNext, new FungsiTombol(NextTekan));
            kendali.TambahTombol(btnPrev, new FungsiTombol(PrevTekan));

            kendali.Start();
        }

        private static formPrestasi Instance;
        public static formPrestasi getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new formPrestasi();
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
            string SelectQuery = "SELECT No FROM Prestasi WHERE Show = 1;";
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

        public void PopulateButton()
        {
            if (maxCounter == 1)
            {
                btnPrev.Visible = false;
                btnNext.Visible = false;
            }
            else if (counter == 0)
            {
                btnPrev.Visible = false;
                btnNext.Visible = true;
            }
            else if (counter == maxCounter - 1)
            {
                btnNext.Visible = false;
                btnPrev.Visible = true;
            }
            else
            {
                btnNext.Visible = true;
                btnPrev.Visible = true;
            }
        }

        public void LoadContent(int ViewShow)
        {
            con.Open();
            string SelectQuery = "SELECT * FROM Prestasi WHERE No = " + ViewShow;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                lblJudul.Text = read["Judul"].ToString();
                textBoxIsi.Text = read["Isi"].ToString();

                if (!Convert.IsDBNull(read["Gambar"]))
                {
                    Byte[] img = (Byte[])(read["Gambar"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBox1.Image = null; //gambar default
                }

            }
            else
            {
                lblJudul.Text = "";
                textBoxIsi.Text = "";
                pictureBox1.Image = null;
            }
            con.Close();

        }

        private void formPrestasi_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }
           
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnPrev.Location = new Point((int)wx[0], (int)wy[0]);
            btnNext.Location = new Point((int)wx[1], (int)wy[1]);
            btnBack.Location = new Point((int)wx[2], (int)wy[2]);
            btnHome.Location = new Point((int)wx[3], (int)wy[3]);

            if(lap==0)
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
            if(wy[0]==470)
            {
                lap = 1;
            }
            if(wy[0]==170)
            {
                lap = 0;
            }
            kendali.CekTombol();
        }
        private void BackTekan(ArgumenKendaliTombol e)
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

            if (e.status)
            {
                formInformasi FormInformasi = formInformasi.getInstance();
                FormInformasi.Show();
                timer1.Stop();
                kendali.Close();
                this.Close();
            }
        }
        private void HomeTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                formUser Home = formUser.getInstance();
                Home.Show();
                timer1.Stop();
                kendali.Close();
                this.Close();
            }
        }
        private void NextTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                ++counter;
                nowShowing = ShowID[counter];
                PopulateButton();
                LoadContent(nowShowing);
            }
        }
        private void PrevTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                --counter;
                nowShowing = ShowID[counter];
                PopulateButton();
                LoadContent(nowShowing);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formInformasi FormInformasi = new formInformasi();
            FormInformasi.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            formUser Home = new formUser();
            Home.Show();
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ++counter;
            nowShowing = ShowID[counter];
            PopulateButton();
            LoadContent(nowShowing);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            --counter;
            nowShowing = ShowID[counter];
            PopulateButton();
            LoadContent(nowShowing);
        }
    }
}
