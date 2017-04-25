using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    public class Issues
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

    public class IssuesHistory
    {
        [JsonProperty(PropertyName = "issue")]
        public Issue IssueHistory { get; set; }
        
    }
    public class Issue
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "project")]
        public Project Project { get; set; }
        [JsonProperty(PropertyName = "tracker")]
        public Tracker Tracker { get; set; }
        [JsonProperty(PropertyName = "status")]
        public Status Status { get; set; }
        [JsonProperty(PropertyName = "priority")]
        public Priority Priority { get; set; }
        [JsonProperty(PropertyName = "author")]
        public Author Author { get; set; }
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "start_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "done_ratio")]
        public int DoneRatio { get; set; }
        [JsonProperty(PropertyName = "created_on")]
        public DateTime CreatedOn { get; set; }
        [JsonProperty(PropertyName = "updated_on")]
        public DateTime UpdatedOn { get; set; }
        [JsonProperty(PropertyName = "assigned_to")]
        public Assigned AssignedTo { get; set; }
        [JsonProperty(PropertyName = "journals")]
        public List<HistoryIssue> Journals { get; set; }
    }
    public class Tracker
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
    public class Status
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
    public class Priority
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Author
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
    public class Assigned
    {
         [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class HistoryIssue
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "user")]
        public UserHistory User { get; set; }
        [JsonProperty(PropertyName = "created_on")]
        public DateTime CreatedOn { get; set; }
        [JsonProperty(PropertyName = "details")]
        public List<DetailsHistory> Details { get; set; }
    }
    public class UserHistory
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
    public class DetailsHistory
    {
        [JsonProperty(PropertyName = "property")]
        public string Property { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "old_value")]
        public string OldValue { get; set; }
        [JsonProperty(PropertyName = "new_value")]
        public string NewValue { get; set; }
    }


}
