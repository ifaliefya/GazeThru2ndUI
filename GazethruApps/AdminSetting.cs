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
    }
}
