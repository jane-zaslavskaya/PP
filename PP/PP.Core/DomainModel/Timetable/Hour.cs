using System.Collections.Generic;
using Newtonsoft.Json;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.Timetable
{
    public class Hour : BaseModel
    {
        [JsonProperty("teachers")]
        public List<long> Teachers { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("val")]
        public int Value { get; set; }
    }
}