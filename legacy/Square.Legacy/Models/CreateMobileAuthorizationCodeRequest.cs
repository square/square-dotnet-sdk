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
    /// CreateMobileAuthorizationCodeRequest.
    /// </summary>
    public class CreateMobileAuthorizationCodeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMobileAuthorizationCodeRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        public CreateMobileAuthorizationCodeRequest(string locationId = null)
        {
            this.LocationId = locationId;
        }

        /// <summary>
        /// The Square location ID that the authorization code should be tied to.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateMobileAuthorizationCodeRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateMobileAuthorizationCodeRequest other
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -289105183;
            hashCode = HashCode.Combine(hashCode, this.LocationId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().LocationId(this.LocationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string locationId;

            /// <summary>
            /// LocationId.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateMobileAuthorizationCodeRequest. </returns>
            public CreateMobileAuthorizationCodeRequest Build()
            {
                return new CreateMobileAuthorizationCodeRequest(this.locationId);
            }
        }
    }
}
