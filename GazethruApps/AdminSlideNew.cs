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
    public partial class AdminSlideNew : Form
    {
        private readonly AdminSlideshow _SlideAwal;

        public AdminSlideNew(AdminSlideshow SlideAwal)
        {
            _SlideAwal = SlideAwal;
            InitializeComponent();
            TanggalNOW.Text = DateTime.Now.ToShortDateString();
            ShowHide.Checked = true;
        }

        public static int infoIDlast;
        
        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        private void AdminSlideNew_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
            pictureBox1.Image = bmp;
            GetLastID(con);
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

        public void GetLastID(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
              "SELECT MAX(No) FROM Slider", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    infoIDlast = reader.GetInt32(0);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            connection.Close();
        }

        private byte[] GetPic(Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Masukkan gambar terlebih dahulu");
            }

            else
            {
                try
                {
                    //SqlCommand command = new SqlCommand("INSERT INTO Slider(Tanggal, Judul, Show, Gambar) VALUES (@tanggal, @judul , @show, @gambar)", con);
                    string InsertQuery =
                    "DBCC CHECKIDENT (Slider, RESEED," + infoIDlast + "); " + //DBCC adalah menyalahi aturan increment dan unique, semoga tidak error
                    "INSERT INTO Slider(Tanggal, Judul, Show, Gambar) VALUES (@tanggal, @judul, @show, @gambar);";
                    SqlCommand command = new SqlCommand(InsertQuery, con);

                    command.Parameters.Add("@tanggal", SqlDbType.Date).Value = Convert.ToDateTime(TanggalNOW.Text);
                    command.Parameters.Add("@judul", SqlDbType.VarChar).Value = textBoxJudul.Text;
                    command.Parameters.Add("@show", SqlDbType.Bit).Value = ShowHide.Checked;
                    command.Parameters.Add("@gambar", SqlDbType.Image).Value = GetPic(pictureBox1.Image);
                    ExecMyQuery(command, "Data Inserted");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //if (pictureBox1.Image == null)
            //{
            //    MessageBox.Show("Masukkan gambar terlebih dahulu");
            //    AdminInfoNew.location.reload();
            //    this.Show();
            //}
            //else
            //{
            //    command.Parameters.Add("@gambar", SqlDbType.Image).Value = GetPic(pictureBox1.Image);
            //    ExecMyQuery(command, "Data Inserted");
            //}
        }

        public void ExecMyQuery(SqlCommand mcomd, string myMsg)
        {
            con.Open();
            if (mcomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query Not Executed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
            _SlideAwal.SlideList("");
            this.Close();
        }


    }
}
