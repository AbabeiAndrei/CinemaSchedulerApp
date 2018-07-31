using System.Diagnostics.CodeAnalysis;

using CinemaScheduler.App.Entities;
using CinemaScheduler.App.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace CinemaScheduler.App.Data
{
    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        /// <inheritdoc />
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region Overrides of DbContext

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("server=localhost;database=cinema;user=cinema;password=cinema");
        }

        #endregion

        #region Overrides of IdentityDbContext<IdentityUser,IdentityRole,string,IdentityUserClaim<string>,IdentityUserRole<string>,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            
            builder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                
                entity.HasMany(e => e.Cinemas)
                      .WithOne(e => e.City)
                      .HasForeignKey(e => e.CityId);
            });
            
            builder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Phone);
                entity.Property(e => e.Email);
                entity.Property(e => e.Metadata);
                entity.Property(e => e.Closed);
                
                entity.HasOne(e => e.City)
                      .WithMany(c => c.Cinemas)
                      .HasForeignKey(e => e.CityId)
                      .IsRequired();

                entity.HasMany(e => e.CinemaHalls)
                      .WithOne(e => e.Cinema)
                      .HasForeignKey(e => e.CinemaId)
                      .IsRequired();
            });
            builder.Entity<CinemaHall>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.NumberOfSeats).IsRequired();
                entity.Property(e => e.Closed).IsRequired();
               
                entity.HasOne(e => e.Cinema)
                      .WithMany(c => c.CinemaHalls)
                      .HasForeignKey(e => e.CinemaId)
                      .IsRequired();

                entity.HasMany(e => e.MovieSchedules)
                      .WithOne(e => e.CinemaHall)
                      .HasForeignKey(e => e.CinemaHallId)
                      .IsRequired();
            });

            builder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.ImdbId).IsRequired();

                entity.HasMany(e => e.Schedules)
                      .WithOne(e => e.Movie)
                      .HasForeignKey(e => e.MovieId);
            });

            builder.Entity<MovieSchedule>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MovieType).IsRequired();
                entity.Property(e => e.Metadata).IsRequired();

                entity.HasOne(e => e.Movie)
                      .WithMany(e => e.Schedules)
                      .HasForeignKey(e => e.MovieId)
                      .IsRequired();

                entity.HasOne(e => e.CinemaHall)
                      .WithMany(e => e.MovieSchedules)
                      .HasForeignKey(e => e.CinemaHallId)
                      .IsRequired();

                entity.HasMany(e => e.Schedules)
                      .WithOne(e => e.MovieSchedule)
                      .HasForeignKey(e => e.MovieScheduleId)
                      .IsRequired();
            });

            builder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ReservedAt).IsRequired();
                entity.Property(e => e.Seat).IsRequired();
                entity.Property(e => e.PaidWith).HasDefaultValue(PaymentMethod.None);
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.HasOne(e => e.MovieSchedule)
                      .WithMany(e => e.Schedules)
                      .HasForeignKey(e => e.MovieScheduleId)
                      .IsRequired();
            });
        }

        #endregion

        #region Implementation of IApplicationDbContext

        /// <inheritdoc />
        public DbSet<Cinema> Cinemas => Set<Cinema>();

        /// <inheritdoc />
        public DbSet<CinemaHall> CinemaHalls => Set<CinemaHall>();

        /// <inheritdoc />
        public DbSet<City> Cities => Set<City>();

        /// <inheritdoc />
        public DbSet<Movie> Movies => Set<Movie>();

        /// <inheritdoc />
        public DbSet<MovieSchedule> MovieSchedules => Set<MovieSchedule>();

        /// <inheritdoc />
        public DbSet<Schedule> Schedules => Set<Schedule>();

        #endregion
    }
}
