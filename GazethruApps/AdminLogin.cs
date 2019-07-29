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

namespace GazethruApps
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void linkLabelBackHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            formAwal back = new formAwal();
            back.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);
            
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login where Uname='" + textBoxUname.Text + "' and Password = '" + textBoxPsswrd.Text + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Close();
                //AdminAwal Informasi = new AdminAwal();
                //Informasi.Show();
            }
            else
            {
                MessageBox.Show("Please check your Username and Password");
            }

        }
    }
}
