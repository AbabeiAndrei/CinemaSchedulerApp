using System;
using System.Collections.Generic;
using System.Linq;

using CinemaScheduler.App.Entities;

namespace CinemaScheduler.App.Models
{
    public class CityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CinemaModel> Cinemas { get; set; }

        public CityModel(City city)
        {
            Id = city.Id;
            Name = city.Name;
            Cinemas = city.Cinemas.Select(c => new CinemaModel(c)).ToList();
        }
    }

    public class CinemaModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CinemaModel(Cinema cinema)
        {
            Id = cinema.Id;
            Name = cinema.Name;
        }
    }
}
