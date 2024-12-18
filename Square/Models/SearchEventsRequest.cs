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
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// SearchEventsRequest.
    /// </summary>
    public class SearchEventsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchEventsRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        /// <param name="query">query.</param>
        public SearchEventsRequest(
            string cursor = null,
            int? limit = null,
            Models.SearchEventsQuery query = null)
        {
            this.Cursor = cursor;
            this.Limit = limit;
            this.Query = query;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of events for your original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of events to return in a single page. The response might contain fewer events. The default value is 100, which is also the maximum allowed value.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// Default: 100
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// Contains query criteria for the search.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchEventsQuery Query { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchEventsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SearchEventsRequest other &&
                (this.Cursor == null && other.Cursor == null ||
                 this.Cursor?.Equals(other.Cursor) == true) &&
                (this.Limit == null && other.Limit == null ||
                 this.Limit?.Equals(other.Limit) == true) &&
                (this.Query == null && other.Query == null ||
                 this.Query?.Equals(other.Query) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 774681883;
            hashCode = HashCode.Combine(hashCode, this.Cursor, this.Limit, this.Query);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Query = {(this.Query == null ? "null" : this.Query.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(this.Cursor)
                .Limit(this.Limit)
                .Query(this.Query);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private int? limit;
            private Models.SearchEventsQuery query;

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
             /// Query.
             /// </summary>
             /// <param name="query"> query. </param>
             /// <returns> Builder. </returns>
            public Builder Query(Models.SearchEventsQuery query)
            {
                this.query = query;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchEventsRequest. </returns>
            public SearchEventsRequest Build()
            {
                return new SearchEventsRequest(
                    this.cursor,
                    this.limit,
                    this.query);
            }
        }
    }
}