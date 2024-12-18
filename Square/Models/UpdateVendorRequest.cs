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
    /// UpdateVendorRequest.
    /// </summary>
    public class UpdateVendorRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVendorRequest"/> class.
        /// </summary>
        /// <param name="vendor">vendor.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public UpdateVendorRequest(
            Models.Vendor vendor,
            string idempotencyKey = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false }
            };

            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }
            this.Vendor = vendor;
        }

        internal UpdateVendorRequest(
            Dictionary<string, bool> shouldSerialize,
            Models.Vendor vendor,
            string idempotencyKey = null)
        {
            this.shouldSerialize = shouldSerialize;
            IdempotencyKey = idempotencyKey;
            Vendor = vendor;
        }

        /// <summary>
        /// A client-supplied, universally unique identifier (UUID) for the
        /// request.
        /// See [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) in the
        /// [API Development 101](https://developer.squareup.com/docs/buildbasics) section for more
        /// information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents a supplier to a seller.
        /// </summary>
        [JsonProperty("vendor")]
        public Models.Vendor Vendor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"UpdateVendorRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateVendorRequest other &&
                (this.IdempotencyKey == null && other.IdempotencyKey == null ||
                 this.IdempotencyKey?.Equals(other.IdempotencyKey) == true) &&
                (this.Vendor == null && other.Vendor == null ||
                 this.Vendor?.Equals(other.Vendor) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -111759500;
            hashCode = HashCode.Combine(hashCode, this.IdempotencyKey, this.Vendor);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
            toStringOutput.Add($"this.Vendor = {(this.Vendor == null ? "null" : this.Vendor.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Vendor)
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

            private Models.Vendor vendor;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for UpdateVendorRequest.
            /// </summary>
            /// <param name="vendor"> vendor. </param>
            public Builder(
                Models.Vendor vendor)
            {
                this.vendor = vendor;
            }

             /// <summary>
             /// Vendor.
             /// </summary>
             /// <param name="vendor"> vendor. </param>
             /// <returns> Builder. </returns>
            public Builder Vendor(Models.Vendor vendor)
            {
                this.vendor = vendor;
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
            /// <returns> UpdateVendorRequest. </returns>
            public UpdateVendorRequest Build()
            {
                return new UpdateVendorRequest(
                    shouldSerialize,
                    this.vendor,
                    this.idempotencyKey);
            }
        }
    }
}