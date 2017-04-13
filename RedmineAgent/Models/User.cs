using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    public class User
    {
        [JsonProperty (PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }
        [JsonProperty(PropertyName = "created_on")]
        public DateTime CreatedOn { get; set; }
        [JsonProperty(PropertyName = "last_login_on")]
        public DateTime LastLoginOn { get; set; }
        [JsonProperty(PropertyName = "api_key")]
        public string ApiKey { get; set; }
    
    }
}
