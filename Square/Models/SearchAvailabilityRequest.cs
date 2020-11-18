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
    public class SearchAvailabilityRequest 
    {
        public SearchAvailabilityRequest(Models.SearchAvailabilityQuery query)
        {
            Query = query;
        }

        /// <summary>
        /// Query conditions to search for availabilities of bookings.
        /// </summary>
        [JsonProperty("query")]
        public Models.SearchAvailabilityQuery Query { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Query);
            return builder;
        }

        public class Builder
        {
            private Models.SearchAvailabilityQuery query;

            public Builder(Models.SearchAvailabilityQuery query)
            {
                this.query = query;
            }

            public Builder Query(Models.SearchAvailabilityQuery query)
            {
                this.query = query;
                return this;
            }

            public SearchAvailabilityRequest Build()
            {
                return new SearchAvailabilityRequest(query);
            }
        }
    }
}