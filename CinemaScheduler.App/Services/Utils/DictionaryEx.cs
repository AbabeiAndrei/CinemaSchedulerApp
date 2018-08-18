using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaScheduler.App.Services.Utils
{
    public static class DictionaryEx
    {
        public static IDictionary<TKey, TValue> Split<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if(!typeof(TKey).IsEnum)
                throw new ArgumentException("TKey must be enum");

            var split = new Dictionary<TKey, TValue>();

            foreach (var kvp in dictionary)
            {
                if(!(kvp.Key is Enum enm))
                    continue;

                var values = enm.GetIndividualFlags();

                foreach (var @enum in values)
                    if(@enum is TKey key)
                        split.Add(key, kvp.Value);
            }

            return split;
        }
    }
}
