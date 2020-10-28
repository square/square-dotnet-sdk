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
    public class UpdateLocationRequest 
    {
        public UpdateLocationRequest(Models.Location location = null)
        {
            Location = location;
        }

        /// <summary>
        /// Getter for location
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Location Location { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Location(Location);
            return builder;
        }

        public class Builder
        {
            private Models.Location location;



            public Builder Location(Models.Location location)
            {
                this.location = location;
                return this;
            }

            public UpdateLocationRequest Build()
            {
                return new UpdateLocationRequest(location);
            }
        }
    }
}