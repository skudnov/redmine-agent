using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedmineAgent
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        Login l = new Login();

        

        private void bt_input_Click_1(object sender, EventArgs e)
        {
            l.Show();
        }
    }
}
