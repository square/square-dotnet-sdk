
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
        [JsonProperty("catalog_object_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CatalogObjectIds { get; }

        /// <summary>
        /// The filter to return results by `Location` ID. 
        /// This filter is applicable only when set. The default is null.
        /// </summary>
        [JsonProperty("location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// The filter to return results with their `calculated_at` value 
        /// after the given time as specified in an RFC 3339 timestamp. 
        /// The default value is the UNIX epoch of (`1970-01-01T00:00:00Z`).
        /// </summary>
        [JsonProperty("updated_after", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAfter { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The filter to return results by `InventoryState`. The filter is only applicable when set.
        /// Ignored are untracked states of `NONE`, `SOLD`, and `UNLINKED_RETURN`.
        /// The default is null.
        /// </summary>
        [JsonProperty("states", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> States { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveInventoryCountsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CatalogObjectIds = {(CatalogObjectIds == null ? "null" : $"[{ string.Join(", ", CatalogObjectIds)} ]")}");
            toStringOutput.Add($"LocationIds = {(LocationIds == null ? "null" : $"[{ string.Join(", ", LocationIds)} ]")}");
            toStringOutput.Add($"UpdatedAfter = {(UpdatedAfter == null ? "null" : UpdatedAfter == string.Empty ? "" : UpdatedAfter)}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"States = {(States == null ? "null" : $"[{ string.Join(", ", States)} ]")}");
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

            return obj is BatchRetrieveInventoryCountsRequest other &&
                ((CatalogObjectIds == null && other.CatalogObjectIds == null) || (CatalogObjectIds?.Equals(other.CatalogObjectIds) == true)) &&
                ((LocationIds == null && other.LocationIds == null) || (LocationIds?.Equals(other.LocationIds) == true)) &&
                ((UpdatedAfter == null && other.UpdatedAfter == null) || (UpdatedAfter?.Equals(other.UpdatedAfter) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((States == null && other.States == null) || (States?.Equals(other.States) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1765897747;

            if (CatalogObjectIds != null)
            {
               hashCode += CatalogObjectIds.GetHashCode();
            }

            if (LocationIds != null)
            {
               hashCode += LocationIds.GetHashCode();
            }

            if (UpdatedAfter != null)
            {
               hashCode += UpdatedAfter.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (States != null)
            {
               hashCode += States.GetHashCode();
            }

            return hashCode;
        }

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
            private IList<string> catalogObjectIds;
            private IList<string> locationIds;
            private string updatedAfter;
            private string cursor;
            private IList<string> states;



            public Builder CatalogObjectIds(IList<string> catalogObjectIds)
            {
                this.catalogObjectIds = catalogObjectIds;
                return this;
            }

            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

            public Builder UpdatedAfter(string updatedAfter)
            {
                this.updatedAfter = updatedAfter;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder States(IList<string> states)
            {
                this.states = states;
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