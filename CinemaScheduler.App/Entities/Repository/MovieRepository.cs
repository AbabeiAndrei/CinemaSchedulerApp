using System.Collections.Generic;

using CinemaScheduler.App.Data;

using Microsoft.EntityFrameworkCore;

namespace CinemaScheduler.App.Entities.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IApplicationDbContext _context;

        public MovieRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        #region Implementation of IRepository<Movie>

        public Movie Find(int id)
        {
            return _context.Movies.Find(id);
        }

        /// <inheritdoc />
        public DbSet<Movie> List()
        {
            return _context.Movies;
        }

        /// <inheritdoc />
        public void Add(Movie entity)
        {
            _context.Movies.Add(entity);
        }

        /// <inheritdoc />
        public void Delete(Movie entity)
        {
            _context.Movies.Remove(entity);
        }

        #endregion
    }
}
