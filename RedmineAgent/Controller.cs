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
        public Action apiKeyChanged;
        public Action<List<Project>> projectsUpdated;
        public Action<List<Issue>> issuesUpdated;

        private List<Project> projects;
        private List<Issue> issues;
        
        public void LoginApiKey(string apiKey)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/users/current.json");
                request.Method = "GET";
                request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                request.Accept = "application/json";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string jsonResult = streamReader.ReadToEnd();
                response.Close();
                streamReader.Close();
                Properties.Settings.Default.api_key = apiKey;
                Properties.Settings.Default.Save();
                if (apiKeyChanged != null)
                    apiKeyChanged();
            }
            catch (Exception g)
            {
                
            }
        }

        public void UpdateProject()
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
                    projectsUpdated(projects);
            }
            catch (Exception g)
            {
                
            }
        }

        public void UpdateIssue(int projectId)
        {
             try
            {
                // /issues.json?project_id=2
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/" + "issues.json?project_id="+projectId);
                request.Method = "GET";
                request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                request.Accept = "application/json";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string jsonResult = streamReader.ReadToEnd();
                response.Close();
                streamReader.Close();
                issues = JsonConvert.DeserializeObject<Issues>(jsonResult).IssuesList;
                
                if (issuesUpdated != null)
                    issuesUpdated(issues);


            }
            catch (Exception g)
            {
              

            }
        }

        public void NewProject()
        {
        }

        public void NewIssue()
        {
        }

    }
}
