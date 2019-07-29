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
    public partial class AdminPetaNewRuang : UserControl
    {
        private static AdminPetaNewRuang _instance;
        public static AdminPetaNewRuang Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminPetaNewRuang();
                return _instance;
            }
        }

        public int NoLantai;
        public int LastPointer = 0;
        public int currentPLocX;
        public int currentPLocY;
        public string NewPName;
        public int IDChoose;
        public int LastID;
        public int EditSession = 0;
        public Boolean NotSave;

        public struct PExist
        {
            public int LocX;
            public int LocY;
            public string Name;

            public PExist(int x, int y, string name)
            {
                LocX = x;
                LocY = y;
                Name = name;
            }
        }

        List<PExist> AllPointer = new List<PExist>();
        int counter = 0;
        int maxCounter;
        
        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        public AdminPetaNewRuang()
        {
            InitializeComponent();
        }

        private void AdminPetaNewRuang_Load(object sender, EventArgs e)
        {
            AddEditView(false, false, false);
            GetLastID(con);

        }

        public void LoadPointer (int IDLantai)
        {
            con.Open();
            string SelectQuery = "SELECT LocX, LocY, Pointer FROM Ruang WHERE PetaID = " + IDLantai;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    var locx = read.GetInt32(0);
                    var locy = read.GetInt32(1);
                    var name = read.GetString(2);
                    var Pini = new PExist(locx, locy, name);
                    AllPointer.Add(Pini);

                    Pointer P = ReadPointer(locx, locy, name);
                    pbPetaLantai.Controls.Add(P);
                    P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PointerDown);
                    P.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PointerDrag);
                    P.Move += new System.EventHandler(this.PointerMove);
                    P.Click += new System.EventHandler(this.PointerClick);
                    //    var locx = AllPointer[PointerID].LocX;
                }
                maxCounter = AllPointer.Count;
                LastPointer = Convert.ToInt32(AllPointer[maxCounter - 1].Name);
            }
            else
            {
                MessageBox.Show("Tambahkan Pointer");
            }
            
            con.Close();

        }

        Pointer ReadPointer(int x, int y, string name)
        {
            Pointer Pointer = new Pointer();
            Pointer.Name = name;
            Pointer.Size = new Size(22, 30);
            Pointer.Location = new System.Drawing.Point(x, y);
            Bitmap bmp = new Bitmap(Properties.Resources.biru);
            Pointer.Image = bmp;
            Pointer.BackColor = Color.Transparent;
            //Pointer.BorderStyle = BorderStyle.FixedSingle;

            return Pointer;
        }

        public void GetLantaiPic (int IDLantai)
        {
            NoLantai = IDLantai;

            con.Open();
            string SelectQuery = "SELECT * FROM Peta WHERE No=" + NoLantai;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                labelNamaLantai.Text = (read["Judul"].ToString());
                if (!Convert.IsDBNull(read["Gambar"]))
                {
                    Byte[] img = (Byte[])(read["Gambar"]);
                    MemoryStream ms = new MemoryStream(img);
                    pbPetaLantai.Image = Image.FromStream(ms);
                }
            }
            else
            {
                labelNamaLantai.Text = "";
                pbPetaLantai.Image = null;
            }
            con.Close();
        }

        public void ListPoint (int IDLantai)
        {
            string SelectQuery = "SELECT Id, Judul, Pointer FROM Ruang WHERE PetaID =" + IDLantai;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command); 

            DataTable table = new DataTable(); 

            adapter.Fill(table);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = table; 

            CreateButtonColumn();
            CreateDeleteButton();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Load first
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                string Pname = dataGridView1.Rows[0].Cells["Pointer"].Value.ToString();
                labelIDNow.Text = Pname;
                PreviewDetail(Pname);
            }
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

        private void buttonAddPoint_Click(object sender, EventArgs e)
        {
            ++LastPointer;
            Pointer P = AddPointer(LastPointer);
            pbPetaLantai.Controls.Add(P);
            NewPName = P.Name;
            P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PointerDown);
            P.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PointerDrag);
            P.Move += new System.EventHandler(this.PointerMove);
            P.Click += new System.EventHandler(this.PointerClick);

            tbLocX.Text = P.Location.X.ToString();
            tbLocY.Text = P.Location.Y.ToString();

            AddEditView(false, true, false);
            NotSave = true;
        }

        void BelomDisimpan ()
        {
            List<Control> listPointer = pbPetaLantai.Controls.Cast<Control>().ToList();
            foreach (Control control in listPointer)
            {
                pbPetaLantai.Controls.Remove(control);
                control.Dispose();
            }
            LoadPointer(NoLantai);
        }

        Pointer AddPointer (int newPointerID)
        {
            EditSession = 0;
            Pointer Pointer = new Pointer();
            Pointer.Name = newPointerID.ToString();
            Pointer.Size = new Size(22, 30);
            Pointer.Top = pbPetaLantai.Top + 10;
            Pointer.Left = pbPetaLantai.Left + 10;

            Bitmap bmp = new Bitmap(Properties.Resources.biru);
            Pointer.Image = bmp;
            Pointer.BackColor = Color.Transparent;
            //Pointer.BorderStyle = BorderStyle.FixedSingle;
            currentPLocX = Pointer.Location.X;
            currentPLocY = Pointer.Location.Y;

            return Pointer;
        }

        Point loc;
        void PointerDown (object sender, MouseEventArgs e)
        {
            Pointer currentP = (Pointer)sender;
            if (e.Button == MouseButtons.Left)
                loc = e.Location;
        }

        void PointerDrag(object sender, MouseEventArgs e)
        {
            Pointer currentP = (Pointer)sender;
            if (e.Button == MouseButtons.Left)
                currentP.Location = new Point(currentP.Left + (e.X - loc.X), currentP.Top + (e.Y - loc.Y));
        }

        void PointerMove(object sender, EventArgs e)
        {
            Pointer currentP = (Pointer)sender;
            currentPLocX = currentP.Location.X;
            currentPLocY = currentP.Location.Y;
            tbLocX.Text = currentPLocX.ToString();
            tbLocY.Text = currentPLocY.ToString();
        }

        void PointerClick(object sender, EventArgs e)
        {
            Pointer currentP = (Pointer)sender;
            string Pname = currentP.Name;
            PointerChoosen(Pname);
            AddEditView(true, true, false);
            //if (Pname != NewPName || NotSave == true )
            //{
            //    BelomDisimpan();
            //}
            PreviewDetail(Pname);
            labelIDNow.Text = Pname;
        }

        //PointerChoosen dipanggil dari dalam PreviewDetail
        void PointerChoosen(string Pname)
        {
            foreach (Pointer item in pbPetaLantai.Controls)
                if (item.Name == Pname)
                {
                    item.Size = new Size(45, 45);
                    item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    Bitmap bmp = new Bitmap(Properties.Resources.kuning52px);
                    item.Image = bmp;
                    currentPLocX = item.Location.X;
                    currentPLocY = item.Location.Y;
                    tbLocX.Text = currentPLocX.ToString();
                    tbLocY.Text = currentPLocY.ToString();
                }
                else
                {
                    Bitmap bmp = new Bitmap(Properties.Resources.biru);
                    item.Image = bmp;
                }

        }


        public void AddEditView (Boolean Content, Boolean Write, Boolean ButtonEdit )
        {
            Boolean Edit;
            Boolean Read;
            buttonEdit.Visible = ButtonEdit;
            Color ColorTB;

            if (Content == false)
            {
                tbLocX.Text = null;
                tbLocY.Text = null;
                textBoxJudul.Text = null;
                textBoxIsi.Text = null;
                pictureBoxRuang.Image = null;
            }

            if (Write == true)
            {
                Edit = true;
                Read = false;
                panelDetails.BackColor = Color.LightBlue;
                ColorTB = Color.White;
            }

            else
            {
                Edit = false;
                Read = true;
                panelDetails.BackColor = SystemColors.Control;
                ColorTB = SystemColors.Control;
            }

            buttonBrowsePict.Visible = Edit;
            buttonSave.Visible = Edit;
            buttonCancel.Visible = Edit;

            buttonAddPoint.Enabled = Read;
            tbLocX.ReadOnly = Read;
            tbLocY.ReadOnly = Read;
            textBoxJudul.ReadOnly = Read;
            textBoxIsi.ReadOnly = Read;

            tbLocX.BackColor = ColorTB;
            tbLocY.BackColor = ColorTB; ;
            textBoxJudul.BackColor = ColorTB; 
            textBoxIsi.BackColor = ColorTB; 

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            AddEditView(false, false, false);
            //if (EditSession == 0)
            if (NotSave == true)
            {
                string Pname = LastPointer.ToString();
                foreach (Control item in pbPetaLantai.Controls)
                    if (item.Name == Pname)
                    {
                        pbPetaLantai.Controls.Remove(item);
                        break;
                    }
                LastPointer--;
            }
            LoadPointer(NoLantai);
        }

        public void GetLastID(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
              "SELECT MAX(Id) FROM Ruang", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    LastID = reader.GetInt32(0) + 1;
                }
                else
                {
                    LastID = 0;
                }
            }
            reader.Close();
            connection.Close();
        }

        private void buttonBrowsePict_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG; *.PNG; *.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxRuang.Image = Image.FromFile(opf.FileName);
            }
        }

        private byte[] GetPic(Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(pictureBoxRuang.Image);
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //int newID = LastID + 1 ;
            if (EditSession == 0)
            {
                string InsertQuery =
                "DBCC CHECKIDENT (Ruang, RESEED," + LastID + "); " + //DBCC adalah menyalahi aturan increment dan unique, semoga tidak error
                "INSERT INTO Ruang(LocX, LocY, Judul, Isi, Gambar, Pointer, PetaID) VALUES (@locx, @locy, @judul, @isi, @gambar, @pointer, @petaid);";
                SqlCommand command = new SqlCommand(InsertQuery, con);

                command.Parameters.Add("@petaid", SqlDbType.Int).Value = NoLantai;
                command.Parameters.Add("@locx", SqlDbType.Int).Value = currentPLocX;
                command.Parameters.Add("@locy", SqlDbType.Int).Value = currentPLocY;
                command.Parameters.Add("@judul", SqlDbType.VarChar).Value = textBoxJudul.Text;
                command.Parameters.Add("@isi", SqlDbType.VarChar).Value = textBoxJudul.Text;
                command.Parameters.Add("@pointer", SqlDbType.VarChar).Value = NewPName;

                if (pictureBoxRuang.Image == null)
                {
                    command.Parameters.Add("@gambar", SqlDbType.Image).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@gambar", SqlDbType.Image).Value = GetPic(pictureBoxRuang.Image);
                }
                ExecMyQuery(command, "Pointer Ruangan Ditambahkan");
                NotSave = false;
            }
            else
            {
                string UpdateQuery =
               "UPDATE Ruang SET LocX=@locx, LocY=@locy, Judul=@judul, Isi=@isi, Gambar=@gambar WHERE Id =" + EditSession;
                SqlCommand command = new SqlCommand(UpdateQuery, con);

                command.Parameters.Add("@locx", SqlDbType.Int).Value = currentPLocX;
                command.Parameters.Add("@locy", SqlDbType.Int).Value = currentPLocY;
                command.Parameters.Add("@judul", SqlDbType.VarChar).Value = textBoxJudul.Text;
                command.Parameters.Add("@isi", SqlDbType.VarChar).Value = textBoxJudul.Text;


                if (pictureBoxRuang.Image == null)
                {
                    command.Parameters.Add("@gambar", SqlDbType.Image).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@gambar", SqlDbType.Image).Value = GetPic(pictureBoxRuang.Image);
                }
                ExecMyQuery(command, "Pointer Ruangan Diedit");
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
            ListPoint(NoLantai);
            LoadPointer(NoLantai);
            GetLastID(con);
            AddEditView(false, false, false);
            pictureBoxRuang.Image = null;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (NotSave == true)
            {
                BelomDisimpan();
            }
            this.dataGridView1.Rows[e.RowIndex].Cells["Id"].ReadOnly = true;
            this.dataGridView1.Rows[e.RowIndex].Cells["Judul"].ReadOnly = true;

            int selected = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            IDChoose = selected;
            string Pselected = (string)dataGridView1.Rows[e.RowIndex].Cells["Pointer"].Value;

            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                AddEditView(true, true, false);
                PreviewDetail(Pselected);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Ruang WHERE Id=" + IDChoose, con);

                if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecMyQuery(command, "Data Deleted");
                    foreach (Control item in pbPetaLantai.Controls)
                        if (item.Name == Pselected)
                        {
                            pbPetaLantai.Controls.Remove(item);
                            break;
                        }
                }
            }
            else
            {
                AddEditView(true, false, true);
                PreviewDetail(Pselected);
                //labelIDNow.Text = Pselected;
            }
        }

        void PreviewDetail (string Pname)
        {
            PointerChoosen(Pname);

            con.Open();
            string SelectQuery = "SELECT Id, LocX, LocY, Judul, Isi, Gambar, Pointer FROM Ruang WHERE PetaID=" + NoLantai + "AND Pointer ='" + Pname + "'";
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                EditSession = (int)(read["Id"]);
                //tbLocX.Text = (String)(read["LocX"].ToString());
                //tbLocY.Text = (String)(read["LocY"].ToString());
                textBoxJudul.Text = (String)(read["Judul"]); 
                textBoxIsi.Text = (String)(read["Isi"]);

                if (!Convert.IsDBNull(read["Gambar"]))
                {
                    Byte[] img = (Byte[])(read["Gambar"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBoxRuang.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBoxRuang.Image = null;
                }
            }
            else
            {
                textBoxJudul.Text = "";
                textBoxIsi.Text = "";
                pictureBoxRuang.Image = null;
            }
            con.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            AddEditView(true, true, false);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            //adminPetaNew Close
        }

        int SelectedRow;

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (NotSave == true)
            {
                BelomDisimpan();
            }
            buttonNext.Enabled = true;
            SelectedRow = dataGridView1.SelectedCells[0].OwningRow.Index;
            if (SelectedRow > 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[SelectedRow - 1].Selected = true;
                string SelectedPointer = dataGridView1.Rows[SelectedRow].Cells["Pointer"].Value.ToString();
                labelIDNow.Text = SelectedPointer;
                PreviewDetail(SelectedPointer);
            }
            else
            {
                buttonPrev.Enabled = false;
            }

        }
        
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (NotSave == true)
            {
                BelomDisimpan();
            }
            buttonPrev.Enabled = true;
            SelectedRow = dataGridView1.SelectedCells[0].OwningRow.Index;
            if (SelectedRow < dataGridView1.Rows.Count -1)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[SelectedRow + 1].Selected = true;
                string SelectedPointer = dataGridView1.Rows[SelectedRow].Cells["Pointer"].Value.ToString();
                labelIDNow.Text = SelectedPointer;
                PreviewDetail(SelectedPointer);
            }
            else
            {
                buttonNext.Enabled = false;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<Control> listPointer = pbPetaLantai.Controls.Cast<Control>().ToList();
            foreach (Control control in listPointer)
            {
                pbPetaLantai.Controls.Remove(control);
                control.Dispose();
            }
            LoadPointer(NoLantai);
        }
    }

    //Pointer Class
    public class Pointer : PictureBox

    {
        //protected override void OnMouseHover(System.EventArgs e)
        //{
        //    float fontSize = Font.SizeInPoints;
        //    fontSize += 1;
        //    System.Drawing.Size buttonSize = Size;
        //    this.Font = new System.Drawing.Font(
        //        Font.FontFamily, fontSize, Font.Style);

        //    Size = new System.Drawing.Size(Size.Width + 5, Size.Height + 5);

        //    base.OnMouseHover(e);
        //}

        protected override void OnMouseLeave(System.EventArgs e)
        {
            Size = new System.Drawing.Size(22, 30);

            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            base.OnMouseMove(e);
        }
    }
}
