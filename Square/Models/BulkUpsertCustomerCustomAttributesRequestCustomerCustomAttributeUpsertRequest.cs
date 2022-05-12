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
    /// BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest.
    /// </summary>
    public class BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest"/> class.
        /// </summary>
        /// <param name="customerId">customer_id.</param>
        /// <param name="customAttribute">custom_attribute.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest(
            string customerId,
            Models.CustomAttribute customAttribute,
            string idempotencyKey = null)
        {
            this.CustomerId = customerId;
            this.CustomAttribute = customAttribute;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// The ID of the target [customer profile]($m/Customer).
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// A custom attribute value. Each custom attribute value has a corresponding
        /// `CustomAttributeDefinition` object.
        /// </summary>
        [JsonProperty("custom_attribute")]
        public Models.CustomAttribute CustomAttribute { get; }

        /// <summary>
        /// A unique identifier for this individual upsert request, used to ensure idempotency.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest other &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.CustomAttribute == null && other.CustomAttribute == null) || (this.CustomAttribute?.Equals(other.CustomAttribute) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 423430873;
            hashCode = HashCode.Combine(this.CustomerId, this.CustomAttribute, this.IdempotencyKey);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.CustomAttribute = {(this.CustomAttribute == null ? "null" : this.CustomAttribute.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.CustomerId,
                this.CustomAttribute)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string customerId;
            private Models.CustomAttribute customAttribute;
            private string idempotencyKey;

            public Builder(
                string customerId,
                Models.CustomAttribute customAttribute)
            {
                this.customerId = customerId;
                this.customAttribute = customAttribute;
            }

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
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest. </returns>
            public BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest Build()
            {
                return new BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest(
                    this.customerId,
                    this.customAttribute,
                    this.idempotencyKey);
            }
        }
    }
}