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

namespace Square.Models
{
    /// <summary>
    /// ListPaymentLinksResponse.
    /// </summary>
    public class ListPaymentLinksResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListPaymentLinksResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="paymentLinks">payment_links.</param>
        /// <param name="cursor">cursor.</param>
        public ListPaymentLinksResponse(
            IList<Models.Error> errors = null,
            IList<Models.PaymentLink> paymentLinks = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.PaymentLinks = paymentLinks;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The list of payment links.
        /// </summary>
        [JsonProperty("payment_links", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.PaymentLink> PaymentLinks { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can use in a subsequent request
        /// to retrieve the next set of gift cards. If a cursor is not present, this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListPaymentLinksResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ListPaymentLinksResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.PaymentLinks == null && other.PaymentLinks == null) || (this.PaymentLinks?.Equals(other.PaymentLinks) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -477927456;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.PaymentLinks, this.Cursor);

            return hashCode;
        }
        internal ListPaymentLinksResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.PaymentLinks = {(this.PaymentLinks == null ? "null" : $"[{string.Join(", ", this.PaymentLinks)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .PaymentLinks(this.PaymentLinks)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.PaymentLink> paymentLinks;
            private string cursor;

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
             /// PaymentLinks.
             /// </summary>
             /// <param name="paymentLinks"> paymentLinks. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentLinks(IList<Models.PaymentLink> paymentLinks)
            {
                this.paymentLinks = paymentLinks;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListPaymentLinksResponse. </returns>
            public ListPaymentLinksResponse Build()
            {
                return new ListPaymentLinksResponse(
                    this.errors,
                    this.paymentLinks,
                    this.cursor);
            }
        }
    }
}