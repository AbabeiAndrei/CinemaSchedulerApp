using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace CinemaScheduler.App.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual string FullName { get; set; }

        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) 
                : base(userName)
        {
        }

        public virtual ICollection<MovieReview> Reviews { get; set; }
    }
}
