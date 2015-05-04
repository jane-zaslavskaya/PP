using PP.Core.Data.Base;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class Teacher : BaseEntity
    {
        public string FullName { get; set; }

        public string ShortName { get; set; }
    }
}