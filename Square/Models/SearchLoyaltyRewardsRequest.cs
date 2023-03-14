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
    /// SearchLoyaltyRewardsRequest.
    /// </summary>
    public class SearchLoyaltyRewardsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchLoyaltyRewardsRequest"/> class.
        /// </summary>
        /// <param name="query">query.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        public SearchLoyaltyRewardsRequest(
            Models.SearchLoyaltyRewardsRequestLoyaltyRewardQuery query = null,
            int? limit = null,
            string cursor = null)
        {
            this.Query = query;
            this.Limit = limit;
            this.Cursor = cursor;
        }

        /// <summary>
        /// The set of search requirements.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchLoyaltyRewardsRequestLoyaltyRewardQuery Query { get; }

        /// <summary>
        /// The maximum number of results to return in the response. The default value is 30.
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

            return $"SearchLoyaltyRewardsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchLoyaltyRewardsRequest other &&
                ((this.Query == null && other.Query == null) || (this.Query?.Equals(other.Query) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -218195523;
            hashCode = HashCode.Combine(this.Query, this.Limit, this.Cursor);

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
            private Models.SearchLoyaltyRewardsRequestLoyaltyRewardQuery query;
            private int? limit;
            private string cursor;

             /// <summary>
             /// Query.
             /// </summary>
             /// <param name="query"> query. </param>
             /// <returns> Builder. </returns>
            public Builder Query(Models.SearchLoyaltyRewardsRequestLoyaltyRewardQuery query)
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
            /// <returns> SearchLoyaltyRewardsRequest. </returns>
            public SearchLoyaltyRewardsRequest Build()
            {
                return new SearchLoyaltyRewardsRequest(
                    this.query,
                    this.limit,
                    this.cursor);
            }
        }
    }
}