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
        bool checkapi = true;
        public int sortColumn = 0;
        public int lastidproject=0;
        private readonly Timer tmrShow;


        public Form_Main()
        {
            InitializeComponent();
            tmrShow = new Timer(); // создаем новый таймер
            tmrShow.Interval = 60000; // ставим интервал выполнения единственного события, через 5 секунд
            cb_project.SelectedIndex = 0;
            controller = Program.controllerProgram;
            controller.projectsUpdated += projectsUpdated;
            controller.issuesUpdated += issuesUpdated;
            controller.apiKeyChanged += apiKeyChanged;
            controller.UpdateStatus += updateStatus;
            controller.OneIssueDelete += deleteIssue;
            controller.UpdateProject();
            tmrShow.Tick += tmrShow_Tick;
            tmrShow.Start();
        }

        private void tmrShow_Tick(object sender, EventArgs e)
        {
            tmrShow.Stop();
            controller.UpdateProject();
            tb_RealTime.Text = " Обновлено: " + System.DateTime.Now.ToLongTimeString();
        }


        private void deleteIssue(string check)
        {
            Action action = () =>
            {
                tmrShow.Stop();
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
                else if (check == "unknownError")
                    MessageBox.Show("Повторите попытку,неизвестная ошибка!", "Неизвестная ошибка");
                tmrShow.Start();  
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
            
           
        }
        private void updateStatus(string check)
        {
            Action action = () =>
            {
                tmrShow.Stop();

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
                else if (check == "unknownError")
                    MessageBox.Show("Повторите попытку,неизвестная ошибка!", "Неизвестная ошибка");
                tmrShow.Start();
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
        private void apiKeyChanged(string check, bool checkapi)
        {
            Action action = () =>
            {
                tmrShow.Stop();
                if (check == "noError")
                {
                    mi_update.Enabled = true;
                    lastidproject = 0;
                    this.checkapi = checkapi;
                    cb_project.SelectedIndex = 0;
                    lv_issue.Items.Clear();
                    mi_info.Enabled = true;
                    controller.UpdateProject();
                }
                tmrShow.Start();
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();

        }

        public void projectsUpdated(List<Project> projects, string check, List<IssuePrioriti> priority, List<TrackerNew> tracker)
        {
            Action action = () =>
            {
                tmrShow.Stop();
                mi_info.Enabled = false;
                if (check == "noError")
                {
                    mi_update.Enabled = true;
                    tm_priority.DropDown.Items.Clear();

                    tm_tracker.DropDown.Items.Clear();

                    foreach (TrackerNew tr in tracker)
                    {
                        tm_tracker.DropDownItems.Add(tr.Name);
                    }
                    foreach (IssuePrioriti ip in priority)
                    {
                        tm_priority.DropDownItems.Add(ip.Name);

                    }

                    mi_info.Enabled = true;
                    for (int i = cb_project.Items.Count - 1; i >= 1; i--)
                    {
                        cb_project.Items.RemoveAt(i);
                        
                    }
                    idProject.Clear();
                    

                    foreach (Project project in projects)
                    {
                        if (project.Parent!=null)
                        {
                            cb_project.Items.Add(" └── " + project.Name);
                        }
                        else
                        cb_project.Items.Add(project.Name);
                        idProject.Add(project.Id);
                    }
                    int count=0;
                    bool checking= true;
                    foreach (Project project in projects)
                    {count++;
                        if (project.Id==lastidproject)
                        {
                            lastidproject = count;
                           checking = false;
                            break;
                            

                        }
                    }
                    if (checking==false)
                    cb_project.SelectedIndex = count;


                }
                else if (check == "errorKey")
                {
                    mi_update.Enabled = false;
                    new Form_Apikey().ShowDialog();
                }
                else if (check == "errorInternet")
                {
                    MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
                }
                else if (check == "unknownError")
                    MessageBox.Show("Повторите попытку,неизвестная ошибка!", "Неизвестная ошибка");
                tmrShow.Start();
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        public void issuesUpdated(List<Issue> issues, string check, string roles)
        {
            Action action = () =>
            {
                tmrShow.Stop();
                lv_issue.Items.Clear();
                tm_status.DropDown.Items.Clear();
                tm_apointed.DropDown.Items.Clear();
                if (check == "noError")
                {
                    List<StatusNew> liststatus = controller.StatusInfo();
                    lb_role.Visible = true;
                    
                    membershipslist = controller.MembershipInfo();
                    tm_apointed.DropDownItems.Add("Никому");
                    foreach (Membership mem in membershipslist)
                    {
                        if (mem.Member != null)
                            tm_apointed.DropDownItems.Add(mem.Member.Name);
                    }
                    if (roles == "Manager")
                    {
                        foreach (StatusNew st in liststatus)
                        {
                            tm_status.DropDownItems.Add(st.Name);
                        }
                        lb_role.Text = "Роль в проекте: Менеджер";
                        mi_newissue.Enabled = true;
                        tm_delete.Enabled = true;


                    }
                    else if (roles == "Developer")
                    {
                        foreach (StatusNew st in liststatus)
                        {
                            if (st.Name == "In Progress" || st.Name == "Resolved" || st.Name == "Feedback")
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
                    lv_issue.Enabled = true;
                    foreach (Issue issue in issues)
                    {
                        if (issue.Project.Id == idProject[cb_project.SelectedIndex - 1])
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
                else if (check == "unknownError")
                    MessageBox.Show("Повторите попытку,неизвестная ошибка!", "Неизвестная ошибка");
                tmrShow.Start();
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
        
        private void mi_exit_Click(object sender, EventArgs e)
        {

            if (checkapi == false)
            {
                Properties.Settings.Default.api_key = null;
                Properties.Settings.Default.Save();

            }
            Application.Exit();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkapi == false)
            {
                Properties.Settings.Default.api_key = null;
                Properties.Settings.Default.Save();

            }
        }

        private void mi_update_Click(object sender, EventArgs e)
        {
            tb_RealTime.Text =" Обновлено: " + System.DateTime.Now.ToLongTimeString();

            tmrShow.Stop();
            mi_update.Enabled = false;
            if (cb_project.SelectedIndex!=0)
            lastidproject = idProject[cb_project.SelectedIndex-1];

            controller.UpdateProject();
            tmrShow.Start();
        }

        private void mi_info_Click(object sender, EventArgs e)
        {
            tmrShow.Stop();
            MessageBox.Show(" id: " + Properties.Settings.Default.id + "\n\r" + " Логин: " + Properties.Settings.Default.Login + "\n\r" + " Имя: " + Properties.Settings.Default.FirstName + "\n\r" + " Фамилия: " + Properties.Settings.Default.LastName + "\n\r" + " mail: " + Properties.Settings.Default.mail + "\n\r" + " Дата создания: " + Properties.Settings.Default.CreatedOn + "\n\r" + " Последнее подключение: " + Properties.Settings.Default.LastLoginOn + "\n\r" + " Api ключ: " + Properties.Settings.Default.api_key, "Информация об аккаунте");
            tmrShow.Start();
        }

        private void cb_project_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cb_project.SelectedIndex == 0)
            {
                tmrShow.Stop();    
                lv_issue.Items.Clear();
                mi_ifoprj.Enabled = false;
                lb_role.Visible = false;
                mi_newissue.Enabled = false;
                lastidproject = 0;
            }
            else
            {
                tmrShow.Stop();
                
                controller.UpdateIssue(idProject[cb_project.SelectedIndex - 1]);
                lastidproject = idProject[cb_project.SelectedIndex - 1];
                mi_ifoprj.Enabled = true;
            }
            tmrShow.Start();
        }

        private void mi_ifoprj_Click(object sender, EventArgs e)
        {
            tmrShow.Stop();
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
            MessageBox.Show("id: " + project.Id + "\n\r" + "Название проекта: " + project.Name + "\n\r" + "Статус: " + project.Status + "\n\r" + "Идентификатор: " + project.Indentifier + "\n\r" + "Публичный: " + project.IsPublic + "\n\r" + "Дата изменения: " + project.UpdatedOn + "\n\r" + "Дата создания: " + project.CreatedOn + "\n\r" + manager + "\n\r" + developer, "Информация о проекте!");
            tmrShow.Start();
        }

        private void tm_infoIssue_Click(object sender, EventArgs e)
        {
            tmrShow.Stop();
            string assigned = "";
            Issue issue = controller.IssueInfo(lv_issue.FocusedItem.Text);
            if (issue.AssignedTo == null)
                assigned = "";
            else
                assigned = issue.AssignedTo.Name;
            MessageBox.Show("Название проекта: " + issue.Project.Name + "\n\r" + "Название задачи: " + issue.Subject + "\n\r" + "Трекер: " + issue.Tracker.Name + "\n\r" + "Статус: " + issue.Status.Name + "\n\r" + "Приоритет: " + issue.Priority.Name + "\n\r" + "Автор: " + issue.Author.Name + "\n\r" + "Назначена: " + assigned + "\n\r" + "Описание: " + issue.Description + "\n\r" + "Обновлено " + issue.CreatedOn, "Информация о задаче!");
            tmrShow.Start();
        }

        private void mi_newissue_Click(object sender, EventArgs e)
        {
            tmrShow.Stop();
            new Form_NewIssue(idProject[cb_project.SelectedIndex - 1]).ShowDialog();
            tmrShow.Start();
        }

        public void ResultJson(NewIssue newissue)
        {
            
                lv_issue.Enabled = false;
                tmrShow.Stop();
                Issue issue = controller.IssueInfo(lv_issue.FocusedItem.Text);
                int idissue = issue.Id;
                string jsonResult = JsonConvert.SerializeObject(new NewIssues() { NewIssue = newissue }, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });

                controller.StatusUpdate(jsonResult, idissue);
                tmrShow.Start();
            
        }
        private void tm_delete_Click(object sender, EventArgs e)
        {
            
                lv_issue.Enabled = false;   
                tmrShow.Stop();
                Issue issue = controller.IssueInfo(lv_issue.FocusedItem.Text);
                int idissue = issue.Id;
                controller.DeleteIssue(idissue);
                tmrShow.Start();
            
        }

        private void lv_issue_MouseClick(object sender, MouseEventArgs e)
        {
            tmrShow.Stop();
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
                    if (mb.Text == issue.Priority.Name)
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
            else
            tmrShow.Start();
        }

        private void tm_status_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            tmrShow.Stop();
            List<StatusNew> liststatus = controller.StatusInfo();
            NewIssue newissue = new NewIssue();
            foreach (StatusNew st in liststatus)
            {
                if (st.Name == e.ClickedItem.Text)
                {
                    newissue.StatusId = st.Id;
                    break;
                }

            }
            
            ResultJson(newissue);
            tmrShow.Start();
        }

        private void tm_priority_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            tmrShow.Stop();
            NewIssue newissue = new NewIssue();
            List<IssuePrioriti> listpriority = controller.PriorityInfo();
            foreach (IssuePrioriti pr in listpriority)
            {
                if (pr.Name == e.ClickedItem.Text)
                {
                    newissue.PriorityId = pr.Id;
                    break;
                }
            }
            
            ResultJson(newissue);
            tmrShow.Start();
        }

        private void tm_apointed_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            tmrShow.Stop();
            NewIssue newissue = new NewIssue();
            membershipslist = controller.MembershipInfo();

            if (e.ClickedItem.Text == "Никому")
            {
                newissue.AssignedToId = " ";
            }
            else
                foreach (Membership mb in membershipslist)
                {
                    if (e.ClickedItem.Text == mb.Member.Name)
                        newissue.AssignedToId = Convert.ToString(mb.Member.Id);
                }
            ResultJson(newissue);
            tmrShow.Start();
        }

        private void tm_tracker_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            tmrShow.Stop();
            NewIssue newissue = new NewIssue();
            List<TrackerNew> listracker = controller.TrackerInfo();

            foreach (TrackerNew tr in listracker)
            {
                if (tr.Name == e.ClickedItem.Text)
                {
                    newissue.TrackerId = tr.Id;
                    break;
                }

            }
            ResultJson(newissue);
            tmrShow.Start();
        }

        private void tm_history_Click(object sender, EventArgs e)
        {
            if (lv_issue.FocusedItem != null)
            {
                tmrShow.Stop();
                Issue issue = controller.IssueInfo(lv_issue.FocusedItem.Text);
                new Form_HistoryIssue(issue.Id).ShowDialog();
                tmrShow.Start();
            }
        }

        private void lv_issue_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            tmrShow.Stop();
            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lv_issue.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lv_issue.Sorting == SortOrder.Ascending)
                    lv_issue.Sorting = SortOrder.Descending;
                else
                    lv_issue.Sorting = SortOrder.Ascending;
            }
            lv_issue.Sort();
            this.lv_issue.ListViewItemSorter = new ListViewItemComparer(e.Column,lv_issue.Sorting);
            tmrShow.Start();
        }
        class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            private SortOrder order;
            public ListViewItemComparer()
            {
                col = 0;
                order = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                        ((ListViewItem)y).SubItems[col].Text);
                if (order == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }
        }

        private void cb_project_MouseClick(object sender, MouseEventArgs e)
        {
            tmrShow.Stop();
        }

        private void tm_stap_Click(object sender, EventArgs e)
        {
            tmrShow.Stop();
            if (Properties.Settings.Default.api_key == "")
            {
                new Form_Apikey().ShowDialog();

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите поменять аккаунт?", "Внимание!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    new Form_Apikey().ShowDialog();
                }
            }
            tmrShow.Start();
        }

        

       
    }
}

