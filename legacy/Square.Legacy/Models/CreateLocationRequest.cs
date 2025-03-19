using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// CreateLocationRequest.
    /// </summary>
    public class CreateLocationRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLocationRequest"/> class.
        /// </summary>
        /// <param name="location">location.</param>
        public CreateLocationRequest(Models.Location location = null)
        {
            this.Location = location;
        }

        /// <summary>
        /// Represents one of a business' [locations](https://developer.squareup.com/docs/locations-api).
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Location Location { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateLocationRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateLocationRequest other
                && (
                    this.Location == null && other.Location == null
                    || this.Location?.Equals(other.Location) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1009906280;
            hashCode = HashCode.Combine(hashCode, this.Location);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Location = {(this.Location == null ? "null" : this.Location.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Location(this.Location);
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
            /// <returns> CreateLocationRequest. </returns>
            public CreateLocationRequest Build()
            {
                return new CreateLocationRequest(this.location);
            }
        }
    }
}
