using System;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RedmineAgent
{
    public partial class Form_Apikey : Form
    {
        Controller controller;
        public Form_Apikey()
        {
            InitializeComponent();
            controller = Program.controllerProgram;
            controller.apiKeyChanged += apiTokenChanged;
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            controller.LoginApiKey(tbapikey.Text);
        }

        private void apiTokenChanged()
        {
            this.Close();
        }
        
    }
}
