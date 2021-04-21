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
    /// BatchRetrieveInventoryCountsRequest.
    /// </summary>
    public class BatchRetrieveInventoryCountsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRetrieveInventoryCountsRequest"/> class.
        /// </summary>
        /// <param name="catalogObjectIds">catalog_object_ids.</param>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="updatedAfter">updated_after.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="states">states.</param>
        public BatchRetrieveInventoryCountsRequest(
            IList<string> catalogObjectIds = null,
            IList<string> locationIds = null,
            string updatedAfter = null,
            string cursor = null,
            IList<string> states = null)
        {
            this.CatalogObjectIds = catalogObjectIds;
            this.LocationIds = locationIds;
            this.UpdatedAfter = updatedAfter;
            this.Cursor = cursor;
            this.States = states;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveInventoryCountsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is BatchRetrieveInventoryCountsRequest other &&
                ((this.CatalogObjectIds == null && other.CatalogObjectIds == null) || (this.CatalogObjectIds?.Equals(other.CatalogObjectIds) == true)) &&
                ((this.LocationIds == null && other.LocationIds == null) || (this.LocationIds?.Equals(other.LocationIds) == true)) &&
                ((this.UpdatedAfter == null && other.UpdatedAfter == null) || (this.UpdatedAfter?.Equals(other.UpdatedAfter) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.States == null && other.States == null) || (this.States?.Equals(other.States) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1765897747;

            if (this.CatalogObjectIds != null)
            {
               hashCode += this.CatalogObjectIds.GetHashCode();
            }

            if (this.LocationIds != null)
            {
               hashCode += this.LocationIds.GetHashCode();
            }

            if (this.UpdatedAfter != null)
            {
               hashCode += this.UpdatedAfter.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            if (this.States != null)
            {
               hashCode += this.States.GetHashCode();
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
            toStringOutput.Add($"this.UpdatedAfter = {(this.UpdatedAfter == null ? "null" : this.UpdatedAfter == string.Empty ? "" : this.UpdatedAfter)}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.States = {(this.States == null ? "null" : $"[{string.Join(", ", this.States)} ]")}");
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
                .UpdatedAfter(this.UpdatedAfter)
                .Cursor(this.Cursor)
                .States(this.States);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> catalogObjectIds;
            private IList<string> locationIds;
            private string updatedAfter;
            private string cursor;
            private IList<string> states;

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
            /// Builds class object.
            /// </summary>
            /// <returns> BatchRetrieveInventoryCountsRequest. </returns>
            public BatchRetrieveInventoryCountsRequest Build()
            {
                return new BatchRetrieveInventoryCountsRequest(
                    this.catalogObjectIds,
                    this.locationIds,
                    this.updatedAfter,
                    this.cursor,
                    this.states);
            }
        }
    }
}