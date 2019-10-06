﻿using System;
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
    public partial class AdminPrestasi : UserControl
    {
        private static AdminPrestasi _instance;
        public static AdminPrestasi Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminPrestasi();
                return _instance;
            }
        }

        public AdminPrestasi()
        {
            InitializeComponent();
        }

        public static int infoIDchoose;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        private void AdminPrestasi_Load(object sender, EventArgs e)
        {
            PrestasiContent("");
        }

        public void PrestasiContent(string valueToSearch)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Prestasi WHERE CONCAT(No, Judul, Isi) LIKE '%" + valueToSearch + "%'", con);
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

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            PrestasiContent(textBoxSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminInfoNew addInfo = new AdminInfoNew("Prestasi");
            addInfo.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //disable edit on datagridview
                this.dataGridView1.Rows[e.RowIndex].Cells["No"].ReadOnly = true;
                this.dataGridView1.Rows[e.RowIndex].Cells["Judul"].ReadOnly = true;
                this.dataGridView1.Rows[e.RowIndex].Cells["Isi"].ReadOnly = true;

                infoIDchoose = (int)dataGridView1.Rows[e.RowIndex].Cells["No"].Value;
                if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    AdminInfoEdit editInfo = new AdminInfoEdit(infoIDchoose, "Prestasi");
                    editInfo.Show();
                }
                else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Prestasi WHERE No=" + infoIDchoose, con);

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
            catch
            {
                return;
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
            PrestasiContent("");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PrestasiContent("");
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Show")
            {
                infoIDchoose = (int)dataGridView1.Rows[e.RowIndex].Cells["No"].Value;
                SqlCommand command = new SqlCommand("UPDATE Prestasi SET Show=@show WHERE No=" + infoIDchoose, con);
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
