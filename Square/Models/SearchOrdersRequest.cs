
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class SearchOrdersRequest 
    {
        public SearchOrdersRequest(IList<string> locationIds = null,
            string cursor = null,
            Models.SearchOrdersQuery query = null,
            int? limit = null,
            bool? returnEntries = null)
        {
            LocationIds = locationIds;
            Cursor = cursor;
            Query = query;
            Limit = limit;
            ReturnEntries = returnEntries;
        }

        /// <summary>
        /// The location IDs for the orders to query. All locations must belong to
        /// the same merchant.
        /// Min: 1 location IDs.
        /// Max: 10 location IDs.
        /// </summary>
        [JsonProperty("location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Contains query criteria for the search.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchOrdersQuery Query { get; }

        /// <summary>
        /// Maximum number of results to be returned in a single page. It is
        /// possible to receive fewer results than the specified limit on a given page.
        /// Default: `500`
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// Boolean that controls the format of the search results. If `true`,
        /// SearchOrders will return [`OrderEntry`](#type-orderentry) objects. If `false`, SearchOrders
        /// will return complete Order objects.
        /// Default: `false`.
        /// </summary>
        [JsonProperty("return_entries", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReturnEntries { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LocationIds = {(LocationIds == null ? "null" : $"[{ string.Join(", ", LocationIds)} ]")}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"Query = {(Query == null ? "null" : Query.ToString())}");
            toStringOutput.Add($"Limit = {(Limit == null ? "null" : Limit.ToString())}");
            toStringOutput.Add($"ReturnEntries = {(ReturnEntries == null ? "null" : ReturnEntries.ToString())}");
        }

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

            return obj is SearchOrdersRequest other &&
                ((LocationIds == null && other.LocationIds == null) || (LocationIds?.Equals(other.LocationIds) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((Query == null && other.Query == null) || (Query?.Equals(other.Query) == true)) &&
                ((Limit == null && other.Limit == null) || (Limit?.Equals(other.Limit) == true)) &&
                ((ReturnEntries == null && other.ReturnEntries == null) || (ReturnEntries?.Equals(other.ReturnEntries) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 455417059;

            if (LocationIds != null)
            {
               hashCode += LocationIds.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (Query != null)
            {
               hashCode += Query.GetHashCode();
            }

            if (Limit != null)
            {
               hashCode += Limit.GetHashCode();
            }

            if (ReturnEntries != null)
            {
               hashCode += ReturnEntries.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationIds(LocationIds)
                .Cursor(Cursor)
                .Query(Query)
                .Limit(Limit)
                .ReturnEntries(ReturnEntries);
            return builder;
        }

        public class Builder
        {
            private IList<string> locationIds;
            private string cursor;
            private Models.SearchOrdersQuery query;
            private int? limit;
            private bool? returnEntries;



            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Query(Models.SearchOrdersQuery query)
            {
                this.query = query;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder ReturnEntries(bool? returnEntries)
            {
                this.returnEntries = returnEntries;
                return this;
            }

            public SearchOrdersRequest Build()
            {
                return new SearchOrdersRequest(locationIds,
                    cursor,
                    query,
                    limit,
                    returnEntries);
            }
        }
    }
}