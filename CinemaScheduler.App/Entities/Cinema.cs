using System.Collections.Generic;

using CinemaScheduler.App.Entities.Base;
using CinemaScheduler.App.Entities.Metadata;

namespace CinemaScheduler.App.Entities
{
    public class Cinema : MetadataEntity<CinemaMetadata>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get;set; }

        public int CityId { get; set; }

        public bool Closed { get; set; } 

        #region Overrides of MetadataEntity<CinemaMetadata>

        /// <inheritdoc />
        public override string Metadata { get; set; }

        #endregion

        public City City { get; set; }

        public ICollection<CinemaHall> CinemaHalls { get; set; }
    }
}
