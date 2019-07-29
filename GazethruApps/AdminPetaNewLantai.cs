using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GazethruApps
{
    public partial class AdminPetaNewLantai : UserControl
    {
        private static AdminPetaNewLantai _instance;
        public static AdminPetaNewLantai Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminPetaNewLantai();
                return _instance;
            }
        }

        int LastID;
        int LantaiChoosen;


        public AdminPetaNewLantai()
        {
            InitializeComponent();
        }


        private void AdminPetaNewLantai_Load(object sender, EventArgs e)
        {
            //GetLastID(con);
            //NoInfo.Text = LastID.ToString();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        public void LoadLantai(int PetaID)
        {
            LantaiChoosen = PetaID;
            if (PetaID !=0)
            {
                con.Open();
                string SelectQuery = "SELECT * FROM Peta WHERE No=" + PetaID;
                SqlCommand command = new SqlCommand(SelectQuery, con);
                SqlDataReader read = command.ExecuteReader();
                if (read.Read())
                {
                    NoInfo.Text = (read["No"].ToString());
                    textBoxJudul.Text = (read["Judul"].ToString());

                    Byte[] img = (Byte[])(read["Gambar"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                else
                {
                    textBoxJudul.Text = "";
                    pictureBox1.Image = null;
                }
                con.Close();
            }
            else
            {
                Bitmap bmp = new Bitmap(Properties.Resources.defaultPicRuang);
                pictureBox1.Image = bmp;
                GetLastID(con);
                NoInfo.Text = LastID.ToString();
            }
        }

        public void GetLastID(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
              "SELECT MAX(No) FROM Peta", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LastID = reader.GetInt32(0) + 1;
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

        private void buttonBrowsePict_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG; *.PNG; *.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnInsertnEdit_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Masukkan gambar terlebih dahulu");
            }
            else
            {
                //try catch disini
                    if (LantaiChoosen == 0)
                    {
                        int newID = LastID - 1;
                        string InsertQuery =
                        "DBCC CHECKIDENT (Peta, RESEED," + newID + "); " + //DBCC adalah menyalahi aturan increment dan unique, semoga tidak error
                        "INSERT INTO Peta(Judul, Gambar) VALUES (@judul, @gambar);";
                        SqlCommand command = new SqlCommand(InsertQuery, con);

                        command.Parameters.Add("@judul", SqlDbType.VarChar).Value = textBoxJudul.Text;
                        command.Parameters.Add("@gambar", SqlDbType.Image).Value = GetPic(pictureBox1.Image);
                        ExecMyQuery(command, "Peta Lantai Ditambahkan");
                        //ke user control adminPetaRuang
                    }
                    else
                    {
                        string UpdateQuery =
                        "UPDATE Peta SET Judul=@judul, Gambar=@gambar WHERE No=" + LantaiChoosen;
                        SqlCommand command = new SqlCommand(UpdateQuery, con);

                        command.Parameters.Add("@judul", SqlDbType.VarChar).Value = textBoxJudul.Text;
                        command.Parameters.Add("@gambar", SqlDbType.Image).Value = GetPic(pictureBox1.Image);
                        ExecMyQuery(command, "Peta Lantai Diupdate");
                    }
            }
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
            AdminPetaAwal.Instance.PetaList();

            if (!AdminPetaNew.Instance.PnlEdit.Controls.ContainsKey("AdminPetaNewRuang"))
            {
                AdminPetaNewRuang newRuang = new AdminPetaNewRuang();
                newRuang.Dock = DockStyle.Fill;
                AdminPetaNew.Instance.PnlEdit.Controls.Add(newRuang);
                if (LantaiChoosen == 0)
                {
                    newRuang.GetLantaiPic(LastID);
                    newRuang.ListPoint(LastID);
                }
                else
                {
                    newRuang.GetLantaiPic(LantaiChoosen);
                    newRuang.LoadPointer(LantaiChoosen);
                    newRuang.ListPoint(LantaiChoosen);
                }

            }
            AdminPetaNew.Instance.PnlEdit.Controls["AdminPetaNewRuang"].BringToFront();
        }


    }
}
