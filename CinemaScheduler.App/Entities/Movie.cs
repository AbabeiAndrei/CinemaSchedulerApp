using System.Collections.Generic;

namespace CinemaScheduler.App.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImdbId { get; set; }

        public virtual ICollection<MovieSchedule> Schedules { get; set; }

        public virtual ICollection<MovieReview> Reviews { get; set; }
    }
}
