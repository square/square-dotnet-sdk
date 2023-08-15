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
    /// BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse.
    /// </summary>
    public class BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="customAttribute">custom_attribute.</param>
        /// <param name="errors">errors.</param>
        public BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse(
            string locationId = null,
            Models.CustomAttribute customAttribute = null,
            IList<Models.Error> errors = null)
        {
            this.LocationId = locationId;
            this.CustomAttribute = customAttribute;
            this.Errors = errors;
        }

        /// <summary>
        /// The ID of the location associated with the custom attribute.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// A custom attribute value. Each custom attribute value has a corresponding
        /// `CustomAttributeDefinition` object.
        /// </summary>
        [JsonProperty("custom_attribute", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomAttribute CustomAttribute { get; }

        /// <summary>
        /// Any errors that occurred while processing the individual request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.CustomAttribute == null && other.CustomAttribute == null) || (this.CustomAttribute?.Equals(other.CustomAttribute) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -32654242;
            hashCode = HashCode.Combine(this.LocationId, this.CustomAttribute, this.Errors);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.CustomAttribute = {(this.CustomAttribute == null ? "null" : this.CustomAttribute.ToString())}");
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
                .CustomAttribute(this.CustomAttribute)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string locationId;
            private Models.CustomAttribute customAttribute;
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
             /// CustomAttribute.
             /// </summary>
             /// <param name="customAttribute"> customAttribute. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttribute(Models.CustomAttribute customAttribute)
            {
                this.customAttribute = customAttribute;
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
            /// <returns> BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse. </returns>
            public BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse Build()
            {
                return new BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse(
                    this.locationId,
                    this.customAttribute,
                    this.errors);
            }
        }
    }
}