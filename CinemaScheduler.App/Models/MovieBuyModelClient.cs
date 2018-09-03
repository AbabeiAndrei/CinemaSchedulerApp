using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaScheduler.App.Models
{
    public class MovieBuyModelClient
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DayOfWeek Day { get;set; }
        
        [Required]
        public string Time { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string CardNumber { get; set; }
        
        [Required]
        public string CardExpire { get; set; }
        
        [Required]
        [MaxLength(3)]
        public string CardCcv { get; set; }

        public string SeatNumber { get; set; }

        public bool Paid { get; set; }
    }
}
