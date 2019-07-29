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
    public partial class AdminSlideshow : UserControl
    {
        private static AdminSlideshow _instance;
        public static AdminSlideshow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminSlideshow();
                return _instance;
            }
        }

        public AdminSlideshow()
        {
            InitializeComponent();
        }

        public static int infoIDchoose;
        public static int PreviewID;
        public static int LastID;
        public static int FirstID;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        private void AdminSlideshow_Load(object sender, EventArgs e)
        {
            SlideList("");
            GetFirstID(con);
            GetLastID(con);

            PreviewID = FirstID;
            PreviewImage();
        }

        public void SlideList(string valueToSearch)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Slider WHERE CONCAT(No, Judul, Tanggal, Show) LIKE '%" + valueToSearch + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(command); //adapter perintah query sql

            DataTable table = new DataTable(); //bikin DataTable namanya table                  

            adapter.Fill(table); //perintah query sql disimpan di table

            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = table; //datagrid datasourcenya dari table

            CreateImageColumn();
            CreateButtonColumn();
            CreateDeleteButton();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SlideList(textBoxSearch.Text);
        }

        private void CreateImageColumn()
        {
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dataGridView1.Columns[3];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        //Add a edit button column. 
        private void CreateButtonColumn()
        {
            DataGridViewButtonColumn buttonCol = new DataGridViewButtonColumn();
            buttonCol.HeaderText = "";
            buttonCol.Name = "Edit";
            buttonCol.Text = "Edit";

            buttonCol.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(buttonCol);

        }

        //Add a delete button column. 
        private void CreateDeleteButton()
        {
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "";
            deleteBtn.Name = "Delete";
            deleteBtn.Text = "Delete";

            deleteBtn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(deleteBtn);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminSlideNew addSlider = new AdminSlideNew(this);
            addSlider.Show();
        }

        //Add checkbox hide show
        private void CreateShowCheckbox ()
        {
            DataGridViewCheckBoxColumn showCheck = new DataGridViewCheckBoxColumn();
            showCheck.HeaderText = "Show";
            showCheck.Name = "Show";


            dataGridView1.Columns.Add(showCheck);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SlideList("");
            PreviewID = 1; //belum handle if kosong
            PreviewImage();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //disable edit on datagridview
            this.dataGridView1.Rows[e.RowIndex].Cells["No"].ReadOnly = true;
            this.dataGridView1.Rows[e.RowIndex].Cells["Tanggal"].ReadOnly = true;
            this.dataGridView1.Rows[e.RowIndex].Cells["Judul"].ReadOnly = true;

            int selected = 0;
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
                infoIDchoose = selected;
                AdminSlideEdit editInfo = new AdminSlideEdit(this, infoIDchoose);
                editInfo.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {

                Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
                infoIDchoose = selected;
                SqlCommand command = new SqlCommand("DELETE FROM Slider WHERE No=" + infoIDchoose, con);

                if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecMyQuery(command, "Data Deleted");
                }

            }
            else
            {
                Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
                PreviewID = selected;
                PreviewImage();
            }
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
            SlideList("");

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int selected = 0;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Show")
            {
                Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
                infoIDchoose = selected;

                SqlCommand command = new SqlCommand("UPDATE Slider SET Show=@show WHERE No=" + infoIDchoose, con);
                Boolean check = (Boolean)(dataGridView1.Rows[e.RowIndex].Cells["Show"].Value);

                if (check == true)
                {
                    command.Parameters.Add("@show", SqlDbType.Bit).Value = check;
                    ExecMyQuery(command, "Data Show");
                }
                else if (check == false)
                {
                    command.Parameters.Add("@show", SqlDbType.Bit).Value = check;
                    ExecMyQuery(command, "Data Hide");
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            PreviewID = PreviewID - 1;
            btnNext.Enabled = true;
            if (PreviewID < 0)
            {
                btnPrev.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                PreviewImage();
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
                    LastID = reader.GetInt32(0);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            connection.Close();
        }

        public void GetFirstID(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
              "SELECT MIN(No) FROM Slider", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    FirstID = reader.GetInt32(0);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            connection.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrev.Enabled = true;
            PreviewID = PreviewID + 1;
            if (PreviewID > LastID)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                PreviewImage();
            }
        }

        void PreviewImage()
        {
            con.Open();
            string SelectQuery = "SELECT Gambar FROM Slider WHERE No=" + PreviewID;
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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int Read = (int)row.Cells["No"].Value;
                if (Read == PreviewID)
                {
                    row.Selected = true;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }
    }


}
