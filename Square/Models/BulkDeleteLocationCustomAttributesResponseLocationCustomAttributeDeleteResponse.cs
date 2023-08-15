namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse.
    /// </summary>
    public class BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="errors">errors.</param>
        public BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse(
            string locationId = null,
            IList<Models.Error> errors = null)
        {
            this.LocationId = locationId;
            this.Errors = errors;
        }

        /// <summary>
        /// The ID of the location associated with the custom attribute.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// Errors that occurred while processing the individual LocationCustomAttributeDeleteRequest request
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1478228795;
            hashCode = HashCode.Combine(this.LocationId, this.Errors);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(this.LocationId)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string locationId;
            private IList<Models.Error> errors;

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
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse. </returns>
            public BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse Build()
            {
                return new BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse(
                    this.locationId,
                    this.errors);
            }
        }
    }
}