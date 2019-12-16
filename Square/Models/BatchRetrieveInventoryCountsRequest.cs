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
            string cursor = null)
        {
            CatalogObjectIds = catalogObjectIds;
            LocationIds = locationIds;
            UpdatedAfter = updatedAfter;
            Cursor = cursor;
        }

        /// <summary>
        /// Filters results by `CatalogObject` ID.
        /// Only applied when set. Default: unset.
        /// </summary>
        [JsonProperty("catalog_object_ids")]
        public IList<string> CatalogObjectIds { get; }

        /// <summary>
        /// Filters results by `Location` ID. Only
        /// applied when set. Default: unset.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// Provided as an RFC 3339 timestamp. Returns results whose
        /// `calculated_at` value is after the given time. Default: UNIX epoch
        /// (`1970-01-01T00:00:00Z`).
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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogObjectIds(CatalogObjectIds)
                .LocationIds(LocationIds)
                .UpdatedAfter(UpdatedAfter)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<string> catalogObjectIds;
            private IList<string> locationIds;
            private string updatedAfter;
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

            public BatchRetrieveInventoryCountsRequest Build()
            {
                return new BatchRetrieveInventoryCountsRequest(catalogObjectIds,
                    locationIds,
                    updatedAfter,
                    cursor);
            }
        }
    }
} 