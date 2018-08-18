using System.Collections.Generic;

namespace CinemaScheduler.App.Entities
{
    public class City
    {
        public int Id { get;set; }

        public string Name { get; set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }
    }
}
