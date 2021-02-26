
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Coordinates : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Latitude = {(Latitude == null ? "null" : Latitude.ToString())}");
            toStringOutput.Add($"Longitude = {(Longitude == null ? "null" : Longitude.ToString())}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is Coordinates other &&
                ((Latitude == null && other.Latitude == null) || (Latitude?.Equals(other.Latitude) == true)) &&
                ((Longitude == null && other.Longitude == null) || (Longitude?.Equals(other.Longitude) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1577606388;

            if (Latitude != null)
            {
               hashCode += Latitude.GetHashCode();
            }

            if (Longitude != null)
            {
               hashCode += Longitude.GetHashCode();
            }

            return hashCode;
        }

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