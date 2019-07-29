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
    public partial class formLantai1 : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;
        KendaliTombol kendali;
        public struct PExist
        {
            public int LocX;
            public int LocY;
            public string Name;

            public PExist(int x, int y, string name)
            {
                LocX = x;
                LocY = y;
                Name = name;
            }
        }


        List<PExist> AllPointer = new List<PExist>();
        int counter = 0;
        int maxCounter;
        public int NoLantai;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        public formLantai1()
        {
            InitializeComponent();
            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0); //next
            wy.Add(0);
            wx.Add(0); //prev
            wy.Add(0);
            wx.Add(0); //kembali
            wy.Add(0);

            wx[0] = 1620; //next
            wy[0] = 370;
            wx[1] = 255; //prev
            wy[1] = 140;
            wx[2] = 1100; //back
            wy[2] = 900;

            kendali = new KendaliTombol();
            kendali.TambahTombol(btnBack, new FungsiTombol(TombolBackTekan));
            kendali.TambahTombol(btnNext2, new FungsiTombol(TombolNextTekan));
            kendali.TambahTombol(btnPrev, new FungsiTombol(TombolPrevTekan));
            kendali.Start();
        }

        private static formLantai1 Instance;
        public static formLantai1 getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new formLantai1();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }

        private void FormLantai1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnNext2.Location = new Point((int)wx[0], (int)wy[0]);
            btnPrev.Location = new Point((int)wx[1], (int)wy[1]);
            btnBack.Location = new Point((int)wx[2], (int)wy[2]);

            if (lap==0)
            {
                wy[0]--;
                wy[1]++;
                wx[2]--;
            }
            if (lap == 1)
            {
                wy[0]++;
                wy[1]--;
                wx[2]++;
            }
            if(wy[0]==140)
            {
                lap = 1;
            }
            if(wy[0]==440)
            {
                lap = 0;
            }

            kendali.CekTombol();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formPeta FormPeta = new formPeta();
            FormPeta.Show();
            this.Close();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            --counter;
            PreviewDetail(AllPointer[counter].Name);
            PopulateButton();
        }


        private void btnNext2_Click(object sender, EventArgs e)
        {
            ++counter;
            PreviewDetail(AllPointer[counter].Name);
            PopulateButton();
        }

        private void TombolBackTekan(ArgumenKendaliTombol e)
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
                formPeta FormPeta = formPeta.getInstance();
                FormPeta.Show();
                timer1.Stop();
                kendali.Close();
                this.Close();
            }
        }

        private void TombolNextTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                ++counter;
                PreviewDetail(AllPointer[counter].Name);
                PopulateButton();
            }
        }

        void TombolPrevTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                --counter;
                PreviewDetail(AllPointer[counter].Name);
                PopulateButton();
            }
        }

        public void PopulateButton()
        {
            if (maxCounter == 1)
            {
                btnPrev.Visible = false;
                btnNext2.Visible = false;
            }
            else if (counter == 0)
            {
                btnPrev.Visible = false;
                btnNext2.Visible = true;
            }
            else if (counter == maxCounter - 1)
            {
                btnNext2.Visible = false;
                btnPrev.Visible = true;
            }
            else
            {
                btnNext2.Visible = true;
                btnPrev.Visible = true;
            }
        }


        public void GetLantaiPic(int IDLantai)
        {
            NoLantai = IDLantai;

            con.Open();
            string SelectQuery = "SELECT * FROM Peta WHERE No=" + NoLantai;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                labelNamaLantai.Text = (read["Judul"].ToString());
                if (!Convert.IsDBNull(read["Gambar"]))
                {
                    Byte[] img = (Byte[])(read["Gambar"]);
                    MemoryStream ms = new MemoryStream(img);
                    pbPetaLantai.Image = Image.FromStream(ms);
                }
            }
            else
            {
                labelNamaLantai.Text = "";
                pbPetaLantai.Image = null;
            }
            con.Close();
        }

        public void LoadPointer(int IDLantai)
        {
            con.Open();
            string SelectQuery = "SELECT LocX, LocY, Pointer FROM Ruang WHERE PetaID = " + IDLantai;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    var locx = read.GetInt32(0);
                    var locy = read.GetInt32(1);
                    var name = read.GetString(2);
                    var Pini = new PExist(locx, locy, name);
                    AllPointer.Add(Pini);

                    Pointer P = ReadPointer(locx, locy, name);
                    pbPetaLantai.Controls.Add(P);
                }
                maxCounter = AllPointer.Count;
            }
            else
            {
                MessageBox.Show("Tambahkan Pointer");
            }

            con.Close();

            PreviewDetail(AllPointer[0].Name);
            PopulateButton();
        }

        Pointer ReadPointer(int x, int y, string name)
        {
            Pointer Pointer = new Pointer();
            Pointer.Name = name;
            Pointer.Size = new Size(22, 30);
            Pointer.Location = new System.Drawing.Point(x, y);
            Pointer.BackColor = Color.Transparent;
            Pointer.Image = new Bitmap(Properties.Resources.biru);
            return Pointer;
        }

        void PointerChoosen(string Pname)
        {
            foreach (Pointer item in pbPetaLantai.Controls)
                if (item.Name == Pname)
                {
                    item.Size = new Size(52, 52);
                    Bitmap bmp = new Bitmap(Properties.Resources.kuning52px);
                    item.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(Properties.Resources.biru);
                    item.Image = bmp;
                }
        }

        void PreviewDetail(string Pname)
        {
            PointerChoosen(Pname);

            con.Open();
            string SelectQuery = "SELECT Id, LocX, LocY, Judul, Isi, Gambar FROM Ruang WHERE PetaID=" + NoLantai + "AND Pointer ='" + Pname + "'";
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                labelJudul.Text = (String)(read["Judul"]);
                textBoxIsi.Text = (String)(read["Isi"]);

                if (!Convert.IsDBNull(read["Gambar"]))
                {
                    Byte[] img = (Byte[])(read["Gambar"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBoxRuang.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBoxRuang.Image = null;
                }
            }
            else
            {
                labelJudul.Text = "";
                textBoxIsi.Text = "";
                pictureBoxRuang.Image = null;
            }
            con.Close();
        }
    }
}
