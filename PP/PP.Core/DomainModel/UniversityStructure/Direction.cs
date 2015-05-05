using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class Direction : BaseFullShortNameModel
    {
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        [JsonProperty("specialities")]
        public List<Spetiality> Spetialities { get; set; }

        [JsonProperty("teachers")]
        public List<Teacher> Teachers { get; set; }
    }
}