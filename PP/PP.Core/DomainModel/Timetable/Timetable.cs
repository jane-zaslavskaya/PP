using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PP.Core.DomainModel.UniversityStructure;

namespace PP.Core.DomainModel.Timetable
{
    public class Timetable
    {
        [JsonProperty("events")]
        public List<Event> Events { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        [JsonProperty("subjects")]
        public List<Subject> Subjects { get; set; }

        [JsonProperty("teachers")]
        public List<Teacher> Teachers { get; set; }

        [JsonProperty("types")]
        public List<Type> Types { get; set; }

        [JsonProperty("time-zone")]
        public string TimeZone { get; set; }
    }
}
