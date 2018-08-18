using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DayOfWeek = CinemaScheduler.App.Models.DayOfWeek;

namespace CinemaScheduler.App.Services.Utils
{
    public static class DateTimeUtils
    {
        public static DayOfWeek GetDayOfWeek(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case System.DayOfWeek.Monday:
                    return DayOfWeek.Monday;
                case System.DayOfWeek.Tuesday:
                    return DayOfWeek.Tuesday;
                case System.DayOfWeek.Wednesday:
                    return DayOfWeek.Wednesday;
                case System.DayOfWeek.Thursday:
                    return DayOfWeek.Thursday;
                case System.DayOfWeek.Friday:
                    return DayOfWeek.Friday;
                case System.DayOfWeek.Saturday:
                    return DayOfWeek.Saturday;
                case System.DayOfWeek.Sunday:
                    return DayOfWeek.Sunday;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public static System.DayOfWeek GetDayOfWeek(this DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return System.DayOfWeek.Monday;
                case DayOfWeek.Tuesday:
                    return System.DayOfWeek.Tuesday;
                case DayOfWeek.Wednesday:
                    return System.DayOfWeek.Wednesday;
                case DayOfWeek.Thursday:
                    return System.DayOfWeek.Thursday;
                case DayOfWeek.Friday:
                    return System.DayOfWeek.Friday;
                case DayOfWeek.Saturday:
                    return System.DayOfWeek.Saturday;
                case DayOfWeek.Sunday:
                    return System.DayOfWeek.Sunday;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public static DateTime GetDate(this DayOfWeek dayOfWeek, DateTime startDate)
        {
            var day = dayOfWeek.GetDayOfWeek();

            return startDate.AddDays(GetDiference(day, startDate.DayOfWeek));
        }

        private static int GetDiference(System.DayOfWeek start, System.DayOfWeek end)
        {
            return (7 + (start - end)) % 7;
        }
    }
}
