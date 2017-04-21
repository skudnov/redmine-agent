using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    public class NewStatus
    {
        [JsonProperty(PropertyName = "status_id")]
        public int StatusId { get; set; } 
    }
    public class NewStatues
    {
        [JsonProperty(PropertyName = "issue")]
        public NewStatus NewIssue { get; set; }
    }

    public class NewIssues
    {
        [JsonProperty(PropertyName = "issue")]
        public NewIssue NewIssue { get; set; }
    }
   public class NewIssue
    {
       [JsonProperty(PropertyName = "project_id")]
       public int ProjectId { get; set; }
       [JsonProperty(PropertyName = "tracker_id")]
       public int TrackerId { get; set; }
       [JsonProperty(PropertyName = "status_id")]
       public int StatusId { get; set; } 
       [JsonProperty(PropertyName = "priority_id")]
       public int PriorityId { get; set; }
       [JsonProperty(PropertyName = "subject")]
       public string Subject { get; set; }
       [JsonProperty(PropertyName = "description")]
       public string Description { get; set; }
       [JsonProperty(PropertyName = "assigned_to_id")]
       public int AssignedToId { get; set; }
       [JsonProperty(PropertyName = "watcher_user_ids")]
       public List<string> WatcherUserIds { get; set; }///?????
       [JsonProperty(PropertyName = "is_private")]
       public bool IsPrivate { get; set; }
       [JsonProperty(PropertyName = "estimated_hours")]
       public int EstimatedHours { get; set; }//????

    }

}
