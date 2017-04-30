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
            
            bt_login.Enabled = false;
            bt_cancel.Enabled = false;
            controller.LoginApiKey(tbapikey.Text,cbapikey.Checked);
        }

        private void apiKeyChanged(string check, bool checkapi)
        {
            Action action = () =>
                {

                    if (check == "noError")
                    {
                        this.Close();

                    }
                    else if (check == "errorKey")
                    {
                        MessageBox.Show("Введенный api-key неправильный. Повторите ввод!", "Ошибка Api-key");
                        bt_login.Enabled = true;
                        bt_cancel.Enabled = true;
                    }
                    else if (check == "errorInternet")
                    {
                        bt_login.Enabled = true;
                        bt_cancel.Enabled = true;
                        MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
                    }
                    else if (check == "unknownError")
                        MessageBox.Show("Повторите попытку,неизвестная ошибка!", "Неизвестная ошибка");

                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();

        }

        private void tbapikey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) bt_login.PerformClick();
        }

      
    }
}
