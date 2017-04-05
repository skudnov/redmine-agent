using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    class User
    {
        [JsonProperty (PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }
        [JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }
        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }
        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }
        [JsonProperty(PropertyName = "created_on")]
        public DateTime Created_on { get; set; }
        [JsonProperty(PropertyName = "last_login_on")]
        public DateTime Last_login_on { get; set; }
        [JsonProperty(PropertyName = "apikey")]
        public string Apikey { get; set; }
    
    }
}
