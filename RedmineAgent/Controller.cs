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
        public Action<string> apiKeyChanged;
        public Action<List<Project>,string> projectsUpdated;
        public Action<List<Issue>,string,string> issuesUpdated;
       // int idName;
        

        private List<Project> projects;
        private List<Issue> issues;
        private List<Membership> membership;
      
        
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
                    User users = JsonConvert.DeserializeObject<Users>(jsonResult).UserInfo;
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
                catch (Exception g)
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
                
                
                

                // http://student-rm.exactpro.com/projects/5/memberships.json

                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://student-rm.exactpro.com/projects/"+projectId+"/memberships.json");
                request2.Method = "GET";
                request2.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                request2.Accept = "application/json";
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                StreamReader streamReader2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
                string jsonResult2 = streamReader2.ReadToEnd();
                response2.Close();
                streamReader2.Close();
                membership = JsonConvert.DeserializeObject<Memberships>(jsonResult2).MembershipsList;
                Membership memberships = membership.Single(x => x.Member.Id == Properties.Settings.Default.idname);
              
                string roles="";
                 foreach (Role role in memberships.Roles)
                     roles = role.Name;

                if (issuesUpdated != null)
                    issuesUpdated(issues, "noError",roles);
            }
            catch (Exception g)
            {
                if (g.Message.Contains("401"))
                    issuesUpdated(null,"errorKey",null);
                else if (g.Message.Contains("Невозможно разрешить удаленное имя: 'student-rm.exactpro.com"))
                {
                    apiKeyChanged("errorInternet");
                }
               
            }
              
            }
            else
            {
                apiKeyChanged("errorInternet");
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
