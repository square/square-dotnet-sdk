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
    public class BatchRetrieveInventoryCountsRequest 
    {
        public BatchRetrieveInventoryCountsRequest(IList<string> catalogObjectIds = null,
            IList<string> locationIds = null,
            string updatedAfter = null,
            string cursor = null,
            IList<string> states = null)
        {
            CatalogObjectIds = catalogObjectIds;
            LocationIds = locationIds;
            UpdatedAfter = updatedAfter;
            Cursor = cursor;
            States = states;
        }

        /// <summary>
        /// The filter to return results by `CatalogObject` ID.
        /// The filter is applicable only when set.  The default is null.
        /// </summary>
        [JsonProperty("catalog_object_ids")]
        public IList<string> CatalogObjectIds { get; }

        /// <summary>
        /// The filter to return results by `Location` ID. 
        /// This filter is applicable only when set. The default is null.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// The filter to return results with their `calculated_at` value 
        /// after the given time as specified in an RFC 3339 timestamp. 
        /// The default value is the UNIX epoch of (`1970-01-01T00:00:00Z`).
        /// </summary>
        [JsonProperty("updated_after")]
        public string UpdatedAfter { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The filter to return results by `InventoryState`. The filter is only applicable when set.
        /// Ignored are untracked states of `NONE`, `SOLD`, and `UNLINKED_RETURN`.
        /// The default is null.
        /// See [InventoryState](#type-inventorystate) for possible values
        /// </summary>
        [JsonProperty("states")]
        public IList<string> States { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogObjectIds(CatalogObjectIds)
                .LocationIds(LocationIds)
                .UpdatedAfter(UpdatedAfter)
                .Cursor(Cursor)
                .States(States);
            return builder;
        }

        public class Builder
        {
            private IList<string> catalogObjectIds = new List<string>();
            private IList<string> locationIds = new List<string>();
            private string updatedAfter;
            private string cursor;
            private IList<string> states = new List<string>();

            public Builder() { }
            public Builder CatalogObjectIds(IList<string> value)
            {
                catalogObjectIds = value;
                return this;
            }

            public Builder LocationIds(IList<string> value)
            {
                locationIds = value;
                return this;
            }

            public Builder UpdatedAfter(string value)
            {
                updatedAfter = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder States(IList<string> value)
            {
                states = value;
                return this;
            }

            public BatchRetrieveInventoryCountsRequest Build()
            {
                return new BatchRetrieveInventoryCountsRequest(catalogObjectIds,
                    locationIds,
                    updatedAfter,
                    cursor,
                    states);
            }
        }
    }
}