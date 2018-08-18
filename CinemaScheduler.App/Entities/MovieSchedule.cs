using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CinemaScheduler.App.Models;
using CinemaScheduler.App.Entities.Base;
using CinemaScheduler.App.Entities.Metadata;
using CinemaScheduler.App.Services.Utils;

using DayOfWeek = CinemaScheduler.App.Models.DayOfWeek;

namespace CinemaScheduler.App.Entities
{
    public class MovieSchedule : MetadataEntity<MovieScheduleMetadata>
    {
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int CinemaHallId { get; set; }

        public MovieType MovieType { get; set; }

        #region Overrides of MetadataEntity<MovieScheduleMetadata>

        /// <inheritdoc />
        public override string Metadata { get; set; }

        #endregion

        public virtual Movie Movie { get; set; }

        public virtual CinemaHall CinemaHall { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual IDictionary<DayOfWeek, IEnumerable<ScheduleData>> Program => GetMetadata(false)?.Days ?? new Dictionary<DayOfWeek, IEnumerable<ScheduleData>>();
        public virtual IDictionary<DayOfWeek, IEnumerable<ScheduleData>> ProgramSplited => Program.Split();
    }
}
