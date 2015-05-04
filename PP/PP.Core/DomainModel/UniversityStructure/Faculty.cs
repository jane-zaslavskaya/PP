using System.Collections.Generic;
using PP.Core.Data.Base;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class Faculty : BaseEntity
    {
        public List<Direction> Directions { get; set; }

        public List<Direction> Departments { get; set; }
    }
}