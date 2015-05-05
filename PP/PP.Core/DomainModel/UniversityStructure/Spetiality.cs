using System.Collections.Generic;
using Newtonsoft.Json;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class Spetiality : BaseFullShortNameModel
    {
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }
}