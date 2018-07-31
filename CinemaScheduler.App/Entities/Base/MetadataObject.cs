using Newtonsoft.Json;

namespace CinemaScheduler.App.Entities.Base
{
    public class MetadataObject
    {
        /// <inheritdoc />
        protected MetadataObject()
        {
        }

        public string Serialize() => JsonConvert.SerializeObject(this);
    }
}