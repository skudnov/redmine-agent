using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedmineAgent.Models;

namespace RedmineAgent
{
    public partial class Form_Main : Form
    {
        private Controller controller;
        public  List<int> idProject = new List<int>();
        
        public Form_Main()
        {
            InitializeComponent();
            cb_project.SelectedIndex = 0;
            controller = Program.controllerProgram;
            controller.projectsUpdated += projectsUpdated;
            controller.issuesUpdated += issuesUpdated;
            controller.UpdateProject();
           controller.apiKeyChanged += apiTokenChanged;
            
        }

        private void apiTokenChanged()
        {
            cb_project.SelectedIndex = 0;
            lv_issue.Items.Clear();
            mi_info.Enabled = true;
        }        

        public void projectsUpdated(List<Project> projects)
        {
            for (int i = cb_project.Items.Count-1; i >=1 ; i--)
            {
                cb_project.Items.RemoveAt(i); ;
            }          
            foreach (Project project in projects)
            {
              
                cb_project.Items.Add(project.Id+" "+project.Name);
                idProject.Add(project.Id);
            }
        }

        public void issuesUpdated(List<Issue> issues)
        {
            foreach (Issue issue in issues)
            {
                ListViewItem lvi = new ListViewItem(issue.Subject);
                lvi.SubItems.Add(issue.Tracker.Name);
                lvi.SubItems.Add(issue.Status.Name);
                lvi.SubItems.Add(issue.Priority.Name);
                if (issue.AssignedTo == null) 
                    lvi.SubItems.Add("");                    
                else
                lvi.SubItems.Add(issue.AssignedTo.Name);
                lvi.SubItems.Add(issue.UpdatedOn.ToShortDateString());
                lv_issue.Items.Add(lvi);              
            }
        }



        private void mi_apikey_Click(object sender, EventArgs e)
        {
            new Form_Apikey().ShowDialog();
        }

        private void mi_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            var Result2 = MessageBox.Show("Вы действительно хотите выйти?", "Внимание!", MessageBoxButtons.YesNo);
            if (Result2 == DialogResult.No)
            {
                e.Cancel = true;
            }               
        }

        private void mi_update_Click(object sender, EventArgs e)
        {
            controller.UpdateProject();
            cb_project.SelectedIndex = 0;
            lv_issue.Items.Clear();            
        }

        private void mi_info_Click(object sender, EventArgs e)
        {
            // инфо об аккаунте
        }

        private void cb_project_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_project.SelectedIndex == 0)
            {
                lv_issue.Items.Clear();
            }
            else
            {   
                lv_issue.Items.Clear();
           //     string projectName = cb_project.SelectedItem.ToString();
                controller.UpdateIssue(idProject[cb_project.SelectedIndex-1]);
            }
        }      
    }
}
