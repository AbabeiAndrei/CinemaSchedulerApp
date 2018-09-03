using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace CinemaScheduler.App.Entities.Repository
{
    public interface ICinemaRepository : IRepository<Cinema>
    {

    }

    public interface IMovieReviewRepository : IRepository<MovieReview>
    {
        void Save();
    }

    public interface IScheduleRepository : IRepository<Schedule>
    {
        void Save();
    }

    public interface ICitiesRepository : IRepository<City>
    {

    }

    public interface IMovieScheduleRepository : IRepository<MovieSchedule>
    {
    }

    public interface IMovieRepository : IRepository<Movie>
    {
    }

    public interface IRepository<T>
            where T : class
    {
        T Find(int id);
        DbSet<T> List();
        void Add(T entity);
        void Delete(T entity);
    }
}
