using Newtonsoft.Json;

namespace PP.Core.Data.Base
{
    public class BaseFullShortNameModel : BaseModel
    {
        [JsonProperty("full_name")]

        public string FullName { get; set; }

        [JsonProperty("short_name")]

        public string ShortName { get; set; }
    }
}