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
    /// SearchSubscriptionsRequest.
    /// </summary>
    public class SearchSubscriptionsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchSubscriptionsRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        /// <param name="query">query.</param>
        /// <param name="include">include.</param>
        public SearchSubscriptionsRequest(
            string cursor = null,
            int? limit = null,
            Models.SearchSubscriptionsQuery query = null,
            IList<string> include = null)
        {
            this.Cursor = cursor;
            this.Limit = limit;
            this.Query = query;
            this.Include = include;
        }

        /// <summary>
        /// When the total number of resulting subscriptions exceeds the limit of a paged response,
        /// specify the cursor returned from a preceding response here to fetch the next set of results.
        /// If the cursor is unset, the response contains the last page of the results.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The upper limit on the number of subscriptions to return
        /// in a paged response.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// Represents a query, consisting of specified query expressions, used to search for subscriptions.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchSubscriptionsQuery Query { get; }

        /// <summary>
        /// A query parameter to specify related information to be included in the response.
        /// The supported query parameter values are:
        /// - `actions`: to include scheduled actions on the targeted subscriptions.
        /// </summary>
        [JsonProperty("include", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Include { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchSubscriptionsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchSubscriptionsRequest other &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Query == null && other.Query == null) || (this.Query?.Equals(other.Query) == true)) &&
                ((this.Include == null && other.Include == null) || (this.Include?.Equals(other.Include) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 363002383;
            hashCode = HashCode.Combine(this.Cursor, this.Limit, this.Query, this.Include);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Query = {(this.Query == null ? "null" : this.Query.ToString())}");
            toStringOutput.Add($"this.Include = {(this.Include == null ? "null" : $"[{string.Join(", ", this.Include)} ]")}");
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
                .Include(this.Include);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private int? limit;
            private Models.SearchSubscriptionsQuery query;
            private IList<string> include;

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
            public Builder Query(Models.SearchSubscriptionsQuery query)
            {
                this.query = query;
                return this;
            }

             /// <summary>
             /// Include.
             /// </summary>
             /// <param name="include"> include. </param>
             /// <returns> Builder. </returns>
            public Builder Include(IList<string> include)
            {
                this.include = include;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchSubscriptionsRequest. </returns>
            public SearchSubscriptionsRequest Build()
            {
                return new SearchSubscriptionsRequest(
                    this.cursor,
                    this.limit,
                    this.query,
                    this.include);
            }
        }
    }
}