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
    /// BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest.
    /// </summary>
    public class BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false }
            };

            this.CustomerId = customerId;
            this.CustomAttribute = customAttribute;
            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }

        }
        internal BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest(Dictionary<string, bool> shouldSerialize,
            string customerId,
            Models.CustomAttribute customAttribute,
            string idempotencyKey = null)
        {
            this.shouldSerialize = shouldSerialize;
            CustomerId = customerId;
            CustomAttribute = customAttribute;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// The ID of the target [customer profile](entity:Customer).
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
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIdempotencyKey()
        {
            return this.shouldSerialize["idempotency_key"];
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
            return obj is BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest other &&                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
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
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
            toStringOutput.Add($"this.CustomAttribute = {(this.CustomAttribute == null ? "null" : this.CustomAttribute.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false },
            };

            private string customerId;
            private Models.CustomAttribute customAttribute;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest.
            /// </summary>
            /// <param name="customerId"> customerId. </param>
            /// <param name="customAttribute"> customAttribute. </param>
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
                shouldSerialize["idempotency_key"] = true;
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIdempotencyKey()
            {
                this.shouldSerialize["idempotency_key"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest. </returns>
            public BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest Build()
            {
                return new BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest(shouldSerialize,
                    this.customerId,
                    this.customAttribute,
                    this.idempotencyKey);
            }
        }
    }
}