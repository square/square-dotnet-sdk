namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// Coordinates.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class.
        /// </summary>
        /// <param name="latitude">latitude.</param>
        /// <param name="longitude">longitude.</param>
        public Coordinates(
            double? latitude = null,
            double? longitude = null)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Coordinates : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
                ((this.Latitude == null && other.Latitude == null) || (this.Latitude?.Equals(other.Latitude) == true)) &&
                ((this.Longitude == null && other.Longitude == null) || (this.Longitude?.Equals(other.Longitude) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1577606388;

            if (this.Latitude != null)
            {
               hashCode += this.Latitude.GetHashCode();
            }

            if (this.Longitude != null)
            {
               hashCode += this.Longitude.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Latitude = {(this.Latitude == null ? "null" : this.Latitude.ToString())}");
            toStringOutput.Add($"this.Longitude = {(this.Longitude == null ? "null" : this.Longitude.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Latitude(this.Latitude)
                .Longitude(this.Longitude);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private double? latitude;
            private double? longitude;

             /// <summary>
             /// Latitude.
             /// </summary>
             /// <param name="latitude"> latitude. </param>
             /// <returns> Builder. </returns>
            public Builder Latitude(double? latitude)
            {
                this.latitude = latitude;
                return this;
            }

             /// <summary>
             /// Longitude.
             /// </summary>
             /// <param name="longitude"> longitude. </param>
             /// <returns> Builder. </returns>
            public Builder Longitude(double? longitude)
            {
                this.longitude = longitude;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Coordinates. </returns>
            public Coordinates Build()
            {
                return new Coordinates(
                    this.latitude,
                    this.longitude);
            }
        }
    }
}