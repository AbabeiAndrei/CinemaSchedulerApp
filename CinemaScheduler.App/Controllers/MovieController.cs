using System;
using System.Linq;
using System.Threading.Tasks;

using CinemaScheduler.App.Models;
using CinemaScheduler.App.Entities.Repository;
using CinemaScheduler.App.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

using Newtonsoft.Json;

using DayOfWeek = CinemaScheduler.App.Models.DayOfWeek;

namespace CinemaScheduler.App.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieScheduleRepository _movieScheduleRepository;
        private readonly IImdbService _imdbService;

        public MovieController(IMovieScheduleRepository movieScheduleRepository, IImdbService imdbService)
        {
            _movieScheduleRepository = movieScheduleRepository;
            _imdbService = imdbService;
        }

        [Route("Movie/Details/{movieScheduleId}")]
        public async Task<IActionResult> Details(int movieScheduleId)
        {
            var model = new MovieDetailsModel
            {
                Movie = _movieScheduleRepository.Find(movieScheduleId)
            };

            var imdbData = await _imdbService.GetMovie(model.Movie.Movie.ImdbId);

            if (!string.IsNullOrEmpty(imdbData.Error))
                return RedirectToAction("Error", "Public");

            model.Rate = float.Parse(imdbData.ImdbRating);
            model.Categories = imdbData.Genre.Split(',');
            model.Duration = TimeSpan.FromMinutes(int.Parse(imdbData.RunTime.Replace("min", string.Empty).Trim()));
            model.ImageSource = imdbData.Poster;

            return View(model);
        }

        public IActionResult Buy(int movie, DayOfWeek day, string time)
        {
            var model = new MovieBuyModel
            {
                Movie = _movieScheduleRepository.Find(movie),
                Day = day
            };

            model.Schedule = model.Movie.ProgramSplited.Where(p => p.Key == day)
                                  .SelectMany(kvp => kvp.Value)
                                  .FirstOrDefault(sd => sd.ShortTime == time);

            return View(model);
        }
        
        [Route("Movie/Pay")]
        public IActionResult Pay([FromQuery] string data)
        {
            var model = JsonConvert.DeserializeObject<MovieBuyModelClient>(data);

            if (string.IsNullOrEmpty(model.Name))
                return RedirectToAction("Error", "Public", new {Error = "Nume invalid"});

            return View();
        }
    }
}