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
    /// ListBreakTypesRequest.
    /// </summary>
    public class ListBreakTypesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBreakTypesRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        public ListBreakTypesRequest(
            string locationId = null,
            int? limit = null,
            string cursor = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "limit", false },
                { "cursor", false },
            };

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }
        }

        internal ListBreakTypesRequest(
            Dictionary<string, bool> shouldSerialize,
            string locationId = null,
            int? limit = null,
            string cursor = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            LocationId = locationId;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Filter the returned `BreakType` results to only those that are associated with the
        /// specified location.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The maximum number of `BreakType` results to return per page. The number can range between 1
        /// and 200. The default is 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// A pointer to the next page of `BreakType` results to fetch.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListBreakTypesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLimit()
        {
            return this.shouldSerialize["limit"];
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

            return obj is ListBreakTypesRequest other
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                )
                && (
                    this.Limit == null && other.Limit == null
                    || this.Limit?.Equals(other.Limit) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1110829719;
            hashCode = HashCode.Combine(hashCode, this.LocationId, this.Limit, this.Cursor);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add(
                $"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}"
            );
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(this.LocationId)
                .Limit(this.Limit)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "limit", false },
                { "cursor", false },
            };

            private string locationId;
            private int? limit;
            private string cursor;

            /// <summary>
            /// LocationId.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
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
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
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
            /// <returns> ListBreakTypesRequest. </returns>
            public ListBreakTypesRequest Build()
            {
                return new ListBreakTypesRequest(
                    shouldSerialize,
                    this.locationId,
                    this.limit,
                    this.cursor
                );
            }
        }
    }
}
