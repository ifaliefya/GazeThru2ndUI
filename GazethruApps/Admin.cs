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
    public partial class Admin : Form
    {
        // Variable global mencoba
        static class Global
        {
            private static string _globalVar = "abc";

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }
        public Admin()
        {
            InitializeComponent();
        }
    }
}
