using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IMDBCore;

namespace CinemaScheduler.App.Services.Interfaces
{
    public interface IImdbService
    {
        Task<ImdbMovie> GetMovie(string id);
    }
}
