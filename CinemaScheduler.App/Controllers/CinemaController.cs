using System.Linq;

using CinemaScheduler.App.Models;
using CinemaScheduler.App.Entities.Repository;

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

        public CinemaController(IMovieScheduleRepository movieRepository, ICitiesRepository citiesRepository)
        {
            _movieRepository = movieRepository;
            _citiesRepository = citiesRepository;
        }

        public IActionResult Index()
        {
            var model = new MoviesViewModel
            {
                Movies = _movieRepository.List().Include(schedule => schedule.Movie).ToList(),
                Cities = _citiesRepository.List().Include(city => city.Cinemas).ToList()
            };

            model.SelectedCity = model.Cities.FirstOrDefault();
            model.SelectedCinema = model.SelectedCity?.Cinemas.FirstOrDefault();

            return View(model);
        }

        public IActionResult About() => View();

        public IActionResult Contact() => View();

        public IActionResult Movies() => PartialView("Movies");

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }
    }
}