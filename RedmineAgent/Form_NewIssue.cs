using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedmineAgent.Models;
using Newtonsoft.Json;

namespace RedmineAgent
{
    public partial class Form_NewIssue : Form
    {
        private Controller controller;
        int projectid;
        public List<Membership> membershipslist = new List<Membership>();

        public Form_NewIssue(int projectid)
        {

            InitializeComponent();

            this.projectid = projectid;
            controller = Program.controllerProgram;
            UpdateFormNewIssue();
            controller.issueLoading += UpdateIssueNew;
        }

        private void UpdateIssueNew(string cheсk)
        {
            Action action = () =>
            {

                if (cheсk == "noError")
                {
                    controller.UpdateIssue(projectid);
                    this.Close();

                }
                else if (cheсk == "errorKey")
                {
                    bt_newissue.Enabled = true;
                    bt_cancel.Enabled = true;
                    MessageBox.Show("Введенный api-key неправильный. Повторите ввод!", "Ошибка Api-key");
                    new Form_Apikey().ShowDialog();

                }
                else if (cheсk == "errorInternet")
                {
                    bt_newissue.Enabled = true;
                    bt_cancel.Enabled = true;
                    MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
                }

            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
        public void UpdateFormNewIssue()
        {
            List<StatusNew> liststatus = controller.StatusInfo();
            List<TrackerNew> listracker = controller.TrackerInfo();
            List<IssuePrioriti> listpriority = controller.PriorityInfo();
            membershipslist = controller.MembershipInfo();

            foreach (TrackerNew tracker in listracker)
            {
                cb_trackers.Items.Add(tracker.Name);
            }
            foreach (StatusNew st in liststatus)
            {
                if (st.Name == "New")
                    cb_status.Items.Add(st.Name);
            }
            foreach (IssuePrioriti ip in listpriority)
            {
                cb_priority.Items.Add(ip.Name);
            }

            foreach (Membership mb in membershipslist)
            {
                if (mb.Member != null)
                {
                    cb_assigned.Items.Add(mb.Member.Name);
                    cb_checkmember.Items.Add(mb.Member.Name);
                }
            }
            cb_trackers.SelectedIndex = 0;
            cb_status.SelectedIndex = 0;
            cb_priority.SelectedIndex = 0;
            cb_assigned.SelectedIndex = 0;
        }

      /*  private void UpdateFormNewIssue(List<TrackerNew> trackers, List<StatusNew> status, List<IssuePrioriti> issueprioriti, List<Membership> membership, string check)
        {
            Action action = () =>
            {

                if (check == "noError")
                {
                    foreach (TrackerNew tracker in trackers)
                    {
                        cb_trackers.Items.Add(tracker.Name);
                    }
                    foreach (StatusNew st in status)
                    {
                        if (st.Name == "New")
                            cb_status.Items.Add(st.Name);
                    }
                    foreach (IssuePrioriti ip in issueprioriti)
                    {
                        cb_priority.Items.Add(ip.Name);
                    }

                    foreach (Membership mb in membership)
                    {
                        if (mb.Member != null)
                        {
                            cb_assigned.Items.Add(mb.Member.Name);
                            cb_checkmember.Items.Add(mb.Member.Name);
                        }
                    }
                    cb_trackers.SelectedIndex = 0;
                    cb_status.SelectedIndex = 0;
                    cb_priority.SelectedIndex = 0;
                    cb_assigned.SelectedIndex = 0;
                }
                else
                    if (check == "errorKey")
                    {
                        bt_newissue.Enabled = true;
                        bt_cancel.Enabled = true;
                        MessageBox.Show("Введенный api-key неправильный. Повторите ввод!", "Ошибка Api-key");
                        new Form_Apikey().ShowDialog();
                    }
                    else if (check == "errorInternet")
                    {
                        bt_newissue.Enabled = true;
                        bt_cancel.Enabled = true;
                        MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
                    }

            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        } */

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_newissue_Click(object sender, EventArgs e)
        {
            bt_newissue.Enabled = false;
            bt_cancel.Enabled = false;
            if (tb_topic != null)
            {
                NewIssue newissue = new NewIssue();
                //Id проектa
                newissue.ProjectId = projectid;
                // Получение списка трекеров
                List<TrackerNew> listracker = controller.TrackerInfo();
               
                foreach (TrackerNew tr in listracker)
                {
                    if (tr.Name == cb_trackers.Text)
                    {
                        newissue.TrackerId = tr.Id;
                        break;
                    }

                }
              
                //Получение списка статусов
                List<StatusNew> liststatus = controller.StatusInfo();
               
                foreach (StatusNew st in liststatus)
                {
                    if (st.Name == cb_status.Text)
                    {
                        newissue.StatusId = st.Id;
                        break;
                    }

                }

                //Приоритет 

                List<IssuePrioriti> listpriority = controller.PriorityInfo();
                foreach (IssuePrioriti pr in listpriority)
                {
                    if (pr.Name == cb_priority.Text)
                    {
                        newissue.PriorityId = pr.Id;
                        break;
                    }
                }
              
                //Название темы
                newissue.Subject = tb_topic.Text;
                //Описание
                if (tb_description.Text != null)
                    newissue.Description = tb_description.Text;
                //Участники проекта
                membershipslist = controller.MembershipInfo();
                //Назначение задачи
                if (cb_assigned.SelectedIndex != 0)
                    foreach (Membership mb in membershipslist)
                    {
                        if (mb.Member.Name == cb_assigned.Text)
                        {
                            newissue.AssignedToId = Convert.ToString(mb.Member.Id);
                            break;
                        }
                    }
                //Публичная
                newissue.IsPrivate = cb_private.Checked;
                //Время
                if (cb_estimated_hours.SelectedIndex != -1)
                    newissue.EstimatedHours = cb_estimated_hours.SelectedIndex;

                List<string> memberis = new List<string>();
                if (cb_checkmember.CheckedItems.Count != 0)
                {
                    foreach (var check in cb_checkmember.CheckedItems)
                    {
                        foreach (Membership mb in membershipslist)
                        {
                            if (mb.Member.Name == check.ToString())
                            {
                                memberis.Add(Convert.ToString(mb.Member.Id));
                            }
                        }
                    }
                    newissue.WatcherUserIds = memberis;

                }
                //Преобразуем строку в формат json
                string jsonResult = JsonConvert.SerializeObject(new NewIssues() { NewIssue = newissue }, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                controller.LoadingIssue(jsonResult);
            }
            else
            {
                MessageBox.Show("Введите тему задачи!", "Ошибка");
            }
        }

        private void tb_topic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bt_newissue.PerformClick();
        }
    }
}
