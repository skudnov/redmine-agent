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
            controller.OneIssueDelete += deleteIssue;
            controller.UpdateProject();
        }
        private void deleteIssue(string check)
        {
            if (check == "noError")
            {
                controller.UpdateIssue(idProject[cb_project.SelectedIndex - 1]);
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
        private void updateStatus(string check)
        {

            if (check == "noError")
            {
                controller.UpdateIssue(idProject[cb_project.SelectedIndex - 1]);
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

        public void issuesUpdated(List<Issue> issues, string check, string roles,List<StatusNew> statues,List<IssuePrioriti> priority,List<TrackerNew> tracker)
        {
            
            if (check == "noError")
            {
                membershipslist = controller.MembershipInfo();
                lv_issue.Items.Clear();
                tm_status.DropDown.Items.Clear();
                tm_priority.DropDown.Items.Clear();
                tm_apointed.DropDown.Items.Clear();
                tm_tracker.DropDown.Items.Clear();

                foreach (TrackerNew tr in tracker)
                {
                    tm_tracker.DropDownItems.Add(tr.Name);
                }
                foreach (IssuePrioriti ip in priority)
                {
                   tm_priority.DropDownItems.Add(ip.Name);
                   
                }
                tm_apointed.DropDownItems.Add("Никому");
                foreach (Membership mem in membershipslist)
                {
                    if (mem.Member!=null)
                    tm_apointed.DropDownItems.Add(mem.Member.Name);
                }
                lb_role.Visible = true;
                if (roles == "Manager")
                {
                 foreach (StatusNew st in statues)
                {
                    tm_status.DropDownItems.Add(st.Name);
                }
                    lb_role.Text = "Роль в проекте: Менеджер";
                    mi_newissue.Enabled = true;
                    tm_delete.Enabled = true;

                   
                }
                else if (roles == "Developer")
                {
                      foreach (StatusNew st in statues)
                {
                       if (st.Name=="In Progress" || st.Name=="Resolved" || st.Name=="Feedback")
                    tm_status.DropDownItems.Add(st.Name);

                }

                    lb_role.Text = "Роль в проекте: Разработчик";                    
                    tm_delete.Enabled = false;
                    

                }
                else if (roles == "Reporter")
                {
                    lb_role.Text = "Роль в проекте: Репортер";
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

        public void ResultJson(NewIssue newissue)
        {
            Issue issue = controller.IssueInfo(lv_issue.FocusedItem.Text);
            int idissue = issue.Id;
            string jsonResult = JsonConvert.SerializeObject(new NewIssues() { NewIssue = newissue }, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
           
            controller.StatusUpdate(jsonResult,idissue);
        }      

        private void tm_delete_Click(object sender, EventArgs e)
        {
            Issue issue = controller.IssueInfo(lv_issue.FocusedItem.Text);
            int idissue = issue.Id;
            controller.DeleteIssue(idissue);
        }

        private void lv_issue_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && lv_issue.SelectedIndices.Count != 0)
            {
                 Issue issue = controller.IssueInfo(lv_issue.FocusedItem.Text);
                 membershipslist = controller.MembershipInfo();
                tm_infoIssue.Enabled = true;
                tm_status.Enabled = true;
                tm_tracker.Enabled = true;
                tm_priority.Enabled = true;
                tm_apointed.Enabled = true;
                foreach (ToolStripMenuItem mb in tm_priority.DropDown.Items)             
                        mb.Enabled = true;

                foreach (ToolStripMenuItem mb in tm_status.DropDown.Items)
                        mb.Enabled = true;

                foreach (ToolStripMenuItem mb in tm_apointed.DropDown.Items)
                    mb.Enabled = true;

                foreach (ToolStripMenuItem mb in tm_tracker.DropDown.Items)
                    mb.Enabled = true;

                foreach (ToolStripMenuItem mb in tm_priority.DropDown.Items)
                if(mb.Text == issue.Priority.Name)
                    mb.Enabled = false;

                foreach (ToolStripMenuItem mb in tm_status.DropDown.Items)
                    if (mb.Text == issue.Status.Name)
                        mb.Enabled = false;

                foreach (ToolStripMenuItem mb in tm_apointed.DropDown.Items)
                    if (issue.AssignedTo != null)
                    {
                        if (mb.Text == issue.AssignedTo.Name)
                            mb.Enabled = false;
                    }
                    else
                        if (mb.Text == "Никому")
                        {
                            mb.Enabled = false;
                            break;
                        }

                foreach (ToolStripMenuItem mb in tm_tracker.DropDown.Items)
                    if (mb.Text == issue.Tracker.Name)
                    mb.Enabled = false;
                contextMenuStrip.Show(Cursor.Position);
            }
        }

        private void tm_status_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            StatusNew status = controller.StatusInfo(e.ClickedItem.Text);
            NewIssue newissue = new NewIssue();
            newissue.StatusId = status.Id;
            ResultJson(newissue);
        }

        private void tm_priority_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            IssuePrioriti priority = controller.PriorityInfo(e.ClickedItem.Text);
            NewIssue newissue = new NewIssue();
            newissue.PriorityId = priority.Id;
            ResultJson(newissue);
        }

        private void tm_apointed_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
               NewIssue newissue = new NewIssue();
            membershipslist = controller.MembershipInfo();
           
            if(e.ClickedItem.Text=="Никому")
            {
              newissue.AssignedToId=" ";   
            }
            else
               foreach (Membership mb in membershipslist)
            {
               if (e.ClickedItem.Text == mb.Member.Name)
                   newissue.AssignedToId = Convert.ToString(mb.Member.Id);
            }
            ResultJson(newissue);
        }

        private void tm_tracker_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TrackerNew tracker = controller.TrackerInfo(e.ClickedItem.Text);
            NewIssue newissue = new NewIssue();
            newissue.TrackerId = tracker.Id;
            ResultJson(newissue);
        }

       

        
    }
}

