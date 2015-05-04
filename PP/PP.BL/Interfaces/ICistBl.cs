using System;

namespace PP.BL.Interfaces
{
    public interface ICistBl
    {
        string GetAllGroups();

        string GetTimetableForGroup(string groupName);

        string GetTimetableForGroup(string groupName, DateTime startFrom);

        string GetTimetableForGroup(string groupName, DateTime from, DateTime to);
    }
}