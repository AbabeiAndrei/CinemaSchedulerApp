using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CinemaScheduler.App.Data;
using CinemaScheduler.App.Entities;
using CinemaScheduler.App.Services.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CinemaScheduler.App.Services
{
    public class DbSeeder : ISeeder
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <inheritdoc />
        public DbSeeder(IApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        #region Implementation of ISeeder

        /// <inheritdoc />
        public async Task UpdateDb()
        {
            if(_context is ApplicationDbContext context)
                await context.Database.MigrateAsync();
        }

        /// <inheritdoc />
        public async Task Seed()
        {
            if (!_context.Users.Any())
                await _userManager.CreateAsync(new ApplicationUser("admin"), "admin");
        }

        #endregion
    }
}
