using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RedmineAgent.Models;

namespace RedmineAgent
{
    public class Controller
    {
        string redminehost = "http://student-rm.exactpro.com/";

        public Action<string, bool> apiKeyChanged;

        public Action<List<Project>, string, List<IssuePrioriti>, List<TrackerNew>> projectsUpdated;

        public Action<List<Issue>, string, string> issuesUpdated;

        public Action<string> issueLoading;

        public Action<string> UpdateStatus;

        public Action<string> OneIssueDelete;

        public Action<Issue, string> HistoryIssueUpdate;


        private List<Project> projects;

        private List<Issue> issues;

        private List<Membership> membership;

        private User users;

        private List<TrackerNew> tracker;

        private List<StatusNew> status;

        private List<IssuePrioriti> issueprioriti;

        private Issue historyissue;

        public void LoginApiKey(string apiKey, bool check)
        {
            new Thread(delegate()
               {
                   if (CheckInternet.CheckTheInternet() == "Connected")
                   {
                       try
                       {
                           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(redminehost+"users/current.json");
                           request.Method = "GET";
                           request.Headers.Add("X-Redmine-API-Key", apiKey);
                           request.Accept = "application/json";
                           HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                           StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                           string jsonResult = streamReader.ReadToEnd();
                           response.Close();
                           streamReader.Close();
                           users = JsonConvert.DeserializeObject<Users>(jsonResult).UserInfo;
                           Properties.Settings.Default.api_key = apiKey;
                           Properties.Settings.Default.id = users.Id;
                           Properties.Settings.Default.CreatedOn = users.CreatedOn;
                           Properties.Settings.Default.FirstName = users.FirstName;
                           Properties.Settings.Default.Login = users.Login;
                           Properties.Settings.Default.LastName = users.LastName;
                           Properties.Settings.Default.mail = users.Mail;
                           Properties.Settings.Default.LastLoginOn = users.LastLoginOn;
                           Properties.Settings.Default.Save();
                           if (apiKeyChanged != null)
                               apiKeyChanged("noError", check);
                       }
                       catch (Exception g)
                       {
                           if (g.Message.Contains("401"))
                           apiKeyChanged("errorKey", check);
                           else
                               apiKeyChanged("unknownError", check);
                       }
                   }
                   else
                   {
                       apiKeyChanged("errorInternet", check);
                   }
               }).Start();
        }

        public void UpdateProject()
        {
            new Thread(delegate()
               {
                   if (CheckInternet.CheckTheInternet() == "Connected")
                   {
                       try
                       {
                           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(redminehost + "projects.json");
                           request.Method = "GET";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.Accept = "application/json";
                           HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                           StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                           string jsonResult = streamReader.ReadToEnd();
                           response.Close();
                           streamReader.Close();
                           projects = JsonConvert.DeserializeObject<Projects>(jsonResult).ProjectsList;
                           List<Project> projectactive = new List<Project>();
                           foreach (Project project in projects)
                           {
                               if ((project.Status!=5))
                                   if ((project.Status != 6))
                               {
                               request = (HttpWebRequest)WebRequest.Create(redminehost + "projects/" + project.Id + "/memberships.json");
                               request.Method = "GET";
                               request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                               request.Accept = "application/json";
                               response = (HttpWebResponse)request.GetResponse();
                               streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                               jsonResult = streamReader.ReadToEnd();
                               response.Close();
                               streamReader.Close();
                               membership = JsonConvert.DeserializeObject<Memberships>(jsonResult).MembershipsList;
                               bool check = false;
                               foreach (Membership ol in membership)
                               {
                                   if (ol.Member.Id == Properties.Settings.Default.id)
                                   {
                                       check = true;
                                       break;
                                   }
                               }
                               if (check == true)
                               {
                                   projectactive.Add(project);
                               }
                           }
                           }

                           request = (HttpWebRequest)WebRequest.Create(redminehost+"issue_statuses.json");
                           request.Method = "GET";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.Accept = "application/json";
                           response = (HttpWebResponse)request.GetResponse();
                           streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                           jsonResult = streamReader.ReadToEnd();
                           response.Close();
                           streamReader.Close();
                           status = JsonConvert.DeserializeObject<Statues>(jsonResult).StatuesList;

                           request = (HttpWebRequest)WebRequest.Create(redminehost +"enumerations/issue_priorities.json");
                           request.Method = "GET";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.Accept = "application/json";
                           response = (HttpWebResponse)request.GetResponse();
                           streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                           jsonResult = streamReader.ReadToEnd();
                           response.Close();
                           streamReader.Close();
                           issueprioriti = JsonConvert.DeserializeObject<IssuePriorities>(jsonResult).IssuePrioritiesList;

                           request = (HttpWebRequest)WebRequest.Create(redminehost + "trackers.json");
                           request.Method = "GET";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.Accept = "application/json";
                           response = (HttpWebResponse)request.GetResponse();
                           streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                           jsonResult = streamReader.ReadToEnd();
                           response.Close();
                           streamReader.Close();
                           tracker = JsonConvert.DeserializeObject<Trackers>(jsonResult).TrackersList;

                           if (projectsUpdated != null)
                               projectsUpdated(projectactive, "noError", issueprioriti, tracker);
                       }
                       catch (Exception g)
                       {
                           if (g.Message.Contains("401"))
                               projectsUpdated(null, "errorKey", null, null);
                           else
                               projectsUpdated(null,"unknownError",null,null);
                       }
                      
                   }
                   else
                   {
                       projectsUpdated(null, "errorInternet", null, null);
                   }
               }).Start();
        }

        public void UpdateIssue(int projectId)
        {
            new Thread(delegate()
               {
                   if (CheckInternet.CheckTheInternet() == "Connected")
                   {
                       try
                       {
                           HttpWebRequest request;
                           HttpWebResponse response;
                           StreamReader streamReader;
                           string jsonResult;
                           request = (HttpWebRequest)WebRequest.Create(redminehost + "issues.json?project_id=" + projectId);
                           request.Method = "GET";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.Accept = "application/json";
                           response = (HttpWebResponse)request.GetResponse();
                           streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                           jsonResult = streamReader.ReadToEnd();
                           response.Close();
                           streamReader.Close();
                           issues = JsonConvert.DeserializeObject<Issues>(jsonResult).IssuesList;                          

                           request = (HttpWebRequest)WebRequest.Create(redminehost+"projects/" + projectId + "/memberships.json");
                           request.Method = "GET";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.Accept = "application/json";
                           response = (HttpWebResponse)request.GetResponse();
                           streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                           jsonResult = streamReader.ReadToEnd();
                           response.Close();
                           streamReader.Close();
                           membership = JsonConvert.DeserializeObject<Memberships>(jsonResult).MembershipsList;
                           string roles = "";
                           Membership rolesmember = null;
                           foreach (Membership ol in membership)
                           {
                               if (ol.Member.Id == Properties.Settings.Default.id)
                               {
                                   rolesmember = ol;
                                   break;
                               }

                           }
                           foreach (Role role in rolesmember.Roles)
                               roles = role.Name;
                           if (issuesUpdated != null)
                               issuesUpdated(issues, "noError", roles);
                       }
                       catch (Exception g)
                       {
                           if (g.Message.Contains("401"))
                               issuesUpdated(null, "errorKey", null);
                           else
                               issuesUpdated(null, "unknownError", null);
                       }
                      
                   }
                   else
                   {
                       issuesUpdated(null, "errorInternet", null);
                   }
               }).Start();
        }

        

        public User UserInfo()
        {
            return users;
        }

        public Issue IssueInfo(string projectid)
        {
            Issue infoissue = null;
            foreach (Issue issu in issues)
            {
                if (issu.Subject == projectid)
                {
                    infoissue = issu;
                    break;
                }
            }
            return infoissue;
        }

        public Project ProjectInfo(int projectid)
        {
            Project project_info = null;
            foreach (Project pr in projects)
            {
                if (pr.Id == projectid)
                {
                    project_info = pr;
                    break;
                }

            }
            return project_info;
        }

        public List<Membership> MembershipInfo()
        {
            return membership;
        }

        public List<TrackerNew> TrackerInfo()
        {
            return tracker;

        }

        public List<StatusNew> StatusInfo()
        {
            return status;
        }

        public List<IssuePrioriti> PriorityInfo()
        {
            return issueprioriti;
        }

        public void LoadingIssue(string jsonResult)
        {
            new Thread(delegate()
               {
                   if (CheckInternet.CheckTheInternet() == "Connected")
                   {
                       try
                       {
                           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(redminehost+"issues.json");
                           request.Method = "POST";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.ContentType = "application/json";
                           StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
                           streamWriter.Write(jsonResult);
                           streamWriter.Flush();
                           HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                           streamWriter.Close();
                           response.Close();
                           if (issueLoading != null)
                               issueLoading("noError");
                       }
                       catch (Exception g)
                       {
                           if (g.Message.Contains("401"))
                               issueLoading("errorKey");
                           else
                               issueLoading("unknownError");
                       }
                      
                   }
                   else
                   {
                       issueLoading("errorInternet");
                   }
               }).Start();
        }

        public void StatusUpdate(string jsonResult, int issueid)
        {
            new Thread(delegate()
               {
                   if (CheckInternet.CheckTheInternet() == "Connected")
                   {
                       try
                       {
                           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(redminehost+"issues/" + issueid + ".json");
                           request.Method = "PUT";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.ContentType = "application/json";
                           StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
                           streamWriter.Write(jsonResult);
                           streamWriter.Flush();
                           HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                           streamWriter.Close();
                           response.Close();
                           if (UpdateStatus != null)
                               UpdateStatus("noError");
                       }
                       catch (Exception g)
                       {
                           if (g.Message.Contains("401"))
                               UpdateStatus("errorKey");
                           else
                               UpdateStatus("unknownError");
                       }
                      
                   }
                   else
                   {
                       UpdateStatus("errorInternet");
                   }
               }).Start();
        }

        public void DeleteIssue(int issueid)
        {
            new Thread(delegate()
               {
                   if (CheckInternet.CheckTheInternet() == "Connected")
                   {
                       try
                       {
                           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(redminehost+"issues/" + issueid + ".json");
                           request.Method = "DELETE";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.ContentType = "application/json";
                           HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                           response.Close();
                           if (OneIssueDelete != null)
                               OneIssueDelete("noError");
                       }
                       catch (Exception g)
                       {
                           if (g.Message.Contains("401"))
                               OneIssueDelete("errorKey");
                           else
                               OneIssueDelete("unknownError");
                       }

                      
                   }
                   else
                   {
                       OneIssueDelete("errorInternet");

                   }
               }).Start();
        }

        public void HistoryIssue(int issueid)
        {
            new Thread(delegate()
               {
                   if (CheckInternet.CheckTheInternet() == "Connected")
                   {
                       try
                       {
                           HttpWebRequest request;
                           HttpWebResponse response;
                           StreamReader streamReader;
                           string jsonResult = "";
                           request = (HttpWebRequest)WebRequest.Create(redminehost+"issues/" + issueid + ".json?include=journals");
                           request.Method = "GET";
                           request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                           request.Accept = "application/json";
                           response = (HttpWebResponse)request.GetResponse();
                           streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                           jsonResult = streamReader.ReadToEnd();
                           response.Close();
                           streamReader.Close();
                           historyissue = JsonConvert.DeserializeObject<IssuesHistory>(jsonResult).IssueHistory;

                           if (HistoryIssueUpdate != null)
                               HistoryIssueUpdate(historyissue, "noError");
                       }
                       catch (Exception g)
                       {
                           if (g.Message.Contains("401"))
                               HistoryIssueUpdate(null,"errorKey");
                           else
                               HistoryIssueUpdate(null,"unknownError");
                       }                       
                   }
                   else
                   {
                       HistoryIssueUpdate(null, "errorInternet");
                   }
               }).Start();
        }
    }
}
