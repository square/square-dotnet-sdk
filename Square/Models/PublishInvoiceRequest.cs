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
    /// PublishInvoiceRequest.
    /// </summary>
    public class PublishInvoiceRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PublishInvoiceRequest"/> class.
        /// </summary>
        /// <param name="version">version.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public PublishInvoiceRequest(
            int version,
            string idempotencyKey = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false }
            };
            this.Version = version;

            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }
        }

        internal PublishInvoiceRequest(
            Dictionary<string, bool> shouldSerialize,
            int version,
            string idempotencyKey = null)
        {
            this.shouldSerialize = shouldSerialize;
            Version = version;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// The version of the [invoice](entity:Invoice) to publish.
        /// This must match the current version of the invoice; otherwise, the request is rejected.
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; }

        /// <summary>
        /// A unique string that identifies the `PublishInvoice` request. If you do not
        /// provide `idempotency_key` (or provide an empty string as the value), the endpoint
        /// treats each request as independent.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PublishInvoiceRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is PublishInvoiceRequest other &&
                (this.Version.Equals(other.Version)) &&
                (this.IdempotencyKey == null && other.IdempotencyKey == null ||
                 this.IdempotencyKey?.Equals(other.IdempotencyKey) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1055593006;
            hashCode = HashCode.Combine(hashCode, this.Version, this.IdempotencyKey);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Version = {this.Version}");
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Version)
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

            private int version;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for PublishInvoiceRequest.
            /// </summary>
            /// <param name="version"> version. </param>
            public Builder(
                int version)
            {
                this.version = version;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int version)
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
            /// <returns> PublishInvoiceRequest. </returns>
            public PublishInvoiceRequest Build()
            {
                return new PublishInvoiceRequest(
                    shouldSerialize,
                    this.version,
                    this.idempotencyKey);
            }
        }
    }
}