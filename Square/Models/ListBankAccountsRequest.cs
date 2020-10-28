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
    public class ListBankAccountsRequest 
    {
        public ListBankAccountsRequest(string cursor = null,
            int? limit = null,
            string locationId = null)
        {
            Cursor = cursor;
            Limit = limit;
            LocationId = locationId;
        }

        /// <summary>
        /// The pagination cursor returned by a previous call to this endpoint.
        /// Use it in the next `ListBankAccounts` request to retrieve the next set 
        /// of results.
        /// See the [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Upper limit on the number of bank accounts to return in the response. 
        /// Currently, 1000 is the largest supported limit. You can specify a limit 
        /// of up to 1000 bank accounts. This is also the default limit.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// Location ID. You can specify this optional filter 
        /// to retrieve only the linked bank accounts belonging to a specific location.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .Limit(Limit)
                .LocationId(LocationId);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private int? limit;
            private string locationId;



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

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public ListBankAccountsRequest Build()
            {
                return new ListBankAccountsRequest(cursor,
                    limit,
                    locationId);
            }
        }
    }
}