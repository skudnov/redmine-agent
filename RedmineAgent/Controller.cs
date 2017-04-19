﻿using System;
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
        
        public Action<string> apiKeyChanged;
        public Action<List<Project>,string> projectsUpdated;
        public Action<List<Issue>,string,string> issuesUpdated;
        public Action<List<TrackerNew>, List<StatusNew>, List<IssuePrioriti>, List<Membership>, string> UpdateFormNewIssue;
       
        
        
        private List<Project> projects;
        private List<Issue> issues;
        private List<Membership> membership;
        private User users;
        private List<TrackerNew> tracker;
        private List<StatusNew> status;
        private List<IssuePrioriti> issueprioriti;
      
      
        public void LoginApiKey(string apiKey)
        {
            if (CheckInternet.CheckTheInternet() == "Connected")
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/users/current.json");
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
                    Properties.Settings.Default.idname = users.Id;
                    Properties.Settings.Default.Save();
                    if (apiKeyChanged != null)
                        apiKeyChanged("noError");
                }
                catch 
                {
                        apiKeyChanged("errorKey");
                }
            }
            else
            {
                apiKeyChanged("errorInternet");
            }
        }

        public void UpdateProject()
        {
            if (CheckInternet.CheckTheInternet() == "Connected")
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/projects.json");
                    request.Method = "GET";
                    request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                    request.Accept = "application/json";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string jsonResult = streamReader.ReadToEnd();
                    response.Close();
                    streamReader.Close();
                    projects = JsonConvert.DeserializeObject<Projects>(jsonResult).ProjectsList;
                    if (projectsUpdated != null)
                        projectsUpdated(projects, "noError");
                }
                catch 
                {
                    projectsUpdated(null, "errorKey");
                }
            }
            else
            {
                projectsUpdated(null, "errorInternet");
            }
        }

        public void UpdateIssue(int projectId)
        {
            if (CheckInternet.CheckTheInternet() == "Connected")
            {
                try
                {
                    HttpWebRequest request;
                    HttpWebResponse response;
                    StreamReader streamReader;
                    string jsonResult;
                    request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/" + "issues.json?project_id=" + projectId);
                    request.Method = "GET";
                    request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                    request.Accept = "application/json";
                    response = (HttpWebResponse)request.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    jsonResult = streamReader.ReadToEnd();
                    response.Close();
                    streamReader.Close();
                    issues = JsonConvert.DeserializeObject<Issues>(jsonResult).IssuesList;
                    
                    request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/projects/" + projectId + "/memberships.json");
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
                    Membership rolesmember=null;
                    bool check = false;
                    foreach(Membership ol in membership)
                    {
                        if (ol.Member.Id == Properties.Settings.Default.idname)
                        {
                            rolesmember = ol;
                            check = true;
                            break;
                        }

                    }
                    if (!check)
                    {
                        issuesUpdated(issues,"noError",null);
                    }
                   else
                    foreach (Role role in rolesmember.Roles)
                     roles = role.Name;
                    if (issuesUpdated != null)
                        issuesUpdated(issues, "noError", roles);
                }
                catch
                {                    
                    issuesUpdated(null, "errorKey", null);
                }
            }
            else
            {
                apiKeyChanged("errorInternet");
            }
        }


        public void InfoNewIssue()
        {
            if (CheckInternet.CheckTheInternet() == "Connected")
            {
                try
                {
                    HttpWebRequest request;
                    HttpWebResponse response;
                    StreamReader streamReader;
                    string jsonResult;
                    request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/trackers.json");
                    request.Method = "GET";
                    request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                    request.Accept = "application/json";
                    response = (HttpWebResponse)request.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    jsonResult = streamReader.ReadToEnd();
                    response.Close();
                    streamReader.Close();
                    tracker = JsonConvert.DeserializeObject<Trackers>(jsonResult).TrackersList;

                    request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/issue_statuses.json");
                    request.Method = "GET";
                    request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                    request.Accept = "application/json";
                    response = (HttpWebResponse)request.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    jsonResult = streamReader.ReadToEnd();
                    response.Close();
                    streamReader.Close();
                    status = JsonConvert.DeserializeObject<Statues>(jsonResult).StatuesList;

                    request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/enumerations/issue_priorities.json");
                    request.Method = "GET";
                    request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                    request.Accept = "application/json";
                    response = (HttpWebResponse)request.GetResponse();
                    streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    jsonResult = streamReader.ReadToEnd();
                    response.Close();
                    streamReader.Close();
                    issueprioriti = JsonConvert.DeserializeObject<IssuePriorities>(jsonResult).IssuePrioritiesList;
                    if (UpdateFormNewIssue != null)
                        UpdateFormNewIssue(tracker, status, issueprioriti, membership, "noError");


                }
                catch
                {
                    issuesUpdated(null, "errorKey", null);
                }
            }
            else
            {
                apiKeyChanged("errorInternet");
            }

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
                if (issu.Subject==projectid)
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
                if (pr.Id==projectid)
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
        public TrackerNew TrackerInfo(string track)
        {
            TrackerNew tracker_info = null;
            foreach (TrackerNew tr in tracker)
            {
                if (tr.Name==track)
                {
                    tracker_info = tr;
                    break;
                }

            }
            return tracker_info;
        }

        public StatusNew StatusInfo(string stat)
        {
            StatusNew status_info = null;
            foreach (StatusNew st in status)
            {
                if (st.Name == stat)
                {
                    status_info = st;
                    break;
                }

            }
            return status_info;
        }
        public IssuePrioriti PriorityInfo(string prior)
        {
            IssuePrioriti priority_info = null;
            foreach (IssuePrioriti pr in issueprioriti)
            {
                if (pr.Name == prior)
                {
                    priority_info = pr;
                    break;
                }

            }
            return priority_info;
        }


       

    }
}
