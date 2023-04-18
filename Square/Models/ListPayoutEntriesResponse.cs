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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// ListPayoutEntriesResponse.
    /// </summary>
    public class ListPayoutEntriesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListPayoutEntriesResponse"/> class.
        /// </summary>
        /// <param name="payoutEntries">payout_entries.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public ListPayoutEntriesResponse(
            IList<Models.PayoutEntry> payoutEntries = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.PayoutEntries = payoutEntries;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The requested list of payout entries, ordered with the given or default sort order.
        /// </summary>
        [JsonProperty("payout_entries", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.PayoutEntry> PayoutEntries { get; }

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

            return $"ListPayoutEntriesResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListPayoutEntriesResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.PayoutEntries == null && other.PayoutEntries == null) || (this.PayoutEntries?.Equals(other.PayoutEntries) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1074469266;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.PayoutEntries, this.Cursor, this.Errors);

            return hashCode;
        }
        internal ListPayoutEntriesResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.PayoutEntries = {(this.PayoutEntries == null ? "null" : $"[{string.Join(", ", this.PayoutEntries)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PayoutEntries(this.PayoutEntries)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.PayoutEntry> payoutEntries;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// PayoutEntries.
             /// </summary>
             /// <param name="payoutEntries"> payoutEntries. </param>
             /// <returns> Builder. </returns>
            public Builder PayoutEntries(IList<Models.PayoutEntry> payoutEntries)
            {
                this.payoutEntries = payoutEntries;
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
            /// <returns> ListPayoutEntriesResponse. </returns>
            public ListPayoutEntriesResponse Build()
            {
                return new ListPayoutEntriesResponse(
                    this.payoutEntries,
                    this.cursor,
                    this.errors);
            }
        }
    }
}