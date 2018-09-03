using System.Collections.Generic;

using CinemaScheduler.App.Entities;

namespace CinemaScheduler.App.Models
{
    public class MoviesViewModel : MovieSchedule
    {
        public IEnumerable<MovieSchedule> Movies { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public int SelectedCity { get; set; }
        public int SelectedCinema { get; set; }
    }
}