using System.Linq;

using CinemaScheduler.App.Models;
using CinemaScheduler.App.Entities.Repository;
using CinemaScheduler.App.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CinemaScheduler.App.Controllers
{
    [AllowAnonymous]
    public class CinemaController : Controller
    {
        private readonly IMovieScheduleRepository _movieRepository;
        private readonly ICitiesRepository _citiesRepository;
        private readonly ICinemaRepository _cinemaRepository;

        public CinemaController(IMovieScheduleRepository movieRepository, ICitiesRepository citiesRepository, ICinemaRepository cinemaRepository)
        {
            _movieRepository = movieRepository;
            _citiesRepository = citiesRepository;
            _cinemaRepository = cinemaRepository;
        }

        public IActionResult Index()
        {
            var model = new MoviesViewModel
            {
                Movies = _movieRepository.List().Include(schedule => schedule.Movie).ToList(),
                Cities = _citiesRepository.List().Include(city => city.Cinemas).ToList()
            };
            
            return View(model);
        }

        public IActionResult Filtred(int city, int cinema)
        {
            var model = new MoviesViewModel
            {
                Movies = _movieRepository.List().Include(schedule => schedule.Movie).ToList(),
                Cities = _citiesRepository.List().Include(c => c.Cinemas).ToList(),
                SelectedCity = city,
                SelectedCinema = cinema
            };

            if (cinema != 0)
                model.Movies = model.Movies.Where(m => m.CinemaHall.CinemaId == cinema).ToList();
            else if (city != 0)
                model.Movies = model.Movies.Where(m => m.CinemaHall.Cinema.CityId == city).ToList();
            
            return View("Index", model);
        }

        public IActionResult Contact() => View(_cinemaRepository.List());

        public IActionResult Movies() => PartialView("Movies");

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }
    }
}