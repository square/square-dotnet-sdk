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
    /// BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute.
    /// </summary>
    public class BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute"/> class.
        /// </summary>
        /// <param name="customAttribute">custom_attribute.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute(
            Models.CustomAttribute customAttribute,
            string orderId,
            string idempotencyKey = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false }
            };
            this.CustomAttribute = customAttribute;

            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }
            this.OrderId = orderId;
        }

        internal BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute(
            Dictionary<string, bool> shouldSerialize,
            Models.CustomAttribute customAttribute,
            string orderId,
            string idempotencyKey = null)
        {
            this.shouldSerialize = shouldSerialize;
            CustomAttribute = customAttribute;
            IdempotencyKey = idempotencyKey;
            OrderId = orderId;
        }

        /// <summary>
        /// A custom attribute value. Each custom attribute value has a corresponding
        /// `CustomAttributeDefinition` object.
        /// </summary>
        [JsonProperty("custom_attribute")]
        public Models.CustomAttribute CustomAttribute { get; }

        /// <summary>
        /// A unique identifier for this request, used to ensure idempotency.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The ID of the target [order](entity:Order).
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute other &&
                (this.CustomAttribute == null && other.CustomAttribute == null ||
                 this.CustomAttribute?.Equals(other.CustomAttribute) == true) &&
                (this.IdempotencyKey == null && other.IdempotencyKey == null ||
                 this.IdempotencyKey?.Equals(other.IdempotencyKey) == true) &&
                (this.OrderId == null && other.OrderId == null ||
                 this.OrderId?.Equals(other.OrderId) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -575571452;
            hashCode = HashCode.Combine(hashCode, this.CustomAttribute, this.IdempotencyKey, this.OrderId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomAttribute = {(this.CustomAttribute == null ? "null" : this.CustomAttribute.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
            toStringOutput.Add($"this.OrderId = {this.OrderId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.CustomAttribute,
                this.OrderId)
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

            private Models.CustomAttribute customAttribute;
            private string orderId;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute.
            /// </summary>
            /// <param name="customAttribute"> customAttribute. </param>
            /// <param name="orderId"> orderId. </param>
            public Builder(
                Models.CustomAttribute customAttribute,
                string orderId)
            {
                this.customAttribute = customAttribute;
                this.orderId = orderId;
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
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
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
            /// <returns> BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute. </returns>
            public BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute Build()
            {
                return new BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute(
                    shouldSerialize,
                    this.customAttribute,
                    this.orderId,
                    this.idempotencyKey);
            }
        }
    }
}