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
    /// UpdateCatalogImageRequest.
    /// </summary>
    public class UpdateCatalogImageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCatalogImageRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public UpdateCatalogImageRequest(string idempotencyKey)
        {
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// A unique string that identifies this UpdateCatalogImage request.
        /// Keys can be any valid string but must be unique for every UpdateCatalogImage request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"UpdateCatalogImageRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is UpdateCatalogImageRequest other
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -793116434;
            hashCode = HashCode.Combine(hashCode, this.IdempotencyKey);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for UpdateCatalogImageRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            public Builder(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
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
            /// <returns> UpdateCatalogImageRequest. </returns>
            public UpdateCatalogImageRequest Build()
            {
                return new UpdateCatalogImageRequest(this.idempotencyKey);
            }
        }
    }
}
