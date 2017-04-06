using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    class Issues
    {
        [JsonProperty(PropertyName = "issues")]
        public List<Issue> IssuesList { get; set; }
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }
        [JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }
        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }
    }
}
