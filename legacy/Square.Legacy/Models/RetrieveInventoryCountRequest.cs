using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// RetrieveInventoryCountRequest.
    /// </summary>
    public class RetrieveInventoryCountRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveInventoryCountRequest"/> class.
        /// </summary>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="cursor">cursor.</param>
        public RetrieveInventoryCountRequest(string locationIds = null, string cursor = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_ids", false },
                { "cursor", false },
            };

            if (locationIds != null)
            {
                shouldSerialize["location_ids"] = true;
                this.LocationIds = locationIds;
            }

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }
        }

        internal RetrieveInventoryCountRequest(
            Dictionary<string, bool> shouldSerialize,
            string locationIds = null,
            string cursor = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            LocationIds = locationIds;
            Cursor = cursor;
        }

        /// <summary>
        /// The [Location](entity:Location) IDs to look up as a comma-separated
        /// list. An empty list queries all locations.
        /// </summary>
        [JsonProperty("location_ids")]
        public string LocationIds { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RetrieveInventoryCountRequest : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is RetrieveInventoryCountRequest other
                && (
                    this.LocationIds == null && other.LocationIds == null
                    || this.LocationIds?.Equals(other.LocationIds) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -618098554;
            hashCode = HashCode.Combine(hashCode, this.LocationIds, this.Cursor);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationIds = {this.LocationIds ?? "null"}");
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().LocationIds(this.LocationIds).Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_ids", false },
                { "cursor", false },
            };

            private string locationIds;
            private string cursor;

            /// <summary>
            /// LocationIds.
            /// </summary>
            /// <param name="locationIds"> locationIds. </param>
            /// <returns> Builder. </returns>
            public Builder LocationIds(string locationIds)
            {
                shouldSerialize["location_ids"] = true;
                this.locationIds = locationIds;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationIds()
            {
                this.shouldSerialize["location_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveInventoryCountRequest. </returns>
            public RetrieveInventoryCountRequest Build()
            {
                return new RetrieveInventoryCountRequest(
                    shouldSerialize,
                    this.locationIds,
                    this.cursor
                );
            }
        }
    }
}
