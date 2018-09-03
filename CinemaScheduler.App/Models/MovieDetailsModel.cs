using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CinemaScheduler.App.Entities;
using CinemaScheduler.App.Services.Utils;

namespace CinemaScheduler.App.Models
{
    public class MovieDetailsModel
    {
        private DayOfWeek _selectedDay;

        public int Id { get; set; }
        public virtual MovieSchedule Movie { get; set; }
        public virtual string ImdbId { get; set; }
        public virtual float Rate { get; set; }
        public virtual TimeSpan Duration { get; set; }
        [NotMapped]
        public virtual string[] Categories { get; set; }
        public virtual string ImageSource { get; set; }

        [NotMapped]
        public virtual MovieReview[] Reviews { get; set; }
        public string Trailer { get; set; }

        public virtual string CategoriesString => string.Join(", ", Categories);
        public virtual string DurationFormat => Duration.ToString("hh':'mm");

        public virtual DayOfWeek SelectedDay
        {
            get => _selectedDay;
            set => _selectedDay = value;
        }

        public MovieDetailsModel()
        {
            _selectedDay = DateTime.Now.GetDayOfWeek();
        }
    }
}
