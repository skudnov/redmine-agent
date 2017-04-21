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
            this.projectid = projectid;
            InitializeComponent();
            controller = Program.controllerProgram;
            controller.UpdateFormNewIssue += UpdateFormNewIssue;
            controller.InfoNewIssue();
            cb_trackers.SelectedIndex = 0;
            cb_status.SelectedIndex = 0;
            //cb_readiness.SelectedIndex = 0;
            cb_priority.SelectedIndex = 0;
            cb_assigned.SelectedIndex = 0;
            controller.issueLoading += UpdateIssueNew;

        }
        private void UpdateIssueNew(string cheсk)
        {
            if (cheсk == "noError")
            {
                controller.UpdateIssue(projectid);
                this.Close();
            }
            else if (cheсk == "errorKey")
            {
                MessageBox.Show("Введенный api-key неправильный. Повторите ввод!", "Ошибка Api-key");
                new Form_Apikey().ShowDialog();

            }
            else if (cheсk == "errorInternet")
            {
                MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
            }
        }
        private void UpdateFormNewIssue(List<TrackerNew> trackers, List<StatusNew> status, List<IssuePrioriti> issueprioriti, List<Membership> membership, string check)
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

            }
            else
                if (check == "errorKey")
                {
                    MessageBox.Show("Введенный api-key неправильный. Повторите ввод!", "Ошибка Api-key");
                    new Form_Apikey().ShowDialog();
                }
                else if (check == "errorInternet")
                {
                    MessageBox.Show("Проверьте подключение к интернету!", "Ошибка");
                }

        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_newissue_Click(object sender, EventArgs e)
        {
            if (tb_topic != null)
            {
                NewIssue newissue = new NewIssue();
                //Id проекте
                newissue.ProjectId = projectid;
                // Получение списка трекеров
                TrackerNew track = controller.TrackerInfo(cb_trackers.Text);
                newissue.TrackerId = track.Id;
                //Получение списка статусов
                StatusNew stat = controller.StatusInfo(cb_status.Text);
                newissue.StatusId = stat.Id;
                //Приоритет 
                IssuePrioriti prior = controller.PriorityInfo(cb_priority.Text);
                newissue.PriorityId = prior.Id;
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
                            newissue.AssignedToId = mb.Member.Id;
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
                            if (mb.Member.Name == check)
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














    }
}
