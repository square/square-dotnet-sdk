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
    /// UpdateLocationRequest.
    /// </summary>
    public class UpdateLocationRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLocationRequest"/> class.
        /// </summary>
        /// <param name="location">location.</param>
        public UpdateLocationRequest(
            Models.Location location = null)
        {
            this.Location = location;
        }

        /// <summary>
        /// Represents one of a business's locations.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Location Location { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateLocationRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateLocationRequest other &&
                ((this.Location == null && other.Location == null) || (this.Location?.Equals(other.Location) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 687060631;
            hashCode = HashCode.Combine(this.Location);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Location = {(this.Location == null ? "null" : this.Location.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Location(this.Location);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Location location;

             /// <summary>
             /// Location.
             /// </summary>
             /// <param name="location"> location. </param>
             /// <returns> Builder. </returns>
            public Builder Location(Models.Location location)
            {
                this.location = location;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateLocationRequest. </returns>
            public UpdateLocationRequest Build()
            {
                return new UpdateLocationRequest(
                    this.location);
            }
        }
    }
}