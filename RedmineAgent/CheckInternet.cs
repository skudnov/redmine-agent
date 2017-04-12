using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace RedmineAgent
{
    public class CheckInternet
    {


        public static string CheckTheInternet()
        {
           try
           {
               WebClient Client = new WebClient();
               String Response = Client.DownloadString("http://www.google.com");
               return "Connected";
           }
            catch
           {
                return "noconnected";
           }
        }

    }
}
