using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class CistUniversity
    {
        [JsonProperty("university")]
        public University University { get; set; }
    }
}
