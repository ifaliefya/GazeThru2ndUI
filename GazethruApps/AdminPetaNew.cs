using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazethruApps
{
    public partial class AdminPetaNew : Form
    {
        static AdminPetaNew _obj;
        public int LantaiID;
        public static AdminPetaNew Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new AdminPetaNew();
                }
                return _obj;
            }
        }

        public Panel PnlEdit
        {
            get { return panelEdit; }
            set { panelEdit = value; }

        }
        public AdminPetaNew()
        {
            InitializeComponent();
            LantaiID = AdminPetaAwal.PetaIDchoose;
        }

        private void AdminPetaNew_Load(object sender, EventArgs e)
        {
            _obj = this;

            AdminPetaNewLantai newLantai = new AdminPetaNewLantai();
            newLantai.Dock = DockStyle.Fill;
            panelEdit.Controls.Add(newLantai);
            newLantai.LoadLantai(LantaiID);
        }
    }
}
