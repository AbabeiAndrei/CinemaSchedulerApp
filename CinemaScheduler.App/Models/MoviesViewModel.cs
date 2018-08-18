using System.Collections.Generic;

using CinemaScheduler.App.Entities;

namespace CinemaScheduler.App.Models
{
    public class MoviesViewModel : MovieSchedule
    {
        public IEnumerable<MovieSchedule> Movies { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public City SelectedCity { get; set; }
        public Cinema SelectedCinema { get; set; }
    }
}