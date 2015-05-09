using System;
using System.Collections.Generic;
using PP.Core.DomainModel.Timetable;
using PP.Core.DomainModel.UniversityStructure;

namespace PP.BL.Interfaces
{
    public interface ICistBl
    {
        List<Group> GetAllGroups();

        Timetable GetTimetableForGroup(string groupName);

        Timetable GetTimetableForGroup(string groupName, DateTime startFrom);

        Timetable GetTimetableForGroup(string groupName, DateTime from, DateTime to);
    }
}