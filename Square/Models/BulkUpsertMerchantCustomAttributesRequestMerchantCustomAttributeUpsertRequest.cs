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

namespace Square.Models
{
    /// <summary>
    /// BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest.
    /// </summary>
    public class BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest"/> class.
        /// </summary>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="customAttribute">custom_attribute.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest(
            string merchantId,
            Models.CustomAttribute customAttribute,
            string idempotencyKey = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false }
            };

            this.MerchantId = merchantId;
            this.CustomAttribute = customAttribute;
            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }

        }
        internal BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest(Dictionary<string, bool> shouldSerialize,
            string merchantId,
            Models.CustomAttribute customAttribute,
            string idempotencyKey = null)
        {
            this.shouldSerialize = shouldSerialize;
            MerchantId = merchantId;
            CustomAttribute = customAttribute;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// The ID of the target [merchant](entity:Merchant).
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

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

            return $"BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest other &&                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.CustomAttribute == null && other.CustomAttribute == null) || (this.CustomAttribute?.Equals(other.CustomAttribute) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1927345765;
            hashCode = HashCode.Combine(this.MerchantId, this.CustomAttribute, this.IdempotencyKey);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId)}");
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
                this.MerchantId,
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

            private string merchantId;
            private Models.CustomAttribute customAttribute;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest.
            /// </summary>
            /// <param name="merchantId"> merchantId. </param>
            /// <param name="customAttribute"> customAttribute. </param>
            public Builder(
                string merchantId,
                Models.CustomAttribute customAttribute)
            {
                this.merchantId = merchantId;
                this.customAttribute = customAttribute;
            }

             /// <summary>
             /// MerchantId.
             /// </summary>
             /// <param name="merchantId"> merchantId. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
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
            /// <returns> BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest. </returns>
            public BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest Build()
            {
                return new BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest(shouldSerialize,
                    this.merchantId,
                    this.customAttribute,
                    this.idempotencyKey);
            }
        }
    }
}