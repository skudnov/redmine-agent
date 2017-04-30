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
    public partial class Form_HistoryIssue : Form
    {
        private Controller controller;
        public int sortColumn = 0;
        public Form_HistoryIssue(int s)
        {
            InitializeComponent();
            controller = Program.controllerProgram;
            controller.HistoryIssueUpdate += IssueHistory;
            controller.HistoryIssue(s);
        }
        public List<Membership> membershipslist = new List<Membership>();

        private void IssueHistory(Issue historyissue, string check)
        {
            Action action = () =>
            {
                this.Text = "История задачи - "+ historyissue.Subject;
                List<StatusNew> liststatus = controller.StatusInfo();
                List<TrackerNew> listracker = controller.TrackerInfo();
                List<IssuePrioriti> listpriority = controller.PriorityInfo();
                membershipslist = controller.MembershipInfo();
                foreach (var jd in historyissue.Journals)
                {
                    ListViewItem lvi = new ListViewItem(jd.User.Name);
                    lvi.SubItems.Add(jd.CreatedOn.ToShortDateString() + " - " + jd.CreatedOn.ToShortTimeString());
                    string Old = "";
                    string New = "";
                    foreach (var det in jd.Details)
                    {
                        if (det.Name == "status_id")
                        {
                            foreach (StatusNew st in liststatus)
                            {
                                if (Convert.ToInt32(det.OldValue) == st.Id)
                                {
                                    Old = st.Name;
                                }
                                else if (Convert.ToInt32(det.NewValue) == st.Id)
                                {
                                    New = st.Name;
                                }
                            }
                            lvi.SubItems.Add("Статус: " + Old + " на: " + New);
                        }
                        else if (det.Name == "tracker_id")
                        {
                            foreach (TrackerNew st in listracker)
                            {
                                if (Convert.ToInt32(det.OldValue) == st.Id)
                                {
                                    Old = st.Name;
                                }
                                else if (Convert.ToInt32(det.NewValue) == st.Id)
                                {
                                    New = st.Name;
                                }
                            }
                            lvi.SubItems.Add("Трекер: " + Old + " на: " + New);
                        }
                        else if (det.Name == "priority_id")
                        {
                            foreach (IssuePrioriti st in listpriority)
                            {
                                if (Convert.ToInt32(det.OldValue) == st.Id)
                                {
                                    Old = st.Name;
                                }
                                else if (Convert.ToInt32(det.NewValue) == st.Id)
                                {
                                    New = st.Name;
                                }
                            }
                            lvi.SubItems.Add("Приоритет: " + Old + " на: " + New);
                        }
                        else if (det.Name == "assigned_to_id")
                        {
                            foreach (Membership st in membershipslist)
                            {
                                if (st.Member != null)
                                {
                                    if (Convert.ToInt32(det.OldValue) == st.Member.Id)
                                    {
                                        Old = st.Member.Name;
                                    }
                                    else
                                        if (Convert.ToInt32(det.NewValue) == st.Member.Id)
                                        {
                                            New = st.Member.Name;
                                        }
                                }
                            }
                            if (Old == "")
                                Old = "Никому";
                            else if (New == "")
                                New = "Никому";
                            lvi.SubItems.Add("Назначен: " + Old + " на: " + New);
                        }
                        else if (det.Name == "subject")
                        {
                            Old = det.OldValue;
                            New = det.NewValue;
                            lvi.SubItems.Add("Название: " + Old + " на: " + New);
                        }
                        else if (det.Name == "is_private")
                        {
                            if (det.OldValue == "0")
                                Old = "Нет";
                            else Old = "Да";
                            if (det.NewValue == "0")
                                New = "Нет";
                            else
                                New = "Да";
                            lvi.SubItems.Add("Частная: " + Old + " на: " + New);
                        }
                        else if (det.Name == "estimated_hours")
                        {
                            Old = det.OldValue;
                            New = det.NewValue;
                            if (Old == null)
                                Old = "(Нет оценки)";
                            if (New == null)
                                New = "(Нет оценки)";
                            lvi.SubItems.Add("Оценка трудозатрат: " + Old + " на: " + New);
                        }
                        else if (det.Name == "project_id")
                        {
                            Project project = controller.ProjectInfo(Convert.ToInt32(det.OldValue));
                            if (project.Id == (Convert.ToInt32(det.OldValue)))
                            {
                                Old = project.Name;
                            }
                            if (Convert.ToInt32(det.NewValue) == historyissue.Project.Id)
                            {
                                New = historyissue.Project.Name;
                            }
                            lvi.SubItems.Add("Проект: " + Old + " на: " + New);
                        }
                        else if (det.Name == "start_date")
                        {
                            Old = det.OldValue;
                            New = det.NewValue;
                            lvi.SubItems.Add("Дата начала: " + Old + " на: " + New);
                        }
                        else if (det.Name == "due_date")
                        {
                            Old = det.OldValue;
                            New = det.NewValue;
                            if (Old == null)
                                Old = "(Нет даты)";
                            if (New == null)
                                New = "(Нет даты)";
                            lvi.SubItems.Add("Дата завершения: " + Old + " на: " + New);
                        }
                        else if (det.Name == "done_ratio")
                        {
                            Old = det.OldValue;
                            New = det.NewValue;
                            if (Old == null)
                                Old = "0";
                            if (New == null)
                                New = "0";
                            lvi.SubItems.Add("Готовность: " + Old + " на: " + New);
                        }
                        else if (det.Name == "description")
                        {
                            Old = det.OldValue;
                            New = det.NewValue;
                            if (Old == null)
                                Old = "нет описания";
                            if (New == null)
                                New = "нет описания";
                            lvi.SubItems.Add("Описание: " + Old + " на: " + New);
                        }
                    }
                    lv_history.Items.Add(lvi);
                }
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void lv_history_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lv_history.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lv_history.Sorting == SortOrder.Ascending)
                    lv_history.Sorting = SortOrder.Descending;
                else
                    lv_history.Sorting = SortOrder.Ascending;
            }
            lv_history.Sort();
            this.lv_history.ListViewItemSorter = new ListViewItemComparer(e.Column, lv_history.Sorting);
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
                // Определение того, является ли порядок сортировки порядком "по
                // убыванию".
                if (order == SortOrder.Descending)
                    // Изменение значения, возвращенного String.Compare, на
                    // противоположное.
                    returnVal *= -1;
                return returnVal;
            }
        }

    }
}
