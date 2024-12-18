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
    /// ListCustomersRequest.
    /// </summary>
    public class ListCustomersRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCustomersRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        /// <param name="sortField">sort_field.</param>
        /// <param name="sortOrder">sort_order.</param>
        /// <param name="count">count.</param>
        public ListCustomersRequest(
            string cursor = null,
            int? limit = null,
            string sortField = null,
            string sortOrder = null,
            bool? count = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "cursor", false },
                { "limit", false },
                { "count", false }
            };

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
            this.SortField = sortField;
            this.SortOrder = sortOrder;

            if (count != null)
            {
                shouldSerialize["count"] = true;
                this.Count = count;
            }
        }

        internal ListCustomersRequest(
            Dictionary<string, bool> shouldSerialize,
            string cursor = null,
            int? limit = null,
            string sortField = null,
            string sortOrder = null,
            bool? count = null)
        {
            this.shouldSerialize = shouldSerialize;
            Cursor = cursor;
            Limit = limit;
            SortField = sortField;
            SortOrder = sortOrder;
            Count = count;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for your original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results.
        /// If the specified limit is less than 1 or greater than 100, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 100.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Specifies customer attributes as the sort key to customer profiles returned from a search.
        /// </summary>
        [JsonProperty("sort_field", NullValueHandling = NullValueHandling.Ignore)]
        public string SortField { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <summary>
        /// Indicates whether to return the total count of customers in the `count` field of the response.
        /// The default value is `false`.
        /// </summary>
        [JsonProperty("count")]
        public bool? Count { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListCustomersRequest : ({string.Join(", ", toStringOutput)})";
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCount()
        {
            return this.shouldSerialize["count"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ListCustomersRequest other &&
                (this.Cursor == null && other.Cursor == null ||
                 this.Cursor?.Equals(other.Cursor) == true) &&
                (this.Limit == null && other.Limit == null ||
                 this.Limit?.Equals(other.Limit) == true) &&
                (this.SortField == null && other.SortField == null ||
                 this.SortField?.Equals(other.SortField) == true) &&
                (this.SortOrder == null && other.SortOrder == null ||
                 this.SortOrder?.Equals(other.SortOrder) == true) &&
                (this.Count == null && other.Count == null ||
                 this.Count?.Equals(other.Count) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -2144515002;
            hashCode = HashCode.Combine(hashCode, this.Cursor, this.Limit, this.SortField, this.SortOrder, this.Count);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.SortField = {(this.SortField == null ? "null" : this.SortField.ToString())}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder.ToString())}");
            toStringOutput.Add($"this.Count = {(this.Count == null ? "null" : this.Count.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(this.Cursor)
                .Limit(this.Limit)
                .SortField(this.SortField)
                .SortOrder(this.SortOrder)
                .Count(this.Count);
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
                { "count", false },
            };

            private string cursor;
            private int? limit;
            private string sortField;
            private string sortOrder;
            private bool? count;

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
             /// SortField.
             /// </summary>
             /// <param name="sortField"> sortField. </param>
             /// <returns> Builder. </returns>
            public Builder SortField(string sortField)
            {
                this.sortField = sortField;
                return this;
            }

             /// <summary>
             /// SortOrder.
             /// </summary>
             /// <param name="sortOrder"> sortOrder. </param>
             /// <returns> Builder. </returns>
            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

             /// <summary>
             /// Count.
             /// </summary>
             /// <param name="count"> count. </param>
             /// <returns> Builder. </returns>
            public Builder Count(bool? count)
            {
                shouldSerialize["count"] = true;
                this.count = count;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCount()
            {
                this.shouldSerialize["count"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListCustomersRequest. </returns>
            public ListCustomersRequest Build()
            {
                return new ListCustomersRequest(
                    shouldSerialize,
                    this.cursor,
                    this.limit,
                    this.sortField,
                    this.sortOrder,
                    this.count);
            }
        }
    }
}