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
    /// ListCashDrawerShiftsResponse.
    /// </summary>
    public class ListCashDrawerShiftsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCashDrawerShiftsResponse"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        /// <param name="cashDrawerShifts">cash_drawer_shifts.</param>
        public ListCashDrawerShiftsResponse(
            string cursor = null,
            IList<Models.Error> errors = null,
            IList<Models.CashDrawerShiftSummary> cashDrawerShifts = null
        )
        {
            this.Cursor = cursor;
            this.Errors = errors;
            this.CashDrawerShifts = cashDrawerShifts;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Opaque cursor for fetching the next page of results. Cursor is not
        /// present in the last page of results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// A collection of CashDrawerShiftSummary objects for shifts that match
        /// the query.
        /// </summary>
        [JsonProperty("cash_drawer_shifts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CashDrawerShiftSummary> CashDrawerShifts { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListCashDrawerShiftsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ListCashDrawerShiftsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.CashDrawerShifts == null && other.CashDrawerShifts == null
                    || this.CashDrawerShifts?.Equals(other.CashDrawerShifts) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 84684055;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Cursor, this.Errors, this.CashDrawerShifts);

            return hashCode;
        }

        internal ListCashDrawerShiftsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.CashDrawerShifts = {(this.CashDrawerShifts == null ? "null" : $"[{string.Join(", ", this.CashDrawerShifts)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(this.Cursor)
                .Errors(this.Errors)
                .CashDrawerShifts(this.CashDrawerShifts);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private IList<Models.Error> errors;
            private IList<Models.CashDrawerShiftSummary> cashDrawerShifts;

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
            /// CashDrawerShifts.
            /// </summary>
            /// <param name="cashDrawerShifts"> cashDrawerShifts. </param>
            /// <returns> Builder. </returns>
            public Builder CashDrawerShifts(IList<Models.CashDrawerShiftSummary> cashDrawerShifts)
            {
                this.cashDrawerShifts = cashDrawerShifts;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListCashDrawerShiftsResponse. </returns>
            public ListCashDrawerShiftsResponse Build()
            {
                return new ListCashDrawerShiftsResponse(
                    this.cursor,
                    this.errors,
                    this.cashDrawerShifts
                );
            }
        }
    }
}
