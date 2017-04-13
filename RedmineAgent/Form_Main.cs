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
            controller.UpdateProject();
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
            if (check == "noError")
            {
                lb_role.Visible = true;
                if (roles == "Manager")
                {
                    lb_role.Text = "Роль в проекте: Менеджер";
                    mi_newissue.Enabled = true;
                }
                else if (roles == "Developer")
                {
                    lb_role.Text = "Роль в проекте: Разработчик";
                }
                else if (roles == "Reporter")
                {
                    lb_role.Text = "Роль в проекте: Репортер";
                }
                else if (roles == null)
                {
                    lb_role.Text = "Вы не состоите в проекте!";
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

            string manager = "";
            string developer = "";
            Membership roles = null;
            foreach (Membership mb in membershipslist)
            {
                roles = mb;
                foreach (Role rl in roles.Roles)
                {
                    if (rl.Name == "Manager")

                        manager = manager + mb.Member.Name;

                    else if (rl.Name == "Developer")
                        developer =developer+ mb.Member.Name;

                }
            }
            MessageBox.Show(" id: " + project.Id + "\n\r" + " Название проекта: " + project.Name + "\n\r " + "Статус: " + project.Status + "\n\r" + " Идентификатор: " + project.Indentifier + "\n\r" + " Публичный: " + project.IsPublic + "\n\r" + " Дата изменения: " + project.UpdatedOn + "\n\r" + " Дата создания: " + project.CreatedOn + "\n\r" + " Менеджеры: " + manager + "\n\r" + " Разработчики: " + developer,"Информация о проекте!");

        }
    }
}

