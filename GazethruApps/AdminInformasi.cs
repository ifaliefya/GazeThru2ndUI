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
    public partial class AdminInformasi : UserControl
    {
        private static AdminInformasi _instance;
        public static AdminInformasi Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminInformasi();
                return _instance;
            }
        }

        public AdminInformasi()
        {
            InitializeComponent();
        }

        public static int infoIDchoose;
        public string Category = AdminAwal.Category;
        //public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aliefya\source\repos\GazeThru00\GazethruApps\GazeThruDB.mdf;Integrated Security=True;Connect Timeout=30";
        //SqlConnection con = new SqlConnection(connectionString);

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);
        private void AdminInformasi_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            InfoContent("");
        }

        public void InfoContent(string valueToSearch)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Info WHERE CONCAT(No, Judul, Isi) LIKE '%" + valueToSearch + "%'", con);
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

        //Add a button column. 
        private void CreateButtonColumn()
        {
            DataGridViewButtonColumn buttonCol = new DataGridViewButtonColumn();
            buttonCol.HeaderText = "";
            buttonCol.Name = "Edit";
            buttonCol.Text = "Edit";

            // Use the Text property for the button text for all cells rather
            // than using each cell's value as the text for its own button.
            buttonCol.UseColumnTextForButtonValue = true;

            // Add the button column to the control.
            //dataGridView1.Columns.Insert(4, buttonCol);
            dataGridView1.Columns.Add(buttonCol);

        }

        //Add a delete button column. 
        private void CreateDeleteButton()
        {
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "";
            deleteBtn.Name = "Delete";
            deleteBtn.Text = "Delete";

            // Use the Text property for the button text for all cells rather
            // than using each cell's value as the text for its own button.
            deleteBtn.UseColumnTextForButtonValue = true;

            // Add the button column to the control.
            //dataGridView1.Columns.Insert(4, buttonCol);
            dataGridView1.Columns.Add(deleteBtn);

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            InfoContent(textBoxSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminInfoNew addInfo = new AdminInfoNew("Info");
            addInfo.Show();
        }

        protected void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //disable edit on datagridview
            this.dataGridView1.Rows[e.RowIndex].Cells["No"].ReadOnly = true;
            this.dataGridView1.Rows[e.RowIndex].Cells["Judul"].ReadOnly = true;
            this.dataGridView1.Rows[e.RowIndex].Cells["Isi"].ReadOnly = true;

            int selected = 0;
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
                infoIDchoose = selected;

                AdminInfoEdit editInfo = new AdminInfoEdit(infoIDchoose, "Info");
                editInfo.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {

                Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
                infoIDchoose = selected;
                SqlCommand command = new SqlCommand("DELETE FROM Info WHERE No=" + infoIDchoose, con);

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


            // Ignore clicks that are not on button cells. 
            //if (e.RowIndex < 0 || e.ColumnIndex !=
            // dataGridView1.Columns["edit"].Index) return;

            // Retrieve the content info ID.
            //int infoID = (Int32)dataGridView1[0, e.RowIndex].Value;

            //int selected = 0;
            //Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
            //infoIDchoose = selected;

            //AdminInfoEdit editInfo = new AdminInfoEdit();
            //editInfo.Show();

        }

        // message box
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
            InfoContent("");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InfoContent("");
        }

        // This event handler manually raises the CellValueChanged event
        // by calling the CommitEdit method.
        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // If a check box cell is clicked, this event handler disables  
        // or enables the button in the same row as the clicked cell.
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int selected = 0;
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Show")
            {
                Int32.TryParse(dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString(), out selected);
                infoIDchoose = selected;

                SqlCommand command = new SqlCommand("UPDATE Info SET Show=@show WHERE No=" + infoIDchoose, con);
                Boolean check = (Boolean)(dataGridView1.Rows[e.RowIndex].Cells["Show"].Value);

                if (check == true)
                {
                    command.Parameters.Add("@show", SqlDbType.Bit).Value = check;
                    ExecMyQuery(command, "Data Show");
                }
                else if (check==false)
                {
                    command.Parameters.Add("@show", SqlDbType.Bit).Value = check;
                    ExecMyQuery(command, "Data Hide");
                }
            }
        }

        private void textBoxIsi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
