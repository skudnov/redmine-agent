using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    public class Memberships
    {
        [JsonProperty(PropertyName = "memberships")]
        public List<Membership> MembershipsList { get; set; }
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { set; get; }
        [JsonProperty(PropertyName = "offset")]
        public int Offset { set; get; }
        [JsonProperty(PropertyName = "limit")]
        public int Limit { set; get; }
    }
}
