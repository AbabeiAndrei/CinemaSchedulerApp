using System.Threading.Tasks;

using CinemaScheduler.App.Services.Interfaces;

using IMDBCore;

namespace CinemaScheduler.App.Services
{
    public class ImdbService : IImdbService
    {
        private readonly string _key;

        public ImdbService(string key)
        {
            _key = key;
        }

        #region Implementation of IImdbService

        public async Task<ImdbMovie> GetMovie(string id)
        {
            return await new Imdb(_key).GetMovieFromIdAsync(id);
        }

        #endregion
    }
}
