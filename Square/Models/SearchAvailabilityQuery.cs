using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class SearchAvailabilityQuery 
    {
        public SearchAvailabilityQuery(Models.SearchAvailabilityFilter filter)
        {
            Filter = filter;
        }

        /// <summary>
        /// A query filter to search for availabilities by.
        /// </summary>
        [JsonProperty("filter")]
        public Models.SearchAvailabilityFilter Filter { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Filter);
            return builder;
        }

        public class Builder
        {
            private Models.SearchAvailabilityFilter filter;

            public Builder(Models.SearchAvailabilityFilter filter)
            {
                this.filter = filter;
            }

            public Builder Filter(Models.SearchAvailabilityFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public SearchAvailabilityQuery Build()
            {
                return new SearchAvailabilityQuery(filter);
            }
        }
    }
}