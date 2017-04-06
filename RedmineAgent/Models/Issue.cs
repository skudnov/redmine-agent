using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    public class Issue
    {
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


}
