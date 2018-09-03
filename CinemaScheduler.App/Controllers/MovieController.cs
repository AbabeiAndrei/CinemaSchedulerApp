using System;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using CinemaScheduler.App.Entities;
using CinemaScheduler.App.Models;
using CinemaScheduler.App.Entities.Repository;
using CinemaScheduler.App.Services;
using CinemaScheduler.App.Services.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using YoutubeSearch;

using DayOfWeek = CinemaScheduler.App.Models.DayOfWeek;

namespace CinemaScheduler.App.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieReviewRepository _movieReviewRepository;
        private readonly IEmailSender _sender;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMovieScheduleRepository _movieScheduleRepository;
        private readonly IImdbService _imdbService;

        public MovieController(IMovieScheduleRepository movieScheduleRepository, IImdbService imdbService, IScheduleRepository scheduleRepository, IMovieReviewRepository movieReviewRepository, IEmailSender sender)
        {
            _movieReviewRepository = movieReviewRepository;
            _sender = sender;
            _movieScheduleRepository = movieScheduleRepository;
            _imdbService = imdbService;
            _scheduleRepository = scheduleRepository;
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
            model.Reviews = model.Movie.Movie.Reviews.OrderByDescending(mr => mr.CreatedAt).ToArray();

            var searcher = new VideoSearch();

            var video = searcher.SearchQuery(model.Movie.Movie.Name, 1).FirstOrDefault();

            if (video != null)
                model.Trailer = TransformUrlToEmbed(video.Url);

            return View(model);
        }

        private string TransformUrlToEmbed(string videoUrl)
        {
            const string pattern = @"(?:https?:\/\/)?(?:www\.)?(?:(?:(?:youtube.com\/watch\?[^?]*v=|youtu.be\/)([\w\-]+))(?:[^\s?]+)?)";
            const string replacement = "https://www.youtube.com/embed/$1";

            var rgx = new Regex(pattern);
            return rgx.Replace(videoUrl, replacement);
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
            model.Seats = _scheduleRepository.List()
                                             .Include(sch => sch.MovieSchedule)
                                             .Where(sch => sch.MovieScheduleId == movie && 
                                                           sch.ReservedForDay == day && 
                                                           sch.ReservedForTime == time)
                                             .ToList()
                                             .Select(sch => sch.Seat)
                                             .ToList();

            return View(model);
        }
        
        [Route("Movie/Pay")]
        public async Task<IActionResult> Pay([FromQuery] string data)
        {
            var model = JsonConvert.DeserializeObject<MovieBuyModelClient>(data);

            if (string.IsNullOrEmpty(model.Name))
                return RedirectToAction("Error", "Public", new {Error = "Nume invalid"});

            var schedule = new Schedule
            {
                Email = model.Email,
                FullName = model.Name,
                PaidWith = model.Paid ? PaymentMethod.Card : PaymentMethod.None,
                PhoneNumber = model.Phone,
                ReservedAt = DateTime.Now,
                Seat = model.SeatNumber,
                MovieScheduleId = model.Id,
                ReservedForTime = model.Time,
                ReservedForDay = model.Day
            };

            _scheduleRepository.Add(schedule);

            var email = "Bilet " + (model.Paid ? "Cumparat" : "Rezervat");
            var result = await _sender.SendEmail(model.Email, "Cinema", email);

            if (!result)
                return RedirectToAction("Error", "Public");

            _scheduleRepository.Save();

            var schModel = new ScheduleModel
            {
                Paid = model.Paid
            };

            return View(schModel);
        }
        
        [Route("Movie/Details/Review/{movieScheduleId}")]
        public IActionResult Review(int movieScheduleId, [FromQuery] string review)
        {
            var action = RedirectToAction("Details", new {movieScheduleId});

            if(string.IsNullOrWhiteSpace(review))
                return action;

            var movie = _movieScheduleRepository.Find(movieScheduleId);

            if (movie == null)
                return action;

            var mReview = new MovieReview
            {
                MovieId = movie.MovieId,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Review = review,
                CreatedAt = DateTime.Now
            };

            _movieReviewRepository.Add(mReview);
            _movieReviewRepository.Save();

            return action;
        }
    }
}