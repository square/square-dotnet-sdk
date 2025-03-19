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
    /// BulkUpdateVendorsRequest.
    /// </summary>
    public class BulkUpdateVendorsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpdateVendorsRequest"/> class.
        /// </summary>
        /// <param name="vendors">vendors.</param>
        public BulkUpdateVendorsRequest(IDictionary<string, Models.UpdateVendorRequest> vendors)
        {
            this.Vendors = vendors;
        }

        /// <summary>
        /// A set of [UpdateVendorRequest](entity:UpdateVendorRequest) objects encapsulating to-be-updated [Vendor](entity:Vendor)
        /// objects. The set is represented by  a collection of `Vendor`-ID/`UpdateVendorRequest`-object pairs.
        /// </summary>
        [JsonProperty("vendors")]
        public IDictionary<string, Models.UpdateVendorRequest> Vendors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkUpdateVendorsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BulkUpdateVendorsRequest other
                && (
                    this.Vendors == null && other.Vendors == null
                    || this.Vendors?.Equals(other.Vendors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1326021068;
            hashCode = HashCode.Combine(hashCode, this.Vendors);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"Vendors = {(this.Vendors == null ? "null" : this.Vendors.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Vendors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.UpdateVendorRequest> vendors;

            /// <summary>
            /// Initialize Builder for BulkUpdateVendorsRequest.
            /// </summary>
            /// <param name="vendors"> vendors. </param>
            public Builder(IDictionary<string, Models.UpdateVendorRequest> vendors)
            {
                this.vendors = vendors;
            }

            /// <summary>
            /// Vendors.
            /// </summary>
            /// <param name="vendors"> vendors. </param>
            /// <returns> Builder. </returns>
            public Builder Vendors(IDictionary<string, Models.UpdateVendorRequest> vendors)
            {
                this.vendors = vendors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkUpdateVendorsRequest. </returns>
            public BulkUpdateVendorsRequest Build()
            {
                return new BulkUpdateVendorsRequest(this.vendors);
            }
        }
    }
}
