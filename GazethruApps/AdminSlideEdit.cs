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
    public partial class AdminSlideEdit : Form
    {
        private readonly AdminSlideshow _SlideAwal;
        public int ChoosenID;

        public AdminSlideEdit(AdminSlideshow SlideAwal, int Choosen)
        {
            _SlideAwal = SlideAwal;
            ChoosenID = Choosen;
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        private void AdminSlideEdit_Load(object sender, EventArgs e)
        {
            EditSliderContent();
        }

        public void EditSliderContent()
        {
            con.Open();
            string SelectQuery = "SELECT * FROM Slider WHERE No=" + ChoosenID;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                DateTime tanggal = read.GetDateTime(1);
                TanggalNOW.Text = tanggal.ToShortDateString();

                textBoxJudul.Text = (read["Judul"].ToString());
                ShowHide.Checked = Convert.ToBoolean(read["Show"].ToString());
                if (!Convert.IsDBNull(read["Gambar"]))
                {
                    Byte[] img = (Byte[])(read["Gambar"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                textBoxJudul.Text = "";
                pictureBox1.Image = null;
            }

            con.Close();
        }

        private void buttonBrowsePict_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG; *.PNG; *.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            SqlCommand command = new SqlCommand("UPDATE Slider SET Judul=@judul, Gambar=@gambar, Show=@show WHERE No=" + ChoosenID, con);

            command.Parameters.Add("@judul", SqlDbType.VarChar).Value = textBoxJudul.Text;
            command.Parameters.Add("@show", SqlDbType.Bit).Value = ShowHide.Checked;
            command.Parameters.Add("@gambar", SqlDbType.Image).Value = img;

            ExecMyQuery(command, "Data Updated");
        }

        public void ExecMyQuery(SqlCommand mcomd, string myMsg)
        {
            con.Open();
            if (mcomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);
            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }

            con.Close();
            _SlideAwal.SlideList("");
            this.Close();
        }
    }
}
