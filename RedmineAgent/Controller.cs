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
       // int idName;
        

        private List<Project> projects;
        private List<Issue> issues;
        private List<Membership> membership;
        private User users;
      
      
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
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/" + "issues.json?project_id=" + projectId);
                    request.Method = "GET";
                    request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                    request.Accept = "application/json";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string jsonResult = streamReader.ReadToEnd();
                    response.Close();
                    streamReader.Close();
                    issues = JsonConvert.DeserializeObject<Issues>(jsonResult).IssuesList;

                    HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/projects/" + projectId + "/memberships.json");
                    request2.Method = "GET";
                    request2.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                    request2.Accept = "application/json";
                    HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                    StreamReader streamReader2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
                    string jsonResult2 = streamReader2.ReadToEnd();
                    response2.Close();
                    streamReader2.Close();
                    membership = JsonConvert.DeserializeObject<Memberships>(jsonResult2).MembershipsList;
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

        public void NewIssue()
        {
               
        }

        public User UserInfo()
        {
            return users;
        }
        public List<Issue> IssueInfo()
        {
            return issues;
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
       

    }
}
