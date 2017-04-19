using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
   public class IssuePriorities
    {
         [JsonProperty("issue_priorities")]
        public List<IssuePrioriti> IssuePrioritiesList { set; get; }
    }

    public class IssuePrioriti
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "is_default")]
        public bool IsClosed { get; set; }
    }
}
