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
    public class LoyaltyEventLocationFilter 
    {
        public LoyaltyEventLocationFilter(IList<string> locationIds)
        {
            LocationIds = locationIds;
        }

        /// <summary>
        /// The [location](#type-Location) IDs for loyalty events to query.
        /// If multiple values are specified, the endpoint uses 
        /// a logical OR to combine them.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> locationIds;

            public Builder(IList<string> locationIds)
            {
                this.locationIds = locationIds;
            }
            public Builder LocationIds(IList<string> value)
            {
                locationIds = value;
                return this;
            }

            public LoyaltyEventLocationFilter Build()
            {
                return new LoyaltyEventLocationFilter(locationIds);
            }
        }
    }
}