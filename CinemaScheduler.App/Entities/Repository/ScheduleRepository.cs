using CinemaScheduler.App.Data;

using Microsoft.EntityFrameworkCore;

namespace CinemaScheduler.App.Entities.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IApplicationDbContext _context;

        public ScheduleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        #region Implementation of IRepository<Schedule>

        public Schedule Find(int id)
        {
            return _context.Schedules.Find(id);
        }

        public DbSet<Schedule> List()
        {
            return _context.Schedules;
        }

        public void Add(Schedule entity)
        {
            _context.Schedules.Add(entity);
        }

        public void Delete(Schedule entity)
        {
            _context.Schedules.Remove(entity);
        }

        public void Save()
        {
            _context.Save();
        }

        #endregion
    }
}