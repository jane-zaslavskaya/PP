using System.Collections.Generic;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class Spetiality : BaseEntity
    {
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public List<Group> Groups { get; set; }
    }
}