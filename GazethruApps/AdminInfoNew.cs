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
    public partial class AdminInfoNew : Form
    {
        //private readonly  AdminInformasi _InfoAwal;
        //private readonly AdminPrestasi _PrestasiAwal;
        //private readonly AdminKegiatan _KegiatanAwal;
        public string Category;
        public static int infoIDlast;

        public AdminInfoNew(string Kategori)
        {
            //_InfoAwal = InfoAwal;
            Category = Kategori;
            InitializeComponent();
            this.Text = "Konten Baru " + Category;
            ShowHide.Checked = true;
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        private void buttonBrowsePict_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG; *.PNG; *.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void AdminInfoNew_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
            pictureBox1.Image = bmp;
            GetLastID(con);
            NoInfo.Text = infoIDlast.ToString();
        }


        public void GetLastID(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
              "SELECT MAX(No) FROM " + Category, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    infoIDlast = reader.GetInt32(0) + 1;
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
            int last = infoIDlast - 1; 
            string InsertQuery =
                "DBCC CHECKIDENT (" + Category + ", RESEED," + last + "); " + //DBCC adalah menyalahi aturan increment dan unique, semoga tidak error
                "INSERT INTO "+ Category +"(Judul, Isi, Show, Gambar) VALUES (@judul , @isi, @show, @gambar);";
            SqlCommand command = new SqlCommand(InsertQuery, con);

            command.Parameters.Add("@judul", SqlDbType.VarChar).Value = textBoxJudul.Text;
            command.Parameters.Add("@isi", SqlDbType.VarChar).Value = textBoxIsi.Text;
            command.Parameters.Add("@show", SqlDbType.Bit).Value = ShowHide.Checked;

            if (pictureBox1.Image == null)
            {
                command.Parameters.Add("@gambar", SqlDbType.VarBinary).Value = DBNull.Value;
            }
            else
            {
                command.Parameters.Add("@gambar", SqlDbType.Image).Value = GetPic(pictureBox1.Image);
            }

            ExecMyQuery(command, "Data Inserted");
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
            //_InfoAwal.InfoContent("");
            if (Category == "Info")
            {
                AdminInformasi.Instance.InfoContent("");
            }
            else if (Category == "Prestasi")
            {
                AdminPrestasi.Instance.PrestasiContent("");
            }
            else
            {
                AdminKegiatan.Instance.KegiatanContent("");
            }
            this.Close();
        }
    }
}
