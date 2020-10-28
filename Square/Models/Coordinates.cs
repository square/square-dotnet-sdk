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
    public class Coordinates 
    {
        public Coordinates(double? latitude = null,
            double? longitude = null)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// The latitude of the coordinate expressed in degrees.
        /// </summary>
        [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? Latitude { get; }

        /// <summary>
        /// The longitude of the coordinate expressed in degrees.
        /// </summary>
        [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? Longitude { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Latitude(Latitude)
                .Longitude(Longitude);
            return builder;
        }

        public class Builder
        {
            private double? latitude;
            private double? longitude;



            public Builder Latitude(double? latitude)
            {
                this.latitude = latitude;
                return this;
            }

            public Builder Longitude(double? longitude)
            {
                this.longitude = longitude;
                return this;
            }

            public Coordinates Build()
            {
                return new Coordinates(latitude,
                    longitude);
            }
        }
    }
}