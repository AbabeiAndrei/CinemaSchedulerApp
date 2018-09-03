using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaScheduler.App.Models
{
    public class ScheduleModel
    {
        public bool Paid { get; set; }

        public string PaidLiteral => Paid ? "cumparat" : "rezervat";
    }
}
