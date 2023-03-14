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
    /// SearchTerminalCheckoutsRequest.
    /// </summary>
    public class SearchTerminalCheckoutsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTerminalCheckoutsRequest"/> class.
        /// </summary>
        /// <param name="query">query.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        public SearchTerminalCheckoutsRequest(
            Models.TerminalCheckoutQuery query = null,
            string cursor = null,
            int? limit = null)
        {
            this.Query = query;
            this.Cursor = cursor;
            this.Limit = limit;
        }

        /// <summary>
        /// Gets or sets Query.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalCheckoutQuery Query { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for the original query.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Limits the number of results returned for a single request.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchTerminalCheckoutsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchTerminalCheckoutsRequest other &&
                ((this.Query == null && other.Query == null) || (this.Query?.Equals(other.Query) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1621232276;
            hashCode = HashCode.Combine(this.Query, this.Cursor, this.Limit);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Query = {(this.Query == null ? "null" : this.Query.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Query(this.Query)
                .Cursor(this.Cursor)
                .Limit(this.Limit);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.TerminalCheckoutQuery query;
            private string cursor;
            private int? limit;

             /// <summary>
             /// Query.
             /// </summary>
             /// <param name="query"> query. </param>
             /// <returns> Builder. </returns>
            public Builder Query(Models.TerminalCheckoutQuery query)
            {
                this.query = query;
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
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchTerminalCheckoutsRequest. </returns>
            public SearchTerminalCheckoutsRequest Build()
            {
                return new SearchTerminalCheckoutsRequest(
                    this.query,
                    this.cursor,
                    this.limit);
            }
        }
    }
}