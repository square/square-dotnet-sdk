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
    /// DeleteInvoiceRequest.
    /// </summary>
    public class DeleteInvoiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteInvoiceRequest"/> class.
        /// </summary>
        /// <param name="version">version.</param>
        public DeleteInvoiceRequest(
            int? version = null)
        {
            this.Version = version;
        }

        /// <summary>
        /// The version of the [invoice]($m/Invoice) to delete.
        /// If you do not know the version, you can call [GetInvoice]($e/Invoices/GetInvoice) or
        /// [ListInvoices]($e/Invoices/ListInvoices).
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeleteInvoiceRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is DeleteInvoiceRequest other &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -231963317;

            if (this.Version != null)
            {
               hashCode += this.Version.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Version(this.Version);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int? version;

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeleteInvoiceRequest. </returns>
            public DeleteInvoiceRequest Build()
            {
                return new DeleteInvoiceRequest(
                    this.version);
            }
        }
    }
}