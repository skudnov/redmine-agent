using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    public class Users
    {
        [JsonProperty(PropertyName = "user")]
        public User UserInfo { get; set; }
      
      }
}
