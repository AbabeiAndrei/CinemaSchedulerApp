using System;

using Microsoft.AspNetCore.Identity;

namespace CinemaScheduler.App.Entities
{
    public class MovieReview
    {
        public virtual int Id { get;set; }

        public virtual int MovieId { get; set; }

        public virtual string UserId { get; set; }
        
        public virtual string Review { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual DateTime CreatedAt { get; set; }
    }
}
