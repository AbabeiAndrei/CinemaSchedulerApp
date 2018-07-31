using System.Collections.Generic;

namespace CinemaScheduler.App.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImdbId { get; set; }

        public ICollection<MovieSchedule> Schedules { get; set; }
    }
}
