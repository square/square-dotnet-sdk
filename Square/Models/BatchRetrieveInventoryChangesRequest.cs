
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
        [JsonProperty("catalog_object_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CatalogObjectIds { get; }

        /// <summary>
        /// The filter to return results by `Location` ID. 
        /// The filter is only applicable when set. The default value is null.
        /// </summary>
        [JsonProperty("location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// The filter to return results by `InventoryChangeType` values other than `TRANSFER`.
        /// The default value is `[PHYSICAL_COUNT, ADJUSTMENT]`.
        /// </summary>
        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Types { get; }

        /// <summary>
        /// The filter to return `ADJUSTMENT` query results by
        /// `InventoryState`. This filter is only applied when set.
        /// The default value is null.
        /// </summary>
        [JsonProperty("states", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> States { get; }

        /// <summary>
        /// The filter to return results with their `calculated_at` value  
        /// after the given time as specified in an RFC 3339 timestamp. 
        /// The default value is the UNIX epoch of (`1970-01-01T00:00:00Z`).
        /// </summary>
        [JsonProperty("updated_after", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAfter { get; }

        /// <summary>
        /// The filter to return results with their `created_at` or `calculated_at` value  
        /// strictly before the given time as specified in an RFC 3339 timestamp. 
        /// The default value is the UNIX epoch of (`1970-01-01T00:00:00Z`).
        /// </summary>
        [JsonProperty("updated_before", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBefore { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveInventoryChangesRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CatalogObjectIds = {(CatalogObjectIds == null ? "null" : $"[{ string.Join(", ", CatalogObjectIds)} ]")}");
            toStringOutput.Add($"LocationIds = {(LocationIds == null ? "null" : $"[{ string.Join(", ", LocationIds)} ]")}");
            toStringOutput.Add($"Types = {(Types == null ? "null" : $"[{ string.Join(", ", Types)} ]")}");
            toStringOutput.Add($"States = {(States == null ? "null" : $"[{ string.Join(", ", States)} ]")}");
            toStringOutput.Add($"UpdatedAfter = {(UpdatedAfter == null ? "null" : UpdatedAfter == string.Empty ? "" : UpdatedAfter)}");
            toStringOutput.Add($"UpdatedBefore = {(UpdatedBefore == null ? "null" : UpdatedBefore == string.Empty ? "" : UpdatedBefore)}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
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

            return obj is BatchRetrieveInventoryChangesRequest other &&
                ((CatalogObjectIds == null && other.CatalogObjectIds == null) || (CatalogObjectIds?.Equals(other.CatalogObjectIds) == true)) &&
                ((LocationIds == null && other.LocationIds == null) || (LocationIds?.Equals(other.LocationIds) == true)) &&
                ((Types == null && other.Types == null) || (Types?.Equals(other.Types) == true)) &&
                ((States == null && other.States == null) || (States?.Equals(other.States) == true)) &&
                ((UpdatedAfter == null && other.UpdatedAfter == null) || (UpdatedAfter?.Equals(other.UpdatedAfter) == true)) &&
                ((UpdatedBefore == null && other.UpdatedBefore == null) || (UpdatedBefore?.Equals(other.UpdatedBefore) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 870378021;

            if (CatalogObjectIds != null)
            {
               hashCode += CatalogObjectIds.GetHashCode();
            }

            if (LocationIds != null)
            {
               hashCode += LocationIds.GetHashCode();
            }

            if (Types != null)
            {
               hashCode += Types.GetHashCode();
            }

            if (States != null)
            {
               hashCode += States.GetHashCode();
            }

            if (UpdatedAfter != null)
            {
               hashCode += UpdatedAfter.GetHashCode();
            }

            if (UpdatedBefore != null)
            {
               hashCode += UpdatedBefore.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            return hashCode;
        }

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
            private IList<string> catalogObjectIds;
            private IList<string> locationIds;
            private IList<string> types;
            private IList<string> states;
            private string updatedAfter;
            private string updatedBefore;
            private string cursor;



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

            public Builder Types(IList<string> types)
            {
                this.types = types;
                return this;
            }

            public Builder States(IList<string> states)
            {
                this.states = states;
                return this;
            }

            public Builder UpdatedAfter(string updatedAfter)
            {
                this.updatedAfter = updatedAfter;
                return this;
            }

            public Builder UpdatedBefore(string updatedBefore)
            {
                this.updatedBefore = updatedBefore;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
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