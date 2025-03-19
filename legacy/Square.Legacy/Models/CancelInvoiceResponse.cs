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
    /// CancelInvoiceResponse.
    /// </summary>
    public class CancelInvoiceResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelInvoiceResponse"/> class.
        /// </summary>
        /// <param name="invoice">invoice.</param>
        /// <param name="errors">errors.</param>
        public CancelInvoiceResponse(
            Models.Invoice invoice = null,
            IList<Models.Error> errors = null
        )
        {
            this.Invoice = invoice;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Stores information about an invoice. You use the Invoices API to create and manage
        /// invoices. For more information, see [Invoices API Overview](https://developer.squareup.com/docs/invoices-api/overview).
        /// </summary>
        [JsonProperty("invoice", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Invoice Invoice { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CancelInvoiceResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CancelInvoiceResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Invoice == null && other.Invoice == null
                    || this.Invoice?.Equals(other.Invoice) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1339431050;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Invoice, this.Errors);

            return hashCode;
        }

        internal CancelInvoiceResponse ContextSetter(HttpContext context)
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
                $"this.Invoice = {(this.Invoice == null ? "null" : this.Invoice.ToString())}"
            );
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Invoice(this.Invoice).Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Invoice invoice;
            private IList<Models.Error> errors;

            /// <summary>
            /// Invoice.
            /// </summary>
            /// <param name="invoice"> invoice. </param>
            /// <returns> Builder. </returns>
            public Builder Invoice(Models.Invoice invoice)
            {
                this.invoice = invoice;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> CancelInvoiceResponse. </returns>
            public CancelInvoiceResponse Build()
            {
                return new CancelInvoiceResponse(this.invoice, this.errors);
            }
        }
    }
}
