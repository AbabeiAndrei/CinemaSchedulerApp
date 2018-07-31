using System;
using System.Collections.Generic;

using CinemaScheduler.App.Models;
using CinemaScheduler.App.Entities.Base;

namespace CinemaScheduler.App.Entities.Metadata
{
    public class CinemaMetadata : MetadataObject
    {
        public IDictionary<DayOfWeek, Tuple<TimeOfDay, TimeOfDay>> Schedule { get; set; }
    }
}
