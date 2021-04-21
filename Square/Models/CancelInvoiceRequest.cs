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
    /// CancelInvoiceRequest.
    /// </summary>
    public class CancelInvoiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelInvoiceRequest"/> class.
        /// </summary>
        /// <param name="version">version.</param>
        public CancelInvoiceRequest(
            int version)
        {
            this.Version = version;
        }

        /// <summary>
        /// The version of the [invoice]($m/Invoice) to cancel.
        /// If you do not know the version, you can call
        /// [GetInvoice]($e/Invoices/GetInvoice) or [ListInvoices]($e/Invoices/ListInvoices).
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
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is CancelInvoiceRequest other &&
                this.Version.Equals(other.Version);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1350501489;
            hashCode += this.Version.GetHashCode();

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
            var builder = new Builder(
                this.Version);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int version;

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
            /// Builds class object.
            /// </summary>
            /// <returns> CancelInvoiceRequest. </returns>
            public CancelInvoiceRequest Build()
            {
                return new CancelInvoiceRequest(
                    this.version);
            }
        }
    }
}