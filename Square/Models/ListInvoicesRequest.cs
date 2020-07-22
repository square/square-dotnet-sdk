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
    public class ListInvoicesRequest 
    {
        public ListInvoicesRequest(string locationId,
            string cursor = null,
            int? limit = null)
        {
            LocationId = locationId;
            Cursor = cursor;
            Limit = limit;
        }

        /// <summary>
        /// The ID of the location for which to list invoices.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint. 
        /// Provide this cursor to retrieve the next set of results for your original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of invoices to return (200 is the maximum `limit`). 
        /// If not provided, the server 
        /// uses a default limit of 100 invoices.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationId)
                .Cursor(Cursor)
                .Limit(Limit);
            return builder;
        }

        public class Builder
        {
            private string locationId;
            private string cursor;
            private int? limit;

            public Builder(string locationId)
            {
                this.locationId = locationId;
            }
            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Limit(int? value)
            {
                limit = value;
                return this;
            }

            public ListInvoicesRequest Build()
            {
                return new ListInvoicesRequest(locationId,
                    cursor,
                    limit);
            }
        }
    }
}