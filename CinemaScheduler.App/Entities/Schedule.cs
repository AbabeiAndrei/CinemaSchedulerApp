using System;

using CinemaScheduler.App.Models;

namespace CinemaScheduler.App.Entities
{
    public class Schedule
    {
        public int Id { get; set; }

        public int MovieScheduleId { get; set; }

        public DateTime ReservedAt { get; set; }

        public string Seat { get; set; }

        public PaymentMethod PaidWith { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual  MovieSchedule MovieSchedule { get; set; }
    }
}
