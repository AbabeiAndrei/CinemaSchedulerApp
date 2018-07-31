using System.Collections.Generic;

using CinemaScheduler.App.Models;
using CinemaScheduler.App.Entities.Base;
using CinemaScheduler.App.Entities.Metadata;

namespace CinemaScheduler.App.Entities
{
    public class MovieSchedule : MetadataEntity<MovieScheduleMetadata>
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int CinemaHallId { get; set; }

        public MovieType MovieType { get; set; }

        #region Overrides of MetadataEntity<MovieScheduleMetadata>

        /// <inheritdoc />
        public override string Metadata { get; set; }

        #endregion

        public Movie Movie { get; set; }

        public CinemaHall CinemaHall { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
