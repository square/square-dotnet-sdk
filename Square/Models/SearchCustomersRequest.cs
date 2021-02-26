
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
    public class SearchCustomersRequest 
    {
        public SearchCustomersRequest(string cursor = null,
            long? limit = null,
            Models.CustomerQuery query = null)
        {
            Cursor = cursor;
            Limit = limit;
            Query = query;
        }

        /// <summary>
        /// Include the pagination cursor in subsequent calls to this endpoint to retrieve
        /// the next set of results associated with the original query.
        /// See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// A limit on the number of results to be returned in a single page.
        /// The limit is advisory - the implementation may return more or fewer results.
        /// If the supplied limit is negative, zero, or is higher than the maximum limit
        /// of 100, it will be ignored.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? Limit { get; }

        /// <summary>
        /// Represents a query (including filtering criteria, sorting criteria, or both) used to search
        /// for customer profiles.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerQuery Query { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCustomersRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchCustomersRequest other &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((Limit == null && other.Limit == null) || (Limit?.Equals(other.Limit) == true)) &&
                ((Query == null && other.Query == null) || (Query?.Equals(other.Query) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 236271593;

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
            private long? limit;
            private Models.CustomerQuery query;



            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Limit(long? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder Query(Models.CustomerQuery query)
            {
                this.query = query;
                return this;
            }

            public SearchCustomersRequest Build()
            {
                return new SearchCustomersRequest(cursor,
                    limit,
                    query);
            }
        }
    }
}