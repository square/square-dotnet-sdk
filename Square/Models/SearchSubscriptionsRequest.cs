
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
    public class SearchSubscriptionsRequest 
    {
        public SearchSubscriptionsRequest(string cursor = null,
            int? limit = null,
            Models.SearchSubscriptionsQuery query = null)
        {
            Cursor = cursor;
            Limit = limit;
            Query = query;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The upper limit on the number of subscriptions to return 
        /// in the response. 
        /// Default: `200`
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// Represents a query (including filtering criteria) used to search for subscriptions.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchSubscriptionsQuery Query { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchSubscriptionsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"Limit = {(Limit == null ? "null" : Limit.ToString())}");
            toStringOutput.Add($"Query = {(Query == null ? "null" : Query.ToString())}");
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

            return obj is SearchSubscriptionsRequest other &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((Limit == null && other.Limit == null) || (Limit?.Equals(other.Limit) == true)) &&
                ((Query == null && other.Query == null) || (Query?.Equals(other.Query) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 193071717;

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (Limit != null)
            {
               hashCode += Limit.GetHashCode();
            }

            if (Query != null)
            {
               hashCode += Query.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .Limit(Limit)
                .Query(Query);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private int? limit;
            private Models.SearchSubscriptionsQuery query;



            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder Query(Models.SearchSubscriptionsQuery query)
            {
                this.query = query;
                return this;
            }

            public SearchSubscriptionsRequest Build()
            {
                return new SearchSubscriptionsRequest(cursor,
                    limit,
                    query);
            }
        }
    }
}