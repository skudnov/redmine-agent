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
            controller.apiKeyChanged += apiKeyChanged;
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {

            controller.LoginApiKey(tbapikey.Text);
          

            if (cbapikey.Checked==true)
            {

            }
            else
            {

            }
        }

        private void apiKeyChanged(string check)
        {
            if (check =="NO")
            {
                this.Close();
            }
            else if (check == "errorkey")
            {
                MessageBox.Show("Введенный api-key неправильный. Повторите ввод!","Ошибка Api-key");
            }
            else if (check == "errorkey")
            {
                MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
            }
           
        }
        
    }
}
