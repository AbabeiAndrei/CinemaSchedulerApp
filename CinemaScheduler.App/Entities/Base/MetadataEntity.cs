using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace CinemaScheduler.App.Entities.Base
{
    public abstract class MetadataEntity<T>
    {
        private T _metadata;
        public abstract string Metadata { get; set; }

        public T GetMetadata(bool forceDeserialize)
        {
            if (forceDeserialize || _metadata == null)
                return _metadata = JsonConvert.DeserializeObject<T>(Metadata);

            return _metadata;
        }
    }
}
