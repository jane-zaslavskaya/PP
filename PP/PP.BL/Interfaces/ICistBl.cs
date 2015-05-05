using System;
using System.Collections.Generic;
using PP.Core.DomainModel.UniversityStructure;

namespace PP.BL.Interfaces
{
    public interface ICistBl
    {
        List<Group> GetAllGroups();

        string GetTimetableForGroup(string groupName);

        string GetTimetableForGroup(string groupName, DateTime startFrom);

        string GetTimetableForGroup(string groupName, DateTime from, DateTime to);
    }
}