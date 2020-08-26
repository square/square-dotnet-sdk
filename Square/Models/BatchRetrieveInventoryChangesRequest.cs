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
    public class BatchRetrieveInventoryChangesRequest 
    {
        public BatchRetrieveInventoryChangesRequest(IList<string> catalogObjectIds = null,
            IList<string> locationIds = null,
            IList<string> types = null,
            IList<string> states = null,
            string updatedAfter = null,
            string updatedBefore = null,
            string cursor = null)
        {
            CatalogObjectIds = catalogObjectIds;
            LocationIds = locationIds;
            Types = types;
            States = states;
            UpdatedAfter = updatedAfter;
            UpdatedBefore = updatedBefore;
            Cursor = cursor;
        }

        /// <summary>
        /// The filter to return results by `CatalogObject` ID.
        /// The filter is only applicable when set. The default value is null.
        /// </summary>
        [JsonProperty("catalog_object_ids")]
        public IList<string> CatalogObjectIds { get; }

        /// <summary>
        /// The filter to return results by `Location` ID. 
        /// The filter is only applicable when set. The default value is null.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// The filter to return results by `InventoryChangeType` values other than `TRANSFER`.
        /// The default value is `[PHYSICAL_COUNT, ADJUSTMENT]`.
        /// See [InventoryChangeType](#type-inventorychangetype) for possible values
        /// </summary>
        [JsonProperty("types")]
        public IList<string> Types { get; }

        /// <summary>
        /// The filter to return `ADJUSTMENT` query results by
        /// `InventoryState`. This filter is only applied when set.
        /// The default value is null.
        /// See [InventoryState](#type-inventorystate) for possible values
        /// </summary>
        [JsonProperty("states")]
        public IList<string> States { get; }

        /// <summary>
        /// The filter to return results with their `calculated_at` value  
        /// after the given time as specified in an RFC 3339 timestamp. 
        /// The default value is the UNIX epoch of (`1970-01-01T00:00:00Z`).
        /// </summary>
        [JsonProperty("updated_after")]
        public string UpdatedAfter { get; }

        /// <summary>
        /// The filter to return results with their `created_at` or `calculated_at` value  
        /// strictly before the given time as specified in an RFC 3339 timestamp. 
        /// The default value is the UNIX epoch of (`1970-01-01T00:00:00Z`).
        /// </summary>
        [JsonProperty("updated_before")]
        public string UpdatedBefore { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogObjectIds(CatalogObjectIds)
                .LocationIds(LocationIds)
                .Types(Types)
                .States(States)
                .UpdatedAfter(UpdatedAfter)
                .UpdatedBefore(UpdatedBefore)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<string> catalogObjectIds = new List<string>();
            private IList<string> locationIds = new List<string>();
            private IList<string> types = new List<string>();
            private IList<string> states = new List<string>();
            private string updatedAfter;
            private string updatedBefore;
            private string cursor;

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

            public Builder Types(IList<string> value)
            {
                types = value;
                return this;
            }

            public Builder States(IList<string> value)
            {
                states = value;
                return this;
            }

            public Builder UpdatedAfter(string value)
            {
                updatedAfter = value;
                return this;
            }

            public Builder UpdatedBefore(string value)
            {
                updatedBefore = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public BatchRetrieveInventoryChangesRequest Build()
            {
                return new BatchRetrieveInventoryChangesRequest(catalogObjectIds,
                    locationIds,
                    types,
                    states,
                    updatedAfter,
                    updatedBefore,
                    cursor);
            }
        }
    }
}