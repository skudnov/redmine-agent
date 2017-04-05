using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RedmineAgent
{
    public partial class Form_Main : Form
    {
        private Controller controller;
        public Form_Main()
        {
            InitializeComponent();
            cb_project.SelectedIndex = 0;
            controller = Program.controllerProgram;
        }


        private void mi_apikey_Click(object sender, EventArgs e)
        {
            new Form_Apikey().ShowDialog();
        }

        private void mi_exit_Click(object sender, EventArgs e)
        {
           var Result= MessageBox.Show("Вы действительно хотите выйти?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);                  
        if (Result == DialogResult.Yes)
        {
            Application.Exit();
        }

        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            var Result2 = MessageBox.Show("Вы действительно хотите выйти?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Result2 == DialogResult.No)
            {
                e.Cancel = true;
            }
            
                
        }

        private void mi_update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обновленно", "", MessageBoxButtons.OK);
                          
        }

        private void mi_info_Click(object sender, EventArgs e)
        {
            // инфо об аккаунте
        }

        private void cb_project_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (cb_project.SelectedIndex==0)
           {

           }
           else
           {

           }

        }
        

        

      
    }
}
