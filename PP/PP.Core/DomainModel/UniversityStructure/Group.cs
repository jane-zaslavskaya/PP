using Newtonsoft.Json;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class Group : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}