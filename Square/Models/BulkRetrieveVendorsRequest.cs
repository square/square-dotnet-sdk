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
    /// BulkRetrieveVendorsRequest.
    /// </summary>
    public class BulkRetrieveVendorsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkRetrieveVendorsRequest"/> class.
        /// </summary>
        /// <param name="vendorIds">vendor_ids.</param>
        public BulkRetrieveVendorsRequest(
            IList<string> vendorIds = null)
        {
            this.VendorIds = vendorIds;
        }

        /// <summary>
        /// IDs of the [Vendor]($m/Vendor) objects to retrieve.
        /// </summary>
        [JsonProperty("vendor_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> VendorIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkRetrieveVendorsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is BulkRetrieveVendorsRequest other &&
                ((this.VendorIds == null && other.VendorIds == null) || (this.VendorIds?.Equals(other.VendorIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 615646763;
            hashCode = HashCode.Combine(this.VendorIds);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.VendorIds = {(this.VendorIds == null ? "null" : $"[{string.Join(", ", this.VendorIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .VendorIds(this.VendorIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> vendorIds;

             /// <summary>
             /// VendorIds.
             /// </summary>
             /// <param name="vendorIds"> vendorIds. </param>
             /// <returns> Builder. </returns>
            public Builder VendorIds(IList<string> vendorIds)
            {
                this.vendorIds = vendorIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkRetrieveVendorsRequest. </returns>
            public BulkRetrieveVendorsRequest Build()
            {
                return new BulkRetrieveVendorsRequest(
                    this.vendorIds);
            }
        }
    }
}