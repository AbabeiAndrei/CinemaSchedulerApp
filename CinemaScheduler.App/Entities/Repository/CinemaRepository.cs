using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CinemaScheduler.App.Data;

using Microsoft.EntityFrameworkCore;

namespace CinemaScheduler.App.Entities.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly IApplicationDbContext _context;
        
        public CinemaRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        #region Implementation of IRepository<Cinema>

        /// <inheritdoc />
        public Cinema Find(int id)
        {
            return _context.Cinemas.Find(id);
        }

        /// <inheritdoc />
        public DbSet<Cinema> List()
        {
            return _context.Cinemas;
        }

        /// <inheritdoc />
        public void Add(Cinema entity)
        {
            _context.Cinemas.Add(entity);
        }

        /// <inheritdoc />
        public void Delete(Cinema entity)
        {
            _context.Cinemas.Remove(entity);
        }

        #endregion
    }
}
