using Newtonsoft.Json;

namespace PP.Core.Data.Base
{
    public class BaseModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}