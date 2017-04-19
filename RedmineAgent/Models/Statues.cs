using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
   public class Statues
    {
         [JsonProperty("issue_statuses")]
        public List<StatusNew> StatuesList { set; get; }
    }
    public class StatusNew
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "is_closed")]
        public bool IsClosed { get; set; }
    }
}
