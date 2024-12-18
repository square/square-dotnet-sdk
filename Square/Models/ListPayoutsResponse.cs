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
    /// ListPayoutsResponse.
    /// </summary>
    public class ListPayoutsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListPayoutsResponse"/> class.
        /// </summary>
        /// <param name="payouts">payouts.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public ListPayoutsResponse(
            IList<Models.Payout> payouts = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.Payouts = payouts;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The requested list of payouts.
        /// </summary>
        [JsonProperty("payouts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Payout> Payouts { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If empty, this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

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
            return $"ListPayoutsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ListPayoutsResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Payouts == null && other.Payouts == null ||
                 this.Payouts?.Equals(other.Payouts) == true) &&
                (this.Cursor == null && other.Cursor == null ||
                 this.Cursor?.Equals(other.Cursor) == true) &&
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -440325397;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Payouts, this.Cursor, this.Errors);

            return hashCode;
        }

        internal ListPayoutsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Payouts = {(this.Payouts == null ? "null" : $"[{string.Join(", ", this.Payouts)} ]")}");
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Payouts(this.Payouts)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Payout> payouts;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// Payouts.
             /// </summary>
             /// <param name="payouts"> payouts. </param>
             /// <returns> Builder. </returns>
            public Builder Payouts(IList<Models.Payout> payouts)
            {
                this.payouts = payouts;
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
            /// <returns> ListPayoutsResponse. </returns>
            public ListPayoutsResponse Build()
            {
                return new ListPayoutsResponse(
                    this.payouts,
                    this.cursor,
                    this.errors);
            }
        }
    }
}