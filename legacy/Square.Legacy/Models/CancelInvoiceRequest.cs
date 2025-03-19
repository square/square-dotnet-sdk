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
    /// CancelInvoiceRequest.
    /// </summary>
    public class CancelInvoiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelInvoiceRequest"/> class.
        /// </summary>
        /// <param name="version">version.</param>
        public CancelInvoiceRequest(int version)
        {
            this.Version = version;
        }

        /// <summary>
        /// The version of the [invoice](entity:Invoice) to cancel.
        /// If you do not know the version, you can call
        /// [GetInvoice](api-endpoint:Invoices-GetInvoice) or [ListInvoices](api-endpoint:Invoices-ListInvoices).
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CancelInvoiceRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CancelInvoiceRequest other && (this.Version.Equals(other.Version));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1350501489;
            hashCode = HashCode.Combine(hashCode, this.Version);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Version = {this.Version}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Version);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int version;

            /// <summary>
            /// Initialize Builder for CancelInvoiceRequest.
            /// </summary>
            /// <param name="version"> version. </param>
            public Builder(int version)
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
            /// Builds class object.
            /// </summary>
            /// <returns> CancelInvoiceRequest. </returns>
            public CancelInvoiceRequest Build()
            {
                return new CancelInvoiceRequest(this.version);
            }
        }
    }
}
