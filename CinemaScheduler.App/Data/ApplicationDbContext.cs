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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }

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
                entity.Property(e => e.ReservedForDay).IsRequired();
                entity.Property(e => e.ReservedForTime).IsRequired();

                entity.HasOne(e => e.MovieSchedule)
                      .WithMany(e => e.Schedules)
                      .HasForeignKey(e => e.MovieScheduleId)
                      .IsRequired();
            });

            builder.Entity<MovieReview>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Review).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();

                entity.HasOne(e => e.Movie)
                      .WithMany(e => e.Reviews)
                      .HasForeignKey(e => e.MovieId)
                      .IsRequired();

                entity.HasOne(e => e.User)
                      .WithMany(e => e.Reviews)
                      .HasForeignKey(e => e.UserId)
                      .IsRequired();
            });
        }

        #endregion

        #region Implementation of IApplicationDbContext
        
        public DbSet<Cinema> Cinemas => Set<Cinema>();
        
        public DbSet<CinemaHall> CinemaHalls => Set<CinemaHall>();
        
        public DbSet<City> Cities => Set<City>();
        
        public DbSet<Movie> Movies => Set<Movie>();
        
        public DbSet<MovieSchedule> MovieSchedules => Set<MovieSchedule>();
        
        public DbSet<Schedule> Schedules => Set<Schedule>();

        public new DbSet<ApplicationUser> Users => Set<ApplicationUser>();

        public DbSet<MovieReview> MovieReviews => Set<MovieReview>();

        public void Save()
        {
            SaveChanges();
        }

        #endregion
    }
}
