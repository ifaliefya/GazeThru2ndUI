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
    public partial class AdminSetting : UserControl
    {
        private static AdminSetting _instance;
        public static AdminSetting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminSetting();
                return _instance;
            }
        }
        public AdminSetting()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        private void btnPassword_Click(object sender, EventArgs e)
        {
            string AuthQuery = "SELECT COUNT(*) FROM Login WHERE Uname='" + txtUname.Text + "' and Password = '" + txtPassword.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(AuthQuery, con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (txtConfirmaPassword.Text == txtNewPassword.Text)
                {
                    string NewPasswordQuery = "UPDATE Login SET Password = @password WHERE Id = 1";
                    SqlCommand command = new SqlCommand(NewPasswordQuery, con);

                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = txtNewPassword.Text;

                    con.Open();
                    try
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Password berhasil diubah");
                            txtUname.Text = "";
                            txtPassword.Text = "";
                            txtNewPassword.Text = "";
                            txtConfirmaPassword.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Query Not Executed, Pesan Error : " + ex);
                    }
                    con.Close();

                }
                else
                {
                    MessageBox.Show("Konfirmasi password salah");
                }
            }
            else
            {
                MessageBox.Show("Username tidak terdaftar atau password salah");
            }

        }
    }
}
