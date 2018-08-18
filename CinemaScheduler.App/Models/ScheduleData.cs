using System;

using CinemaScheduler.App.Formaters;

using Newtonsoft.Json;

namespace CinemaScheduler.App.Models
{
    [Flags]
    public enum DayOfWeek
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64,
        Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,
        Weekend = Saturday | Sunday,
        AllTime = Weekdays | Weekend
    }

    public class ScheduleData : ITimeOfDay, IPriceTag
    {
        public long Ticks => Time.Ticks;

        public TimeOfDay Time { get; set; }

        public decimal Price { get;set; }
        
        public ScheduleData()
        {
        }
        
        public ScheduleData(TimeOfDay time, decimal price)
        {
            Time = time;
            Price = price;
        }

        #region Implementation of ITimeOfDay

        [JsonIgnore]
        public string ShortTime => $"{Time.Hour:00}:{Time.Minute:00}";

        #endregion

        #region Implementation of IPriceTag

        [JsonIgnore]
        public string PriceTag => $"{Price:N2} lei";

        #endregion
    }
}