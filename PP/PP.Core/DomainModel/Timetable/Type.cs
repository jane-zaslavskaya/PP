using PP.Core.Data.Base;

namespace PP.Core.DomainModel.Timetable
{
    public class Type : BaseModel
    {

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string TypeName { get; set; }
    }
}