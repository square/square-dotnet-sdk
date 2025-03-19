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
    /// BulkCreateVendorsRequest.
    /// </summary>
    public class BulkCreateVendorsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkCreateVendorsRequest"/> class.
        /// </summary>
        /// <param name="vendors">vendors.</param>
        public BulkCreateVendorsRequest(IDictionary<string, Models.Vendor> vendors)
        {
            this.Vendors = vendors;
        }

        /// <summary>
        /// Specifies a set of new [Vendor](entity:Vendor) objects as represented by a collection of idempotency-key/`Vendor`-object pairs.
        /// </summary>
        [JsonProperty("vendors")]
        public IDictionary<string, Models.Vendor> Vendors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkCreateVendorsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BulkCreateVendorsRequest other
                && (
                    this.Vendors == null && other.Vendors == null
                    || this.Vendors?.Equals(other.Vendors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1416477053;
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
            private IDictionary<string, Models.Vendor> vendors;

            /// <summary>
            /// Initialize Builder for BulkCreateVendorsRequest.
            /// </summary>
            /// <param name="vendors"> vendors. </param>
            public Builder(IDictionary<string, Models.Vendor> vendors)
            {
                this.vendors = vendors;
            }

            /// <summary>
            /// Vendors.
            /// </summary>
            /// <param name="vendors"> vendors. </param>
            /// <returns> Builder. </returns>
            public Builder Vendors(IDictionary<string, Models.Vendor> vendors)
            {
                this.vendors = vendors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkCreateVendorsRequest. </returns>
            public BulkCreateVendorsRequest Build()
            {
                return new BulkCreateVendorsRequest(this.vendors);
            }
        }
    }
}
