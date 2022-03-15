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
    /// UpdateVendorRequest.
    /// </summary>
    public class UpdateVendorRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVendorRequest"/> class.
        /// </summary>
        /// <param name="vendor">vendor.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public UpdateVendorRequest(
            Models.Vendor vendor,
            string idempotencyKey = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Vendor = vendor;
        }

        /// <summary>
        /// A client-supplied, universally unique identifier (UUID) for the
        /// request.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) in the
        /// [API Development 101](https://developer.squareup.com/docs/basics/api101/overview) section for more
        /// information.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
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

            return obj is UpdateVendorRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Vendor == null && other.Vendor == null) || (this.Vendor?.Equals(other.Vendor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -111759500;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.Vendor);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
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
            private Models.Vendor vendor;
            private string idempotencyKey;

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
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateVendorRequest. </returns>
            public UpdateVendorRequest Build()
            {
                return new UpdateVendorRequest(
                    this.vendor,
                    this.idempotencyKey);
            }
        }
    }
}