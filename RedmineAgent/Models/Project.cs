using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
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
