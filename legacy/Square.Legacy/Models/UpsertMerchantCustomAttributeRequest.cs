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
    /// UpsertMerchantCustomAttributeRequest.
    /// </summary>
    public class UpsertMerchantCustomAttributeRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertMerchantCustomAttributeRequest"/> class.
        /// </summary>
        /// <param name="customAttribute">custom_attribute.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public UpsertMerchantCustomAttributeRequest(
            Models.CustomAttribute customAttribute,
            string idempotencyKey = null
        )
        {
            shouldSerialize = new Dictionary<string, bool> { { "idempotency_key", false } };
            this.CustomAttribute = customAttribute;

            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }
        }

        internal UpsertMerchantCustomAttributeRequest(
            Dictionary<string, bool> shouldSerialize,
            Models.CustomAttribute customAttribute,
            string idempotencyKey = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            CustomAttribute = customAttribute;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// A custom attribute value. Each custom attribute value has a corresponding
        /// `CustomAttributeDefinition` object.
        /// </summary>
        [JsonProperty("custom_attribute")]
        public Models.CustomAttribute CustomAttribute { get; }

        /// <summary>
        /// A unique identifier for this request, used to ensure idempotency. For more information,
        /// see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"UpsertMerchantCustomAttributeRequest : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is UpsertMerchantCustomAttributeRequest other
                && (
                    this.CustomAttribute == null && other.CustomAttribute == null
                    || this.CustomAttribute?.Equals(other.CustomAttribute) == true
                )
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -553298040;
            hashCode = HashCode.Combine(hashCode, this.CustomAttribute, this.IdempotencyKey);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.CustomAttribute = {(this.CustomAttribute == null ? "null" : this.CustomAttribute.ToString())}"
            );
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.CustomAttribute).IdempotencyKey(this.IdempotencyKey);
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

            private Models.CustomAttribute customAttribute;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for UpsertMerchantCustomAttributeRequest.
            /// </summary>
            /// <param name="customAttribute"> customAttribute. </param>
            public Builder(Models.CustomAttribute customAttribute)
            {
                this.customAttribute = customAttribute;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetIdempotencyKey()
            {
                this.shouldSerialize["idempotency_key"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpsertMerchantCustomAttributeRequest. </returns>
            public UpsertMerchantCustomAttributeRequest Build()
            {
                return new UpsertMerchantCustomAttributeRequest(
                    shouldSerialize,
                    this.customAttribute,
                    this.idempotencyKey
                );
            }
        }
    }
}
