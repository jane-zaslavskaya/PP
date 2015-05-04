using System.Collections.Generic;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class Direction : BaseEntity
    {
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public List<Group> Groups { get; set; }

        public List<Spetiality> Spetialities { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}