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
    /// ListCashDrawerShiftEventsResponse.
    /// </summary>
    public class ListCashDrawerShiftEventsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCashDrawerShiftEventsResponse"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        /// <param name="cashDrawerShiftEvents">cash_drawer_shift_events.</param>
        public ListCashDrawerShiftEventsResponse(
            string cursor = null,
            IList<Models.Error> errors = null,
            IList<Models.CashDrawerShiftEvent> cashDrawerShiftEvents = null)
        {
            this.Cursor = cursor;
            this.Errors = errors;
            this.CashDrawerShiftEvents = cashDrawerShiftEvents;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Opaque cursor for fetching the next page. Cursor is not present in
        /// the last page of results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// All of the events (payments, refunds, etc.) for a cash drawer during
        /// the shift.
        /// </summary>
        [JsonProperty("cash_drawer_shift_events", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CashDrawerShiftEvent> CashDrawerShiftEvents { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListCashDrawerShiftEventsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ListCashDrawerShiftEventsResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Cursor == null && other.Cursor == null ||
                 this.Cursor?.Equals(other.Cursor) == true) &&
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.CashDrawerShiftEvents == null && other.CashDrawerShiftEvents == null ||
                 this.CashDrawerShiftEvents?.Equals(other.CashDrawerShiftEvents) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 249739654;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Cursor, this.Errors, this.CashDrawerShiftEvents);

            return hashCode;
        }

        internal ListCashDrawerShiftEventsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.CashDrawerShiftEvents = {(this.CashDrawerShiftEvents == null ? "null" : $"[{string.Join(", ", this.CashDrawerShiftEvents)} ]")}");
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
                .CashDrawerShiftEvents(this.CashDrawerShiftEvents);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private IList<Models.Error> errors;
            private IList<Models.CashDrawerShiftEvent> cashDrawerShiftEvents;

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
             /// CashDrawerShiftEvents.
             /// </summary>
             /// <param name="cashDrawerShiftEvents"> cashDrawerShiftEvents. </param>
             /// <returns> Builder. </returns>
            public Builder CashDrawerShiftEvents(IList<Models.CashDrawerShiftEvent> cashDrawerShiftEvents)
            {
                this.cashDrawerShiftEvents = cashDrawerShiftEvents;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListCashDrawerShiftEventsResponse. </returns>
            public ListCashDrawerShiftEventsResponse Build()
            {
                return new ListCashDrawerShiftEventsResponse(
                    this.cursor,
                    this.errors,
                    this.cashDrawerShiftEvents);
            }
        }
    }
}