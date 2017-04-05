using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedmineAgent.Models
{
    class Projects
    {
        [JsonProperty(PropertyName = "projects")]
        public List <Project> ProjectsList { get; set; }
    }
}
