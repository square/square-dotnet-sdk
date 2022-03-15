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
    /// CreateVendorRequest.
    /// </summary>
    public class CreateVendorRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVendorRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="vendor">vendor.</param>
        public CreateVendorRequest(
            string idempotencyKey,
            Models.Vendor vendor = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Vendor = vendor;
        }

        /// <summary>
        /// A client-supplied, universally unique identifier (UUID) to make this [CreateVendor]($e/Vendors/CreateVendor) call idempotent.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) in the
        /// [API Development 101](https://developer.squareup.com/docs/basics/api101/overview) section for more
        /// information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents a supplier to a seller.
        /// </summary>
        [JsonProperty("vendor", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Vendor Vendor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateVendorRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateVendorRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Vendor == null && other.Vendor == null) || (this.Vendor?.Equals(other.Vendor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 25408875;
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
                this.IdempotencyKey)
                .Vendor(this.Vendor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.Vendor vendor;

            public Builder(
                string idempotencyKey)
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
            /// Builds class object.
            /// </summary>
            /// <returns> CreateVendorRequest. </returns>
            public CreateVendorRequest Build()
            {
                return new CreateVendorRequest(
                    this.idempotencyKey,
                    this.vendor);
            }
        }
    }
}