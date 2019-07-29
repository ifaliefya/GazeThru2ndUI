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

namespace GazethruApps
{
    public partial class AdminKegiatan : UserControl
    {
        private static AdminKegiatan _instance;
        public static AdminKegiatan Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminKegiatan();
                return _instance;
            }
        }

        public AdminKegiatan()
        {
            InitializeComponent();
        }

        public static int infoIDchoose;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        private void AdminKegiatan_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            KegiatanContent("");
        }

        public void KegiatanContent(string valueToSearch)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Kegiatan WHERE CONCAT(No, Judul, Isi) LIKE '%" + valueToSearch + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(command); //adapter perintah query sql

            DataTable table = new DataTable(); //bikin DataTable namanya table                  

            adapter.Fill(table); //perintah query sql disimpan di table

            dataGridView1.RowTemplate.Height = 60;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = table; //datagrid datasourcenya dari table

            CreateImageColumn();
            CreateButtonColumn();
            CreateDeleteButton();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CreateImageColumn()
        {
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dataGridView1.Columns[3];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void CreateButtonColumn()
        {
            DataGridViewButtonColumn buttonCol = new DataGridViewButtonColumn();
            buttonCol.HeaderText = "";
            buttonCol.Name = "Edit";
            buttonCol.Text = "Edit";
            
            buttonCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonCol);
        }

        private void CreateDeleteButton()
        {
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "";
            deleteBtn.Name = "Delete";
            deleteBtn.Text = "Delete";

            deleteBtn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteBtn);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            KegiatanContent(textBoxSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminInfoNew addInfo = new AdminInfoNew("Kegiatan");
            addInfo.Show();
        }

        protected void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["No"].ReadOnly = true;
            this.dataGridView1.Rows[e.RowIndex].Cells["Judul"].ReadOnly = true;
            this.dataGridView1.Rows[e.RowIndex].Cells["Isi"].ReadOnly = true;

            int selected = 0;
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
                infoIDchoose = selected;

               AdminInfoEdit editInfo = new AdminInfoEdit(infoIDchoose, "Kegiatan");
               editInfo.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {

                Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
                infoIDchoose = selected;
                SqlCommand command = new SqlCommand("DELETE FROM Kegiatan WHERE No=" + infoIDchoose, con);

                if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecMyQuery(command, "Data Deleted");
                }

            }
            else
            {
                textBoxJudul.Text = dataGridView1.Rows[e.RowIndex].Cells["Judul"].Value.ToString();
                textBoxIsi.Text = dataGridView1.Rows[e.RowIndex].Cells["Isi"].Value.ToString();
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
            KegiatanContent("");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            KegiatanContent("");
        }

        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
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

                SqlCommand command = new SqlCommand("UPDATE Kegiatan SET Show=@show WHERE No=" + infoIDchoose, con);
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
    }
}
