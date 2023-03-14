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
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class.
        /// </summary>
        /// <param name="latitude">latitude.</param>
        /// <param name="longitude">longitude.</param>
        public Coordinates(
            double? latitude = null,
            double? longitude = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "latitude", false },
                { "longitude", false }
            };

            if (latitude != null)
            {
                shouldSerialize["latitude"] = true;
                this.Latitude = latitude;
            }

            if (longitude != null)
            {
                shouldSerialize["longitude"] = true;
                this.Longitude = longitude;
            }

        }
        internal Coordinates(Dictionary<string, bool> shouldSerialize,
            double? latitude = null,
            double? longitude = null)
        {
            this.shouldSerialize = shouldSerialize;
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// The latitude of the coordinate expressed in degrees.
        /// </summary>
        [JsonProperty("latitude")]
        public double? Latitude { get; }

        /// <summary>
        /// The longitude of the coordinate expressed in degrees.
        /// </summary>
        [JsonProperty("longitude")]
        public double? Longitude { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Coordinates : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLatitude()
        {
            return this.shouldSerialize["latitude"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLongitude()
        {
            return this.shouldSerialize["longitude"];
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
            hashCode = HashCode.Combine(this.Latitude, this.Longitude);

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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "latitude", false },
                { "longitude", false },
            };

            private double? latitude;
            private double? longitude;

             /// <summary>
             /// Latitude.
             /// </summary>
             /// <param name="latitude"> latitude. </param>
             /// <returns> Builder. </returns>
            public Builder Latitude(double? latitude)
            {
                shouldSerialize["latitude"] = true;
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
                shouldSerialize["longitude"] = true;
                this.longitude = longitude;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLatitude()
            {
                this.shouldSerialize["latitude"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLongitude()
            {
                this.shouldSerialize["longitude"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Coordinates. </returns>
            public Coordinates Build()
            {
                return new Coordinates(shouldSerialize,
                    this.latitude,
                    this.longitude);
            }
        }
    }
}