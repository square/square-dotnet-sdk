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
    /// ListPaymentRefundsResponse.
    /// </summary>
    public class ListPaymentRefundsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListPaymentRefundsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="refunds">refunds.</param>
        /// <param name="cursor">cursor.</param>
        public ListPaymentRefundsResponse(
            IList<Models.Error> errors = null,
            IList<Models.PaymentRefund> refunds = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.Refunds = refunds;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The list of requested refunds.
        /// </summary>
        [JsonProperty("refunds", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.PaymentRefund> Refunds { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If empty,
        /// this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListPaymentRefundsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ListPaymentRefundsResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Refunds == null && other.Refunds == null ||
                 this.Refunds?.Equals(other.Refunds) == true) &&
                (this.Cursor == null && other.Cursor == null ||
                 this.Cursor?.Equals(other.Cursor) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 94523183;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Refunds, this.Cursor);

            return hashCode;
        }

        internal ListPaymentRefundsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Refunds = {(this.Refunds == null ? "null" : $"[{string.Join(", ", this.Refunds)} ]")}");
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Refunds(this.Refunds)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.PaymentRefund> refunds;
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
             /// Refunds.
             /// </summary>
             /// <param name="refunds"> refunds. </param>
             /// <returns> Builder. </returns>
            public Builder Refunds(IList<Models.PaymentRefund> refunds)
            {
                this.refunds = refunds;
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
            /// <returns> ListPaymentRefundsResponse. </returns>
            public ListPaymentRefundsResponse Build()
            {
                return new ListPaymentRefundsResponse(
                    this.errors,
                    this.refunds,
                    this.cursor);
            }
        }
    }
}