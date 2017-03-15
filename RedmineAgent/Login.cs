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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btgolog_Click(object sender, EventArgs e)
        {
            Logins lg = new Logins(tbapikey.Text);
            label4.Text = lg.Redmine();
        }
    }
}
