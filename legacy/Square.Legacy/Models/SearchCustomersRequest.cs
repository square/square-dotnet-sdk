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
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// SearchCustomersRequest.
    /// </summary>
    public class SearchCustomersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCustomersRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        /// <param name="query">query.</param>
        /// <param name="count">count.</param>
        public SearchCustomersRequest(
            string cursor = null,
            long? limit = null,
            Models.CustomerQuery query = null,
            bool? count = null
        )
        {
            this.Cursor = cursor;
            this.Limit = limit;
            this.Query = query;
            this.Count = count;
        }

        /// <summary>
        /// Include the pagination cursor in subsequent calls to this endpoint to retrieve
        /// the next set of results associated with the original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results.
        /// If the specified limit is invalid, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 100.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? Limit { get; }

        /// <summary>
        /// Represents filtering and sorting criteria for a [SearchCustomers]($e/Customers/SearchCustomers) request.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerQuery Query { get; }

        /// <summary>
        /// Indicates whether to return the total count of matching customers in the `count` field of the response.
        /// The default value is `false`.
        /// </summary>
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Count { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchCustomersRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SearchCustomersRequest other
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                )
                && (
                    this.Limit == null && other.Limit == null
                    || this.Limit?.Equals(other.Limit) == true
                )
                && (
                    this.Query == null && other.Query == null
                    || this.Query?.Equals(other.Query) == true
                )
                && (
                    this.Count == null && other.Count == null
                    || this.Count?.Equals(other.Count) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 113405763;
            hashCode = HashCode.Combine(hashCode, this.Cursor, this.Limit, this.Query, this.Count);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
            toStringOutput.Add(
                $"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}"
            );
            toStringOutput.Add(
                $"this.Query = {(this.Query == null ? "null" : this.Query.ToString())}"
            );
            toStringOutput.Add(
                $"this.Count = {(this.Count == null ? "null" : this.Count.ToString())}"
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
                .Limit(this.Limit)
                .Query(this.Query)
                .Count(this.Count);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private long? limit;
            private Models.CustomerQuery query;
            private bool? count;

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
            public Builder Limit(long? limit)
            {
                this.limit = limit;
                return this;
            }

            /// <summary>
            /// Query.
            /// </summary>
            /// <param name="query"> query. </param>
            /// <returns> Builder. </returns>
            public Builder Query(Models.CustomerQuery query)
            {
                this.query = query;
                return this;
            }

            /// <summary>
            /// Count.
            /// </summary>
            /// <param name="count"> count. </param>
            /// <returns> Builder. </returns>
            public Builder Count(bool? count)
            {
                this.count = count;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchCustomersRequest. </returns>
            public SearchCustomersRequest Build()
            {
                return new SearchCustomersRequest(this.cursor, this.limit, this.query, this.count);
            }
        }
    }
}
