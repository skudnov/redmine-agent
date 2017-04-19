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

namespace RedmineAgent
{
    public partial class Form_NewIssue : Form
    {
        private Controller controller;
        int projectid;
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
                if (st.Name=="New")
                cb_status.Items.Add(st.Name);
            }
            foreach (IssuePrioriti ip in issueprioriti)
            {
                cb_priority.Items.Add(ip.Name);
            }

            foreach (Membership mb in membership)
            {
                cb_assigned.Items.Add(mb.Member.Name);
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
            if (tb_topic!=null)
            {
                NewIssue newissue = new NewIssue();
                newissue.ProjectId = projectid;
                TrackerNew track = controller.TrackerInfo(cb_trackers.Text);
                newissue.TrackerId = track.Id;
                StatusNew stat = controller.StatusInfo(cb_status.Text);
                newissue.StatusId = stat.Id;
                IssuePrioriti prior = controller.PriorityInfo(cb_priority.Text);
                newissue.PriorityId = prior.Id;
                newissue.Subject = tb_topic.Text;
                newissue.Description = tb_description.Text;

                

            }
            else
            {
                MessageBox.Show("Введите тему задачи!", "Ошибка");
            }

        }

       

    

      

      
    }
}
