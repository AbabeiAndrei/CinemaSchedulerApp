using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using CinemaScheduler.App.Entities;

namespace CinemaScheduler.App.Models
{
    public class MovieBuyModel
    {
        public MovieSchedule Movie { get; set; }
        public DayOfWeek Day { get;set; }
        public ScheduleData Schedule { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }
        
        [Required]
        [EmailAddress]
        [DataType(DataType.Date)]
        public string CardExpire { get; set; }
        
        [Required]
        [EmailAddress]
        [MaxLength(3)]
        public string CardCcv { get; set; }

        public string SeatNumber { get; set; }
    }
}
