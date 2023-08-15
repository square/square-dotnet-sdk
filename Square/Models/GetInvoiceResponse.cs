namespace Square.Models
{
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
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// GetInvoiceResponse.
    /// </summary>
    public class GetInvoiceResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoiceResponse"/> class.
        /// </summary>
        /// <param name="invoice">invoice.</param>
        /// <param name="errors">errors.</param>
        public GetInvoiceResponse(
            Models.Invoice invoice = null,
            IList<Models.Error> errors = null)
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

            return $"GetInvoiceResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is GetInvoiceResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Invoice == null && other.Invoice == null) || (this.Invoice?.Equals(other.Invoice) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1352095872;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Invoice, this.Errors);

            return hashCode;
        }
        internal GetInvoiceResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Invoice = {(this.Invoice == null ? "null" : this.Invoice.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Invoice(this.Invoice)
                .Errors(this.Errors);
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
            /// <returns> GetInvoiceResponse. </returns>
            public GetInvoiceResponse Build()
            {
                return new GetInvoiceResponse(
                    this.invoice,
                    this.errors);
            }
        }
    }
}