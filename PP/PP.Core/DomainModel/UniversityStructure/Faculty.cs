using System.Collections.Generic;
using Newtonsoft.Json;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class Faculty : BaseModel
    {
        [JsonProperty("directions")]
        public List<Direction> Directions { get; set; }

        [JsonProperty("departments")]
        public List<Direction> Departments { get; set; }
    }
}