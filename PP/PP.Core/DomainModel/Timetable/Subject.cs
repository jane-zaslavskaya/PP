using System.Collections.Generic;
using Newtonsoft.Json;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.Timetable
{
    public class Subject : BaseModel
    {
        [JsonProperty("brief")]
        public string Brief { get; set; }

        [JsonProperty("hours")]
        public List<Hour> Hours { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}