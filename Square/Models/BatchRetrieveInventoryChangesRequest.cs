namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// BatchRetrieveInventoryChangesRequest.
    /// </summary>
    public class BatchRetrieveInventoryChangesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRetrieveInventoryChangesRequest"/> class.
        /// </summary>
        /// <param name="catalogObjectIds">catalog_object_ids.</param>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="types">types.</param>
        /// <param name="states">states.</param>
        /// <param name="updatedAfter">updated_after.</param>
        /// <param name="updatedBefore">updated_before.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        public BatchRetrieveInventoryChangesRequest(
            IList<string> catalogObjectIds = null,
            IList<string> locationIds = null,
            IList<string> types = null,
            IList<string> states = null,
            string updatedAfter = null,
            string updatedBefore = null,
            string cursor = null,
            int? limit = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "catalog_object_ids", false },
                { "location_ids", false },
                { "types", false },
                { "states", false },
                { "updated_after", false },
                { "updated_before", false },
                { "cursor", false },
                { "limit", false }
            };

            if (catalogObjectIds != null)
            {
                shouldSerialize["catalog_object_ids"] = true;
                this.CatalogObjectIds = catalogObjectIds;
            }

            if (locationIds != null)
            {
                shouldSerialize["location_ids"] = true;
                this.LocationIds = locationIds;
            }

            if (types != null)
            {
                shouldSerialize["types"] = true;
                this.Types = types;
            }

            if (states != null)
            {
                shouldSerialize["states"] = true;
                this.States = states;
            }

            if (updatedAfter != null)
            {
                shouldSerialize["updated_after"] = true;
                this.UpdatedAfter = updatedAfter;
            }

            if (updatedBefore != null)
            {
                shouldSerialize["updated_before"] = true;
                this.UpdatedBefore = updatedBefore;
            }

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

        }
        internal BatchRetrieveInventoryChangesRequest(Dictionary<string, bool> shouldSerialize,
            IList<string> catalogObjectIds = null,
            IList<string> locationIds = null,
            IList<string> types = null,
            IList<string> states = null,
            string updatedAfter = null,
            string updatedBefore = null,
            string cursor = null,
            int? limit = null)
        {
            this.shouldSerialize = shouldSerialize;
            CatalogObjectIds = catalogObjectIds;
            LocationIds = locationIds;
            Types = types;
            States = states;
            UpdatedAfter = updatedAfter;
            UpdatedBefore = updatedBefore;
            Cursor = cursor;
            Limit = limit;
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
        /// </summary>
        [JsonProperty("types")]
        public IList<string> Types { get; }

        /// <summary>
        /// The filter to return `ADJUSTMENT` query results by
        /// `InventoryState`. This filter is only applied when set.
        /// The default value is null.
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

        /// <summary>
        /// The number of [records]($m/InventoryChange) to return.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveInventoryChangesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogObjectIds()
        {
            return this.shouldSerialize["catalog_object_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationIds()
        {
            return this.shouldSerialize["location_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTypes()
        {
            return this.shouldSerialize["types"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStates()
        {
            return this.shouldSerialize["states"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUpdatedAfter()
        {
            return this.shouldSerialize["updated_after"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUpdatedBefore()
        {
            return this.shouldSerialize["updated_before"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLimit()
        {
            return this.shouldSerialize["limit"];
        }

        /// <inheritdoc/>
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
                ((this.CatalogObjectIds == null && other.CatalogObjectIds == null) || (this.CatalogObjectIds?.Equals(other.CatalogObjectIds) == true)) &&
                ((this.LocationIds == null && other.LocationIds == null) || (this.LocationIds?.Equals(other.LocationIds) == true)) &&
                ((this.Types == null && other.Types == null) || (this.Types?.Equals(other.Types) == true)) &&
                ((this.States == null && other.States == null) || (this.States?.Equals(other.States) == true)) &&
                ((this.UpdatedAfter == null && other.UpdatedAfter == null) || (this.UpdatedAfter?.Equals(other.UpdatedAfter) == true)) &&
                ((this.UpdatedBefore == null && other.UpdatedBefore == null) || (this.UpdatedBefore?.Equals(other.UpdatedBefore) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1313386924;
            hashCode = HashCode.Combine(this.CatalogObjectIds, this.LocationIds, this.Types, this.States, this.UpdatedAfter, this.UpdatedBefore, this.Cursor);

            hashCode = HashCode.Combine(hashCode, this.Limit);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CatalogObjectIds = {(this.CatalogObjectIds == null ? "null" : $"[{string.Join(", ", this.CatalogObjectIds)} ]")}");
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.Types = {(this.Types == null ? "null" : $"[{string.Join(", ", this.Types)} ]")}");
            toStringOutput.Add($"this.States = {(this.States == null ? "null" : $"[{string.Join(", ", this.States)} ]")}");
            toStringOutput.Add($"this.UpdatedAfter = {(this.UpdatedAfter == null ? "null" : this.UpdatedAfter == string.Empty ? "" : this.UpdatedAfter)}");
            toStringOutput.Add($"this.UpdatedBefore = {(this.UpdatedBefore == null ? "null" : this.UpdatedBefore == string.Empty ? "" : this.UpdatedBefore)}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogObjectIds(this.CatalogObjectIds)
                .LocationIds(this.LocationIds)
                .Types(this.Types)
                .States(this.States)
                .UpdatedAfter(this.UpdatedAfter)
                .UpdatedBefore(this.UpdatedBefore)
                .Cursor(this.Cursor)
                .Limit(this.Limit);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "catalog_object_ids", false },
                { "location_ids", false },
                { "types", false },
                { "states", false },
                { "updated_after", false },
                { "updated_before", false },
                { "cursor", false },
                { "limit", false },
            };

            private IList<string> catalogObjectIds;
            private IList<string> locationIds;
            private IList<string> types;
            private IList<string> states;
            private string updatedAfter;
            private string updatedBefore;
            private string cursor;
            private int? limit;

             /// <summary>
             /// CatalogObjectIds.
             /// </summary>
             /// <param name="catalogObjectIds"> catalogObjectIds. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectIds(IList<string> catalogObjectIds)
            {
                shouldSerialize["catalog_object_ids"] = true;
                this.catalogObjectIds = catalogObjectIds;
                return this;
            }

             /// <summary>
             /// LocationIds.
             /// </summary>
             /// <param name="locationIds"> locationIds. </param>
             /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                shouldSerialize["location_ids"] = true;
                this.locationIds = locationIds;
                return this;
            }

             /// <summary>
             /// Types.
             /// </summary>
             /// <param name="types"> types. </param>
             /// <returns> Builder. </returns>
            public Builder Types(IList<string> types)
            {
                shouldSerialize["types"] = true;
                this.types = types;
                return this;
            }

             /// <summary>
             /// States.
             /// </summary>
             /// <param name="states"> states. </param>
             /// <returns> Builder. </returns>
            public Builder States(IList<string> states)
            {
                shouldSerialize["states"] = true;
                this.states = states;
                return this;
            }

             /// <summary>
             /// UpdatedAfter.
             /// </summary>
             /// <param name="updatedAfter"> updatedAfter. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAfter(string updatedAfter)
            {
                shouldSerialize["updated_after"] = true;
                this.updatedAfter = updatedAfter;
                return this;
            }

             /// <summary>
             /// UpdatedBefore.
             /// </summary>
             /// <param name="updatedBefore"> updatedBefore. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedBefore(string updatedBefore)
            {
                shouldSerialize["updated_before"] = true;
                this.updatedBefore = updatedBefore;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                shouldSerialize["cursor"] = true;
                this.cursor = cursor;
                return this;
            }

             /// <summary>
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                shouldSerialize["limit"] = true;
                this.limit = limit;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogObjectIds()
            {
                this.shouldSerialize["catalog_object_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationIds()
            {
                this.shouldSerialize["location_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTypes()
            {
                this.shouldSerialize["types"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStates()
            {
                this.shouldSerialize["states"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUpdatedAfter()
            {
                this.shouldSerialize["updated_after"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUpdatedBefore()
            {
                this.shouldSerialize["updated_before"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchRetrieveInventoryChangesRequest. </returns>
            public BatchRetrieveInventoryChangesRequest Build()
            {
                return new BatchRetrieveInventoryChangesRequest(shouldSerialize,
                    this.catalogObjectIds,
                    this.locationIds,
                    this.types,
                    this.states,
                    this.updatedAfter,
                    this.updatedBefore,
                    this.cursor,
                    this.limit);
            }
        }
    }
}