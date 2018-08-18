using System.Collections.Generic;

namespace CinemaScheduler.App.Entities
{
    public class CinemaHall
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfSeats { get; set; }

        public int CinemaId { get; set; }

        public bool Closed { get; set; } 

        public virtual Cinema Cinema { get; set; }

        public virtual ICollection<MovieSchedule> MovieSchedules { get; set; }
    }
}
