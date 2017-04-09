using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
 public class Membership
    {
            [JsonProperty(PropertyName = "id")]
            public int Id { set; get; }
            [JsonProperty(PropertyName = "project")]
            public Project Project { set; get; }
            [JsonProperty(PropertyName =  "user")]
            public Member Member { set; get; }
            [JsonProperty(PropertyName =  "roles")]
            public List<Role> Roles { set; get; }
    }
    

        public class Member
        {
            [JsonProperty(PropertyName = "id")]
            public int Id { set; get; }
            [JsonProperty(PropertyName = "name")]
            public string Name { set; get; }
        }

        public class Role
        {
            [JsonProperty(PropertyName = "id")]
            public int ID { set; get; }
            [JsonProperty(PropertyName =  "name")]
            public string Name { set; get; }
        }
    }

