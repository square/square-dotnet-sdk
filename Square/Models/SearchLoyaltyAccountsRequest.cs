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
    /// SearchLoyaltyAccountsRequest.
    /// </summary>
    public class SearchLoyaltyAccountsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchLoyaltyAccountsRequest"/> class.
        /// </summary>
        /// <param name="query">query.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        public SearchLoyaltyAccountsRequest(
            Models.SearchLoyaltyAccountsRequestLoyaltyAccountQuery query = null,
            int? limit = null,
            string cursor = null)
        {
            this.Query = query;
            this.Limit = limit;
            this.Cursor = cursor;
        }

        /// <summary>
        /// The search criteria for the loyalty accounts.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchLoyaltyAccountsRequestLoyaltyAccountQuery Query { get; }

        /// <summary>
        /// The maximum number of results to include in the response.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to
        /// this endpoint. Provide this to retrieve the next set of
        /// results for the original query.
        /// For more information,
        /// see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchLoyaltyAccountsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchLoyaltyAccountsRequest other &&
                ((this.Query == null && other.Query == null) || (this.Query?.Equals(other.Query) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1708395605;

            if (this.Query != null)
            {
               hashCode += this.Query.GetHashCode();
            }

            if (this.Limit != null)
            {
               hashCode += this.Limit.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Query = {(this.Query == null ? "null" : this.Query.ToString())}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Query(this.Query)
                .Limit(this.Limit)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.SearchLoyaltyAccountsRequestLoyaltyAccountQuery query;
            private int? limit;
            private string cursor;

             /// <summary>
             /// Query.
             /// </summary>
             /// <param name="query"> query. </param>
             /// <returns> Builder. </returns>
            public Builder Query(Models.SearchLoyaltyAccountsRequestLoyaltyAccountQuery query)
            {
                this.query = query;
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
            /// <returns> SearchLoyaltyAccountsRequest. </returns>
            public SearchLoyaltyAccountsRequest Build()
            {
                return new SearchLoyaltyAccountsRequest(
                    this.query,
                    this.limit,
                    this.cursor);
            }
        }
    }
}