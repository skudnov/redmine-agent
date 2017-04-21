using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    public class Projects
    {
        [JsonProperty(PropertyName = "projects")]
        public List<Project> ProjectsList { get; set; }
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { set; get; }
        [JsonProperty(PropertyName = "offset")]
        public int Offset { set; get; }
        [JsonProperty(PropertyName = "limit")]
        public int Limit { set; get; }
    }
    public class Project
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "indentifier")]
        public string Indentifier { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
        [JsonProperty(PropertyName = "is_public")]
        public bool IsPublic { get; set; }
        [JsonProperty(PropertyName = "created_on")]
        public DateTime CreatedOn { get; set; }
        [JsonProperty(PropertyName = "updated_on")]
        public DateTime UpdatedOn { get; set; }
    }
}
