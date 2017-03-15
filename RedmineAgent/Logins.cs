using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Collections.Specialized;
using System.Web;
using RedmineAgent.Properties; //
using System.Runtime.Serialization.Json;

namespace RedmineAgent
{
    class Logins
    {
        string apikey = "";
        public Logins(string apikey)
        {
            this.apikey = apikey; 
        }

        public string Redmine()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Redmine-API-Key",apikey);
            UriBuilder builder = new UriBuilder("https", "exactprotest.plan.io", -1, "issues.json");
            NameValueCollection query = HttpUtility.ParseQueryString(builder.Query);
            query["project_id"] = "4";
            builder.Query = query.ToString();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, builder.Uri);
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> taskResponse = client.SendAsync(message);

            taskResponse.Wait();

            HttpResponseMessage response = taskResponse.Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(" response successful");

                Task<Stream> streamTask = response.Content.ReadAsStreamAsync();

                streamTask.Wait();

                if (streamTask.IsCompleted)
                {
                    Stream responseStream = streamTask.Result;


                    // Save to file
                    String result = null;

                    using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }

                    using (StreamWriter file = new StreamWriter("Result.txt"))
                    {
                        file.WriteLine(result);
                    }


                    //IDictionary<string, Issue> issues = parseIssueJson(responseStream);

                    //foreach (KeyValuePair<string, Issue> issuePair in issues)
                    //{
                    //    Console.WriteLine(issuePair.Key + "<-->" + issuePair.Value);
                    //}

                    //responseStream.Close();

                }
            }
            else
            {
                return(" response failed. Response status code: [" + response.StatusCode + "]");
            }

            return message.ToString();
        }



    }
}
