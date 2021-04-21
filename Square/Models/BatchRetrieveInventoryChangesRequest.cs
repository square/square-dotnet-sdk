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
        public BatchRetrieveInventoryChangesRequest(
            IList<string> catalogObjectIds = null,
            IList<string> locationIds = null,
            IList<string> types = null,
            IList<string> states = null,
            string updatedAfter = null,
            string updatedBefore = null,
            string cursor = null)
        {
            this.CatalogObjectIds = catalogObjectIds;
            this.LocationIds = locationIds;
            this.Types = types;
            this.States = states;
            this.UpdatedAfter = updatedAfter;
            this.UpdatedBefore = updatedBefore;
            this.Cursor = cursor;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveInventoryChangesRequest : ({string.Join(", ", toStringOutput)})";
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
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 870378021;

            if (this.CatalogObjectIds != null)
            {
               hashCode += this.CatalogObjectIds.GetHashCode();
            }

            if (this.LocationIds != null)
            {
               hashCode += this.LocationIds.GetHashCode();
            }

            if (this.Types != null)
            {
               hashCode += this.Types.GetHashCode();
            }

            if (this.States != null)
            {
               hashCode += this.States.GetHashCode();
            }

            if (this.UpdatedAfter != null)
            {
               hashCode += this.UpdatedAfter.GetHashCode();
            }

            if (this.UpdatedBefore != null)
            {
               hashCode += this.UpdatedBefore.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

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
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> catalogObjectIds;
            private IList<string> locationIds;
            private IList<string> types;
            private IList<string> states;
            private string updatedAfter;
            private string updatedBefore;
            private string cursor;

             /// <summary>
             /// CatalogObjectIds.
             /// </summary>
             /// <param name="catalogObjectIds"> catalogObjectIds. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectIds(IList<string> catalogObjectIds)
            {
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
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchRetrieveInventoryChangesRequest. </returns>
            public BatchRetrieveInventoryChangesRequest Build()
            {
                return new BatchRetrieveInventoryChangesRequest(
                    this.catalogObjectIds,
                    this.locationIds,
                    this.types,
                    this.states,
                    this.updatedAfter,
                    this.updatedBefore,
                    this.cursor);
            }
        }
    }
}