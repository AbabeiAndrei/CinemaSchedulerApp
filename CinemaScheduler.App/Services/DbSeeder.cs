using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CinemaScheduler.App.Data;
using CinemaScheduler.App.Services.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace CinemaScheduler.App.Services
{
    public class DbSeeder : ISeeder
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        /// <inheritdoc />
        public DbSeeder(IApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        #region Implementation of ISeeder

        /// <inheritdoc />
        public async Task Seed()
        {
            if (!_context.Users.Any())
                await _userManager.CreateAsync(new IdentityUser("admin"), "admin");
        }

        #endregion
    }
}
