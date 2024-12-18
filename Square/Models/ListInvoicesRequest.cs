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
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// ListInvoicesRequest.
    /// </summary>
    public class ListInvoicesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListInvoicesRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        public ListInvoicesRequest(
            string locationId,
            string cursor = null,
            int? limit = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "cursor", false },
                { "limit", false }
            };
            this.LocationId = locationId;

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

        internal ListInvoicesRequest(
            Dictionary<string, bool> shouldSerialize,
            string locationId,
            string cursor = null,
            int? limit = null)
        {
            this.shouldSerialize = shouldSerialize;
            LocationId = locationId;
            Cursor = cursor;
            Limit = limit;
        }

        /// <summary>
        /// The ID of the location for which to list invoices.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for your original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of invoices to return (200 is the maximum `limit`).
        /// If not provided, the server uses a default limit of 100 invoices.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListInvoicesRequest : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ListInvoicesRequest other &&
                (this.LocationId == null && other.LocationId == null ||
                 this.LocationId?.Equals(other.LocationId) == true) &&
                (this.Cursor == null && other.Cursor == null ||
                 this.Cursor?.Equals(other.Cursor) == true) &&
                (this.Limit == null && other.Limit == null ||
                 this.Limit?.Equals(other.Limit) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1549280345;
            hashCode = HashCode.Combine(hashCode, this.LocationId, this.Cursor, this.Limit);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LocationId)
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
                { "cursor", false },
                { "limit", false },
            };

            private string locationId;
            private string cursor;
            private int? limit;

            /// <summary>
            /// Initialize Builder for ListInvoicesRequest.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            public Builder(
                string locationId)
            {
                this.locationId = locationId;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListInvoicesRequest. </returns>
            public ListInvoicesRequest Build()
            {
                return new ListInvoicesRequest(
                    shouldSerialize,
                    this.locationId,
                    this.cursor,
                    this.limit);
            }
        }
    }
}