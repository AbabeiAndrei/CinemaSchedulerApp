using CinemaScheduler.App.Data;

using Microsoft.EntityFrameworkCore;

namespace CinemaScheduler.App.Entities.Repository
{
    public class MovieScheduleRepository : IMovieScheduleRepository
    {
        private readonly IApplicationDbContext _context;

        /// <inheritdoc />
        public MovieScheduleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        #region Implementation of IRepository<MovieSchedule>

        public MovieSchedule Find(int id)
        {
            return _context.MovieSchedules.Find(id);
        }

        /// <inheritdoc />
        public DbSet<MovieSchedule> List()
        {
            return _context.MovieSchedules;
        }

        /// <inheritdoc />
        public void Add(MovieSchedule entity)
        {
            _context.MovieSchedules.Add(entity);
        }

        /// <inheritdoc />
        public void Delete(MovieSchedule entity)
        {
            _context.MovieSchedules.Remove(entity);
        }

        #endregion
    }
}
