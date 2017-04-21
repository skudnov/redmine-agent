using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedmineAgent.Models;
using Newtonsoft.Json;

namespace RedmineAgent
{
    public partial class Form_Main : Form
    {
        private Controller controller;
        public List<int> idProject = new List<int>();
        public List<Membership> membershipslist = new List<Membership>();
       

        public Form_Main()
        {
            InitializeComponent();
            cb_project.SelectedIndex = 0;
            controller = Program.controllerProgram;
            controller.projectsUpdated += projectsUpdated;
            controller.issuesUpdated += issuesUpdated;
            controller.apiKeyChanged += apiKeyChanged;
            controller.UpdateStatus += updateStatus;
            controller.UpdateProject();
        }
        private void updateStatus(string check)
        {

            if (check == "noError")
            {
                controller.UpdateIssue(cb_project.SelectedIndex - 1);
            }
            else if (check == "errorKey")
            {
                MessageBox.Show("Введенный api-key неправильный. Повторите ввод!", "Ошибка Api-key");
                new Form_Apikey().ShowDialog();
            }
            else if (check == "errorInternet")
            {
                MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
            }
        }
        private void apiKeyChanged(string check)
        {
            if (check == "noError")
            {
                cb_project.SelectedIndex = 0;
                lv_issue.Items.Clear();
                mi_info.Enabled = true;
                controller.UpdateProject();
            }
        }

        public void projectsUpdated(List<Project> projects, string check)
        {
            if (check == "noError")
            {
                for (int i = cb_project.Items.Count - 1; i >= 1; i--)
                {
                    cb_project.Items.RemoveAt(i); ;
                }
                foreach (Project project in projects)
                {
                    cb_project.Items.Add(project.Name);
                    idProject.Add(project.Id);
                }
            }
            else if (check == "errorKey")
            {
                MessageBox.Show("Введенный api-key неправильный. Повторите ввод!", "Ошибка Api-key");
                new Form_Apikey().ShowDialog();
            }
            else if (check == "errorInternet")
            {
                MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
            }
        }

        public void issuesUpdated(List<Issue> issues, string check, string roles)
        {
            lv_issue.Items.Clear();
            if (check == "noError")
            {
                lb_role.Visible = true;
                if (roles == "Manager")
                {
                    lb_role.Text = "Роль в проекте: Менеджер";
                    mi_newissue.Enabled = true;
                    

                    tm_new.Visible = true;
                    tm_inProgress.Visible = true;
                    tm_Resolved.Visible = true;
                    tm_feedblack.Visible = true;
                    tm_closed.Visible = true;
                    tm_rejected.Visible = true;

                   
                }
                else if (roles == "Developer")
                {
                    lb_role.Text = "Роль в проекте: Разработчик";
                    tm_inProgress.Visible = true;
                    tm_Resolved.Visible = true;
                    tm_feedblack.Visible = true;
                    
                    tm_new.Visible = false;
                    tm_closed.Visible = false;
                    tm_rejected.Visible = false;
                    

                }
                else if (roles == "Reporter")
                {
                    lb_role.Text = "Роль в проекте: Репортер";
                }
                else if (roles == null)
                {
                    lb_role.Text = "Вы не состоите в проекте!";
                    tm_new.Visible = false;
                    tm_inProgress.Visible = false;
                    tm_Resolved.Visible = false;
                    tm_feedblack.Visible = false;
                    tm_closed.Visible = false;
                    tm_rejected.Visible = false;
                }
                else
                {
                    mi_newissue.Enabled = false;
                }

                foreach (Issue issue in issues)
                {
                    ListViewItem lvi = new ListViewItem(issue.Subject);
                    lvi.SubItems.Add(issue.Tracker.Name);
                    lvi.SubItems.Add(issue.Status.Name);
                    lvi.SubItems.Add(issue.Priority.Name);
                    //  lvi.SubItems.Add();
                    if (issue.AssignedTo == null)
                        lvi.SubItems.Add("(не назначен)");
                    else
                        lvi.SubItems.Add(issue.AssignedTo.Name);
                    lvi.SubItems.Add(issue.UpdatedOn.ToShortDateString());
                    lv_issue.Items.Add(lvi);
                }
            }
            else if (check == "errorKey")
            {
                MessageBox.Show("Введенный api-key неправильный. Повторите ввод!", "Ошибка Api-key");
                new Form_Apikey().ShowDialog();

            }
            else if (check == "errorInternet")
            {
                MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
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
            //var Result2 = MessageBox.Show("Вы действительно хотите выйти?", "Внимание!", MessageBoxButtons.YesNo);
            //if (Result2 == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void mi_update_Click(object sender, EventArgs e)
        {
            controller.UpdateProject();
            cb_project.SelectedIndex = 0;
            lv_issue.Items.Clear();
        }

        private void mi_info_Click(object sender, EventArgs e)
        {
            User user = controller.UserInfo();
            MessageBox.Show(" id: " + user.Id + "\n\r" + " Логин: " + user.Login + "\n\r" + " Имя: " + user.FirstName + "\n\r" + " Фамилия: " + user.LastName + "\n\r" + " mail: " + user.Mail + "\n\r" + " Дата создания: " + user.CreatedOn + "\n\r" + " Последнее подключение: " + user.LastLoginOn + "\n\r" + " Api ключ: " + user.ApiKey, "Информация об аккаунте");
        }

        private void cb_project_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_project.SelectedIndex == 0)
            {
                lv_issue.Items.Clear();
                mi_ifoprj.Enabled = false;
                lb_role.Visible = false;
                mi_newissue.Enabled = false;
            }
            else
            {
                lv_issue.Items.Clear();
                //     string projectName = cb_project.SelectedItem.ToString();
                controller.UpdateIssue(idProject[cb_project.SelectedIndex - 1]);
                mi_ifoprj.Enabled = true;
            }
        }

        private void mi_ifoprj_Click(object sender, EventArgs e)
        {
            Project project = controller.ProjectInfo(idProject[cb_project.SelectedIndex - 1]);
            membershipslist = controller.MembershipInfo();

            string manager = "Менеджеры: ";
            string developer = "Разработчики: ";
            Membership roles = null;
            foreach (Membership mb in membershipslist)
            {
                roles = mb;
                if (mb.Member != null)
                {
                    foreach (Role rl in roles.Roles)
                    {
                        if (rl.Name == "Manager")

                            manager = manager + mb.Member.Name + " ";

                        else if (rl.Name == "Developer")
                            developer = developer + mb.Member.Name + " ";

                    }
                }
            }
            MessageBox.Show("id: " + project.Id + "\n\r" + "Название проекта: " + project.Name + "\n\r" + "Статус: " + project.Status + "\n\r" + "Идентификатор: " + project.Indentifier + "\n\r" + "Публичный: " + project.IsPublic + "\n\r" + "Дата изменения: " + project.UpdatedOn + "\n\r" + "Дата создания: " + project.CreatedOn + "\n\r"  + manager + "\n\r" + developer,"Информация о проекте!");

        }

        private void lv_issue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lv_issue.SelectedIndices.Count!=0)
            {
                tm_infoIssue.Enabled = true;
                tm_status.Enabled = true;
                tm_tracker.Enabled = true;
                tm_priority.Enabled = true;
                tm_apointed.Enabled = true;
                contextMenuStrip.Show(Cursor.Position);
            }
            else if (e.Button == MouseButtons.Right)
            {
                tm_status.Enabled = false;
                tm_infoIssue.Enabled = false;
                tm_tracker.Enabled = false;
                tm_priority.Enabled = false;
                tm_apointed.Enabled = false;
                contextMenuStrip.Show(Cursor.Position);
            }

        }

        private void tm_infoIssue_Click(object sender, EventArgs e)
        {
            string assigned="";
            Issue issue = controller.IssueInfo(lv_issue.FocusedItem.Text);
            if (issue.AssignedTo == null)
                assigned="";
            else
               assigned = issue.AssignedTo.Name;
            MessageBox.Show("Название проекта: " + issue.Project.Name + "\n\r" + "Название задачи: " + issue.Subject + "\n\r" + "Трекер: " + issue.Tracker.Name + "\n\r" + "Статус: " + issue.Status.Name + "\n\r" + "Приоритет: " + issue.Priority.Name + "\n\r" + "Автор: " + issue.Author.Name + "\n\r" + "Назначена: " + assigned + "\n\r" + "Описание: " + issue.Description + "\n\r" + "Обновлено " + issue.CreatedOn,"Информация о задаче!");
        }

        private void mi_newissue_Click(object sender, EventArgs e)
        {
            new Form_NewIssue(idProject[cb_project.SelectedIndex - 1]).ShowDialog();
        }

        private void tm_new_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.StatusId = 1;
            ResultJson(newissue);
        }
        public void ResultJson(NewIssue newissue)
        {
            Issue issue = controller.IssueInfo(lv_issue.FocusedItem.Text);
            int idissue = issue.Id;
            string jsonResult = JsonConvert.SerializeObject(new NewIssues() { NewIssue = newissue }, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
           
            controller.StatusUpdate(jsonResult,idissue);
        }

        private void tm_inProgress_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.StatusId = 2;
            ResultJson(newissue);
        }

        private void tm_Resolved_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.StatusId = 3;
            ResultJson(newissue);
        }

        private void tm_feedblack_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.StatusId = 4;
            ResultJson(newissue);
        }

        private void tm_closed_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.StatusId = 5;
            ResultJson(newissue);
        }

        private void tm_rejected_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.StatusId = 6;
            ResultJson(newissue);
        }

        private void tm_bbug_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.TrackerId = 1;
            ResultJson(newissue);
        }

        private void tm_feature_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.TrackerId = 2;
            ResultJson(newissue);
        }

        private void tm_suppurt_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.TrackerId = 3;
            ResultJson(newissue);
        }

        private void tm_immediate_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.PriorityId = 5;
            ResultJson(newissue);
        }

        private void tm_urgent_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.PriorityId = 4;
            ResultJson(newissue);
        }

        private void tm_high_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.PriorityId = 3;
            ResultJson(newissue);
        }

        private void tm_normal_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.PriorityId = 2;
            ResultJson(newissue);
        }

        private void tm_low_Click(object sender, EventArgs e)
        {
            NewIssue newissue = new NewIssue();
            newissue.PriorityId = 1;
            ResultJson(newissue);
        }

       

        
    }
}

