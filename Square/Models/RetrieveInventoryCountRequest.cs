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
    public class RetrieveInventoryCountRequest 
    {
        public RetrieveInventoryCountRequest(string locationIds = null,
            string cursor = null)
        {
            LocationIds = locationIds;
            Cursor = cursor;
        }

        /// <summary>
        /// The [Location](#type-location) IDs to look up as a comma-separated
        /// list. An empty list queries all locations.
        /// </summary>
        [JsonProperty("location_ids")]
        public string LocationIds { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// See the [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationIds(LocationIds)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private string locationIds;
            private string cursor;

            public Builder() { }
            public Builder LocationIds(string value)
            {
                locationIds = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public RetrieveInventoryCountRequest Build()
            {
                return new RetrieveInventoryCountRequest(locationIds,
                    cursor);
            }
        }
    }
}