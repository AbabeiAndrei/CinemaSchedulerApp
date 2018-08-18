using System;

using CinemaScheduler.App.Data;

using Microsoft.EntityFrameworkCore;

namespace CinemaScheduler.App.Entities.Repository
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly IApplicationDbContext _context;

        public CitiesRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        #region Implementation of IRepository<City>

        public City Find(int id)
        {
            return _context.Cities.Find(id);
        }

        public DbSet<City> List()
        {
            return _context.Cities;
        }

        public void Add(City entity)
        {
            _context.Cities.Add(entity);
        }

        public void Delete(City entity)
        {
            _context.Cities.Remove(entity);
        }

        #endregion
    }
}
