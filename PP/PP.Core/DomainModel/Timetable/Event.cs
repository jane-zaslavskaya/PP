using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PP.Core.DomainModel.Timetable
{
    public class Event
    {
        [JsonProperty("auditory")]
        public string Auditory { get; set; }

        [JsonProperty("end_time")]
        public long EndTime { get; set; }

        [JsonProperty("groups")]
        public List<long> Groups { get; set; }

        [JsonProperty("number_pair")]
        public int NumberPair { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("subject_id")]
        public long SubjectId { get; set; }

        [JsonProperty("teachers")]
        public List<long> Teachers { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }
}