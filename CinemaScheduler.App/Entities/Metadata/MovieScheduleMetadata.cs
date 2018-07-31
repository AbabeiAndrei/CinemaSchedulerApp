using System;
using System.Collections.Generic;

using CinemaScheduler.App.Models;
using CinemaScheduler.App.Entities.Base;

namespace CinemaScheduler.App.Entities.Metadata
{
    public class MovieScheduleMetadata : MetadataObject
    {
        public IDictionary<DayOfWeek, IEnumerable<ScheduleData>> Days { get; set; } 

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveUntil { get; set; }
    }
}
