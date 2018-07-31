using CinemaScheduler.App.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CinemaScheduler.App.Data
{
    public interface IApplicationDbContext
    {
        DbSet<IdentityUser> Users { get; }
        DbSet<Cinema> Cinemas { get; }
        DbSet<CinemaHall> CinemaHalls { get; }
        DbSet<City> Cities { get; }
        DbSet<Movie> Movies { get; }
        DbSet<MovieSchedule> MovieSchedules { get; }
        DbSet<Schedule> Schedules { get; }
    }
}
