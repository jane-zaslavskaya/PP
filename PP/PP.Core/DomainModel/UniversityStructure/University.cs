using System.Collections.Generic;
using Newtonsoft.Json;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class University : BaseFullShortNameModel
    {
        [JsonProperty("faculties")]
        public List<Faculty> Faculties { get; set; }
    }
}