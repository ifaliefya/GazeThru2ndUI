using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazethruApps
{
    public partial class AdminPetaEdit : UserControl
    {
        private static AdminPetaEdit _instance;
        public static AdminPetaEdit Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminPetaEdit();
                return _instance;
            }
        }

        public AdminPetaEdit()
        {
            InitializeComponent();
        }


    }
}
