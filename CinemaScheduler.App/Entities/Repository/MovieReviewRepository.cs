using System;

using CinemaScheduler.App.Data;

using Microsoft.EntityFrameworkCore;

namespace CinemaScheduler.App.Entities.Repository
{
    public class MovieReviewRepository : IMovieReviewRepository
    {
        private readonly IApplicationDbContext _context;

        public MovieReviewRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        #region Implementation of IRepository<MovieReview>

        /// <inheritdoc />
        public MovieReview Find(int id)
        {
            return _context.MovieReviews.Find(id);
        }

        /// <inheritdoc />
        public DbSet<MovieReview> List()
        {
            return _context.MovieReviews;
        }

        /// <inheritdoc />
        public void Add(MovieReview entity)
        {
            _context.MovieReviews.Add(entity);
        }

        /// <inheritdoc />
        public void Delete(MovieReview entity)
        {
            _context.MovieReviews.Remove(entity);
        }

        /// <inheritdoc />
        public void Save()
        {
            _context.Save();
        }

        #endregion
    }
}