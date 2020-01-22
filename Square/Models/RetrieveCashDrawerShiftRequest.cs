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
    public class RetrieveCashDrawerShiftRequest 
    {
        public RetrieveCashDrawerShiftRequest(string locationId)
        {
            LocationId = locationId;
        }

        /// <summary>
        /// The ID of the location to retrieve cash drawer shifts from.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationId);
            return builder;
        }

        public class Builder
        {
            private string locationId;

            public Builder(string locationId)
            {
                this.locationId = locationId;
            }
            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public RetrieveCashDrawerShiftRequest Build()
            {
                return new RetrieveCashDrawerShiftRequest(locationId);
            }
        }
    }
}