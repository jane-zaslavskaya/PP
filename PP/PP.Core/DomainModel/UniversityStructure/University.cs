using System.Collections.Generic;

namespace PP.Core.DomainModel.UniversityStructure
{
    public class University
    {
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public List<Faculty> Faculties { get; set; }    
    }
}