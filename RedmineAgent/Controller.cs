using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RedmineAgent.Models;
using System.Windows.Forms;

namespace RedmineAgent
{
    class Controller
    {
       private List<Project> project;
      

        public void LoginApiKey(string apiKey)
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

            
           
            }
            catch (Exception g)
            {
                MessageBox.Show("ошибка логина", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
            }
        }

        public void UpgradeProject()
        {


        }

        public void UpgradeIssue()
        {
        }

        public void NewProjects()
        {
        }

        public void NewIssue()
        {
        }

    }
}
