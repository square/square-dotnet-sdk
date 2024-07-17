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
    /// BulkUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse.
    /// </summary>
    public class BulkUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse"/> class.
        /// </summary>
        /// <param name="customerId">customer_id.</param>
        /// <param name="customAttribute">custom_attribute.</param>
        /// <param name="errors">errors.</param>
        public BulkUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse(
            string customerId = null,
            Models.CustomAttribute customAttribute = null,
            IList<Models.Error> errors = null)
        {
            this.CustomerId = customerId;
            this.CustomAttribute = customAttribute;
            this.Errors = errors;
        }

        /// <summary>
        /// The ID of the customer profile associated with the custom attribute.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

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

            return $"BulkUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse other &&                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.CustomAttribute == null && other.CustomAttribute == null) || (this.CustomAttribute?.Equals(other.CustomAttribute) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1075458575;
            hashCode = HashCode.Combine(this.CustomerId, this.CustomAttribute, this.Errors);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
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
                .CustomerId(this.CustomerId)
                .CustomAttribute(this.CustomAttribute)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string customerId;
            private Models.CustomAttribute customAttribute;
            private IList<Models.Error> errors;

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
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
            /// <returns> BulkUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse. </returns>
            public BulkUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse Build()
            {
                return new BulkUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse(
                    this.customerId,
                    this.customAttribute,
                    this.errors);
            }
        }
    }
}