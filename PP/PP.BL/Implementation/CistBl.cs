using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using PP.BL.Interfaces;
using PP.Core.DomainModel.Timetable;
using PP.Core.DomainModel.UniversityStructure;

namespace PP.BL.Implementation
{
    public class CistBl : ICistBl
    {
        private const string BaseseApiAddress = "http://cist.kture.kharkov.ua/ias/app/tt/";

        private const string GetUniversityStructure = "P_API_GROUP_JSON";

        private const string GetTimetable = "P_API_EVENT_JSON";

        // потом может поменяем WebClient на HttpWebRequest или вообще на сокеты, что бы было быстрее.

        public List<Group> GetAllGroups()
        {
            var client = new WebClient();
            var content = client.DownloadString(BaseseApiAddress + GetUniversityStructure);
            var university = JsonConvert.DeserializeObject<CistUniversity>(content);

            var groups = new List<Group>();
            foreach (var fac in university.University.Faculties)
            {
                if (fac.Directions != null)
                {
                    foreach (var direction in fac.Directions)
                    {
                        if (direction.Groups != null)
                        {
                            groups.AddRange(direction.Groups);
                        }
                    }
                }
            }

//
            return groups;
        }

        public Timetable GetTimetableForGroup(string groupName)
        {
            var client = new WebClient();
            var content = client.DownloadString(BaseseApiAddress + GetTimetable + "?timetable_id=" + groupName);
            var university = JsonConvert.DeserializeObject<Timetable>(content);
            return university;
        }

        public Timetable GetTimetableForGroup(string groupName, DateTime startFrom)
        {
            var startDate = GetTimeStampFromDate(startFrom);
            var client = new WebClient();
            var content =
                client.DownloadString(BaseseApiAddress + GetTimetable + "?timetable_id=" + groupName + "&time_from=" +
                                      startDate);
            return JsonConvert.DeserializeObject<Timetable>(content);
        }

        public Timetable GetTimetableForGroup(string groupName, DateTime @from, DateTime to)
        {
            var startDate = GetTimeStampFromDate(@from);
            var toDate = GetTimeStampFromDate(to);
            var client = new WebClient();
            var content =
                client.DownloadString(BaseseApiAddress + GetTimetable + "?timetable_id=" + groupName + "&time_from=" +
                                      startDate + "&time_to=" + toDate);
            return JsonConvert.DeserializeObject<Timetable>(content);
        }

        private long GetTimeStampFromDate(DateTime date)
        {
            var unixStart = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            return (long)Math.Floor((date.ToUniversalTime() - unixStart).TotalSeconds);
        }
    }
}