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
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// RetrieveVendorResponse.
    /// </summary>
    public class RetrieveVendorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveVendorResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="vendor">vendor.</param>
        public RetrieveVendorResponse(
            IList<Models.Error> errors = null,
            Models.Vendor vendor = null
        )
        {
            this.Errors = errors;
            this.Vendor = vendor;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Errors encountered when the request fails.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

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
            return $"RetrieveVendorResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is RetrieveVendorResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Vendor == null && other.Vendor == null
                    || this.Vendor?.Equals(other.Vendor) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 417996321;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Vendor);

            return hashCode;
        }

        internal RetrieveVendorResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.Vendor = {(this.Vendor == null ? "null" : this.Vendor.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).Vendor(this.Vendor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Vendor vendor;

            /// <summary>
            /// Errors.
            /// </summary>
            /// <param name="errors"> errors. </param>
            /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
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
            /// <returns> RetrieveVendorResponse. </returns>
            public RetrieveVendorResponse Build()
            {
                return new RetrieveVendorResponse(this.errors, this.vendor);
            }
        }
    }
}
