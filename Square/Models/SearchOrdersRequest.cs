namespace Square.Models
{
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

    /// <summary>
    /// SearchOrdersRequest.
    /// </summary>
    public class SearchOrdersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersRequest"/> class.
        /// </summary>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="query">query.</param>
        /// <param name="limit">limit.</param>
        /// <param name="returnEntries">return_entries.</param>
        public SearchOrdersRequest(
            IList<string> locationIds = null,
            string cursor = null,
            Models.SearchOrdersQuery query = null,
            int? limit = null,
            bool? returnEntries = null)
        {
            this.LocationIds = locationIds;
            this.Cursor = cursor;
            this.Query = query;
            this.Limit = limit;
            this.ReturnEntries = returnEntries;
        }

        /// <summary>
        /// The location IDs for the orders to query. All locations must belong to
        /// the same merchant.
        /// Min: 1 location ID.
        /// Max: 10 location IDs.
        /// </summary>
        [JsonProperty("location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for your original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Contains query criteria for the search.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchOrdersQuery Query { get; }

        /// <summary>
        /// The maximum number of results to be returned in a single page. It is
        /// possible to receive fewer results than the specified limit on a given page.
        /// Default: `500`
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// A Boolean that controls the format of the search results. If `true`,
        /// `SearchOrders` returns [OrderEntry](entity:OrderEntry) objects. If `false`, `SearchOrders`
        /// returns complete order objects.
        /// Default: `false`.
        /// </summary>
        [JsonProperty("return_entries", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReturnEntries { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is SearchOrdersRequest other &&                ((this.LocationIds == null && other.LocationIds == null) || (this.LocationIds?.Equals(other.LocationIds) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Query == null && other.Query == null) || (this.Query?.Equals(other.Query) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.ReturnEntries == null && other.ReturnEntries == null) || (this.ReturnEntries?.Equals(other.ReturnEntries) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 455417059;
            hashCode = HashCode.Combine(this.LocationIds, this.Cursor, this.Query, this.Limit, this.ReturnEntries);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.Query = {(this.Query == null ? "null" : this.Query.ToString())}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.ReturnEntries = {(this.ReturnEntries == null ? "null" : this.ReturnEntries.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationIds(this.LocationIds)
                .Cursor(this.Cursor)
                .Query(this.Query)
                .Limit(this.Limit)
                .ReturnEntries(this.ReturnEntries);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> locationIds;
            private string cursor;
            private Models.SearchOrdersQuery query;
            private int? limit;
            private bool? returnEntries;

             /// <summary>
             /// LocationIds.
             /// </summary>
             /// <param name="locationIds"> locationIds. </param>
             /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
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
             /// Query.
             /// </summary>
             /// <param name="query"> query. </param>
             /// <returns> Builder. </returns>
            public Builder Query(Models.SearchOrdersQuery query)
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
             /// ReturnEntries.
             /// </summary>
             /// <param name="returnEntries"> returnEntries. </param>
             /// <returns> Builder. </returns>
            public Builder ReturnEntries(bool? returnEntries)
            {
                this.returnEntries = returnEntries;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchOrdersRequest. </returns>
            public SearchOrdersRequest Build()
            {
                return new SearchOrdersRequest(
                    this.locationIds,
                    this.cursor,
                    this.query,
                    this.limit,
                    this.returnEntries);
            }
        }
    }
}