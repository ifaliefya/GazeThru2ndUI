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
    public partial class AdminInfoEdit : Form
    {
        //private readonly AdminInformasi _InfoAwal;
        //private readonly AdminKegiatan _KegAwal;
        //private readonly AdminPrestasi _PresAwal;

        public int ChoosenID;
        public string Category;

        public AdminInfoEdit(int Choosen, string Kategori)
        {
            //_InfoAwal = InfoAwal;
            //_KegAwal = KegAwal;
            //_PresAwal = PresAwal;
            ChoosenID = Choosen;
            Category = Kategori;
            InitializeComponent();
            this.Text = "Edit Konten " + Category + " Nomor " + ChoosenID;
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        private void AdminInfoEdit_Load(object sender, EventArgs e)
        {
            EditInfoContent();
        }

        public void EditInfoContent()
        {
            
            con.Open();
            string SelectQuery = "SELECT * FROM " + Category + " WHERE No=" + ChoosenID;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                NoInfo.Text = (read["No"].ToString());
                textBoxJudul.Text = (read["Judul"].ToString());
                textBoxIsi.Text = (read["Isi"].ToString());
                ShowHide.Checked = (Boolean)(read["Show"]);
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
                textBoxIsi.Text = "";
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

            SqlCommand command = new SqlCommand("UPDATE " + Category + " SET Judul=@judul, Isi=@isi, Gambar=@gambar, Show=@show WHERE No=" + ChoosenID, con);

            command.Parameters.Add("@judul", SqlDbType.VarChar).Value = textBoxJudul.Text;
            command.Parameters.Add("@isi", SqlDbType.VarChar).Value = textBoxIsi.Text;
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
