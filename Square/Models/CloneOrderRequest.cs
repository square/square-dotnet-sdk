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
    /// CloneOrderRequest.
    /// </summary>
    public class CloneOrderRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CloneOrderRequest"/> class.
        /// </summary>
        /// <param name="orderId">order_id.</param>
        /// <param name="version">version.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CloneOrderRequest(
            string orderId,
            int? version = null,
            string idempotencyKey = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false }
            };
            this.OrderId = orderId;
            this.Version = version;

            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }
        }

        internal CloneOrderRequest(
            Dictionary<string, bool> shouldSerialize,
            string orderId,
            int? version = null,
            string idempotencyKey = null)
        {
            this.shouldSerialize = shouldSerialize;
            OrderId = orderId;
            Version = version;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// The ID of the order to clone.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// An optional order version for concurrency protection.
        /// If a version is provided, it must match the latest stored version of the order to clone.
        /// If a version is not provided, the API clones the latest version.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// A value you specify that uniquely identifies this clone request.
        /// If you are unsure whether a particular order was cloned successfully,
        /// you can reattempt the call with the same idempotency key without
        /// worrying about creating duplicate cloned orders.
        /// The originally cloned order is returned.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CloneOrderRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CloneOrderRequest other &&
                (this.OrderId == null && other.OrderId == null ||
                 this.OrderId?.Equals(other.OrderId) == true) &&
                (this.Version == null && other.Version == null ||
                 this.Version?.Equals(other.Version) == true) &&
                (this.IdempotencyKey == null && other.IdempotencyKey == null ||
                 this.IdempotencyKey?.Equals(other.IdempotencyKey) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1356195535;
            hashCode = HashCode.Combine(hashCode, this.OrderId, this.Version, this.IdempotencyKey);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderId = {this.OrderId ?? "null"}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.OrderId)
                .Version(this.Version)
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

            private string orderId;
            private int? version;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for CloneOrderRequest.
            /// </summary>
            /// <param name="orderId"> orderId. </param>
            public Builder(
                string orderId)
            {
                this.orderId = orderId;
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
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
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
            /// <returns> CloneOrderRequest. </returns>
            public CloneOrderRequest Build()
            {
                return new CloneOrderRequest(
                    shouldSerialize,
                    this.orderId,
                    this.version,
                    this.idempotencyKey);
            }
        }
    }
}